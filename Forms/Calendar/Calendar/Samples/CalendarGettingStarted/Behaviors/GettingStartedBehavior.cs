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
using SelectionMode = Syncfusion.SfCalendar.XForms.SelectionMode;

namespace SampleBrowser.SfCalendar
{
    internal class GettingStartedBehavior : Behavior<SampleView>
    {
        private Syncfusion.SfCalendar.XForms.SfCalendar calendar;
        private Grid grid;
        private double calendarHeight = 400;
        private double calendarWidth = 400;
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

            this.calendar.SelectionMode = SelectionMode.MultiSelection;
            var random = new Random();
            var dates = new System.Collections.Generic.List<DateTime>();
            var currentDate = DateTime.Now;
            for (int i = 0; i < 6; i++)
            {
                dates.Add(new DateTime(currentDate.Year, currentDate.Month, random.Next(1, 27)));
            }

            this.calendar.SelectedDates = dates; 
            this.calendar.MinDate = DateTime.Now.AddMonths(-5);
            this.calendar.MaxDate = DateTime.Now.AddMonths(5);
            MonthViewSettings monthSettings = new MonthViewSettings();
            monthSettings.HeaderBackgroundColor = Color.White;
            monthSettings.TodayBorderColor = Color.Transparent;
            if (Device.Idiom == TargetIdiom.Tablet)
            {
                if (Device.RuntimePlatform == "Android")
                {
                    monthSettings.SelectionRadius = 30;
                }
                else
                {
                    monthSettings.SelectionRadius = 15;
                }
            }

            this.calendar.MonthViewSettings = monthSettings;
            if (Device.RuntimePlatform == "UWP")
            {
                this.calendar.ShowNavigationButtons = true;
            } 
             
            if (Device.RuntimePlatform == "Android" || (Device.RuntimePlatform == "UWP" && Device.Idiom == TargetIdiom.Desktop))
            {
                this.calendar.HeaderHeight = 50;
            }
            else if (Device.RuntimePlatform == "iOS")
            {
                this.calendar.HeaderHeight = 40;
            }
           
            var selectionModePicker = bindable.Content.FindByName<Picker>("selectionModePicker");
            selectionModePicker.SelectedIndex = 1;
            selectionModePicker.SelectedIndexChanged += SelectionModePicker_SelectedIndexChanged;

            var viewModePicker = bindable.Content.FindByName<Picker>("viewModePicker");
            viewModePicker.SelectedIndex = 0;
            viewModePicker.SelectedIndexChanged += ViewModePicker_SelectedIndexChanged;

            var selectionShape = bindable.Content.FindByName<StackLayout>("selectionShape");
            if (Device.RuntimePlatform != "UWP")
            {
                selectionShape.IsVisible = false;
            }
            else
            {
                this.calendar.MonthViewSettings.SelectionShape = SelectionShape.Circle;
            }

            var selectionShapePicker = bindable.Content.FindByName<Picker>("selectionShapePicker");
            selectionShapePicker.SelectedIndex = 0;
            selectionShapePicker.SelectedIndexChanged += SelectionShapePicker_SelectedIndexChanged;

            var minDatePicker = bindable.Content.FindByName<DatePicker>("minDatePicker");
            minDatePicker.Date = this.calendar.MinDate;
            minDatePicker.DateSelected += MinDatePicker_DateSelected;

            var maxDatePicker = bindable.Content.FindByName<DatePicker>("maxDatePicker");
            maxDatePicker.Date = this.calendar.MaxDate;
            maxDatePicker.DateSelected += MaxDatePicker_DateSelected;

            var navigationDirectionPicker = bindable.Content.FindByName<Picker>("navigationDirectionPicker");
            navigationDirectionPicker.SelectedIndex = 0;
            navigationDirectionPicker.SelectedIndexChanged += NavigationDirectionPicker_SelectedIndexChanged;

            var horizontalLinePicker = bindable.Content.FindByName<Picker>("horizontalLinePicker");
            horizontalLinePicker.SelectedIndex = 3;
            horizontalLinePicker.SelectedIndexChanged += HorizontalLinePicker_SelectedIndexChanged;
            if (Device.RuntimePlatform != "Android" && Device.RuntimePlatform != "iOS")
            {
                var horizontalLineLabel = bindable.Content.FindByName<Label>("horizontalLineLabel");
                horizontalLineLabel.IsVisible = false;
                horizontalLinePicker.IsVisible = false;
            }

            var yearViewPicker = bindable.Content.FindByName<Picker>("yearViewPicker");
            yearViewPicker.SelectedIndex = 0;
            yearViewPicker.SelectedIndexChanged += YearViewPicker_SelectedIndexChanged;
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

        private void SelectionShapePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as Picker).SelectedIndex)
            {
                case 0:
                    {
                        this.calendar.MonthViewSettings.SelectionShape = SelectionShape.Circle;
                        break;
                    }
                case 1:
                    {
                        this.calendar.MonthViewSettings.SelectionShape = SelectionShape.Fill;
                        break;
                    }
            }
        }

        private void ViewModePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as Picker).SelectedIndex)
            {
                case 0:
                    {
                        calendar.ViewMode = ViewMode.MonthView;
                        break;
                    }
                case 1:
                    {
                        calendar.ViewMode = ViewMode.YearView;
                        break;
                    }
                case 2:
                    {
                        calendar.ViewMode = ViewMode.Decade;
                        break;
                    }
                case 3:
                    {
                        calendar.ViewMode = ViewMode.Century;
                        break;
                    }
            }
        }

        private void SelectionModePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as Picker).SelectedIndex)
            {
                case 0:
                    {
                        this.calendar.SelectionMode = SelectionMode.SingleSelection;
                        if (Device.RuntimePlatform == "Android" || Device.RuntimePlatform == "iOS")
                        {
                            this.calendar.Refresh();
                        }
                        else if (Device.RuntimePlatform == "UWP")
                        {
                            this.calendar.ShowNavigationButtons = false;
                        }
                    }

                    break;
                case 1:
                    {
                        this.calendar.SelectionMode = SelectionMode.MultiSelection;
                        if (Device.RuntimePlatform == "Android" || Device.RuntimePlatform == "iOS")
                        {
                            this.calendar.Refresh();
                        }
                        else if (Device.RuntimePlatform == "UWP")
                        {
                            this.calendar.ShowNavigationButtons = false;
                        }
                    }

                    break;
                case 2:
                    {
                        this.calendar.SelectionMode = SelectionMode.RangeSelection;
                        if (Device.RuntimePlatform == "Android" || Device.RuntimePlatform == "iOS")
                        {
                            this.calendar.Refresh();
                        }
                        else if (Device.RuntimePlatform == "UWP")
                        {
                            this.calendar.ShowNavigationButtons = true;
                        }
                    }

                    break;
                case 3:
                    {
                        this.calendar.SelectionMode = SelectionMode.MultiRangeSelection;
                        if (Device.RuntimePlatform == "Android" || Device.RuntimePlatform == "iOS")
                        {
                            this.calendar.Refresh();
                        }
                        else if (Device.RuntimePlatform == "UWP")
                        {
                            this.calendar.ShowNavigationButtons = true;
                        }
                    }

                    break;
            }
        }

        private void MinDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            this.calendar.MinDate = e.NewDate;
        }

        private void MaxDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            this.calendar.MaxDate = e.NewDate;
        }

        private void NavigationDirectionPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as Picker).SelectedIndex)
            {
                case 0:
                    {
                        this.calendar.NavigationDirection = NavigationDirection.Horizontal;
                    }

                    break;
                case 1:
                    {
                        this.calendar.NavigationDirection = NavigationDirection.Vertical;
                    }

                    break;
            }
        }

        private void HorizontalLinePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            MonthViewSettings monthViewSettings = new MonthViewSettings();
            switch ((sender as Picker).SelectedIndex)
            {
                case 0:
                    {
                        if (Device.RuntimePlatform == "UWP")
                        {
                            monthViewSettings.CellGridOptions = CellGridOptions.HorizontalLines;
                        }
                        else
                        {
                            this.calendar.MonthViewSettings.CellGridOptions = CellGridOptions.HorizontalLines;
                        }
                    }

                    break;
                case 1:
                    {
                        if (Device.RuntimePlatform == "UWP")
                        {
                            monthViewSettings.CellGridOptions = CellGridOptions.VerticalLines;
                        }
                        else
                        {
                            this.calendar.MonthViewSettings.CellGridOptions = CellGridOptions.VerticalLines;
                        }
                    }

                    break;
                case 2:
                    {
                        if (Device.RuntimePlatform == "UWP")
                        {
                            monthViewSettings.CellGridOptions = CellGridOptions.Both;
                        }
                        else
                        {
                            this.calendar.MonthViewSettings.CellGridOptions = CellGridOptions.Both;
                        }
                    }

                    break;
                case 3:
                    {
                        if (Device.RuntimePlatform == "UWP")
                        {
                            monthViewSettings.CellGridOptions = CellGridOptions.None;
                        }
                        else
                        {
                            this.calendar.MonthViewSettings.CellGridOptions = CellGridOptions.None;
                        }
                    }

                    if (Device.RuntimePlatform == "UWP")
                    {
                        this.calendar.MonthViewSettings = monthViewSettings;
                    }

                    break;
            }
        }

        private void YearViewPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as Picker).SelectedIndex)
            {
                case 0:
                    {
                        calendar.ShowYearView = true;
                    }

                    break;
                case 1:
                    {
                        calendar.ShowYearView = false;
                    }

                    break;
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

