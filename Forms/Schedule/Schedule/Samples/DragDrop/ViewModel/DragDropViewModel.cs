#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfSchedule
{
    /// <summary>
    /// Drag and Drop View Model class
    /// </summary>
    [Preserve(AllMembers = true)]
    public class DragDropViewModel : INotifyPropertyChanged
    {
        #region Properties

        /// <summary>
        /// team management
        /// </summary>
        private List<string> teamManagement;

        /// <summary>
        /// all day team management
        /// </summary>
        private List<string> allDayTeamManagement;

        /// <summary>
        /// color collection
        /// </summary>
        private List<Color> colorCollection;

        /// <summary>
        /// start time collection
        /// </summary>
        private List<DateTime> startTimeCollection;

        /// <summary>
        /// end time collection
        /// </summary>
        private List<DateTime> endTimeCollection;

        /// <summary>
        /// work start hour value
        /// </summary>
        private double workStartHour = 8;

        /// <summary>
        /// end hour value
        /// </summary>
        private double endHour = 16;

        /// <summary>
        /// random numbers
        /// </summary>
        ////creating random number collection
        private List<int> randomNums = new List<int>();

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DragDropViewModel" /> class.
        /// </summary>
        public DragDropViewModel()
        {
            this.Appointments = new ScheduleAppointmentCollection();
            this.CreateRandomNumbersCollection();
            this.CreateStartTimeCollection();
            this.CreateEndTimeCollection();
            this.CreateSubjectCollection();
            this.CreateColorCollection();
            this.IntializeAppoitments(10);
        }

        #endregion Constructor

        /// <summary>
        /// Property changed event handler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets work start hour
        /// </summary>
        public double WorkStartHour
        {
            get
            {
                return this.workStartHour;
            }

            set
            {
                this.workStartHour = value;
                this.RaiseOnPropertyChanged("WorkStartHour");
            }
        }

        /// <summary>
        /// Gets or sets end hour
        /// </summary>
        public double EndHour
        {
            get
            {
                return this.endHour;
            }

            set
            {
                this.endHour = value;
                this.RaiseOnPropertyChanged("EndHour");
            }
        }

        /// <summary>
        /// Gets or sets appointments
        /// </summary>
        public ScheduleAppointmentCollection Appointments
        {
            get;
            set;
        }

        #region Methods

        #region InitializeAppointments

        /// <summary>
        /// initialize the appointments
        /// </summary>
        /// <param name="count">count value</param>
        private void IntializeAppoitments(int count)
        {
            for (int i = 0; i < count; i++)
            {
                ScheduleAppointment scheduleAppointment = new ScheduleAppointment();
                scheduleAppointment.Color = this.colorCollection[i];
                scheduleAppointment.Subject = this.teamManagement[i];
                scheduleAppointment.StartTime = this.startTimeCollection[i];
                scheduleAppointment.EndTime = this.endTimeCollection[i];
                this.Appointments.Add(scheduleAppointment);
            }

            int allDayCount = 0;
            //// AllDay Appointment
            for (int i = 0; i < count; i++)
            {
                ScheduleAppointment allDayAppointment = new ScheduleAppointment();
                allDayAppointment.Color = this.colorCollection[allDayCount];
                allDayAppointment.Subject = this.allDayTeamManagement[allDayCount];
                allDayAppointment.StartTime = this.startTimeCollection[i];
                allDayAppointment.EndTime = this.endTimeCollection[i];
                allDayAppointment.IsAllDay = true;
                this.Appointments.Add(allDayAppointment);
                allDayCount = allDayCount + 1;
                i = i + 1;
            }        
        }

        #endregion InitializeAppointments

        #region SubjectCollection

        /// <summary>
        /// subject collection
        /// </summary>
        //// creating subject collection
        private void CreateSubjectCollection()
        {
            this.teamManagement = new List<string>();
            this.teamManagement.Add("General Meeting");
            this.teamManagement.Add("Plan Execution");
            this.teamManagement.Add("Project Plan");
            this.teamManagement.Add("Consulting");
            this.teamManagement.Add("Performance Check");
            this.teamManagement.Add("General Meeting");
            this.teamManagement.Add("Plan Execution");
            this.teamManagement.Add("Project Plan");
            this.teamManagement.Add("Consulting");
            this.teamManagement.Add("Performance Check");

            this.allDayTeamManagement = new List<string>();
            this.allDayTeamManagement.Add("Review");
            this.allDayTeamManagement.Add("Meeting");
            this.allDayTeamManagement.Add("Discussion");
            this.allDayTeamManagement.Add("Retrospective");
            this.allDayTeamManagement.Add("Outing");
        }

        #endregion SubjectCollection

        #region creating color collection

        /// <summary>
        /// color collection
        /// </summary>
        ////creating color collection
        private void CreateColorCollection()
        {
            this.colorCollection = new List<Color>();
            this.colorCollection.Add(Color.FromHex("#FFA2C139"));
            this.colorCollection.Add(Color.FromHex("#FFD80073"));
            this.colorCollection.Add(Color.FromHex("#FF1BA1E2"));
            this.colorCollection.Add(Color.FromHex("#FFE671B8"));
            this.colorCollection.Add(Color.FromHex("#FFF09609"));
            this.colorCollection.Add(Color.FromHex("#FF339933"));
            this.colorCollection.Add(Color.FromHex("#FF00ABA9"));
            this.colorCollection.Add(Color.FromHex("#FFE671B8"));
            this.colorCollection.Add(Color.FromHex("#FF1BA1E2"));
            this.colorCollection.Add(Color.FromHex("#FFD80073"));
            this.colorCollection.Add(Color.FromHex("#FFA2C139"));
            this.colorCollection.Add(Color.FromHex("#FFA2C139"));
            this.colorCollection.Add(Color.FromHex("#FFD80073"));
            this.colorCollection.Add(Color.FromHex("#FF339933"));
            this.colorCollection.Add(Color.FromHex("#FFE671B8"));
            this.colorCollection.Add(Color.FromHex("#FF00ABA9"));
        }

        #endregion creating color collection

        #region CreateRandomNumbersCollection

        /// <summary>
        /// method for random number collection
        /// </summary>
        private void CreateRandomNumbersCollection()
        {
            this.randomNums = new List<int>();

            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                int random = rand.Next(9, 15);
                this.randomNums.Add(random);
            }
        }

        #endregion CreateRandomNumbersCollection

        #region CreateStartTimeCollection

        /// <summary>
        /// start time collection
        /// </summary>
        //// creating StartTime collection
        private void CreateStartTimeCollection()
        {
            this.startTimeCollection = new List<DateTime>();
            DateTime currentDate = DateTime.Now;

            int count = 0;
            for (int i = -5; i < 5; i++)
            {
                DateTime startTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, this.randomNums[count], 0, 0);
                DateTime startDateTime = startTime.AddDays(i);
                this.startTimeCollection.Add(startDateTime);
                count++;
            }
        }

        #endregion CreateStartTimeCollection

        #region CreateEndTimeCollection

        /// <summary>
        /// end time collection
        /// </summary>
        ////  creating EndTime collection
        private void CreateEndTimeCollection()
        {
            this.endTimeCollection = new List<DateTime>();
            DateTime currentDate = DateTime.Now;
            int count = 0;
            for (int i = -5; i < 5; i++)
            {
                DateTime endTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, this.randomNums[count] + 1, 0, 0);
                DateTime endDateTime = endTime.AddDays(i);
                this.endTimeCollection.Add(endDateTime);
                count++;
            }
        }

        #endregion CreateEndTimeCollection

        #endregion Methods

        /// <summary>
        /// Invoke method when property changed
        /// </summary>
        /// <param name="propertyName">proper name</param>
        private void RaiseOnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}