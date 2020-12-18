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
using Android.Content.Res;
using Android.Widget;
using Android.Graphics;

namespace SampleBrowser
{
	public class AutoRowHeight:SamplePage
	{
		SfDataGrid sfGrid;
		AutoRowHeightViewModel viewModel;

		public override Android.Views.View GetSampleContent (Android.Content.Context context)
		{
			sfGrid = new SfDataGrid (context);
            sfGrid.ColumnSizer = ColumnSizer.None;
            sfGrid.SelectionMode = SelectionMode.Single;
			sfGrid.QueryRowHeight += HandleQueryRowHeightEventHandler;
			viewModel = new AutoRowHeightViewModel ();
			sfGrid.AutoGeneratingColumn += GridAutoGenerateColumns;
			sfGrid.ItemsSource = (viewModel.ReleaseInformation);
            sfGrid.VerticalOverScrollMode= VerticalOverScrollMode.None;
            sfGrid.Alpha = 0.87f ;

            if (MainActivity.IsTablet)
            {
                GridTextColumn sno = new GridTextColumn();
                sno.MappingName = "SNo";
                sno.HeaderText = "S.No";
                sno.ColumnSizer = ColumnSizer.Auto;
                sno.HeaderTextAlignment = GravityFlags.Center;
                sno.TextAlignment = GravityFlags.Center;
                this.sfGrid.Columns.Insert(0, sno);
                this.sfGrid.ColumnSizer = ColumnSizer.Star;
            }
            return sfGrid;
		}

		void HandleQueryRowHeightEventHandler (object sender, QueryRowHeightEventArgs e)
		{
            if (e.RowIndex > 0)
            {
                double height = SfDataGridHelpers.GetRowHeight(sfGrid, e.RowIndex);
                e.Height = height + (16 * Resources.System.DisplayMetrics.Density);
                e.Handled = true;
            }
        }

        void GridAutoGenerateColumns(object sender, AutoGeneratingColumnEventArgs e)
        {
            if (e.Column.MappingName == "SNo")
                e.Cancel = true;
            if (e.Column.MappingName == "ReleaseVersion")
            {
                e.Column.LineBreakMode = LineBreakMode.WordWrap;
                e.Column.HeaderText = "Release Version";
                e.Column.TextAlignment = GravityFlags.CenterHorizontal | GravityFlags.CenterVertical;
                e.Column.HeaderTextMargin = new Thickness(8);
                e.Column.TextMargin = new Thickness(8);
                e.Column.HeaderCellTextSize = 13;
                e.Column.CellTextSize = 13;
                e.Column.HeaderFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
                e.Column.RecordFont= Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
            }
            else if (e.Column.MappingName == "Platform")
            {
                e.Column.HeaderText = "Platform";
                e.Column.LineBreakMode = LineBreakMode.WordWrap;
                e.Column.TextAlignment = GravityFlags.Left | GravityFlags.CenterVertical;
                e.Column.HeaderTextMargin = new Thickness(8);
                e.Column.TextMargin= new Thickness(8);
                e.Column.HeaderCellTextSize = 13;
                e.Column.CellTextSize = 13;
                e.Column.HeaderFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
                e.Column.RecordFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
            }
            else if (e.Column.MappingName == "Features")
            {
                e.Column.HeaderText = "Feature";
                e.Column.TextAlignment = GravityFlags.Left | GravityFlags.CenterVertical;
                e.Column.LineBreakMode = LineBreakMode.WordWrap;
                e.Column.HeaderTextMargin = new Thickness(8);
                e.Column.TextMargin = new Thickness(8);
                e.Column.HeaderCellTextSize = 13;
                e.Column.CellTextSize = 13;
                e.Column.HeaderFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
                e.Column.RecordFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
            }
            else if (e.Column.MappingName == "Description")
            {
                e.Column.HeaderText = "Description";
                e.Column.TextAlignment = GravityFlags.Left | GravityFlags.CenterVertical;
                e.Column.LineBreakMode = LineBreakMode.WordWrap;
                e.Column.HeaderTextMargin = new Thickness(8);
                e.Column.TextMargin = new Thickness(8);
                e.Column.HeaderCellTextSize = 13;
                e.Column.CellTextSize = 13;
                e.Column.HeaderFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
                e.Column.RecordFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
            }
        }

		public override void Destroy ()
		{
			this.sfGrid.QueryRowHeight -= HandleQueryRowHeightEventHandler;
			sfGrid.Dispose ();
			sfGrid = null;
			viewModel = null;
		}

	}
}

