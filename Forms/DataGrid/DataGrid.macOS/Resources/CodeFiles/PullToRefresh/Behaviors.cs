#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfPullToRefresh.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser.SfDataGrid
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class PullToRefreshBehavior : Behavior<SampleView>
    {
        private Syncfusion.SfPullToRefresh.XForms.SfPullToRefresh pullToRefresh;
        private Syncfusion.SfDataGrid.XForms.SfDataGrid datagrid;
        private PickerExt transitionType;
        private GettingStartedViewModel viewModel;

        protected override void OnAttachedTo(SampleView bindable)
        {
            viewModel = new GettingStartedViewModel();
            bindable.BindingContext = viewModel;
            pullToRefresh = bindable.FindByName<Syncfusion.SfPullToRefresh.XForms.SfPullToRefresh>("pullToRefresh");
            datagrid = bindable.FindByName<Syncfusion.SfDataGrid.XForms.SfDataGrid>("dataGrid");
            datagrid.ItemsSource = viewModel.OrdersInfo;
            transitionType = bindable.FindByName<PickerExt>("transitionType");
            datagrid.ItemsSource = viewModel.OrdersInfo;
            transitionType.Items.Add("SlideOnTop");
            transitionType.Items.Add("Push");
            transitionType.SelectedIndex = 0;
            transitionType.SelectedIndexChanged += OnSelectionChanged;
            pullToRefresh.Refreshing += PullToRefresh_Refreshing;

            if(Device.RuntimePlatform == Device.UWP)
            {
                pullToRefresh.ProgressBackgroundColor = Color.FromHex("0065ff");
                pullToRefresh.ProgressStrokeColor = Color.FromHex("#ffffff");
            }

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
            if (Device.RuntimePlatform == Device.UWP)
            {
                pullToRefresh.ProgressBackgroundColor = Color.FromHex("0065ff");
                pullToRefresh.ProgressStrokeColor = Color.FromHex("#ffffff");
            }

            if (transitionType.SelectedIndex == 0)
            {
                pullToRefresh.TransitionMode = TransitionType.SlideOnTop;
            }
            else
            {
                pullToRefresh.TransitionMode = TransitionType.Push;
            }
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            transitionType.SelectedIndexChanged -= OnSelectionChanged;
            pullToRefresh.Refreshing -= PullToRefresh_Refreshing;
            pullToRefresh = null;
            datagrid = null;
            viewModel = null;
            base.OnDetachingFrom(bindable);
        }
    }
}
