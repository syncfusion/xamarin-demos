#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;

namespace SampleBrowser.SfChart
{
    public class StackedColumnSeriesViewModel
    {
        public ObservableCollection<ChartDataModel> StackedColumnData1 { get; set; }

        public ObservableCollection<ChartDataModel> StackedColumnData2 { get; set; }

        public ObservableCollection<ChartDataModel> StackedColumnData3 { get; set; }

        public ObservableCollection<ChartDataModel> StackedColumnData4 { get; set; }

        public StackedColumnSeriesViewModel()
        {
            StackedColumnData1 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("2014", 111.1),
                new ChartDataModel("2015", 127.3),
                new ChartDataModel("2016", 143.4),
                new ChartDataModel("2017", 159.9)
            };
            StackedColumnData2 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("2014", 76.9),
                new ChartDataModel("2015", 99.5),
                new ChartDataModel("2016", 121.7),
                new ChartDataModel("2017", 142.5)
            };
            StackedColumnData3 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("2014", 66.1),
                new ChartDataModel("2015", 79.3),
                new ChartDataModel("2016", 91.3),
                new ChartDataModel("2017", 102.4)
            };
            StackedColumnData4 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("2014", 34.1),
                new ChartDataModel("2015", 38.2),
                new ChartDataModel("2016", 44.0),
                new ChartDataModel("2017", 51.6)
            };
        }
    }
}