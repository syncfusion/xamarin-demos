using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace SampleBrowser
{
    public class LoadMoreViewModel : INotifyPropertyChanged
    {
        #region Fields

        private OrderDetailsRepository order;
        private ObservableCollection<OrderInfo> ordersInfo;

        #endregion

        #region Constructor

        public LoadMoreViewModel()
        {
            SetRowstoGenerate(30);
        }

        #endregion

        #region ItemsSource

        public ObservableCollection<OrderInfo> OrdersInfo
        {
            get { return ordersInfo; }
            set
            {
                this.ordersInfo = value;
                RaisePropertyChanged("OrdersInfo");
            }
        }

        #endregion

        #region ItemSource Generator

        public void SetRowstoGenerate(int count)
        {
            order = new OrderDetailsRepository();
            ordersInfo = order.GetOrderDetails(count);
        }

        #endregion

        #region LoadMore Generator

        internal void LoadMoreItems()
        {
            for (int i = 0; i < 20; i++)
                this.OrdersInfo.Add(order.GenerateOrder(OrdersInfo.Count + 1));
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
