#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;

using Syncfusion.SfRangeSlider.iOS;

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
	public class Slider : SampleView
	{
		UIImageView mountImg;
		SFRangeSlider RangeSliderSample;
		UILabel opacityLabel;

		public Slider ()
		{
			//RangeSlider
			RangeSliderSample = new SFRangeSlider();
			RangeSliderSample.Delegate = new RangeSliderDelegate();
			RangeSliderSample.Maximum=100;
			RangeSliderSample.Minimum=0;
			RangeSliderSample.Value = 100;
			RangeSliderSample.RangeStart=0;
			RangeSliderSample.RangeEnd=100;
			RangeSliderSample.TickPlacement=SFTickPlacement.SFTickPlacementBottomRight;
			RangeSliderSample.ValuePlacement=SFValuePlacement.SFValuePlacementBottomRight;
			RangeSliderSample.TickFrequency=20;
			RangeSliderSample.ToolTipPlacement = SFToolTipPlacement.SFToolTipPlacementTopLeft;
			RangeSliderSample.SnapsTo = SFSnapsTo.SFSnapsToNone;
			RangeSliderSample.ShowRange=false;
			RangeSliderSample.KnobColor=UIColor.White;
			RangeSliderSample.TrackSelectionColor=UIColor.FromRGB(66,115,185);
			RangeSliderSample.TrackColor=UIColor.FromRGB(182,182,182);
			this.AddSubview (RangeSliderSample);

			mainPageDesign();
		}

		public void mainPageDesign()
		{
			//Image
			mountImg = new UIImageView();
			mountImg.Image = UIImage.FromBundle("Images/mount.png");

			//opacityLabel
			opacityLabel = new UILabel();
			opacityLabel.TextColor = UIColor.Black;
			opacityLabel.Text = "Opacity";
			opacityLabel.TextAlignment = UITextAlignment.Left;
			opacityLabel.Font = UIFont.FromName("Helvetica", 20f);
			this.AddSubview(mountImg);
			this.AddSubview(opacityLabel);

		}
		public void SetValue(nfloat value)
		{
			mountImg.Alpha = value / 100;

		}
		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Bounds;
				if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
					mountImg.Frame = new CGRect (this.Frame.X + 120, this.Frame.Y, this.Frame.Size.Width - 240, this.Frame.Size.Height / 2);
					opacityLabel.Frame = new CGRect (this.Frame.X + 120, this.Frame.Y + this.Frame.Size.Height / 2 + 10, this.Frame.Size.Width - 60, 30);
					RangeSliderSample.Frame = new CGRect (this.Frame.X + 120, this.Frame.Y + this.Frame.Size.Height / 2 + 20, this.Frame.Size.Width - 220, 100);
				}
				else 
				{
					mountImg.Frame = new CGRect (this.Frame.X + 20, this.Frame.Y, this.Frame.Size.Width - 40, this.Frame.Size.Height / 2);
					opacityLabel.Frame = new CGRect (this.Frame.X + 20, this.Frame.Y + this.Frame.Size.Height / 2 + 10, this.Frame.Size.Width - 40, 30);
					RangeSliderSample.Frame = new CGRect (this.Frame.X + 10, this.Frame.Y + this.Frame.Size.Height / 2 + 20, this.Frame.Size.Width - 20, 100);
				}
			}
			base.LayoutSubviews ();
		}
	}

	public class RangeSliderDelegate:SFRangeSliderDelegate
	{
		public override void ValueChange (SFRangeSlider SFRangeSlider, nfloat value)
		{
			(SFRangeSlider.Superview as Slider).SetValue (value);
		}
	}

	public class RangeSliderValueChangedEventArgs : EventArgs
	{
		public nfloat imageval {get; set;}
	}
}

