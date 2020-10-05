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
    public class StepAreaSeriesViewModel
    {
        public ObservableCollection<ChartDataModel> StepAreaData1 { get; set; }

        public ObservableCollection<ChartDataModel> StepAreaData2 { get; set; }

        public StepAreaSeriesViewModel()
        {
            StepAreaData1 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel(2000, 416),
                new ChartDataModel(2001, 490),
                new ChartDataModel(2002, 470),
                new ChartDataModel(2003, 500),
                new ChartDataModel(2004, 449),
                new ChartDataModel(2005, 470),
                new ChartDataModel(2006, 437),
                new ChartDataModel(2007, 458),
                new ChartDataModel(2008, 500),
                new ChartDataModel(2009, 473),
                new ChartDataModel(2010, 520),
                new ChartDataModel(2011, 509),
            };

            StepAreaData2 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel(2000, 180),
                new ChartDataModel(2001, 240),
                new ChartDataModel(2002, 370),
                new ChartDataModel(2003, 200),
                new ChartDataModel(2004, 229),
                new ChartDataModel(2005, 210),
                new ChartDataModel(2006, 337),
                new ChartDataModel(2007, 258),
                new ChartDataModel(2008, 300),
                new ChartDataModel(2009, 173),
                new ChartDataModel(2010, 220),
                new ChartDataModel(2011, 309),
            };
        }
    }
}