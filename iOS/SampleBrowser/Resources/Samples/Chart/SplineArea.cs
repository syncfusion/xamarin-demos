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
using nint = System.Int32;
using nuint = System.Int32;
#endif

namespace SampleBrowser
{
	public class SplineArea : SampleView
	{
		public SplineArea()
		{
			SFChart chart = new SFChart();
            chart.ColorModel.Palette = SFChartColorPalette.Natural;

			chart.Title.Text = new NSString("Inflation Rate");
			SFCategoryAxis primaryAxis = new SFCategoryAxis();
			primaryAxis.Title.Text = new NSString("Year");
			primaryAxis.Interval = new NSNumber(1);
			chart.PrimaryAxis = primaryAxis;
			SFNumericalAxis secondaryAxis = new SFNumericalAxis();
			secondaryAxis.Title.Text = new NSString("Rate (%)");
			chart.SecondaryAxis = secondaryAxis;
			ChartViewModel dataModel = new ChartViewModel();

			SFSplineAreaSeries series1 = new SFSplineAreaSeries();
			series1.ItemsSource = dataModel.SplineAreaData1;
			series1.XBindingPath = "XValue";
			series1.YBindingPath = "YValue";
			series1.EnableTooltip = true;
			series1.DataMarker.LabelContent = SFChartLabelContent.Percentage;
			series1.Label = "US";
			series1.Alpha = 0.4f;
			series1.EnableAnimation = true;
			chart.Series.Add(series1);

			SFSplineAreaSeries series2 = new SFSplineAreaSeries();
			series2.ItemsSource = dataModel.SplineAreaData2;
			series2.XBindingPath = "XValue";
			series2.YBindingPath = "YValue";
			series2.EnableTooltip = true;
			series2.Alpha = 0.4f;
			series2.DataMarker.LabelContent = SFChartLabelContent.Percentage;
			series2.Label = "France";
			series2.EnableAnimation = true;
			chart.Series.Add(series2);

			SFSplineAreaSeries series3 = new SFSplineAreaSeries();
			series3.ItemsSource = dataModel.SplineAreaData3;
			series3.XBindingPath = "XValue";
			series3.YBindingPath = "YValue";
			series3.EnableTooltip = true;
			series3.Alpha = 0.4f;
			series3.DataMarker.LabelContent = SFChartLabelContent.Percentage;
			series3.Label = "Germany";
			series3.EnableAnimation = true;
			chart.Series.Add(series3);

			chart.Legend.Visible = true;
            chart.Legend.IconWidth = 14;
            chart.Legend.IconHeight = 14;
			chart.Legend.DockPosition = SFChartLegendPosition.Bottom;
			chart.AddChartBehavior(new SFChartZoomPanBehavior());
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