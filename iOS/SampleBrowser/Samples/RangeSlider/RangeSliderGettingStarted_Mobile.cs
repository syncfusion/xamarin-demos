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
	public class RangeSliderGettingStarted_Mobile : SampleView
	{
		SfRangeSlider rangeSlider1, rangeSlider2;
		UILabel departureLabel,arrivalLabel,ticksLabel,placementLabel,timeLabel1,showLabel,snapsToLabel,timeLabel2,timeLabel3;
		UIButton positionbutton = new UIButton ();
		UIButton positionbutton1 = new UIButton ();
		UIButton doneButton=new UIButton();
		UIPickerView positionPicker1, positionPicker2;
		UISwitch labelswitch, labelswitch1;
		public UIView option=new UIView();
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
		public void  optionView()
		{

			this.option.AddSubview (ticksLabel);
			this.option.AddSubview (positionbutton);
			this.option.AddSubview (placementLabel);
			this.option.AddSubview (positionbutton1);
			this.option.AddSubview (positionPicker1);
			this.option.AddSubview (positionPicker2);
			this.option.AddSubview (doneButton);
			this.option.AddSubview (showLabel);
			this.option.AddSubview (labelswitch);
			this.option.AddSubview (snapsToLabel);
			this.option.AddSubview (labelswitch1);
		}

		public RangeSliderGettingStarted_Mobile ()
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
			rangeSlider2.Frame = new CGRect(10, 100, this.Frame.Size.Width, this.Frame.Size.Height);
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
			rangeSlider2.TrackSelectionColor = UIColor.FromRGB(65, 115, 185);
			rangeSlider2.TrackColor = UIColor.FromRGB(182, 182, 182);
			rangeSlider2.RangeValueChange += Slider_RangeValueChange;
			rangeSlider1.RangeValueChange += Slider_RangeValueChange;
			this.AddSubview(rangeSlider1);
			this.AddSubview(rangeSlider2);
			mainPageDesign();
			this.optionView();


		}
		void Slider_RangeValueChange(object sender, RangeEventArgs e)
		{
			SetValue(sender as SfRangeSlider,e.RangeStart,e.RangeEnd);
		}
		public void mainPageDesign()
		{
			//DepartureLabel
			departureLabel = new UILabel();
			departureLabel.Text = "Departure";
			departureLabel.TextColor = UIColor.Black;
			departureLabel.TextAlignment = UITextAlignment.Left;
			departureLabel.Font = UIFont.FromName("Helvetica", 18f);

			//TicksLabel
			ticksLabel = new UILabel();
			ticksLabel.Text = "Tick Placement";
			ticksLabel.TextColor = UIColor.Black;
			ticksLabel.TextAlignment = UITextAlignment.Left;

			//placementLabell
			placementLabel = new UILabel();
			placementLabel.Text = "Label Placement";
			placementLabel.TextColor = UIColor.Black;
			placementLabel.TextAlignment = UITextAlignment.Left;

 			//timeLabel11
			timeLabel1 = new UILabel();
			timeLabel1.Text = "(in Hours)";
			timeLabel1.TextColor = UIColor.Gray;
			timeLabel1.TextAlignment = UITextAlignment.Left;
			timeLabel1.Font = UIFont.FromName("Helvetica", 14f);

			//TimeLabel2
			timeLabel2 = new UILabel();
			timeLabel2.Text = "(in Hours)";
			timeLabel2.TextColor = UIColor.Gray;
			timeLabel2.TextAlignment = UITextAlignment.Left;
			timeLabel2.Font = UIFont.FromName("Helvetica", 14f);

			//snapsToLabel
			snapsToLabel = new UILabel();
			snapsToLabel.Text = "Snap To Tick";
			snapsToLabel.TextColor = UIColor.Black;
			snapsToLabel.TextAlignment = UITextAlignment.Left;

			//TimeLabel 2
			timeLabel2 = new UILabel();
			timeLabel2.Text = "Time: 12 AM - 12 PM";
			timeLabel2.TextColor = UIColor.Gray;
			timeLabel2.TextAlignment = UITextAlignment.Left;
			timeLabel2.Font = UIFont.FromName("Helvetica", 14f);

			//TimeLabel 3
			timeLabel3 = new UILabel();
			timeLabel3.Text = "Time: 12 AM - 12 PM";
			timeLabel3.TextColor = UIColor.Gray;
			timeLabel3.TextAlignment = UITextAlignment.Left;
			timeLabel3.Font = UIFont.FromName("Helvetica", 14f);

			//PostionButton
			positionbutton = new UIButton();
			positionbutton.SetTitle("BottomRight", UIControlState.Normal);
			positionbutton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			positionbutton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			positionbutton.Layer.CornerRadius = 8;
			positionbutton.Layer.BorderWidth = 2;
			positionbutton.TouchUpInside += ShowPicker1;
			positionbutton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;

			//PositionButton1
			positionbutton1 = new UIButton();
			positionbutton1.SetTitle("BottomRight", UIControlState.Normal);
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
			doneButton.BackgroundColor = UIColor.FromRGB(246, 246, 246);

			//ShowLabel
			showLabel = new UILabel();
			showLabel.Text = "Show Label";
			showLabel.TextColor = UIColor.Black;
			showLabel.TextAlignment = UITextAlignment.Left;

			//LabelSwitch
			labelswitch = new UISwitch();
			labelswitch.On = true;
			labelswitch.ValueChanged += toggleChanged;

			//labelSwitch 1
			labelswitch1 = new UISwitch();
			labelswitch1.On = false;
			labelswitch1.ValueChanged += toggleChanged1;

			//ArrivalLabel
			arrivalLabel = new UILabel();
			arrivalLabel.Text = "Arrival";
			arrivalLabel.TextColor = UIColor.Black;
			arrivalLabel.TextAlignment = UITextAlignment.Left;
			arrivalLabel.Font = UIFont.FromName("Helvetica", 18f);

			this.OptionView = new UIView();
			//PositionPicker 1
			positionPicker1 = new UIPickerView();
			positionPicker1.ShowSelectionIndicator = true;
			positionPicker1.Hidden = true;
			PickerModel model = new PickerModel(TAlignment);
			model.PickerChanged += SelectedIndexChanged;
			positionPicker1.Model = model;

			//PositionPicker 2
			positionPicker2 = new UIPickerView();
			positionPicker2.ShowSelectionIndicator = true;
			positionPicker2.Hidden = true;
			PickerModel model1 = new PickerModel(LAlignment);
			model1.PickerChanged += SelectedIndexChanged1;
			positionPicker2.Model = model1;

			//Adding to view
			this.AddSubview(departureLabel);
			this.AddSubview(arrivalLabel);
			this.AddSubview(timeLabel1);
			this.AddSubview(timeLabel2);
			this.AddSubview(timeLabel2);
			this.AddSubview(timeLabel3);
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
				this.OptionView.Frame = view.Frame;
				option.Frame = new CGRect (0, 50, Frame.Width, Frame.Height);
				departureLabel.Frame = new CGRect (this.Frame.X + 10, this.Frame.Size.Height/6,85, 30);
				arrivalLabel.Frame = new CGRect (this.Frame.X + 10,this.Frame.Size.Height -(this.Frame.Size.Height/2.5f), 80, 30);
				timeLabel1.Frame = new CGRect (this.Frame.X + 95, this.Frame.Size.Height / 6, this.Frame.Size.Width-20, 30);
				timeLabel2.Frame = new CGRect (this.Frame.X + 65, this.Frame.Size.Height -(this.Frame.Size.Height/2.5f), 85, 30);
				timeLabel2.Frame = new CGRect (this.Frame.X + 10, (this.Frame.Size.Height/6)+30,150, 30);
				timeLabel3.Frame = new CGRect (this.Frame.X + 10,(this.Frame.Size.Height -(this.Frame.Size.Height/2.5f))+30, 150, 30);
				rangeSlider1.Frame = new CGRect (2, (nfloat)(this.Frame.Size.Height/3.5), this.Frame.Size.Width - 4,  100);
				rangeSlider2.Frame = new CGRect (2, this.Frame.Size.Height -(nfloat)(this.Frame.Size.Height/3.5), this.Frame.Size.Width - 4, 100);


				ticksLabel.Frame = new CGRect (10, this.Frame.Y, this.Frame.Size.Width - 20, 25);
				positionbutton.Frame=new CGRect(10, this.Frame.Y+25, this.Frame.Size.Width - 20, 25);	
				placementLabel.Frame = new CGRect (10, this.Frame.Y+55, this.Frame.Size.Width - 20, 25);
				positionbutton1.Frame=new CGRect(10, this.Frame.Y+85, this.Frame.Size.Width - 20, 25);	
				positionPicker1.Frame = new CGRect (this.Frame.X, this.Frame.Size.Height/3, this.Frame.Size.Width, this.Frame.Size.Height/3);
				positionPicker2.Frame = new CGRect (this.Frame.X, this.Frame.Size.Height/3, this.Frame.Size.Width  , this.Frame.Size.Height/3);
				showLabel.Frame = new CGRect (10, this.Frame.Y+110, this.Frame.Size.Width - 20, 25);
				labelswitch.Frame = new CGRect (this.Frame.Size.Width-(labelswitch.Frame.Width)-20, this.Frame.Y+120, labelswitch.Frame.Width, 25);
				snapsToLabel.Frame = new CGRect (10, this.Frame.Y+150, this.Frame.Size.Width - 20, 25);
				labelswitch1.Frame = new CGRect (this.Frame.Size.Width-(labelswitch.Frame.Width)-20, this.Frame.Y+160, labelswitch.Frame.Width, 25);
				doneButton.Frame = new CGRect (0, this.Frame.Y+190, this.Frame.Size.Width, 30);
			}
			base.LayoutSubviews ();
		}


		void ShowPicker1 (object sender, EventArgs e) {

			doneButton.Hidden = false;
			positionPicker1.Hidden = false;
			positionPicker2.Hidden = true;
		}

		void HidePicker (object sender, EventArgs e) {

			doneButton.Hidden = true;
			positionPicker2.Hidden = true;
			positionPicker1.Hidden = true;
		}

		void ShowPicker2 (object sender, EventArgs e) {

			doneButton.Hidden = false;
			positionPicker1.Hidden = true;
			positionPicker2.Hidden = false;
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