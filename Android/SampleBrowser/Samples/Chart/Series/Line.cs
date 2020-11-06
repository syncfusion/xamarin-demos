#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Reflection.Emit;
using Android.App;
using Android.Graphics;
using Android.OS;
using Com.Syncfusion.Charts;
using Android.Views;
using Android.Content;
using Android.Widget;
using System.Collections.Generic;
using System;
using Com.Syncfusion.Charts.Enums;

namespace SampleBrowser
{
   public class Line : SamplePage
    {
        SfChart chart;

        public override View GetSampleContent(Context context)
        {
            chart = new SfChart(context);
            chart.Title.Text = "Inflation - Consumer Price";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);
            chart.ColorModel.ColorPalette = ChartColorPalette.Natural;

            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.DockPosition = ChartDock.Bottom;
            chart.Legend.IconHeight = 14;
            chart.Legend.IconWidth = 14;
            chart.Legend.ToggleSeriesVisibility = true;

            CategoryAxis categoryaxis = new CategoryAxis();
            categoryaxis.LabelPlacement = LabelPlacement.BetweenTicks;
            categoryaxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            categoryaxis.ShowMajorGridLines = false;
            categoryaxis.AxisLineOffset = 10;
            categoryaxis.PlotOffset = 10;
            categoryaxis.MajorTickStyle.TickSize = 10;
            chart.PrimaryAxis = categoryaxis;

            NumericalAxis numericalaxis = new NumericalAxis();
            numericalaxis.Minimum = 0;
            numericalaxis.Maximum = 100;
            numericalaxis.Interval = 20;
            numericalaxis.LineStyle.StrokeWidth = 0;
            numericalaxis.MajorTickStyle.TickSize = 0;
            numericalaxis.LabelStyle.LabelFormat = "#'%'";
            chart.SecondaryAxis = numericalaxis;

            LineSeries lineSeries1 = new LineSeries();
            lineSeries1.ItemsSource = MainPage.GetLineData1();
            lineSeries1.XBindingPath = "XValue";
            lineSeries1.YBindingPath = "YValue";
            lineSeries1.DataMarker.ShowMarker = true;
            lineSeries1.DataMarker.MarkerColor = Color.White;
            lineSeries1.DataMarker.MarkerWidth = 10;
            lineSeries1.DataMarker.MarkerHeight = 10;
            lineSeries1.DataMarker.MarkerStrokeColor = Color.ParseColor("#00bdae");
            lineSeries1.DataMarker.MarkerStrokeWidth = 2;
            lineSeries1.Label = "Germany";
            lineSeries1.StrokeWidth = 3;
            lineSeries1.TooltipEnabled = true;

            LineSeries lineSeries2 = new LineSeries();
            lineSeries2.ItemsSource = MainPage.GetLineData2();
            lineSeries2.XBindingPath = "XValue";
            lineSeries2.YBindingPath = "YValue";
            lineSeries2.Label = "Japan";
            lineSeries2.DataMarker.ShowMarker = true;
            lineSeries2.DataMarker.MarkerColor = Color.White;
            lineSeries2.DataMarker.MarkerWidth = 10;
            lineSeries2.DataMarker.MarkerHeight = 10;
            lineSeries2.DataMarker.MarkerStrokeColor = Color.ParseColor("#404041");
            lineSeries2.DataMarker.MarkerStrokeWidth = 2;
            lineSeries2.StrokeWidth = 3;
            lineSeries2.TooltipEnabled = true;

            lineSeries1.EnableAnimation = true;
            lineSeries2.EnableAnimation = true;

            chart.Series.Add(lineSeries1);
            chart.Series.Add(lineSeries2);
            return chart;
        }
    }
}