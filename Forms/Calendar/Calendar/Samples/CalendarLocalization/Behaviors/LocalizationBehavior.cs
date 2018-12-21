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
    internal class LocalizationBehavior : Behavior<SampleView>
    {
        private Syncfusion.SfCalendar.XForms.SfCalendar calendar;
        private LocalizationViewModel viewModel;

        protected override void OnAttachedTo(SampleView bindable)
        {
            base.OnAttachedTo(bindable);

            this.calendar = bindable.Content.FindByName<Syncfusion.SfCalendar.XForms.SfCalendar>("calendar");
            this.viewModel = bindable.BindingContext as LocalizationViewModel;
            this.calendar.Locale = new System.Globalization.CultureInfo("zh-CN");
            MonthViewSettings monthSettings = new MonthViewSettings();
            if (Device.RuntimePlatform == "Android")
            {
                monthSettings.DayCellFont = Font.SystemFontOfSize(15);
                if (Device.Idiom == TargetIdiom.Tablet)
                {
                    monthSettings.SelectionRadius = 25;
                }
                else
                {
                    monthSettings.SelectionRadius = 20;
                }
            }
            else if (Device.RuntimePlatform == "iOS")
            {
                monthSettings.SelectionRadius = 15;
            }

            monthSettings.HeaderFont = Font.OfSize("SemiBold", monthSettings.HeaderFont.FontSize);
            monthSettings.HeaderBackgroundColor = Color.White;
            monthSettings.InlineBackgroundColor = Color.FromHex("#EEEEEE");
            monthSettings.DateSelectionColor = Color.FromHex("#EEEEEE");
            monthSettings.TodayTextColor = Color.FromHex("#2196F3");
            monthSettings.SelectedDayTextColor = Color.Black;
            monthSettings.DayLabelTextAlignment = DayLabelTextAlignment.Center;
            monthSettings.CellGridOptions = CellGridOptions.None;
            monthSettings.SelectionShape = SelectionShape.Circle;
            monthSettings.DateTextAlignment = DateTextAlignment.Center;
            this.calendar.MonthViewSettings = monthSettings;
            this.calendar.FirstDayofWeek = 1;
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

        protected override void OnDetachingFrom(SampleView bindable)
        {
            base.OnDetachingFrom(bindable);
            calendar = null;
        }
    }
}

