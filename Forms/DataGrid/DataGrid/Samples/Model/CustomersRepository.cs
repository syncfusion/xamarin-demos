#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "CustomersRepository.cs" company="Syncfusion.com">
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
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// A class Used to Store the Item values 
    /// </summary>
    public class CustomersRepository
    {
        #region Fields

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Random random = new Random();

        #endregion

        #region MainGrid DataSource
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string[] genders = new string[] 
        {
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

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string[] firstNames = new string[] 
        {
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

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string[] lastNames = new string[]
        {
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
            "Holmes",
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

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string[] customerID = new string[] 
        {
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

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string[] country = new string[]
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

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Dictionary<string, string[]> city = new Dictionary<string, string[]>();

        #endregion

        /// <summary>
        /// Initializes a new instance of the CustomersRepository class.
        /// </summary>
        public CustomersRepository()
        {
        }

        #region GetOrderDetails

        /// <summary>
        /// Generates record rows with given count
        /// </summary>
        /// <param name="count">generates row count</param>
        /// <returns>returns the added record rows</returns>
        public ObservableCollection<CustomerDetails> GetCutomerDetails(int count)
        {
            this.SetCity();
            ObservableCollection<CustomerDetails> orderDetails = new ObservableCollection<CustomerDetails>();

            for (int i = 10001; i <= count + 10000; i++)
            {
                var country = this.country[this.random.Next(5)];
                var citycoll = this.city[country];

                var ord = new CustomerDetails()
                {
                    CustomerID = this.customerID[this.random.Next(15)],
                    FirstName = this.firstNames[this.random.Next(15)],
                    LastName = this.lastNames[this.random.Next(15)],
                    Gender = this.genders[this.random.Next(5)],
                    Country = this.country[this.random.Next(5)],
                    City = citycoll[this.random.Next(citycoll.Length - 1)],
                };
                orderDetails.Add(ord);
            }

            return orderDetails;
        }

        /// <summary>
        /// Used to stored a String type collection value
        /// </summary>
        private void SetCity()
        {
            string[] argentina = new string[] { "Rosario" };

            string[] austria = new string[] { "Graz", "Salzburg" };

            string[] belgium = new string[] { "Bruxelles", "Charleroi" };

            string[] brazil = new string[] { "Campinas", "Resende", "Manaus", "Recife" };

            string[] canada = new string[] { "Montréal", "Tsawassen", "Vancouver" };

            string[] denmark = new string[] { "Århus", "København" };

            string[] finland = new string[] { "Helsinki", "Oulu" };

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
                "Cunewalde",
                "Frankfurt",
                "Köln",
                "Leipzig",
                "Mannheim",
                "München",
                "Münster",
                "Stuttgart"
            };

            string[] ireland = new string[]
            {
                "Cork"
            };

            string[] italy = new string[]
            {
                "Bergamo", "Reggio", "Torino"
            };

            string[] mexico = new string[]
            {
                "México D.F."
            };

            string[] norway = new string[]
            {
                "Stavern"
            };

            string[] poland = new string[]
            {
                "Warszawa"
            };

            string[] portugal = new string[]
            {
                "Lisboa"
            };

            string[] spain = new string[]
            {
                "Barcelona",
                "Madrid",
                "Sevilla"
            };

            string[] sweden = new string[]
            {
                "Bräcke",
                "Luleå"
            };

            string[] switzerland = new string[]
            {
                "Bern",
                "Genève"
            };

            string[] uk = new string[]
            {
                "Colchester",
                "Hedge End",
                "London"
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
                "Seattle",
                "Walla"
            };

            string[] venezuela = new string[] { "Barquisimeto", "Caracas", "I. de Margarita", "San Cristóbal" };

            this.city.Add("Argentina", argentina);
            this.city.Add("Austria", austria);
            this.city.Add("Belgium", belgium);
            this.city.Add("Brazil", brazil);
            this.city.Add("Canada", canada);
            this.city.Add("Denmark", denmark);
            this.city.Add("Finland", finland);
            this.city.Add("France", france);
            this.city.Add("Germany", germany);
            this.city.Add("Ireland", ireland);
            this.city.Add("Italy", italy);
            this.city.Add("Mexico", mexico);
            this.city.Add("Norway", norway);
            this.city.Add("Poland", poland);
            this.city.Add("Portugal", portugal);
            this.city.Add("Spain", spain);
            this.city.Add("Sweden", sweden);
            this.city.Add("Switzerland", switzerland);
            this.city.Add("UK", uk);
            this.city.Add("USA", usa);
            this.city.Add("Venezuela", venezuela);
        }

        #endregion   
    }
}