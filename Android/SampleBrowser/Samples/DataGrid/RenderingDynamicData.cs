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

namespace SampleBrowser
{
	public class RenderingDynamicData:SamplePage
	{
		SfDataGrid sfGrid;

		public override Android.Views.View GetSampleContent (Android.Content.Context context)
		{
			sfGrid = new SfDataGrid (context);

            GridTextColumn product = new GridTextColumn();
            product.MappingName = "Product";
            product.HeaderTextMargin = new Thickness(8, 0, 0, 0);
            product.TextMargin = new Thickness(8, 0, 0, 0);
            sfGrid.Columns.Add(product);
            GridTextColumn stockColumn = new GridTextColumn ();
			stockColumn.UserCellType = typeof(StockCell);
			stockColumn.LoadUIView = true;
			stockColumn.MappingName = "StockChange";
			stockColumn.HeaderText = "Stock";
			stockColumn.AllowSorting = false;
            stockColumn.HeaderTextMargin = new Thickness(8, 0, 0, 0);
            stockColumn.TextMargin = new Thickness(8, 0, 0, 0);
            sfGrid.SelectionMode = SelectionMode.Single;
			sfGrid.Columns.Add (stockColumn);
			sfGrid.GridStyle.AlternatingRowColor = Color.Rgb (206, 206, 206);
			sfGrid.AutoGeneratingColumn += GridAutoGenerateColumns;
			sfGrid.ItemsSource = new RenderingDynamicDataViewModel ().Stocks;
            sfGrid.VerticalOverScrollMode = VerticalOverScrollMode.None;
            return sfGrid;
		}

		void GridAutoGenerateColumns (object sender, AutoGeneratingColumnEventArgs e)
		{
			if (e.Column.MappingName == "LastTrade") {
				e.Column.HeaderText = "Last Trade";
				e.Column.TextAlignment = GravityFlags.Center;
			} else if (e.Column.MappingName == "Change") {
				e.Column.TextAlignment = GravityFlags.Right;
			} else if (e.Column.MappingName == "PreviousClose") {
				e.Column.HeaderText = "Previous Close";
				e.Column.TextAlignment = GravityFlags.Center;
			} else if (e.Column.MappingName == "Open") {
				e.Column.TextAlignment = GravityFlags.Center;
			} else if (e.Column.MappingName == "Account") {
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "Symbol") {
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "Volume") {
				e.Column.TextAlignment = GravityFlags.Center;
			}
		}

		public override void Destroy ()
		{
			this.sfGrid.AutoGeneratingColumn -= GridAutoGenerateColumns;
			sfGrid.Dispose ();
			sfGrid = null;
		}

	}
}

