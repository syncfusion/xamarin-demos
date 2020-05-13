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
	public class Spline : SampleView
	{
		public Spline ()
		{
			SFChart chart 					= new SFChart ();
			chart.Title.Text 				= new NSString ("NC Weather Report");
			chart.ColorModel.Palette = SFChartColorPalette.Natural;

			SFCategoryAxis primaryAxis 		= new SFCategoryAxis ();
			chart.PrimaryAxis 				= primaryAxis;
			primaryAxis.LabelPlacement 		= SFChartLabelPlacement.BetweenTicks;
			primaryAxis.ShowMajorGridLines  = false;
			chart.SecondaryAxis 			= new SFNumericalAxis ();
			chart.SecondaryAxis.Minimum = new NSNumber(0);
			chart.SecondaryAxis.Maximum = new NSNumber(40);
			chart.SecondaryAxis.Interval = new NSNumber(10);
			chart.SecondaryAxis.AxisLineStyle.LineWidth = 0;
			chart.SecondaryAxis.MajorTickStyle.LineSize = 0;
			NSNumberFormatter formatter = new NSNumberFormatter();
            formatter.PositiveSuffix = "°C";
            chart.SecondaryAxis.LabelStyle.LabelFormatter = formatter;
			ChartViewModel dataModel = new ChartViewModel();

			SFSplineSeries series1 = new SFSplineSeries();
			series1.ItemsSource = dataModel.SplineData1;
			series1.XBindingPath = "XValue";
			series1.YBindingPath = "YValue";
			series1.EnableTooltip = true;
			series1.DataMarker.ShowMarker = true;
			series1.DataMarker.MarkerHeight = 10;
			series1.DataMarker.MarkerWidth = 10;
			series1.DataMarker.MarkerBorderColor = UIColor.FromRGBA(0.0f / 255.0f, 189.0f / 255.0f, 174.0f / 255.0f, 1.0f);
			series1.DataMarker.MarkerBorderWidth = 2;
			series1.DataMarker.MarkerColor = UIColor.White;
			series1.Label = "Max Temp";
			series1.EnableAnimation = true;
			series1.LegendIcon = SFChartLegendIcon.SeriesType;
			chart.Series.Add(series1);

			SFSplineSeries series2 = new SFSplineSeries();
			series2.ItemsSource = dataModel.SplineData2;
			series2.XBindingPath = "XValue";
			series2.YBindingPath = "YValue";
			series2.EnableTooltip = true;
			series2.DataMarker.MarkerHeight = 10;
			series2.DataMarker.MarkerWidth = 10;
			series2.DataMarker.ShowMarker = true;
			series2.DataMarker.MarkerBorderColor = UIColor.FromRGBA(64.0f / 255.0f, 64.0f / 255.0f, 65.0f / 255.0f, 1.0f);
            series2.DataMarker.MarkerBorderWidth = 2;
            series2.DataMarker.MarkerColor = UIColor.White;
			series2.Label = "Avg Temp";
			series2.EnableAnimation = true;
			series2.LegendIcon = SFChartLegendIcon.SeriesType;
			chart.Series.Add(series2);

			SFSplineSeries series3 = new SFSplineSeries();
            series3.ItemsSource = dataModel.SplineData3;
            series3.XBindingPath = "XValue";
            series3.YBindingPath = "YValue";
            series3.EnableTooltip = true;
            series3.DataMarker.MarkerHeight = 10;
            series3.DataMarker.MarkerWidth = 10;
            series3.DataMarker.ShowMarker = true;
			series3.DataMarker.MarkerBorderColor = UIColor.FromRGBA(53.0f / 255.0f, 124.0f / 255.0f, 210.0f / 255.0f, 1.0f);
            series3.DataMarker.MarkerBorderWidth = 2;
            series3.DataMarker.MarkerColor = UIColor.White;
            series3.Label = "Min Temp";
            series3.EnableAnimation = true;
			series3.LegendIcon = SFChartLegendIcon.SeriesType;
            chart.Series.Add(series3);
           
			chart.Legend.Visible 			= true;
			chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.IconWidth = 14;
            chart.Legend.IconHeight = 14;
			chart.Legend.DockPosition 		= SFChartLegendPosition.Bottom;
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