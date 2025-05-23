#region Copyright Syncfusion Inc. 2001 - 2015
// Copyright Syncfusion Inc. 2001 - 2015. All rights reserved.
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
namespace SampleBrowser
{
	public class StackedColumn : SampleView
	{
		public StackedColumn ()
		{
			SFChart chart 						= new SFChart ();
			chart.Title.Text 					= new NSString ("Mobile Game Market by Country");
			chart.ColorModel.Palette = SFChartColorPalette.Natural;

			SFCategoryAxis primaryAxis 			= new SFCategoryAxis ();
			primaryAxis.LabelPlacement			= SFChartLabelPlacement.BetweenTicks;
			primaryAxis.ShowMajorGridLines      = false;
			primaryAxis.MajorTickStyle.LineSize = 0;
			chart.PrimaryAxis 					= primaryAxis;
			chart.SecondaryAxis 				= new SFNumericalAxis ();
			chart.SecondaryAxis.Title.Text 		= new NSString ("Sales");
			chart.SecondaryAxis.Maximum 		= new NSNumber (500);
			chart.SecondaryAxis.Minimum = new NSNumber(0);
			chart.SecondaryAxis.Interval = new NSNumber(100);
			chart.SecondaryAxis.AxisLineStyle.LineWidth = 0;
            chart.SecondaryAxis.MajorTickStyle.LineSize = 0;
            NSNumberFormatter formatter = new NSNumberFormatter();
            formatter.PositiveSuffix = "B";
            chart.SecondaryAxis.LabelStyle.LabelFormatter = formatter;
			ChartViewModel dataModel			= new ChartViewModel();

			SFStackingColumnSeries series1 = new SFStackingColumnSeries();
			series1.ItemsSource = dataModel.StackedColumnData1;
			series1.XBindingPath = "XValue";
			series1.YBindingPath = "YValue";
			series1.EnableTooltip = true;
			series1.Label = "UK";
			series1.EnableAnimation = true;
			chart.Series.Add(series1);

			SFStackingColumnSeries series2 = new SFStackingColumnSeries();
			series2.ItemsSource = dataModel.StackedColumnData2;
			series2.XBindingPath = "XValue";
			series2.YBindingPath = "YValue";
			series2.EnableTooltip = true;
			series2.Label = "Germany";
			series2.EnableAnimation = true;
			chart.Series.Add(series2);

			SFStackingColumnSeries series3 = new SFStackingColumnSeries();
			series3.ItemsSource = dataModel.StackedColumnData3;
			series3.XBindingPath = "XValue";
			series3.YBindingPath = "YValue";
			series3.EnableTooltip = true;
			series3.Label = "France";
			series3.EnableAnimation = true;
			chart.Series.Add(series3);

			SFStackingColumnSeries series4 = new SFStackingColumnSeries();
			series4.ItemsSource = dataModel.StackedColumnData4;
			series4.XBindingPath = "XValue";
			series4.YBindingPath = "YValue";
			series4.EnableTooltip = true;
			series4.Label = "Italy";
			series4.EnableAnimation = true;
			chart.Series.Add(series4);

			chart.Legend.Visible				= true;
			chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.IconWidth = 14;
            chart.Legend.IconHeight = 14;
			chart.Legend.DockPosition 			= SFChartLegendPosition.Bottom;

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