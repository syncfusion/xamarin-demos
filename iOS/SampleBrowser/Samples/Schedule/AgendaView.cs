#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.Collections.Generic;
using Syncfusion.SfSchedule.iOS;
using System.Collections.ObjectModel;

#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using CGRect = System.Drawing.RectangleF;
using CGPoint = System.Drawing.PointF;
using CGSize = System.Drawing.SizeF;
using nfloat = System.Single;
using System.Drawing;
#endif

namespace SampleBrowser
{
    public class AgendaView : SampleView
    {
        private static SFSchedule schedule;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AgendaView()
        {
            schedule = new SFSchedule();
            schedule.ScheduleView = SFScheduleView.SFScheduleViewMonth;
            MonthViewSettings monthSettings = new MonthViewSettings();

            monthSettings.ShowAppointmentsInline = false;
            monthSettings.ShowAgendaView = true;
            schedule.MonthViewSettings = monthSettings;
            schedule.ItemsSource = CreateAppointments();
            this.AddSubview(schedule);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (schedule != null)
                {
                    schedule.Dispose();
                    schedule = null;
                }
            }

            base.Dispose(disposing);
        }

        public override void LayoutSubviews()
        {
            foreach (var view in this.Subviews)
            {
                view.Frame = Bounds;
            }

            base.LayoutSubviews();
        }

        private ObservableCollection<ScheduleAppointment> CreateAppointments()
        {
            NSDate today = new NSDate();
            SetColors();
            SetSubjects();
            ObservableCollection<ScheduleAppointment> appCollection = new ObservableCollection<ScheduleAppointment>();
            NSCalendar calendar = NSCalendar.CurrentCalendar;
            
            // Get the year, month, day from the date
            NSDateComponents components = calendar.Components(
            NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
            
            // Set the hour, minute, second
            components.Hour = 10;
            components.Minute = 0;
            components.Second = 0;

            // Get the year, month, day from the date
            NSDateComponents endDateComponents = calendar.Components(NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
           
            // Set the hour, minute, second
            endDateComponents.Hour = 12;
            endDateComponents.Minute = 0;
            endDateComponents.Second = 0;
            var startDay = components.Day;
            var nextMonth = components.Month;
            var prevMonth = components.Month;
            if (nextMonth == 12)
            {
                nextMonth = 1;
            }
            else
            {
                nextMonth = nextMonth + 1;
            }

            if (prevMonth == 1)
            {
                prevMonth = 12;
            }
            else
            {
                prevMonth = prevMonth - 1;
            }

            Random randomNumber = new Random();
            var count = 0;
            for (int i = 0; i < 30; i++)
            {
                components.Hour = randomNumber.Next(10, 16);
                endDateComponents.Hour = components.Hour + randomNumber.Next(1, 3);
                NSDate startDate = calendar.DateFromComponents(components);
                NSDate endDate = calendar.DateFromComponents(endDateComponents);
                ScheduleAppointment appointment = new ScheduleAppointment();
                if (i < 10 && i >= 0)
                {
                    appointment.StartTime = startDate;
                    appointment.EndTime = endDate;
                }
                else if (i < 20 && i >= 10)
                {
                    components.Month = nextMonth;
                    endDateComponents.Month = nextMonth;
                    appointment.StartTime = startDate;
                    appointment.EndTime = endDate;
                }
                else if (i < 30 && i >= 20)
                {
                    components.Month = prevMonth;
                    endDateComponents.Month = prevMonth;
                    appointment.StartTime = startDate;
                    appointment.EndTime = endDate;
                }

                components.Day = components.Day + 1;
                endDateComponents.Day = endDateComponents.Day + 1;
                appointment.Subject = (NSString)subjectCollection[count];
                appointment.AppointmentBackground = colorCollection[count];

                if (i == 10 || i == 20)
                {
                    components.Day = startDay;
                    endDateComponents.Day = startDay;
                }

                count++;
                if (count == 10)
                {
                    count = 0;
                }

                appCollection.Add(appointment);
            }

            return appCollection;
        }

        private List<String> subjectCollection;

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
        private List<UIColor> colorCollection;

        private void SetColors()
        {
            colorCollection = new List<UIColor>();
            colorCollection.Add(UIColor.FromRGB(0xA2, 0xC1, 0x39));
            colorCollection.Add(UIColor.FromRGB(0xD8, 0x00, 0x73));
            colorCollection.Add(UIColor.FromRGB(0x1B, 0xA1, 0xE2));
            colorCollection.Add(UIColor.FromRGB(0xE6, 0x71, 0xB8));
            colorCollection.Add(UIColor.FromRGB(0xF0, 0x96, 0x09));
            colorCollection.Add(UIColor.FromRGB(0x33, 0x99, 0x33));
            colorCollection.Add(UIColor.FromRGB(0x00, 0xAB, 0xA9));
            colorCollection.Add(UIColor.FromRGB(0xE6, 0x71, 0xB8));
            colorCollection.Add(UIColor.FromRGB(0x1B, 0xA1, 0xE2));
            colorCollection.Add(UIColor.FromRGB(0xD8, 0x00, 0x73));
            colorCollection.Add(UIColor.FromRGB(0xA2, 0xC1, 0x39));
            colorCollection.Add(UIColor.FromRGB(0xD8, 0x00, 0x73));
            colorCollection.Add(UIColor.FromRGB(0x33, 0x99, 0x33));
            colorCollection.Add(UIColor.FromRGB(0xE6, 0x71, 0xB8));
            colorCollection.Add(UIColor.FromRGB(0x00, 0xAB, 0xA9));
        }
    }
}
