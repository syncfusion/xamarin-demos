#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "PullToRefreshBehavior.cs" company="Syncfusion.com">
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
    using Syncfusion.SfPullToRefresh.XForms;
   
    using Xamarin.Forms;

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]

    /// <summary>
    ///  Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    ///  Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the  PullToRefresh samples
    /// </summary>
    public class PullToRefreshBehavior : Behavior<SampleView>
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Syncfusion.SfPullToRefresh.XForms.SfPullToRefresh pullToRefresh;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Syncfusion.SfDataGrid.XForms.SfDataGrid datagrid;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private PickerExt transitionType;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private DataBindingViewModel viewModel;

        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="bindAble">SampleView type of parameter bindAble</param>
        protected override void OnAttachedTo(SampleView bindAble)
        {
            this.viewModel = new DataBindingViewModel();
            bindAble.BindingContext = this.viewModel;
            this.pullToRefresh = bindAble.FindByName<Syncfusion.SfPullToRefresh.XForms.SfPullToRefresh>("pullToRefresh");
            this.datagrid = bindAble.FindByName<Syncfusion.SfDataGrid.XForms.SfDataGrid>("dataGrid");
            this.datagrid.ItemsSource = this.viewModel.OrdersInfo;
            this.transitionType = bindAble.FindByName<PickerExt>("transitionType");
            this.datagrid.ItemsSource = this.viewModel.OrdersInfo;
            this.transitionType.Items.Add("SlideOnTop");
            this.transitionType.Items.Add("Push");
            this.transitionType.SelectedIndex = 0;
            this.transitionType.SelectedIndexChanged += this.OnSelectionChanged;
            this.pullToRefresh.Refreshing += this.PullToRefresh_Refreshing;

            if (Device.RuntimePlatform == Device.UWP)
            {
                this.pullToRefresh.ProgressBackgroundColor = Color.FromHex("0065ff");
                this.pullToRefresh.ProgressStrokeColor = Color.FromHex("#ffffff");
            }

            base.OnAttachedTo(bindAble);
        }

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="bindAble">bindAble Object type of bindAble</param>
        protected override void OnDetachingFrom(BindableObject bindAble)
        {
            this.transitionType.SelectedIndexChanged -= this.OnSelectionChanged;
            this.pullToRefresh.Refreshing -= this.PullToRefresh_Refreshing;
            this.pullToRefresh = null;
            this.datagrid = null;
            this.viewModel = null;
            base.OnDetachingFrom(bindAble);
        }

        /// <summary>
        /// Triggers while PullToRefresh View was refreshing
        /// </summary>
        /// <param name="sender">PullToRefresh_Refreshing event sender</param>
        /// <param name="e">PullToRefresh_Refreshing event args e</param>
        private async void PullToRefresh_Refreshing(object sender, EventArgs e)
        {
            this.pullToRefresh.IsRefreshing = true;
            await Task.Delay(1200);
            this.viewModel.ItemsSourceRefresh();
            this.pullToRefresh.IsRefreshing = false;
        }

        /// <summary>
        /// Triggers while selection of records was changed
        /// </summary>
        /// <param name="sender">OnSelectionChanged sender</param>
        /// <param name="e">OnSelectionChanged event args e</param>
        private void OnSelectionChanged(object sender, EventArgs e)
        {
            if (Device.RuntimePlatform == Device.UWP)
            {
                this.pullToRefresh.ProgressBackgroundColor = Color.FromHex("0065ff");
                this.pullToRefresh.ProgressStrokeColor = Color.FromHex("#ffffff");
            }

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
