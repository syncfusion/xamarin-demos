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
using Syncfusion.SfRangeSlider.iOS;
using System.Collections.ObjectModel;
using Foundation;
using UIKit;
using CoreGraphics;

namespace SampleBrowser
{
	public class Configuration : SampleView
	{
		private static SFSchedule schedule = new SFSchedule();
        private ScheduleConfigurationViewModel viewModel = new ScheduleConfigurationViewModel();
        private string selectedType;
		private UILabel labelScheduleView, labelWorkingHours, labelWeekNumber, labelShowNonAccess, labelBlackOutDays;
		private SfRangeSlider rangeslider;
		private UIButton buttonScheduleView = new UIButton();
		private UIButton doneButton = new UIButton();
		private UIPickerView pickerScheduleView;
		private UISwitch switchWeekNumber, switchNonAccessbleBlock, switchBlackOutDates;
		private DayViewSettings daySettings;
		private WeekViewSettings weekSettings;
		private WorkWeekViewSettings workWeekSettings;
		private MonthViewSettings monthSettings;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Configuration()
        {
            schedule = new SFSchedule();
            schedule.ScheduleView = SFScheduleView.SFScheduleViewWeek;

            //Initializing configuration controls
            pickerScheduleView = new UIPickerView();
            rangeslider = new SfRangeSlider();
            labelScheduleView = new UILabel();
            buttonScheduleView = new UIButton();
            labelWorkingHours = new UILabel();
            labelWeekNumber = new UILabel();
            labelShowNonAccess = new UILabel();
            labelBlackOutDays = new UILabel();
            switchBlackOutDates = new UISwitch();
            switchNonAccessbleBlock = new UISwitch();
            switchWeekNumber = new UISwitch();
            switchNonAccessbleBlock.On = true;
            switchBlackOutDates.On = true;
            switchWeekNumber.On = true;
            SetNonWorkingHours();
            SetMonthSettings();
            schedule.ItemsSource = viewModel.CreateAppointments();
            this.AddSubview(schedule);
            this.OptionView = new UIView();
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

				if (buttonScheduleView != null)
				{
                    buttonScheduleView.TouchUpInside -= ShowPicker1;
                    buttonScheduleView.Dispose();
                    buttonScheduleView = null;
				}

				if (doneButton != null)
				{
					doneButton.TouchUpInside -= HidePicker;
					doneButton.Dispose();
					doneButton = null;
				}

				if (rangeslider != null)
				{
                    rangeslider.RangeValueChange -= Slider_RangeValueChange;
                    rangeslider.Dispose();
                    rangeslider = null;
				}

                if (daySettings != null)
                {
                    daySettings.Dispose();
                    daySettings = null;
                }

                if (labelBlackOutDays != null)
                {
                    labelBlackOutDays.Dispose();
                    labelBlackOutDays = null;
                }

                if (labelScheduleView != null)
                {
                    labelScheduleView.Dispose();
                    labelScheduleView = null;
                }

                if (labelShowNonAccess != null)
                {
                    labelShowNonAccess.Dispose();
                    labelShowNonAccess = null;
                }

                if (labelWeekNumber != null)
                {
                    labelWeekNumber.Dispose();
                    labelWeekNumber = null;
                }

                if (labelWorkingHours != null)
                {
                    labelWorkingHours.Dispose();
                    labelWorkingHours = null;
                }

                if (monthSettings != null)
                {
                    monthSettings.Dispose();
                    monthSettings = null;
                }

                if (pickerScheduleView != null)
                {
                    pickerScheduleView.Dispose();
                    pickerScheduleView = null;
                }

                if (switchBlackOutDates != null)
                {
                    switchBlackOutDates.Dispose();
                    switchBlackOutDates = null;
                }

                if (switchNonAccessbleBlock != null)
                {
                    switchNonAccessbleBlock.Dispose();
                    switchNonAccessbleBlock = null;
                }

                if (switchWeekNumber != null)
                {
                    switchWeekNumber.Dispose();
                    switchWeekNumber = null;
                }

                if (weekSettings != null)
                {
                    weekSettings.Dispose();
                    weekSettings = null;
                }

                if (workWeekSettings != null)
                {
                    workWeekSettings.Dispose();
                    workWeekSettings = null;
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

			if (switchNonAccessbleBlock != null && switchNonAccessbleBlock.On)
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
			if (switchBlackOutDates != null && switchBlackOutDates.On)
			{
				components.Day -= 3;
				for (int i = 0; i < 3; i++)
				{
					NSDate startDate = calendar.DateFromComponents(components);
					components.Day += 1;
					schedule.MonthViewSettings.BlackoutDates.Add(startDate);
				}
			}

			if (switchWeekNumber != null && switchWeekNumber.On)
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

		private readonly IList<string> scheduleViewsCollection = new List<string>
		{
			"DayView",
			"WeekView",
			"WorkWeekView",
			"MonthView"
		};

		private void Slider_RangeValueChange(object sender, RangeEventArgs e)
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
			Localization.SchedulePickerModel model = new Localization.SchedulePickerModel(scheduleViewsCollection);
            pickerScheduleView.Model = model;
            labelScheduleView.Text = "Select the Schedule Type";
            labelScheduleView.TextColor = UIColor.Black;
            labelScheduleView.TextAlignment = UITextAlignment.Left;

            buttonScheduleView.SetTitle("WeekView", UIControlState.Normal);
            buttonScheduleView.SetTitleColor(UIColor.Black, UIControlState.Normal);
            buttonScheduleView.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            buttonScheduleView.Layer.CornerRadius = 8;
            buttonScheduleView.Layer.BorderWidth = 2;
            buttonScheduleView.TouchUpInside += ShowPicker1;
            buttonScheduleView.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;

			doneButton.SetTitle("Done\t", UIControlState.Normal);
			doneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			doneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			doneButton.TouchUpInside += HidePicker;
			doneButton.Hidden = true;
			doneButton.BackgroundColor = UIColor.FromRGB(246, 246, 246);

			model.PickerChanged += Model_PickerChanged;
            pickerScheduleView.ShowSelectionIndicator = true;
            pickerScheduleView.Hidden = true;

            //working Hours
            labelWorkingHours.Text = "Working Hours ";
            labelWorkingHours.TextColor = UIColor.Black;
            labelWorkingHours.TextAlignment = UITextAlignment.Left;

            rangeslider.Maximum = 24;
            rangeslider.Minimum = 0;
            rangeslider.RangeStart = (nfloat)schedule.WeekViewSettings.WorkStartHour;
            rangeslider.RangeEnd = (nfloat)schedule.WeekViewSettings.WorkEndHour;
            rangeslider.ShowRange = true;
            rangeslider.ShowValueLabel = false;
            rangeslider.SnapsTo = SFSnapsTo.SFSnapsToNone;
            rangeslider.TickPlacement = SFTickPlacement.SFTickPlacementNone;
            rangeslider.LabelColor = UIColor.Gray;
            rangeslider.TickFrequency = 2;
            rangeslider.ToolTipPlacement = SFToolTipPlacement.SFToolTipPlacementTopLeft;
            rangeslider.KnobColor = UIColor.White;
            rangeslider.RangeValueChange += Slider_RangeValueChange;

            // show week number
            labelWeekNumber.Text = "Show Week number ";
            labelWeekNumber.TextColor = UIColor.Black;
            labelWeekNumber.TextAlignment = UITextAlignment.Left;
            switchWeekNumber.ValueChanged += (object sender, EventArgs e) =>
			{
				SetMonthSettings();
			};

            //show non acceesible block
            labelShowNonAccess.Text = "Show Non AccessibleBlocks ";
            labelShowNonAccess.TextColor = UIColor.Black;
            labelShowNonAccess.TextAlignment = UITextAlignment.Left;

            switchNonAccessbleBlock.ValueChanged += (object sender, EventArgs e) =>
			{
				SetNonWorkingHours();
			};

            //show black out dates
            labelBlackOutDays.Text = "Show Blackout dates ";
            labelBlackOutDays.TextColor = UIColor.Black;
            labelBlackOutDays.TextAlignment = UITextAlignment.Left;

            switchBlackOutDates.On = true;
            switchBlackOutDates.ValueChanged += (object sender, EventArgs e) =>
			{
				SetMonthSettings();
			};
			string deviceType = UIDevice.CurrentDevice.Model;
			if (deviceType == "iPhone" || deviceType == "iPod touch")
			{
                labelWorkingHours.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y - 70, this.Frame.Size.Width - 20, 30);
                rangeslider.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y - 40, this.Frame.Size.Width - 20, 30);

				switchWeekNumber.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y, this.Frame.Size.Width / 9, 30);
                labelWeekNumber.Frame = new CGRect((this.Frame.Size.Width / 9) + 30, this.Frame.Y, this.Frame.Size.Width - 20, 30);
               
                //switch_weekNumber
                switchNonAccessbleBlock.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 40, this.Frame.Size.Width / 9, 30);
                labelShowNonAccess.Frame = new CGRect((this.Frame.Size.Width / 9) + 30, this.Frame.Y + 40, this.Frame.Size.Width - 20, 30);
               
                //switch_nonAccessbleBlock
                switchBlackOutDates.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 80, this.Frame.Size.Width / 9, 30);
                labelBlackOutDays.Frame = new CGRect((this.Frame.Size.Width / 9) + 30, this.Frame.Y + 80, this.Frame.Size.Width - 20, 30);
               
                //label_blackOutDays
                labelScheduleView.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 120, this.Frame.Size.Width - 20, 30);
                buttonScheduleView.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 150, this.Frame.Size.Width - 20, 30);
				doneButton.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 180, this.Frame.Size.Width - 20, 30);
                pickerScheduleView.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 170, this.Frame.Size.Width - 20, 150);
			}		
			else
			{
				schedule.DayViewSettings.WorkStartHour = 7;
				schedule.DayViewSettings.WorkEndHour = 18;
				schedule.WeekViewSettings.WorkStartHour = 7;
				schedule.WeekViewSettings.WorkEndHour = 18;
				schedule.WorkWeekViewSettings.WorkStartHour = 7;
				schedule.WorkWeekViewSettings.WorkEndHour = 18;
                labelWorkingHours.Frame = new CGRect(10, 10, 320, 20);
                rangeslider.Frame = new CGRect(0, 30, 320, 30);

				switchWeekNumber.Frame = new CGRect(10, 60, 30, 30);
                labelWeekNumber.Frame = new CGRect(80, 60, 320, 30);
               
                //switch_weekNumber
                switchNonAccessbleBlock.Frame = new CGRect(10, 100, 30, 30);
                labelShowNonAccess.Frame = new CGRect(80, 100, 320, 30);
                
                //switch_nonAccessbleBlock
                switchBlackOutDates.Frame = new CGRect(10, 140, 30, 30);
                labelBlackOutDays.Frame = new CGRect(80, 140, 320, 30);
                
                //label_blackOutDays
                labelScheduleView.Frame = new CGRect(10, 180, 320, 20);
                buttonScheduleView.Frame = new CGRect(0, 210, 320, 30);

				doneButton.Frame = new CGRect(0, 250, 320, 30);
                pickerScheduleView.Frame = new CGRect(0, 270, 320, 100);
			}

			this.OptionView.AddSubview(labelWorkingHours);
			this.OptionView.AddSubview(rangeslider);
			this.OptionView.AddSubview(labelWeekNumber);
			this.OptionView.AddSubview(switchWeekNumber);
			this.OptionView.AddSubview(labelShowNonAccess);
			this.OptionView.AddSubview(switchNonAccessbleBlock);
			this.OptionView.AddSubview(labelBlackOutDays);
			this.OptionView.AddSubview(switchBlackOutDates);
			this.OptionView.AddSubview(labelScheduleView);
			this.OptionView.AddSubview(buttonScheduleView);
			this.OptionView.AddSubview(pickerScheduleView);
			this.OptionView.AddSubview(doneButton);
		}

		private void Model_PickerChanged(object sender, Localization.SchedulePickerChangedEventArgs e)
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

            buttonScheduleView.SetTitle(selectedType.ToString(), UIControlState.Normal);
		}

		private void ShowPicker1(object sender, EventArgs e)
		{
			doneButton.Hidden = false;
            pickerScheduleView.Hidden = false;
            buttonScheduleView.Hidden = false;
            labelScheduleView.Hidden = false;
            labelWorkingHours.Hidden = false;
		}

		private void HidePicker(object sender, EventArgs e)
		{
			doneButton.Hidden = true;
            pickerScheduleView.Hidden = true;
            buttonScheduleView.Hidden = false;
            labelScheduleView.Hidden = false;
            labelWorkingHours.Hidden = false;
		}
	}
}
