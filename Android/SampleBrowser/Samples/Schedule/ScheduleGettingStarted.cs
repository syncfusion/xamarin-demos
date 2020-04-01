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
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Java.Util;
using Com.Syncfusion.Schedule.Enums;
using Com.Syncfusion.Schedule;
using Android.Runtime;

namespace SampleBrowser
{
    [Preserve(AllMembers = true)]
    public class ScheduleGettingStarted : SamplePage, IDisposable
    {
        /// <summary>
        /// Variable for Schedule
        /// </summary>
        private SfSchedule schedule;


        /// <summary>
        /// Custom appointment variable
        /// </summary>
        private Meeting meeting;

        /// <summary>
        /// Custom appointment collection
        /// </summary>
        private ObservableCollection<Meeting> appointmentCollection;

        /// <summary>
        /// Spinner to select schedule view
        /// </summary>
        private Spinner spinner;

        /// <summary>
        /// Option view to change schedule view
        /// </summary>
        private LinearLayout propertyLayout;

        public ScheduleGettingStarted()
        {
        }

        public override View GetSampleContent(Context context)
        {
            LinearLayout linearLayout = new LinearLayout(context);
            linearLayout.Orientation = Orientation.Vertical;
            schedule = new SfSchedule(context);
            propertyLayout = new LinearLayout(context);
            propertyLayout = SetOptionPage(context);

            // Schedule custom appointment mapping 
            AppointmentMapping mapping = new AppointmentMapping();
            mapping.StartTime = "From";
            mapping.EndTime = "To";
            mapping.Subject = "EventName";
            mapping.IsAllDay = "IsAllDay";
            mapping.MinHeight = "MinimumHeight";
            mapping.Color = "Color";

            schedule.AppointmentMapping = mapping;

            schedule.ScheduleView = ScheduleView.WeekView;
            schedule.MonthViewSettings.ShowAppointmentsInline = true;
            GetAppointments();

            schedule.ItemsSource = appointmentCollection;
            schedule.LayoutParameters = new FrameLayout.LayoutParams(
                LinearLayout.LayoutParams.MatchParent,
        LinearLayout.LayoutParams.MatchParent);
            linearLayout.AddView(schedule);

            return linearLayout;
        }

        /// <summary>
        /// Custom appointment subject collection
        /// </summary>
        private List<string> eventCollection;

        /// <summary>
        /// Custom appointment start time collection
        /// </summary>
        private List<Calendar> fromCollection;

        /// <summary>
        /// Custom appointment end time collection
        /// </summary>
        private List<Calendar> toCollection;

        /// <summary>
        /// Custom appointment color collection
        /// </summary>
        private List<string> colorCollection;

        /// <summary>
        /// Collection of random numbers to get start time and end time
        /// </summary>
        private List<int> randomNumbers;

        /// <summary>
        /// Gets the appointments collection
        /// </summary>
        private void GetAppointments()
        {
            appointmentCollection = new ObservableCollection<Meeting>();
            SetEventCollection();
            RandomNumbers();
            SetFromCollection();
            SetToCollection();
            SetColorCollection();

            for (int i = 0; i < 15; i++)
            {
                meeting = new Meeting();
                meeting.Color = Color.ParseColor(colorCollection[i]);
                meeting.EventName = eventCollection[i];
                meeting.From = fromCollection[i];

                // To create all day appointments
                if (i % 6 == 0 && i != 0)
                {
                    meeting.IsAllDay = true;
                }

                // To create two days span appointment
                if (i % 5 == 0 && i != 0)
                {
                    toCollection[i] = (Calendar)fromCollection[i].Clone();
                    var date = toCollection[i].Get(CalendarField.DayOfMonth) + 2;
                    toCollection[i].Set(CalendarField.DayOfMonth, date);
                }

                // To create 24 hour span appointments
                if (i % 7 == 0)
                {
                    toCollection[i] = (Calendar)fromCollection[i].Clone();
                    var hour = toCollection[i].Get(CalendarField.Hour) + 23;
                    var min = toCollection[i].Get(CalendarField.Minute) + 59;
                    toCollection[i].Set(CalendarField.Hour, hour);
                    toCollection[i].Set(CalendarField.Minute, min);
                }

                // To create minimum height appointments
                if (eventCollection[i].Contains("alert"))
                {
                    toCollection[i] = (Calendar)fromCollection[i].Clone();
                    meeting.MinimumHeight = 50;
                }

                meeting.To = toCollection[i];
                appointmentCollection.Add(meeting);
            }
        }

        /// <summary>
        /// Gets the random numbers to get start time and end time
        /// </summary>
        private void RandomNumbers()
        {
            randomNumbers = new List<int>();
            Java.Util.Random rand = new Java.Util.Random();
            for (int i = 0; i < 20; i++)
            {
                int randomNum = rand.NextInt((15 - 9) + 1) + 9;
                randomNumbers.Add(randomNum);
            }
        }

        /// <summary>
        /// Sets the color collection for custom appointment
        /// </summary>
        private void SetColorCollection()
        {
            colorCollection = new List<string>();
            colorCollection.Add("#FFA2C139");
            colorCollection.Add("#FFD80073");
            colorCollection.Add("#FF1BA1E2");
            colorCollection.Add("#FFE671B8");
            colorCollection.Add("#FFF09609");
            colorCollection.Add("#FFA2C139");
            colorCollection.Add("#FFD80073");
            colorCollection.Add("#FF1BA1E2");
            colorCollection.Add("#FFE671B8");
            colorCollection.Add("#FFF09609");
            colorCollection.Add("#FFA2C139");
            colorCollection.Add("#FFD80073");
            colorCollection.Add("#FF1BA1E2");
            colorCollection.Add("#FFE671B8");
            colorCollection.Add("#FFF09609");
            colorCollection.Add("#FFA2C139");
            colorCollection.Add("#FFD80073");
            colorCollection.Add("#FF1BA1E2");
            colorCollection.Add("#FFE671B8");
            colorCollection.Add("#FFF09609");
            colorCollection.Add("#FFA2C139");
            colorCollection.Add("#FFD80073");
            colorCollection.Add("#FF1BA1E2");
            colorCollection.Add("#FFE671B8");
            colorCollection.Add("#FFF09609");
            colorCollection.Add("#FFA2C139");
            colorCollection.Add("#FFD80073");
            colorCollection.Add("#FF1BA1E2");
            colorCollection.Add("#FFE671B8");
            colorCollection.Add("#FFF09609");
        }

        /// <summary>
        /// Sets the end time for custom appointments
        /// </summary>
        private void SetToCollection()
        {
            toCollection = new List<Calendar>();
            Calendar currentDate = Calendar.Instance;
            int count = 0;
            for (int i = -10; i < 10; i++)
            {
                Calendar to = (Calendar)currentDate.Clone();
                to.Set(
                    currentDate.Get(CalendarField.Year),
                    currentDate.Get(CalendarField.Month),
                    currentDate.Get(CalendarField.DayOfMonth) + i,
                    randomNumbers[count] + 2,
                    0,
                    0);
                toCollection.Add(to);
                count++;
            }
        }

        /// <summary>
        /// Sets the start time collection for custom appointments
        /// </summary>
        private void SetFromCollection()
        {
            fromCollection = new List<Calendar>();
            Calendar currentDate = Calendar.Instance;
            int count = 0;
            for (int i = -10; i < 10; i++)
            {
                Calendar from = (Calendar)currentDate.Clone();
                from.Set(
                    currentDate.Get(CalendarField.Year),
                    currentDate.Get(CalendarField.Month),
                    currentDate.Get(CalendarField.DayOfMonth) + i,
                    randomNumbers[count],
                    0,
                    0);
                fromCollection.Add(from);
                count++;
            }
        }

        /// <summary>
        /// Sets the subject collection for custom appointment
        /// </summary>
        private void SetEventCollection()
        {
            eventCollection = new List<string>();
            eventCollection.Add("General Meeting");
            eventCollection.Add("Plan Execution");
            eventCollection.Add("Project Plan");
            eventCollection.Add("Consulting");
            eventCollection.Add("Performance Check");
            eventCollection.Add("Yoga Therapy");
            eventCollection.Add("Plan Execution");
            eventCollection.Add("Project Plan");
            eventCollection.Add("Consulting");
            eventCollection.Add("Performance Check");
            eventCollection.Add("Work log alert");
            eventCollection.Add("Birthday wish alert");
            eventCollection.Add("Task due date");
            eventCollection.Add("Status mail");
            eventCollection.Add("Start sprint alert");
        }

        /// <summary>
        /// Sets the option page to change schedule view
        /// </summary>
        /// <param name="context">Context of this view</param>
        /// <returns>Option layout</returns>
        private LinearLayout SetOptionPage(Context context)
        {
            TextView scheduleType_txtBlock = new TextView(context);
            scheduleType_txtBlock.Text = "Schedule View";
            scheduleType_txtBlock.TextSize = 20;
            scheduleType_txtBlock.SetPadding(0, 0, 0, 10);
            scheduleType_txtBlock.SetTextColor(Color.Black);
            LinearLayout layout = new LinearLayout(context);
            layout.SetPadding(15, 15, 15, 20);
            layout.Orientation = Android.Widget.Orientation.Vertical;
            layout.SetBackgroundColor(Color.White);

            spinner = new Spinner(context, SpinnerMode.Dialog);
            spinner.SetMinimumHeight(60);
            spinner.SetBackgroundColor(Color.Gray);
            spinner.DropDownWidth = 500;
            layout.AddView(scheduleType_txtBlock);
            layout.AddView(spinner);

            List<string> list = new List<string>();
            list.Add("Week View");
            list.Add("Day View");
            list.Add("Work Week View");
            list.Add("Month View");

            ArrayAdapter<string> dataAdapter = new ArrayAdapter<string>(context, Android.Resource.Layout.SimpleSpinnerItem, list);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = dataAdapter;
            spinner.ItemSelected += Spinner_ItemSelected;

            return layout;
        }

        /// <summary>
        /// Event occurs when item selected in the spinner to change schedule view
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Arguments of the event</param>
        private void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (e.Position == 0)
            {
                schedule.ScheduleView = ScheduleView.WeekView;
            }
            else if (e.Position == 1)
            {
                schedule.ScheduleView = ScheduleView.DayView;
            }
            else if (e.Position == 2)
            {
                schedule.ScheduleView = ScheduleView.WorkWeekView;
            }
            else if (e.Position == 3)
            {
                schedule.ScheduleView = ScheduleView.MonthView;
            }
        }

        /// <summary>
        /// Adds the property layout to the view
        /// </summary>
        /// <param name="context">Context of the view</param>
        /// <returns>Property layout</returns>
        public override View GetPropertyWindowLayout(Context context)
        {
            return propertyLayout;
        }

        public void Dispose()
        {
            if (schedule != null)
            {
                schedule.Dispose();
                schedule = null;
            }

            if (propertyLayout != null)
            {
                propertyLayout.Dispose();
                propertyLayout = null;
            }

            if (spinner != null)
            {
                spinner.ItemSelected -= Spinner_ItemSelected;
                spinner.Dispose();
                spinner = null;
            }
        }
    }

    /// <summary>
    /// Custom appointment class
    /// </summary>
    [Preserve(AllMembers = true)]
    public class Meeting
    {
        /// <summary>
        /// Gets or sets the Event name for the meeting
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// Gets or sets the From time for the meeting
        /// </summary>
        public Calendar From { get; set; }

        /// <summary>
        /// Gets or sets the To time for the meeting
        /// </summary>
        public Calendar To { get; set; }

        /// <summary>
        /// Gets or sets the color for the meeting
        /// </summary>
        public int Color { get; set; }

        /// <summary>
        /// Gets or sets the minimum height for the meeting
        /// </summary>
        public double MinimumHeight { get; set; }

        /// <summary>
        /// Gets or sets a value to indicate whether the meeting is all day or not
        /// </summary>
        public bool IsAllDay { get; set; }
    }
}