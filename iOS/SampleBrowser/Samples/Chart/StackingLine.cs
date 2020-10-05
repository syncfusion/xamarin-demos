#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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
using nint	 = System.Int32;
using nuint	 = System.Int32;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
#endif
namespace SampleBrowser
{
    public class StackedLine : SampleView
    {
        public StackedLine()
        {
            SFChart chart = new SFChart();
            chart.Title.Text = new NSString("Monthly Expenses of a Family");
            chart.ColorModel.Palette = SFChartColorPalette.Natural;

            SFCategoryAxis primaryAxis = new SFCategoryAxis();
            primaryAxis.LabelPlacement = SFChartLabelPlacement.BetweenTicks;
            primaryAxis.ShowMajorGridLines = false;
            primaryAxis.MajorTickStyle.LineSize = 0;
            chart.PrimaryAxis = primaryAxis;
            chart.SecondaryAxis = new SFNumericalAxis();
            chart.SecondaryAxis.Maximum = new NSNumber(200);
            chart.SecondaryAxis.Minimum = new NSNumber(0);
            chart.SecondaryAxis.Interval = new NSNumber(20);
            chart.SecondaryAxis.AxisLineStyle.LineWidth = 0;
            chart.SecondaryAxis.MajorTickStyle.LineSize = 0;
            NSNumberFormatter formatter = new NSNumberFormatter();
            formatter.PositivePrefix = "$";
            chart.SecondaryAxis.LabelStyle.LabelFormatter = formatter;
            ChartViewModel dataModel = new ChartViewModel();

            SFStackingLineSeries series1 = new SFStackingLineSeries();
            series1.LineWidth = 2;
            series1.ItemsSource = dataModel.StackedLineData1;
            series1.XBindingPath = "XValue";
            series1.YBindingPath = "YValue";
            series1.DataMarker.ShowMarker = true;
            series1.DataMarker.MarkerColor = UIColor.White;
            series1.DataMarker.MarkerBorderColor = UIColor.FromRGBA(0.0f / 255.0f, 189.0f / 255.0f, 174.0f / 255.0f, 1.0f);
            series1.DataMarker.MarkerBorderWidth = 2;
            series1.DataMarker.MarkerWidth = 10f;
            series1.DataMarker.MarkerHeight = 10f;
            series1.LegendIcon = SFChartLegendIcon.SeriesType;
            series1.EnableTooltip = true;
            series1.Label = "Daughter";
            series1.EnableAnimation = true;
            series1.LegendIcon = SFChartLegendIcon.SeriesType;
            chart.Series.Add(series1);

            SFStackingLineSeries series2 = new SFStackingLineSeries();
            series2.LineWidth = 2;
            series2.ItemsSource = dataModel.StackedLineData2;
            series2.XBindingPath = "XValue";
            series2.YBindingPath = "YValue";
            series2.DataMarker.ShowMarker = true;
            series2.DataMarker.MarkerColor = UIColor.White;
            series2.DataMarker.MarkerBorderColor = UIColor.FromRGBA(64.0f / 255.0f, 64.0f / 255.0f, 65.0f / 255.0f, 1.0f);
            series2.DataMarker.MarkerBorderWidth = 2;
            series2.DataMarker.MarkerWidth = 10f;
            series2.DataMarker.MarkerHeight = 10f;
            series2.LegendIcon = SFChartLegendIcon.SeriesType;
            series2.EnableTooltip = true;
            series2.Label = "Son";
            series2.LegendIcon = SFChartLegendIcon.SeriesType;
            series2.EnableAnimation = true;
            chart.Series.Add(series2);

            SFStackingLineSeries series3 = new SFStackingLineSeries();
            series3.LineWidth = 2;
            series3.ItemsSource = dataModel.StackedLineData3;
            series3.XBindingPath = "XValue";
            series3.YBindingPath = "YValue";
            series3.DataMarker.ShowMarker = true;
            series3.DataMarker.MarkerColor = UIColor.White;
            series3.DataMarker.MarkerBorderColor = UIColor.FromRGBA(53.0f / 255.0f, 124.0f / 255.0f, 210.0f / 255.0f, 1.0f);
            series3.DataMarker.MarkerBorderWidth = 2;
            series3.DataMarker.MarkerWidth = 10f;
            series3.DataMarker.MarkerHeight = 10f;
            series3.LegendIcon = SFChartLegendIcon.SeriesType;
            series3.EnableTooltip = true;
            series3.Label = "Mother";
            series3.EnableAnimation = true;
            chart.Series.Add(series3);

            SFStackingLineSeries series4 = new SFStackingLineSeries();
            series4.ItemsSource = dataModel.StackedLineData4;
            series4.XBindingPath = "XValue";
            series4.YBindingPath = "YValue";
            series4.DataMarker.ShowMarker = true;
            series4.DataMarker.MarkerColor = UIColor.White;
            series4.DataMarker.MarkerBorderColor = UIColor.FromRGBA(229.0f / 255.0f, 101.0f / 255.0f, 144.0f / 255.0f, 1.0f);
            series4.DataMarker.MarkerBorderWidth = 2;
            series4.DataMarker.MarkerWidth = 10f;
            series4.DataMarker.MarkerHeight = 10f;
            series4.LegendIcon = SFChartLegendIcon.SeriesType;
            series4.EnableTooltip = true;
            series4.Label = "Father";
            series4.EnableAnimation = true;
            chart.Series.Add(series4);

            chart.Legend.Visible = true;
            chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.IconWidth = 14;
            chart.Legend.IconHeight = 14;
            chart.Legend.DockPosition = SFChartLegendPosition.Bottom;

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
