#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using System.Globalization;
using System.Linq;
using Android.Content;
using Android.Content.Res;
using Syncfusion.GridCommon.ScrollAxis;
using System.Collections.ObjectModel;
using Syncfusion.SfDataGrid;

namespace SampleBrowser
{
    public class UnboundColumn : SamplePage
    {
        SfDataGrid sfGrid;
        SalesInfoViewModel viewModel;

        public override Android.Views.View GetSampleContent(Android.Content.Context context)
        {
            LinearLayout linear = new LinearLayout(context);
            linear.Orientation = Android.Widget.Orientation.Vertical;
            sfGrid = new SfDataGrid(context);
            sfGrid.VerticalOverScrollMode = VerticalOverScrollMode.None;
            sfGrid.SelectionMode = SelectionMode.Multiple;
            viewModel = new SalesInfoViewModel();
            sfGrid.AutoGenerateColumns = false;
            sfGrid.ItemsSource = viewModel.DailySalesDetails;
            sfGrid.AllowResizingColumn = true;
            sfGrid.VerticalOverScrollMode = VerticalOverScrollMode.None;
            sfGrid.CellRenderers.Remove("Unbound");
            sfGrid.CellRenderers.Add("Unbound", new UnboundColumnRenderer());
            sfGrid.Alpha = 0.87f;
            sfGrid.SelectedIndex = 3;
            sfGrid.GridStyle = new UnboundRowstyle();
            sfGrid.ColumnSizer = ColumnSizer.Star;
            sfGrid.UnboundRows.Add(new GridUnboundRow() {Position = UnboundRowsPosition.FixedBottom });
            sfGrid.QueryUnboundRow += SfGrid_QueryUnboundRow;
            sfGrid.QueryRowHeight += SfGrid_QueryRowHeight;
            sfGrid.SelectionChanged += SfGrid_SelectionChanged;

            if(MainActivity.IsTablet)
            {
                this.sfGrid.UnboundRows.Insert(0, new GridUnboundRow() { Position = UnboundRowsPosition.FixedTop });
                this.sfGrid.UnboundRows.Insert(0, new GridUnboundRow() { Position = UnboundRowsPosition.Top });
            }

            GridTextColumn EmployeeName = new GridTextColumn();
            EmployeeName.HeaderText = "Employee";
            EmployeeName.TextAlignment = GravityFlags.CenterVertical | GravityFlags.Left;
            EmployeeName.HeaderTextAlignment = GravityFlags.CenterVertical | GravityFlags.Left;
            EmployeeName.HeaderCellTextSize = 12;
            EmployeeName.MappingName = "Name";
            EmployeeName.LoadUIView = true;
            sfGrid.Columns.Add(EmployeeName);

            GridTextColumn QS1 = new GridTextColumn();
            QS1.LoadUIView = true;
            QS1.HeaderText = "2015";
            QS1.Format = "C";
            QS1.LineBreakMode = LineBreakMode.NoWrap;
            QS1.HeaderTextAlignment = GravityFlags.CenterVertical | GravityFlags.Left;
            QS1.HeaderCellTextSize = 12;
            QS1.TextAlignment = GravityFlags.CenterVertical | GravityFlags.Right;
            QS1.MappingName = "QS1";
            if (MainActivity.IsTablet)
            {
                sfGrid.Columns.Add(QS1);
            }

            GridTextColumn QS2 = new GridTextColumn();
            QS2.LoadUIView = true;
            QS2.HeaderText = "2016";
            QS2.Format = "C";
            QS2.LineBreakMode = LineBreakMode.NoWrap;
            QS2.HeaderTextAlignment = GravityFlags.CenterVertical | GravityFlags.Left;
            QS2.HeaderCellTextSize = 12;
            QS2.TextAlignment = GravityFlags.CenterVertical | GravityFlags.Right;
            QS2.MappingName = "QS2";
            sfGrid.Columns.Add(QS2);

            GridTextColumn QS3 = new GridTextColumn();
            QS3.LoadUIView = true;
            QS3.HeaderText = "2017";
            QS3.Format = "C";
            QS3.LineBreakMode = LineBreakMode.NoWrap;
            QS3.HeaderTextAlignment = GravityFlags.CenterVertical | GravityFlags.Left;
            QS3.HeaderCellTextSize = 12;
            QS3.TextAlignment = GravityFlags.CenterVertical | GravityFlags.Right;
            QS3.MappingName = "QS3";
            sfGrid.Columns.Add(QS3);

            GridUnboundColumn Total = new GridUnboundColumn();
            Total.TextAlignment = GravityFlags.Right | GravityFlags.CenterVertical;
            if (MainActivity.IsTablet)
            {
                Total.Expression = "(QS1 + QS2 + QS3 )";
            }
            else
            {
                Total.Expression = "(QS2 + QS3)";
            }
            Total.Format = "C";
            Total.LineBreakMode = LineBreakMode.NoWrap;
            Total.HeaderText = "Total";
            Total.HeaderTextAlignment = GravityFlags.Left | GravityFlags.CenterVertical;
            Total.HeaderCellTextSize = 12;
            Total.HeaderFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
            Total.RecordFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
            Total.TextAlignment = GravityFlags.Center;
            Total.MappingName = "Total";
            Total.LoadUIView = true;
            sfGrid.Columns.Add(Total);

            linear.AddView(sfGrid);
            return linear;
        }

        private void SfGrid_SelectionChanged(object sender, GridSelectionChangedEventArgs e)
        {
            this.sfGrid.InvalidateUnboundRow(this.sfGrid.UnboundRows[this.sfGrid.UnboundRows.Count - 1]);
        }

        private void SfGrid_QueryRowHeight(object sender, QueryRowHeightEventArgs e)
        {
            e.Height = 60 * Resources.System.DisplayMetrics.Density;
            if (this.sfGrid.IsUnboundRow(e.RowIndex))
            {
                e.Height = 70 * Resources.System.DisplayMetrics.Density;
            }
            e.Handled = true;
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
                            if (this.sfGrid.SelectedItems.Count > 0)
                            {
                                for (int i = 0; i < this.sfGrid.SelectedItems.Count; i++)
                                {
                                    e.Value = sum += this.sfGrid.SelectedItems[i] != null ? (this.sfGrid.SelectedItems[i] as SalesByDate).QS2 : 0;
                                }
                            }
                            else
                            {
                                e.Value = null;
                            }
                        }
                        else if (e.RowColumnIndex.ColumnIndex == 2)
                        {
                            if (this.sfGrid.SelectedItems.Count > 0)
                            {
                                for (int i = 0; i < this.sfGrid.SelectedItems.Count; i++)
                                {
                                    e.Value = sum += this.sfGrid.SelectedItems[i] != null ? (this.sfGrid.SelectedItems[i] as SalesByDate).QS3 : 0;
                                }
                            }
                            else
                            {
                                e.Value = null;
                            }
                        }
                        else if (e.RowColumnIndex.ColumnIndex == 3)
                        {
                            if (this.sfGrid.SelectedItems.Count > 0)
                            {
                                for (int i = 0; i < this.sfGrid.SelectedItems.Count; i++)
                                {
                                    if(MainActivity.IsTablet)
                                    {
                                        e.Value = sum += this.sfGrid.SelectedItems[i] != null ? (this.sfGrid.SelectedItems[i] as SalesByDate).QS1 + (this.sfGrid.SelectedItems[i] as SalesByDate).QS2 + (this.sfGrid.SelectedItems[i] as SalesByDate).QS3 : 0;
                                    }
                                    else
                                    {
                                        e.Value = sum += this.sfGrid.SelectedItems[i] != null ? (this.sfGrid.SelectedItems[i] as SalesByDate).QS2 + (this.sfGrid.SelectedItems[i] as SalesByDate).QS3 : 0;
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

        public override void OnApplyChanges()
        {
            base.OnApplyChanges();
        }

        public override void Destroy()
        {
            sfGrid.Dispose();
            sfGrid = null;
            viewModel = null;
        }
    }

    public class UnboundColumnRenderer: GridUnboundCellTextBoxRenderer
    {
        public UnboundColumnRenderer()
        {
           
        }
        public override void OnInitializeDisplayView(DataColumnBase dataColumn, TextView view)
        {
            base.OnInitializeDisplayView(dataColumn, view);
            view.SetBackgroundColor(Color.Rgb(225, 245, 254));
        }

        protected override void OnLayout(RowColumnIndex rowColumnIndex, View view, int left, int top, int right, int bottom)
        {
            base.OnLayout(rowColumnIndex, view, left, top, right, bottom);
            view.SetPadding((int)(0.5 *Resources.System.DisplayMetrics.Density), (int)(0.5 * Resources.System.DisplayMetrics.Density), (int)(0.5 * Resources.System.DisplayMetrics.Density), (int)(0.5 * Resources.System.DisplayMetrics.Density));
        }
    }

    public class UnboundRowstyle : DefaultStyle
    {
        public UnboundRowstyle()
        {

        }

        public override Color GetUnboundRowBackgroundColor()
        {
            return Color.Rgb(225, 245, 254);
        }
    }
}
