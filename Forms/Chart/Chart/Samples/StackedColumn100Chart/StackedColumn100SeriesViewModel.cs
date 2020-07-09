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
    public class StackedColumn100SeriesViewModel
    {

        public ObservableCollection<ChartDataModel> StackedColumnData1 { get; set; }

        public ObservableCollection<ChartDataModel> StackedColumnData2 { get; set; }

        public ObservableCollection<ChartDataModel> StackedColumnData3 { get; set; }

        public ObservableCollection<ChartDataModel> StackedColumnData4 { get; set; }

        public StackedColumn100SeriesViewModel()
        {
            StackedColumnData1 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("2006", 900),
                new ChartDataModel("2007", 544),
                new ChartDataModel("2008", 880),
                new ChartDataModel("2009", 675)
            };
            StackedColumnData2 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("2006", 190),
                new ChartDataModel("2007", 226),
                new ChartDataModel("2008", 194),
                new ChartDataModel("2009", 250)
            };
            StackedColumnData3 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("2006", 250),
                new ChartDataModel("2007", 145),
                new ChartDataModel("2008", 190),
                new ChartDataModel("2009", 220)
            };
            StackedColumnData4 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("2006", 150),
                new ChartDataModel("2007", 120),
                new ChartDataModel("2008", 115),
                new ChartDataModel("2009", 125)
            };
        }
    }
}