#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
        public ObservableCollection<ChartDataModel> CategoryData { get; set; }

        public CategoryAxisViewModel()
        {
            CategoryData = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("South Korea", 39),
                new ChartDataModel("India", 20),
                new ChartDataModel("South Africa", 61),
                new ChartDataModel("China", 65),
                new ChartDataModel("France", 45),
                new ChartDataModel("Saudi Arabia", 10),
                new ChartDataModel("Japan", 16),
                new ChartDataModel("Mexico", 31)
            };
        }
    }
}
