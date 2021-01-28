#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using CoreGraphics;
using Syncfusion.DataSource;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace SampleBrowser 
{
    public class DataSourceGettingStarted : SampleView
    {
        #region Field

        UITableView tableView;
        DataSource sfDataSource;
        UISearchBar searchbar;
        DataSourceOptionsView option;
        DataSourceGettingStartedViewModel viewModel;

        #endregion

        #region Constructor

        public DataSourceGettingStarted()
        {
            tableView = new UITableView();
            tableView.RowHeight = 100;
            tableView.SeparatorColor = UIColor.Clear;
            tableView.EstimatedRowHeight = 100;
            viewModel = new DataSourceGettingStartedViewModel();
            viewModel.SetRowstoGenerate(100);
            sfDataSource = new DataSource();
            sfDataSource.Source = viewModel.BookInfo;
            sfDataSource.DisplayItems.CollectionChanged += DisplayItems_CollectionChanged;
            sfDataSource.LiveDataUpdateMode = Syncfusion.DataSource.LiveDataUpdateMode.AllowDataShaping;
            sfDataSource.SortDescriptors.Add(new SortDescriptor()
            {
                Direction = Syncfusion.DataSource.ListSortDirection.Descending,
                PropertyName = "BookID",
            });

            tableView.Source = new TableViewSource(sfDataSource);

            searchbar = new UISearchBar ();
			searchbar.OnEditingStarted += HandleOnEditingStarted;
			searchbar.TextChanged += HandleTextChanged;
			searchbar.CancelButtonClicked += HandleCancelButtonClicked;
			searchbar.EnablesReturnKeyAutomatically = false;
			searchbar.Placeholder = "Search in All Columns";
			viewModel.filtertextchanged = OnFilterChanged;
			option = new DataSourceOptionsView (viewModel,searchbar,this);
            this.OptionView = option;

            this.AddSubview(searchbar);
            this.AddSubview(this.tableView);
        }

        private void DisplayItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            tableView.ReloadData();
        }

        #endregion

        internal void OnFilterChanged()
        {
            if (this.sfDataSource != null)
            {
                sfDataSource.Filter = viewModel.FilerRecords;
                sfDataSource.RefreshFilter();
            }
        }

        void HandleCancelButtonClicked(object sender, EventArgs e)
        {
            searchbar.ResignFirstResponder();
            searchbar.SetShowsCancelButton(false, true);
        }

        void HandleTextChanged(object sender, UISearchBarTextChangedEventArgs e)
        {
            viewModel.FilterText = e.SearchText;
        }

        void HandleOnEditingStarted(object sender, EventArgs e)
        {
            searchbar.SetShowsCancelButton(true, true);
        }

        public override void LayoutSubviews()
        {
            searchbar.Frame = (new CGRect(0, 0, this.Frame.Width, 40));
            if (UIDevice.CurrentDevice.CheckSystemVersion(7, 1))
            {
                searchbar.SizeToFit();
                this.tableView.Frame = new CGRect(0, searchbar.Bounds.Height, this.Frame.Width, this.Frame.Height - 44);

            }
            else
            {
                searchbar.SizeToFit();
                this.tableView.Frame = new CGRect(0, searchbar.Bounds.Height, this.Frame.Width, this.Frame.Height - 44);
            }
            base.LayoutSubviews();
        }
    }
}
