#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfDataGrid.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser.SfDataGrid
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class SelectionBehaviors:Behavior<SampleView>
    {
        private Syncfusion.SfDataGrid.XForms.SfDataGrid dataGrid;
        private PickerExt selectionPicker;
        private SelectionViewModel viewModel;

        protected override void OnAttachedTo(SampleView bindable)
        {
            viewModel = new SelectionViewModel();
            bindable.BindingContext = viewModel;
            selectionPicker = bindable.FindByName<PickerExt>("SelectionPicker");
            selectionPicker.Items.Add("None");
            selectionPicker.Items.Add("Single");
            selectionPicker.Items.Add("Single Deselect");
            selectionPicker.Items.Add("Multiple");
            dataGrid = bindable.FindByName<Syncfusion.SfDataGrid.XForms.SfDataGrid>("dataGrid");
            dataGrid.ItemsSource = viewModel.OrdersInfo;
            dataGrid.AllowKeyboardNavigation = true;
            dataGrid.SelectionController = new SelectionController(dataGrid);
            selectionPicker.SelectedIndexChanged += OnSelectionChanged;
            dataGrid.SelectedItems.Add(viewModel.OrdersInfo[1]);
            dataGrid.SelectedItems.Add(viewModel.OrdersInfo[3]);
            dataGrid.SelectedItems.Add(viewModel.OrdersInfo[7]);
            base.OnAttachedTo(bindable);
        }
        public void OnSelectionChanged(object sender, EventArgs e)
        {
            (dataGrid.SelectionController as SelectionController).CanApplyMultipleSelectionColor = false;
            if (selectionPicker.SelectedIndex == 0)
            {
                dataGrid.SelectionMode = SelectionMode.None;
            }
            else if (selectionPicker.SelectedIndex == 1)
            {
                dataGrid.SelectionMode = SelectionMode.Single;
            }
            else if (selectionPicker.SelectedIndex == 2)
            {
                dataGrid.SelectionMode = SelectionMode.SingleDeselect;
            }
            else if (selectionPicker.SelectedIndex == 3)
            {
                dataGrid.SelectionMode = SelectionMode.Multiple;
               
            }
        }
        protected override void OnDetachingFrom(SampleView bindable)
        {
            selectionPicker.SelectedIndexChanged -= OnSelectionChanged;
            dataGrid = null;
            selectionPicker = null;
            base.OnDetachingFrom(bindable);
        }
    }
}
