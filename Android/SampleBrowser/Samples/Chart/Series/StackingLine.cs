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
    public class StackingLine : SamplePage
    {
        SfChart chart;

        public override View GetSampleContent(Context context)
        {
            chart = new SfChart(context);
            chart.Title.Text = "Monthly Expenses of a Family";
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
            numericalaxis.Maximum = 200;
            numericalaxis.Interval = 20;
            numericalaxis.LineStyle.StrokeWidth = 0;
            numericalaxis.MajorTickStyle.TickSize = 0;
            numericalaxis.LabelStyle.LabelFormat = "'$'#";
            chart.SecondaryAxis = numericalaxis;

            StackingLineSeries stackingline1 = new StackingLineSeries();
            stackingline1.ItemsSource = MainPage.GetStackingLineData1();
            stackingline1.XBindingPath = "XValue";
            stackingline1.YBindingPath = "YValue";
            stackingline1.DataMarker.ShowMarker = true;
            stackingline1.DataMarker.MarkerColor = Color.White;
            stackingline1.DataMarker.MarkerWidth = 10;
            stackingline1.DataMarker.MarkerHeight = 10;
            stackingline1.DataMarker.MarkerStrokeColor = Color.ParseColor("#00bdae");
            stackingline1.DataMarker.MarkerStrokeWidth = 2;
            stackingline1.Label = "Daughter";
            stackingline1.StrokeWidth = 3;
            stackingline1.TooltipEnabled = true;

            StackingLineSeries stackingline2 = new StackingLineSeries();
            stackingline2.ItemsSource = MainPage.GetStackingLineData2();
            stackingline2.XBindingPath = "XValue";
            stackingline2.YBindingPath = "YValue";
            stackingline2.Label = "Son";
            stackingline2.DataMarker.ShowMarker = true;
            stackingline2.DataMarker.MarkerColor = Color.White;
            stackingline2.DataMarker.MarkerWidth = 10;
            stackingline2.DataMarker.MarkerHeight = 10;
            stackingline2.DataMarker.MarkerStrokeColor = Color.ParseColor("#404041");
            stackingline2.DataMarker.MarkerStrokeWidth = 2;
            stackingline2.StrokeWidth = 3;
            stackingline2.TooltipEnabled = true;

            StackingLineSeries stackingline3 = new StackingLineSeries();
            stackingline3.ItemsSource = MainPage.GetStackingLineData3();
            stackingline3.XBindingPath = "XValue";
            stackingline3.YBindingPath = "YValue";
            stackingline3.DataMarker.ShowMarker = true;
            stackingline3.DataMarker.MarkerColor = Color.White;
            stackingline3.DataMarker.MarkerWidth = 10;
            stackingline3.DataMarker.MarkerHeight = 10;
            stackingline3.DataMarker.MarkerStrokeColor = Color.ParseColor("#357cd2");
            stackingline3.DataMarker.MarkerStrokeWidth = 2;
            stackingline3.Label = "Mother";
            stackingline3.StrokeWidth = 3;
            stackingline3.TooltipEnabled = true;

            StackingLineSeries stackingline4 = new StackingLineSeries();
            stackingline4.ItemsSource = MainPage.GetStackingLineData4();
            stackingline4.XBindingPath = "XValue";
            stackingline4.YBindingPath = "YValue";
            stackingline4.Label = "Father";
            stackingline4.DataMarker.ShowMarker = true;
            stackingline4.DataMarker.MarkerColor = Color.White;
            stackingline4.DataMarker.MarkerWidth = 10;
            stackingline4.DataMarker.MarkerHeight = 10;
            stackingline4.DataMarker.MarkerStrokeColor = Color.ParseColor("#e56590");
            stackingline4.DataMarker.MarkerStrokeWidth = 2;
            stackingline4.StrokeWidth = 3;
            stackingline4.TooltipEnabled = true;

            stackingline1.EnableAnimation = true;
            stackingline2.EnableAnimation = true;
            stackingline3.EnableAnimation = true;
            stackingline4.EnableAnimation = true;

            chart.Series.Add(stackingline1);
            chart.Series.Add(stackingline2);
            chart.Series.Add(stackingline3);
            chart.Series.Add(stackingline4);

            return chart;
        }
    }
}