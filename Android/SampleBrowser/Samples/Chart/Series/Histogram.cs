#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Charts;
using Com.Syncfusion.Charts.Enums;
using Com.Syncfusion.Navigationdrawer;

namespace SampleBrowser
{
    public class Histogram : SamplePage
    {
        public override View GetSampleContent(Context context)
        {
            SfChart chart = new SfChart(context);
            chart.Title.Text = "Examination Result";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);

            chart.ColorModel.ColorPalette = ChartColorPalette.Natural;

            NumericalAxis categoryaxis = new NumericalAxis();
            categoryaxis.Title.Text = "Score of Final Examination";
            categoryaxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            categoryaxis.ShowMajorGridLines = false;
            chart.PrimaryAxis = categoryaxis;

            NumericalAxis numericalaxis = new NumericalAxis();
            numericalaxis.Title.Text = "Number of Students";
            numericalaxis.ShowMajorGridLines = true;
            numericalaxis.LineStyle.StrokeWidth = 0;
            numericalaxis.MajorTickStyle.TickSize = 0;
            chart.SecondaryAxis = numericalaxis;

            HistogramSeries histogramSeries = new HistogramSeries();
            histogramSeries.ItemsSource = MainPage.GetHistogramData();
            histogramSeries.XBindingPath = "YValue";
            histogramSeries.YBindingPath = "XValue";
            histogramSeries.Interval = 20;
            histogramSeries.TooltipEnabled = true;
            histogramSeries.EnableAnimation = true;
            histogramSeries.StrokeColor = Color.White;
            histogramSeries.StrokeWidth = 1;
            histogramSeries.DataMarker.ShowLabel = true;
            histogramSeries.DataMarker.LabelStyle.LabelPosition = DataMarkerLabelPosition.Inner;
            histogramSeries.DataMarker.LabelStyle.BackgroundColor = Color.Transparent;
            histogramSeries.DataMarker.LabelStyle.TextColor = Color.White;

            chart.Series.Add(histogramSeries);

            return chart;
        }
    }
}
