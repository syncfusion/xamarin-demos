using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SampleBrowser
{
    public class SalesInfoViewModel
    {
        #region Constructor

        public SalesInfoViewModel()
        {

        }

        #endregion

        #region ItemsSource

        private ObservableCollection<SalesByDate> dailySalesDetails = null;

        public ObservableCollection<SalesByDate> DailySalesDetails
        {
            get
            {
                if (dailySalesDetails == null)
                {
                    dailySalesDetails = new SalesInfoRepository().GetSalesDetailsByDay(60);
                }
                return dailySalesDetails;
            }
        }

        #endregion
    }
}
