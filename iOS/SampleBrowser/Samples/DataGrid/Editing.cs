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
using System.Linq;
using System.Text;


namespace SampleBrowser
{
    [Foundation.Preserve(AllMembers = true)]
    public class Editing : SampleView
    {

        SfDataGrid sfGrid;
        EditingViewModel viewmodel;

        public Editing()
        {
            sfGrid = new SfDataGrid();
            viewmodel = new EditingViewModel();
            sfGrid.AutoGenerateColumns = false;
            sfGrid.RowHeight = 50;
            sfGrid.AllowEditing = true;
            sfGrid.SelectionMode = SelectionMode.Single;
            sfGrid.NavigationMode = NavigationMode.Cell;
            sfGrid.EditTapAction = TapAction.OnTap;
            sfGrid.ColumnSizer = ColumnSizer.Star;
            sfGrid.HeaderRowHeight = 40;
            sfGrid.ItemsSource = viewmodel.DealerInformation;

            GridNumericColumn productPrice = new GridNumericColumn();
            productPrice.MappingName = "ProductPrice";
            productPrice.HeaderText = "Product Price";
            productPrice.HeaderTextAlignment = UIKit.UITextAlignment.Center;

            GridDateTimeColumn shippedDate = new GridDateTimeColumn();
            shippedDate.MappingName = "ShippedDate";
            shippedDate.HeaderText = "Shipped Date";
            shippedDate.Format = "d";
            shippedDate.HeaderTextAlignment = UIKit.UITextAlignment.Center;

            GridPickerColumn dealerName = new GridPickerColumn();
            dealerName.MappingName = "DealerName";
            dealerName.HeaderText = "Dealer Name";
            dealerName.ItemsSource = viewmodel.CustomerNames;
            dealerName.HeaderTextAlignment = UIKit.UITextAlignment.Center;

            GridTextColumn productNo = new GridTextColumn();
            productNo.MappingName = "ProductNo";
            productNo.HeaderText = "Product No";
            productNo.HeaderTextAlignment = UIKit.UITextAlignment.Center;

            sfGrid.Columns.Add(productNo);
            sfGrid.Columns.Add(dealerName);
            sfGrid.Columns.Add(shippedDate);
            sfGrid.Columns.Add(productPrice);
            this.AddSubview(sfGrid);
        }

        public override void LayoutSubviews()
        {
            this.sfGrid.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);
            base.LayoutSubviews();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (sfGrid != null)
                    sfGrid.Dispose();

                viewmodel = null;
                sfGrid = null;
            }
           base.Dispose(disposing);
        }
    }
}