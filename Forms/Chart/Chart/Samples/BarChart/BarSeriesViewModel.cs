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
    public class BarSeriesViewModel
    {
        public ObservableCollection<ChartDataModel> BarData1 { get; set; }

        public ObservableCollection<ChartDataModel> BarData2 { get; set; }

        public BarSeriesViewModel()
        {
            BarData1 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("Egg", 2.2),
                new ChartDataModel("Fish", 2.4),
                new ChartDataModel("Misc", 3),
                new ChartDataModel("Tea", 3.1),

            };

            BarData2 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("Egg", 1.2),
                new ChartDataModel("Fish", 1.3),
                new ChartDataModel("Misc", 1.5),
                new ChartDataModel("Tea", 2.2),
            };
        }
    }
}