#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfSchedule
{
    /// <summary>
    /// Month Cell Data Template Selector class
    /// </summary>
    public class MonthCellDataTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MonthCellDataTemplateSelector" /> class.
        /// </summary>
        public MonthCellDataTemplateSelector()
        {
            this.MonthAppointmentTemplate = new DataTemplate(typeof(MonthAppointmentTemplate));
            this.MonthCellDatesTemplate = new DataTemplate(typeof(MonthCellDatesTemplate));
        }

        /// <summary>
        /// Gets or sets Month Appointment Template
        /// </summary>
        public DataTemplate MonthAppointmentTemplate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Month Cell Dates Template
        /// </summary>
        public DataTemplate MonthCellDatesTemplate
        {
            get;
            set;
        }
        
        /// <summary>
        /// Template selection method
        /// </summary>
        /// <param name="item">return the object</param>
        /// <param name="container">return the bindable object</param>
        /// <returns>return the template</returns>
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var sfSchedule = container as Syncfusion.SfSchedule.XForms.SfSchedule;
            if (sfSchedule == null)
            {
                return null;
            }

            if (sfSchedule != null)
            {
                var appointments = (IList)(item as MonthCellItem).Appointments;

                foreach (var appointment in appointments)
                {
                    CustomizationViewModel.ScheduleAppointment = appointment as ScheduleAppointment;
                    return this.MonthAppointmentTemplate;
                }

                CustomizationViewModel.MonthCellItem = item as MonthCellItem;
                return this.MonthCellDatesTemplate;
            }
            else
            {
                return null;
            }
        }
    }
}