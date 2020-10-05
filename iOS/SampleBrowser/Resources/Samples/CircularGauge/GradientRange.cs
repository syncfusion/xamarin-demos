#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using Syncfusion.SfGauge.iOS;
using System.Collections.ObjectModel;

#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;
using System.Drawing;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using CGRect = System.Drawing.RectangleF;
using CGPoint = System.Drawing.PointF;
using CGSize = System.Drawing.SizeF;
using nfloat = System.Single;
using System.Drawing;
#endif
namespace SampleBrowser
{
    public class GradientRange : SampleView
    {

        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }



        SFCircularGauge gauge;

        public override void LayoutSubviews()
        {
            foreach (var view in this.Subviews)
            {
                view.Frame = Bounds;
            }
            if (Utility.IsIpad)
            {
                gauge.Frame = new CGRect(50, 50, (float)this.Frame.Width - 100, (float)this.Frame.Height - 100);
            }
            else
            {
                gauge.Frame = new CGRect(10, 10, (float)this.Frame.Width - 20, (float)this.Frame.Height - 20);
            }
            base.LayoutSubviews();
        }
        public GradientRange()
        {
            gauge = new SFCircularGauge();
            gauge.BackgroundColor = UIColor.White;

            ObservableCollection<SFCircularScale> scales = new ObservableCollection<SFCircularScale>();

            SFCircularScale scale = new SFCircularScale();
            scale.StartValue = 0;
            scale.EndValue = 100;
            scale.Interval = 10;
            scale.ShowRim = false;
            scale.ShowTicks = false;
            scale.ShowLabels = false;

            SFCircularRange range = new SFCircularRange();
            range.Offset = 0.8f;
            range.StartValue = 0;
            range.EndValue = 100;
            range.Width = 25;

            GaugeGradientStop color1 = new GaugeGradientStop();
            color1.Value = 0;
            color1.Color = UIColor.FromRGB(240, 62, 62);
            range.GradientStops.Add(color1);

            GaugeGradientStop color2 = new GaugeGradientStop();
            color2.Value = 35;
            color2.Color = UIColor.FromRGB(255, 221, 0);
            range.GradientStops.Add(color2);

            GaugeGradientStop color3 = new GaugeGradientStop();
            color3.Value = 75;
            color3.Color = UIColor.FromRGB(255, 221, 0);
            range.GradientStops.Add(color3);

            GaugeGradientStop color4 = new GaugeGradientStop();
            color4.Value = 100;
            color4.Color = UIColor.FromRGB(48, 179, 45);
            range.GradientStops.Add(color4);
            scale.Ranges.Add(range);

            ObservableCollection<SFMarkerPointer> pointers = new ObservableCollection<SFMarkerPointer>();
            SFMarkerPointer pointer = new SFMarkerPointer();
            pointer.MarkerShape = MarkerShape.InvertedTriangle;
            pointer.Offset = 0.8f;
            pointer.Value = 55;
            pointer.MarkerWidth = 15;
            pointer.MarkerHeight = 15;
            pointer.Color = UIColor.Red;
            pointers.Add(pointer);
            scale.Pointers.Add(pointer);

            SFGaugeHeader header1 = new SFGaugeHeader();
            header1.Text = (Foundation.NSString)"0";
            header1.TextColor = UIColor.FromRGB(240, 62, 62);
            header1.Position = new CGPoint(0.28, 0.86);
            header1.TextStyle = UIFont.BoldSystemFontOfSize(12);
            gauge.Headers.Add(header1);

            SFGaugeHeader header2 = new SFGaugeHeader();
            header2.Text = (Foundation.NSString)"100";
            header2.TextColor = UIColor.FromRGB(48, 179, 45);
            header2.Position = new CGPoint(0.75, 0.86);
            header2.TextStyle = UIFont.BoldSystemFontOfSize(12);
            gauge.Headers.Add(header2);

            SFGaugeHeader header3 = new SFGaugeHeader();
            header3.Text = (Foundation.NSString)"55%";
            header3.TextColor = UIColor.FromRGB(240, 62, 62);
            header3.Position = new CGPoint(0.5, 0.5);
            header1.TextStyle = UIFont.BoldSystemFontOfSize(16);
            gauge.Headers.Add(header3);

            scales.Add(scale);


            gauge.Scales = scales;
            this.AddSubview(gauge);
        }

        protected override void Dispose(bool disposing)
        {
            //gauge.Scales[0].Pointers.Clear();
            //gauge.Scales[0].Ranges[0].GradientColors.Clear();
            //gauge.Scales[0].Ranges.Clear();
            //gauge.Scales.Clear();
            //gauge.Dispose();

            base.Dispose(disposing);


        }
    }
}
