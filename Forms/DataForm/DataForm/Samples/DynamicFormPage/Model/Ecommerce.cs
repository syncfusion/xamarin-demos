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
    /// Represents the Ecommerce information of the data form dynamicforms sample.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class Ecommerce: INotifyPropertyChanged
    {
        #region Fields       
        /// <summary>
        /// Represents the full name of the ecommerce information.
        /// </summary>
        private string fullname;

        /// <summary>
        /// Represents the card number of the ecommerce information.
        /// </summary>
        private string cardNumber;

        /// <summary>
        /// Represents the ccv of the ecommerce information.
        /// </summary>
        private string ccv;

        /// <summary>
        /// Represents the expiration date of the ecommerce information.
        /// </summary>
        private string expirationDate;

        /// <summary>
        /// Represents the first address line of the ecommerce information.
        /// </summary>
        private string addressline1;

        /// <summary>
        /// Represents the second address line of the ecommerce information.
        /// </summary>
        private string addressline2;

        /// <summary>
        /// Represents the city of the ecommerce information.
        /// </summary>
        private string city;

        /// <summary>
        /// Represents the state of the ecommerce information.
        /// </summary>
        private string state;

        /// <summary>
        /// Represents the country of the ecommerce information.
        /// </summary>
        private string ecommerceCountry;

        /// <summary>
        /// Represents the zip code of the ecommerce information.
        /// </summary>
        private string zipCode;

        /// <summary>
        /// Represents the comment of the ecommerce information.
        /// </summary>
        private string comment;

        #endregion

        public Ecommerce()
        {

        }

        /// <summary>
        /// Represents the method that will handle when a property is changed on a component.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #region Public Properties  

        /// <summary>
        /// Gets or sets the full name field.
        /// </summary>
        [DisplayOptions(ColumnSpan = 4)]
        [Display(ShortName = "Full Name")]
        public string FullName
        {
            get
            {
                return this.fullname;
            }
            set
            {
                this.fullname = value;
                this.RaisePropertyChanged("FullName");

            }
        }

        /// <summary>
        /// Gets or sets the card number field.
        /// </summary>
        [DisplayOptions(ColumnSpan = 3)]
        [Display(ShortName = "Card Number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Card number should not be empty")]
        [StringLength(19, ErrorMessage = "Card number should not exceed 16 digits")]
        [DataType(DataType.PhoneNumber)]
        public string CardNumber
        {
            get
            {
                return this.cardNumber;
            }
            set
            {
                this.cardNumber = value;
                this.RaisePropertyChanged("CardNumber");

            }
        }

        /// <summary>
        /// Gets or sets the ccv field.
        /// </summary>
        [DisplayOptions(ColumnSpan = 1)]
        [DataType(DataType.PhoneNumber)]
        public string CCV
        {
            get
            {
                return this.ccv;
            }
            set
            {
                this.ccv = value;
                this.RaisePropertyChanged("CCV");
            }
        }

        /// <summary>
        /// Gets or sets the expiration date field.
        /// </summary>
        [DisplayOptions(ColumnSpan = 4)]
        [DataType(DataType.PhoneNumber)]
        [Display(ShortName = "Expiration Date")]
        public string ExpirationDate
        {
            get
            {
                return this.expirationDate;
            }
            set
            {
                this.expirationDate = value;
                this.RaisePropertyChanged("ExpirationDate");
            }
        }

        /// <summary>
        /// Gets or sets the first address line field.
        /// </summary>
        [DisplayOptions(ColumnSpan = 4)]
        [Display(ShortName = "Address Line 1")]
        [DataType(DataType.MultilineText)]
        public string Addressline1
        {
            get
            {
                return this.addressline1;
            }
            set
            {
                this.addressline1 = value;
                this.RaisePropertyChanged("Addressline1");
            }
        }

        /// <summary>
        /// Gets or sets the second address line field.
        /// </summary>
        [DisplayOptions(ColumnSpan = 4)]
        [Display(ShortName = "Address Line 2")]
        [DataType(DataType.MultilineText)]
        public string Addressline2
        {
            get
            {
                return this.addressline2;
            }
            set
            {
                this.addressline2 = value;
                this.RaisePropertyChanged("Addressline2");
            }
        }

        /// <summary>
        /// Gets or sets the city field.
        /// </summary>
        [DisplayOptions(ColumnSpan = 4)]
        [Display(ShortName = "City")]
        public string EcommerceCity
        {
            get
            {
                return this.city;
            }
            set
            {
                this.city = value;
                this.RaisePropertyChanged("EcommerceCity");
            }
        }

        /// <summary>
        /// Gets or sets the state field.
        /// </summary>
        [DisplayOptions(ColumnSpan = 4)]
        public string State
        {
            get
            {
                return this.state;
            }
            set
            {
                this.state = value;
                this.RaisePropertyChanged("State");
            }
        }

        /// <summary>
        /// Gets or sets the country field.
        /// </summary>
        [DisplayOptions(ColumnSpan = 2)]
        [Display(ShortName = "Country")]
        public string EcommerceCountry
        {
            get
            {
                return this.ecommerceCountry;
            }
            set
            {
                this.ecommerceCountry = value;
                this.RaisePropertyChanged("EcommerceCountry");
            }
        }

        /// <summary>
        /// Gets or sets the zip code field.
        /// </summary>
        [DisplayOptions(ColumnSpan = 2)]
        [DataType(DataType.PhoneNumber)]
        [Display(ShortName = "Zip code")]
        public string ZipCode
        {
            get
            {
                return this.zipCode;
            }
            set
            {
                this.zipCode = value;
                this.RaisePropertyChanged("ZipCode");
            }
        }

        /// <summary>
        /// Gets or sets the comment field.
        /// </summary>
        [DisplayOptions(ColumnSpan = 4)]
        [DataType(DataType.MultilineText)]
        public string Comment
        {
            get
            {
                return this.comment;
            }
            set
            {
                this.comment = value;
                this.RaisePropertyChanged("Comment");
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
