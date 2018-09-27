#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.Collections.Generic;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using System.ComponentModel;

namespace SampleBrowser.SfSchedule
{
    [Preserve(AllMembers = true)]
    public class TimetableViewModel : INotifyPropertyChanged
    {
        #region Properties
        public ScheduleAppointmentCollection Appointments { get; set; }

        internal List<String> subjectCollection;
        internal List<DateTime> startTimeCollection;
        internal List<DateTime> endTimeCollection;
        internal NonAccessibleBlocksCollection nonAccessibleBlocksCollection;
        internal NonAccessibleBlocksCollection nonAccessibleBlocks;

        #endregion Properties

        #region Constructor

        public TimetableViewModel()
        {
            Appointments = new ScheduleAppointmentCollection();
            InitializingAppointmentData();

            nonAccessibleBlocksCollection = new NonAccessibleBlocksCollection();
            var lunch = new NonAccessibleBlock();
            lunch.StartTime = 12;
            lunch.EndTime = 13;
            lunch.Text = "Lunch Break";
            nonAccessibleBlocksCollection.Add(lunch);
            nonAccessibleBlocks = nonAccessibleBlocksCollection;
        }

        #endregion Constructor

        public void InitializingAppointmentData()
        {
            SetSubjects();
            SetStartTime();
            SetEndTime();
        }

        internal void SetSubjects()
        {
            subjectCollection = new List<String>();
            subjectCollection.Add("Wellness");
            subjectCollection.Add("Language Arts");
            subjectCollection.Add("Mathematics");
            subjectCollection.Add("Social Studies");
            subjectCollection.Add("Physical Education");
            subjectCollection.Add("Geography");
        }

        internal void SetStartTime()
        {
            //appointment1
            startTimeCollection = new List<DateTime>();
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

            startTimeCollection.Add(startTime1);
            startTimeCollection.Add(startTime2);
            startTimeCollection.Add(startTime3);
            startTimeCollection.Add(startTime4);
            startTimeCollection.Add(startTime5);
            startTimeCollection.Add(startTime6);

        }

        internal void SetEndTime()
        {
            endTimeCollection = new List<DateTime>();

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

            endTimeCollection.Add(endTime1);
            endTimeCollection.Add(endTime2);
            endTimeCollection.Add(endTime3);
            endTimeCollection.Add(endTime4);
            endTimeCollection.Add(endTime5);
            endTimeCollection.Add(endTime6);
        }

        internal Color GetColors(string subject)
        {
            if (subject == "Wellness")
                return Color.FromHex("#FFA2C139");
            else if (subject == "Language Arts")
                return Color.FromHex("#FFD80073");
            else if (subject == "Mathematics")
                return Color.FromHex("#FFE671B8");
            else if (subject == "Social Studies")
                return Color.FromHex("#FF1BA1E2");
            else if (subject == "Physical Education")
                return Color.FromHex("#FF00ABA9");
            else
                return Color.FromHex("#FF339933");
        }
        internal string GetStaff(string subject)
        {
            if (subject == "Wellness")
                return "Mr. Jamison";
            else if (subject == "Language Arts")
                return "Ms. Casey";
            else if (subject == "Mathematics")
                return "Mr. Percorino";
            else if (subject == "Social Studies")
                return "Ms. Gawade";
            else if (subject == "Physical Education")
                return "Mr. Shilling";
            else
                return "Mr. Paul Anderson";
        }

        #region Property Changed Event

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaiseOnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}

