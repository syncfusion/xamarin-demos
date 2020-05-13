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
    public class DragDrop : SampleView
    {
        /// <summary>
        /// Initialize the schedule.
        /// </summary>
        private SFSchedule schedule = new SFSchedule();
       
        /// <summary>
        /// Label for toast view.
        /// </summary>
        private UILabel toastUIView;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DragDrop()
        {
            schedule = new SFSchedule();
            schedule.ScheduleView = SFScheduleView.SFScheduleViewWeek;

            NonAccessibleBlock nonAccessibleBlock = new NonAccessibleBlock();
           
            //Create new instance of NonAccessibleBlocksCollection
            NSMutableArray nonAccessibleBlocksCollection = new NSMutableArray();
            WeekViewSettings weekViewSettings = new WeekViewSettings();
            nonAccessibleBlock.StartHour = 13;
            nonAccessibleBlock.EndHour = 14;
            nonAccessibleBlock.Text = (NSString)"LUNCH";
            nonAccessibleBlock.BackgroundColor = UIColor.Black;
            nonAccessibleBlocksCollection.Add(nonAccessibleBlock);
            weekViewSettings.NonAccessibleBlockCollection = nonAccessibleBlocksCollection;
            schedule.WeekViewSettings = weekViewSettings;

            schedule.AllowAppointmentDrag = true;
            schedule.AppointmentDrop += Schedule_AppointmentDrop;
            schedule.ItemsSource = CreateAppointments();
            this.AddSubview(schedule);
        }

        /// <summary>
        /// drop event for schedule appointment.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Schedule_AppointmentDrop(object sender, AppointmentDropEventArgs e)
        {
            e.Cancel = false;
            if (IsInNonAccessRegion(e.DropTime))
            {
                DisplayToast("Cannot be moved to blocked time slots");
                e.Cancel = true;
                return;
            }

            DisplayToast("Moved to " + FormattedDate(e.DropTime));
        }

        private string FormattedDate(NSDate startDate)
        {
            NSDateFormatter dateFormat = new NSDateFormatter();
            dateFormat.DateFormat = "EEEE, MMM d, h:mm a";
            return dateFormat.ToString(startDate);
        }

        /// <summary>
        /// check the appointment with in non accessible block region.
        /// </summary>
        /// <param name="dropTime"></param>
        /// <returns></returns>
        private bool IsInNonAccessRegion(NSDate dropTime)
        {
            NSCalendar calendar = NSCalendar.CurrentCalendar;
            NSDateComponents start = calendar.Components(
                                                         NSCalendarUnit.Year |
                                                         NSCalendarUnit.Month |
                                                         NSCalendarUnit.Day |
                                                         NSCalendarUnit.Hour |
                                                         NSCalendarUnit.Minute |                                                                   
                                                         NSCalendarUnit.Second, 
                                                         dropTime);
            if ((schedule.WeekViewSettings.NonAccessibleBlockCollection.GetItem<NonAccessibleBlock>(0).StartHour == start.Hour)
                || (schedule.WeekViewSettings.NonAccessibleBlockCollection.GetItem<NonAccessibleBlock>(0).StartHour - 1 == start.Hour && start.Minute > 0))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// displaying toast when drag or drop the appointment.
        /// </summary>
        /// <param name="toastText"></param>
        private void DisplayToast(string toastText)
        {
            toastUIView = new UILabel();
            toastUIView.Hidden = false;
            toastUIView.Text = toastText;
            toastUIView.Layer.CornerRadius = 20f;
            toastUIView.TextColor = UIColor.White;
            toastUIView.LineBreakMode = UILineBreakMode.WordWrap;
            toastUIView.Lines = 2;
            toastUIView.TextAlignment = UITextAlignment.Center;
            toastUIView.ClipsToBounds = true;
            toastUIView.Font = UIFont.SystemFontOfSize(14);
            toastUIView.BackgroundColor = UIColor.FromRGB(101.0f / 255.0f, 101.0f / 255.0f, 101.0f / 255.0f);
            toastUIView.Layer.ZPosition = 10;
            this.AddSubview(toastUIView);
            toastUIView.Frame = new CGRect(this.Frame.Right / 10, this.Frame.Bottom - 150, this.Frame.Right - ((this.Frame.Right / 10) * 2), 50);
            UIView.Animate(
                0.5,
                0, 
                UIViewAnimationOptions.CurveLinear, 
                () =>
            {
                toastUIView.Alpha = 1.0f;
            },
                () =>
                {
                    UIView.Animate(
                        3.0, 
                        () =>
                    {
                        toastUIView.Alpha = 0.0f;
                    });
                });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (schedule != null)
                {
                    schedule.AppointmentDrop -= Schedule_AppointmentDrop;
                    schedule.Dispose();
                    schedule = null;
                }

                if(toastUIView != null)
                {
                    toastUIView.Dispose();
                    toastUIView = null;
                }
            }

            base.Dispose(disposing);
        }

        public override void LayoutSubviews()
        {
            foreach (var view in this.Subviews)
            {
                if (view is UILabel)
                {
                    this.BringSubviewToFront(toastUIView);
                    toastUIView.Frame = new CGRect(this.Frame.Right / 10, this.Frame.Bottom - 150, this.Frame.Right - ((this.Frame.Right / 10) * 2), 50);
                }
                else
                {
                    view.Frame = Bounds;
                }
            }

            base.LayoutSubviews();
        }

        /// <summary>
        /// create appointments.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<ScheduleAppointment> CreateAppointments()
        {
            NSDate today = new NSDate();
            SetColors();
            SetSubjects();
            List<ScheduleAppointment> appCollection = new List<ScheduleAppointment>();
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
            Random randomNumber = new Random();

            for (int i = 0; i < 10; i++)
            {
                components.Hour = randomNumber.Next(10, 16);
                endDateComponents.Hour = components.Hour + randomNumber.Next(1, 1);
                NSDate startDate = calendar.DateFromComponents(components);
                NSDate endDate = calendar.DateFromComponents(endDateComponents);
                ScheduleAppointment appointment = new ScheduleAppointment();
                appointment.StartTime = startDate;
                appointment.EndTime = endDate;
                components.Day = components.Day + 1;
                endDateComponents.Day = endDateComponents.Day + 1;
                appointment.Subject = (NSString)subjectCollection[i];
                appointment.AppointmentBackground = colorCollection[i];
                if (i == 10 || i == 7)
                {
                    appointment.IsAllDay = true;
                }

                appCollection.Add(appointment);
            }

            return appCollection;
        }
       
        //adding subject collection.
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
