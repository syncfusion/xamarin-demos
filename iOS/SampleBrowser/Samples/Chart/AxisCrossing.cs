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

using System.Threading.Tasks;

namespace SampleBrowser
{
    public class AxisCrossing : SampleView
    {
        public AxisCrossing()
        {
            SFChart chart = new SFChart();
            chart.Title.Text = new NSString("Profit/loss percentage comparison");

            SFCategoryAxis primaryAxis = new SFCategoryAxis();
            primaryAxis.Interval = new NSNumber(2);
            primaryAxis.CrossesAt = 0;
            primaryAxis.PlotOffset = 7;
            primaryAxis.ShowMajorGridLines = false;
            primaryAxis.AxisLineOffset = 7;
            primaryAxis.EdgeLabelsDrawingMode = SFChartAxisEdgeLabelsDrawingMode.Fit;
            primaryAxis.Name = new NSString("XAxis");
            primaryAxis.CrossingAxisName = "YAxis";
            primaryAxis.ShowMajorGridLines = false;
            chart.PrimaryAxis = primaryAxis;

            SFNumericalAxis secondaryAxis = new SFNumericalAxis();
            secondaryAxis.Maximum = new NSNumber(-100);
            secondaryAxis.Minimum = new NSNumber(100);
            secondaryAxis.Interval = new NSNumber(20);
            secondaryAxis.CrossesAt = 8;
            secondaryAxis.EdgeLabelsDrawingMode = SFChartAxisEdgeLabelsDrawingMode.Shift;
            secondaryAxis.Name = new NSString("YAxis");
            secondaryAxis.CrossingAxisName = "XAxis";
            secondaryAxis.ShowMajorGridLines = false;
            secondaryAxis.ShowMinorGridLines = false;
            chart.SecondaryAxis = secondaryAxis;

            ChartViewModel dataModel = new ChartViewModel();

            SFScatterSeries series = new SFScatterSeries();
            series.ScatterWidth = 15;
            series.ScatterHeight = 15;
            series.ItemsSource = dataModel.AxisCrossingData;
            series.XBindingPath = "XValue";
            series.YBindingPath = "YValue";
            series.ColorModel.Palette = SFChartColorPalette.Natural;
            series.EnableTooltip = true;


            chart.Behaviors.Add(new SFChartZoomPanBehavior() { EnableSelectionZooming = false });
            chart.Delegate = new CustomDelegate();
            chart.Series.Add(series);
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

    public class CustomDelegate : SFChartDelegate
    {
        public override NSString GetFormattedAxisLabel(SFChart chart, NSString label, NSObject value, SFAxis axis)
        {
            if (axis == chart.SecondaryAxis)
                label = (Foundation.NSString)(label + "%");

            return label;
        }
    }
}
