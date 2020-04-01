#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "FilteringBehaviors.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfDataGrid
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SampleBrowser.Core;
    using Syncfusion.Data.Extensions;
 
    using Xamarin.Forms;

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]

    /// <summary>
    ///  Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    ///  Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the Filtering samples
    /// </summary>
    public class FilteringBehaviors : Behavior<SampleView>
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Syncfusion.SfDataGrid.XForms.SfDataGrid dataGrid;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private FilteringViewModel viewModel;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private PickerExt optionsList;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private PickerExt columnsList;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private SearchBarExt filterText;

        /// <summary>
        /// Triggers while columns selection was changed
        /// </summary>
        /// <param name="sender">OnColumnsSelectionChanged event sender</param>
        /// <param name="e">OnColumnsSelectionChanged event args</param>
        public void OnColumnsSelectionChanged(object sender, EventArgs e)
        {
            Picker newPicker = (Picker)sender;
            this.viewModel.SelectedColumn = newPicker.Items[newPicker.SelectedIndex];
            if (this.viewModel.SelectedColumn == "All Columns")
            {
                this.viewModel.SelectedCondition = "Contains";
                this.optionsList.IsVisible = false;
                this.OnFilterChanged();
            }
            else
            {
                this.optionsList.IsVisible = true;
                foreach (var prop in typeof(BookInfo).GetProperties())
                {
                    if (prop.Name == this.viewModel.SelectedColumn)
                    {
                        if (prop.PropertyType == typeof(string))
                        {
                            this.optionsList.Items.Clear();
                            this.optionsList.Items.Add("Contains");
                            this.optionsList.Items.Add("Equals");
                            this.optionsList.Items.Add("NotEquals");
                            if (this.viewModel.SelectedCondition == "Equals")
                            {
                                this.optionsList.SelectedIndex = 1;
                            }                               
                            else if (this.viewModel.SelectedCondition == "NotEquals")
                            {
                                this.optionsList.SelectedIndex = 2;
                            }                             
                            else
                            {
                                this.optionsList.SelectedIndex = 0;
                            }                             
                        }
                        else
                        {
                            this.optionsList.Items.Clear();
                            this.optionsList.Items.Add("Equals");
                            this.optionsList.Items.Add("NotEquals");
                            if (this.viewModel.SelectedCondition == "Equals")
                            {
                                this.optionsList.SelectedIndex = 0;
                            }                              
                            else
                            {
                                this.optionsList.SelectedIndex = 1;
                            }                           
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Triggers while filter options are changed. 
        /// </summary>
        /// <param name="sender">OnFilterOptionsChanged event sender</param>
        /// <param name="e">OnFilterOptionsChanged event args e</param>
        public void OnFilterOptionsChanged(object sender, EventArgs e)
        {
            Picker newPicker = (Picker)sender;
            if (newPicker.SelectedIndex >= 0)
            {
                this.viewModel.SelectedCondition = newPicker.Items[newPicker.SelectedIndex];
                if (this.filterText.Text != null)
                {
                    this.OnFilterChanged();
                }
            }
        }

        /// <summary>
        /// Triggers while filter text was changed 
        /// </summary>
        /// <param name="sender">OnFilterTextChanged event sender</param>
        /// <param name="e">OnFilterTextChanged event args e</param>
        public void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue == null)
            {
                this.viewModel.FilterText = string.Empty;
            }           
            else
            {
                this.viewModel.FilterText = e.NewTextValue;
            }              
        }

        /// <summary>
        /// Refreshes the filter.
        /// </summary>
        public void OnFilterChanged()
        {
            if (this.dataGrid.View != null)
            {
                this.dataGrid.View.Filter = this.viewModel.FilerRecords;
                this.dataGrid.View.RefreshFilter();
            }
        }

        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="bindAble">SampleView type of bindAble</param>
        protected override void OnAttachedTo(SampleView bindAble)
        {
            this.viewModel = new FilteringViewModel();
            this.dataGrid = bindAble.FindByName<Syncfusion.SfDataGrid.XForms.SfDataGrid>("dataGrid");
            bindAble.BindingContext = this.viewModel;
            this.optionsList = bindAble.FindByName<PickerExt>("OptionsList");
            this.columnsList = bindAble.FindByName<PickerExt>("ColumnsList");
            this.filterText = bindAble.FindByName<SearchBarExt>("filterText");
            this.optionsList.Items.Add("Equals");
            this.optionsList.Items.Add("NotEquals");
            this.optionsList.Items.Add("Contains");
            this.columnsList.Items.Add("All Columns");
            this.columnsList.Items.Add("CustomerID");
            this.columnsList.Items.Add("BookID");
            this.columnsList.Items.Add("FirstName");
            this.columnsList.Items.Add("LastName");
            this.columnsList.Items.Add("BookName");
            this.columnsList.SelectedIndex = 0;
            this.viewModel.Filtertextchanged = this.OnFilterChanged;
            this.filterText.TextChanged += this.OnFilterTextChanged;
            this.columnsList.SelectedIndexChanged += this.OnColumnsSelectionChanged;
            this.optionsList.SelectedIndexChanged += this.OnFilterOptionsChanged;
            base.OnAttachedTo(bindAble);
        }

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="bindAble">SampleView type of bindAble parameter</param>
        protected override void OnDetachingFrom(SampleView bindAble)
        {
            this.optionsList.SelectedIndexChanged -= this.OnFilterOptionsChanged;
            this.columnsList.SelectedIndexChanged -= this.OnColumnsSelectionChanged;
            this.filterText.TextChanged -= this.OnFilterTextChanged;            
            this.dataGrid = null;
            this.optionsList = null;
            this.columnsList = null;
            this.filterText = null;
            base.OnDetachingFrom(bindAble);
        }
    }
}
