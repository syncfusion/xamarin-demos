#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using Android.Content;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Sfrangeslider;
using System.Collections.Generic;
using Java.Util;
using Android.Graphics;
using Java.Text;
using Android.App;
using Android.OS;
using Com.Syncfusion.Schedule;
using System.Collections.ObjectModel;
using Com.Syncfusion.Schedule.Enums;

namespace SampleBrowser
{
    public class Timetable : SamplePage, IDisposable
    {
        private SfSchedule sfschedule;
        private NonAccessibleBlocksCollection nonAccessibleBlocksCollection;
        private NonAccessibleBlocksCollection nonAccessibleBlocks;
        private Context con;
        private List<String> subjectCollection;
        private List<Calendar> startTimeCollection;
        private List<Calendar> endTimeCollection;
        private ScheduleAppointmentCollection appointmentCollection;

        public override View GetSampleContent(Context context)
        {
            con = context;
            sfschedule = new SfSchedule(context);
            InitializingAppointmentData();
            sfschedule.ScheduleView = ScheduleView.DayView;
            sfschedule.TimeIntervalHeight = -1;
            sfschedule.VisibleDatesChanged += Sfschedule_VisibleDatesChanged;

            var dayViewSettings = new DayViewSettings();
            dayViewSettings.StartHour = 9;
            dayViewSettings.EndHour = 16;
            sfschedule.DayViewSettings = dayViewSettings;

            nonAccessibleBlocksCollection = new NonAccessibleBlocksCollection();
            var lunch = new NonAccessibleBlock();
            lunch.StartTime = 12;
            lunch.EndTime = 13;
            lunch.Text = "Lunch Break";
            nonAccessibleBlocksCollection.Add(lunch);
            nonAccessibleBlocks = nonAccessibleBlocksCollection;

            sfschedule.DayViewSettings.NonAccessibleBlocks = nonAccessibleBlocks;

            LinearLayout layout = new LinearLayout(context);
            layout.Orientation = Android.Widget.Orientation.Vertical;
            layout.AddView(sfschedule);
            return layout;
        }

        // Creating appointments for ScheduleAppointmentCollection
        public void InitializingAppointmentData()
        {
            SetSubjects();
            SetStartTime();
            SetEndTime();
        }

        private void SetSubjects()
        {
            subjectCollection = new List<String>();
            subjectCollection.Add("Wellness");
            subjectCollection.Add("Language Arts");
            subjectCollection.Add("Mathematics");
            subjectCollection.Add("Social Studies");
            subjectCollection.Add("Physical Education");
            subjectCollection.Add("Geography");
        }

        private void SetStartTime()
        {
            //appointment1
            startTimeCollection = new List<Calendar>();
            var currentDate1 = Calendar.Instance;
            var startTime1 = (Calendar)currentDate1.Clone();
            startTime1.Set(
                startTime1.Get(CalendarField.Year),
                startTime1.Get(CalendarField.Month),
                startTime1.Get(CalendarField.DayOfMonth),
                9,
                1,
                0);

            // appointment2
            var currentDate2 = Calendar.Instance;
            var startTime2 = (Calendar)currentDate2.Clone();
            startTime2.Set(
                startTime2.Get(CalendarField.Year),
                startTime2.Get(CalendarField.Month),
                startTime2.Get(CalendarField.DayOfMonth),
              10, 
              1,
              0);

            //appointment3
            var currentDate3 = Calendar.Instance;
            var startTime3 = (Calendar)currentDate3.Clone();
            startTime3.Set(
                startTime3.Get(CalendarField.Year),
                startTime3.Get(CalendarField.Month),
                startTime3.Get(CalendarField.DayOfMonth),
              11, 
              11, 
              0);

            //appointment4
            var currentDate4 = Calendar.Instance;
            var startTime4 = (Calendar)currentDate4.Clone();
            startTime4.Set(
                startTime4.Get(CalendarField.Year),
                startTime4.Get(CalendarField.Month),
                startTime4.Get(CalendarField.DayOfMonth),
              13,
              1,
              0);

            // appointment5
            var currentDate5 = Calendar.Instance;
            var startTime5 = (Calendar)currentDate5.Clone();
            startTime5.Set(
                startTime5.Get(CalendarField.Year),
                startTime5.Get(CalendarField.Month),
                startTime5.Get(CalendarField.DayOfMonth),
              14, 
              1, 
              0);

            // appointment6
            var currentDate6 = Calendar.Instance;
            var startTime6 = (Calendar)currentDate6.Clone();
            startTime6.Set(
                startTime6.Get(CalendarField.Year),
                startTime6.Get(CalendarField.Month),
                startTime6.Get(CalendarField.DayOfMonth),
              15, 
              11,
              0);

            startTimeCollection.Add(startTime1);
            startTimeCollection.Add(startTime2);
            startTimeCollection.Add(startTime3);
            startTimeCollection.Add(startTime4);
            startTimeCollection.Add(startTime5);
            startTimeCollection.Add(startTime6);
        }

        private void SetEndTime()
        {
            endTimeCollection = new List<Calendar>();

            // appointment1
            var currentDate1 = Calendar.Instance;
            var endTime1 = (Calendar)currentDate1.Clone();
            endTime1.Set(
                endTime1.Get(CalendarField.Year),
                endTime1.Get(CalendarField.Month),
                endTime1.Get(CalendarField.DayOfMonth),
                10, 
                0,
                0);

            // appointment2
            var currentDate2 = Calendar.Instance;
            var endTime2 = (Calendar)currentDate2.Clone();
            endTime2.Set(
                endTime2.Get(CalendarField.Year),
                endTime2.Get(CalendarField.Month),
                endTime2.Get(CalendarField.DayOfMonth),
              11, 
              0, 
              0);

            //appointment3
            var currentDate3 = Calendar.Instance;
            var endTime3 = (Calendar)currentDate3.Clone();
            endTime3.Set(
                endTime3.Get(CalendarField.Year),
                endTime3.Get(CalendarField.Month),
                endTime3.Get(CalendarField.DayOfMonth),
              12, 
              0, 
              0);

            //appointment4
            var currentDate4 = Calendar.Instance;
            var endTime4 = (Calendar)currentDate4.Clone();
            endTime4.Set(
                endTime4.Get(CalendarField.Year),
                endTime4.Get(CalendarField.Month),
                endTime4.Get(CalendarField.DayOfMonth),
              14,
              0, 
              0);

            // appointment5
            var currentDate5 = Calendar.Instance;
            var endTime5 = (Calendar)currentDate5.Clone();
            endTime5.Set(
                endTime5.Get(CalendarField.Year),
                endTime5.Get(CalendarField.Month),
                endTime5.Get(CalendarField.DayOfMonth),
              15, 
              0, 
              0);

            // appointment6
            var currentDate6 = Calendar.Instance;
            var endTime6 = (Calendar)currentDate6.Clone();
            endTime6.Set(
                endTime6.Get(CalendarField.Year),
                endTime6.Get(CalendarField.Month),
                endTime6.Get(CalendarField.DayOfMonth),
              16, 
              0,
              0);
            endTimeCollection.Add(endTime1);
            endTimeCollection.Add(endTime2);
            endTimeCollection.Add(endTime3);
            endTimeCollection.Add(endTime4);
            endTimeCollection.Add(endTime5);
            endTimeCollection.Add(endTime6);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        private Color GetColors(string subject)
        {
            if (subject == "Wellness")
            {
                return Color.ParseColor("#FFA2C139");
            } 
            else if (subject == "Language Arts")
            {
                return Color.ParseColor("#FFD80073");
            }  
            else if (subject == "Mathematics")
            {
                return Color.ParseColor("#FFE671B8");
            }   
            else if (subject == "Social Studies")
            {
                return Color.ParseColor("#FF1BA1E2");
            }   
            else if (subject == "Physical Education")
            {
                return Color.ParseColor("#FF00ABA9");
            }          
            else
            {
                return Color.ParseColor("#FF339933");
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        private string GetStaff(string subject)
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

       private void Sfschedule_VisibleDatesChanged(object sender, VisibleDatesChangedEventArgs e)
        {
            appointmentCollection = new ScheduleAppointmentCollection();
            var visibleDates = e.VisibleDates;
            var rand = new Java.Util.Random();
            var endCalendar = Calendar.Instance;
            var startCalendar = Calendar.Instance;
            var breakStartValue = Calendar.Instance;
            var breakEndValue = Calendar.Instance;
            var break1StartValue = Calendar.Instance;
            var break2StartValue = Calendar.Instance;

            for (int i = 0; i < visibleDates.Count; i++)
            {
                if (visibleDates[i].Get(CalendarField.DayOfWeek) == 1 || visibleDates[i].Get(CalendarField.DayOfWeek) == 7)
                {
                    sfschedule.DayViewSettings.NonAccessibleBlocks = null;
                }
                else
                {
                    sfschedule.DayViewSettings.NonAccessibleBlocks = nonAccessibleBlocks;
                }

                if (visibleDates[i].Get(CalendarField.DayOfWeek) == 1 || visibleDates[i].Get(CalendarField.DayOfWeek) == 7)
                {
                    continue;
                }
              
                // Periods Appointments
                for (int j = 0; j < startTimeCollection.Count; j++)
                {
                    startCalendar.Set(visibleDates[i].Get(CalendarField.Year), visibleDates[i].Get(CalendarField.Month), visibleDates[i].Get(CalendarField.Date), startTimeCollection[j].Get(CalendarField.HourOfDay), startTimeCollection[j].Get(CalendarField.Minute), startTimeCollection[j].Get(CalendarField.Second));
                    endCalendar.Set(visibleDates[i].Get(CalendarField.Year), visibleDates[i].Get(CalendarField.Month), visibleDates[i].Get(CalendarField.Date), endTimeCollection[j].Get(CalendarField.HourOfDay), endTimeCollection[j].Get(CalendarField.Minute), endTimeCollection[j].Get(CalendarField.Second));
                    var subject = subjectCollection[rand.NextInt(subjectCollection.Count)];
                    appointmentCollection.Add(new ScheduleAppointment()
                    {
                        StartTime = (Calendar)startCalendar.Clone(),
                        EndTime = (Calendar)endCalendar.Clone(),
                        Subject = subject + " (" + startTimeCollection[j].Get(CalendarField.HourOfDay).ToString() + ":00 - " + endTimeCollection[j].Get(CalendarField.HourOfDay).ToString() + ":00" + ") \n\n"  + GetStaff(subject),
                        Color = GetColors(subject),
                    });
                }

                // Break Timings
                breakStartValue.Set(visibleDates[i].Get(CalendarField.Year), visibleDates[i].Get(CalendarField.Month), visibleDates[i].Get(CalendarField.Date), 11, 01, 0);
                breakEndValue.Set(visibleDates[i].Get(CalendarField.Year), visibleDates[i].Get(CalendarField.Month), visibleDates[i].Get(CalendarField.Date), 11, 10, 0);
                appointmentCollection.Add(new ScheduleAppointment()
                {
                    StartTime = (Calendar)breakStartValue.Clone(),
                    EndTime = (Calendar)breakEndValue.Clone(),
                    Color = Color.LightGray
                });

                break1StartValue.Set(visibleDates[i].Get(CalendarField.Year), visibleDates[i].Get(CalendarField.Month), visibleDates[i].Get(CalendarField.Date), 15, 01, 0);
                break2StartValue.Set(visibleDates[i].Get(CalendarField.Year), visibleDates[i].Get(CalendarField.Month), visibleDates[i].Get(CalendarField.Date), 15, 10, 0);
                appointmentCollection.Add(new ScheduleAppointment()
                {
                    StartTime = (Calendar)break1StartValue.Clone(),
                    EndTime = (Calendar)break2StartValue.Clone(),
                    Color = Color.LightGray
                });
            }

            sfschedule.ItemsSource = appointmentCollection;
        }

        public void Dispose()
        {
            if (sfschedule != null)
            {
                sfschedule.VisibleDatesChanged -= Sfschedule_VisibleDatesChanged;
                sfschedule.Dispose();
                sfschedule = null;
            }

            if (nonAccessibleBlocksCollection != null)
            {
                nonAccessibleBlocksCollection.Clear();
                nonAccessibleBlocksCollection = null;
            }

            if (subjectCollection != null)
            {
                subjectCollection.Clear();
                subjectCollection = null;
            }

            if (startTimeCollection != null)
            {
                startTimeCollection.Clear();
                startTimeCollection = null;
            }

            if (endTimeCollection != null)
            {
                endTimeCollection.Clear();
                endTimeCollection = null;
            }

            if (appointmentCollection != null)
            {
                appointmentCollection.Clear();
                appointmentCollection = null;
            }

            if (nonAccessibleBlocks != null)
            {
                nonAccessibleBlocks.Clear();
                nonAccessibleBlocks = null;
            }

            if (con != null)
            {
                con = null;
            }
        }
    }
}
