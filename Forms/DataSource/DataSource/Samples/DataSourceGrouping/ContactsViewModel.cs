#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms.Internals;

namespace SampleBrowser.DataSource
{
    [Preserve(AllMembers = true)]
    public class ContatsViewModel : INotifyPropertyChanged
    {
        #region Constructor

        public ContatsViewModel()
        {
            ContactsList = new ContactsLists();
        }

        #endregion

        #region ItemsSource

        private ContactsLists contactsList;

        public ContactsLists ContactsList
        {
            get { return this.contactsList; }
            set
            {
                if (this.contactsList != value)
                {
                    this.contactsList = value;
                    this.OnPropertyChanged("ContactsList");
                }
            }
        }

        #endregion

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        #endregion
    }
}
