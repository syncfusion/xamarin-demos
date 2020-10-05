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
using Java.Lang;
using Com.Syncfusion.Charts.Enums;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SampleBrowser
{
    public class VerticalChart : SamplePage
    {
		ObservableCollection<DataPoint> datas1;
 
        SfChart sfChart;

        int count = 0;     

        public override View GetSampleContent(Context context) {
            datas1 = new ObservableCollection<DataPoint>();

            sfChart = new SfChart(context);
			sfChart.ColorModel.ColorPalette = ChartColorPalette.Natural;

            sfChart.Title.Text ="Seismograph analysis of a country";
            sfChart.Title.TextSize = 15;

            sfChart.Legend.Visibility = Visibility.Visible;
			sfChart.Legend.ToggleSeriesVisibility = true;

            NumericalAxis primaryAxis = new NumericalAxis();
            primaryAxis.Title.Text ="Time (s)";
            primaryAxis.ShowMajorGridLines = false;
            sfChart.PrimaryAxis = primaryAxis;

            NumericalAxis numericalAxis = new NumericalAxis() {
                Minimum = -15,
                Maximum = 15,
            };
            numericalAxis.Title.Text ="Velocity (m/s)";
            numericalAxis.ShowMajorGridLines = false;
            sfChart.SecondaryAxis = numericalAxis;

            FastLineSeries fastLineSeries = new FastLineSeries();
			fastLineSeries.ItemsSource = datas1;
			fastLineSeries.XBindingPath = "XValue";
			fastLineSeries.YBindingPath = "YValue";
            fastLineSeries.Label="Indonesia";
            fastLineSeries.Transposed = true;
            sfChart.Series.Add(fastLineSeries);

            Random random = new Random();
            for (int i = 1; i < 50; i++)
            {
              datas1.Add(new DataPoint(i, random.Next(-3, 3)));
            }

            UpdateData();
            return sfChart;
        }

        private async void UpdateData()
        {
            bool isFlag = true;
            while (isFlag)
            {
                await Task.Delay(10);

                count = count + 1;
                Random random = new Random();
                int index = datas1.Count();
                if (count > 350)
                {
                    isFlag =false;
                }
                else if (count > 300)
                {
                    datas1.Add(new DataPoint(index, random.Next(0, 0)));
                }
                else if (count > 250)
                {
                    datas1.Add(new DataPoint(index, random.Next(-2, 1)));
                }
                else if (count > 180)
                {
                    datas1.Add(new DataPoint(index,random.Next(-3, 2)));
                }
                else if (count > 100)
                {
                    datas1.Add(new DataPoint(index,random.Next(-7, 6)));
                }
                else
                {
                    datas1.Add(new DataPoint(index, random.Next(-9, 9)));
                }
                index++;
            }
        }
    }
}