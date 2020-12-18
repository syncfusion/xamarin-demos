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
using System.ComponentModel;

namespace SampleBrowser
{
	public class Sorting:SampleView
	{
		#region Fields

		SfDataGrid SfGrid;

		#endregion

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public Sorting ()
		{
			this.SfGrid = new SfDataGrid ();
            this.SfGrid.SelectionMode = SelectionMode.Single;
			this.SfGrid.AllowSorting = true;
			this.SfGrid.AllowTriStateSorting = true;
			this.SfGrid.AutoGeneratingColumn += GridAutoGenerateColumns;
			this.SfGrid.ItemsSource = new SortViewModel ().Products;
			this.SfGrid.ShowRowHeader = false;
			this.SfGrid.HeaderRowHeight = 45;
			this.SfGrid.RowHeight = 45;
			if (Utility.IsIpad)
				this.SfGrid.ColumnSizer = ColumnSizer.Star;
            this.SfGrid.SortColumnDescriptions.Add (new SortColumnDescription (){ ColumnName ="ProductID",SortDirection = ListSortDirection.Descending });
			this.AddSubview (SfGrid);
		}

		void GridAutoGenerateColumns (object sender, AutoGeneratingColumnEventArgs e)
		{
			if (e.Column.MappingName == "SupplierID") {
				e.Column.HeaderText = "Supplier ID";
				e.Column.TextAlignment = UITextAlignment.Center;
			} else if (e.Column.MappingName == "ProductID") {
				e.Column.HeaderText = "Product ID";
				e.Column.TextAlignment = UITextAlignment.Center;
			} else if (e.Column.MappingName == "ProductName") {
				e.Column.HeaderText = "Product Name";
				e.Column.TextMargin = 15;
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "QuantityPerUnit") {
				e.Column.HeaderText = "Quantity Per Unit";
				e.Column.TextAlignment = UITextAlignment.Center;
			} else if (e.Column.MappingName == "UnitPrice") {
				e.Column.TextAlignment = UITextAlignment.Center;
				e.Column.Format = "C";
				e.Column.CultureInfo = new CultureInfo ("en-US");
				e.Column.HeaderText = "Unit Price";
			} else if (e.Column.MappingName == "UnitsInStock") {
				e.Column.TextAlignment = UITextAlignment.Center;
				e.Column.HeaderText = "Units In Stock";
			}
		}
	
		public override void LayoutSubviews ()
		{
			this.SfGrid.Frame = new CGRect (0, 0, this.Frame.Width, this.Frame.Height);
			base.LayoutSubviews ();
		}

        protected override void Dispose(bool disposing)
        {
            SfGrid.Dispose();
            base.Dispose(disposing);
        }
    }
}

