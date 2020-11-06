#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using Syncfusion.SfSchedule.iOS;
using UIKit;
using System.Collections.ObjectModel;

namespace SampleBrowser
{
    public class Timetable : SampleView
    {
        private static SFSchedule schedule;
        private List<NSString> subjectCollection;
        private List<NSDate> startTimeCollection;
        private List<NSDate> endTimeCollection;
        private ObservableCollection<ScheduleAppointment> appointmentCollection = new ObservableCollection<ScheduleAppointment>();

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Timetable()
        {
            schedule = new SFSchedule();
            schedule.ScheduleView = SFScheduleView.SFScheduleViewDay;
            schedule.TimeIntervalHeight = -1;
            schedule.VisibleDatesChanged += Schedule_VisibleDatesChanged;
            InitializeAppointmentComponents();
            var dayViewSettings = new DayViewSettings();
            dayViewSettings.StartHour = 9;
            dayViewSettings.EndHour = 16;
            schedule.DayViewSettings = dayViewSettings;
            dayViewSettings.NonAccessibleBlockCollection = CreateNonAccescibleBlock();
            schedule.DayViewSettings = dayViewSettings;
            this.AddSubview(schedule);
        }

        public override void LayoutSubviews()
        {
            foreach (var view in this.Subviews)
            {
                view.Frame = new CGRect(Frame.X, 0, Frame.Width, Frame.Height);
            }

            base.LayoutSubviews();
        }

        private NSMutableArray CreateNonAccescibleBlock()
        {
            var nonAccessibleBlocks = new NonAccessibleBlock();
            var nonAccessibleBlocksCollection = new NSMutableArray();
            nonAccessibleBlocks.StartHour = 12;
            nonAccessibleBlocks.EndHour = 13;
            nonAccessibleBlocks.Text = (NSString)"LUNCH";
            nonAccessibleBlocksCollection.Add(nonAccessibleBlocks);
            return nonAccessibleBlocksCollection;
        }

        private void InitializeAppointmentComponents()
        {
            SetSubjects();
            SetStartTime();
            SetEndTime();
        }

        private void SetSubjects()
        {
            subjectCollection = new List<NSString>();
            subjectCollection.Add((NSString)"Wellness");
            subjectCollection.Add((NSString)"Language Arts");
            subjectCollection.Add((NSString)"Mathematics");
            subjectCollection.Add((NSString)"Social Studies");
            subjectCollection.Add((NSString)"Physical Education");
            subjectCollection.Add((NSString)"Geography");
        }

        private void SetStartTime()
        {
            startTimeCollection = new List<NSDate>();
            NSCalendar calendar = NSCalendar.CurrentCalendar;
            NSDate today = new NSDate();
            NSDateComponents startDateComponents = calendar.Components(
                NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
            startDateComponents.Hour = 9;
            startDateComponents.Minute = 1;
            startDateComponents.Second = 0;

            NSDateComponents startDateComponents1 = calendar.Components(
                NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
            startDateComponents1.Hour = 10;
            startDateComponents1.Minute = 1;
            startDateComponents1.Second = 0;

            NSDateComponents startDateComponents2 = calendar.Components(
                NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
            startDateComponents2.Hour = 11;
            startDateComponents2.Minute = 11;
            startDateComponents2.Second = 0;

            NSDateComponents startDateComponents3 = calendar.Components(
                NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
            startDateComponents3.Hour = 13;
            startDateComponents3.Minute = 1;
            startDateComponents3.Second = 0;

            NSDateComponents startDateComponents4 = calendar.Components(
                NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
            startDateComponents4.Hour = 14;
            startDateComponents4.Minute = 1;
            startDateComponents4.Second = 0;

            NSDateComponents startDateComponents5 = calendar.Components(
                NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
            startDateComponents5.Hour = 15;
            startDateComponents5.Minute = 11;
            startDateComponents5.Second = 0;

            startTimeCollection.Add(calendar.DateFromComponents(startDateComponents));
            startTimeCollection.Add(calendar.DateFromComponents(startDateComponents1));
            startTimeCollection.Add(calendar.DateFromComponents(startDateComponents2));
            startTimeCollection.Add(calendar.DateFromComponents(startDateComponents3));
            startTimeCollection.Add(calendar.DateFromComponents(startDateComponents4));
            startTimeCollection.Add(calendar.DateFromComponents(startDateComponents5));
        }

        private void SetEndTime()
        {
            endTimeCollection = new List<NSDate>();

            NSCalendar calendar = NSCalendar.CurrentCalendar;
            NSDate today = new NSDate();
            NSDateComponents endDateComponents = calendar.Components(
            NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
            endDateComponents.Hour = 10;
            endDateComponents.Minute = 0;
            endDateComponents.Second = 0;

            NSDateComponents endDateComponents1 = calendar.Components(
                NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
            endDateComponents1.Hour = 11;
            endDateComponents1.Minute = 0;
            endDateComponents1.Second = 0;

            NSDateComponents endDateComponents2 = calendar.Components(
            NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
            endDateComponents2.Hour = 12;
            endDateComponents2.Minute = 0;
            endDateComponents2.Second = 0;

            NSDateComponents endDateComponents3 = calendar.Components(
            NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
            endDateComponents3.Hour = 14;
            endDateComponents3.Minute = 0;
            endDateComponents3.Second = 0;

            NSDateComponents endDateComponents4 = calendar.Components(
            NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
            endDateComponents4.Hour = 15;
            endDateComponents4.Minute = 0;
            endDateComponents4.Second = 0;

            NSDateComponents endDateComponents5 = calendar.Components(
            NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
            endDateComponents5.Hour = 16;
            endDateComponents5.Minute = 0;
            endDateComponents5.Second = 0;

            endTimeCollection.Add(calendar.DateFromComponents(endDateComponents));
            endTimeCollection.Add(calendar.DateFromComponents(endDateComponents1));
            endTimeCollection.Add(calendar.DateFromComponents(endDateComponents2));
            endTimeCollection.Add(calendar.DateFromComponents(endDateComponents3));
            endTimeCollection.Add(calendar.DateFromComponents(endDateComponents4));
            endTimeCollection.Add(calendar.DateFromComponents(endDateComponents5));
        }

        private UIColor GetColors(NSString subject)
        {
            if (subject == "Wellness")
            {
                return UIColor.FromRGB(162, 193, 57);
            }
            else if (subject == "Language Arts")
            {
                return UIColor.FromRGB(216, 0, 115);
            }
            else if (subject == "Mathematics")
            {
                return UIColor.FromRGB(230, 1113, 284);
            }
            else if (subject == "Social Studies")
            {
                return UIColor.FromRGB(27, 161, 226);
            }
            else if (subject == "Physical Education")
            {
                return UIColor.FromRGB(0, 171, 169);
            }
            else
            {
                return UIColor.FromRGB(511, 153, 51);
            }
        }

        private string GetStaff(NSString subject)
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

        private NSDate GetDate(NSDate visibleDate, NSDate startTimeDate)
        {
            NSCalendar calendar = NSCalendar.CurrentCalendar;
            NSDate today1 = new NSDate();
            NSDateComponents visibleDateCompoents = calendar.Components(
                NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, visibleDate);
            NSDateComponents startDateCompoents = calendar.Components(
                NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day | NSCalendarUnit.Hour | NSCalendarUnit.Minute | NSCalendarUnit.Second, startTimeDate);
            visibleDateCompoents.Hour = startDateCompoents.Hour;
            visibleDateCompoents.Minute = startDateCompoents.Minute;
            visibleDateCompoents.Second = startDateCompoents.Second;
            return calendar.DateFromComponents(visibleDateCompoents);
        }

        private NSDate GetBreakDate(NSDate visibleDate, int hour, int mins, int secs)
        {
            NSCalendar calendar = NSCalendar.CurrentCalendar;
            NSDate today1 = new NSDate();
            NSDateComponents visibleDateCompoents = calendar.Components(
                NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, visibleDate);
            visibleDateCompoents.Hour = hour;
            visibleDateCompoents.Minute = mins;
            visibleDateCompoents.Second = secs;
            return calendar.DateFromComponents(visibleDateCompoents);
        }

        private int GetDayOfWeek(NSDate visibleDate)
        {
            NSCalendar calendar = NSCalendar.CurrentCalendar;
            NSDate today1 = new NSDate();
            NSDateComponents visibleDateCompoents = calendar.Components(
                NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day | NSCalendarUnit.Weekday, visibleDate);
            return (int)visibleDateCompoents.Weekday;
        }

        private int GetStartDateHour(NSDate startTimeDate)
        {
            NSCalendar calendar = NSCalendar.CurrentCalendar;
            NSDateComponents startDateCompoents = calendar.Components(
                NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day | NSCalendarUnit.Hour | NSCalendarUnit.Minute | NSCalendarUnit.Second, startTimeDate);
            return (int)startDateCompoents.Hour;
        }

        private int GetEndDateHour(NSDate endTimeDate)
        {
            NSCalendar calendar = NSCalendar.CurrentCalendar;
            NSDateComponents endDateComponents = calendar.Components(
                NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day | NSCalendarUnit.Hour | NSCalendarUnit.Minute | NSCalendarUnit.Second, endTimeDate);
            return (int)endDateComponents.Hour;
        }

        private void Schedule_VisibleDatesChanged(object sender, VisibleDatesChangedEventArgs e)
        {
            var visibleDates = e.VisibleDates;
            var randomNumber = new Random();
            var startDate = NSDate.Now;
            var endDate = NSDate.Now;
            appointmentCollection = new ObservableCollection<ScheduleAppointment>();
            for (nuint i = 0; i < visibleDates.Count; i++)
            {
                if (GetDayOfWeek(visibleDates.GetItem<NSDate>(i)) == 1 || GetDayOfWeek(visibleDates.GetItem<NSDate>(i)) == 7)
                {
                    schedule.DayViewSettings.NonAccessibleBlockCollection = null;
                }
                else
                {
                    schedule.DayViewSettings.NonAccessibleBlockCollection = CreateNonAccescibleBlock();
                }

                if (GetDayOfWeek(visibleDates.GetItem<NSDate>(i)) == 1 || GetDayOfWeek(visibleDates.GetItem<NSDate>(i)) == 7)
                {
                    continue;
                }

                for (int j = 0; j < startTimeCollection.Count; j++)
                {
                    startDate = GetDate(visibleDates.GetItem<NSDate>(i), startTimeCollection[j]);
                    endDate = GetDate(visibleDates.GetItem<NSDate>(i), endTimeCollection[j]);
                    var subject = subjectCollection[randomNumber.Next(subjectCollection.Count)];
                    appointmentCollection.Add(new ScheduleAppointment()
                    {
                        StartTime = startDate,
                        EndTime = endDate,
                        Subject = (NSString)(subject + " (" + GetStartDateHour(startDate).ToString() + ":00 - " + GetEndDateHour(endDate).ToString() + ":00" + ") \n\n" + GetStaff(subject)),
                        AppointmentBackground = GetColors(subject),
                    });
                }
             
                // Break Timings
                startDate = GetBreakDate(visibleDates.GetItem<NSDate>(i), 11, 01, 0);
                endDate = GetBreakDate(visibleDates.GetItem<NSDate>(i), 11, 10, 0);
                appointmentCollection.Add(new ScheduleAppointment()
                {
                    StartTime = startDate,
                    EndTime = endDate,
                    AppointmentBackground = UIColor.LightGray
                });
                startDate = GetBreakDate(visibleDates.GetItem<NSDate>(i), 15, 01, 0);
                endDate = GetBreakDate(visibleDates.GetItem<NSDate>(i), 15, 10, 0);
                appointmentCollection.Add(new ScheduleAppointment()
                {
                    StartTime = startDate,
                    EndTime = endDate,
                    AppointmentBackground = UIColor.LightGray
                });
            }

            schedule.ItemsSource = appointmentCollection;
        }

        protected override void Dispose(bool disposing)
        {
            if (schedule != null)
            {
                schedule.Dispose();
            }

            if (appointmentCollection != null)
            {
                appointmentCollection.Clear();
            }

            if (startTimeCollection != null)
            {
                startTimeCollection.Clear();
            }

            if (endTimeCollection != null)
            {
                endTimeCollection.Clear();
            }

            if (subjectCollection != null)
            {
                subjectCollection.Clear();
            }

            schedule = null;
            appointmentCollection = null;
            endTimeCollection = null;
            startTimeCollection = null;
            subjectCollection = null;
        }
    }
}
