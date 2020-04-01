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
using System.Text;

namespace SampleBrowser
{
    public class GridGettingStartedViewModel
    {
        private OrderDetailsRepository order;

        public GridGettingStartedViewModel()
        {
            order = new OrderDetailsRepository();
            OrdersInfo = order.GetOrderDetails(100);
        }

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
