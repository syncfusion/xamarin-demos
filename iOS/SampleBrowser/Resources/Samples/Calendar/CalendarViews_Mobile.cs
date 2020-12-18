#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfCalendar.iOS;
using System.Collections.Generic;


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
	public class CalendarViews_Mobile : SampleView
	{
		SFCalendar calendar;
		private string selectedType;
		UILabel label_calendarView;
		UIButton button_calendarView = new UIButton ();
		UIButton doneButton=new UIButton();
		UIPickerView picker_calendarView;
		public UIView option=new UIView();
		public CalendarViews_Mobile ()
		{
			calendar= new SFCalendar ();
			calendar.ViewMode = SFCalendarViewMode.SFCalendarViewModeMonth;
			calendar.HeaderHeight = 40;
			//calendar.Appointments = CreateAppointments ();
			this.AddSubview (calendar);
			this.optionView();


		}

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Bounds;
				option.Frame = new CGRect (0, 90, Frame.Width, Frame.Height);
				label_calendarView.Frame = new CGRect (this.Frame.X + 10, this.Frame.Y - 20, this.Frame.Size.Width - 20, 30);
				button_calendarView.Frame = new CGRect (this.Frame.X + 10, this.Frame.Y + 20, this.Frame.Size.Width - 20, 30);	
				picker_calendarView.Frame = new CGRect (this.Frame.X, this.Frame.Size.Height/4, this.Frame.Size.Width , this.Frame.Size.Height/3);
				doneButton.Frame = new CGRect(0, this.Frame.Size.Height/4, this.Frame.Size.Width, 40);
			}
			base.LayoutSubviews ();
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
			if (selectedType == "Month View") {
				calendar.ViewMode = SFCalendarViewMode.SFCalendarViewModeMonth;
			} else if (selectedType == "Year View") {
				calendar.ViewMode = SFCalendarViewMode.SFCalendarViewModeYear;
			}

			button_calendarView.SetTitle(selectedType.ToString(),UIControlState.Normal);
		}

		private readonly IList<string> _calendarViewsCollection = new List<string>
		{
			"Month View",
			"Year View",
		};

		public void  optionView()
		{

			//Calendar View
			this.OptionView = new UIView();

			//Intializing configurationc controls
			picker_calendarView = new UIPickerView();
			label_calendarView = new UILabel();
			button_calendarView = new UIButton();
			picker_calendarView = new UIPickerView();

			//Picker
			PickerModel model = new PickerModel (_calendarViewsCollection);
			picker_calendarView.Model = model;
			label_calendarView.Text = "View Mode: ";
			label_calendarView.TextColor = UIColor.Black;
			label_calendarView.TextAlignment = UITextAlignment.Left;

			//ViewModeButton
			button_calendarView.SetTitle ("Month View", UIControlState.Normal);
			button_calendarView.SetTitleColor (UIColor.Black, UIControlState.Normal);
			button_calendarView.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			button_calendarView.Layer.CornerRadius = 8;
			button_calendarView.Layer.BorderWidth = 2;
			button_calendarView.TouchUpInside += ShowPicker1;
			button_calendarView.Layer.BorderColor = UIColor.FromRGB (246, 246, 246).CGColor;

			//DoneButton
			doneButton.SetTitle ("Done\t", UIControlState.Normal);
			doneButton.SetTitleColor (UIColor.Black, UIControlState.Normal);
			doneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			doneButton.TouchUpInside += HidePicker;
			doneButton.Hidden = true;
			doneButton.BackgroundColor = UIColor.FromRGB (246, 246, 246);

			model.PickerChanged += SelectedIndexChanged1;
			picker_calendarView.ShowSelectionIndicator = true;
			picker_calendarView.Hidden = true;


			//settings frame size for sub views


			//adding subviews to the option view
			this.option.AddSubview (label_calendarView);
			this.option.AddSubview (button_calendarView);
			this.option.AddSubview (picker_calendarView);
			this.option.AddSubview (doneButton);
		}
	}
}

