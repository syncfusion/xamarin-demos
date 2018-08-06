#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Syncfusion.DataSource;
using Android.Graphics;

namespace SampleBrowser
{
    public class DataSourceSorting:SamplePage
    {
        #region Fields

        DataSource sfDataSource;
        ContatsViewModel viewModel;
        ListView listView;
        Spinner groupDropdown;
        GridLayout gridlayout;
        TextView groupTextView;
        SearchView filterText;

        #endregion

        #region Override

        public override Android.Views.View GetSampleContent(Android.Content.Context context)
        {
            LinearLayout linear = new LinearLayout(context) {  Orientation = Orientation.Vertical}; 
            listView = new ListView(context);
            listView.FastScrollEnabled = true;
            viewModel = new ContatsViewModel();
            sfDataSource = new DataSource();
            sfDataSource.Source = viewModel.ContactsList;
            sfDataSource.LiveDataUpdateMode = LiveDataUpdateMode.AllowDataShaping;
            sfDataSource.SortDescriptors.Add(new SortDescriptor("ContactName",Syncfusion.DataSource.ListSortDirection.Ascending));
            listView.Adapter = new ContactsAdapter(sfDataSource, context);
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

        public override View GetPropertyWindowLayout(Context context)
        {
            gridlayout = new GridLayout(context);
            var layoutParam = new GridLayout.LayoutParams();
            gridlayout.SetPadding(20, 20, 20, 20);
            gridlayout.RowCount = 2;
            gridlayout.ColumnCount = 2;
            groupTextView = new TextView(context);
            groupTextView.Text = "Sort by";
            groupDropdown = new Spinner(context,SpinnerMode.Dialog);
            var groupAdapter = new ArrayAdapter(context, Android.Resource.Layout.SimpleSpinnerItem);
            groupAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            groupAdapter.Add("Ascending");
            groupAdapter.Add("Descending");

            groupDropdown.Adapter = groupAdapter;
            groupDropdown.ItemSelected += groupDropdown_ItemSelected;

            gridlayout.AddView(groupTextView ,LinearLayout.LayoutParams.WrapContent, (int)(30 * context.Resources.DisplayMetrics.Density));
            gridlayout.AddView(groupDropdown);
            return gridlayout;
        }

        void groupDropdown_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var spinner = sender as Spinner;
            var direction = spinner.GetItemAtPosition(e.Position).ToString();
            sfDataSource.BeginInit();

            sfDataSource.SortDescriptors.Clear();
            sfDataSource.SortDescriptors.Add(new SortDescriptor()
            {
                PropertyName = "ContactName",
                Direction = direction == "Ascending" ? Syncfusion.DataSource.ListSortDirection.Ascending : Syncfusion.DataSource.ListSortDirection.Descending
            });
            sfDataSource.EndInit();
            (this.listView.Adapter as ContactsAdapter).NotifyDataSetChanged();
        }

        private void OnFilterTextChanged(object sender, SearchView.QueryTextChangeEventArgs e)
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
            if (contacts.ContactName.ToLower().Contains(filterText.Query.ToLower())
                || contacts.ContactNumber.ToLower().Contains(filterText.Query.ToLower()))
                return true;
            else
                return false;
        }

        #endregion
    }
}