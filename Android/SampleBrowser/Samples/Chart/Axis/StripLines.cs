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
    public class StripLines : SamplePage
    {
        public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);
            chart.SetBackgroundColor(Color.White);
            chart.Title.Text = "Weather Report";
            chart.Title.TextSize = 15;
            
            NumericalStripLine numericalStripLines1 = new NumericalStripLine();
            numericalStripLines1.Start = 10;
            numericalStripLines1.Width = 10;
            numericalStripLines1.Text = "Low Temperature";
			numericalStripLines1.LabelStyle.TextSize = 12;
            numericalStripLines1.FillColor = Color.ParseColor("#f9d423");
   
            NumericalStripLine numericalStripLines2 = new NumericalStripLine();
            numericalStripLines2.Start = 20;
            numericalStripLines2.Width = 10;
            numericalStripLines2.Text = "Average Temperature";
			numericalStripLines2.LabelStyle.TextSize = 12;
			numericalStripLines2.FillColor = Color.ParseColor("#fc902a");

            NumericalStripLine numericalStripLines3 = new NumericalStripLine();
            numericalStripLines3.Start = 30;
            numericalStripLines3.Width = 10;
            numericalStripLines3.Text = "High Temperature";
			numericalStripLines3.LabelStyle.TextSize = 12;
            numericalStripLines3.FillColor = Color.ParseColor("#ff512f");

			NumericalAxis numericalAxis = new NumericalAxis();
			numericalAxis.Minimum = 10;
			numericalAxis.Maximum = 40;
			numericalAxis.LabelStyle.LabelFormat = "##.##°C";

            numericalAxis.StripLines.Add(numericalStripLines1);
            numericalAxis.StripLines.Add(numericalStripLines2);
            numericalAxis.StripLines.Add(numericalStripLines3);

            chart.PrimaryAxis = new CategoryAxis();
            (chart.PrimaryAxis as CategoryAxis).LabelPlacement = LabelPlacement.BetweenTicks;
            chart.SecondaryAxis = numericalAxis;

			var lineSeries = new LineSeries
            {
                StrokeWidth = 2,
				ItemsSource = MainPage.GetStripLineData(),
				XBindingPath = "XValue",
				YBindingPath = "YValue",
				Color = Color.White
            };

			chart.Series.Add(lineSeries);

            ChartTooltipBehavior toolTip = new ChartTooltipBehavior();
            toolTip.TextColor = Color.Black;
            chart.Behaviors.Add(toolTip);

			lineSeries.DataMarker.ShowLabel = false;
			lineSeries.DataMarker.ShowMarker = true;
			lineSeries.DataMarker.MarkerWidth = 10;
			lineSeries.DataMarker.MarkerHeight = 10;
			lineSeries.DataMarker.MarkerColor = Color.ParseColor("#666666");
			lineSeries.DataMarker.MarkerStrokeColor = Color.ParseColor("#ffffff");
			lineSeries.DataMarker.MarkerStrokeWidth = 4;
			lineSeries.TooltipEnabled = true;
            return chart;
        }
    }
}