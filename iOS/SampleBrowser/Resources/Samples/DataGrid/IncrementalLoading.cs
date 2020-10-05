#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfDataGrid;
using UIKit;
using System.Globalization;
using CoreGraphics;

namespace SampleBrowser
{
	public class IncrementalLoading:SampleView
	{
		#region Fields

		SfDataGrid SfGrid;
		IncrementalLoadingViewModel viewmodel;

		#endregion

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public IncrementalLoading()
		{
			this.SfGrid = new SfDataGrid ();
			viewmodel = new IncrementalLoadingViewModel ();
			this.SfGrid.ItemsSource = viewmodel.GridSource;
            this.SfGrid.SelectionMode = SelectionMode.Single;
			this.SfGrid.HeaderRowHeight = 45;
			this.SfGrid.RowHeight = 52;
			this.SfGrid.GridStyle.AlternatingRowColor = UIColor.FromRGB (219, 219, 219);
			this.SfGrid.AutoGeneratingColumn += GridAutoGeneratingColumns;
			this.AddSubview (SfGrid);
            this.AddSubview(viewmodel.LoaderBorder);
		}

		void GridAutoGeneratingColumns (object sender, AutoGeneratingColumnEventArgs e)
		{
			if (e.Column.MappingName == "OrderID") {
				e.Column.HeaderText = "OrderID";
			} else if (e.Column.MappingName == "CustomerID") {
				e.Column.HeaderText = "Customer ID";
				e.Column.TextMargin = 20;
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "EmployeeID") {
				e.Column.HeaderText = "Employee ID";
			} else if (e.Column.MappingName == "OrderDate") {
				e.Column.HeaderText = "Order Date";
				e.Column.TextMargin = 15;
				e.Column.TextAlignment = UITextAlignment.Left;
				e.Column.Format = "d";
			} else if (e.Column.MappingName == "RequiredDate") {
				e.Column.HeaderText = "Required Date";
				e.Column.TextMargin = 15;
				e.Column.TextAlignment = UITextAlignment.Left;
				e.Column.Format = "d";
			} else if (e.Column.MappingName == "ShippedDate") {
				e.Column.HeaderText = "Shipped Date";
				e.Column.TextMargin = 15;
				e.Column.TextAlignment = UITextAlignment.Left;
				e.Column.Format = "d";
			} else if (e.Column.MappingName == "ShipVia") {
				e.Column.HeaderText = "Ship Via";
			} else if (e.Column.MappingName == "Freight") {
				e.Column.Format = "C";
				e.Column.CultureInfo = new CultureInfo ("en-US");
			} else if (e.Column.MappingName == "ShipName") {
				e.Column.HeaderText = "Ship Name";
				e.Column.TextMargin = 10;
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "ShipAddress") {
				e.Column.HeaderText = "Ship Address";
				e.Column.TextMargin = 10;
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "ShipCity") {
				e.Column.HeaderText = "Ship City";
				e.Column.TextMargin = 20;
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "ShipRegion") {
				e.Column.HeaderText = "Ship Region";
				e.Column.TextMargin = 20;
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "ShipPostalCode") {
				e.Column.HeaderText = "Ship Postal Code";
			} else if (e.Column.MappingName == "ShipCountry") {
				e.Column.HeaderText = "Ship Country";
				e.Column.TextMargin = 20;
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "Order_Details") {
				e.Column.HeaderText = "Order Details";
				e.Column.TextAlignment = UITextAlignment.Left;
			} else {
				e.Cancel = true;
			}
		}

		public override void LayoutSubviews ()
		{
			this.SfGrid.Frame = new CGRect (0, 0, this.Frame.Width, this.Frame.Height);
			viewmodel.LoaderBorder.Frame = new CGRect (0, this.Frame.Height- 60, this.Frame.Width, 70);
			viewmodel.LoaderIndicator.Frame = new CGRect (50, 25, 20, 20);
			viewmodel.LoaderLable.Frame = new CGRect (80, 0, this.Frame.Width, 70);
			viewmodel.LoaderLable.TextColor = UIColor.White;
			base.LayoutSubviews ();
		}

        protected override void Dispose(bool disposing)
        {
            SfGrid.Dispose();
            base.Dispose(disposing);
        }
	}
}

