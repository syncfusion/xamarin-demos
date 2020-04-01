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
	public class Bar : SampleView
	{
		public Bar ()
		{
			SFChart chart 						= new SFChart ();
			chart.ColorModel.Palette = SFChartColorPalette.Natural;

            SFCategoryAxis primaryAxis			= new SFCategoryAxis();
			primaryAxis.EdgeLabelsDrawingMode   = SFChartAxisEdgeLabelsDrawingMode.Shift;
			primaryAxis.ShowMajorGridLines      = false;
			primaryAxis.Title.Text              = new NSString("Food");
            chart.PrimaryAxis					= primaryAxis;
			chart.SecondaryAxis 				= new SFNumericalAxis (){
				EdgeLabelsDrawingMode 			= SFChartAxisEdgeLabelsDrawingMode.Shift ,
				ShowMajorGridLines              = false,
				Visible                         = false
			};            
			chart.Delegate                      = new DataMarkerFormatter();
			ChartViewModel dataModel			= new ChartViewModel ();
			chart.Title.Text 					= new NSString ("UK Trade in Food Groups - 2015");

			SFBarSeries series1 = new SFBarSeries();
			series1.ItemsSource = dataModel.BarData1;
			series1.XBindingPath = "XValue";
			series1.YBindingPath = "YValue";
			series1.EnableTooltip = true;
			series1.DataMarker.ShowLabel = true;
			series1.DataMarker.LabelStyle.Font = UIFont.BoldSystemFontOfSize(10);
			series1.DataMarker.LabelStyle.LabelPosition = SFChartDataMarkerLabelPosition.Inner;
			series1.Label = "Imports";
			series1.EnableAnimation = true;
			chart.Series.Add(series1);

			SFBarSeries series2 = new SFBarSeries();
			series2.ItemsSource = dataModel.BarData2;
			series2.XBindingPath = "XValue";
			series2.YBindingPath = "YValue";
			series2.EnableTooltip = true;
			series2.DataMarker.ShowLabel = true;
			series2.DataMarker.LabelStyle.Font = UIFont.BoldSystemFontOfSize(10);
			series2.Label = "Exports";
			series2.EnableAnimation = true;
			series2.DataMarker.LabelStyle.LabelPosition = SFChartDataMarkerLabelPosition.Inner;
			chart.Series.Add(series2);

			chart.Legend.Visible				= true;
			chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.IconWidth = 14;
            chart.Legend.IconHeight = 14;
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

	class DataMarkerFormatter : SFChartDelegate
    {
        public override NSString GetFormattedDataMarkerLabel(SFChart chart, NSString label, nint index)
        {
            String formattedLabel = label + "B";
            label = new NSString(formattedLabel);
            return label;
        }
    }

}