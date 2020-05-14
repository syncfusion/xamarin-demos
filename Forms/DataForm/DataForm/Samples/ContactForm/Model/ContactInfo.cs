#region Copyright
// <copyright file="ContactInfo.cs" company="Syncfusion"> 
//  Copyright (c) Syncfusion Inc. 2001 - 2020. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright> 
#endregion

namespace SampleBrowser
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using Syncfusion.XForms.DataForm;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents the fields and properties of the data form.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ContactInfo : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// Represents the contact name of the contact information.
        /// </summary>
        private string contactName;

        /// <summary>
        /// Represents the middle name of the contact information.
        /// </summary>
        private string middelName;

        /// <summary>
        /// Represents the last name of the contact information.
        /// </summary>
        private string lastname;

        /// <summary>
        /// Represents the contact number of the contact information.
        /// </summary>
        private string contactNo;

        /// <summary>
        /// Represents the contact image.
        /// </summary>
        private ImageSource image;

        /// <summary>
        /// Represents the contact type of the contact information.
        /// </summary>
        private ContactsType contactType;

        /// <summary>
        /// Represents the email type of the contact information.
        /// </summary>
        private ContactsType emailType;

        /// <summary>
        /// Represents the email field of the contact information.
        /// </summary>
        private string email;

        /// <summary>
        /// Represents the address type of the contact information.
        /// </summary>
        private AddressType addressType;

        /// <summary>
        /// Represents the adress of the contact information.
        /// </summary>
        private string address;

        /// <summary>
        /// Represents the notes of the contact information.
        /// </summary>
        private string notes;

        /// <summary>
        /// Represents the birth date of the contact information.
        /// </summary>
        private DateTime birthDate;

        /// <summary>
        /// Represents the group name of the contact information.
        /// </summary>
        private string groupName;

        /// <summary>
        /// Represents the save field of the contact information.
        /// </summary>
        private Save saveTo;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactInfo"/> class.
        /// </summary>
        public ContactInfo()
        {
        }

        /// <summary>
        /// Represents a method that will handle when a property is changed on a component.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Describes the possible contact type values.
        /// </summary>
        public enum ContactsType
        {
            /// <summary>
            /// Represents home.
            /// </summary>
            Home,

            /// <summary>
            /// Represents work.
            /// </summary>
            Work,

            /// <summary>
            /// Represents other contact type.
            /// </summary>
            Other,
        }

        /// <summary>
        /// Describes the possible address type.
        /// </summary>
        public enum AddressType
        {
            /// <summary>
            /// Represents home.
            /// </summary>
            Home,

            /// <summary>
            /// Represents office.
            /// </summary>
            Office
        }

        /// <summary>
        /// Describes the possible types to save.
        /// </summary>
        public enum Save
        {
            /// <summary>
            /// Represents sim.
            /// </summary>
            Sim,

            /// <summary>
            /// Represents phone.
            /// </summary>
            Phone
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the contact field in the contacts information.
        /// </summary>
        [DisplayOptions(ColumnSpan = 5)]
        [Display( GroupName = "Name", Order = 1 , ShortName ="Contact name")]
        public string ContactName
        {
            get
            {
                return this.contactName;
            }

            set
            {
                this.contactName = value;
                this.RaisePropertyChanged("ContactName");
            }
        }

        /// <summary>
        /// Gets or sets the middle name field in the contacts information.
        /// </summary>
        [DisplayOptions(ColumnSpan = 5)]
        [Display( GroupName = "Name", Order = 2, ShortName = "Middle name")]
        public string MiddleName
        {
            get
            {
                return this.middelName;
            }

            set
            {
                this.middelName = value;
                this.RaisePropertyChanged("MiddleName");
            }
        }

        /// <summary>
        /// Gets or sets the last name in the contacts information.
        /// </summary>
        [DisplayOptions(ColumnSpan = 5)]
        [Display( GroupName = "Name", Order = 3, ShortName = "Last name")]
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
        /// Gets or sets the contact number field in the contacts information.
        /// </summary>
        [Display( Order = 4, ShortName = "Contact number")]
        [DisplayOptions(ColumnSpan = 3)]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10, ErrorMessage = "Phone number should not exceed 10 digits.")]
        public string ContactNumber
        {
            get
            {
                return this.contactNo;
            }

            set
            {
                this.contactNo = value;
                this.RaisePropertyChanged("ContactNumber");
            }
        }

        /// <summary>
        /// Gets or sets the contact type in the contacts information.
        /// </summary>
        [DisplayOptions(ShowLabel = false , ColumnSpan = 2)]
        [Display(Order = 5)]
        public ContactsType ContactType
        {
            get
            {
                return this.contactType;
            }

            set
            {
                this.contactType = value;
                this.RaisePropertyChanged("ContactType");
            }
        }

        /// <summary>
        /// Gets or sets the contact image in the contacts information.
        /// </summary>
        [Display(AutoGenerateField = false)]
        public ImageSource ContactImage
        {
            get
            {
                return this.image;
            }

            set
            {
                this.image = value;
                this.RaisePropertyChanged("ContactImage");
            }
        }

        /// <summary>
        /// Gets or sets the email field in the contacts information.
        /// </summary>
        [Display( Order = 6)]
        [DisplayOptions(ColumnSpan = 3)]
        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
                this.RaisePropertyChanged("Email");
            }
        }

        /// <summary>
        /// Gets or sets the email type in the contacts information.
        /// </summary>
        [DisplayOptions(ShowLabel = false , ColumnSpan = 2)]
        [Display(Order = 7)]
        public ContactsType EmailType
        {
            get
            {
                return this.emailType;
            }

            set
            {
                this.emailType = value;
                this.RaisePropertyChanged("EmailType");
            }
        }

        /// <summary>
        /// Gets or sets the address field in the contacts information.
        /// </summary>
        [Display( Order = 8)]
        [DisplayOptions(ColumnSpan = 3)]
        public string Address
        {
            get
            {
                return this.address;
            }

            set
            {
                this.address = value;
                this.RaisePropertyChanged("Address");
            }
        }

        /// <summary>
        /// Gets or sets the address type in the contacts information.
        /// </summary>
        [DisplayOptions(ShowLabel = false, ColumnSpan = 2)]
        [Display(Order = 9)]
        public AddressType AddressTypes
        {
            get
            {
                return this.addressType;
            }

            set
            {
                this.addressType = value;
                this.RaisePropertyChanged("AddressType");
            }
        }

        /// <summary>
        /// Gets or sets the notes field in the contacts information.
        /// </summary>
        [DataType(DataType.MultilineText)]
        [Display( Order = 10)]
        [DisplayOptions(ColumnSpan = 5)]
        public string Notes
        {
            get
            {
                return this.notes;
            }

            set
            {
                this.notes = value;
                this.RaisePropertyChanged("Notes");
            }
        }

        /// <summary>
        /// Gets or sets the birth date field in the contacts information.
        /// </summary>
        [Display( Order = 11, ShortName = "Birth date")]
        [DisplayOptions(ColumnSpan = 5)]
        public DateTime BirthDate
        {
            get
            {
                return this.birthDate;
            }

            set
            {
                this.birthDate = value;
                this.RaisePropertyChanged("BirthDate");
            }
        }

        /// <summary>
        /// Gets or sets the group name field in the contacts information.
        /// </summary>
        [Display(Order = 12, ShortName = "Group name")]
        [DisplayOptions(ColumnSpan = 5)]
        public string GroupName
        {
            get
            {
                return this.groupName;
            }

            set
            {
                this.groupName = value;
                this.RaisePropertyChanged("GroupName");
            }
        }

        /// <summary>
        /// Gets or sets the save field in the contacts information.
        /// </summary>
        [Display(ShortName = "Save To", Order = 13)]
        [DisplayOptions(ColumnSpan = 5)]
        public Save SaveTo
        {
            get
            {
                return this.saveTo;
            }

            set
            {
                this.saveTo = value;
                this.RaisePropertyChanged("SaveTo");
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation

        /// <summary>
        /// Occurs when propery value is changed.
        /// </summary>
        /// <param name="name">Property name</param>
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