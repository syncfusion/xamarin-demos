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
using Foundation;
using UIKit;
using CoreGraphics;

namespace SampleBrowser
{
	public class ScheduleViews : SampleView
	{
		public static SFSchedule schedule;
		
		internal ScheduleAppointment selectedAppointment;
        internal int indexOfAppointment;
        internal UIView headerView = new UIView();

        private UIButton headerButton = new UIButton();
		private UIButton moveToDate = new UIButton();
		private static UILabel monthText = new UILabel();
		private UIButton editorView = new UIButton();
        private ScheduleViewModel viewModel = new ScheduleViewModel();
		public static UITableView tableView = new UITableView();
        public ScheduleEditor scheduleEditor;

		public ScheduleViews()
		{
			schedule = new SFSchedule();
            scheduleEditor = new ScheduleEditor(schedule, this);
            schedule.AppointmentsForDate += Schedule_AppointmentsForDate;
			schedule.AppointmentsFromDate += Schedule_AppointmentsFromDate;
			schedule.CellTapped += Schedule_CellTapped;
			schedule.CellDoubleTapped += Schedule_DoubleTapped;
			schedule.VisibleDatesChanged += Schedule_VisibleDatesChanged;
			schedule.ScheduleView = SFScheduleView.SFScheduleViewWeek;
			schedule.ItemsSource = viewModel.CreateAppointments();
            scheduleEditor.CreateEditor();
			this.OptionView = new UIView();
			schedule.HeaderHeight = 0;
			schedule.ViewHeaderHeight = 50;
			schedule.Hidden = false;
            scheduleEditor.Editor.Hidden = true;
		}

		private void Schedule_CellTapped(object sender, CellTappedEventArgs e)
		{
			if (schedule.ScheduleView == SFScheduleView.SFScheduleViewMonth)
			{
				schedule.ScheduleView = SFScheduleView.SFScheduleViewDay;
				schedule.MoveToDate(e.Date);
				schedule.Hidden = false;
                scheduleEditor.Editor.Hidden = true;
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
            scheduleEditor.Editor.Hidden = false;
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
                scheduleEditor.label_subject.Text = selectedAppointment.Subject;
                scheduleEditor.label_location.Text = selectedAppointment.Location;
				String _sDate = DateTime.Parse((selectedAppointment.StartTime.ToString())).ToString();
                scheduleEditor.button_startDate.SetTitle(_sDate, UIControlState.Normal);
                scheduleEditor.picker_startDate.SetDate(selectedAppointment.StartTime, true);
				String _eDate = DateTime.Parse((selectedAppointment.EndTime.ToString())).ToString();
                scheduleEditor.button_endDate.SetTitle(_eDate, UIControlState.Normal);
                scheduleEditor.picker_endDate.SetDate(selectedAppointment.EndTime, true);
                scheduleEditor.allDaySwitch.On = selectedAppointment.IsAllDay;
                if(scheduleEditor.allDaySwitch.On)
                {
                    scheduleEditor.Disablechild();
                }
                else
                {
                    scheduleEditor.EnableChild();
                }
                scheduleEditor.Editor.EndEditing(true);
			}
			else
			{
				List<UIColor> colorCollection = new List<UIColor>();
				colorCollection.Add(UIColor.FromRGB(0xA2, 0xC1, 0x39));
				colorCollection.Add(UIColor.FromRGB(0xD8, 0x00, 0x73));
                scheduleEditor.label_subject.Text = "Subject";
                scheduleEditor.label_location.Text = "Location";
				String _sDate = DateTime.Parse((e.Date.ToString())).ToString();
                scheduleEditor.picker_startDate.SetDate(e.Date, true);
                scheduleEditor.button_startDate.SetTitle(_sDate, UIControlState.Normal);
				String _eDate = DateTime.Parse((e.Date.AddSeconds(3600).ToString())).ToString();
                scheduleEditor.picker_endDate.SetDate(e.Date.AddSeconds(3600), true);
                scheduleEditor.button_endDate.SetTitle(_eDate, UIControlState.Normal);
                scheduleEditor.allDaySwitch.On = false;
                this.scheduleEditor.EnableChild();

			}
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
            scheduleEditor.CreateOptionWindow();
            scheduleEditor.timezoneLabel.Frame = new CGRect(0, 0, this.Frame.Size.Width, 30);
            scheduleEditor.timezoneButton.Frame = new CGRect(0, scheduleEditor.timezoneLabel.Frame.Bottom, this.Frame.Size.Width, 30);
            scheduleEditor.doneButton.Frame = new CGRect(0, scheduleEditor.timezoneButton.Frame.Bottom, this.Frame.Size.Width, 30);
            scheduleEditor.timeZonePicker.Frame = new CGRect(0, scheduleEditor.doneButton.Frame.Bottom, this.Frame.Size.Width, 200);

			this.OptionView.AddSubview(scheduleEditor.timezoneLabel);
			this.OptionView.AddSubview(scheduleEditor.timezoneButton);
            this.OptionView.AddSubview(scheduleEditor.doneButton);
			this.OptionView.AddSubview(scheduleEditor.timeZonePicker);
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
			}
			base.Dispose(disposing);
		}

		private void EditorView_TouchUpInside(object sender, EventArgs e)
		{
            scheduleEditor.Editor.Hidden = false;
			schedule.Hidden = true;
			headerView.Hidden = true;
			tableView.Hidden = true;

			NSDate today = new NSDate();
			NSCalendar calendar = NSCalendar.CurrentCalendar;
			// Get the year, month, day from the date
			NSDateComponents components = calendar.Components(
				NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
			NSDate startDate = calendar.DateFromComponents(components);

            scheduleEditor.label_subject.Text = "Subject";
            scheduleEditor.label_location.Text = "Location";
			String _sDate = DateTime.Parse((startDate.ToString())).ToString();
            scheduleEditor.picker_startDate.SetDate(startDate, true);
            scheduleEditor.button_startDate.SetTitle(_sDate, UIControlState.Normal);
			String _eDate = DateTime.Parse((startDate.AddSeconds(3600).ToString())).ToString();
            scheduleEditor.picker_endDate.SetDate(startDate.AddSeconds(3600), true);
            scheduleEditor.button_endDate.SetTitle(_eDate, UIControlState.Normal);

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
            scheduleEditor.Editor.Frame = new CGRect(0, 0, this.Frame.Size.Width, this.Frame.Size.Height);
            scheduleEditor.scrollView.Frame = new CGRect(scheduleEditor.Editor.Frame.X + 10, scheduleEditor.Editor.Frame.Y + 10, scheduleEditor.Editor.Frame.Size.Width - 10, scheduleEditor.Editor.Frame.Size.Height);

            scheduleEditor.EditorFrameUpdate();

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
			this.AddSubview(scheduleEditor.Editor);
			this.AddSubview(tableView);
			base.LayoutSubviews();
		}
	}
}
