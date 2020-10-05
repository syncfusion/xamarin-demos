#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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
	public class Rotator_Tablet : SampleView
	{
		SFRotator rotator;
		NSMutableArray array;
		UIView sub_View;
		UIView contentView = new UIView ();
		UIView controlView = new UIView ();
		UISwitch autoPlaySwitch;
		UIPickerView navigationModePicker,navigationDirectionPicker,tabStripPicker;
		UILabel navigationModeLabel,navigationDirectionLabel,tabStripLabel,autoPlayLabel,propertiesLabel;
		UIButton navigationModeButton,navigationDirectionButton,tabStripButton;
		UIButton doneButton,showPropertyButton,closeButton;
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
				view.Frame = Frame;
				sub_View.Frame = new CGRect (0,  view.Frame.Size.Height-view.Frame.Size.Height/3 , view.Frame.Size.Width, view.Frame.Size.Height/3);
				controlView.Frame=new CGRect(100,40,this.Frame.Size.Width-200,this.Frame.Size.Height);
				contentView.Frame=new CGRect(0,40,sub_View.Frame.Size.Width,sub_View.Frame.Size.Height-20);
				rotator.Frame = new CGRect (0,0,controlView.Frame.Size.Width, 400);
				navigationModeLabel.Frame = new CGRect (110, 40, contentView.Frame.Size.Width-200,30 );
				navigationDirectionLabel.Frame = new CGRect (110,90, contentView.Frame.Size.Width-200, 30);
				tabStripLabel.Frame = new CGRect (110, 130,contentView.Frame.Size.Width-200, 30);
				navigationModePicker.Frame = new CGRect (100, 50, contentView.Frame.Size.Width-200, 150);
				navigationDirectionPicker.Frame = new CGRect (100, 50, contentView.Frame.Size.Width-200 , 150);
				tabStripPicker.Frame = new CGRect (100, 50, contentView.Frame.Size.Width-200, 150);
				doneButton.Frame = new CGRect (100, 20, contentView.Frame.Size.Width-200, 30);
				navigationModeButton.Frame = new CGRect (350, 40,contentView.Frame.Size.Width-520,30 );
				navigationDirectionButton.Frame = new CGRect (350,90,contentView.Frame.Size.Width-520,30 );
				tabStripButton.Frame = new CGRect (350,130,contentView.Frame.Size.Width-520,30 );
				autoPlayLabel.Frame=new CGRect(110, 175, contentView.Frame.Size.Width-220, 20);
				autoPlaySwitch.Frame=new CGRect(350,175,  contentView.Frame.Size.Width-220, 20);
				showPropertyButton.Frame = new CGRect (0, this.Frame.Size.Height - 25, this.Frame.Size.Width, 30);
				closeButton.Frame = new CGRect (this.Frame.Size.Width - 30, 5, 20, 30);
				propertiesLabel.Frame = new CGRect (10, 5, this.Frame.Width, 30);

			}
			base.LayoutSubviews ();
		}

		public Rotator_Tablet ()
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
			//array.Add (item6);
			//array.Add (item7);

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
			navigationModeLabel.Font=UIFont.FromName("Helvetica", 14f);
			navigationModeLabel.TextColor = UIColor.Black;
			navigationModeLabel.TextAlignment = UITextAlignment.Left;
			navigationDirectionLabel = new UILabel();
			navigationDirectionLabel.Text = "Navigation Direction";
			navigationDirectionLabel.Font=UIFont.FromName("Helvetica", 14f);
			navigationDirectionLabel.TextColor = UIColor.Black;
			navigationDirectionLabel.TextAlignment = UITextAlignment.Left;
			tabStripLabel = new UILabel();
			tabStripLabel.Text = "NavigationStrip Position";
			tabStripLabel.Font=UIFont.FromName("Helvetica", 14f);
			tabStripLabel.TextColor = UIColor.Black;
			tabStripLabel.TextAlignment = UITextAlignment.Left;

			//navigationModeButton
			navigationModeButton = new UIButton();
			navigationModeButton.SetTitle("Dots",UIControlState.Normal);
			navigationModeButton.Font=UIFont.FromName("Helvetica", 14f);
			navigationModeButton.SetTitleColor(UIColor.Black,UIControlState.Normal);
			navigationModeButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			navigationModeButton.Layer.CornerRadius = 8;
			navigationModeButton.Layer.BorderWidth = 2;

			navigationModeButton.Layer.BorderColor =UIColor.FromRGB(246,246,246).CGColor;

			//navigationDirectionButton
			navigationDirectionButton = new UIButton();
			navigationDirectionButton.SetTitle("Horizontal",UIControlState.Normal);
			navigationDirectionButton.Font=UIFont.FromName("Helvetica", 14f);
			navigationDirectionButton.SetTitleColor(UIColor.Black,UIControlState.Normal);
			navigationDirectionButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			navigationDirectionButton.Layer.CornerRadius = 8;
			navigationDirectionButton.Layer.BorderWidth = 2;

			navigationDirectionButton.Layer.BorderColor =UIColor.FromRGB(246,246,246).CGColor;

			//tabStripButton
			tabStripButton = new UIButton();
			tabStripButton.SetTitle("Bottom",UIControlState.Normal);
			tabStripButton.Font=UIFont.FromName("Helvetica", 14f);
			tabStripButton.SetTitleColor(UIColor.Black,UIControlState.Normal);
			tabStripButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			tabStripButton.Layer.CornerRadius = 8;
			tabStripButton.Layer.BorderWidth = 2;
			tabStripButton.TouchUpInside += ShowtabStripPicker;
			tabStripButton.Layer.BorderColor =UIColor.FromRGB(246,246,246).CGColor;

			//doneButton
			doneButton = new UIButton ();
			doneButton.SetTitle("Done\t",UIControlState.Normal);
			doneButton.Font=UIFont.FromName("Helvetica", 14f);
			doneButton.SetTitleColor(UIColor.Black,UIControlState.Normal);
			doneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			doneButton.TouchUpInside += HidePicker;
			doneButton.Hidden = true;
			doneButton.BackgroundColor = UIColor.FromRGB(240,240,240);

			//picker
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
			autoPlayLabel.Font=UIFont.FromName("Helvetica", 14f);
			//allowSwitch
			autoPlaySwitch = new UISwitch();
			autoPlaySwitch.ValueChanged += autoPlayToggleChanged;
			autoPlaySwitch.On=false;
			autoPlaySwitch.OnTintColor = UIColor.FromRGB (50, 150, 221);

			controlView.AddSubview (rotator);
			this.AddSubview (controlView);

			sub_View = new UIView ();
			propertiesLabel = new UILabel ();
			closeButton = new UIButton ();
			showPropertyButton = new UIButton ();

			//adding to content view
			contentView.AddSubview (navigationModeLabel);
			contentView.AddSubview (navigationModeButton);
			contentView.AddSubview (navigationDirectionLabel);
			contentView.AddSubview (navigationDirectionButton);
			contentView.AddSubview (tabStripLabel);
			contentView.AddSubview (tabStripButton);
			contentView.AddSubview (autoPlayLabel);
			contentView.AddSubview (autoPlaySwitch);
			contentView.AddSubview (doneButton);
			contentView.AddSubview (navigationModePicker);
			contentView.AddSubview (tabStripPicker);
			contentView.AddSubview (navigationDirectionPicker);
			contentView.BackgroundColor=UIColor.FromRGB(240,240,240);

			//adding to sub_view
			sub_View.AddSubview (contentView);
			sub_View.AddSubview(closeButton);
			sub_View.AddSubview(propertiesLabel);
			sub_View.BackgroundColor=UIColor.FromRGB(230,230,230);
			this.AddSubview(sub_View);
			propertiesLabel.Text="OPTIONS";

			//showPropertyButton
			showPropertyButton.Hidden = true;
			showPropertyButton.SetTitle("OPTIONS\t", UIControlState.Normal);
			showPropertyButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
			showPropertyButton.BackgroundColor = UIColor.FromRGB(230,230,230);
			showPropertyButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			showPropertyButton.TouchUpInside += (object sender, EventArgs e) => {
				sub_View.Hidden = false;
				showPropertyButton.Hidden = true;
			};
			this.AddSubview(showPropertyButton);

			//CloseButton
			closeButton.SetTitle("X\t", UIControlState.Normal);
			closeButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
			closeButton.BackgroundColor = UIColor.FromRGB(230,230,230);
			closeButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			closeButton.TouchUpInside += (object sender, EventArgs e) => {
				sub_View.Hidden = true;
				showPropertyButton.Hidden = false;
			};

			//AddingGesture
			UITapGestureRecognizer tapgesture = new UITapGestureRecognizer (() =>{
				sub_View.Hidden = true;
				showPropertyButton.Hidden = false;
			}
			);
			propertiesLabel.UserInteractionEnabled = true;
			propertiesLabel.AddGestureRecognizer (tapgesture);
		}

	

		void ShowtabStripPicker (object sender, EventArgs e) {
			doneButton.Hidden = false;
			navigationModePicker.Hidden = true;
			navigationDirectionPicker.Hidden = true;
			tabStripPicker.Hidden = false;
			navigationModeButton.Hidden = true;
			tabStripLabel.Hidden = true;
			tabStripButton.Hidden = true;
			navigationDirectionButton.Hidden = true;
			navigationDirectionLabel.Hidden = true;
			autoPlayLabel.Hidden = true;
			autoPlaySwitch.Hidden = true;

		}

		void HidePicker (object sender, EventArgs e) {
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

