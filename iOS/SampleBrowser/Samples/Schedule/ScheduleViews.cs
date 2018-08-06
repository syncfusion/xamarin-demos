#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfSchedule.iOS;
using System.Collections.ObjectModel;
using System.Collections;

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
	public class ScheduleViews : SampleView
	{
		public static SFSchedule schedule;
		private static UIView editor;
        private UIButton button_cancel, button_save, done_button, timezoneButton, doneButton;
		private UITextView label_subject,label_location;
        private UILabel label_starts, label_ends, startTimeZoneLabel, endTimeZoneLabel, allDaylabel,timezoneLabel;
        private UISwitch allDaySwitch;
        private UIPickerView startTimeZonePicker, endTimeZonePicker,timeZonePicker;
		private UIButton button_startDate, button_endDate, startTimeZoneButton, endTimeZoneButton;
		private UIDatePicker picker_startDate,picker_endDate;
		private ScheduleAppointment selectedAppointment;
		UIScrollView scrollView;
		private int indexOfAppointment;

		private UIButton headerButton = new UIButton();
		private UIButton moveToDate = new UIButton();
		private static UILabel monthText = new UILabel();
		private UIButton editorView = new UIButton();
		private static UIView headerView = new UIView();
		public static UITableView tableView = new UITableView();
		public ScheduleViews()
		{
			schedule = new SFSchedule();
			editor = new UIView();
            editor.BackgroundColor = UIColor.White;

			schedule.AppointmentsForDate += Schedule_AppointmentsForDate;
			schedule.AppointmentsFromDate += Schedule_AppointmentsFromDate;
			schedule.CellTapped += Schedule_CellTapped;
			schedule.CellDoubleTapped += Schedule_DoubleTapped;
			schedule.VisibleDatesChanged += Schedule_VisibleDatesChanged;

			schedule.ScheduleView = SFScheduleView.SFScheduleViewWeek;
			schedule.ItemsSource = CreateAppointments();
			createEditor();
			this.OptionView = new UIView();
			schedule.HeaderHeight = 0;
			schedule.ViewHeaderHeight = 50;

			schedule.Hidden = false;
			editor.Hidden = true;
		}

		private void Schedule_CellTapped(object sender, CellTappedEventArgs e)
		{
			if (schedule.ScheduleView == SFScheduleView.SFScheduleViewMonth)
			{

				schedule.ScheduleView = SFScheduleView.SFScheduleViewDay;
				schedule.MoveToDate(e.Date);
				schedule.Hidden = false;
				editor.Hidden = true;
				headerView.Hidden = false;
			}
		}

		private void Schedule_VisibleDatesChanged(object sender, VisibleDatesChangedEventArgs e)
		{
			int CurrentVisibleMonth = 0;
			if (schedule.ScheduleView == SFScheduleView.SFScheduleViewMonth)
			{
				CurrentVisibleMonth = 8;
			}
			else
			{
				CurrentVisibleMonth = 0;
			}
			NSDate date = e.VisibleDates.GetItem<NSDate>((nuint)CurrentVisibleMonth);
			NSDateFormatter dateFormat = new NSDateFormatter();
			dateFormat.DateFormat = "MMMM YYYY";
			string monthName = dateFormat.ToString(date);
			monthText.Text = monthName;
			tableView.Hidden = true;
		}

		private void Schedule_DoubleTapped(object sender, CellTappedEventArgs e)
		{

			//base.didSelectDate (schedule, selectedDate, appointments);
			editor.Hidden = false;
			headerView.Hidden = true;
			schedule.Hidden = true;


			indexOfAppointment = -1;
			tableView.Hidden = true;
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
				selectedAppointment = (e.ScheduleAppointment);
				label_subject.Text = selectedAppointment.Subject;
				label_location.Text = selectedAppointment.Location;
				String _sDate = DateTime.Parse((selectedAppointment.StartTime.ToString())).ToString();
				button_startDate.SetTitle(_sDate, UIControlState.Normal);
				picker_startDate.SetDate(selectedAppointment.StartTime, true);
				String _eDate = DateTime.Parse((selectedAppointment.EndTime.ToString())).ToString();
				button_endDate.SetTitle(_eDate, UIControlState.Normal);
				picker_endDate.SetDate(selectedAppointment.EndTime, true);
                allDaySwitch.On = selectedAppointment.IsAllDay;
                if(allDaySwitch.On)
                {
                    this.Disablechild();
                }
                else
                {
                    this.EnableChild();
                }
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
                allDaySwitch.On = false;
                this.EnableChild();

			}
		}

        /// <summary>
        /// Disable time zone picker.
        /// </summary>
        private void Disablechild()
        {
            startTimeZoneButton.UserInteractionEnabled = false;
            startTimeZoneButton.SetTitleColor(UIColor.Gray, UIControlState.Normal);
            endTimeZoneButton.UserInteractionEnabled = false;
            endTimeZoneButton.SetTitleColor(UIColor.Gray, UIControlState.Normal);
        }

        /// <summary>
        /// Enable time zone picker.
        /// </summary>
        private void EnableChild()
        {
            startTimeZoneButton.UserInteractionEnabled = true;
            startTimeZoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            endTimeZoneButton.UserInteractionEnabled = true;
            endTimeZoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
        }

		private void Schedule_AppointmentsFromDate(object sender, AppointmentsFromDateEventArgs e)
		{
			NSCalendar calendar = NSCalendar.CurrentCalendar;
			NSDateComponents components = calendar.Components(NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, e.EndDate);
			components.Hour = 23;
			components.Minute = 59;
			components.Second = 59;
			NSDate rangeEndDateWithTime = calendar.DateFromComponents(components);
			NSPredicate predicate = NSPredicate.FromFormat(@"(startTime <= %@) AND (startTime >= %@)", rangeEndDateWithTime, e.StartDate);

		}

		private void Schedule_AppointmentsForDate(object sender, AppointmentsForDateEventArgs e)
		{
			NSCalendar calendar = NSCalendar.CurrentCalendar;
			NSDateComponents components = calendar.Components(NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, (NSDate)e.Date);
			components.Hour = 23;
			components.Minute = 59;
			components.Second = 59;
			NSDate rangeEndDateWithTime = calendar.DateFromComponents(components);
			NSPredicate predicate = NSPredicate.FromFormat(@"(startTime <= %@) AND (startTime >= %@)", rangeEndDateWithTime, (NSDate)e.Date);

		}
		private void CreateOptionView()
		{
            if(timezoneButton == null)
            {
                timezoneButton = new UIButton();
                timezoneButton.Layer.BorderWidth = 2;
                timezoneButton.Layer.CornerRadius = 4;
                timezoneButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
                timezoneButton.SetTitle("Default", UIControlState.Normal);
                timezoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            }
			
            if (timezoneLabel == null)
            {
                timezoneLabel = new UILabel();
                timezoneLabel.Text = "Time Zone";
                timezoneLabel.TextColor = UIColor.Black;
            }
			 
            if (timeZonePicker == null)
            {
                timeZonePicker = new UIPickerView();
                timeZonePicker.Hidden = true;
            }
            if (doneButton == null)
            {
                doneButton = new UIButton();
                doneButton.Hidden = true;
                doneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
                doneButton.SetTitle("Done\t", UIControlState.Normal);
                doneButton.BackgroundColor = UIColor.LightGray;
                doneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            }

			timezoneButton.TouchUpInside += (object sender, EventArgs e) =>
			{
				timeZonePicker.Hidden = false;
                doneButton.Hidden = false;
			};
            doneButton.TouchUpInside += (object sender, EventArgs e) =>
			{
				timeZonePicker.Hidden = true;
                doneButton.Hidden = true;
			};

			SchedulePickerModel model = new SchedulePickerModel(TimeZoneCollection.TimeZoneList);
			model.PickerChanged += (sender, e) =>
			{
				if (e.SelectedValue != "Default")
				{
					schedule.TimeZone = e.SelectedValue;
				}
				timezoneButton.SetTitle(e.SelectedValue, UIControlState.Normal);
			};

			timeZonePicker.Model = model;
			timeZonePicker.ShowSelectionIndicator = true;

            timezoneLabel.Frame = new CGRect(0, 0, this.Frame.Size.Width, 30);
            timezoneButton.Frame = new CGRect(0, timezoneLabel.Frame.Bottom, this.Frame.Size.Width,  30);
            doneButton.Frame = new CGRect(0, timezoneButton.Frame.Bottom, this.Frame.Size.Width, 30);
            timeZonePicker.Frame = new CGRect(0, doneButton.Frame.Bottom, this.Frame.Size.Width, 200);

            if (Utility.IsIpad)
            {
                timezoneLabel.Frame = new CGRect(0, 0, 320, 30);
                timezoneButton.Frame = new CGRect(0, timezoneLabel.Frame.Bottom, 320, 30);
                doneButton.Frame = new CGRect(0, timezoneButton.Frame.Bottom, 320, 30);
                timeZonePicker.Frame = new CGRect(0, doneButton.Frame.Bottom, 320, 200);
            }
			this.OptionView.AddSubview(timezoneLabel);
			this.OptionView.AddSubview(timezoneButton);
            this.OptionView.AddSubview(doneButton);
			this.OptionView.AddSubview(timeZonePicker);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (schedule != null)
				{
					schedule.AppointmentsForDate -= Schedule_AppointmentsForDate;
					schedule.AppointmentsFromDate -= Schedule_AppointmentsFromDate;
					schedule.CellTapped -= Schedule_CellTapped;
					schedule.CellDoubleTapped -= Schedule_DoubleTapped;
					schedule.VisibleDatesChanged -= Schedule_VisibleDatesChanged;
					schedule.Dispose();
					schedule = null;
				}
				if (moveToDate != null)
				{
					moveToDate.TouchUpInside -= MoveToDate_TouchUpInside;
					moveToDate.Dispose();
					moveToDate = null;
				}
				if (headerButton != null)
				{
					headerButton.TouchUpInside -= HeaderButton_TouchUpInside;
					headerButton.Dispose();
					headerButton = null;
				}
				if (editorView != null)
				{
					editorView.TouchUpInside -= EditorView_TouchUpInside;
					editorView.Dispose();
					editorView = null;
				}
				if (subjectCollection != null)
				{
					subjectCollection.Clear();
					subjectCollection = null;
				}
				if (minTimeSubjectCollection != null)
				{
					minTimeSubjectCollection.Clear();
					minTimeSubjectCollection = null;
				}
			}
			base.Dispose(disposing);
		}



		private void EditorView_TouchUpInside(object sender, EventArgs e)
		{
			editor.Hidden = false;
			schedule.Hidden = true;
			headerView.Hidden = true;
			tableView.Hidden = true;

			NSDate today = new NSDate();
			NSCalendar calendar = NSCalendar.CurrentCalendar;
			// Get the year, month, day from the date
			NSDateComponents components = calendar.Components(
				NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
			NSDate startDate = calendar.DateFromComponents(components);

			label_subject.Text = "Subject";
			label_location.Text = "Location";
			String _sDate = DateTime.Parse((startDate.ToString())).ToString();
			picker_startDate.SetDate(startDate, true);
			button_startDate.SetTitle(_sDate, UIControlState.Normal);
			String _eDate = DateTime.Parse((startDate.AddSeconds(3600).ToString())).ToString();
			picker_endDate.SetDate(startDate.AddSeconds(3600), true);
			button_endDate.SetTitle(_eDate, UIControlState.Normal);

		}
		private void MoveToDate_TouchUpInside(object sender, EventArgs e)
		{
			tableView.Hidden = true;
			NSDate today = new NSDate();
			NSCalendar calendar = NSCalendar.CurrentCalendar;
			// Get the year, month, day from the date
			NSDateComponents components = calendar.Components(
				NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
			NSDate startDate = calendar.DateFromComponents(components);

			schedule.MoveToDate(startDate);
		}
		private void HeaderButton_TouchUpInside(object sender, EventArgs e)
		{
			tableView.Hidden = false;
		}

		public override void LayoutSubviews()
		{
			foreach (var view in this.Subviews)
			{
				view.Frame = new CGRect(Frame.X, 0, Frame.Width, Frame.Height);
			}
			CreateOptionView();
            var childHeight = 30;
            if(Utility.IsIpad)
            {
                childHeight = 40;
            }
            var padding = 20;
            editor.Frame = new CGRect(0, 0, this.Frame.Size.Width, this.Frame.Size.Height);
            scrollView.Frame = new CGRect(editor.Frame.X + 10, editor.Frame.Y + 10, editor.Frame.Size.Width - 10, editor.Frame.Size.Height);

            label_subject.Frame = new CGRect(scrollView.Frame.X, scrollView.Frame.Y, scrollView.Frame.Size.Width - padding, childHeight);
            label_location.Frame = new CGRect(scrollView.Frame.X, label_subject.Frame.Bottom + 10, scrollView.Frame.Size.Width - padding, childHeight);
            label_starts.Frame = new CGRect(scrollView.Frame.X, label_location.Frame.Bottom, scrollView.Frame.Size.Width-padding, childHeight);
            button_startDate.Frame = new CGRect(scrollView.Frame.X, label_starts.Frame.Bottom, scrollView.Frame.Size.Width-padding, childHeight);
            startTimeZoneLabel.Frame = new CGRect(scrollView.Frame.X, button_startDate.Frame.Bottom, scrollView.Frame.Size.Width-padding, childHeight);
            startTimeZoneButton.Frame = new CGRect(scrollView.Frame.X, startTimeZoneLabel.Frame.Bottom, scrollView.Frame.Size.Width-padding, childHeight);
            label_ends.Frame = new CGRect(scrollView.Frame.X, startTimeZoneButton.Frame.Bottom, scrollView.Frame.Size.Width-padding, childHeight);
            button_endDate.Frame = new CGRect(scrollView.Frame.X, label_ends.Frame.Bottom, scrollView.Frame.Size.Width - padding, childHeight);
            endTimeZoneLabel.Frame = new CGRect(scrollView.Frame.X, button_endDate.Frame.Bottom, scrollView.Frame.Size.Width - padding, childHeight);
            endTimeZoneButton.Frame = new CGRect(scrollView.Frame.X, endTimeZoneLabel.Frame.Bottom, scrollView.Frame.Size.Width - padding, childHeight);
            allDaylabel.Frame = new CGRect(scrollView.Frame.X, endTimeZoneButton.Frame.Bottom + 10, scrollView.Frame.Size.Width / 2 - padding, childHeight);
            allDaySwitch.Frame = new CGRect(allDaylabel.Frame.Right, endTimeZoneButton.Frame.Bottom + 10, scrollView.Frame.Size.Width / 2 - padding, childHeight);
            button_cancel.Frame = new CGRect(scrollView.Frame.X, allDaySwitch.Frame.Bottom + 10, scrollView.Frame.Size.Width / 2 - padding, childHeight);
            button_save.Frame = new CGRect(button_cancel.Frame.Right + 10, allDaySwitch.Frame.Bottom + 10, scrollView.Frame.Size.Width / 2 - padding, childHeight);

            picker_startDate.Frame = new CGRect(scrollView.Frame.X, button_endDate.Frame.Bottom, scrollView.Frame.Size.Width-padding, 200);
            picker_endDate.Frame = new CGRect(scrollView.Frame.X, button_endDate.Frame.Bottom, scrollView.Frame.Size.Width-padding, 200);
            startTimeZonePicker.Frame = new CGRect(scrollView.Frame.X, button_endDate.Frame.Bottom, scrollView.Frame.Size.Width-padding, 200);
            endTimeZonePicker.Frame = new CGRect(scrollView.Frame.X, button_endDate.Frame.Bottom, scrollView.Frame.Size.Width-padding, 200);
            done_button.Frame = new CGRect(scrollView.Frame.X, button_endDate.Frame.Bottom, scrollView.Frame.Size.Width - padding, childHeight);
            scrollView.ContentSize = new CGSize(scrollView.Frame.Size.Width - padding, button_cancel.Frame.Bottom);

			UIImageView image1 = new UIImageView();
			UIImageView image2 = new UIImageView();
			UIImageView image3 = new UIImageView();

			moveToDate = new UIButton();
			editorView = new UIButton();
			monthText = new UILabel();

			headerView = new UIView();
			headerView.BackgroundColor = UIColor.FromRGB(214, 214, 214);

			NSDate today = new NSDate();
			NSCalendar calendar = NSCalendar.CurrentCalendar;
			// Get the year, month, day from the date
			NSDateComponents components = calendar.Components(
				NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
			NSDate startDate = calendar.DateFromComponents(components);
			NSDateFormatter dateFormat = new NSDateFormatter();
			dateFormat.DateFormat = "MMMM YYYY";
			string monthName = dateFormat.ToString(startDate);
			monthText.Text = monthName;
			monthText.TextColor = UIColor.Black;
			monthText.TextAlignment = UITextAlignment.Left;
			moveToDate.AddSubview(image2);
			headerButton.AddSubview(image1);
			editorView.AddSubview(image3);


			string[] tableItems = new string[] { "Day", "Week", "WorkWeek", "Month" };
			tableView = new UITableView();
			tableView.Frame = new CGRect(0, 0, this.Frame.Size.Width / 2, 60.0f * 4);
			tableView.Hidden = true;
			tableView.Source = new ScheduleTableSource(tableItems);

			string deviceType = UIDevice.CurrentDevice.Model;
			if (deviceType == "iPhone" || deviceType == "iPod touch")
			{
				image1.Frame = new CGRect(0, 0, 60, 60);
				image1.Image = UIImage.FromFile("black-09.png");
				image2.Frame = new CGRect(0, 0, 60, 60);
				image2.Image = UIImage.FromFile("black-11.png");
				image3.Frame = new CGRect(0, 0, 60, 60);
				image3.Image = UIImage.FromFile("black-10.png");

				headerView.Frame = new CGRect(0, 0, this.Frame.Size.Width, 50);
				moveToDate.Frame = new CGRect((this.Frame.Size.Width / 6) + (this.Frame.Size.Width / 2), -10, this.Frame.Size.Width / 8, 50);
				editorView.Frame = new CGRect((this.Frame.Size.Width / 6) + (this.Frame.Size.Width / 6) + (this.Frame.Size.Width / 2), -10, this.Frame.Size.Width / 8, 50);
				headerButton.Frame = new CGRect(-10, -10, this.Frame.Size.Width / 8, 50);
				monthText.Frame = new CGRect(this.Frame.Size.Width / 8, -10, this.Frame.Size.Width / 2, 60);
				schedule.Frame = new CGRect(0, 50, this.Frame.Size.Width, this.Frame.Size.Height - 50);
			}
			else
			{
				schedule.DayViewSettings.WorkStartHour = 7;
				schedule.DayViewSettings.WorkEndHour = 18;

				schedule.WeekViewSettings.WorkStartHour = 7;
				schedule.WeekViewSettings.WorkEndHour = 18;

				schedule.WorkWeekViewSettings.WorkStartHour = 7;
				schedule.WorkWeekViewSettings.WorkEndHour = 18;

				image1.Frame = new CGRect(0, 0, 80, 80);
				image1.Image = UIImage.FromFile("black-09.png");
				image2.Frame = new CGRect(0, 0, 80, 80);
				image2.Image = UIImage.FromFile("black-11.png");
				image3.Frame = new CGRect(0, 0, 80, 80);
				image3.Image = UIImage.FromFile("black-10.png");

				headerView.Frame = new CGRect(0, 0, this.Frame.Size.Width, 60);
				moveToDate.Frame = new CGRect((this.Frame.Size.Width / 5) + (this.Frame.Size.Width / 2) + (this.Frame.Size.Width / 8), -10, this.Frame.Size.Width / 8, 50);
				editorView.Frame = new CGRect((this.Frame.Size.Width / 5) + (this.Frame.Size.Width / 5) + (this.Frame.Size.Width / 2), -10, this.Frame.Size.Width / 8, 50);
				headerButton.Frame = new CGRect(0, -10, this.Frame.Size.Width / 8, 50);
				monthText.Frame = new CGRect(this.Frame.Size.Width / 8, 5, this.Frame.Size.Width / 2, 50);
				schedule.Frame = new CGRect(0, 60, this.Frame.Size.Width, this.Frame.Size.Height - 60);
			}

			moveToDate.TouchUpInside += MoveToDate_TouchUpInside;
			headerButton.TouchUpInside += HeaderButton_TouchUpInside;
			editorView.TouchUpInside += EditorView_TouchUpInside;

			headerView.AddSubview(moveToDate);
			headerView.AddSubview(editorView);
			headerView.AddSubview(monthText);
			headerView.AddSubview(headerButton);
			this.AddSubview(schedule);
			this.AddSubview(headerView);
			this.AddSubview(editor);
			this.AddSubview(tableView);
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
			startTimeZoneLabel = new UILabel();
			endTimeZoneLabel = new UILabel();
			startTimeZoneButton = new UIButton();
			endTimeZoneButton = new UIButton();
			picker_startDate = new UIDatePicker();
			picker_endDate = new UIDatePicker();
			done_button = new UIButton();
			scrollView = new UIScrollView();
            startTimeZonePicker = new UIPickerView();
            endTimeZonePicker = new UIPickerView();
            allDaySwitch = new UISwitch();
            allDaylabel = new UILabel();

            scrollView.BackgroundColor = UIColor.White;

            label_subject.Font = UIFont.SystemFontOfSize(14);
            label_location.Font = UIFont.SystemFontOfSize(14);
            label_starts.Font = UIFont.SystemFontOfSize(15);
            label_ends.Font = UIFont.SystemFontOfSize(15);
            startTimeZoneLabel.Font = UIFont.SystemFontOfSize(15);
            endTimeZoneLabel.Font = UIFont.SystemFontOfSize(15);
            allDaylabel.Font = UIFont.SystemFontOfSize(15);
            startTimeZoneButton.Font = UIFont.SystemFontOfSize(15);
            endTimeZoneButton.Font = UIFont.SystemFontOfSize(15);
            button_startDate.Font = UIFont.SystemFontOfSize(15);
            button_endDate.Font = UIFont.SystemFontOfSize(15);

			button_cancel.BackgroundColor = UIColor.FromRGB(229, 229, 229);
			button_cancel.Font = UIFont.SystemFontOfSize(15);
			button_save.Font = UIFont.SystemFontOfSize(15);
			button_save.BackgroundColor = UIColor.FromRGB(33, 150, 243);
			button_cancel.Layer.CornerRadius = 6;
			button_save.Layer.CornerRadius = 6;
			button_startDate.Layer.CornerRadius = 6;
			button_endDate.Layer.CornerRadius = 6;

           
            startTimeZoneLabel.Text = "Start Time Zone";
            startTimeZoneLabel.TextColor = UIColor.Black;

            endTimeZoneLabel.Text = "End Time Zone";
            endTimeZoneLabel.TextColor = UIColor.Black;

            allDaylabel.Text = "All Day";
            allDaylabel.TextColor = UIColor.Black;

            allDaySwitch.On = false;
            allDaySwitch.OnTintColor = UIColor.FromRGB(33, 150, 243);
            allDaySwitch.ValueChanged+= AllDaySwitch_ValueChanged;

            startTimeZoneButton.SetTitle("Default", UIControlState.Normal);
            startTimeZoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            startTimeZoneButton.Layer.BorderWidth = 2;
            startTimeZoneButton.Layer.CornerRadius = 4;
            startTimeZoneButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
            startTimeZoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            startTimeZoneButton.TouchUpInside += (object sender, EventArgs e) =>
            {

                startTimeZonePicker.Hidden = false;
                done_button.Hidden = false;

                allDaylabel.Hidden = true;
                allDaySwitch.Hidden = true;
                button_cancel.Hidden = true;
                button_save.Hidden = true;
                endTimeZoneLabel.Hidden = true;
                endTimeZoneButton.Hidden = true;
                editor.EndEditing(true);

            };

            endTimeZoneButton.SetTitle("Default", UIControlState.Normal);
            endTimeZoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            endTimeZoneButton.Layer.BorderWidth = 2;
            endTimeZoneButton.Layer.CornerRadius = 4;
            endTimeZoneButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
            endTimeZoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            endTimeZoneButton.TouchUpInside += (object sender, EventArgs e) =>
            {

                endTimeZonePicker.Hidden = false;
                done_button.Hidden = false;
                allDaylabel.Hidden = true;
                allDaySwitch.Hidden = true;
                button_cancel.Hidden = true;
                button_save.Hidden = true;
                endTimeZoneLabel.Hidden = true;
                endTimeZoneButton.Hidden = true;
                editor.EndEditing(true);
            };


			//cancel button
			button_cancel.SetTitle("Cancel", UIControlState.Normal);
			button_cancel.SetTitleColor(UIColor.FromRGB(59, 59, 59), UIControlState.Normal);// UIColor.FromRGB(59, 59, 59);
			button_cancel.TouchUpInside += (object sender, EventArgs e) =>
			{

				editor.Hidden = true;
				schedule.Hidden = false;
				editor.EndEditing(true);
				headerView.Hidden = false;

			};

			//save button
			button_save.SetTitle("Save", UIControlState.Normal);
			button_save.SetTitleColor(UIColor.White, UIControlState.Normal);
			button_save.TouchUpInside += (object sender, EventArgs e) =>
			{
				headerView.Hidden = false;
				if (indexOfAppointment != -1)
				{
					(schedule.ItemsSource as ObservableCollection<ScheduleAppointment>)[int.Parse(indexOfAppointment.ToString())].Subject = (NSString)label_subject.Text;
					(schedule.ItemsSource as ObservableCollection<ScheduleAppointment>)[int.Parse(indexOfAppointment.ToString())].Location = (NSString)label_location.Text;
					(schedule.ItemsSource as ObservableCollection<ScheduleAppointment>)[int.Parse(indexOfAppointment.ToString())].StartTime = picker_startDate.Date;
					(schedule.ItemsSource as ObservableCollection<ScheduleAppointment>)[int.Parse(indexOfAppointment.ToString())].EndTime = picker_endDate.Date;
                    (schedule.ItemsSource as ObservableCollection<ScheduleAppointment>)[int.Parse(indexOfAppointment.ToString())].IsAllDay = allDaySwitch.On;
				}
				else
				{
					ScheduleAppointment appointment = new ScheduleAppointment();
					appointment.Subject = (NSString)label_subject.Text;
					appointment.Location = (NSString)label_location.Text;
					appointment.StartTime = picker_startDate.Date;
					appointment.EndTime = picker_endDate.Date;
					appointment.AppointmentBackground = UIColor.FromRGB(0xA2, 0xC1, 0x39);
                    appointment.IsAllDay = allDaySwitch.On;
					(schedule.ItemsSource as ObservableCollection<ScheduleAppointment>).Add(appointment);
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

			label_starts.Text = "Start Time";
			label_starts.TextColor = UIColor.Black;

			button_startDate.SetTitle("Start time", UIControlState.Normal);
            button_startDate.Layer.BorderWidth = 2;
            button_startDate.Layer.CornerRadius = 4;
            button_startDate.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
            button_startDate.SetTitleColor(UIColor.Black, UIControlState.Normal);
			button_startDate.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			button_startDate.TouchUpInside += (object sender, EventArgs e) =>
			{
				picker_startDate.Hidden = false;
				done_button.Hidden = false;

                allDaylabel.Hidden = true;
                allDaySwitch.Hidden = true;
                button_cancel.Hidden = true;
                button_save.Hidden = true;
                endTimeZoneLabel.Hidden = true;
                endTimeZoneButton.Hidden = true;
				editor.EndEditing(true);
			};

			//end time

			label_ends.Text = "End Time";
			label_ends.TextColor = UIColor.Black;


			//end date
			button_endDate.SetTitle("End time", UIControlState.Normal);
            button_endDate.SetTitleColor(UIColor.Black, UIControlState.Normal);
            button_endDate.Layer.BorderWidth = 2;
            button_endDate.Layer.CornerRadius = 4;
            button_endDate.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
			button_endDate.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			button_endDate.TouchUpInside += (object sender, EventArgs e) =>
			{
				picker_endDate.Hidden = false;
				done_button.Hidden = false;
                allDaylabel.Hidden = true;
                allDaySwitch.Hidden = true;
                button_cancel.Hidden = true;
                button_save.Hidden = true;
                endTimeZoneLabel.Hidden = true;
                endTimeZoneButton.Hidden = true;
			
				editor.EndEditing(true);
			};

			//date and time pickers
			picker_startDate.Hidden = true;
			picker_endDate.Hidden = true;
            startTimeZonePicker.Hidden = true;
            endTimeZonePicker.Hidden = true;
			done_button.Hidden = true;

			//done button
			done_button.SetTitle("Done", UIControlState.Normal);
			done_button.SetTitleColor(UIColor.Blue, UIControlState.Normal);
			done_button.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			done_button.TouchUpInside += (object sender, EventArgs e) =>
			{
				picker_startDate.Hidden = true;
				picker_endDate.Hidden = true;
                startTimeZonePicker.Hidden = true;
                endTimeZonePicker.Hidden = true;
				done_button.Hidden = true;

				label_ends.Hidden = false;
				button_endDate.Hidden = false;
				button_startDate.Hidden = false;
				label_starts.Hidden = false;
                endTimeZoneLabel.Hidden = false;
                startTimeZoneLabel.Hidden = false;
                allDaylabel.Hidden = false;
                allDaySwitch.Hidden = false;
                startTimeZoneButton.Hidden = false;
                endTimeZoneButton.Hidden = false;
                button_cancel.Hidden = false;
                button_save.Hidden = false;

				String _sDate = DateTime.Parse((picker_startDate.Date.ToString())).ToString();
				button_startDate.SetTitle(_sDate, UIControlState.Normal);

				String _eDate = DateTime.Parse((picker_endDate.Date.ToString())).ToString();
				button_endDate.SetTitle(_eDate, UIControlState.Normal);
				editor.EndEditing(true);

			};

			SchedulePickerModel model = new SchedulePickerModel(TimeZoneCollection.TimeZoneList);
			model.PickerChanged += (sender, e) =>
			{
                if(e.SelectedValue!="Default" && selectedAppointment!=null)
                    selectedAppointment.StartTimeZone = e.SelectedValue;
                startTimeZoneButton.SetTitle(e.SelectedValue, UIControlState.Normal);
			};

            SchedulePickerModel model2 = new SchedulePickerModel(TimeZoneCollection.TimeZoneList);
            model2.PickerChanged += (sender, e) =>
            {
                if (e.SelectedValue != "Default" && selectedAppointment != null)
                    selectedAppointment.EndTimeZone = e.SelectedValue;
                endTimeZoneButton.SetTitle(e.SelectedValue, UIControlState.Normal);
            };

			startTimeZonePicker.Model = model;
            endTimeZonePicker.Model = model2;
			startTimeZonePicker.ShowSelectionIndicator = true;
			endTimeZonePicker.ShowSelectionIndicator = true;

			scrollView.Add(label_subject);
			scrollView.Add(label_location);
			scrollView.Add(label_starts);
			scrollView.Add(button_startDate);
			scrollView.Add(startTimeZoneLabel);
			scrollView.Add(startTimeZoneButton);
			scrollView.Add(label_ends);
			scrollView.Add(button_endDate);
			scrollView.Add(endTimeZoneLabel);
			scrollView.Add(endTimeZoneButton);
			scrollView.Add(startTimeZonePicker);
			scrollView.Add(endTimeZonePicker);
			scrollView.Add(picker_endDate);
			scrollView.Add(picker_startDate);
			scrollView.Add(done_button);
            scrollView.Add(allDaylabel);
            scrollView.Add(allDaySwitch);
            scrollView.Add(button_cancel);
            scrollView.Add(button_save);

			editor.Add(scrollView);
		}

        private void AllDaySwitch_ValueChanged(object sender, EventArgs e)
        {
            if((sender as UISwitch).On)
            {
                this.Disablechild();
            }
            else
            {
                this.EnableChild();
            }

            if(selectedAppointment!=null)
            {
                selectedAppointment.IsAllDay = (sender as UISwitch).On;
            }
        }

        private ObservableCollection<ScheduleAppointment> CreateAppointments()
		{
			NSDate today = new NSDate();
			setColors();
			setSubjects();
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
				if (i == 2 || i == 4)
				{
					appointment.IsAllDay = true;
				}

				appCollection.Add(appointment);
			}

			NSDateComponents startDateComponents = calendar.Components(
			   NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
			startDateComponents.Minute = 0;
			startDateComponents.Second = 0;

			// Minimum Height Appointments
			for (int i = 0; i < 5; i++)
			{
				startDateComponents.Hour = randomNumber.Next(9, 18);
				NSDate startDate = calendar.DateFromComponents(startDateComponents);
				ScheduleAppointment appointment = new ScheduleAppointment();
				appointment.StartTime = startDate;
				appointment.EndTime = startDate;
				startDateComponents.Day = startDateComponents.Day + 1;
				appointment.Subject = (NSString)minTimeSubjectCollection[i];
				appointment.AppointmentBackground = colorCollection[randomNumber.Next(0, 14)];
				// Setting Mininmum Appointment Height for Schedule Appointments
				appointment.MinHeight = 25;
				appCollection.Add(appointment);
			}

			return appCollection;
		}

		private List<String> subjectCollection;
		private List<String> minTimeSubjectCollection;

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

			// MinimumHeight Appointment Subjects
			minTimeSubjectCollection = new List<string>();
			minTimeSubjectCollection.Add("Work log alert");
			minTimeSubjectCollection.Add("Birthday wish alert");
			minTimeSubjectCollection.Add("Task due date");
			minTimeSubjectCollection.Add("Status mail");
			minTimeSubjectCollection.Add("Start sprint alert");
		}

		// adding colors collection
		private List<UIColor> colorCollection;
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

	public static class TimeZoneCollection
	{
		public static IList<string> TimeZoneList = new List<string>() {
				"Default",
				"AUS Central Standard Time",
				"AUS Eastern Standard Time",
				"Afghanistan Standard Time",
				"Alaskan Standard Time",
				"Arab Standard Time",
				"Arabian Standard Time",
				"Arabic Standard Time",
				"Argentina Standard Time",
				"Atlantic Standard Time",
				"Azerbaijan Standard Time",
				"Azores Standard Time",
				"Bahia Standard Time",
				"Bangladesh Standard Time",
				"Belarus Standard Time",
				"Canada Central Standard Time",
				"Cape Verde Standard Time",
				"Caucasus Standard Time",
				"Cen. Australia Standard Time",
				"Central America Standard Time",
				"Central Asia Standard Time",
				"Central Brazilian Standard Time",
				"Central Europe Standard Time",
				"Central European Standard Time",
				"Central Pacific Standard Time",
				"Central Standard Time",
				"China Standard Time",
				"Dateline Standard Time",
				"E. Africa Standard Time",
				"E. Australia Standard Time",
				"E. South America Standard Time",
				"Eastern Standard Time",
				"Egypt Standard Time",
				"Ekaterinburg Standard Time",
				"FLE Standard Time",
				"Fiji Standard Time",
				"GMT Standard Time",
				"GTB Standard Time",
				"Georgian Standard Time",
				"Greenland Standard Time",
				"Greenwich Standard Time",
				"Hawaiian Standard Time",
				"India Standard Time",
				"Iran Standard Time",
				"Israel Standard Time",
				"Jordan Standard Time",
				"Kaliningrad Standard Time",
				"Korea Standard Time",
				"Libya Standard Time",
				"Line Islands Standard Time",
				"Magadan Standard Time",
				"Mauritius Standard Time",
				"Middle East Standard Time",
				"Montevideo Standard Time",
				"Morocco Standard Time",
				"Mountain Standard Time",
				"Mountain Standard Time (Mexico)",
				"Myanmar Standard Time",
				"N. Central Asia Standard Time",
				"Namibia Standard Time",
				"Nepal Standard Time",
				"New Zealand Standard Time",
				"Newfoundland Standard Time",
				"North Asia East Standard Time",
				"North Asia Standard Time",
				"Pacific SA Standard Time",
				"Pacific Standard Time",
				"Pacific Standard Time (Mexico)",
				"Pakistan Standard Time",
				"Paraguay Standard Time",
				"Romance Standard Time",
				"Russia Time Zone 10",
				"Russia Time Zone 11",
				"Russia Time Zone 3",
				"Russian Standard Time",
				"SA Eastern Standard Time",
				"SA Pacific Standard Time",
				"SA Western Standard Time",
				"SE Asia Standard Time",
				"Samoa Standard Time",
				"Singapore Standard Time",
				"South Africa Standard Time",
				"Sri Lanka Standard Time",
				"Syria Standard Time",
				"Taipei Standard Time",
				"Tasmania Standard Time",
				"Tokyo Standard Time",
				"Tonga Standard Time",
				"Turkey Standard Time",
				"US Eastern Standard Time",
				"US Mountain Standard Time",
				"UTC",
				"UTC+12",
				"UTC-02",
				"UTC-11",
				"Ulaanbaatar Standard Time",
				"Venezuela Standard Time",
				"Vladivostok Standard Time",
				"W. Australia Standard Time",
				"W. Central Africa Standard Time",
				"W. Europe Standard Time",
				"West Asia Standard Time",
				"West Pacific Standard Time",
				 "Yakutsk Standard Time"};

	}

	public class SchedulePickerModel : UIPickerViewModel
	{
		private readonly IList<string> values;

		public event EventHandler<SchedulePickerChangedEventArgs> PickerChanged;

		public SchedulePickerModel(IList<string> values)
		{
			this.values = values;
		}
#if __UNIFIED__
		public override nint GetComponentCount(UIPickerView picker)
		{
			return 1;
		}

		public override nint GetRowsInComponent(UIPickerView picker, nint component)
		{
			return values.Count;
		}

		public override string GetTitle(UIPickerView picker, nint row, nint component)
		{
			return values[(int)row];
		}

		public override nfloat GetRowHeight(UIPickerView picker, nint component)
		{
			return 30f;
		}
       
		public override void Selected(UIPickerView picker, nint row, nint component)
		{
			if (this.PickerChanged != null)
			{
				this.PickerChanged(this, new SchedulePickerChangedEventArgs { SelectedValue = values[(int)row] });
			}
		}
#else
		public override int GetComponentCount(UIPickerView picker)
		{
			return 1;
		}

		public override int GetRowsInComponent(UIPickerView picker, int component)
		{
			return values.Count;
		}

		public override string GetTitle(UIPickerView picker, int row, int component)
		{
			return values[(int)row];
		}

		public override nfloat GetRowHeight(UIPickerView picker, int component)
		{
			return 30f;
		}

		public override void Selected(UIPickerView picker, int row, int component)
		{
			if (this.PickerChanged != null)
			{
				this.PickerChanged(this, new SchedulePickerChangedEventArgs { SelectedValue = values[(int)row] });
			}
		}
#endif
	}

	public class SchedulePickerChangedEventArgs : EventArgs
	{
		public string SelectedValue { get; set; }
	}
	public class ScheduleTableSource : UITableViewSource
	{
		string[] TableItems;
		string CellIdentifier = "TableCell";
		public ScheduleTableSource(string[] items)
		{
			TableItems = items;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			int i = TableItems.Length;
			return (nint)i;
		}
		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{

			switch (indexPath.Row)
			{
				case 0:
					ScheduleViews.schedule.ScheduleView = SFScheduleView.SFScheduleViewDay;
					ScheduleViews.tableView.Hidden = true;
					break;
				case 1:
					ScheduleViews.schedule.ScheduleView = SFScheduleView.SFScheduleViewWeek;
					ScheduleViews.tableView.Hidden = true;
					break;
				case 2:
					ScheduleViews.schedule.ScheduleView = SFScheduleView.SFScheduleViewWorkWeek;
					ScheduleViews.tableView.Hidden = true;
					break;
				case 3:
					ScheduleViews.schedule.ScheduleView = SFScheduleView.SFScheduleViewMonth;
					ScheduleViews.tableView.Hidden = true;
					break;

			}
		}
		public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return 60.0f;

		}


		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);

			string item = TableItems[indexPath.Row];
			if (cell == null)
			{ cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }
			cell.TextLabel.Text = item;
			return cell;
		}
	}
}
