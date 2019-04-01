#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfSchedule.iOS;
using System.Drawing;

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
		SFSchedule schedule;

		UIPickerView scheduleTypePicker = new UIPickerView();
		public Recurrence()
		{
			schedule = new SFSchedule();
			schedule.ScheduleView = SFScheduleView.SFScheduleViewMonth;
			schedule.Appointments = CreateAppointments();
			schedule.MonthViewSettings.ShowAppointmentsInline = true;
			schedule.MonthInlineLoaded += Schedule_MonthInlineLoaded;
			schedule.MonthInlineAppointmentLoaded += Schedule_MonthInlineAppointmentLoaded;
			this.AddSubview(schedule);
			//control = this;
		}

		private void Schedule_MonthInlineAppointmentLoaded(object sender, MonthInlineAppointmentLoadedEventArgs e)
		{
			UIView mainView = new UIView();
			mainView.BackgroundColor = UIColor.FromRGB(221, 221, 221);
			mainView.Frame = new RectangleF(0, 0, (float)UIScreen.MainScreen.Bounds.Size.Width, 40);

			UIView view = new UIView();
			view.BackgroundColor = UIColor.FromRGB(246, 246, 246);
			view.Frame = new RectangleF(0, 0, (float)mainView.Frame.Size.Width, 38);

			UITextView startTime = new UITextView();
			startTime.Text = DateTime.Parse(e.Appointment.StartTime.ToString()).ToString("hh:mm tt");
			startTime.BackgroundColor = UIColor.FromRGB(246, 246, 246);
			startTime.TextColor = UIColor.FromRGB(0, 0, 0);
			startTime.Frame = new RectangleF(0, 0, ((float)mainView.Frame.Size.Width), (float)17.5);
			startTime.Font = UIFont.SystemFontOfSize(8, UIFontWeight.Bold);

			UITextView endTime = new UITextView();
			endTime.Text = DateTime.Parse((e.Appointment.EndTime.ToString())).ToString("hh:mm tt");
			endTime.BackgroundColor = UIColor.FromRGB(246, 246, 246);
			endTime.TextColor = UIColor.FromRGB(0, 0, 0);
			endTime.Frame = new RectangleF(0, 20, ((float)mainView.Frame.Size.Width), (float)17.5);
			endTime.Font = UIFont.SystemFontOfSize(8, UIFontWeight.Bold);

			UITextView subject = new UITextView();
			subject.Text = e.Appointment.Subject.ToString();
			subject.TextColor = UIColor.FromRGB(0, 0, 0);
			subject.BackgroundColor = UIColor.FromRGB(246, 246, 246);
			subject.Frame = new RectangleF(100, 5, (float)mainView.Frame.Size.Width, 30);
			subject.Font = UIFont.SystemFontOfSize(12, UIFontWeight.Bold);

			view.AddSubview(startTime);
			view.AddSubview(endTime);
			view.AddSubview(subject);

			mainView.AddSubview(view);
			e.View = mainView;
		}

		private void Schedule_MonthInlineLoaded(object sender, MonthInlineLoadedEventArgs e)
		{

			e.MonthInlineViewStyle.BackgroundColor = UIColor.FromRGB(246, 246, 246);
			e.MonthInlineViewStyle.TextColor = UIColor.Black;


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
		}

		NSMutableArray CreateAppointments()
		{
			NSDate today = new NSDate();
			NSMutableArray appCollection = new NSMutableArray();
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
			ScheduleAppointment ClientMeeting_Recurrence = new ScheduleAppointment();
			ClientMeeting_Recurrence.StartTime = startDate;
			ClientMeeting_Recurrence.EndTime = endDate;
			ClientMeeting_Recurrence.Subject = (NSString)@"Occurs on Every 1 week";
			//assinging RFC stardard recurring rule.
			ClientMeeting_Recurrence.RecurrenceRule = (NSString)@"FREQ=WEEKLY;INTERVAL=1;BYDAY=FR;COUNT=10";
			ClientMeeting_Recurrence.IsRecursive = true;
			//			ClientMeeting_Recurrence.AppointmentBackground = UIColor.FromRGB(red:0.106, green:0.631, blue:0.886 );
			ClientMeeting_Recurrence.AppointmentBackground = UIColor.FromRGB(0xD8, 0x00, 0x73);
			appCollection.Add(ClientMeeting_Recurrence);

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
			ScheduleAppointment General_Meeting_Recurrence = new ScheduleAppointment();
			General_Meeting_Recurrence.StartTime = startDate1;
			General_Meeting_Recurrence.EndTime = endDate1;
			General_Meeting_Recurrence.Subject = (NSString)@"Occurs on Every 2 days";
			//assinging RFC stardard recurring rule.
			General_Meeting_Recurrence.RecurrenceRule = (NSString)@"FREQ=DAILY;INTERVAL=2;COUNT=25";
			General_Meeting_Recurrence.IsRecursive = true;
			//			ClientMeeting_Recurrence.AppointmentBackground = UIColor.FromRGB(red:0.106, green:0.631, blue:0.886 );
			General_Meeting_Recurrence.AppointmentBackground = UIColor.FromRGB(0xA2, 0xC1, 0x39);

			appCollection.Add(General_Meeting_Recurrence);
			return appCollection;
		}
	}
}

