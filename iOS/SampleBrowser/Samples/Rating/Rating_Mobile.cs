#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.Collections.Generic;
using Syncfusion.SfRating.iOS;


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
	public class Rating_Mobile : SampleView
	{
		UILabel precisionLabel,toolTipLabel,itemCountLabel;
		UILabel movieRateLabel,walkLabel,timeLabel,descriptionLabel,rateLabel,valueLabel;
		UITextView itemCountTextfield;
		UIImageView image1;
		UIView customView;
		UIButton precisionButton = new UIButton ();
		UIButton toolTipButton = new UIButton ();
		UIButton doneButton=new UIButton();
		UIPickerView precisionPicker, toolTipPicker;
		public UIView option=new UIView();
		private string selectedType;
		SfRating rating2,rating1;
		private readonly IList<string> precisionList = new List<string>
		{
			"Standard",
			"Half",
			"Exact"
		};
		private readonly IList<string> toottipplace = new List<string>
		{
			"TopLeft",
			"BottomRight",
			"None"
		};

		public void optionView()
		{
			this.option.AddSubview (precisionLabel);
			this.option.AddSubview (toolTipLabel);
			this.option.AddSubview (precisionButton);
			this.option.AddSubview (itemCountLabel);
			this.option.AddSubview (toolTipButton);
			this.option.AddSubview (precisionPicker);
			this.option.AddSubview (toolTipPicker);
			this.option.AddSubview (doneButton);
			this.option.AddSubview (itemCountTextfield);

		}
		void Rating_ValueChanged(object sender, ValueChangedEventArgs e)
		{
			UpdateText();
		}
		public Rating_Mobile()
		{
			SfRatingSettings ratingSetting1 = new SfRatingSettings();
			ratingSetting1.RatedStrokeWidth = 2;
			ratingSetting1.UnRatedStrokeWidth = 2;

			//Rating 1
			rating1 = new SfRating ();
			rating1.ItemCount=5;
			rating1.Precision= SFRatingPrecision.Standard;
			rating1.TooltipPlacement= SFRatingTooltipPlacement.None;
			rating1.ItemSize=30;
			rating1.RatingSettings = ratingSetting1;
			rating1.Value = 3;
			rating1.ItemSpacing = 5;
            rating1.EnableAutoSize = true;
			rating1.ValueChanged += Rating_ValueChanged;

			//RatingSettings
			SfRatingSettings ratingSetting = new SfRatingSettings ();
			ratingSetting.RatedFill = UIColor.FromRGB (251,209,10);
			ratingSetting.RatedStroke = UIColor.FromRGB (251,209,10);

			//Rating 2
			rating2 = new SfRating();
			rating2.ItemCount=5;
			rating2.RatingSettings = ratingSetting;
			rating2.Precision = SFRatingPrecision.Half;
			rating2.TooltipPlacement= SFRatingTooltipPlacement.None;
			rating2.ItemSize=10;
			rating2.Readonly=true;
			rating2.Value=(nfloat)3.5;
			rating2.ItemSpacing = 5;

			this.AddSubview (rating1);
			this.AddSubview (rating2);

			mainPageDesign();


		}

		public void mainPageDesign()
		{ 
			customView = new UIView();
			customView.BackgroundColor = UIColor.FromRGB(165, 165, 165);
			this.OptionView = new UIView();
			image1 = new UIImageView();
			precisionPicker = new UIPickerView();
			toolTipPicker = new UIPickerView();
			PickerModel model = new PickerModel(precisionList);
			precisionPicker.Model = model;
			PickerModel model1 = new PickerModel(toottipplace);
			toolTipPicker.Model = model1;
			precisionLabel = new UILabel();
			toolTipLabel = new UILabel();
			itemCountLabel = new UILabel();
			movieRateLabel = new UILabel();
			walkLabel = new UILabel();
			timeLabel = new UILabel();
			descriptionLabel = new UILabel();
			rateLabel = new UILabel();
			valueLabel = new UILabel();
			precisionButton = new UIButton();
			toolTipButton = new UIButton();
			image1.Image = UIImage.FromBundle("Images/walk.png");

			precisionLabel.Text = "Precision";
			precisionLabel.TextColor = UIColor.Black;
			precisionLabel.TextAlignment = UITextAlignment.Left;

			toolTipLabel.Text = "ToolTip Placement";
			toolTipLabel.TextColor = UIColor.Black;
			toolTipLabel.TextAlignment = UITextAlignment.Left;

			itemCountLabel.Text = "Item Count";
			itemCountLabel.TextColor = UIColor.Black;
			itemCountLabel.TextAlignment = UITextAlignment.Left;
			itemCountLabel.Font = UIFont.FromName("Helvetica", 14f);

			movieRateLabel.Text = "Movie Rating";
			movieRateLabel.TextColor = UIColor.Black;
			movieRateLabel.TextAlignment = UITextAlignment.Left;
			movieRateLabel.Font = UIFont.FromName("Helvetica", 22f);

			walkLabel.Text = "The Walk (2015)";
			walkLabel.TextColor = UIColor.Black;
			walkLabel.TextAlignment = UITextAlignment.Left;
			walkLabel.Font = UIFont.FromName("Helvetica", 18f);

			timeLabel.Text = "PG | 2 h 20 min";
			timeLabel.TextColor = UIColor.Black;
			timeLabel.TextAlignment = UITextAlignment.Left;
			timeLabel.Font = UIFont.FromName("Helvetica", 10f);

			descriptionLabel.Text = "In 1974, high-wire artist Philippe Petit recruits a team of people to help him realize his dream: to walk the immense void between the world Trade Centre towers.";
			descriptionLabel.TextColor = UIColor.Black;
			descriptionLabel.TextAlignment = UITextAlignment.Left;
			descriptionLabel.Font = UIFont.FromName("Helvetica", 12f);
			descriptionLabel.LineBreakMode = UILineBreakMode.WordWrap;
			descriptionLabel.Lines = 0;

			rateLabel.Text = "Rate";
			rateLabel.TextColor = UIColor.Black;
			rateLabel.TextAlignment = UITextAlignment.Left;
			rateLabel.Font = UIFont.FromName("Helvetica", 18f);

			valueLabel.TextColor = UIColor.Black;
			valueLabel.TextAlignment = UITextAlignment.Left;
			valueLabel.Font = UIFont.FromName("Helvetica", 14f);
			UpdateText();

			precisionButton.SetTitle("Standard", UIControlState.Normal);
			precisionButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			precisionButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			precisionButton.Layer.CornerRadius = 8;
			precisionButton.Layer.BorderWidth = 2;
			precisionButton.TouchUpInside += ShowPicker1;
			precisionButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;

			toolTipButton.SetTitle("None", UIControlState.Normal);
			toolTipButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			toolTipButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			toolTipButton.Layer.CornerRadius = 8;
			toolTipButton.Layer.BorderWidth = 2;
			toolTipButton.TouchUpInside += ShowPicker2;
			toolTipButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;

			doneButton.SetTitle("Done\t", UIControlState.Normal);
			doneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			doneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			doneButton.TouchUpInside += HidePicker;
			doneButton.Hidden = true;
			doneButton.BackgroundColor = UIColor.FromRGB(246, 246, 246);

			model.PickerChanged += SelectedIndexChanged;
			model1.PickerChanged += SelectedIndexChanged1;
			precisionPicker.ShowSelectionIndicator = true;
			precisionPicker.Hidden = true;
			toolTipPicker.Hidden = true;
			//precisionPicker.BackgroundColor = UIColor.Gray;
			//toolTipPicker.BackgroundColor = UIColor.Gray;
			toolTipPicker.ShowSelectionIndicator = true;

			itemCountTextfield = new UITextView();
			itemCountTextfield.TextAlignment = UITextAlignment.Center;
			itemCountTextfield.Layer.BorderColor = UIColor.Black.CGColor;
			itemCountTextfield.BackgroundColor = UIColor.FromRGB(246, 246, 246);
			itemCountTextfield.KeyboardType = UIKeyboardType.NumberPad;
			itemCountTextfield.Text = "5";
			itemCountTextfield.Changed += (object sender, EventArgs e) =>
			 {
				 if (itemCountTextfield.Text.Length > 0)
				 {
					 rating1.ItemCount = int.Parse(itemCountTextfield.Text);
				 }
				 else {
					 rating1.ItemCount = 5;
				 }
				 UpdateText();
			 };

			this.AddSubview(movieRateLabel);
			this.AddSubview(walkLabel);
			this.AddSubview(timeLabel);
			this.AddSubview(descriptionLabel);
			this.AddSubview(rateLabel);
			this.AddSubview(valueLabel);
			this.AddSubview(image1);
			this.AddSubview(itemCountTextfield);
		}
		private void UpdateText()
		{
			nint tempIntValue = (nint)rating1.Value;
			nfloat tempFloatValue = rating1.Value;
			nfloat differencevalue = tempFloatValue - tempIntValue;
			if(differencevalue == 0)
				valueLabel.Text = "Rating : "+tempIntValue+" / "+rating1.ItemCount;
			else
				valueLabel.Text = "Rating : "+ Math.Round (tempFloatValue,1)+" / "+rating1.ItemCount;
		}

		void ShowPicker1 (object sender, EventArgs e) {
			doneButton.Hidden = false;
			precisionPicker.Hidden = false;
			toolTipPicker.Hidden = true;
			itemCountLabel.Hidden = true;
			itemCountTextfield.Hidden = true;
		}

		void HidePicker (object sender, EventArgs e) {

			doneButton.Hidden = true;
			toolTipPicker.Hidden = true;
			precisionPicker.Hidden = true;
			itemCountLabel.Hidden = false;
			itemCountTextfield.Hidden = false;
		}

		void ShowPicker2 (object sender, EventArgs e) {
			doneButton.Hidden = false;
			precisionPicker.Hidden = true;
			toolTipPicker.Hidden = false;
			itemCountLabel.Hidden = true;
			itemCountTextfield.Hidden = true;
		}

		private void SelectedIndexChanged(object sender, PickerChangedEventArgs e)
		{
			this.selectedType = e.SelectedValue;
			precisionButton.SetTitle (selectedType, UIControlState.Normal);
			if (selectedType == "Standard") {
				rating1.Precision = SFRatingPrecision.Standard;
			} else if (selectedType == "Half") {
				rating1.Precision = SFRatingPrecision.Half;
			} else if (selectedType == "Exact") {
				rating1.Precision = SFRatingPrecision.Exact;
			} 
		}

		public override void TouchesBegan (NSSet touches, UIEvent evt){
			this.EndEditing (true);
		}

		private void SelectedIndexChanged1(object sender, PickerChangedEventArgs e)
		{
			this.selectedType = e.SelectedValue;
			toolTipButton.SetTitle (selectedType, UIControlState.Normal);
			if (selectedType == "TopLeft") {
				rating1.TooltipPlacement = SFRatingTooltipPlacement.TopLeft;
			}
			else if (selectedType == "BottomRight") {
				rating1.TooltipPlacement = SFRatingTooltipPlacement.BottomRight;
			}
			else if (selectedType == "None")
			{
				rating1.TooltipPlacement = SFRatingTooltipPlacement.None;
			}
		}

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Bounds;
				this.OptionView.Frame = view.Frame;
				option.Frame = new CGRect (0, 90, Frame.Width, Frame.Height);
				customView.Frame = new CGRect (10, 260,view.Frame.Width-20, 1);
				rating1.Frame = new CGRect (10,320,270,50);
				rating2.Frame = new CGRect (235,80,200,20);
				movieRateLabel.Frame = new CGRect (10,10,200,30);
				walkLabel.Frame = new CGRect (160,50,160,30);
				timeLabel.Frame = new CGRect (160,71,80,30);
				if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
					descriptionLabel.Frame = new CGRect (160, 30, 400, 200);
				}
				else
					descriptionLabel.Frame = new CGRect (160, 70, 150, 200);
				rateLabel.Frame = new CGRect (10,280,200,30);
				valueLabel.Frame = new CGRect (10,370,200,30);
				image1.Frame = new CGRect (10, 50, 140, 180);
				precisionLabel.Frame = new CGRect (10,0, this.Frame.Size.Width-10, 30);
				toolTipLabel.Frame = new CGRect (10, 80, this.Frame.Size.Width-20, 30);
				itemCountLabel.Frame = new CGRect (10, 160,this.Frame.Size.Width-10 , 30);
				precisionButton.Frame=new CGRect (10, 40, this.Frame.Size.Width - 20, 30);
				toolTipButton.Frame=new CGRect (10, 120, this.Frame.Size.Width - 20, 30);	
				itemCountTextfield.Frame = new CGRect (230, 160, this.Frame.Size.Width - 250, 30);
				precisionPicker.Frame = new CGRect (0, this.Frame.Size.Height/4+50, this.Frame.Size.Width, this.Frame.Size.Height/3-30);
				toolTipPicker.Frame = new CGRect (0, this.Frame.Size.Height/4+50, this.Frame.Size.Width , this.Frame.Size.Height/3-30);
				doneButton.Frame = new CGRect (0, this.Frame.Size.Height/4+50, this.Frame.Size.Width, 40);	
			}
			this.optionView ();
			base.LayoutSubviews ();
		}
	}
}