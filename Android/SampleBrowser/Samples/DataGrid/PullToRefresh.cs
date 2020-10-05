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
using Syncfusion.SfDataGrid;
using System.Globalization;
using System.Threading.Tasks;
using Syncfusion.SfPullToRefresh;

namespace SampleBrowser
{
    public class PullToRefresh:SamplePage
    {
        SfPullToRefresh pullToRefresh;
        SfDataGrid sfGrid;
        PullToRefreshViewModel viewModel;

        public override View GetSampleContent(Context context)
        {
            pullToRefresh = new SfPullToRefresh(context);
            pullToRefresh.Refreshing += Pull_Refreshing;
            sfGrid = new SfDataGrid(context);
            sfGrid.HeaderRowHeight = 52;
            pullToRefresh.RefreshContentThreshold = 52;
            sfGrid.RowHeight = 48;
            viewModel = new PullToRefreshViewModel();
            sfGrid.SelectionMode = SelectionMode.Single;
            viewModel.SetRowstoGenerate(100);
            sfGrid.AutoGenerateColumns = false;
            sfGrid.ColumnSizer = ColumnSizer.Star;
            GridGenerateColumns();
            sfGrid.ItemsSource = (viewModel.OrdersInfo);
            sfGrid.AllowResizingColumn = true;
            sfGrid.VerticalOverScrollMode = VerticalOverScrollMode.None;
            pullToRefresh.PullableContent = sfGrid;
            return pullToRefresh;
        }

        #region Private Methods

        void GridGenerateColumns()
        {
            sfGrid.Columns.Add(new GridTextColumn() { MappingName = "OrderID", HeaderText = "Order ID" });
            sfGrid.Columns.Add(new GridTextColumn() { MappingName = "CustomerID", HeaderText = "Customer ID", TextAlignment = GravityFlags.CenterVertical });
            sfGrid.Columns.Add(new GridTextColumn() { MappingName = "Freight", Format = "C", CultureInfo = new CultureInfo("en-US"), TextAlignment = GravityFlags.Center });
            sfGrid.Columns.Add(new GridTextColumn() { MappingName = "ShipCity", HeaderText = "Ship City", TextAlignment = GravityFlags.CenterVertical });
        }

        private async void Pull_Refreshing(object sender, RefreshingEventArgs e)
        {
            await Task.Delay(4000);
            if (viewModel != null)
            {
                viewModel.ItemsSourceRefresh();
                e.Refreshed = true;
            }
        }

        #endregion

        public override void Destroy()
        {
            pullToRefresh.Refreshing -= Pull_Refreshing;
            viewModel = null;
            pullToRefresh.Dispose();
            pullToRefresh = null;
        }
    }
}