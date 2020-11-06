#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "ProductInfoRepository.cs" company="Syncfusion.com">
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
    using System.Linq;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// A class Used to store the item values 
    /// </summary>
    public class ProductInfoRepository
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string[] productName = new string[] 
        {
            "Laptop",
            "Mobile",
            "Watch",
            "Footware"
        };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Dictionary<string, string[]> product = new Dictionary<string, string[]>();
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Dictionary<string, string[]> productModel = new Dictionary<string, string[]>();
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Dictionary<string, int> productPrice = new Dictionary<string, int>();
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Random r = new Random();

        /// <summary>
        /// Gets the orders details.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns>generated record row details</returns>
        public List<ProductInfo> GetProductDetails(int count)
        {
            List<ProductInfo> productDetails = new List<ProductInfo>();
            this.SetProduct();
            this.SetProductPrice();
            for (int i = 10000; i < count + 10000; i++)
            {
                productDetails.Add(this.GetProduct(i));
            }

            return productDetails;
        }

        /// <summary>
        /// Generates record rows with given count
        /// </summary>
        /// <param name="i">generates row count</param>
        /// <returns>returns added record row details</returns>
        private ProductInfo GetProduct(int i)
        {
            ProductInfo product = new ProductInfo();
            var productName = this.productName[this.r.Next(this.productName.Count() - 1)];
            var productcoll = this.product[productName];
            product.ProductID = i;
            product.UserRating = this.r.Next(3, 5);
            product.ShippingDays = this.r.Next(1, 5);
            product.ProductType = productName;
            product.Product = productcoll[this.r.Next(productcoll.Length - 1)];
            var productModel = this.productModel[product.Product];
            product.Availability = this.r.Next(0, 20) % 5 == 0 ? false : true;
            product.Price = this.productPrice[productName];
            product.ProductModel = productModel[this.r.Next(productModel.Count())];

            return product;
        }

        /// <summary>
        /// Used this method to store a String type collection
        /// </summary>
        private void SetProduct()
        {
            string[] laptop = new string[] { "Dell", "HP", "Asus", "Sony", "Apple", "Lenovo" };

            string[] mobile = new string[] { "Nokia", "Samsung", "SonyMobile", "HTC", "IPhone" };

            string[] watch = new string[] { "FastTrack", "ROLEX", "Casio", "Geneva", "Seiko" };

            string[] footware = new string[] { "Reebok", "Puma" };
            this.product.Add("Laptop", laptop);
            this.product.Add("Mobile", mobile);
            this.product.Add("Watch", watch);
            this.product.Add("Footware", footware);
                 
            this.productModel.Add("Dell", new string[] { "XPS15", "XPS12" });
            this.productModel.Add("HP", new string[] { "Pavilion_G6", "Envy_X2" });
            this.productModel.Add("Asus", new string[] { "Transformer" });
            this.productModel.Add("Sony", new string[] { "Vaio" });
            this.productModel.Add("Apple", new string[] { "Macbook_Air", "Macbook_Pro2" });
            this.productModel.Add("Lenovo", new string[] { "Yoga" });
                 
            this.productModel.Add("Nokia", new string[] { "Lumia_920", "Lumia_800" });
            this.productModel.Add("Samsung", new string[] { "S3" });
            this.productModel.Add("SonyMobile", new string[] { "Xperia_Tipo", "Xperia_Z" });
            this.productModel.Add("IPhone", new string[] { "Iphone5" });
            this.productModel.Add("HTC", new string[] { "8x", "One_X" });
                 
            this.productModel.Add("FastTrack", new string[] { "Fastrack", "Men_Black" });
            this.productModel.Add("Casio", new string[] { "G-Shock" });
            this.productModel.Add("Geneva", new string[] { "Carrera", "Monaco" });
            this.productModel.Add("Seiko", new string[] { "Aquaracer" });
            this.productModel.Add("ROLEX", new string[] { "Sea_Dweller", "Submariner" });
                 
            this.productModel.Add("Puma", new string[] { "Aquil", "Axis_XT" });
            this.productModel.Add("Reebok", new string[] { "Advantage_Runner", "FieldEffect", "RunCruise" });
        }

        /// <summary>
        /// Used this method to store a product price in product price collection
        /// </summary>
        private void SetProductPrice()
        {
            this.productPrice.Add("Laptop", this.r.Next(1200, 1500));
            this.productPrice.Add("Mobile", this.r.Next(250, 350));
            this.productPrice.Add("Watch", this.r.Next(120, 150));
            this.productPrice.Add("Footware", this.r.Next(35, 45));
        }

        // string[] ProductID = new string[] {
        //  "ALFKI",
        //  "FRANS",
        //  "MEREP",
        //  "FOLKO",
        //  "SIMOB",
        //  "WARTH",
        //  "VAFFE",
        //  "FURIB",
        //  "SEVES",
        //  "LINOD",
        //  "RISCU",
        //  "PICCO",
        //  "BLONP",
        //  "WELLI",
        //  "FOLIG"
        // };
    }
}