#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.Data;
using System.Globalization;
using System.ComponentModel;

namespace SampleBrowser
{
    public class CustomerInfo : IComparer<Object>, ISortDirection
	{
		public int Compare(object x, object y)
		{
			int namX;
			int namY;

			//For Customers Type data
			if (x.GetType() == typeof(CustomerDetails))
			{
				//Calculating the length of CustomerName if the object type is Customers
				namX = ((CustomerDetails)x).FirstName.Length;
				namY = ((CustomerDetails)y). FirstName.Length;
			}

			//For Group type Data                                   
			else if (x.GetType() == typeof(Syncfusion.Data.Group))
			{
				//Calculating the group key length
                namX = ((Syncfusion.Data.Group)x).Key.ToString().Length;
                namY = ((Syncfusion.Data.Group)y).Key.ToString().Length;
			}
			else
			{
				namX = x.ToString().Length;
				namY = y.ToString().Length;
			}

			// Objects are compared and return the SortDirection
			if (namX.CompareTo(namY) > 0)
				return SortDirection == ListSortDirection.Ascending ? 1 : -1;
			else if (namX.CompareTo(namY) == -1)
				return SortDirection == ListSortDirection.Ascending ? -1 : 1;
			else
				return 0; 
		}

		//Get or Set the SortDirection value
		private ListSortDirection _SortDirection; 
		public ListSortDirection SortDirection
		{
			get  {   return _SortDirection;  }
			set  {  _SortDirection = value;    }
		}
	}

	public class CustomSortComparer : IComparer<object>, ISortDirection
	{
		public ListSortDirection SortDirection { get; set; }
		public Comparer _comparer;
		public CustomSortComparer()
		{
			this._comparer = Comparer.Default;
		}

		private double ConverKeyToDouble(string Key)
		{
			if (Key.Equals("TOTAL SALE LESS THAN 100K"))
				return 0;
			else if (Key.Equals("TOTAL SALE GREATER THAN 100K LESS THAN 500K"))
				return 1;
			else if (Key.Equals("TOTAL SALE GREATER THAN 500K LESS THAN 1 MILLION"))
				return 2;
			else if (Key.Equals("TOTAL SALE GREATER THAN 1 MILLION LESS THAN 5 MILLION"))
				return 3;
			else if (Key.Equals("TOTAL SALE GREATER THAN 5 MILLION"))
				return 4;
			else if (Key.Equals("TOTAL SALE GREATER THAN 2 MILLION LESS THAN 5 MILLION"))
				return 5;
			return 0;
		}
		public int Compare(object x, object y)
		{
			double namX;
			double namY;
			if (x.GetType() == typeof(SalesByDate))
			{
				namX = ((SalesByDate)x).Total;
				namY = ((SalesByDate)y).Total;
			}
			else if (x.GetType() == typeof(Syncfusion.Data.Group))
			{
				namX = ConverKeyToDouble((string)((Syncfusion.Data.Group)x).Key);
				namY = ConverKeyToDouble((string)((Syncfusion.Data.Group)y).Key);
			}
			else
			{
				namX = (double) x;
				namY = (double) y;
			}

			// Objects are compared and return the SortDirection
			if (namX > namY)
				return SortDirection == ListSortDirection.Ascending ? 1 : -1;
			else 
				return SortDirection == ListSortDirection.Ascending ? -1 : 1;

		}
	}

	public class GroupDataTimeConverter : IValueConverter
	{
		public GroupDataTimeConverter()
		{

		}
		public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
		{
			var saleinfo = value as SalesByDate;
			if (saleinfo.Total > 100000 &&  saleinfo.Total < 500000)
				return "TOTAL SALE GREATER THAN 100K LESS THAN 500K";
			else if (saleinfo.Total > 1000000 && saleinfo.Total < 5000000)
				return "TOTAL SALE GREATER THAN 1 MILLION LESS THAN 5 MILLION";
			else if (saleinfo.Total > 500000 && saleinfo.Total <1000000)
				return "TOTAL SALE GREATER THAN 500K LESS THAN 1 MILLION";
			else if (saleinfo.Total > 5000000)
				return "TOTAL SALE GREATER THAN 5 MILLION";
			else if(saleinfo.Total > 2000000 && saleinfo.Total < 5000000)
				return "TOTAL SALE GREATER THAN 2 MILLION LESS THAN 5 MILLION";
			else
				return "TOTAL SALE LESS THAN 100K";
		}

		public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
		{
			throw new System.NotImplementedException();
		}
	}
}