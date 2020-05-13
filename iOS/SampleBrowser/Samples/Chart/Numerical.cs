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
	public class NumericalAxis : SampleView
	{
		public NumericalAxis()
		{
			SFChart chart 					= new SFChart ();
			chart.Title.Text				= (NSString) "England vs West Indies";
			chart.ColorModel.Palette = SFChartColorPalette.Natural;
			chart.PrimaryAxis = new SFCategoryAxis()
			{
				Interval = NSObject.FromObject(1),
				LabelPlacement = SFChartLabelPlacement.BetweenTicks,
				ShowMajorGridLines = false,
				PlotOffset = 2,
				AxisLineOffset = 2,
			};
			chart.PrimaryAxis.Title.Text 	= (NSString) "Death Overs";
			chart.SecondaryAxis             = new SFNumericalAxis();
			chart.SecondaryAxis.Minimum  	= new NSNumber(0);
			chart.SecondaryAxis.Maximum		= new NSNumber(25);
			chart.SecondaryAxis.Interval    = new NSNumber(5);
			chart.SecondaryAxis.AxisLineStyle.LineWidth = 0;
			chart.SecondaryAxis.MajorTickStyle.LineSize = 0;   

			ChartViewModel dataModel 	= new ChartViewModel ();

			SFColumnSeries series = new SFColumnSeries();
			series.ItemsSource = dataModel.NumericData;
			series.XBindingPath = "XValue";
			series.YBindingPath = "YValue";
			series.EnableTooltip = true;            
			series.EnableAnimation = true;
			series.Label = "England";
			series.LegendIcon = SFChartLegendIcon.SeriesType;
			series.DataMarker.ShowLabel = true;
			series.DataMarker.LabelStyle.LabelPosition = SFChartDataMarkerLabelPosition.Inner;
			chart.Series.Add(series);

			SFColumnSeries series1 = new SFColumnSeries();
            series1.ItemsSource = dataModel.NumericData1;
            series1.XBindingPath = "XValue";
            series1.YBindingPath = "YValue";
            series1.EnableTooltip = true;
            series1.EnableAnimation = true;
			series1.Label = "West Indies";
            series1.LegendIcon = SFChartLegendIcon.SeriesType;
            series1.DataMarker.ShowLabel = true;
            series1.DataMarker.LabelStyle.LabelPosition = SFChartDataMarkerLabelPosition.Inner;
            chart.Series.Add(series1);

			chart.Legend.Visible = true;
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