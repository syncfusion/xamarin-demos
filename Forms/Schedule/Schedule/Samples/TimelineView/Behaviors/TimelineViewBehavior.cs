#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
        /// The today date.
        /// </summary>
        private DateTime today;
        
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
            if (Device.RuntimePlatform == "iOS")
            {
                this.schedule.TimeIntervalHeight = 80;
            }

            this.schedule.VisibleDatesChangedEvent += Schedule_VisibleDatesChangedEvent;
            this.schedule.TimelineViewSettings.AppointmentHeight = 1000;
            this.schedule.TimelineViewSettings.DaysCount = 7;
            this.schedule.ScheduleView = ScheduleView.TimelineView;
            today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0);
            this.schedule.MoveToDate = today;
            TimeRegionSettings timeRegionSettings = new TimeRegionSettings()
            {
                StartHour = 13,
                EndHour = 14,
                Text = "Lunch",
                TextColor = Color.Black,
                CanEdit = false,
                Color = Color.FromHex("#eaeaea")
            };

            TimeRegionSettings startRegionSettings = new TimeRegionSettings()
            {
                StartHour = 0,
                EndHour = 9,
                Color = Color.FromHex("#fafafa")
            };

            TimeRegionSettings endRegionSettings = new TimeRegionSettings()
            {
                StartHour = 18,
                EndHour = 24,
                Color = Color.FromHex("#fafafa")
            };

            this.schedule.SpecialTimeRegions = new System.Collections.ObjectModel.ObservableCollection<TimeRegionSettings>()
            {
                timeRegionSettings,
                startRegionSettings,
                endRegionSettings
            };

            this.viewPicker = bindable.FindByName<Picker>("viewPicker");
            if (this.viewPicker == null)
            {
                return;
            }

            this.viewPicker.SelectedIndex = 1;
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
            var timelineviewSettings = new TimelineViewSettings();
            timelineviewSettings.AppointmentHeight = 1000;
            this.schedule.NavigateTo(today);
            switch ((sender as Picker).SelectedIndex)
            {
                case 0:
                    timelineviewSettings.NonWorkingsDays = new System.Collections.ObjectModel.ObservableCollection<DayOfWeek>();
                    this.schedule.TimelineViewSettings = timelineviewSettings;
                    this.schedule.TimelineViewSettings.DaysCount = 1;
                    break;
                case 1:
                    timelineviewSettings.NonWorkingsDays = new System.Collections.ObjectModel.ObservableCollection<DayOfWeek>();
                    this.schedule.TimelineViewSettings = timelineviewSettings;
                    this.schedule.TimelineViewSettings.DaysCount = 7;
                    break;
                case 2:
                    timelineviewSettings.NonWorkingsDays = new System.Collections.ObjectModel.ObservableCollection<DayOfWeek>()
                    {
                        DayOfWeek.Sunday,
                        DayOfWeek.Saturday
                    };

                    this.schedule.TimelineViewSettings = timelineviewSettings;
                    this.schedule.TimelineViewSettings.DaysCount = 5;
                    break;
            }
        }

        void Schedule_VisibleDatesChangedEvent(object sender, VisibleDatesChangedEventArgs e)
        {
            var viewModel = this.schedule.BindingContext as TimelineViewModel;
            viewModel.ListOfMeeting = new System.Collections.ObjectModel.ObservableCollection<Meeting>();
            viewModel.BookingAppointments(e.visibleDates);
        }

    }
}