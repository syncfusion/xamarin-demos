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
	public class Rating_Tablet: SampleView
	{
		UILabel precisionLabel,toolTipLabel,itemCountLabel;
		UILabel movieRateLabel,walkLabel,timeLabel,descriptionLabel,rateLabel,valueLabel,propertiesLabel;
		UITextView itemCountTextfield;
		UIImageView image1;
		UIView customView;
		UIScrollView subView;
		UIButton showPropertyButton,closeButton;
		UIButton precisionButton = new UIButton ();
		UIButton toolTipButton = new UIButton ();
		UIButton doneButton=new UIButton();
		UIView contentView = new UIView ();
		UIView controlView = new UIView ();
		PickerModel model,model1;
		UIPickerView precisionPicker, toolTipPicker;
		private string selectedType;
		private UIView activeview;             // Controller that activated the keyboard
		private float scroll_amount = 0.0f;    // amount to scroll 
		private float bottom = 0.0f;           // bottom point
		private float offset = 10.0f;          // extra offset
		private bool moveViewUp = false;
		SFRating rating2,rating1;
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

		public Rating_Tablet()
		{
			//Rating 1
			rating1 = new SFRating ();
			rating1.ItemCount=5;
			rating1.Precision= SFRatingPrecision.Standard;
			rating1.TooltipPlacement= SFRatingTooltipPlacement.None;
			rating1.ItemSize=30;
			rating1.Value = 3;
			rating1.ItemSpacing = 30;
			rating1.Delegate = new RatingControlTabletDelegate();

			//RatingSettings
			SFRatingSettings ratingSetting = new SFRatingSettings ();
			ratingSetting.RatedFill = UIColor.FromRGB (251,209,10);
			ratingSetting.RatedStroke = UIColor.FromRGB (251,209,10);

			//Rating 2
			rating2 = new SFRating();
			rating2.ItemCount=5;
			rating2.RatingSettings = ratingSetting;
			rating2.Precision = SFRatingPrecision.Half;
			rating2.TooltipPlacement= SFRatingTooltipPlacement.None;
			rating2.ItemSize=10;
			rating2.Readonly=true;
			rating2.Value=(nfloat)3.5;
			rating2.ItemSpacing = 5;

			mainPageDesign();
			autoHide();
			loadOptionView();
		}

		public void autoHide()
		{
			NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.DidShowNotification, KeyBoardUpNotification);
			NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, KeyBoardDownNotification);
		}
		private void KeyBoardUpNotification(NSNotification notification)
		{
			propertiesLabel.Hidden = true;
			closeButton.Hidden = true;
			// get the keyboard size
			var r = UIKeyboard.BoundsFromNotification(notification);

			// Find what opened the keyboard
			foreach (UIView view in this.contentView.Subviews)
			{
				if (view.IsFirstResponder)
					activeview = view;
			}

			// Bottom of the controller = initial position + height + offset      
			bottom = ((float)(activeview.Frame.Y + activeview.Frame.Height + offset));

			// Calculate how far we need to scroll
			scroll_amount = ((float)(r.Height - (contentView.Frame.Size.Height - bottom)));

			// Perform the scrolling
			if (scroll_amount > 0)
			{
				moveViewUp = true;
				ScrollTheView(moveViewUp);
			}
			else {
				moveViewUp = false;
			}

		}

		private void KeyBoardDownNotification(NSNotification notification)
		{
			propertiesLabel.Hidden = false;
			closeButton.Hidden = false;
			if (moveViewUp) { ScrollTheView(false); }
		}

		private void ScrollTheView(bool move)
		{

			// scroll the view up or down
			UIView.BeginAnimations(string.Empty, System.IntPtr.Zero);
			UIView.SetAnimationDuration(0.1);

			var frame = contentView.Frame;

			if (move)
			{
				frame.Y -= scroll_amount;
			}
			else {
				frame.Y += scroll_amount;
				scroll_amount = 0;
			}

			contentView.Frame = frame;
			UIView.CommitAnimations();
		}
		public void mainPageDesign()
		{ 
			customView = new UIView();
			customView.BackgroundColor = UIColor.FromRGB(165, 165, 165);

			//Image
			image1 = new UIImageView();
			image1.Image = UIImage.FromBundle("Images/walk.png");

			//PrecisionLabell
			precisionLabel = new UILabel();
			precisionLabel.Text = "Precision";
			precisionLabel.Font = UIFont.FromName("Helvetica", 14f);
			precisionLabel.TextColor = UIColor.Black;
			precisionLabel.TextAlignment = UITextAlignment.Left;

			//ToolTipLabell
			toolTipLabel = new UILabel();
			toolTipLabel.Text = "ToolTip Placement";
			toolTipLabel.Font = UIFont.FromName("Helvetica", 14f);
			toolTipLabel.TextColor = UIColor.Black;
			toolTipLabel.TextAlignment = UITextAlignment.Left;

			//ItemCountLabell
			itemCountLabel = new UILabel();
			itemCountLabel.Text = "Item Count";
			itemCountLabel.Font = UIFont.FromName("Helvetica", 14f);
			itemCountLabel.TextColor = UIColor.Black;
			itemCountLabel.TextAlignment = UITextAlignment.Left;

			//MovieRateLabell
			movieRateLabel = new UILabel();
			movieRateLabel.Text = "Movie Rating";
			movieRateLabel.TextColor = UIColor.Black;
			movieRateLabel.TextAlignment = UITextAlignment.Left;
			movieRateLabel.Font = UIFont.FromName("Helvetica", 22f);

			//WalkLabell
			walkLabel = new UILabel();
			walkLabel.Text = "The Walk (2015)";
			walkLabel.TextColor = UIColor.Black;
			walkLabel.TextAlignment = UITextAlignment.Left;
			walkLabel.Font = UIFont.FromName("Helvetica", 18f);

			//TimeLabell
			timeLabel = new UILabel();
			timeLabel.Text = "PG | 2 h 20 min";
			timeLabel.TextColor = UIColor.Black;
			timeLabel.TextAlignment = UITextAlignment.Left;
			timeLabel.Font = UIFont.FromName("Helvetica", 12f);

			//DescriptionLabell
			descriptionLabel = new UILabel();
			descriptionLabel.Text = "In 1974, high-wire artist Philippe Petit recruits a team of people to help him realize his dream: to walk the immense void between the world Trade Centre towers.";
			descriptionLabel.TextColor = UIColor.Black;
			descriptionLabel.TextAlignment = UITextAlignment.Left;
			descriptionLabel.Font = UIFont.FromName("Helvetica", 14f);
			descriptionLabel.LineBreakMode = UILineBreakMode.WordWrap;
			descriptionLabel.Lines = 0;

			//RateLabell
			rateLabel = new UILabel();
			rateLabel.Text = "Rate";
			rateLabel.TextColor = UIColor.Black;
			rateLabel.TextAlignment = UITextAlignment.Left;
			rateLabel.Font = UIFont.FromName("Helvetica", 18f);

			//ValueLabell
			valueLabel = new UILabel();
			valueLabel.TextColor = UIColor.Black;
			valueLabel.TextAlignment = UITextAlignment.Left;
			valueLabel.Font = UIFont.FromName("Helvetica", 14f);
			UpdateText();

		}

		public void loadOptionView()
		{ 
			//PrecisionButton
			precisionButton = new UIButton();
			precisionButton.SetTitle("Standard", UIControlState.Normal);
			precisionButton.Font = UIFont.FromName("Helvetica", 14f);
			precisionButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			precisionButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			precisionButton.Layer.CornerRadius = 8;
			precisionButton.Layer.BorderWidth = 2;
			precisionButton.TouchUpInside += ShowPicker1;
			precisionButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;

			//TooltipButton
			toolTipButton = new UIButton();
			toolTipButton.SetTitle("None", UIControlState.Normal);
			toolTipButton.Font = UIFont.FromName("Helvetica", 14f);
			toolTipButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			toolTipButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			toolTipButton.Layer.CornerRadius = 8;
			toolTipButton.Layer.BorderWidth = 2;
			toolTipButton.TouchUpInside += ShowPicker2;
			toolTipButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;

			//DoneButton
			doneButton.SetTitle("Done\t", UIControlState.Normal);
			doneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			doneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			doneButton.Font = UIFont.FromName("Helvetica", 14f);
			doneButton.TouchUpInside += HidePicker;
			doneButton.Hidden = true;
			doneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);

			//Picker
			precisionPicker = new UIPickerView();
			toolTipPicker = new UIPickerView();
			model = new PickerModel(precisionList);
			precisionPicker.Model = model;
			model1 = new PickerModel(toottipplace);
			toolTipPicker.Model = model1;
			model.PickerChanged += SelectedIndexChanged;
			model1.PickerChanged += SelectedIndexChanged1;
			precisionPicker.ShowSelectionIndicator = true;
			precisionPicker.Hidden = true;
			toolTipPicker.Hidden = true;
			precisionPicker.BackgroundColor = UIColor.Gray;
			toolTipPicker.BackgroundColor = UIColor.Gray;
			toolTipPicker.ShowSelectionIndicator = true;

			//ItemCountTextField
			itemCountTextfield = new UITextView();
			itemCountTextfield.TextAlignment = UITextAlignment.Center;
			itemCountTextfield.Layer.BorderColor = UIColor.Black.CGColor;
			itemCountTextfield.BackgroundColor = UIColor.FromRGB(246, 246, 246);
			itemCountTextfield.KeyboardType = UIKeyboardType.NumberPad;
			itemCountTextfield.Text = "5";
			itemCountTextfield.Font = UIFont.FromName("Helvetica", 14f);
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

			//adding to controlView
			controlView.AddSubview(rating1);
			controlView.AddSubview(rating2);
			controlView.AddSubview(movieRateLabel);
			controlView.AddSubview(walkLabel);
			controlView.AddSubview(timeLabel);
			controlView.AddSubview(descriptionLabel);
			controlView.AddSubview(rateLabel);
			controlView.AddSubview(valueLabel);
			controlView.AddSubview(image1);
			controlView.AddSubview(itemCountTextfield);
			this.AddSubview(controlView);

			//Adding to content view
			contentView.AddSubview(precisionLabel);
			contentView.AddSubview(toolTipLabel);
			contentView.AddSubview(precisionButton);
			contentView.AddSubview(itemCountLabel);
			contentView.AddSubview(toolTipButton);
			contentView.AddSubview(precisionPicker);
			contentView.AddSubview(toolTipPicker);
			contentView.AddSubview(doneButton);
			contentView.AddSubview(itemCountTextfield);
			contentView.BackgroundColor = UIColor.FromRGB(240, 240, 240);


			//PropertyLabel
			propertiesLabel = new UILabel();
			propertiesLabel.Text = " OPTIONS";


			//ShowpropertyButton
			showPropertyButton = new UIButton();
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
			closeButton = new UIButton();
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

			//Adding to subvieww
			subView = new UIScrollView();
			subView.ContentSize = new CGSize(Frame.Width, 350);
			subView.AddSubview(contentView);
			subView.AddSubview(propertiesLabel);
			subView.AddSubview(closeButton);
			subView.BackgroundColor = UIColor.FromRGB(230, 230, 230);
			this.AddSubview(subView);

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

		public void SetValue(nfloat value)
		{
			UpdateText ();
		}

		void ShowPicker1 (object sender, EventArgs e) {
			doneButton.Hidden = false;
			precisionPicker.Hidden = false;
			itemCountLabel.Hidden = itemCountLabel.Hidden = true;
			itemCountTextfield.Hidden = true;;
			itemCountTextfield.Hidden = true;
			toolTipPicker.Hidden = true;
		}

		void HidePicker (object sender, EventArgs e) {

			doneButton.Hidden = true;
			toolTipPicker.Hidden = true;
			itemCountLabel.Hidden = false;
			itemCountTextfield.Hidden = false;
			precisionPicker.Hidden = true;
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
				subView.Frame = new CGRect (0, view.Frame.Size.Height -view.Frame.Size.Height/3, view.Frame.Size.Width, view.Frame.Size.Height/3);
				controlView.Frame=new CGRect(100,40,this.Frame.Size.Width-200,this.Frame.Size.Height-40);
				contentView.Frame=new CGRect(0,40,subView.Frame.Size.Width,subView.Frame.Size.Height);
				customView.Frame = new CGRect (10, 220,view.Frame.Width-20, 1);
				rating1.Frame = new CGRect (10,355,270,50);
				rating2.Frame = new CGRect (295,60,200,20);
				movieRateLabel.Frame = new CGRect(10, 0, 200, 30);
				walkLabel.Frame = new CGRect (220,30,160,30);
				timeLabel.Frame = new CGRect (220,51,80,30);
				descriptionLabel.Frame = new CGRect (220, 10, 400, 200);
				rateLabel.Frame = new CGRect (10,315,200,30);
				valueLabel.Frame = new CGRect (10,405,200,30);
				image1.Frame = new CGRect (10, 30, 200, 255);
				precisionLabel.Frame = new CGRect (100,40, contentView.Frame.Size.Width-210, 30);
				toolTipLabel.Frame = new CGRect (100, 90, contentView.Frame.Size.Width-220, 30);
				itemCountLabel.Frame = new CGRect (100, 140,contentView.Frame.Size.Width-210 , 30);
				precisionButton.Frame=new CGRect (350, 40, contentView.Frame.Size.Width - 520, 30);
				toolTipButton.Frame=new CGRect (350, 90, contentView.Frame.Size.Width - 520, 30);	
				itemCountTextfield.Frame = new CGRect (350, 140, contentView.Frame.Size.Width - 520, 30);
				precisionPicker.Frame = new CGRect (100,0, contentView.Frame.Size.Width-200,200);
				toolTipPicker.Frame = new CGRect (100,0 , contentView.Frame.Size.Width-200 , 200);
				doneButton.Frame = new CGRect (100,0 , contentView.Frame.Size.Width-200, 30);	
				showPropertyButton.Frame = new CGRect (0, this.Frame.Size.Height - 25, this.Frame.Size.Width, 30);
				closeButton.Frame = new CGRect (this.Frame.Size.Width - 30, 5, 20, 30);
				propertiesLabel.Frame = new CGRect (10, 5, this.Frame.Width, 30);
			}
			base.LayoutSubviews ();
		}
	}

	public class RatingControlTabletDelegate:SFRatingDelegate
	{
		public override void DidValueChanged (SFRating sfRating, nfloat value)
		{
			(sfRating.Superview.Superview as Rating_Tablet).SetValue (value);
		}
	}
}