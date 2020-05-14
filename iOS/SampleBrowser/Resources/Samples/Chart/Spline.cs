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
			chart.Title.Text 				= new NSString ("Climate Graph");
			chart.ColorModel.Palette = SFChartColorPalette.Natural;

			SFCategoryAxis primaryAxis 		= new SFCategoryAxis ();
			chart.PrimaryAxis 				= primaryAxis;
			primaryAxis.LabelPlacement 		= SFChartLabelPlacement.BetweenTicks;
			primaryAxis.Title.Text 			= new NSString ("Month");
			chart.SecondaryAxis 			= new SFNumericalAxis ();
            chart.SecondaryAxis.Title.Text	= new NSString ("Temperature (celsius)");
			ChartViewModel dataModel = new ChartViewModel();

			SFSplineSeries series1 = new SFSplineSeries();
			series1.ItemsSource = dataModel.SplineData1;
			series1.XBindingPath = "XValue";
			series1.YBindingPath = "YValue";
			series1.EnableTooltip = true;
			series1.DataMarker.ShowMarker = true;
			series1.DataMarker.MarkerHeight = 5;
			series1.DataMarker.MarkerWidth = 5;
			series1.Label = "London";
			series1.EnableAnimation = true;
			chart.Series.Add(series1);

			SFSplineSeries series2 = new SFSplineSeries();
			series2.ItemsSource = dataModel.SplineData2;
			series2.XBindingPath = "XValue";
			series2.YBindingPath = "YValue";
			series2.EnableTooltip = true;
			series2.DataMarker.MarkerHeight = 5;
			series2.DataMarker.MarkerWidth = 5;
			series2.DataMarker.ShowMarker = true;
			series2.Label = "France";
			series2.EnableAnimation = true;
			chart.Series.Add(series2);

           
			chart.Legend.Visible 			= true;
			chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.IconWidth = 14;
            chart.Legend.IconHeight = 14;
			chart.Legend.DockPosition 		= SFChartLegendPosition.Bottom;
			chart.AddChartBehavior(new SFChartZoomPanBehavior());
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