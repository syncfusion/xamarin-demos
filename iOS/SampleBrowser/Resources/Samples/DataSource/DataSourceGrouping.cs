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
    public class DataSourceGrouping : SampleView
    {
        #region Fields

        UITableView tableView;
        ContatsViewModel viewModel;
        DataSource sfDataSource;
        UISearchBar searchbar;

        #endregion

        #region Static Methods

        static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

        #endregion

        #region Constructor

        public DataSourceGrouping()
        {
            tableView = new UITableView();
            tableView.AllowsSelection = false;
            tableView.SeparatorColor = UIColor.Clear;
            tableView.RowHeight = 70;
            tableView.EstimatedRowHeight = 70;
            viewModel = new ContatsViewModel();
            sfDataSource = new DataSource();
            sfDataSource.Source = viewModel.ContactsList;
            sfDataSource.LiveDataUpdateMode = LiveDataUpdateMode.AllowDataShaping;
            sfDataSource.DisplayItems.CollectionChanged += DisplayItems_CollectionChanged;
            sfDataSource.SortDescriptors.Add(new SortDescriptor("ContactName"));
            sfDataSource.GroupDescriptors.Add(new GroupDescriptor()
            {
                PropertyName = "ContactName",
                KeySelector = (object obj1) =>
                {
                    var item = (obj1 as Contacts);
                    return item.ContactName[0].ToString();
                }
            });
            searchbar = new UISearchBar();
            searchbar.OnEditingStarted += HandleOnEditingStarted;
            searchbar.TextChanged += HandleTextChanged;
            searchbar.CancelButtonClicked += HandleCancelButtonClicked;
            searchbar.EnablesReturnKeyAutomatically = false;
            searchbar.Placeholder = "Search Contact";
            tableView.Source = new TableViewSource(sfDataSource);

            this.AddSubview(searchbar);
            this.AddSubview (tableView);
        }

        #endregion

        #region Private Methods

        private void DisplayItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            tableView.ReloadData();
        }
        void HandleCancelButtonClicked(object sender, EventArgs e)
        {
            searchbar.ResignFirstResponder();
            searchbar.SetShowsCancelButton(false, true);
        }

        void HandleTextChanged(object sender, UISearchBarTextChangedEventArgs e)
        {
            if (sfDataSource != null)
            {
                this.sfDataSource.Filter = FilterContacts;
                this.sfDataSource.RefreshFilter();
            }
        }

        void HandleOnEditingStarted(object sender, EventArgs e)
        {
            searchbar.SetShowsCancelButton(true, true);
        }

        private bool FilterContacts(object obj)
        {
            var contacts = obj as Contacts;
            if (searchbar.Text == null || contacts.ContactName.ToLower().Contains(searchbar.Text.ToLower())
                || contacts.ContactNumber.ToLower().Contains(searchbar.Text.ToLower()))
                return true;
            else
                return false;
        }

        #endregion

        #region Override Methods

        public override void LayoutSubviews ()
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

        #endregion
    }
}
