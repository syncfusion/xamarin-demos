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
	public class LogarithmicAxis : SampleView
	{
		public LogarithmicAxis()
		{
			SFChart chart 					 = new SFChart ();
			chart.PrimaryAxis				 = new SFCategoryAxis (){ Interval = NSObject.FromObject(1)};
			chart.PrimaryAxis.Title.Text     = new NSString ("Years");
			SFLogarithmicAxis yAxis 		 = new SFLogarithmicAxis ();
			yAxis.ShowMinorGridLines 		 = true;
			yAxis.MinorTicksPerInterval 	 = 5;
			yAxis.Title.Text  				 = new NSString ("Profit");
			chart.SecondaryAxis 			 = yAxis;
			chart.Title.Text 			     = new NSString ("Business Growth");
			chart.Title.EdgeInsets 			 = new UIEdgeInsets (10, 5, 10, 5);
			chart.EdgeInsets                 = new UIEdgeInsets(-3, 5, 5, 10);
			chart.Delegate 			         = new ChartDollarDelegate ();
			ChartViewModel dataModel 		 = new ChartViewModel ();

			SFLineSeries series = new SFLineSeries();
			series.ItemsSource = dataModel.LogarithmicData;
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

public class ChartDollarDelegate : SFChartDelegate
{
	public override NSString GetFormattedAxisLabel (SFChart chart, NSString label, NSObject value, SFAxis axis)
	{
		if (axis == chart.SecondaryAxis) {
			String formattedLabel = "$" + label.ToString ();
			label = new NSString (formattedLabel);
			return label;
		}
		return label;
	}
}