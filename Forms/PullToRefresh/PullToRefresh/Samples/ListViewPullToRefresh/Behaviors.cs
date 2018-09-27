#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.DataSource;
using Syncfusion.ListView.XForms;
using Syncfusion.SfPullToRefresh.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SampleBrowser.Core;
using System.Reflection;

namespace SampleBrowser.SfPullToRefresh
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    #region PullToRefreshBehavior

    public class SfListViewPullToRefreshBehavior : Behavior<SampleView>
    {
        #region Fields

        private ListViewPullToRefreshViewModel pulltoRefreshViewModel;
        private Syncfusion.ListView.XForms.SfListView ListView;
        private Syncfusion.SfPullToRefresh.XForms.SfPullToRefresh pullToRefresh = null;
        private PickerExt picker;

        #endregion

        #region Overrides

        protected override void OnAttachedTo(SampleView bindable)
        {
            ListView = bindable.FindByName<Syncfusion.ListView.XForms.SfListView>("listView");
            pulltoRefreshViewModel = new ListViewPullToRefreshViewModel();
            pulltoRefreshViewModel.Navigation = bindable.Navigation;
            ListView.BindingContext = pulltoRefreshViewModel;
            ListView.ItemsSource = pulltoRefreshViewModel.BlogsInfo;

            pullToRefresh = bindable.FindByName<Syncfusion.SfPullToRefresh.XForms.SfPullToRefresh>("pullToRefresh");
            pullToRefresh.Refreshing += PullToRefresh_Refreshing;

            picker = bindable.FindByName<PickerExt>("transitionTypePicker");
            picker.Items.Add("SlideOnTop");
            picker.Items.Add("Push");
            picker.SelectedIndex = 1;
            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
            base.OnAttachedTo(bindable);
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (picker.SelectedIndex == 0)
            {
                pullToRefresh.RefreshContentThreshold = 0;
                pullToRefresh.TransitionMode = TransitionType.SlideOnTop;
            }
            else
            {
                pullToRefresh.RefreshContentThreshold = 50;
                pullToRefresh.TransitionMode = TransitionType.Push;
            }
        }

        #endregion

        #region Private Methods
        private async void PullToRefresh_Refreshing(object sender, EventArgs args)
        {
            pullToRefresh.IsRefreshing = true;
            await Task.Delay(1200);
            var blogsTitleCount = pulltoRefreshViewModel.source.BlogsTitle.Count() - 1;

            if ((pulltoRefreshViewModel.BlogsInfo.Count - 1) == blogsTitleCount)
            {
                pullToRefresh.IsRefreshing = false;
                return;
            }

            var blogsCategoryCount = pulltoRefreshViewModel.source.BlogsCategory.Count() - 1;
            var blogsAuthorCount = pulltoRefreshViewModel.source.BlogsAuthers.Count() - 1;
            var blogsReadMoreCount = pulltoRefreshViewModel.source.BlogsReadMoreInfo.Count() - 1;

            for (int i = 0; i < 3; i++)
            {
                var blogsCount = pulltoRefreshViewModel.BlogsInfo.Count;
                var item = new ListViewBlogsInfo()
                {
                    BlogTitle = pulltoRefreshViewModel.source.BlogsTitle[blogsTitleCount- blogsCount],
                    BlogAuthor = pulltoRefreshViewModel.source.BlogsAuthers[blogsAuthorCount - blogsCount],
                    BlogCategory = pulltoRefreshViewModel.source.BlogsCategory[blogsCategoryCount - blogsCount],
                    ReadMoreContent = pulltoRefreshViewModel.source.BlogsReadMoreInfo[blogsReadMoreCount - blogsCount],
#if COMMONSB
                    BlogAuthorIcon = ImageSource.FromResource("SampleBrowser.Icons.BlogAuthor.png", this.GetType().Assembly),
                    BlogCategoryIcon = ImageSource.FromResource("SampleBrowser.Icons.BlogCategory.png", this.GetType().Assembly),
                    BlogFacebookIcon = ImageSource.FromResource("SampleBrowser.Icons.Blog_Facebook.png", this.GetType().Assembly),
                    BlogTwitterIcon = ImageSource.FromResource("SampleBrowser.Icons.Blog_Twitter.png", this.GetType().Assembly),
                    BlogGooglePlusIcon = ImageSource.FromResource("SampleBrowser.Icons.Blog_Google Plus.png", this.GetType().Assembly),
                    BlogLinkedInIcon = ImageSource.FromResource("SampleBrowser.Icons.Blog_LinkedIn.png", this.GetType().Assembly),
#else
                    BlogAuthorIcon = ImageSource.FromResource("SampleBrowser.SfPullToRefresh.Icons.BlogAuthor.png", this.GetType().Assembly),
                    BlogCategoryIcon = ImageSource.FromResource("SampleBrowser.SfPullToRefresh.Icons.BlogCategory.png", this.GetType().Assembly),
                    BlogFacebookIcon = ImageSource.FromResource("SampleBrowser.SfPullToRefresh.Icons.Blog_Facebook.png", this.GetType().Assembly),
                    BlogTwitterIcon = ImageSource.FromResource("SampleBrowser.SfPullToRefresh.Icons.Blog_Twitter.png", this.GetType().Assembly),
                    BlogGooglePlusIcon = ImageSource.FromResource("SampleBrowser.SfPullToRefresh.Icons.Blog_Google Plus.png", this.GetType().Assembly),
                    BlogLinkedInIcon = ImageSource.FromResource("SampleBrowser.SfPullToRefresh.Icons.Blog_LinkedIn.png", this.GetType().Assembly),
#endif
                };
                pulltoRefreshViewModel.BlogsInfo.Insert(0, item);
            }
            pullToRefresh.IsRefreshing = false;
        }

#endregion
    }

#endregion
}