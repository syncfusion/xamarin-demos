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
	public class Area : SampleView
	{
		public Area ()
		{
			SFChart chart 					        = new SFChart ();
			chart.ColorModel.Palette                = SFChartColorPalette.Natural;
			chart.Title.Text				        = new NSString ("Average Sales Comparison");
			chart.Title.TextAlignment		        = UITextAlignment.Center;

			SFNumericalAxis primaryAxis             = new SFNumericalAxis();
			primaryAxis.EdgeLabelsDrawingMode       = SFChartAxisEdgeLabelsDrawingMode.Shift;
			primaryAxis.Minimum                     = new NSNumber(2000);
			primaryAxis.Maximum                     = new NSNumber(2005);
			primaryAxis.Interval                    = new NSNumber(1);
			primaryAxis.ShowMajorGridLines          = false;
			chart.PrimaryAxis 				        = primaryAxis;	

			SFNumericalAxis secondaryAxis 	        = new SFNumericalAxis ();
			chart.SecondaryAxis 			        = secondaryAxis;
			secondaryAxis.Minimum 			        = new NSNumber (2);
			secondaryAxis.Maximum 			        = new NSNumber (5);
			secondaryAxis.Interval			        = new NSNumber (1);
			secondaryAxis.Title.Text                = new NSString("Revenue in Millions");
			secondaryAxis.AxisLineStyle.LineWidth   = 0;
			secondaryAxis.MajorTickStyle.LineSize   = 0;
			chart.Delegate                          = new AxisLabelFormatter();
			ChartViewModel dataModel 		        = new ChartViewModel();

			SFAreaSeries series1	= new SFAreaSeries();
			series1.ItemsSource		= dataModel.AreaData1;
			series1.XBindingPath	= "XValue";
			series1.YBindingPath	= "YValue";
			series1.EnableTooltip	= true;
			series1.Alpha 			= 0.5f;
			series1.Label			= "Product A"; 
			series1.EnableAnimation = true;
			series1.LegendIcon      = SFChartLegendIcon.SeriesType;
			chart.Series.Add(series1);

			SFAreaSeries series2    = new SFAreaSeries();
			series2.ItemsSource     = dataModel.AreaData2;
			series2.XBindingPath    = "XValue";
			series2.YBindingPath    = "YValue";
			series2.EnableTooltip   = true;
			series2.Alpha           = 0.5f;
			series2.Label           = "Product B";
			series2.EnableAnimation = true;
			series2.LegendIcon      = SFChartLegendIcon.SeriesType;
			chart.Series.Add(series2);

			chart.Legend.Visible			    = true;
			chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.IconWidth              = 14;
            chart.Legend.IconHeight             = 14;
			chart.Legend.DockPosition		    = SFChartLegendPosition.Bottom;
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

	class AxisLabelFormatter : SFChartDelegate
	{
		public override NSString GetFormattedAxisLabel(SFChart chart, NSString label, NSObject value, SFAxis axis)
        {
            if (axis == chart.SecondaryAxis)
            {
                String formattedLabel = label + "M";
                label = new NSString(formattedLabel);
                return label;
            }
            return label;
        }
	}
}

