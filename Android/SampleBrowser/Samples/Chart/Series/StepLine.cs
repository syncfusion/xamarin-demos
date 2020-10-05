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
using Com.Syncfusion.Charts.Enums;
using Android.Graphics;

namespace SampleBrowser
{
    public class StepLine : SamplePage
    {
        SfChart chart;
        public override View GetSampleContent(Context context)
        {
            chart = new SfChart(context);
            chart.Title.Text = "Unemployment Rates 1975-2010";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);
            chart.ColorModel.ColorPalette = ChartColorPalette.Natural;

            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.DockPosition = ChartDock.Bottom;
            chart.Legend.IconHeight = 14;
            chart.Legend.IconWidth = 14;
            chart.Legend.ToggleSeriesVisibility = true;

            NumericalAxis numericalAxis = new NumericalAxis();
            numericalAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            numericalAxis.Minimum = 1975;
            numericalAxis.Maximum = 2010;
            numericalAxis.Interval = 5;
            numericalAxis.ShowMajorGridLines = false;
            numericalAxis.PlotOffset = 10;
            numericalAxis.AxisLineOffset = 10;
            numericalAxis.MajorTickStyle.TickSize = 10;
            chart.PrimaryAxis = numericalAxis;

            NumericalAxis numericalaxis = new NumericalAxis();
            numericalaxis.Minimum = 0;
            numericalaxis.Maximum = 20;
            numericalaxis.Interval = 5;
            numericalaxis.LineStyle.StrokeWidth = 0;
            numericalaxis.MajorTickStyle.TickSize = 0;
            numericalaxis.LabelStyle.LabelFormat = "#'%'";
            chart.SecondaryAxis = numericalaxis;

            StepLineSeries stepLineSeries1 = new StepLineSeries();
            stepLineSeries1.ItemsSource = MainPage.GetStepLineData1();
            stepLineSeries1.XBindingPath = "XValue";
            stepLineSeries1.YBindingPath = "YValue";
            stepLineSeries1.Label = "China";
            stepLineSeries1.DataMarker.ShowMarker = true;
            stepLineSeries1.DataMarker.MarkerColor = Color.White;
            stepLineSeries1.DataMarker.MarkerWidth = 10;
            stepLineSeries1.DataMarker.MarkerHeight = 10;
            stepLineSeries1.DataMarker.MarkerStrokeColor = Color.ParseColor("#00bdae");
            stepLineSeries1.DataMarker.MarkerStrokeWidth = 2;
            stepLineSeries1.LegendIcon = ChartLegendIcon.SeriesType;
            stepLineSeries1.StrokeWidth = 3;
            stepLineSeries1.TooltipEnabled = true;

            StepLineSeries stepLineSeries2 = new StepLineSeries();
            stepLineSeries2.ItemsSource = MainPage.GetStepLineData2();
            stepLineSeries2.XBindingPath = "XValue";
            stepLineSeries2.YBindingPath = "YValue";
            stepLineSeries2.Label = "Australia";
            stepLineSeries2.DataMarker.ShowMarker = true;
            stepLineSeries2.DataMarker.MarkerColor = Color.White;
            stepLineSeries2.DataMarker.MarkerWidth = 10;
            stepLineSeries2.DataMarker.MarkerHeight = 10;
            stepLineSeries2.DataMarker.MarkerStrokeColor = Color.ParseColor("#404041");
            stepLineSeries2.DataMarker.MarkerStrokeWidth = 2;
            stepLineSeries2.LegendIcon = ChartLegendIcon.SeriesType;
            stepLineSeries2.StrokeWidth = 3;
            stepLineSeries2.TooltipEnabled = true;

            stepLineSeries1.EnableAnimation = true;
            stepLineSeries2.EnableAnimation = true;

            chart.Series.Add(stepLineSeries1);
            chart.Series.Add(stepLineSeries2);
            return chart;
        }
    }
}