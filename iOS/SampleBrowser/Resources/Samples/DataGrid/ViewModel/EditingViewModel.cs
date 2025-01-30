using Syncfusion.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SampleBrowser
{
    public class EditingViewModel : INotifyPropertyChanged
    {
        #region Constructor

        public EditingViewModel()
        {
            DealerRepository dealerrep = new DealerRepository();
            dealerInformation = dealerrep.GetDealerDetails(100);
            this.CustomerNames = dealerrep.Customers.ToObservableCollection();
        }

        #endregion

        #region ItemsSource

        private ObservableCollection<DealerInfo> dealerInformation;

        public ObservableCollection<DealerInfo> DealerInformation
        {
            get { return this.dealerInformation; }
            set { this.dealerInformation = value; }
        }

        public ObservableCollection<string> CustomerNames { get; set; }

        #endregion

        #region Property Changed

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