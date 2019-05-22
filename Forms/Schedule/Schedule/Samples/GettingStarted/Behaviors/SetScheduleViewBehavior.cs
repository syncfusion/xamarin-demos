#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
            }
            else if (bindable.GetType().Equals(typeof(ViewCustomization)))
            {
                this.viewPicker.SelectedIndex = 3;
            }
            else if (bindable.GetType().Equals(typeof(Localization)))
            {
                this.viewPicker.SelectedIndex = 1;
            }
            else
            {
                this.viewPicker.SelectedIndex = 2;
            }

            this.viewPicker.SelectedIndexChanged += this.ViewPicker_SelectedIndexChanged;
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
