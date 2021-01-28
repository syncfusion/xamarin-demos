#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Calendar;
using Android.Graphics;
using Com.Syncfusion.Calendar.Enums;
using util = Java.Util;
using Java.Util;

namespace SampleBrowser
{
	public class CalendarBlackOutDates : SamplePage, IDisposable
	{
        /*********************************
         **Local Variable Inizialisation**
         *********************************/
        private FrameLayout mainView;
		private SfCalendar calendar;

        public override View GetSampleContent(Context context)
		{
           /************
            **Calendar**
            ************/
            calendar = new SfCalendar(context);
			calendar.ShowEventsInline = false;
			calendar.ViewMode = ViewMode.MonthView;					
			calendar.BlackoutDates = GetBlackOutDates();
			calendar.HeaderHeight = 100;
            
            //MonthViewSettings
			MonthViewLabelSetting labelSettings = new MonthViewLabelSetting();
			labelSettings.DateLabelSize = 14;
			MonthViewSettings monthViewSettings = new MonthViewSettings();
			monthViewSettings.MonthViewLabelSetting = labelSettings;
            monthViewSettings.SelectedDayTextColor = Color.Black;
			monthViewSettings.TodayTextColor = Color.ParseColor("#1B79D6");
			monthViewSettings.InlineBackgroundColor = Color.ParseColor("#E4E8ED");
			monthViewSettings.WeekDayBackgroundColor = Color.ParseColor("#F7F7F7");
			calendar.MonthViewSettings = monthViewSettings;

            //Main View
            mainView = new FrameLayout(context);
            mainView.AddView(calendar);
			return mainView;
		}

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        private List<util.Date> GetBlackOutDates()
        {
            List<util.Date> blackOutDates = new List<util.Date>();
            var date = Calendar.Instance;
            date.Set(CalendarField.Date, 10);
            blackOutDates.Add(date.Time);
            date.Set(CalendarField.Date, 12);
            blackOutDates.Add(date.Time);
            date.Set(CalendarField.Date, 14);
            blackOutDates.Add(date.Time);
            date.Set(CalendarField.Date, 16);
            blackOutDates.Add(date.Time);
            date.Set(CalendarField.Date, 18);
            blackOutDates.Add(date.Time);
            date.Set(CalendarField.Date, 20);
            blackOutDates.Add(date.Time);
            date.Add(CalendarField.Month, 2);
            date.Set(CalendarField.Date, 12);
            blackOutDates.Add(date.Time);
            date.Set(CalendarField.Date, 14);
            blackOutDates.Add(date.Time);
            date.Set(CalendarField.Date, 16);
            blackOutDates.Add(date.Time);
            date.Set(CalendarField.Date, 18);
            blackOutDates.Add(date.Time);
            date.Set(CalendarField.Date, 20);
            blackOutDates.Add(date.Time);
            date.Add(CalendarField.Month, -1);
            date.Set(CalendarField.Date, 6);
            blackOutDates.Add(date.Time);
            date.Set(CalendarField.Date, 8);
            blackOutDates.Add(date.Time);
            date.Set(CalendarField.Date, 10);
            blackOutDates.Add(date.Time);
            date.Set(CalendarField.Date, 12);
            blackOutDates.Add(date.Time);
            date.Set(CalendarField.Date, 14);
            blackOutDates.Add(date.Time);
            date.Set(CalendarField.Date, 16);
            blackOutDates.Add(date.Time);
            date.Set(CalendarField.Date, 18);
            blackOutDates.Add(date.Time);

            return blackOutDates;
        }

        public void Dispose()
        {
           if(calendar != null)
            {
                calendar.Dispose();
                calendar = null;
            }
            if (mainView != null)
            {
                mainView.Dispose();
                mainView = null;
            }
        }
    }
}