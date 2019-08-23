#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
                    if (Device.RuntimePlatform == "UWP" && Device.Idiom == TargetIdiom.Desktop)
                    {
                        button.Source = ImagePathConverter.GetImageSource("SampleBrowser.SfSchedule.conference_schedule.png");
                    }
                    else
                    {
                        button.Source = "conference_schedule.png";
                    }
                }
                else if (CustomizationViewModel.ScheduleAppointment.Subject == "System Troubleshoot")
                {
                    if (Device.RuntimePlatform == "UWP" && Device.Idiom == TargetIdiom.Desktop)
                    {
                        button.Source = ImagePathConverter.GetImageSource("SampleBrowser.SfSchedule.troubleshoot_schedule.png");
                    }
                    else
                    {
                        button.Source = "troubleshoot_schedule.png";
                    }
                }
                else if (CustomizationViewModel.ScheduleAppointment.Subject == "Checkup")
                {
                    if (Device.RuntimePlatform == "UWP" && Device.Idiom == TargetIdiom.Desktop)
                    {
                        button.Source = ImagePathConverter.GetImageSource("SampleBrowser.SfSchedule.stethoscope_schedule.png");
                    }
                    else
                    {
                        button.Source = "stethoscope_schedule.png";
                    }
                }
                else if (CustomizationViewModel.ScheduleAppointment.Subject == "Jeni's Birthday")
                {
                    if (Device.RuntimePlatform == "UWP" && Device.Idiom == TargetIdiom.Desktop)
                    {
                        button.Source = ImagePathConverter.GetImageSource("SampleBrowser.SfSchedule.cake_schedule.png");
                    }
                    else
                    {
                        button.Source = "cake_schedule.png";
                    }
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