#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Globalization;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using SampleBrowser.Core;

namespace SampleBrowser.SfSchedule
{
    [Preserve(AllMembers = true)]
    public class AppointmentDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DayAppointmentTemplate { get; set; }
        public DataTemplate AllDayAppointmentTemplate { get; set; }

        public AppointmentDataTemplateSelector()
        {
            DayAppointmentTemplate = new DataTemplate(typeof(DayAppointmentTemplate));
            AllDayAppointmentTemplate = new DataTemplate(typeof(AllDayAppointmentTemplate));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var schedule = (container as Syncfusion.SfSchedule.XForms.SfSchedule);
            if (schedule == null) return null;
            if (schedule.ScheduleView == ScheduleView.MonthView) return null;
            if (schedule.ScheduleView == ScheduleView.DayView)
            {
                if (Device.RuntimePlatform == "UWP")
                    return DayAppointmentTemplate;
                else
                {
                    if ((item as ScheduleAppointment).IsAllDay)
                        return AllDayAppointmentTemplate;
                    else
                        return DayAppointmentTemplate;
                }
            }
            else
                return null;
        }
    }

    public class ImageFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Device.RuntimePlatform == "UWP")
               return ImagePathConverter.GetImageSource(("SampleBrowser.SfSchedule." + value.ToString() + ".png").ToString());
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}

