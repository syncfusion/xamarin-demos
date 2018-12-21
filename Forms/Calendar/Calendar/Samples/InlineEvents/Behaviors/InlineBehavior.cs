#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
            var customLabels = new ObservableCollection<string> { "S", "M", "T", "W", "T", "F", "S" };
            this.calendar.CustomDayLabels = customLabels;
            if (Device.RuntimePlatform == "Android")
            {
                this.calendar.MonthViewSettings.DayCellFont = Font.SystemFontOfSize(15);
            }

            this.calendar.InlineViewMode = InlineViewMode.Agenda;
            this.calendar.MonthViewSettings.HeaderFont = Font.OfSize("SemiBold", this.calendar.MonthViewSettings.HeaderFont.FontSize);
            this.calendar.MonthViewSettings.DayHeight = 50;
            this.calendar.MonthViewSettings.DayLabelTextAlignment = DayLabelTextAlignment.Center;
            this.calendar.MonthViewSettings.DateTextAlignment = DateTextAlignment.Center;
            this.calendar.MonthViewSettings.SelectionShape = SelectionShape.Fill;
            this.calendar.MonthViewSettings.WeekEndTextColor = Color.FromHex("#009688");
            this.calendar.MonthViewSettings.HeaderBackgroundColor = Color.White;
            if (Device.RuntimePlatform == "iOS")
            {
                this.calendar.MonthViewSettings.InlineBackgroundColor = Color.White;
            }
            else
            {
                this.calendar.MonthViewSettings.InlineBackgroundColor = Color.FromHex("#EEEEEE");
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

