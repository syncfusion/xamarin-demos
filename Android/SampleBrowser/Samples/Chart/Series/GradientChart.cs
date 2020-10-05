#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.Content;
using Android.Graphics;
using Com.Syncfusion.Charts;
using Android.Views;

namespace SampleBrowser
{
    public class GradientChart : SamplePage
    {
        SfChart chart;
        public override View GetSampleContent(Context context)
        {
            chart = new SfChart(context);
            chart.Title.Text = "Oxygen Level";
            chart.SetBackgroundColor(Color.White);

			chart.ColorModel.ColorPalette = ChartColorPalette.Custom;

            ChartGradientColor gradientColor = new ChartGradientColor() { StartPoint = new PointF(0.5f, 1), EndPoint = new PointF(0.5f, 0) };
            ChartGradientStop stopColor1 = new ChartGradientStop() { Color = Color.White, Offset = 0 };
            ChartGradientStop stopColor2 = new ChartGradientStop() { Color = Color.ParseColor("#FF0080DF"), Offset = 1 };
            gradientColor.GradientStops.Add(stopColor1);
            gradientColor.GradientStops.Add(stopColor2);

            ChartGradientColorCollection gradientColorsCollection = new ChartGradientColorCollection()
            {
                gradientColor
            };

            chart.ColorModel.CustomGradientColors = gradientColorsCollection;

            DateTimeAxis primaryAxis = new DateTimeAxis();
            primaryAxis.PlotOffset = 6;
            primaryAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            primaryAxis.ShowMinorGridLines = false;
            primaryAxis.ShowMajorGridLines = false;
            primaryAxis.LabelStyle.LabelFormat = "MMM dd";
            chart.PrimaryAxis = primaryAxis;

            NumericalAxis numericalAxis = new NumericalAxis();
            numericalAxis.Maximum = 50;
            numericalAxis.Interval = 5;
			numericalAxis.LabelStyle.LabelFormat = "#'%'";
            chart.SecondaryAxis = numericalAxis;

            SplineAreaSeries splineAreaSeries = new SplineAreaSeries();
            splineAreaSeries.ItemsSource = MainPage.GetGradientData();
            splineAreaSeries.XBindingPath = "Date";
            splineAreaSeries.YBindingPath = "High";
            splineAreaSeries.StrokeColor = Color.ParseColor("#FF0080DF");
            splineAreaSeries.StrokeWidth = 2;
            splineAreaSeries.DataMarker.ShowLabel = true;
            splineAreaSeries.DataMarker.MarkerWidth = 8;
            splineAreaSeries.DataMarker.MarkerHeight = 8;
            splineAreaSeries.DataMarker.MarkerColor = Color.White;
            splineAreaSeries.DataMarker.MarkerStrokeColor = Color.ParseColor("#FF0080DF");
            splineAreaSeries.DataMarker.MarkerStrokeWidth = 2;
            splineAreaSeries.DataMarker.ShowMarker = true;
            splineAreaSeries.DataMarker.LabelStyle.OffsetY = -10;
            splineAreaSeries.DataMarker.LabelStyle.BackgroundColor = Color.ParseColor("#FF0080DF");
			splineAreaSeries.DataMarker.LabelStyle.LabelFormat = "#.#'%'";

            chart.Series.Add(splineAreaSeries);
            return chart;
        }
    }
}