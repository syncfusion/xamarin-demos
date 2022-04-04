#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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
        private Grid grid;
        private double calendarWidth = 500;
        private int padding = 50;

        protected override void OnAttachedTo(SampleView bindable)
        {
            base.OnAttachedTo(bindable);
            this.calendar = bindable.Content.FindByName<Syncfusion.SfCalendar.XForms.SfCalendar>("calendar");
            this.grid = bindable.Content.FindByName<Grid>("grid");
            if (Device.RuntimePlatform == "UWP")
            {
                this.grid.HorizontalOptions = LayoutOptions.Center;
                this.grid.WidthRequest = this.calendarWidth;
                bindable.SizeChanged += this.Bindable_SizeChanged;
            }

            this.calendar.InlineViewMode = InlineViewMode.Agenda;
            this.calendar.ShowLeadingAndTrailingDays = false;
            this.calendar.BackgroundColor = Color.White;

            this.calendar.MonthViewSettings.DayHeight = 50;
            this.calendar.MonthViewSettings.WeekEndTextColor = Color.FromHex("#009688");
            this.calendar.MonthViewSettings.HeaderBackgroundColor = Color.White;
            this.calendar.MonthViewSettings.InlineBackgroundColor = Color.White; 
            this.calendar.MonthViewSettings.DateSelectionColor = Color.FromHex("#EEEEEE");
            this.calendar.MonthViewSettings.TodayTextColor = Color.Red;
            this.calendar.MonthViewSettings.TodayBorderColor = Color.Red;
            this.calendar.MonthViewSettings.SelectedDayTextColor = Color.Black;
            if (Device.RuntimePlatform == "Android" || (Device.RuntimePlatform == "UWP" && Device.Idiom == TargetIdiom.Desktop))
            {
                this.calendar.HeaderHeight = 50;
            }
            else if (Device.RuntimePlatform == "iOS")
            {
                this.calendar.HeaderHeight = 40;
            }

            if (Device.RuntimePlatform == "UWP")
            {
                this.calendar.AgendaViewHeight = 150;
            }
        }

        private void Bindable_SizeChanged(object sender, EventArgs e)
        {
            var sampleView = sender as SampleView;
            if (sampleView.Width < this.calendarWidth + padding)
            {
                this.grid.WidthRequest = sampleView.Width - padding;
            }
        }

        protected override void OnDetachingFrom(SampleView bindable)
        {
            base.OnDetachingFrom(bindable);
            if (Device.RuntimePlatform == "UWP")
            {
                bindable.SizeChanged -= this.Bindable_SizeChanged;
            }

            this.grid = null;
            this.calendar = null;
        }
    }
}

