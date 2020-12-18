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
	public class NumericUpDown_Mobile: SampleView
	{
		UIPickerView spinPicker;
		UILabel minPrefixCharacterLabel,maxDropDownHeightLabel, adultLabel, infantLabel, spinLabel,autoReverse;
		UISwitch autoSwitch;
		UITextView minimumText,maximumText;
		UIButton cultureDoneButton,spinAlignmentButton;
		private string cultureSelectedType;
		SFNumericUpDown adultNumericUpDown;
		SFNumericUpDown infantsNumericUpDown;
		public UIView option = new UIView ();
		private readonly IList<string> cultureList = new List<string> ();
		public void  optionView()
		{
			this.option.AddSubview(autoReverse);
			this.option.AddSubview(autoSwitch);
			this.option.AddSubview(spinLabel);
			this.option.AddSubview (spinAlignmentButton);
			this.option.AddSubview (minPrefixCharacterLabel);
			this.option.AddSubview (maxDropDownHeightLabel);
			this.option.AddSubview (minimumText);
			this.option.AddSubview (maximumText);
			this.option.AddSubview(spinPicker);
			this.option.AddSubview (cultureDoneButton);


		}

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Bounds;
				this.OptionView.Frame = view.Frame;
				option.Frame = new CGRect (0, 70, Frame.Width, Frame.Height);
				adultNumericUpDown.Frame = new CGRect(10, 40, view.Frame.Width-20, 32);
				infantsNumericUpDown.Frame = new CGRect(10, 150, view.Frame.Width-20,32);

				adultLabel.Frame = new CGRect(15, 0, this.Frame.Size.Width-20, 30);
				infantLabel.Frame = new CGRect(15, 110, this.Frame.Size.Width-20, 30);

				minimumText.Frame = new CGRect (230, 40, this.Frame.Size.Width - 250, 30);
				maximumText.Frame = new CGRect (230, 80, this.Frame.Size.Width - 250, 30);
				minPrefixCharacterLabel.Frame = new CGRect ( 10, 40,this.Frame.Size.Width-10 , 30);
				maxDropDownHeightLabel.Frame = new CGRect (10, 80, this.Frame.Size.Width - 10, 30);

				spinLabel.Frame=new CGRect(15,140, this.Frame.Size.Width-20, 40);
				spinAlignmentButton.Frame=new CGRect(10,180,  this.Frame.Size.Width-20, 40);
				autoReverse.Frame=new CGRect(15, 240, this.Frame.Size.Width-20, 40);
				autoSwitch.Frame=new CGRect(250,240,  this.Frame.Size.Width-20, 40);
				spinPicker.Frame=new CGRect(0,this.Frame.Size.Height/4, this.Frame.Size.Width,this.Frame.Size.Height/3);
				cultureDoneButton.Frame=new CGRect(0, this.Frame.Size.Height/4, this.Frame.Size.Width, 40);
			}
			this.optionView ();
			base.LayoutSubviews ();
		}
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}
		public NumericUpDown_Mobile()
		{
			this.OptionView = new UIView();
			//cultureList
			this.cultureList.Add((NSString)"Right");
			this.cultureList.Add((NSString)"Left");
			this.cultureList.Add((NSString)"Both");

			//adultNumericUpDown
			adultNumericUpDown = new SFNumericUpDown();
			adultNumericUpDown.AllowNull = true;
			adultNumericUpDown.PercentDisplayMode = SFNumericUpDownPercentDisplayMode.Compute;
			adultNumericUpDown.ValueChangeMode = SFNumericUpDownValueChangeMode.OnLostFocus;
			adultNumericUpDown.Value = 5;
			adultNumericUpDown.Minimum = 0;
			adultNumericUpDown.Maximum = 100;
		    adultNumericUpDown.MaximumDecimalDigits = 0;
            adultNumericUpDown.Culture = new NSLocale("en_US");
			this.AddSubview(adultNumericUpDown);

			//infantsNumericUpDown
			infantsNumericUpDown = new SFNumericUpDown();
			infantsNumericUpDown.AllowNull = true;
			infantsNumericUpDown.PercentDisplayMode = SFNumericUpDownPercentDisplayMode.Compute;
			infantsNumericUpDown.Value = 3;
			infantsNumericUpDown.Minimum = 0;
			infantsNumericUpDown.Maximum = 100;
		    infantsNumericUpDown.MaximumDecimalDigits = 0;
            infantsNumericUpDown.Culture = new NSLocale("en_US");
			this.AddSubview(infantsNumericUpDown);

			mainPageDesign();

		}
		public void mainPageDesign()
		{
			//adultLabell
			adultLabel = new UILabel();
			adultLabel.TextColor = UIColor.Black;
			adultLabel.BackgroundColor = UIColor.Clear;
			adultLabel.Text = @"Number of Adults";
			adultLabel.TextAlignment = UITextAlignment.Left;
			adultLabel.Font = UIFont.FromName("Helvetica", 16f);
			this.AddSubview(adultLabel);

			//infantLabell
			infantLabel = new UILabel();
			infantLabel.TextColor = UIColor.Black;
			infantLabel.BackgroundColor = UIColor.Clear;
			infantLabel.Text = @"Number of Infants";
			infantLabel.TextAlignment = UITextAlignment.Left;
			infantLabel.Font = UIFont.FromName("Helvetica", 16f);
			this.AddSubview(infantLabel);

			//autoReversee
			autoReverse = new UILabel();
			autoReverse.TextColor = UIColor.Black;
			autoReverse.BackgroundColor = UIColor.Clear;
			autoReverse.Text = @"Auto Reverse";
			autoReverse.TextAlignment = UITextAlignment.Left;
			autoReverse.Font = UIFont.FromName("Helvetica", 16f);

			//autoSwitchh
			autoSwitch = new UISwitch();
			autoSwitch.ValueChanged += autoReverseToggleChanged;
			autoSwitch.On = false;

			//spinLabell
			spinLabel = new UILabel();
			spinLabel.TextColor = UIColor.Black;
			spinLabel.BackgroundColor = UIColor.Clear;
			spinLabel.Text = @"Spin Alignment";
			spinLabel.TextAlignment = UITextAlignment.Left;
			spinLabel.Font = UIFont.FromName("Helvetica", 16f);

			//spinAlignmentButtonn
			spinAlignmentButton = new UIButton();
			spinAlignmentButton.SetTitle("Right", UIControlState.Normal);
			spinAlignmentButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			spinAlignmentButton.BackgroundColor = UIColor.Clear;
			spinAlignmentButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			spinAlignmentButton.Hidden = false;
			spinAlignmentButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
			spinAlignmentButton.Layer.BorderWidth = 4;
			spinAlignmentButton.Layer.CornerRadius = 8;
			spinAlignmentButton.TouchUpInside += ShowSpinPicker;

			minPrefixCharacterLabel = new UILabel();
			maxDropDownHeightLabel = new UILabel();

			//minPrefixCharacterLabell
			minPrefixCharacterLabel.Text = "Minimum";
			minPrefixCharacterLabel.TextColor = UIColor.Black;
			minPrefixCharacterLabel.TextAlignment = UITextAlignment.Left;
			minPrefixCharacterLabel.Font = UIFont.FromName("Helvetica", 16f);

			//maxDropDownHeightLabell
			maxDropDownHeightLabel.Text = "Maximum";
			maxDropDownHeightLabel.TextColor = UIColor.Black;
			maxDropDownHeightLabel.TextAlignment = UITextAlignment.Left;
			maxDropDownHeightLabel.Font = UIFont.FromName("Helvetica", 16f);

			//Textt
			minimumText = new UITextView();
			maximumText = new UITextView();
			minimumText.Layer.BorderColor = UIColor.Black.CGColor;
			maximumText.Layer.BorderColor = UIColor.Black.CGColor;
			minimumText.BackgroundColor = UIColor.FromRGB(246, 246, 246);
			maximumText.BackgroundColor = UIColor.FromRGB(246, 246, 246);
			minimumText.KeyboardType = UIKeyboardType.NumberPad;
			maximumText.KeyboardType = UIKeyboardType.NumberPad;
			minimumText.Text = "0";
			maximumText.Text = "100";
			maximumText.Font = UIFont.FromName("Helvetica", 16f);
			minimumText.Font = UIFont.FromName("Helvetica", 16f);
			maximumText.Changed += (object sender, EventArgs e) =>
			 {
				 if (maximumText.Text.Length > 0)
				 {
					 adultNumericUpDown.Maximum = nfloat.Parse(maximumText.Text);
					 infantsNumericUpDown.Maximum = nfloat.Parse(maximumText.Text);
				 }

			 };
			minimumText.Changed += (object sender, EventArgs e) =>
			 {
				 if (minimumText.Text.Length > 0)
				 {
					 adultNumericUpDown.Minimum = nfloat.Parse(minimumText.Text);
					 infantsNumericUpDown.Minimum = nfloat.Parse(minimumText.Text);
				 }
			 };

			//spinPickerr
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
					infantsNumericUpDown.TextAlignment=UITextAlignment.Left;
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
			spinPicker.BackgroundColor = UIColor.White;

			//cultureDoneButtonn
			cultureDoneButton = new UIButton();
			cultureDoneButton.SetTitle("Done\t", UIControlState.Normal);
			cultureDoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			cultureDoneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
			cultureDoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			cultureDoneButton.Hidden = true;
			cultureDoneButton.TouchUpInside += HideSpinPicker;

			this.BackgroundColor = UIColor.White;
		
		}
		void ShowSpinPicker (object sender, EventArgs e) {
			cultureDoneButton.Hidden = false;
			spinPicker.Hidden = false;
			this.BecomeFirstResponder ();
		}

		void HideSpinPicker (object sender, EventArgs e) {
			cultureDoneButton.Hidden = true;
			spinPicker.Hidden = true;
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

