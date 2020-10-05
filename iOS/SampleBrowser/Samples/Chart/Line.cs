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
			chart.Title.Text 					= new NSString ("Inflation - Consumer Price");
			chart.ColorModel.Palette = SFChartColorPalette.Natural;

			SFCategoryAxis primaryAxis 			= new SFCategoryAxis ();
			primaryAxis.ShowMajorGridLines      = false;
			primaryAxis.PlotOffset              = 10;
			primaryAxis.AxisLineOffset          = 10;
			chart.PrimaryAxis 					= primaryAxis;
			SFNumericalAxis secondaryAxis 		= new SFNumericalAxis ();
			secondaryAxis.Minimum 				= new NSNumber (0);
			secondaryAxis.Maximum 				= new NSNumber (100);
			secondaryAxis.Interval              = new NSNumber(20);
			secondaryAxis.MajorTickStyle.LineSize = 0;
			secondaryAxis.AxisLineStyle.LineWidth = 0;
			chart.SecondaryAxis 				= secondaryAxis;
			ChartViewModel dataModel			= new ChartViewModel ();

			SFLineSeries series1 = new SFLineSeries();
			series1.ItemsSource = dataModel.LineData1;
			series1.XBindingPath = "XValue";
			series1.YBindingPath = "YValue";
			series1.EnableTooltip = true;
			series1.Label = "Germany";
			series1.EnableAnimation = true;
			series1.DataMarker.ShowMarker = true;
			series1.DataMarker.MarkerColor = UIColor.White;
			series1.DataMarker.MarkerBorderColor = UIColor.FromRGBA(0.0f / 255.0f, 189.0f / 255.0f, 174.0f / 255.0f, 1.0f);
			series1.DataMarker.MarkerBorderWidth = 2;
            series1.DataMarker.MarkerWidth = 10f;
            series1.DataMarker.MarkerHeight = 10f;
			chart.Series.Add(series1);

			SFLineSeries series2 = new SFLineSeries();
			series2.ItemsSource = dataModel.LineData2;
			series2.XBindingPath = "XValue";
			series2.YBindingPath = "YValue";
			series2.EnableTooltip = true;
			series2.Label = "England";
			series2.EnableAnimation = true;
			series2.DataMarker.ShowMarker = true;
			series2.DataMarker.ShowMarker = true;
            series2.DataMarker.MarkerColor = UIColor.White;
			series2.DataMarker.MarkerBorderColor = UIColor.FromRGBA(64.0f / 255.0f, 64.0f / 255.0f, 65.0f / 255.0f, 1.0f);
			series2.DataMarker.MarkerBorderWidth = 2;
            series2.DataMarker.MarkerWidth = 10f;
            series2.DataMarker.MarkerHeight = 10f;
            chart.Series.Add(series2);
		
			chart.Legend.Visible = true;
			chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.IconWidth = 14;
            chart.Legend.IconHeight = 14;
			chart.Legend.DockPosition = SFChartLegendPosition.Bottom;
			chart.Delegate = new AxisLabelFormatter();
           
			this.AddSubview(chart);
		}

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Bounds;
			}
			base.LayoutSubviews ();
		}

		class AxisLabelFormatter : SFChartDelegate
        {
            public override NSString GetFormattedAxisLabel(SFChart chart, NSString label, NSObject value, SFAxis axis)
            {
                if (axis == chart.SecondaryAxis)
                {
                    String formattedLabel = label + "%";
                    label = new NSString(formattedLabel);
                    return label;
                }
                return label;
            }
        }
	}
}