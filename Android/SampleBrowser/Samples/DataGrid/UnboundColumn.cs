#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfDataGrid;
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

namespace SampleBrowser
{
    public class UnboundColumn : SamplePage
    {
        SfDataGrid sfGrid;
        UnboundColumnViewModel viewModel;

        public override Android.Views.View GetSampleContent(Android.Content.Context context)
        {
            LinearLayout linear = new LinearLayout(context);
            linear.Orientation = Android.Widget.Orientation.Vertical;
            sfGrid = new SfDataGrid(context);
            viewModel = new UnboundColumnViewModel();
            viewModel.SetRowstoGenerate(100);
            sfGrid.AutoGenerateColumns = false;
            sfGrid.ItemsSource = viewModel.Products;
            sfGrid.AllowResizingColumn = true;
            sfGrid.VerticalOverScrollMode = VerticalOverScrollMode.None;
            sfGrid.CellRenderers.Remove("Unbound");
            sfGrid.CellRenderers.Add("Unbound", new UnboundColumnRenderer());
            sfGrid.Alpha = 0.87f ;
           
            GridTextColumn ProductName = new GridTextColumn();
            ProductName.HeaderText = "Product";
            ProductName.TextAlignment = GravityFlags.CenterVertical;
            ProductName.HeaderTextAlignment = GravityFlags.Center;
            ProductName.HeaderCellTextSize = 12;
            ProductName.MappingName = "ProductName";
            sfGrid.Columns.Add(ProductName);

            GridTextColumn UnitPrice = new GridTextColumn();
            UnitPrice.HeaderText = "Price";
            UnitPrice.Format = "C";
            UnitPrice.HeaderTextAlignment = GravityFlags.Center;
            UnitPrice.HeaderCellTextSize = 12;
            UnitPrice.TextAlignment = GravityFlags.Center;
            UnitPrice.MappingName = "UnitPrice";
            sfGrid.Columns.Add(UnitPrice);

            GridTextColumn Quantity = new GridTextColumn();
            Quantity.HeaderText = "Quantity";
            Quantity.HeaderTextAlignment = GravityFlags.Center;
            Quantity.HeaderCellTextSize = 12;
            Quantity.MappingName = "Quantity";
            Quantity.TextAlignment = GravityFlags.Center;
            sfGrid.Columns.Add(Quantity);

            //GridUnboundColumn Amount = new GridUnboundColumn();
            //Amount.HeaderText = "Amount";
            //Amount.TextAlignment = GravityFlags.Left;
            //Amount.Expression = "UnitPrice * Quantity";
            //Amount.Format = "C";
            //Amount.HeaderTextAlignment = GravityFlags.Center;
            //Amount.TextAlignment = GravityFlags.Center;
            //Amount.HeaderCellTextSize = 13;
            //Amount.CellTextSize = 13;
            //Amount.HeaderFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
            //Amount.RecordFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
            //Amount.LoadUIView = true;
            //Amount.MappingName = "Amount";
            //sfGrid.Columns.Add(Amount);

            GridTextColumn Discount = new GridTextColumn();
           Discount.TextAlignment = GravityFlags.Left;
           Discount.Format = "p";
           Discount.HeaderText = "Discount";
           Discount.HeaderTextAlignment = GravityFlags.Center;
           Discount.HeaderCellTextSize = 12;
           Discount.CellTextSize = 12;
           Discount.HeaderFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
           Discount.RecordFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
           Discount.TextAlignment = GravityFlags.Center;
           Discount.MappingName = "Discount";
            Discount.LoadUIView = true;
            sfGrid.Columns.Add(Discount);

            GridUnboundColumn Total = new GridUnboundColumn();
            Total.TextAlignment = GravityFlags.Left;
            Total.Expression = "(Quantity * UnitPrice) - ((Quantity * UnitPrice)/100 * Quantity)";
            Total.Format = "C";
            Total.HeaderText = "Total";
            Total.HeaderTextAlignment = GravityFlags.Center;
            Total.HeaderCellTextSize = 13;
            Total.CellTextSize = 13;
            Total.HeaderFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
            Total.RecordFont = Typeface.Create("Roboto-Regular", TypefaceStyle.Normal);
            Total.TextAlignment = GravityFlags.Center;
            Total.MappingName = "Total";
            Total.LoadUIView = true;
            sfGrid.Columns.Add(Total);

            foreach(GridColumn column in sfGrid.Columns)
            {
                if (MainActivity.IsTablet)
                    column.MaximumWidth = 300;
                else
                    column.MaximumWidth = 150;
            }

            linear.AddView(sfGrid);
            return linear;
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
}
