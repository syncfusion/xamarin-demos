#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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

#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using nint = System.Int32;
using nuint = System.Int32;
#endif

namespace SampleBrowser
{
    public class ErrorBar : SampleView
    {
        public ErrorBar()
        {
            SFChart chart = new SFChart();
            chart.Title.Text = new NSString("Sales Distribution of Car by Region");
            chart.Title.EdgeInsets = new UIEdgeInsets(0, 0, 15, 0);

            ChartViewModel dataModel = new ChartViewModel();

            SFCategoryAxis primaryAxis = new SFCategoryAxis();
            primaryAxis.ShowMajorGridLines = false;
            primaryAxis.PlotOffset = 10;
            primaryAxis.LabelPlacement = SFChartLabelPlacement.BetweenTicks;
            NSNumberFormatter formatter = new NSNumberFormatter();
            formatter.PositiveSuffix = "%";
            primaryAxis.AxisLineOffset = 10;
            chart.PrimaryAxis = primaryAxis;

            SFNumericalAxis secondaryAxis = new SFNumericalAxis();
            secondaryAxis.Minimum = new NSNumber(15);
            secondaryAxis.Maximum = new NSNumber(45);
            secondaryAxis.Interval = new NSNumber(5);
            secondaryAxis.MajorTickStyle.LineSize = 0;
            secondaryAxis.AxisLineStyle.LineWidth = 0;
            chart.SecondaryAxis = secondaryAxis;

            SFScatterSeries scatterSeries = new SFScatterSeries();
            scatterSeries.ItemsSource = dataModel.ErrorBarData;
            scatterSeries.XBindingPath = "XValue";
            scatterSeries.YBindingPath = "YValue";
            scatterSeries.ScatterHeight = 20;
            scatterSeries.ScatterWidth = 20;
            scatterSeries.ShapeType = ChartScatterShapeType.Ellipse;
            scatterSeries.ColorModel.Palette = SFChartColorPalette.Natural;
            chart.Series.Add(scatterSeries);

            SFErrorBarSeries errorBarSeries = new SFErrorBarSeries();
            errorBarSeries.ItemsSource = dataModel.ErrorBarData;
            errorBarSeries.XBindingPath = "XValue";
            errorBarSeries.YBindingPath = "YValue";
            errorBarSeries.HorizontalErrorPath = "High";
            errorBarSeries.VerticalErrorPath = "Low";
            errorBarSeries.HorizontalErrorValue = 3;
            errorBarSeries.VerticalErrorValue = 3;
            errorBarSeries.Mode = ErrorBarMode.Vertical;
            errorBarSeries.Type = ErrorBarType.Fixed;
            errorBarSeries.HorizontalLineStyle = new ErrorBarLineStyle();
            errorBarSeries.HorizontalLineStyle.LineColor = UIColor.Black;
            errorBarSeries.VerticalLineStyle = new ErrorBarLineStyle();
            errorBarSeries.VerticalLineStyle.LineColor = UIColor.Black;
            errorBarSeries.HorizontalCapLineStyle = new ErrorBarCapLineStyle();
            errorBarSeries.HorizontalCapLineStyle.LineColor = UIColor.Black;
            errorBarSeries.VerticalCapLineStyle = new ErrorBarCapLineStyle();
            errorBarSeries.VerticalCapLineStyle.LineColor = UIColor.Black;
            chart.Series.Add(errorBarSeries);

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
