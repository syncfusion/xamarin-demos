#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
                new ChartDataModel("GER", 72),
                new ChartDataModel("RUS", 103.1),
                new ChartDataModel("BRZ", 139.1),
                new ChartDataModel("IND", 462.1),
                new ChartDataModel("CHN", 721.4),
                new ChartDataModel("USA", 286.9),
                new ChartDataModel("GBR", 115.1),
                new ChartDataModel("NGR", 97.2)
            };
        }
    }
}
