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

using CoreGraphics;
using Foundation;
using UIKit;
using Syncfusion.Data;
using Syncfusion.SfDataGrid;

namespace SampleBrowser
{
    public class CustomSorting : SampleView
    {
        #region Fields

        CustomerViewModel viewModel;
        SfDataGrid sfGrid;

        #endregion

        #region Static Methods

        static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

        #endregion

        #region Constructor

        public CustomSorting()
        {
            sfGrid = new SfDataGrid();
            this.sfGrid.SelectionMode = SelectionMode.Single;
            viewModel = new CustomerViewModel();
            sfGrid.AutoGeneratingColumn += GridAutoGenerateColumns;
            sfGrid.ItemsSource = viewModel.CustomerInformation;
            sfGrid.AllowSorting = true;
            sfGrid.AllowTriStateSorting = true;
            this.sfGrid.HeaderRowHeight = 45;
            this.sfGrid.RowHeight = 45;
            sfGrid.GridStyle.AlternatingRowColor = UIColor.FromRGB(219, 219, 219);
            sfGrid.SortComparers.Add(new SortComparer() { Comparer = new CustomerInfo(), PropertyName = "FirstName" });
            sfGrid.SortColumnDescriptions.Add(new SortColumnDescription() { ColumnName = "FirstName" });
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

        private void GridAutoGenerateColumns(object sender, AutoGeneratingColumnEventArgs e)
        {
            if (e.Column.MappingName == "CustomerID") {
				e.Column.HeaderText = "Customer ID";
                e.Column.TextAlignment = UITextAlignment.Left;
                e.Column.TextMargin = 15;
			}  else if (e.Column.MappingName == "City") {
				e.Column.HeaderText = "City";
                e.Column.TextAlignment = UITextAlignment.Left;
                e.Column.TextMargin = 15;
			} else if (e.Column.MappingName == "Country") {
				e.Column.HeaderText = "Country";
                e.Column.TextAlignment = UITextAlignment.Left;
                e.Column.TextMargin = 15;
			}  else if (e.Column.MappingName == "FirstName") {
				e.Column.HeaderText = "First Name";
                e.Column.TextAlignment = UITextAlignment.Left;
                e.Column.TextMargin = 15;
			} else if (e.Column.MappingName == "LastName") {
				e.Column.HeaderText = "Last Name";
                e.Column.TextAlignment = UITextAlignment.Left;
                e.Column.TextMargin = 15;
			} else if (e.Column.MappingName == "Gender") {
                e.Column.TextAlignment = UITextAlignment.Left;
                e.Column.TextMargin = 15;
			}
        }

        #endregion
    }
}