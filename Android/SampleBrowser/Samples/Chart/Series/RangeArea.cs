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
    internal class RangeArea : SamplePage
    {
        SfChart chart;
        public override View GetSampleContent(Context context)
        {
            chart = new SfChart(context);
            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.DockPosition = ChartDock.Bottom;
			chart.Legend.ToggleSeriesVisibility = true;
			chart.Legend.IconHeight = 14;
			chart.Legend.IconWidth = 14;
            chart.Title.Text = "World Gold Price";
            chart.Title.TextSize = 15;
            chart.ColorModel.ColorPalette = ChartColorPalette.Natural;
            chart.SetBackgroundColor(Color.White);

            CategoryAxis categoryaxis = new CategoryAxis();
            categoryaxis.Title.Text = "Month";
            chart.PrimaryAxis = categoryaxis;

            NumericalAxis numericalaxis = new NumericalAxis();
            numericalaxis.Minimum = 5;
            numericalaxis.Maximum = 55;
            numericalaxis.Interval = 5;
            numericalaxis.Title.Text = "Gold Price";
            chart.SecondaryAxis = numericalaxis;

            RangeAreaSeries series = new RangeAreaSeries();
			series.ItemsSource = MainPage.GetRangeArea1();
			series.XBindingPath = "XValue";
			series.High = "High";
			series.Low = "Low";
            series.Label = "India";
            series.TooltipEnabled = true;
            series.EnableAnimation = true;
            chart.Series.Add(series);
           
            RangeAreaSeries series1 = new RangeAreaSeries();
			series1.ItemsSource = MainPage.GetRangeArea();
			series1.XBindingPath = "XValue";
			series1.High = "High";
			series1.Low = "Low";
            series1.Label = "Germany";
            series1.TooltipEnabled = true;
            series1.EnableAnimation = true;
            chart.Series.Add(series1);
          
            return chart;
        }
    }
}