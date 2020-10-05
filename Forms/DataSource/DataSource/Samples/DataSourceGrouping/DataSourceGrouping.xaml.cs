#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Syncfusion.DataSource;
using Syncfusion.DataSource.Extensions;
using SampleBrowser.Core;
using Xamarin.Forms.Internals;

namespace SampleBrowser.DataSource
{
    [Preserve(AllMembers = true)]
    public partial class DataSourceGrouping : SampleView
    {
        ContatsViewModel viewModel;
        Syncfusion.DataSource.DataSource sfDataSource;
        public DataSourceGrouping()
        {
            InitializeComponent();
            viewModel = new ContatsViewModel();
            sfDataSource = new Syncfusion.DataSource.DataSource();
            sfDataSource.Source = viewModel.ContactsList;
            sfDataSource.BeginInit();
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
            sfDataSource.EndInit();
            listView.ItemsSource = sfDataSource.DisplayItems;
        }

        private void ListViewTemplate_BindingContextChanged(object sender, EventArgs e)
        {
            if (Device.RuntimePlatform == Device.UWP)
            {
                var viewCell = sender as ViewCell;
                if (viewCell.BindingContext is GroupResult)
                    viewCell.View = new Header();
            }
        }

        private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            if (sfDataSource != null)
            {
                this.sfDataSource.Filter = FilterContacts;
                this.sfDataSource.RefreshFilter();
            }
        }

        private bool FilterContacts(object obj)
        {
            var contacts = obj as Contacts;
            if (filterText.Text == null || contacts.ContactName.ToLower().Contains(filterText.Text.ToLower())
              || contacts.ContactNumber.ToLower().Contains(filterText.Text.ToLower()))
                return true;
            else
                return false;
        }
    }
}

