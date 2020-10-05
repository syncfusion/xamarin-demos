#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Com.Syncfusion.Charts;
using Com.Syncfusion.Charts.Enums;

namespace SampleBrowser
{
    public class Spline : SamplePage
    {
        public override View GetSampleContent(Context context)
        {

            var chart = new SfChart(context);
            chart.SetBackgroundColor(Color.White);
            chart.Title.Text = "NC Weather Report";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);
            chart.Legend.DockPosition = ChartDock.Bottom;
			chart.Legend.IconHeight = 14;
			chart.Legend.IconWidth = 14;
            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.ToggleSeriesVisibility = true;
            chart.ColorModel.ColorPalette = ChartColorPalette.Natural;

            CategoryAxis categoryaxis = new CategoryAxis();
 	        categoryaxis.LabelPlacement = LabelPlacement.BetweenTicks;
            categoryaxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            chart.PrimaryAxis = categoryaxis;

            NumericalAxis numericalaxis = new NumericalAxis();
            numericalaxis.Minimum = 0;
            numericalaxis.Maximum = 40;
            numericalaxis.Interval = 10;
            numericalaxis.LineStyle.StrokeWidth = 0;
            numericalaxis.MajorTickStyle.TickSize = 0;
            numericalaxis.LabelStyle.LabelFormat = "##.##" + (char)0x00B0 + "C";
            chart.SecondaryAxis = numericalaxis;

            SplineSeries splineSeries1 = new SplineSeries();
			splineSeries1.ItemsSource = MainPage.GetSplineData1();
			splineSeries1.XBindingPath = "XValue";
			splineSeries1.YBindingPath = "YValue";
            splineSeries1.Label = "Max Temp";
            splineSeries1.DataMarker.ShowMarker = true;
            splineSeries1.DataMarker.MarkerWidth = 10;
            splineSeries1.DataMarker.MarkerHeight = 10;
            splineSeries1.DataMarker.MarkerColor = Color.White;
            splineSeries1.DataMarker.MarkerStrokeColor = Color.ParseColor("#00bdae");
            splineSeries1.DataMarker.MarkerStrokeWidth = 2;
            splineSeries1.LegendIcon = ChartLegendIcon.SeriesType;
            splineSeries1.TooltipEnabled = true;
            splineSeries1.StrokeWidth = 3;

            SplineSeries splineSeries2 = new SplineSeries();
			splineSeries2.ItemsSource = MainPage.GetSplineData2();
			splineSeries2.XBindingPath = "XValue";
			splineSeries2.YBindingPath = "YValue";
            splineSeries2.Label = "Avg Temp";
            splineSeries2.DataMarker.ShowMarker = true;
            splineSeries2.DataMarker.MarkerWidth = 10;
            splineSeries2.DataMarker.MarkerHeight = 10;
            splineSeries2.DataMarker.MarkerColor = Color.White;
            splineSeries2.DataMarker.MarkerStrokeColor = Color.ParseColor("#404041");
            splineSeries2.DataMarker.MarkerStrokeWidth = 2;
            splineSeries2.LegendIcon = ChartLegendIcon.SeriesType;
            splineSeries2.TooltipEnabled = true;
            splineSeries2.StrokeWidth = 3;

            SplineSeries splineSeries3 = new SplineSeries();
            splineSeries3.ItemsSource = MainPage.GetSplineData3();
            splineSeries3.XBindingPath = "XValue";
            splineSeries3.YBindingPath = "YValue";
            splineSeries3.Label = "Min Temp";
            splineSeries3.DataMarker.ShowMarker = true;
            splineSeries3.DataMarker.MarkerWidth = 10;
            splineSeries3.DataMarker.MarkerHeight = 10;
            splineSeries3.DataMarker.MarkerColor = Color.White;
            splineSeries3.DataMarker.MarkerStrokeColor = Color.ParseColor("#357CD2");
            splineSeries3.DataMarker.MarkerStrokeWidth = 2;
            splineSeries3.LegendIcon = ChartLegendIcon.SeriesType;
            splineSeries3.TooltipEnabled = true;
            splineSeries3.StrokeWidth = 3;

            splineSeries1.EnableAnimation = true;
            splineSeries2.EnableAnimation = true;
            splineSeries3.EnableAnimation = true;

            chart.Series.Add(splineSeries1);
            chart.Series.Add(splineSeries2);
            chart.Series.Add(splineSeries3);
            return chart;
        }
    }
}