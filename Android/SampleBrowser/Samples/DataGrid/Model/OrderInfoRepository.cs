#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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
	public class OrderInfoRepository
	{
		public OrderInfoRepository ()
		{
		}

		#region private variables

		private List<DateTime> OrderedDates;
		private Random random = new Random ();

		#endregion

        #region GetOrderDetails

        public ObservableCollection<OrderInfo> GetOrderDetails(int count) {
            SetShipCity();
            this.OrderedDates = GetDateBetween(2000, 2014, count);
            ObservableCollection<OrderInfo> orderDetails = new ObservableCollection<OrderInfo>();

            for (int i = 10001; i <= count + 10000; i++) {
                var shipcountry = ShipCountry[random.Next(5)];
                var shipcitycoll = ShipCity[shipcountry];

                var ord = new OrderInfo() {
                    OrderID = i.ToString(),
                    CustomerID = CustomerID[random.Next(15)],
                    EmployeeID = random.Next(1700, 1800).ToString(),
                    FirstName = FirstNames[random.Next(15)],
                    LastName = LastNames[random.Next(15)],
                    Gender = Genders[random.Next(5)],
                    ShipCountry = ShipCountry[random.Next(5)],
                    ShippingDate = this.OrderedDates[i - 10001],
                    Freight = (Math.Round(random.Next(1000) + random.NextDouble(), 2)).ToString(),
                    IsClosed = ((i % random.Next(1, 10) > 5) ? true : false).ToString(),
                    ShipCity = shipcitycoll[random.Next(shipcitycoll.Length - 1)],
                };
                orderDetails.Add(ord);
            }
            return orderDetails;
        }

        internal OrderInfo RefreshItemsource(int i)
        {
            var ordeshipcity = ShipCity[ShipCountry[random.Next(0, 5)]];
            var order = new OrderInfo()
            {
                OrderID = i.ToString(),
                CustomerID = CustomerID[random.Next(15)],
                EmployeeID = random.Next(1700, 1800).ToString(),
                FirstName = FirstNames[random.Next(15)],
                LastName = LastNames[random.Next(15)],
                Gender = Genders[random.Next(5)],
                ShipCountry = ShipCountry[random.Next(5)],
                ShippingDate = DateTime.Now,
                Freight = (Math.Round(random.Next(1000) + random.NextDouble(), 2)).ToString(),
                IsClosed = ((i % random.Next(1, 10) > 5) ? true : false).ToString(),
                ShipCity = ordeshipcity[0],
            };
            return order;
        }

        internal OrderInfo GenerateOrder(int id)
        {
            var shipcountry = ShipCountry[random.Next(5)];
            var shipcitycoll = ShipCity[shipcountry];
            var order = new OrderInfo()
            {
                OrderID = (id + 10000).ToString(),
                EmployeeID = random.Next(1700, 1800).ToString(),
                CustomerID = CustomerID[random.Next(15)],
                IsClosed = ((id % random.Next(1, 10) > 5) ? true : false).ToString(),
                FirstName = FirstNames[random.Next(15)],
                LastName = LastNames[random.Next(15)],
                Gender = Genders[random.Next(5)],
                ShipCity = shipcitycoll[random.Next(shipcitycoll.Length - 1)],
                ShipCountry = ShipCountry[random.Next(5)],
                Freight = (Math.Round(random.Next(1000) + random.NextDouble(), 2)).ToString(),
                ShippingDate = this.OrderedDates[random.Next(15)],
            };
            return order;
        }

        #endregion

		#region MainGrid DataSource

		private List<DateTime> GetDateBetween (int startYear, int endYear, int count)
		{
			List<DateTime> date = new List<DateTime> ();
			Random d = new Random (1);
			Random m = new Random (2);
			Random y = new Random (startYear);
			for (int i = 0; i < count; i++) {
				int year = y.Next (startYear, endYear);
				int month = m.Next (3, 13);
				int day = d.Next (1, 31);

				date.Add (new DateTime (year, month, day));
			}
			return date;
		}

		string[] Genders = new string[] {
			"Male",
			"Female",
			"Female",
			"Female",
			"Male",
			"Male",
			"Male",
			"Male",
			"Male",
			"Male",
			"Male",
			"Male",
			"Female",
			"Female",
			"Female",
			"Male",
			"Male",
			"Male",
			"Female",
			"Female",
			"Female",
			"Male",
			"Male",
			"Male",
			"Male"
		};

		string[] FirstNames = new string[] {
			"Kyle",
			"Gina",
			"Irene",
			"Katie",
			"Michael",
			"Oscar",
			"Ralph",
			"Torrey",
			"William",
			"Bill",
			"Daniel",
			"Frank",
			"Brenda",
			"Danielle",
			"Fiona",
			"Howard",
			"Jack",
			"Larry",
			"Holly",
			"Jennifer",
			"Liz",
			"Pete",
			"Steve",
			"Vince",
			"Zeke"
		};

		string[] LastNames = new string[] {
			"Adams",
			"Crowley",
			"Ellis",
			"Gable",
			"Irvine",
			"Keefe",
			"Mendoza",
			"Owens",
			"Rooney",
			"Waddell",
			"Thomas",
			"Betts",
			"Doran",
			"Fitzgerald",
			"Holmes",
			"Jefferson",
			"Landry",
			"Newberry",
			"Perez",
			"Spencer",
			"Vargas",
			"Grimes",
			"Edwards",
			"Stark",
			"Cruise",
			"Fitz",
			"Chief",
			"Blanc",
			"Perry",
			"Stone",
			"Williams",
			"Lane",
			"Jobs"
		};

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
			"Switzerland",
			"UK",
			"USA",
			"Venezuela"
		};

		Dictionary<string, string[]> ShipCity = new Dictionary<string, string[]> ();

		private void SetShipCity ()
		{
			string[] argentina = new string[] { "Buenos Aires" };

			string[] austria = new string[] { "Graz", "Salzburg" };

			string[] belgium = new string[] { "Bruxelles", "Charleroi" };

			string[] brazil = new string[] { "Campinas", "Resende", "Rio de Janeiro", "São Paulo" };

			string[] canada = new string[] { "Montréal", "Tsawassen", "Vancouver" };

			string[] denmark = new string[] { "Århus", "København" };

			string[] finland = new string[] { "Helsinki", "Oulu" };

			string[] france = new string[] {
				"Lille",
				"Lyon",
				"Marseille",
				"Nantes",
				"Paris",
				"Reims",
				"Strasbourg",
				"Toulouse",
				"Versailles"
			};

			string[] germany = new string[] {
				"Aachen",
				"Berlin",
				"Brandenburg",
				"Cunewalde",
				"Frankfurt a.M.",
				"Köln",
				"Leipzig",
				"Mannheim",
				"München",
				"Münster",
				"Stuttgart"
			};

			string[] ireland = new string[] { "Cork" };

			string[] italy = new string[] { "Bergamo", "Reggio Emilia", "Torino" };

			string[] mexico = new string[] { "México D.F." };

			string[] norway = new string[] { "Stavern" };

			string[] poland = new string[] { "Warszawa" };

			string[] portugal = new string[] { "Lisboa" };

			string[] spain = new string[] { "Barcelona", "Madrid", "Sevilla" };

			string[] sweden = new string[] { "Bräcke", "Luleå" };

			string[] switzerland = new string[] { "Bern", "Genève" };

			string[] uk = new string[] { "Colchester", "Hedge End", "London" };

			string[] usa = new string[] {
				"Albuquerque",
				"Anchorage",
				"Boise",
				"Butte",
				"Elgin",
				"Eugene",
				"Kirkland",
				"Lander",
				"Portland",
				"San Francisco",
				"Seattle",
				"Walla Walla"
			};

			string[] venezuela = new string[] { "Barquisimeto", "Caracas", "I. de Margarita", "San Cristóbal" };

			ShipCity.Add ("Argentina", argentina);
			ShipCity.Add ("Austria", austria);
			ShipCity.Add ("Belgium", belgium);
			ShipCity.Add ("Brazil", brazil);
			ShipCity.Add ("Canada", canada);
			ShipCity.Add ("Denmark", denmark);
			ShipCity.Add ("Finland", finland);
			ShipCity.Add ("France", france);
			ShipCity.Add ("Germany", germany);
			ShipCity.Add ("Ireland", ireland);
			ShipCity.Add ("Italy", italy);
			ShipCity.Add ("Mexico", mexico);
			ShipCity.Add ("Norway", norway);
			ShipCity.Add ("Poland", poland);
			ShipCity.Add ("Portugal", portugal);
			ShipCity.Add ("Spain", spain);
			ShipCity.Add ("Sweden", sweden);
			ShipCity.Add ("Switzerland", switzerland);
			ShipCity.Add ("UK", uk);
			ShipCity.Add ("USA", usa);
			ShipCity.Add ("Venezuela", venezuela);
		}

		#endregion

	}
}

