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
			chart.Title.Text					= new NSString("Sales Comparison");
			SFCategoryAxis categoryAxis 		= new SFCategoryAxis ();
			categoryAxis.LabelPlacement 		= SFChartLabelPlacement.BetweenTicks;
			chart.PrimaryAxis					= categoryAxis;
			chart.PrimaryAxis.Interval			= new NSNumber(1);
			chart.PrimaryAxis.Title.Text    	= new NSString ("Sales Across Products");

			chart.SecondaryAxis 				= new SFNumericalAxis ();
			chart.SecondaryAxis.Title.Text  	= new NSString ("Sales Amount in Millions (USD)");
			chart.SecondaryAxis.Minimum 		= new NSNumber(0);
			chart.SecondaryAxis.Maximum 		= new NSNumber(100);
			chart.SecondaryAxis.Interval 		= new NSNumber(10);

			NSNumberFormatter numberFormatter 		= new NSNumberFormatter ();
			numberFormatter.NumberStyle 			= NSNumberFormatterStyle.Currency;
			numberFormatter.MinimumFractionDigits	= 0;

			chart.SecondaryAxis.LabelStyle.LabelFormatter  = numberFormatter;

			ChartViewModel dataModel 	= new ChartViewModel ();

			SFLineSeries series = new SFLineSeries();
			series.ItemsSource	= dataModel.CategoryData;
			series.XBindingPath = "XValue";
			series.YBindingPath = "YValue";
			series.EnableTooltip = true;
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