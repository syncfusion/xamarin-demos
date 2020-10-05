#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfDataGrid;
using UIKit;
using CoreGraphics;
using System.Globalization;

namespace SampleBrowser
{
	public class Grouping:SampleView
	{
		#region Fields

		SfDataGrid SfGrid;

		#endregion

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public Grouping ()
		{
			this.SfGrid = new SfDataGrid ();
            this.SfGrid.SelectionMode = SelectionMode.Single;
			this.SfGrid.ItemsSource = new GroupingViewModel ().ProductDetails;
			this.SfGrid.AutoGeneratingColumn += GridAutoGenerateColumns;
			this.SfGrid.HeaderRowHeight = 45;
			this.SfGrid.RowHeight = 45;
            this.SfGrid.AllowGroupExpandCollapse = true;
            this.SfGrid.AllowResizingColumn = true;

            // Multi-Grouping
            this.SfGrid.GroupingMode = GroupingMode.Multiple;
            this.SfGrid.GroupColumnDescriptions.Add(new GroupColumnDescription() { ColumnName = "Product" });
            this.SfGrid.GroupColumnDescriptions.Add(new GroupColumnDescription() { ColumnName = "ProductModel" });

            // GroupSummary codes
            GridGroupSummaryRow groupSummaryRow = new GridGroupSummaryRow();
            groupSummaryRow.Title = "Total items:{Total} items";
            groupSummaryRow.ShowSummaryInRow = true;
            GridSummaryColumn groupSummaryColumn = new GridSummaryColumn();
            groupSummaryColumn.Name = "Total";
            groupSummaryColumn.MappingName = "Product";
            groupSummaryColumn.Format = "{Count}";
            groupSummaryColumn.SummaryType = Syncfusion.Data.SummaryType.CountAggregate;
            groupSummaryRow.SummaryColumns.Add(groupSummaryColumn);
            SfGrid.GroupSummaryRows.Add(groupSummaryRow);

            //TableSummary codes
            GridTableSummaryRow summaryRow = new GridTableSummaryRow();
            summaryRow.Title = "Total items:{Total} items";
            summaryRow.ShowSummaryInRow = true;
            summaryRow.Position = Position.Bottom;
            GridSummaryColumn summaryColumn = new GridSummaryColumn();
            summaryColumn.Name = "Total";
            summaryColumn.MappingName = "ProductID";
            summaryColumn.Format = "{Count}";
            summaryColumn.SummaryType = Syncfusion.Data.SummaryType.CountAggregate;
            summaryRow.SummaryColumns.Add(summaryColumn);
            this.SfGrid.TableSummaryRows.Add(summaryRow);

            this.AddSubview (SfGrid);
		}



		void GridAutoGenerateColumns (object sender, AutoGeneratingColumnEventArgs e)
		{
            if (UserInterfaceIdiomIsPhone)
                e.Column.MaximumWidth = 150;
            else
                e.Column.MaximumWidth = 300;
            if (e.Column.MappingName == "ProductID") {
				e.Column.HeaderText = "Product ID";
			} else if (e.Column.MappingName == "UserRating") {
				e.Column.HeaderText = "User Rating";
			} else if (e.Column.MappingName == "ProductModel") {
				e.Column.HeaderText = "Product Model";
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "Price") {
				e.Column.Format = "C";
				e.Column.CultureInfo = new CultureInfo ("en-US");
			} else if (e.Column.MappingName == "ShippingDays") {
				e.Column.HeaderText = "Shipping Days";
			} else if (e.Column.MappingName == "ProductType") {
				e.Column.HeaderText = "Product Type";
				e.Column.TextAlignment = UITextAlignment.Left;
				e.Column.TextMargin = 15;
			} else if (e.Column.MappingName == "Availability") {
		    	 e.Column.TextMargin = new Thickness(30, 6, 5, 6);
			}
		}

		public override void LayoutSubviews ()
		{
            if(Utility.IsIPad)
            {
                if ((UIDevice.CurrentDevice.Orientation == UIDeviceOrientation.LandscapeLeft)
                    || (UIDevice.CurrentDevice.Orientation == UIDeviceOrientation.LandscapeRight))
                    this.SfGrid.ColumnSizer = ColumnSizer.Star;
                else
                    this.SfGrid.ColumnSizer = ColumnSizer.None;
            }
			this.SfGrid.Frame = new CGRect (0, 0, this.Frame.Width, this.Frame.Height);
			base.LayoutSubviews ();
		}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (SfGrid != null)
                {
                    SfGrid.AutoGeneratingColumn -= GridAutoGenerateColumns;
                    SfGrid.Dispose();
                }
               SfGrid = null;
            }
            base.Dispose(disposing);
            
        }
    }
}

