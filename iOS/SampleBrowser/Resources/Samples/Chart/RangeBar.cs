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
#endif

namespace SampleBrowser
{
    public class RangeBar : SampleView
    {
        SFChart chart;

        public RangeBar()
        {
            chart = new SFChart();
            chart.Title.Text = new NSString("Pipeline Volume");
            chart.Title.Font = UIFont.SystemFontOfSize(13);

            SFCategoryAxis categoryaxis = new SFCategoryAxis();
            categoryaxis.ShowMajorGridLines = false;
            categoryaxis.AxisLineStyle.LineWidth = 0;
            categoryaxis.MajorTickStyle.LineSize = 0;
            categoryaxis.LabelStyle.Color = UIColor.Black;
            categoryaxis.LabelStyle.Font = UIFont.SystemFontOfSize(11);
            chart.PrimaryAxis = categoryaxis;

            SFNumericalAxis numericalaxis = new SFNumericalAxis();
            numericalaxis.Visible = false;
            numericalaxis.ShowMajorGridLines = false;
            numericalaxis.AxisLineStyle.LineWidth = 0;
            numericalaxis.MajorTickStyle.LineSize = 0;
            chart.SecondaryAxis = numericalaxis;
            ChartViewModel dataModel = new ChartViewModel();

            SFRangeColumnSeries rangeColumnSeries = new SFRangeColumnSeries();
            rangeColumnSeries.ItemsSource = dataModel.RangeBarData;
            rangeColumnSeries.XBindingPath = "XValue";
            rangeColumnSeries.High = "YValue";
            rangeColumnSeries.Low = string.Empty;
            rangeColumnSeries.DataMarker.ShowLabel = true;
            NSNumberFormatter formatter = new NSNumberFormatter();
            formatter.PositiveFormat = "$#,###";
            rangeColumnSeries.DataMarker.LabelStyle.LabelFormatter = formatter;
            rangeColumnSeries.IsTransposed = true;
            rangeColumnSeries.ColorModel.Palette = SFChartColorPalette.Natural;
            chart.Series.Add(rangeColumnSeries);

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
