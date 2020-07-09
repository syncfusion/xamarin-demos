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
using Syncfusion.DataSource;
using Android.Widget;
using Android.Views;
using Android.Graphics;

namespace SampleBrowser
{
    public class DataSourceGrouping : SamplePage, IDisposable
    {
        #region Fields

        private DataSource dataSource;
        private ContatsViewModel viewModel;
        private ListView listView;
        private SearchView filterText;

        #endregion

        #region Override

        public override Android.Views.View GetSampleContent(Android.Content.Context context)
        {
            LinearLayout linear = new LinearLayout(context) { Orientation = Orientation.Vertical };
            listView = new ListView(context);
            viewModel = new ContatsViewModel();
            dataSource = new DataSource();
            dataSource.Source = viewModel.ContactsList;
            dataSource.LiveDataUpdateMode = LiveDataUpdateMode.AllowDataShaping;
            listView.Adapter = new ContactsAdapter(dataSource, context);
            dataSource.SortDescriptors.Add(new SortDescriptor("ContactName"));
            dataSource.GroupDescriptors.Add(new GroupDescriptor()
            {
                PropertyName = "ContactName",
                KeySelector = (object obj1) =>
                {
                    var item = obj1 as Contacts;
                    return item.ContactName[0].ToString();
                }
            });
            filterText = new SearchView(context);
            filterText.SetIconifiedByDefault(false);
            filterText.SetPadding(0, 0, 0, (int)(10 * context.Resources.DisplayMetrics.Density));
            filterText.SetQueryHint("Search contact");
            filterText.QueryTextChange += OnFilterTextChanged;
            linear.AddView(new LinearLayout(context) { Focusable = true, FocusableInTouchMode = true }, 0, 0);
            linear.AddView(filterText);
            linear.AddView(listView);
            return linear;
        }

        private void OnFilterTextChanged(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            if (dataSource != null)
            {
                this.dataSource.Filter = FilterContacts;
                this.dataSource.RefreshFilter();
            }
        }

        private bool FilterContacts(object obj)
        {
            var contacts = obj as Contacts;
            if (contacts.ContactName.ToLower().Contains(filterText.Query.ToLower())
                || contacts.ContactNumber.ToLower().Contains(filterText.Query.ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        public void Dispose()
        {
            if (dataSource != null)
            {
                dataSource.Dispose();
                dataSource = null;
            }

            if (listView != null)
            {
                listView.Dispose();
                listView = null;
            }

            if (filterText != null)
            {
                filterText.Dispose();
                filterText = null;
            }
        }
    }
}