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

    public class SplineArea : SamplePage
    {
        public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);
            chart.SetBackgroundColor(Color.White);
            chart.Title.Text = "Inflation Rate in Percentage";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);
            chart.Legend.DockPosition = ChartDock.Bottom;
            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.IconHeight = 14;
            chart.Legend.IconWidth = 14;
            chart.Legend.ToggleSeriesVisibility = true;
            chart.ColorModel.ColorPalette = ChartColorPalette.Natural;

            NumericalAxis primaryAxis = new NumericalAxis();
            primaryAxis.ShowMajorGridLines = false;
            primaryAxis.Interval = 2;
            primaryAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            chart.PrimaryAxis = primaryAxis;

            NumericalAxis numericalaxis = new NumericalAxis();
            numericalaxis.Minimum = 0;
            numericalaxis.Maximum = 4;
            numericalaxis.Interval = 1;
            numericalaxis.MajorTickStyle.TickSize = 0;
            numericalaxis.LineStyle.StrokeWidth = 0;
            numericalaxis.LabelStyle.LabelFormat = "#'% '";
            chart.SecondaryAxis = numericalaxis;

            var areaSeries1 = new SplineAreaSeries
            {
                Label = "US",
                Alpha = 0.5f,
                EnableAnimation = true,
                ItemsSource = MainPage.GetSplineAreaData1(),
                XBindingPath = "XValue",
                YBindingPath = "YValue",
                LegendIcon = ChartLegendIcon.SeriesType
            };
            var areaSeries2 = new SplineAreaSeries
            {
                Alpha = 0.5f,
                Label = "France",
                EnableAnimation = true,
                ItemsSource = MainPage.GetSplineAreaData2(),
                XBindingPath = "XValue",
                YBindingPath = "YValue",
                LegendIcon = ChartLegendIcon.SeriesType
            };
            var areaSeries3 = new SplineAreaSeries
            {
                Alpha = 0.5f,
                Label = "Germany",
                EnableAnimation = true,
                ItemsSource = MainPage.GetSplineAreaData3(),
                XBindingPath = "XValue",
                YBindingPath = "YValue",
                LegendIcon = ChartLegendIcon.SeriesType
            };

            chart.Series.Add(areaSeries1);
            chart.Series.Add(areaSeries2);
            chart.Series.Add(areaSeries3);

            areaSeries1.TooltipEnabled = true;
            areaSeries2.TooltipEnabled = true;
            areaSeries3.TooltipEnabled = true;
			
            areaSeries1.EnableAnimation = true;
            areaSeries2.EnableAnimation = true;
            areaSeries3.EnableAnimation = true;
			
            return chart;
        }
    }
}