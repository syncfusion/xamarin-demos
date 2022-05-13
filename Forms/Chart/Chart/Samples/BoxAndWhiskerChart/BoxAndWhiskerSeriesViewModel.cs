#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SampleBrowser.SfChart
{
    public class BoxAndWhiskerSeriesViewModel
    {
        public ObservableCollection<ChartDataModel> BoxWhiskerData { get; set; }

        public BoxAndWhiskerSeriesViewModel()
        {
            BoxWhiskerData = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("Development", new List<double> { 22, 22, 23, 25, 25, 25, 26, 27, 27, 28, 28, 29, 30, 32, 34, 32, 34, 36, 35, 38 }),
                new ChartDataModel("Testing", new List<double> { 22, 33, 23, 25, 26, 28, 29, 30, 34, 33, 32, 31, 50 }),
                new ChartDataModel("HR", new List<double> { 22, 24, 25, 30, 32, 34, 36, 38, 39, 41, 35, 36, 40, 56 }),
                new ChartDataModel("Finance", new List<double> { 26, 27, 28, 30, 32, 34, 35, 37, 35, 37, 45 }),
                new ChartDataModel("Sales", new List<double> { 26, 27, 29, 32, 34, 35, 36, 37, 38, 39, 41, 43, 58 }),
            };          
        }
    }
}