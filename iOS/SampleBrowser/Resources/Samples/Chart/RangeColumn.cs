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
	public class RangeColumn : SampleView
	{
		public RangeColumn()
		{
			SFChart chart = new SFChart();
			chart.ColorModel.Palette = SFChartColorPalette.Natural;

			chart.Title.Text = new NSString("Maximum and Minimum Temperature - 2012");
            chart.Title.Font = UIFont.SystemFontOfSize(13);
			SFCategoryAxis primary = new SFCategoryAxis();
			primary.LabelPlacement = SFChartLabelPlacement.BetweenTicks;
			primary.Title.Text = new NSString("Month");
			chart.PrimaryAxis = primary;
			chart.SecondaryAxis = new SFNumericalAxis();
			chart.SecondaryAxis.Title.Text = new NSString("Temperature (Celsius)");
			chart.SecondaryAxis.Minimum = new NSNumber(0);
			chart.SecondaryAxis.Maximum = new NSNumber(20);
			chart.SecondaryAxis.Interval = new NSNumber(2);
			ChartViewModel dataModel = new ChartViewModel();

			SFRangeColumnSeries series1 = new SFRangeColumnSeries();
			series1.ItemsSource = dataModel.RangeColumnData1;
			series1.XBindingPath = "XValue";
			series1.High = "High";
			series1.Low = "Low";
			series1.EnableTooltip = true;
			series1.Label = "India";
			series1.EnableAnimation = true;
			chart.Series.Add(series1);

			SFRangeColumnSeries series2 = new SFRangeColumnSeries();
			series2.ItemsSource = dataModel.RangeColumnData2;
			series2.XBindingPath = "XValue";
			series2.High = "High";
			series2.Low = "Low";
			series2.EnableTooltip = true;
			series2.Label = "Germany";
			series2.EnableAnimation = true;
			chart.Series.Add(series2);

			chart.Legend.Visible = true;
            chart.Legend.IconWidth = 14;
            chart.Legend.IconHeight = 14;
			chart.Legend.ToggleSeriesVisibility = true;
			chart.Legend.DockPosition = SFChartLegendPosition.Bottom;
          
			chart.AddChartBehavior(new SFChartZoomPanBehavior());
			this.AddSubview(chart);

		}

		public override void LayoutSubviews()
		{
			foreach (var view in this.Subviews)
			{
				view.Frame = Bounds;
			}
			base.LayoutSubviews();
		}
	}
}