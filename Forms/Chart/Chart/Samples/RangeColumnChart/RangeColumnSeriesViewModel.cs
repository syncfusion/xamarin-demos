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
    public class RangeColumnSeriesViewModel
    {
        public ObservableCollection<RangeSeriesBaseModel> RangeColumnData1 { get; set; }

        public ObservableCollection<RangeSeriesBaseModel> RangeColumnData2 { get; set; }

        public RangeColumnSeriesViewModel()
        {
            RangeColumnData1 = new ObservableCollection<RangeSeriesBaseModel>
            {
                new RangeSeriesBaseModel("Sun", 10.8, 3.1),
                new RangeSeriesBaseModel("Mon", 14.4, 5.7),
                new RangeSeriesBaseModel("Tue", 16.9, 8.4),
                new RangeSeriesBaseModel("Wed", 19.2, 10.6),
                new RangeSeriesBaseModel("Thu", 16.1, 8.5),
                new RangeSeriesBaseModel("Fri", 12.5, 6.0),
                new RangeSeriesBaseModel("Sat", 6.9, 1.5)
            };

            RangeColumnData2 = new ObservableCollection<RangeSeriesBaseModel>
            {
                new RangeSeriesBaseModel("Sun", 9.8, 2.5),
                new RangeSeriesBaseModel("Mon", 11.4, 4.7),
                new RangeSeriesBaseModel("Tue", 14.4, 6.4),
                new RangeSeriesBaseModel("Wed", 17.2, 9.6),
                new RangeSeriesBaseModel("Thu", 15.1, 7.5),
                new RangeSeriesBaseModel("Fri", 10.5, 3.0),
                new RangeSeriesBaseModel("Sat", 7.9, 1.2)
            };
        }
    }
}