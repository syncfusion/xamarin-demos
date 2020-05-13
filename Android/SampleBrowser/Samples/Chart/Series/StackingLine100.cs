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
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Charts;

namespace SampleBrowser
{
    public class StackingLine100 : SamplePage
    {
        public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);
            chart.Title.Text = "Monthly Expenses of a Family";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);
            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.DockPosition = ChartDock.Bottom;
            chart.Legend.IconHeight = 14;
            chart.Legend.IconWidth = 14;
            chart.ColorModel.ColorPalette = ChartColorPalette.Natural;

            CategoryAxis PrimaryAxis = new CategoryAxis();
            PrimaryAxis.ShowMajorGridLines = false;
            PrimaryAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            PrimaryAxis.LabelPlacement = LabelPlacement.BetweenTicks;
            chart.PrimaryAxis = PrimaryAxis;

            NumericalAxis numericalAxis = new NumericalAxis();
            numericalAxis.PlotOffset = 20;
            numericalAxis.Minimum = 0;
            numericalAxis.Maximum = 100;
            numericalAxis.Interval = 10;
            numericalAxis.LineStyle.StrokeWidth = 0;
            numericalAxis.MajorTickStyle.TickSize = 0;
            numericalAxis.LabelStyle.LabelFormat = "#'%' ";
            chart.SecondaryAxis = numericalAxis;

            StackingLine100Series stackingLine100Series1 = new StackingLine100Series();
            stackingLine100Series1.EnableAnimation = true;
            stackingLine100Series1.Label = "Daughter";
            stackingLine100Series1.ItemsSource = MainPage.GetStackedLine100Data1();
            stackingLine100Series1.XBindingPath = "XValue";
            stackingLine100Series1.YBindingPath = "YValue";
            stackingLine100Series1.DataMarker.ShowMarker = true;
            stackingLine100Series1.DataMarker.MarkerColor = Color.White;
            stackingLine100Series1.DataMarker.MarkerWidth = 10;
            stackingLine100Series1.DataMarker.MarkerHeight = 10;
            stackingLine100Series1.DataMarker.MarkerStrokeColor = Color.ParseColor("#00bdae");
            stackingLine100Series1.DataMarker.MarkerStrokeWidth = 2;
            stackingLine100Series1.StrokeWidth = 3;
            stackingLine100Series1.LegendIcon = ChartLegendIcon.SeriesType;

            StackingLine100Series stackingLine100Series2 = new StackingLine100Series();
            stackingLine100Series2.EnableAnimation = true;
            stackingLine100Series2.Label = "Son";
            stackingLine100Series2.ItemsSource = MainPage.GetStackedLine100Data2();
            stackingLine100Series2.XBindingPath = "XValue";
            stackingLine100Series2.YBindingPath = "YValue";
            stackingLine100Series2.DataMarker.ShowMarker = true;
            stackingLine100Series2.DataMarker.MarkerColor = Color.White;
            stackingLine100Series2.DataMarker.MarkerWidth = 10;
            stackingLine100Series2.DataMarker.MarkerHeight = 10;
            stackingLine100Series2.DataMarker.MarkerStrokeColor = Color.ParseColor("#404041");
            stackingLine100Series2.DataMarker.MarkerStrokeWidth = 2;
            stackingLine100Series2.StrokeWidth = 3;
            stackingLine100Series2.LegendIcon = ChartLegendIcon.SeriesType;

            StackingLine100Series stackingLine100Series3 = new StackingLine100Series();
            stackingLine100Series3.EnableAnimation = true;
            stackingLine100Series3.Label = "Mother";
            stackingLine100Series3.ItemsSource = MainPage.GetStackedLine100Data3();
            stackingLine100Series3.XBindingPath = "XValue";
            stackingLine100Series3.YBindingPath = "YValue";
            stackingLine100Series3.DataMarker.ShowMarker = true;
            stackingLine100Series3.DataMarker.MarkerColor = Color.White;
            stackingLine100Series3.DataMarker.MarkerWidth = 10;
            stackingLine100Series3.DataMarker.MarkerHeight = 10;
            stackingLine100Series3.DataMarker.MarkerStrokeColor = Color.ParseColor("#357cd2");
            stackingLine100Series3.DataMarker.MarkerStrokeWidth = 2;
            stackingLine100Series3.StrokeWidth = 3;
            stackingLine100Series3.LegendIcon = ChartLegendIcon.SeriesType;

            StackingLine100Series stackingLine100Series4 = new StackingLine100Series();
            stackingLine100Series4.EnableAnimation = true;
            stackingLine100Series4.Label = "Father";
            stackingLine100Series4.ItemsSource = MainPage.GetStackedLine100Data4();
            stackingLine100Series4.XBindingPath = "XValue";
            stackingLine100Series4.YBindingPath = "YValue";
            stackingLine100Series4.DataMarker.ShowMarker = true;
            stackingLine100Series4.DataMarker.MarkerColor = Color.White;
            stackingLine100Series4.DataMarker.MarkerWidth = 10;
            stackingLine100Series4.DataMarker.MarkerHeight = 10;
            stackingLine100Series4.DataMarker.MarkerStrokeColor = Color.ParseColor("#e56590");
            stackingLine100Series4.DataMarker.MarkerStrokeWidth = 2;
            stackingLine100Series4.StrokeWidth = 3;
            stackingLine100Series4.LegendIcon = ChartLegendIcon.SeriesType;

            chart.Series.Add(stackingLine100Series1);
            chart.Series.Add(stackingLine100Series2);
            chart.Series.Add(stackingLine100Series3);
            chart.Series.Add(stackingLine100Series4);

            stackingLine100Series1.TooltipEnabled = true;
            stackingLine100Series2.TooltipEnabled = true;
            stackingLine100Series3.TooltipEnabled = true;
            stackingLine100Series4.TooltipEnabled = true;

            stackingLine100Series1.EnableAnimation = true;
            stackingLine100Series2.EnableAnimation = true;
            stackingLine100Series3.EnableAnimation = true;
            stackingLine100Series4.EnableAnimation = true;

            return chart;
        }
    }
}