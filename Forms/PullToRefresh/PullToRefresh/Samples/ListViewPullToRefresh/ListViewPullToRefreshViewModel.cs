#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "ListViewPullToRefreshViewModel.cs" company="Syncfusion.com">
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
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// A ViewModel for ListViewPullToRefresh sample.
    /// </summary>
    public class ListViewPullToRefreshViewModel
    {
        #region Fields

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.internal field does not need documentation")]
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Some fields must be public")]
        internal BlogsInfoRepository Source;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the ListViewPullToRefreshViewModel class.
        /// </summary>
        public ListViewPullToRefreshViewModel()
        {
            this.Source = new BlogsInfoRepository();
            this.BlogsInfo = this.Source.GenerateSource();
            this.ReadMoreCommand = new Command<object>(this.NavigateToReadMoreContent);
            this.TwitterCommand = new Command<object>(this.NavigateTwitterLink);
            this.LinkedInCommand = new Command<object>(this.NavigateLinkedInLink);
            this.FacebookCommand = new Command<object>(this.NavigateFacebookLink);
            this.GooglePlusCommand = new Command<object>(this.NavigateGooglePlusLink);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the BlogsInfo type of ObservableCollection and notifies user when collection value gets changed.
        /// </summary>
        public ObservableCollection<ListViewBlogsInfo> BlogsInfo { get; set; }

        /// <summary>
        /// Gets or sets the value of ReadMoreCommand, Defines an System.Windows.Input.ICommand implementation wrapping a generic Action
        /// </summary>
        public Command<object> ReadMoreCommand { get; set; }

        /// <summary>
        /// Gets or sets the value of TwitterCommand Defines an System.Windows.Input.ICommand implementation wrapping a generic Action
        /// </summary>
        public Command<object> TwitterCommand { get; set; }

        /// <summary>
        /// Gets or sets the value of LinkedInCommand Defines an System.Windows.Input.ICommand implementation wrapping a generic Action
        /// </summary>
        public Command<object> LinkedInCommand { get; set; }

        /// <summary>
        /// Gets or sets the value of FacebookCommand, Defines an System.Windows.Input.ICommand implementation wrapping a generic Action
        /// </summary>
        public Command<object> FacebookCommand { get; set; }

        /// <summary>
        /// Gets or sets the value of GooglePlus with Command Defines an System.Windows.Input.ICommand implementation wrapping a generic Action
        /// </summary>
        public Command<object> GooglePlusCommand { get; set; }

        /// <summary>
        /// Gets or sets the value of GooglePlus with Interface abstracting platform-specific navigation
        /// </summary>
        internal INavigation Navigation { get; set; }

        #endregion

        #region Private Methods

        /// <summary>
        /// Used to Navigation of Read More Content
        /// </summary>
        /// <param name="obj">object type parameter named as object</param>
        private void NavigateToReadMoreContent(object obj)
        {
            ReadMoreContentPage readMoreContentPage = new ReadMoreContentPage();
            readMoreContentPage.BindingContext = obj;
            this.Navigation.PushAsync(readMoreContentPage);
        }

        /// <summary>
        /// Used to Navigate to the twitter link
        /// </summary>
        /// <param name="obj">object type parameter named as object</param>
        private void NavigateTwitterLink(object obj)
        {
            string title = (obj as ListViewBlogsInfo).BlogTitle;
            string firstPart = "https://twitter.com/intent/tweet?status=";
            string lastPart =
                "+%7C+Syncfusion+Blog+%3A+http%3A%2F%2Fbit.ly%2FQ2iGwU+%23syncfusionblog&url=http%3A%2F%2Fbit.ly%2FQ2iGwU";
            Device.OpenUri(new Uri(firstPart + title.Replace(" ", "+") + lastPart));
        }

        /// <summary>
        /// Used to Navigate to the Linked in link
        /// </summary>
        /// <param name="obj">object type parameter named as object</param>
        private void NavigateLinkedInLink(object obj)
        {
            string title = (obj as ListViewBlogsInfo).BlogTitle;
            string firstPart =
                "http://www.linkedin.com/shareArticle?mini=true&url=http%3A%2F%2Fwww.syncfusion.com/blogs/.UARWGQDuyus.linkedin&title=";
            string lastPart =
                "+%7C+Syncfusion+Blog+%3A+http%3A%2F%2Fwww.syncfusion.com/blogs/+%23syncfusionblog&ro=false&summary=&source=";
            Device.OpenUri(new Uri(firstPart + title.Replace(" ", "+") + lastPart));
        }

        /// <summary>
        /// Used to Navigate to the Facebook link
        /// </summary>
        /// <param name="obj">object type parameter named as object</param>
        private void NavigateFacebookLink(object obj)
        {
            string title = (obj as ListViewBlogsInfo).BlogTitle;
            string firstPart =
                "https://www.facebook.com/sharer/sharer.php?u=http://www.syncfusion.com/blogs//blogs/post/";
            string lastPart = ".aspx";
            title = title.ToLower();
            title = title.Replace(":", string.Empty);
            title = title.Replace(" + ", string.Empty);
            title = title.Replace(" - ", string.Empty);
            title = title.Replace("&", " and ");
            title = title.Replace("#", string.Empty);
            title = title.Replace(",", string.Empty);
            title = title.Replace("\"", string.Empty);
            title = title.Replace("?", string.Empty);
            Device.OpenUri(new Uri(firstPart + title.Replace(" ", "-") + lastPart));
        }

        /// <summary>
        /// Used to Navigate to the Google plus link
        /// </summary>
        /// <param name="obj">object type parameter named as object</param>
        private void NavigateGooglePlusLink(object obj)
        {
            string title = (obj as ListViewBlogsInfo).BlogTitle;
            string firstPart =
                "https://plus.google.com/share?url=http%3A%2F%2Fwww.syncfusion.com/blogs/%23.UARa30_n4sY.google_plusone_share&t=";
            string lastPart = "+%7C+Syncfusion+Blog+%3A+http%3A%2F%2Fwww.syncfusion.com/blogs/+%23syncfusionblog";
            Device.OpenUri(new Uri(firstPart + title.Replace(" ", "+") + lastPart));
        }

        #endregion
    }
}