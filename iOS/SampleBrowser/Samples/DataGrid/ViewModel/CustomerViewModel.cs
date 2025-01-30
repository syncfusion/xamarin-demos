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
