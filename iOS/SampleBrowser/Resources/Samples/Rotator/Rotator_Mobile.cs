#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using UIKit;
using Foundation;
using Syncfusion.SfRotator.iOS;
using System.Collections.Generic;
using CoreGraphics;

namespace SampleBrowser
{
	public class Rotator_Mobile : SampleView
	{
		SFRotator rotator;
		NSMutableArray array;
		UIView main_view;
		UIScrollView sub_View;
		UISwitch autoPlaySwitch;
		UIPickerView navigationModePicker,navigationDirectionPicker,tabStripPicker;
		UILabel navigationModeLabel,navigationDirectionLabel,tabStripLabel,autoPlayLabel;
		UIButton navigationModeButton,navigationDirectionButton,tabStripButton;
		UIButton doneButton;
		private string selectedType;
		private readonly IList<string> navigationModeList = new List<string>{
			"Dots",
			"Thumbnail"
		};
		private readonly IList<string> navigationDirectionList = new List<string>{
			"Horizontal",
			"Vertical"
		};
		private readonly IList<string> tabStripPositionList = new List<string>{
			"Left",
			"Top",
			"Right",
			"Bottom"
		};

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Bounds;
				main_view.Frame = new CGRect(0,0,Frame.Width,Frame.Height);
				rotator.Frame = new CGRect (0,main_view.Frame.Y,main_view.Frame.Size.Width, Frame.Height / 2+30);
				sub_View.Frame = new CGRect (0,main_view.Frame.Height/2+35,main_view.Frame.Size.Width, Frame.Height / 2-35);
				navigationModeLabel.Frame = new CGRect (10, 4, main_view.Frame.Size.Width,25 );
				navigationDirectionLabel.Frame = new CGRect (10,67, main_view.Frame.Size.Width, 25);
				tabStripLabel.Frame = new CGRect (10, 130, main_view.Frame.Size.Width, 25);
				navigationModePicker.Frame = new CGRect (0, this.Frame.Size.Height-(this.Frame.Size.Height/3), this.Frame.Size.Width, this.Frame.Size.Height/3);
				navigationDirectionPicker.Frame = new CGRect (0, this.Frame.Size.Height-(this.Frame.Size.Height/3), this.Frame.Size.Width , this.Frame.Size.Height/3);
				tabStripPicker.Frame = new CGRect (0, this.Frame.Size.Height-(this.Frame.Size.Height/3), this.Frame.Size.Width , this.Frame.Size.Height/3);
				doneButton.Frame = new CGRect (0, this.Frame.Size.Height-(this.Frame.Size.Height/3)-30, this.Frame.Size.Width, 30);
				navigationModeButton.Frame = new CGRect (10, 35, main_view.Frame.Size.Width-20,30 );
				navigationDirectionButton.Frame = new CGRect (10,95, main_view.Frame.Size.Width-20,30 );
				tabStripButton.Frame = new CGRect (10, 158, main_view.Frame.Size.Width-20,30 );
				autoPlayLabel.Frame=new CGRect(10, 205, this.Frame.Size.Width-20, 20);
				autoPlaySwitch.Frame=new CGRect(250,200,  this.Frame.Size.Width-20, 20);
				sub_View.ContentSize = new CGSize (main_view.Frame.Width,main_view.Frame.Height/2+20);
			}
			base.LayoutSubviews ();
		}

		public Rotator_Mobile ()
		{
			array = new NSMutableArray ();
			getRotatorItem ();

			//Control Initialization
			rotator = new SFRotator ();
			rotator.DataSource = array;
			rotator.EnableLooping=true;
			rotator.NavigationStripMode=SFRotatorNavigationStripMode.Dots;
			rotator.SelectedIndex=0;
			rotator.NavigationDelay = 2;
			getPropertiesInitialization ();
			this.AddSubview (main_view);
			this.BackgroundColor = UIColor.White;

			main_view.BringSubviewToFront (navigationModePicker);
			main_view.BringSubviewToFront (navigationDirectionPicker);
			main_view.BringSubviewToFront (tabStripPicker);
			main_view.BringSubviewToFront (doneButton);
		}

		void getRotatorItem()
		{
			SFRotatorItem item1 = new SFRotatorItem ();
			UIView view1 = new UIView();
			UIImageView image1 =new UIImageView();
			image1.Frame = view1.Frame;
			image1.Image = UIImage.FromFile ("movie1.png");
			item1.View = view1;
			view1.AddSubview(image1);

			SFRotatorItem item2 = new SFRotatorItem ();
			UIView view2 = new UIView();
			UIImageView image2 =new UIImageView();
			image2.Frame = view2.Frame;
			image2.Image = UIImage.FromFile ("movie2.png");
			item2.View = view2;
			view2.AddSubview(image2);

			SFRotatorItem item3 = new SFRotatorItem ();
			UIView view3 = new UIView();
			UIImageView image3 =new UIImageView();
			image3.Frame = view3.Frame;
			image3.Image = UIImage.FromFile ("movie3.png");
			item3.View = view3;
			view3.AddSubview(image3);

			SFRotatorItem item4 = new SFRotatorItem ();
			UIView view4 = new UIView();
			UIImageView image4 =new UIImageView();
			image4.Frame = view4.Frame;
			image4.Image = UIImage.FromFile ("movie4.png");
			item4.View = view4;
			view4.AddSubview(image4);

			SFRotatorItem item5 = new SFRotatorItem ();
			UIView view5 = new UIView();
			UIImageView image5 =new UIImageView();
			image5.Frame = view5.Frame;
			image5.Image = UIImage.FromFile ("movie5.png");
			item5.View = view5;
			view5.AddSubview(image5);

			SFRotatorItem item6 = new SFRotatorItem ();
			UIView view6 = new UIView();
			UIImageView image6 =new UIImageView();
			image6.Frame = view6.Frame;
			image6.Image = UIImage.FromFile ("movie6.png");
			item6.View = view6;
			view6.AddSubview(image6);

			SFRotatorItem item7 = new SFRotatorItem ();
			UIView view7 = new UIView();
			UIImageView image7 =new UIImageView();
			image7.Frame = view7.Frame;
			image7.Image = UIImage.FromFile ("movie7.png");
			item7.View = view7;
			view7.AddSubview(image7);

			image1.AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth;
			image2.AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth;
			image3.AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth;
			image4.AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth;
			image5.AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth;
			image6.AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth;
			image7.AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth;

			array.Add (item1);
			array.Add (item2);
			array.Add (item3);
			array.Add (item4);
			array.Add (item5);

		}

		void getPropertiesInitialization()
		{
			navigationModePicker = new UIPickerView ();
			navigationDirectionPicker = new UIPickerView ();
			tabStripPicker = new UIPickerView ();
			PickerModel navigationModeModel = new PickerModel (navigationModeList);
			navigationModePicker.Model = navigationModeModel;
			PickerModel navigationDirectionModel = new PickerModel (navigationDirectionList);
			navigationDirectionPicker.Model = navigationDirectionModel;
			PickerModel tabStripModel = new PickerModel (tabStripPositionList);
			tabStripPicker.Model = tabStripModel;

			//navigationModeLabel
			navigationModeLabel = new UILabel();
			navigationModeLabel.Text = "NavigationStrip Mode";
			navigationModeLabel.TextColor = UIColor.Black;
			navigationModeLabel.TextAlignment = UITextAlignment.Left;
			navigationDirectionLabel = new UILabel();
			navigationDirectionLabel.Text = "Navigation Direction";
			navigationDirectionLabel.TextColor = UIColor.Black;
			navigationDirectionLabel.TextAlignment = UITextAlignment.Left;
			tabStripLabel = new UILabel();
			tabStripLabel.Text = "NavigationStrip Position";
			tabStripLabel.TextColor = UIColor.Black;
			tabStripLabel.TextAlignment = UITextAlignment.Left;

			//navigationModeButton
			navigationModeButton = new UIButton();
			navigationModeButton.SetTitle("Dots",UIControlState.Normal);
			navigationModeButton.SetTitleColor(UIColor.Black,UIControlState.Normal);
			navigationModeButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			navigationModeButton.Layer.CornerRadius = 8;
			navigationModeButton.Layer.BorderWidth = 2;
			navigationModeButton.Layer.BorderColor =UIColor.FromRGB(246,246,246).CGColor;

			//navigationDirectionButton
			navigationDirectionButton = new UIButton();
			navigationDirectionButton.SetTitle("Horizontal",UIControlState.Normal);
			navigationDirectionButton.SetTitleColor(UIColor.Black,UIControlState.Normal);
			navigationDirectionButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			navigationDirectionButton.Layer.CornerRadius = 8;
			navigationDirectionButton.Layer.BorderWidth = 2;
			navigationDirectionButton.Layer.BorderColor =UIColor.FromRGB(246,246,246).CGColor;

			//tabStripButton
			tabStripButton = new UIButton();
			tabStripButton.SetTitle("Bottom",UIControlState.Normal);
			tabStripButton.SetTitleColor(UIColor.Black,UIControlState.Normal);
			tabStripButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			tabStripButton.Layer.CornerRadius = 8;
			tabStripButton.Layer.BorderWidth = 2;
			tabStripButton.TouchUpInside += ShowtabStripPicker;
			tabStripButton.Layer.BorderColor =UIColor.FromRGB(246,246,246).CGColor;

			doneButton = new UIButton ();
			doneButton.SetTitle("Done\t",UIControlState.Normal);
			doneButton.SetTitleColor(UIColor.Black,UIControlState.Normal);
			doneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			doneButton.TouchUpInside += HidePicker;
			doneButton.Hidden = true;
			doneButton.BackgroundColor = UIColor.FromRGB(246,246,246);
			navigationModeModel.PickerChanged += navigationModeSelectedIndexChanged;
			navigationDirectionModel.PickerChanged += navigationDirectionSelectedIndexChanged;
			tabStripModel.PickerChanged += tabStripSelectedIndexChanged;
			navigationModePicker.ShowSelectionIndicator = true;
			navigationModePicker.Hidden = true;
			navigationModePicker.BackgroundColor = UIColor.Gray;
			navigationDirectionPicker.BackgroundColor = UIColor.Gray;
			navigationDirectionPicker.ShowSelectionIndicator = true;
			navigationDirectionPicker.Hidden = true;
			tabStripPicker.BackgroundColor = UIColor.Gray;
			tabStripPicker.ShowSelectionIndicator = true;
			tabStripPicker.Hidden = true;

			//autoPlayLabel
			autoPlayLabel = new UILabel();
			autoPlayLabel.TextColor = UIColor.Black;
			autoPlayLabel.BackgroundColor= UIColor.Clear;
			autoPlayLabel.Text=@"Enable AutoPlay";
			autoPlayLabel.TextAlignment= UITextAlignment.Left;
			autoPlayLabel.Font=UIFont.FromName("Helvetica", 16f);
			//allowSwitch
			autoPlaySwitch = new UISwitch();
			autoPlaySwitch.ValueChanged += autoPlayToggleChanged;
			autoPlaySwitch.On=false;

			//adding to mainview
			main_view = new UIView ();
			main_view.AddSubview (rotator);
			main_view.AddSubview (doneButton);
			main_view.AddSubview (navigationDirectionPicker);
			main_view.AddSubview (navigationModePicker);
			main_view.AddSubview (tabStripPicker);

			sub_View = new UIScrollView ();
			sub_View.AddSubview (navigationModeLabel);
			sub_View.AddSubview (navigationModeButton);
			sub_View.AddSubview (navigationDirectionLabel);
			sub_View.AddSubview (navigationDirectionButton);
			sub_View.AddSubview (tabStripLabel);
			sub_View.AddSubview (tabStripButton);
			sub_View.AddSubview (autoPlayLabel);
			sub_View.AddSubview (autoPlaySwitch);
			main_view.AddSubview (sub_View);
		}

	
		void ShowtabStripPicker (object sender, EventArgs e) {
			sub_View.UserInteractionEnabled = false;
			doneButton.Hidden = false;
			navigationModePicker.Hidden = true;
			navigationDirectionPicker.Hidden = true;
			tabStripPicker.Hidden = false;
			navigationModeButton.Hidden = true;
			navigationModeLabel.Hidden = true;
			tabStripLabel.Hidden = true;
			tabStripButton.Hidden = true;
			navigationDirectionButton.Hidden = true;
			navigationDirectionLabel.Hidden = true;
			autoPlayLabel.Hidden = true;
			autoPlaySwitch.Hidden = true;
		}

		void HidePicker (object sender, EventArgs e) {
			sub_View.UserInteractionEnabled = true;
			doneButton.Hidden = true;
			navigationDirectionPicker.Hidden = true;
			navigationModePicker.Hidden = true;
			tabStripPicker.Hidden = true;
			navigationModeButton.Hidden = false;
			navigationModeLabel.Hidden = false;
			tabStripLabel.Hidden = false;
			tabStripButton.Hidden = false;
			navigationDirectionButton.Hidden = false;
			navigationDirectionLabel.Hidden = false;
			autoPlayLabel.Hidden = false;
			autoPlaySwitch.Hidden = false;
		}

		private void navigationModeSelectedIndexChanged(object sender, PickerChangedEventArgs e)
		{
			this.selectedType = e.SelectedValue;
			navigationModeButton.SetTitle (selectedType, UIControlState.Normal);
			if (selectedType == "Dots")
				rotator.NavigationStripMode = SFRotatorNavigationStripMode.Dots;
			else
				rotator.NavigationStripMode = SFRotatorNavigationStripMode.Thumbnail;
		}

		private void navigationDirectionSelectedIndexChanged(object sender, PickerChangedEventArgs e)
		{
			this.selectedType = e.SelectedValue;
			navigationDirectionButton.SetTitle (selectedType, UIControlState.Normal);
			if (selectedType == "Horizontal")
				rotator.NavigationDirection = SFRotatorNavigationDirection.Horizontal;
			else
				rotator.NavigationDirection = SFRotatorNavigationDirection.Vertical;
		}

		private void tabStripSelectedIndexChanged(object sender, PickerChangedEventArgs e)
		{
			this.selectedType = e.SelectedValue;
			tabStripButton.SetTitle (selectedType, UIControlState.Normal);
			if (selectedType == "Left")
				rotator.NavigationStripPosition = SFRotatorNavigationStripPosition.Left;
			else if (selectedType == "Top")
				rotator.NavigationStripPosition =SFRotatorNavigationStripPosition.Top;
			else if (selectedType == "Right")
				rotator.NavigationStripPosition =SFRotatorNavigationStripPosition.Right;
			else
				rotator.NavigationStripPosition =SFRotatorNavigationStripPosition.Bottom;
		}

		private void autoPlayToggleChanged(object sender, EventArgs e)
		{
			if (((UISwitch)sender).On) {
				rotator.EnableAutoPlay = true;
			} else {
				rotator.EnableAutoPlay = false;
			}
		}

	}
}

