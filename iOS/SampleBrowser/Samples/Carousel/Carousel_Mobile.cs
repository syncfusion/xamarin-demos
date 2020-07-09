#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Syncfusion.SfCarousel.iOS;

using System;
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
	public class Carousel_Mobile : SampleView
	{
		SfCarousel carousel;
		SfCarouselItem carouselItem;
		UILabel offsetLabel,scaleOffsetLabel,rotationAngleLabel;

		UITextView offsetTextfield,scaleOffsetTextfield,rotationAngleTextfield;
		UILabel viewModeLabel;
		UIButton viewButton = new UIButton ();
		UIButton viewDoneButton=new UIButton();
		UIPickerView viewModePicker;
		public UIView option=new UIView();
		private string selectedType;
		private readonly IList<string> viewModeList = new List<string>{
			"Default",
			"Linear"
		};
		public Carousel_Mobile ()
		{
			viewModePicker = new UIPickerView ();
			PickerModel viewModel = new PickerModel (viewModeList);
			viewModePicker.Model = viewModel;
			viewModeLabel = new UILabel ();
			viewButton = new UIButton ();
			this.OptionView = new UIView ();
			
			NSMutableArray<SfCarouselItem> carouselItemCollection = new NSMutableArray<SfCarouselItem> ();
			carousel = new SfCarousel ();
			if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				carousel.Frame = new CGRect ( 150,150, 300,650);
            
			else
				carousel.Frame = new CGRect ( 0,0, 300,430);
			carousel.ItemHeight = 300;
			carousel.ItemWidth = 150;
			carousel.SelectedItemOffset = 20;

			for (int i = 1; i <= 7; i++) {
				carouselItem = new SfCarouselItem ();
				carouselItem.ImageName = "image"+i+".png";
				carouselItemCollection.Add (carouselItem);
			}

			carousel.DataSource = carouselItemCollection;
			carousel.SelectedIndex = 2;
			this.AddSubview (carousel);

			offsetLabel = new UILabel ();
			scaleOffsetLabel = new UILabel ();
			rotationAngleLabel = new UILabel ();

			offsetLabel.Text = "OFFSET";
			offsetLabel.TextColor = UIColor.Black;
			offsetLabel.TextAlignment = UITextAlignment.Left;
			offsetLabel.Font=UIFont.FromName("Helvetica", 14f);

			scaleOffsetLabel.Text = "SCALE OFFSET";
			scaleOffsetLabel.TextColor = UIColor.Black;
			scaleOffsetLabel.TextAlignment = UITextAlignment.Left;
			scaleOffsetLabel.Font=UIFont.FromName("Helvetica", 14f);

			rotationAngleLabel.Text = "ROTATION ANGLE";
			rotationAngleLabel.TextColor = UIColor.Black;
			rotationAngleLabel.TextAlignment = UITextAlignment.Left;
			rotationAngleLabel.Font=UIFont.FromName("Helvetica", 14f);


			offsetTextfield = new UITextView ();
			offsetTextfield.TextAlignment = UITextAlignment.Center;
			offsetTextfield.Layer.BorderColor = UIColor.Black.CGColor;
			offsetTextfield.KeyboardType = UIKeyboardType.NumberPad;
			offsetTextfield.BackgroundColor = UIColor.FromRGB(246,246,246);
			offsetTextfield.Text = "60";
			offsetTextfield.Changed+= (object sender, EventArgs e) => 
			{
				if(offsetTextfield.Text.Length>0){
					carousel.Offset = nfloat.Parse(offsetTextfield.Text);
				}
				else{
					carousel.Offset = 60;
				}
			};

			scaleOffsetTextfield = new UITextView ();
			scaleOffsetTextfield.TextAlignment = UITextAlignment.Center;
			scaleOffsetTextfield.Layer.BorderColor = UIColor.Black.CGColor;
			scaleOffsetTextfield.BackgroundColor = UIColor.FromRGB(246,246,246);
			scaleOffsetTextfield.KeyboardType = UIKeyboardType.NumberPad;
			scaleOffsetTextfield.Text = "0.8";
			scaleOffsetTextfield.Changed+= (object sender, EventArgs e) => 
			{
				if(scaleOffsetTextfield.Text.Length>0){
					carousel.ScaleOffset = nfloat.Parse(scaleOffsetTextfield.Text);
				}
				else{
					carousel.ScaleOffset = (nfloat)0.8;
				}
			};

			rotationAngleTextfield = new UITextView ();
			rotationAngleTextfield.TextAlignment = UITextAlignment.Center;
			rotationAngleTextfield.Layer.BorderColor = UIColor.Black.CGColor;
			rotationAngleTextfield.BackgroundColor = UIColor.FromRGB(246,246,246);
			rotationAngleTextfield.KeyboardType = UIKeyboardType.NumberPad;
			rotationAngleTextfield.Text = "45";
			rotationAngleTextfield.Changed+= (object sender, EventArgs e) => 
			{
				if(rotationAngleTextfield.Text.Length>0)
				{
					carousel.RotationAngle = int.Parse(rotationAngleTextfield.Text);
				}
				else
				{
					carousel.RotationAngle = 45;
				}
			};
			//viewModeLabel
			viewModeLabel.Text = "VIEW MODE";
			viewModeLabel.TextColor = UIColor.Black;
			viewModeLabel.TextAlignment = UITextAlignment.Left;

			//viewButton
			viewButton.SetTitle("Default",UIControlState.Normal);
			viewButton.SetTitleColor(UIColor.Black,UIControlState.Normal);
			viewButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			viewButton.Layer.CornerRadius = 8;
			viewButton.Layer.BorderWidth = 2;
			viewButton.TouchUpInside += ShowviewModePicker;
			viewButton.Layer.BorderColor =UIColor.FromRGB(246,246,246).CGColor;

			//viewDoneButton
			viewDoneButton.SetTitle("Done\t",UIControlState.Normal);
			viewDoneButton.SetTitleColor(UIColor.Black,UIControlState.Normal);
			viewDoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			viewDoneButton.TouchUpInside += HidePicker;
			viewDoneButton.Hidden = true;
			viewDoneButton.BackgroundColor = UIColor.FromRGB(246,246,246);
			viewModel.PickerChanged += viewSelectedIndexChanged;
			viewModePicker.ShowSelectionIndicator = true;
			viewModePicker.Hidden = true;
			//viewModePicker.BackgroundColor = UIColor.Gray;
		}
		public void  optionView()
		{
			this.option.AddSubview (scaleOffsetLabel);
			this.option.AddSubview (rotationAngleLabel);
			this.option.AddSubview (offsetTextfield);
			this.option.AddSubview (scaleOffsetTextfield);
			this.option.AddSubview (rotationAngleTextfield);
			this.option.AddSubview (offsetLabel);
			this.option.AddSubview (viewModeLabel);
			this.option.AddSubview (viewButton);
			this.option.AddSubview (viewModePicker);
			this.option.AddSubview (viewDoneButton);
		}
		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Bounds;
				this.OptionView.Frame = view.Frame;

                if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                {
                    var height = this.Frame.Height;
                    viewModePicker.Frame = new CGRect(0, 330, 300, 40);
                    viewDoneButton.Frame = new CGRect(0, 270, 300, 40);
                   
                    carousel.ItemHeight = 180;
                    carousel.Frame = new CGRect(0, 0, this.Frame.Size.Width, this.Frame.Size.Height);
                    offsetLabel.Frame = new CGRect(10, 20, this.Frame.Size.Width - 20, 30);
                    scaleOffsetLabel.Frame = new CGRect(10, 90, this.Frame.Size.Width - 20, 30);
                    rotationAngleLabel.Frame = new CGRect(10, 160, this.Frame.Size.Width - 20, 30);
                    offsetTextfield.Frame = new CGRect(200, 20, 100, 30);
                    scaleOffsetTextfield.Frame = new CGRect(200, 90, 100, 30);
                    rotationAngleTextfield.Frame = new CGRect(200, 160, 100, 30);
                    viewModeLabel.Frame = new CGRect(10, 220, this.Frame.Size.Width - 20, 30);
                    viewButton.Frame = new CGRect(10, 260, 300, 30);
                }
                else
                {
                    option.Frame = new CGRect(0, 50, Frame.Width, Frame.Height);
                    carousel.Frame = new CGRect(0, 0, this.Frame.Size.Width, this.Frame.Size.Height);
                    offsetLabel.Frame = new CGRect(10, 20, this.Frame.Size.Width - 10, 30);
                    scaleOffsetLabel.Frame = new CGRect(10, 70, this.Frame.Size.Width - 10, 30);
                    rotationAngleLabel.Frame = new CGRect(10, 120, this.Frame.Size.Width - 10, 30);
                    offsetTextfield.Frame = new CGRect(230, 20, this.Frame.Size.Width - 250, 30);
                    scaleOffsetTextfield.Frame = new CGRect(230, 70, this.Frame.Size.Width - 250, 30);
                    rotationAngleTextfield.Frame = new CGRect(230, 120, this.Frame.Size.Width - 250, 30);
                    viewModeLabel.Frame = new CGRect(10, 170, this.Frame.Size.Width - 10, 30);
                    viewButton.Frame = new CGRect(10, 200, this.Frame.Size.Width - 20, 30);
                    viewModePicker.Frame = new CGRect(0, this.Frame.Size.Height / 3, this.Frame.Size.Width, this.Frame.Size.Height / 3);
                    viewDoneButton.Frame = new CGRect(0, this.Frame.Size.Height / 3, this.Frame.Size.Width, 30);
                }
			}
			this.optionView ();
			base.LayoutSubviews ();
		}
		void ShowviewModePicker (object sender, EventArgs e) {
			offsetTextfield.EndEditing(true);
			scaleOffsetTextfield.EndEditing(true);
			rotationAngleTextfield.EndEditing(true);
			viewDoneButton.Hidden = false;
			viewModePicker.Hidden = false;
			viewButton.Hidden = true;
		}

		void HidePicker (object sender, EventArgs e) {
			viewDoneButton.Hidden = true;
			viewModePicker.Hidden = true;
			viewButton.Hidden = false;
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