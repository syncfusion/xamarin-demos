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
    public class StepLineSeriesViewModel
    {
        public ObservableCollection<ChartDataModel> StepLineData1 { get; set; }

        public ObservableCollection<ChartDataModel> StepLineData2 { get; set; }


        public StepLineSeriesViewModel()
        {
            StepLineData1 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel(1975, 16),
                new ChartDataModel(1980, 12.5),
                new ChartDataModel(1985, 19),
                new ChartDataModel(1990, 14.4),
                new ChartDataModel(1995, 11.5),
                new ChartDataModel(2000, 14),
                new ChartDataModel(2005, 10),
                new ChartDataModel(2010, 16),
            };

            StepLineData2 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel(1975, 10),
                new ChartDataModel(1980, 7.5),
                new ChartDataModel(1985, 11),
                new ChartDataModel(1990, 7),
                new ChartDataModel(1995, 8),
                new ChartDataModel(2000, 6),
                new ChartDataModel(2005, 3.5),
                new ChartDataModel(2010, 7),
            };
        }
    }
}