#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
namespace SampleBrowser
{
	public class ChartDataModel
	{
		public IComparable XValue { get; set; }

		public double YValue { get; set; }

		public double Open { get; set; }

		public double Close { get; set; }

		public double Size { get; set; }

		public double High { get; set; }

		public double Low { get; set; }

		public double Volume { get; set; }

		public ChartDataModel()
		{
		}

		public ChartDataModel(IComparable xValue, double yValue)
		{
			XValue = xValue;
			YValue = yValue;
		}

		public ChartDataModel(IComparable xValue, double value1, double value2)
		{
			XValue = xValue;
			High = value1;
			YValue = value1;
			Low = value2;
			Size = value2;
		}

		public ChartDataModel(IComparable xValue, double open, double high, double low, double close)
		{
			XValue = xValue;
			High = high;
			Low = low;
			Open = open;
			Close = close;
		}

		public ChartDataModel(IComparable xValue, double open, double high, double low, double close, double volume)
		{
			XValue = xValue;
			High = high;
			Low = low;
			Open = open;
			Close = close;
			Volume = volume;
		}
	}
}
