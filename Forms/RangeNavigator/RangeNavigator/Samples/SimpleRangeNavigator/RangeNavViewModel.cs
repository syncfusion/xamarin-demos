#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfRangeNavigator
{
    [Preserve(AllMembers = true)]
	public class RangeNavViewModel
	{
		public ObservableCollection<ChartDataPoint> DateTimeRangeData { get; set; }

		public RangeNavViewModel()
		{
			DateTimeRangeData = new ObservableCollection<ChartDataPoint>
			{
				new ChartDataPoint(new DateTime(2015, 01, 1), 14),
				new ChartDataPoint(new DateTime(2015, 02, 1), 54),
				new ChartDataPoint(new DateTime(2015, 03, 1), 23),
				new ChartDataPoint(new DateTime(2015, 04, 1), 53),
				new ChartDataPoint(new DateTime(2015, 05, 1), 25),
				new ChartDataPoint(new DateTime(2015, 06, 1), 32),
				new ChartDataPoint(new DateTime(2015, 07, 1), 78),
				new ChartDataPoint(new DateTime(2015, 08, 1), 100),
				new ChartDataPoint(new DateTime(2015, 09, 1), 55),
				new ChartDataPoint(new DateTime(2015, 10, 1), 38),
				new ChartDataPoint(new DateTime(2015, 11, 1), 27),
				new ChartDataPoint(new DateTime(2015, 12, 1), 56),
				new ChartDataPoint(new DateTime(2015, 12, 31), 35)
			};
		}
	}
}