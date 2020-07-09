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
    public class FunnelSeriesViewModel
    {
        public ObservableCollection<ChartDataModel> FunnelData { get; set; }

        public FunnelSeriesViewModel()
        {
            FunnelData = new ObservableCollection<ChartDataModel>
            {
               new ChartDataModel("Renewed", 18.2),
               new ChartDataModel("Subscribe", 27.3),
               new ChartDataModel("Support", 55.9),
               new ChartDataModel("Downloaded", 76.8),
               new ChartDataModel("Visited", 100)
           };
        }
    }
}