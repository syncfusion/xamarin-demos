#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser.SfSchedule
{
    internal class AgendaViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Meeting> meetings;

        public ObservableCollection<Meeting> Meetings
        {
            get { return meetings; }
            set
            {
                meetings = value;
                RaiseOnPropertyChanged("Meetings");
            }
        }

     
        private ObservableCollection<Meeting> selectedDateMeetings;

        public ObservableCollection<Meeting> SelectedDateMeetings
        {
            get { return selectedDateMeetings; }
            set
            {
                selectedDateMeetings = value;
                RaiseOnPropertyChanged("SelectedDateMeetings");
            }
        }

        private string selectedDate;

        public string SelectedDate
        {
            get { return selectedDate; }
            set
            {
                selectedDate = value;
                RaiseOnPropertyChanged("SelectedDate");
            }
        }

        private ObservableCollection<DateTime> blackoutDates;

        public ObservableCollection<DateTime> BlackoutDates
        {
            get { return blackoutDates; }
            set
            {
                blackoutDates = value;
                RaiseOnPropertyChanged("BlackoutDates");
            }
        }

        List<Color> colorCollection;
        private ObservableCollection<string> titleCollection = new ObservableCollection<string>();
        List<string> currentDayMeetings;

        public AgendaViewModel()
        {
            Meetings = new ObservableCollection<Meeting>();
            AddAppointmentDetails();
            AddPreBookMeetings();
            AddBlackouDates();
        }

        private void AddBlackouDates()
        {
            BlackoutDates = new ObservableCollection<DateTime>();
            for (int i = 0; i < 5; i++)
            {
                var date = DateTime.Now.Date.AddDays(15).AddDays(i);
                BlackoutDates.Add(date);
            }
        }

        //creating color collection
        private void AddAppointmentDetails()
        {
            currentDayMeetings = new List<string>();
            currentDayMeetings.Add("General Meeting");
            currentDayMeetings.Add("Plan Execution");
            currentDayMeetings.Add("Project Plan");
            currentDayMeetings.Add("Consulting");
            currentDayMeetings.Add("Support");
            currentDayMeetings.Add("Development Meeting");
            currentDayMeetings.Add("Scrum");
            currentDayMeetings.Add("Project Completion");
            currentDayMeetings.Add("Release updates");
            currentDayMeetings.Add("Performance Check");

            colorCollection = new List<Color>();
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
                            EventName = currentDayMeetings[random.Next(7)],
                            color = colorCollection[random.Next(10)]
                        };
                        Meetings.Add(meeting);
                    }
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void RaiseOnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
