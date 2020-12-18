#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.Content;
using Android.OS;
using Android.App;
using Com.Syncfusion.Charts;
using Com.Syncfusion.Charts.Enums;
using Android.Graphics;
using Android.Views;
using System;

namespace SampleBrowser
{
    public class Date : SamplePage
    {
		int month = int.MaxValue;

       public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);
			chart.Title.Text = "Food Production - 2017";
            chart.SetBackgroundColor(Color.White);
			chart.Scroll += (sender, e) => 
			{
				month = int.MaxValue;
			};

            DateTimeAxis dateTimeAxis = new DateTimeAxis();
            dateTimeAxis.Title.Text = "Production Across Years";
			dateTimeAxis.ZoomFactor = 0.2f;
			dateTimeAxis.ZoomPosition = 0.6f;
			dateTimeAxis.LabelCreated += (sender, e) => 
			{
				var date = DateTime.Parse(e.AxisLabel.LabelContent.ToString());
				if(date.Month != month)
				{
					ChartAxisLabelStyle labelStyle = new ChartAxisLabelStyle();
					labelStyle.LabelFormat = "MMM-dd";
					labelStyle.TextSize = 9;
					labelStyle.Typeface = Typeface.DefaultBold;
					e.AxisLabel.LabelStyle = labelStyle;
					month = date.Month;
				}
				else{
					ChartAxisLabelStyle labelStyle = new ChartAxisLabelStyle();
					labelStyle.LabelFormat = "dd";
					e.AxisLabel.LabelStyle = labelStyle;
				}
			};
            dateTimeAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            chart.PrimaryAxis = dateTimeAxis;

            var numericalAxis = new NumericalAxis();
			numericalAxis.Title.Text = "Growth (In Metric Tons)";
            chart.SecondaryAxis = numericalAxis;

			FastLineSeries lineSeries = new FastLineSeries();
			lineSeries.ColorModel.ColorPalette = ChartColorPalette.Natural;
			lineSeries.ItemsSource = Data.GetDateTimeValue();
			lineSeries.XBindingPath = "Date";
			lineSeries.YBindingPath = "YValue";
            lineSeries.TooltipEnabled = true;
            chart.Series.Add(lineSeries);

			ChartZoomPanBehavior zoomPan = new ChartZoomPanBehavior();
			zoomPan.SelectionZoomingEnabled  = false;
			zoomPan.ZoomMode = ZoomMode.X;

			chart.Behaviors.Add(zoomPan);

            return chart;
        }
    }
}