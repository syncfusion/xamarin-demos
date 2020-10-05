#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;

namespace SampleBrowser.SfChart
{
    class TrackballViewModel
    {

        public ObservableCollection<ChartDataModel> LineSeries1 { get; set; }

        public ObservableCollection<ChartDataModel> LineSeries2 { get; set; }

        public ObservableCollection<ChartDataModel> LineSeries3 { get; set; }

        public TrackballViewModel()
        {

            LineSeries1 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel(new DateTime(2000, 2, 11), 15),
                new ChartDataModel(new DateTime(2000, 9, 14), 20),
                new ChartDataModel(new DateTime(2001, 2, 11), 25),
                new ChartDataModel(new DateTime(2001, 9, 16), 21),
                new ChartDataModel(new DateTime(2002, 2, 07), 13),
                new ChartDataModel(new DateTime(2002, 9, 07), 18),
                new ChartDataModel(new DateTime(2003, 2, 11), 24),
                new ChartDataModel(new DateTime(2003, 9, 14), 23),
                new ChartDataModel(new DateTime(2004, 2, 06), 19),
                new ChartDataModel(new DateTime(2004, 9, 06), 31),
                new ChartDataModel(new DateTime(2005, 2, 11), 39),
                new ChartDataModel(new DateTime(2005, 9, 11), 50),
                new ChartDataModel(new DateTime(2006, 2, 11), 24)
            };

            LineSeries2 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel(new DateTime(2000, 2, 11), 39),
                new ChartDataModel(new DateTime(2000, 9, 14), 30),
                new ChartDataModel(new DateTime(2001, 2, 11), 28),
                new ChartDataModel(new DateTime(2001, 9, 16), 35),
                new ChartDataModel(new DateTime(2002, 2, 07), 39),
                new ChartDataModel(new DateTime(2002, 9, 07), 41),
                new ChartDataModel(new DateTime(2003, 2, 11), 45),
                new ChartDataModel(new DateTime(2003, 9, 14), 48),
                new ChartDataModel(new DateTime(2004, 2, 06), 54),
                new ChartDataModel(new DateTime(2004, 9, 06), 55),
                new ChartDataModel(new DateTime(2005, 2, 11), 57),
                new ChartDataModel(new DateTime(2005, 9, 11), 60),
                new ChartDataModel(new DateTime(2006, 2, 11), 60)
            };

            LineSeries3 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel(new DateTime(2000, 2, 11), 60),
                new ChartDataModel(new DateTime(2000, 9, 14), 55),
                new ChartDataModel(new DateTime(2001, 2, 11), 48),
                new ChartDataModel(new DateTime(2001, 9, 16), 57),
                new ChartDataModel(new DateTime(2002, 2, 07), 62),
                new ChartDataModel(new DateTime(2002, 9, 07), 64),
                new ChartDataModel(new DateTime(2003, 2, 11), 57),
                new ChartDataModel(new DateTime(2003, 9, 14), 53),
                new ChartDataModel(new DateTime(2004, 2, 06), 63),
                new ChartDataModel(new DateTime(2004, 9, 06), 50),
                new ChartDataModel(new DateTime(2005, 2, 11), 66),
                new ChartDataModel(new DateTime(2005, 9, 11), 65),
                new ChartDataModel(new DateTime(2006, 2, 11), 79)
            };
        }
    }
}
