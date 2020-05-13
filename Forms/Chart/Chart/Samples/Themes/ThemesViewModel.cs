#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SampleBrowser.SfChart
{
    public class ThemesViewModel
    {
        public ObservableCollection<ChartDataModel> ColumnData1 { get; set; }

        public ObservableCollection<ChartDataModel> ColumnData2 { get; set; }

        public ThemesViewModel()
        {
            ColumnData1 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("USA", 46),
                new ChartDataModel("GBR", 27),
                new ChartDataModel("CHN", 50),
                new ChartDataModel("FRA", 30),
                new ChartDataModel("IND", 28),
            };

            ColumnData2 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("USA", 37),
                new ChartDataModel("GBR", 23),
                new ChartDataModel("CHN", 30),
                new ChartDataModel("FRA", 40),
                new ChartDataModel("IND", 25),
            };
        }
    }
}

