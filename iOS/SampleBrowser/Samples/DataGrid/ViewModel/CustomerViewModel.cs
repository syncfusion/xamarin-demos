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

namespace SampleBrowser
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        #region Constructor

        public CustomerViewModel()
        {
            CustomersRepository customerrep = new CustomersRepository();
            customerInformation = customerrep.GetCutomerDetails(100);
        }

        #endregion

        #region ItemsSource

        private ObservableCollection<CustomerDetails> customerInformation;

        public ObservableCollection<CustomerDetails> CustomerInformation
        {
            get { return this.customerInformation; }
            set { this.customerInformation = value; }
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
