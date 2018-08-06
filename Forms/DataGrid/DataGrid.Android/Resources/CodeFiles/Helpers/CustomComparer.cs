#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Syncfusion.Data;
using Xamarin.Forms;

namespace SampleBrowser.SfDataGrid
{
    public class CustomSortComparer : IComparer<object>, ISortDirection
    {
        public Syncfusion.Data.ListSortDirection SortDirection { get; set; }

        public CustomSortComparer()
        {
        }

		private double ConverKeyToDouble(string Key)
		{
			if (Key.Equals("<1 K"))
				return 0;
            else if (Key.Equals(">1 K and <5 K"))
				return 1;
            else if (Key.Equals(">5 K and <10 K"))
				return 2;
            else if (Key.Equals(">10 K and <50 K"))
				return 3;
            else if (Key.Equals(">50 K"))
				return 4;
            else if (Key.Equals(">20 K and <50 K"))
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
            else if (x.GetType() == typeof(Group))
            {
				namX = ConverKeyToDouble((string)((Group)x).Key);
				namY = ConverKeyToDouble((string)((Group)y).Key);
            }
			else
			{
				namX = (double) x;
				namY = (double) y;
			}

			// Objects are compared and return the SortDirection
			if (namX > namY)
				return SortDirection == Syncfusion.Data.ListSortDirection.Ascending ? 1 : -1;
			else 
				return SortDirection == Syncfusion.Data.ListSortDirection.Ascending ? -1 : 1;
		
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
			if (saleinfo.Total > 1000 &&  saleinfo.Total < 5000)
                return ">1 K and <5 K";
			else if (saleinfo.Total > 5000 && saleinfo.Total <10000)
                return ">5 K and <10 K";
            else if (saleinfo.Total > 10000 && saleinfo.Total < 50000)
                return ">10 K and <50 K";
            else if (saleinfo.Total > 20000 && saleinfo.Total < 50000)
                return ">20 K and <50 K";
			else if (saleinfo.Total > 50000)
                return ">50 K";			
			else
                return "<1 K";
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }

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
			else if (x.GetType() == typeof(Group))
			{
				//Calculating the group key length
				namX = ((Group)x).Key.ToString().Length;
				namY = ((Group)y).Key.ToString().Length;
			}
			else
			{
				namX = x.ToString().Length;
				namY = y.ToString().Length;
			}

			// Objects are compared and return the SortDirection
			if (namX.CompareTo(namY) > 0)
				return SortDirection == Syncfusion.Data.ListSortDirection.Ascending ? 1 : -1;
			else if (namX.CompareTo(namY) == -1)
				return SortDirection == Syncfusion.Data.ListSortDirection.Ascending ? -1 : 1;
			else
				return 0; 
		}

		//Get or Set the SortDirection value
		private Syncfusion.Data.ListSortDirection _SortDirection; 
		public Syncfusion.Data.ListSortDirection SortDirection
		{
			get  {   return _SortDirection;  }
			set  {  _SortDirection = value;    }
		}
	}

	internal class ChangeBackgroundConverter : IValueConverter
	{
		object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo info)
		{
			var data = value as double?;
			if (data != null && data > 0)
				return Color.Green;
			else
				return Color.Red;
		}

		object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo info)
		{
			throw new NotImplementedException();
		}
	}

	internal class ChangeForegroundConverter : IValueConverter
	{
		object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo info)
		{
			var data = value as double?;
			if (data != null && data > 10)
				return Color.Green;
			else
				return Color.Red;
		}

		object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo info)
		{
			throw new NotImplementedException();
		}
	}
}
