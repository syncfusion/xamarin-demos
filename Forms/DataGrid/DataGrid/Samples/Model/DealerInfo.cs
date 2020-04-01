#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "DealerInfo.cs" company="Syncfusion.com">
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
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    ///  A class contains properties and notifies clients that a property value has changed.
    /// </summary>
    public class DealerInfo : INotifyPropertyChanged
    {
        #region private variables

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int productNo;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int productID;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string dealerName;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private bool isOnline;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int productprice;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string dealerImage;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private DateTime shippedDate;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string shipCity;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string shipCountry;

        #endregion

        /// <summary>
        /// Represents the method that will handle the <see cref="E:System.ComponentModel.INotifyPropertyChanged.PropertyChanged"></see> event raised when a property is changed on a component
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #region Public Properties

        /// <summary>
        /// Gets or sets the value of DealerImage and notifies user when value gets changed
        /// </summary>
        public string DealerImage
        {
            get
            {
                return this.dealerImage;
            }

            set
            {
                this.dealerImage = value;
                this.RaisePropertyChanged("DealerImage");
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
        /// Gets or sets the value of DealerName and notifies user when value gets changed
        /// </summary>
        public string DealerName
        {
            get
            {
                return this.dealerName;
            }

            set
            {
                this.dealerName = value;
                this.RaisePropertyChanged("DealerName");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether property value IsOnline was true or false and notifies user when value gets changed
        /// </summary>
        public bool IsOnline
        {
            get
            {
                return this.isOnline;
            }

            set
            {
                this.isOnline = value;
                this.RaisePropertyChanged("IsOnline");
            }
        }

        /// <summary>
        /// Gets or sets the value of ProductPrice and notifies user when value gets changed
        /// </summary>
        public int ProductPrice
        {
            get
            {
                return this.productprice;
            }

            set
            {
                this.productprice = value;
                this.RaisePropertyChanged("ProductPrice");
            }
        }

        /// <summary>
        /// Gets or sets the value of ProductNo and notifies user when value gets changed
        /// </summary>
        public int ProductNo
        {
            get
            {
                return this.productNo;
            }

            set
            {
                this.productNo = value;
                this.RaisePropertyChanged("ProductNo");
            }
        }

        /// <summary>
        /// Gets or sets the value of ShippedDate and notifies user when value gets changed
        /// </summary>
        public DateTime ShippedDate
        {
            get
            {
                return this.shippedDate;
            }

            set
            {
                this.shippedDate = value;
                this.RaisePropertyChanged("ShippedDate");
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
        #endregion

        #region INotifyPropertyChanged implementation

        /// <summary>
        /// Triggers when Items Collections Changed.
        /// </summary>
        /// <param name="name">string type of name</param>
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