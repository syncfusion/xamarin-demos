#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Collections.ObjectModel;

namespace SampleBrowser
{
    public class CustomersRepository
	{
		#region Fields

		private Random random = new Random ();

		#endregion

        #region Constructor

        public CustomersRepository ()
		{
		}

        #endregion

        #region GetOrderDetails

        public ObservableCollection<CustomerDetails> GetCutomerDetails (int count)
		{
			SetCity ();
            ObservableCollection<CustomerDetails> orderDetails = new ObservableCollection<CustomerDetails>();

			for (int i = 10001; i <= count + 10000; i++) {
				var country = Country [random.Next (5)];
				var citycoll = City [country];

                var ord = new CustomerDetails()
                {
					CustomerID = CustomerID [random.Next (15)],
					FirstName = FirstNames [random.Next (15)],
					LastName = LastNames [random.Next (15)],
					Gender = Genders [random.Next (5)],
					Country = Country [random.Next (5)],
					City = citycoll [random.Next (citycoll.Length - 1)],
				};
				orderDetails.Add (ord);
			}
			return orderDetails;
		}

		#endregion

		#region MainGrid DataSource

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

		string[] Country = new string[] {

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

		Dictionary<string, string[]> City = new Dictionary<string, string[]> (); 

		private void SetCity ()
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

			City.Add ("Argentina", argentina);
			City.Add ("Austria", austria);
			City.Add ("Belgium", belgium);
			City.Add ("Brazil", brazil);
			City.Add ("Canada", canada);
			City.Add ("Denmark", denmark);
			City.Add ("Finland", finland);
			City.Add ("France", france);
			City.Add ("Germany", germany);
			City.Add ("Ireland", ireland);
			City.Add ("Italy", italy);
			City.Add ("Mexico", mexico);
			City.Add ("Norway", norway);
			City.Add ("Poland", poland);
			City.Add ("Portugal", portugal);
			City.Add ("Spain", spain);
			City.Add ("Sweden", sweden);
			City.Add ("Switzerland", switzerland);
			City.Add ("UK", uk);
			City.Add ("USA", usa);
			City.Add ("Venezuela", venezuela);
		}

		#endregion
	}
}