#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "PullToRefreshTemplate.xaml.cs" company="Syncfusion.com">
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
    using SampleBrowser.Core;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// A sampleView that contains the template while refreshing <see cref="SfPullToRefresh"/>.
    /// </summary>
    public partial class PullToRefreshTemplate : SampleView
    {
        /// <summary>
        /// Initializes a new instance of the PullToRefreshTemplate class.
        /// </summary>
        public PullToRefreshTemplate()
        {
            this.InitializeComponent();
        }
    }
}