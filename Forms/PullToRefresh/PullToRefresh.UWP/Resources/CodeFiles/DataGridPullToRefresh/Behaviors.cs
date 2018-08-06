#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfDataGrid.XForms;
using Syncfusion.SfPullToRefresh.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser.SfPullToRefresh
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class DataGridPullToRefreshBehaviors : Behavior<SampleView>
    {
        private Syncfusion.SfPullToRefresh.XForms.SfPullToRefresh pullToRefresh;
        private DataGridPullToRefreshViewModel viewModel;
        private Syncfusion.SfDataGrid.XForms.SfDataGrid dataGrid;
        private PickerExt transitionType;

        protected override void OnAttachedTo(SampleView bindable)
        {
            viewModel = new DataGridPullToRefreshViewModel();
            bindable.BindingContext = viewModel;
            pullToRefresh = bindable.FindByName<Syncfusion.SfPullToRefresh.XForms.SfPullToRefresh>("pullToRefresh");
            dataGrid = bindable.FindByName< Syncfusion.SfDataGrid.XForms.SfDataGrid> ("dataGrid");
            transitionType = bindable.FindByName<PickerExt>("transitionType");
            dataGrid.ItemsSource = viewModel.OrdersInfo;
            transitionType.Items.Add("SlideOnTop");
            transitionType.Items.Add("Push");
            transitionType.SelectedIndex = 0;
            transitionType.SelectedIndexChanged += OnSelectionChanged;
            pullToRefresh.Refreshing += PullToRefresh_Refreshing;
            
            base.OnAttachedTo(bindable);
        }
        private async void PullToRefresh_Refreshing(object sender, EventArgs e)
        {
            pullToRefresh.IsRefreshing = true;
            await Task.Delay(1200);
            this.viewModel.ItemsSourceRefresh();
            pullToRefresh.IsRefreshing = false;
        }
        private void OnSelectionChanged(object sender, EventArgs e)
        {
            if (transitionType.SelectedIndex == 0)
            {
                pullToRefresh.TransitionMode = TransitionType.SlideOnTop;
            }
            else
            {
                pullToRefresh.TransitionMode = TransitionType.Push;
            }
        }
        protected override void OnDetachingFrom(SampleView bindable)
        {
            transitionType.SelectedIndexChanged -= OnSelectionChanged;
            pullToRefresh.Refreshing -= PullToRefresh_Refreshing;
            pullToRefresh = null;
            dataGrid = null;
            transitionType = null;
            base.OnDetachingFrom(bindable);
        }
    }
}
