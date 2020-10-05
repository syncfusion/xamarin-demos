#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "Product.cs" company="Syncfusion.com">
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
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// A class contains properties and notifies clients that a property value has changed.
    /// </summary>  
    public class Product : INotifyPropertyChanged
    {
        #region private variables

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int supplierID;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int productID;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string productName;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int quantity;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int unitPrice;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int unitsInStock;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string discount;

        #endregion

        /// <summary>
        /// Initializes a new instance of the Product class.
        /// </summary>
        public Product()
        {
        }

        /// <summary>
        /// Represents the method that will handle the <see cref="E:System.ComponentModel.INotifyPropertyChanged.PropertyChanged"></see> event raised when a property is changed on a component
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #region Public Properties

        /// <summary>
        /// Gets or sets the value of SupplierID and notifies user when value gets changed
        /// </summary>
        public int SupplierID
        {
            get
            {
                return this.supplierID;
            }

            set
            {
                this.supplierID = value;
                this.RaisePropertyChanged("SupplierID");
            }
        }

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
        /// Gets or sets the value of ProductName and notifies user when value gets changed
        /// </summary>
        public string ProductName
        {
            get
            {
                return this.productName;
            }

            set
            {
                this.productName = value;
                this.RaisePropertyChanged("ProductName");
            }
        }

        /// <summary>
        /// Gets or sets the value of Quantity and notifies user when value gets changed
        /// </summary>
        public int Quantity
        {
            get
            {
                return this.quantity;
            }

            set
            {
                this.quantity = value;
                this.RaisePropertyChanged("Quantity");
            }
        }

        /// <summary>
        /// Gets or sets the value of UnitPrice and notifies user when value gets changed
        /// </summary>
        public int UnitPrice
        {
            get
            {
                return this.unitPrice;
            }

            set
            {
                this.unitPrice = value;
                this.RaisePropertyChanged("UnitPrice");
            }
        }

        /// <summary>
        /// Gets or sets the value of UnitsInStock and notifies user when value gets changed
        /// </summary>
        public int UnitsInStock
        {
            get
            {
                return this.unitsInStock;
            }

            set
            {
                this.unitsInStock = value;
                this.RaisePropertyChanged("UnitsInStock");
            }
        }

        /// <summary>
        /// Gets or sets the value of Discount and notifies user when value gets changed
        /// </summary>
        public string Discount
        {
            get
            {
                return this.discount;
            }

            set
            {
                this.discount = value;
                this.RaisePropertyChanged("Discount");
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation

        /// <summary>
        /// Triggers when Items Collections Changed.
        /// </summary>
        /// <param name="name">String type of parameter name</param>
        private void RaisePropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }
}