#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser.SfPopupLayout
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class SwipingViewModel : INotifyPropertyChanged
    {

        private DataTemplate popupContentTemplate;

        public DataTemplate PopupContentTemplate
        {
            get
            {
                return popupContentTemplate;
            }
            set
            {
                popupContentTemplate = value;
                RaisePropertyChanged("PopupContentTemplate");
            }
        }

        public SwipingViewModel()
        {
            SetRowstoGenerate(100);
        }

        #region ItemsSource

        private OrderInfoRepository order;

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
            order = new OrderInfoRepository();
            ordersInfo = order.GetOrderDetails(count);
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
