#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
        IList<ChartDataModel> datapoint;
		public DataPointSelection()
		{
			InitializeComponent();
			Grid.SetRow(Chart, 0);
			Grid.SetRow(label, 1);
            datapoint = (column.ItemsSource as IList<ChartDataModel>);
            if (column.SelectedDataPointIndex < 0)
            {
                label.Text = "Tap on a bar segment to select a data point";
                label.FontSize = 14;
            }

            if(Device.RuntimePlatform == Device.UWP)
            {
                secondaryAxisLabelStyle.LabelFormat = "$0";
            }
            else
            {
                secondaryAxisLabelStyle.LabelFormat = "$##.##";
            }
		}

		private void chart_SelectionChanged(object sender, ChartSelectionEventArgs e)
		{
			var selectedindex = e.SelectedDataPointIndex;
			if (selectedindex < 0)
			{
				label.Text = "Tap on a bar segment to select a data point";
                label.FontSize = 14;
				return;
			}
			label.FontSize = 14;
			var series = e.SelectedSeries;
			if (series == null) return;
		
			if (datapoint == null) return;
			var x = datapoint[selectedindex].Name.ToString();
			var y = datapoint[selectedindex].Value.ToString();
			label.Text = "Month : " + x + ",  Sales : $" + y;
		}
	}
}