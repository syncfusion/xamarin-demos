#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfDataGrid.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser.SfDataGrid
{
    public class AutoRowHeightBehaviors : Behavior<Syncfusion.SfDataGrid.XForms.SfDataGrid>
    {
        private Syncfusion.SfDataGrid.XForms.SfDataGrid dataGrid;
        protected override void OnAttachedTo(Syncfusion.SfDataGrid.XForms.SfDataGrid bindable)
        {
            dataGrid = bindable;
            dataGrid.GridViewCreated += DataGrid_GridViewCreated;
            dataGrid.QueryRowHeight += DataGrid_QueryRowHeight;
            base.OnAttachedTo(bindable);
        }

        private void DataGrid_GridViewCreated(object sender, GridViewCreatedEventArgs e)
        {
            if (Device.Idiom != TargetIdiom.Phone)
            {
                GridTextColumn serialNumberColumn = new GridTextColumn();
                serialNumberColumn.MappingName = "SNo";
                serialNumberColumn.HeaderText = "S.No";
                serialNumberColumn.ColumnSizer = ColumnSizer.Auto;
                serialNumberColumn.HeaderFontAttribute = FontAttributes.Bold;
                serialNumberColumn.HeaderTextAlignment = TextAlignment.Start;
                serialNumberColumn.TextAlignment = TextAlignment.End;

                GridTextColumn releaseDataColumn = new GridTextColumn();
                releaseDataColumn.MappingName = "DateOfRelease";
                releaseDataColumn.HeaderText = "Release Date";
                releaseDataColumn.Padding = 5;
                releaseDataColumn.ColumnSizer = ColumnSizer.Auto;
                releaseDataColumn.HeaderFontAttribute = FontAttributes.Bold;
                releaseDataColumn.HeaderTextAlignment = TextAlignment.Start;
                releaseDataColumn.TextAlignment = TextAlignment.Start;

                if (Device.RuntimePlatform == (Device.Android) || (Device.RuntimePlatform == Device.iOS))
                {
                    serialNumberColumn.HeaderCellTextSize = 14;
                    serialNumberColumn.CellTextSize = 14;
                    serialNumberColumn.Padding = new Thickness(16, 12, 8, 12);
                    releaseDataColumn.HeaderCellTextSize = 14;
                    releaseDataColumn.CellTextSize = 14;
                    releaseDataColumn.Padding = new Thickness(8, 12, 8, 12);
                }
                else
                {
                    serialNumberColumn.HeaderCellTextSize = 12;
                    serialNumberColumn.CellTextSize = 12;
                    serialNumberColumn.Padding = new Thickness(8, 12, 8, 16);
                    releaseDataColumn.HeaderCellTextSize = 12;
                    releaseDataColumn.CellTextSize = 12;
                    releaseDataColumn.Padding = new Thickness(8, 12, 8, 16);
                }

                dataGrid.Columns.Insert(0, serialNumberColumn);
                dataGrid.Columns.Insert(4, releaseDataColumn);
            }
        }

        private void DataGrid_QueryRowHeight(object sender, QueryRowHeightEventArgs e)
        {
            double height = SfDataGridHelpers.GetRowHeight(dataGrid, e.RowIndex);
            if (e.RowIndex > 0)
            {
                if (height > 35)
                {
                    e.Height = height;
                    e.Handled = true;
                }
            }
        }
        protected override void OnDetachingFrom(Syncfusion.SfDataGrid.XForms.SfDataGrid bindable)
        {
            dataGrid.GridViewCreated -= DataGrid_GridViewCreated;
            dataGrid.QueryRowHeight -= DataGrid_QueryRowHeight;
            dataGrid = null;
            base.OnDetachingFrom(bindable);
        }
    }
}

