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
	public class MultipleAxes : SampleView
	{
		public MultipleAxes ()
		{
			SFChart chart 				= new SFChart ();
			chart.Title.Text = new NSString("Weather Condition JPN vs DEU");
            chart.Legend.Visible = true;
            chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.DockPosition = SFChartLegendPosition.Bottom;
            chart.Legend.IconWidth = 14;
            chart.Legend.IconHeight = 14;

			chart.ColorModel.Palette = SFChartColorPalette.Natural;

			SFCategoryAxis primaryAxis 	= new SFCategoryAxis ();
			primaryAxis.LabelPlacement	= SFChartLabelPlacement.BetweenTicks;
			primaryAxis.ShowMajorGridLines = false;
			primaryAxis.Interval = new NSNumber(1);
			chart.PrimaryAxis 			= primaryAxis;
			chart.SecondaryAxis = new SFNumericalAxis()
			{
				ShowMajorGridLines = false,
				Maximum = new NSNumber(100),
				Minimum = new NSNumber(0),
				Interval = new NSNumber(20),
			};
			chart.SecondaryAxis.Title.Text = new NSString ("Revenue (in millions)");
			NSNumberFormatter formatter	= new NSNumberFormatter();
			formatter.PositiveSuffix	= "°F";
			chart.SecondaryAxis.LabelStyle.LabelFormatter = formatter;
			
			ChartViewModel dataModel	= new ChartViewModel ();

			SFColumnSeries series = new SFColumnSeries();
			series.ItemsSource = dataModel.MultipleAxisData;
			series.XBindingPath = "XValue";
			series.YBindingPath = "YValue";
			series.EnableTooltip = true;
			series.Label = new NSString("Germany");
			series.EnableAnimation = true;
			chart.Series.Add(series);

			SFLineSeries series1 = new SFLineSeries();
			series1.ItemsSource = dataModel.MultipleAxisData1;
			series1.XBindingPath = "XValue";
			series1.YBindingPath = "YValue";
			series1.EnableTooltip = true;
			series1.Label = new NSString("Japan");
			series1.YAxis = new SFNumericalAxis()
			{
				OpposedPosition = true,
				Minimum = new NSNumber(24),
				Maximum = new NSNumber(36),
				Interval = new NSNumber(2),
				ShowMajorGridLines = false
			};
			NSNumberFormatter formatter1 = new NSNumberFormatter();
			formatter1.PositiveSuffix = "°C";
			series1.YAxis.LabelStyle.LabelFormatter = formatter1;
			series1.EnableAnimation = true;
			series1.DataMarker.ShowMarker = true;
            series1.DataMarker.MarkerColor = UIColor.White;
			series1.DataMarker.MarkerBorderColor = UIColor.FromRGBA(248.0f / 171.0f, 189.0f / 255.0f, 29.0f / 255.0f, 1.0f);
            series1.DataMarker.MarkerBorderWidth = 2;
            series1.DataMarker.MarkerWidth = 10f;
            series1.DataMarker.MarkerHeight = 10f;
			chart.Series.Add(series1);
           
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