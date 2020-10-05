#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.Content;
using Android.Views;
using Com.Syncfusion.Charts;
using Android.Graphics;

namespace SampleBrowser
{
    public class RangeBar : SamplePage
    {
        SfChart chart;

        public override View GetSampleContent(Context context)
        {
            chart = new SfChart(context);
            chart.Title.Text = "Pipeline Volume";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);

            CategoryAxis categoryaxis = new CategoryAxis();
            categoryaxis.ShowMajorGridLines = false;
            categoryaxis.LabelStyle.TextColor = Color.Black;
            categoryaxis.LineStyle.StrokeWidth = 0;
            categoryaxis.LabelStyle.TextSize = 11;
            categoryaxis.MajorTickStyle.TickSize = 0;
            chart.PrimaryAxis = categoryaxis;

            NumericalAxis numericalaxis = new NumericalAxis();
            numericalaxis.Visibility = Visibility.Gone;
            numericalaxis.ShowMajorGridLines = false;
            numericalaxis.LineStyle.StrokeWidth = 0;
            numericalaxis.MajorTickStyle.TickSize = 0;
            numericalaxis.LabelStyle.LabelFormat = "$#,###";
            chart.SecondaryAxis = numericalaxis;

            RangeColumnSeries rangeColumnSeries = new RangeColumnSeries();
            rangeColumnSeries.ItemsSource = MainPage.GetRangeBarData();
            rangeColumnSeries.XBindingPath = "XValue";
            rangeColumnSeries.High = "YValue";
            rangeColumnSeries.Low = string.Empty;
            rangeColumnSeries.Transposed = true;
            rangeColumnSeries.DataMarker.ShowLabel = true;
            rangeColumnSeries.DataMarker.LabelStyle.LabelFormat = "$#,###";
            rangeColumnSeries.ColorModel.ColorPalette = ChartColorPalette.Natural;

            chart.Series.Add(rangeColumnSeries);
            return chart;
        }
    }
}
