#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfSchedule
{
    /// <summary>
    /// Time table View Model class
    /// </summary>
    [Preserve(AllMembers = true)]
    public class TimetableViewModel : INotifyPropertyChanged
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TimetableViewModel" /> class.
        /// </summary>
        public TimetableViewModel()
        {
            this.Appointments = new ScheduleAppointmentCollection();
            this.InitializingAppointmentData();

            NonAccessibleBlocksCollection = new NonAccessibleBlocksCollection();
            var lunch = new NonAccessibleBlock();
            lunch.StartTime = 12;
            lunch.EndTime = 13;
            lunch.Text = "Lunch Break";
            NonAccessibleBlocksCollection.Add(lunch);
            this.NonAccessibleBlocks = NonAccessibleBlocksCollection;
        }

        #endregion Constructor

        #region Properties
        #region Property Changed Event
        /// <summary>
        /// Property changed event handler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets appointment collection
        /// </summary>
        public ScheduleAppointmentCollection Appointments
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets subject collection
        /// </summary>
        internal List<string> SubjectCollection { get; set; }

        /// <summary>
        /// Gets or sets start time collection
        /// </summary>
        internal List<DateTime> StartTimeCollection { get; set; }

        /// <summary>
        /// Gets or sets end time collection
        /// </summary>
        internal List<DateTime> EndTimeCollection { get; set; }

        /// <summary>
        /// Gets or sets non accessible blocks collection
        /// </summary>
        internal NonAccessibleBlocksCollection NonAccessibleBlocksCollection { get; set; }

        /// <summary>
        /// Gets or sets non accessible blocks
        /// </summary>
        internal NonAccessibleBlocksCollection NonAccessibleBlocks
        {
            get;
            set;
        }

        #endregion Properties
        /// <summary>
        /// Initialize the appointment 
        /// </summary>
        public void InitializingAppointmentData()
        {
            this.SetSubjects();
            this.SetStartTime();
            this.SetEndTime();
        }

        /// <summary>
        /// subject collection
        /// </summary>
        internal void SetSubjects()
        {
            this.SubjectCollection = new List<string>();
            this.SubjectCollection.Add("Wellness");
            this.SubjectCollection.Add("Language Arts");
            this.SubjectCollection.Add("Mathematics");
            this.SubjectCollection.Add("Social Studies");
            this.SubjectCollection.Add("Physical Education");
            this.SubjectCollection.Add("Geography");
        }

        /// <summary>
        /// Start time collection
        /// </summary>
        internal void SetStartTime()
        {
            //appointment1
            this.StartTimeCollection = new List<DateTime>();
            var currentDate1 = DateTime.Now.Date;
            var startTime1 = new DateTime(currentDate1.Year, currentDate1.Month, currentDate1.Day, 9, 1, 0);

            // appointment2
            var startTime2 = new DateTime(currentDate1.Year, currentDate1.Month, currentDate1.Day, 10, 1, 0);

            //appointment3
            var startTime3 = new DateTime(currentDate1.Year, currentDate1.Month, currentDate1.Day, 11, 11, 0);

            //appointment4
            var startTime4 = new DateTime(currentDate1.Year, currentDate1.Month, currentDate1.Day, 13, 1, 0);

            // appointment5
            var startTime5 = new DateTime(currentDate1.Year, currentDate1.Month, currentDate1.Day, 14, 1, 0);

            // appointment6
            var startTime6 = new DateTime(currentDate1.Year, currentDate1.Month, currentDate1.Day, 15, 11, 0);

            this.StartTimeCollection.Add(startTime1);
            this.StartTimeCollection.Add(startTime2);
            this.StartTimeCollection.Add(startTime3);
            this.StartTimeCollection.Add(startTime4);
            this.StartTimeCollection.Add(startTime5);
            this.StartTimeCollection.Add(startTime6);
        }

        /// <summary>
        /// End time collection
        /// </summary>
        internal void SetEndTime()
        {
            this.EndTimeCollection = new List<DateTime>();

            // appointment1
            var currentDate1 = DateTime.Now.Date;
            var endTime1 = new DateTime(currentDate1.Year, currentDate1.Month, currentDate1.Day, 10, 0, 0);

            // appointment2
            var endTime2 = new DateTime(currentDate1.Year, currentDate1.Month, currentDate1.Day, 11, 0, 0);

            //appointment3
            var endTime3 = new DateTime(currentDate1.Year, currentDate1.Month, currentDate1.Day, 12, 0, 0);

            //appointment4
            var endTime4 = new DateTime(currentDate1.Year, currentDate1.Month, currentDate1.Day, 14, 0, 0);

            // appointment5
            var endTime5 = new DateTime(currentDate1.Year, currentDate1.Month, currentDate1.Day, 15, 0, 0);

            // appointment6
            var endTime6 = new DateTime(currentDate1.Year, currentDate1.Month, currentDate1.Day, 16, 0, 0);

            this.EndTimeCollection.Add(endTime1);
            this.EndTimeCollection.Add(endTime2);
            this.EndTimeCollection.Add(endTime3);
            this.EndTimeCollection.Add(endTime4);
            this.EndTimeCollection.Add(endTime5);
            this.EndTimeCollection.Add(endTime6);
        }

        /// <summary>
        /// Color collection
        /// </summary>
        /// <param name="subject">subject value</param>
        /// <returns>color value</returns>
        internal Color GetColors(string subject)
        {
            if (subject == "Wellness")
            {
                return Color.FromHex("#FFA2C139");
            }
            else if (subject == "Language Arts")
            {
                return Color.FromHex("#FFD80073");
            }
            else if (subject == "Mathematics")
            {
                return Color.FromHex("#FFE671B8");
            }
            else if (subject == "Social Studies")
            {
                return Color.FromHex("#FF1BA1E2");
            }
            else if (subject == "Physical Education")
            {
                return Color.FromHex("#FF00ABA9");
            }
            else
            {
                return Color.FromHex("#FF339933");
            }
        }

        /// <summary>
        /// Staff collection
        /// </summary>
        /// <param name="subject">subject value</param>
        /// <returns>color value</returns>
        internal string GetStaff(string subject)
        {
            if (subject == "Wellness")
            {
                return "Mr. Jamison";
            }
            else if (subject == "Language Arts")
            {
                return "Ms. Casey";
            }
            else if (subject == "Mathematics")
            {
                return "Mr. Percorino";
            }
            else if (subject == "Social Studies")
            {
                return "Ms. Gawade";
            }
            else if (subject == "Physical Education")
            {
                return "Mr. Shilling";
            }
            else
            {
                return "Mr. Paul Anderson";
            }
        }

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
}