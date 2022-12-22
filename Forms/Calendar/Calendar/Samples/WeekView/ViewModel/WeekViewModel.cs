#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Syncfusion.SfCalendar.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfCalendar
{
    public class WeekViewModel : INotifyPropertyChanged
    {
        private CalendarEventCollection appointments;
        private ObservableCollection<Color> colorCollection;
        private ObservableCollection<string> meetingSubjectCollection;

        public event PropertyChangedEventHandler PropertyChanged;

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

        public WeekViewModel()
        {
            this.Appointments = new CalendarEventCollection();
            this.AddAppointmentDetails();
            this.AddAppointments();
        }

        private void AddAppointmentDetails()
        {
            meetingSubjectCollection = new ObservableCollection<string>();
            meetingSubjectCollection.Add("BigDoor Board Meeting Paris, France");
            meetingSubjectCollection.Add("Development Meeting New York, U.S.A");
            meetingSubjectCollection.Add("Project Plan Meeting Kuala Lumpur, Malaysia");
            meetingSubjectCollection.Add("Support - Web Meeting  Dubai, UAE");
            meetingSubjectCollection.Add("Project Release Meeting  Istanbul, Turkey");
            meetingSubjectCollection.Add("Customer Meeting  Tokyo, Japan");
            meetingSubjectCollection.Add("Consulting with doctor  Amsterdam, Netherlands");

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

        private void AddAppointments()
        {
            var today = DateTime.Now.Date;
            var random = new Random();
            for (int month = -1; month < 5; month++)
            {
                for (int day = -15; day < 15; day++)
                {
                    for (int count = 0; count < 2; count++)
                    {
                        var appointment = new CalendarInlineEvent();
                        appointment.Subject = meetingSubjectCollection[random.Next(meetingSubjectCollection.Count)];
                        appointment.Color = colorCollection[random.Next(10)];
                        appointment.StartTime = today.AddMonths(month).AddDays(random.Next(0, 28)).AddHours(random.Next(9, 18));
                        appointment.EndTime = appointment.StartTime.AddHours(2);
                        this.Appointments.Add(appointment);
                    }
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

