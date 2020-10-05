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
    public class PyramidSeriesViewModel
    {
        public ObservableCollection<ChartDataModel> PyramidData { get; set; }

        public PyramidSeriesViewModel()
        {
            PyramidData = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("Sweet Treats", 120),
                new ChartDataModel("Milk, Youghnut, Cheese", 435),
                new ChartDataModel("Vegetables", 470),
                new ChartDataModel("Meat, Poultry, Fish", 475),
                new ChartDataModel("Fruits", 520),
                new ChartDataModel("Bread, Rice, Pasta", 930),
           };
        }
    }
}