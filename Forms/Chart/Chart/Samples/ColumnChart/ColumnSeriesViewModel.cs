#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;

namespace SampleBrowser.SfChart
{
    public class ColumnSeriesViewModel
    {

        public ObservableCollection<ChartDataModel> ColumnData1 { get; set; }

        public ObservableCollection<ChartDataModel> ColumnData2 { get; set; }

        public ObservableCollection<ChartDataModel> ColumnData3 { get; set; }

        public ColumnSeriesViewModel()
        {
            ColumnData1 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("USA", 46),
                new ChartDataModel("GBR", 27),
                new ChartDataModel("CHN", 26),

           };
            ColumnData2 = new ObservableCollection<ChartDataModel>
            {
                 new ChartDataModel("USA", 37),
                new ChartDataModel("GBR", 23),
                new ChartDataModel("CHN", 18),

            };
            ColumnData3 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("USA", 38),
                new ChartDataModel("GBR", 17),
                new ChartDataModel("CHN", 26),
            };
        }
    }
}