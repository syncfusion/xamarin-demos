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
using Android.Graphics;
using Syncfusion.Data;
using Syncfusion.SfDataGrid;
using System.ComponentModel;

namespace SampleBrowser
{
    public class CustomSorting : SamplePage
    {
        #region Fields

        CustomerViewModel viewModel;
        SfDataGrid sfGrid;

        #endregion

        #region Override Methods

        public override View GetSampleContent(Context context)
        {
            sfGrid = new SfDataGrid (context);
            viewModel = new CustomerViewModel ();
            sfGrid.AutoGeneratingColumn += GridAutoGenerateColumns;
            sfGrid.ItemsSource = viewModel.CustomerInformation;
            sfGrid.AllowSorting = true;
            sfGrid.SelectionMode = SelectionMode.Single;
            sfGrid.AllowTriStateSorting = true;
            sfGrid.GridStyle.AlternatingRowColor = Color.Rgb(206, 206, 206);
            sfGrid.VerticalOverScrollMode = VerticalOverScrollMode.None;
            sfGrid.SortComparers.Add(new SortComparer () { Comparer = new CustomerInfo (), PropertyName="FirstName" });
            sfGrid.SortColumnDescriptions.Add(new SortColumnDescription () { ColumnName = "FirstName", SortDirection = ListSortDirection.Descending });
            return sfGrid;
        }

        public override void Destroy()
        {
            sfGrid.AutoGeneratingColumn -= GridAutoGenerateColumns;
            sfGrid.Dispose();
            sfGrid = null;
            viewModel = null;
        }

        #endregion

        #region CallBacks

        private void GridAutoGenerateColumns(object sender, AutoGeneratingColumnEventArgs e)
        {
            if (e.Column.MappingName == "CustomerID") {
				e.Column.HeaderText = "Customer ID";
                e.Column.TextAlignment = GravityFlags.CenterVertical;
			}  else if (e.Column.MappingName == "City") {
				e.Column.HeaderText = "City";
                e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "Country") {
				e.Column.HeaderText = "Country";
                e.Column.TextAlignment = GravityFlags.CenterVertical;
			}  else if (e.Column.MappingName == "FirstName") {
				e.Column.HeaderText = "First Name";
                e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "LastName") {
				e.Column.HeaderText = "Last Name";
                e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "Gender") {
                e.Column.TextAlignment = GravityFlags.CenterVertical;
			}
        }

        #endregion
    }
}