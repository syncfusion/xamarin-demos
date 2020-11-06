#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Drawing;
using CoreGraphics;
using Foundation;
using Syncfusion.Drawing;
using Syncfusion.SfChart.iOS;
using UIKit;

namespace SampleBrowser
{
	public class GradientChart : SampleView
	{
		public GradientChart()
		{
			SFChart chart = new SFChart();
			chart.Title.Text = (NSString)"Oxygen Level";

			chart.ColorModel.Palette = SFChartColorPalette.Custom;
			ChartGradientColor gradientColor = new ChartGradientColor() { StartPoint = new CGPoint(0.5f, 1), EndPoint = new CGPoint(0.5f, 0) };
			ChartGradientStop stopColor1 = new ChartGradientStop() { Color = UIColor.White, Offset = 0 };
            ChartGradientStop stopColor2 = new ChartGradientStop() { Color = UIColor.FromRGBA(0, 128f / 255f, 223f / 255f, 1.0f), Offset = 1 };
			gradientColor.GradientStops.Add(stopColor1);
			gradientColor.GradientStops.Add(stopColor2);

			ChartGradientColorCollection gradientColorsCollection = new ChartGradientColorCollection()
			{
				gradientColor
			};

			chart.ColorModel.CustomGradientColors = gradientColorsCollection;

			chart.PrimaryAxis = new SFDateTimeAxis() { PlotOffset = 6, EdgeLabelsDrawingMode = SFChartAxisEdgeLabelsDrawingMode.Shift, ShowMajorGridLines = false, ShowMinorGridLines = false };

			NSDateFormatter formatter = new NSDateFormatter();
			formatter.DateFormat = new NSString("MMM dd");
			chart.PrimaryAxis.LabelStyle.LabelFormatter = formatter;

			chart.SecondaryAxis = new SFNumericalAxis
			{
				Maximum = new NSNumber(50),
				Interval = new NSNumber(5)
			};
			NSNumberFormatter secondaryAxisFormatter = new NSNumberFormatter();
			secondaryAxisFormatter.PositiveSuffix = "%";
			chart.SecondaryAxis.LabelStyle.LabelFormatter = secondaryAxisFormatter;

			ChartViewModel dataModel = new ChartViewModel();

			SFSplineAreaSeries series = new SFSplineAreaSeries();
			series.ItemsSource = dataModel.GradientData;
			series.XBindingPath = "XValue";
			series.YBindingPath = "YValue";
			series.BorderColor = UIColor.FromRGBA(0, 128f / 255f, 223f / 255f, 1.0f);
			series.BorderWidth = 2;
			series.DataMarker.ShowLabel = true;
			series.DataMarker.MarkerWidth = 8;
			series.DataMarker.MarkerHeight = 8;
			series.DataMarker.MarkerColor = UIColor.White;
			series.DataMarker.MarkerBorderColor = UIColor.FromRGBA(0, 128f / 255f, 223f / 255f, 1.0f);
			series.DataMarker.MarkerBorderWidth = 2;
			series.DataMarker.ShowMarker = true;
			series.DataMarker.LabelStyle.OffsetY = -10;
			series.DataMarker.LabelStyle.BackgroundColor = UIColor.FromRGBA(0, 128f / 255f, 223f / 255f, 1.0f);
			NSNumberFormatter dataMarkerFormatter = new NSNumberFormatter();
			dataMarkerFormatter.PositiveSuffix = "%";
			series.DataMarker.LabelStyle.LabelFormatter = dataMarkerFormatter;
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
}
