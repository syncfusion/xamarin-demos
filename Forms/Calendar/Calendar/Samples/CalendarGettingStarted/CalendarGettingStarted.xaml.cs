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
	public partial class CalendarGettingStarted : SampleView
	{
		double width;
      
		public CalendarGettingStarted()
		{
			InitializeComponent();
            //SizeChanged += OnSizeChanged;
			this.sampleSettings();
           
		}
        protected override void OnSizeAllocated(double width, double height)
        {
        }
        //void OnSizeChanged(object sender, EventArgs e)
        //{
        //}
       
		void sampleSettings()
		{
			width = Core.SampleBrowser.ScreenWidth;
			MonthViewSettings monthSettings = new MonthViewSettings();
			monthSettings.DayHeight = 50;
            monthSettings.HeaderBackgroundColor = Color.White;
			monthSettings.InlineBackgroundColor = Color.FromHex("#F5F5F5");
			monthSettings.DateSelectionColor = Color.FromHex("#E0E0E0");
			monthSettings.TodayTextColor = Color.FromHex("#2196F3");
			cal.MonthViewSettings = monthSettings;
            if (Device.RuntimePlatform == "Android" || (Device.RuntimePlatform == "UWP"&& Device.Idiom == TargetIdiom.Desktop))
			{
				cal.HeaderHeight = 50;
			}
			if (Device.Idiom == TargetIdiom.Tablet)
			{
				width /= 2;
			}

			if (Device.RuntimePlatform == "iOS")
			{
				cal.HeaderHeight = 40;
			}
		}
	}
}

