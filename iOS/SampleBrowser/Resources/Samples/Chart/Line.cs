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
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
#endif
namespace SampleBrowser
{
	public class Line : SampleView
	{
		public Line ()
		{
			SFChart chart 						= new SFChart ();
			chart.Title.Text 					= new NSString ("Efficiency of oil fired power production");
			chart.ColorModel.Palette = SFChartColorPalette.Natural;

			SFCategoryAxis primaryAxis 			= new SFCategoryAxis ();
			primaryAxis.Title.Text 				= new NSString ("Year");
			primaryAxis.LabelPlacement 			= SFChartLabelPlacement.BetweenTicks;
			chart.PrimaryAxis 					= primaryAxis;
			SFNumericalAxis secondaryAxis 		= new SFNumericalAxis ();
			secondaryAxis.Title.Text	 		= new NSString ("Efficiency (%)");
			secondaryAxis.Minimum 				= new NSNumber (25);
			secondaryAxis.Maximum 				= new NSNumber (50);
			chart.SecondaryAxis 				= secondaryAxis;
			ChartViewModel dataModel			= new ChartViewModel ();

			SFLineSeries series1 = new SFLineSeries();
			series1.ItemsSource = dataModel.LineData1;
			series1.XBindingPath = "XValue";
			series1.YBindingPath = "YValue";
			series1.EnableTooltip = true;
			series1.Label = "India";
			series1.EnableAnimation = true;
			series1.DataMarker.ShowMarker = true;
			chart.Series.Add(series1);

			SFLineSeries series2 = new SFLineSeries();
			series2.ItemsSource = dataModel.LineData2;
			series2.XBindingPath = "XValue";
			series2.YBindingPath = "YValue";
			series2.EnableTooltip = true;
			series2.Label = "France";
			series2.EnableAnimation = true;
			series2.DataMarker.ShowMarker = true;
            chart.Series.Add(series2);
		
			chart.Legend.Visible = true;
			chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.IconWidth = 14;
            chart.Legend.IconHeight = 14;
			chart.Legend.DockPosition = SFChartLegendPosition.Bottom;
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