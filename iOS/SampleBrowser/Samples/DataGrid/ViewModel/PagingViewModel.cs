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
    public class PagingViewModel : INotifyPropertyChanged
    {
        public PagingViewModel()
        {
            SetRowstoGenerate(300);
        }

        #region ItemsSource

        private OrderDetailsRepository order;

        private ObservableCollection<OrderInfo> ordersInfo;

        public ObservableCollection<OrderInfo> OrdersInfo
        {
            get { return ordersInfo; }
            set { this.ordersInfo = value; RaisePropertyChanged("OrdersInfo"); }
        }

        #endregion

        #region ItemSource Generator

        public void SetRowstoGenerate(int count)
        {
            order = new OrderDetailsRepository();
            ordersInfo = order.GetOrderDetails(count);
        }

        #endregion

        private Random random = new Random();

        internal void ItemsSourceRefresh()
        {
            var count = random.Next(1, 6);

            for (int i = 11000; i < 11000 + count; i++)
            {
                int val = i + random.Next(100, 150);
                this.OrdersInfo.Insert(0, order.RefreshItemsource(val));
            }
        }

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
