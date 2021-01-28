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
	public class CalendarViews_Tablet: SampleView
	{
		SFCalendar calendar;
		private string selectedType;
		UILabel label_calendarView;
		UIView subView = new UIView ();
		UIView calendarView = new UIView ();		
		UIView contentView = new UIView ();
		UIButton button_calendarView = new UIButton ();
		UIButton showPropertyButton = new UIButton ();
		UIButton closeButton = new UIButton ();
		UILabel propertiesLabel = new UILabel ();
		UIButton doneButton=new UIButton();
		UIPickerView picker_calendarView;
		UIView pickerSubView = new UIView ();
		public CalendarViews_Tablet ()
		{
			//Calendar
			calendar= new SFCalendar ();
			calendar.ViewMode = SFCalendarViewMode.SFCalendarViewModeMonth;
			calendar.HeaderHeight = 40;
			calendarView.AddSubview(calendar);

			this.AddSubview (calendarView);
			this.loadOptionView();

		}
		public void loadOptionView()
		{
			//Intializing configurationc controls
			label_calendarView = new UILabel();
			button_calendarView = new UIButton();
			picker_calendarView = new UIPickerView();
			PickerModel model = new PickerModel(_calendarViewsCollection);
			picker_calendarView.Model = model;

			//label
			label_calendarView.Text = "View Mode ";
			label_calendarView.Font = UIFont.FromName("Helvetica", 14f);
			label_calendarView.TextColor = UIColor.Black;
			label_calendarView.TextAlignment = UITextAlignment.Left;

			//button
			button_calendarView.SetTitle("Month View", UIControlState.Normal);
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

			//picker
			model.PickerChanged += SelectedIndexChanged1;
			picker_calendarView.ShowSelectionIndicator = true;
			picker_calendarView.Hidden = true;
			picker_calendarView.BackgroundColor = UIColor.Gray;

			//adding to contentView
			contentView.AddSubview(label_calendarView);
			contentView.AddSubview(button_calendarView);
			pickerSubView.AddSubview(picker_calendarView);

			//pickerSubview
			pickerSubView.BackgroundColor = UIColor.Gray;
			pickerSubView.Hidden = true;
			contentView.AddSubview(pickerSubView);
			contentView.AddSubview(doneButton);
			contentView.BackgroundColor = UIColor.FromRGB(240, 240, 240);

			//adding to subView
			subView.AddSubview(contentView);
			subView.AddSubview(closeButton);
			subView.AddSubview(propertiesLabel);
			subView.BackgroundColor = UIColor.FromRGB(230, 230, 230);
			subView.AddSubview(closeButton);
			subView.AddSubview(propertiesLabel);
			subView.BackgroundColor = UIColor.FromRGB(230, 230, 230);
			this.AddSubview(subView);

			//ShowPropertyButton
			propertiesLabel.Text = "OPTIONS";
			showPropertyButton.Hidden = true;
			showPropertyButton.SetTitle("OPTIONS\t", UIControlState.Normal);
			showPropertyButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
			showPropertyButton.BackgroundColor = UIColor.FromRGB(230, 230, 230);
			showPropertyButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			showPropertyButton.TouchUpInside += (object sender, EventArgs e) =>
			{
				subView.Hidden = false;
				showPropertyButton.Hidden = true;
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
				calendarView.Frame = new CGRect (0, 0,this.Frame.Size.Width, this.Frame.Size.Height-30);
				calendar.Frame = new CGRect (0, 0, this.Frame.Size.Width, this.Frame.Size.Height-30);
				label_calendarView.Frame = new CGRect ( 110, 70, this.Frame.Size.Width - 220, 30);
				button_calendarView.Frame = new CGRect (350, 70, contentView.Frame.Size.Width-520, 30);		
				picker_calendarView.Frame = new CGRect (105,  0, pickerSubView.Frame.Size.Width-200 , 150);
				pickerSubView.Frame = new CGRect (100, 0, contentView.Frame.Size.Width - 200, 150);
				doneButton.Frame = new CGRect(100, 0, contentView.Frame.Size.Width-200, 30);	
				showPropertyButton.Frame = new CGRect (0, this.Frame.Size.Height-25, this.Frame.Size.Width, 30);
				closeButton.Frame = new CGRect (this.Frame.Size.Width - 30, 5, 20, 30);
				propertiesLabel.Frame = new CGRect (10, 5, this.Frame.Width, 30);
			}
			base.LayoutSubviews ();
		}

		void ShowPicker1 (object sender, EventArgs e) {
			doneButton.Hidden = false;
			picker_calendarView.Hidden = false;
			button_calendarView.Hidden = true;
			label_calendarView.Hidden = false;
			pickerSubView.Hidden = false;
		}

		void HidePicker (object sender, EventArgs e) {

			doneButton.Hidden = true;
			picker_calendarView.Hidden = true;
			button_calendarView.Hidden = false;
			label_calendarView.Hidden = false;
			pickerSubView.Hidden = true;
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


	}
}

