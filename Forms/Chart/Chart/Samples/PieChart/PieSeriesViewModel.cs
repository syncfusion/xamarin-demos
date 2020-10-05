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
    public class PieSeriesViewModel
    {
        public ObservableCollection<ChartDataModel> PieSeriesData { get; set; }

        public PieSeriesViewModel()
        {
            PieSeriesData = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("David", 30),
                new ChartDataModel("Steve", 35),
                new ChartDataModel("Micheal", 24),
                new ChartDataModel("John", 11),
                new ChartDataModel("Regev", 25),
                new ChartDataModel("Jack", 39),
                new ChartDataModel("Stephen", 15),
           };
        }
    }
}
