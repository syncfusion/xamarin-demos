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

using Foundation;
using UIKit;
using Syncfusion.SfDataGrid;
using System.Globalization;
using CoreGraphics;
using Syncfusion.GridCommon.ScrollAxis;

namespace SampleBrowser
{
    public class FrozenView : SampleView
    {
        #region Fields

        SfDataGrid sfGrid;
        FrozenViewViewModel viewModel;
        UIView frozenView;

        #endregion

        #region Static Methods

        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        #endregion

        #region Constructor

        public FrozenView()
        {
            sfGrid = new SfDataGrid();
            frozenView = new UIView();
            this.sfGrid.SelectionMode = SelectionMode.Single;
            viewModel = new FrozenViewViewModel();
            sfGrid.AutoGeneratingColumn += GridAutoGenerateColumns;
            sfGrid.ItemsSource = viewModel.Products;
            if (Utility.IsIpad)
                this.sfGrid.ColumnSizer = ColumnSizer.Star;
            sfGrid.FrozenRowsCount = 2;
            sfGrid.FrozenColumnsCount = 1;
            sfGrid.GridLoaded += DataGrid_GridLoaded;
            this.sfGrid.GridStyle = new FrozenViewStyle();
            this.AddSubview(sfGrid);
        }

        private void DataGrid_GridLoaded(object sender, GridLoadedEventArgs e)
        {
            var point = sfGrid.RowColumnIndexToPoint(new RowColumnIndex(sfGrid.FrozenRowsCount, 0));
            frozenView.Frame = new CGRect(0, point.Y + sfGrid.RowHeight, this.Frame.Width, 1);
            frozenView.BackgroundColor = UIColor.FromRGB(117, 117, 117);
            this.AddSubview(frozenView);
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
            sfGrid.GridLoaded -= DataGrid_GridLoaded;
            sfGrid.Dispose();
            base.Dispose(disposing);
        }

        #endregion

        #region CallBacks

        private void GridAutoGenerateColumns(object sender, AutoGeneratingColumnEventArgs e)
        {
            if (e.Column.MappingName == "SupplierID")
            {
                e.Column.HeaderText = "Supplier ID";
                e.Column.TextAlignment = UITextAlignment.Center;
            }
            else if (e.Column.MappingName == "ProductID")
            {
                e.Column.HeaderText = "Product ID";
                e.Column.TextAlignment = UITextAlignment.Center;
            }
            else if (e.Column.MappingName == "ProductName")
            {
                e.Column.HeaderText = "Product Name";
                e.Column.TextAlignment = UITextAlignment.Left;
            }
            else if (e.Column.MappingName == "QuantityPerUnit")
            {
                e.Column.HeaderText = "Quantity Per Unit";
                e.Column.TextAlignment = UITextAlignment.Center;
            }
            else if (e.Column.MappingName == "UnitPrice")
            {
                e.Column.TextAlignment = UITextAlignment.Center;
                e.Column.Format = "C";
                e.Column.CultureInfo = new CultureInfo("en-US");
                e.Column.HeaderText = "Unit Price";
            }
            else if (e.Column.MappingName == "UnitsInStock")
            {
                e.Column.TextAlignment = UITextAlignment.Center;
                e.Column.HeaderText = "Units In Stock";
            }
        }

        #endregion

    }

    public class FrozenViewStyle : DataGridStyle
        {
        public FrozenViewStyle()
        {

        }
     
        public override GridLinesVisibility GetGridLinesVisibility()
        {
           return GridLinesVisibility.Both;
        }
    }
          
}