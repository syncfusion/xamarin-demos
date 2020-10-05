#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfChart.iOS;

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
#endif

namespace SampleBrowser
{
    public class BoxAndWhisker : SampleView
    {
        public BoxAndWhisker()
        {
            SFChart chart = new SFChart();
            chart.Title.Text = new NSString("Employee Age Group in Various Department");
            chart.Title.EdgeInsets = new UIEdgeInsets(0, 0, 15, 0);

            SFCategoryAxis primaryAxis = new SFCategoryAxis();
            primaryAxis.LabelPlacement = SFChartLabelPlacement.BetweenTicks;
            primaryAxis.ShowMajorGridLines = false;
            primaryAxis.Title.Text = new NSString("Department");
            chart.PrimaryAxis = primaryAxis;

            SFNumericalAxis secoundaryAxis = new SFNumericalAxis();
            secoundaryAxis.Title.Text = new NSString("Age");
            secoundaryAxis.Maximum = new NSNumber(60);
            secoundaryAxis.Minimum = new NSNumber(20);
            secoundaryAxis.Interval = new NSNumber(5);
            secoundaryAxis.ShowMinorGridLines = false;
            secoundaryAxis.AxisLineStyle.LineWidth = 0;
            secoundaryAxis.MajorTickStyle.LineSize = 0;
            chart.SecondaryAxis = secoundaryAxis;
            ChartViewModel dataModel = new ChartViewModel();

            SFBoxAndWhiskerSeries boxPlotSeries = new SFBoxAndWhiskerSeries();
            boxPlotSeries.ItemsSource = dataModel.BoxAndWhiskerData;
            boxPlotSeries.XBindingPath = "Department";
            boxPlotSeries.YBindingPath = "EmployeeAges";
            boxPlotSeries.BoxPlotMode = BoxPlotMode.Exclusive;
            boxPlotSeries.EnableTooltip = true;
            boxPlotSeries.ShowMedian = true;
            boxPlotSeries.ColorModel.Palette = SFChartColorPalette.Custom;
            boxPlotSeries.ColorModel.CustomColors = NSArray.FromObjects(UIColor.FromRGBA(0 / 255.0f, 189 / 255.0f, 174 / 255.0f, 255 / 255.0f),
                                                                        UIColor.FromRGBA(128 / 255.0f, 132 / 255.0f, 232 / 255.0f, 255 / 255.0f),
                                                                        UIColor.FromRGBA(53 / 255.0f, 124 / 255.0f, 210 / 255.0f, 255 / 255.0f),
                                                                        UIColor.FromRGBA(229 / 255.0f, 101 / 255.0f, 144 / 255.0f, 255 / 255.0f),
                                                                        UIColor.FromRGBA(248 / 255.0f, 184 / 255.0f, 131 / 255.0f, 255 / 255.0f));
            chart.Series.Add(boxPlotSeries);

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
