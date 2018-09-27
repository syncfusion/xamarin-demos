#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Syncfusion.ListView.XForms;
using System.Reflection;

namespace SampleBrowser.SfPullToRefresh
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class ListViewPullToRefreshViewModel
    {

        #region Fields

        internal BlogsInfoRepository source;
        private Command<object> readMoreCommand;
        private Command<object> twitterCommand;
        private Command<object> linkedInCommand;
        private Command<object> facebookCommand;
        private Command<object> googlePlusCommand;

        #endregion

        #region Constructor

        public ListViewPullToRefreshViewModel()
        {
            source = new BlogsInfoRepository();
            BlogsInfo =  source.GenerateSource();
            readMoreCommand = new Command<object>(NavigateToReadMoreContent);
            twitterCommand = new Command<object>(NavigateTwitterLink);
            linkedInCommand = new Command<object>(NavigateLinkedInLink);
            facebookCommand = new Command<object>(NavigateFacebookLink);
            googlePlusCommand = new Command<object>(NavigateGooglePlusLink);
        }

        #endregion

        #region Properties

        public ObservableCollection<ListViewBlogsInfo> BlogsInfo
        {
            get;
            set;
        }

        public Command<object> ReadMoreCommand
        {
            get { return readMoreCommand; }
            set { readMoreCommand = value; }
        }

        public Command<object> TwitterCommand
        {
            get { return twitterCommand; }
            set { twitterCommand = value; }
        }

        public Command<object> LinkedInCommand
        {
            get { return linkedInCommand; }
            set { linkedInCommand = value; }
        }

        public Command<object> FacebookCommand
        {
            get { return facebookCommand; }
            set { facebookCommand = value; }
        }

        public Command<object> GooglePlusCommand
        {
            get { return googlePlusCommand; }
            set { googlePlusCommand = value; }
        }

        internal INavigation Navigation
        {
            get;
            set;
        }

        #endregion

        #region Private Methods

        private void NavigateToReadMoreContent(object obj)
        {
            var readMoreContentPage = new ReadMoreContentPage();
            readMoreContentPage.BindingContext = obj;
            Navigation.PushAsync(readMoreContentPage);
        }

        private void NavigateTwitterLink(object obj)
        {
            var title = (obj as ListViewBlogsInfo).BlogTitle;
            var firstPart = "https://twitter.com/intent/tweet?status=";
            var lastPart = "+%7C+Syncfusion+Blog+%3A+http%3A%2F%2Fbit.ly%2FQ2iGwU+%23syncfusionblog&url=http%3A%2F%2Fbit.ly%2FQ2iGwU";
            Device.OpenUri(new Uri(firstPart + title.Replace(" ", "+") + lastPart));
        }

        private void NavigateLinkedInLink(object obj)
        {
            var title = (obj as ListViewBlogsInfo).BlogTitle;
            var firstPart = "http://www.linkedin.com/shareArticle?mini=true&url=http%3A%2F%2Fwww.syncfusion.com/blogs/.UARWGQDuyus.linkedin&title=";
            var lastPart = "+%7C+Syncfusion+Blog+%3A+http%3A%2F%2Fwww.syncfusion.com/blogs/+%23syncfusionblog&ro=false&summary=&source=";
            Device.OpenUri(new Uri(firstPart + title.Replace(" ", "+") + lastPart));
        }

        private void NavigateFacebookLink(object obj)
        {
            var title = (obj as ListViewBlogsInfo).BlogTitle;
            var firstPart = "https://www.facebook.com/sharer/sharer.php?u=http://www.syncfusion.com/blogs//blogs/post/";
            var lastPart = ".aspx";
            title = title.ToLower();
            title = title.Replace(":", "");
            title = title.Replace(" + ", " ");
            title = title.Replace(" - ", " ");
            title = title.Replace("&", " and ");
            title = title.Replace("#", "");
            title = title.Replace(",", "");
            title = title.Replace("\"", "");
            title = title.Replace("?", "");
            Device.OpenUri(new Uri(firstPart + title.Replace(" ", "-") + lastPart));
        }

        private void NavigateGooglePlusLink(object obj)
        {
            var title = (obj as ListViewBlogsInfo).BlogTitle;
            var firstPart = "https://plus.google.com/share?url=http%3A%2F%2Fwww.syncfusion.com/blogs/%23.UARa30_n4sY.google_plusone_share&t=";
            var lastPart = "+%7C+Syncfusion+Blog+%3A+http%3A%2F%2Fwww.syncfusion.com/blogs/+%23syncfusionblog";
            Device.OpenUri(new Uri(firstPart + title.Replace(" ", "+") + lastPart));
        }

        #endregion
    }
}
