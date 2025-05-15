#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfDataGrid;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using System.Globalization;
using System.Linq;
using System.ComponentModel;

namespace SampleBrowser
{
	public class Sorting:SamplePage
	{
		SfDataGrid sfGrid;
		SortingViewModel viewModel;
		CheckBox allowsorting;
		CheckBox allowtristatesorting;
		CheckBox allowsortingforSupplierID;
		CheckBox allowMultiSorting;

		public override Android.Views.View GetSampleContent (Android.Content.Context context)
		{
			sfGrid = new SfDataGrid (context);
			viewModel = new SortingViewModel ();
			viewModel.SetRowstoGenerate (100);
			sfGrid.AutoGeneratingColumn += GridAutoGenerateColumns;
			sfGrid.ItemsSource = viewModel.Products;
            sfGrid.SelectionMode = SelectionMode.Single;
			sfGrid.AllowSorting = true;
			sfGrid.AllowTriStateSorting = true;
            sfGrid.Alpha = 1.0f;
            sfGrid.VerticalOverScrollMode = VerticalOverScrollMode.None;
            this.sfGrid.SortColumnDescriptions.Add (new SortColumnDescription (){ ColumnName ="ProductID", SortDirection = ListSortDirection.Descending });
			return sfGrid;
		}

		public override void OnApplyChanges ()
		{
			base.OnApplyChanges ();
		}

		public override View GetPropertyWindowLayout (Android.Content.Context context)
		{
			LinearLayout linear = new LinearLayout (context);
			linear.Orientation = Orientation.Vertical;
			allowsorting = new CheckBox (context);
			allowtristatesorting = new CheckBox (context);
            allowMultiSorting = new CheckBox(context);
            allowsortingforSupplierID = new CheckBox (context);

			allowsorting.Text = "Allow Sorting";
			allowtristatesorting.Text = "Allow TriState Sorting";
            allowMultiSorting.Text = "Allow Mutli-Sorting";
            allowsortingforSupplierID.Text = "Allow Sorting For SupplierID";

			allowsorting.Checked = true;
			allowtristatesorting.Checked = false;
            allowMultiSorting.Checked = false;
            allowsortingforSupplierID.Checked = true;

			allowsorting.CheckedChange += OnAllowSortingChanged;
			allowtristatesorting.CheckedChange += OnAllowTriStateSortingChanged;
			allowMultiSorting.CheckedChange += OnAllowMultiSortingChanged;
			allowsortingforSupplierID.CheckedChange += OnSortingForSupplierIDChanged;
			linear.AddView (allowsorting);
			linear.AddView (allowtristatesorting);
            linear.AddView(allowMultiSorting);
            linear.AddView (allowsortingforSupplierID);
			return linear;
		}

		void OnSortingForSupplierIDChanged (object sender, CompoundButton.CheckedChangeEventArgs e)
		{
			var supplierId = sfGrid.Columns.FirstOrDefault (x => x.MappingName == "SupplierID");

			if (e.IsChecked)
				supplierId.AllowSorting = true;
			else
				supplierId.AllowSorting = false;
		}

		void OnAllowTriStateSortingChanged (object sender, CompoundButton.CheckedChangeEventArgs e)
		{
			if (e.IsChecked)
				sfGrid.AllowTriStateSorting = true;
			else
				sfGrid.AllowTriStateSorting = false;
		}

		void OnAllowMultiSortingChanged (object sender, CompoundButton.CheckedChangeEventArgs e)
		{
            if (e.IsChecked)
                sfGrid.AllowMultiSorting = true;
            else
                sfGrid.AllowMultiSorting = false;
        }

		void OnAllowSortingChanged (object sender, CompoundButton.CheckedChangeEventArgs e)
		{
			if (e.IsChecked)
				sfGrid.AllowSorting = true;
			else
				sfGrid.AllowSorting = false;
		}

		void GridAutoGenerateColumns (object sender, AutoGeneratingColumnEventArgs e)
		{
			if (e.Column.MappingName == "SupplierID") {
				e.Column.HeaderText = "Supplier ID";
				e.Column.TextAlignment = GravityFlags.Center;
            } else if (e.Column.MappingName == "ProductID") {
				e.Column.HeaderText = "Product ID";
				e.Column.TextAlignment = GravityFlags.Center;
			} else if (e.Column.MappingName == "ProductName") {
				e.Column.HeaderText = "Product Name";
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "Quantity") {
				e.Column.TextAlignment = GravityFlags.Center;
			} else if (e.Column.MappingName == "UnitPrice") {
				e.Column.HeaderText = "Unit Price";
				e.Column.Format = "C";
				e.Column.CultureInfo = new CultureInfo ("en-US");
			} else if (e.Column.MappingName == "UnitsInStock") {
				e.Column.HeaderText = "Units In Stock";
				e.Column.TextAlignment = GravityFlags.Center;
			}
		}

		public override void Destroy ()
		{
			sfGrid.AutoGeneratingColumn -= GridAutoGenerateColumns;
			sfGrid.Dispose ();
			sfGrid = null;
			allowsorting = null;
			allowtristatesorting = null;
			allowMultiSorting = null;
			allowsortingforSupplierID = null;
			viewModel = null;
		}

	}
}