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
using Android.Graphics;
using Com.Syncfusion.Charts.Enums;

namespace SampleBrowser
{
    public class Funnel : SamplePage
    {
        SfChart chart;

        public override View GetSampleContent(Context context)
        {
            chart = new SfChart(context);
            chart.Title.Text = "Website Visitors";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);
            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.ToggleSeriesVisibility = true;
			chart.Legend.IconHeight = 14;
			chart.Legend.IconWidth = 14;

            FunnelSeries funnelSeries = new FunnelSeries();
			funnelSeries.ItemsSource = MainPage.GetFunnelData();
			funnelSeries.XBindingPath = "XValue";
			funnelSeries.YBindingPath = "YValue";
            funnelSeries.DataMarker.ShowLabel = true;
            funnelSeries.DataMarker.LabelStyle.LabelFormat = "#.#'%'";
            funnelSeries.DataMarker.LabelStyle.BackgroundColor = Color.Transparent;
            funnelSeries.DataMarker.LabelStyle.TextColor = Color.White;
            funnelSeries.StrokeWidth = 1;
            funnelSeries.StrokeColor = Color.White;
            funnelSeries.ColorModel.ColorPalette = ChartColorPalette.Natural;
            chart.Series.Add(funnelSeries);
            return chart;
        }
    }
}