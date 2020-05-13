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
	public class Bubble : SampleView
	{
		public Bubble ()
		{
			SFChart chart 						= new SFChart ();
			chart.Title.Text					= new NSString ("World Countries Details");
			SFNumericalAxis primaryAxis			= new SFNumericalAxis ();
			chart.PrimaryAxis 					= primaryAxis;
			primaryAxis.Minimum 				= new NSNumber (50);
			primaryAxis.Maximum					= new NSNumber (110);
			primaryAxis.Interval 				= new NSNumber (10);
            primaryAxis.ShowMinorGridLines      = false;
            primaryAxis.ShowMajorGridLines      = false;
			chart.PrimaryAxis.Title.Text		= new NSString ("Literacy Rate");

			chart.SecondaryAxis 				= new SFNumericalAxis ();
			chart.SecondaryAxis.Title.Text 		= new NSString ("GDP Growth Rate");
			chart.SecondaryAxis.Minimum 		= new NSNumber (-2);
			chart.SecondaryAxis.Maximum 		= new NSNumber (16);
            chart.SecondaryAxis.ShowMinorGridLines = false;
            chart.SecondaryAxis.ShowMajorGridLines = false;
			ChartViewModel dataModel			= new ChartViewModel ();

			SFBubbleSeries series	= new SFBubbleSeries();
			series.EnableTooltip	= true;
			series.Alpha			= 0.6f;
			series.ItemsSource		= dataModel.BubbleData;
			series.XBindingPath		= "XValue";
			series.YBindingPath		= "YValue";
			series.Size				= "Size";
			series.MaximumRadius	= 20;
			series.MinimumRadius 	= 5;
            series.ColorModel.Palette = SFChartColorPalette.Natural;
			series.EnableAnimation	= true;
			chart.Series.Add(series);

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