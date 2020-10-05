#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfSchedule
{
    /// <summary>
    /// Agenda View Model class.
    /// </summary>
    internal class AgendaViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// collecions for meetings.
        /// </summary>
        private ObservableCollection<Meeting> meetings;

        /// <summary>
        /// selected date meetings.
        /// </summary>
        private ObservableCollection<Meeting> selectedDateMeetings;

        /// <summary>
        /// selected date.
        /// </summary>
        private string selectedDate;

        /// <summary>
        /// blackout dates.
        /// </summary>
        private ObservableCollection<DateTime> blackoutDates;
        
        /// <summary>
        /// title collection.
        /// </summary>
        private ObservableCollection<string> titleCollection = new ObservableCollection<string>();

        /// <summary>
        /// color collection.
        /// </summary>
        private List<Color> colorCollection;

        /// <summary>
        /// current day meeting.
        /// </summary>
        private List<string> currentDayMeetings;

        /// <summary>
        /// Initializes a new instance of the <see cref="AgendaViewModel" /> class.
        /// </summary>
        public AgendaViewModel()
        {
            this.Meetings = new ObservableCollection<Meeting>();
            this.AddAppointmentDetails();
            this.AddPreBookMeetings();
            this.AddBlackouDates();
        }

        /// <summary>
        /// property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets meetings.
        /// </summary>
        public ObservableCollection<Meeting> Meetings
        {
            get
            {
                return this.meetings;
            }

            set
            {
                this.meetings = value;
                this.RaiseOnPropertyChanged("Meetings");
            }
        }

        /// <summary>
        /// Gets or sets selected date meetings.
        /// </summary>
        public ObservableCollection<Meeting> SelectedDateMeetings
        {
            get
            {
                return this.selectedDateMeetings;
            }

            set
            {
                this.selectedDateMeetings = value;
                this.RaiseOnPropertyChanged("SelectedDateMeetings");
            }
        }

        /// <summary>
        /// Gets or sets selected date.
        /// </summary>
        public string SelectedDate
        {
            get
            {
                return this.selectedDate;
            }

            set
            {
                this.selectedDate = value;
                this.RaiseOnPropertyChanged("SelectedDate");
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
                this.RaiseOnPropertyChanged("BlackoutDates");
            }
        }

        /// <summary>
        /// method for add blackout dates
        /// </summary>
        private void AddBlackouDates()
        {
            this.BlackoutDates = new ObservableCollection<DateTime>();
            for (int i = 0; i < 5; i++)
            {
                var date = DateTime.Now.Date.AddDays(15).AddDays(i);
                this.BlackoutDates.Add(date);
            }
        }

        /// <summary>
        /// adding appointment details.
        /// </summary>
        private void AddAppointmentDetails()
        {
            this.currentDayMeetings = new List<string>();
            this.currentDayMeetings.Add("General Meeting");
            this.currentDayMeetings.Add("Plan Execution");
            this.currentDayMeetings.Add("Project Plan");
            this.currentDayMeetings.Add("Consulting");
            this.currentDayMeetings.Add("Support");
            this.currentDayMeetings.Add("Development Meeting");
            this.currentDayMeetings.Add("Scrum");
            this.currentDayMeetings.Add("Project Completion");
            this.currentDayMeetings.Add("Release updates");
            this.currentDayMeetings.Add("Performance Check");

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

        /// <summary>
        /// method for add pre book meetings.
        /// </summary>
        private void AddPreBookMeetings()
        {
            var today = DateTime.Now.Date;
            var random = new Random();
            for (int month = -1; month < 2; month++)
            {
                for (int day = -5; day < 5; day++)
                {
                    for (int hour = 9; hour < 18; hour += 5)
                    {
                        var meeting = new Meeting()
                        {
                            From = today.AddMonths(month).AddDays(day).AddHours(hour),
                            To = today.AddMonths(month).AddDays(day).AddHours(hour + 2),
                            EventName = this.currentDayMeetings[random.Next(7)],
                            Color = this.colorCollection[random.Next(10)]
                        };
                        this.Meetings.Add(meeting);
                    }
                }
            }
        }

        /// <summary>
        /// Invoke method when property changed.
        /// </summary>
        /// <param name="propertyName">property name</param>
        private void RaiseOnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
