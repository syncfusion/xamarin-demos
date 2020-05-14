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
	public class SemiPieSeriesViewModel
	{
		public ObservableCollection<ChartDataModel> SemiCircularData { get; set; }

		public SemiPieSeriesViewModel()
		{
			SemiCircularData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Product A", 14),
				new ChartDataModel("Product B", 54),
				new ChartDataModel("Product C", 23),
				new ChartDataModel("Product D", 53)
			};
		}
	}
}