#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser.SfDataGrid
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class FilteringBehaviors : Behavior<SampleView>
    {
        private Syncfusion.SfDataGrid.XForms.SfDataGrid dataGrid;
        private FilteringViewModel viewModel;
        private PickerExt optionsList;
        private PickerExt columnsList;
        private SearchBarExt filterText;

        protected override void OnAttachedTo(SampleView bindable)
        {
            viewModel = new FilteringViewModel();       
            dataGrid = bindable.FindByName<Syncfusion.SfDataGrid.XForms.SfDataGrid>("dataGrid");
            bindable.BindingContext = viewModel;
            optionsList = bindable.FindByName<PickerExt>("OptionsList");
            columnsList = bindable.FindByName<PickerExt>("ColumnsList");
            filterText = bindable.FindByName<SearchBarExt>("filterText");
            optionsList.Items.Add("Equals");
            optionsList.Items.Add("NotEquals");
            optionsList.Items.Add("Contains");
            columnsList.Items.Add("All Columns");
            columnsList.Items.Add("CustomerID");
            columnsList.Items.Add("BookID");
            columnsList.Items.Add("FirstName");
            columnsList.Items.Add("LastName");
            columnsList.Items.Add("BookName");
            columnsList.SelectedIndex = 0;
            viewModel.filtertextchanged = OnFilterChanged;
            filterText.TextChanged += OnFilterTextChanged;
            columnsList.SelectedIndexChanged += OnColumnsSelectionChanged;
            optionsList.SelectedIndexChanged += OnFilterOptionsChanged;
            base.OnAttachedTo(bindable);
        }
        public void OnColumnsSelectionChanged(object sender, EventArgs e)
        {
            Picker newPicker = (Picker)sender;
            viewModel.SelectedColumn = newPicker.Items[newPicker.SelectedIndex];
            if (viewModel.SelectedColumn == "All Columns")
            {
                viewModel.SelectedCondition = "Contains";
                optionsList.IsVisible = false;
                this.OnFilterChanged();
            }
            else
            {
                optionsList.IsVisible = true;
                foreach (var prop in typeof(BookInfo).GetProperties())
                {
                    if (prop.Name == viewModel.SelectedColumn)
                    {
                        if (prop.PropertyType == typeof(string))
                        {
                            optionsList.Items.Clear();
                            optionsList.Items.Add("Contains");
                            optionsList.Items.Add("Equals");
                            optionsList.Items.Add("NotEquals");
                            if (this.viewModel.SelectedCondition == "Equals")
                                optionsList.SelectedIndex = 1;
                            else if (this.viewModel.SelectedCondition == "NotEquals")
                                optionsList.SelectedIndex = 2;
                            else
                                optionsList.SelectedIndex = 0;
                        }
                        else
                        {
                            optionsList.Items.Clear();
                            optionsList.Items.Add("Equals");
                            optionsList.Items.Add("NotEquals");
                            if (this.viewModel.SelectedCondition == "Equals")
                                optionsList.SelectedIndex = 0;
                            else
                                optionsList.SelectedIndex = 1;
                        }
                    }
                }
            }
        }

        public void OnFilterOptionsChanged(object sender, EventArgs e)
        {
            Picker newPicker = (Picker)sender;
            if (newPicker.SelectedIndex >= 0)
            {
                viewModel.SelectedCondition = newPicker.Items[newPicker.SelectedIndex];
                if (filterText.Text != null)
                    this.OnFilterChanged();
            }
        }

        public void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue == null)
                viewModel.FilterText = "";
            else
                viewModel.FilterText = e.NewTextValue;
        }

        public void OnFilterChanged()
        {
            if (dataGrid.View != null)
            {
                dataGrid.View.Filter = viewModel.FilerRecords;
                dataGrid.View.RefreshFilter();
            }
        }
        protected override void OnDetachingFrom(SampleView bindable)
        {
            optionsList.SelectedIndexChanged -= OnFilterOptionsChanged;
            columnsList.SelectedIndexChanged -= OnColumnsSelectionChanged;
            filterText.TextChanged -= OnFilterTextChanged;            
            dataGrid = null;
            optionsList = null;
            columnsList = null;
            filterText = null;
            base.OnDetachingFrom(bindable);
        }

    }
}
