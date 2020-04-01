#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
    /// Resource View Model class.
	[Preserve(AllMembers = true)]

    #region ResourceViewModel
    public class ResourceViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// current day meetings 
        /// </summary>
        private List<string> currentDayMeetings;

        /// <summary>
        /// minimum time meetings
        /// </summary>
        private List<string> minTimeMeetings;

        /// <summary>
        /// color collection
        /// </summary>
        private List<Color> colorCollection;

        /// <summary>
        /// list of meeting
        /// </summary>
        private ObservableCollection<Meeting> listOfMeeting;

        /// <summary>
        /// name collection
        /// </summary>

        private List<string> nameCollection;

        /// <summary>
        /// resources
        /// </summary>
        private ObservableCollection<object> resources;

        /// <summary>
        /// selected Resources
        /// </summary>
        private ObservableCollection<object> selectedResources;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceViewModel" /> class.
        /// </summary>
        public ResourceViewModel()
        {
            this.ListOfMeeting = new ObservableCollection<Meeting>();
            Resources = new ObservableCollection<object>();
            SelectedResources = new ObservableCollection<object>();
            this.InitializeDataForBookings();
            this.InitializeResources();
            this.BookingAppointments();
        }

        private void InitializeResources()
        {
            Random random = new Random();
            for (int i = 0; i < 15; i++)
            {
                Employees employees = new Employees();
                employees.Name = nameCollection[i];
                employees.Color = Color.FromRgb(random.Next(0, 255), random.Next(10, 255), random.Next(100, 255));
                employees.ID = i.ToString();
                if (i < 9)
                {
                    if (employees.Name == "Brooklyn")
                    {
                        employees.Image = "People_Circle8.png";
                    }
                    else if (employees.Name == "Sophia")
                    {
                        employees.Image = "People_Circle1.png";
                    }
                    else if (employees.Name == "Stephen")
                    {
                        employees.Image = "People_Circle12.png";
                    }
                    else if (employees.Name == "Zoey Addison")
                    {
                        employees.Image = "People_Circle2.png";
                    }
                    else if (employees.Name == "Daniel")
                    {
                        employees.Image = "People_Circle14.png";
                    }
                    else if (employees.Name == "Emilia")
                    {
                        employees.Image = "People_Circle3.png";
                    }
                    else if (employees.Name == "Adeline Ruby")
                    {
                        employees.Image = "People_Circle4.png";
                    }
                    else if (employees.Name == "James William")
                    {
                        employees.Image = "People_Circle5.png";
                    }
                    else if (employees.Name == "Kinsley Elena")
                    {
                        employees.Image = "People_Circle6.png";
                    }
                }
                else
                {
                    employees.Image = null;
                }

                Resources.Add(employees);
            }

            for (int i = 0; i < 10; i++)
            {
                SelectedResources.Add(Resources[random.Next(Resources.Count)]);
            }
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

        public ObservableCollection<object> Resources
        {
            get
            {
                return resources;
            }

            set
            {
                resources = value;
                this.RaiseOnPropertyChanged("Resources");
            }
        }


        public ObservableCollection<object> SelectedResources
        {
            get
            {
                return selectedResources;
            }

            set
            {
                selectedResources = value;
                this.RaiseOnPropertyChanged("selectedResources");
            }
        }

        #region BookingAppointments

        /// <summary>
        /// Method for booking appointments.
        /// </summary>
        private void BookingAppointments()
        {
            Random randomTime = new Random();
            List<Point> randomTimeCollection = this.GettingTimeRanges();

            DateTime date;
            DateTime dateFrom = DateTime.Now.AddDays(-80);
            DateTime dateTo = DateTime.Now.AddDays(80);
            DateTime dateRangeStart = DateTime.Now.AddDays(-70);
            DateTime dateRangeEnd = DateTime.Now.AddDays(70);

            for (date = dateFrom; date < dateTo; date = date.AddDays(1))
            {
                if ((DateTime.Compare(date, dateRangeStart) > 0) && (DateTime.Compare(date, dateRangeEnd) < 0))
                {
                    for (int additionalAppointmentIndex = 0; additionalAppointmentIndex < 3; additionalAppointmentIndex++)
                    {
                        Meeting meeting = new Meeting();
                        int hour = randomTime.Next((int)randomTimeCollection[additionalAppointmentIndex].X, (int)randomTimeCollection[additionalAppointmentIndex].Y);
                        meeting.From = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(9, 14), 0, 0);
                        meeting.To = meeting.From.AddHours(randomTime.Next(1, 3));
                        meeting.EventName = this.currentDayMeetings[randomTime.Next(9)];
                        meeting.Color = this.colorCollection[randomTime.Next(9)];
                        meeting.IsAllDay = false;
                        meeting.StartTimeZone = string.Empty;
                        meeting.EndTimeZone = string.Empty;

                        var coll = new ObservableCollection<object>
                            {
                                (resources[randomTime.Next(Resources.Count)] as Employees).ID
                            };
                        meeting.Resources = coll;


                        this.ListOfMeeting.Add(meeting);
                    }
                }
                else
                {
                    Meeting meeting = new Meeting();
                    meeting.From = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(9, 11), 0, 0);
                    meeting.To = meeting.From.AddDays(2).AddHours(1);
                    meeting.EventName = this.currentDayMeetings[randomTime.Next(9)];
                    meeting.Color = this.colorCollection[randomTime.Next(9)];
                    meeting.IsAllDay = true;
                    meeting.StartTimeZone = string.Empty;
                    meeting.EndTimeZone = string.Empty;
                    var coll = new ObservableCollection<object>
                            {
                                (resources[randomTime.Next(Resources.Count)] as Employees).ID
                            };
                    meeting.Resources = coll;
                    this.ListOfMeeting.Add(meeting);   
                }
               
            }

            // Minimum Height Meetings
            DateTime minDate;
            DateTime minDateFrom = DateTime.Now.AddDays(-2);
            DateTime minDateTo = DateTime.Now.AddDays(2);

            for (minDate = minDateFrom; minDate < minDateTo; minDate = minDate.AddDays(1))
            {
                Meeting meeting = new Meeting();
                meeting.From = new DateTime(minDate.Year, minDate.Month, minDate.Day, randomTime.Next(9, 18), 30, 0);
                meeting.To = meeting.From;
                meeting.EventName = this.minTimeMeetings[randomTime.Next(0, 4)];
                meeting.Color = this.colorCollection[randomTime.Next(0, 10)];
                meeting.StartTimeZone = string.Empty;
                meeting.EndTimeZone = string.Empty;

                // Setting Mininmum Appointment Height for Schedule Appointments
                if (Device.RuntimePlatform == "Android")
                {
                    meeting.MinimumHeight = 50;
                }
                else
                {
                    meeting.MinimumHeight = 25;
                }

                this.ListOfMeeting.Add(meeting);
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
            this.currentDayMeetings.Add("Plan Execution");
            this.currentDayMeetings.Add("Project Plan");
            this.currentDayMeetings.Add("Consulting");
            this.currentDayMeetings.Add("Performance Check");
            this.currentDayMeetings.Add("Yoga Therapy");
            this.currentDayMeetings.Add("Plan Execution");
            this.currentDayMeetings.Add("Project Plan");
            this.currentDayMeetings.Add("Consulting");
            this.currentDayMeetings.Add("Performance Check");

            // MinimumHeight Appointment Subjects
            this.minTimeMeetings = new List<string>();
            this.minTimeMeetings.Add("Work log alert");
            this.minTimeMeetings.Add("Birthday wish alert");
            this.minTimeMeetings.Add("Task due date");
            this.minTimeMeetings.Add("Status mail");
            this.minTimeMeetings.Add("Start sprint alert");

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

            this.nameCollection = new List<string>();
            this.nameCollection.Add("Brooklyn");
            this.nameCollection.Add("James William");
            this.nameCollection.Add("Sophia");
            this.nameCollection.Add("Stephen");
            this.nameCollection.Add("Zoey Addison");
            this.nameCollection.Add("Daniel");
            this.nameCollection.Add("Emilia");
            this.nameCollection.Add("Adeline Ruby");
            this.nameCollection.Add("Kinsley Elena");
            this.nameCollection.Add("Danial William");
            this.nameCollection.Add("Stephen Addison");
            this.nameCollection.Add("Kinsley Ruby");
            this.nameCollection.Add("Adeline Elena");
            this.nameCollection.Add("Emilia William");
            this.nameCollection.Add("Danial Addison");
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