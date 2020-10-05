#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "ProductInfo.cs" company="Syncfusion.com">
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
    using System.Diagnostics.CodeAnalysis;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// A class contains properties and notifies clients that a property value has changed.
    /// </summary>  
    public class ProductInfo : Employee
    {
        #region Private Members

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int productID;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string productModel;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int userRating;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string product;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private bool availability;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private double price;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int shippingDays;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string productType;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value of ProductID and notifies user when value gets changed
        /// </summary>
        public int ProductID
        {
            get
            {
                return this.productID;
            }

            set
            {
                this.productID = value;
                this.RaisePropertyChanged("ProductID");
            }
        }

        /// <summary>
        /// Gets or sets the value of Product and notifies user when value gets changed
        /// </summary>
        public string Product
        {
            get
            {
                return this.product;
            }

            set
            {
                this.product = value;
                this.RaisePropertyChanged("Product");
            }
        }

        /// <summary>
        /// Gets or sets the value of UserRating and notifies user when value gets changed
        /// </summary>
        public int UserRating
        {
            get
            {
                return this.userRating;
            }

            set
            {
                this.userRating = value;
                this.RaisePropertyChanged("UserRating");
            }
        }

        /// <summary>
        /// Gets or sets the value of ProductModel and notifies user when value gets changed
        /// </summary>
        public string ProductModel
        {
            get
            {
                return this.productModel;
            }

            set
            {
                this.productModel = value;
                this.RaisePropertyChanged("ProductModel");
            }
        }

        /// <summary>
        /// Gets or sets the value of Price and notifies user when value gets changed
        /// </summary>
        public double Price
        {
            get
            {
                return this.price;
            }

            set
            {
                this.price = value;
                this.RaisePropertyChanged("Price");
            }
        }

        /// <summary>
        /// Gets or sets the value of ShippingDays and notifies user when value gets changed
        /// </summary>
        public int ShippingDays
        {
            get
            {
                return this.shippingDays;
            }

            set
            {
                this.shippingDays = value;
                this.RaisePropertyChanged("ShippingDays");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether Availability has true or false value and notifies user when value gets changed
        /// </summary>
        public bool Availability
        {
            get
            {
                return this.availability;
            }

            set
            {
                this.availability = value;
                this.RaisePropertyChanged("Availability");
            }
        }

        /// <summary>
        /// Gets or sets the value of ProductType and notifies user when value gets changed
        /// </summary>
        public string ProductType
        {
            get
            {
                return this.productType;
            }

            set
            {
                this.productType = value;
                this.RaisePropertyChanged("ProductType");
            }
        }

        #endregion
    }
}