#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.Content;
using Com.Syncfusion.Schedule;
using Com.Syncfusion.Schedule.Enums;
using Android.Views;
using Android.Widget;
using Java.Util;
using System.Collections.Generic;
using Android.Graphics;
using Java.Text;

namespace SampleBrowser
{
	public class Recurrence : SamplePage, IDisposable
	{
		public Recurrence()
		{
		}

		private SfSchedule sfschedule;

		public override View GetSampleContent(Context con)
		{
			sfschedule = new SfSchedule(con);
			sfschedule.ScheduleView = ScheduleView.MonthView;
			sfschedule.FirstDayOfWeek = 1;
			GetAppointments();
			sfschedule.ItemsSource = appointmentCollection;
			MonthViewSettings monthViewSettings = new MonthViewSettings();
			monthViewSettings.ShowAppointmentsInline = true;
			sfschedule.MonthViewSettings = monthViewSettings;
			sfschedule.EnableNavigation = true;
			
			return sfschedule;
		}
        		
		private ScheduleAppointmentCollection appointmentCollection;

		//Creating appointments for ScheduleAppointmentCollection
		public void GetAppointments()
		{
			appointmentCollection = new ScheduleAppointmentCollection();

			//Recurrence Appointment 1
			ScheduleAppointment appointment1 = new ScheduleAppointment();
			Calendar currentDate = Calendar.Instance;
			Calendar startTime = (Calendar)currentDate.Clone();
			Calendar endTime = (Calendar)currentDate.Clone();
			startTime.Set(
				currentDate.Get(CalendarField.Year),
				currentDate.Get(CalendarField.Month),
				currentDate.Get(CalendarField.DayOfMonth),
				4, 
                0, 
                0);
			endTime.Set(
				currentDate.Get(CalendarField.Year),
				currentDate.Get(CalendarField.Month),
				currentDate.Get(CalendarField.DayOfMonth),
				6, 
                0, 
                0);
			appointment1.StartTime = startTime;
			appointment1.EndTime = endTime;
			appointment1.Color = Color.ParseColor("#FF1BA1E2");
			appointment1.Subject = "Occurs once in every two days";
			RecurrenceProperties recurrenceProp1 = new RecurrenceProperties();
			recurrenceProp1.RecurrenceType = RecurrenceType.Daily;
			recurrenceProp1.Interval = 2;
            recurrenceProp1.RecurrenceRange = RecurrenceRange.Count;
            recurrenceProp1.RecurrenceCount = 10;
			appointment1.RecurrenceRule = ScheduleHelper.RRuleGenerator(recurrenceProp1, appointment1.StartTime, appointment1.EndTime);
            appointmentCollection.Add(appointment1);

			//Recurrence Appointment 2
			ScheduleAppointment scheduleAppointment1 = new ScheduleAppointment();
			Calendar currentDate1 = Calendar.Instance;
			Calendar startTime1 = (Calendar)currentDate1.Clone();
			Calendar endTime1 = (Calendar)currentDate1.Clone();
			startTime1.Set(
				currentDate.Get(CalendarField.Year),
				currentDate.Get(CalendarField.Month),
				currentDate.Get(CalendarField.DayOfMonth),
				10, 
                0,
                0);
			endTime1.Set(
				currentDate.Get(CalendarField.Year),
				currentDate.Get(CalendarField.Month),
				currentDate.Get(CalendarField.DayOfMonth),
				12, 
                0, 
                0);

			scheduleAppointment1.StartTime = startTime1;
			scheduleAppointment1.EndTime = endTime1;
			scheduleAppointment1.Color = Color.ParseColor("#FFD80073");
			scheduleAppointment1.Subject = "Occurs every Monday";
			RecurrenceProperties recurrenceProperties1 = new RecurrenceProperties();
			recurrenceProperties1.RecurrenceType = RecurrenceType.Weekly;
            recurrenceProperties1.RecurrenceRange = RecurrenceRange.Count;
			recurrenceProperties1.Interval = 1;
            recurrenceProperties1.WeekDays = WeekDays.Monday;
			recurrenceProperties1.RecurrenceCount = 10;
			scheduleAppointment1.RecurrenceRule = ScheduleHelper.RRuleGenerator(recurrenceProperties1, scheduleAppointment1.StartTime, scheduleAppointment1.EndTime); 

			appointmentCollection.Add(scheduleAppointment1);
		}

		public void OnNothingSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			sfschedule.ScheduleView = ScheduleView.WeekView;
		}

        public void Dispose()
        {
           if (sfschedule != null)
            {
                sfschedule.Dispose();
                sfschedule = null;
            }
        }
    }
}