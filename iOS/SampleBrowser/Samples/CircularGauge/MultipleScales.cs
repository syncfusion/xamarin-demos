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
    public class MultipleScales : SampleView
    {

        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }


        UISlider slider;
        UIView option = new UIView();
        SFCircularGauge gauge;
        SFCircularScale scale1;
        SFCircularScale scale2;

        public override void LayoutSubviews()
        {
            foreach (var view in this.Subviews)
            {
                view.Frame = Bounds;
            }
            if (Utility.IsIPad)
            {
                gauge.Frame = new CGRect(50, 50, (float)this.Frame.Width - 100, (float)this.Frame.Height - 100);
            }
            else
            {
                gauge.Frame = new CGRect(10, 10, (float)this.Frame.Width - 20, (float)this.Frame.Height - 20);
            }
            base.LayoutSubviews();
        }
        public MultipleScales()
        {
            gauge = new SFCircularGauge();
            scale1 = new SFCircularScale();
            scale1.StartValue = 0;
            scale1.EndValue = 240;
            scale1.Interval = 20;
            scale1.MinorTicksPerInterval = 1;
            scale1.ScaleStartOffset = 0.7f;
            scale1.ScaleEndOffSet = 0.69f;
            scale1.LabelOffset = 0.88f;
            scale1.LabelColor = UIColor.FromRGB(198, 46, 10);
            scale1.RimColor = UIColor.FromRGB(198, 46, 10);

            SFTickSettings major = new SFTickSettings();
            major.StartOffset = 0.7f;
            major.EndOffset = 0.77f;
            major.Width = 2;
            major.Color = UIColor.FromRGB(198, 46, 10);

            SFTickSettings minor = new SFTickSettings();
            minor.StartOffset = 0.7f;
            minor.EndOffset = 0.77f;
            minor.Width = 2;
            minor.Color = UIColor.FromRGB(198, 46, 10);
            scale1.MajorTickSettings = major;
            scale1.MinorTickSettings = minor;

            SFMarkerPointer pointer1 = new SFMarkerPointer();
            pointer1.Value = 120;
            pointer1.Color = UIColor.FromRGB(198, 46, 10);
            pointer1.Offset = 0.69f;
            pointer1.MarkerShape = MarkerShape.InvertedTriangle;
            pointer1.EnableAnimation = false;
            scale1.Pointers.Add(pointer1);
            gauge.Scales.Add(scale1);

            scale2 = new SFCircularScale();
            scale2.StartValue = 0;
            scale2.EndValue = 160;
            scale2.Interval = 40;
            scale2.MinorTicksPerInterval = 1;
            scale2.RimColor = UIColor.FromRGB(51, 51, 51);
            scale2.LabelOffset = 0.45f;
            scale2.LabelColor = UIColor.FromRGB(51, 51, 51);
            scale2.ScaleStartOffset = 0.65f;
            scale2.ScaleEndOffSet = 0.64f;

            SFTickSettings major1 = new SFTickSettings();
            major1.StartOffset = 0.64f;
            major1.EndOffset = 0.57f;
            major1.Width = 2;
            major1.Color = UIColor.FromRGB(51, 51, 51);
            scale2.MajorTickSettings = major1;

            SFTickSettings minor1 = new SFTickSettings();
            minor1.StartOffset = 0.64f;
            minor1.EndOffset = 0.59f;
            minor1.Width = 2;
            minor1.Color = UIColor.FromRGB(51, 51, 51);
            scale2.MinorTickSettings = minor1;

            SFMarkerPointer pointer2 = new SFMarkerPointer();
            pointer2.Value = 80;
            pointer2.Color = UIColor.FromRGB(51, 51, 51);
            pointer2.Offset = 0.65f;
            pointer2.MarkerShape = MarkerShape.Triangle;
            pointer2.EnableAnimation = false;
            scale2.Pointers.Add(pointer2);

            gauge.Scales.Add(scale2);

            this.AddSubview(gauge);

            CreateOptionView();
            this.OptionView = option;
        }

        private void CreateOptionView()
        {
            UILabel text = new UILabel();
            text.Text = "Scale1";
            text.TextAlignment = UITextAlignment.Left;
            text.TextColor = UIColor.Black;
            text.Frame = new CGRect(10, 10, 320, 20);
            text.Font = UIFont.FromName("Helvetica", 14f);

            UILabel text1 = new UILabel();
            text1.Text = "StartAngle";
            text1.TextAlignment = UITextAlignment.Left;
            text1.TextColor = UIColor.Black;
            text1.Frame = new CGRect(10, 35, 320, 20);
            text1.Font = UIFont.FromName("Helvetica", 14f);

            slider = new UISlider();
            slider.Frame = new CGRect(5, 60, 320, 20);
            slider.MinValue = 0f;
            slider.MaxValue = 360f;
            slider.Value = 40f;
            slider.ValueChanged += (object sender, EventArgs e) =>
            {
                scale1.StartAngle = slider.Value;
            };

            UILabel text2 = new UILabel();
            text2.Text = "SweepAngle";
            text2.TextAlignment = UITextAlignment.Left;
            text2.TextColor = UIColor.Black;
            text2.Frame = new CGRect(10, 85, 320, 20);
            text2.Font = UIFont.FromName("Helvetica", 14f);


            UISlider slider1 = new UISlider();
            slider1.Frame = new CGRect(5, 110, 320, 20);
            slider1.MinValue = 0f;
            slider1.MaxValue = 360f;
            slider1.Value = 320f;
            slider1.ValueChanged += (object sender, EventArgs e) =>
            {
                scale1.SweepAngle = slider1.Value;
            };


            UILabel text3 = new UILabel();
            text3.Text = "Scale2";
            text3.TextAlignment = UITextAlignment.Left;
            text3.TextColor = UIColor.Black;
            text3.Frame = new CGRect(10, 135, 320, 20);
            text3.Font = UIFont.FromName("Helvetica", 14f);

            UILabel text4 = new UILabel();
            text4.Text = "StartAngle";
            text4.TextAlignment = UITextAlignment.Left;
            text4.TextColor = UIColor.Black;
            text4.Frame = new CGRect(10, 160, 320, 20);
            text4.Font = UIFont.FromName("Helvetica", 14f);

            UISlider slider2 = new UISlider();
            slider2.Frame = new CGRect(5, 185, 320, 20);
            slider2.MinValue = 0f;
            slider2.MaxValue = 360f;
            slider2.Value = 40f;
            slider2.ValueChanged += (object sender, EventArgs e) =>
            {
                scale2.StartAngle = slider2.Value;
            };

            UILabel text5 = new UILabel();
            text5.Text = "SweepAngle";
            text5.TextAlignment = UITextAlignment.Left;
            text5.TextColor = UIColor.Black;
            text5.Frame = new CGRect(10, 210, 320, 20);
            text5.Font = UIFont.FromName("Helvetica", 14f);

            UISlider slider3 = new UISlider();
            slider3.Frame = new CGRect(5, 235, 320, 20);
            slider3.MinValue = 0f;
            slider3.MaxValue = 360f;
            slider3.Value = 320f;
            slider3.ValueChanged += (object sender, EventArgs e) =>
            {
                scale2.SweepAngle = slider3.Value;
            };

            this.option.AddSubview(text);
            this.option.AddSubview(text1);
            this.option.AddSubview(slider);
            this.option.AddSubview(text2);
            this.option.AddSubview(slider1);
            this.option.AddSubview(text3);
            this.option.AddSubview(text4);
            this.option.AddSubview(slider2);
            this.option.AddSubview(text5);
            this.option.AddSubview(slider3);
        }


        protected override void Dispose(bool disposing)
        {
            //gauge.Scales[0].Pointers.Clear();
            //gauge.Scales[1].Pointers.Clear();
            //gauge.Scales.Clear();
            //gauge.Dispose();

            base.Dispose(disposing);
        }
    }
}
