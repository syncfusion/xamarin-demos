#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleBrowser.Core;
using Xamarin.Forms;

namespace SampleBrowser.SfSchedule
{
    /// <summary>
    /// Month Cell Custom View Behavior class
    /// </summary>
    public class MonthCellCustomViewBehavior : Behavior<StackLayout>
    {
        /// <summary>
        /// Begins when the behavior attached to the view 
        /// </summary>
        /// <param name="bindable">bindable value</param>
        protected override void OnAttachedTo(StackLayout bindable)
        {
            base.OnAttachedTo(bindable);
            var button = bindable.FindByName<Image>("Image");
            var label = bindable.FindByName<Label>("label");

            if (CustomizationViewModel.MonthCellItem != null)
            {
                if (CustomizationViewModel.MonthCellItem.IsLeadingDay || CustomizationViewModel.MonthCellItem.IsTrailingDay)
                {
                    label.TextColor = Color.Gray;
                }
                else
                {
                    label.TextColor = Color.Black;
                }
            }

            if (CustomizationViewModel.ScheduleAppointment != null)
            {
                if (CustomizationViewModel.ScheduleAppointment.Subject == "Conference")
                {
                    button.Source = "Conference_schedule.png";
                }
                else if (CustomizationViewModel.ScheduleAppointment.Subject == "System Troubleshoot")
                {
                    button.Source = "Troubleshoot.png";
                }
                else if (CustomizationViewModel.ScheduleAppointment.Subject == "Checkup")
                {
                    button.Source = "Stethoscope.png";
                }
                else if (CustomizationViewModel.ScheduleAppointment.Subject == "Jeni's Birthday")
                {
                    button.Source = "cake_schedule.png";
                }
            }
        }

        /// <summary>
        /// Begins when the behavior attached to the view 
        /// </summary>
        /// <param name="bindable">bindable value</param>
        protected override void OnDetachingFrom(StackLayout bindable)
        {
            base.OnDetachingFrom(bindable);
        }
    }
}