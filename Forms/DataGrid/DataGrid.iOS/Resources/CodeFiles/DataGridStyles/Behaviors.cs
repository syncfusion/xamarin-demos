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
    public class DataGridStylesBehaviors : Behavior<SampleView>
    {
        private Syncfusion.SfDataGrid.XForms.SfDataGrid dataGrid;
        private StylesViewModel viewModel;
        private PickerExt stylePicker;
        protected override void OnAttachedTo(SampleView bindable)
        {
            dataGrid = bindable.FindByName<Syncfusion.SfDataGrid.XForms.SfDataGrid>("dataGrid");
            viewModel = new StylesViewModel();
            bindable.BindingContext = viewModel;
            dataGrid.ItemsSource = viewModel.OrdersInfo;
            dataGrid.GridViewCreated += GridViewCreated;
            stylePicker = bindable.FindByName<PickerExt>("StylePicker");
            stylePicker.Items.Add("Dark");
            stylePicker.Items.Add("Blue");
            stylePicker.Items.Add("Red");
            stylePicker.Items.Add("Green");
            stylePicker.Items.Add("Purple");
            stylePicker.SelectedIndex = 4;
            stylePicker.SelectedIndexChanged += OnStyleChanged;
            base.OnAttachedTo(bindable);
        }
        protected override void OnDetachingFrom(SampleView bindable)
        {
            dataGrid.GridViewCreated -= GridViewCreated;
            stylePicker.SelectedIndexChanged -= OnStyleChanged;
            dataGrid = null;
            stylePicker = null;
            base.OnDetachingFrom(bindable);
        }
        public void OnStyleChanged(object sender, EventArgs e)
        {
            if (stylePicker.SelectedIndex == 0)
            {
                dataGrid.GridStyle = new Dark();
            }
            else if (stylePicker.SelectedIndex == 1)
            {
                dataGrid.GridStyle = new Blue();
            }
            else if (stylePicker.SelectedIndex == 2)
            {
                dataGrid.GridStyle = new Red();
            }
            else if (stylePicker.SelectedIndex == 3)
            {
                dataGrid.GridStyle = new Green();
            }
            else if (stylePicker.SelectedIndex == 4)
            {
                dataGrid.GridStyle = new Purple();
            }
        }
        public void GridViewCreated(object sender, GridViewCreatedEventArgs e)
        {
            dataGrid.SelectedItem = viewModel.OrdersInfo[3];
        }
    }
}
