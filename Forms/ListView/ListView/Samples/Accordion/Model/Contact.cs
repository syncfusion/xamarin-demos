#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
        private string contactImage;
        private bool isVisible = false;

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

        public string ContactImage
        {
            get { return this.contactImage; }
            set
            {
                this.contactImage = value;
                this.RaisedOnPropertyChanged("ContactImage");
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