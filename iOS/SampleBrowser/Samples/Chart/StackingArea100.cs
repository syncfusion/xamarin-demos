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
	public class StackingArea100 :SampleView
	{
		public StackingArea100 ()
		{
			SFChart chart = new SFChart();
            chart.ColorModel.Palette = SFChartColorPalette.Natural;

            chart.Title.Text = new NSString("Trend in Sales of Ethical Produce");
            SFCategoryAxis primaryAxis = new SFCategoryAxis();
            primaryAxis.ShowMajorGridLines = false;
            primaryAxis.EdgeLabelsDrawingMode = SFChartAxisEdgeLabelsDrawingMode.Shift;
            chart.PrimaryAxis = primaryAxis;
            chart.SecondaryAxis = new SFNumericalAxis();
            chart.SecondaryAxis.Title.Text = new NSString("Spends");
            chart.SecondaryAxis.ShowMajorGridLines = false;
            chart.SecondaryAxis.AxisLineStyle.LineWidth = 0;
            chart.SecondaryAxis.MajorTickStyle.LineSize = 0;
            chart.SecondaryAxis.Minimum = new NSNumber(0);
            chart.SecondaryAxis.Maximum = new NSNumber(100);
            chart.SecondaryAxis.Interval = new NSNumber(10);
            NSNumberFormatter formatter = new NSNumberFormatter();
            formatter.PositiveSuffix = "%";
            chart.SecondaryAxis.LabelStyle.LabelFormatter = formatter;
            ChartViewModel dataModel = new ChartViewModel();

            SFStackingArea100Series series1 = new SFStackingArea100Series();
            series1.ItemsSource = dataModel.StackedArea100Data1;
            series1.XBindingPath = "XValue";
            series1.YBindingPath = "YValue";
            series1.EnableTooltip = true;
            series1.Label = "Organic";
            series1.LegendIcon = SFChartLegendIcon.SeriesType;
            series1.EnableAnimation = true;
            chart.Series.Add(series1);

            SFStackingArea100Series series2 = new SFStackingArea100Series();
            series2.ItemsSource = dataModel.StackedArea100Data2;
            series2.XBindingPath = "XValue";
            series2.YBindingPath = "YValue";
            series2.EnableTooltip = true;
            series2.Label = "Fair-trade";
            series2.LegendIcon = SFChartLegendIcon.SeriesType;
            series2.EnableAnimation = true;
            chart.Series.Add(series2);

            SFStackingArea100Series series3 = new SFStackingArea100Series();
            series3.ItemsSource = dataModel.StackedArea100Data3;
            series3.XBindingPath = "XValue";
            series3.YBindingPath = "YValue";
            series3.EnableTooltip = true;
            series3.Label = "Veg Alternatives";
            series3.LegendIcon = SFChartLegendIcon.SeriesType;
            series3.EnableAnimation = true;
            chart.Series.Add(series3);

            SFStackingArea100Series series4 = new SFStackingArea100Series();
            series4.ItemsSource = dataModel.StackedArea100Data4;
            series4.XBindingPath = "XValue";
            series4.YBindingPath = "YValue";
            series4.EnableTooltip = true;
            series4.Label = "Others";
            series4.LegendIcon = SFChartLegendIcon.SeriesType;
            series4.EnableAnimation = true;
            chart.Series.Add(series4);

            chart.Legend.Visible = true;
            chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.IconWidth = 14;
            chart.Legend.IconHeight = 14;
            chart.Legend.DockPosition = SFChartLegendPosition.Bottom;
            this.AddSubview(chart);
		}

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Bounds;
			}
			base.LayoutSubviews ();
		}

	}

}