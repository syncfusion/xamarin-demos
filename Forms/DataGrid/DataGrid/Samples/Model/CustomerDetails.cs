#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "CustomerDetails.cs" company="Syncfusion.com">
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
    /// A class contains properties
    /// </summary>
    public class CustomerDetails
    {
        #region private variables
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string customerID;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string firstname;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string lastname;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string gender;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string city;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string country;
        #endregion

        /// <summary>
        /// Represents the method that will handle the <see cref="E:System.ComponentModel.INotifyPropertyChanged.PropertyChanged"></see> event raised when a property is changed on a component
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #region Public Properties

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
        /// Gets or sets the value of City and notifies user when value gets changed
        /// </summary>
        public string City
        {
            get
            {
                return this.city;
            }

            set
            {
                this.city = value;
                this.RaisePropertyChanged("City");
            }
        }

        /// <summary>
        /// Gets or sets the value of Country and notifies user when value gets changed
        /// </summary>
        public string Country
        {
            get
            {
                return this.country;
            }

            set
            {
                this.country = value;
                this.RaisePropertyChanged("Country");
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation

        /// <summary>
        /// Triggers when Items Collections Changed.
        /// </summary>
        /// <param name="name">string type of parameter name</param>
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