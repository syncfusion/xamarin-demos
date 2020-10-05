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
using nint = System.Int32;using nuint = System.Int32;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
#endif
namespace SampleBrowser
{
	public class Candle : SampleView
	{
		public Candle ()
		{
			SFChart chart 					= new SFChart ();
			chart.Title.Text				= new NSString ("Foreign Exchange Rate Analysis");
			SFDateTimeAxis primary 			= new SFDateTimeAxis ();
			primary.Title.Text 				= new NSString ("Date");
			primary.LabelRotationAngle 		= -45;
			chart.PrimaryAxis 				= primary;
			chart.SecondaryAxis 			= new SFNumericalAxis ();
			chart.SecondaryAxis.Title.Text	= new NSString ("Price in Dollar");
			chart.SecondaryAxis.Minimum 	= new NSNumber (0);
			chart.SecondaryAxis.Maximum		= new NSNumber (250);
			chart.SecondaryAxis.Interval 	= new NSNumber (50);
			chart.Delegate 			        = new ChartDollarDelegate ();
			ChartViewModel dataModel		= new ChartViewModel ();

			SFCandleSeries series = new SFCandleSeries();
			series.ItemsSource = dataModel.FinancialData;
			series.XBindingPath = "XValue";
			series.High = "High";
			series.Low = "Low";
			series.Open = "Open";
			series.Close = "Close";
			series.EnableTooltip = true;
			series.BorderWidth = 1;
			series.EnableAnimation = true;
			chart.Series.Add(series);
			chart.AddChartBehavior(new SFChartZoomPanBehavior());
            series.ColorModel.Palette = SFChartColorPalette.Natural;
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

