#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using Syncfusion.SfDataGrid;
using Syncfusion.SfDataGrid.DataPager;
using UIKit;
using System.Globalization;
using CoreGraphics;

namespace SampleBrowser
{
    public class Paging : SampleView
    {
       #region Fields

		SfDataGrid SfGrid;
        SfDataPager SfDataPager;

		#endregion

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

        public Paging()
		{
            this.SfDataPager = new SfDataPager();
            this.SfDataPager.PageSize = 15;
            this.SfDataPager.Source = new PagingViewModel().OrdersInfo;
            this.SfDataPager.NumericButtonCount = 20;
            this.AddSubview(this.SfDataPager);

			this.SfGrid = new SfDataGrid ();
			this.SfGrid.AutoGeneratingColumn += GridAutoGenerateColumns;
            this.SfGrid.SelectionMode = SelectionMode.Single;
			this.SfGrid.ItemsSource = SfDataPager.PagedSource;
			this.SfGrid.ShowRowHeader = false;
			this.SfGrid.HeaderRowHeight = 45;
			this.SfGrid.RowHeight = 45;
			this.SfGrid.GridStyle.AlternatingRowColor = UIColor.FromRGB (219, 219, 219);
			this.AddSubview (this.SfGrid);
		}


		void GridAutoGenerateColumns (object sender, AutoGeneratingColumnEventArgs e)
		{
			if (e.Column.MappingName == "OrderID") {
				e.Column.HeaderText = "Order ID";
				e.Column.TextAlignment = UITextAlignment.Center;
			} else if (e.Column.MappingName == "CustomerID") {
				e.Column.HeaderText = "Customer ID";
				e.Column.TextMargin = 10;
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "Freight") {
				e.Column.Format = "C";
				e.Column.CultureInfo = new CultureInfo ("en-US");
				e.Column.TextAlignment = UITextAlignment.Center;
			} else if (e.Column.MappingName == "ShipCity") {
				e.Column.HeaderText = "Ship City";
				e.Column.TextMargin = 10;
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "ShipCountry") {
				e.Column.HeaderText = "Ship Country";
				e.Column.TextMargin = 10;
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "Index") {
				e.Column.TextAlignment = UITextAlignment.Center;
			} else if (e.Column.MappingName == "EmployeeID") {
				e.Column.HeaderText = "Employee ID";
				e.Column.TextAlignment = UITextAlignment.Center;
			} else if (e.Column.MappingName == "FirstName") {
				e.Column.HeaderText = "First Name";
				e.Column.TextMargin = 10;
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "LastName") {
				e.Column.HeaderText = "Last Name";
				e.Column.TextMargin = 10;
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "Gender") {
				e.Column.TextAlignment = UITextAlignment.Left;
				e.Column.TextMargin = 10;
			} else if (e.Column.MappingName == "ShippingDate") {
				e.Column.HeaderText = "Shipping Date";
				e.Column.TextMargin = 15;
				e.Column.TextAlignment = UITextAlignment.Left;
				e.Column.Format = "d";
			} else if (e.Column.MappingName == "IsClosed") {
				e.Column.HeaderText = "Is Closed";
				e.Column.TextMargin = 15;
				e.Column.TextAlignment = UITextAlignment.Left;
			}				
		}

		public override void LayoutSubviews ()
		{
            this.SfDataPager.Frame = new CGRect(0, 0, this.Frame.Width + 5, 75);
			this.SfGrid.Frame = new CGRect (0, 75, this.Frame.Width, this.Frame.Height - 75);
			base.LayoutSubviews ();
		}

        protected override void Dispose(bool disposing)
        {
            SfGrid.Dispose();
            base.Dispose(disposing);
        }
    }
}
