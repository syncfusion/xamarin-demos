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

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Syncfusion.DataSource;
using System.Reflection;
using Android.Graphics;
using Syncfusion.Data;

namespace SampleBrowser
{
    public class DataSourceGettingStarted : SamplePage, IDisposable
    {
        private DataSource dataSource;
        private DataSourceGettingStartedViewModel viewModel;
        private SearchView filterText;
        private Spinner conditionDropdown;
        private Spinner columnDropdown;
        private ArrayAdapter condtionAdapter;
        private GridLayout gridlayout;
        private TextView conditionTextView;
        private TextView columnTextView;
        private TextView groupTextView;
        private ListView listView;

        public override Android.Views.View GetSampleContent(Android.Content.Context context)
        {
            LinearLayout linear = new LinearLayout(context);
            linear.Orientation = Orientation.Vertical;
            dataSource = new DataSource();
            viewModel = new DataSourceGettingStartedViewModel(context);
            viewModel.SetRowstoGenerate(100);
            listView = new ListView(context);

            dataSource.Source = viewModel.BookInfo;
            dataSource.LiveDataUpdateMode = Syncfusion.DataSource.LiveDataUpdateMode.AllowDataShaping;
            dataSource.SortDescriptors.Add(new SortDescriptor()
            {
                Direction = Syncfusion.DataSource.ListSortDirection.Descending,
                PropertyName = "BookID",
            });

            listView.Adapter = new CustomAdapter(dataSource, context);
            filterText = new SearchView(context);
            filterText.SetIconifiedByDefault(false);
            filterText.SetPadding(0, 0, 0, (int)(10 * context.Resources.DisplayMetrics.Density));
            this.filterText.KeyPress += FilterText_KeyPress;
            filterText.SetQueryHint("Enter the text to filter");
            filterText.QueryTextChange += OnFilterTextChanged;
            viewModel.Filtertextchanged = OnFilterChanged;
            linear.AddView(new LinearLayout(context) { Focusable = true, FocusableInTouchMode = true }, 0, 0);
            linear.AddView(filterText);
            linear.AddView(listView);
            return linear;
        }

        private void FilterText_KeyPress(object sender, View.KeyEventArgs e)
        {
            listView.RemoveAllViews();
        }

        public override View GetPropertyWindowLayout(Android.Content.Context context)
        {
            gridlayout = new GridLayout(context);
            gridlayout.SetPadding(20, 20, 20, 20);
            gridlayout.RowCount = 2;
            gridlayout.ColumnCount = 2;

            conditionTextView = new TextView(context);
            conditionTextView.Text = "Select the condition to filter";
            columnTextView = new TextView(context);
            columnTextView.Text = "Select the column to filter";
            groupTextView = new TextView(context);
            groupTextView.Text = "Group by";
            columnDropdown = new Spinner(context, SpinnerMode.Dialog);

            var columnAdapter = new ArrayAdapter(context, Android.Resource.Layout.SimpleSpinnerItem);
            var properties = typeof(BookDetails).GetProperties();
            columnAdapter.Add("All Columns");
            foreach (var propertyInfo in properties)
            {
                if (propertyInfo.Name != "CustomerImage")
                {
                    columnAdapter.Add(propertyInfo.Name);
                }
            }

            columnAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            columnDropdown.Adapter = columnAdapter;

            conditionDropdown = new Spinner(context, SpinnerMode.Dialog);
            condtionAdapter = new ArrayAdapter(context, Android.Resource.Layout.SimpleSpinnerItem);
            condtionAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            conditionDropdown.Adapter = condtionAdapter;
            columnDropdown.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(OnColumnSelected);
            conditionDropdown.ItemSelected += OnConditionSelected;
            gridlayout.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);

            gridlayout.AddView(columnTextView, LinearLayout.LayoutParams.WrapContent, (int)(30 * context.Resources.DisplayMetrics.Density));
            gridlayout.AddView(columnDropdown);
            gridlayout.AddView(conditionTextView, LinearLayout.LayoutParams.WrapContent, (int)(30 * context.Resources.DisplayMetrics.Density));
            gridlayout.AddView(conditionDropdown);

            return gridlayout;
        }

        private void OnColumnSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner newSpinner = (Spinner)sender;
            viewModel.SelectedColumn = newSpinner.GetItemAtPosition(e.Position).ToString();

            if (viewModel.SelectedColumn == "All Columns")
            {
                conditionDropdown.Visibility = ViewStates.Gone;
                conditionTextView.Visibility = ViewStates.Gone;
            }
            else
            {
                conditionDropdown.Visibility = ViewStates.Visible;
                conditionTextView.Visibility = ViewStates.Visible;
                var prop = typeof(BookDetails).GetProperty(viewModel.SelectedColumn);
                if (prop.Name == viewModel.SelectedColumn)
                {
                    if (prop.PropertyType == typeof(string))
                    {
                        condtionAdapter.Clear();
                        condtionAdapter.Add("Equals");
                        condtionAdapter.Add("Contains");
                        if (this.viewModel.SelectedCondition == "Equals")
                        {
                            this.viewModel.SelectedCondition = "Equals";
                        }
                        else
                        {
                            this.viewModel.SelectedCondition = "Contains";
                        }
                    }
                    else
                    {
                        condtionAdapter.Clear();
                        condtionAdapter.Add("Equals");
                        condtionAdapter.Add("NotEquals");
                        if (this.viewModel.SelectedCondition == "Equals")
                        {
                            this.viewModel.SelectedCondition = "Equals";
                        }
                        else
                        {
                            this.viewModel.SelectedCondition = "NotEquals";
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(filterText.Query))
            {
                this.OnFilterChanged();
            }
        }

        private void OnFilterChanged()
        {
            if (dataSource != null)
            {
                this.dataSource.Filter = viewModel.FilerRecords;
                this.dataSource.RefreshFilter();
            }
        }

        private void OnFilterTextChanged(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            viewModel.FilterText = (sender as SearchView).Query.ToString();
        }

        private void OnConditionSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner newSpinner = (Spinner)sender;
            viewModel.SelectedCondition = newSpinner.GetItemAtPosition(e.Position).ToString();
            if (string.IsNullOrEmpty(filterText.Query))
            {
                this.OnFilterChanged();
            }
        }

        public override void Destroy()
        {
            dataSource.Dispose();
            conditionDropdown = null;
            columnDropdown = null;
            filterText = null;
            columnTextView = null;
            conditionTextView = null;
            dataSource = null;
            viewModel = null;
            condtionAdapter = null;
            gridlayout.RemoveAllViews();
            gridlayout = null;
        }

        public void Dispose()
        {
            if (dataSource != null)
            {
                dataSource.Dispose();
                dataSource = null;
            }

            if (conditionDropdown != null)
            {
                conditionDropdown.Dispose();
                conditionDropdown = null;
            }

            if (columnDropdown != null)
            {
                columnDropdown.Dispose();
                columnDropdown = null;
            }

            if (filterText != null)
            {
                filterText.Dispose();
                filterText = null;
            }

            if (columnTextView != null)
            {
                columnTextView.Dispose();
                columnTextView = null;
            }

            if (conditionTextView != null)
            {
                conditionTextView.Dispose();
                conditionTextView = null;
            }

            if (condtionAdapter != null)
            {
                condtionAdapter.Dispose();
                condtionAdapter = null;
            }

            if (gridlayout != null)
            {
                gridlayout.Dispose();
                gridlayout = null;
            }

            if (columnDropdown != null)
            {
                columnDropdown.Dispose();
                columnDropdown = null;
            }

            if (groupTextView != null)
            {
                groupTextView.Dispose();
                groupTextView = null;
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