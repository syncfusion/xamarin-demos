#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "OrderInfo.cs" company="Syncfusion.com">
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
    /// A class contains properties Notifies clients that a property value has changed.
    /// </summary>
    public class OrderInfo : INotifyPropertyChanged
    {
        #region private variables

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string orderID;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string employeeID;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string customerID;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string firstname;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string lastname;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string gender;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string shipCity;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string shipCountry;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private double freight;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private DateTime shippingDate;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private bool isClosed;

        #endregion

        /// <summary>
        /// Initializes a new instance of the OrderInfo class.
        /// </summary>
        public OrderInfo()
        {
        }

        /// <summary>
        /// Represents the method that will handle the <see cref="E:System.ComponentModel.INotifyPropertyChanged.PropertyChanged"></see> event raised when a property is changed on a component
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #region Public Properties

        /// <summary>
        /// Gets or sets the value of OrderID and notifies user when value gets changed
        /// </summary>
        public string OrderID
        {
            get
            {
                return this.orderID;
            }

            set
            {
                this.orderID = value;
                this.RaisePropertyChanged("OrderID");
            }
        }

        /// <summary>
        /// Gets or sets the value of EmployeeID and notifies user when value gets changed
        /// </summary>
        public string EmployeeID
        {
            get
            {
                return this.employeeID;
            }

            set
            {
                this.employeeID = value;
                this.RaisePropertyChanged("EmployeeID");
            }
        }

        /// <summary>
        /// Gets or sets the value of CustomerID and notifies user when value gets changed
        /// </summary>
        public string CustomerID
        {
            get
            {
                return this.customerID;
            }

            set
            {
                this.customerID = value;
                this.RaisePropertyChanged("CustomerID");
            }
        }

        /// <summary>
        /// Gets or sets the value of FirstName and notifies user when value gets changed
        /// </summary>
        public string FirstName
        {
            get
            {
                return this.firstname;
            }

            set
            {
                this.firstname = value;
                this.RaisePropertyChanged("FirstName");
            }
        }

        /// <summary>
        /// Gets or sets the value of LastName and notifies user when value gets changed
        /// </summary>
        public string LastName
        {
            get
            {
                return this.lastname;
            }

            set
            {
                this.lastname = value;
                this.RaisePropertyChanged("LastName");
            }
        }

        /// <summary>
        /// Gets or sets the value of Gender and notifies user when value gets changed
        /// </summary>
        public string Gender
        {
            get
            {
                return this.gender;
            }

            set
            {
                this.gender = value;
                this.RaisePropertyChanged("Gender");
            }
        }

        /// <summary>
        /// Gets or sets the value of ShipCity and notifies user when value gets changed
        /// </summary>
        public string ShipCity
        {
            get
            {
                return this.shipCity;
            }

            set
            {
                this.shipCity = value;
                this.RaisePropertyChanged("ShipCity");
            }
        }

        /// <summary>
        /// Gets or sets the value of ShipCountry and notifies user when value gets changed
        /// </summary>
        public string ShipCountry
        {
            get
            {
                return this.shipCountry;
            }

            set
            {
                this.shipCountry = value;
                this.RaisePropertyChanged("ShipCountry");
            }
        }

        /// <summary>
        /// Gets or sets the value of Freight and notifies user when value gets changed
        /// </summary>
        public double Freight
        {
            get
            {
                return this.freight;
            }

            set
            {
                this.freight = value;
                this.RaisePropertyChanged("Freight");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether IsClosed is true or false and notifies user when value gets changed
        /// </summary>
        public bool IsClosed
        {
            get
            {
                return this.isClosed;
            }

            set
            {
                this.isClosed = value;
                this.RaisePropertyChanged("IsClosed");
            }
        }

        /// <summary>
        /// Gets or sets the value of ShippingDate and notifies user when value gets changed
        /// </summary>
        public DateTime ShippingDate
        {
            get
            {
                return this.shippingDate;
            }

            set
            {
                this.shippingDate = value;
                this.RaisePropertyChanged("ShippingDate");
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation

        /// <summary>
        /// Triggers when Items Collections Changed.
        /// </summary>
        /// <param name="name">string type parameter name</param>
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