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
    public class Numerical : SamplePage
    {
        public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);
            chart.SetBackgroundColor(Color.White);
            chart.Title.Text = "England vs West Indies";
            chart.Title.TextSize = 15;
            chart.ColorModel.ColorPalette = ChartColorPalette.Natural;
            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.DockPosition = ChartDock.Bottom;
            chart.Legend.IconHeight = 14;
            chart.Legend.IconWidth = 14;
            chart.Legend.ToggleSeriesVisibility = true;

            CategoryAxis categoryAxis = new CategoryAxis();
            categoryAxis.Title.Text = "Death Overs";
            categoryAxis.LabelPlacement = LabelPlacement.BetweenTicks;
            categoryAxis.PlotOffset = 2;
            categoryAxis.AxisLineOffset = 2;
            categoryAxis.Interval = 1;
            chart.PrimaryAxis = categoryAxis;

            var numericalAxis = new NumericalAxis();
            numericalAxis.Minimum = 0;
            numericalAxis.Maximum = 25;
            numericalAxis.Interval = 5;
            numericalAxis.MajorTickStyle.TickSize = 0;
            numericalAxis.LineStyle.StrokeWidth = 0;
            chart.SecondaryAxis = numericalAxis;

            ColumnSeries columnSeries = new ColumnSeries();
            columnSeries.EnableAnimation = true;
            columnSeries.ItemsSource = MainPage.GetNumericalData();
            columnSeries.XBindingPath = "XValue";
            columnSeries.YBindingPath = "YValue";
            columnSeries.LegendIcon = ChartLegendIcon.SeriesType;
            columnSeries.Label = "England";
            columnSeries.DataMarker.ShowLabel = true;
            columnSeries.DataMarker.LabelStyle.LabelPosition = DataMarkerLabelPosition.Inner;
            columnSeries.TooltipEnabled = true;
            chart.Series.Add(columnSeries);

            ColumnSeries columnSeries1 = new ColumnSeries();
            columnSeries1.EnableAnimation = true;
            columnSeries1.ItemsSource = MainPage.GetNumericalData1();
            columnSeries1.XBindingPath = "XValue";
            columnSeries1.YBindingPath = "YValue";
            columnSeries1.LegendIcon = ChartLegendIcon.SeriesType;
            columnSeries1.Label = "West Indies";
            columnSeries1.DataMarker.ShowLabel = true;
            columnSeries1.DataMarker.LabelStyle.LabelPosition = DataMarkerLabelPosition.Inner;
            columnSeries1.TooltipEnabled = true;
            chart.Series.Add(columnSeries1);
            return chart;
        }
    }
}