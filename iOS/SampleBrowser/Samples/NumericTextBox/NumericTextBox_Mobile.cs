#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfNumericTextBox.iOS;
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
	public class NumericTextBox_Mobile : SampleView
	{
		UIPickerView culturePicker;
		UILabel titleLabel, descriptionLabel, formulaLabel, principalLabel, interestRateLabel, termLabel, interestLabel, cultureLabel,allowNullLabel;
		UISwitch allowSwitch;
		UIButton cultureDoneButton,cultureButton;
		private string cultureSelectedType;
		SfNumericTextBox principalNumericTextBox;
		SfNumericTextBox interestRateNumericTextBox;
		SfNumericTextBox periodNumericTextBox;
		SfNumericTextBox outputNumericTextBox;
		public UIView option = new UIView ();
		private readonly IList<string> cultureList = new List<string> ();
		public void  optionView()
		{
			this.option.AddSubview(allowNullLabel);
			this.option.AddSubview(allowSwitch);
			this.option.AddSubview(cultureLabel);
			this.option.AddSubview (cultureDoneButton);
			this.option.AddSubview(culturePicker);
			this.option.AddSubview (cultureButton);
			
		}
		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Bounds;
				this.OptionView.Frame = view.Frame;
				this.option.Frame = new CGRect (0, 70, Frame.Width, Frame.Height);
				principalNumericTextBox.Frame = new CGRect(200, 120, view.Frame.Width-220, 40);
				interestRateNumericTextBox.Frame = new CGRect(200, 180, view.Frame.Width-220, 40);
				periodNumericTextBox.Frame = new CGRect(200, 240, view.Frame.Width-220, 40);
				outputNumericTextBox.Frame = new CGRect(200, 300, view.Frame.Width-220, 40);
				titleLabel.Frame =new CGRect(15, 0, this.Frame.Size.Width-20, 50);
				descriptionLabel.Frame = new CGRect(15, 35, this.Frame.Size.Width-20, 50);
				formulaLabel.Frame = new CGRect(15, 60, this.Frame.Size.Width-20, 50);
				principalLabel.Frame = new CGRect(15, 120, this.Frame.Size.Width-20, 50);
				interestRateLabel.Frame = new CGRect(15, 180, this.Frame.Size.Width-20, 50);
				termLabel.Frame = new CGRect(15, 240, this.Frame.Size.Width-20, 50);
				interestLabel.Frame = new CGRect(15, 300, this.Frame.Size.Width-20, 50);
				cultureLabel.Frame=new CGRect(15, 40, this.Frame.Size.Width-20, 40);
				cultureButton.Frame=new CGRect(10,80,  this.Frame.Size.Width-20, 40);
				allowNullLabel.Frame=new CGRect(15, 140, this.Frame.Size.Width-20, 40);
				allowSwitch.Frame=new CGRect(250,140,  this.Frame.Size.Width-20, 40);
				culturePicker.Frame=new CGRect(0,this.Frame.Size.Height/4+20, this.Frame.Size.Width,this.Frame.Size.Height/3);
				cultureDoneButton.Frame=new CGRect(0, this.Frame.Size.Height/4-20, this.Frame.Size.Width, 40);
			}
			this.optionView ();
			base.LayoutSubviews ();
		}
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}
		public NumericTextBox_Mobile ()
		{
			this.OptionView = new UIView ();
			//cultureList
			this.cultureList.Add ((NSString)"United States");
			this.cultureList.Add ((NSString)"United Kingdom");
			this.cultureList.Add ((NSString)"Japan");
			this.cultureList.Add ((NSString)"France");
			this.cultureList.Add ((NSString)"Italy");

			//principalNumericTextBox
			principalNumericTextBox= new SfNumericTextBox();
			principalNumericTextBox.Watermark = "Enter Principal";
			principalNumericTextBox.AllowNull = true;
			principalNumericTextBox.MaximumNumberDecimalDigits = 2;
			principalNumericTextBox.PercentDisplayMode = SFNumericTextBoxPercentDisplayMode.Compute;
			principalNumericTextBox.ValueChangeMode = SFNumericTextBoxValueChangeMode.OnLostFocus;
			principalNumericTextBox.FormatString = "c";
			principalNumericTextBox.Value = 1000;
			principalNumericTextBox.CultureInfo = new NSLocale ("en_US");
			this.AddSubview(principalNumericTextBox);

			//interestRateNumericTextBox
			interestRateNumericTextBox= new SfNumericTextBox();
			interestRateNumericTextBox.Watermark = "Enter RI";
			interestRateNumericTextBox.AllowNull = true;
			interestRateNumericTextBox.MaximumNumberDecimalDigits = 0;
			interestRateNumericTextBox.PercentDisplayMode = SFNumericTextBoxPercentDisplayMode.Compute;
			interestRateNumericTextBox.ValueChangeMode = SFNumericTextBoxValueChangeMode.OnLostFocus;
			interestRateNumericTextBox.FormatString = @"p";
			interestRateNumericTextBox.Value = 1f;
			interestRateNumericTextBox.CultureInfo = new NSLocale ("en_US");
			this.AddSubview(interestRateNumericTextBox);

			//periodNumericTextBox
			periodNumericTextBox= new SfNumericTextBox();
			periodNumericTextBox.Watermark = @"Enter Years";
			periodNumericTextBox.AllowNull = true;
			periodNumericTextBox.MaximumNumberDecimalDigits = 0;
			periodNumericTextBox.PercentDisplayMode = SFNumericTextBoxPercentDisplayMode.Compute;
			periodNumericTextBox.ValueChangeMode = SFNumericTextBoxValueChangeMode.OnLostFocus;
			periodNumericTextBox.FormatString = @"years";
			periodNumericTextBox.Value = 20;
			periodNumericTextBox.CultureInfo = new NSLocale ("en_US");
			this.AddSubview(periodNumericTextBox);

			//outputNumericTextBox
			outputNumericTextBox= new SfNumericTextBox();
			outputNumericTextBox.Watermark = @"Enter a number";
			outputNumericTextBox.AllowNull = true;
			outputNumericTextBox.MaximumNumberDecimalDigits = 0;
			outputNumericTextBox.PercentDisplayMode = SFNumericTextBoxPercentDisplayMode.Compute;
			outputNumericTextBox.ValueChangeMode = SFNumericTextBoxValueChangeMode.OnLostFocus;
			outputNumericTextBox.FormatString = @"c";
			outputNumericTextBox.Value = 2000;
			outputNumericTextBox.Enabled = false;
			outputNumericTextBox.TextColor = UIColor.Gray;
			outputNumericTextBox.CultureInfo = new NSLocale ("en_US");
			this.AddSubview(outputNumericTextBox);
			principalNumericTextBox.ValueChanged += Box_ValueChanged;
            periodNumericTextBox.ValueChanged += Box_ValueChanged;
            interestRateNumericTextBox.ValueChanged += Box_ValueChanged;
			mainPageDesign();
		
		}
		void Box_ValueChanged(object sender, ValueEventArgs e)
		{
			outputNumericTextBox.Value = Convert.ToDecimal( principalNumericTextBox.Value )*Convert.ToDecimal(interestRateNumericTextBox.Value) *Convert.ToDecimal(periodNumericTextBox.Value);
		}
		public void mainPageDesign()
		{
			//titleLabell
			titleLabel = new UILabel();
			titleLabel.TextColor = UIColor.Black;
			titleLabel.BackgroundColor = UIColor.Clear;
			titleLabel.Text = @"Simple Interest Calculator";
			titleLabel.TextAlignment = UITextAlignment.Left;
			titleLabel.Font = UIFont.FromName("Helvetica", 20f);
			this.AddSubview(titleLabel);
		
			//descriptionLabell
			descriptionLabel = new UILabel();
			descriptionLabel.TextColor = UIColor.Black;
			descriptionLabel.BackgroundColor = UIColor.Clear;
			descriptionLabel.Text = @"The formula for finding simple interest is:";
			descriptionLabel.TextAlignment = UITextAlignment.Left;
			descriptionLabel.Font = UIFont.FromName("Helvetica", 16f);
			this.AddSubview(descriptionLabel);

			//formulaLabell
			formulaLabel = new UILabel();
			formulaLabel.TextColor = UIColor.Black;
			formulaLabel.BackgroundColor = UIColor.Clear;
			formulaLabel.Text = @"Interest = Principal * Rate * Time";
			formulaLabel.TextAlignment = UITextAlignment.Left;
			formulaLabel.Font = UIFont.FromName("Helvetica", 16f);
			this.AddSubview(formulaLabel);

			//principalLabell
			principalLabel = new UILabel();
			principalLabel.TextColor = UIColor.Black;
			principalLabel.BackgroundColor = UIColor.Clear;
			principalLabel.Text = @"Principal";
			principalLabel.TextAlignment = UITextAlignment.Left;
			principalLabel.Font = UIFont.FromName("Helvetica", 13f);
			this.AddSubview(principalLabel);

			//interestRateLabell
			interestRateLabel = new UILabel();
			interestRateLabel.TextColor = UIColor.Black;
			interestRateLabel.BackgroundColor = UIColor.Clear;
			interestRateLabel.Text = @"Interest Rate";
			interestRateLabel.TextAlignment = UITextAlignment.Left;
			interestRateLabel.Font = UIFont.FromName("Helvetica", 13f);
			this.AddSubview(interestRateLabel);
		
			//termLabell
			termLabel = new UILabel();
			termLabel.TextColor = UIColor.Black;
			termLabel.BackgroundColor = UIColor.Clear;
			termLabel.Text = @"Term";
			termLabel.TextAlignment = UITextAlignment.Left;
			termLabel.Font = UIFont.FromName("Helvetica", 13f);
			this.AddSubview(termLabel);

			//interestLabell
			interestLabel = new UILabel();
			interestLabel.TextColor = UIColor.Black;
			interestLabel.BackgroundColor = UIColor.Clear;
			interestLabel.Text = @"Interest";
			interestLabel.TextAlignment = UITextAlignment.Left;
			interestLabel.Font = UIFont.FromName("Helvetica", 13f);
			this.AddSubview(interestLabel);

			//allowNullLabell
			allowNullLabel = new UILabel();
			allowNullLabel.TextColor = UIColor.Black;
			allowNullLabel.BackgroundColor = UIColor.Clear;
			allowNullLabel.Text = @"Allow Null";
			allowNullLabel.TextAlignment = UITextAlignment.Left;
			allowNullLabel.Font = UIFont.FromName("Helvetica", 16f);

			//allowSwitchh
			allowSwitch = new UISwitch();
			allowSwitch.ValueChanged += allowNullToggleChanged;
			allowSwitch.On = true;

			//cultureLabell
			cultureLabel = new UILabel();
			cultureLabel.TextColor = UIColor.Black;
			cultureLabel.BackgroundColor = UIColor.Clear;
			cultureLabel.Text = @"Culture";
			cultureLabel.TextAlignment = UITextAlignment.Left;
			cultureLabel.Font = UIFont.FromName("Helvetica", 16f);
			//			this.OptionView.AddSubview(cultureLabel);

			//cultureButtonn
			cultureButton = new UIButton();
			cultureButton.SetTitle("United States", UIControlState.Normal);
			cultureButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			cultureButton.BackgroundColor = UIColor.Clear;
			cultureButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			cultureButton.Hidden = false;
			cultureButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
			cultureButton.Layer.BorderWidth = 4;
			cultureButton.Layer.CornerRadius = 8;
			cultureButton.TouchUpInside += ShowCulturePicker;

			//culturePickerr
			PickerModel culturePickermodel = new PickerModel(this.cultureList);
			culturePickermodel.PickerChanged += (sender, e) =>
			{
				this.cultureSelectedType = e.SelectedValue;
				cultureButton.SetTitle(cultureSelectedType, UIControlState.Normal);
				if (cultureSelectedType == "United States")
				{
					principalNumericTextBox.CultureInfo = new NSLocale("en_US");
					interestRateNumericTextBox.CultureInfo = new NSLocale("en_US");
					periodNumericTextBox.CultureInfo = new NSLocale("en_US");
					outputNumericTextBox.CultureInfo = new NSLocale("en_US");
				}
				else if (cultureSelectedType == "United Kingdom")
				{
					principalNumericTextBox.CultureInfo = new NSLocale("en_UK");
					interestRateNumericTextBox.CultureInfo = new NSLocale("en_UK");
					periodNumericTextBox.CultureInfo = new NSLocale("en_UK");
					outputNumericTextBox.CultureInfo = new NSLocale("en_UK");
				}
				else if (cultureSelectedType == "Japan")
				{
					principalNumericTextBox.CultureInfo = new NSLocale("ja_JP");
					interestRateNumericTextBox.CultureInfo = new NSLocale("ja_JP");
					periodNumericTextBox.CultureInfo = new NSLocale("ja_JP");
					outputNumericTextBox.CultureInfo = new NSLocale("ja_JP");
				}
				else if (cultureSelectedType == "France")
				{
					principalNumericTextBox.CultureInfo = new NSLocale("fr_FR");
					interestRateNumericTextBox.CultureInfo = new NSLocale("fr_FR");
					periodNumericTextBox.CultureInfo = new NSLocale("fr_FR");
					outputNumericTextBox.CultureInfo = new NSLocale("fr_FR");
				}
				else if (cultureSelectedType == "Italy")
				{
					principalNumericTextBox.CultureInfo = new NSLocale("it_IT");
					interestRateNumericTextBox.CultureInfo = new NSLocale("it_IT");
					periodNumericTextBox.CultureInfo = new NSLocale("it_IT");
					outputNumericTextBox.CultureInfo = new NSLocale("it_IT");
				}
			};
			culturePicker = new UIPickerView();
			culturePicker.ShowSelectionIndicator = true;
			culturePicker.Hidden = true;
			culturePicker.Model = culturePickermodel;
			culturePicker.BackgroundColor = UIColor.White;

			//cultureDoneButtonn
			cultureDoneButton = new UIButton();
			cultureDoneButton.SetTitle("Done\t", UIControlState.Normal);
			cultureDoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			cultureDoneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
			cultureDoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			cultureDoneButton.Hidden = true;
			cultureDoneButton.TouchUpInside += HideCulturePicker;
 
			this.BackgroundColor = UIColor.White;
		}

		void ShowCulturePicker (object sender, EventArgs e) {
			cultureDoneButton.Hidden = false;
			culturePicker.Hidden = false;
			this.BecomeFirstResponder ();
		}

		void HideCulturePicker (object sender, EventArgs e) {
			cultureDoneButton.Hidden = true;
			culturePicker.Hidden = true;
			this.BecomeFirstResponder ();
		}
		private void allowNullToggleChanged(object sender, EventArgs e)
		{
			if (((UISwitch)sender).On) {
				principalNumericTextBox.AllowNull = true;
				interestRateNumericTextBox.AllowNull = true;
				periodNumericTextBox.AllowNull = true;
				outputNumericTextBox.AllowNull = true;
			} else {
				principalNumericTextBox.AllowNull = false;
				interestRateNumericTextBox.AllowNull = false;
				periodNumericTextBox.AllowNull = false;
				outputNumericTextBox.AllowNull = false;
			}
		}

		public override void TouchesBegan (NSSet touches, UIEvent evt){
			this.EndEditing (true);
		}
	}

}

