#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "PullToRefreshTemplateBehaviour.cs" company="Syncfusion.com">
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
    using System.Threading.Tasks;
    using SampleBrowser.Core;
    using Syncfusion.SfDataGrid.XForms;
    using Syncfusion.SfPullToRefresh.XForms;
    using Syncfusion.XForms.Border;
    using Syncfusion.XForms.ProgressBar;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    /// Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the <see cref="PullToRefreshTemplateBehaviour"/> samples
    /// </summary>
    public class PullToRefreshTemplateBehaviour : Behavior<SampleView>
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private SfDataGrid dataGrid;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private SfPullToRefresh pullToRefresh;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private PickerExt transitionType;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private DataGridPullToRefreshViewModel viewModel;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private SfCircularProgressBar progressbar;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private SfBorder border;

        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="bindAble">SampleView type parameter named as bindAble</param>
        protected override void OnAttachedTo(SampleView bindAble)
        {
            this.viewModel = new DataGridPullToRefreshViewModel();
            this.progressbar = new SfCircularProgressBar();
            this.border = new SfBorder();

            this.border.BorderColor = Color.LightGray;
            this.border.BackgroundColor = Color.White;
            this.border.CornerRadius = 35;
            this.border.Content = this.progressbar;
            this.border.BorderWidth = 0.2;

            this.progressbar.SegmentCount = 10;
            this.progressbar.IndicatorInnerRadius = 0.5;
            this.progressbar.IndicatorOuterRadius = 0.7;
            this.progressbar.ShowProgressValue = true;
            this.progressbar.GapWidth = 0.5;           
            this.progressbar.WidthRequest = 70;
            this.progressbar.HeightRequest = 55;
            this.progressbar.IndeterminateAnimationDuration = 750;
            
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
            this.pullToRefresh.Pulling += this.PullToRefresh_Pulling;

            var pullingTemplate = new DataTemplate(() =>
             {
                 return new ViewCell { View = this.border };
             });

            this.pullToRefresh.PullingViewTemplate = pullingTemplate;
            this.pullToRefresh.RefreshingViewTemplate = pullingTemplate;

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
        /// Fired when pulling occurs. 
        /// </summary>
        /// <param name="sender">PullToRefresh_Refreshing event sender</param>
        /// <param name="e">PullToRefresh_Refreshing event args</param>
        private void PullToRefresh_Pulling(object sender, PullingEventArgs e)
        {
            this.progressbar.TrackInnerRadius = 0.8;
            this.progressbar.TrackOuterRadius = 0.1;
            this.progressbar.IsIndeterminate = false;            
            this.progressbar.ProgressColor = Color.FromRgb(0, 124, 238);            
            this.progressbar.TrackColor = Color.White;  
            
            var absoluteProgress = Convert.ToInt32(Math.Abs(e.Progress));
            this.progressbar.Progress = absoluteProgress;
            this.progressbar.SetProgress(absoluteProgress, 1, Easing.CubicInOut);
        }

        /// <summary>
        /// Fired when pullToRefresh View is refreshed
        /// </summary>
        /// <param name="sender">PullToRefresh_Refreshing event sender</param>
        /// <param name="e">PullToRefresh_Refreshing event args</param>
        private async void PullToRefresh_Refreshing(object sender, EventArgs e)
        {
            this.pullToRefresh.IsRefreshing = true;
            await this.AnimateRefresh();
            this.viewModel.ItemsSourceRefresh();
            this.pullToRefresh.IsRefreshing = false;
        }

        /// <summary>
        /// Increments the <see cref="SfProgressBar"/> progress value
        /// </summary>
        /// <returns>Returns the <see cref="Task"/>.</returns>
        private async Task AnimateRefresh()
        {
            this.progressbar.Progress = 0;
            this.progressbar.IsIndeterminate = true;

            await Task.Delay(750);
            this.progressbar.ProgressColor = Color.Red;

            await Task.Delay(750);
            this.progressbar.ProgressColor = Color.Green;

            await Task.Delay(750);
            this.progressbar.ProgressColor = Color.Orange;

            await Task.Delay(750);
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
