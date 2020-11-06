#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
    /// Load On Demand Behavior class
    /// </summary>
    public class LoadOnDemandBehavior : Behavior<SampleView>
    {
        /// <summary>
        /// schedule initialize
        /// </summary>
        private Syncfusion.SfSchedule.XForms.SfSchedule schedule; 

        /// <summary>
        /// subject collection
        /// </summary>
        private List<string> subjectCollection;

        /// <summary>
        /// Begins when the behavior attached to the view
        /// </summary>
        /// <param name="bindable">bindable value</param>
        protected override void OnAttachedTo(SampleView bindable)
        {
            base.OnAttachedTo(bindable);
			this.schedule = bindable.Content.FindByName<Syncfusion.SfSchedule.XForms.SfSchedule>("Schedule");
            if (Device.RuntimePlatform == Device.Android)
            {
                this.schedule.ViewHeaderStyle.DateFontSize = 24;
            }

            this.CreateAppointmentSubjects();
            this.schedule.VisibleDatesChangedEvent += this.Schedule_VisibleDatesChangedEvent;        
        }

        /// <summary>
        /// Begins when the behavior attached to the view 
        /// </summary>
        /// <param name="bindable">bindable value</param>
        protected override void OnDetachingFrom(SampleView bindable)
        {
            base.OnDetachingFrom(bindable);
            this.schedule.VisibleDatesChangedEvent -= this.Schedule_VisibleDatesChangedEvent;
            this.schedule = null;
        }

        /// <summary>
        /// Schedules the visible dates changed event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Visible Dates Changed Event Args</param>
        private void Schedule_VisibleDatesChangedEvent(object sender, VisibleDatesChangedEventArgs e)
        {
            this.IntializeAppoitments(e.visibleDates.Count, e.visibleDates);
            this.schedule.MoveToDate = DateTime.Now.Date.AddHours(9);
        }

        /// <summary>
        /// Initialize the appointment.
        /// </summary>
        /// <param name="count">Count</param>
        /// <param name="visibleDates">Visible dates</param>
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
                    scheduleAppointment.Subject = this.subjectCollection[random.Next(0, 25)];

                    appointments.Add(scheduleAppointment);
                }
            }

            // Allday Appointment per view
            var alldayAppointment = new ScheduleAppointment();
            alldayAppointment.StartTime = new DateTime(randomDate.Year, randomDate.Month, randomDate.Day, random.Next(9, 18), 0, 0);
            alldayAppointment.EndTime = alldayAppointment.StartTime.AddHours(1);
            alldayAppointment.Color = Color.FromRgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            alldayAppointment.Subject = this.subjectCollection[random.Next(0, 25)];
            alldayAppointment.IsAllDay = true;
            appointments.Add(alldayAppointment);

            this.schedule.DataSource = appointments;
        }

        /// <summary>
        /// Creates the appointment subjects.
        /// </summary>
        private void CreateAppointmentSubjects()
        {
            this.subjectCollection = new List<string>();
            this.subjectCollection.Add("General Meeting");
            this.subjectCollection.Add("Plan Execution");
            this.subjectCollection.Add("Project Plan");
            this.subjectCollection.Add("Consulting");
            this.subjectCollection.Add("Performance Check");
            this.subjectCollection.Add("General Meeting");
            this.subjectCollection.Add("Plan Execution");
            this.subjectCollection.Add("Project Plan");
            this.subjectCollection.Add("Consulting");
            this.subjectCollection.Add("Performance Check");
            this.subjectCollection.Add("Business Meeting");
            this.subjectCollection.Add("Conference");
            this.subjectCollection.Add("Project Status Discussion");
            this.subjectCollection.Add("Auditing");
            this.subjectCollection.Add("Client Meeting");
            this.subjectCollection.Add("Generate Report");
            this.subjectCollection.Add("Target Meeting");
            this.subjectCollection.Add("Pay House Rent");
            this.subjectCollection.Add("Car Service");
            this.subjectCollection.Add("Feedback Meeting");
            this.subjectCollection.Add("E-Bill due");
            this.subjectCollection.Add("CheckUp");
            this.subjectCollection.Add("Rating Meeting");
            this.subjectCollection.Add("Sprint report");
            this.subjectCollection.Add("Team outing");
        }
    }
}
