#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleBrowser.Core;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfSchedule
{
    /// <summary>
    /// Drag drop behavior.
    /// </summary>
    internal class DragDropBehaviour : Behavior<SampleView>
    {
        /// <summary>
        /// schedule initialize
        /// </summary>
        private Syncfusion.SfSchedule.XForms.SfSchedule schedule;

        /// <summary>
        /// view picker
        /// </summary>
        private Picker viewPicker;

        /// <summary>
        /// label value
        /// </summary>
        private Label label;

        /// <summary>
        /// Begins when the behavior attached to the view 
        /// </summary>
        /// <param name="bindable">bindable value</param>
        protected override void OnAttachedTo(SampleView bindable)
        {
            base.OnAttachedTo(bindable);

            this.schedule = bindable.Content.FindByName<Syncfusion.SfSchedule.XForms.SfSchedule>("Schedule");
            if (Device.RuntimePlatform == Device.Android)
            {
                this.schedule.ViewHeaderStyle.DateFontSize = 24;
            }

            this.viewPicker = bindable.FindByName<Picker>("viewPicker");

            this.label = bindable.Content.FindByName<Label>("labelIndicator");
            this.label.WidthRequest = this.schedule.Width;
            this.label.BackgroundColor = Color.FromHex("#2e2f30");

            if (bindable.GetType().Equals(typeof(RecursiveAppointments)))
            {
                this.viewPicker.SelectedIndex = 3;
            }
            else if (bindable.GetType().Equals(typeof(ViewCustomization)))
            {
                this.viewPicker.SelectedIndex = 0;
            }           
            else
            {
                this.viewPicker.SelectedIndex = 2;
            }

            this.viewPicker.SelectedIndexChanged += this.ViewPicker_SelectedIndexChanged;
            this.schedule.AppointmentDrop += this.Schedule_AppointmentDrop;
            this.schedule.CellTapped += this.Schedule_CellTapped;

            this.SetNonAccessibleBlocks();
        }

        /// <summary>
        /// Disposing the elements
        /// </summary>
        /// <param name="bindable">bindable value</param>
        protected override void OnDetachingFrom(SampleView bindable)
        {
            base.OnDetachingFrom(bindable);

            if (this.viewPicker != null)
            {
                this.viewPicker.SelectedIndexChanged -= this.ViewPicker_SelectedIndexChanged;
                this.viewPicker = null;
            }

            if (this.schedule != null)
            {
                this.schedule.AppointmentDrop -= this.Schedule_AppointmentDrop;
                this.schedule.CellTapped -= this.Schedule_CellTapped;
                this.schedule = null;
            }
        }

        /// <summary>
        /// Schedules the cell tapped.
        /// </summary>
        /// <param name="sender">Sender value.</param>
        /// <param name="e">E value.</param>
        private void Schedule_CellTapped(object sender, CellTappedEventArgs e)
        {
            this.label.HeightRequest = 0;
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
            this.label.Opacity = 1;
            this.label.HeightRequest = 50;

            if (Device.RuntimePlatform == "Android" || Device.RuntimePlatform == "iOS")
            {
                if (this.IsInNonAccessRegion(e.DropTime))
                {
                    e.Cancel = true;
                    this.label.Text = "Cannot be moved to blocked time slots";
                    await this.label.FadeTo(0, 2000, Easing.SpringIn);
                    this.label.HeightRequest = 0;
                    return;
                }
            }

            this.label.Text = this.GetDroppedLocation(e.DropTime);
            await this.label.FadeTo(0, 2000, Easing.SpringIn);
            this.label.HeightRequest = 0;
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
                    this.schedule.ScheduleView = ScheduleView.DayView;
                    break;
                case 1:
                    this.schedule.ScheduleView = ScheduleView.WeekView;
                    break;
                case 2:
                    this.schedule.ScheduleView = ScheduleView.WorkWeekView;
                    break;
                case 3:
                    this.schedule.ScheduleView = ScheduleView.TimelineView;
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
                this.schedule.DayViewSettings = dayViewSettings;

                var weekViewSettings = new WeekViewSettings();
                weekViewSettings.NonAccessibleBlocks = nonAccessibleBlocks;
                this.schedule.WeekViewSettings = weekViewSettings;

                var workWeekViewSettings = new WorkWeekViewSettings();
                workWeekViewSettings.NonAccessibleBlocks = nonAccessibleBlocks;
                this.schedule.WorkWeekViewSettings = workWeekViewSettings;
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
        /// <returns><c>true</c>, if in non access region was used, <c>false</c> otherwise.</returns>
        /// <param name="dropTime">Drop time.</param>
        private bool IsInNonAccessRegion(DateTime dropTime)
        {
            if (this.schedule.WorkWeekViewSettings.NonAccessibleBlocks[0].StartTime == dropTime.Hour || (this.schedule.WorkWeekViewSettings.NonAccessibleBlocks[0].StartTime - 1 == dropTime.Hour && dropTime.Minute > 0))
            {
                return true;
            }

            return false;
        }
    }
}