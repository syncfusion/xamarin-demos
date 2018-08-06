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
	public partial class InlineEvents : SampleView
	{
		CalendarEventCollection calendarEventCollection;
		List<String> subjectCollection, colorCollection, subjectCollection2, colorCollection2;
		List<DateTime> startTimeCollection, endTimeCollection, startTimeCollection2, endTimeCollection2;

		public InlineEvents()
		{
			InitializeComponent();
			this.Padding = new Thickness(-10);
			MonthViewSettings monthSettings = new MonthViewSettings();
			monthSettings.DayHeight = 50;
			monthSettings.WeekEndTextColor = Color.FromHex("#009688");
            monthSettings.HeaderBackgroundColor = Color.White;
			monthSettings.InlineBackgroundColor = Color.FromHex("#EEEEEE");
			monthSettings.DateSelectionColor = Color.FromHex("#EEEEEE");
			monthSettings.TodayTextColor = Color.FromHex("#2196F3");
			monthSettings.SelectedDayTextColor = Color.Black;
			calendar.MonthViewSettings = monthSettings;
			if (Device.OS == TargetPlatform.Android)
			{
				calendar.HeaderHeight = 50;
			}
			else if (Device.OS == TargetPlatform.Windows)
			{
				calendar.HeaderHeight = 50;
			}
			if (Device.OS == TargetPlatform.iOS)
			{
				calendar.HeaderHeight = 40;
			}

            viewModePicker.Items.Add("Inline");
            viewModePicker.Items.Add("Agenda");
            viewModePicker.SelectedIndex = 0;
            viewModePicker.SelectedIndexChanged += ViewModePicker_SelectedIndexChanged; ; 
            calendarEventCollection = new CalendarEventCollection();
			setColors();
			setSubjects();
			setStartTime();
			setEndTime();
			for (int i = 0; i < 5; i++)
			{
				CalendarInlineEvent appointment = new CalendarInlineEvent();
				appointment.Color = Color.FromHex(colorCollection[i]);
				appointment.Subject = subjectCollection[i];
				appointment.StartTime = startTimeCollection[i];
				appointment.EndTime = endTimeCollection[i];
				calendarEventCollection.Add(appointment);
			}
			for (int i = 0; i < 5; i++)
			{
				CalendarInlineEvent appointment2 = new CalendarInlineEvent();
				appointment2.Color = Color.FromHex(colorCollection2[i]);
				appointment2.Subject = subjectCollection2[i];
				appointment2.StartTime = startTimeCollection2[i];
				appointment2.EndTime = endTimeCollection2[i];
				calendarEventCollection.Add(appointment2);
			}
			calendar.BindingContext = calendarEventCollection;

		}

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (Device.OS == TargetPlatform.iOS && Device.Idiom == TargetIdiom.Phone)
            {
                if (width > height)
                {
                    MonthViewSettings monthSettings = new MonthViewSettings();
                    monthSettings.DayHeight = 20;
                    monthSettings.DayCellFont = Font.SystemFontOfSize(10);
                    monthSettings.SelectionRadius = 5;
                    monthSettings.WeekEndTextColor = Color.FromHex("#009688");
                    monthSettings.HeaderBackgroundColor = Color.White;
                    monthSettings.InlineBackgroundColor = Color.FromHex("#EEEEEE");
                    monthSettings.DateSelectionColor = Color.FromHex("#EEEEEE");
                    monthSettings.TodayTextColor = Color.FromHex("#2196F3");
                    monthSettings.SelectedDayTextColor = Color.Black;
                    monthSettings.DateTextAlignment = DateTextAlignment.Center;
                    calendar.MonthViewSettings = monthSettings;
                }
                else
                {
                    MonthViewSettings monthSettings = new MonthViewSettings();
                    monthSettings.DayHeight = 50;
                    monthSettings.WeekEndTextColor = Color.FromHex("#009688");
                    monthSettings.HeaderBackgroundColor = Color.White;
                    monthSettings.InlineBackgroundColor = Color.FromHex("#EEEEEE");
                    monthSettings.DateSelectionColor = Color.FromHex("#EEEEEE");
                    monthSettings.TodayTextColor = Color.FromHex("#2196F3");
                    monthSettings.SelectedDayTextColor = Color.Black;
                    monthSettings.DateTextAlignment = DateTextAlignment.Center;
                    calendar.MonthViewSettings = monthSettings;
                }
            }
        }

        private void ViewModePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(viewModePicker.SelectedIndex)
            {
                case 0:
                    {
                        calendar.InlineViewMode = InlineViewMode.Inline;
                    }
                    break;
                case 1:
                    {
                        calendar.InlineViewMode = InlineViewMode.Agenda;
                    }
                    break;
            }
        }

        private void setSubjects()
		{
			subjectCollection = new List<String>();
			subjectCollection2 = new List<String>();
			subjectCollection.Add("IT file discussion with Clara");
			subjectCollection.Add("Submit audit report");
			subjectCollection.Add("Consulting IT related queries");
			subjectCollection.Add("IT file discussion with Clara");
			subjectCollection.Add("Submit audit report");
			subjectCollection2.Add("Submit audit report");
			subjectCollection2.Add("IT file discussion with Clara");
			subjectCollection2.Add("Submit audit report");
			subjectCollection2.Add("Consulting IT related queries");
			subjectCollection2.Add("IT file discussion with Clara");
			
		}
		private void setColors()
		{
			colorCollection = new List<String>();
			colorCollection.Add("#FFA2C139");
			colorCollection.Add("#FFD80073");
			colorCollection.Add("#FF1BA1E2");
			colorCollection.Add("#FFE671B8");
			colorCollection.Add("#FFF09609");
			colorCollection.Add("#FF339933");
			colorCollection.Add("#FF00ABA9");
			colorCollection.Add("#FFE671B8");
			colorCollection.Add("#FF1BA1E2");
			colorCollection.Add("#FFD80073");
			colorCollection.Add("#FFA2C139");
			colorCollection.Add("#FFD80073");
			colorCollection.Add("#FF339933");
			colorCollection.Add("#FFE671B8");
			colorCollection.Add("#FF00ABA9");
			colorCollection2 = new List<String>();
			colorCollection2.Add("#FF00ABA9");
			colorCollection2.Add("#FFE671B8");
			colorCollection2.Add("#FF339933");
			colorCollection2.Add("#FF339973");
			colorCollection2.Add("#FFA2C139");
			colorCollection2.Add("#FF00ABA9");
			colorCollection2.Add("#FFA2C139");
			colorCollection2.Add("#FFA2C139");
			colorCollection2.Add("#FF1BA1E2");
			colorCollection2.Add("#FFE671B8");
			colorCollection2.Add("#FF00ABA9");
			colorCollection2.Add("#FFE671B8");
			colorCollection2.Add("#FFA2C139");
			colorCollection2.Add("#FFA2C139");
			colorCollection2.Add("#FF1BA1E2");
			colorCollection2.Add("#FFA2C139");
		}
		private void setStartTime()
		{
			startTimeCollection = new List<DateTime>();
			startTimeCollection2 = new List<DateTime>();
			DateTime currentDate = DateTime.Now;
			for (int i = 0; i < 5; i++)
			{
				DateTime startTime = new DateTime(currentDate.Year, currentDate.Month, 12 + i, 3, 0, 0);
				startTimeCollection.Add(startTime);
				startTimeCollection2.Add(startTime);
			}
			for (int i = 0; i < 5; i++)
			{
				DateTime startTime = new DateTime(currentDate.Year, currentDate.Month, 12 + i, 7, 0, 0);
				startTimeCollection.Add(startTime);
				startTimeCollection2.Add(startTime);
			}

		}
		private void setEndTime()
		{
			endTimeCollection = new List<DateTime>();
			endTimeCollection2 = new List<DateTime>();
			DateTime currentDate = DateTime.Now;
			for (int i = 0; i < 5; i++)
			{
				DateTime endTime = new DateTime(currentDate.Year, currentDate.Month, 12 + i, 5, 0, 0);
				endTimeCollection.Add(endTime);
				endTimeCollection2.Add(endTime);
			}
			for (int i = 0; i < 5; i++)
			{
				DateTime endTime = new DateTime(currentDate.Year, currentDate.Month, 12 + i, 8, 0, 0);
				endTimeCollection.Add(endTime);
				endTimeCollection2.Add(endTime);
			}

		}
	}
}


