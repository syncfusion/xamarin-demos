#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using CoreGraphics;
using Syncfusion.SfDataGrid;
using Syncfusion.SfDataGrid.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UIKit;

namespace SampleBrowser
{
    [Foundation.Preserve(AllMembers = true)]
    class UnboundColumn : SampleView
    {
        #region Fields

        SfDataGrid SfGrid;
        SalesInfoViewModel viewModel;

        #endregion

        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public UnboundColumn()
        {
            this.SfGrid = new SfDataGrid();
            this.viewModel = new SalesInfoViewModel();
            this.SfGrid.ColumnSizer = ColumnSizer.Star;
            this.SfGrid.AutoGenerateColumns = false;
            this.SfGrid.ItemsSource = viewModel.DailySalesDetails;
            this.SfGrid.HeaderRowHeight = 45;
            this.SfGrid.RowHeight = 45;
            this.SfGrid.SelectionMode = SelectionMode.Multiple;
            this.SfGrid.SelectedIndex = 3;
            this.SfGrid.AllowResizingColumn = true;
            this.SfGrid.GridStyle = new UnboundRowStyle();
            SfGrid.CellRenderers.Remove("Unbound");
            SfGrid.CellRenderers.Add("Unbound", new UnboundColumnRenderer());
            SfGrid.UnboundRows.Add(new GridUnboundRow() { Position = UnboundRowsPosition.FixedBottom });
            SfGrid.QueryUnboundRow += SfGrid_QueryUnboundRow;
            SfGrid.SelectionChanged += SfGrid_SelectionChanged;
            SfGrid.QueryRowHeight += SfGrid_QueryRowHeight;

            GridTextColumn EmployeeName = new GridTextColumn();
            EmployeeName.HeaderText = "Employee";
            EmployeeName.TextAlignment = UITextAlignment.Left;
            EmployeeName.HeaderTextAlignment = UITextAlignment.Center;
            EmployeeName.HeaderCellTextSize = 12;
            EmployeeName.MappingName = "Name";
            SfGrid.Columns.Add(EmployeeName);

            GridTextColumn QS1 = new GridTextColumn();
            QS1.HeaderText = "2015";
            QS1.Format = "C";
            QS1.HeaderTextAlignment = UITextAlignment.Center;
            QS1.HeaderCellTextSize = 12;
            QS1.TextAlignment = UITextAlignment.Right;
            QS1.MappingName = "QS1";
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                this.SfGrid.UnboundRows.Insert(0, new GridUnboundRow() { Position = UnboundRowsPosition.FixedTop });
                this.SfGrid.UnboundRows.Insert(0, new GridUnboundRow() { Position = UnboundRowsPosition.Top });
                SfGrid.Columns.Add(QS1);
            }

            GridTextColumn QS2 = new GridTextColumn();
            QS2.HeaderText = "2016";
            QS2.Format = "C";
            QS2.HeaderTextAlignment = UITextAlignment.Center;
            QS2.HeaderCellTextSize = 12;
            QS2.TextAlignment = UITextAlignment.Right;
            QS2.MappingName = "QS2";
            SfGrid.Columns.Add(QS2);

            GridTextColumn QS3 = new GridTextColumn();
            QS3.HeaderText = "2017";
            QS3.Format = "C";
            QS3.HeaderTextAlignment = UITextAlignment.Center;
            QS3.HeaderCellTextSize = 12;
            QS3.TextAlignment = UITextAlignment.Right;
            QS3.MappingName = "QS3";
            SfGrid.Columns.Add(QS3);

            GridUnboundColumn Total = new GridUnboundColumn();
            Total.TextAlignment = UITextAlignment.Center;
            if (UserInterfaceIdiomIsPhone)
            {
                Total.Expression = "(QS2 + QS3)";

            }
            else
            {
                Total.Expression = "(QS1 + QS2 + QS3 )";
            }
            Total.Format = "C";
            Total.HeaderText = "Total";
            Total.HeaderTextAlignment = UITextAlignment.Center;
            Total.HeaderCellTextSize = 12;
            Total.TextAlignment = UITextAlignment.Center;
            Total.MappingName = "Total";
            SfGrid.Columns.Add(Total);

            foreach (GridColumn column in SfGrid.Columns)
            {
                if (UserInterfaceIdiomIsPhone)
                    SfGrid.ColumnSizer = ColumnSizer.None;
                else
                    SfGrid.ColumnSizer = ColumnSizer.Star;
            }
            this.AddSubview(SfGrid);
        }

        private void SfGrid_QueryRowHeight(object sender, QueryRowHeightEventArgs e)
        {
            if (SfGrid.IsUnboundRow(e.RowIndex))
            {
                e.Height = 70;
                e.Handled = true;
            }
        }

        private void SfGrid_SelectionChanged(object sender, GridSelectionChangedEventArgs e)
        {
            this.SfGrid.InvalidateUnboundRow(this.SfGrid.UnboundRows[this.SfGrid.UnboundRows.Count - 1]);
        }

        private void SfGrid_QueryUnboundRow(object sender, GridUnboundRowEventArgs e)
        {
            if (e.GridUnboundRow != null)
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
                            for (int i = 0; i < this.viewModel.DailySalesDetails.Count; i++)
                            {
                                sum += this.viewModel.DailySalesDetails[i].QS1;
                                e.Value = sum;
                            }
                        }
                        else if (e.RowColumnIndex.ColumnIndex == 2)
                        {
                            for (int i = 0; i < this.viewModel.DailySalesDetails.Count; i++)
                            {
                                sum += this.viewModel.DailySalesDetails[i].QS2;
                                e.Value = sum;
                            }
                        }
                        else if (e.RowColumnIndex.ColumnIndex == 3)
                        {
                            for (int i = 0; i < this.viewModel.DailySalesDetails.Count; i++)
                            {
                                sum += this.viewModel.DailySalesDetails[i].QS3;
                                e.Value = sum;
                            }
                        }
                        else if (e.RowColumnIndex.ColumnIndex == 4)
                        {
                            for (int i = 0; i < this.viewModel.DailySalesDetails.Count; i++)
                            {
                                sum += this.viewModel.DailySalesDetails[i].QS1 + this.viewModel.DailySalesDetails[i].QS2 + this.viewModel.DailySalesDetails[i].QS3;
                                e.Value = sum / this.viewModel.DailySalesDetails.Count;
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
                            for (int i = 0; i < this.viewModel.DailySalesDetails.Count; i++)
                            {
                                sum += this.viewModel.DailySalesDetails[i].QS1;
                                e.Value = sum / this.viewModel.DailySalesDetails.Count;
                            }
                        }
                        else if (e.RowColumnIndex.ColumnIndex == 2)
                        {
                            for (int i = 0; i < this.viewModel.DailySalesDetails.Count; i++)
                            {
                                sum += this.viewModel.DailySalesDetails[i].QS2;
                                e.Value = sum / this.viewModel.DailySalesDetails.Count;
                            }
                        }
                        else if (e.RowColumnIndex.ColumnIndex == 3)
                        {
                            for (int i = 0; i < this.viewModel.DailySalesDetails.Count; i++)
                            {
                                sum += this.viewModel.DailySalesDetails[i].QS3;
                                e.Value = sum / this.viewModel.DailySalesDetails.Count;
                            }
                        }
                        else if (e.RowColumnIndex.ColumnIndex == 4)
                        {
                            for (int i = 0; i < this.viewModel.DailySalesDetails.Count; i++)
                            {
                                sum += this.viewModel.DailySalesDetails[i].QS1 + this.viewModel.DailySalesDetails[i].QS2 + this.viewModel.DailySalesDetails[i].QS3;
                                e.Value = sum / this.viewModel.DailySalesDetails.Count;
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
                            if (this.SfGrid.SelectedItems.Count > 0)
                            {
                                for (int i = 0; i < this.SfGrid.SelectedItems.Count; i++)
                                {
                                    e.Value = sum += this.SfGrid.SelectedItems[i] != null ? (this.SfGrid.SelectedItems[i] as SalesByDate).QS2 : 0;
                                }
                            }
                            else
                            {
                                e.Value = null;
                            }
                        }
                        else if (e.RowColumnIndex.ColumnIndex == 2)
                        {
                            if (this.SfGrid.SelectedItems.Count > 0)
                            {
                                for (int i = 0; i < this.SfGrid.SelectedItems.Count; i++)
                                {
                                    e.Value = sum += this.SfGrid.SelectedItems[i] != null ? (this.SfGrid.SelectedItems[i] as SalesByDate).QS3 : 0;
                                }
                            }
                            else
                            {
                                e.Value = null;
                            }
                        }
                        else if (e.RowColumnIndex.ColumnIndex == 3)
                        {
                            if (this.SfGrid.SelectedItems.Count > 0)
                            {
                                for (int i = 0; i < this.SfGrid.SelectedItems.Count; i++)
                                {
                                    if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                                    {
                                        e.Value = sum += this.SfGrid.SelectedItems[i] != null ? (this.SfGrid.SelectedItems[i] as SalesByDate).QS1 + (this.SfGrid.SelectedItems[i] as SalesByDate).QS2 + (this.SfGrid.SelectedItems[i] as SalesByDate).QS3 : 0;
                                    }
                                    else
                                    {
                                        e.Value = sum += this.SfGrid.SelectedItems[i] != null ? (this.SfGrid.SelectedItems[i] as SalesByDate).QS2 + (this.SfGrid.SelectedItems[i] as SalesByDate).QS3 : 0;
                                    }
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
        }

        public override void LayoutSubviews()
        {
            this.SfGrid.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);
            base.LayoutSubviews();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (SfGrid != null)
                {
                    SfGrid.Dispose();
                    SfGrid = null;
                }
                base.Dispose(disposing);
            }
        }
    }

    public class UnboundColumnRenderer : GridUnboundCellTextBoxRenderer
    {
        public UnboundColumnRenderer()
        {

        }

        public override void OnInitializeDisplayView(DataColumnBase dataColumn, UILabel view)
        {
            base.OnInitializeDisplayView(dataColumn, view);
            var gridcell = dataColumn.GetType().GetRuntimeProperties().FirstOrDefault(x => x.Name.Equals("Element")).GetValue(dataColumn);
            (gridcell as UIView).BackgroundColor = UIColor.FromRGB(225, 245, 254);
        }
    }

    public class UnboundRowStyle : DefaultStyle
    {
        public UnboundRowStyle()
        {

        }
        public override GridLinesVisibility GetGridLinesVisibility()
        {
            return GridLinesVisibility.Both;
        }
        public override UIColor GetUnboundRowBackgroundColor()
        {
            return UIColor.FromRGB(225, 245, 254);
        }
    }
}
