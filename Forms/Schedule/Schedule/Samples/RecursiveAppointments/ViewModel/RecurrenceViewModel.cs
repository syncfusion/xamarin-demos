#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
    /// <summary>
    /// Recurrence View Model class
    /// </summary>
	[Preserve(AllMembers = true)]
	public class RecurrenceViewModel
	{
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RecurrenceViewModel" /> class.
        /// </summary>
        public RecurrenceViewModel()
		{
			this.CreateRecurrsiveAppointments();
		}

        #endregion Constructor
        #region Properties

        /// <summary>
        /// Gets or sets recursive appointment collection
        /// </summary>
        public ScheduleAppointmentCollection RecursiveAppointmentCollection
        {
            get;
            set;
        }

        #endregion Properties

        #region creating RecurrsiveAppointments

        /// <summary>
        /// recursive appointments
        /// </summary>
        ////creating RecurrsiveAppointments
        private void CreateRecurrsiveAppointments()
		{
			this.RecursiveAppointmentCollection = new ScheduleAppointmentCollection();

			//Recurrence Appointment 1
			ScheduleAppointment alternativeDayAppointment = new ScheduleAppointment();
			DateTime currentDate = DateTime.Now;
			DateTime startTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 9, 0, 0);
			DateTime endTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 10, 0, 0);
			alternativeDayAppointment.StartTime = startTime;
			alternativeDayAppointment.EndTime = endTime;
			alternativeDayAppointment.Color = Color.FromHex("#FFA2C139");
			alternativeDayAppointment.Subject = "Scrum meeting";
			RecurrenceProperties recurrencePropertiesForAlternativeDay = new RecurrenceProperties();
			recurrencePropertiesForAlternativeDay.RecurrenceType = RecurrenceType.Daily;
			recurrencePropertiesForAlternativeDay.Interval = 2;
            recurrencePropertiesForAlternativeDay.RecurrenceRange = RecurrenceRange.Count;
			recurrencePropertiesForAlternativeDay.RecurrenceCount = 10;
            alternativeDayAppointment.RecurrenceRule = DependencyService.Get<IRecurrenceBuilder>().RRuleGenerator(recurrencePropertiesForAlternativeDay, alternativeDayAppointment.StartTime, alternativeDayAppointment.EndTime);
            this.RecursiveAppointmentCollection.Add(alternativeDayAppointment);

			//Recurrence Appointment 2
			ScheduleAppointment weeklyAppointment = new ScheduleAppointment();
			DateTime startTime1 = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 11, 0, 0);
			DateTime endTime1 = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 12, 0, 0);
			weeklyAppointment.StartTime = startTime1;
			weeklyAppointment.EndTime = endTime1;
			weeklyAppointment.Color = Color.FromHex("#FFD80073");
			weeklyAppointment.Subject = "Weekly product development status";

			RecurrenceProperties recurrencePropertiesForWeeklyAppointment = new RecurrenceProperties();
			recurrencePropertiesForWeeklyAppointment.RecurrenceType = RecurrenceType.Weekly;
            recurrencePropertiesForWeeklyAppointment.RecurrenceRange = RecurrenceRange.Count;
			recurrencePropertiesForWeeklyAppointment.Interval = 1;
            recurrencePropertiesForWeeklyAppointment.WeekDays = WeekDays.Monday;
			recurrencePropertiesForWeeklyAppointment.RecurrenceCount = 10;
            weeklyAppointment.RecurrenceRule = DependencyService.Get<IRecurrenceBuilder>().RRuleGenerator(recurrencePropertiesForWeeklyAppointment, weeklyAppointment.StartTime, weeklyAppointment.EndTime);
            this.RecursiveAppointmentCollection.Add(weeklyAppointment);

            //Recurrence Appointment 3
            ScheduleAppointment lastWeekOfMonth = new ScheduleAppointment();
            DateTime startTime2 = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 11, 0, 0);
            DateTime endTime2 = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 12, 0, 0);
            lastWeekOfMonth.StartTime = startTime2;
            lastWeekOfMonth.EndTime = endTime2;
            lastWeekOfMonth.Color = Color.Red;
            lastWeekOfMonth.Subject = "Retrospective Meeting";

            RecurrenceProperties recurrencePropertiesForLastWeekOfMonth = new RecurrenceProperties();
            recurrencePropertiesForLastWeekOfMonth.RecurrenceType = RecurrenceType.Monthly;
            recurrencePropertiesForLastWeekOfMonth.RecurrenceRange = RecurrenceRange.Count;
            recurrencePropertiesForLastWeekOfMonth.Interval = 1;
            recurrencePropertiesForLastWeekOfMonth.Week = -1;
            recurrencePropertiesForLastWeekOfMonth.DayOfWeek=5;
            recurrencePropertiesForLastWeekOfMonth.RecurrenceCount = 10;
            lastWeekOfMonth.RecurrenceRule = DependencyService.Get<IRecurrenceBuilder>().RRuleGenerator(recurrencePropertiesForLastWeekOfMonth, lastWeekOfMonth.StartTime, lastWeekOfMonth.EndTime);
            this.RecursiveAppointmentCollection.Add(lastWeekOfMonth);


        }

		#endregion creating RecurrsiveAppointments
	}
}