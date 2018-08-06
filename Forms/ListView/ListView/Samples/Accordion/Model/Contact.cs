#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.ComponentModel;
using Xamarin.Forms;

namespace SampleBrowser.SfListView
{
    public class Contact : INotifyPropertyChanged
    {
        #region Fields

        private string contactName;
        private string callTime;
        private ImageSource contactImage;
        private ImageSource phoneImage;
        private bool isVisible = false;
        private ImageSource sendMessage;
        private ImageSource blockSpan;
        private ImageSource callDetails;
        private ImageSource addContact;
        private ImageSource newContact;

        #endregion

        #region Properties

        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                isVisible = value;
                this.RaisedOnPropertyChanged("IsVisible");
            }
        }

        public string ContactName
        {
            get { return contactName; }
            set
            {
                if (contactName != value)
                {
                    contactName = value;
                    this.RaisedOnPropertyChanged("ContactName");
                }
            }
        }

        public string CallTime
        {
            get { return callTime; }
            set
            {
                if (callTime != value)
                {
                    callTime = value;
                    this.RaisedOnPropertyChanged("CallTime");
                }
            }
        }

        public ImageSource ContactImage
        {
            get { return this.contactImage; }
            set
            {
                this.contactImage = value;
                this.RaisedOnPropertyChanged("ContactImage");
            }
        }

        public ImageSource AddContact
        {
            get { return this.addContact; }
            set
            {
                this.addContact = value;
                this.RaisedOnPropertyChanged("AddContact");
            }
        }

        public ImageSource NewContact
        {
            get { return this.newContact; }
            set
            {
                this.newContact = value;
                this.RaisedOnPropertyChanged("NewContact");
            }
        }

        public ImageSource SendMessage
        {
            get { return this.sendMessage; }
            set
            {
                this.sendMessage = value;
                this.RaisedOnPropertyChanged("SendMessage");
            }
        }

        public ImageSource BlockSpan
        {
            get { return this.blockSpan; }
            set
            {
                this.blockSpan = value;
                this.RaisedOnPropertyChanged("BlockSpan");
            }
        }

        public ImageSource CallDetails
        {
            get { return this.callDetails; }
            set
            {
                this.callDetails = value;
                this.RaisedOnPropertyChanged("CallDetails");
            }
        }

        public ImageSource PhoneImage
        {
            get { return this.phoneImage; }
            set
            {
                this.phoneImage = value;
                this.RaisedOnPropertyChanged("PhoneImage");
            }
        }

        #endregion

        #region Constrator

        public Contact()
        {

        }

        public Contact(string Name)
        {
            contactName = Name;
        }

        #endregion

        #region Interface Member

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisedOnPropertyChanged(string _PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
            }
        }

        #endregion
    }
}