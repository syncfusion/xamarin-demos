#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "DataGridPullToRefreshBehaviors.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
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
    using System.Threading.Tasks;

    using Core;

    using Syncfusion.SfDataGrid.XForms;
    using Syncfusion.SfPullToRefresh.XForms;

    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    /// Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the DataGridPullToRefreshBehaviors samples
    /// </summary>
    public class DataGridPullToRefreshBehaviors : Behavior<SampleView>
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private SfDataGrid dataGrid;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private SfPullToRefresh pullToRefresh;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private PickerExt transitionType;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private DataGridPullToRefreshViewModel viewModel;

        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="bindAble">SampleView type parameter named as bindAble</param>
        protected override void OnAttachedTo(SampleView bindAble)
        {
            this.viewModel = new DataGridPullToRefreshViewModel();
            bindAble.BindingContext = this.viewModel;
            this.pullToRefresh = bindAble.FindByName<SfPullToRefresh>("pullToRefresh");
            this.dataGrid = bindAble.FindByName<SfDataGrid>("dataGrid");
            this.transitionType = bindAble.FindByName<PickerExt>("transitionType");
            this.dataGrid.ItemsSource = this.viewModel.OrdersInfo;
            this.transitionType.Items.Add("SlideOnTop");
            this.transitionType.Items.Add("Push");
            this.transitionType.SelectedIndex = 0;
            this.transitionType.SelectedIndexChanged += this.OnSelectionChanged;
            this.pullToRefresh.Refreshing += this.PullToRefresh_Refreshing;

            base.OnAttachedTo(bindAble);
        }

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="bindAble">SampleView type parameter named as bindAble</param>
        protected override void OnDetachingFrom(SampleView bindAble)
        {
            this.transitionType.SelectedIndexChanged -= this.OnSelectionChanged;
            this.pullToRefresh.Refreshing -= this.PullToRefresh_Refreshing;
            this.pullToRefresh = null;
            this.dataGrid = null;
            this.transitionType = null;
            base.OnDetachingFrom(bindAble);
        }

        /// <summary>
        /// Fired when pullToRefresh View is refreshed
        /// </summary>
        /// <param name="sender">PullToRefresh_Refreshing event sender</param>
        /// <param name="e">PullToRefresh_Refreshing event args</param>
        private async void PullToRefresh_Refreshing(object sender, EventArgs e)
        {
            this.pullToRefresh.IsRefreshing = true;
            await Task.Delay(1200);
            this.viewModel.ItemsSourceRefresh();
            this.pullToRefresh.IsRefreshing = false;
        }

        /// <summary>
        /// Fired when selected index is changed
        /// </summary>
        /// <param name="sender">OnSelectionChanged sender</param>
        /// <param name="e">OnSelectionChanged event args e</param>
        private void OnSelectionChanged(object sender, EventArgs e)
        {
            if (this.transitionType.SelectedIndex == 0)
            {
                this.pullToRefresh.TransitionMode = TransitionType.SlideOnTop;
            }
            else
            {
                this.pullToRefresh.TransitionMode = TransitionType.Push;
            }
        }
    }
}