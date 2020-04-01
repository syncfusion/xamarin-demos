#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfSchedule.XForms;
using System;
using Xamarin.Forms;

namespace SampleBrowser.SfSchedule
{
    internal class TimelineViewBehavior : Behavior<SampleView>
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
        /// Resource view mode picker
        /// </summary>
        //private Picker viewModePicker;

        /// <summary>
        /// Resource view switch.
        /// </summary>
        private Switch showResourceView;

        /// <summary>
        /// TimelineView settings
        /// </summary>
        private TimelineViewSettings timelineViewSettings;

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
            if(Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WPF)
            {
                this.schedule.TimeIntervalHeight = -1;
            }
            else if (Device.RuntimePlatform == "iOS")
            {
                this.schedule.TimeIntervalHeight = 80;
            }

            this.timelineViewSettings = new TimelineViewSettings();
            this.timelineViewSettings.DaysCount = 7;
            this.SetDateFormat();
            this.schedule.ScheduleView = ScheduleView.TimelineView;
            this.schedule.ResourceViewMode = ResourceViewMode.Absolute;
            this.schedule.ShowResourceView = true;
            if (Device.Idiom == TargetIdiom.Phone)
            {
                this.schedule.ResourceViewHeight = Device.RuntimePlatform == Device.iOS ? 75 : 100;
            }

            this.schedule.TimeInterval = 720;
            this.schedule.ViewHeaderStyle.DateFontSize = this.schedule.HeaderStyle.FontSize;
            this.schedule.TimelineViewSettings = this.timelineViewSettings;
            if (Device.RuntimePlatform == Device.Android)
            {
                this.schedule.ViewHeaderHeight = 70;
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                this.schedule.ViewHeaderHeight = 30;
            }
            this.viewPicker = bindable.FindByName<Picker>("viewPicker");
            if (this.viewPicker == null)
            {
                return;
            }

            this.viewPicker.SelectedIndex = 1;
            this.viewPicker.SelectedIndexChanged += this.ViewPicker_SelectedIndexChanged;

            //this.viewModePicker = bindable.FindByName<Picker>("viewModePicker");
            //if (this.viewModePicker == null)
            //{
            //    return;
            //}

            //this.viewModePicker.SelectedIndex = 1;
            //this.viewModePicker.SelectedIndexChanged += OnViewModePickerSelectedIndexChanged;

            this.showResourceView = bindable.FindByName<Switch>("showResourceView");
            if (this.showResourceView == null)
            {
                return;
            }

            this.showResourceView.Toggled += OnShowResourceViewToggled;
        }

        /// <summary>
        /// Method to show resource view
        /// </summary>
        /// <param name="sender">Return the object</param>
        /// <param name="e">Event args</param>
        private void OnShowResourceViewToggled(object sender, ToggledEventArgs e)
        {
            if ((sender as Switch).IsToggled)
            {
                this.schedule.ShowResourceView = true;
            }
            else
            {
                this.schedule.ShowResourceView = false;
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

            //if (this.viewModePicker != null)
            //{
            //    this.viewModePicker.SelectedIndexChanged -= OnViewModePickerSelectedIndexChanged;
            //    this.viewModePicker = null;
            //}

            if (this.showResourceView != null)
            {
                this.showResourceView.Toggled -= OnShowResourceViewToggled;
                this.showResourceView = null;
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
                    this.timelineViewSettings.NonWorkingsDays = new System.Collections.ObjectModel.ObservableCollection<DayOfWeek>();
                    this.timelineViewSettings.DaysCount = 1;
                    this.schedule.TimeInterval = 60;
                    break;
                case 1:
                    this.timelineViewSettings.NonWorkingsDays = new System.Collections.ObjectModel.ObservableCollection<DayOfWeek>();
                    this.timelineViewSettings.DaysCount = 7;
                    this.schedule.TimeInterval = 720;
                    break;
                case 2:
                    this.timelineViewSettings.NonWorkingsDays = new System.Collections.ObjectModel.ObservableCollection<DayOfWeek>()
                    {
                        DayOfWeek.Sunday,
                        DayOfWeek.Saturday
                    };
                    this.timelineViewSettings.DaysCount = 5;
                    this.schedule.TimeInterval = 720;
                    break;
            }

            this.SetDateFormat();
        }

        /// <summary>
        /// Method for schedule resource view mode selection.
        /// </summary>
        /// <param name="sender">return the object</param>
        /// <param name="e">Event Args</param>
        private void OnViewModePickerSelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as Picker).SelectedIndex)
            {
                case 0:
                    this.schedule.ResourceViewMode = ResourceViewMode.Selection;
                    if (Device.Idiom == TargetIdiom.Phone)
                    {
                        this.schedule.ResourceViewHeight = Device.RuntimePlatform == Device.iOS ? 100 : 150;
                    }
                    break;
                case 1:
                    this.schedule.ResourceViewMode = ResourceViewMode.Absolute;
                    if (Device.Idiom == TargetIdiom.Phone)
                    {
                        this.schedule.ResourceViewHeight = Device.RuntimePlatform == Device.iOS ? 75 : 100;
                    }
                    break;
            }
        }

        /// <summary>
        /// Sets the date format for timeline view.
        /// </summary>
        private void SetDateFormat()
        {
            string dateFormat;
            if (this.timelineViewSettings.DaysCount == 1)
            {
                dateFormat = Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS ? "dd EEEE" : "%d dddd";
            }
            else
            {
                dateFormat = Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS ? "dd EEE" : "%d ddd";
            }

            timelineViewSettings.LabelSettings.DateFormat = dateFormat;
        }
    }
}