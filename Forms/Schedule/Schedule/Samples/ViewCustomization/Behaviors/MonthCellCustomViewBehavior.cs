#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace SampleBrowser.SfSchedule
{
    public class MonthCellCustomViewBehavior : Behavior<StackLayout>
    {
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
                        button.Source = ImagePathConverter.GetImageSource("SampleBrowser.SfSchedule.conference_schedule.png");
                    else
                        button.Source = "conference_schedule.png";
                }
                else if (CustomizationViewModel.ScheduleAppointment.Subject == "System Troubleshoot")
                {
                    if (Device.RuntimePlatform == "UWP" && Device.Idiom == TargetIdiom.Desktop)
                        button.Source = ImagePathConverter.GetImageSource("SampleBrowser.SfSchedule.troubleshoot_schedule.png");
                    else
                        button.Source = "troubleshoot_schedule.png";
                }

                else if (CustomizationViewModel.ScheduleAppointment.Subject == "Checkup")
                {
                    if (Device.RuntimePlatform == "UWP" && Device.Idiom == TargetIdiom.Desktop)
                        button.Source = ImagePathConverter.GetImageSource("SampleBrowser.SfSchedule.stethoscope_schedule.png");
                    else
                        button.Source = "stethoscope_schedule.png";
                }
                else if (CustomizationViewModel.ScheduleAppointment.Subject == "Jeni's Birthday")
                {
                    if (Device.RuntimePlatform == "UWP" && Device.Idiom == TargetIdiom.Desktop)
                        button.Source = ImagePathConverter.GetImageSource("SampleBrowser.SfSchedule.cake_schedule.png");
                    else
                        button.Source = "cake_schedule.png";
                }
            }
        }

        protected override void OnDetachingFrom(StackLayout bindable)
        {
            base.OnDetachingFrom(bindable);
        }
    }
}