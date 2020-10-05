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
    public class DataMarkerCustomizationViewModel
    {
        public ObservableCollection<ChartDataModel> DataMarkerData1 { get; set; }

        public ObservableCollection<ChartDataModel> DataMarkerData2 { get; set; }

        public DataMarkerCustomizationViewModel()
        {
            DataMarkerData1 = new ObservableCollection<ChartDataModel>
                {
                    new ChartDataModel("2013", 1110),
                    new ChartDataModel("2014", 1130),
                    new ChartDataModel("2015", 1153),
                    new ChartDataModel("2016", 1175),
                };
            DataMarkerData2 = new ObservableCollection<ChartDataModel>
                {
                    new ChartDataModel("2013", 1070),
                    new ChartDataModel("2014", 1105),
                    new ChartDataModel("2015", 1138),
                    new ChartDataModel("2016", 1155),
                };
        }
    }
}