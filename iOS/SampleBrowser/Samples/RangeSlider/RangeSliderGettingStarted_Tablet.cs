#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using Syncfusion.SfRangeSlider.iOS;
using System.Collections.Generic;


#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;

#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using nint = System.Int32;
using nuint = System.Int32;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
using nfloat  = System.Single;
#endif

namespace SampleBrowser
{
	public class RangeSliderGettingStarted_Tablet : SampleView
	{
		SfRangeSlider rangeSlider1,rangeSlider2;
		UILabel departureLabel,arrivalLabel,ticksLabel,placementLabel,timeLabel1,showLabel,snapsToLabel,timeLabel2,timeLabel3;
		UIButton positionbutton = new UIButton ();
		UIButton positionbutton1 = new UIButton ();
		UIButton doneButton=new UIButton();
		UIButton closeButton=new UIButton();
		UIButton showPropertyButton=new UIButton();
		UILabel propertiesLabel=new UILabel();
		UILabel headingLabel=new UILabel();
		UIView subView=new UIView();
		UIView contentView = new UIView ();
		UIView controlView = new UIView ();
		UIPickerView positionPicker1, positionPicker2;
		UISwitch labelswitch, labelswitch1;
		private string selectedType;
		private readonly IList<string> TAlignment = new List<string>
		{
			"BottomRight",
			"TopLeft",
			"Inline",
			"Outside",
			"None"
		};
		private readonly IList<string> LAlignment = new List<string>
		{
			"BottomRight",
			"TopLeft"
		};
		public RangeSliderGettingStarted_Tablet()
		{
			//RangeSlider 1
			rangeSlider1 = new SfRangeSlider();
			rangeSlider1.Maximum = 12;
			rangeSlider1.Minimum = 0;
			rangeSlider1.RangeStart = 0;
			rangeSlider1.RangeEnd = 12;
			rangeSlider1.TickPlacement = SFTickPlacement.SFTickPlacementBottomRight;
			rangeSlider1.TickFrequency = 2;
			rangeSlider1.ToolTipPlacement = SFToolTipPlacement.SFToolTipPlacementTopLeft;
			rangeSlider1.ValuePlacement = SFValuePlacement.SFValuePlacementBottomRight;
			rangeSlider1.SnapsTo = SFSnapsTo.SFSnapsToNone;
			rangeSlider1.KnobColor = UIColor.White;
			rangeSlider1.TrackSelectionColor = UIColor.FromRGB (65, 115, 185);
			rangeSlider1.TrackColor = UIColor.FromRGB (182, 182, 182);


			//RangeSlider 2
			rangeSlider2 = new SfRangeSlider();
			rangeSlider2.Frame = new CGRect (10, 100, this.Frame.Size.Width, this.Frame.Size.Height);
			rangeSlider2.Maximum = 12;
			rangeSlider2.Minimum = 0;
			rangeSlider2.RangeStart = 0;
			rangeSlider2.RangeEnd = 12;
			rangeSlider2.TickPlacement = SFTickPlacement.SFTickPlacementBottomRight;
			rangeSlider2.TickFrequency = 2;
			rangeSlider2.ValuePlacement = SFValuePlacement.SFValuePlacementBottomRight;
			rangeSlider2.ToolTipPlacement = SFToolTipPlacement.SFToolTipPlacementTopLeft;
			rangeSlider2.SnapsTo = SFSnapsTo.SFSnapsToNone;
			rangeSlider2.KnobColor = UIColor.White;
			rangeSlider2.TrackSelectionColor = UIColor.FromRGB (65, 115, 185);
			rangeSlider2.TrackColor = UIColor.FromRGB (182, 182, 182);

			controlView.AddSubview (rangeSlider1);
			controlView.AddSubview (rangeSlider2);
			rangeSlider2.RangeValueChange += Slider_RangeValueChange;
			rangeSlider1.RangeValueChange += Slider_RangeValueChange;
			this.AddSubview (controlView);
			mainPageDesign();
			loadOptionView();
		}

		public void mainPageDesign()
		{ 
			//headingLabel
			headingLabel.Text = "RangeSlider";
			headingLabel.Font = UIFont.FromName("Helvetica", 20f);

			//departureLabel
			departureLabel = new UILabel();
			departureLabel.Text = "Departure";
			departureLabel.TextColor = UIColor.Black;
			departureLabel.TextAlignment = UITextAlignment.Left;
			departureLabel.Font = UIFont.FromName("Helvetica", 18f);

			//tickLabel
			ticksLabel = new UILabel();
			ticksLabel.Text = "Tick Placement";
			ticksLabel.Font = UIFont.FromName("Helvetica", 14f);
			ticksLabel.TextColor = UIColor.Black;
			ticksLabel.TextAlignment = UITextAlignment.Left;

			//PlacementLabel
			placementLabel = new UILabel();
			placementLabel.Text = "Label Placement";
			placementLabel.Font = UIFont.FromName("Helvetica", 14f);
			placementLabel.TextColor = UIColor.Black;
			placementLabel.TextAlignment = UITextAlignment.Left;

			//TimeLabel 1
			timeLabel1 = new UILabel();
			timeLabel1.Text = "(in Hours)";
			timeLabel1.TextColor = UIColor.Gray;
			timeLabel1.TextAlignment = UITextAlignment.Left;
			timeLabel1.Font = UIFont.FromName("Helvetica", 14f);

			//TimeLabel 2
			timeLabel2 = new UILabel();
			timeLabel2.Text = "(in Hours)";
			timeLabel2.TextColor = UIColor.Gray;
			timeLabel2.TextAlignment = UITextAlignment.Left;
			timeLabel2.Font = UIFont.FromName("Helvetica", 14f);

			//SnapsToLabel 
			snapsToLabel = new UILabel();
			snapsToLabel.Text = "Snap To Tick";
			snapsToLabel.Font = UIFont.FromName("Helvetica", 14f);
			snapsToLabel.TextColor = UIColor.Black;
			snapsToLabel.TextAlignment = UITextAlignment.Left;

			//TimeLabel 2
			timeLabel2 = new UILabel();
			timeLabel2.Text = "Time: 12 AM - 12 PM";
			timeLabel2.TextColor = UIColor.Gray;
			timeLabel2.TextAlignment = UITextAlignment.Left;
			timeLabel2.Font = UIFont.FromName("Helvetica", 14f);

			//TimleLabel 3
			timeLabel3 = new UILabel();
			timeLabel3.Text = "Time: 12 AM - 12 PM";
			timeLabel3.TextColor = UIColor.Gray;
			timeLabel3.TextAlignment = UITextAlignment.Left;
			timeLabel3.Font = UIFont.FromName("Helvetica", 14f);

			//PositionButtton
			positionbutton = new UIButton();
			positionbutton.SetTitle("BottomRight", UIControlState.Normal);
			positionbutton.Font = UIFont.FromName("Helvetica", 14f);
			positionbutton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			positionbutton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			positionbutton.Layer.CornerRadius = 8;
			positionbutton.Layer.BorderWidth = 2;
			positionbutton.TouchUpInside += ShowPicker1;
			positionbutton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;

			//PositionButton 1
			positionbutton1 = new UIButton();
			positionbutton1.SetTitle("BottomRight", UIControlState.Normal);
			positionbutton1.Font = UIFont.FromName("Helvetica", 14f);
			positionbutton1.SetTitleColor(UIColor.Black, UIControlState.Normal);
			positionbutton1.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			positionbutton1.Layer.CornerRadius = 8;
			positionbutton1.Layer.BorderWidth = 2;
			positionbutton1.TouchUpInside += ShowPicker2;
			positionbutton1.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;

			//DoneButton
			doneButton.SetTitle("Done\t", UIControlState.Normal);
			doneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			doneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			doneButton.TouchUpInside += HidePicker;
			doneButton.Hidden = true;
			doneButton.Font = UIFont.FromName("Helvetica", 14f);
			doneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);

			//ShowLabel
			showLabel = new UILabel();
			showLabel.Text = "Show Label";
			showLabel.Font = UIFont.FromName("Helvetica", 14f);
			showLabel.TextColor = UIColor.Black;
			showLabel.TextAlignment = UITextAlignment.Left;

			//LabelSwitch
			labelswitch = new UISwitch();
			labelswitch.On = true;
			labelswitch.OnTintColor = UIColor.FromRGB(50, 150, 221);
			labelswitch.ValueChanged += toggleChanged;

			//LabelSwitch 1
			labelswitch1 = new UISwitch();
			labelswitch1.OnTintColor = UIColor.FromRGB(50, 150, 221);
			labelswitch1.On = false;
			labelswitch1.ValueChanged += toggleChanged1;

			//ArrivalLabel 
			arrivalLabel = new UILabel();
			arrivalLabel.Text = "Arrival";
			arrivalLabel.TextColor = UIColor.Black;
			arrivalLabel.TextAlignment = UITextAlignment.Left;
			arrivalLabel.Font = UIFont.FromName("Helvetica", 18f);

			//PositionPicker 1
			positionPicker1 = new UIPickerView();
			PickerModel model = new PickerModel(TAlignment);
			model.PickerChanged += SelectedIndexChanged;
			positionPicker1.Model = model;
			positionPicker1.ShowSelectionIndicator = true;
			positionPicker1.Hidden = true;
			positionPicker1.BackgroundColor = UIColor.Gray;

			//PositionPicker 2
			positionPicker2 = new UIPickerView();
			PickerModel model1 = new PickerModel(LAlignment);
			model1.PickerChanged += SelectedIndexChanged1;
			positionPicker2.Model = model1;
			positionPicker2.ShowSelectionIndicator = true;
			positionPicker2.BackgroundColor = UIColor.Gray;
			positionPicker2.Hidden = true;

			//Adding to control view
			controlView.AddSubview(departureLabel);
			controlView.AddSubview(arrivalLabel);
			controlView.AddSubview(timeLabel1);
			controlView.AddSubview(timeLabel2);
			controlView.AddSubview(timeLabel2);
			controlView.AddSubview(timeLabel3);

		}

		public void loadOptionView()
		{
			//Adding to contentView
			propertiesLabel.Text = "OPTIONS";
			contentView.AddSubview(ticksLabel);
			contentView.AddSubview(positionbutton);
			contentView.AddSubview(placementLabel);
			contentView.AddSubview(positionbutton1);
			contentView.AddSubview(positionPicker1);
			contentView.AddSubview(positionPicker2);
			contentView.AddSubview(doneButton);
			contentView.AddSubview(showLabel);
			contentView.AddSubview(labelswitch);
			contentView.AddSubview(snapsToLabel);
			contentView.AddSubview(labelswitch1);

			//Adding to SubView
			subView.AddSubview(contentView);
			contentView.BackgroundColor = UIColor.FromRGB(240, 240, 240);
			subView.AddSubview(closeButton);
			subView.AddSubview(propertiesLabel);
			subView.BackgroundColor = UIColor.FromRGB(230, 230, 230);
			this.AddSubview(subView);

			//ShowPropertyButton
			showPropertyButton.Hidden = true;
			showPropertyButton.SetTitle("OPTIONS\t", UIControlState.Normal);
			showPropertyButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
			showPropertyButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
			showPropertyButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			showPropertyButton.TouchUpInside += (object sender, EventArgs e) =>
			{
				subView.Hidden = false;
				showPropertyButton.Hidden = true;
			};
			this.AddSubview(showPropertyButton);


			//closeButton
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
		void Slider_RangeValueChange(object sender, RangeEventArgs e)
		{
			SetValue(sender as SfRangeSlider, e.RangeStart, e.RangeEnd);
		}
		public void SetValue(SfRangeSlider r,nfloat start, nfloat end)
		{
			if (r == rangeSlider1) {
				if (Math.Round (start) < 1) {
					if (Math.Round (end) == 12)
						timeLabel2.Text = "Time: 12 AM - " + Math.Round (end) + " PM";
					else
						timeLabel2.Text = "Time: 12 AM - " + Math.Round (end) + " AM";
				} else {
					if (Math.Round (end) == 12)
						timeLabel2.Text = "Time: " + Math.Round (start) + " AM - " + Math.Round (end) + " PM";
					else
						timeLabel2.Text = "Time: " + Math.Round (start) + " AM - " + Math.Round (end) + " AM";
				}
				if (Math.Round (start) == Math.Round (end)) {
					if (Math.Round (start) < 1)
						timeLabel2.Text = "Time: 12 AM";
					else if (Math.Round (start) == 12)
						timeLabel2.Text = "Time: 12 PM";
					else
						timeLabel2.Text = "Time: " + Math.Round (start) + " AM";
				}

			} 
			else if(r==rangeSlider2){
				if (Math.Round (start) < 1) {
					if (Math.Round (end) == 12)
						timeLabel3.Text = "Time: 12 AM - " + Math.Round (end) + " PM";
					else
						timeLabel3.Text = "Time: 12 AM - " + Math.Round (end) + " AM";
				} else {
					if (Math.Round (end) == 12)
						timeLabel3.Text = "Time: " + Math.Round (start) + " AM - " + Math.Round (end) + " PM";
					else
						timeLabel3.Text = "Time: " + Math.Round (start) + " AM - " + Math.Round (end) + " AM";
				}
				if (Math.Round (start) == Math.Round (end)) {
					if (Math.Round (start) < 1)
						timeLabel3.Text = "Time: 12 AM";
					else if (Math.Round (start) == 12)
						timeLabel3.Text = "Time: 12 PM";
					else
						timeLabel3.Text = "Time: " + Math.Round (start) + " AM";
				}

			}

		}

		public override void LayoutSubviews ()
		{

			foreach (var view in this.Subviews) {
				view.Frame = Bounds;
				subView.Frame = new CGRect (0,view.Frame.Size.Height-view.Frame.Size.Height/3,  view.Frame.Size.Width, view.Frame.Size.Height/3);
				controlView.Frame=new CGRect(100,40,this.Frame.Size.Width-200,this.Frame.Size.Height-40);
				contentView.Frame=new CGRect(0,40,subView.Frame.Size.Width,subView.Frame.Size.Height-20);
				headingLabel.Frame = new CGRect (10, 10, 120, 30);
				departureLabel.Frame = new CGRect (this.Frame.X + 10, 45,85, 30);
				arrivalLabel.Frame = new CGRect (this.Frame.X + 10,210, 80, 30);
				timeLabel1.Frame = new CGRect (this.Frame.X + 95, 45, this.Frame.Size.Width-20, 30);
				timeLabel2.Frame = new CGRect (this.Frame.X + 65, 210, 85, 30);
				timeLabel2.Frame = new CGRect (this.Frame.X + 10, 75,150, 30);
				timeLabel3.Frame = new CGRect (this.Frame.X + 10,240, 150, 30);
				rangeSlider1.Frame = new CGRect (2, 105, controlView.Frame.Size.Width - 4,  100);
				rangeSlider2.Frame = new CGRect (2, 265, controlView.Frame.Size.Width - 4, 100);


				ticksLabel.Frame = new CGRect (110, 50, contentView.Frame.Size.Width - 220, 30);
				positionbutton.Frame=new CGRect(350, 50, contentView.Frame.Size.Width - 520, 30);	
				placementLabel.Frame = new CGRect (110, 90, contentView.Frame.Size.Width - 220, 30);
				positionbutton1.Frame=new CGRect(350, 90, contentView.Frame.Size.Width - 520, 30);	
				positionPicker1.Frame = new CGRect (100, 20, contentView.Frame.Size.Width-200, 200);
				positionPicker2.Frame = new CGRect (100, 20, contentView.Frame.Size.Width-200 , 200);
				showLabel.Frame = new CGRect (110, 130, contentView.Frame.Size.Width - 220, 30);
				labelswitch.Frame = new CGRect (350, 130, labelswitch.Frame.Width-200, 30);
				snapsToLabel.Frame = new CGRect (110, 170, contentView.Frame.Size.Width - 220, 30);
				labelswitch1.Frame = new CGRect (350, 170, labelswitch.Frame.Width-200, 30);
				doneButton.Frame = new CGRect (100, 20, contentView.Frame.Size.Width-200, 30);
				showPropertyButton.Frame = new CGRect (0, this.Frame.Size.Height-25, this.Frame.Size.Width, 30);
				closeButton.Frame = new CGRect (this.Frame.Size.Width - 30, 5, 20, 30);
				propertiesLabel.Frame = new CGRect (10, 5, this.Frame.Width, 30);
			}
			base.LayoutSubviews ();
		}


		void ShowPicker1 (object sender, EventArgs e) {

			doneButton.Hidden = false;
			positionPicker1.Hidden = false;
			positionPicker2.Hidden = true;
			positionbutton.Hidden = true;
			placementLabel.Hidden = true;
			positionbutton1.Hidden = true;
			ticksLabel.Hidden = true;
			labelswitch.Hidden = true;
			showLabel.Hidden = true;
			snapsToLabel.Hidden = true;
			labelswitch1.Hidden = true;
		}

		void HidePicker (object sender, EventArgs e) {

			doneButton.Hidden = true;
			positionPicker2.Hidden = true;
			positionPicker1.Hidden = true;
			positionbutton.Hidden = false;
			placementLabel.Hidden = false;
			positionbutton1.Hidden = false;
			labelswitch.Hidden = false;
			showLabel.Hidden = false;
			ticksLabel.Hidden = false;
			snapsToLabel.Hidden = false;
			labelswitch1.Hidden = false;
		}

		void ShowPicker2 (object sender, EventArgs e) {

			doneButton.Hidden = false;
			positionPicker1.Hidden = true;
			positionPicker2.Hidden = false;
			positionbutton.Hidden = true;
			placementLabel.Hidden = true;
			positionbutton1.Hidden = true;
			ticksLabel.Hidden = true;
			labelswitch.Hidden = true;
			showLabel.Hidden = true;
			snapsToLabel.Hidden = true;
			labelswitch1.Hidden = true;
		}

		private void SelectedIndexChanged(object sender, PickerChangedEventArgs e)
		{
			this.selectedType = e.SelectedValue;
			positionbutton.SetTitle (selectedType, UIControlState.Normal);
			if (selectedType == "TopLeft") {
				rangeSlider1.TickPlacement = SFTickPlacement.SFTickPlacementTopLeft;
				rangeSlider2.TickPlacement = SFTickPlacement.SFTickPlacementTopLeft;
			} else if (selectedType == "BottomRight") {
				rangeSlider1.TickPlacement = SFTickPlacement.SFTickPlacementBottomRight;
				rangeSlider2.TickPlacement = SFTickPlacement.SFTickPlacementBottomRight;
			} else if (selectedType == "Inline") {
				rangeSlider1.TickPlacement = SFTickPlacement.SFTickPlacementInline;
				rangeSlider2.TickPlacement = SFTickPlacement.SFTickPlacementInline;
			} else if (selectedType == "Outside") {
				rangeSlider1.TickPlacement = SFTickPlacement.SFTickPlacementOutSide;
				rangeSlider2.TickPlacement = SFTickPlacement.SFTickPlacementOutSide;
			} else if (selectedType == "None") {
				rangeSlider1.TickPlacement = SFTickPlacement.SFTickPlacementNone;
				rangeSlider2.TickPlacement = SFTickPlacement.SFTickPlacementNone;
			} 
		}

		private void SelectedIndexChanged1(object sender, PickerChangedEventArgs e)
		{
			this.selectedType = e.SelectedValue;
			positionbutton1.SetTitle (selectedType, UIControlState.Normal);
			if (selectedType == "TopLeft") {
				rangeSlider1.ValuePlacement = SFValuePlacement.SFValuePlacementTopLeft;
				rangeSlider2.ValuePlacement = SFValuePlacement.SFValuePlacementTopLeft;
			} else if (selectedType == "BottomRight") {
				rangeSlider1.ValuePlacement = SFValuePlacement.SFValuePlacementBottomRight;
				rangeSlider2.ValuePlacement = SFValuePlacement.SFValuePlacementBottomRight;
			}
		}

		private void toggleChanged(object sender, EventArgs e)
		{
			if (((UISwitch)sender).On) {
				rangeSlider1.ShowValueLabel = true;
				rangeSlider2.ShowValueLabel = true;
			} else {
				rangeSlider1.ShowValueLabel = false;
				rangeSlider2.ShowValueLabel = false;
			}
		}

		private void toggleChanged1(object sender, EventArgs e)
		{
			if (((UISwitch)sender).On) {
				rangeSlider1.SnapsTo = SFSnapsTo.SFSnapsToTicks;
				rangeSlider2.SnapsTo = SFSnapsTo.SFSnapsToTicks;
			} else {
				rangeSlider1.SnapsTo = SFSnapsTo.SFSnapsToNone;
				rangeSlider2.SnapsTo = SFSnapsTo.SFSnapsToNone;
			}
		}
	}
}