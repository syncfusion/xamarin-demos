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
    internal class InlineBehavior : Behavior<SampleView>
    {
        private Syncfusion.SfCalendar.XForms.SfCalendar calendar;

        protected override void OnAttachedTo(SampleView bindable)
        {
            base.OnAttachedTo(bindable);
            this.calendar = bindable.Content.FindByName<Syncfusion.SfCalendar.XForms.SfCalendar>("calendar");
            this.calendar.InlineViewMode = InlineViewMode.Agenda;
            this.calendar.ShowLeadingAndTrailingDays = true;
            this.calendar.MonthViewSettings.DayHeight = 50;
            this.calendar.MonthViewSettings.WeekEndTextColor = Color.FromHex("#009688");
            this.calendar.BackgroundColor = Color.White;
            this.calendar.MonthViewSettings.HeaderBackgroundColor = Color.White;
            if (Device.RuntimePlatform == "iOS")
            {
                this.calendar.MonthViewSettings.InlineBackgroundColor = Color.White;
            }

            if (Device.Idiom == TargetIdiom.Tablet)
            {
                if (Device.RuntimePlatform == "Android")
                {
                    this.calendar.MonthViewSettings.SelectionRadius = 20;
                }
                else
                {
                    this.calendar.MonthViewSettings.SelectionRadius = 15;
                }
            }

            this.calendar.MonthViewSettings.DateSelectionColor = Color.FromHex("#EEEEEE");
            this.calendar.MonthViewSettings.TodayTextColor = Color.FromHex("#2196F3");
            this.calendar.MonthViewSettings.SelectedDayTextColor = Color.Black;
            if (Device.RuntimePlatform == "Android" || (Device.RuntimePlatform == "UWP" && Device.Idiom == TargetIdiom.Desktop))
            {
                this.calendar.HeaderHeight = 50;
            }
            else if (Device.RuntimePlatform == "iOS")
            {
                this.calendar.HeaderHeight = 40;
            }
        }

        protected override void OnDetachingFrom(SampleView bindable)
        {
            base.OnDetachingFrom(bindable);
            calendar = null;
        }
    }
}

