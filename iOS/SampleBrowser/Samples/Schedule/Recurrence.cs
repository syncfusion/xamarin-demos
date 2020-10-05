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
using System.Drawing;
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
	public class Recurrence : SampleView
	{
		private SFSchedule schedule;

		private UIPickerView scheduleTypePicker = new UIPickerView();

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Recurrence()
		{
			schedule = new SFSchedule();
			schedule.ScheduleView = SFScheduleView.SFScheduleViewMonth;
			schedule.ItemsSource = CreateAppointments();
			schedule.MonthViewSettings.ShowAppointmentsInline = true;
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

		protected override void Dispose(bool disposing)
		{
			if (schedule != null)
			{
				this.schedule.Dispose();
			}

			this.schedule = null;
            
            if(scheduleTypePicker != null)
            {
                scheduleTypePicker.Dispose();
                scheduleTypePicker = null;
            }
		}

		private ObservableCollection<ScheduleAppointment> CreateAppointments()
		{
			NSDate today = new NSDate();
			ObservableCollection<ScheduleAppointment> appCollection = new ObservableCollection<ScheduleAppointment>();
			NSCalendar calendar = NSCalendar.CurrentCalendar;

			//Client Meeting recusive appointments
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
			NSDate startDate = calendar.DateFromComponents(components);
			NSDate endDate = calendar.DateFromComponents(endDateComponents);
			ScheduleAppointment clientMeetingRecurrence = new ScheduleAppointment();
            clientMeetingRecurrence.StartTime = startDate;
            clientMeetingRecurrence.EndTime = endDate;
            clientMeetingRecurrence.Subject = (NSString)@"Occurs on Every 1 week";

            //assigning RFC standard recurring rule.
            clientMeetingRecurrence.RecurrenceRule = (NSString)@"FREQ=WEEKLY;INTERVAL=1;BYDAY=FR;COUNT=10";
            clientMeetingRecurrence.AppointmentBackground = UIColor.FromRGB(0xD8, 0x00, 0x73);
			appCollection.Add(clientMeetingRecurrence);

			// Get the year, month, day from the date
			NSDateComponents components1 = calendar.Components(
				NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
			
            // Set the hour, minute, second
			components1.Hour = 12;
			components1.Minute = 0;
			components1.Second = 0;
			
            // Get the year, month, day from the date
			NSDateComponents endDateComponents1 = calendar.Components(NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
			
            // Set the hour, minute, second
			endDateComponents1.Hour = 13;
			endDateComponents1.Minute = 0;
			endDateComponents1.Second = 0;
			NSDate startDate1 = calendar.DateFromComponents(components1);
			NSDate endDate1 = calendar.DateFromComponents(endDateComponents1);
			ScheduleAppointment generalMeetingRecurrence = new ScheduleAppointment();
            generalMeetingRecurrence.StartTime = startDate1;
            generalMeetingRecurrence.EndTime = endDate1;
            generalMeetingRecurrence.Subject = (NSString)@"Occurs on Every 2 days";

            //assinging RFC stardard recurring rule.
            generalMeetingRecurrence.RecurrenceRule = (NSString)@"FREQ=DAILY;INTERVAL=2;COUNT=25";
            generalMeetingRecurrence.AppointmentBackground = UIColor.FromRGB(0xA2, 0xC1, 0x39);

			appCollection.Add(generalMeetingRecurrence);
			return appCollection;
		}
	}
}