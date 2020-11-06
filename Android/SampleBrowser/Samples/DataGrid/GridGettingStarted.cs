#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfDataGrid;
using Android.Views;
using System.Globalization;

namespace SampleBrowser
{
	public class GridGettingStarted:SamplePage
	{
		SfDataGrid sfGrid;
		GettingStartedViewModel viewModel;
        
		public override Android.Views.View GetSampleContent (Android.Content.Context context)
		{
			sfGrid = new SfDataGrid (context);
			viewModel = new GettingStartedViewModel ();
            sfGrid.SelectionMode = SelectionMode.Single;
			viewModel.SetRowstoGenerate (100);
			sfGrid.AutoGeneratingColumn += GridGenerateColumns;
			sfGrid.ItemsSource = (viewModel.OrdersInfo);
            sfGrid.AllowResizingColumn = true;
            sfGrid.VerticalOverScrollMode = VerticalOverScrollMode.None;
            return sfGrid;
		}

       
        void GridGenerateColumns (object sender, AutoGeneratingColumnEventArgs e)
		{
            if (MainActivity.IsTablet)
                e.Column.MaximumWidth = 300;
            else
                e.Column.MaximumWidth = 150;
            if (e.Column.MappingName == "OrderID") {
				e.Column.HeaderText = "Order ID";
			} else if (e.Column.MappingName == "CustomerID") {
				e.Column.HeaderText = "Customer ID";
				e.Column.ColumnSizer = ColumnSizer.Auto;
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "Freight") {
				e.Column.Format = "C";
				e.Column.CultureInfo = new CultureInfo ("en-US");
				e.Column.TextAlignment = GravityFlags.Center;
			} else if (e.Column.MappingName == "ShipCity") {
				e.Column.HeaderText = "Ship City";
				e.Column.ColumnSizer = ColumnSizer.Auto;
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "ShipCountry") {
				e.Column.HeaderText = "Ship Country";
				e.Column.ColumnSizer = ColumnSizer.Auto;
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "EmployeeID") {
				e.Column.HeaderText = "Employee ID";
				e.Column.TextAlignment = GravityFlags.Center;
			} else if (e.Column.MappingName == "FirstName") {
				e.Column.HeaderText = "First Name";
				e.Column.ColumnSizer = ColumnSizer.Auto;
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "LastName") {
				e.Column.HeaderText = "Last Name";
				e.Column.ColumnSizer = ColumnSizer.Auto;
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "Gender") {
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "ShippingDate") {
				e.Column.HeaderText = "Shipping Date";
				e.Column.Format = "d";
			} else if (e.Column.MappingName == "IsClosed") {
				e.Column.HeaderText = "Is Closed";
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} 
		}

		public override void Destroy ()
		{
			sfGrid.AutoGeneratingColumn -= GridGenerateColumns;
			sfGrid.Dispose ();
			sfGrid = null;
			viewModel = null;
		}
	}
}

