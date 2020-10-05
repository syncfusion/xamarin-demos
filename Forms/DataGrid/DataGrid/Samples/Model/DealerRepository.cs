#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "DealerRepository.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfDataGrid
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    ///  A class Used to store the values 
    /// </summary>
    public class DealerRepository
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed")]
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Some fields must be public")]
        public string[] CustomersMale = new string[]
      {
            "Adams",
            "Owens",
            "Thomas",
            "Doran",
            "Jefferson",
            "Spencer",
            "Vargas",
            "Grimes",
            "Edwards",
            "Stark",
            "Cruise",
            "Fitz",
            "Chief",
            "Blanc",
            "Stone",
            "Williams",
            "Jobs",
            "Holmes"
      };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed")]
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Some fields must be public")]
        public string[] CustomersFemale = new string[]
        {
            "Crowley",
            "Waddell",
            "Irvine",
            "Keefe",
            "Ellis",
            "Gable",
            "Mendoza",
            "Rooney",
            "Lane",
            "Landry",
            "Perry",
            "Perez",
            "Newberry",
            "Betts",
            "Fitzgerald",
        };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed")]
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Some fields must be public")]
        public string[] Customers = new string[]
        {
            "Adams",
            "Owens",
            "Thomas",
            "Doran",
            "Jefferson",
            "Spencer",
            "Vargas",
            "Grimes",
            "Edwards",
            "Stark",
            "Cruise",
            "Fitz",
            "Chief",
            "Blanc",
            "Stone",
            "Williams",
            "Jobs",
            "Holmes",
            "Crowley",
            "Waddell",
            "Irvine",
            "Keefe",
            "Ellis",
            "Gable",
            "Mendoza",
            "Rooney",
            "Lane",
            "Landry",
            "Perry",
            "Perez",
            "Newberry",
            "Betts",
            "Fitzgerald",
        };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed")]
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Some fields must be public")]
        public string[] ImageMale = new string[]
        {
         "People_Circle5.png",
         "People_Circle8.png",
         "People_Circle12.png",
         "People_Circle14.png",
         "People_Circle18.png",
         "People_Circle23.png",
         "People_Circle26.png",
         "People_Circle27.png",
        };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed")]
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Some fields must be public")]
        public string[] ImageFemale = new string[]
        {
           "People_Circle0.png",
           "People_Circle1.png",
           "People_Circle2.png",
           "People_Circle3.png",
           "People_Circle4.png",
           "People_Circle6.png",
           "People_Circle7.png",
           "People_Circle9.png",
           "People_Circle10.png",
           "People_Circle11.png",
           "People_Circle13.png",
           "People_Circle15.png",
           "People_Circle16.png",
           "People_Circle17.png",
           "People_Circle19.png",
           "People_Circle20.png",
           "People_Circle21.png",
           "People_Circle22.png",
           "People_Circle24.png",
            "People_Circle25.png",
        };

        #region private variables

        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed. Suppression is OK here.This field is used in outside this class")]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        internal Dictionary<string, string[]> ShipCity = new Dictionary<string, string[]>();
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Random random = new Random();
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private List<DateTime> shippedDate;

        #endregion

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int[] productNo = new int[]
        {
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

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string[] shipCountry = new string[]
        {
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

        #region GetDealerDetails

        /// <summary>
        /// Generates record rows with given count
        /// </summary>
        /// <param name="count">generates row count</param>
        /// <returns>generated row records</returns>
        public ObservableCollection<DealerInfo> GetDealerDetails(int count)
        {
            ObservableCollection<DealerInfo> dealerDetails = new ObservableCollection<DealerInfo>();
            var assembly = Assembly.GetAssembly(this.GetType());
            this.SetShipCity();
            this.shippedDate = this.GetDateBetween(2001, 2016, count);
            for (int i = 1; i <= count; i++)
            {
                var shipcountry = this.shipCountry[this.random.Next(5)];
                var shipcitycoll = this.ShipCity[shipcountry];
                var ord = new DealerInfo()
                {
                    ProductID = 1100 + i,
                    ProductNo = this.productNo[this.random.Next(15)],
                    DealerName = (i % 2 == 0) ? this.CustomersMale[this.random.Next(15)] : this.CustomersFemale[this.random.Next(14)],
                    ProductPrice = this.random.Next(2000, 10000),
                    IsOnline = (i % this.random.Next(1, 10) > 2) ? true : false,
                    DealerImage = (i % 2 == 0) ? this.ImageMale[this.random.Next(7)] : this.ImageFemale[this.random.Next(15)],
                    ShippedDate = this.shippedDate[i - 1],
                    ShipCountry = shipcountry,
                    ShipCity = shipcitycoll[this.random.Next(shipcitycoll.Length - 1)],
                };
                dealerDetails.Add(ord);
            }

            return dealerDetails;
        }

        #endregion

        /// <summary>
        /// Used to generate DateTime and returns the value
        /// </summary>
        /// <param name="startYear">integer type of parameter startYear</param>
        /// <param name="endYear">integer type of parameter endYear</param>
        /// <param name="count">integer type of parameter count</param>
        /// <returns>returns the generated DateTime</returns>
        private List<DateTime> GetDateBetween(int startYear, int endYear, int count)
        {
            List<DateTime> date = new List<DateTime>();
            Random d = new Random(1);
            Random m = new Random(2);
            Random y = new Random(startYear);
            for (int i = 0; i < count; i++)
            {
                int year = y.Next(startYear, endYear);
                int month = m.Next(3, 13);
                int day = d.Next(1, 31);

                date.Add(new DateTime(year, month, day));
            }

            return date;
        }

        /// <summary>
        /// This method used to store the string items collections Value
        /// </summary>
        private void SetShipCity()
        {
            string[] argentina = new string[]
            {
                "Rosario",
                "Catamarca",
                "Formosa",
                "Salta"
            };

            string[] austria = new string[]
            {
                "Graz",
                "Salzburg",
                "Linz",
                "Wels"
            };

            string[] belgium = new string[]
            {
                "Bruxelles",
                "Charleroi",
                "Namur",
                "Mons"
            };

            string[] brazil = new string[]
            {
                "Campinas",
                "Resende",
                "Recife",
                "Manaus"
            };

            string[] canada = new string[]
            {
                "Alberta",
                "Montral",
                "Tsawassen",
                "Vancouver"
            };

            string[] denmark = new string[]
            {
                "Svendborg",
                "Farum",
                "rhus",
                "Kbenhavn"
            };

            string[] finland = new string[]
            {
                "Helsinki",
                "Helsinki",
                "Espoo",
                "Oulu"
            };

            string[] france = new string[]
            {
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

            string[] germany = new string[]
            {
                "Aachen",
                "Berlin",
                "Brandenburg",
                "Cunewalde",
                "Frankfurt",
                "Kln",
                "Leipzig",
                "Mannheim",
                "Mnchen",
                "Mnster",
                "Stuttgart"
            };

            string[] ireland = new string[]
            {
                "Cork",
                "Waterford",
                "Bray",
                "Athlone"
            };

            string[] italy = new string[]
            {
                "Bergamo",
                "Reggio",
                "Torino",
                "Genoa"
            };

            string[] mexico = new string[]
            {
                "Mxico D.F.",
                "Puebla",
                "León",
                "Zapopan"
            };

            string[] norway = new string[]
            {
                "Stavern",
                "Hamar",
                "Harstad",
                "Narvik"
            };

            string[] poland = new string[]
            {
                "Warszawa",
                "Gdynia",
                "Rybnik",
                "Legnica"
            };

            string[] portugal = new string[]
            {
                "Lisboa",
                "Albufeira",
                "Elvas",
                "Estremoz"
            };

            string[] spain = new string[]
            {
                "Barcelona",
                "Madrid",
                "Sevilla",
                "Biscay"
            };

            string[] sweden = new string[]
            {
                "Brcke",
                "Pitea",
                "Robertsfors ",
                "Lule"
            };

            string[] switzerland = new string[]
            {
                "Bern",
                "Genve",
                "Charrat",
                "Châtillens"
            };

            string[] uk = new string[]
            {
                "Colchester",
                "Hedge End",
                "London",
                "Bristol"
            };

            string[] usa = new string[]
            {
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
            };

            string[] venezuela = new string[]
            {
                "Barquisimeto",
                "Caracas", "I. de Margarita",
                "San Cristbal",
                "Cantaura"
            };

            this.ShipCity.Add("Argentina", argentina);
            this.ShipCity.Add("Austria", austria);
            this.ShipCity.Add("Belgium", belgium);
            this.ShipCity.Add("Brazil", brazil);
            this.ShipCity.Add("Canada", canada);
            this.ShipCity.Add("Denmark", denmark);
            this.ShipCity.Add("Finland", finland);
            this.ShipCity.Add("France", france);
            this.ShipCity.Add("Germany", germany);
            this.ShipCity.Add("Ireland", ireland);
            this.ShipCity.Add("Italy", italy);
            this.ShipCity.Add("Mexico", mexico);
            this.ShipCity.Add("Norway", norway);
            this.ShipCity.Add("Poland", poland);
            this.ShipCity.Add("Portugal", portugal);
            this.ShipCity.Add("Spain", spain);
            this.ShipCity.Add("Sweden", sweden);
            this.ShipCity.Add("Switzerland", switzerland);
            this.ShipCity.Add("UK", uk);
            this.ShipCity.Add("USA", usa);
            this.ShipCity.Add("Venezuela", venezuela);
        }
    }
}