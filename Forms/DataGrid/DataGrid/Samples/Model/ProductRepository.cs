#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "ProductRepository.cs" company="Syncfusion.com">
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
    using System.Diagnostics.CodeAnalysis;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// A class used to store the item values 
    /// </summary>
    public class ProductRepository
    {
        #region MainGrid DataSource

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string[] productNames = new string[] 
        {
            "Bag",
            "Syrup",
            "Crab",
            "Meat",
            "Cashew",
            "Chai",
            "Chang",
            "Walnuts",
            "Cajun",
            "Gumb",
            "Chocolate",
            "Cote de",
            "lax",
            "Filo",
            "Geitost",
            "Flotemy",
            "Ikura",
            "Longlife",
            "Maxilaku",
            "Mishi",
            "Ipoh",
            "Konbu",
            "Pavlova",
            "Cabrales"
        };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int[] productID = new int[] 
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
        private Random random = new Random();

        #endregion

        /// <summary>
        /// Initializes a new instance of the ProductRepository class.
        /// </summary>
        public ProductRepository()
        {
        }

        #region GetOrderDetails
     
        /// <summary>
        /// Generates record rows with given count
        /// </summary>
        /// <param name="count">generates row count</param>
        /// <returns>returns the added row details</returns>
        public List<Product> GetProductDetails(int count)
        {
            List<Product> productDetails = new List<Product>();

            for (int i = 1; i <= count; i++)
            {
                int position = this.random.Next(15);
                var ord = new Product()
                {
                    SupplierID = i,
                    ProductID = this.productID[position],
                    ProductName = this.productNames[position],
                    Quantity = this.random.Next(1, 20),
                    UnitPrice = this.random.Next(70, 200),
                    UnitsInStock = this.random.Next(3, 12),
                };
                ord.Discount = ord.Quantity + "%";
                productDetails.Add(ord);
            }

            return productDetails;
        }

        #endregion     
    }
}