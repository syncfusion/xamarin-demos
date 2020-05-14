#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfChart.XForms;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SampleBrowser.SfChart
{
	public partial class DataPointSelection : SampleView
	{
        double sumOfTotalSeries1 = 0;
        double sumOfTotalSeries2 = 0;
        IList<ChartDataModel> datapoint;
        IList<ChartDataModel> datapoint1;

        public DataPointSelection()
		{
			InitializeComponent();

            picker.SelectedIndex = 0;

            datapoint = (column.ItemsSource as IList<ChartDataModel>);
            datapoint1 = (column1.ItemsSource as IList<ChartDataModel>);

            foreach (var data in datapoint)
            {
                sumOfTotalSeries1 += data.Value;
            }

            foreach (var data in datapoint1)
            {
                sumOfTotalSeries2 += data.Value;
            }

            if (Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WPF)
            {
                secondaryAxisLabelStyle.LabelFormat = "$0";
            }
            else
            {
                secondaryAxisLabelStyle.LabelFormat = "$##.##";
            }

            if (Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.macOS || Device.RuntimePlatform == Device.WPF)
            {              
                productA.HorizontalOptions = LayoutOptions.EndAndExpand;
                productA.Margin = new Thickness(0, 0, 10, 0);
                productB.HorizontalOptions = LayoutOptions.StartAndExpand;
                productB.Margin = new Thickness(10, 0, 0, 0);
            }
        }

		private void chart_SelectionChanged(object sender, ChartSelectionEventArgs e)
		{
            var series = e.SelectedSeries;
            if (series == null) return;

            if (Chart.EnableSeriesSelection)
            {
                productA.IsVisible = false;
                productB.IsVisible = false;
                seriesSelection.IsVisible = true;

                if (column.IsSelected)
                {
                    seriesSelection.Text = series.Label + " | Total Sales : $" + sumOfTotalSeries1;
                    return;
                }
                else if (column1.IsSelected)
                {
                    seriesSelection.Text = series.Label + " | Total Sales : $" + sumOfTotalSeries2;
                    return;
                }

                seriesSelection.Text = "Tap on a bar segment to select a series";
            }
            else
            {
                productA.IsVisible = true;
                productB.IsVisible = true;
                seriesSelection.IsVisible = false;

                var selectedindex = e.SelectedDataPointIndex;
                var seriesIndex = Chart.Series.IndexOf(e.SelectedSeries);

                if (selectedindex < 0)
                {
                    if (seriesIndex == 0)
                        productA.Text = "Tap on a bar segment";
                    else
                        productB.Text = "Tap on a bar segment";

                    return;
                }
                else
                {
                    if (seriesIndex == 0)
                    {
                        var x = datapoint[selectedindex].Name;
                        var y = datapoint[selectedindex].Value;
                        productA.Text = "Month : " + x + ",  Sales : $" + y;
                    }
                    else if (seriesIndex == 1)
                    {
                        var x = datapoint1[selectedindex].Name;
                        var y = datapoint1[selectedindex].Value;
                        productB.Text = "Month : " + x + ",  Sales : $" + y;
                    }
                }
            }
        }

        private void selectedIndex_Changed(object sender, System.EventArgs e)
        {
            int index = picker.SelectedIndex;

            productA.IsVisible = false;
            productB.IsVisible = false;
            seriesSelection.IsVisible = true;

            if (index == 0)
            {
                seriesSelection.Text = "Tap on a bar segment to select a data point";
                Chart.EnableSeriesSelection = false;
            }
            else if(index == 1)
            {
                seriesSelection.Text = "Tap on a bar segment to select a series";
                Chart.EnableSeriesSelection = true;
            }
        }
    }
}