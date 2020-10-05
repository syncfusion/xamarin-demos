#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace SampleBrowser.SfChart
{
    public class WaterfallSeriesViewModel
    {
        public ObservableCollection<ChartDataModel> RevenueDetails { get; set; }

        public WaterfallSeriesViewModel()
        {
            RevenueDetails = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("Sales", 165),
                new ChartDataModel("Staff", -47),
                new ChartDataModel("Balance", 58, true),
                new ChartDataModel("Others", 15),
                new ChartDataModel("Tax", -20),
                new ChartDataModel("Profit", 45, true)
            };

            if (Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WPF)
            {
                RevenueDetails.Add(new ChartDataModel("Inventory", -10));
                RevenueDetails.Add(new ChartDataModel("Marketing", -25));
                RevenueDetails.Add(new ChartDataModel("Net Income", 25, true));
            }
        }
    }
}