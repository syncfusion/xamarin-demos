#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using SampleBrowser.Core;
using Syncfusion.SfCalendar.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfCalendar
{
    internal class BlackoutDatesBehavior : Behavior<SampleView>
    {
        private Syncfusion.SfCalendar.XForms.SfCalendar calendar;

        protected override void OnAttachedTo(SampleView bindable)
        {
            base.OnAttachedTo(bindable);
            this.calendar = bindable.Content.FindByName<Syncfusion.SfCalendar.XForms.SfCalendar>("calendar");
            MonthViewSettings monthSettings = new MonthViewSettings
            {
                HeaderBackgroundColor = Color.White,
                TodayBorderColor = Color.FromHex("#2196F3"),
                TodayTextColor = Color.FromHex("#2196F3"),
                BlackoutColor = Color.Red
            };
            this.calendar.MonthViewSettings = monthSettings;
            if (Device.Idiom == TargetIdiom.Tablet)
            {
                if (Device.RuntimePlatform == "Android")
                {
                    this.calendar.MonthViewSettings.SelectionRadius = 30;
                }
                else
                {
                    this.calendar.MonthViewSettings.SelectionRadius = 20;
                }
            }

            if (Device.RuntimePlatform == "Android" || (Device.RuntimePlatform == "UWP" && Device.Idiom == TargetIdiom.Desktop))
            {
                this.calendar.HeaderHeight = 50;
            }
            else if (Device.RuntimePlatform == "iOS")
            {
                this.calendar.HeaderHeight = 40;
            }

            this.calendar.OnMonthCellLoaded += Calendar_OnMonthCellLoaded;
        }

        private void Calendar_OnMonthCellLoaded(object sender, MonthCellLoadedEventArgs e)
        {
            var blackoutDates = new ObservableCollection<DateTime>();
            if (e.Date.DayOfWeek == DayOfWeek.Sunday || e.Date.DayOfWeek == DayOfWeek.Saturday)
            {
                if (this.calendar.BlackoutDates != null)
                {
                    blackoutDates = (ObservableCollection<DateTime>)this.calendar.BlackoutDates;
                }
                blackoutDates.Add(e.Date);
                this.calendar.BlackoutDates = blackoutDates;
            } 
        }

        protected override void OnDetachingFrom(SampleView bindable)
        {
            base.OnDetachingFrom(bindable);
            calendar = null;
        }
    }
}

