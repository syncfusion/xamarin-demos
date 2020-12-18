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
	public class OHLC : SampleView
	{
		public OHLC ()
		{
			SFChart chart 							= new SFChart ();
			chart.Title.Text						= new NSString ("Financial Analysis");
			chart.PrimaryAxis 						= new SFDateTimeAxis ();
			chart.PrimaryAxis.Title.Text			= new NSString ("Date");
			chart.PrimaryAxis.LabelRotationAngle 	= -45;
			chart.PrimaryAxis.EdgeLabelsDrawingMode = SFChartAxisEdgeLabelsDrawingMode.Hide;
			chart.SecondaryAxis 					= new SFNumericalAxis ();
			chart.SecondaryAxis.Title.Text			= new NSString ("Price in Dollar");
			chart.SecondaryAxis.Minimum 			= new NSNumber (0);
			chart.SecondaryAxis.Maximum				= new NSNumber (250);
			chart.SecondaryAxis.Interval 			= new NSNumber (50);

			chart.Delegate 			        = new ChartDollarDelegate ();
			ChartViewModel dataModel		= new ChartViewModel ();

			SFOHLCSeries series = new SFOHLCSeries();
			series.ItemsSource = dataModel.FinancialData;
			series.XBindingPath = "XValue";
			series.High = "High";
			series.Low = "Low";
			series.Open = "Open";
			series.Close = "Close";
			series.EnableTooltip = true;
			series.EnableAnimation = true;
            series.ColorModel.Palette = SFChartColorPalette.Natural;
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


