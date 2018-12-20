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
		private SFCalendar calendar;
		private string selectedType;
		private UILabel labelCalendarView;
		private UIButton buttonCalendarView = new UIButton();
		private UIButton doneButton = new UIButton();
		private UIPickerView pickerCalendarView;

        public UIView Option { get; set; } = new UIView();

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CalendarViews_Mobile()
		{
			calendar = new SFCalendar();
			calendar.ViewMode = SFCalendarViewMode.SFCalendarViewModeMonth;
			calendar.HeaderHeight = 40;
			
            //calendar.Appointments = CreateAppointments ();
			this.AddSubview(calendar);
			this.OptionView1();
		}

		public override void LayoutSubviews()
		{
			foreach (var view in this.Subviews)
            {
				view.Frame = Bounds;
                if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                {
                    var height = this.Frame.Height;
                    pickerCalendarView.Frame = new CGRect(0, 160, 300, 70);
                    doneButton.Frame = new CGRect(0, 100, 300, 40);

                    labelCalendarView.Frame = new CGRect(10, 20, this.Frame.Size.Width - 20, 30);

                    buttonCalendarView.Frame = new CGRect(10, 80, 300, 30);
                }
                else
                {
                    Option.Frame = new CGRect(0, 90, Frame.Width, Frame.Height);
                    labelCalendarView.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y - 20, this.Frame.Size.Width - 20, 30);
                    buttonCalendarView.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 20, this.Frame.Size.Width - 20, 30);
                    pickerCalendarView.Frame = new CGRect(this.Frame.X, this.Frame.Size.Height / 4, this.Frame.Size.Width, this.Frame.Size.Height / 3);
                    doneButton.Frame = new CGRect(0, this.Frame.Size.Height / 4, this.Frame.Size.Width, 40);
                }
			}

			base.LayoutSubviews();
		}

		private void ShowPicker1(object sender, EventArgs e)
        {
			doneButton.Hidden = false;
            pickerCalendarView.Hidden = false;
            buttonCalendarView.Hidden = true;
            labelCalendarView.Hidden = true;
		}

		private void HidePicker(object sender, EventArgs e)
        {
			doneButton.Hidden = true;
            pickerCalendarView.Hidden = true;
            buttonCalendarView.Hidden = false;
            labelCalendarView.Hidden = false;
		}

		private void SelectedIndexChanged1(object sender, PickerChangedEventArgs e)
		{
			this.selectedType = e.SelectedValue;
			if (selectedType == "Month View")
            {
				calendar.ViewMode = SFCalendarViewMode.SFCalendarViewModeMonth;
			}
            else if (selectedType == "Year View")
            {
				calendar.ViewMode = SFCalendarViewMode.SFCalendarViewModeYear;
			}

            buttonCalendarView.SetTitle(selectedType.ToString(), UIControlState.Normal);
		}

		private readonly IList<string> calendarViewsCollection = new List<string>
		{
			"Month View",
			"Year View",
		};

		public void OptionView1()
		{
			//Calendar View
			this.OptionView = new UIView();

            //Intializing configurationc controls
            pickerCalendarView = new UIPickerView();
            labelCalendarView = new UILabel();
            buttonCalendarView = new UIButton();
            pickerCalendarView = new UIPickerView();

			//Picker
			PickerModel model = new PickerModel(calendarViewsCollection);
            pickerCalendarView.Model = model;
            labelCalendarView.Text = "VIEW MODE: ";
            labelCalendarView.TextColor = UIColor.Black;
            labelCalendarView.TextAlignment = UITextAlignment.Left;

            //ViewModeButton
            buttonCalendarView.SetTitle("Month View", UIControlState.Normal);
            buttonCalendarView.SetTitleColor(UIColor.Black, UIControlState.Normal);
            buttonCalendarView.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            buttonCalendarView.Layer.CornerRadius = 8;
            buttonCalendarView.Layer.BorderWidth = 2;
            buttonCalendarView.TouchUpInside += ShowPicker1;
            buttonCalendarView.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;

			//DoneButton
			doneButton.SetTitle("Done\t", UIControlState.Normal);
			doneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			doneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			doneButton.TouchUpInside += HidePicker;
			doneButton.Hidden = true;
			doneButton.BackgroundColor = UIColor.FromRGB(246, 246, 246);

			model.PickerChanged += SelectedIndexChanged1;
            pickerCalendarView.ShowSelectionIndicator = true;
            pickerCalendarView.Hidden = true;

			//settings frame size for sub views

			//adding subviews to the option view
			this.Option.AddSubview(labelCalendarView);
			this.Option.AddSubview(buttonCalendarView);
			this.Option.AddSubview(pickerCalendarView);
			this.Option.AddSubview(doneButton);
		}
	}
}