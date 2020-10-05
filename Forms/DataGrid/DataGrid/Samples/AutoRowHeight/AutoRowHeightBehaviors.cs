#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "AutoRowHeightBehaviors.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfDataGrid
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SampleBrowser.Core;
    using Syncfusion.SfDataGrid.XForms;
    using Xamarin.Forms;

    /// <summary>
    ///  Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    ///  Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the AutoRowHeight sample.
    /// </summary>
    public class AutoRowHeightBehaviors : Behavior<Syncfusion.SfDataGrid.XForms.SfDataGrid>
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Syncfusion.SfDataGrid.XForms.SfDataGrid dataGrid;

        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="bindAble">DataGrid type of bindAble</param>
        protected override void OnAttachedTo(Syncfusion.SfDataGrid.XForms.SfDataGrid bindAble)
        {
            this.dataGrid = bindAble;
            this.dataGrid.GridViewCreated += this.DataGrid_GridViewCreated;
            this.dataGrid.QueryRowHeight += this.DataGrid_QueryRowHeight;
            base.OnAttachedTo(bindAble);
        }

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="bindAble">DataGrid type of bindAble parameter</param>
        protected override void OnDetachingFrom(Syncfusion.SfDataGrid.XForms.SfDataGrid bindAble)
        {
            this.dataGrid.GridViewCreated -= this.DataGrid_GridViewCreated;
            this.dataGrid.QueryRowHeight -= this.DataGrid_QueryRowHeight;
            this.dataGrid = null;
            base.OnDetachingFrom(bindAble);
        }

        /// <summary>
        /// Fired when DataGrid view is created.
        /// </summary>
        /// <param name="sender">DataGrid_GridViewCreated sender</param>
        /// <param name="e">GridViewCreatedEventArgs parameter e</param>
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

                if (Device.RuntimePlatform == Device.Android || (Device.RuntimePlatform == Device.iOS))
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

                this.dataGrid.Columns.Insert(0, serialNumberColumn);
                this.dataGrid.Columns.Insert(4, releaseDataColumn);
            }
        }

        /// <summary>
        /// Fired when a row comes in to View 
        /// </summary>
        /// <param name="sender">DataGrid_QueryRowHeight sender</param>
        /// <param name="e">QueryRowHeightEventArgs parameter e</param>
        private void DataGrid_QueryRowHeight(object sender, QueryRowHeightEventArgs e)
        {
            double height = SfDataGridHelpers.GetRowHeight(this.dataGrid, e.RowIndex);
            if (e.RowIndex > 0)
            {
                if (height > 35)
                {
                    e.Height = height;
                    e.Handled = true;
                }
            }
        }
    }
}