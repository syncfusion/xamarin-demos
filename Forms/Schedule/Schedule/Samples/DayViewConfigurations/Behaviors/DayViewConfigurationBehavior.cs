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
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfSchedule
{
    /// <summary>
    /// Day View Configuration Behavior class
    /// </summary>
    public class DayViewConfigurationBehavior : Behavior<SampleView>
    {
        /// <summary>
        /// schedule initialization
        /// </summary>
        private Syncfusion.SfSchedule.XForms.SfSchedule schedule;

        /// <summary>
        /// start time slider
        /// </summary>
        private Slider startTimeSlider;

        /// <summary>
        /// time label switch.
        /// </summary>
        private Switch showTimeLabel;

        /// <summary>
        /// end time slider
        /// </summary>
        private Slider endTimeSlider;

        /// <summary>
        /// view picker
        /// </summary>
        private Picker viewPicker;

        /// <summary>
        /// date picker
        /// </summary>
        private DatePicker datePicker;

        /// <summary>
        /// end hour label
        /// </summary>
        private Label endHourLabel;

        /// <summary>
        /// start hour label
        /// </summary>
        private Label startHourLabel;

        #region OnAttached

        /// <summary>
        /// Method for converter
        /// </summary>
        /// <param name="input">input value</param>
        /// <returns>return the double value</returns>
        public string Converter(double input)
        {
            string final;
            double h = (int)input;
            double m = input - h;
            string ampm = " ";
            if (m == 59)
            {
                h = h + 1;
                m = 0;
            }

            if (h == 12)
            {
                ampm = "PM";
            }
            else if (h == 24)
            {
                h = 12;
                ampm = "AM";
            }
            else if (h > 12)
            {
                h = h - 12;
                ampm = "PM";
            }
            else if (h < 12)
            {
                ampm = "AM";
            }

            m = TimeSpan.FromMinutes(m).Seconds;
            if (m == 0)
            {
                var time = TimeSpan.FromMinutes(m);
                final = h.ToString() + ":" + m.ToString() + "0 " + ampm;
            }
            else if (m == 1 || m == 2 || m == 3 || m == 4 || m == 5 || m == 6 || m == 7 || m == 8 || m == 9)
            {
                var time = TimeSpan.FromMinutes(m);
                final = h.ToString() + ":0" + m.ToString() + " " + ampm;
            }
            else
            {
                final = h.ToString() + ":" + m.ToString() + " " + ampm;
            }

            return final;
        }

        #region SetScheduleView

        /// <summary>
        ///method for selecting schedule view 
        /// </summary>
        /// <param name="sender">return the object</param>
        internal void SetScheduleView(object sender)
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
            }
        }
        #endregion

        #region DatePickerGoToDate

        /// <summary>
        /// method for move to date
        /// </summary>
        /// <param name="date">date value</param>
        internal void DatePickerGoToDate(DateTime date)
        {
            this.schedule.MoveToDate = date;
        }
        #endregion

        #region OnDetachingFrom

        /// <summary>
        /// Begins when the behavior attached to the view
        /// </summary>
        /// <param name="bindable">bindable value</param>
        protected override void OnDetachingFrom(SampleView bindable)
        {
            this.startTimeSlider.ValueChanged -= this.StartTimeSlider_ValueChanged;
            this.endTimeSlider.ValueChanged -= this.EndTimeSlider_ValueChanged;
            this.viewPicker.SelectedIndexChanged -= this.ViewPicker_SelectedIndexChanged;
            this.datePicker.DateSelected -= this.DatePicker_DateSelected;
            this.showTimeLabel.Toggled -= this.ShowTimeLabel_Toggled;
            
            this.schedule = null;
            this.startTimeSlider = null;
            this.endTimeSlider = null;
            this.viewPicker = null;
            this.datePicker = null;
            this.showTimeLabel = null;
        }
        #endregion

        /// <summary>
        /// Begins when the behavior attached to the view
        /// </summary>
        /// <param name="bindable">binadable value</param>
        protected override void OnAttachedTo(SampleView bindable)
        {
            this.schedule = (bindable.Content as Grid).Children[0] as Syncfusion.SfSchedule.XForms.SfSchedule;
            if (Device.RuntimePlatform == Device.Android)
            {
                this.schedule.ViewHeaderStyle.DateFontSize = 24;
            }

            this.startTimeSlider = bindable.FindByName<Slider>("startTimeSlider");
            this.endTimeSlider = bindable.FindByName<Slider>("endTimeSlider");
            this.viewPicker = bindable.FindByName<Picker>("viewPicker");
            this.datePicker = bindable.FindByName<DatePicker>("datePicker");
            this.startHourLabel = bindable.FindByName<Label>("startHourLabel");
            this.endHourLabel = bindable.FindByName<Label>("endHourLabel");
            this.showTimeLabel = bindable.FindByName<Switch>("timeLabelWidth");
            this.viewPicker.SelectedIndex = 0;

            this.startTimeSlider.ValueChanged += this.StartTimeSlider_ValueChanged;
            this.endTimeSlider.ValueChanged += this.EndTimeSlider_ValueChanged;
            this.viewPicker.SelectedIndexChanged += this.ViewPicker_SelectedIndexChanged;
            this.datePicker.DateSelected += this.DatePicker_DateSelected;
            this.showTimeLabel.Toggled += this.ShowTimeLabel_Toggled;
            this.SetNonAccessibleBlocks();
        }

        private void ShowTimeLabel_Toggled(object sender, ToggledEventArgs e)
        {
            if ((sender as Switch).IsToggled)
            {
                if (Device.RuntimePlatform == "UWP" || Device.RuntimePlatform == "WPF")
                {
                    this.schedule.DayViewSettings.TimeRulerSize = 52;
                    this.schedule.WeekViewSettings.TimeRulerSize = 52;
                    this.schedule.WorkWeekViewSettings.TimeRulerSize = 52;
                }
                else
                {
                    this.schedule.DayViewSettings.TimeRulerSize = -1;
                    this.schedule.WeekViewSettings.TimeRulerSize = -1;
                    this.schedule.WorkWeekViewSettings.TimeRulerSize = -1;
                }
            }
            else
            {
                this.schedule.DayViewSettings.TimeRulerSize = 0;
                this.schedule.WeekViewSettings.TimeRulerSize = 0;
                this.schedule.WorkWeekViewSettings.TimeRulerSize = 0;
            }
        }
        #endregion

        #region DatePicker_DateSelected

        /// <summary>
        /// Method for date selection
        /// </summary>
        /// <param name="sender">return the object</param>
        /// <param name="e">Date Changed Event Args</param>
        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            this.DatePickerGoToDate(e.NewDate);
        }
        #endregion

        #region ViewPicker_SelectedIndexChanged

        /// <summary>
        /// Method for schedule view selection
        /// </summary>
        /// <param name="sender">return the object</param>
        /// <param name="e">Event Args</param>
        private void ViewPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetScheduleView(sender);
        }
        #endregion

        #region EndTimeSlider_ValueChanged

        /// <summary>
        /// Method for end time selection 
        /// </summary>
        /// <param name="sender">return the object</param>
        /// <param name="e">Value Changed Event Args</param>
        private void EndTimeSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (e.NewValue >= this.startTimeSlider.Value)
            {
                (this.schedule.BindingContext as ConfigurationViewModel).EndHour = e.NewValue;
                this.endHourLabel.Text = "Change the work hour end time:" + this.Converter(e.NewValue);
            }
            else
            {
                this.endTimeSlider.Value = this.startTimeSlider.Value;
                this.endHourLabel.Text = "Change the work hour end time:" + this.Converter(this.startTimeSlider.Value);
            }
        }
        #endregion

        #region StartTimeSlider_ValueChanged

        /// <summary>
        /// method for start time value changed.
        /// </summary>
        /// <param name="sender">return the object</param>
        /// <param name="e">Value Changed Event Args</param>
        private void StartTimeSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (e.NewValue <= this.endTimeSlider.Value)
            {
                (this.schedule.BindingContext as ConfigurationViewModel).WorkStartHour = e.NewValue;
                this.startHourLabel.Text = "Change the work hour start time:" + this.Converter(e.NewValue);
            }
            else
            {
                this.startTimeSlider.Value = this.endTimeSlider.Value;
                this.startHourLabel.Text = "Change the work hour start time:" + this.Converter(this.endTimeSlider.Value);
            }
        }
        #endregion
        #region SetNonAccessibleBlocks

        /// <summary>
        /// method for non accessible blocks
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
                this.schedule.DayViewSettings.NonAccessibleBlocks = nonAccessibleBlocks;
                this.schedule.WeekViewSettings.NonAccessibleBlocks = nonAccessibleBlocks;
                this.schedule.WorkWeekViewSettings.NonAccessibleBlocks = nonAccessibleBlocks;
            }
        }

        #endregion
    }
}