#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "OrderInfoRepository.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfPullToRefresh
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using Xamarin.Forms.Internals;

    /// <summary>
    /// A class used to assign collection values for a Model properties
    /// </summary>
    public class OrderInfoRepository
    {
        #region private variables
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private readonly Random random = new Random();
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private readonly string[] customerID =
    {
            "Alfki", "Frans", "Merep", "Folko", "Simob", "Warth", "Vaffe", "Furib", "Seves", "Linod",
            "Riscu", "Picco",
            "Blonp", "Welli", "Folig"
        };
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private readonly string[] shipCountry =
        {
            "Argentina", "Austria", "Belgium", "Brazil", "Canada", "Denmark", "Finland", "France", "Germany",
            "Ireland",
            "Italy", "Mexico", "Norway", "Poland", "Portugal", "Spain", "Sweden", "UK", "USA"
        };
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private readonly Dictionary<string, string[]> shipCity = new Dictionary<string, string[]>();
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private List<DateTime> orderedDates;

        #endregion

        #region GetOrderDetails

        /// <summary>
        /// Used to assign the Collection values to Model Properties.
        /// </summary>
        /// <param name="count">integer type parameter named as records count</param>
        /// <returns>added orderDetails items</returns>
        public ObservableCollection<OrderInfo> GetOrderDetails(int count)
        {
            this.SetShipCity();
            this.orderedDates = this.GetDateBetween(2000, 2014, count);
            ObservableCollection<OrderInfo> orderDetails = new ObservableCollection<OrderInfo>();

            for (int i = 10001; i <= count + 10000; i++)
            {
                string shipcountry = this.shipCountry[this.random.Next(5)];
                string[] shipcitycoll = this.shipCity[shipcountry];

                OrderInfo ord = new OrderInfo
                {
                    OrderID = i.ToString(),
                    CustomerID = this.customerID[this.random.Next(15)],
                    EmployeeID = this.random.Next(1700, 1800).ToString(),
                    ShipCountry = this.shipCountry[this.random.Next(5)],
                    ShipCity = shipcitycoll[this.random.Next(shipcitycoll.Length - 1)]
                };
                orderDetails.Add(ord);
            }

            return orderDetails;
        }

        /// <summary>
        /// Used while Refreshing Items Can be added.
        /// </summary>
        /// <param name="i">integer type parameter named as i to get the records count</param>
        /// <returns>returns added record rows value as order</returns>
        internal OrderInfo RefreshItemsource(int i)
        {
            string[] ordeshipcity = this.shipCity[this.shipCountry[this.random.Next(0, 5)]];
            OrderInfo order = new OrderInfo
            {
                OrderID = i.ToString(),
                CustomerID = this.customerID[this.random.Next(15)],
                EmployeeID = this.random.Next(1700, 1800).ToString(),
                ShipCountry = this.shipCountry[this.random.Next(5)],
                ShipCity = ordeshipcity[0]
            };
            return order;
        }

        /// <summary>
        /// Used to add More Items in View
        /// </summary>
        /// <param name="id">integer type of parameter named as id to get the records count</param>
        /// <returns>returns the value order details</returns>
        internal OrderInfo GenerateOrder(int id)
        {
            string shipcountry = this.shipCountry[this.random.Next(5)];
            string[] shipcitycoll = this.shipCity[shipcountry];
            OrderInfo order = new OrderInfo
            {
                OrderID = (id + 10000).ToString(),
                EmployeeID = this.random.Next(1700, 1800).ToString(),
                CustomerID = this.customerID[this.random.Next(15)],
                ShipCity = shipcitycoll[this.random.Next(shipcitycoll.Length - 1)],
                ShipCountry = this.shipCountry[this.random.Next(5)]
            };
            return order;
        }

        #endregion

        #region MainGrid DataSource

        /// <summary>
        /// Used to store a collection value
        /// </summary>
        private void SetShipCity()
        {
            string[] argentina = { "Rosario" };

            string[] austria = { "Graz", "Salzburg" };

            string[] belgium = { "Bruxelles", "Charleroi" };

            string[] brazil = { "Campinas", "Resende", "Recife", "Manaus" };

            string[] canada = { "Montréal", "Tsawassen", "Vancouver" };

            string[] denmark = { "Århus", "København" };

            string[] finland = { "Helsinki", "Oulu" };

            string[] france =
            {
                "Lille", "Lyon", "Marseille", "Nantes", "Paris", "Reims", "Strasbourg", "Toulouse", "Versailles"
            };

            string[] germany =
            {
                "Aachen", "Berlin", "Brandenburg", "Cunewalde", "Frankfurt", "Köln", "Leipzig", "Mannheim",
                "München",
                "Münster", "Stuttgart"
            };

            string[] ireland = { "Cork" };

            string[] italy = { "Bergamo", "Reggio", "Torino" };

            string[] mexico = { "México D.F." };

            string[] norway = { "Stavern" };

            string[] poland = { "Warszawa" };

            string[] portugal = { "Lisboa" };

            string[] spain = { "Barcelona", "Madrid", "Sevilla" };

            string[] sweden = { "Bräcke", "Luleå" };

            string[] switzerland = { "Bern", "Genève" };

            string[] uk = { "Colchester", "Hedge End", "London" };

            string[] usa =
            {
                "Albuquerque", "Anchorage", "Boise", "Butte", "Elgin", "Eugene", "Kirkland", "Lander",
                "Portland",
                "San Francisco", "Seattle"
            };

            string[] venezuela = { "Barquisimeto", "Caracas", "I. de Margarita", "San Cristóbal" };

            this.shipCity.Add("Argentina", argentina);
            this.shipCity.Add("Austria", austria);
            this.shipCity.Add("Belgium", belgium);
            this.shipCity.Add("Brazil", brazil);
            this.shipCity.Add("Canada", canada);
            this.shipCity.Add("Denmark", denmark);
            this.shipCity.Add("Finland", finland);
            this.shipCity.Add("France", france);
            this.shipCity.Add("Germany", germany);
            this.shipCity.Add("Ireland", ireland);
            this.shipCity.Add("Italy", italy);
            this.shipCity.Add("Mexico", mexico);
            this.shipCity.Add("Norway", norway);
            this.shipCity.Add("Poland", poland);
            this.shipCity.Add("Portugal", portugal);
            this.shipCity.Add("Spain", spain);
            this.shipCity.Add("Sweden", sweden);
            this.shipCity.Add("Switzerland", switzerland);
            this.shipCity.Add("UK", uk);
            this.shipCity.Add("USA", usa);
            this.shipCity.Add("Venezuela", venezuela);
        }

        /// <summary>
        /// Used to generate Date with given years
        /// </summary>
        /// <param name="startYear">integer type parameter named as startYear</param>
        /// <param name="endYear">integer type parameter named as endYear</param>
        /// <param name="count">integer type parameter named as count</param>
        /// <returns>returns generates date value</returns>
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

        #endregion
    }
}
