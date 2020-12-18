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
    public class Ranges : SampleView
    {
        SFLinearGauge linearGauge;
        SFLinearGauge linearGauge1;
        SFLinearGauge linearGauge2;


        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public override void LayoutSubviews()
        {
                foreach (var view in this.Subviews)
                {
                    view.Frame = Bounds;
                    CGSize sz = this.Frame.Size;
                    
                    linearGauge.Frame = new CGRect(0, 0, sz.Width, sz.Height / 3);
                    linearGauge1.Frame = new CGRect(0, sz.Height / 3, sz.Width, sz.Height / 3);
                    linearGauge2.Frame = new CGRect(0, sz.Height / 3 * 2, sz.Width, sz.Height / 3);

                }
            
            base.LayoutSubviews();
        }
        public Ranges()
        {
            this.BackgroundColor = UIColor.White;

            linearGauge = new SFLinearGauge();
            linearGauge.BackgroundColor = UIColor.White;
            linearGauge.Header = new SFLinearLabel();

            SFLinearScale scale = new SFLinearScale();
            scale.Minimum = 0;
            scale.Maximum = 100;
            scale.Interval = 25;
            scale.LabelOffset = 10;
            scale.LabelColor = UIColor.FromRGB(66, 66, 66);
            scale.LabelFont = UIFont.FromName("Helvetica", 14f);
            scale.ShowTicks = false;
            scale.ScaleBarColor = UIColor.Clear;

            SFSymbolPointer pointer = new SFSymbolPointer();
            pointer.SymbolPosition = SymbolPointerPosition.Far;
            pointer.Thickness = 12;
            pointer.Value = 35;
            pointer.Color = UIColor.Black;
            pointer.MarkerShape = MarkerShape.InvertedTriangle;
            scale.Pointers.Add(pointer);

            SFLinearRange range1 = new SFLinearRange();
            range1.StartValue = 0;
            range1.EndValue = 25;
            range1.StartWidth = 20;
            range1.EndWidth = 20;
            range1.Color = UIColor.FromRGB(26, 35, 126);
            scale.Ranges.Add(range1);

            SFLinearRange range2 = new SFLinearRange();
            range2.StartValue = 25;
            range2.EndValue = 50;
            range2.StartWidth = 20;
            range2.EndWidth = 20;
            range2.Color = UIColor.FromRGB(40, 53, 147);
            scale.Ranges.Add(range2);

            SFLinearRange range3 = new SFLinearRange();
            range3.StartValue = 50;
            range3.EndValue = 75;
            range3.StartWidth = 20;
            range3.EndWidth = 20;
            range3.Color = UIColor.FromRGB(63, 81, 181);
            scale.Ranges.Add(range3);

            SFLinearRange range4 = new SFLinearRange();
            range4.StartValue = 75;
            range4.EndValue = 100;
            range4.StartWidth = 20;
            range4.EndWidth = 20;
            range4.Color = UIColor.FromRGB(92, 107, 192);
            scale.Ranges.Add(range4);

            linearGauge.Scales.Add(scale);


            linearGauge1 = new SFLinearGauge();
            linearGauge1.BackgroundColor = UIColor.White;
            linearGauge1.Header = new SFLinearLabel();

            SFLinearScale scale1 = new SFLinearScale();
            scale1.Minimum = 0;
            scale1.Maximum = 100;
            scale1.Interval = 25;
            scale1.LabelOffset = 20;
            scale1.LabelColor = UIColor.FromRGB(66, 66, 66);
            scale1.LabelFont = UIFont.FromName("Helvetica", 14f);
            scale1.ShowTicks = false;
            scale1.ScaleBarColor = UIColor.Clear;

            SFSymbolPointer pointer1 = new SFSymbolPointer();
            pointer1.SymbolPosition = SymbolPointerPosition.Far;
            pointer1.Thickness = 12;
            pointer1.Value = 35;
            pointer1.Color = UIColor.Black;
            pointer1.MarkerShape = MarkerShape.InvertedTriangle;
            scale1.Pointers.Add(pointer1);

            SFLinearRange range5 = new SFLinearRange();
            range5.StartValue = 0;
            range5.EndValue = 25;
            range5.StartWidth = 10;
            range5.EndWidth = 15;
            range5.Color = UIColor.FromRGB(109, 229, 0);
            scale1.Ranges.Add(range5);

            SFLinearRange range6 = new SFLinearRange();
            range6.StartValue = 25;
            range6.EndValue = 50;
            range6.StartWidth = 15;
            range6.EndWidth = 20;
            range6.Color = UIColor.FromRGB(83, 173, 0);
            scale1.Ranges.Add(range6);

            SFLinearRange range7 = new SFLinearRange();
            range7.StartValue = 50;
            range7.EndValue = 75;
            range7.StartWidth = 20;
            range7.EndWidth = 25;
            range7.Color = UIColor.FromRGB(0, 145, 72);
            scale1.Ranges.Add(range7);

            SFLinearRange range8 = new SFLinearRange();
            range8.StartValue = 75;
            range8.EndValue = 100;
            range8.StartWidth = 25;
            range8.EndWidth = 30;
            range8.Color = UIColor.FromRGB(2, 102, 35);
            scale1.Ranges.Add(range8);

            linearGauge1.Scales.Add(scale1);


            linearGauge2 = new SFLinearGauge();
            linearGauge2.BackgroundColor = UIColor.White;
            linearGauge2.Header = new SFLinearLabel();

            SFLinearScale scale2 = new SFLinearScale();
            scale2.Minimum = 0;
            scale2.Maximum = 100;
            scale2.Interval = 25;
            scale2.LabelOffset = 20;
            scale2.LabelColor = UIColor.FromRGB(66, 66, 66);
            scale2.LabelFont = UIFont.FromName("Helvetica", 14f);
            scale2.ShowTicks = false;
            scale2.ScaleBarColor = UIColor.Clear;

            SFSymbolPointer pointer2 = new SFSymbolPointer();
            pointer2.SymbolPosition = SymbolPointerPosition.Far;
            pointer2.Thickness = 12;
            pointer2.Value = 35;
            pointer2.Color = UIColor.Black;
            pointer2.MarkerShape = MarkerShape.InvertedTriangle;
            scale2.Pointers.Add(pointer2);

            SFLinearRange range9 = new SFLinearRange();
            range9.StartValue = 0;
            range9.EndValue = 100;
            range9.StartWidth = 20;
            range9.EndWidth = 20;

            GaugeGradientStop color3 = new GaugeGradientStop();
            color3.Value = 0;
            color3.Color = UIColor.FromRGB(255, 249, 194);

            GaugeGradientStop color4 = new GaugeGradientStop();
            color4.Value = 100;
            color4.Color = UIColor.FromRGB(253, 145, 215);
            range9.GradientStops.Add(color3);
            range9.GradientStops.Add(color4);
            scale2.Ranges.Add(range9);


            linearGauge2.Scales.Add(scale2);


            this.AddSubview(linearGauge);
            this.AddSubview(linearGauge1);
            this.AddSubview(linearGauge2);


        }


    }
}
