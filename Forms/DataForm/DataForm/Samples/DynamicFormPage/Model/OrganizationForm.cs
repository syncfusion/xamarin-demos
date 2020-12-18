#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.XForms.DataForm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms.Internals;
using System.ComponentModel.DataAnnotations;

namespace SampleBrowser.SfDataForm
{
    /// <summary>
    /// Represents the Organization information of the data form dynamicforms sample.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class OrganizationForm : INotifyPropertyChanged
    {
        #region Fields       
        /// <summary>
        /// Represents the name of the organization form information.
        /// </summary>
        private string organizationName;

        /// <summary>
        /// Represents the first address line of the organization form information.
        /// </summary>
        private string addressline1;

        /// <summary>
        /// Represents the second address line of the organization form information.
        /// </summary>
        private string addressline2;

        /// <summary>
        /// Represents the country of the organization form information.
        /// </summary>
        private string organizationCountry;

        /// <summary>
        /// Represents the city of the organization form information.
        /// </summary>
        private string organizationCity;

        /// <summary>
        /// Represents the zip of the organization form information.
        /// </summary>
        private string zip;

        /// <summary>
        /// Represents the code of the organization form information.
        /// </summary>
        private string code;

        /// <summary>
        /// Represents the phone of the organization form information.
        /// </summary>
        private string phone;

        /// <summary>
        /// Represents the contact email of the organization form information.
        /// </summary>
        private string contactemail;
        #endregion

        public OrganizationForm()
        {

        }

        /// <summary>
        /// Represents the method that will handle when a property is changed on a component.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #region Public Properties  

        /// <summary>
        /// Gets or sets the organization name field.
        /// </summary>
        [Display(ShortName = "Organization name")]
        public string OrganizationName
        {
            get
            {
                return this.organizationName;
            }
            set
            {
                this.organizationName = value;
                this.RaisePropertyChanged("OrganizationName");
            }
        }

        /// <summary>
        /// Gets or sets the first address line field.
        /// </summary>
        [Display(ShortName = "Address line 1")]
        [DataType(DataType.MultilineText)]
        public string AddressLine1
        {
            get
            {
                return this.addressline1;
            }
            set
            {
                this.addressline1 = value;
                this.RaisePropertyChanged("AddressLine1");
            }
        }

        /// <summary>
        /// Gets or sets the second address line field.
        /// </summary>
        [Display(ShortName = "Address line 2")]
        [DataType(DataType.MultilineText)]
        public string AddressLine2
        {
            get
            {
                return this.addressline2;
            }
            set
            {
                this.addressline2 = value;
                this.RaisePropertyChanged("AddressLine2");
            }
        }

        /// <summary>
        /// Gets or sets the city field.
        /// </summary>
        [DisplayOptions(ColumnSpan = 2)]
        [Display(ShortName = "City")]
        public string OrganizationCity
        {
            get
            {
                return this.organizationCity;
            }
            set
            {
                this.organizationCity = value;
                this.RaisePropertyChanged("OrganizationCity");
            }
        }

        /// <summary>
        /// Gets or sets the zip field.
        /// </summary>
        [DisplayOptions(ColumnSpan = 2)]
        [DataType(DataType.PhoneNumber)]
        public string Zip
        {
            get
            {
                return this.zip;
            }
            set
            {
                this.zip = value;
                this.RaisePropertyChanged("Zip");
            }
        }

        /// <summary>
        /// Gets or sets the country field.
        /// </summary>
        [Display(ShortName = "Country")]
        public string OrganizationCountry
        {
            get
            {
                return this.organizationCountry;
            }
            set
            {
                this.organizationCountry = value;
                this.RaisePropertyChanged("OrganizationCountry");
            }
        }

        /// <summary>
        /// Gets or sets the code field.
        /// </summary>
        [DisplayOptions(ColumnSpan = 2)]
        [DataType(DataType.PhoneNumber)]
        public string Code
        {
            get
            {
                return this.code;
            }
            set
            {
                this.code = value;
                this.RaisePropertyChanged("Code");
            }
        }

        /// <summary>
        /// Gets or sets the phone field.
        /// </summary>
        [DisplayOptions(ColumnSpan = 2)]
        [Display(ShortName = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string Phone
        {
            get
            {
                return this.phone;
            }
            set
            {
                this.phone = value;
                this.RaisePropertyChanged("Phone");
            }
        }

        /// <summary>
        /// Gets or sets the contact email field.
        /// </summary>
        [Display(ShortName = "Contact email")]
        public string ContactEmail
        {
            get
            {
                return this.contactemail;
            }
            set
            {
                this.contactemail = value;
                this.RaisePropertyChanged("ContactEmail");
            }
        }
        #endregion

        /// <summary>
        /// Occurs when propery value is changed.
        /// </summary>
        /// <param name="propName">Property name</param>
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
