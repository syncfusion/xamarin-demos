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
    public class NumericAxisViewModel
    {
        public ObservableCollection<ChartDataModel> NumericData { get; set; }
        public ObservableCollection<ChartDataModel> NumericData1 { get; set; }

        public NumericAxisViewModel()
        {
            NumericData = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel(16, 2 ),
                new ChartDataModel(17, 14),
                new ChartDataModel(18, 7 ),
                new ChartDataModel(19, 7 ),
                new ChartDataModel(20, 10),
            };
            NumericData1 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel(16, 7 ),
                new ChartDataModel(17, 7 ),
                new ChartDataModel(18, 11),
                new ChartDataModel(19, 8 ),
                new ChartDataModel(20, 24),
            };
        }
    }
}
