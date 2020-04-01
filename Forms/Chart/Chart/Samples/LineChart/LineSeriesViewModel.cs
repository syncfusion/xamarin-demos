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
    public class LineSeriesViewModel
    {

        public ObservableCollection<ChartDataModel> LineData1 { get; set; }

        public ObservableCollection<ChartDataModel> LineData2 { get; set; }
        public LineSeriesViewModel()
        {
            LineData1 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("2005", 21),
                new ChartDataModel("2006", 24),
                new ChartDataModel("2007", 36),
                new ChartDataModel("2008", 38),
                new ChartDataModel("2009", 54),
                new ChartDataModel("2010", 57),
                new ChartDataModel("2011", 70)
            };

            LineData2 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("2005", 28),
                new ChartDataModel("2006", 44),
                new ChartDataModel("2007", 48),
                new ChartDataModel("2008", 50),
                new ChartDataModel("2009", 66),
                new ChartDataModel("2010", 78),
                new ChartDataModel("2011", 84)
            };
        }
    }
}