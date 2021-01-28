#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfTabView
{
    [Preserve(AllMembers = true)]
    public class ContactsInfo : INotifyPropertyChanged
    {
        #region Fields

        private string contactName;
        private string contactNo;
        private string image;
        private string contactType;
        private string date;
        private string message;
        private bool read = false;
        private string messageCount;
        private string dateMonth;

        #endregion

        #region Constructor

        public ContactsInfo()
        {
          
        }

        #endregion

        #region Public Properties

        public string ContactName
        {
            get { return this.contactName; }
            set
            {
                this.contactName = value;
                RaisePropertyChanged("ContactName");
            }
        }

        public string ContactNumber
        {
            get { return contactNo; }
            set
            {
                this.contactNo = value;
                RaisePropertyChanged("ContactNumber");
            }
        }

        public string ContactReadType
        {
            get { return contactType; }
            set
            {
                this.contactType = value;
                RaisePropertyChanged("ContactReadType");
            }
        }

        public string ContactImage
        {
            get { return this.image; }
            set
            {
                this.image = value;
                this.RaisePropertyChanged("ContactImage");
            }
        }

        public string Message
        {
            get { return this.message; }
            set
            {
                this.message = value;
                this.RaisePropertyChanged("Message");
            }
        }

        public bool Read
        {
            get { return this.read; }
            set
            {
                this.read = value;
                this.RaisePropertyChanged("Read");
            }
        }

        public string Date
        {
            get { return this.date; }
            set
            {
                this.date = value;
                this.RaisePropertyChanged("Date");
            }
        }
        public string DateMonth
        {
            get { return this.dateMonth; }
            set
            {
                this.dateMonth = value;
                this.RaisePropertyChanged("DateMonth");
            }
        }
        public string MessageCount
        {
            get { return this.messageCount; }
            set
            {
                this.messageCount = value;
                this.RaisePropertyChanged("MessageCount");
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
    }
}
