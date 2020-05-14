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
	public class StripLinesViewModel
	{
		public ObservableCollection<ChartDataModel> StripLineData { get; set; }

		public StripLinesViewModel()
		{

			StripLineData = new ObservableCollection<ChartDataModel>
			{
				 new ChartDataModel("Sun", 26),
				 new ChartDataModel("Mon", 24),
				 new ChartDataModel("Tue", 31),
				 new ChartDataModel("Wed", 28),
				 new ChartDataModel("Thu", 30),
				 new ChartDataModel("Fri", 26),
				 new ChartDataModel("Sat", 30)
			};
		}
	}
}