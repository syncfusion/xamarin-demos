using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace SampleBrowser
{
    public class ContatsViewModel
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
            set { this.contactsList = value; }
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
