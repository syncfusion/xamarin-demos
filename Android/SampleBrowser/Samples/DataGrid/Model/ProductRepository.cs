#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SampleBrowser
{
	public class ProductRepository
	{
		public ProductRepository ()
		{
		}

		#region private variables

		private Random random = new Random ();

		#endregion

		#region GetOrderDetails

		public ObservableCollection<Products> GetProductDetails (int count)
		{
            ObservableCollection<Products> productDetails = new ObservableCollection<Products>();

			for (int i = 1; i <= count; i++) {
                var ord = new Products()
                {
                    SupplierID = i,
                    ProductID = ProductID[random.Next(15)],
                    ProductName = ProductNames[random.Next(15)],
                    Quantity = random.Next(1, 20),
                    UnitPrice = random.Next(70, 200),
                    UnitsInStock = random.Next(3, 12),
                };
                ord.Discount = ord.Quantity + "%";
				productDetails.Add (ord);
			}
			return productDetails;
		}

        #endregion

        #region MainGrid DataSource

        string[] ProductNames = new string[] {
			"Alice Mutton",
			"Anished Syrup",
			"Crab Meat",
			"Camembert",
			"Carnarvon Tigers",
			"Chai",
			"Chang",
			"Chartreuse",
			"Cajun",
			"Gumb",
			"Chocolate",
			"Cote de Blaye",
			"Gravad lax",
			"Filo Mix",
			"Geitost",
			"Flotemysost",
			"Ikura",
			"Longlife Tofu",
			"Maxilaku",
			"Mishi Kobe Niku",
			"Ipoh Coffee",
			"Konbu",
			"Inlagd Sill",
			"Pavlova",
			"Queso Cabrales"
		};

		int[] ProductID = new int[] {
			1803,
			1345,
			4523,
			4932,
			9475,
			5243,
			4263,
			2435,
			3527,
			3634,
			2523,
			3652,
			3524,
			6532,
			2123
		};

		#endregion
	}
}

