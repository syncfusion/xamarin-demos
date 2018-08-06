#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using Syncfusion.XForms.DataForm;
using Xamarin.Forms.Internals;

namespace SampleBrowser
{
    [Preserve(AllMembers = true)]
    public class ContactInfo : INotifyPropertyChanged
    {
        #region Fields

        private string contactName;
        private string middelName;
        private string lastname;
        private string contactNo;
        private ImageSource image;
        private ContactsType contactType;
        private ContactsType emailType;
        private string email;
        private AddressType addressType;
        private string address;
        private DateTime birthDate;
        private string groupName;
        private Save saveTo;

        #endregion

        #region Constructor

        public ContactInfo()
        {

        }

        #endregion

        #region Public Properties
        [DisplayOptions( ColumnSpan = 2)]
        [Display(Prompt = "First Name", GroupName = "Name")]
        public string ContactName
        {
            get { return this.contactName; }
            set
            {
                this.contactName = value;
                RaisePropertyChanged("ContactName");
            }
        }

        [DisplayOptions(ShowLabel = false,ColumnSpan = 2)]
        [Display(Prompt = "Middle Name", GroupName = "Name")]
        public string MiddleName
        {
            get { return this.middelName; }
            set
            {
                this.middelName = value;
                RaisePropertyChanged("MiddleName");
            }
        }

        [DisplayOptions(ShowLabel = false, ColumnSpan = 2)]
        [Display(Prompt = "Last Name", GroupName = "Name")]
        public string LastName
        {
            get { return this.lastname; }
            set
            {
                this.lastname = value;
                RaisePropertyChanged("LastName");
            }
        }

        [Display(Prompt = "Phone")]
        [StringLength(10, ErrorMessage = "Phone number should not exceed 10 digits.")]
        public string ContactNumber
        {
            get { return contactNo; }
            set
            {
                this.contactNo = value;
                RaisePropertyChanged("ContactNumber");
            }
        }

        [DisplayOptions(ShowLabel = false)]
        public ContactsType ContactType
        {
            get { return contactType; }
            set
            {
                this.contactType = value;
                RaisePropertyChanged("ContactType");
            }
        }

        [Display(AutoGenerateField = false)]
        public ImageSource ContactImage
        {
            get { return this.image; }
            set
            {
                this.image = value;
                this.RaisePropertyChanged("ContactImage");
            }
        }

        [Display(Prompt = "Email")]
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                this.RaisePropertyChanged("Email");
            }
        }

        [DisplayOptions(ShowLabel = false)]
        public ContactsType EmailType
        {
            get { return emailType; }
            set
            {
                emailType = value;
                this.RaisePropertyChanged("EmailType");
            }
        }
        
        [Display(Prompt = "Address")]
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                this.RaisePropertyChanged("Address");
            }
        }

        [DisplayOptions(ShowLabel = false)]
        public AddressType AddressTypes
        {
            get { return addressType; }
            set
            {
                addressType = value;
                this.RaisePropertyChanged("AddressType");
            }
        }

        [DisplayOptions(ColumnSpan = 2)]
        [Display(Prompt = "Birth Date")]
        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                birthDate = value;
                this.RaisePropertyChanged("BirthDate");
            }
        }

        [DisplayOptions(ColumnSpan = 2)]
        [Display(Prompt = "Group")]
        public string GroupName
        {
            get { return groupName; }
            set
            {
                groupName = value;
                this.RaisePropertyChanged("GroupName");
            }
        }

        [DisplayOptions(ColumnSpan = 2)]
        [Display(Prompt = "Save To", ShortName = "Save To")]
        public Save SaveTo
        {
            get { return saveTo; }
            set
            {
                saveTo = value;
                this.RaisePropertyChanged("SaveTo");
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        public enum ContactsType
        {
            Home,
            Work,
            Mobile,
            Other,
            Business
        };

        public enum AddressType
        {
            Home,
            Office
        };

        public enum Save
        {
            Sim,
            Phone
        }
    }
}