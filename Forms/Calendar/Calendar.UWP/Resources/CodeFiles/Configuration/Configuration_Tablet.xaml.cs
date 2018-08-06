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
	public partial class Configuration_Tablet : SampleView
	{
		double width;
		

		public Configuration_Tablet()
		{
			InitializeComponent();
            selectionModePicker.Items.Add("SingleSelection");
            selectionModePicker.Items.Add("MultiSelection");
            selectionModePicker.SelectedIndex = 0;
            minDatePicker.Date = new DateTime(2012, 1, 1);
            minDatePicker.Format = "D";
            minDatePicker.DateSelected += minDatePicker_DateSelected;
			
            maxDatePicker.Date = new DateTime(2018, 12, 1);
            maxDatePicker.Format = "D";
            maxDatePicker.DateSelected += maxDate_DateSelected;


			sampleSettings();
			getmonthSettings();
			eventsInitialization();
		}
        public View getPropertiesView()
        {
            return this.PropertyView;
        }

		void eventsInitialization()
		{
			calendar.OnMonthCellLoaded += (object sender, MonthCell args) =>
			 {
				 DateTime dTime = args.Date;
				 string s = dTime.DayOfWeek.ToString();
				 if (s.Equals("Sunday", StringComparison.CurrentCultureIgnoreCase) || s.Equals("Saturday", StringComparison.CurrentCultureIgnoreCase))
				 {
					 args.TextColor = Color.FromHex("#0990e9");
				 }
			 };
		}
		void getmonthSettings()
		{
			MonthViewSettings monthSettings = new MonthViewSettings();
			monthSettings.DayHeight = 50;
			monthSettings.WeekEndTextColor = Color.FromHex("#009688");
            monthSettings.HeaderBackgroundColor = Color.White;
			monthSettings.InlineBackgroundColor = Color.FromHex("#EEEEEE");
			monthSettings.DateSelectionColor = Color.FromHex("#EEEEEE");
			monthSettings.TodayTextColor = Color.FromHex("#2196F3");
			monthSettings.SelectedDayTextColor = Color.Black;
			calendar.MonthViewSettings = monthSettings;
		}
		void sampleSettings()
		{
			this.Padding = new Thickness(-10);
			if (Device.OS == TargetPlatform.iOS)
			{
				calendar.HeaderHeight = 40;
				this.Padding = new Thickness(-10, -30, -10, -10);
			}
			if (Device.OS == TargetPlatform.Android)
				calendar.HeaderHeight = 60;
			width = Core.SampleBrowser.ScreenWidth;
			if (Device.Idiom == TargetIdiom.Tablet)
			{
				width /= 2;
			}
		}

        public View getContent()
        {
            return this.Content;
        }
		public void maxDate_DateSelected(object c, DateChangedEventArgs e)
		{
			calendar.MaxDate = e.NewDate;
		}
		public void minDatePicker_DateSelected(object c, DateChangedEventArgs e)
		{
			calendar.MinDate = e.NewDate;
		}
		
		public void selectionModePicker_Changed(object c, EventArgs e)
		{
            switch (selectionModePicker.SelectedIndex)
            {
                case 0:
                    {
                        calendar.SelectionMode = SelectionMode.SingleSelection;
                        if (Device.OS == TargetPlatform.Android || Device.OS == TargetPlatform.iOS)
                        {
                            calendar.Refresh();
                        }
                    }
                    break;
                case 1:
                    {
                        calendar.SelectionMode = SelectionMode.MultiSelection;
                        if (Device.OS == TargetPlatform.Android || Device.OS == TargetPlatform.iOS)
                        {
                            calendar.Refresh();
                        }
                    }
                    break;
            }
		}
	}
}



