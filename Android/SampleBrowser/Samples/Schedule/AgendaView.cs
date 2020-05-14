#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Schedule;
using Com.Syncfusion.Schedule.Enums;
using Java.Util;
using Android.Graphics;

namespace SampleBrowser
{
    public class AgendaView : SamplePage, IDisposable
    {
        public AgendaView()
        {
        }

        private SfSchedule sfSchedule;
        public override View GetSampleContent(Context context)
        {
            LinearLayout linearLayout = new LinearLayout(context);
            linearLayout.Orientation = Orientation.Vertical;

            //creating instance for Schedule
            sfSchedule = new SfSchedule(context);
            sfSchedule.ScheduleView = ScheduleView.MonthView;
            MonthViewSettings month = new MonthViewSettings();
            month.ShowAppointmentsInline = false;
            month.ShowAgendaView = true;
            sfSchedule.MonthViewSettings = month;

            //set the appointment collection
            GetAppointments();
            sfSchedule.ItemsSource = appointmentCollection;
            linearLayout.AddView(sfSchedule);
            return linearLayout;
        }

        private List<string> subjectCollection = new List<string>();
        private List<string> colorCollection = new List<string>();
        private List<Calendar> startTimeCollection = new List<Calendar>();
        private List<Calendar> endTimeCollection = new List<Calendar>();
        private ScheduleAppointmentCollection appointmentCollection;

        //Creating appointments for ScheduleAppointmentCollection
        private void GetAppointments()
        {
            appointmentCollection = new ScheduleAppointmentCollection();
            SetColors();
            RandomNumbers();
            SetSubjects();
            SetStartTime();
            SetEndTime();
            var count = 0;
            for (int i = 0; i < 30; i++)
            {
               var scheduleAppointment = new ScheduleAppointment();
                scheduleAppointment.Color = Color.ParseColor(colorCollection[count]);
                scheduleAppointment.Subject = subjectCollection[count];
                if (i < 10 && i >= 0)
                {
                    scheduleAppointment.StartTime = startTimeCollection[count];
                    scheduleAppointment.EndTime = endTimeCollection[count];
                    count++;
                }
                else if (i < 20 && i >= 10)
                {
                    var date = (Calendar)startTimeCollection[count].Clone();
                    var month = date.Get(CalendarField.Month);
                    if (month == 12)
                    {
                        month = 1;
                    }
                    else
                    {
                        month = month + 1;
                    }

                    date.Set(CalendarField.Month, month);
                    var endDate = (Calendar)endTimeCollection[count].Clone();
                    endDate.Set(CalendarField.Month, month);
                    scheduleAppointment.StartTime = date;
                    scheduleAppointment.EndTime = endDate;
                    count++;
                }
                else if (i < 30 && i >= 20)
                {
                    var date = (Calendar)startTimeCollection[count].Clone();
                    var month = date.Get(CalendarField.Month);
                    if (month == 1)
                    {
                        month = 12;
                    }
                    else
                    {
                        month = month - 1;
                    }

                    date.Set(CalendarField.Month, month);
                    var endDate = (Calendar)endTimeCollection[count].Clone();
                    endDate.Set(CalendarField.Month, month);
                    scheduleAppointment.StartTime = date;
                    scheduleAppointment.EndTime = endDate;
                    count++;
                }

                if (count >= 10)
                {
                    count = 0;
                }
                
                appointmentCollection.Add(scheduleAppointment);
            }
        }

        private void SetSubjects()
        {
            subjectCollection = new List<String>();
            subjectCollection.Add("GoToMeeting");
            subjectCollection.Add("Business Meeting");
            subjectCollection.Add("Conference");
            subjectCollection.Add("Project Status Discussion");
            subjectCollection.Add("Auditing");
            subjectCollection.Add("Client Meeting");
            subjectCollection.Add("Generate Report");
            subjectCollection.Add("Target Meeting");
            subjectCollection.Add("General Meeting");
            subjectCollection.Add("Pay House Rent");
            subjectCollection.Add("Car Service");
            subjectCollection.Add("Medical Check Up");
            subjectCollection.Add("Wedding Anniversary");
            subjectCollection.Add("Sam's Birthday");
            subjectCollection.Add("Jenny's Birthday");
        }

        // adding colors collection
        private void SetColors()
        {
            colorCollection = new List<String>();
            colorCollection.Add("#FFA2C139");
            colorCollection.Add("#FFD80073");
            colorCollection.Add("#FF1BA1E2");
            colorCollection.Add("#FFE671B8");
            colorCollection.Add("#FFF09609");
            colorCollection.Add("#FF339933");
            colorCollection.Add("#FF00ABA9");
            colorCollection.Add("#FFE671B8");
            colorCollection.Add("#FF1BA1E2");
            colorCollection.Add("#FFD80073");
            colorCollection.Add("#FFA2C139");
            colorCollection.Add("#FFD80073");
            colorCollection.Add("#FF339933");
            colorCollection.Add("#FFE671B8");
            colorCollection.Add("#FF00ABA9");
        }

        private List<int> randomNums = new List<int>();

        private void RandomNumbers()
        { 
            randomNums = new List<int>();
            Java.Util.Random rand = new Java.Util.Random();
            for (int i = 0; i < 10; i++)
            {
                int randomNum = rand.NextInt((15 - 9) + 1) + 9;
                randomNums.Add(randomNum);
            }
        }

        // adding StartTime collection
        private void SetStartTime()
        {
            startTimeCollection = new List<Calendar>();
            Calendar currentDate = Calendar.Instance;
            int count = 0;
            for (int i = -5; i < 5; i++)
            {
                Calendar startTime = (Calendar)currentDate.Clone();
                startTime.Set(
                    currentDate.Get(CalendarField.Year),
                    currentDate.Get(CalendarField.Month),
                    currentDate.Get(CalendarField.DayOfMonth) + i,
                    randomNums[count],
                    0,
                    0);
                startTimeCollection.Add(startTime);
                count++;
            }
        }

        // adding EndTime collection
        private void SetEndTime()
        {
            endTimeCollection = new List<Calendar>();
            Calendar currentDate = Calendar.Instance;
            int count = 0;
            for (int i = -5; i < 5; i++)
            {
                Calendar endTime = (Calendar)currentDate.Clone();
                endTime.Set(
                    currentDate.Get(CalendarField.Year),
                    currentDate.Get(CalendarField.Month),
                    currentDate.Get(CalendarField.DayOfMonth) + i,
                    randomNums[count] + 1,
                    0,
                    0);

                endTimeCollection.Add(endTime);
                count++;
            }
        }

        public void Dispose()
        {
            if (sfSchedule != null)
            {
                sfSchedule.Dispose();
                sfSchedule = null;
            }
        }
    }
}