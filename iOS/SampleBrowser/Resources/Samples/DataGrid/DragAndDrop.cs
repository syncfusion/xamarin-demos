#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using CoreGraphics;
using Syncfusion.SfDataGrid;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UIKit;

namespace SampleBrowser
{
    public class DragAndDrop : SampleView
    {
        #region Fields

        SfDataGrid sfGrid;
        DragAndDropViewModel viewModel;

        #endregion

        #region Static Methods

        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        #endregion

        #region Constructor

        public DragAndDrop()
        {
            sfGrid = new SfDataGrid();
            this.sfGrid.SelectionMode = SelectionMode.Single;
            viewModel = new DragAndDropViewModel();
            sfGrid.AutoGeneratingColumn += GridAutoGenerateColumns;
            sfGrid.ItemsSource = viewModel.OrdersInfo;
            sfGrid.AllowDraggingRow = true;
            sfGrid.RowDragDropTemplate = new RowDragDropTemplate();
            sfGrid.AllowDraggingColumn = true;
            sfGrid.QueryRowDragging += QueryRowDragging;
            sfGrid.ColumnSizer = ColumnSizer.Star;
            this.AddSubview(sfGrid);
        }

        #endregion

        #region Override Methods

        public override void LayoutSubviews()
        {
            this.sfGrid.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);
            base.LayoutSubviews();
        }

        protected override void Dispose(bool disposing)
        {
            sfGrid.Dispose();
            base.Dispose(disposing);
        }

        #endregion

        #region CallBacks

        void GridAutoGenerateColumns(object sender, AutoGeneratingColumnEventArgs e)
        {
            if (e.Column.MappingName == "OrderID")
            {
                e.Column.HeaderText = "Order ID";
                e.Column.TextAlignment = UITextAlignment.Center;
            }
            else if (e.Column.MappingName == "CustomerID")
            {
                e.Column.HeaderText = "Customer ID";
                e.Column.TextAlignment = UITextAlignment.Left;
            }
            else if (e.Column.MappingName == "EmployeeID")
            {
                e.Column.HeaderText = "Employee ID";
                e.Column.TextAlignment = UITextAlignment.Center;
            }
            else if (e.Column.MappingName == "FirstName")
            {
                e.Column.HeaderText = "First Name";
                e.Column.TextMargin = 5;
                e.Column.TextAlignment = UITextAlignment.Left;
            }
            else
                e.Cancel = true;
            e.Column.RecordFont = UIFont.FromName("HelveticaNeue", 12);
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

    public class RowDragDropTemplate : UIView
    {
        #region Field

        UILabel label1;
        UILabel label2;
        UILabel label3;
        UILabel label4;

        #endregion

        #region Constructor 

        public RowDragDropTemplate()
        {
            label1 = new UILabel() { TextAlignment = UITextAlignment.Center, TextColor = UIColor.Black, LineBreakMode = UILineBreakMode.TailTruncation, Font = UIFont.FromName("HelveticaNeue", 12) };
            label2 = new UILabel() { TextAlignment = UITextAlignment.Center, TextColor = UIColor.Black, LineBreakMode = UILineBreakMode.TailTruncation, Font = UIFont.FromName("HelveticaNeue", 12) };
            label3 = new UILabel() { TextAlignment = UITextAlignment.Center, TextColor = UIColor.Black, LineBreakMode = UILineBreakMode.TailTruncation, Font = UIFont.FromName("HelveticaNeue", 12) };
            label4 = new UILabel() { TextAlignment = UITextAlignment.Center, TextColor = UIColor.Black, LineBreakMode = UILineBreakMode.TailTruncation, Font = UIFont.FromName("HelveticaNeue", 12) };

            this.AddSubview(label1);
            this.AddSubview(label2);
            this.AddSubview(label3);
            this.AddSubview(label4);

            this.Layer.MasksToBounds = true;
            this.Layer.AllowsEdgeAntialiasing = true;
            this.Layer.BorderWidth = 0.25f;
            this.Layer.BorderColor = UIColor.Black.CGColor;
        }

        #endregion

        #region Method

        public void UpdateRow(object rowData)
        {
            var orderInfo = rowData as OrderInfo;
            label1.Text = orderInfo.OrderID;
            label2.Text = orderInfo.EmployeeID;
            label3.Text = orderInfo.CustomerID;
            label4.Text = orderInfo.FirstName;
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            label1.Frame = new CGRect(0, 0, this.Frame.Width / 4, this.Frame.Height);
            label2.Frame = new CGRect(this.Frame.Width / 4, 0, this.Frame.Width / 4, this.Frame.Height);
            label3.Frame = new CGRect((this.Frame.Width / 4) * 2, 0, this.Frame.Width / 4, this.Frame.Height);
            label4.Frame = new CGRect((this.Frame.Width / 4) * 3, 0, this.Frame.Width / 4, this.Frame.Height);
        }

        #endregion
    }
}
