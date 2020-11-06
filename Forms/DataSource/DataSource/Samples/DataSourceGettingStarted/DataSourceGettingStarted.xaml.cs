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
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Reflection;
using Syncfusion.DataSource;
using SampleBrowser.Core;
using Xamarin.Forms.Internals;

namespace SampleBrowser.DataSource
{
    [Preserve(AllMembers = true)]
    public partial class DataSourceGettingStarted : SampleView
    {
        DataSourceGettingStartedViewModel viewModel;
        Syncfusion.DataSource.DataSource sfDataSource;
        public DataSourceGettingStarted()
        {
            InitializeComponent();
            viewModel = new DataSourceGettingStartedViewModel();
            sfDataSource = new Syncfusion.DataSource.DataSource();
            viewModel.DataSource = sfDataSource;
            sfDataSource.Source = viewModel.BookInfo as IEnumerable<BookDetails>;
            sfDataSource.BeginInit();
            viewModel.filtertextchanged = OnFilterChanged;
            sfDataSource.SortDescriptors.Add(new SortDescriptor()
            {
                Direction = ListSortDirection.Descending,
                PropertyName = "BookID",
            });
            sfDataSource.EndInit();
            listView.ItemsSource = sfDataSource.DisplayItems;
            ColumnsList.SelectedIndex = 0;
        }

        #region CallBacks

        void OnColumnsSelectionChanged(object sender, EventArgs e)
        {
            Picker newPicker = (Picker)sender;
            viewModel.SelectedColumn = newPicker.Items[newPicker.SelectedIndex];
            if (viewModel.SelectedColumn == "All Columns")
            {
                viewModel.SelectedCondition = "Contains";
                OptionsList.IsVisible = false;
                this.OnFilterChanged();
            }
            else
            {
                OptionsList.IsVisible = true;
                var prop = typeof(BookDetails).GetRuntimeProperty(viewModel.SelectedColumn);
                if (prop.Name == viewModel.SelectedColumn)
                {
                    if (prop.PropertyType == typeof(string))
                    {
                        OptionsList.Items.Clear();
                        OptionsList.Items.Add("Contains");
                        OptionsList.Items.Add("Equals");
                        OptionsList.Items.Add("NotEquals");
                        if (this.viewModel.SelectedCondition == "Equals")
                            OptionsList.SelectedIndex = 1;
                        else if (this.viewModel.SelectedCondition == "NotEquals")
                            OptionsList.SelectedIndex = 2;
                        else
                            OptionsList.SelectedIndex = 0;
                    }
                    else
                    {
                        OptionsList.Items.Clear();
                        OptionsList.Items.Add("Equals");
                        OptionsList.Items.Add("NotEquals");
                        if (this.viewModel.SelectedCondition == "Equals")
                            OptionsList.SelectedIndex = 0;
                        else
                            OptionsList.SelectedIndex = 1;
                    }
                }
            }
        }

        void OnFilterOptionsChanged(object sender, EventArgs e)
        {
            Picker newPicker = (Picker)sender;
            if (newPicker.SelectedIndex >= 0)
            {
                viewModel.SelectedCondition = newPicker.Items[newPicker.SelectedIndex];
                if (viewModel.FilterText != null)
                    this.OnFilterChanged();
            }
        }

        void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue == null)
                viewModel.FilterText = "";
            else
                viewModel.FilterText = e.NewTextValue;
        }

        void OnFilterChanged()
        {
            if (sfDataSource != null)
            {
                this.sfDataSource.Filter = viewModel.FilerRecords;
                this.sfDataSource.RefreshFilter();
            }
        }

        #endregion
    }
}
