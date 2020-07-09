#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace SampleBrowser.SfChart
{
	public class RangeSeriesBaseModel
	{
		public string Name { get; set; }

		public double High { get; set; }

		public double Low { get; set; }

		public RangeSeriesBaseModel(string name, double high, double low)
		{
			Name = name;
			High = high;
			Low = low;
		}
	}
}