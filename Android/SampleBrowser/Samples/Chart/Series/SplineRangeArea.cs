#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Charts;
using Android.Graphics;
using Com.Syncfusion.Charts.Enums;

namespace SampleBrowser
{
	public class SplineRangeArea : SamplePage
	{
		SfChart chart;

		public override View GetSampleContent(Context context)
		{
			chart = new SfChart(context);
			chart.Title.Text = "Product Price Comparison";
			chart.Legend.Visibility = Visibility.Visible;
			chart.Legend.DockPosition = ChartDock.Bottom;
			chart.Legend.ToggleSeriesVisibility = true;

			chart.Legend.IconHeight = 14;
			chart.Legend.IconWidth = 14;
			chart.ColorModel.ColorPalette = ChartColorPalette.Natural;
			chart.SetBackgroundColor(Color.White);

			CategoryAxis categoryaxis = new CategoryAxis();
			categoryaxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
			categoryaxis.ShowMajorGridLines = false;
			categoryaxis.LabelStyle.MarginTop = 10;
			categoryaxis.MajorTickStyle.TickSize = 10;
			chart.PrimaryAxis = categoryaxis;

			NumericalAxis numericalaxis = new NumericalAxis();
			numericalaxis.Minimum = 5;
			numericalaxis.Maximum = 55;
			numericalaxis.Interval = 5;
			numericalaxis.ShowMajorGridLines = false;
			numericalaxis.ShowMinorGridLines = false;
			chart.SecondaryAxis = numericalaxis;

			SplineRangeAreaSeries series = new SplineRangeAreaSeries();
			series.EnableAnimation = true;
			series.ItemsSource = MainPage.GetSplineRangeArea1();
			series.XBindingPath = "XValue";
			series.High = "High";
			series.Low = "Low";
			series.Label = "Product A";
			series.TooltipEnabled = true;
			series.EnableAnimation = true;
			chart.Series.Add(series);

			SplineRangeAreaSeries series1 = new SplineRangeAreaSeries();
			series1.EnableAnimation = true;
			series1.ItemsSource = MainPage.GetSplineRangeArea2();
			series1.XBindingPath = "XValue";
			series1.High = "High";
			series1.Low = "Low";
			series1.Label = "Product B";
			series1.TooltipEnabled = true;
			series1.EnableAnimation = true;
			chart.Series.Add(series1);

			return chart;
		}
	}
}
