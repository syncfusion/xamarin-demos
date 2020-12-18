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
#endif

namespace SampleBrowser
{
	public class Polar : SampleView
	{
		public Polar ()
		{
			SFChart chart 					= new SFChart ();
			chart.Title.Text				= new NSString ("Plants in Wonderland");
			chart.ColorModel.Palette = SFChartColorPalette.Natural;

			chart.Title.TextAlignment		= UITextAlignment.Center;
			SFCategoryAxis primaryAxis 	    = new SFCategoryAxis ();
			chart.PrimaryAxis 				= primaryAxis;
			SFNumericalAxis secondaryAxis 	= new SFNumericalAxis ();
			chart.SecondaryAxis 			= secondaryAxis;
			ChartViewModel dataModel		= new ChartViewModel ();

			SFPolarSeries series1 = new SFPolarSeries();
			series1.ItemsSource = dataModel.PolarData1;
			series1.XBindingPath = "XValue";
			series1.YBindingPath = "YValue";
			series1.EnableTooltip = true;
			series1.Alpha = 0.5f;
			series1.Label = "Weed";
			series1.EnableAnimation = true;
			chart.Series.Add(series1);

			SFPolarSeries series2 = new SFPolarSeries();
			series2.ItemsSource = dataModel.PolarData2;
			series2.XBindingPath = "XValue";
			series2.YBindingPath = "YValue";
			series2.EnableTooltip = true;
			series2.Alpha = 0.5f;
			series2.Label = "Flower";
			series2.EnableAnimation = true;
			chart.Series.Add(series2);

			SFPolarSeries series3 = new SFPolarSeries();
			series3.ItemsSource = dataModel.PolarData3;
			series3.XBindingPath = "XValue";
			series3.YBindingPath = "YValue";
			series3.EnableTooltip = true;
			series3.Alpha = 0.5f;
			series3.Label = "Tree";
			series3.EnableAnimation = true;
			chart.Series.Add(series3);

			chart.Legend.Visible			= true;
            chart.Legend.IconWidth = 14;
            chart.Legend.IconHeight = 14;
            chart.Legend.ToggleSeriesVisibility = true;
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