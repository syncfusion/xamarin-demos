#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "DataGridPullToRefreshViewModel.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfPullToRefresh
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// A ViewModel for DataGridPullToRefresh sample.
    /// </summary>
    public class DataGridPullToRefreshViewModel : INotifyPropertyChanged
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private readonly Random random = new Random();
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private OrderInfoRepository order;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private ObservableCollection<OrderInfo> ordersInfo;

        /// <summary>
        /// Initializes a new instance of the DataGridPullToRefreshViewModel class.
        /// </summary>
        public DataGridPullToRefreshViewModel()
        {
            this.SetRowstoGenerate(100);
        }

        /// <summary>
        /// Represents the method that will handle the <see cref="E:System.ComponentModel.INotifyPropertyChanged.PropertyChanged"></see> event raised when a property is changed on a component
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #region ItemsSource

        /// <summary>
        /// Gets or sets the OrdersInfo type of ObservableCollection and notifies user when collection value gets changed.
        /// </summary>
        public ObservableCollection<OrderInfo> OrdersInfo
        {
            get => this.ordersInfo;
            set
            {
                this.ordersInfo = value;
                this.RaisePropertyChanged("OrdersInfo");
            }
        }

        #endregion

        #region ItemSource Generator

        /// <summary>
        /// Used to generate rows.
        /// </summary>
        /// <param name="count">records count value</param>
        public void SetRowstoGenerate(int count)
        {
            this.order = new OrderInfoRepository();
            this.ordersInfo = this.order.GetOrderDetails(count);
        }

        #endregion

        /// <summary>
        /// Used to add More Items in View while calling Refresh View
        /// </summary>
        internal void ItemsSourceRefresh()
        {
            int count = this.random.Next(1, 6);

            for (int i = 11000; i < 11000 + count; i++)
            {
                int val = i + this.random.Next(100, 150);
                this.OrdersInfo.Insert(0, this.order.RefreshItemsource(val));
            }
        }

        #region INotifyPropertyChanged implementation

        /// <summary>
        /// Triggers when Items Collections Changed.
        /// </summary>
        /// <param name="name">string type parameter represent propertyName as name</param>
        private void RaisePropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }
}