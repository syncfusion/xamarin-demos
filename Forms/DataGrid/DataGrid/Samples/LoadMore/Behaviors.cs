#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
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
using Syncfusion.SfDataGrid.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfDataGrid
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class LoadMoreBehaviors : Behavior<Syncfusion.SfDataGrid.XForms.SfDataGrid>
    {
        private Syncfusion.SfDataGrid.XForms.SfDataGrid dataGrid;
        private LoadMoreViewModel viewModel;

        protected override void OnAttachedTo(Syncfusion.SfDataGrid.XForms.SfDataGrid bindable)
        {
            dataGrid = bindable;
            viewModel = new LoadMoreViewModel();
            dataGrid.BindingContext = viewModel;
            dataGrid.ItemsSource = viewModel.OrdersInfo;
            InitializeLoadMoreCommand();
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Syncfusion.SfDataGrid.XForms.SfDataGrid bindable)
        {
            dataGrid = null;
            base.OnDetachingFrom(bindable);
        }
        private void InitializeLoadMoreCommand()
        {
            dataGrid.LoadMoreView.Opacity = 100;
            dataGrid.LoadMoreCommand = new Command(ExecuteLoadMoreCommand);
        }

        private async void ExecuteLoadMoreCommand()
        {
            try
            {
                dataGrid.IsBusy = true;
                int rowIndex = viewModel.OrdersInfo.Count;
                await Task.Delay(new TimeSpan(0, 0, 5));
                viewModel.LoadMoreItems();
                dataGrid.IsBusy = false;
                dataGrid.ScrollToRowIndex(rowIndex);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }
    }
}
