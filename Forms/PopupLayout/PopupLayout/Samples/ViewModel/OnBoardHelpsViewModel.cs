#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "OnBoardHelpsViewModel.cs" company="Syncfusion.com">
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
    using System.Reflection;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// A ViewModel for OnBoardHelps sample.
    /// </summary>
    public class OnBoardHelpsViewModel : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// Holds the instance of the repository.
        /// </summary>
        private OrderInfoRepository order;

        /// <summary>
        /// Backing field for OrdersInfo collection.
        /// </summary>
        private ObservableCollection<OrderInfo> ordersInfo;

        /// <summary>
        /// Backing field for the DeleteCommand.
        /// </summary>
        private Command<OrderInfo> deleteCommand;

        /// <summary>
        /// Backing field for the CurrentRotatorItemIndex.
        /// </summary>
        private int currentRotatorItemIndex;

        /// <summary>
        /// Backing field for the NextLabelVisibility.
        /// </summary>
        private bool nextLabelVisibility;

        /// <summary>
        /// Backing field for the OkLabelVisibility.
        /// </summary>
        private bool labelOkVisibility;

        /// <summary>
        /// Backing field for the OverlayVisibility.
        /// </summary>
        private bool overlayVisibility;

        /// <summary>
        /// Backing field for the popupVisibility.
        /// </summary>
        private bool popupIsOpen;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the OnBoardHelpsViewModel class.
        /// </summary>
        public OnBoardHelpsViewModel()
        {
            this.SetRowstoGenerate(100);
            this.DeleteCommand = new Command<OrderInfo>(this.DeleteRowData);
            this.SetBindingImageSource();
            this.ChangeRotatorItem = new Command(this.SelectNextRotatorItem);
            this.CurrentRotatorItemIndex = 0;
            this.NextLabelVisibility = true;
            this.OkLabelVisibility = false;
            this.OverlayVisibility = true;
            this.OverlayColor = Color.FromRgba(0, 0, 0, 0.7);
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

        /// <summary>
        /// Gets or sets the source for the HandSymbol Image for drag and drop illustration.
        /// </summary>
        public string HandSymbolImage { get; set; }

        /// <summary>
        /// Gets or sets the source for the layout image for drag and drop illustration.
        /// </summary>
        public string DragAndDropLayoutImage { get; set; }

        /// <summary>
        /// Gets or sets the source for the Editing illustration Image.
        /// </summary>
        public string EditingIllustrationImage { get; set; }

        /// <summary>
        /// Gets or sets the source for the Resizing illustration Image.
        /// </summary>
        public string ResizingIllustrationImage { get; set; }

        /// <summary>
        /// Gets or sets the source for the Swiping illustration Image.
        /// </summary>
        public string SwipingIllustrationImage { get; set; }

        /// <summary>
        /// Gets or sets the command for changing the rotator item.
        /// </summary>
        public Command ChangeRotatorItem { get; set; }

        /// <summary>
        /// Gets or sets the background color for the Overlay.
        /// </summary>
        public Color OverlayColor { get; set; }

        /// <summary>
        /// Gets or sets the current item's index in the rotator.
        /// </summary>
        public int CurrentRotatorItemIndex
        {
            get
            {
                return this.currentRotatorItemIndex;
            }

            set
            {
                this.currentRotatorItemIndex = value;
                this.RaisePropertyChanged("CurrentRotatorItemIndex");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether next label should be visible or not.
        /// </summary>
        public bool NextLabelVisibility
        {
            get
            {
                return this.nextLabelVisibility;
            }

            set
            {
                this.nextLabelVisibility = value;
                this.RaisePropertyChanged("NextLabelVisibility");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether ok label should be visible or not.
        /// </summary>
        public bool OkLabelVisibility
        {
            get
            {
                return this.labelOkVisibility;
            }

            set
            {
                this.labelOkVisibility = value;
                this.RaisePropertyChanged("OkLabelVisibility");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether overlay should be visible or not.
        /// </summary>
        public bool OverlayVisibility
        {
            get
            {
                return this.overlayVisibility;
            }

            set
            {
                this.overlayVisibility = value;
                this.RaisePropertyChanged("OverlayVisibility");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether popup is open or not.
        /// </summary>
        public bool PopupIsOpen
        {
            get
            {
                return this.popupIsOpen;
            }

            set
            {
                this.popupIsOpen = value;
                this.RaisePropertyChanged("PopupIsOpen");
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

        /// <summary>
        /// Sets the ImageSource for the Images.
        /// </summary>
        private void SetBindingImageSource()
        {
            this.HandSymbolImage = "HandSymbol.png";
            this.EditingIllustrationImage = "EditIllustration.png";
            this.ResizingIllustrationImage = "ResizingIllustration.png";
            this.SwipingIllustrationImage = "SwipeIllustration.png";
            this.DragAndDropLayoutImage = "DragAndDropIllustration.png";
        }

        /// <summary>
        /// Selects the next item in the rotator.
        /// </summary>
        private void SelectNextRotatorItem()
        {
            if (this.CurrentRotatorItemIndex < 2)
            {
                this.CurrentRotatorItemIndex++;
            }
            else if (this.CurrentRotatorItemIndex == 2)
            {
                this.NextLabelVisibility = false;
                this.OkLabelVisibility = true;
                this.CurrentRotatorItemIndex++;
            }
            else
            {
                this.OkLabelVisibility = false;
                this.OverlayVisibility = false;
                this.PopupIsOpen = false;
            }
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