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
using nuint = System.Int32;
using System.Drawing;
#endif

namespace SampleBrowser
{
	public class AppointmentEditor : SampleView
	{
		private SFSchedule schedule;
		private static UIView editor;
		private static UIButton buttonCancel;
		private static UIButton buttonSave;
		private static UITextView labelSubject;
		private static UITextView labelLocation;
		private static UILabel labelStarts;
		private static UILabel labelEnds;
		private static UIButton buttonStartDate;
		private static UIButton buttonEndDate;
		private static UIDatePicker pickerStartDate;
		private static UIDatePicker pickerEndDate;
		private static UIButton doneButton;
		private static ScheduleAppointment selectedAppointment;
		private static int indexOfAppointment;

        //UITapGestureRecognizer tapGesture;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AppointmentEditor()
		{
			schedule = new SFSchedule();
			editor = new UIView();
			schedule.CellTapped += Schedule_ScheduleTapped;
			schedule.ScheduleView = SFScheduleView.SFScheduleViewWeek;
			schedule.ItemsSource = CreateAppointments();
			CreateEditor();

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
				for (int i = 0; i < (schedule.ItemsSource as ObservableCollection<ScheduleAppointment>).Count; i++)
				{
					if ((schedule.ItemsSource as ObservableCollection<ScheduleAppointment>)[i] == e.ScheduleAppointment)
					{
						indexOfAppointment = int.Parse(i.ToString());
						break;
					}
				}

				selectedAppointment = e.ScheduleAppointment;
                labelSubject.Text = selectedAppointment.Subject;
                labelLocation.Text = selectedAppointment.Location;
				String startDate = DateTime.Parse(selectedAppointment.StartTime.ToString()).ToString();
                buttonStartDate.SetTitle(startDate, UIControlState.Normal);
                pickerStartDate.SetDate(selectedAppointment.StartTime, true);
				String endDate = DateTime.Parse(selectedAppointment.EndTime.ToString()).ToString();
                buttonEndDate.SetTitle(endDate, UIControlState.Normal);
                pickerEndDate.SetDate(selectedAppointment.EndTime, true);
				editor.EndEditing(true);
			}
			else
			{
				List<UIColor> colorCollection = new List<UIColor>();
				colorCollection.Add(UIColor.FromRGB(0xA2, 0xC1, 0x39));
				colorCollection.Add(UIColor.FromRGB(0xD8, 0x00, 0x73));
                labelSubject.Text = "Subject";
                labelLocation.Text = "Location";
				String startDate = DateTime.Parse(e.Date.ToString()).ToString();
                pickerStartDate.SetDate(e.Date, true);
                buttonStartDate.SetTitle(startDate, UIControlState.Normal);
				String endDate = DateTime.Parse(e.Date.AddSeconds(3600).ToString()).ToString();
                pickerEndDate.SetDate(e.Date.AddSeconds(3600), true);
                buttonEndDate.SetTitle(endDate, UIControlState.Normal);
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

            buttonCancel.Frame = new CGRect(20, yMargin, 200, 30);
            buttonSave.Frame = new CGRect(this.Frame.Width - 220, yMargin, 200, 30);
            labelSubject.Frame = new CGRect(xMargin, yMargin * 2, elementWidth, 30);
            labelLocation.Frame = new CGRect(xMargin, yMargin * 3, elementWidth, 30);
            labelStarts.Frame = new CGRect(xMargin, yMargin * 4, elementWidth, 30);
            buttonStartDate.Frame = new CGRect(xMargin, yMargin * 5, elementWidth, 30);
            labelEnds.Frame = new CGRect(xMargin, yMargin * 6, elementWidth, 30);
            buttonEndDate.Frame = new CGRect(xMargin, yMargin * 7, elementWidth, 30);

            pickerStartDate.Frame = new CGRect(xMargin, yMargin * 4, elementWidth, 200);
            pickerEndDate.Frame = new CGRect(xMargin, yMargin * 4, elementWidth, 200);
            doneButton.Frame = new CGRect(xMargin, yMargin * 4, elementWidth, 30);

			base.LayoutSubviews();
		}

        private void CreateEditor()
		{
            buttonCancel = new UIButton();
            buttonSave = new UIButton();
            labelSubject = new UITextView();
            labelLocation = new UITextView();
            labelEnds = new UILabel();
            labelStarts = new UILabel();
            buttonStartDate = new UIButton();
            buttonEndDate = new UIButton();
            pickerStartDate = new UIDatePicker();
            pickerEndDate = new UIDatePicker();
            doneButton = new UIButton();

            //cancel button
            buttonCancel.SetTitle("Cancel", UIControlState.Normal);
            buttonCancel.SetTitleColor(UIColor.Blue, UIControlState.Normal);
            buttonCancel.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            buttonCancel.TouchUpInside += (object sender, EventArgs e) =>
			{
				editor.Hidden = true;
				schedule.Hidden = false;
				editor.EndEditing(true);
			};

            //save button
            buttonSave.SetTitle("Save", UIControlState.Normal);
            buttonSave.SetTitleColor(UIColor.Blue, UIControlState.Normal);
            buttonSave.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            buttonSave.TouchUpInside += (object sender, EventArgs e) =>
			{
				if (indexOfAppointment != -1)
				{
					(schedule.ItemsSource as ObservableCollection<ScheduleAppointment>)[int.Parse(indexOfAppointment.ToString())].Subject = (NSString)labelSubject.Text;
					(schedule.ItemsSource as ObservableCollection<ScheduleAppointment>)[int.Parse(indexOfAppointment.ToString())].Location = (NSString)labelLocation.Text;
					(schedule.ItemsSource as ObservableCollection<ScheduleAppointment>)[int.Parse(indexOfAppointment.ToString())].StartTime = pickerStartDate.Date;
					(schedule.ItemsSource as ObservableCollection<ScheduleAppointment>)[int.Parse(indexOfAppointment.ToString())].EndTime = pickerEndDate.Date;
				}
				else
				{
					ScheduleAppointment appointment = new ScheduleAppointment();
					appointment.Subject = (NSString)labelSubject.Text;
					appointment.Location = (NSString)labelLocation.Text;
					appointment.StartTime = pickerStartDate.Date;
					appointment.EndTime = pickerEndDate.Date;
					appointment.AppointmentBackground = UIColor.FromRGB(0xA2, 0xC1, 0x39);
					(schedule.ItemsSource as ObservableCollection<ScheduleAppointment>).Add(appointment);
				}

				editor.Hidden = true;
				schedule.Hidden = false;
				schedule.ReloadData();
				editor.EndEditing(true);
			};

            //subject label
            labelSubject.TextColor = UIColor.Black;
            labelSubject.TextAlignment = UITextAlignment.Left;
            labelSubject.Layer.CornerRadius = 8;
            labelSubject.Layer.BorderWidth = 2;
            labelSubject.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;

            //location label
            labelLocation.TextColor = UIColor.Black;
            labelLocation.TextAlignment = UITextAlignment.Left;
            labelLocation.Layer.CornerRadius = 8;
            labelLocation.Layer.BorderWidth = 2;
            labelLocation.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;

            //starts time
            labelStarts.Text = "Start Time :";
            labelStarts.TextColor = UIColor.Black;

            buttonStartDate.SetTitle("Start time", UIControlState.Normal);
            buttonStartDate.SetTitleColor(UIColor.Blue, UIControlState.Normal);
            buttonStartDate.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            buttonStartDate.TouchUpInside += (object sender, EventArgs e) =>
			{
                pickerStartDate.Hidden = false;
                doneButton.Hidden = false;
                labelEnds.Hidden = true;
                buttonEndDate.Hidden = true;
                buttonStartDate.Hidden = true;
                labelStarts.Hidden = true;
				editor.EndEditing(true);
			};

            //end time
            labelEnds.Text = "End Time :";
            labelEnds.TextColor = UIColor.Black;

            //end date
            buttonEndDate.SetTitle("End time", UIControlState.Normal);
            buttonEndDate.SetTitleColor(UIColor.Blue, UIControlState.Normal);
            buttonEndDate.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            buttonEndDate.TouchUpInside += (object sender, EventArgs e) =>
			{
                pickerEndDate.Hidden = false;
                doneButton.Hidden = false;
                labelEnds.Hidden = true;
                buttonEndDate.Hidden = true;
                buttonStartDate.Hidden = true;
                labelStarts.Hidden = true;
				editor.EndEditing(true);
			};

            //date and time pickers
            pickerStartDate.Hidden = true;
            pickerEndDate.Hidden = true;

            //done button
            doneButton.SetTitle("Done", UIControlState.Normal);
            doneButton.SetTitleColor(UIColor.Blue, UIControlState.Normal);
            doneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            doneButton.TouchUpInside += (object sender, EventArgs e) =>
			{
                pickerStartDate.Hidden = true;
                pickerEndDate.Hidden = true;
                doneButton.Hidden = true;
                labelEnds.Hidden = false;
                buttonEndDate.Hidden = false;
                buttonStartDate.Hidden = false;
                labelStarts.Hidden = false;

				String _sDate = DateTime.Parse(pickerStartDate.Date.ToString()).ToString();
                buttonStartDate.SetTitle(_sDate, UIControlState.Normal);

				String _eDate = DateTime.Parse(pickerEndDate.Date.ToString()).ToString();
                buttonEndDate.SetTitle(_eDate, UIControlState.Normal);
				editor.EndEditing(true);
			};

            buttonCancel.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 10, 100, 30);
            buttonSave.Frame = new CGRect(100, this.Frame.Y + 10, 300, 30);
            labelSubject.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 50, 300, 30);
            labelLocation.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 90, 300, 30);
            labelStarts.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 140, 300, 30);
            buttonStartDate.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 180, 300, 30);
            labelEnds.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 220, 300, 30);
            buttonEndDate.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 260, 300, 30);

            pickerStartDate.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 180, 300, 30);
            pickerEndDate.Frame = new CGRect(100, this.Frame.Y + 180, 300, 30);
            pickerEndDate.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 180, 300, 30);
            doneButton.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 180, 300, 30);
            doneButton.Hidden = true;

			editor.Add(buttonCancel);
			editor.Add(buttonSave);
			editor.Add(labelSubject);
			editor.Add(labelLocation);
			editor.Add(labelStarts);
			editor.Add(buttonStartDate);
			editor.Add(labelEnds);
			editor.Add(buttonEndDate);
			editor.Add(pickerEndDate);
			editor.Add(pickerStartDate);
			editor.Add(doneButton);
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