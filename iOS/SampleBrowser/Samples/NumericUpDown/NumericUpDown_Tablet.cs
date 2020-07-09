#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfNumericUpDown.iOS;
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
	public class NumericUpDown_Tablet : SampleView
	{
		UIPickerView spinPicker;
		UILabel minimumLabel,maximumLabel, adultLabel, infantLabel, spinLabel,autoReverse,propertyLabel;
		UISwitch autoSwitch;
		UITextView minimumText,maximumText;
		UIScrollView subView;
		UIView contentView = new UIView ();
		UIView controlView = new UIView ();
		UIButton cultureDoneButton,spinAlignmentButton,showPropertyButton,closeButton;
		private string cultureSelectedType;
        private bool IsViewLoaded = false;
		SFNumericUpDown adultNumericUpDown;
		SFNumericUpDown infantsNumericUpDown;
		private UIView activeview;             // Controller that activated the keyboard
		private float scroll_amount = 0.0f;    // amount to scroll 
		private float bottom = 0.0f;           // bottom point
		private float offset = 10.0f;          // extra offset
		private bool moveViewUp = false;

		private readonly IList<string> cultureList = new List<string> ();


		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Bounds;
				subView.Frame = new CGRect (0, view.Frame.Size.Height-view.Frame.Size.Height/3, view.Frame.Size.Width, view.Frame.Size.Height / 3);
				controlView.Frame=new CGRect(150,90,this.Frame.Size.Width-300,this.Frame.Size.Height-40);
				contentView.Frame=new CGRect(0,40,subView.Frame.Size.Width,subView.Frame.Size.Height-30);
				adultNumericUpDown.Frame = new CGRect(10, 60, controlView.Frame.Width-20, 32);
				infantsNumericUpDown.Frame = new CGRect(10, 170, controlView.Frame.Width-20,32);

				adultLabel.Frame = new CGRect(15, 20, this.Frame.Size.Width-20, 30);
				infantLabel.Frame = new CGRect(15, 130, this.Frame.Size.Width-20, 30);

				minimumText.Frame = new CGRect (330, 40, contentView.Frame.Size.Width - 520, 30);
				maximumText.Frame = new CGRect (330, 90, contentView.Frame.Size.Width - 520, 30);
				minimumLabel.Frame = new CGRect ( 110, 40,contentView.Frame.Size.Width-210 , 30);
				maximumLabel.Frame = new CGRect (110, 90, contentView.Frame.Size.Width - 210, 30);

				spinLabel.Frame=new CGRect(110,140, contentView.Frame.Size.Width-220, 30);
				spinAlignmentButton.Frame=new CGRect(330,140,  contentView.Frame.Size.Width-520, 30);
				autoReverse.Frame=new CGRect(110, 190, contentView.Frame.Size.Width-220, 30);
				autoSwitch.Frame=new CGRect(330,190,  contentView.Frame.Size.Width-220, 30);
				spinPicker.Frame=new CGRect(100,12, contentView.Frame.Size.Width-200,220);
				cultureDoneButton.Frame=new CGRect(100, 0, contentView.Frame.Size.Width-200, 30);
				showPropertyButton.Frame = new CGRect (0, this.Frame.Size.Height - 25, this.Frame.Size.Width, 30);
				closeButton.Frame = new CGRect (this.Frame.Size.Width - 30, 5, 20, 30);
				propertyLabel.Frame = new CGRect (10, 5, this.Frame.Width, 30);

			}
			base.LayoutSubviews ();
		}

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public NumericUpDown_Tablet ()
		{
			
			//adultNumericUpDown
			adultNumericUpDown= new SFNumericUpDown();
			adultNumericUpDown.AllowNull = true;
			adultNumericUpDown.PercentDisplayMode = SFNumericUpDownPercentDisplayMode.Compute;
			adultNumericUpDown.ValueChangeMode = SFNumericUpDownValueChangeMode.OnLostFocus;
			adultNumericUpDown.Value = 5;
			adultNumericUpDown.Minimum = 0;
			adultNumericUpDown.Maximum = 100;
		    adultNumericUpDown.MaximumDecimalDigits = 0;
            adultNumericUpDown.Culture = new NSLocale ("en_US");
			controlView.AddSubview(adultNumericUpDown);

			//infantsNumericUpDown
			infantsNumericUpDown= new SFNumericUpDown();
			infantsNumericUpDown.AllowNull = true;
			infantsNumericUpDown.PercentDisplayMode = SFNumericUpDownPercentDisplayMode.Compute;
			infantsNumericUpDown.Value = 3;
			infantsNumericUpDown.Minimum = 0;
			infantsNumericUpDown.Maximum = 100;
		    infantsNumericUpDown.MaximumDecimalDigits = 0;
            infantsNumericUpDown.Culture = new NSLocale ("en_US");
			controlView.AddSubview(infantsNumericUpDown);
		

			this.AddSubview(controlView);
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
            if (!IsViewLoaded) return;
			// get the keyboard size
			var r = UIKeyboard.BoundsFromNotification(notification);

			// Find what opened the keyboard
			foreach (UIView view in this.contentView.Subviews)
			{
				if (view.IsFirstResponder)
					activeview = view;
			}
			if(activeview!=null)
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
        protected override void Dispose(bool disposing)
        {
            IsViewLoaded = false;
            base.Dispose(disposing);
        }
		public void mainPageDesign()
		{
			//adding to cultureListt
			this.cultureList.Add((NSString)"Right");
			this.cultureList.Add((NSString)"Left");
			this.cultureList.Add((NSString)"Both");

			//adultLabell
			adultLabel = new UILabel();
			adultLabel.TextColor = UIColor.Black;
			adultLabel.BackgroundColor = UIColor.Clear;
			adultLabel.Text = @"Number of Adults";
			adultLabel.TextAlignment = UITextAlignment.Left;
			adultLabel.Font = UIFont.FromName("Helvetica", 16f);
			controlView.AddSubview(adultLabel);

			//infantLabell
			infantLabel = new UILabel();
			infantLabel.TextColor = UIColor.Black;
			infantLabel.BackgroundColor = UIColor.Clear;
			infantLabel.Text = @"Number of Infants";
			infantLabel.TextAlignment = UITextAlignment.Left;
			infantLabel.Font = UIFont.FromName("Helvetica", 16f);
			controlView.AddSubview(infantLabel);
			
		}

		public void loadOptionView()
		{
			subView = new UIScrollView();
			subView.ContentSize = new CGSize(Frame.Width, 400);

			//autoReverse
			autoReverse = new UILabel();
			autoReverse.TextColor = UIColor.Black;
			autoReverse.BackgroundColor = UIColor.Clear;
			autoReverse.Text = @"Auto Reverse";
			autoReverse.TextAlignment = UITextAlignment.Left;
			autoReverse.Font = UIFont.FromName("Helvetica", 14f);
			contentView.AddSubview(autoReverse);

			//autoSwitch
			autoSwitch = new UISwitch();
			autoSwitch.ValueChanged += autoReverseToggleChanged;
			autoSwitch.On = false;
			autoSwitch.OnTintColor = UIColor.FromRGB(50, 150, 221);
			contentView.AddSubview(autoSwitch);

			//spinLabel
			spinLabel = new UILabel();
			spinLabel.TextColor = UIColor.Black;
			spinLabel.BackgroundColor = UIColor.Clear;
			spinLabel.Text = @"Spin Alignment";
			spinLabel.TextAlignment = UITextAlignment.Left;
			spinLabel.Font = UIFont.FromName("Helvetica", 14f);
			contentView.AddSubview(spinLabel);

			//spinAlignmentButton
			spinAlignmentButton = new UIButton();
			spinAlignmentButton.SetTitle("Right", UIControlState.Normal);
			spinAlignmentButton.Font = UIFont.FromName("Helvetica", 14f);
			spinAlignmentButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			spinAlignmentButton.BackgroundColor = UIColor.Clear;
			spinAlignmentButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			spinAlignmentButton.Hidden = false;
			spinAlignmentButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
			spinAlignmentButton.Layer.BorderWidth = 4;
			spinAlignmentButton.Layer.CornerRadius = 8;
			spinAlignmentButton.TouchUpInside += ShowSpinPicker;
			contentView.AddSubview(spinAlignmentButton);

			//minimumLabel
			minimumLabel = new UILabel();
			minimumLabel.Text = "Minimum";
			minimumLabel.TextColor = UIColor.Black;
			minimumLabel.TextAlignment = UITextAlignment.Left;
			minimumLabel.Font = UIFont.FromName("Helvetica", 14f);

			//maximumLabel
			maximumLabel = new UILabel();
			maximumLabel.Text = "Maximum";
			maximumLabel.TextColor = UIColor.Black;
			maximumLabel.TextAlignment = UITextAlignment.Left;
			maximumLabel.Font = UIFont.FromName("Helvetica", 14f);
			contentView.AddSubview(minimumLabel);
			contentView.AddSubview(maximumLabel);

			//minimumText
			minimumText = new UITextView();
			minimumText.TextAlignment = UITextAlignment.Center;
			minimumText.Layer.BorderColor = UIColor.Black.CGColor;
			minimumText.BackgroundColor = UIColor.FromRGB(246, 246, 246);
			minimumText.KeyboardType = UIKeyboardType.NumberPad;
			minimumText.Text = "0";
			minimumText.Font = UIFont.FromName("Helvetica", 14f);
			minimumText.Changed += (object sender, EventArgs e) =>
			 {
				 if (minimumText.Text.Length > 0)
				 {
					 adultNumericUpDown.Minimum = nfloat.Parse(minimumText.Text);
					 infantsNumericUpDown.Minimum = nfloat.Parse(minimumText.Text);
				 }
			 };
			contentView.AddSubview(minimumText);

			//maximumText
			maximumText = new UITextView();
			maximumText.TextAlignment = UITextAlignment.Center;
			maximumText.Layer.BorderColor = UIColor.Black.CGColor;
			maximumText.BackgroundColor = UIColor.FromRGB(246, 246, 246);
			maximumText.KeyboardType = UIKeyboardType.NumberPad;
			maximumText.Text = "100";
			maximumText.Font = UIFont.FromName("Helvetica", 14f);
			maximumText.Changed += (object sender, EventArgs e) =>
			 {
				 if (maximumText.Text.Length > 0)
				 {
					 adultNumericUpDown.Maximum = nfloat.Parse(maximumText.Text);
					 infantsNumericUpDown.Maximum = nfloat.Parse(maximumText.Text);
				 }

			 };
			contentView.AddSubview(maximumText);

			//spinPicker
			PickerModel culturePickermodel = new PickerModel(this.cultureList);
			culturePickermodel.PickerChanged += (sender, e) =>
			{
				this.cultureSelectedType = e.SelectedValue;
				spinAlignmentButton.SetTitle(cultureSelectedType, UIControlState.Normal);
				if (cultureSelectedType == "Right")
				{
					adultNumericUpDown.SpinButtonAlignment = SFNumericUpDownSpinButtonAlignment.Right;
					infantsNumericUpDown.SpinButtonAlignment = SFNumericUpDownSpinButtonAlignment.Right;
					adultNumericUpDown.TextAlignment = UITextAlignment.Left;
					infantsNumericUpDown.TextAlignment = UITextAlignment.Left;
				}
				else if (cultureSelectedType == "Left")
				{
					adultNumericUpDown.SpinButtonAlignment = SFNumericUpDownSpinButtonAlignment.Left;
					infantsNumericUpDown.SpinButtonAlignment = SFNumericUpDownSpinButtonAlignment.Left;
					adultNumericUpDown.TextAlignment = UITextAlignment.Right;
					infantsNumericUpDown.TextAlignment = UITextAlignment.Right;
				}
				else if (cultureSelectedType == "Both")
				{
					adultNumericUpDown.SpinButtonAlignment = SFNumericUpDownSpinButtonAlignment.Both;
					infantsNumericUpDown.SpinButtonAlignment = SFNumericUpDownSpinButtonAlignment.Both;
					adultNumericUpDown.TextAlignment = UITextAlignment.Center;
					infantsNumericUpDown.TextAlignment = UITextAlignment.Center;
				}

			};
			spinPicker = new UIPickerView();
			spinPicker.ShowSelectionIndicator = true;
			spinPicker.Hidden = true;
			spinPicker.Model = culturePickermodel;
			spinPicker.BackgroundColor = UIColor.Gray;
			contentView.AddSubview(spinPicker);

			//cultureDoneButton
			cultureDoneButton = new UIButton();
			cultureDoneButton.SetTitle("Done\t", UIControlState.Normal);
			cultureDoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			cultureDoneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
			cultureDoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			cultureDoneButton.Hidden = true;
			cultureDoneButton.Font = UIFont.FromName("Helvetica", 14f);
			cultureDoneButton.TouchUpInside += HideSpinPicker;
			contentView.AddSubview(cultureDoneButton);

			//propertyLabel
			propertyLabel = new UILabel();
			propertyLabel.Text = "OPTIONS";
			subView.AddSubview(propertyLabel);
			subView.BackgroundColor = UIColor.FromRGB(230, 230, 230);
			contentView.BackgroundColor = UIColor.FromRGB(240, 240, 240);
			subView.AddSubview(contentView);
			this.AddSubview(subView);

			//ShowPropertyButton
			showPropertyButton = new UIButton();
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
			this.AddSubview(showPropertyButton);


			//closeButton
			closeButton = new UIButton();
			closeButton.SetTitle("X\t", UIControlState.Normal);
			closeButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
			closeButton.BackgroundColor = UIColor.FromRGB(230, 230, 230);
			closeButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			closeButton.TouchUpInside += (object sender, EventArgs e) =>
			{
				subView.Hidden = true;
				showPropertyButton.Hidden = false; ;
			};
			subView.AddSubview(closeButton);

			//Adding Gesture
			UITapGestureRecognizer tapgesture = new UITapGestureRecognizer(() =>
			{
				subView.Hidden = true;
				showPropertyButton.Hidden = false;
			}
			);
			propertyLabel.UserInteractionEnabled = true;
			propertyLabel.AddGestureRecognizer(tapgesture);
		}

		void ShowSpinPicker (object sender, EventArgs e) {
			cultureDoneButton.Hidden = false;
			spinPicker.Hidden = false;
			spinAlignmentButton.Hidden = true;
			autoSwitch.Hidden = true;
			autoReverse.Hidden = true;
			this.BecomeFirstResponder ();
		}

		void HideSpinPicker (object sender, EventArgs e) {
			cultureDoneButton.Hidden = true;
			spinPicker.Hidden = true;
			spinAlignmentButton.Hidden = false;
			autoSwitch.Hidden = false;
			autoReverse.Hidden = false;		    
			this.BecomeFirstResponder ();
		}

		private void autoReverseToggleChanged(object sender, EventArgs e)
		{
			if (((UISwitch)sender).On) {
				adultNumericUpDown.AutoReverse = true;
				infantsNumericUpDown.AutoReverse = true;
			} else {
				adultNumericUpDown.AutoReverse = false;
				infantsNumericUpDown.AutoReverse = false;
			}
		}

		public override void TouchesBegan (NSSet touches, UIEvent evt){
			this.EndEditing (true);
		}
	}


}

