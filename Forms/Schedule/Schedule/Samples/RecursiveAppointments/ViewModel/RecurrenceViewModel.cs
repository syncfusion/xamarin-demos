#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfSchedule
{
	[Preserve(AllMembers = true)]
	public class RecurrenceViewModel
	{
		#region Properties

		public ScheduleAppointmentCollection RecursiveAppointmentCollection { get; set; }

		#endregion Properties

		#region Constructor

		public RecurrenceViewModel()
		{
			CreateRecurrsiveAppointments();

		}

		#endregion Constructor

		#region creating RecurrsiveAppointments

		//creating RecurrsiveAppointments
		private void CreateRecurrsiveAppointments()
		{
			RecursiveAppointmentCollection = new ScheduleAppointmentCollection();

			//Recurrence Appointment 1
			ScheduleAppointment alternativeDayAppointment = new ScheduleAppointment();
			DateTime currentDate = DateTime.Now;
			DateTime startTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 9, 0, 0);
			DateTime endTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 10, 0, 0);
			alternativeDayAppointment.StartTime = startTime;
			alternativeDayAppointment.EndTime = endTime;
			alternativeDayAppointment.Color = Color.FromHex("#FFA2C139");
			alternativeDayAppointment.Subject = "Occurs every 2 days";
			RecurrenceProperties recurrencePropertiesForAlternativeDay = new RecurrenceProperties();
			recurrencePropertiesForAlternativeDay.RecurrenceType = RecurrenceType.Daily;
			recurrencePropertiesForAlternativeDay.Interval = 2;
            recurrencePropertiesForAlternativeDay.RecurrenceRange = RecurrenceRange.Count;
			recurrencePropertiesForAlternativeDay.RecurrenceCount = 10;
            alternativeDayAppointment.RecurrenceRule = DependencyService.Get<IRecurrenceBuilder>().RRuleGenerator(recurrencePropertiesForAlternativeDay, alternativeDayAppointment.StartTime, alternativeDayAppointment.EndTime);
            RecursiveAppointmentCollection.Add(alternativeDayAppointment);

			//Recurrence Appointment 2
			ScheduleAppointment weeklyAppointment = new ScheduleAppointment();
			DateTime startTime1 = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 11, 0, 0);
			DateTime endTime1 = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 12, 0, 0);
			weeklyAppointment.StartTime = startTime1;
			weeklyAppointment.EndTime = endTime1;
			weeklyAppointment.Color = Color.FromHex("#FFD80073");
			weeklyAppointment.Subject = "Occurs every Monday";

			RecurrenceProperties recurrencePropertiesForWeeklyAppointment = new RecurrenceProperties();
			recurrencePropertiesForWeeklyAppointment.RecurrenceType = RecurrenceType.Weekly;
            recurrencePropertiesForWeeklyAppointment.RecurrenceRange = RecurrenceRange.Count;
			recurrencePropertiesForWeeklyAppointment.Interval = 1;
            recurrencePropertiesForWeeklyAppointment.WeekDays = WeekDays.Monday;
			recurrencePropertiesForWeeklyAppointment.RecurrenceCount = 10;
            weeklyAppointment.RecurrenceRule = DependencyService.Get<IRecurrenceBuilder>().RRuleGenerator(recurrencePropertiesForWeeklyAppointment, weeklyAppointment.StartTime, weeklyAppointment.EndTime);
            RecursiveAppointmentCollection.Add(weeklyAppointment);
		}

		#endregion creating RecurrsiveAppointments

	}
}

