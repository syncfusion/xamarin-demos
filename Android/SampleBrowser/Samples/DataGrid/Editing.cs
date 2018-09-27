#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.Content;
using Android.Views;
using Syncfusion.SfDataGrid;
using System.Globalization;


namespace SampleBrowser
{
    public class Editing : SamplePage
    {

        SfDataGrid sfGrid;
        EditingViewModel viewmodel;

        public override View GetSampleContent(Context context)
        {
            sfGrid = new SfDataGrid(context);
            viewmodel = new EditingViewModel();
            sfGrid.AutoGenerateColumns = false;
            sfGrid.RowHeight = 50;
            sfGrid.AllowEditing = true;
            sfGrid.EditTapAction = TapAction.OnTap;
            sfGrid.ColumnSizer = ColumnSizer.Star;
            sfGrid.SelectionMode = SelectionMode.None;
            sfGrid.HeaderRowHeight = 40;
            sfGrid.ItemsSource = viewmodel.DealerInformation;
            sfGrid.VerticalOverScrollMode = VerticalOverScrollMode.None;

            GridNumericColumn productPrice = new GridNumericColumn();
            productPrice.MappingName = "ProductPrice";
            productPrice.HeaderText = "Product Price";
            productPrice.HeaderTextAlignment = GravityFlags.Center;
           
            GridDateTimeColumn shippedDate = new GridDateTimeColumn();
            shippedDate.MappingName = "ShippedDate";
            shippedDate.HeaderText = "Shipped Date";
            shippedDate.HeaderTextAlignment = GravityFlags.Center;
            shippedDate.Format = "d";
           
            GridPickerColumn dealerName = new GridPickerColumn();
            dealerName.MappingName = "DealerName";
            dealerName.HeaderText = "Dealer Name";
            dealerName.ItemsSource = viewmodel.CustomerNames;
            dealerName.HeaderTextAlignment = GravityFlags.Center;

            GridTextColumn productNo = new GridTextColumn();
            productNo.MappingName = "ProductNo";
            productNo.HeaderText = "Product No";
            productNo.HeaderTextAlignment = GravityFlags.Center;
            
            sfGrid.Columns.Add(productNo);
            sfGrid.Columns.Add(dealerName);
            sfGrid.Columns.Add(shippedDate);
            sfGrid.Columns.Add(productPrice);
            
            return sfGrid;
        }
    }
}
