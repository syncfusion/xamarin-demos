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
using Syncfusion.SfRangeSlider.iOS;

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
	public class Configuration : SampleView
	{
		public static SFSchedule schedule = new SFSchedule();
		private string selectedType;
		UILabel label_scheduleView, label_workingHours, label_weekNumber, label_showNonAccess, label_blackOutDays;
		SfRangeSlider _rangeslider;
		UIButton button_scheduleView = new UIButton();
		UIButton doneButton = new UIButton();
		UIPickerView picker_scheduleView;
		UISwitch switch_weekNumber, switch_nonAccessbleBlock, switch_blackOutDates;

		DayViewSettings daySettings;
		WeekViewSettings weekSettings;
		WorkWeekViewSettings workWeekSettings;
		MonthViewSettings monthSettings;

		public Configuration()
		{
			schedule = new SFSchedule();
			schedule.ScheduleView = SFScheduleView.SFScheduleViewWeek;

			//Intializing configurationc controls
			picker_scheduleView = new UIPickerView();
			_rangeslider = new SfRangeSlider();
			label_scheduleView = new UILabel();
			button_scheduleView = new UIButton();
			label_workingHours = new UILabel();
			label_weekNumber = new UILabel();
			label_showNonAccess = new UILabel();
			label_blackOutDays = new UILabel();
			switch_blackOutDates = new UISwitch();
			switch_nonAccessbleBlock = new UISwitch();
			switch_weekNumber = new UISwitch();
			switch_nonAccessbleBlock.On = true;
			switch_blackOutDates.On = true;
			switch_weekNumber.On = true;
			SetNonWorkingHours();
			SetMonthSettings();
			//schedule.AppointmentStyle.BorderColor = UIColor.LightGray;
			//schedule.AppointmentStyle.SelectionBorderColor = UIColor.Red;
			//schedule.AppointmentStyle.SelectionTextColor = UIColor.Orange;
			//schedule.AppointmentStyle.BorderWidth = 5;
			//schedule.AppointmentStyle.TextColor = UIColor.Magenta;
			schedule.Appointments = CreateAppointments();
			this.AddSubview(schedule);
			this.OptionView = new UIView();
			//control = this;
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
				if (OptionView != null)
				{
					this.OptionView.RemoveFromSuperview();
					this.OptionView.Dispose();
					this.OptionView = null;
				}
				if (button_scheduleView != null)
				{
					button_scheduleView.TouchUpInside -= ShowPicker1;
					button_scheduleView.Dispose();
					button_scheduleView = null;
				}
				if (doneButton != null)
				{
					doneButton.TouchUpInside -= HidePicker;
					doneButton.Dispose();
					doneButton = null;
				}
				if (_rangeslider != null)
				{
					_rangeslider.RangeValueChange -= Slider_RangeValueChange;
					_rangeslider.Dispose();
					_rangeslider = null;
				}
			}
			base.Dispose(disposing);
		}


		private void SetNonWorkingHours()
		{
			daySettings = new DayViewSettings();
			weekSettings = new WeekViewSettings();
			workWeekSettings = new WorkWeekViewSettings();


			//Non-AccessbleBlocks
			NonAccessibleBlock lunch_hour = new NonAccessibleBlock();
			lunch_hour.StartHour = 13;
			lunch_hour.EndHour = 14;
			lunch_hour.Text = (NSString)"LUNCH";
			daySettings.NonAccessibleBlockCollection = new NSMutableArray();
			weekSettings.NonAccessibleBlockCollection = new NSMutableArray();
			workWeekSettings.NonAccessibleBlockCollection = new NSMutableArray();

			if (switch_nonAccessbleBlock != null && switch_nonAccessbleBlock.On)
			{
				daySettings.NonAccessibleBlockCollection.Add(lunch_hour);
				weekSettings.NonAccessibleBlockCollection.Add(lunch_hour);
				workWeekSettings.NonAccessibleBlockCollection.Add(lunch_hour);
			}
			schedule.DayViewSettings = daySettings;
			schedule.WeekViewSettings = weekSettings;
			schedule.WorkWeekViewSettings = workWeekSettings;

		}

		private void SetMonthSettings()
		{
			monthSettings = new MonthViewSettings();

			NSDate today = new NSDate();
			NSCalendar calendar = NSCalendar.CurrentCalendar;
			// Get the year, month, day from the date
			NSDateComponents components = calendar.Components(
											  NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
			// Set the hour, minute, second
			schedule.MonthViewSettings = monthSettings;
			monthSettings.BlackoutDates = new NSMutableArray();
			if (switch_blackOutDates != null && switch_blackOutDates.On)
			{
				components.Day -= 3;
				for (int i = 0; i < 3; i++)
				{
					NSDate startDate = calendar.DateFromComponents(components);
					components.Day += 1;
					schedule.MonthViewSettings.BlackoutDates.Add(startDate);
				}
			}
			if (switch_weekNumber != null && switch_weekNumber.On)
			{
				schedule.MonthViewSettings.ShowWeekNumber = true;
			}
			else
			{
				schedule.MonthViewSettings.ShowWeekNumber = false;
			}
		}

		public override void LayoutSubviews()
		{
			foreach (var view in this.Subviews)
			{
				view.Frame = Bounds;
			}
			this.CreateOptionView();
			base.LayoutSubviews();
		}

		private readonly IList<string> _scheduleViewsCollection = new List<string>
		{
			"DayView",
			"WeekView",
			"WorkWeekView",
			"MonthView"
		};
		void Slider_RangeValueChange(object sender, RangeEventArgs e)
		{
			schedule.DayViewSettings.WorkStartHour = (int)e.RangeStart;
			schedule.DayViewSettings.WorkEndHour = (int)e.RangeEnd;
			schedule.WeekViewSettings.WorkStartHour = (int)e.RangeStart;
			schedule.WeekViewSettings.WorkEndHour = (int)e.RangeEnd;
			schedule.WorkWeekViewSettings.WorkStartHour = (int)e.RangeStart;
			schedule.WorkWeekViewSettings.WorkEndHour = (int)e.RangeEnd;
		}

		private void CreateOptionView()
		{
			//Schedule View

			Localization.SchedulePickerModel model = new Localization.SchedulePickerModel(_scheduleViewsCollection);
			picker_scheduleView.Model = model;
			label_scheduleView.Text = "Select the Schedule Type";
			label_scheduleView.TextColor = UIColor.Black;
			label_scheduleView.TextAlignment = UITextAlignment.Left;

			button_scheduleView.SetTitle("WeekView", UIControlState.Normal);
			button_scheduleView.SetTitleColor(UIColor.Black, UIControlState.Normal);
			button_scheduleView.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			button_scheduleView.Layer.CornerRadius = 8;
			button_scheduleView.Layer.BorderWidth = 2;
			button_scheduleView.TouchUpInside += ShowPicker1;
			button_scheduleView.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;

			doneButton.SetTitle("Done\t", UIControlState.Normal);
			doneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			doneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			doneButton.TouchUpInside += HidePicker;
			doneButton.Hidden = true;
			doneButton.BackgroundColor = UIColor.FromRGB(246, 246, 246);

			model.PickerChanged += Model_PickerChanged;
			picker_scheduleView.ShowSelectionIndicator = true;
			picker_scheduleView.Hidden = true;

			//working Hours

			label_workingHours.Text = "Working Hours ";
			label_workingHours.TextColor = UIColor.Black;
			label_workingHours.TextAlignment = UITextAlignment.Left;

			_rangeslider.Maximum = 24;
			_rangeslider.Minimum = 0;
			_rangeslider.RangeStart = schedule.WeekViewSettings.WorkStartHour;
			_rangeslider.RangeEnd = schedule.WeekViewSettings.WorkEndHour;
			_rangeslider.ShowRange = true;
			_rangeslider.ShowValueLabel = false;
			_rangeslider.SnapsTo = SFSnapsTo.SFSnapsToNone;
			_rangeslider.TickPlacement = SFTickPlacement.SFTickPlacementNone;
			_rangeslider.LabelColor = UIColor.Gray;
			_rangeslider.TickFrequency = 2;
			_rangeslider.ToolTipPlacement = SFToolTipPlacement.SFToolTipPlacementTopLeft;
			_rangeslider.KnobColor = UIColor.White;
			_rangeslider.RangeValueChange += Slider_RangeValueChange;
			//_rangeslider.touch
			//_rangeslider.TouchUpInside+=	(object sender, EventArgs e) =>
			//{

			//	schedule.DayViewSettings.WorkStartHour = (int)(sender as SFRangeSlider).RangeStart;
			//	schedule.DayViewSettings.WorkEndHour = (int)(sender as SFRangeSlider).RangeEnd;

			//	schedule.WeekViewSettings.WorkStartHour = (int)(sender as SFRangeSlider).RangeStart;
			//	schedule.WeekViewSettings.WorkEndHour = (int)(sender as SFRangeSlider).RangeEnd;

			//	schedule.WorkWeekViewSettings.WorkStartHour = (int)(sender as SFRangeSlider).RangeStart;
			//	schedule.WorkWeekViewSettings.WorkEndHour = (int)(sender as SFRangeSlider).RangeEnd;
			//	schedule.UpdateConstraints ();
			//};

			// show week number
			label_weekNumber.Text = "Show Week number ";
			label_weekNumber.TextColor = UIColor.Black;
			label_weekNumber.TextAlignment = UITextAlignment.Left;


			switch_weekNumber.ValueChanged += (object sender, EventArgs e) =>
			{
				SetMonthSettings();
			};


			//show non acceesible block
			label_showNonAccess.Text = "Show Non AccessibleBlocks ";
			label_showNonAccess.TextColor = UIColor.Black;
			label_showNonAccess.TextAlignment = UITextAlignment.Left;


			switch_nonAccessbleBlock.ValueChanged += (object sender, EventArgs e) =>
			{
				SetNonWorkingHours();
			};

			//show black out dates
			label_blackOutDays.Text = "Show Blackout dates ";
			label_blackOutDays.TextColor = UIColor.Black;
			label_blackOutDays.TextAlignment = UITextAlignment.Left;

			switch_blackOutDates.On = true;
			switch_blackOutDates.ValueChanged += (object sender, EventArgs e) =>
			{
				SetMonthSettings();
			};
			string deviceType = UIDevice.CurrentDevice.Model;
			if (deviceType == "iPhone" || deviceType == "iPod touch")
			{
				label_workingHours.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y - 70, this.Frame.Size.Width - 20, 30);
				_rangeslider.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y - 40, this.Frame.Size.Width - 20, 30);

				switch_weekNumber.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y, this.Frame.Size.Width / 9, 30);
				label_weekNumber.Frame = new CGRect(this.Frame.Size.Width / 9 + 30, this.Frame.Y, this.Frame.Size.Width - 20, 30);
				//switch_weekNumber
				switch_nonAccessbleBlock.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 40, this.Frame.Size.Width / 9, 30);
				label_showNonAccess.Frame = new CGRect(this.Frame.Size.Width / 9 + 30, this.Frame.Y + 40, this.Frame.Size.Width - 20, 30);
				//switch_nonAccessbleBlock
				switch_blackOutDates.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 80, this.Frame.Size.Width / 9, 30);
				label_blackOutDays.Frame = new CGRect(this.Frame.Size.Width / 9 + 30, this.Frame.Y + 80, this.Frame.Size.Width - 20, 30);
				//label_blackOutDays
				label_scheduleView.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 120, this.Frame.Size.Width - 20, 30);
				button_scheduleView.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 150, this.Frame.Size.Width - 20, 30);

				doneButton.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 180, this.Frame.Size.Width - 20, 30);
				picker_scheduleView.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 170, this.Frame.Size.Width - 20, 150);
			}
			//settings frame size for sub views
			else
			{

				schedule.DayViewSettings.WorkStartHour = 7;
				schedule.DayViewSettings.WorkEndHour = 18;

				schedule.WeekViewSettings.WorkStartHour = 7;
				schedule.WeekViewSettings.WorkEndHour = 18;

				schedule.WorkWeekViewSettings.WorkStartHour = 7;
				schedule.WorkWeekViewSettings.WorkEndHour = 18;




				label_workingHours.Frame = new CGRect(10, 10, 320, 20);
				_rangeslider.Frame = new CGRect(0, 30, 320, 30);

				switch_weekNumber.Frame = new CGRect(10, 60, 30, 30);
				label_weekNumber.Frame = new CGRect(80, 60, 320, 30);
				//switch_weekNumber
				switch_nonAccessbleBlock.Frame = new CGRect(10, 100, 30, 30);
				label_showNonAccess.Frame = new CGRect(80, 100, 320, 30);
				//switch_nonAccessbleBlock
				switch_blackOutDates.Frame = new CGRect(10, 140, 30, 30);
				label_blackOutDays.Frame = new CGRect(80, 140, 320, 30);
				//label_blackOutDays
				label_scheduleView.Frame = new CGRect(10, 180, 320, 20);
				button_scheduleView.Frame = new CGRect(0, 210, 320, 30);

				doneButton.Frame = new CGRect(0, 250, 320, 30);
				picker_scheduleView.Frame = new CGRect(0, 270, 320, 100);

			}
			this.OptionView.AddSubview(label_workingHours);
			this.OptionView.AddSubview(_rangeslider);
			this.OptionView.AddSubview(label_weekNumber);
			this.OptionView.AddSubview(switch_weekNumber);
			this.OptionView.AddSubview(label_showNonAccess);
			this.OptionView.AddSubview(switch_nonAccessbleBlock);
			this.OptionView.AddSubview(label_blackOutDays);
			this.OptionView.AddSubview(switch_blackOutDates);
			this.OptionView.AddSubview(label_scheduleView);
			this.OptionView.AddSubview(button_scheduleView);
			this.OptionView.AddSubview(picker_scheduleView);
			this.OptionView.AddSubview(doneButton);
		}

		void Model_PickerChanged(object sender, Localization.SchedulePickerChangedEventArgs e)
		{
			this.selectedType = e.SelectedValue;
			if (selectedType == "WeekView")
			{
				schedule.ScheduleView = SFScheduleView.SFScheduleViewWeek;
			}
			else if (selectedType == "DayView")
			{
				schedule.ScheduleView = SFScheduleView.SFScheduleViewDay;
			}
			else if (selectedType == "WorkWeekView")
			{
				schedule.ScheduleView = SFScheduleView.SFScheduleViewWorkWeek;
			}
			else
			{
				schedule.ScheduleView = SFScheduleView.SFScheduleViewMonth;
			}
			button_scheduleView.SetTitle(selectedType.ToString(), UIControlState.Normal);
		}

		void ShowPicker1(object sender, EventArgs e)
		{

			doneButton.Hidden = false;
			picker_scheduleView.Hidden = false;
			button_scheduleView.Hidden = false;
			label_scheduleView.Hidden = false;
			label_workingHours.Hidden = false;
		}

		void HidePicker(object sender, EventArgs e)
		{

			doneButton.Hidden = true;
			picker_scheduleView.Hidden = true;
			button_scheduleView.Hidden = false;
			label_scheduleView.Hidden = false;
			label_workingHours.Hidden = false;
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
