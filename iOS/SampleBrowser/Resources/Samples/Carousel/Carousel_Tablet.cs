#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Syncfusion.SfCarousel.iOS;
using System.Collections.Generic;
using System;
using Syncfusion.Drawing;
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
	public class Carousel_Tablet: SampleView
	{
		SFCarousel carousel;
		SFCarouselItem carouselItem;
		UILabel offsetLabel,scaleOffsetLabel,rotationAngleLabel;
		UIView contentView = new UIView ();
		UILabel propertiesLabel=new UILabel();
		UIButton showPropertyButton,closeButton;
		UIView subView;

		UITextView offsetTextfield,scaleOffsetTextfield,rotationAngleTextfield;
		UILabel viewModeLabel;
		PickerModel viewModel;
		UIButton viewButton = new UIButton ();
		UIButton viewDoneButton=new UIButton();
		UIPickerView viewModePicker;
		private string selectedType;
		private UIView activeview;             // Controller that activated the keyboard
		private float scroll_amount = 0.0f;    // amount to scroll 
		private float bottom = 0.0f;           // bottom point
		private float offset = 10.0f;          // extra offset
		private bool moveViewUp = false;
		private readonly IList<string> viewModeList = new List<string>{
			"Default",
			"Linear"
		};
		public Carousel_Tablet()
		{
			
			//Carousel
			carousel = new SFCarousel ();
			carousel.ItemHeight = 350;
			carousel.ItemWidth = 200;
			carousel.SelectedItemOffset = 20;

			//CarouselItem collection creation
			NSMutableArray<SFCarouselItem> carouselItemCollection = new NSMutableArray<SFCarouselItem>();

			for (int i = 1; i <= 7; i++) {
				carouselItem = new SFCarouselItem ();
				carouselItem.ImageName = "image"+i+".png";
				carouselItemCollection.Add (carouselItem);
			}

			carousel.DataSource = carouselItemCollection;
			carousel.SelectedIndex = 2;
			carousel.Frame = new CGRect(125, 190, 350, 650);

			this.AddSubview (carousel);
			variableDeclaration();
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
			if (moveViewUp) { 

				ScrollTheView(false); 
			
				subView.Frame = new CGRect(0, this.Frame.Size.Height - this.Frame.Size.Height / 3, this.Frame.Size.Width, this.Frame.Size.Height / 3);
			}
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

			subView.Frame = new CGRect(0, (this.Frame.Size.Height - this.Frame.Size.Height/2)-50, this.Frame.Size.Width, this.Frame.Size.Height / 3);
			UIView.CommitAnimations();
		}

		public void variableDeclaration()
		{ 
			viewModePicker = new UIPickerView();
			viewModel = new PickerModel(viewModeList);
			viewModePicker.Model = viewModel;
			viewModeLabel = new UILabel();
			viewButton = new UIButton();
			showPropertyButton = new UIButton();
			closeButton = new UIButton();
			offsetLabel = new UILabel();
			scaleOffsetLabel = new UILabel();
			rotationAngleLabel = new UILabel();
		}
		public void loadOptionView()
		{ 
			//offsetLabel
			offsetLabel.Text = "Offset";
			offsetLabel.TextColor = UIColor.Black;
			offsetLabel.TextAlignment = UITextAlignment.Left;
			offsetLabel.Font = UIFont.FromName("Helvetica", 14f);

			//scaleOffsetLabel
			scaleOffsetLabel.Text = "Scale Offset";
			scaleOffsetLabel.TextColor = UIColor.Black;
			scaleOffsetLabel.TextAlignment = UITextAlignment.Left;
			scaleOffsetLabel.Font = UIFont.FromName("Helvetica", 14f);

			//rotatingAngleLabel
			rotationAngleLabel.Text = "Rotation Angle";
			rotationAngleLabel.TextColor = UIColor.Black;
			rotationAngleLabel.TextAlignment = UITextAlignment.Left;
			rotationAngleLabel.Font = UIFont.FromName("Helvetica", 14f);

			//offsetTextField
			offsetTextfield = new UITextView();
			offsetTextfield.TextAlignment = UITextAlignment.Center;
			offsetTextfield.Layer.BorderColor = UIColor.Black.CGColor;
			offsetTextfield.KeyboardType = UIKeyboardType.NumberPad;
			offsetTextfield.BackgroundColor = UIColor.FromRGB(246, 246, 246);
			offsetTextfield.Text = "60";
			offsetTextfield.Changed += (object sender, EventArgs e) =>
			 {
				 if (offsetTextfield.Text.Length > 0)
				 {
					 carousel.Offset = nfloat.Parse(offsetTextfield.Text);
				 }
				 else {
					 carousel.Offset = 60;
				 }
				 if (offsetTextfield.Text.Length > 0)
				 {
					 if (((nfloat)0) <= (nfloat.Parse(offsetTextfield.Text)))
					 {
						 if ((nfloat.Parse(offsetTextfield.Text)) <= (nfloat)100)
							 carousel.Offset = nfloat.Parse(offsetTextfield.Text);
						 else
						 {
							 carousel.Offset = (nfloat)60;
							 offsetTextfield.Text = "60";
						 }
					 }
					 else
					 {
						 carousel.Offset = (nfloat)60;
						 offsetTextfield.Text = "60";
					 }
				 }
			 };

			//scaleOffsetTextField
			scaleOffsetTextfield = new UITextView();
			scaleOffsetTextfield.TextAlignment = UITextAlignment.Center;
			scaleOffsetTextfield.Layer.BorderColor = UIColor.Black.CGColor;
			scaleOffsetTextfield.BackgroundColor = UIColor.FromRGB(246, 246, 246);
			scaleOffsetTextfield.KeyboardType = UIKeyboardType.NumberPad;
			scaleOffsetTextfield.Text = "0.8";
			scaleOffsetTextfield.Changed += (object sender, EventArgs e) =>
			 {
				 if (scaleOffsetTextfield.Text.Length > 0)
				 {
					 carousel.ScaleOffset = nfloat.Parse(scaleOffsetTextfield.Text);
				 }
				 else {
					 carousel.ScaleOffset = (nfloat)0.8;
				 }
				 if (scaleOffsetTextfield.Text.Length > 0)
				 {
					 if (((nfloat)0) <= (nfloat.Parse(scaleOffsetTextfield.Text)))
					 {
						 if ((nfloat.Parse(scaleOffsetTextfield.Text)) <= (nfloat)1)
							 carousel.ScaleOffset = nfloat.Parse(scaleOffsetTextfield.Text);
						 else
						 {
							 carousel.ScaleOffset = (nfloat)0.8;
							 scaleOffsetTextfield.Text = "0.8";
						 }
					 }
					 else
					 {
						 carousel.ScaleOffset = (nfloat)0.8;
						 scaleOffsetTextfield.Text = "0.8";
					 }
				 }

			 };

			//rotationAngleTextfield
			rotationAngleTextfield = new UITextView();
			rotationAngleTextfield.TextAlignment = UITextAlignment.Center;
			rotationAngleTextfield.Layer.BorderColor = UIColor.Black.CGColor;
			rotationAngleTextfield.BackgroundColor = UIColor.FromRGB(246, 246, 246);
			rotationAngleTextfield.KeyboardType = UIKeyboardType.NumberPad;
			rotationAngleTextfield.Text = "45";
			rotationAngleTextfield.Changed += (object sender, EventArgs e) =>
			 {
				 if (rotationAngleTextfield.Text.Length > 0)
				 {
					 carousel.RotationAngle = int.Parse(rotationAngleTextfield.Text);
				 }
				 else
				 {
					 carousel.RotationAngle = 45;
				 }
				 if (rotationAngleTextfield.Text.Length > 0)
				 {
					 if (((nfloat)0) <= (nfloat.Parse(rotationAngleTextfield.Text)))
					 {
						 if ((nfloat.Parse(rotationAngleTextfield.Text)) <= (nfloat)360)
							 carousel.RotationAngle = nfloat.Parse(rotationAngleTextfield.Text);
						 else
						 {
							 carousel.RotationAngle = (nfloat)45;
							 rotationAngleTextfield.Text = "45";
						 }
					 }
					 else
					 {
						 carousel.RotationAngle = (nfloat)45;
						 rotationAngleTextfield.Text = "45";
					 }
				 }
			 };

			//viewModeLabel
			viewModeLabel.Text = "View Mode";
			viewModeLabel.Font = UIFont.FromName("Helvetica", 14f);
			viewModeLabel.TextColor = UIColor.Black;
			viewModeLabel.TextAlignment = UITextAlignment.Left;

			//viewButton
			viewButton.SetTitle("Default", UIControlState.Normal);
			viewButton.Font = UIFont.FromName("Helvetica", 14f);
			viewButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			viewButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			viewButton.Layer.CornerRadius = 8;
			viewButton.Layer.BorderWidth = 2;
			viewButton.TouchUpInside += ShowviewModePicker;
			viewButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;

			//viewDoneButton
			viewDoneButton.SetTitle("Done\t", UIControlState.Normal);
			viewDoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			viewDoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			viewDoneButton.TouchUpInside += HidePicker;
			viewDoneButton.Hidden = true;
			viewDoneButton.BackgroundColor = UIColor.FromRGB(230, 230, 230);
			viewModel.PickerChanged += viewSelectedIndexChanged;
			viewModePicker.ShowSelectionIndicator = true;
			viewModePicker.Hidden = true;
			viewModePicker.BackgroundColor = UIColor.Gray;

			//adding to contentView
			subView = new UIView();
			contentView.AddSubview(rotationAngleLabel);
			contentView.AddSubview(offsetTextfield);
			contentView.AddSubview(scaleOffsetTextfield);
			contentView.AddSubview(rotationAngleTextfield);
			contentView.AddSubview(offsetLabel);
			contentView.AddSubview(scaleOffsetLabel);
			contentView.AddSubview(viewModeLabel);
			contentView.AddSubview(viewButton);
			contentView.AddSubview(viewModePicker);
			contentView.AddSubview(viewDoneButton);
			contentView.BackgroundColor = UIColor.FromRGB(230, 230, 230);
			subView.AddSubview(closeButton);

			//adding to subView
			propertiesLabel.Text = "OPTIONS";
			subView.AddSubview(propertiesLabel);
			subView.BackgroundColor = UIColor.FromRGB(240, 240, 240);
			subView.AddSubview(contentView);
			this.AddSubview(subView);
			this.AddSubview(showPropertyButton);

			//showPropertyButton
			showPropertyButton.Hidden = true;
			showPropertyButton.SetTitle(" OPTIONS\t", UIControlState.Normal);
			showPropertyButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
			showPropertyButton.BackgroundColor = UIColor.FromRGB(230, 230, 230);
			showPropertyButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			showPropertyButton.TouchUpInside += (object sender, EventArgs e) =>
			{
				subView.Hidden = false;
				showPropertyButton.Hidden = true;
			};

			//closeButton
			closeButton.SetTitle("X\t", UIControlState.Normal);
			closeButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
			closeButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
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
				view.Frame = Bounds;
				carousel.Frame = new CGRect ( 0,0, this.Frame.Size.Width,this.Frame.Size.Height-this.Frame.Size.Height/3);	
				subView.Frame = new CGRect (0, this.Frame.Size.Height-this.Frame.Size.Height/3, this.Frame.Size.Width, this.Frame.Size.Height/3);
				contentView.Frame=new CGRect(0,40,subView.Frame.Size.Width,subView.Frame.Size.Height);
				offsetLabel.Frame = new CGRect ( 110, 30,this.Frame.Size.Width-210 , 30);
				scaleOffsetLabel.Frame = new CGRect (110, 80, contentView.Frame.Size.Width - 210, 30);
				rotationAngleLabel.Frame = new CGRect (110, 130, contentView.Frame.Size.Width - 210, 30);
				offsetTextfield.Frame = new CGRect (430, 30, contentView.Frame.Size.Width - 550, 30);
				scaleOffsetTextfield.Frame = new CGRect (430, 80, contentView.Frame.Size.Width - 550, 30);
				rotationAngleTextfield.Frame = new CGRect (430, 130, contentView.Frame.Size.Width - 550, 30);
				showPropertyButton.Frame = new CGRect (0, this.Frame.Size.Height-25, this.Frame.Size.Width, 30);
				closeButton.Frame = new CGRect (this.Frame.Width - 30, 5, 20, 30);
				propertiesLabel.Frame = new CGRect (10, 5, this.Frame.Width, 30);
                viewModeLabel.Frame = new CGRect ( 110,180, contentView.Frame.Size.Width - 210, 30);
				viewButton.Frame=new CGRect ( 430, 180, contentView.Frame.Size.Width - 550, 30);
				viewModePicker.Frame = new CGRect (100, 20, contentView.Frame.Size.Width-200, 150);
				viewDoneButton.Frame = new CGRect (100, 20, contentView.Frame.Size.Width-200, 30);
			}
			base.LayoutSubviews ();
		}

		void ShowviewModePicker (object sender, EventArgs e) {
			offsetTextfield.EndEditing(true);
			scaleOffsetTextfield.EndEditing(true);
			rotationAngleTextfield.EndEditing(true);
			viewDoneButton.Hidden = false;
			viewModePicker.Hidden = false;
		}

		void HidePicker (object sender, EventArgs e) {
			viewDoneButton.Hidden = true;
			viewModePicker.Hidden = true;
		}
		private void viewSelectedIndexChanged(object sender, PickerChangedEventArgs e)
		{
			this.selectedType = e.SelectedValue;
			viewButton.SetTitle (selectedType, UIControlState.Normal);
			if (selectedType == "Default")
				carousel.ViewMode = SFCarouselViewMode.SFCarouselViewModeDefault;
			else
				carousel.ViewMode = SFCarouselViewMode.SFCarouselViewModeLinear;
		}

			
		}
	}