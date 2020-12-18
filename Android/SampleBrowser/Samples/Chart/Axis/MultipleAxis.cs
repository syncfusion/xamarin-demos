#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.App;
using Android.Content;
using Android.OS;
using Android.Graphics;
using Com.Syncfusion.Charts;
using Com.Syncfusion.Charts.Enums;
using Android.Views;
using System.Collections.Generic;

namespace SampleBrowser
{
    public class MultipleAxis : SamplePage
    {
       public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);
            chart.SetBackgroundColor(Color.White);
            chart.Legend.ToggleSeriesVisibility = true;
            chart.Title.Text = "Weather Condition JPN vs DEU";
            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.IconHeight = 14;
            chart.Legend.IconWidth = 14;
            chart.Legend.DockPosition = ChartDock.Bottom;
            chart.ColorModel.ColorPalette = ChartColorPalette.Natural;

            var primary = new CategoryAxis();
            primary.Title.Text = "Year";
            primary.Title.TextColor = Color.Black;
            primary.LabelPlacement = LabelPlacement.BetweenTicks;
            primary.ShowMajorGridLines = false;
            chart.PrimaryAxis = primary;

            var secondaryAxis = new NumericalAxis()
            {
                Interval = 2,
                ShowMajorGridLines = false
            };
            secondaryAxis.LabelStyle.LabelFormat = "##.##" + (char)0x00B0 + "F";
            secondaryAxis.Maximum = 100;
            secondaryAxis.Minimum = 0;
            secondaryAxis.Interval = 20;
            chart.SecondaryAxis = secondaryAxis;

            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Sun", 35));
            datas.Add(new DataPoint("Mon",40 ));
            datas.Add(new DataPoint("Tue",80 ));
            datas.Add(new DataPoint("Wed",70 ));
            datas.Add(new DataPoint("Thu",65 ));
            datas.Add(new DataPoint("Fri",55 ));
            datas.Add(new DataPoint("Sat", 50 ));

            var datas1 = new List<DataPoint>();
            datas1.Add(new DataPoint("Sun", 30));
            datas1.Add(new DataPoint("Mon", 28));
            datas1.Add(new DataPoint("Tue", 29));
            datas1.Add(new DataPoint("Wed", 30));
            datas1.Add(new DataPoint("Thu", 33));
            datas1.Add(new DataPoint("Fri", 32));
            datas1.Add(new DataPoint("Sat", 34));

            chart.Series.Add(new ColumnSeries()
            {
                Label = "Germany",
                ItemsSource = datas,
                XBindingPath = "XValue",
                YBindingPath = "YValue",
                TooltipEnabled = true,
                EnableAnimation = true,
            });

            var lineSeries = new FastLineSeries()
            {
                Label = "Japan",
                ItemsSource = datas1,
                XBindingPath = "XValue",
                YBindingPath = "YValue",
                EnableAnimation = true,
                YAxis = new NumericalAxis()
                {
                    OpposedPosition = true,
                    Minimum = 24,
                    Maximum = 36,
                    Interval = 2,
                    ShowMajorGridLines = false,
                }
            };
            lineSeries.DataMarker.ShowLabel = false;
            lineSeries.DataMarker.ShowMarker = true;
            lineSeries.DataMarker.MarkerColor = Color.White;
            lineSeries.DataMarker.MarkerWidth = 10;
            lineSeries.DataMarker.MarkerHeight = 10;
            lineSeries.DataMarker.MarkerStrokeColor = Color.ParseColor("#F8AB1D");
            lineSeries.DataMarker.MarkerStrokeWidth = 2;
			lineSeries.YAxis.LabelStyle.LabelFormat = "##.##" + (char)0x00B0 + "C";
            chart.Series.Add(lineSeries);
            lineSeries.TooltipEnabled = true;
            return chart;
        }
    }
}