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
namespace SampleBrowser.SfPopupLayout
{
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// A class contains Properties and Notifies that a property value has changed 
    /// </summary>
    public class OrderInfo : INotifyPropertyChanged
    {
        #region private variables

        /// <summary>
        /// backing field for OrderID.
        /// </summary>
        private string orderID;

        /// <summary>
        /// backing field for EmployeeID.
        /// </summary>
        private string employeeID;

        /// <summary>
        /// backing field for CustomerID.
        /// </summary>
        private string customerID;

        /// <summary>
        /// backing field for ShipCountry.
        /// </summary>
        private string shipCountry;

        #endregion

        /// <summary>
        /// Represents the method that will handle the <see cref="E:System.ComponentModel.INotifyPropertyChanged.PropertyChanged"></see> event raised when a property is changed on a component
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #region Public Properties

        /// <summary>
        /// Gets or sets the OrderID value.
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
        /// Gets or sets the EmployeeID value.
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
        /// Gets or sets the CustomerID value.
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
        /// Gets or sets the ShipCountry value.
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

        #endregion

        #region INotifyPropertyChanged implementation

        /// <summary>
        /// Triggers when Items Collections Changed.
        /// </summary>
        /// <param name="name">string type parameter named as name</param>
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