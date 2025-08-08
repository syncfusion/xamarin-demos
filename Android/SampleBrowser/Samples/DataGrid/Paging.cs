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
using Syncfusion.SfDataGrid.DataPager;
using System.Globalization;

namespace SampleBrowser
{
    public class Paging:SamplePage
    {
        SfDataGrid sfGrid;
        PagingViewModel viewModel;
        SfDataPager sfDataPager;

        public override Android.Views.View GetSampleContent(Android.Content.Context context)
        {
            sfDataPager = new SfDataPager(context);
            sfGrid = new SfDataGrid(context);
            sfGrid.SelectionMode = SelectionMode.Single;
            viewModel = new PagingViewModel();
            sfDataPager.PageSize = 15;
            sfDataPager.Source =  viewModel.OrdersInfo;
            sfDataPager.NumericButtonCount = 20;
            sfGrid.AutoGeneratingColumn += GridGenerateColumns;
            sfGrid.ItemsSource = sfDataPager.PagedSource;
            sfGrid.VerticalOverScrollMode = VerticalOverScrollMode.None;

            LinearLayout linearLayout = new LinearLayout(context);
            linearLayout.Orientation = Orientation.Vertical;
            linearLayout.AddView(sfDataPager, new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)SfDataGridHelpers.ConvertDpToPixels(this.sfGrid, 75)));
            linearLayout.AddView(sfGrid);

            return linearLayout;
        }

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

        public override void Destroy()
        {
            sfGrid.AutoGeneratingColumn -= GridGenerateColumns;
            sfGrid.Dispose();
            sfGrid = null;
            viewModel = null;
        }
    }
}