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
	public class CalendarConfiguration_Tablet :SampleView
	{
		SFCalendar calendar;
		private string selectedType;
		UILabel label_calendarView;
		UIButton button_calendarView = new UIButton ();
		UIButton doneButton=new UIButton();
		UIButton showPropertyButton = new UIButton ();
		UIButton closeButton = new UIButton ();
		UILabel propertiesLabel = new UILabel ();
		UIView subView = new UIView ();
		UIView pickerSubView = new UIView ();
		UIView contentView = new UIView ();
		UIView calendarView = new UIView ();
		UIPickerView selectionPicker=new UIPickerView();

		public CalendarConfiguration_Tablet()
		{
			//Calendar
			calendar = new SFCalendar ();
			calendar.ViewMode = SFCalendarViewMode.SFCalendarViewModeMonth;
			calendar.Delegate = new CalendarDelegate();
			calendar.HeaderHeight = 40;
			NSMutableArray<NSString> customLabel = new NSMutableArray<NSString>();
			customLabel.Add((NSString)"SUN");
			customLabel.Add((NSString)"MON");
			customLabel.Add((NSString)"TUE");
			customLabel.Add((NSString)"WED");
			customLabel.Add((NSString)"THU");
			customLabel.Add((NSString)"FRI");
			customLabel.Add((NSString)"SAT");
			calendar.CustomDayLabels = customLabel;
			//MonthViewSettings
			SFMonthViewSettings monthSettings = new SFMonthViewSettings ();
			monthSettings.HeaderFontAttribute = UIFont.SystemFontOfSize(24f);
			monthSettings.WeekDayFontAttribute = UIFont.FromName("Menlo-Italic", 16f);
			monthSettings.FontAttribute = UIFont.FromName("Menlo-Regular", 16f);
			monthSettings.HeaderTextColor = UIColor.White;
			monthSettings.HeaderBackgroundColor = UIColor.FromRGB (61,61,61);
			monthSettings.DayLabelTextColor = UIColor.White;
			monthSettings.DayLabelBackgroundColor = UIColor.FromRGB (61,61,61);
			monthSettings.DateSelectionColor = UIColor.FromRGB (61,61,61);
			calendar.MonthViewSettings = monthSettings;

			this.AddSubview (calendar);
			this.loadOptionView();

		}
		public void loadOptionView()
		{ 
			PickerModel model = new PickerModel(_calendarViewsCollection);

			//label
			label_calendarView = new UILabel();
			label_calendarView.Text = "Selection Mode ";
			label_calendarView.TextColor = UIColor.Black;
			label_calendarView.Font = UIFont.FromName("Helvetica", 14f);
			label_calendarView.TextAlignment = UITextAlignment.Left;

			//button
			button_calendarView = new UIButton();
			button_calendarView.SetTitle("Single Selection", UIControlState.Normal);
			button_calendarView.SetTitleColor(UIColor.Black, UIControlState.Normal);
			button_calendarView.Font = UIFont.FromName("Helvetica", 14f);
			button_calendarView.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			button_calendarView.Layer.CornerRadius = 8;
			button_calendarView.Layer.BorderWidth = 2;
			button_calendarView.TouchUpInside += ShowPicker1;
			button_calendarView.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;

			//doneButton
			doneButton.SetTitle("Done\t", UIControlState.Normal);
			doneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			doneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			doneButton.TouchUpInside += HidePicker;
			doneButton.Hidden = true;
			doneButton.Font = UIFont.FromName("Helvetica", 14f);
			doneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);

			//selectionPicker
			model.PickerChanged += SelectedIndexChanged1;
			selectionPicker.Model = model;
			selectionPicker.ShowSelectionIndicator = true;
			selectionPicker.Hidden = true;
			selectionPicker.BackgroundColor = UIColor.Gray;

			contentView.AddSubview(label_calendarView);
			contentView.AddSubview(button_calendarView);

			pickerSubView.AddSubview(selectionPicker);
			pickerSubView.BackgroundColor = UIColor.Gray;
			pickerSubView.Hidden = true;
			contentView.AddSubview(pickerSubView);
			contentView.AddSubview(doneButton);
			contentView.BackgroundColor = UIColor.FromRGB(240, 240, 240);
			subView.AddSubview(contentView);
			subView.AddSubview(closeButton);
			subView.AddSubview(propertiesLabel);
			subView.BackgroundColor = UIColor.FromRGB(230, 230, 230);
			this.AddSubview(subView);

			//showPropertyButton
			propertiesLabel.Text = " OPTIONS";
			showPropertyButton.Hidden = true;
			showPropertyButton.SetTitle("OPTIONS\t", UIControlState.Normal);
			showPropertyButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
			showPropertyButton.BackgroundColor = UIColor.FromRGB(230, 230, 230);
			showPropertyButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			showPropertyButton.TouchUpInside += (object sender, EventArgs e) =>
			{
				subView.Hidden = true;
				showPropertyButton.Hidden = false;

			};
			this.AddSubview(showPropertyButton);


			//CloseButton
			closeButton.SetTitle("X\t", UIControlState.Normal);
			closeButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
			closeButton.BackgroundColor = UIColor.FromRGB(230, 230, 230);
			closeButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			closeButton.TouchUpInside += (object sender, EventArgs e) =>
			{
				subView.Hidden = true;
				showPropertyButton.Hidden = false;
			};

			//AddingGesture
			UITapGestureRecognizer tapgesture = new UITapGestureRecognizer(() =>
			{
				subView.Hidden = true;
				showPropertyButton.Hidden = false;
			}
			);
			propertiesLabel.UserInteractionEnabled = true;
			propertiesLabel.AddGestureRecognizer(tapgesture);
		}

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = new CGRect(Frame.X, -2, Frame.Width, Frame.Height);
				subView.Frame = new CGRect (0, 4 *  this.Frame.Size.Height / 5-25, this.Frame.Size.Width, 2 *  this.Frame.Size.Height / 5);
				contentView.Frame=new CGRect(0,40,subView.Frame.Size.Width,subView.Frame.Size.Height-50);
				calendarView.Frame = new CGRect (0, 0,this.Frame.Size.Width,   this.Frame.Size.Height-30);
				calendar.Frame = new CGRect (0, 0, this.Frame.Size.Width, this.Frame.Size.Height-30);
				label_calendarView.Frame = new CGRect ( 110, 70, this.Frame.Size.Width - 220, 30);
				button_calendarView.Frame = new CGRect (350, 70, contentView.Frame.Size.Width-520, 30);		
				selectionPicker.Frame = new CGRect (105,  0, pickerSubView.Frame.Size.Width-200 , 150);
				pickerSubView.Frame = new CGRect (100, 0, contentView.Frame.Size.Width - 200, 150);
				doneButton.Frame = new CGRect(100, 0, contentView.Frame.Size.Width-200, 30);	
				showPropertyButton.Frame = new CGRect (0, this.Frame.Size.Height-25, this.Frame.Size.Width, 30);
				closeButton.Frame = new CGRect (this.Frame.Size.Width - 30, 5, 20, 30);
				propertiesLabel.Frame = new CGRect (10, 5, this.Frame.Width, 30);
			}
			base.LayoutSubviews ();
		}

		private readonly IList<string> _calendarViewsCollection = new List<string>
		{
			"Single Selection",
			"Multi Selection"
		};

		void ShowPicker1 (object sender, EventArgs e) {

			doneButton.Hidden = false;
			selectionPicker.Hidden = false;
			button_calendarView.Hidden = true;
			pickerSubView.Hidden = false;

		}

		void HidePicker (object sender, EventArgs e) {

			doneButton.Hidden = true;
			selectionPicker.Hidden = true;
			button_calendarView.Hidden = false;
			pickerSubView.Hidden = true;

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
				NSString dayname = (NSString)dateFormatter.ToString(now);
				if (dayname.ToString().Equals("Saturday") || dayname.ToString().Equals("Sunday"))
				{
					monthCell.TextColor = UIColor.FromRGB(9, 144, 233);
				}
				if (day.ToString().Equals("15") || day.ToString().Equals("24"))
				{
					UIImageView view = new UIImageView();
					view.Image = UIImage.FromBundle("Shop-Closed.png");
					monthCell.View = view;
				}
				return monthCell;
			}
		}

	}
}
