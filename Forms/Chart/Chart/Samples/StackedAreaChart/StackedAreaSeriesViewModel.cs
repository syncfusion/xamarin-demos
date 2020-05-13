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
    public class StackedAreaSeriesViewModel
    {
        public ObservableCollection<ChartDataModel> StackedAreaData1 { get; set; }

        public ObservableCollection<ChartDataModel> StackedAreaData2 { get; set; }

        public ObservableCollection<ChartDataModel> StackedAreaData3 { get; set; }

        public ObservableCollection<ChartDataModel> StackedAreaData4 { get; set; }

        public StackedAreaSeriesViewModel()
        {
            StackedAreaData1 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("2000", 0.61),
                new ChartDataModel("2001", 0.81),
                new ChartDataModel("2002", 0.91),
                new ChartDataModel("2003", 1),
                new ChartDataModel("2004", 1.19),
                new ChartDataModel("2005", 1.47),
                new ChartDataModel("2006", 1.74),
                new ChartDataModel("2007", 1.98),
                new ChartDataModel("2008", 1.99),
                new ChartDataModel("2009", 1.70),
                new ChartDataModel("2010", 1.48),
                new ChartDataModel("2011", 1.38),
                new ChartDataModel("2012", 1.66),
                new ChartDataModel("2013", 1.66),
                new ChartDataModel("2014", 1.67),
            };

            StackedAreaData2 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("2000", 0.03),
                new ChartDataModel("2001", 0.05),
                new ChartDataModel("2002", 0.06),
                new ChartDataModel("2003", 0.09),
                new ChartDataModel("2004", 0.14),
                new ChartDataModel("2005", 0.20),
                new ChartDataModel("2006", 0.29),
                new ChartDataModel("2007", 0.46),
                new ChartDataModel("2008", 0.64),
                new ChartDataModel("2009", 0.75),
                new ChartDataModel("2010", 1.06),
                new ChartDataModel("2011", 1.25),
                new ChartDataModel("2012", 1.55),
                new ChartDataModel("2013", 1.55),
                new ChartDataModel("2014", 1.65),
            };
            StackedAreaData3 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("2000", 0.48),
                new ChartDataModel("2001", 0.53),
                new ChartDataModel("2002", 0.57),
                new ChartDataModel("2003", 0.61),
                new ChartDataModel("2004", 0.63),
                new ChartDataModel("2005", 0.64),
                new ChartDataModel("2006", 0.66),
                new ChartDataModel("2007", 0.76),
                new ChartDataModel("2008", 0.77),
                new ChartDataModel("2009", 0.55),
                new ChartDataModel("2010", 0.54),
                new ChartDataModel("2011", 0.57),
                new ChartDataModel("2012", 0.61),
                new ChartDataModel("2013", 0.67),
                new ChartDataModel("2014", 0.67),
            };

            StackedAreaData4 = new ObservableCollection<ChartDataModel>
            {
               new ChartDataModel("2000", 0.23),
                new ChartDataModel("2001", 0.17),
                new ChartDataModel("2002", 0.17),
                new ChartDataModel("2003", 0.20),
                new ChartDataModel("2004", 0.23),
                new ChartDataModel("2005", 0.36),
                new ChartDataModel("2006", 0.43),
                new ChartDataModel("2007", 0.52),
                new ChartDataModel("2008", 0.72),
                new ChartDataModel("2009", 1.29),
                new ChartDataModel("2010", 1.38),
                new ChartDataModel("2011", 1.82),
                new ChartDataModel("2012", 2.16),
                new ChartDataModel("2013", 2.51),
                new ChartDataModel("2014", 2.61),
            };
        }
    }
}
