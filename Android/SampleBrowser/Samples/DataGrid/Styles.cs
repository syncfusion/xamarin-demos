#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfDataGrid;
using Android.Graphics;
using Android.Views;
using System.Globalization;
using Android.Widget;
using System.Collections.Generic;

namespace SampleBrowser
{
	public class Styles:SamplePage
	{
		SfDataGrid sfGrid;
		StylesViewModel viewModel;
		DataGridStyle defaultStyle;
		Dark darkStyle;
		Red redStyle;
		Green greenStyle;
		Blue blueStyle;
        Purple purpleStyle;

		public override Android.Views.View GetSampleContent (Android.Content.Context context)
		{
			sfGrid = new SfDataGrid (context);
			viewModel = new StylesViewModel ();
			sfGrid.ItemsSource = (viewModel.OrdersInfo);
			sfGrid.AutoGeneratingColumn += GridGenerateColumns;
			sfGrid.SelectionMode = SelectionMode.Single;
			sfGrid.GridViewCreated += SfGrid_GridViewCreated;
			sfGrid.QueryRowHeight += SfGrid_QueryRowHeight;
            sfGrid.VerticalOverScrollMode = VerticalOverScrollMode.None;
            sfGrid.Alpha = 1.0f;
            defaultStyle = new DataGridStyle ();
			darkStyle = new Dark ();
			blueStyle = new Blue ();
			redStyle = new Red ();
			greenStyle = new Green ();
            purpleStyle = new Purple();
			return sfGrid;
		}

		public override View GetPropertyWindowLayout (Android.Content.Context context)
		{
			LinearLayout linear = new LinearLayout (context);
			linear.Orientation = Orientation.Horizontal;
			TextView txt = new TextView (context);
			txt.Text = "Select Theme";
			txt.SetPadding (10, 10, 10, 10);
			txt.TextSize = 15f;
			Spinner themeDropDown = new Spinner (context, SpinnerMode.Dialog);
			List<String> adapter = new List<String> (){"Default","Dark","Blue","Red","Green", "Purple" };
			ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, adapter);
			themeDropDown.Adapter = dataAdapter; 
			themeDropDown.SetPadding (10, 10, 10, 10);
            themeDropDown.SetSelection(5);
			themeDropDown.ItemSelected += OnGridThemeChanged;
			themeDropDown.SetMinimumHeight (70);
			linear.AddView (txt);
			linear.AddView (themeDropDown);
			return linear;
		}

		void OnGridThemeChanged (object sender, AdapterView.ItemSelectedEventArgs e)
		{
			if (e.Position == 0)
				sfGrid.GridStyle = defaultStyle;
			if (e.Position == 1)
				sfGrid.GridStyle = darkStyle;
 			if (e.Position == 2)
				sfGrid.GridStyle = blueStyle;
			if (e.Position == 3)
				sfGrid.GridStyle = redStyle;
			if (e.Position == 4)
				sfGrid.GridStyle = greenStyle;
            if (e.Position == 5)
                sfGrid.GridStyle = purpleStyle;

        }

		void SfGrid_GridViewCreated (object sender, GridViewCreatedEventArgs e)
		{
			this.sfGrid.SelectedItem = viewModel.OrdersInfo[3];
			this.sfGrid.GridStyle = purpleStyle;
		}

		void SfGrid_QueryRowHeight (object sender, QueryRowHeightEventArgs e)
		{
			if (SfDataGridHelpers.IsCaptionSummaryRow (this.sfGrid, e.RowIndex)) {
				e.Height = 30 * sfGrid.Resources.DisplayMetrics.Density;
				e.Handled = true;
			}
		}

		void GridGenerateColumns (object sender, AutoGeneratingColumnEventArgs e)
		{
			if (e.Column.MappingName == "OrderID") {
				e.Column.HeaderText = "Order ID";
                e.Column.HeaderCellTextSize = 12;
                e.Column.CellTextSize = 13;
                e.Column.HeaderFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
                e.Column.RecordFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
        } else if (e.Column.MappingName == "CustomerID") {
				e.Column.HeaderText = "Customer ID";
                e.Column.HeaderCellTextSize = 12;
                e.Column.CellTextSize = 13;
                e.Column.HeaderFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
                e.Column.RecordFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
                e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "Freight") {
				e.Column.Format = "C";
				e.Column.CultureInfo = new CultureInfo ("en-US");
                e.Column.HeaderCellTextSize = 12;
                e.Column.CellTextSize = 13;
                e.Column.HeaderFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
                e.Column.RecordFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
                e.Column.TextAlignment = GravityFlags.Center;
			} else if (e.Column.MappingName == "ShipCity") {
				e.Column.HeaderText = "Ship City";
				e.Column.TextAlignment = GravityFlags.CenterVertical;
                e.Column.HeaderCellTextSize = 12;
                e.Column.CellTextSize = 13;
                e.Column.HeaderFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
                e.Column.RecordFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
            } else if (e.Column.MappingName == "ShipCountry") {
				e.Column.HeaderText = "Ship Country";
				e.Column.TextAlignment = GravityFlags.CenterVertical;
                e.Column.HeaderCellTextSize = 12;
                e.Column.CellTextSize = 13;
                e.Column.HeaderFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
                e.Column.RecordFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
            } else if (e.Column.MappingName == "EmployeeID") {
				e.Column.HeaderText = "Employee ID";
				e.Column.TextAlignment = GravityFlags.Center;
                e.Column.HeaderCellTextSize = 12;
                e.Column.CellTextSize = 13;
                e.Column.HeaderFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
                e.Column.RecordFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
            } else if (e.Column.MappingName == "FirstName") {
				e.Column.HeaderText = "First Name";
				e.Column.TextAlignment = GravityFlags.CenterVertical;
                e.Column.HeaderCellTextSize = 12;
                e.Column.CellTextSize = 13;
                e.Column.HeaderFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
                e.Column.RecordFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
            } else if (e.Column.MappingName == "LastName") {
				e.Column.HeaderText = "Last Name";
				e.Column.TextAlignment = GravityFlags.CenterVertical;
                e.Column.HeaderCellTextSize = 12;
                e.Column.CellTextSize = 13;
                e.Column.HeaderFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
                e.Column.RecordFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
            } else if (e.Column.MappingName == "Gender") {
				e.Column.TextAlignment = GravityFlags.CenterVertical;
                e.Column.HeaderCellTextSize = 12;
                e.Column.CellTextSize = 13;
                e.Column.HeaderFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
                e.Column.RecordFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
            } else if (e.Column.MappingName == "ShippingDate") {
				e.Column.HeaderText = "Shipping Date";
				e.Column.Format = "d";
                e.Column.HeaderCellTextSize = 12;
                e.Column.CellTextSize = 13;
                e.Column.HeaderFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
                e.Column.RecordFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
            } else if (e.Column.MappingName == "IsClosed") {
				e.Column.HeaderText = "Is Closed";
				e.Column.TextAlignment = GravityFlags.CenterVertical;
                e.Column.HeaderCellTextSize = 12;
                e.Column.CellTextSize = 13;
                e.Column.HeaderFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
                e.Column.RecordFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
            } 
		}

		public override void Destroy ()
		{
			sfGrid.AutoGeneratingColumn -= GridGenerateColumns;
			sfGrid.Dispose ();
			sfGrid = null;
			viewModel = null;
			defaultStyle = null;
			darkStyle = null;
			blueStyle = null;
			redStyle = null;
			greenStyle = null;
            purpleStyle = null;

        }
	}
}

