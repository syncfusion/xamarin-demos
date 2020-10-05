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
	public class Orientation : SampleView
	{
		SfRangeSlider rangeSlider1, rangeSlider2, rangeSlider3;
		UILabel hertzLabel1,hertzLabel2,hertzLabel3,decibelLabel1,decibelLabel2,decibelLabel3;

		public Orientation ()
		{
			//RangeSlider 1
			rangeSlider1 = new SfRangeSlider();
			rangeSlider1.Maximum=12;
			rangeSlider1.Minimum =-12;
			rangeSlider1.RangeStart =-12;
			rangeSlider1.RangeEnd =(nfloat)2.2;
            rangeSlider1.Value = (nfloat)2.2;
			rangeSlider1.TickPlacement = SFTickPlacement.SFTickPlacementNone;
			rangeSlider1.TickFrequency =12;
			rangeSlider1.Orientation = SFOrientation.SFOrientationVertical;
			rangeSlider1.ValuePlacement = SFValuePlacement.SFValuePlacementTopLeft;
			rangeSlider1.SnapsTo = SFSnapsTo.SFSnapsToNone;
			rangeSlider1.KnobColor = UIColor.White;
			rangeSlider1.TrackSelectionColor = UIColor.FromRGB (182, 182, 182);
			rangeSlider1.TrackColor = UIColor.FromRGB (182, 182, 182);
			rangeSlider1.ShowRange = false;

			//RangeSlider 2
			rangeSlider2 = new SfRangeSlider();
			rangeSlider2.Maximum=12;
			rangeSlider2.Minimum =-12;
			rangeSlider2.RangeStart =-12;
			rangeSlider2.RangeEnd =(nfloat)(-4.7);
            rangeSlider2.Value = (nfloat)(-4.7);
			rangeSlider2.TickPlacement = SFTickPlacement.SFTickPlacementNone;
			rangeSlider2.TickFrequency = 12;
			rangeSlider2.Orientation = SFOrientation.SFOrientationVertical;
			rangeSlider2.ValuePlacement = SFValuePlacement.SFValuePlacementTopLeft;
			rangeSlider2.SnapsTo = SFSnapsTo.SFSnapsToNone;
			rangeSlider2.KnobColor = UIColor.White;
			rangeSlider2.ShowRange = false;
			rangeSlider2.TrackSelectionColor = UIColor.FromRGB (182, 182, 182);
			rangeSlider2.TrackColor = UIColor.FromRGB (182, 182, 182);

			//RangeSlider 3
			rangeSlider3 = new SfRangeSlider();
			rangeSlider3.Maximum=12;
			rangeSlider3.Minimum =-12;
			rangeSlider3.RangeStart =-12;
			rangeSlider3.RangeEnd =(nfloat)6;
            rangeSlider3.Value = (nfloat)6;
			rangeSlider3.TickPlacement = SFTickPlacement.SFTickPlacementNone;
			rangeSlider3.TickFrequency = 12;
			rangeSlider3.Orientation = SFOrientation.SFOrientationVertical;
			rangeSlider3.ValuePlacement = SFValuePlacement.SFValuePlacementTopLeft;
			rangeSlider3.SnapsTo = SFSnapsTo.SFSnapsToNone;
			rangeSlider3.KnobColor = UIColor.White;
			rangeSlider3.ShowRange = false;
			rangeSlider3.TrackSelectionColor = UIColor.FromRGB (182, 182, 182);
			rangeSlider3.TrackColor = UIColor.FromRGB (182, 182, 182);
			rangeSlider1.ValueChange += Slider_ValueChange;
            rangeSlider2.ValueChange += Slider_ValueChange;
            rangeSlider3.ValueChange += Slider_ValueChange;
			this.AddSubview (rangeSlider3);
			this.AddSubview (rangeSlider1);
			this.AddSubview (rangeSlider2);
			mainPageDesign();

		}
		void Slider_ValueChange(object sender, ValueEventArgs e)
		{
			SetValue(sender as SfRangeSlider, e.Value);
		}
		public void SetValue(SfRangeSlider r, nfloat value)
		{
			nfloat f = (nfloat)Math.Round(value, 1);
			if (r == rangeSlider1)
				decibelLabel1.Text = f.ToString() + "db";
			else if (r == rangeSlider2)
				decibelLabel2.Text = f.ToString() + "db";
			else
				decibelLabel3.Text = f.ToString() + "db";
		}
		public void mainPageDesign()
		{ 
			//HertzLabel1
			hertzLabel1 = new UILabel();
			hertzLabel1.TextColor = UIColor.FromRGB(109, 109, 114);
			hertzLabel1.Text = "60Hz";
			hertzLabel1.TextAlignment = UITextAlignment.Center;
			hertzLabel1.Font = UIFont.FromName("Helvetica", 20f);

 			//HertzLabel21
			hertzLabel2 = new UILabel();
			hertzLabel2.TextColor = UIColor.FromRGB(109, 109, 114);
			hertzLabel2.Text = "170Hz";
			hertzLabel2.TextAlignment = UITextAlignment.Center;
			hertzLabel2.Font = UIFont.FromName("Helvetica", 20f);

			//HertzLabel3
			hertzLabel3 = new UILabel();
			hertzLabel3.TextColor = UIColor.FromRGB(109, 109, 114);
			hertzLabel3.Text = "310Hz";
			hertzLabel3.TextAlignment = UITextAlignment.Center;
			hertzLabel3.Font = UIFont.FromName("Helvetica", 20f);

			//Decibellabel1
			decibelLabel1 = new UILabel();
			decibelLabel1.TextColor = UIColor.FromRGB(57, 181, 247);
			decibelLabel1.Text = "2.2db";
			decibelLabel1.TextAlignment = UITextAlignment.Center;
			decibelLabel1.Font = UIFont.FromName("Helvetica", 14f);

			//Decibellabel2
			decibelLabel2 = new UILabel();
			decibelLabel2.TextColor = UIColor.FromRGB(57, 181, 247);
			decibelLabel2.Text = "-4.7db";
			decibelLabel2.TextAlignment = UITextAlignment.Center;
			decibelLabel2.Font = UIFont.FromName("Helvetica", 14f);

			//DecibelLabel3 
			decibelLabel3=new UILabel();;
			decibelLabel3.TextColor = UIColor.FromRGB(57, 181, 247);
			decibelLabel3.Text = "6.0db";
			decibelLabel3.TextAlignment = UITextAlignment.Center;
			decibelLabel3.Font = UIFont.FromName("Helvetica", 14f);

			//Adding to view
			this.AddSubview(hertzLabel1);
			this.AddSubview(hertzLabel2);
			this.AddSubview(hertzLabel3);
			this.AddSubview(decibelLabel1);
			this.AddSubview(decibelLabel2);
			this.AddSubview(decibelLabel3);
			
		}

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews)
			{
				if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
				{
					view.Frame = Frame;
					hertzLabel1.Frame = new CGRect(0, this.Frame.Size.Height / 7, this.Frame.Size.Width / 3, 30);
					hertzLabel2.Frame = new CGRect(this.Frame.Size.Width / 3, this.Frame.Size.Height / 7, this.Frame.Size.Width / 3, 30);
					hertzLabel3.Frame = new CGRect((this.Frame.Size.Width / 3) * 2, this.Frame.Size.Height / 7, this.Frame.Size.Width / 3, 30);
					decibelLabel1.Frame = new CGRect(0, this.Frame.Size.Height / 5, this.Frame.Size.Width / 3, 30);
					decibelLabel2.Frame = new CGRect(this.Frame.Size.Width / 3, this.Frame.Size.Height / 5, this.Frame.Size.Width / 3, 30);
					decibelLabel3.Frame = new CGRect((this.Frame.Size.Width / 3) * 2, this.Frame.Size.Height / 5, this.Frame.Size.Width / 3, 30);
					rangeSlider1.Frame = new CGRect(0, this.Frame.Size.Height / 4, this.Frame.Size.Width / 4, this.Frame.Size.Height - this.Frame.Size.Height / 4 - 50);
					rangeSlider2.Frame = new CGRect(this.Frame.Size.Width / 3, this.Frame.Size.Height / 4, this.Frame.Size.Width / 3, this.Frame.Size.Height - this.Frame.Size.Height / 4 - 50);
					rangeSlider3.Frame = new CGRect((this.Frame.Size.Width / 3) * 2, this.Frame.Size.Height / 4, this.Frame.Size.Width / 3, this.Frame.Size.Height - this.Frame.Size.Height / 4 - 50);
				}
				else
				{
					view.Frame = Bounds;
					hertzLabel1.Frame = new CGRect(40, this.Frame.Size.Height / 7 - 40, this.Frame.Size.Width / 3, 30);
					hertzLabel2.Frame = new CGRect(this.Frame.Size.Width / 3, this.Frame.Size.Height / 7 - 40, this.Frame.Size.Width / 3, 30);
					hertzLabel3.Frame = new CGRect((this.Frame.Size.Width / 3) * 2 - 20, this.Frame.Size.Height / 7 - 40, this.Frame.Size.Width / 3, 30);
					decibelLabel1.Frame = new CGRect(40, this.Frame.Size.Height / 5 - 40, this.Frame.Size.Width / 3, 30);
					decibelLabel2.Frame = new CGRect(this.Frame.Size.Width / 3, this.Frame.Size.Height / 5 - 40, this.Frame.Size.Width / 3, 30);
					decibelLabel3.Frame = new CGRect((this.Frame.Size.Width / 3) * 2 - 20, this.Frame.Size.Height / 5 - 40, this.Frame.Size.Width / 3, 30);
					rangeSlider1.Frame = new CGRect(70, this.Frame.Size.Height / 4 - 40, this.Frame.Size.Width / 4, this.Frame.Size.Height - this.Frame.Size.Height / 4 - 50);
					rangeSlider2.Frame = new CGRect(this.Frame.Size.Width / 3, this.Frame.Size.Height / 4 - 40, this.Frame.Size.Width / 3, this.Frame.Size.Height - this.Frame.Size.Height / 4 - 50);
					rangeSlider3.Frame = new CGRect((this.Frame.Size.Width / 3) * 2 - 20, this.Frame.Size.Height / 4 - 40, this.Frame.Size.Width / 3, this.Frame.Size.Height - this.Frame.Size.Height / 4 - 50);
				}
			}
			base.LayoutSubviews ();
		}
	}
}

