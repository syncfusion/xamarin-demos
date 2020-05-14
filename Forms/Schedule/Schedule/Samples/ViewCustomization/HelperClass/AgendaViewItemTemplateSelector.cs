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
    /// AgendaViewItem  Template Selector class
    /// </summary>
    [Preserve(AllMembers = true)]
    public class AgendaViewItemTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AgendaViewItemTemplateSelector" /> class.
        /// </summary>
        public AgendaViewItemTemplateSelector()
        {
            this.AgendaViewItemTemplate = new DataTemplate(typeof(AgendaViewItemTemplate));
        }

        /// <summary>
        /// Gets or sets Appointment Template
        /// </summary>
        public DataTemplate AgendaViewItemTemplate
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

            if (!(item as ScheduleAppointment).IsAllDay)
                return this.AgendaViewItemTemplate;

            return null;
        }
    }

    /// <summary>
    /// Image format convertor method
    /// </summary>
    public class ImageConverter : IValueConverter
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
            var subject = value.ToString();
            if (subject == "Conference")
                return "Conference_schedule.png";
            else if (subject == "Checkup")
                return "Stethoscope.png";
            else if (subject == "System Troubleshoot")
                return "Troubleshoot.png";
            else if (subject == "Jeni's Birthday")
                return "cake_schedule.png";

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
