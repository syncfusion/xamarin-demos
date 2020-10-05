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
	public class NumericTextBox_Tablet : SampleView
	{
		UIPickerView culturePicker;
		UILabel titleLabel, descriptionLabel, formulaLabel, principalLabel, interestRateLabel, termLabel, interestLabel, cultureLabel,allowNullLabel,propertiesLabel;
		UISwitch allowSwitch;
		UIButton cultureDoneButton,cultureButton;
		UIView subView = new UIView();
		UIView contentView,controlView;
		UIButton showPropertyButton,closeButton;
		private string cultureSelectedType;
		SfNumericTextBox principalNumericTextBox;
		SfNumericTextBox interestRateNumericTextBox;
		SfNumericTextBox periodNumericTextBox;
		SfNumericTextBox outputNumericTextBox;

		private readonly IList<string> cultureList = new List<string> ();

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Bounds;
				subView.Frame = new CGRect (0, this.Frame.Size.Height-this.Frame.Size.Height/3+75, this.Frame.Size.Width, this.Frame.Height / 3-75);
				controlView.Frame=new CGRect(150,40,this.Frame.Size.Width-200,this.Frame.Size.Height-40);
				contentView.Frame=new CGRect(0,40,subView.Frame.Size.Width,subView.Frame.Size.Height-30);
				principalNumericTextBox.Frame = new CGRect(200, 120, controlView.Frame.Width-320, 40);
				interestRateNumericTextBox.Frame = new CGRect(200, 180, controlView.Frame.Width-320, 40);
				periodNumericTextBox.Frame = new CGRect(200, 240, controlView.Frame.Width-320, 40);
				outputNumericTextBox.Frame = new CGRect(200, 300, controlView.Frame.Width-320, 40);
				titleLabel.Frame =new CGRect(15, 0, controlView.Frame.Size.Width-20, 50);
				descriptionLabel.Frame = new CGRect(15, 48, controlView.Frame.Size.Width-20, 50);
				formulaLabel.Frame = new CGRect(269, 48, controlView.Frame.Size.Width-20, 50);
				principalLabel.Frame = new CGRect(15, 120, controlView.Frame.Size.Width-20, 50);
				interestRateLabel.Frame = new CGRect(15, 180, controlView.Frame.Size.Width-20, 50);
				termLabel.Frame = new CGRect(15, 240, controlView.Frame.Size.Width-20, 50);
				interestLabel.Frame = new CGRect(15, 300, controlView.Frame.Size.Width-20, 50);
				cultureLabel.Frame=new CGRect(110, 40, contentView.Frame.Size.Width-220, 40);
				cultureButton.Frame=new CGRect(350,40,  contentView.Frame.Size.Width-520, 40);
				allowNullLabel.Frame=new CGRect(110, 100, contentView.Frame.Size.Width-220, 40);
				allowSwitch.Frame=new CGRect(350,100,  contentView.Frame.Size.Width-220, 40);
				culturePicker.Frame=new CGRect(100,20, contentView.Frame.Size.Width-200,150);
				cultureDoneButton.Frame=new CGRect(100, 0, contentView.Frame.Size.Width-200, 40);
				showPropertyButton.Frame = new CGRect (0, this.Frame.Size.Height -25, this.Frame.Size.Width, 30);
				closeButton.Frame = new CGRect (this.Frame.Size.Width - 30, 5, 20, 30);
				propertiesLabel.Frame = new CGRect (10, 5, this.Frame.Width, 30);
			}
			base.LayoutSubviews ();
		}
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}
		public NumericTextBox_Tablet ()
		{
			controlView = new UIView();

			//principalNumericTextBox
			principalNumericTextBox= new SfNumericTextBox();
			principalNumericTextBox.Watermark = "Enter Principal";
			principalNumericTextBox.AllowNull = true;
			principalNumericTextBox.MaximumNumberDecimalDigits = 2;
			principalNumericTextBox.PercentDisplayMode = SFNumericTextBoxPercentDisplayMode.Compute;
			principalNumericTextBox.ValueChangeMode = SFNumericTextBoxValueChangeMode.OnLostFocus;
			principalNumericTextBox.FormatString = "c";
			principalNumericTextBox.Value = 1000;
			principalNumericTextBox.Layer.CornerRadius = 8;
			principalNumericTextBox.ClipsToBounds = true;
			principalNumericTextBox.Layer.BorderWidth = (nfloat)1.2;
			principalNumericTextBox.Layer.BorderColor = UIColor.Black.CGColor;
			principalNumericTextBox.CultureInfo = new NSLocale ("en_US");
			controlView.AddSubview(principalNumericTextBox);

			//interestRateNumericTextBox
			interestRateNumericTextBox= new SfNumericTextBox();
			interestRateNumericTextBox.Watermark = "Enter RI";
			interestRateNumericTextBox.AllowNull = true;
			interestRateNumericTextBox.Layer.CornerRadius = 8;
			interestRateNumericTextBox.ClipsToBounds = true;
			interestRateNumericTextBox.Layer.BorderWidth = (nfloat)1.2;
			interestRateNumericTextBox.MaximumNumberDecimalDigits = 0;
			interestRateNumericTextBox.PercentDisplayMode = SFNumericTextBoxPercentDisplayMode.Compute;
			interestRateNumericTextBox.ValueChangeMode = SFNumericTextBoxValueChangeMode.OnLostFocus;
			interestRateNumericTextBox.FormatString = @"p";
			interestRateNumericTextBox.Value = 1f;
			interestRateNumericTextBox.CultureInfo = new NSLocale ("en_US");
			controlView.AddSubview(interestRateNumericTextBox);

			//periodNumericTextBox
			periodNumericTextBox= new SfNumericTextBox();
			periodNumericTextBox.Watermark = @"Enter Years";
			periodNumericTextBox.AllowNull = true;
			periodNumericTextBox.MaximumNumberDecimalDigits = 0;
			periodNumericTextBox.Layer.CornerRadius = 8;
			periodNumericTextBox.ClipsToBounds = true;
			periodNumericTextBox.Layer.BorderWidth = (nfloat)1.2;
			periodNumericTextBox.PercentDisplayMode = SFNumericTextBoxPercentDisplayMode.Compute;
			periodNumericTextBox.ValueChangeMode = SFNumericTextBoxValueChangeMode.OnLostFocus;
			periodNumericTextBox.FormatString = @"years";
			periodNumericTextBox.Value = 20;
			periodNumericTextBox.CultureInfo = new NSLocale ("en_US");
			controlView.AddSubview(periodNumericTextBox);

			//outputNumericTextBox
			outputNumericTextBox= new SfNumericTextBox();
			outputNumericTextBox.Watermark = @"Enter a number";
			outputNumericTextBox.AllowNull = true;
			outputNumericTextBox.MaximumNumberDecimalDigits = 0;
			outputNumericTextBox.Layer.CornerRadius = 8;
			outputNumericTextBox.ClipsToBounds = true;
			outputNumericTextBox.Layer.BorderWidth = (nfloat)1.2;
			outputNumericTextBox.PercentDisplayMode = SFNumericTextBoxPercentDisplayMode.Compute;
			outputNumericTextBox.ValueChangeMode = SFNumericTextBoxValueChangeMode.OnLostFocus;
			outputNumericTextBox.FormatString = @"c";
			outputNumericTextBox.Value = 2000;
			outputNumericTextBox.Enabled = false;
			outputNumericTextBox.TextColor = UIColor.Gray;
			outputNumericTextBox.CultureInfo = new NSLocale ("en_US");
			controlView.AddSubview(outputNumericTextBox);						
			this.AddSubview (controlView);

			principalNumericTextBox.ValueChanged += Box_ValueChanged;
            periodNumericTextBox.ValueChanged += Box_ValueChanged;
            interestRateNumericTextBox.ValueChanged += Box_ValueChanged;
			this.mainPageDesign();
			this.loadOptionView();
				
		}
		void Box_ValueChanged(object sender, ValueEventArgs e)
		{
			outputNumericTextBox.Value = Convert.ToDecimal( principalNumericTextBox.Value )* Convert.ToDecimal(interestRateNumericTextBox.Value) * Convert.ToDecimal(periodNumericTextBox.Value);
				}
		public void mainPageDesign()
		{
			

			//titleLabell
			titleLabel = new UILabel();
			titleLabel.TextColor = UIColor.Black;
			titleLabel.BackgroundColor = UIColor.Clear;
			titleLabel.Text = @"Simple Interest Calculator";
			titleLabel.TextAlignment = UITextAlignment.Left;
			titleLabel.Font = UIFont.FromName("Helvetica-Bold", 20f);
			controlView.AddSubview(titleLabel);

			//descriptionLabell
			descriptionLabel = new UILabel();
			descriptionLabel.TextColor = UIColor.Black;
			descriptionLabel.BackgroundColor = UIColor.Clear;
			descriptionLabel.Text = @"The formula for finding simple interest ";
			descriptionLabel.TextAlignment = UITextAlignment.Left;
			descriptionLabel.Font = UIFont.FromName("Helvetica", 14f);
			controlView.AddSubview(descriptionLabel);

			//formulaLabell
			formulaLabel = new UILabel();
			formulaLabel.TextColor = UIColor.Black;
			formulaLabel.BackgroundColor = UIColor.Clear;
			formulaLabel.Text = @"= Principal * Rate * Time";
			formulaLabel.TextAlignment = UITextAlignment.Left;
			formulaLabel.Font = UIFont.FromName("Helvetica", 14f);
			controlView.AddSubview(formulaLabel);

			//principalLabell
			principalLabel = new UILabel();
			principalLabel.TextColor = UIColor.Black;
			principalLabel.BackgroundColor = UIColor.Clear;
			principalLabel.Text = @"Principal";
			principalLabel.Font = UIFont.FromName("Helvetica", 16f);
			principalLabel.TextAlignment = UITextAlignment.Left;
			controlView.AddSubview(principalLabel);

			//interestRateLabell
			interestRateLabel = new UILabel();
			interestRateLabel.TextColor = UIColor.Black;
			interestRateLabel.BackgroundColor = UIColor.Clear;
			interestRateLabel.Font = UIFont.FromName("Helvetica", 16f);
			interestRateLabel.Text = @"Interest Rate";
			interestRateLabel.TextAlignment = UITextAlignment.Left;
			controlView.AddSubview(interestRateLabel);

			//termLabell
			termLabel = new UILabel();
			termLabel.TextColor = UIColor.Black;
			termLabel.BackgroundColor = UIColor.Clear;
			termLabel.Text = @"Term";
			termLabel.TextAlignment = UITextAlignment.Left;
			termLabel.Font = UIFont.FromName("Helvetica", 16f);
			controlView.AddSubview(termLabel);

			//interestLabell
			interestLabel = new UILabel();
			interestLabel.TextColor = UIColor.Black;
			interestLabel.BackgroundColor = UIColor.Clear;
			interestLabel.Text = @"Interest";
			interestLabel.TextAlignment = UITextAlignment.Left;
			interestLabel.Font = UIFont.FromName("Helvetica", 16f);
			controlView.AddSubview(interestLabel);
		}

		public void loadOptionView()
		{
			contentView = new UIView();

			//allowNullLabel
			allowNullLabel = new UILabel();
			allowNullLabel.TextColor = UIColor.Black;
			allowNullLabel.BackgroundColor = UIColor.Clear;
			allowNullLabel.Text = @"Allow Null";
			allowNullLabel.TextAlignment = UITextAlignment.Left;
			allowNullLabel.Font = UIFont.FromName("Helvetica", 14f);
			contentView.AddSubview(allowNullLabel);

			//allowSwitch
			allowSwitch = new UISwitch();
			allowSwitch.OnTintColor = UIColor.FromRGB(50, 150, 221);
			allowSwitch.ValueChanged += allowNullToggleChanged;
			allowSwitch.On = true;
			contentView.AddSubview(allowSwitch);

			//cultureLabel
			cultureLabel = new UILabel();
			cultureLabel.TextColor = UIColor.Black;
			cultureLabel.BackgroundColor = UIColor.Clear;
			cultureLabel.Text = @"Culture";
			cultureLabel.TextAlignment = UITextAlignment.Left;
			cultureLabel.Font = UIFont.FromName("Helvetica", 14f);
			contentView.AddSubview(cultureLabel);

			//adding locale to culture listt
			this.cultureList.Add((NSString)"United States");
			this.cultureList.Add((NSString)"United Kingdom");
			this.cultureList.Add((NSString)"Japan");
			this.cultureList.Add((NSString)"France");
			this.cultureList.Add((NSString)"Italy");

			//cultureButton
			cultureButton = new UIButton();
			cultureButton.SetTitle("United States", UIControlState.Normal);
			cultureButton.Font = UIFont.FromName("Helvetica", 14f);
			cultureButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			cultureButton.BackgroundColor = UIColor.Clear;
			cultureButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			cultureButton.Hidden = false;
			cultureButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
			cultureButton.Layer.BorderWidth = 4;
			cultureButton.Layer.CornerRadius = 8;
			cultureButton.TouchUpInside += (object sender, EventArgs e) =>
			{
				cultureDoneButton.Hidden = false;
				culturePicker.Hidden = false;
				allowNullLabel.Hidden = true;
				allowSwitch.Hidden = true;
			};
			contentView.AddSubview(cultureButton);

			//culturePickerModel
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

			//culturePicker
			culturePicker = new UIPickerView();
			culturePicker.ShowSelectionIndicator = true;
			culturePicker.Hidden = true;
			culturePicker.Model = culturePickermodel;
			culturePicker.BackgroundColor = UIColor.Gray;
			contentView.AddSubview(culturePicker);

			//cultureDoneButton
			cultureDoneButton = new UIButton();
			cultureDoneButton.SetTitle("Done\t", UIControlState.Normal);
			cultureDoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			cultureDoneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
			cultureDoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			cultureDoneButton.Hidden = true;
			cultureDoneButton.Font = UIFont.FromName("Helvetica", 14f);
			cultureDoneButton.TouchUpInside += HideCulturePicker;
			contentView.AddSubview(cultureDoneButton);

			//propertiesLabel
			propertiesLabel = new UILabel();
			propertiesLabel.Text = "OPTIONS";


			//showPropertyButton
			showPropertyButton = new UIButton();
			showPropertyButton.Hidden = true;
			showPropertyButton.SetTitle(" OPTIONS\t", UIControlState.Normal);
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

			//subVieww
			subView.AddSubview(closeButton);
			subView.AddSubview(propertiesLabel);
			subView.BackgroundColor = UIColor.FromRGB(230, 230, 230);
			contentView.BackgroundColor = UIColor.FromRGB(240, 240, 240);
			subView.AddSubview(contentView);
			this.AddSubview(subView);


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


		void ShowCulturePicker (object sender, EventArgs e) {
			cultureDoneButton.Hidden = false;
			culturePicker.Hidden = false;
			allowNullLabel.Hidden = true;
			allowSwitch.Hidden = true;
			cultureLabel.Hidden = true;
			this.BecomeFirstResponder ();
		}

		void HideCulturePicker (object sender, EventArgs e) {
			cultureDoneButton.Hidden = true;
			culturePicker.Hidden = true;
			allowNullLabel.Hidden = false;
			allowSwitch.Hidden = false;
			cultureLabel.Hidden = false;
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

