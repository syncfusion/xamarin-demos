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
    /// Schedule View Behavior class
    /// </summary>
    internal class SetScheduleViewBehavior : Behavior<SampleView>
    {
        /// <summary>
        /// schedule initialize
        /// </summary>
        private Syncfusion.SfSchedule.XForms.SfSchedule schedule;

        /// <summary>
        /// localization view model
        /// </summary>
        private LocalizationViewModel localizationViewModel;

        /// <summary>
        /// view picker
        /// </summary>
        private Picker viewPicker;

        /// <summary>
        /// locale picker
        /// </summary>
        private Picker localePicker;

        /// <summary>
        /// current time indicator
        /// </summary>
        private Switch currentTime;

        /// <summary>
        /// current time label
        /// </summary>
        private Label showCurrentTime;

        /// <summary>
        /// Begins when the behavior attached to the view 
        /// </summary>
        /// <param name="bindable">bindable value</param>
        protected override void OnAttachedTo(SampleView bindable)
        {
            if (bindable == null)
            {
                return;
            }

            base.OnAttachedTo(bindable);

            this.schedule = bindable.Content.FindByName<Syncfusion.SfSchedule.XForms.SfSchedule>("Schedule");
            this.currentTime = bindable.FindByName<Switch>("currentTime");
            this.showCurrentTime = bindable.FindByName<Label>("showCurrentTime");
            if (Device.RuntimePlatform == Device.Android)
            {
                this.schedule.ViewHeaderStyle.DateFontSize = 24;
            }

            if (this.schedule?.Locale == "ja")
            {
                this.localizationViewModel = new LocalizationViewModel();
                this.localePicker = bindable.FindByName<Picker>("localePicker");
                if (this.localePicker == null)
                {
                    return;
                }

                this.localePicker.SelectedIndex = 0;
                this.localePicker.SelectedIndexChanged += this.LocalePicker_SelectedIndexChanged;
                this.schedule.DataSource = this.localizationViewModel.JapaneseAppointments;
            }

            this.viewPicker = bindable.FindByName<Picker>("viewPicker");

            if (this.viewPicker == null)
            {
                return;
            }

            if (bindable.GetType().Equals(typeof(RecursiveAppointments)))
            {
                this.viewPicker.SelectedIndex = 3;
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        this.schedule.MonthViewSettings.AppointmentDisplayMode = AppointmentDisplayMode.Appointment;
                        if (Device.RuntimePlatform == Device.iOS && Device.Idiom == TargetIdiom.Tablet)
                        {
                            schedule.MonthViewSettings.AppointmentIndicatorCount = 4;
                        }
                        else if (Device.RuntimePlatform == Device.iOS)
                        {
                            schedule.MonthViewSettings.AppointmentIndicatorCount = 2;
                        }
                        break;
                    case Device.Android:
                        this.schedule.MonthViewSettings.AppointmentDisplayMode = AppointmentDisplayMode.Appointment;
                        break;
                    case Device.UWP:
                        this.schedule.MonthViewSettings.AppointmentDisplayMode = AppointmentDisplayMode.Indicator;
                        break;
                    case Device.WPF:
                        this.schedule.MonthViewSettings.AppointmentDisplayMode = AppointmentDisplayMode.Indicator;
                        break;
                } 
            }
            else if (bindable.GetType().Equals(typeof(ViewCustomization)))
            {
                this.viewPicker.SelectedIndex = 3;
            }
            else if (bindable.GetType().Equals(typeof(Localization)))
            {
                this.schedule.MonthViewSettings.AppointmentDisplayMode = AppointmentDisplayMode.Appointment;
                this.schedule.MonthViewSettings.AppointmentDisplayCount = 2;
                if (Device.RuntimePlatform == Device.iOS && Device.Idiom == TargetIdiom.Tablet)
                {
                    schedule.MonthViewSettings.AppointmentIndicatorCount = 4;
                }
                else if (Device.RuntimePlatform == Device.iOS)
                {
                    schedule.MonthViewSettings.AppointmentIndicatorCount = 2;
                }

                this.viewPicker.SelectedIndex = 3;
            }
            else
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        schedule.ScheduleView = ScheduleView.MonthView;
                        if (Device.Idiom == TargetIdiom.Tablet)
                        {
                            schedule.MonthViewSettings.AppointmentIndicatorCount = 4;
                        }
                        else
                        {
                            schedule.MonthViewSettings.AppointmentIndicatorCount = 2;
                        }

                        this.viewPicker.SelectedIndex = 3;
                        break;
                    case Device.Android:
                        schedule.ScheduleView = ScheduleView.MonthView;
                        this.viewPicker.SelectedIndex = 3;
                        break;
                    case Device.UWP:
                        schedule.ScheduleView = ScheduleView.WeekView;
                        this.viewPicker.SelectedIndex = 1;
                        break;
                    case Device.WPF:
                        schedule.ScheduleView = ScheduleView.WeekView;
                        this.viewPicker.SelectedIndex = 1;
                        break;
                }
            }

            if (bindable.GetType().Equals(typeof(GettingStarted)))
            {
                schedule.ScheduleView = ScheduleView.WeekView;
                this.viewPicker.SelectedIndex = 1;
                this.currentTime.Toggled += CurrentTime_Toggled;

                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        schedule.ShowAppointmentsInline = true;
                        break;
                    case Device.Android:
                        schedule.ShowAppointmentsInline = true;
                        this.showCurrentTime.FontSize = 18;
                        this.showCurrentTime.TextColor = Color.Gray;
                        break;
                    case Device.UWP:
                        schedule.ShowAppointmentsInline = false;
                        schedule.MonthViewSettings.ShowAgendaView = false;
                        this.showCurrentTime.TextColor = Color.Black;
                        break;
                    case Device.WPF:
                        schedule.ShowAppointmentsInline = false;
                        schedule.MonthViewSettings.ShowAgendaView = false;
                        break;
                }
            }

            this.viewPicker.SelectedIndexChanged += this.ViewPicker_SelectedIndexChanged;
        }


        /// <summary>
        /// method for enabling current time indicator.
        /// </summary>
        /// <param name="sender"> return the object</param>
        /// <param name="e">Event Args</param>
        private void CurrentTime_Toggled(object sender, ToggledEventArgs e)
        {
            if ((sender as Switch).IsToggled)
            {
                this.schedule.ShowCurrentTimeIndicator = true;
            }
            else
            {
                this.schedule.ShowCurrentTimeIndicator = false;
            }
        }

        /// <summary>
        /// Begins when the behavior attached to the view 
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

            if (this.localePicker != null)
            {
                this.localePicker.SelectedIndexChanged -= this.LocalePicker_SelectedIndexChanged;
                this.localePicker = null;
            }

            if(currentTime != null)
            {
                this.currentTime.Toggled -= CurrentTime_Toggled;
                this.currentTime = null;
            }

            if (showCurrentTime != null)
            {
                this.showCurrentTime = null;
            }

            if (this.schedule != null)
            {
                this.schedule = null;
            }
        }

        /// <summary>
        /// Method for schedule view selection
        /// </summary>
        /// <param name="sender">return the object</param>
        /// <param name="e">Event Args</param>
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
                    this.schedule.ScheduleView = ScheduleView.MonthView;
                    break;
                case 4:
                    this.schedule.ScheduleView = ScheduleView.TimelineView;
                    break;
            }
        }

        /// <summary>
        /// method for selecting locale
        /// </summary>
        /// <param name="sender">return the object</param>
        /// <param name="e">Event Args</param>
        private void LocalePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as Picker).SelectedIndex)
            {
                case 0:
                    this.schedule.Locale = "ja";
                    this.schedule.DataSource = this.localizationViewModel.JapaneseAppointments;
                    break;
                case 1:
                    this.schedule.Locale = "en";
                    this.schedule.DataSource = this.localizationViewModel.EnglishAppointments;
                    break;
                case 2:
                    this.schedule.Locale = "fr";
                    this.schedule.DataSource = this.localizationViewModel.FrenchAppointments;
                    break;
                case 3:
                    this.schedule.Locale = "es";
                    this.schedule.DataSource = this.localizationViewModel.SpanishAppointments;
                    break;
            }
        }
    }
}
