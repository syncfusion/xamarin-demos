#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SampleBrowser.SfChart.Samples.ErrorBarChart
{
    public class ErrorBarSeriesViewModel
    {
        public ObservableCollection<ChartDataModel> ErrorBarSeriesData { get; set; }

        public ErrorBarSeriesViewModel()
        {
            ErrorBarSeriesData = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("IND", 23, 0.5, 1),
                new ChartDataModel("AUS", 20, 0, 2),
                new ChartDataModel("USA", 35, 1, 2),
                new ChartDataModel("DEU", 28, 2, 0.5),
                new ChartDataModel("ITA", 30, 1, 0),
                new ChartDataModel("UK",  42, 1.5, 1),
                new ChartDataModel("RUS", 27, 0.5, 2)
           };
        }
    }
}
