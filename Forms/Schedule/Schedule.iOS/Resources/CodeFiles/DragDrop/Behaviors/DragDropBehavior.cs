#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Globalization;

namespace SampleBrowser.SfSchedule
{
    /// <summary>
    /// Drag drop behaviour.
    /// </summary>
    internal class DragDropBehaviour : Behavior<SampleView>
    {
        private Syncfusion.SfSchedule.XForms.SfSchedule schedule;
        private Picker viewPicker;
        private Label label;

        protected override void OnAttachedTo(SampleView bindable)
        {
            base.OnAttachedTo(bindable);

            schedule = bindable.Content.FindByName<Syncfusion.SfSchedule.XForms.SfSchedule>("Schedule");
            
            viewPicker = bindable.PropertyView.FindByName<Picker>("viewPicker");

            label = bindable.Content.FindByName<Label>("labelIndicator");
            label.WidthRequest = schedule.Width;
            label.BackgroundColor = Color.FromHex("#2e2f30");

            if (bindable.GetType().Equals(typeof(RecursiveAppointments)))
                viewPicker.SelectedIndex = 3;
            else if (bindable.GetType().Equals(typeof(ViewCustomization)))
                viewPicker.SelectedIndex = 0;
            else
                viewPicker.SelectedIndex = 2;

            viewPicker.SelectedIndexChanged += ViewPicker_SelectedIndexChanged;
            schedule.AppointmentDrop += Schedule_AppointmentDrop;
            schedule.CellTapped += Schedule_CellTapped;

            SetNonAccessibleBlocks();
        }

        /// <summary>
        /// Schedules the cell tapped.
        /// </summary>
        /// <param name="sender">Sender value.</param>
        /// <param name="e">E value.</param>
        private void Schedule_CellTapped(object sender, CellTappedEventArgs e)
        {
            label.HeightRequest = 0;
        }

        /// <summary>
        /// Schedules the appointment drop.
        /// </summary>
        /// <param name="sender">Sender value.</param>
        /// <param name="e">E value.</param>
        private async void Schedule_AppointmentDrop(object sender, AppointmentDropEventArgs e)
        {
            e.Cancel = false;
            var appointment = e.Appointment as ScheduleAppointment;
            label.Opacity = 1;
            label.HeightRequest = 50;

            if (Device.RuntimePlatform == "Android" || Device.RuntimePlatform == "iOS")
            {
                if (IsInNonAccessRegion(e.DropTime))
                {
                    e.Cancel = true;
                    label.Text = "Cannot be moved to blocked time slots";
                    await label.FadeTo(0, 2000, Easing.SpringIn);
                    label.HeightRequest = 0;
                    return;
                }
            }

            label.Text = GetDroppedLocation(e.DropTime);
            await label.FadeTo(0, 2000, Easing.SpringIn);
            label.HeightRequest = 0;
        }

        /// <summary>
        /// Views the picker selected index changed.
        /// </summary>
        /// <param name="sender">Sender value.</param>
        /// <param name="e">EventArgs value.</param>
        private void ViewPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as Picker).SelectedIndex)
            {
                case 0:
                    schedule.ScheduleView = ScheduleView.DayView;
                    break;
                case 1:
                    schedule.ScheduleView = ScheduleView.WeekView;
                    break;
                case 2:
                    schedule.ScheduleView = ScheduleView.WorkWeekView;
                    break;
            }
        }

        /// <summary>
        /// Sets the non accessible blocks.
        /// </summary>
        private void SetNonAccessibleBlocks()
        {
            if (Device.RuntimePlatform == "Android" || Device.RuntimePlatform == "iOS")
            {
                NonAccessibleBlocksCollection nonAccessibleBlocks = new NonAccessibleBlocksCollection();
                var nonAccessibleBlock = new NonAccessibleBlock();
                nonAccessibleBlock.StartTime = 13;
                nonAccessibleBlock.EndTime = 14;
                nonAccessibleBlock.Text = "Lunch time";
                nonAccessibleBlocks.Add(nonAccessibleBlock);

                var dayViewSettings = new DayViewSettings();
                dayViewSettings.NonAccessibleBlocks = nonAccessibleBlocks;
                schedule.DayViewSettings = dayViewSettings;

                var weekViewSettings = new WeekViewSettings();
                weekViewSettings.NonAccessibleBlocks = nonAccessibleBlocks;
                schedule.WeekViewSettings = weekViewSettings;

                var workWeekViewSettings = new WorkWeekViewSettings();
                workWeekViewSettings.NonAccessibleBlocks = nonAccessibleBlocks;
                schedule.WorkWeekViewSettings = workWeekViewSettings;
            }
        }

        /// <summary>
        /// Gets the dropped location.
        /// </summary>
        /// <returns>The dropped location.</returns>
        /// <param name="startTime">Start time.</param>
        private string GetDroppedLocation(DateTime startTime)
        {
            return "Moved to " + startTime.ToString("dddd, dd MMMM, hh:mm tt");
        }

        /// <summary>
        /// check the drop time in non-accessible region.
        /// </summary>
        /// <returns><c>true</c>, if in non access region was ised, <c>false</c> otherwise.</returns>
        /// <param name="dropTime">Drop time.</param>
        private bool IsInNonAccessRegion(DateTime dropTime)
        {
            if (schedule.WorkWeekViewSettings.NonAccessibleBlocks[0].StartTime == dropTime.Hour || (schedule.WorkWeekViewSettings.NonAccessibleBlocks[0].StartTime - 1 == dropTime.Hour && dropTime.Minute > 0))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Disposing the elements
        /// </summary>
        /// <param name="bindable">Bindable value.</param>
        protected override void OnDetachingFrom(SampleView bindable)
        {
            base.OnDetachingFrom(bindable);

            if (viewPicker != null)
            {
                viewPicker.SelectedIndexChanged -= ViewPicker_SelectedIndexChanged;
                viewPicker = null;
            }

            if (schedule != null)
            {
                schedule.AppointmentDrop -= Schedule_AppointmentDrop;
                schedule.CellTapped -= Schedule_CellTapped;
                schedule = null;
            }

        }
    }
}
