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
    public class MultipleAxesViewModel
    {
        public ObservableCollection<ChartDataModel> ColumnData { get; set; }

        public ObservableCollection<ChartDataModel> LineData { get; set; }

        public MultipleAxesViewModel()
        {
            ColumnData = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("Sun", 35 ),
                new ChartDataModel("Mon", 40 ),
                new ChartDataModel("Tue", 80 ),
                new ChartDataModel("Wed", 70 ),
                new ChartDataModel("Thu", 65 ),
                new ChartDataModel("Fri", 55 ),
                new ChartDataModel("Sat", 50 )
            };

            LineData = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("Sun", 30 ),
                new ChartDataModel("Mon", 28 ),
                new ChartDataModel("Tue", 29 ),
                new ChartDataModel("Wed", 30 ),
                new ChartDataModel("Thu", 33 ),
                new ChartDataModel("Fri", 32 ),
                new ChartDataModel("Sat", 34 )
            };
        }
    }
}