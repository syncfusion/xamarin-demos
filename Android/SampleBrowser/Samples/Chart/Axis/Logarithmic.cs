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
    public class Logarithmic : SamplePage
    {
        public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);
            chart.SetBackgroundColor(Color.White);
            chart.Title.Text = "Product X Growth [1995-2005]";
            chart.Title.TextSize = 15;
            chart.ColorModel.ColorPalette = ChartColorPalette.Natural;

            CategoryAxis categoryAxis = new CategoryAxis();
			categoryAxis.AxisLineOffset = 10;
			categoryAxis.PlotOffset = 10;
            categoryAxis.Title.Text = "Year";
            chart.PrimaryAxis = categoryAxis;
            chart.PrimaryAxis.Interval = 2;
            chart.PrimaryAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;

            LogarithmicAxis logAxis = new LogarithmicAxis();
            logAxis.ShowMinorGridLines = true;
            logAxis.MinorTicksPerInterval = 5;
            logAxis.Title.Text = "Profit";
            logAxis.LabelStyle.LabelFormat = "$##.##";
            chart.SecondaryAxis = logAxis;

            LineSeries lineSeries = new LineSeries();
            lineSeries.EnableAnimation = true;
            lineSeries.ItemsSource = MainPage.GetLogarithmicData();
            lineSeries.XBindingPath = "XValue";
            lineSeries.YBindingPath = "YValue";
            lineSeries.DataMarker.ShowLabel = false;
            lineSeries.DataMarker.ShowMarker = true;
            lineSeries.DataMarker.MarkerHeight = 10;
            lineSeries.DataMarker.MarkerWidth = 10;
            lineSeries.DataMarker.MarkerStrokeWidth = 2;
            lineSeries.DataMarker.MarkerStrokeColor = Color.ParseColor("#00bdae");
            lineSeries.DataMarker.MarkerColor = Color.White;
            chart.Series.Add(lineSeries);

            lineSeries.TooltipEnabled = true;
            return chart;
        }

    }
}