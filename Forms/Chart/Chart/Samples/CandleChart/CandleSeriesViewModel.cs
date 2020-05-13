#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System;

namespace SampleBrowser.SfChart
{
	public class CandleSeriesViewModel
	{
		public ObservableCollection<ChartDataModel> FinancialData { get; set; }

		public CandleSeriesViewModel()
		{
			FinancialData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(new DateTime(2000, 01, 17), 125, 70, 90, 115),
				new ChartDataModel(new DateTime(2000, 02, 17), 150, 60, 120, 70),
				new ChartDataModel(new DateTime(2000, 03, 17), 200, 140, 190, 160),
				new ChartDataModel(new DateTime(2000, 04, 17), 160, 90, 110, 140),
				new ChartDataModel(new DateTime(2000, 05, 17), 200, 100, 120, 180),
				new ChartDataModel(new DateTime(2000, 06, 17), 100, 45, 70, 50)
			};
		}
	}
}