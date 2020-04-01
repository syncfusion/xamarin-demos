#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Charts;
using Com.Syncfusion.Charts.Enums;
using System.Collections.Generic;

namespace SampleBrowser
{
    public class Doughnut : SamplePage
    {
       public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);
            chart.Title.Text = "Project Cost Breakdown";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);
            chart.Legend.Visibility = Visibility.Visible;
			chart.Legend.DockPosition = ChartDock.Bottom;
			chart.Legend.ToggleSeriesVisibility = true;
			chart.Legend.OverflowMode = ChartLegendOverflowMode.Wrap;
			chart.Legend.IconHeight = 14;
			chart.Legend.IconWidth = 14;

            DoughnutSeries doughnutSeries = new DoughnutSeries();
            doughnutSeries.DataPointSelectionEnabled = true;
            doughnutSeries.ColorModel.ColorPalette = ChartColorPalette.Natural;
            doughnutSeries.ExplodableOnTouch = true;
			doughnutSeries.ItemsSource = MainPage.GetDoughnutData();
			doughnutSeries.XBindingPath = "XValue";
			doughnutSeries.YBindingPath = "YValue";
            doughnutSeries.DataMarker.ShowLabel = true;
            doughnutSeries.DataMarker.LabelStyle.LabelFormat = "#.##'M'";
            doughnutSeries.EnableAnimation = true;
            chart.Series.Add(doughnutSeries);

            LinearLayout layout = new LinearLayout(context);
            layout.Orientation = Orientation.Vertical;
            TextView label = new TextView(context);
            label.Gravity = GravityFlags.Center;
            label.TextAlignment = Android.Views.TextAlignment.Center;
            label.Text = "Tap on slice";
            TextView label1 = new TextView(context);
            label1.Gravity = GravityFlags.Center;
            label1.TextAlignment = Android.Views.TextAlignment.Center;
            layout.AddView(label);
            layout.AddView(label1);
            doughnutSeries.CenterView = layout;

            chart.SelectionChanging += (object sender, SfChart.SelectionChangingEventArgs e) =>
            {
                if (doughnutSeries.ExplodeIndex >= 0)
                {
                    var datapoints = e.P1.SelectedSeries.ItemsSource as List<DataPoint>;
                    var datapoint = datapoints[e.P1.SelectedDataPointIndex].YValue;
                    double total = 0;

                    for (int i = 0; i < datapoints.Count; i++)
                    {
                        total = total + (double)datapoints[i].YValue;
                    }

                    double percentageValue = ((double)datapoint / total) * 100;
                    string percentage = percentageValue.ToString("N2") + "%";

                    label.Text = percentage;
                    var segments = e.P1.SelectedSeries.Segments;
                    label.SetTextColor(segments[e.P1.SelectedDataPointIndex].Color);
                    label1.Text = datapoints[e.P1.SelectedDataPointIndex].XValue.ToString();
                    label.TextSize = 19;

                    doughnutSeries.CenterView = layout;
                    e.P1.Cancel = true;
                }
                else
                {
                    label1.Text = string.Empty;
                    label.Text = "Tap on slice";
                    label.TextSize = 13;
                    label.SetTextColor(label1.TextColors);
                    doughnutSeries.CenterView = layout;
                    e.P1.Cancel = true;
                }

            };

            return chart;
        }
    }
}