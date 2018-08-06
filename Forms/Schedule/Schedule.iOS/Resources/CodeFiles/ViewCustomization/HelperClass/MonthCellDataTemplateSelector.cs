#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections;
using Xamarin.Forms;
using Syncfusion.SfSchedule.XForms;

namespace SampleBrowser.SfSchedule
{
    public class MonthCellDataTemplateSelector : DataTemplateSelector
    {

        public DataTemplate MonthAppointmentTemplate { get; set; }
        public DataTemplate MonthCellDatesTemplate { get; set; }

        public MonthCellDataTemplateSelector()
        {
            MonthAppointmentTemplate = new DataTemplate(typeof(MonthAppointmentTemplate));
            MonthCellDatesTemplate = new DataTemplate(typeof(MonthCellDatesTemplate));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var sfSchedule = (container as Syncfusion.SfSchedule.XForms.SfSchedule);
            if (sfSchedule == null) return null;
            if (sfSchedule != null)
            {
                var appointments = (IList)(item as MonthCellItem).Appointments;

                foreach (var appointment in appointments)
                {
                    CustomizationViewModel.ScheduleAppointment = appointment as ScheduleAppointment;
                    return MonthAppointmentTemplate;
                }
                CustomizationViewModel.MonthCellItem = item as MonthCellItem;
                return MonthCellDatesTemplate;
            }
            else
                return null;
        }
    }
}

