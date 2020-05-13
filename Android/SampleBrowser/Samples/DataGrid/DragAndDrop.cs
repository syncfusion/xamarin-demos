#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using Syncfusion.SfDataGrid;
using System.Globalization;
using Android.Util;
using Android.Graphics;

namespace SampleBrowser
{
    public class DragAndDrop : SamplePage
    {
        #region Fields

        SfDataGrid sfGrid;
        DragAndDropViewModel viewModel;

        #endregion

        #region Override Methods

        public override View GetSampleContent(Context context)
        {
            sfGrid = new SfDataGrid(context);
            viewModel = new DragAndDropViewModel();
            sfGrid.AutoGeneratingColumn += GridAutoGenerateColumns;
            sfGrid.ItemsSource = viewModel.OrdersInfo;
            sfGrid.SelectionMode = SelectionMode.Single;
            sfGrid.AllowDraggingColumn = true;
            sfGrid.AllowDraggingRow = true;
            sfGrid.RowDragDropTemplate = new RowDragDropTemplate(context);
            sfGrid.QueryRowDragging += QueryRowDragging;
            sfGrid.ColumnSizer = ColumnSizer.Star;
            sfGrid.VerticalOverScrollMode = VerticalOverScrollMode.None;
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

        #region Callbacks

        void GridAutoGenerateColumns(object sender, AutoGeneratingColumnEventArgs e)
        {
            if (e.Column.MappingName == "OrderID")
            {
                e.Column.HeaderText = "Order ID";
            }
            else if (e.Column.MappingName == "CustomerID")
            {
                e.Column.HeaderText = "Customer ID";
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            }
            else if (e.Column.MappingName == "EmployeeID")
            {
                e.Column.HeaderText = "Employee ID";
                e.Column.TextAlignment = GravityFlags.Center;
            }
            else if (e.Column.MappingName == "FirstName")
            {
                e.Column.HeaderText = "Name";
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            }
            //else if (e.Column.MappingName == "LastName")
            //{
            //    e.Column.HeaderText = "Last Name";
            //    e.Column.TextAlignment = GravityFlags.CenterVertical;
            //}
            else
                e.Cancel = true;
        }
        private void QueryRowDragging(object sender, QueryRowDraggingEventArgs e)
        {
            if (e.Reason == QueryRowDraggingReason.DragStarted)
            {
                (sfGrid.RowDragDropTemplate as RowDragDropTemplate).UpdateRow(e.RowData);
            }
        }

        #endregion
    }


}