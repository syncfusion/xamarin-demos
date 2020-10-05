#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfChart.iOS;
using System.Drawing;
using System.Collections.Generic;

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
    public class Histogram : SampleView
    {
        public Histogram()
        {
            SFChart chart = new SFChart();
            chart.Title.Text = new NSString("Examination Result");
            chart.ColorModel.Palette = SFChartColorPalette.Natural;

            SFNumericalAxis primary = new SFNumericalAxis();
            primary.Title.Text = new NSString("Score of Final Examination");
            primary.EdgeLabelsDrawingMode = SFChartAxisEdgeLabelsDrawingMode.Shift;
            primary.ShowMajorGridLines = false;
            chart.PrimaryAxis = primary;

            chart.SecondaryAxis = new SFNumericalAxis();
            chart.SecondaryAxis.Title.Text = new NSString("Number of Students");
            chart.SecondaryAxis.ShowMajorGridLines = true;
            chart.SecondaryAxis.Visible = true;
            chart.SecondaryAxis.AxisLineStyle.LineWidth = 0;
            chart.SecondaryAxis.MajorTickStyle.LineWidth = new NSNumber(0);
            ChartViewModel dataModel = new ChartViewModel();

            SFHistogramSeries series1 = new SFHistogramSeries();
            series1.ItemsSource = dataModel.HistogramData;
            series1.XBindingPath = "YValue";
            series1.YBindingPath = "XValue";
            series1.EnableTooltip = true;
            series1.Interval = 20;
            series1.StrokeColor = UIColor.White;
            series1.StrokeWidth = 1;
            series1.EnableAnimation = true;
            series1.LegendIcon = SFChartLegendIcon.SeriesType;
            series1.DataMarker.ShowLabel = true;
            series1.DataMarker.LabelStyle.LabelPosition = SFChartDataMarkerLabelPosition.Inner;
            series1.DataMarker.LabelStyle.BackgroundColor = UIColor.Clear;
            series1.DataMarker.LabelStyle.Color = UIColor.White;
            chart.Series.Add(series1);

            chart.Delegate = new HistogramTooltipFormatter();
            var tooltip = new SFChartTooltipBehavior();
            tooltip.BackgroundColor = UIColor.FromRGBA(64.0f / 255.0f, 64.0f / 255.0f, 65.0f / 255.0f, 1.0f);
            chart.AddChartBehavior(tooltip);

            this.AddSubview(chart);

            this.OptionView = new UIView();

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

    class HistogramTooltipFormatter : SFChartDelegate
    {
        int interval = 20;

        public override void WillShowTooltip(SFChart chart, SFChartTooltip tooltipView)
        {
            UIView customView = new UIView();
            customView.Frame = new CGRect(0, 0, 65, 45);

            UILabel label = new UILabel();
            label.Frame = new CGRect(20, 0, 180, 18);
            label.TextColor = UIColor.White;
            label.Font = UIFont.FromName("Helvetica", 12f);
            label.Text = "Score";

            UILabel box = new UILabel();
            box.Frame = new CGRect(customView.Frame.X, label.Frame.Height + 2, customView.Frame.Width, 1);
            box.BackgroundColor = UIColor.White;

            var data = tooltipView.DataPoint as List<object>;
            int x = 0;
            int index = (int)(data[0] as ChartDataModel).YValue / interval;
            x = interval * index;

            UILabel xLabel = new UILabel();
            xLabel.Frame = new CGRect(5, 25, 80, 18);
            xLabel.TextColor = UIColor.LightGray;
            xLabel.Font = UIFont.FromName("Helvetica", 12f);
            xLabel.Text = x + "-" + (x + interval) + " : ";

            UILabel xValue = new UILabel();
            xValue.Frame = index == 4 ? new CGRect(52, 25, 35, 18) : new CGRect(45, 25, 35, 18);
            xValue.TextColor = UIColor.White;
            xValue.Font = UIFont.FromName("Helvetica", 12f);
            xValue.Text = data.Count.ToString();
                
            customView.AddSubview(label);
            customView.AddSubview(box);
            customView.AddSubview(xLabel);
            customView.AddSubview(xValue);
            tooltipView.CustomView = customView;
        }
    }
}