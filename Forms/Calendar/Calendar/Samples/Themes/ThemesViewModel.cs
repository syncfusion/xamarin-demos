#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Syncfusion.SfCalendar.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfCalendar
{
    public class ThemesViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The appointments.
        /// </summary>
        private CalendarEventCollection appointments;

        /// <summary>
        /// The color collection.
        /// </summary>
        private ObservableCollection<Color> colorCollection;

        /// <summary>
        /// blackout dates.
        /// </summary>
        private ObservableCollection<DateTime> blackoutDates;

        /// <summary>
        /// The meeting subject collection.
        /// </summary>
        private ObservableCollection<string> meetingSubjectCollection;

        /// <summary>
        /// Gets or sets the appointments.
        /// </summary>
        /// <value>The appointments.</value>
        public CalendarEventCollection Appointments
        {
            get
            {
                return this.appointments;
            }

            set
            {
                this.appointments = value;
                this.OnPropertyChanged("Appointments");
            }
        }

        /// <summary>
        /// Gets or sets blackout dates.
        /// </summary>
        public ObservableCollection<DateTime> BlackoutDates
        {
            get
            {
                return this.blackoutDates;
            }

            set
            {
                this.blackoutDates = value;
                this.OnPropertyChanged("BlackoutDates");
            }
        }


        public ThemesViewModel()
        {
            this.Appointments = new CalendarEventCollection();
            this.AddAppointmentDetails();
            this.AddAppointments();
            this.AddBlackouDates();
        }

        /// <summary>
        /// Adds the appointment details.
        /// </summary>
        private void AddAppointmentDetails()
        {
            meetingSubjectCollection = new ObservableCollection<string>();
            meetingSubjectCollection.Add("General Meeting");
            meetingSubjectCollection.Add("Plan Execution");
            meetingSubjectCollection.Add("Project Plan");
            meetingSubjectCollection.Add("Consulting");
            meetingSubjectCollection.Add("Support");
            meetingSubjectCollection.Add("Development Meeting");
            meetingSubjectCollection.Add("Scrum");
            meetingSubjectCollection.Add("Project Completion");
            meetingSubjectCollection.Add("Release updates");
            meetingSubjectCollection.Add("Performance Check");

            colorCollection = new ObservableCollection<Color>();
            colorCollection.Add(Color.FromHex("#FFA2C139"));
            colorCollection.Add(Color.FromHex("#FFD80073"));
            colorCollection.Add(Color.FromHex("#FF1BA1E2"));
            colorCollection.Add(Color.FromHex("#FFE671B8"));
            colorCollection.Add(Color.FromHex("#FFF09609"));
            colorCollection.Add(Color.FromHex("#FF339933"));
            colorCollection.Add(Color.FromHex("#FF00ABA9"));
            colorCollection.Add(Color.FromHex("#FFE671B8"));
            colorCollection.Add(Color.FromHex("#FF1BA1E2"));
            colorCollection.Add(Color.FromHex("#FFD80073"));
            colorCollection.Add(Color.FromHex("#FFA2C139"));
            colorCollection.Add(Color.FromHex("#FFA2C139"));
            colorCollection.Add(Color.FromHex("#FFD80073"));
            colorCollection.Add(Color.FromHex("#FF339933"));
            colorCollection.Add(Color.FromHex("#FFE671B8"));
            colorCollection.Add(Color.FromHex("#FF00ABA9"));
        }

        /// <summary>
        /// Adds the appointments.
        /// </summary>
        private void AddAppointments()
        {
            var today = DateTime.Now.Date;
            var random = new Random();
            for (int month = -1; month < 2; month++)
            {
                for (int day = -5; day < 5; day++)
                {
                    for (int count = 0; count < 2; count++)
                    {
                        var appointment = new CalendarInlineEvent();
                        appointment.Subject = meetingSubjectCollection[random.Next(7)];
                        appointment.Color = colorCollection[random.Next(10)];
                        appointment.StartTime = today.AddMonths(month).AddDays(random.Next(1, 28)).AddHours(random.Next(9, 18));
                        appointment.EndTime = appointment.StartTime.AddHours(2);
                        this.Appointments.Add(appointment);
                    }
                }
            }
        }

        /// <summary>
        /// method for add blackout dates
        /// </summary>
        private void AddBlackouDates()
        {
            this.BlackoutDates = new ObservableCollection<DateTime>();
            var random = new Random();
            for (int i = 0; i < 8; i++)
            {
                var date = DateTime.Now.Date.AddDays(random.Next(1, 28)).AddDays(i);
                this.BlackoutDates.Add(date);
            }
        }

       
        /// <summary>
        /// Occurs when property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Ons the property changed.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
