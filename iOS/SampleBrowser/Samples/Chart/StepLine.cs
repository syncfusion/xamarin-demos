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
	public class StepLine : SampleView
	{
		public StepLine ()
		{
			SFChart chart 							= new SFChart ();
			chart.Title.Text 						= new NSString ("Unemployment Rates 1975-2010");
			chart.ColorModel.Palette = SFChartColorPalette.Natural;

			//Primary Axis
			SFNumericalAxis primaryAxis 			= new SFNumericalAxis ();
			primaryAxis.ShowMajorGridLines          = false;
            chart.PrimaryAxis 						= primaryAxis;
			primaryAxis.Interval 					= new NSNumber (5);
			primaryAxis.Minimum                     = new NSNumber(1975);
			primaryAxis.Maximum                     = new NSNumber(2010);
			primaryAxis.PlotOffset                  = 10;
			primaryAxis.AxisLineOffset              = 10;
		

			//Secondary Axis
			SFNumericalAxis secondaryAxis 			= new SFNumericalAxis ();
			chart.SecondaryAxis 					= secondaryAxis;
			secondaryAxis.AxisLineStyle.LineWidth   = 0;
			secondaryAxis.MajorTickStyle.LineSize   = 0;
			chart.SecondaryAxis.Minimum 			= new NSNumber (0);
			chart.SecondaryAxis.Maximum				= new NSNumber (20);
			chart.SecondaryAxis.Interval 			= new NSNumber (5);
			NSNumberFormatter formatter             = new NSNumberFormatter();
            formatter.PositiveSuffix                = "%";
            chart.SecondaryAxis.LabelStyle.LabelFormatter = formatter;
			ChartViewModel dataModel				= new ChartViewModel ();

			SFStepLineSeries series1 = new SFStepLineSeries();
			series1.ItemsSource = dataModel.StepLineData1;
			series1.XBindingPath = "XValue";
			series1.YBindingPath = "YValue";
			series1.EnableTooltip = true;
			series1.DataMarker.ShowMarker = true;
			series1.DataMarker.MarkerColor = UIColor.White;
            series1.DataMarker.MarkerBorderColor = UIColor.FromRGBA(0.0f / 255.0f, 189.0f / 255.0f, 174.0f / 255.0f, 1.0f);
            series1.DataMarker.MarkerBorderWidth = 2;
            series1.DataMarker.MarkerWidth = 10f;
            series1.DataMarker.MarkerHeight = 10f;
			series1.Label = "China";
			series1.LegendIcon = SFChartLegendIcon.SeriesType;
			series1.EnableAnimation = true;
			chart.Series.Add(series1);

			SFStepLineSeries series2 = new SFStepLineSeries();
			series2.ItemsSource = dataModel.StepLineData2;
			series2.XBindingPath = "XValue";
			series2.YBindingPath = "YValue";
			series2.EnableTooltip = true;
			series2.DataMarker.ShowMarker = true;
			series2.DataMarker.MarkerColor = UIColor.White;
            series2.DataMarker.MarkerBorderColor = UIColor.FromRGBA(64.0f / 255.0f, 64.0f / 255.0f, 65.0f / 255.0f, 1.0f);
            series2.DataMarker.MarkerBorderWidth = 2;
            series2.DataMarker.MarkerWidth = 10f;
            series2.DataMarker.MarkerHeight = 10f;
			series2.Label = "Australia";
			series2.LegendIcon = SFChartLegendIcon.SeriesType;
            series2.EnableAnimation = true;
			chart.Series.Add(series2);
            
			chart.Legend.Visible 					= true;
			chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.IconWidth = 14;
            chart.Legend.IconHeight = 14;
			chart.Legend.DockPosition				= SFChartLegendPosition.Bottom;
          
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