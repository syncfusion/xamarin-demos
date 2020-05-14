#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfBusyIndicator.iOS;

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
	public class BusyIndicator_Mobile : SampleView
	{
		private readonly IList<string> animationTypes = new List<string> ();

		private string selectedType;

		UIPickerView animationPicker = new UIPickerView ();
		UIButton animationTextButton = new UIButton ();
		UILabel animationTypeLabel = new UILabel ();
		UIButton doneButton = new UIButton ();
		SfBusyIndicator busyIndicator;
		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Bounds;
				busyIndicator.Frame=new CGRect(0,0, this.Frame.Size.Width,this.Frame.Size.Height);
				animationTypeLabel.Frame=new CGRect(15, 40, this.Frame.Size.Width-20, 40);
				animationTextButton.Frame=new CGRect(10,80,  this.Frame.Size.Width-20, 40);
				animationPicker.Frame=new CGRect(0,this.Frame.Size.Height-( this.Frame.Size.Height/3), this.Frame.Size.Width,this.Frame.Size.Height/3);
				doneButton.Frame=new CGRect(0, this.Frame.Size.Height-( this.Frame.Size.Height/3), this.Frame.Size.Width, 40);
			}
			base.LayoutSubviews ();
		}
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		#region View lifecycle
		//NSArray animationTypes = new NSArray ();

		public BusyIndicator_Mobile()
		{
			//BusyIndicator
			busyIndicator = new SfBusyIndicator ();
			busyIndicator.Foreground = UIColor.FromRGB (36,63,217);
			busyIndicator.ViewBoxWidth = 100;
			busyIndicator.ViewBoxHeight = 100;
			busyIndicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeBall;
			this.AddSubview (busyIndicator);

			mainPageDesign();
		}

		public void mainPageDesign()
		{
			//Animation Types
			animationTypeLabel.Text = "Animation Types";
			this.animationTypes.Add((NSString)"Ball");
			this.animationTypes.Add((NSString)"Battery");
			this.animationTypes.Add((NSString)"DoubleCircle");
			this.animationTypes.Add((NSString)"ECG");
			this.animationTypes.Add((NSString)"Globe");
			this.animationTypes.Add((NSString)"HorizontalPulsingBox");
			this.animationTypes.Add((NSString)"MovieTimer");
			this.animationTypes.Add((NSString)"Print");
			this.animationTypes.Add((NSString)"Rectangle");
			this.animationTypes.Add((NSString)"RollingBall");
			this.animationTypes.Add((NSString)"SingleCircle");
			this.animationTypes.Add((NSString)"SlicedCircle");
			this.animationTypes.Add((NSString)"ZoomingTarget");
			this.animationTypes.Add((NSString)"Gear");
		

			animationTypeLabel.TextColor = UIColor.Black;
			this.AddSubview(animationTypeLabel);

			//AnimationTextButton
			animationTextButton.SetTitle("Ball", UIControlState.Normal);
			animationTextButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			animationTextButton.BackgroundColor = UIColor.Clear;
			animationTextButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			animationTextButton.Hidden = false;
			animationTextButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
			animationTextButton.Layer.BorderWidth = 4;
			animationTextButton.Layer.CornerRadius = 8;
			animationTextButton.TouchUpInside += ShowPicker;
			this.AddSubview(animationTextButton);

			PickerModel model = new PickerModel(this.animationTypes);
			model.PickerChanged += (sender, e) =>
			{
				this.selectedType = e.SelectedValue;
				animationTextButton.SetTitle(selectedType, UIControlState.Normal);
				if (selectedType == "Ball")
				{
					busyIndicator.Duration = 1;
					busyIndicator.ViewBoxWidth = 70;
					busyIndicator.ViewBoxHeight = 70;
					busyIndicator.Foreground = UIColor.FromRGB(36, 63, 217);
					busyIndicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeBall;
				}
				else if (selectedType == "Battery")
				{
					busyIndicator.Duration = 1;
					busyIndicator.ViewBoxWidth = 70;
					busyIndicator.ViewBoxHeight = 70;
					busyIndicator.Foreground = UIColor.FromRGB(167, 0, 21);
					busyIndicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeBattery;
				}
				else if (selectedType == "DoubleCircle")
				{
					busyIndicator.Duration = 0.6f;
					busyIndicator.ViewBoxWidth = 70;
					busyIndicator.ViewBoxHeight = 70;
					busyIndicator.Foreground = UIColor.FromRGB(149, 140, 123);
					busyIndicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeDoubleCircle;
				}
				else if (selectedType == "ECG")
				{
					busyIndicator.Duration = 1;
					busyIndicator.ViewBoxWidth = 70;
					busyIndicator.ViewBoxHeight = 70;
					busyIndicator.Foreground = UIColor.FromRGB(218, 144, 26);
					busyIndicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeECG;
				}
				else if (selectedType == "Globe")
				{
					busyIndicator.Duration = 0.5f;
					busyIndicator.ViewBoxWidth = 100;
					busyIndicator.ViewBoxHeight = 100;
					busyIndicator.Foreground = UIColor.FromRGB(158, 168, 238);
					busyIndicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeGlobe;
				}
				else if (selectedType == "HorizontalPulsingBox")
				{
					busyIndicator.Duration = 0.2f;
					busyIndicator.ViewBoxWidth = 100;
					busyIndicator.ViewBoxHeight = 100;
					busyIndicator.Foreground = UIColor.FromRGB(228, 46, 6);
					busyIndicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeHorizontalPulsingBox;
				}
				else if (selectedType == "MovieTimer")
				{
					busyIndicator.Duration = 1;
					busyIndicator.ViewBoxWidth = 100;
					busyIndicator.ViewBoxHeight = 100;
					busyIndicator.Foreground = UIColor.FromRGB(45, 45, 45);
					busyIndicator.SecondaryColor = UIColor.FromRGB(155, 155, 155);
					busyIndicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeMovieTimer;
				}
				else if (selectedType == "Print")
				{
					busyIndicator.Duration = 0.5f;
					busyIndicator.ViewBoxWidth = 70;
					busyIndicator.ViewBoxHeight = 70;
					busyIndicator.Foreground = UIColor.FromRGB(94, 111, 248);
					busyIndicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypePrint;
				}
				else if (selectedType == "Rectangle")
				{
					busyIndicator.Duration = 0.1f;
					busyIndicator.ViewBoxWidth = 100;
					busyIndicator.ViewBoxHeight = 100;
					busyIndicator.Foreground = UIColor.FromRGB(39, 170, 158);
					busyIndicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeRectangle;
				}
				else if (selectedType == "RollingBall")
				{
					busyIndicator.Duration = 1;
					busyIndicator.ViewBoxWidth = 70;
					busyIndicator.ViewBoxHeight = 70;
					busyIndicator.Foreground = UIColor.FromRGB(45, 45, 45);
					busyIndicator.SecondaryColor = UIColor.White;
					busyIndicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeRollingBall;
				}
				else if (selectedType == "SingleCircle")
				{
					busyIndicator.Duration = 1;
					busyIndicator.ViewBoxWidth = 70;
					busyIndicator.ViewBoxHeight = 70;
					busyIndicator.Foreground = UIColor.FromRGB(175, 37, 65);
					busyIndicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeSingleCircle;
				}
				else if (selectedType == "SlicedCircle")
				{
					busyIndicator.Duration = 1;
					busyIndicator.ViewBoxWidth = 70;
					busyIndicator.ViewBoxHeight = 70;
					busyIndicator.Foreground = UIColor.FromRGB(119, 151, 114);
					busyIndicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeSlicedCircle;
				}
				else if (selectedType == "ZoomingTarget")
				{
					busyIndicator.Duration = 1;
					busyIndicator.ViewBoxWidth = 70;
					busyIndicator.ViewBoxHeight = 70;
					busyIndicator.Foreground = UIColor.FromRGB(237, 143, 60);
					busyIndicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeZoomingTarget;
				}
				else if (selectedType == "Gear")
				{
					busyIndicator.Duration = 1.5f;
					busyIndicator.ViewBoxWidth = 70;
					busyIndicator.ViewBoxHeight = 70;
					busyIndicator.Foreground = UIColor.Gray;
					busyIndicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeGear;
				}

			};

			//AnimationPicker
			animationPicker.ShowSelectionIndicator = true;
			animationPicker.Hidden = true;
			animationPicker.Model = model;
			animationPicker.BackgroundColor = UIColor.White;
			this.AddSubview(animationPicker);


			//DoneButton
			doneButton.SetTitle("Done\t", UIControlState.Normal);
			doneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			doneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
			doneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			doneButton.Hidden = true;
			doneButton.TouchUpInside += HidePicker;
			this.AddSubview(doneButton);
			this.BackgroundColor = UIColor.White;
		}

		void ShowPicker (object sender, EventArgs e) {

			doneButton.Hidden = false;
			animationPicker.Hidden = false;
			this.BecomeFirstResponder ();
		}

		void HidePicker (object sender, EventArgs e) {

			doneButton.Hidden = true;
			animationPicker.Hidden = true;
			this.BecomeFirstResponder ();
		}
		#endregion
	}
}