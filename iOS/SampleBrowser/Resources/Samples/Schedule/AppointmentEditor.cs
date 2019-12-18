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
using nuint = System.Int32;
using System.Drawing;
#endif


namespace SampleBrowser
{
	public class AppointmentEditor : SampleView
	{
		SFSchedule schedule;
		static UIView editor;
		static UIButton button_cancel;
		static UIButton button_save;
		static UITextView label_subject;
		static UITextView label_location;
		static UILabel label_starts;
		static UILabel label_ends;
		static UIButton button_startDate;
		static UIButton button_endDate;
		static UIDatePicker picker_startDate;
		static UIDatePicker picker_endDate;
		static UIButton done_button;
		static ScheduleAppointment selectedAppointment;
		static int indexOfAppointment;

		//UITapGestureRecognizer tapGesture;
		public AppointmentEditor()
		{
			schedule = new SFSchedule();
			editor = new UIView();
			schedule.CellTapped += Schedule_ScheduleTapped;
			schedule.ScheduleView = SFScheduleView.SFScheduleViewWeek;
			schedule.Appointments = CreateAppointments();
			createEditor();

			this.AddSubview(schedule);
			schedule.Hidden = false;
			editor.Hidden = true;
			this.AddSubview(editor);

			//	control = this;
		}

		private void Schedule_ScheduleTapped(object sender, CellTappedEventArgs e)
		{
			editor.Hidden = false;
			schedule.Hidden = true;
			indexOfAppointment = -1;
			if (e.ScheduleAppointment != null)
			{
				for (nuint i = 0; i < schedule.Appointments.Count; i++)
				{
					if (schedule.Appointments.GetItem<ScheduleAppointment>(i) == e.ScheduleAppointment)
					{
						indexOfAppointment = int.Parse(i.ToString());
						break;
					}
				}
				selectedAppointment = (e.ScheduleAppointment);
				label_subject.Text = selectedAppointment.Subject;
				label_location.Text = selectedAppointment.Location;
				String _sDate = DateTime.Parse((selectedAppointment.StartTime.ToString())).ToString();
				button_startDate.SetTitle(_sDate, UIControlState.Normal);
				picker_startDate.SetDate(selectedAppointment.StartTime, true);
				String _eDate = DateTime.Parse((selectedAppointment.EndTime.ToString())).ToString();
				button_endDate.SetTitle(_eDate, UIControlState.Normal);
				picker_endDate.SetDate(selectedAppointment.EndTime, true);
				editor.EndEditing(true);
			}
			else
			{
				List<UIColor> colorCollection = new List<UIColor>();
				colorCollection.Add(UIColor.FromRGB(0xA2, 0xC1, 0x39));
				colorCollection.Add(UIColor.FromRGB(0xD8, 0x00, 0x73));
				label_subject.Text = "Subject";
				label_location.Text = "Location";
				String _sDate = DateTime.Parse((e.Date.ToString())).ToString();
				picker_startDate.SetDate(e.Date, true);
				button_startDate.SetTitle(_sDate, UIControlState.Normal);
				String _eDate = DateTime.Parse((e.Date.AddSeconds(3600).ToString())).ToString();
				picker_endDate.SetDate(e.Date.AddSeconds(3600), true);
				button_endDate.SetTitle(_eDate, UIControlState.Normal);

			}
		}

		public override void LayoutSubviews()
		{
			foreach (var view in this.Subviews)
			{
				view.Frame = new CGRect(Frame.X, 0, Frame.Width, Frame.Height);
			}

			nfloat yMargin = nfloat.Parse((this.Frame.Height * 0.1).ToString());
			nfloat xMargin = nfloat.Parse((this.Frame.Width * 0.1).ToString());
			nfloat elementWidth = nfloat.Parse((this.Frame.Width - (xMargin * 2)).ToString());

			button_cancel.Frame = new CGRect(20, yMargin, 200, 30);
			button_save.Frame = new CGRect((this.Frame.Width) - 220, yMargin, 200, 30);
			label_subject.Frame = new CGRect(xMargin, yMargin * 2, elementWidth, 30);
			label_location.Frame = new CGRect(xMargin, yMargin * 3, elementWidth, 30);
			label_starts.Frame = new CGRect(xMargin, yMargin * 4, elementWidth, 30);
			button_startDate.Frame = new CGRect(xMargin, yMargin * 5, elementWidth, 30);
			label_ends.Frame = new CGRect(xMargin, yMargin * 6, elementWidth, 30);
			button_endDate.Frame = new CGRect(xMargin, yMargin * 7, elementWidth, 30);

			picker_startDate.Frame = new CGRect(xMargin, yMargin * 4, elementWidth, 200);
			picker_endDate.Frame = new CGRect(xMargin, yMargin * 4, elementWidth, 200);
			done_button.Frame = new CGRect(xMargin, yMargin * 4, elementWidth, 30);

			base.LayoutSubviews();
		}
		private void createEditor()
		{
			button_cancel = new UIButton();
			button_save = new UIButton();
			label_subject = new UITextView();
			label_location = new UITextView();
			label_ends = new UILabel();
			label_starts = new UILabel();
			button_startDate = new UIButton();
			button_endDate = new UIButton();
			picker_startDate = new UIDatePicker();
			picker_endDate = new UIDatePicker();
			done_button = new UIButton();


			//cancel button
			button_cancel.SetTitle("Cancel", UIControlState.Normal);
			button_cancel.SetTitleColor(UIColor.Blue, UIControlState.Normal);
			button_cancel.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			button_cancel.TouchUpInside += (object sender, EventArgs e) =>
			{
				editor.Hidden = true;
				schedule.Hidden = false;
				editor.EndEditing(true);
			};

			//save button
			button_save.SetTitle("Save", UIControlState.Normal);
			button_save.SetTitleColor(UIColor.Blue, UIControlState.Normal);
			button_save.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			button_save.TouchUpInside += (object sender, EventArgs e) =>
			{
				if (indexOfAppointment != -1)
				{
					schedule.Appointments.GetItem<ScheduleAppointment>(nuint.Parse(indexOfAppointment.ToString())).Subject = (NSString)label_subject.Text;
					schedule.Appointments.GetItem<ScheduleAppointment>(nuint.Parse(indexOfAppointment.ToString())).Location = (NSString)label_location.Text;
					schedule.Appointments.GetItem<ScheduleAppointment>(nuint.Parse(indexOfAppointment.ToString())).StartTime = picker_startDate.Date;
					schedule.Appointments.GetItem<ScheduleAppointment>(nuint.Parse(indexOfAppointment.ToString())).EndTime = picker_endDate.Date;
				}
				else
				{
					ScheduleAppointment appointment = new ScheduleAppointment();
					appointment.Subject = (NSString)label_subject.Text;
					appointment.Location = (NSString)label_location.Text;
					appointment.StartTime = picker_startDate.Date;
					appointment.EndTime = picker_endDate.Date;
					appointment.AppointmentBackground = UIColor.FromRGB(0xA2, 0xC1, 0x39);
					schedule.Appointments.Add(appointment);
				}
				editor.Hidden = true;
				schedule.Hidden = false;
				schedule.ReloadData();
				editor.EndEditing(true);
			};

			//subject label
			label_subject.TextColor = UIColor.Black;
			label_subject.TextAlignment = UITextAlignment.Left;
			label_subject.Layer.CornerRadius = 8;
			label_subject.Layer.BorderWidth = 2;
			label_subject.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;


			//location label
			label_location.TextColor = UIColor.Black;
			label_location.TextAlignment = UITextAlignment.Left;
			label_location.Layer.CornerRadius = 8;
			label_location.Layer.BorderWidth = 2;
			label_location.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;

			//starts time

			label_starts.Text = "Start Time :";
			label_starts.TextColor = UIColor.Black;

			button_startDate.SetTitle("Start time", UIControlState.Normal);
			button_startDate.SetTitleColor(UIColor.Blue, UIControlState.Normal);
			button_startDate.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			button_startDate.TouchUpInside += (object sender, EventArgs e) =>
			{
				picker_startDate.Hidden = false;
				done_button.Hidden = false;
				label_ends.Hidden = true;
				button_endDate.Hidden = true;
				button_startDate.Hidden = true;
				label_starts.Hidden = true;
				editor.EndEditing(true);
			};

			//end time

			label_ends.Text = "End Time :";
			label_ends.TextColor = UIColor.Black;


			//end date
			button_endDate.SetTitle("End time", UIControlState.Normal);
			button_endDate.SetTitleColor(UIColor.Blue, UIControlState.Normal);
			button_endDate.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			button_endDate.TouchUpInside += (object sender, EventArgs e) =>
			{
				picker_endDate.Hidden = false;
				done_button.Hidden = false;
				label_ends.Hidden = true;
				button_endDate.Hidden = true;
				button_startDate.Hidden = true;
				label_starts.Hidden = true;
				editor.EndEditing(true);
			};

			//date and time pickers
			picker_startDate.Hidden = true;
			picker_endDate.Hidden = true;

			//done button
			done_button.SetTitle("Done", UIControlState.Normal);
			done_button.SetTitleColor(UIColor.Blue, UIControlState.Normal);
			done_button.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			done_button.TouchUpInside += (object sender, EventArgs e) =>
			{
				picker_startDate.Hidden = true;
				picker_endDate.Hidden = true;
				done_button.Hidden = true;
				label_ends.Hidden = false;
				button_endDate.Hidden = false;
				button_startDate.Hidden = false;
				label_starts.Hidden = false;

				String _sDate = DateTime.Parse((picker_startDate.Date.ToString())).ToString();
				button_startDate.SetTitle(_sDate, UIControlState.Normal);

				String _eDate = DateTime.Parse((picker_endDate.Date.ToString())).ToString();
				button_endDate.SetTitle(_eDate, UIControlState.Normal);
				editor.EndEditing(true);

			};

			button_cancel.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 10, 100, 30);
			button_save.Frame = new CGRect(100, this.Frame.Y + 10, 300, 30);
			label_subject.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 50, 300, 30);
			label_location.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 90, 300, 30);
			label_starts.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 140, 300, 30);
			button_startDate.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 180, 300, 30);
			label_ends.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 220, 300, 30);
			button_endDate.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 260, 300, 30);

			picker_startDate.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 180, 300, 30);
			picker_endDate.Frame = new CGRect(100, this.Frame.Y + 180, 300, 30);
			picker_endDate.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 180, 300, 30);
			done_button.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 180, 300, 30);
			done_button.Hidden = true;

			editor.Add(button_cancel);
			editor.Add(button_save);
			editor.Add(label_subject);
			editor.Add(label_location);
			editor.Add(label_starts);
			editor.Add(button_startDate);
			editor.Add(label_ends);
			editor.Add(button_endDate);
			editor.Add(picker_endDate);
			editor.Add(picker_startDate);
			editor.Add(done_button);
		}

		NSMutableArray CreateAppointments()
		{
			NSDate today = new NSDate();
			setColors();
			setSubjects();
			NSMutableArray appCollection = new NSMutableArray();
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
				endDateComponents.Hour = components.Hour + randomNumber.Next(1, 3);
				NSDate startDate = calendar.DateFromComponents(components);
				NSDate endDate = calendar.DateFromComponents(endDateComponents);
				ScheduleAppointment appointment = new ScheduleAppointment();
				appointment.StartTime = startDate;
				appointment.EndTime = endDate;
				components.Day = components.Day + 1;
				endDateComponents.Day = endDateComponents.Day + 1;
				appointment.Subject = (NSString)subjectCollection[i];
				appointment.AppointmentBackground = colorCollection[i];

				appCollection.Add(appointment);
			}
			return appCollection;
		}

		List<String> subjectCollection;

		private void setSubjects()
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
		List<UIColor> colorCollection;
		private void setColors()
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

