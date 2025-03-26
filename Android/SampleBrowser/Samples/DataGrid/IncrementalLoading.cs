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
using Android.Graphics;

namespace SampleBrowser
{
	public class IncrementalLoading:SamplePage
	{
		SfDataGrid sfGrid;
		IncrementalLoadingViewModel viewModel;

		public override Android.Views.View GetSampleContent (Android.Content.Context context)
		{
			sfGrid = new SfDataGrid (context);
            sfGrid.SelectionMode = SelectionMode.Single;
			viewModel = new IncrementalLoadingViewModel (context);
			sfGrid.GridStyle.AlternatingRowColor = Color.Rgb (206, 206, 206);
			sfGrid.ItemsSource = viewModel.GridSource;
			sfGrid.AutoGeneratingColumn += GridAutoGeneratingColumns;
            sfGrid.VerticalOverScrollMode = VerticalOverScrollMode.None;
            return sfGrid;
		}
		public override Android.Views.View GetPropertyWindowLayout (Android.Content.Context context)
		{
			return base.GetPropertyWindowLayout (context);
		}

		void GridAutoGeneratingColumns (object sender, AutoGeneratingColumnEventArgs e)
		{
			if (e.Column.MappingName == "OrderID") {
				e.Column.HeaderText = "OrderID";
			} else if (e.Column.MappingName == "CustomerID") {
				e.Column.HeaderText = "Customer ID";
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "EmployeeID") {
				e.Column.HeaderText = "Employee ID";
			} else if (e.Column.MappingName == "OrderDate") {
				e.Column.HeaderText = "Order Date";
				e.Column.Format = "d";
			} else if (e.Column.MappingName == "RequiredDate") {
				e.Column.HeaderText = "Required Date";
				e.Column.Format = "d";
			} else if (e.Column.MappingName == "ShippedDate") {
				e.Column.HeaderText = "Shipped Date";
				e.Column.Format = "d";
			} else if (e.Column.MappingName == "ShipVia") {
				e.Column.HeaderText = "Ship Via";
			} else if (e.Column.MappingName == "Freight") {
				e.Column.Format = "C";
				e.Column.CultureInfo = new CultureInfo ("en-US");
			} else if (e.Column.MappingName == "ShipName") {
				e.Column.HeaderText = "Ship Name";
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "ShipAddress") {
				e.Column.HeaderText = "Ship Address";
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "ShipCity") {
				e.Column.HeaderText = "Ship City";
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "ShipRegion") {
				e.Column.HeaderText = "Ship Region";
			} else if (e.Column.MappingName == "ShipPostalCode") {
				e.Column.HeaderText = "Ship Postal Code";
			} else if (e.Column.MappingName == "ShipCountry") {
				e.Column.HeaderText = "Ship Country";
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "Order_Details") {
				e.Column.HeaderText = "Order Details";
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			}
		}

		public override void Destroy ()
		{
			this.sfGrid.AutoGeneratingColumn -= GridAutoGeneratingColumns;
			this.sfGrid.Dispose ();
			this.sfGrid = null;
            this.viewModel.Dispose();
			this.viewModel = null;
		}
	}
}

