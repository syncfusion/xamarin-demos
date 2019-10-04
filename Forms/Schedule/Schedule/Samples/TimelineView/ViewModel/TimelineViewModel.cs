#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfSchedule
{
    /// <summary>
    /// Timeline  View Model class.
	[Preserve(AllMembers = true)]

    #region TimelineViewModel
    public class TimelineViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// current day meetings 
        /// </summary>
        private List<string> currentDayMeetings;

        /// <summary>
        /// Author Collection 
        /// </summary>
        private List<string> authorCollection;

        /// <summary>
        /// color collection
        /// </summary>
        private List<Color> colorCollection;

        /// <summary>
        /// list of meeting
        /// </summary>
        private ObservableCollection<Meeting> listOfMeeting;


        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceViewModel" /> class.
        /// </summary>
        public TimelineViewModel()
        {
            this.ListOfMeeting = new ObservableCollection<Meeting>();
            this.InitializeDataForBookings();
            ////this.BookingAppointments();
        }


        /// <summary>
        /// Property changed event handler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #region ListOfMeeting

        /// <summary>
        /// Gets or sets list of meeting
        /// </summary>
        public ObservableCollection<Meeting> ListOfMeeting
        {
            get
            {
                return this.listOfMeeting;
            }

            set
            {
                this.listOfMeeting = value;
                this.RaiseOnPropertyChanged("ListOfMeeting");
            }
        }
        #endregion

        #region BookingAppointments

        /// <summary>
        /// Method for booking appointments.
        /// </summary>
        internal void BookingAppointments(List<DateTime> visibleDates)
        {
            Random randomTime = new Random();
            List<Point> randomTimeCollection = this.GettingTimeRanges();

            DateTime date;
            DateTime dateFrom = visibleDates[0];
            DateTime dateTo = visibleDates[visibleDates.Count - 1];

            for (date = dateFrom; date <= dateTo; date = date.AddDays(1))
            {
                for (int additionalAppointmentIndex = 0; additionalAppointmentIndex < 6; additionalAppointmentIndex++)
                {
                    Meeting meeting = new Meeting();
                    meeting.From = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(9, 12), 0, 0);
                    meeting.To = meeting.From.AddHours(randomTime.Next(1, 3));
                    meeting.EventName = this.currentDayMeetings[randomTime.Next(9)] + "\n \n " + this.authorCollection[randomTime.Next(5)];
                    meeting.Color = this.colorCollection[randomTime.Next(9)];
                    meeting.IsAllDay = false;
                    meeting.StartTimeZone = string.Empty;
                    meeting.EndTimeZone = string.Empty;

                    this.ListOfMeeting.Add(meeting);

                    Meeting meeting1 = new Meeting();
                    meeting1.From = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(14, 17), 0, 0);
                    meeting1.To = meeting1.From.AddHours(randomTime.Next(1, 3));
                    meeting1.EventName = this.currentDayMeetings[randomTime.Next(9)] + "\n \n " + this.authorCollection[randomTime.Next(5)];
                    meeting1.Color = this.colorCollection[randomTime.Next(9)];
                    meeting1.IsAllDay = false;
                    meeting1.StartTimeZone = string.Empty;
                    meeting1.EndTimeZone = string.Empty;

                    this.ListOfMeeting.Add(meeting1);
                }
            }
        }

        #endregion BookingAppointments

        #region GettingTimeRanges

        /// <summary>
        /// Method for get timing range.
        /// </summary>
        /// <returns>return time collection</returns>
        private List<Point> GettingTimeRanges()
        {
            List<Point> randomTimeCollection = new List<Point>();
            randomTimeCollection.Add(new Point(9, 11));
            randomTimeCollection.Add(new Point(12, 14));
            randomTimeCollection.Add(new Point(15, 17));

            return randomTimeCollection;
        }

        #endregion GettingTimeRanges

        #region InitializeDataForBookings

        /// <summary>
        /// Method for initialize data bookings.
        /// </summary>
        private void InitializeDataForBookings()
        {
            this.currentDayMeetings = new List<string>();
            this.currentDayMeetings.Add("General Meeting");
            this.currentDayMeetings.Add("Client Meeting");
            this.currentDayMeetings.Add("HR Meeting");
            this.currentDayMeetings.Add("Training session on Vue");
            this.currentDayMeetings.Add("Board Meeting");
            this.currentDayMeetings.Add("Support Meeting with Managers");
            this.currentDayMeetings.Add("Sprint Planning with Team members");
            this.currentDayMeetings.Add("Training session on C#");
            this.currentDayMeetings.Add("Appraisal Meeting");
            this.currentDayMeetings.Add("Meeting with General Manager");

            this.authorCollection = new List<string>();
            this.authorCollection.Add("Mr. Jamison");
            this.authorCollection.Add("Ms. Casey");
            this.authorCollection.Add("Mr. Percorino");
            this.authorCollection.Add("Ms. Gawade");
            this.authorCollection.Add("Mr. Shilling");
            this.authorCollection.Add("Mr. Paul Anderson");

            this.colorCollection = new List<Color>();
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

        #endregion InitializeDataForBookings

        #region Property Changed Event

        /// <summary>
        /// Invoke method when property changed
        /// </summary>
        /// <param name="propertyName">property name</param>
        private void RaiseOnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
    #endregion
}