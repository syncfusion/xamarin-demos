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
    public class RadarSeriesViewModel
    {

        public ObservableCollection<ChartDataModel> PolarData1 { get; set; }

        public ObservableCollection<ChartDataModel> PolarData2 { get; set; }

        public ObservableCollection<ChartDataModel> PolarData3 { get; set; }

        public RadarSeriesViewModel()
        {
            PolarData1 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("2000", 4),
                new ChartDataModel("2001", 3.0),
                new ChartDataModel("2002", 3.8),
                new ChartDataModel("2003", 3.4),
                new ChartDataModel("2004", 3.2),
                new ChartDataModel("2005", 3.9),

            };

            PolarData2 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("2000", 2.6),
                new ChartDataModel("2001", 2.8),
                new ChartDataModel("2002", 2.6),
                new ChartDataModel("2003", 3),
                new ChartDataModel("2004", 3.6),
                new ChartDataModel("2005", 3),
            };

            PolarData3 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("2000", 2.8),
                new ChartDataModel("2001", 2.5),
                new ChartDataModel("2002", 2.8),
                new ChartDataModel("2003", 3.2),
                new ChartDataModel("2004", 2.9),
                new ChartDataModel("2005", 2),
            };
        }
    }
}