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
	public class StepArea : SampleView
	{
		public StepArea ()
		{
			SFChart chart 						= new SFChart ();
			chart.ColorModel.Palette = SFChartColorPalette.Natural;

			chart.Title.Text 					= new NSString ("Electricity Production");
			SFNumericalAxis primaryAxis 		= new SFNumericalAxis ();
			primaryAxis.Title.Text				= new NSString ("Year");
			primaryAxis.Interval 				= new NSNumber (2);
			primaryAxis.EdgeLabelsDrawingMode = SFChartAxisEdgeLabelsDrawingMode.Shift;
			primaryAxis.ShowMajorGridLines      = false;
			primaryAxis.MajorTickStyle.LineSize = 8;

			chart.PrimaryAxis 					= primaryAxis;
			SFNumericalAxis secondaryAxis 		= new SFNumericalAxis ();
			secondaryAxis.Title.Text			= new NSString ("Production (Billion as kWh)");
			secondaryAxis.Minimum = new NSNumber(0);
			secondaryAxis.Maximum = new NSNumber(600);
			secondaryAxis.Interval = new NSNumber(100);
			secondaryAxis.AxisLineStyle.LineWidth = 0;
			secondaryAxis.MajorTickStyle.LineWidth = 0;
			NSNumberFormatter formatter = new NSNumberFormatter();
            formatter.PositiveSuffix = "B";
			secondaryAxis.LabelStyle.LabelFormatter = formatter;
			chart.SecondaryAxis 				= secondaryAxis;
			ChartViewModel dataModel			= new ChartViewModel ();

			SFStepAreaSeries series1 = new SFStepAreaSeries();
			series1.ItemsSource = dataModel.StepAreaData1;
			series1.XBindingPath = "XValue";
			series1.YBindingPath = "YValue";
			series1.EnableTooltip = true;
			series1.Label = "Renewable";
			series1.EnableAnimation = true;
			series1.LegendIcon = SFChartLegendIcon.Rectangle;
			chart.Series.Add(series1);

			SFStepAreaSeries series2 = new SFStepAreaSeries();
			series2.ItemsSource = dataModel.StepAreaData2;
			series2.XBindingPath = "XValue";
			series2.YBindingPath = "YValue";
			series2.EnableTooltip = true;
			series2.Label = "Non-Renewable";
			series2.EnableAnimation = true;
			series2.LegendIcon = SFChartLegendIcon.Rectangle;
			chart.Series.Add(series2);

			chart.Legend.Visible 				= true;
			chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.IconWidth = 14;
            chart.Legend.IconHeight = 14;
			chart.Legend.DockPosition			= SFChartLegendPosition.Bottom;
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