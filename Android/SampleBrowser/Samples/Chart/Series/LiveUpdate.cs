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
using Com.Syncfusion.Charts;
using Com.Syncfusion.Charts.Enums;
using System;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SampleBrowser
{
    public class LiveUpdate : SamplePage
    {
		private readonly ObservableCollection<DataPoint> data = new ObservableCollection<DataPoint>();
		private readonly ObservableCollection<DataPoint> data2 = new ObservableCollection<DataPoint>();

        private int wave1;
        private int wave2 = 180;

        private SfChart chart;

        public override View GetSampleContent(Context context)
        {
            LoadData();

            chart = new SfChart(context);
            chart.SetBackgroundColor(Color.White);
            chart.PrimaryAxis = new NumericalAxis() { ShowMajorGridLines = false };
            chart.ColorModel.ColorPalette = ChartColorPalette.Natural;

            var axis = new NumericalAxis {Minimum = -1.5, Maximum = 1.5, ShowMajorGridLines= false};
            chart.SecondaryAxis = axis;
            axis.LabelStyle.LabelsPosition = AxisElementPosition.Outside;
            axis.TickPosition = AxisElementPosition.Outside;

            var lineSeries = new FastLineSeries {ItemsSource = data, XBindingPath = "XValue", YBindingPath = "YValue" };

            var fastLine = new FastLineSeries();
            fastLine.ItemsSource = data2;
            fastLine.XBindingPath = "XValue";
            fastLine.YBindingPath = "YValue";
			chart.Series.Add(fastLine);

            chart.Series.Add(lineSeries);

            UpdateData();
            
            return chart;
        }

        private void LoadData()
        {
            for (var i = 0; i < 180; i++)
            {
                data.Add(new DataPoint(i, Math.Sin(wave1*(Math.PI/180.0))));
                wave1++;
            }

            for (var i = 0; i < 180; i++)
            {
                data2.Add(new DataPoint(i, Math.Sin(wave2 * (Math.PI / 180.0))));
                wave2++;
            }

            wave1 = data.Count;
        }

        private async void UpdateData()
        {
            while (true)
            {
                await Task.Delay(10);
                data.RemoveAt(0);
                data.Add(new DataPoint(wave1, Math.Sin(wave1*(Math.PI/180.0))));
                wave1++;

                data2.RemoveAt(0);
                data2.Add(new DataPoint(wave1, Math.Sin(wave2 * (Math.PI / 180.0))));
                wave2++;
            }
        }
    }
}