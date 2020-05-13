#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;
using Foundation;

namespace SampleBrowser
{
	public class ChartDataModel : INotifyPropertyChanged
	{
		IComparable xValue;
		public IComparable XValue 
		{
			get
			{
				return xValue;
			}
			set
			{
				xValue = value;
				OnPropertyChanged("XValue");
			}
		}

		NSDate date;
        public NSDate Date
		{
			get
			{
				return date;
			}
			set
			{
				date = value;
				OnPropertyChanged("Date");
			}
		}


		double yValue;
		public double YValue
		{ 
			get
			{
				return yValue;	
			}
			set
			{
				yValue = value;
				OnPropertyChanged("YValue");
			}
		
		}

		string label;
		public string Label
        {
            get
            {
				return label;
            }
            set
            {
				label = value;
				OnPropertyChanged("Label");
            }

        }

		double open;
		public double Open 
		{
			get
			{
				return open;
			}
			set
			{
				open = value;
				OnPropertyChanged("Open");
			}
		}

		double close;
		public double Close 
		{
			get
			{
				return close;
			}
			set
			{
				close = value;
				OnPropertyChanged("Close");
			}			
		}

		double size;
		public double Size 
		{
			get
			{
				return size;
			}
			set
			{
				size = value;
				OnPropertyChanged("Size");
			}
		}

		double high;
		public double High 
		{
			get
			{
				return high;
			}
			set
			{
				high = value;
				OnPropertyChanged("High");
			}
		}

		double low;
		public double Low 
		{
			get
			{
				return low;
			}
			set
			{
				low = value;
				OnPropertyChanged("Low");
			}
		}

		double volume;
		public double Volume
		{
			get
			{
				return volume;
			}
			set
			{
				volume = value;
				OnPropertyChanged("Volume");
			}
		}

		public string Image
		{
			get;
			set;
		}

		public ChartDataModel(string xValue, double yValue, string image)
		{
			XValue = xValue;
			YValue = yValue;
			Image = image;
		}

		public ChartDataModel()
		{
		}

		public ChartDataModel(IComparable xValue, double yValue)
		{
			XValue = xValue;
			YValue = yValue;
		}

        public ChartDataModel(NSDate xValue, double yValue)
		{
            Date = xValue;
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

		public ChartDataModel(IComparable xValue, double value1, double value2 , string label)
        {
            XValue = xValue;
            High = value1;
            YValue = value1;
            Low = value2;
            Size = value2;
			Label = label;
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

		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		public event PropertyChangedEventHandler PropertyChanged;

	}
}
