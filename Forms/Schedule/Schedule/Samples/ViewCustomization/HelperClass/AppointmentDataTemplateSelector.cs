#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Globalization;
using SampleBrowser.Core;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfSchedule
{
    /// <summary>
    /// Appointment Data Template Selector class
    /// </summary>
    [Preserve(AllMembers = true)]
    public class AppointmentDataTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppointmentDataTemplateSelector" /> class.
        /// </summary>
        public AppointmentDataTemplateSelector()
        {
            this.DayAppointmentTemplate = new DataTemplate(typeof(DayAppointmentTemplate));
            this.AllDayAppointmentTemplate = new DataTemplate(typeof(AllDayAppointmentTemplate));
        }

        /// <summary>
        /// Gets or sets Day Appointment Template
        /// </summary>
        public DataTemplate DayAppointmentTemplate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets AllDay Appointment Template
        /// </summary>
        public DataTemplate AllDayAppointmentTemplate
        {
            get;
            set;
        }

        /// <summary>
        /// Template method  
        /// </summary>
        /// <param name="item">return the object</param>
        /// <param name="container">return the bindable object</param>
        /// <returns>return the template</returns>
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var schedule = container as Syncfusion.SfSchedule.XForms.SfSchedule;
            if (schedule == null)
            {
                return null;
            }

            if (schedule.ScheduleView == ScheduleView.MonthView)
            {
                return null;
            } 

            if (schedule.ScheduleView == ScheduleView.DayView)
            {
                if (Device.RuntimePlatform == "UWP" || Device.RuntimePlatform == "WPF")
                {
                    return this.DayAppointmentTemplate;
                }
                else
                {
                    if ((item as ScheduleAppointment).IsAllDay)
                    {
                        return this.AllDayAppointmentTemplate;
                    }
                    else
                    {
                        return this.DayAppointmentTemplate;
                    }
                }
            }
            else
            {
                return null;
            }
        }
    }

    /// <summary>
    /// Image format convertor method
    /// </summary>
    public class ImageFormatConverter : IValueConverter
    {
        /// <summary>
        /// Convert method
        /// </summary>
        /// <param name="value">return the object</param>
        /// <param name="targetType">return the target type value</param>
        /// <param name="parameter">return the object</param>
        /// <param name="culture">return the culture value</param>
        /// <returns>return the value</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Device.RuntimePlatform == "UWP" || Device.RuntimePlatform == "WPF")
            {
                return ImagePathConverter.GetImageSource(("SampleBrowser.SfSchedule." + value.ToString() + ".png").ToString());
            }

            return value;
        }
        
        /// <summary>
        /// Convert back method 
        /// </summary>
        /// <param name="value">return the object</param>
        /// <param name="targetType"> return the target type value</param>
        /// <param name="parameter">return the object</param>
        /// <param name="culture">return the culture value</param>
        /// <returns>return the value</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}