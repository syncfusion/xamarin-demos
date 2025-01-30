using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SampleBrowser
{
    public class ExportingViewModel
    {
        #region Constructor 

        public ExportingViewModel()
        {
            OrderDetailsRepository order = new OrderDetailsRepository();
            OrdersInfo = order.GetOrderDetails(100);
        }

        #endregion

        #region ItemsSource

        private ObservableCollection<OrderInfo> _ordersInfo;

        public ObservableCollection<OrderInfo> OrdersInfo
        {
            get { return _ordersInfo; }
            set { this._ordersInfo = value; }
        }

        #endregion
    }
}
