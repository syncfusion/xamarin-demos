#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfCalendar.iOS;
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
	public class CalendarConfiguration_Mobile :SampleView
	{
		SFCalendar calendar;
		private string selectedType;
		UILabel label_calendarView;
		UIButton button_calendarView = new UIButton ();
		UIButton doneButton=new UIButton();
		UIPickerView picker_calendarView;
		public UIView option=new UIView();

		public CalendarConfiguration_Mobile ()
		{
			//Calendar
			calendar = new SFCalendar ();
			calendar.ViewMode = SFCalendarViewMode.SFCalendarViewModeMonth;
			calendar.Delegate = new CalendarDelegate();
			NSMutableArray<NSString> customLabel = new NSMutableArray<NSString>();
			customLabel.Add((NSString)"SUN");
			customLabel.Add((NSString)"MON");
			customLabel.Add((NSString)"TUE");
			customLabel.Add((NSString)"WED");
			customLabel.Add((NSString)"THU");
			customLabel.Add((NSString)"FRI");
			customLabel.Add((NSString)"SAT");
			calendar.CustomDayLabels = customLabel;
			calendar.HeaderHeight = 40;
			//MonthViewSettings
			SFMonthViewSettings monthSettings = new SFMonthViewSettings ();
			monthSettings.WeekDayFontAttribute = UIFont.FromName("Menlo-Italic", 16f);
			monthSettings.FontAttribute = UIFont.FromName("Menlo-Regular", 16f);
			monthSettings.HeaderTextColor = UIColor.White;
			monthSettings.HeaderBackgroundColor = UIColor.FromRGB (61,61,61);
			monthSettings.DayLabelTextColor = UIColor.White;
			monthSettings.DayLabelBackgroundColor = UIColor.FromRGB (61,61,61);
			monthSettings.DateSelectionColor = UIColor.FromRGB (61,61,61);
			calendar.MonthViewSettings = monthSettings;
			this.optionView();
			this.AddSubview (calendar);
		}

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Bounds;
				this.OptionView.Frame = view.Frame;
				option.Frame = new CGRect (0, 90, Frame.Width, Frame.Height);
				label_calendarView.Frame = new CGRect (this.Frame.X + 10, this.Frame.Y - 20, this.Frame.Size.Width - 20, 30);
				button_calendarView.Frame = new CGRect (this.Frame.X + 10, this.Frame.Y + 20, this.Frame.Size.Width - 20, 30);	
				picker_calendarView.Frame = new CGRect (this.Frame.X, this.Frame.Size.Height/4, this.Frame.Size.Width, this.Frame.Size.Height/3);
				doneButton.Frame = new CGRect(0, this.Frame.Size.Height/4, this.Frame.Size.Width, 40);
			}

			base.LayoutSubviews ();
		}

		private readonly IList<string> _calendarViewsCollection = new List<string>
		{
			"Single Selection",
			"Multi Selection"
		};

		public void  optionView()
		{
			//Intializing configurationc controls
			picker_calendarView = new UIPickerView();
			label_calendarView = new UILabel();
			button_calendarView = new UIButton();
			this.OptionView = new UIView();

            //CalendarView
			PickerModel model = new PickerModel (_calendarViewsCollection);
			picker_calendarView.Model = model;
			label_calendarView.Text = "Selection Mode: ";
			label_calendarView.TextColor = UIColor.Black;
			label_calendarView.TextAlignment = UITextAlignment.Left;

			button_calendarView.SetTitle ("Single Selection", UIControlState.Normal);
			button_calendarView.SetTitleColor (UIColor.Black, UIControlState.Normal);
			button_calendarView.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			button_calendarView.Layer.CornerRadius = 8;
			button_calendarView.Layer.BorderWidth = 2;
			button_calendarView.TouchUpInside += ShowPicker1;
			button_calendarView.Layer.BorderColor = UIColor.FromRGB (246, 246, 246).CGColor;

			doneButton.SetTitle ("Done\t", UIControlState.Normal);
			doneButton.SetTitleColor (UIColor.Black, UIControlState.Normal);
			doneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			doneButton.TouchUpInside += HidePicker;
			doneButton.Hidden = true;
			doneButton.BackgroundColor = UIColor.FromRGB (246, 246, 246);

			model.PickerChanged += SelectedIndexChanged1;
			picker_calendarView.ShowSelectionIndicator = true;
			picker_calendarView.Hidden = true;
			//picker_calendarView.BackgroundColor = UIColor.Gray;


			//adding subviews to the option view
			this.option.AddSubview (label_calendarView);
			this.option.AddSubview (button_calendarView);

			this.option.AddSubview (picker_calendarView);
			this.option.AddSubview (doneButton);
		}

		void ShowPicker1 (object sender, EventArgs e) {

			doneButton.Hidden = false;
			picker_calendarView.Hidden = false;
			button_calendarView.Hidden = true;
			label_calendarView.Hidden = true;
		}

		void HidePicker (object sender, EventArgs e) {

			doneButton.Hidden = true;
			picker_calendarView.Hidden = true;
			button_calendarView.Hidden = false;
			label_calendarView.Hidden = false;
		}

		private void SelectedIndexChanged1(object sender, PickerChangedEventArgs e)
		{
			this.selectedType = e.SelectedValue;
			if (selectedType == "Single Selection") {
				calendar.SelectionMode = SFCalenderSelectionMode.SFCalenderSelectionModeSingle;
			} else if (selectedType == "Multi Selection") {
				calendar.SelectionMode = SFCalenderSelectionMode.SFCalenderSelectionModeMultiple;
			}else if (selectedType == "Range Selection") {
				calendar.SelectionMode = SFCalenderSelectionMode.SFCalenderSelectionModeRange;
			}

			button_calendarView.SetTitle(selectedType.ToString(),UIControlState.Normal);
		}
		
		public class CalendarDelegate:SFCalendarDelegate
		{
			public override SFMonthCell DidDrawMonthCell (SFCalendar calendar, SFMonthCell monthCell)
			{
				NSDate now = monthCell.Date;
				NSDateFormatter dateFormatter = new NSDateFormatter();
				dateFormatter.DateFormat = "EEEE";
				NSDateFormatter dateFormatter2 = new NSDateFormatter();
				dateFormatter2.DateFormat = "d";
				NSString day = (NSString)dateFormatter2.ToString(now);
				NSString dayname = (NSString)dateFormatter.ToString (now);
				if (dayname.ToString().Equals ("Saturday") || dayname.ToString().Equals("Sunday")) {
					monthCell.TextColor = UIColor.FromRGB (9,144,233);
				}
				if (day.ToString().Equals("15") || day.ToString().Equals("24"))
				{
					UIImageView view = new UIImageView();
					view.Image=UIImage.FromBundle("Shop-Closed.png");
					monthCell.View = view;
				}
				return monthCell;
			}
		}

	}
}
