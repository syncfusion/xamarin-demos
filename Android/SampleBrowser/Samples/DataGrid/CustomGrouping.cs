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

namespace SampleBrowser
{
    public class CustomGrouping : SamplePage
    {
        #region Fields

        SfDataGrid sfGrid;
        SalesInfoViewModel viewModel;

        #endregion

        #region Override Methods

        public override View GetSampleContent(Context context)
        {
            sfGrid = new SfDataGrid (context);
            viewModel = new SalesInfoViewModel ();
            sfGrid.SelectionMode = SelectionMode.Single;
            sfGrid.AutoGeneratingColumn += GridAutoGenerateColumns;
            sfGrid.ItemsSource = viewModel.DailySalesDetails;
            sfGrid.AllowSorting = true;
            sfGrid.AllowGroupExpandCollapse = true;
            sfGrid.VerticalOverScrollMode = VerticalOverScrollMode.None;
            sfGrid.SortComparers.Add(new SortComparer() { Comparer = new CustomSortComparer(), PropertyName = "Total" });
            sfGrid.GroupColumnDescriptions.Add (new GroupColumnDescription () { ColumnName = "Total", Converter = new GroupDataTimeConverter() });

            //TableSummary codes
            GridTableSummaryRow summaryRow = new GridTableSummaryRow();
            summaryRow.Title = "Total items:{Total} items";
            summaryRow.ShowSummaryInRow = true;
            summaryRow.Position = Position.Bottom;
            GridSummaryColumn summaryColumn = new GridSummaryColumn();
            summaryColumn.Name = "Total";
            summaryColumn.MappingName = "Name";
            summaryColumn.Format = "{Count}";
            summaryColumn.SummaryType = Syncfusion.Data.SummaryType.CountAggregate;
            summaryRow.SummaryColumns.Add(summaryColumn);
            sfGrid.TableSummaryRows.Add(summaryRow);

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
            if (e.Column.MappingName == "Name") {
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            } else if (e.Column.MappingName == "QS1") {
                e.Column.HeaderText = "Sales in Quarter1";
            } else if (e.Column.MappingName == "QS2") {
                e.Column.HeaderText = "Sales in Quarter2";
            } else if (e.Column.MappingName == "QS3") {
                e.Column.HeaderText = "Sales in Quarter3";
            } else if (e.Column.MappingName == "QS4") {
                e.Column.HeaderText = "Sales in Quarter4";
            } else if (e.Column.MappingName == "Total") {
                e.Column.HeaderText = "Total Sales in Year";
            }
        }

        #endregion
    }
}