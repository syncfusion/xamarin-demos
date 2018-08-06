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
	public class CalendarBlackOutDates : SamplePage
	{
        /*********************************
         **Local Variable Inizialisation**
         *********************************/
        FrameLayout mainView;
		SfCalendar calendar;

		public override View GetSampleContent (Context context)
		{
           /************
            **Calendar**
            ************/
            calendar = new SfCalendar(context);
			calendar.ShowEventsInline = false;
			calendar.ViewMode=ViewMode.MonthView;					
			calendar.BlackoutDates= GetBlackOutDates();
			calendar.HeaderHeight = 100;
            //MonthViewSettings
			MonthViewLabelSetting labelSettings = new MonthViewLabelSetting();
			labelSettings.DateLabelSize = 14;
			MonthViewSettings monthViewSettings = new MonthViewSettings();
			monthViewSettings.MonthViewLabelSetting = labelSettings;
			monthViewSettings.TodayTextColor=Color.ParseColor("#1B79D6");
			monthViewSettings.InlineBackgroundColor=Color.ParseColor("#E4E8ED");
			monthViewSettings.WeekDayBackgroundColor=Color.ParseColor("#F7F7F7");
			calendar.MonthViewSettings=monthViewSettings;
			calendar.UpdateCalendar();

            //Main View
            mainView = new FrameLayout(context);
            mainView.AddView(calendar);
			return mainView;
		}

        private List<util.Date> GetBlackOutDates()
        {
            List<util.Date> blackOutDates = new List<util.Date>();
            blackOutDates.Add(new util.Date(Calendar.Instance.Get(CalendarField.Year), Calendar.Instance.Get(CalendarField.Month), 10));
            blackOutDates.Add(new util.Date(Calendar.Instance.Get(CalendarField.Year), Calendar.Instance.Get(CalendarField.Month), 12));
            blackOutDates.Add(new util.Date(Calendar.Instance.Get(CalendarField.Year), Calendar.Instance.Get(CalendarField.Month), 14));
            blackOutDates.Add(new util.Date(Calendar.Instance.Get(CalendarField.Year), Calendar.Instance.Get(CalendarField.Month), 16));
            blackOutDates.Add(new util.Date(Calendar.Instance.Get(CalendarField.Year), Calendar.Instance.Get(CalendarField.Month), 18));
            blackOutDates.Add(new util.Date(Calendar.Instance.Get(CalendarField.Year), Calendar.Instance.Get(CalendarField.Month), 20));
            blackOutDates.Add(new util.Date(Calendar.Instance.Get(CalendarField.Year), Calendar.Instance.Get(CalendarField.Month) + 2, 12));
            blackOutDates.Add(new util.Date(Calendar.Instance.Get(CalendarField.Year), Calendar.Instance.Get(CalendarField.Month) + 2, 14));
            blackOutDates.Add(new util.Date(Calendar.Instance.Get(CalendarField.Year), Calendar.Instance.Get(CalendarField.Month) + 1, 16));
            blackOutDates.Add(new util.Date(Calendar.Instance.Get(CalendarField.Year), Calendar.Instance.Get(CalendarField.Month) + 2, 18));
            blackOutDates.Add(new util.Date(Calendar.Instance.Get(CalendarField.Year), Calendar.Instance.Get(CalendarField.Month) + 2, 20));
            blackOutDates.Add(new util.Date(Calendar.Instance.Get(CalendarField.Year), Calendar.Instance.Get(CalendarField.Month) + 1, 6));
            blackOutDates.Add(new util.Date(Calendar.Instance.Get(CalendarField.Year), Calendar.Instance.Get(CalendarField.Month) + 1, 8));
            blackOutDates.Add(new util.Date(Calendar.Instance.Get(CalendarField.Year), Calendar.Instance.Get(CalendarField.Month) + 1, 12));
            blackOutDates.Add(new util.Date(Calendar.Instance.Get(CalendarField.Year), Calendar.Instance.Get(CalendarField.Month) + 1, 10));
            blackOutDates.Add(new util.Date(Calendar.Instance.Get(CalendarField.Year), Calendar.Instance.Get(CalendarField.Month) + 1, 16));
            blackOutDates.Add(new util.Date(Calendar.Instance.Get(CalendarField.Year), Calendar.Instance.Get(CalendarField.Month) + 1, 18));

            return blackOutDates;
        }
    }
}

