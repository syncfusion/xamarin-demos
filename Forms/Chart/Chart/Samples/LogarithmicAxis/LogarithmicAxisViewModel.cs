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
    public class LogarithmicAxisViewModel
    {
        public ObservableCollection<ChartDataModel> LogarithmicData { get; set; }

        public LogarithmicAxisViewModel()
        {
            LogarithmicData = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("1995", 80   ),
                new ChartDataModel("1996", 200  ),
                new ChartDataModel("1997", 400  ),
                new ChartDataModel("1998", 600  ),
                new ChartDataModel("1999", 700  ),
                new ChartDataModel("2000", 1400 ),
                new ChartDataModel("2001", 2000 ),
                new ChartDataModel("2002", 4000 ),
                new ChartDataModel("2003", 6000 ),
                new ChartDataModel("2004", 8000 ),
                new ChartDataModel("2005", 11000)
            };
        }
    }
}
