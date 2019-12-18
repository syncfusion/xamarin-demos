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
    public class DataSourceSorting : SampleView
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

        public DataSourceSorting()
        {
            tableView = new UITableView();
            tableView.RowHeight = 70;
            tableView.SeparatorColor = UIColor.Clear;
            tableView.EstimatedRowHeight = 70;
            tableView.AllowsSelection = false;
            viewModel = new ContatsViewModel();
            sfDataSource = new DataSource();
            sfDataSource.Source = viewModel.ContactsList;
            sfDataSource.LiveDataUpdateMode = LiveDataUpdateMode.AllowDataShaping;
            sfDataSource.DisplayItems.CollectionChanged += DisplayItems_CollectionChanged;
            sfDataSource.SortDescriptors.Add(new SortDescriptor("ContactName", Syncfusion.DataSource.ListSortDirection.Ascending));
            tableView.Source = new TableViewSource(sfDataSource);

            searchbar = new UISearchBar();
            searchbar.OnEditingStarted += HandleOnEditingStarted;
            searchbar.TextChanged += HandleTextChanged;
            searchbar.CancelButtonClicked += HandleCancelButtonClicked;
            searchbar.EnablesReturnKeyAutomatically = false;
            searchbar.Placeholder = "Search Contact";

            this.OptionView = CreateOptionView();

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

		public UIView CreateOptionView()
		{
			var stacklayout = new StackLayout ();
			var label = new UILabel ();
			label.Text = "Sort Direction";
		    label.TextAlignment = UITextAlignment.Center;
			label.Frame = new CGRect (0, 0, 0, 100);
			var picker = new UIPickerView ();
			picker.Model  = new SortingPickerModel(sfDataSource,tableView);
			stacklayout.AddSubview (label);
			stacklayout.AddSubview (picker);
			return stacklayout;
		}

        public override void LayoutSubviews ()
        {
            searchbar.Frame = (new CGRect(0, 0, this.Frame.Width, 40));
            if (UIDevice.CurrentDevice.CheckSystemVersion(7, 1))
            {
                searchbar.SizeToFit();
                this.tableView.Frame = new CGRect(0, searchbar.Bounds.Height, this.Frame.Width, this.Frame.Height - 44 );

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
