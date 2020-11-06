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
	public class DataPointSelectionViewModel
	{
		public ObservableCollection<ChartDataModel> SelectionData { get; set; }

        public ObservableCollection<ChartDataModel> SelectionData1 { get; set; }

        public DataPointSelectionViewModel()
		{
			SelectionData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Jan", 60),
				new ChartDataModel("Feb", 80),
				new ChartDataModel("Mar", 70),
				new ChartDataModel("Apr", 90)
			};

            SelectionData1 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("Jan", 50),
                new ChartDataModel("Feb", 70),
                new ChartDataModel("Mar", 80),
                new ChartDataModel("Apr", 70)
            };
        }
	}
}