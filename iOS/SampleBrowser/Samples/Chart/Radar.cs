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
    public class Radar : SampleView
    {
        public Radar ()
        {
            SFChart chart 					= new SFChart ();
			chart.Title.Text				= new NSString ("Average Sales Comparison");
			chart.ColorModel.Palette = SFChartColorPalette.Natural;

            chart.Title.TextAlignment		= UITextAlignment.Center;
            SFCategoryAxis primaryAxis 	    = new SFCategoryAxis ();
            chart.PrimaryAxis 				= primaryAxis;
            SFNumericalAxis secondaryAxis 	= new SFNumericalAxis ();
			secondaryAxis.Interval = new NSNumber(1);
            chart.SecondaryAxis 			= secondaryAxis;
			NSNumberFormatter formatter = new NSNumberFormatter();
            formatter.PositiveSuffix = "M";
            chart.SecondaryAxis.LabelStyle.LabelFormatter = formatter;
			ChartViewModel dataModel		= new ChartViewModel ();
           
			SFRadarSeries series1 = new SFRadarSeries();
			series1.ItemsSource = dataModel.PolarData1;
			series1.XBindingPath = "XValue";
			series1.YBindingPath = "YValue";
			series1.EnableTooltip = true;
			series1.Alpha = 0.5f;
			series1.Label = "Product A";
			series1.EnableAnimation = true;
			chart.Series.Add(series1);

			SFRadarSeries series2 = new SFRadarSeries();
			series2.ItemsSource = dataModel.PolarData2;
			series2.XBindingPath = "XValue";
			series2.YBindingPath = "YValue";
			series2.EnableTooltip = true;
			series2.Alpha = 0.5f;
			series2.Label = "Product B";
			series2.EnableAnimation = true;
			chart.Series.Add(series2);

			SFRadarSeries series3 = new SFRadarSeries();
			series3.ItemsSource = dataModel.PolarData3;
			series3.XBindingPath = "XValue";
			series3.YBindingPath = "YValue";
			series3.EnableTooltip = true;
			series3.Alpha = 0.5f;
			series3.Label = "Product C";
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
