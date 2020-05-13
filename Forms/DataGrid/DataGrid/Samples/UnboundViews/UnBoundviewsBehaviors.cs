#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "UnboundViewsBehaviors.cs" company="Syncfusion.com">
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
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SampleBrowser.Core;
    using Syncfusion.SfDataGrid.XForms;
    using Xamarin.Forms;

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]

    /// <summary>
    ///  Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    ///  Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the  UnboundColumns samples
    /// </summary>
    public class UnboundViewsBehaviors : Behavior<SampleView>
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed")]
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Some fields must be public")]
        public Syncfusion.SfDataGrid.XForms.SfDataGrid DataGrid;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed")]
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Some fields must be public")]
        public SalesInfoViewModel ViewModel;

        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="bindAble">SampleView type parameter as bindAble</param>
        protected override void OnAttachedTo(SampleView bindAble)
        {
            base.OnAttachedTo(bindAble);

            this.DataGrid = bindAble.FindByName<Syncfusion.SfDataGrid.XForms.SfDataGrid>("dataGrid");
            this.ViewModel = bindAble.FindByName<SalesInfoViewModel>("viewModel");
            this.DataGrid.GridStyle = new UnboundRowStyle();
            this.DataGrid.QueryCellStyle += this.DataGrid_QueryCellStyle;
            this.DataGrid.QueryRowHeight += this.DataGrid_QueryRowHeight;
            this.DataGrid.QueryUnboundRow += this.DataGrid_QueryUnboundRow;
            this.DataGrid.SelectionChanged += this.DataGrid_SelectionChanged;
            if (Device.Idiom == TargetIdiom.Tablet || Device.Idiom == TargetIdiom.Desktop)
            {
                this.DataGrid.UnboundRows.Insert(0, new GridUnboundRow() { Position = UnboundRowsPosition.FixedTop });
                this.DataGrid.UnboundRows.Insert(0, new GridUnboundRow() { Position = UnboundRowsPosition.Top });
            }
        }

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="bindAble">A sampleView type of bindAble</param>
        protected override void OnDetachingFrom(SampleView bindAble)
        {
            this.DataGrid.QueryCellStyle -= this.DataGrid_QueryCellStyle;
            this.DataGrid.QueryRowHeight -= this.DataGrid_QueryRowHeight;
            this.DataGrid.QueryUnboundRow -= this.DataGrid_QueryUnboundRow;
            this.DataGrid.SelectionChanged -= this.DataGrid_SelectionChanged;
            base.OnDetachingFrom(bindAble);
        }

        /// <summary>
        ///  Queries to set the row heights for the rows
        /// </summary>
        /// <param name="sender">DataGrid_GridLoaded sender</param>
        /// <param name="e">GridLoadedEventArgs parameter e</param>
        private void DataGrid_QueryRowHeight(object sender, QueryRowHeightEventArgs e)
        {
            if (this.DataGrid.IsUnboundRow(e.RowIndex))
            {
                e.Height = 70;
                e.Handled = true;
            }
        }

        /// <summary>
        /// Occurs to query the value and settings for cell in Unbound row.
        /// </summary>
        /// <param name="sender">DataGrid_QueryUnboundRow sender</param>
        /// <param name="e">GridUnboundRowEventArgs parameter e</param>
        private void DataGrid_QueryUnboundRow(object sender, GridUnboundRowEventArgs e)
        {
            if (e.UnboundAction == UnboundActions.QueryData)
            {
                if (e.GridUnboundRow.Position == UnboundRowsPosition.FixedTop)
                {
                    double sum = 0;
                    if (e.RowColumnIndex.ColumnIndex == 0)
                    {
                        e.Value = "Total sales by year";
                    }
                    else if (e.RowColumnIndex.ColumnIndex == 1)
                    {
                        for (int i = 0; i < this.ViewModel.DailySalesDetails.Count; i++)
                        {
                            sum += this.ViewModel.DailySalesDetails[i].QS1;
                            e.Value = sum;
                        }
                    }
                    else if (e.RowColumnIndex.ColumnIndex == 2)
                    {
                        for (int i = 0; i < this.ViewModel.DailySalesDetails.Count; i++)
                        {
                            sum += this.ViewModel.DailySalesDetails[i].QS2;
                            e.Value = sum;
                        }
                    }
                    else if (e.RowColumnIndex.ColumnIndex == 3)
                    {
                        for (int i = 0; i < this.ViewModel.DailySalesDetails.Count; i++)
                        {
                            sum += this.ViewModel.DailySalesDetails[i].QS3;
                            e.Value = sum;
                        }
                    }
                    else if (e.RowColumnIndex.ColumnIndex == 4)
                    {
                        for (int i = 0; i < this.ViewModel.DailySalesDetails.Count; i++)
                        {
                            sum += this.ViewModel.DailySalesDetails[i].QS1 + this.ViewModel.DailySalesDetails[i].QS2 + this.ViewModel.DailySalesDetails[i].QS3;
                            e.Value = sum / this.ViewModel.DailySalesDetails.Count;
                        }
                    }
                }
                else if (e.GridUnboundRow.Position == UnboundRowsPosition.Top)
                {
                    double sum = 0;
                    if (e.RowColumnIndex.ColumnIndex == 0)
                    {
                        e.Value = "Average by year";
                    }
                    else if (e.RowColumnIndex.ColumnIndex == 1)
                    {
                        for (int i = 0; i < this.ViewModel.DailySalesDetails.Count; i++)
                        {
                            sum += this.ViewModel.DailySalesDetails[i].QS1;
                            e.Value = sum / this.ViewModel.DailySalesDetails.Count;
                        }
                    }
                    else if (e.RowColumnIndex.ColumnIndex == 2)
                    {
                        for (int i = 0; i < this.ViewModel.DailySalesDetails.Count; i++)
                        {
                            sum += this.ViewModel.DailySalesDetails[i].QS2;
                            e.Value = sum / this.ViewModel.DailySalesDetails.Count;
                        }
                    }
                    else if (e.RowColumnIndex.ColumnIndex == 3)
                    {
                        for (int i = 0; i < this.ViewModel.DailySalesDetails.Count; i++)
                        {
                            sum += this.ViewModel.DailySalesDetails[i].QS3;
                            e.Value = sum / this.ViewModel.DailySalesDetails.Count;
                        }
                    }
                    else if (e.RowColumnIndex.ColumnIndex == 4)
                    {
                        for (int i = 0; i < this.ViewModel.DailySalesDetails.Count; i++)
                        {
                            sum += this.ViewModel.DailySalesDetails[i].QS1 + this.ViewModel.DailySalesDetails[i].QS2 + this.ViewModel.DailySalesDetails[i].QS3;
                            e.Value = sum / this.ViewModel.DailySalesDetails.Count;
                        }
                    }
                }
                else if (e.GridUnboundRow.Position == UnboundRowsPosition.FixedBottom)
                {
                    double sum = 0;
                    if (e.RowColumnIndex.ColumnIndex == 0)
                    {
                        e.Value = "Sum of selection";
                    }
                    else if (e.RowColumnIndex.ColumnIndex == 1)
                    {
                        if (this.DataGrid.SelectedItems.Count > 0)
                        {
                            for (int i = 0; i < this.DataGrid.SelectedItems.Count; i++)
                            {
                                e.Value = sum += this.DataGrid.SelectedItems[i] != null ? (this.DataGrid.SelectedItems[i] as SalesByDate).QS2 : 0;
                            }
                        }
                        else
                        {
                            e.Value = null;
                        }
                    }
                    else if (e.RowColumnIndex.ColumnIndex == 2)
                    {
                        if (this.DataGrid.SelectedItems.Count > 0)
                        {
                            for (int i = 0; i < this.DataGrid.SelectedItems.Count; i++)
                            {
                                e.Value = sum += this.DataGrid.SelectedItems[i] != null ? (this.DataGrid.SelectedItems[i] as SalesByDate).QS3 : 0;
                            }
                        }
                        else
                        {
                            e.Value = null;
                        }
                    }
                    else if (e.RowColumnIndex.ColumnIndex == 3)
                    {
                        if (this.DataGrid.SelectedItems.Count > 0)
                        {
                            for (int i = 0; i < this.DataGrid.SelectedItems.Count; i++)
                            {
                                 e.Value = sum += this.DataGrid.SelectedItems[i] != null ? (this.DataGrid.SelectedItems[i] as SalesByDate).QS2 + (this.DataGrid.SelectedItems[i] as SalesByDate).QS3 : 0;
                            }
                        }
                        else
                        {
                            e.Value = null;
                        }
                    }
                }

                e.Handled = true;
            }
        }

        /// <summary>
        /// Fired when DataGrid selection changed.
        /// </summary>
        /// <param name="sender">dataGrid_SelectionChanged sender</param>
        /// <param name="e">GridSelectionChangedEventArgs parameter e</param>
        private void DataGrid_SelectionChanged(object sender, GridSelectionChangedEventArgs e)
        {
            this.DataGrid.InvalidateUnboundRow(this.DataGrid.UnboundRows[this.DataGrid.UnboundRows.Count - 1]);
        }

        /// <summary>
        /// Triggers when a cell comes to the View
        /// </summary>
        /// <param name="sender">DataGrid_QueryCellStyle event sender</param>
        /// <param name="e">DataGrid_QueryCellStyle event args e</param>
        private void DataGrid_QueryCellStyle(object sender, QueryCellStyleEventArgs e)
        {
            if (e.ColumnIndex == 3 || (this.DataGrid.GetUnboundRowAtRowIndex(e.RowIndex) != null && this.DataGrid.GetUnboundRowAtRowIndex(e.RowIndex).Position == UnboundRowsPosition.FixedBottom))
            {
                e.Style.BackgroundColor = Color.FromRgb(225, 245, 254);
            }

            e.Handled = true;
        }
    }
}
