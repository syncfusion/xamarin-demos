﻿#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Calendar;
using Com.Syncfusion.Calendar.Enums;
using Java.Util;
using System;
using System.Collections.Generic;

namespace SampleBrowser
{
    public class InlineEvents : SamplePage, IDisposable
    {
        /*********************************
         **Local Variable Initialization**
         *********************************/
        private List<Calendar> startTimeCollection, endTimeCollection;
        private List<String> subjectCollection, colorCollection;
        private CalendarEventCollection appointmentCollection;
        private FrameLayout mainView;
        private SfCalendar calendar;

        public override View GetSampleContent(Context context)
        {
            /************
             **Calendar**
             ************/
            calendar = new SfCalendar(context);
            calendar.ViewMode = ViewMode.MonthView;
            calendar.ShowEventsInline = true;
            GetAppointments();
            calendar.DataSource = appointmentCollection;
            calendar.HeaderHeight = 100;

            //Month View Settings
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

        /***********************************************************
         **Creating appointments for ScheduleAppointmentCollection**
         ***********************************************************/
        private void GetAppointments()
        {
            appointmentCollection = new CalendarEventCollection();
            SetColors();
            SetSubjects();
            SetStartTime();
            SetEndTime();
            for (int i = 0; i < 15; i++)
            {
                CalendarInlineEvent appointment = new CalendarInlineEvent();
                appointment.Color = Color.ParseColor(colorCollection[i]);
                appointment.Subject = subjectCollection[i];
                appointment.StartTime = startTimeCollection[i];
                appointment.EndTime = endTimeCollection[i];
                appointmentCollection.Add(appointment);
            }
        }

        /******************************
         **Adding Subjects Collection**
         ******************************/
        private void SetSubjects()
        {
            subjectCollection = new List<String>();
            subjectCollection.Add("GoToMeeting");
            subjectCollection.Add("Business Meeting");
            subjectCollection.Add("Conference");
            subjectCollection.Add("Project Status Discussion");
            subjectCollection.Add("Auditing");
            subjectCollection.Add("Client Meeting");
            subjectCollection.Add("Generate Report");
            subjectCollection.Add("Target Meeting");
            subjectCollection.Add("General Meeting");
            subjectCollection.Add("Pay House Rent");
            subjectCollection.Add("Car Service");
            subjectCollection.Add("Medical Check Up");
            subjectCollection.Add("Wedding Anniversary");
            subjectCollection.Add("Sam's Birthday");
            subjectCollection.Add("Jenny's Birthday");
        }

        /****************************
         **Adding Colors Collection**
         ****************************/
        private void SetColors()
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
        }

        /*******************************
         **Adding StartTime Collection**
         *******************************/
        private void SetStartTime()
        {
            startTimeCollection = new List<Calendar>();
            Calendar currentDate = Calendar.Instance;
            for (int i = 0; i < 5; i++)
            {
                Calendar startTime = (Calendar)currentDate.Clone();
                startTime.Set(
                    currentDate.Get(CalendarField.Year),
                    currentDate.Get(CalendarField.Month),
                    currentDate.Get(CalendarField.DayOfMonth) + i,
                    3,
                    0,
                    0);
                startTimeCollection.Add(startTime);
            }

            for (int i = 0; i < 5; i++)
            {
                Calendar startTime = (Calendar)currentDate.Clone();
                startTime.Set(
                    currentDate.Get(CalendarField.Year),
                    currentDate.Get(CalendarField.Month),
                    currentDate.Get(CalendarField.DayOfMonth) + i,
                    11,
                    0,
                    0);
                startTimeCollection.Add(startTime);
            }

            for (int i = 10; i < 20; i++)
            {
                Calendar startTime = (Calendar)currentDate.Clone();
                startTime.Set(
                    currentDate.Get(CalendarField.Year),
                    currentDate.Get(CalendarField.Month),
                    currentDate.Get(CalendarField.DayOfMonth) + i,
                    17,
                    0,
                    0);
                startTimeCollection.Add(startTime);
            }
        }

        /*****************************
         **Adding EndTime Collection**
         *****************************/
        private void SetEndTime()
        {
            endTimeCollection = new List<Calendar>();
            Calendar currentDate = Calendar.Instance;
            for (int i = 0; i < 5; i++)
            {
                Calendar endTime = (Calendar)currentDate.Clone();
                endTime.Set(
                    currentDate.Get(CalendarField.Year),
                    currentDate.Get(CalendarField.Month),
                    currentDate.Get(CalendarField.DayOfMonth) + i,
                    5,
                    0,
                    0);
                endTimeCollection.Add(endTime);
            }

            for (int i = 0; i < 5; i++)
            {
                Calendar endTime = (Calendar)currentDate.Clone();
                endTime.Set(
                    currentDate.Get(CalendarField.Year),
                    currentDate.Get(CalendarField.Month),
                    currentDate.Get(CalendarField.DayOfMonth) + i,
                    12,
                    0,
                    0);
                endTimeCollection.Add(endTime);
            }

            for (int i = 10; i < 20; i++)
            {
                Calendar endTime = (Calendar)currentDate.Clone();
                endTime.Set(
                    currentDate.Get(CalendarField.Year),
                    currentDate.Get(CalendarField.Month),
                    currentDate.Get(CalendarField.DayOfMonth) + i,
                    18,
                    0,
                    0);
                endTimeCollection.Add(endTime);
            }
        }

        public void Dispose()
        {
            if (calendar != null)
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