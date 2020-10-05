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
    public class BubbleSeriesViewModel
    {
        public ObservableCollection<ChartDataModel> BubbleData { get; set; }

        public BubbleSeriesViewModel()
        {
            BubbleData = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel(92.2, 7.8, 1.347, "China"),
                new ChartDataModel(74, 6.5, 1.241, "India"),
                new ChartDataModel(90.4, 6.0, 0.238, "Indonesia"),
                new ChartDataModel(99.4, 2.2, 0.312, "US"),
                new ChartDataModel(88.6, 1.3, 0.197, "Brazil"),
                new ChartDataModel(99, 0.7, 0.0818, "Germany"),
                new ChartDataModel(72, 2.0, 0.0826, "Egypt"),
                new ChartDataModel(99.6, 3.4, 0.143, "Russia"),
                new ChartDataModel(99, 0.2, 0.128, "Japan"),
                new ChartDataModel(86.1, 4.0, 0.115, "Mexico"),
                new ChartDataModel(92.6, 6.6, 0.096, "Philippines"),
                new ChartDataModel(61.3, 1.45, 0.162, "Nigeria"),
                new ChartDataModel(82.2, 3.97, 0.7, "Hong Kong"),
                new ChartDataModel(79.2, 3.9,0.162, "Netherland"),
                new ChartDataModel(72.5, 4.5,0.7, "Jordan"),
                new ChartDataModel(81, 3.5, 0.21, "Australia"),
                new ChartDataModel(66.8, 3.9, 0.028, "Mongolia"),
                new ChartDataModel(79.2, 2.9, 0.231, "Taiwan"),
            };
        }
    }
}