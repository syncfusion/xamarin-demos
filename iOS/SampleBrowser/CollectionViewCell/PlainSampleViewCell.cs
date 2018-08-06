#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace SampleBrowser
{
	public class PlainSampleViewCell : UICollectionViewCell
	{
		public PlainSampleViewCell()
		{
			
		}

		protected PlainSampleViewCell(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		UILabel label;
		UIImageView imageView;

		[Export("initWithFrame:")]
		public PlainSampleViewCell(CGRect frame) : base(frame)
		{
			BackgroundView = new UIView { BackgroundColor = UIColor.Orange };

			SelectedBackgroundView = new UIView { BackgroundColor = UIColor.Green };

			//ContentView.Layer.BorderColor = UIColor.LightGray.CGColor;
			//ContentView.Layer.BorderWidth = 2.0f;
			//ContentView.BackgroundColor = UIColor.White;
			//ContentView.Transform = CGAffineTransform.MakeScale(0.8f, 0.8f);

			label = new UILabel();
			label.Center = ContentView.Center;
			label.TextColor = UIColor.Red;
			label.Frame = this.Frame;

			imageView = new UIImageView(UIImage.FromBundle("menu.png"));

			imageView.Transform = CGAffineTransform.MakeScale(0.7f, 0.7f);
			imageView.Frame = this.Frame;

			ContentView.AddSubview(label);
		}

		public UIImage Image
		{
			set
			{
				imageView.Image = value;
			}
		}

		public NSString text
		{
			set
			{
				label.Text = value;
			}
		}

	}
}

