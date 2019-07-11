#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// <copyright file="CalendargettingStarted.xaml.cs" company="Syncfusion">
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace SampleBrowser.SfCalendar
{
    using System;
    using System.Collections.Generic;
    using SampleBrowser.Core;
    using Syncfusion.SfCalendar.XForms;
    using Xamarin.Forms;

    /// <summary>
    /// Calendar Getting started sample 
    /// </summary>
	public partial class CalendarGettingStarted : SampleView
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="CalendarGettingStarted" /> class
        /// </summary>
        public CalendarGettingStarted()
		{
			this.InitializeComponent(); 
			this.SampleSettings();           
		}

        /// <summary>
        /// Sample Settings
        /// </summary>
        private void SampleSettings()
        {
            var monthSettings = new MonthViewSettings();
            monthSettings.DayHeight = 50;
            monthSettings.HeaderBackgroundColor = Color.White;
            monthSettings.InlineBackgroundColor = Color.FromHex("#F5F5F5");
            monthSettings.DateSelectionColor = Color.FromHex("#E0E0E0");
            monthSettings.TodayTextColor = Color.FromHex("#2196F3");
            cal.MonthViewSettings = monthSettings;
            if (Device.RuntimePlatform == "Android" || (Device.RuntimePlatform == "UWP" && Device.Idiom == TargetIdiom.Desktop))
            {
                cal.HeaderHeight = 50;
            }

            if (Device.RuntimePlatform == "iOS")
            {
                cal.HeaderHeight = 40;
            }
        }
	}
}