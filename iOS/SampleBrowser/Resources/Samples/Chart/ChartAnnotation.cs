#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
using CoreAnimation;


#endregion
using System;
using Syncfusion.SfChart.iOS;


#if __UNIFIED__
using CoreGraphics;
using Foundation;
using UIKit;

#else
using MonoTouch.Foundation;
using MonoTouch.CoreGraphics;
using MonoTouch.UIKit;
using nint   = System.Int32;
using nuint  = System.Int32;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
#endif


namespace SampleBrowser
{
    public class ChartAnnotation : SampleView
    {
        public ChartAnnotation()
        {
            SFChart chart = new SFChart();
            chart.AreaBackgroundColor = UIColor.FromRGB(245, 245, 245);
            chart.PrimaryAxis = new SFNumericalAxis()
            {
                Minimum = new NSNumber(0),
                Maximum = new NSNumber(4),
                ShowMajorGridLines = false
            };
            chart.SecondaryAxis = new SFNumericalAxis()
            {
                Minimum = new NSNumber(20),
                Maximum = new NSNumber(70),
                ShowMajorGridLines = false,
            };

            VerticalLineAnnotation VerticalLineAnnotation = new VerticalLineAnnotation();
            VerticalLineAnnotation.X1 = 2;
            VerticalLineAnnotation.LineCap = ChartLineCap.Arrow;
            VerticalLineAnnotation.Text = "Vertical Line";
            VerticalLineAnnotation.ShowAxisLabel = true;

            HorizontalLineAnnotation horizontalLineAnnotation = new HorizontalLineAnnotation();
            horizontalLineAnnotation.Y1 = 45;
            horizontalLineAnnotation.LineCap = ChartLineCap.Arrow;
            horizontalLineAnnotation.Text = "Horizontal Line";
            horizontalLineAnnotation.ShowAxisLabel = true;

            LineAnnotation lineAnnotation = new LineAnnotation();
            lineAnnotation.X1 = 2.5;
            lineAnnotation.X2 = 3.5;
            lineAnnotation.Y1 = 52;
            lineAnnotation.Y2 = 63;
            lineAnnotation.LineCap = ChartLineCap.Arrow;
            lineAnnotation.Text = "Line";
           
            RectangleAnnotation rectangleAnnotation = new RectangleAnnotation();
            rectangleAnnotation.Text = "Rectangle";
            rectangleAnnotation.X1 = 0.5;
            rectangleAnnotation.X2 = 1.5;
            rectangleAnnotation.Y1 = 25;
            rectangleAnnotation.Y2 = 35;

            EllipseAnnotation ellipseAnnotation = new EllipseAnnotation();
            ellipseAnnotation.Text = "Ellipse";
            ellipseAnnotation.X1 = 2.5;
            ellipseAnnotation.X2 = 3.5;
            ellipseAnnotation.Y1 = 25;
            ellipseAnnotation.Y2 = 35;

            TextAnnotation textAnnotation = new TextAnnotation();
            textAnnotation.X1 = 1;
            textAnnotation.Y1 = 57.5;
            textAnnotation.Text = "Text Annotation";

            chart.Annotations.Add(VerticalLineAnnotation);
            chart.Annotations.Add(horizontalLineAnnotation);
            chart.Annotations.Add(lineAnnotation);
            chart.Annotations.Add(rectangleAnnotation);
            chart.Annotations.Add(ellipseAnnotation);
            chart.Annotations.Add(textAnnotation);
            this.AddSubview(chart);
        }

        public override void LayoutSubviews()
        {
            foreach (var view in this.Subviews)
            {
                view.Frame = Bounds;
            }
            base.LayoutSubviews();
        }
    }

}
