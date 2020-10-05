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
    public class Pointers : SampleView
    {
        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }


        UIScrollView scroll;
        SFCircularGauge gauge1;
        SFCircularGauge gauge2;
        SFCircularGauge gauge3;
        SFCircularGauge gauge4;
        SFCircularGauge gauge5;

        public override void LayoutSubviews()
        {
                foreach (var view in this.Subviews)
                {
                    view.Frame = Bounds;
                    CGSize sz = this.Frame.Size;

                   
                    gauge1.Frame = new CGRect(0, 0, sz.Width, sz.Height / 2);
                    gauge2.Frame = new CGRect(0, sz.Height / 3, sz.Width, sz.Height / 2);
                    gauge3.Frame = new CGRect(0, sz.Height / 3 * 2, sz.Width, sz.Height / 2);
                  //  gauge4.Frame = new CGRect(10, 470, (float)this.Frame.Width - 20, (float)this.Frame.Height / 2 - 20);
                  //  gauge5.Frame = new CGRect(10, 600, (float)this.Frame.Width - 20, (float)this.Frame.Height / 2 - 20);

                }

            
            base.LayoutSubviews();
        }
        public Pointers()
        {
            scroll = new UIScrollView();
            gauge1 = new SFCircularGauge();
            SFGaugeHeader header1 = new SFGaugeHeader();
            header1.Position = new CGPoint(0.5, 0.6);
            header1.TextStyle = UIFont.SystemFontOfSize(14);
            header1.Text = (Foundation.NSString)"Inverted Triangle";
            header1.TextColor = UIColor.Black;
            gauge1.Headers.Add(header1);

            SFCircularScale scale1 = new SFCircularScale();
            scale1.StartAngle = 90;
            scale1.SweepAngle = 270;
            scale1.ScaleStartOffset = 0.7f;
            scale1.ScaleEndOffSet = 0.68f;
            scale1.StartValue = 0;
            scale1.EndValue = 100;
            scale1.RimColor = UIColor.Gray;
            scale1.Interval = 50;
            scale1.ShowLabels = false;
            scale1.ShowTicks = false;
            scale1.MinorTicksPerInterval = 0;

            SFMarkerPointer pointer1 = new SFMarkerPointer();
            pointer1.Value = 80;
            pointer1.Offset = 0.7f;
            pointer1.MarkerShape = MarkerShape.InvertedTriangle;
            pointer1.Color = UIColor.FromRGB(0, 180, 174);
            scale1.Pointers.Add(pointer1);

            gauge1.Scales.Add(scale1);


            gauge2 = new SFCircularGauge();
            SFGaugeHeader header2 = new SFGaugeHeader();
            header2.Position = new CGPoint(0.5, 0.6);
            header2.TextStyle = UIFont.SystemFontOfSize(14);
            header2.Text = (Foundation.NSString)"Triangle";
            header2.TextColor = UIColor.Black;
            gauge2.Headers.Add(header2);

            SFCircularScale scale2 = new SFCircularScale();
            scale2.StartAngle = 90;
            scale2.SweepAngle = 270;
            scale2.ScaleStartOffset = 0.7f;
            scale2.ScaleEndOffSet = 0.68f;
            scale2.StartValue = 0;
            scale2.EndValue = 100;
            scale2.RimColor = UIColor.Gray;
            scale2.Interval = 50;
            scale2.ShowLabels = false;
            scale2.ShowTicks = false;
            scale2.MinorTicksPerInterval = 0;

            SFMarkerPointer pointer2 = new SFMarkerPointer();
            pointer2.Value = 80;
            pointer2.Offset = 0.68f;
            pointer2.MarkerShape = MarkerShape.Triangle;
            pointer2.Color = UIColor.Green;
            scale2.Pointers.Add(pointer2);

            gauge2.Scales.Add(scale2);

            gauge3 = new SFCircularGauge();
            SFGaugeHeader header3 = new SFGaugeHeader();
            header3.Position = new CGPoint(0.5, 0.6);
            header3.TextStyle = UIFont.SystemFontOfSize(14);
            header3.Text = (Foundation.NSString)"Range Pointer";
            header3.TextColor = UIColor.Black;
            gauge3.Headers.Add(header3);

            SFCircularScale scale3 = new SFCircularScale();
            scale3.StartAngle = 90;
            scale3.SweepAngle = 270;
            scale3.ScaleStartOffset = 0.7f;
            scale3.ScaleEndOffSet = 0.68f;
            scale3.StartValue = 0;
            scale3.EndValue = 100;
            scale3.RimColor = UIColor.Gray;
            scale3.Interval = 50;
            scale3.ShowLabels = false;
            scale3.ShowTicks = false;
            scale3.MinorTicksPerInterval = 0;

            SFRangePointer pointer3 = new SFRangePointer();
            pointer3.Value = 60;
            pointer3.Offset = 0.6f;
            pointer3.Width = 15;
            pointer3.Color = UIColor.FromRGB(255, 38, 128);
            scale3.Pointers.Add(pointer3);
            gauge3.Scales.Add(scale3);


            gauge4 = new SFCircularGauge();
            SFGaugeHeader header4 = new SFGaugeHeader();
            header4.Position = new CGPoint(0.5, 0.7);
            header4.TextStyle = UIFont.SystemFontOfSize(14);
            header4.Text = (Foundation.NSString)"Multiple Needle";
            header4.TextColor = UIColor.Black;
            gauge4.Headers.Add(header4);

            SFCircularScale scale4 = new SFCircularScale();
            scale4.StartAngle = 90;
            scale4.SweepAngle = 270;
            scale4.ScaleStartOffset = 0.7f;
            scale4.ScaleEndOffSet = 0.68f;
            scale4.StartValue = 0;
            scale4.EndValue = 100;
            scale4.RimColor = UIColor.Gray;
            scale4.Interval = 50;
            scale4.ShowLabels = false;
            scale4.ShowTicks = false;
            scale4.MinorTicksPerInterval = 0;


            SFNeedlePointer pointer4 = new SFNeedlePointer();
            pointer4.Value = 80;
            pointer4.Color = UIColor.Purple;
            pointer4.LengthFactor = 0.7f;
            pointer4.KnobRadius = 0;
            pointer4.Width = 10;
            pointer4.PointerType = SFCiruclarGaugePointerType.SFCiruclarGaugePointerTypeTriangle;
            scale4.Pointers.Add(pointer4);

            gauge4.Scales.Add(scale4);

            gauge5 = new SFCircularGauge();
            SFGaugeHeader header5 = new SFGaugeHeader();
            header5.Position = new CGPoint(0.5, 0.6);
            header5.TextStyle = UIFont.SystemFontOfSize(14);
            header5.Text = (Foundation.NSString)"Needle Pointer";
            header5.TextColor = UIColor.Black;
            gauge5.Headers.Add(header5);

            SFCircularScale scale5 = new SFCircularScale();
            scale5.StartAngle = 90;
            scale5.SweepAngle = 270;
            scale5.ScaleStartOffset = 0.7f;
            scale5.ScaleEndOffSet = 0.68f;
            scale5.StartValue = 0;
            scale5.EndValue = 100;
            scale5.RimColor = UIColor.Gray;
            scale5.Interval = 50;
            scale5.ShowLabels = false;
            scale5.ShowTicks = false;
            scale5.MinorTicksPerInterval = 0;


            SFNeedlePointer pointer5 = new SFNeedlePointer();
            pointer5.Value = 40;
            pointer5.Color = UIColor.Purple;
            pointer5.LengthFactor = 0.5f;
            pointer5.KnobRadiusFactor = 0.05f;
            pointer5.Width = 10;
            pointer5.KnobColor = UIColor.White;
            pointer5.KnobStrokeColor = UIColor.FromRGB(237, 125, 49);
            pointer5.KnobStrokeWidth = 2f;
            pointer5.TailLengthFactor = 0.2f;
            pointer5.TailColor = UIColor.FromRGB(237, 125, 49);
            pointer5.TailStrokeColor = UIColor.FromRGB(237, 125, 49);
            pointer5.PointerType = SFCiruclarGaugePointerType.SFCiruclarGaugePointerTypeTriangle;
            scale5.Pointers.Add(pointer5);

            SFNeedlePointer pointer6 = new SFNeedlePointer();
            pointer6.Value = 70;
            pointer6.Color = UIColor.Purple;
            pointer6.LengthFactor = 0.6f;
            pointer6.KnobRadiusFactor = 0.05f;
            pointer6.Width = 10;
            pointer6.KnobColor = UIColor.White;
            pointer6.KnobStrokeColor = UIColor.FromRGB(237, 125, 49);
            pointer6.KnobStrokeWidth = 2f;
            pointer6.TailLengthFactor = 0.25f;
            pointer6.TailColor = UIColor.FromRGB(237, 125, 49);
            pointer6.TailStrokeColor = UIColor.FromRGB(237, 125, 49);
            pointer6.PointerType = SFCiruclarGaugePointerType.SFCiruclarGaugePointerTypeTriangle;
            scale5.Pointers.Add(pointer6);

            gauge5.Scales.Add(scale5);

            scroll.AddSubview(gauge1);
            scroll.AddSubview(gauge2);
            scroll.AddSubview(gauge3);
            scroll.AddSubview(gauge4);
            scroll.AddSubview(gauge5);

            this.AddSubview(scroll);


        }

        protected override void Dispose(bool disposing)
        {
            //gauge1.Scales[0].Pointers.Clear();
            //gauge1.Scales.Clear();
            //gauge1.Dispose();

            //gauge2.Scales[0].Pointers.Clear();
            //gauge2.Scales.Clear();
            //gauge2.Dispose();

            //gauge3.Scales[0].Pointers.Clear();
            //gauge3.Scales.Clear();
            //gauge3.Dispose();

            //gauge4.Scales[0].Pointers.Clear();
            //gauge4.Scales.Clear();
            //gauge4.Dispose();

            //gauge5.Scales[0].Pointers.Clear();
            //gauge5.Scales.Clear();
            //gauge5.Dispose();

            base.Dispose(disposing);
        }
    }
}
