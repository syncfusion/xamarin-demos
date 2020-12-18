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
    class UnboundColumn: SampleView
    {
        #region Fields

		SfDataGrid SfGrid;

		#endregion

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public UnboundColumn ()
		{
			this.SfGrid = new SfDataGrid ();
            this.SfGrid.ColumnSizer = ColumnSizer.Auto;
            this.SfGrid.SelectionMode = SelectionMode.Single;
            this.SfGrid.AutoGenerateColumns = false;
			this.SfGrid.ItemsSource = new UnboundViewModel ().Products;
			this.SfGrid.HeaderRowHeight = 45;
			this.SfGrid.RowHeight = 45;
            this.SfGrid.GridStyle = new Blue();
            this.SfGrid.AllowResizingColumn = true;
            this.SfGrid.GridStyle = new CustomGridStyle();
            SfGrid.CellRenderers.Remove("Unbound");
            SfGrid.CellRenderers.Add("Unbound", new UnboundColumnRenderer());
            SfGrid.CellRenderers.Remove("TextView");
            SfGrid.CellRenderers.Add("TextView", new TextRenderer());

            GridTextColumn ProductName = new GridTextColumn();
            ProductName.HeaderText = "Product Name";
            ProductName.LineBreakMode = UILineBreakMode.WordWrap;
            ProductName.TextAlignment = UITextAlignment.Left;
            ProductName.HeaderTextAlignment = UITextAlignment.Center;
            //ProductName.HeaderCellTextSize = 12;
            ProductName.MappingName = "ProductName";
            SfGrid.Columns.Add(ProductName);

            GridTextColumn UnitPrice = new GridTextColumn();
            UnitPrice.HeaderText = "Price";
            UnitPrice.Format = "C";
            UnitPrice.HeaderTextAlignment = UITextAlignment.Center;
            //UnitPrice.HeaderCellTextSize = 12;
            UnitPrice.TextAlignment = UITextAlignment.Center;
            UnitPrice.MappingName = "UnitPrice";
            SfGrid.Columns.Add(UnitPrice);

            GridTextColumn Quantity = new GridTextColumn();
            Quantity.HeaderText = "Quantity";
            Quantity.HeaderTextAlignment = UITextAlignment.Center;
            //Quantity.HeaderCellTextSize = 12;
            Quantity.MappingName = "Quantity";
            Quantity.TextAlignment = UITextAlignment.Center;
            SfGrid.Columns.Add(Quantity);

            GridTextColumn Discount = new GridTextColumn();
            Discount.TextAlignment = UITextAlignment.Center;
            Discount.HeaderText = "Discount";
            Discount.HeaderTextAlignment = UITextAlignment.Center;
            Discount.HeaderCellTextSize = UIFont.SystemFontOfSize(12);
            Discount.TextAlignment = UITextAlignment.Center;
            Discount.MappingName = "Discount";
           SfGrid.Columns.Add(Discount);

            GridUnboundColumn Total = new GridUnboundColumn();
            Total.TextAlignment = UITextAlignment.Center;
            Total.Expression = "(Quantity * UnitPrice) - ((Quantity * UnitPrice)/100 * Quantity)";
            Total.Format = "C";
            Total.HeaderText = "Total";
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
            this.AddSubview (SfGrid);
		}
        public override void LayoutSubviews()
        {
            this.SfGrid.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);
            base.LayoutSubviews();
        }

        protected override void Dispose(bool disposing)
        {
            SfGrid.Dispose();
            base.Dispose(disposing);
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

    public class TextRenderer: GridCellTextViewRenderer
    {
        public TextRenderer()
        {

        }

        public override void OnInitializeDisplayView(DataColumnBase dataColumn, UILabel view)
        {
            base.OnInitializeDisplayView(dataColumn, view);
            var gridcell = dataColumn.GetType().GetRuntimeProperties().FirstOrDefault(x => x.Name.Equals("Element")).GetValue(dataColumn);
            (gridcell as UIView).BackgroundColor = UIColor.White;
        }
    }
}
