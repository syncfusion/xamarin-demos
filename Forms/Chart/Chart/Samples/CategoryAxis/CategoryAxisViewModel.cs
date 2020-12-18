#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace SampleBrowser.SfChart
{
    public class CategoryAxisViewModel
    {
        public ObservableCollection<ChartDataModel> CategoryData1 { get; set; }

        public ObservableCollection<ChartDataModel> CategoryData2 { get; set; }

        public CategoryAxisViewModel()
        {
            CategoryData1 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("South Korea", 39),
                new ChartDataModel("India", 20),
                new ChartDataModel("China", 65),
            };

            CategoryData2 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("France", 45),
                new ChartDataModel("Italy", 16),
                new ChartDataModel("United Kingdom", 31)
            };
        }
    }
}
