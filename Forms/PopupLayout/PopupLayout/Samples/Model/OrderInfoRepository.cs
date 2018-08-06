#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfPopupLayout
{
    [Preserve(AllMembers = true)]
    public class OrderInfoRepository
	{
		public OrderInfoRepository ()
		{
		}

		#region private variables

		private Random random = new Random ();

		#endregion

		#region GetOrderDetails

		public ObservableCollection<OrderInfo> GetOrderDetails (int count)
		{
			ObservableCollection<OrderInfo> orderDetails = new ObservableCollection<OrderInfo> ();

			for (int i = 10001; i <= count + 10000; i++)
            {
				var ord = new OrderInfo () {
					OrderID = i.ToString (),
					CustomerID = CustomerID [random.Next (15)],
					EmployeeID = random.Next (1700, 1800).ToString (),
                    ShipCountry = ShipCountry[random.Next(5)]
            };
				orderDetails.Add (ord);
			}
			return orderDetails;
		}

		#endregion

		#region MainGrid DataSource

		string[] CustomerID = new string[] {
			"Alfki",
			"Frans",
			"Merep",
			"Folko",
			"Simob",
			"Warth",
			"Vaffe",
			"Furib",
			"Seves",
			"Linod",
			"Riscu",
			"Picco",
			"Blonp",
			"Welli",
			"Folig"
		};

		string[] ShipCountry = new string[] {

			"Argentina",
			"Austria",
			"Belgium",
			"Brazil",            
			"Canada",
			"Denmark",
			"Finland",
			"France",
			"Germany",
			"Ireland",
			"Italy",
			"Mexico",
			"Norway",
			"Poland",
			"Portugal",
			"Spain",
			"Sweden",
			"UK",
			"USA",
		};
		#endregion

	}
}

