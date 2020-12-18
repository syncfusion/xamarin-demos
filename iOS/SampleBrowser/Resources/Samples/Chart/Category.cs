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

using System.Drawing;

namespace SampleBrowser
{
	public class CategoryAxis : SampleView
	{
		public CategoryAxis ()
		{
			SFChart chart 						= new SFChart ();
			chart.Title.Text					= new NSString("Internet Users - 2016");
			SFCategoryAxis categoryAxis 		= new SFCategoryAxis ();
			categoryAxis.LabelPlacement 		= SFChartLabelPlacement.BetweenTicks;
            categoryAxis.ShowMajorGridLines     = false;
			chart.PrimaryAxis					= categoryAxis;
			chart.PrimaryAxis.Interval			= new NSNumber(1);
			chart.PrimaryAxis.Title.Text    	= new NSString ("Country");

			chart.SecondaryAxis 				= new SFNumericalAxis ();
            chart.SecondaryAxis.Title.Text  	= new NSString ("Usage (%)");
			chart.SecondaryAxis.Minimum 		= new NSNumber(0);
			chart.SecondaryAxis.Maximum 		= new NSNumber(100);
			chart.SecondaryAxis.Interval 		= new NSNumber(10);
            chart.SecondaryAxis.Visible         = false;
            chart.SecondaryAxis.ShowMajorGridLines = false;
            chart.SecondaryAxis.ShowMinorGridLines = false;

			ChartViewModel dataModel 	= new ChartViewModel ();

			SFColumnSeries series = new SFColumnSeries();
			series.ItemsSource	= dataModel.CategoryData;
			series.XBindingPath = "XValue";
			series.YBindingPath = "YValue";
			series.EnableTooltip = true;
			series.EnableAnimation = true;
			series.ColorModel.Palette = SFChartColorPalette.Natural;
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