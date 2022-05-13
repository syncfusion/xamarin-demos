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
    internal class CalendarCustomizationBehavior : Behavior<SampleView>
    {
        private Syncfusion.SfCalendar.XForms.SfCalendar calendar;
        private Grid grid;
        private int calendarHeight = 400;
        private int calendarWidth = 400;
        private int padding = 50;

        protected override void OnAttachedTo(SampleView bindable)
        {
            base.OnAttachedTo(bindable);
            this.calendar = bindable.Content.FindByName<Syncfusion.SfCalendar.XForms.SfCalendar>("calendar");
            this.grid = bindable.Content.FindByName<Grid>("grid");
            if (Device.RuntimePlatform == "UWP")
            {
                this.grid.HorizontalOptions = LayoutOptions.Center;
                this.grid.VerticalOptions = LayoutOptions.Center;
                this.grid.HeightRequest = this.calendarHeight;
                this.grid.WidthRequest = this.calendarWidth;
                bindable.SizeChanged += this.Bindable_SizeChanged;
            }

            this.calendar.MonthViewSettings.HeaderBackgroundColor = Color.White;
            this.calendar.MonthViewSettings.SelectedDayTextColor = Color.Black;
            this.calendar.ShowLeadingAndTrailingDays = false;
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
            CalendarCustomizationViewModel viewModel = new CalendarCustomizationViewModel(e.IsCurrentMonth, e.Date);
            e.CellBindingContext = viewModel;
        }

        private void Bindable_SizeChanged(object sender, EventArgs e)
        {
            var sampleView = sender as SampleView;
            if (sampleView.Height < this.calendarHeight + padding)
            {
                this.grid.HeightRequest = sampleView.Height - padding;
            }

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

