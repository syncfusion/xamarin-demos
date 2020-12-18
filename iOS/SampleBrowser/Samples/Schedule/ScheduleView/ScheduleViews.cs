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
		public static SFSchedule Schedule { get; set; }
      
        private UIButton headerButton = new UIButton();
		private UIButton moveToDate = new UIButton();
		private static UILabel monthText = new UILabel();
		private UIButton editorView = new UIButton();
        private ScheduleViewModel viewModel = new ScheduleViewModel();

        public static UITableView TableView { get; set; } = new UITableView();

        public ScheduleEditor ScheduleEditor { get; set; }

		public ScheduleViews()
		{
			Schedule = new SFSchedule();
            ScheduleEditor = new ScheduleEditor(Schedule, this);
            Schedule.AppointmentsForDate += Schedule_AppointmentsForDate;
			Schedule.AppointmentsFromDate += Schedule_AppointmentsFromDate;
			Schedule.CellTapped += Schedule_CellTapped;
			Schedule.CellDoubleTapped += Schedule_DoubleTapped;
			Schedule.VisibleDatesChanged += Schedule_VisibleDatesChanged;
			Schedule.ScheduleView = SFScheduleView.SFScheduleViewWeek;
			Schedule.ItemsSource = viewModel.CreateAppointments();
            ScheduleEditor.CreateEditor();
			this.OptionView = new UIView();
			Schedule.HeaderHeight = 0;
			Schedule.ViewHeaderHeight = 50;
			Schedule.Hidden = false;
            ScheduleEditor.Editor.Hidden = true;
		}

        internal UIView HeaderView { get; set; } = new UIView();

        internal ScheduleAppointment SelectedAppointment { get; set; }

        internal int IndexOfAppointment { get; set; }

        private void Schedule_CellTapped(object sender, CellTappedEventArgs e)
		{
			if (Schedule.ScheduleView == SFScheduleView.SFScheduleViewMonth)
			{
				Schedule.ScheduleView = SFScheduleView.SFScheduleViewDay;
				Schedule.MoveToDate(e.Date);
				Schedule.Hidden = false;
                ScheduleEditor.Editor.Hidden = true;
				HeaderView.Hidden = false;
            }
           
            // Hiding schedule view picker when it was opened and tapped on schedule
            TableView.Hidden = true;
        }

		private void Schedule_VisibleDatesChanged(object sender, VisibleDatesChangedEventArgs e)
		{
			int currentVisibleMonth = 0;
			if (Schedule.ScheduleView == SFScheduleView.SFScheduleViewMonth)
			{
                currentVisibleMonth = 8;
			}
			else
			{
                currentVisibleMonth = 0;
			}

			NSDate date = e.VisibleDates.GetItem<NSDate>((nuint)currentVisibleMonth);
			NSDateFormatter dateFormat = new NSDateFormatter();
			dateFormat.DateFormat = "MMMM YYYY";
			string monthName = dateFormat.ToString(date);
			monthText.Text = monthName;
			TableView.Hidden = true;
		}

		private void Schedule_DoubleTapped(object sender, CellTappedEventArgs e)
		{
            //base.didSelectDate (schedule, selectedDate, appointments);
            ScheduleEditor.Editor.Hidden = false;
			HeaderView.Hidden = true;
			Schedule.Hidden = true;
			IndexOfAppointment = -1;
			TableView.Hidden = true;
			if (e.ScheduleAppointment != null)
			{
				for (int i = 0; i < (Schedule.ItemsSource as ObservableCollection<ScheduleAppointment>).Count; i++)
				{
					if ((Schedule.ItemsSource as ObservableCollection<ScheduleAppointment>)[i] == e.ScheduleAppointment)
					{
						IndexOfAppointment = int.Parse(i.ToString());
						break;
					}
				}

				SelectedAppointment = e.ScheduleAppointment;
                ScheduleEditor.LabelSubject.Text = SelectedAppointment.Subject;
                ScheduleEditor.LabelLocation.Text = SelectedAppointment.Location;
				String startDate = DateTime.Parse(SelectedAppointment.StartTime.ToString()).ToString();
                ScheduleEditor.ButtonStartDate.SetTitle(startDate, UIControlState.Normal);
                ScheduleEditor.PickerStartDate.SetDate(SelectedAppointment.StartTime, true);
				String endDate = DateTime.Parse(SelectedAppointment.EndTime.ToString()).ToString();
                ScheduleEditor.ButtonEndDate.SetTitle(endDate, UIControlState.Normal);
                ScheduleEditor.PickerEndDate.SetDate(SelectedAppointment.EndTime, true);
                ScheduleEditor.AllDaySwitch.On = SelectedAppointment.IsAllDay;
                if (ScheduleEditor.AllDaySwitch.On)
                {
                    ScheduleEditor.Disablechild();
                }
                else
                {
                    ScheduleEditor.EnableChild();
                }

                ScheduleEditor.Editor.EndEditing(true);
			}
			else
			{
				List<UIColor> colorCollection = new List<UIColor>();
				colorCollection.Add(UIColor.FromRGB(0xA2, 0xC1, 0x39));
				colorCollection.Add(UIColor.FromRGB(0xD8, 0x00, 0x73));
                ScheduleEditor.LabelSubject.Text = "Subject";
                ScheduleEditor.LabelLocation.Text = "Location";
				String startDate = DateTime.Parse(e.Date.ToString()).ToString();
                ScheduleEditor.PickerStartDate.SetDate(e.Date, true);
                ScheduleEditor.ButtonStartDate.SetTitle(startDate, UIControlState.Normal);
				String endDate = DateTime.Parse(e.Date.AddSeconds(3600).ToString()).ToString();
                ScheduleEditor.PickerEndDate.SetDate(e.Date.AddSeconds(3600), true);
                ScheduleEditor.ButtonEndDate.SetTitle(endDate, UIControlState.Normal);
                ScheduleEditor.AllDaySwitch.On = false;
                this.ScheduleEditor.EnableChild();
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
            ScheduleEditor.CreateOptionWindow();
            var deviceType = UIDevice.CurrentDevice.Model;
            if (deviceType == "iPad")
            {
                ScheduleEditor.TimezoneLabel.Frame = new CGRect(10, 0, 320, 30);
                ScheduleEditor.TimezoneButton.Frame = new CGRect(0, ScheduleEditor.TimezoneLabel.Frame.Bottom, 320, 30);
                ScheduleEditor.DoneButton1.Frame = new CGRect(0, ScheduleEditor.TimezoneButton.Frame.Bottom, 320, 30);
                ScheduleEditor.TimeZonePicker.Frame = new CGRect(0, ScheduleEditor.DoneButton1.Frame.Bottom, 320, 200);
            }
            else
            {
                ScheduleEditor.TimezoneLabel.Frame = new CGRect(0, 0, this.Frame.Size.Width, 30);
                ScheduleEditor.TimezoneButton.Frame = new CGRect(0, ScheduleEditor.TimezoneLabel.Frame.Bottom, this.Frame.Size.Width, 30);
                ScheduleEditor.DoneButton1.Frame = new CGRect(0, ScheduleEditor.TimezoneButton.Frame.Bottom, this.Frame.Size.Width, 30);
                ScheduleEditor.TimeZonePicker.Frame = new CGRect(0, ScheduleEditor.DoneButton1.Frame.Bottom, this.Frame.Size.Width, 200);
            }

            this.OptionView.AddSubview(ScheduleEditor.TimezoneLabel);
            this.OptionView.AddSubview(ScheduleEditor.TimezoneButton);
            this.OptionView.AddSubview(ScheduleEditor.DoneButton1);
            this.OptionView.AddSubview(ScheduleEditor.TimeZonePicker);
        }

        protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (Schedule != null)
				{
					Schedule.AppointmentsForDate -= Schedule_AppointmentsForDate;
					Schedule.AppointmentsFromDate -= Schedule_AppointmentsFromDate;
					Schedule.CellTapped -= Schedule_CellTapped;
					Schedule.CellDoubleTapped -= Schedule_DoubleTapped;
					Schedule.VisibleDatesChanged -= Schedule_VisibleDatesChanged;
					Schedule.Dispose();
					Schedule = null;
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
            ScheduleEditor.Editor.Hidden = false;
			Schedule.Hidden = true;
			HeaderView.Hidden = true;
			TableView.Hidden = true;

			NSDate today = new NSDate();
			NSCalendar calendar = NSCalendar.CurrentCalendar;
			
            // Get the year, month, day from the date
			NSDateComponents components = calendar.Components(
				NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
			NSDate startDate = calendar.DateFromComponents(components);

            ScheduleEditor.LabelSubject.Text = "Subject";
            ScheduleEditor.LabelLocation.Text = "Location";
			String startDate1 = DateTime.Parse(startDate.ToString()).ToString();
            ScheduleEditor.PickerStartDate.SetDate(startDate, true);
            ScheduleEditor.ButtonStartDate.SetTitle(startDate1, UIControlState.Normal);
			String endDate = DateTime.Parse(startDate.AddSeconds(3600).ToString()).ToString();
            ScheduleEditor.PickerEndDate.SetDate(startDate.AddSeconds(3600), true);
            ScheduleEditor.ButtonEndDate.SetTitle(endDate, UIControlState.Normal);
		}

		private void MoveToDate_TouchUpInside(object sender, EventArgs e)
		{
			TableView.Hidden = true;
			NSDate today = new NSDate();
			NSCalendar calendar = NSCalendar.CurrentCalendar;
			
            // Get the year, month, day from the date
			NSDateComponents components = calendar.Components(
				NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
			NSDate startDate = calendar.DateFromComponents(components);

			Schedule.MoveToDate(startDate);
		}

		private void HeaderButton_TouchUpInside(object sender, EventArgs e)
		{
			TableView.Hidden = false;
		}

		public override void LayoutSubviews()
		{
			foreach (var view in this.Subviews)
			{
				view.Frame = new CGRect(Frame.X, 0, Frame.Width, Frame.Height);
			}

			CreateOptionView();
            ScheduleEditor.Editor.Frame = new CGRect(0, 0, this.Frame.Size.Width, this.Frame.Size.Height);
            ScheduleEditor.ScrollView.Frame = new CGRect(ScheduleEditor.Editor.Frame.X + 10, ScheduleEditor.Editor.Frame.Y + 10, ScheduleEditor.Editor.Frame.Size.Width - 10, ScheduleEditor.Editor.Frame.Size.Height);

            ScheduleEditor.EditorFrameUpdate();

			UIImageView image1 = new UIImageView();
			UIImageView image2 = new UIImageView();
			UIImageView image3 = new UIImageView();

			moveToDate = new UIButton();
			editorView = new UIButton();
			monthText = new UILabel();

			HeaderView = new UIView();
			HeaderView.BackgroundColor = UIColor.FromRGB(214, 214, 214);

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
			TableView = new UITableView();
			TableView.Frame = new CGRect(0, 0, this.Frame.Size.Width / 2, 60.0f * 4);
			TableView.Hidden = true;
			TableView.Source = new ScheduleTableSource(tableItems);

			string deviceType = UIDevice.CurrentDevice.Model;
			if (deviceType == "iPhone" || deviceType == "iPod touch")
			{
				image1.Frame = new CGRect(0, 0, 60, 60);
				image1.Image = UIImage.FromFile("black-09.png");
				image2.Frame = new CGRect(0, 0, 60, 60);
				image2.Image = UIImage.FromFile("black-11.png");
				image3.Frame = new CGRect(0, 0, 60, 60);
				image3.Image = UIImage.FromFile("black-10.png");

				HeaderView.Frame = new CGRect(0, 0, this.Frame.Size.Width, 50);
				moveToDate.Frame = new CGRect((this.Frame.Size.Width / 6) + (this.Frame.Size.Width / 2), -10, this.Frame.Size.Width / 8, 50);
				editorView.Frame = new CGRect((this.Frame.Size.Width / 6) + (this.Frame.Size.Width / 6) + (this.Frame.Size.Width / 2), -10, this.Frame.Size.Width / 8, 50);
				headerButton.Frame = new CGRect(-10, -10, this.Frame.Size.Width / 8, 50);
				monthText.Frame = new CGRect(this.Frame.Size.Width / 8, -10, this.Frame.Size.Width / 2, 60);
				Schedule.Frame = new CGRect(0, 50, this.Frame.Size.Width, this.Frame.Size.Height - 50);
			}
			else
			{
				Schedule.DayViewSettings.WorkStartHour = 7;
				Schedule.DayViewSettings.WorkEndHour = 18;

				Schedule.WeekViewSettings.WorkStartHour = 7;
				Schedule.WeekViewSettings.WorkEndHour = 18;

				Schedule.WorkWeekViewSettings.WorkStartHour = 7;
				Schedule.WorkWeekViewSettings.WorkEndHour = 18;

				image1.Frame = new CGRect(0, 0, 80, 80);
				image1.Image = UIImage.FromFile("black-09.png");
				image2.Frame = new CGRect(0, 0, 80, 80);
				image2.Image = UIImage.FromFile("black-11.png");
				image3.Frame = new CGRect(0, 0, 80, 80);
				image3.Image = UIImage.FromFile("black-10.png");

				HeaderView.Frame = new CGRect(0, 0, this.Frame.Size.Width, 60);
				moveToDate.Frame = new CGRect((this.Frame.Size.Width / 5) + (this.Frame.Size.Width / 2) + (this.Frame.Size.Width / 8), -10, this.Frame.Size.Width / 8, 50);
				editorView.Frame = new CGRect((this.Frame.Size.Width / 5) + (this.Frame.Size.Width / 5) + (this.Frame.Size.Width / 2), -10, this.Frame.Size.Width / 8, 50);
				headerButton.Frame = new CGRect(0, -10, this.Frame.Size.Width / 8, 50);
				monthText.Frame = new CGRect(this.Frame.Size.Width / 8, 5, this.Frame.Size.Width / 2, 50);
				Schedule.Frame = new CGRect(0, 60, this.Frame.Size.Width, this.Frame.Size.Height - 60);
			}

			moveToDate.TouchUpInside += MoveToDate_TouchUpInside;
			headerButton.TouchUpInside += HeaderButton_TouchUpInside;
			editorView.TouchUpInside += EditorView_TouchUpInside;

			HeaderView.AddSubview(moveToDate);
			HeaderView.AddSubview(editorView);
			HeaderView.AddSubview(monthText);
			HeaderView.AddSubview(headerButton);
			this.AddSubview(Schedule);
			this.AddSubview(HeaderView);
			this.AddSubview(ScheduleEditor.Editor);
			this.AddSubview(TableView);
			base.LayoutSubviews();
		}
	}
}
