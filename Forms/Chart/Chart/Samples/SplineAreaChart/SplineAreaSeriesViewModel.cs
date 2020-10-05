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
    public class SplineAreaSeriesViewModel
    {
        public ObservableCollection<ChartDataModel> SplineAreaData1 { get; set; }

        public ObservableCollection<ChartDataModel> SplineAreaData2 { get; set; }

        public ObservableCollection<ChartDataModel> SplineAreaData3 { get; set; }

        public SplineAreaSeriesViewModel()
        {
            SplineAreaData1 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel(2002, 2.2),
                new ChartDataModel(2003, 3.4),
                new ChartDataModel(2004, 2.8),
                new ChartDataModel(2005, 1.6),
                new ChartDataModel(2006, 2.3),
                new ChartDataModel(2007, 2.5),
                new ChartDataModel(2008, 2.9),
                new ChartDataModel(2009, 3.8),
                new ChartDataModel(2010, 1.4),
                new ChartDataModel(2011, 3.1),
            };

            SplineAreaData2 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel(2002, 2.0),
                new ChartDataModel(2003, 1.7),
                new ChartDataModel(2004, 1.8),
                new ChartDataModel(2005, 2.1),
                new ChartDataModel(2006, 2.3),
                new ChartDataModel(2007, 1.7),
                new ChartDataModel(2008, 1.5),
                new ChartDataModel(2009, 2.8),
                new ChartDataModel(2010, 1.5),
                new ChartDataModel(2011, 2.3),

            };

            SplineAreaData3 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel(2002, 0.8),
                new ChartDataModel(2003, 1.3),
                new ChartDataModel(2004, 1.1),
                new ChartDataModel(2005, 1.6),
                new ChartDataModel(2006, 2.0),
                new ChartDataModel(2007, 1.7),
                new ChartDataModel(2008, 2.3),
                new ChartDataModel(2009, 2.7),
                new ChartDataModel(2010, 1.1),
                new ChartDataModel(2011, 2.3),
            };
        }
    }
}
