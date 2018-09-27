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
using Xamarin.Forms;
using SampleBrowser.Core;

namespace SampleBrowser.SfCalendar
{
	public partial class CalendarLocalization_Default : SampleView
	{
		double width;

		public CalendarLocalization_Default()
		{
			InitializeComponent();
			calendar.Locale = new System.Globalization.CultureInfo("zh-CN");
			this.sampleSettings();
		}
        void sampleSettings()
        {
            width = Core.SampleBrowser.ScreenWidth;
            if (Device.Idiom == TargetIdiom.Tablet)
            {
                width /= 2;
            }

            MonthViewSettings monthSettings = new MonthViewSettings();
            monthSettings.DayHeight = 50;
            monthSettings.HeaderBackgroundColor = Color.White;
            monthSettings.InlineBackgroundColor = Color.FromHex("#EEEEEE");
            monthSettings.DateSelectionColor = Color.FromHex("#EEEEEE");
            monthSettings.TodayTextColor = Color.FromHex("#2196F3");
            monthSettings.SelectedDayTextColor = Color.Black;
            calendar.MonthViewSettings = monthSettings;
            if (Device.RuntimePlatform == "Android" ||(Device.RuntimePlatform == "UWP" && Device.Idiom == TargetIdiom.Desktop))
			{
				calendar.HeaderHeight = 50;
			}
			else if (Device.RuntimePlatform == "iOS")
			{
				calendar.HeaderHeight = 40;
			}

			localeLabel.WidthRequest = width / 2;

            if(Device.RuntimePlatform == "Android" || Device.RuntimePlatform == "iOS")
            {
                mainStack.Spacing = 10;
                mainStack.Padding = 10;
            }
            else if(Device.RuntimePlatform == "UWP" && Device.Idiom == TargetIdiom.Phone)
            {
                mainStack.Spacing = 50;
                mainStack.Padding = 10;
            }

			localePicker.Items.Add("Chinese");
			localePicker.Items.Add("Spanish");
			localePicker.Items.Add("English");
			localePicker.Items.Add("French");
			localePicker.SelectedIndex = 0;
			localePicker.SelectedIndexChanged += SelectionChangedPicker; ;
		}
		public View getContent()
		{
			return this.Content;
		}
		public View getPropertyView()
		{
			return this.PropertyView;
		}

		void SelectionChangedPicker(object sender, EventArgs e)
		{
			switch (localePicker.SelectedIndex)
			{
				case 0:
					{
						calendar.Locale = new System.Globalization.CultureInfo("zh-CN");
					}
					break;
				case 1:
					{
						calendar.Locale = new System.Globalization.CultureInfo("es-AR");
					}
					break;
				case 2:
					{
						calendar.Locale = new System.Globalization.CultureInfo("en-US");
					}
					break;
				case 3:
					{
						calendar.Locale = new System.Globalization.CultureInfo("fr-CA");
					}
					break;
			}
		}
	}
}


