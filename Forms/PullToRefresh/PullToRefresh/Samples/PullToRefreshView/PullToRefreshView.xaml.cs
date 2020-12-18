#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "PullToRefreshView.xaml.cs" company="Syncfusion.com">
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
    using Core;

    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// A sampleView that contains the PullToRefreshView sample.
    /// </summary>
    public partial class PullToRefreshView : SampleView
    {
        /// <summary>
        /// Initializes a new instance of the PullToRefreshView class.
        /// </summary>
        public PullToRefreshView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// This method is called when the size of the element is set during a layout cycle. This method is called directly 
        /// before the <see cref="Xamarin.Forms.VisualElement.SizeChanged"/> event is emitted.
        /// </summary>
        /// <param name="width">The new width of the element.</param>
        /// <param name="height">The new height of the element.</param>
        protected override void OnSizeAllocated(double width, double height)
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                height -= 100;
            }

            base.OnSizeAllocated(width, height);
        }
    }
}