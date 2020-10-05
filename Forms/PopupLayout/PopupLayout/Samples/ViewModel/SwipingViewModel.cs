#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "SwipingViewModel.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------ 
#endregion
namespace SampleBrowser.SfPopupLayout
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// A ViewModel for Swiping sample.
    /// </summary>
    public class SwipingViewModel : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// Holds the instance of the repository.
        /// </summary>
        private OrderInfoRepository order;

        /// <summary>
        /// backing field for OrdersInfo collection.
        /// </summary>
        private ObservableCollection<OrderInfo> ordersInfo;

        /// <summary>
        /// backing field for the DeleteCommand.
        /// </summary>
        private Command<OrderInfo> deleteCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the SwipingViewModel class.
        /// </summary>
        public SwipingViewModel()
        {
            this.SetRowstoGenerate(100);
            this.DeleteCommand = new Command<OrderInfo>(this.DeleteRowData);
        }

        #endregion

        #region Events

        /// <summary>
        /// Represents the method that will handle the <see cref="E:System.ComponentModel.INotifyPropertyChanged.PropertyChanged"></see> event raised when a property is changed on a component
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties        

        /// <summary>
        /// Gets or sets the Command that is executed when Delete is clicked.
        /// </summary>
        public Command<OrderInfo> DeleteCommand
        {
            get
            {
                return this.deleteCommand;
            }

            set
            {
                this.deleteCommand = value;
                this.RaisePropertyChanged("DeleteCommand");
            }
        }        

        #region ItemsSource

        /// <summary>
        /// Gets or sets the OrdersInfo and notifies when user value gets changed.
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

        #endregion

        #region ItemSource Generator

        /// <summary>
        /// Generates Rows with given count
        /// </summary>
        /// <param name="count">integer type of parameter named as count</param>
        public void SetRowstoGenerate(int count)
        {
            this.order = new OrderInfoRepository();
            this.ordersInfo = this.order.GetOrderDetails(count);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Deletes the row data.
        /// </summary>
        /// <param name="bindingObject">The binding object.</param>
        private void DeleteRowData(OrderInfo bindingObject)
        {
            this.OrdersInfo.Remove(bindingObject);
        }

        #endregion

        #region INotifyPropertyChanged implementation

        /// <summary>
        /// Triggers when Items Collections Changed.
        /// </summary>
        /// <param name="name">string type parameter named as name</param>
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