#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.ListView.XForms;
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
    public class PullToRefreshViewBehavior:Behavior<SampleView>
    {
        private Syncfusion.SfPullToRefresh.XForms.SfPullToRefresh pullToRefresh;
        private PullToRefreshViewModel viewModel;
        private Syncfusion.ListView.XForms.SfListView listView;
        private Grid SubGrid1;
        private Grid SubGrid2;
        private PickerExt transitionType;
        private Label label2;
        private Label label3;
        private Image imagedata;
        protected override void OnAttachedTo(SampleView bindable)
        {
            viewModel = new PullToRefreshViewModel();
            bindable.BindingContext = viewModel;
            pullToRefresh = bindable.FindByName<Syncfusion.SfPullToRefresh.XForms.SfPullToRefresh>("pullToRefresh");
            SubGrid1 = bindable.FindByName<Grid>("SubGrid1");
            SubGrid2 = bindable.FindByName<Grid>("SubGrid2");
            listView = bindable.FindByName<Syncfusion.ListView.XForms.SfListView>("listView");
            transitionType = bindable.FindByName<PickerExt>("transitionType");
            label2 = bindable.FindByName<Label>("label2");
            label3 = bindable.FindByName<Label>("label3");
            imagedata = bindable.FindByName<Image>("imagedata");

            SubGrid1.BindingContext = viewModel.Data;
            pullToRefresh.PullingThreshold = 100;
            listView.ItemsSource = viewModel.SelectedData;
            if (Device.RuntimePlatform == Device.iOS)
            {
                pullToRefresh.SizeChanged += Pull_SizeChanged;
            }
            pullToRefresh.Refreshing += PullToRefresh_Refreshing;
            pullToRefresh.Refreshed += PullToRefresh_Refreshed;
            listView.SelectionChanging += ListView_SelectionChanging;
            transitionType.Items.Add("Push");
            transitionType.Items.Add("SlideOnTop");
            transitionType.SelectedIndex = 1;
            transitionType.SelectedIndexChanged += OnSelectionChanged;
            base.OnAttachedTo(bindable);
        }
        private void Pull_SizeChanged(object sender, EventArgs e)
        {
            pullToRefresh.WidthRequest = pullToRefresh.Bounds.Width;
            pullToRefresh.HeightRequest = pullToRefresh.Bounds.Height + 10;
        }

        private void PullToRefresh_Refreshing(object sender, EventArgs args)
        {
            pullToRefresh.IsRefreshing = true;
            Device.StartTimer(new TimeSpan(0, 0, 0, 1, 500), () =>
            {
                Random rnd = new Random();
                int i = rnd.Next(20, 40);
                this.UpdateData(i);
                pullToRefresh.IsRefreshing = false;
                return false;
            });
        }

        private void ListView_SelectionChanging(object sender, Syncfusion.ListView.XForms.ItemSelectionChangingEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                this.viewModel.Data = e.AddedItems[0] as WeatherData;
                this.UpdateData(this.viewModel.Data.Temperature);
            }
            else if (e.AddedItems.Count == 0)
            {
                e.Cancel = true;
            }
        }

        internal void UpdateData(double temperature)
        {
            label2.Text = string.Format("{0}°/12°", new object[] { temperature });
            label3.Text = this.viewModel.Data.Month;
            imagedata.Source = this.viewModel.Data.ImageName;
        }

        protected override void OnDetachingFrom(SampleView bindable)
        {
            pullToRefresh.SizeChanged -= Pull_SizeChanged;
            pullToRefresh.Refreshing -= PullToRefresh_Refreshing;
            pullToRefresh.Refreshed -= PullToRefresh_Refreshed;
            listView.SelectionChanging -= ListView_SelectionChanging;
            transitionType.SelectedIndexChanged -= OnSelectionChanged;
            pullToRefresh = null;
            viewModel = null;
            listView = null;
            SubGrid1 = null;
            SubGrid2 = null;
            transitionType = null;
            label2 = null;
            label3 = null;
            imagedata = null;
            base.OnDetachingFrom(bindable);
        }

        void OnSelectionChanged(object sender, EventArgs e)
        {
            if (transitionType.SelectedIndex == 0)
            {
                pullToRefresh.TransitionMode = TransitionType.Push;
            }
            else
            {
                pullToRefresh.TransitionMode = TransitionType.SlideOnTop;
            }
        }

        private void PullToRefresh_Refreshed(object sender, EventArgs e)
        {

            pullToRefresh.IsRefreshing = false;
        }
    }
}
