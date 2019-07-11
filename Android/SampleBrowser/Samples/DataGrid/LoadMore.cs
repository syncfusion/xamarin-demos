#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using System.Globalization;
using Syncfusion.SfDataGrid;
using Android.Graphics;

namespace SampleBrowser
{
    public class LoadMore : SamplePage
    {
        SfDataGrid sfGrid;
        LoadMoreViewModel viewModel;

        public override Android.Views.View GetSampleContent(Android.Content.Context context)
        {
            sfGrid = new SfDataGrid(context);
            viewModel = new LoadMoreViewModel();
            viewModel.SetRowstoGenerate(30);
            sfGrid.SelectionMode = SelectionMode.Single;
            sfGrid.AutoGeneratingColumn += GridGenerateColumns;
            sfGrid.ItemsSource = (viewModel.OrdersInfo);
            sfGrid.AllowLoadMore = true;
            sfGrid.VerticalOverScrollMode = VerticalOverScrollMode.None;
            this.sfGrid.LoadMoreCommand = new Command(ExecuteCommand);
            this.sfGrid.GridStyle = new LoadMoreStyle();
            sfGrid.LoadMoreView.Alpha = 0.1f;
         
            return sfGrid;
        }
        #region Private Methods

        void GridGenerateColumns(object sender, AutoGeneratingColumnEventArgs e)
        {
            if (e.Column.MappingName == "OrderID")
            {
                e.Column.HeaderText = "Order ID";
            }
            else if (e.Column.MappingName == "CustomerID")
            {
                e.Column.HeaderText = "Customer ID";
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            }
            else if (e.Column.MappingName == "Freight")
            {
                e.Column.Format = "C";
                e.Column.CultureInfo = new CultureInfo("en-US");
                e.Column.TextAlignment = GravityFlags.Center;
            }
            else if (e.Column.MappingName == "ShipCity")
            {
                e.Column.HeaderText = "Ship City";
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            }
            else if (e.Column.MappingName == "ShipCountry")
            {
                e.Column.HeaderText = "Ship Country";
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            }
            else if (e.Column.MappingName == "EmployeeID")
            {
                e.Column.HeaderText = "Employee ID";
                e.Column.TextAlignment = GravityFlags.Center;
            }
            else if (e.Column.MappingName == "FirstName")
            {
                e.Column.HeaderText = "First Name";
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            }
            else if (e.Column.MappingName == "LastName")
            {
                e.Column.HeaderText = "Last Name";
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            }
            else if (e.Column.MappingName == "Gender")
            {
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            }
            else if (e.Column.MappingName == "ShippingDate")
            {
                e.Column.HeaderText = "Shipping Date";
                e.Column.Format = "d";
            }
            else if (e.Column.MappingName == "IsClosed")
            {
                e.Column.HeaderText = "Is Closed";
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            }
        }

        private async void ExecuteCommand()
        {
            try
            {
                this.sfGrid.IsBusy = true;
                await Task.Delay(new TimeSpan(0, 0, 3));
                this.viewModel.LoadMoreItems();
                this.sfGrid.IsBusy = false;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        #endregion
        public override void Destroy()
        {
            sfGrid.AutoGeneratingColumn -= GridGenerateColumns;
            sfGrid.Dispose();
            sfGrid = null;
            viewModel = null;
        }

        public class LoadMoreStyle : DataGridStyle
        {
            public LoadMoreStyle()
            {

            }

            public override Color GetLoadMoreViewBackgroundColor()
            {

            return Color.ParseColor("#E0E0E0");

            }

            public override Color GetLoadMoreViewForegroundColor()
            {

            return Color.ParseColor("#000000");

            }

            public override GridLinesVisibility GetGridLinesVisibility()
            {
                return GridLinesVisibility.Horizontal;
            }
        }

    }
}