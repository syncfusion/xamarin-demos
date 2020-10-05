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
    public class SplineSeriesViewModel
    {
        public ObservableCollection<ChartDataModel> SplineData1 { get; set; }

        public ObservableCollection<ChartDataModel> SplineData2 { get; set; }
        public ObservableCollection<ChartDataModel> SplineData3 { get; set; }

        public SplineSeriesViewModel()
        {
            SplineData1 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("Sun", 15),
                new ChartDataModel("Mon", 22),
                new ChartDataModel("Tue", 32),
                new ChartDataModel("Wed", 31),
                new ChartDataModel("Thu", 29),
                new ChartDataModel("Fri", 26),
                new ChartDataModel("Sat", 18),
            };

            SplineData2 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("Sun", 10),
                new ChartDataModel("Mon", 18),
                new ChartDataModel("Tue", 28),
                new ChartDataModel("Wed", 28),
                new ChartDataModel("Thu", 26),
                new ChartDataModel("Fri", 20),
                new ChartDataModel("Sat", 15),
            };

            SplineData3 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("Sun", 2),
                new ChartDataModel("Mon", 12),
                new ChartDataModel("Tue", 22),
                new ChartDataModel("Wed", 23),
                new ChartDataModel("Thu", 19),
                new ChartDataModel("Fri", 13),
                new ChartDataModel("Sat", 8),
            };
        }
    }
}