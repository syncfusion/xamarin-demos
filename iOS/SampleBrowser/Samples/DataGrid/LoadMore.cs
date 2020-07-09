#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using CoreGraphics;
using Syncfusion.SfDataGrid;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using UIKit;

namespace SampleBrowser
{
    public class LoadMore:SampleView
    {
        #region Fields

        SfDataGrid SfGrid;
        LoadMoreViewModel viewModel;

        #endregion

        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public LoadMore()
        {
            this.SfGrid = new SfDataGrid();
            this.SfGrid.SelectionMode = SelectionMode.Single;
            viewModel = new LoadMoreViewModel();
            this.SfGrid.AutoGeneratingColumn += GridAutoGenerateColumns;
            this.SfGrid.ItemsSource = viewModel.OrdersInfo;
            this.SfGrid.ShowRowHeader = false;
            this.SfGrid.HeaderRowHeight = 45;
            this.SfGrid.RowHeight = 45;
            this.SfGrid.AllowLoadMore = true;
            this.SfGrid.GridStyle = new LoadMoreStyle();
            this.SfGrid.LoadMoreCommand = new Command(ExecuteCommand);
            this.AddSubview(this.SfGrid);
        }


        void GridAutoGenerateColumns(object sender, AutoGeneratingColumnEventArgs e)
        {
            if (e.Column.MappingName == "OrderID")
            {
                e.Column.HeaderText = "Order ID";
                e.Column.TextAlignment = UITextAlignment.Center;
            }
            else if (e.Column.MappingName == "CustomerID")
            {
                e.Column.HeaderText = "Customer ID";
                e.Column.TextMargin = 10;
                e.Column.TextAlignment = UITextAlignment.Left;
            }
            else if (e.Column.MappingName == "Freight")
            {
                e.Column.Format = "C";
                e.Column.CultureInfo = new CultureInfo("en-US");
                e.Column.TextAlignment = UITextAlignment.Center;
            }
            else if (e.Column.MappingName == "ShipCity")
            {
                e.Column.HeaderText = "Ship City";
                e.Column.TextMargin = 10;
                e.Column.TextAlignment = UITextAlignment.Left;
            }
            else if (e.Column.MappingName == "ShipCountry")
            {
                e.Column.HeaderText = "Ship Country";
                e.Column.TextMargin = 10;
                e.Column.TextAlignment = UITextAlignment.Left;
            }
            else if (e.Column.MappingName == "Index")
            {
                e.Column.TextAlignment = UITextAlignment.Center;
            }
            else if (e.Column.MappingName == "EmployeeID")
            {
                e.Column.HeaderText = "Employee ID";
                e.Column.TextAlignment = UITextAlignment.Center;
            }
            else if (e.Column.MappingName == "FirstName")
            {
                e.Column.HeaderText = "First Name";
                e.Column.TextMargin = 10;
                e.Column.TextAlignment = UITextAlignment.Left;
            }
            else if (e.Column.MappingName == "LastName")
            {
                e.Column.HeaderText = "Last Name";
                e.Column.TextMargin = 10;
                e.Column.TextAlignment = UITextAlignment.Left;
            }
            else if (e.Column.MappingName == "Gender")
            {
                e.Column.TextAlignment = UITextAlignment.Left;
                e.Column.TextMargin = 10;
            }
            else if (e.Column.MappingName == "ShippingDate")
            {
                e.Column.HeaderText = "Shipping Date";
                e.Column.TextMargin = 15;
                e.Column.TextAlignment = UITextAlignment.Left;
                e.Column.Format = "d";
            }
            else if (e.Column.MappingName == "IsClosed")
            {
                e.Column.HeaderText = "Is Closed";
                e.Column.TextMargin = 15;
                e.Column.TextAlignment = UITextAlignment.Left;
            }
        }

        private async void ExecuteCommand()
        {
            try
            {
                this.SfGrid.IsBusy = true;
                await Task.Delay(new TimeSpan(0, 0, 3));
                this.viewModel.LoadMoreItems();
                this.SfGrid.IsBusy = false;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        public override void LayoutSubviews()
        {
            this.SfGrid.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);
            base.LayoutSubviews();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (SfGrid != null)
                {
                    SfGrid.AutoGeneratingColumn -= GridAutoGenerateColumns;
                    SfGrid.Dispose();
                }
                viewModel = null;
                SfGrid = null;
            }
                base.Dispose(disposing);
        }
    }

    public class LoadMoreStyle : DataGridStyle
    {
        public LoadMoreStyle()
        {

        }

        public override UIColor GetLoadMoreViewBackgroundColor()
        {

            return UIColor.FromRGB(224, 224, 224);

        }

        public override UIColor GetLoadMoreViewForegroundColor()
        {

            return UIColor.FromRGB(0, 0, 0);

        }

        public override GridLinesVisibility GetGridLinesVisibility()
        {
            return GridLinesVisibility.Horizontal;
        }
    }
}
