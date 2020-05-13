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
namespace SampleBrowser.SfPopupLayout
{
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// A class used to assign collection values for a Model properties
    /// </summary>
    public class OrderInfoRepository
    {
        #region private variables

        /// <summary>
        /// Instance of the random data generator.
        /// </summary>
        private readonly Random random = new Random();

        #endregion

        #region MainGrid DataSource

        /// <summary>
        /// Holds the data for CustomerID.
        /// </summary>
        private readonly string[] customerID =
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

        /// <summary>
        /// Holds the data for ShipCountry.
        /// </summary>
        private readonly string[] shipCountry =
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
            "USA"
        };

        #endregion

        #region GetOrderDetails

        /// <summary>
        /// Used to assign the Collection values to Model Properties.
        /// </summary>
        /// <param name="count">record rows count</param>
        /// <returns> added orderDetails items </returns>
        public ObservableCollection<OrderInfo> GetOrderDetails(int count)
        {
            var orderDetails = new ObservableCollection<OrderInfo>();

            for (var i = 10001; i <= count + 10000; i++)
            {
                var ord = new OrderInfo
                {
                    OrderID = i.ToString(),
                    CustomerID = this.customerID[this.random.Next(15)],
                    EmployeeID = this.random.Next(1700, 1800).ToString(),
                    ShipCountry = this.shipCountry[this.random.Next(5)]
                };
                orderDetails.Add(ord);
            }

            return orderDetails;
        }

        #endregion
    }
}