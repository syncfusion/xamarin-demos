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
    public class RangeBarViewModel
    {
        public ObservableCollection<ChartDataModel> RangeBarData { get; set; }

        public RangeBarViewModel()
        {
            RangeBarData = new ObservableCollection<ChartDataModel>()
            {
                new ChartDataModel("Jumbo", 70238),
                new ChartDataModel("FHA", 99595),
                new ChartDataModel("VA", 156398),
                new ChartDataModel("USDA", 256396),
                new ChartDataModel("Const", 356398),
                new ChartDataModel("Total", 459937)
            };
        }
    }
}