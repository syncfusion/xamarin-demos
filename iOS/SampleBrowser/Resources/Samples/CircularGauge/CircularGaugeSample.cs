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
    public class CircularGaugeSample : SampleView
    {

        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }


        #region View lifecycle
        SFCircularGauge gauge;
        SFNeedlePointer needlePointer;
        UISlider slider;
        UIView option = new UIView();


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
        public CircularGaugeSample()
        {

            gauge = new SFCircularGauge();
            gauge.Scales.Add(new SFCircularScale());
            ObservableCollection<SFCircularScale> scales = new ObservableCollection<SFCircularScale>();

            SFCircularScale scale = new SFCircularScale();
            scale.StartValue = 0;
            scale.EndValue = 100;
            scale.Interval = 10;
            //scale.StartAngle = 35;
            // scale.SweepAngle = 320;
            scale.RimWidth = 5;
            scale.ShowTicks = false;
            scale.ShowLabels = true;
            scale.RimColor = UIColor.FromRGB(224, 224, 224);
            scale.LabelColor = UIColor.Black;
            scale.LabelOffset = 0.8f;
            scale.MinorTicksPerInterval = 0;
            ObservableCollection<SFCircularPointer> pointers = new ObservableCollection<SFCircularPointer>();

            needlePointer = new SFNeedlePointer();
            needlePointer.Value = 60;
            needlePointer.Color = UIColor.FromRGB(117, 117, 117);
            needlePointer.KnobRadius = 12;
            needlePointer.KnobColor = UIColor.FromRGB(117, 117, 117);
            needlePointer.Width = 3;
            needlePointer.LengthFactor = 0.6f;
            needlePointer.PointerType = SFCiruclarGaugePointerType.SFCiruclarGaugePointerTypeTriangle;
            scale.Pointers.Add(needlePointer);


            scales.Add(scale);
            gauge.Scales = scales;

            this.AddSubview(gauge);
            CreateOptionView();
            this.OptionView = option;
        }

        private void CreateOptionView()
        {
            slider = new UISlider();
            slider.Frame = new CGRect(5, 50, 320, 60);
            slider.MinValue = 0f;
            slider.MaxValue = 100f;
            slider.Value = 60f;
            slider.ValueChanged += (object sender, EventArgs e) =>
            {
                needlePointer.Value = slider.Value;
            };

            UILabel text1 = new UILabel();
            text1.Text = "Change Pointer Value";
            text1.TextAlignment = UITextAlignment.Left;
            text1.TextColor = UIColor.Black;
            text1.Frame = new CGRect(10, 25, 320, 40);
            text1.Font = UIFont.FromName("Helvetica", 14f);

            this.option.AddSubview(text1);

            this.option.AddSubview(slider);

        }


        protected override void Dispose(bool disposing)
        {
            //gauge.Scales[0].Pointers.Clear();
            //gauge.Scales.Clear();
            //gauge.Dispose();
            base.Dispose(disposing);
        }
        #endregion
    }
}
