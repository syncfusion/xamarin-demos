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
    internal class LocalizationBehavior : Behavior<SampleView>
    {
        private Syncfusion.SfCalendar.XForms.SfCalendar calendar;
        private LocalizationViewModel viewModel;
        private Grid grid;
        private double calendarHeight = 400;
        private double calendarWidth = 400;
        private int padding = 50;

        protected override void OnAttachedTo(SampleView bindable)
        {
            base.OnAttachedTo(bindable);

            this.calendar = bindable.Content.FindByName<Syncfusion.SfCalendar.XForms.SfCalendar>("calendar");
            this.viewModel = bindable.BindingContext as LocalizationViewModel;
            this.grid = bindable.Content.FindByName<Grid>("grid");
            if (Device.RuntimePlatform == "UWP")
            {
                this.grid.HorizontalOptions = LayoutOptions.Center;
                this.grid.VerticalOptions = LayoutOptions.Center;
                this.grid.HeightRequest = this.calendarHeight;
                this.grid.WidthRequest = this.calendarWidth;
                bindable.SizeChanged += this.Bindable_SizeChanged;
            }

            this.calendar.Locale = new System.Globalization.CultureInfo("zh-CN");
            this.calendar.FirstDayofWeek = 1;
            MonthViewSettings monthSettings = new MonthViewSettings
            {
                HeaderBackgroundColor = Color.White,
                InlineBackgroundColor = Color.FromHex("#EEEEEE"),
                DateSelectionColor = Color.FromHex("#EEEEEE"),
                TodayTextColor = Color.Red,
                SelectedDayTextColor = Color.Black,
                DayHeaderFormat = "EEE",
                TodaySelectionBackgroundColor = Color.Red,
                TodayBorderColor = Color.Transparent
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

            var localePicker = bindable.Content.FindByName<Picker>("localePicker");
            localePicker.SelectedIndex = 0;
            localePicker.SelectedIndexChanged += LocalePicker_SelectedIndexChanged;;
        }

        private void LocalePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as Picker).SelectedIndex)
            {
                case 0:
                    {
                        this.calendar.Locale = new System.Globalization.CultureInfo("zh-CN");
                        this.viewModel.Locale = "zh-CN";
                    }

                    break;
                case 1:
                    {
                        this.calendar.Locale = new System.Globalization.CultureInfo("es-AR");
                        this.viewModel.Locale = "es-AR";
                    }

                    break;
                case 2:
                    {
                        this.calendar.Locale = new System.Globalization.CultureInfo("en-US");
                        this.viewModel.Locale = "en-US";
                    }

                    break;
                case 3:
                    {
                        this.calendar.Locale = new System.Globalization.CultureInfo("fr-CA");
                        this.viewModel.Locale = "fr-CA";
                    }

                    break;
            }
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

