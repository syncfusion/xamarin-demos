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

namespace SampleBrowser
{
    class AxisCrossing: SamplePage
    {
        public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);

            chart.SetBackgroundColor(Color.White);
            chart.Title.Text = "Profit/loss percentage comparison";

            CategoryAxis primaryAxis = new CategoryAxis();
            primaryAxis.CrossesAt = 0;
			primaryAxis.PlotOffset = 7;
			primaryAxis.AxisLineOffset = 7;
			primaryAxis.ShowMajorGridLines = false;
            primaryAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            primaryAxis.Interval = 2;
            primaryAxis.Name = "XAxis";
            primaryAxis.CrossingAxisName = "YAxis";
            primaryAxis.ShowMajorGridLines = false;
            chart.PrimaryAxis = primaryAxis;

            NumericalAxis secondaryAxis = new NumericalAxis();
			secondaryAxis.ShowMajorGridLines = false;
            secondaryAxis.Maximum = -100;
            secondaryAxis.Minimum = 100;
            secondaryAxis.Interval = 20;
            secondaryAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            secondaryAxis.Name = "YAxis";
            secondaryAxis.ShowMajorGridLines = false;
            secondaryAxis.ShowMinorGridLines = false;
            secondaryAxis.CrossingAxisName = "XAxis";

            secondaryAxis.LabelCreated += SecondaryAxis_LabelCreated;
            chart.SecondaryAxis = secondaryAxis;

			ScatterSeries scatterSeries = new ScatterSeries()
            {
                Name = "series1",
                ItemsSource = Data.CrossingData(),
                XBindingPath = "XValue",
                YBindingPath = "YValue",
				ScatterWidth = 15,
				ScatterHeight = 15,
                TooltipEnabled = true,
            };
			scatterSeries.ColorModel.ColorPalette = ChartColorPalette.Natural;
            ChartZoomPanBehavior zoomPanBehavior = new ChartZoomPanBehavior();
            chart.Behaviors.Add(zoomPanBehavior);
			chart.Series.Add(scatterSeries);

            chart.SecondaryAxis.CrossesAt = 8;

            return chart;

        }
         void SecondaryAxis_LabelCreated(object sender, ChartAxis.LabelCreatedEventArgs e)
        {
            e.AxisLabel.LabelContent = e.AxisLabel.LabelContent + "%";
        }

    }
}