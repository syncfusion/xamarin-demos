#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "PullToRefreshViewBehavior.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfPullToRefresh
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Core;

    using Syncfusion.ListView.XForms;
    using Syncfusion.SfPullToRefresh.XForms;

    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    /// Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the PullToRefreshViewBehavior samples
    /// </summary>
    public class PullToRefreshViewBehavior : Behavior<SampleView>
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Image imagedata;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Label label2;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Label label3;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private SfListView listView;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private SfPullToRefresh pullToRefresh;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Grid subGrid1;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Grid subGrid2;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private PickerExt transitionType;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private PullToRefreshViewModel viewModel;

        /// <summary>
        /// Used to Update whether Data value
        /// </summary>
        /// <param name="temperature">double parameter named as temperature</param>
        internal void UpdateData(double temperature)
        {
            this.label2.Text = string.Format("{0}°/12°", new object[] { temperature });
            this.label3.Text = this.viewModel.Data.Month;
            this.imagedata.Source = this.viewModel.Data.ImageName;
        }

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="bindAble">Sample View typed parameter named as bindAble</param>
        protected override void OnAttachedTo(SampleView bindAble)
        {
            this.viewModel = new PullToRefreshViewModel();
            bindAble.BindingContext = this.viewModel;
            this.pullToRefresh = bindAble.FindByName<SfPullToRefresh>("pullToRefresh");
            this.subGrid1 = bindAble.FindByName<Grid>("SubGrid1");
            this.subGrid2 = bindAble.FindByName<Grid>("SubGrid2");
            this.listView = bindAble.FindByName<SfListView>("listView");
            this.transitionType = bindAble.FindByName<PickerExt>("transitionType");
            this.label2 = bindAble.FindByName<Label>("label2");
            this.label3 = bindAble.FindByName<Label>("label3");
            this.imagedata = bindAble.FindByName<Image>("imagedata");

            this.subGrid1.BindingContext = this.viewModel.Data;
            this.pullToRefresh.PullingThreshold = 100;
            this.listView.ItemsSource = this.viewModel.SelectedData;
            if (Device.RuntimePlatform == Device.iOS)
            {
                this.pullToRefresh.SizeChanged += this.Pull_SizeChanged;
            }

            this.pullToRefresh.Refreshing += this.PullToRefresh_Refreshing;
            this.pullToRefresh.Refreshed += this.PullToRefresh_Refreshed;
            this.listView.SelectionChanging += this.ListView_SelectionChanging;
            this.transitionType.Items.Add("Push");
            this.transitionType.Items.Add("SlideOnTop");
            this.transitionType.SelectedIndex = 1;
            this.transitionType.SelectedIndexChanged += this.OnSelectionChanged;
            base.OnAttachedTo(bindAble);
        }

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="bindAble">SampleView typed parameter named as bindAble</param>
        protected override void OnDetachingFrom(SampleView bindAble)
        {
            this.pullToRefresh.SizeChanged -= this.Pull_SizeChanged;
            this.pullToRefresh.Refreshing -= this.PullToRefresh_Refreshing;
            this.pullToRefresh.Refreshed -= this.PullToRefresh_Refreshed;
            this.listView.SelectionChanging -= this.ListView_SelectionChanging;
            this.transitionType.SelectedIndexChanged -= this.OnSelectionChanged;
            this.pullToRefresh = null;
            this.viewModel = null;
            this.listView = null;
            this.subGrid1 = null;
            this.subGrid2 = null;
            this.transitionType = null;
            this.label2 = null;
            this.label3 = null;
            this.imagedata = null;
            base.OnDetachingFrom(bindAble);
        }

        /// <summary>
        /// Fired when selected index gets changed
        /// </summary>
        /// <param name="sender">OnSelectionChanged event sender</param>
        /// <param name="e">OnSelectionChanged event args e</param>
        private void OnSelectionChanged(object sender, EventArgs e)
        {
            if (this.transitionType.SelectedIndex == 0)
            {
                this.pullToRefresh.TransitionMode = TransitionType.Push;
            }
            else
            {
                this.pullToRefresh.TransitionMode = TransitionType.SlideOnTop;
            }
        }

        /// <summary>
        /// Triggers while pull to refresh View completes refreshing.
        /// </summary>
        /// <param name="sender">PullToRefresh_Refreshed event sender</param>
        /// <param name="e">PullToRefresh_Refreshed event args e</param>
        private void PullToRefresh_Refreshed(object sender, EventArgs e)
        {
            this.pullToRefresh.IsRefreshing = false;
        }

        /// <summary>
        /// Triggers while pull size gets changed
        /// </summary>
        /// <param name="sender">Pull_SizeChanged sender</param>
        /// <param name="e">Pull_SizeChanged event args e</param>
        private void Pull_SizeChanged(object sender, EventArgs e)
        {
            this.pullToRefresh.WidthRequest = this.pullToRefresh.Bounds.Width;
            this.pullToRefresh.HeightRequest = this.pullToRefresh.Bounds.Height + 10;
        }

        /// <summary>
        /// Triggers while pull to refresh view was refreshing
        /// </summary>
        /// <param name="sender">PullToRefresh_Refreshing sender</param>
        /// <param name="args">PullToRefresh_Refreshing event args e</param>
        private void PullToRefresh_Refreshing(object sender, EventArgs args)
        {
            this.pullToRefresh.IsRefreshing = true;
            Device.StartTimer(
                new TimeSpan(
                    0,
                    0,
                    0,
                    1,
                    500),
                () =>
                {
                    Random rnd = new Random();
                    int i = rnd.Next(20, 40);
                    this.UpdateData(i);
                    this.pullToRefresh.IsRefreshing = false;
                    return false;
                });
        }

        /// <summary>
        /// Triggers while  list view selection was changing
        /// </summary>
        /// <param name="sender">ListView_SelectionChanging event sender</param>
        /// <param name="e">ListView_SelectionChanging event args e</param>
        private void ListView_SelectionChanging(object sender, ItemSelectionChangingEventArgs e)
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
    }
}