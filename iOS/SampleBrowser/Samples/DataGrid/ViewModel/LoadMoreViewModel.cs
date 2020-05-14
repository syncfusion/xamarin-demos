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
