#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

using UIKit;
using CoreGraphics;
using System.Collections.ObjectModel;
using CoreAnimation;
using SampleBrowser;
using Foundation;
using Syncfusion.Calculate;

namespace SampleBrowser
{
    public partial class CalcQuickCalculation : SampleView
	{
        #region Fields

		CalcQuickView calcQuickView;

		#endregion

		#region Constructor

		public CalcQuickCalculation ()
		{
			calcQuickView = new CalcQuickView ();
			this.AddSubview (calcQuickView);
		}

		#endregion

		#region Methods

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Bounds;
			}
			base.LayoutSubviews ();
		}

		protected override void Dispose (bool disposing)
		{
			calcQuickView.Dispose ();
			base.Dispose (disposing);
		}
			
        #endregion
    }

	public class CalcQuickView : UIScrollView
	{
		#region Fields

		CalcQuickBase calcQuickBase; 
		UITextField editTextA;
		UITextField editTextB;
		UITextField editTextC;
		UILabel titleLabel;
		UILabel expressionTitle;
		UILabel descripLabel;
		UILabel expression1;
		UILabel expression2;
		UILabel expression3;
		UILabel result1;
		UILabel result2;
		UILabel result3;
		UILabel textA;
		UILabel textB;
		UILabel textC;
		CALayer layer1;
		CALayer layer2;
		CALayer layer3;
		UIButton calculateButton;
		NSObject showNotification;
		NSObject hideNotification;

		#endregion

		#region Constructor

		public CalcQuickView ()
		{
			InitializeCalcQuick ();
			CreateCalcQuickDesign ();
			RegisterForKeyboardNotifications ();
		}

		#endregion

		#region Methods

		public override void LayoutSubviews ()
		{
			this.ContentSize = new CGSize (Frame.Width, 550);

			var width = Frame.Width - 20;
			var height = Frame.Height;

			titleLabel.Frame = new CGRect (5, 15, width, 25);
			descripLabel.Frame = new CGRect (5, 45, width, 30);

			textA.Frame = new CGRect (5, 70, width / 2 , 40);
			editTextA.Frame = new CGRect ((width / 2) + 5, 70, width / 2, 40);

			textB.Frame = new CGRect (5, 110, width / 2 , 40);
			editTextB.Frame = new CGRect ((width / 2) + 5, 110, width / 2, 40);

			textC.Frame = new CGRect (5, 150, width / 2 , 40);
			editTextC.Frame = new CGRect ((width / 2) + 5, 150, width / 2, 40);

			calculateButton.Frame = new CGRect (5, 200, width, 30);
			expressionTitle.Frame = new CGRect (5, 240, width, 30);

			expression1.Frame = new CGRect (5, 270, width / 2, 40);
			result1.Frame = new CGRect ((width / 2) + 5, 270, width / 2, 40);
			layer1.Frame = new CGRect (result1.Bounds.Left, result1.Bounds.Bottom - 5, result1.Bounds.Right, 1);

			expression2.Frame = new CGRect (5, 310, width / 2, 40);
			result2.Frame = new CGRect ((width / 2) + 5, 310, width / 2, 40);
			layer2.Frame = new CGRect (result2.Bounds.Left, result2.Bounds.Bottom - 5, result2.Bounds.Right, 1);

			expression3.Frame = new CGRect (5, 350, width / 2, 40);
			result3.Frame = new CGRect ((width / 2) + 5, 350, width / 2, 40);
			layer3.Frame = new CGRect (result3.Bounds.Left, result3.Bounds.Bottom - 5, result3.Bounds.Right, 1);

			base.LayoutSubviews ();
		}

		private void CreateCalcQuickDesign()
		{
			#region Header 

			titleLabel = new UILabel();
			titleLabel.Text = "CalcQuick Calculation";
			titleLabel.Font = UIFont.FromName ("Helvetica-Bold", 25f);
			titleLabel.TextAlignment = UITextAlignment.Center;

			descripLabel = new UILabel();
			descripLabel.Text = "This sample demonstrates the calculation via keys and expressions using CalcQuick.";
			descripLabel.Lines = 0;
			descripLabel.LineBreakMode = UILineBreakMode.WordWrap;
			descripLabel.Font = UIFont.FromName ("Helvetica", 12f);

			#endregion

			#region Arguments and Result

			textA = CreateLabel ("Key A");
			textB = CreateLabel ("Key B");
			textC = CreateLabel ("Key C");
			expression1 = CreateLabel ("Sum([A],[B],[C])");
			expression2 = CreateLabel ("PI()*([A]^2)");
			expression3 = CreateLabel ("Concatenate([A],[B],[C])");

			layer1 = new CALayer() { BorderWidth = 1 , BorderColor = UIColor.Black.CGColor};
			layer2 = new CALayer() { BorderWidth = 1 , BorderColor = UIColor.Black.CGColor};
			layer3 = new CALayer() { BorderWidth = 1 , BorderColor = UIColor.Black.CGColor};

			result1 = CreateLabel (calcQuickBase["Exp1"]);
			result1.Layer.AddSublayer(layer1);
			result2 = CreateLabel (calcQuickBase["Exp2"]);
			result2.Layer.AddSublayer(layer2);
			result3 = CreateLabel (calcQuickBase["Exp3"]);
			result3.Layer.AddSublayer(layer3);

			editTextA = CreateTextField (calcQuickBase["A"]);
			editTextB = CreateTextField (calcQuickBase["B"]);
			editTextC = CreateTextField (calcQuickBase["C"]);

			expressionTitle = new UILabel();
			expressionTitle.Text = "CalcQuick Calculation";
			expressionTitle.Font = UIFont.FromName ("Helvetica-Bold", 18f);

			#endregion

			#region Compute

			calculateButton = new UIButton();
			calculateButton.SetTitle("Compute", UIControlState.Normal);
			calculateButton.Layer.BorderWidth = 1;
			calculateButton.Layer.CornerRadius = 4;
			calculateButton.SetTitleColor(UIColor.Black,UIControlState.Highlighted);
			calculateButton.BackgroundColor = UIColor.LightGray;
			calculateButton.TouchUpInside += CalculateButton_TouchUpInside;

			#endregion

			AddSubview (titleLabel);
			AddSubview (descripLabel);
			AddSubview (textA);
			AddSubview (textB);
			AddSubview (textC);
			AddSubview (editTextA);
			AddSubview (editTextB);
			AddSubview (editTextC);
			AddSubview (calculateButton);
			AddSubview (expressionTitle);
			AddSubview (expression1);
			AddSubview (expression2);
			AddSubview (expression3);
			AddSubview (result1);
			AddSubview (result2);
			AddSubview (result3);
		}

		private void InitializeCalcQuick()
		{
			calcQuickBase = new CalcQuickBase();
			calcQuickBase.Engine.UseNoAmpersandQuotes = true;

			calcQuickBase["A"] = "25";
			calcQuickBase["B"] = "50";
			calcQuickBase["C"] = "10";

			calcQuickBase["Exp1"] = "=Sum([A],[B],[C])";
			calcQuickBase["Exp2"] = "=PI()*([A]^2)";
			calcQuickBase["Exp3"] = "=Concatenate([A],[B],[C])";
		}

		private void CalculateButton_TouchUpInside (object sender, EventArgs e)
		{
            this.EndEditing(true);

			calcQuickBase["A"] = editTextA.Text;
			calcQuickBase["B"] = editTextB.Text;
			calcQuickBase["C"] = editTextC.Text;

			calcQuickBase.SetDirty();

			result1.Text = calcQuickBase["Exp1"];
			result2.Text = calcQuickBase["Exp2"];
			result3.Text = calcQuickBase["Exp3"];
		}

		private UILabel CreateLabel(string text)
		{
			return new UILabel () { 
				Text = text,
				Font = UIFont.FromName ("Helvetica", 14f)
			};
		}

		private UITextField CreateTextField(string text)
		{
			var textField = new UITextField () { 
				Text = text,
				Font = UIFont.FromName ("Helvetica", 14f)
			};
			textField.ResignFirstResponder ();
			return textField;
		}

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            this.EndEditing(true);
        }

		protected virtual void RegisterForKeyboardNotifications()
		{
			hideNotification = NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, OnKeyboardNotification);
			showNotification = NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillShowNotification, OnKeyboardNotification);
		}

		private void OnKeyboardNotification (NSNotification notification)
		{
			var visible = notification.Name == UIKeyboard.WillShowNotification;
			var keyboardFrame = visible
				? UIKeyboard.FrameEndFromNotification(notification)
				: UIKeyboard.FrameBeginFromNotification(notification); 	

			if (visible) 
				this.SetContentOffset (new CGPoint (this.Frame.Left, (this.Frame.Height - keyboardFrame.Height) / 2), false);
			else 
				this.SetContentOffset (new CGPoint (this.Frame.Left, this.Frame.Top), false);
		}

		protected override void Dispose (bool disposing)
		{
			if (calcQuickBase != null) {
				calcQuickBase.Dispose ();
				calcQuickBase = null;
			}

			NSNotificationCenter.DefaultCenter.RemoveObserver(showNotification);
			NSNotificationCenter.DefaultCenter.RemoveObserver(hideNotification);

			base.Dispose (disposing);
		}

		#endregion
	}
}

