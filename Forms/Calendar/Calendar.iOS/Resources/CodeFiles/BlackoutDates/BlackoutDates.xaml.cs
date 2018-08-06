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
	public partial class BlackoutDates : SampleView
	{
		List<DateTime> black_dates;
		public BlackoutDates()
		{
			InitializeComponent();
			this.setBlackOutDates();
			this.sampleSettings();
		}
       
		void sampleSettings()
		{
			this.Padding = new Thickness(-10);
			MonthViewSettings monthSettings = new MonthViewSettings();
			monthSettings.DayHeight = 50;
            monthSettings.HeaderBackgroundColor = Color.White;
			monthSettings.InlineBackgroundColor = Color.FromHex("#EEEEEE");
			monthSettings.DateSelectionColor = Color.FromHex("#EEEEEE");
			monthSettings.TodayTextColor = Color.FromHex("#2196F3");
			monthSettings.SelectedDayTextColor = Color.Black;
			calendar.MonthViewSettings = monthSettings;
			if (Device.OS == TargetPlatform.Android)
			{
				calendar.HeaderHeight = 50;
				//sampleLayout.Padding = new Thickness(10, 10, 10, 10);

			}
			else if (Device.OS == TargetPlatform.Windows)
			{
				calendar.HeaderHeight = 50;
				//sampleLayout.Padding = new Thickness(10, 10, 10, 10);
			}
			if (Device.OS == TargetPlatform.iOS)
			{
				calendar.HeaderHeight = 40;
				//sampleLayout.Padding = new Thickness(10, 10, 10, 0);
			}
			if (Device.OS == TargetPlatform.WinPhone)
			{
				//sampleLayout.Scale = 0.95;
			}
		}
		void setBlackOutDates()
		{
			black_dates = new List<DateTime>();
			for (int i = 0; i < 5; i++)
			{
				DateTime date = DateTime.Now.Date.AddDays(i + 7);
				black_dates.Add(date);
			}
			for (int i = 0; i < 5; i++)
			{
				DateTime date = DateTime.Now.Date.AddDays(i - 7);
				black_dates.Add(date);
			}
			calendar.BlackoutDates = black_dates;
		}
		public View getContent()
		{
			return this.Content;
		}
	}
}

