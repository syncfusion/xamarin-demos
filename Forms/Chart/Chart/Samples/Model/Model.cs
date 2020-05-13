#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

namespace SampleBrowser.SfChart
{
    public class ChartDataModel
    {
        public string Name { get; set; }

        public string Label { get; set; }
        public DateTime Date { get; set; }

        public double Value { get; set; }

 		public double Value1 { get; set; }

        public double Size { get; set; }

        public double High { get; set; }

        public double Low { get; set; }
          
        public bool IsSummary { get; set; }

        public ChartDataModel(string name, double value)
        {
            Name = name;
            Value = value;
        }

        public ChartDataModel(string name, double value, double size)
        {
            Name = name;
            Value = value;
            Size = size;
        }
	
		public ChartDataModel(double value, double value1, double size)
        {
            Value1 = value;
            Value = value1;
            Size = size;
        }

        public ChartDataModel(double value1, double value, double size, string label)
        {
            Value1 = value1;
            Value = value;
            Size = size;
            Label = label;
        }

        public ChartDataModel(string name, double high, double low, double open, double close)
        {
            Name = name;
            High = high;
            Low = low;
            Value = open;
            Size = close;
        }
		public ChartDataModel(DateTime date, double high, double low, double open, double close)
        {
            Date = date;
            High = high;
            Low = low;
            Value = open;
            Size = close;
        }
        public ChartDataModel(double value, double size)
        {
            Value = value;
            Size = size;
        }

        public ChartDataModel(DateTime dateTime, double value)
        {
            Date = dateTime;
            Value = value;
        }

        public ChartDataModel(string name, double value, bool isSummary)
        {
            Name = name;
            Value = value;
            IsSummary = isSummary;
        }
    }
}