#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfCalendar.XForms;
using SampleBrowser.Core;
using Xamarin.Forms;

namespace SampleBrowser.SfCalendar
{
	public partial class Configuration_Default : SampleView
	{
		double width;
        public Configuration_Default()
		{
			InitializeComponent();

            MonthViewSettings monthSettings = new MonthViewSettings();
            monthSettings.DayHeight = 50;
			monthSettings.WeekEndTextColor = Color.FromHex("#009688");
            monthSettings.HeaderBackgroundColor = Color.White;
			monthSettings.InlineBackgroundColor = Color.FromHex("#EEEEEE");
			monthSettings.DateSelectionColor = Color.FromHex("#EEEEEE");
			monthSettings.TodayTextColor = Color.FromHex("#2196F3");
			monthSettings.SelectedDayTextColor = Color.Black;
            
			calendar.MonthViewSettings = monthSettings;
			if (Device.RuntimePlatform == "Android" || (Device.RuntimePlatform == "UWP" && Device.Idiom == TargetIdiom.Desktop))
			{
				calendar.HeaderHeight = 50;
			}
			if (Device.RuntimePlatform == "UWP" && Device.Idiom == TargetIdiom.Desktop)
			{
				mainStack.Children.Remove(selectionmodeLayout);
			}
			//monthViewSettings();
			this.sampleSettings();
			eventsInitialization();
		}
		void eventsInitialization()
		{
			selectionModePicker.Items.Add("Single Selection");
			selectionModePicker.Items.Add("Multi Selection");
			selectionModePicker.SelectedIndex = 0;
			selectionModePicker.SelectedIndexChanged += (object sender, EventArgs e) =>
			 {
                 switch (selectionModePicker.SelectedIndex)
                 {
                     case 0:
                         {
                             calendar.SelectionMode = SelectionMode.SingleSelection;
                             if (Device.RuntimePlatform == "Android" || Device.RuntimePlatform == "iOS")
                             {
                                calendar.Refresh();
                             }
                         }
                         break;
                     case 1:
                         {
                             calendar.SelectionMode = SelectionMode.MultiSelection;
                             if (Device.RuntimePlatform == "Android" || Device.RuntimePlatform == "iOS")
                             {
                                 calendar.Refresh();
                             }
                         }
                         break;
                 }
			 };
			minDatePicker.DateSelected += (object sender, DateChangedEventArgs e) =>
			 {
				 calendar.MinDate = e.NewDate;
			 };
			maxDatePicker.DateSelected += (object sender, DateChangedEventArgs e) =>
			 {
				 calendar.MaxDate = e.NewDate;
			 };

            navigationDirectionPicker.Items.Add("Horizontal");
            navigationDirectionPicker.Items.Add("Vertical");
            navigationDirectionPicker.SelectedIndex = 0;
           

            navigationDirectionPicker.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                switch (navigationDirectionPicker.SelectedIndex)
                {
                    case 0:
                        {

                            calendar.NavigationDirection = NavigationDirection.Horizontal;
                        }
                        break;
                    case 1:
                        {
                            calendar.NavigationDirection = NavigationDirection.Vertical;
                        }
                        break;

                }
            };

            horizontalLinePicker.Items.Add("Horizontal");
            horizontalLinePicker.Items.Add("Vertical");
            horizontalLinePicker.Items.Add("Both");
            horizontalLinePicker.Items.Add("None");
            horizontalLinePicker.SelectedIndex = 0;

            horizontalLinePicker.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                MonthViewSettings monthSettings = new MonthViewSettings();

                switch (horizontalLinePicker.SelectedIndex)
                {
                    case 0:
                        {
                            monthSettings.CellGridOptions=CellGridOptions.HorizontalLines;

                        }
                        break;
                    case 1:
                        {
                            monthSettings.CellGridOptions = CellGridOptions.VerticalLines;

                        }
                        break;
                        case 2:
                        {
                            monthSettings.CellGridOptions = CellGridOptions.Both;

                        }
                        break;
                    case 3:
                        {
                            monthSettings.CellGridOptions = CellGridOptions.None;

                        }
                        break;


                }
                calendar.MonthViewSettings = monthSettings;

            };

            yearViewPicker.Items.Add("True");
            yearViewPicker.Items.Add("False");
            yearViewPicker.SelectedIndex = 0;
            yearViewPicker.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                switch (yearViewPicker.SelectedIndex)
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
            };


        }
		void monthViewSettings()
		{
			MonthViewSettings monthSettings = new MonthViewSettings();
			monthSettings.DateSelectionColor = Color.FromRgb(161, 161, 161);
			calendar.MonthViewSettings = monthSettings;
		}
		void sampleSettings()
		{
			width = Core.SampleBrowser.ScreenWidth;
			if (Device.Idiom == TargetIdiom.Tablet)
			{
				width /= 2;
			}
			if (Device.RuntimePlatform == "Android" || (Device.RuntimePlatform == "UWP"&& Device.Idiom== TargetIdiom.Desktop))
			{
				calendar.HeaderHeight = 50;
			}
            if (Device.RuntimePlatform == "iOS" || Device.RuntimePlatform == "Android")
            {
                mainStack.Spacing = 10;
                mainStack.Padding = 10;
            }
            else if (Device.RuntimePlatform == "UWP" && Device.Idiom == TargetIdiom.Phone)
            {
                mainStack.Spacing = 50;
                mainStack.Padding = 10;
            }

            if (Device.RuntimePlatform == "UWP" && Device.Idiom == TargetIdiom.Desktop)
            {
                calendar.HeaderHeight = 40;
            }
			
			selectionModeLabel.WidthRequest = width / 2;
		}
		public View getContent()
		{
			return this.Content;
		}
		public View getPropertyView()
		{
			return this.PropertyView;
		}
	}
}
