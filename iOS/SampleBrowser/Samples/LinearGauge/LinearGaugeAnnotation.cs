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
    public class LinearGaugeAnnotation : SampleView
    {
        SFLinearGauge linearGauge;

        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }


        public override void LayoutSubviews()
        {
            
                foreach (var view in this.Subviews)
                {
                    view.Frame = Bounds;
                    linearGauge.Frame = new CGRect(0, -30, this.Frame.Size.Width, this.Frame.Size.Height + 30);
                }
            
            base.LayoutSubviews();
        }
        public LinearGaugeAnnotation()
        {

            this.BackgroundColor = UIColor.White;
            linearGauge = new SFLinearGauge();
            linearGauge.BackgroundColor = UIColor.White;
            linearGauge.Header = new SFLinearLabel();

            SFLinearGaugeAnnotation annotation1 = new SFLinearGaugeAnnotation();
            annotation1.ScaleValue = 15;
            annotation1.ViewMargin = new CGPoint(0, 30);
            UIImageView image1 = new UIImageView();
            image1.Frame = new CGRect(0, 0, 30, 30);
            image1.Image = UIImage.FromBundle("Low.png");
            annotation1.View = image1;

            SFLinearGaugeAnnotation annotation2 = new SFLinearGaugeAnnotation();
            annotation2.ScaleValue = 45;
            annotation2.ViewMargin = new CGPoint(0, 30);
            UIImageView image2 = new UIImageView();
            image2.Frame = new CGRect(0, 0, 30, 30);
            image2.Image = UIImage.FromBundle("Moderate.png");
            annotation2.View = image2;


            SFLinearGaugeAnnotation annotation3 = new SFLinearGaugeAnnotation();
            annotation3.ScaleValue = 75;
            annotation3.ViewMargin = new CGPoint(0, 30);
            UIImageView image3 = new UIImageView();
            image3.Frame = new CGRect(0, 0, 30, 30);
            image3.Image = UIImage.FromBundle("High.png");
            annotation3.View = image3;


            SFLinearGaugeAnnotation annotation4 = new SFLinearGaugeAnnotation();
            annotation4.ScaleValue = 15;
            annotation4.HorizontalViewAlignment = ViewAlignment.Center;
            annotation4.ViewMargin = new CGPoint(0, 80);
            UILabel label1 = new UILabel();
            label1.Frame = new CGRect(0, 0, 30, 30);
            label1.Text = "Low";
            label1.Font = UIFont.FromName("Helvetica", 12f);
            label1.TextColor = UIColor.FromRGB(48, 179, 45);
            annotation4.View = label1;

            SFLinearGaugeAnnotation annotation5 = new SFLinearGaugeAnnotation();
            annotation5.ScaleValue = 45;
            annotation5.HorizontalViewAlignment = ViewAlignment.Center;
            annotation5.ViewMargin = new CGPoint(0, 80);
            UILabel label2 = new UILabel();
            label2.Text = "Moderate";
            label2.Frame = new CGRect(0, 0, 60, 50);
            label2.Font = UIFont.FromName("Helvetica", 12f);
            label2.TextColor = UIColor.FromRGB(255, 221, 0);
            annotation5.View = label2;

            SFLinearGaugeAnnotation annotation6 = new SFLinearGaugeAnnotation();
            annotation6.ScaleValue = 75;
            annotation6.HorizontalViewAlignment = ViewAlignment.Center;
            annotation6.ViewMargin = new CGPoint(0, 80);
            UILabel label3 = new UILabel();
            label3.Text = "High";
            label3.Frame = new CGRect(0, 0, 30, 30);

            label3.Font = UIFont.FromName("Helvetica", 12f);
            label3.TextColor = UIColor.FromRGB(240, 62, 62);
            annotation6.View = label3;

            SFLinearGaugeAnnotation annotation7 = new SFLinearGaugeAnnotation();
            annotation7.ScaleValue = 45;
            annotation7.HorizontalViewAlignment = ViewAlignment.Center;
            annotation7.ViewMargin = new CGPoint(0, -80);
            UILabel label4 = new UILabel();
            label4.Frame = new CGRect(0, 0, 130, 175);
            label4.Text = "CPU Utilization";
            //label4.Font = UIFont.FromName("Helvetica", 14f);
            label4.TextColor = UIColor.Black;
            annotation7.View = label4;

            linearGauge.Annotations.Add(annotation1);
            linearGauge.Annotations.Add(annotation2);
            linearGauge.Annotations.Add(annotation3);
            linearGauge.Annotations.Add(annotation4);
            linearGauge.Annotations.Add(annotation5);
            linearGauge.Annotations.Add(annotation6);
            linearGauge.Annotations.Add(annotation7);

            SFLinearScale scale = new SFLinearScale();
            scale.Minimum = 0;
            scale.Maximum = 90;
            scale.ShowScaleLabel = false;
            scale.MinorTicksPerInterval = 0;
            scale.ScaleBarSize = 13;
            scale.ShowTicks = false;
            scale.ScaleBarColor = UIColor.Clear;

            SFLinearTickSettings major = new SFLinearTickSettings();
            major.Length = 0;
            scale.MajorTickSettings = major;

            SFLinearRange range1 = new SFLinearRange();
            range1.StartValue = 0;
            range1.EndValue = 30;
            range1.StartWidth = 60;
            range1.EndWidth = 60;
            range1.Color = UIColor.FromRGB(48, 179, 45);
            scale.Ranges.Add(range1);

            SFLinearRange range2 = new SFLinearRange();
            range2.StartValue = 30;
            range2.EndValue = 60;
            range2.StartWidth = 60;
            range2.EndWidth = 60;
            range2.Color = UIColor.FromRGB(255, 221, 0);
            scale.Ranges.Add(range2);

            SFLinearRange range3 = new SFLinearRange();
            range3.StartValue = 60;
            range3.EndValue = 90;
            range3.StartWidth = 60;
            range3.EndWidth = 60;
            range3.Color = UIColor.FromRGB(240, 62, 62);
            scale.Ranges.Add(range3);
            linearGauge.Scales.Add(scale);

            this.AddSubview(linearGauge);
        }
    }
}
