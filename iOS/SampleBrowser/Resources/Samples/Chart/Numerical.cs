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
			chart.Title.Text				= (NSString) "Average Temperature Analysis";
			chart.PrimaryAxis				= new SFNumericalAxis (){ Interval = NSObject.FromObject(1)};
			chart.PrimaryAxis.Title.Text 	= (NSString) "Year";
			chart.SecondaryAxis 			= new SFNumericalAxis ();
            chart.SecondaryAxis.Title.Text  = (NSString) "Temerature (celsius)";
			chart.SecondaryAxis.Minimum  	= new NSNumber(0);
			chart.SecondaryAxis.Maximum		= new NSNumber(100);

			ChartViewModel dataModel 	= new ChartViewModel ();

			SFColumnSeries series = new SFColumnSeries();
			series.ItemsSource = dataModel.NumericData;
			series.XBindingPath = "XValue";
			series.YBindingPath = "YValue";
			series.EnableTooltip = true;
            series.ColorModel.Palette = SFChartColorPalette.Natural;
			series.EnableAnimation = true;
			chart.Series.Add(series);

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