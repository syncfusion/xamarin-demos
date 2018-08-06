#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using SampleBrowser.Core;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfSchedule
{
    /// <summary>
    /// Load on demand behavior.
    /// </summary>
    public class LoadOnDemandBehavior : Behavior<SampleView>
    {
        private Syncfusion.SfSchedule.XForms.SfSchedule schedule; 
        private List<string> subjectCollection;

        protected override void OnAttachedTo(SampleView bindable)
        {
            base.OnAttachedTo(bindable);
			schedule = bindable.Content.FindByName<Syncfusion.SfSchedule.XForms.SfSchedule>("Schedule");
            this.CreateAppointmentSubjects();
			schedule.VisibleDatesChangedEvent += Schedule_VisibleDatesChangedEvent;        
        }

        /// <summary>
        /// Schedules the visible dates changed event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void Schedule_VisibleDatesChangedEvent(object sender, VisibleDatesChangedEventArgs e)
        {
			IntializeAppoitments(e.visibleDates.Count, e.visibleDates);
			schedule.MoveToDate=DateTime.Now.Date.AddHours(9);
        }

        /// <summary>
        /// Intializes the appoitments.
        /// </summary>
        /// <param name="count">Count.</param>
        /// <param name="visibleDates">Visible dates.</param>
        private void IntializeAppoitments(int count, List<DateTime> visibleDates)
        {
            ScheduleAppointmentCollection appointments = new ScheduleAppointmentCollection();
            var random = new Random();
            DateTime randomDate = new DateTime();

            // Adding Appointment based on Visible dates count
            for (int i = 0; i < count; i++)
            {
                var date = visibleDates[i];
                randomDate = visibleDates[random.Next(0, count)];

                // Two appointments per day 
                for (int a = 0; a < 2; a++)
                {
                    var scheduleAppointment = new ScheduleAppointment();
                    scheduleAppointment.StartTime = new DateTime(date.Year, date.Month, date.Day, random.Next(9, 18), 0, 0);
                    scheduleAppointment.EndTime = scheduleAppointment.StartTime.AddHours(1);
                    scheduleAppointment.Color = Color.FromRgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
                    scheduleAppointment.Subject = subjectCollection[random.Next(0, 25)];
                   
                    appointments.Add(scheduleAppointment);
                }
            }

            // Allday Appointment per view
            var alldayAppointment = new ScheduleAppointment();
            alldayAppointment.StartTime = new DateTime(randomDate.Year, randomDate.Month, randomDate.Day, random.Next(9, 18), 0, 0);
            alldayAppointment.EndTime = alldayAppointment.StartTime.AddHours(1);
            alldayAppointment.Color = Color.FromRgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            alldayAppointment.Subject = subjectCollection[random.Next(0, 25)];
            alldayAppointment.IsAllDay = true;
            appointments.Add(alldayAppointment);

            schedule.DataSource = appointments;
        }

        /// <summary>
        /// Creates the appointment subjects.
        /// </summary>
        private void CreateAppointmentSubjects()
        {
            subjectCollection = new List<string>();
            subjectCollection.Add("General Meeting");
            subjectCollection.Add("Plan Execution");
            subjectCollection.Add("Project Plan");
            subjectCollection.Add("Consulting");
            subjectCollection.Add("Performance Check");
            subjectCollection.Add("General Meeting");
            subjectCollection.Add("Plan Execution");
            subjectCollection.Add("Project Plan");
            subjectCollection.Add("Consulting");
            subjectCollection.Add("Performance Check");
            subjectCollection.Add("Business Meeting");
            subjectCollection.Add("Conference");
            subjectCollection.Add("Project Status Discussion");
            subjectCollection.Add("Auditing");
            subjectCollection.Add("Client Meeting");
            subjectCollection.Add("Generate Report");
            subjectCollection.Add("Target Meeting");
            subjectCollection.Add("Pay House Rent");
            subjectCollection.Add("Car Service");
            subjectCollection.Add("Feedback Meeting");
            subjectCollection.Add("E-Bill due");
            subjectCollection.Add("CheckUp");
            subjectCollection.Add("Rating Meeting");
            subjectCollection.Add("Sprint report");
            subjectCollection.Add("Team outing");
        }
        
        protected override void OnDetachingFrom(SampleView bindable)
        {
            base.OnDetachingFrom(bindable);
            schedule.VisibleDatesChangedEvent -= Schedule_VisibleDatesChangedEvent;
            schedule = null;
        }
    }
}
