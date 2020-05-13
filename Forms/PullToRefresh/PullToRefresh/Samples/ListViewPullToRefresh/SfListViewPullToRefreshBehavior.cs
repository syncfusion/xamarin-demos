#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "SfListViewPullToRefreshBehavior.cs" company="Syncfusion.com">
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
    using System.Linq;
    using System.Threading.Tasks;

    using Core;

    using Syncfusion.ListView.XForms;
    using Syncfusion.SfPullToRefresh.XForms;

    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    #region PullToRefreshBehavior

    /// <summary>
    /// Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    /// Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the ListViewPullToRefreshBehavior samples
    /// </summary>
    public class SfListViewPullToRefreshBehavior : Behavior<SampleView>
    {
        #region Fields

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private ListViewPullToRefreshViewModel pulltoRefreshViewModel;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private SfListView listView;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private SfPullToRefresh pullToRefresh;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private PickerExt picker;

        #endregion

        #region Overrides

        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="bindAble">SampleView type of parameter named as bindAble</param>
        protected override void OnAttachedTo(SampleView bindAble)
        {
            this.listView = bindAble.FindByName<SfListView>("listView");
            this.pulltoRefreshViewModel = new ListViewPullToRefreshViewModel();
            this.pulltoRefreshViewModel.Navigation = bindAble.Navigation;
            this.listView.BindingContext = this.pulltoRefreshViewModel;
            this.listView.ItemsSource = this.pulltoRefreshViewModel.BlogsInfo;

            this.pullToRefresh = bindAble.FindByName<SfPullToRefresh>("pullToRefresh");
            this.pullToRefresh.Refreshing += this.PullToRefresh_Refreshing;

            this.picker = bindAble.FindByName<PickerExt>("transitionTypePicker");
            this.picker.Items.Add("SlideOnTop");
            this.picker.Items.Add("Push");
            this.picker.SelectedIndex = 1;
            this.picker.SelectedIndexChanged += this.Picker_SelectedIndexChanged;
            base.OnAttachedTo(bindAble);
        }

        /// <summary>
        /// Fired when picker selected index is changed.
        /// </summary>
        /// <param name="sender">Picker_SelectedIndexChanged event sender</param>
        /// <param name="e">Picker_SelectedIndexChanged event args e</param>
        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.picker.SelectedIndex == 0)
            {
                this.pullToRefresh.RefreshContentThreshold = 0;
                this.pullToRefresh.TransitionMode = TransitionType.SlideOnTop;
            }
            else
            {
                this.pullToRefresh.RefreshContentThreshold = 50;
                this.pullToRefresh.TransitionMode = TransitionType.Push;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Triggers while PullToRefresh View was refreshing
        /// </summary>
        /// <param name="sender">PullToRefresh_Refreshing event sender</param>
        /// <param name="args">PullToRefresh_Refreshing event args e</param>
        private async void PullToRefresh_Refreshing(object sender, EventArgs args)
        {
            this.pullToRefresh.IsRefreshing = true;
            await Task.Delay(1200);
            int blogsTitleCount = this.pulltoRefreshViewModel.Source.BlogsTitle.Count() - 1;

            if (this.pulltoRefreshViewModel.BlogsInfo.Count - 1 == blogsTitleCount)
            {
                this.pullToRefresh.IsRefreshing = false;
                return;
            }

            int blogsCategoryCount = this.pulltoRefreshViewModel.Source.BlogsCategory.Count() - 1;
            int blogsAuthorCount = this.pulltoRefreshViewModel.Source.BlogsAuthers.Count() - 1;
            int blogsReadMoreCount = this.pulltoRefreshViewModel.Source.BlogsReadMoreInfo.Count() - 1;

            for (int i = 0; i < 3; i++)
            {
                int blogsCount = this.pulltoRefreshViewModel.BlogsInfo.Count;
                ListViewBlogsInfo item = new ListViewBlogsInfo
                {
                    BlogTitle = this.pulltoRefreshViewModel.Source.BlogsTitle[blogsTitleCount - blogsCount],
                    BlogAuthor = this.pulltoRefreshViewModel.Source.BlogsAuthers[blogsAuthorCount - blogsCount],
                    BlogCategory =
                        this.pulltoRefreshViewModel.Source.BlogsCategory[blogsCategoryCount - blogsCount],
                    ReadMoreContent =
                        this.pulltoRefreshViewModel.Source.BlogsReadMoreInfo[blogsReadMoreCount - blogsCount],

                    BlogAuthorIcon = new FontImageSource
                    {
                        Glyph = "\ue72a",
                        FontFamily = Device.RuntimePlatform == Device.iOS ? "Sync FontIcons" : Device.RuntimePlatform == Device.Android ? "Sync FontIcons.ttf#" : "Sync FontIcons.ttf#Sync FontIcons",
                        Color = Color.FromRgb(51, 173, 225),
                    },
                    BlogCategoryIcon = new FontImageSource
                    {
                        Glyph = "\ue738",
                        FontFamily = Device.RuntimePlatform == Device.iOS ? "Sync FontIcons" : Device.RuntimePlatform == Device.Android ? "Sync FontIcons.ttf#" : "Sync FontIcons.ttf#Sync FontIcons",
                        Color = Color.FromRgb(51, 173, 225),
                    },
                    BlogFacebookIcon = "FacebookLine.png",
                    BlogTwitterIcon = "TwitterLine.png",
                    BlogGooglePlusIcon = "GooglePlusLine.png",

                    BlogLinkedInIcon = "LinkedInLine.png",
                };
                this.pulltoRefreshViewModel.BlogsInfo.Insert(0, item);
            }

            this.pullToRefresh.IsRefreshing = false;
        }

        #endregion
    }

    #endregion
}