#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
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
    public class Category : SamplePage
    {
        public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);
            chart.SetBackgroundColor(Color.White);
            chart.Title.Text = "Internet Users - 2016";
            chart.Title.TextSize = 15;

            CategoryAxis dateTimeAxis = new CategoryAxis();
            dateTimeAxis.LabelPlacement = LabelPlacement.BetweenTicks;
            dateTimeAxis.ShowMajorGridLines = false;
            dateTimeAxis.LabelStyle.WrappedLabelAlignment = ChartAxisLabelAlignment.Center;
            dateTimeAxis.LabelStyle.MaxWidth = 40;
            dateTimeAxis.LabelStyle.TextColor = Color.Black;
            chart.PrimaryAxis = dateTimeAxis;

            var numericalAxis = new NumericalAxis();
            numericalAxis.Minimum = 0;
            numericalAxis.Maximum = 70;
            numericalAxis.Visibility = Visibility.Gone;
            numericalAxis.ShowMajorGridLines = false;
            numericalAxis.ShowMinorGridLines = false;
            chart.SecondaryAxis = numericalAxis;

            ColumnSeries columnSeries = new ColumnSeries();
            columnSeries.EnableAnimation = true;
            columnSeries.ColorModel.ColorPalette = ChartColorPalette.Natural;
            columnSeries.ItemsSource = Data.GetCategoryData();
            columnSeries.XBindingPath = "XValue";
            columnSeries.YBindingPath = "YValue";
            columnSeries.DataMarker.ShowLabel = true;
            columnSeries.DataMarker.LabelStyle.LabelPosition = DataMarkerLabelPosition.Outer;
            columnSeries.DataMarker.LabelStyle.LabelFormat = "#.#'M'";
            chart.Series.Add(columnSeries);

            return chart;
        }
    }
}