#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;

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
using Syncfusion.SfGauge.iOS;
namespace SampleBrowser
{
    public class Default : SampleView
    {
        SFLinearGauge linearGauge;

        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        #region View lifecycle
        public override void LayoutSubviews()
        {
                foreach (var view in this.Subviews)
                {
                    view.Frame = Bounds;
                    linearGauge.Frame = new CGRect(0, 30, this.Frame.Size.Width, this.Frame.Size.Height - 30);
                }

            base.LayoutSubviews();
        }
        public Default()
        {

            //LinearGauge
            this.BackgroundColor = UIColor.White;

            linearGauge = new SFLinearGauge();
            linearGauge.BackgroundColor = UIColor.White;
            linearGauge.Header = new SFLinearLabel();


            SFLinearScale scale = new SFLinearScale();
            scale.Minimum = 0;
            scale.Maximum = 100;
            scale.Interval = 10;
            scale.ScaleBarSize = 2;
            scale.OpposedPosition = true;
            scale.LabelColor = UIColor.FromRGB(66, 66, 66);
            scale.LabelFont = UIFont.FromName("Helvetica", 14f);
            scale.MinorTicksPerInterval = 4;
            scale.ScaleBarColor = UIColor.FromRGB(158, 158, 158);

            SFLinearTickSettings major = new SFLinearTickSettings();
            major.Thickness = 1.5f;
            major.Length = 30;
            major.Color = UIColor.FromRGB(158, 158, 158);
            scale.MajorTickSettings = major;

            SFLinearTickSettings minor = new SFLinearTickSettings();
            minor.Thickness = 0.9f;
            minor.Color = UIColor.FromRGB(158, 158, 158);
            minor.Length = 15;
            scale.MinorTickSettings = minor;

            SFSymbolPointer pointer = new SFSymbolPointer();
            pointer.SymbolPosition = SymbolPointerPosition.Away;
            pointer.Thickness = 12;
            pointer.Value = 10;
            pointer.Color = UIColor.FromRGB(158, 158, 158);
            pointer.MarkerShape = MarkerShape.Triangle;
            scale.Pointers.Add(pointer);

            linearGauge.Scales.Add(scale);

            this.AddSubview(linearGauge);

        }
        #endregion
    }
}
