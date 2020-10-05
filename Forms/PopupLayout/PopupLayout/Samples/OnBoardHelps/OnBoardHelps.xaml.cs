#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "OnBoardHelps.xaml.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfPopupLayout
{
    using Core;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;
    using Xamarin.Forms.Xaml;

    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]

    /// <summary>
    /// A sampleView that contains the OnBoardHelps sample.
    /// </summary>
    public partial class OnBoardHelps : SampleView
    {
        /// <summary>
        /// Initializes a new instance of the OnBoardHelps class.
        /// </summary>
        public OnBoardHelps()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// You can override this method while View was disappear from window
        /// </summary>
        public override void OnDisappearing()
        {
            base.OnDisappearing();

            if (Device.RuntimePlatform == Device.UWP)
            {
                this.popupLayout.Dismiss();
            }
            else
            {
                this.popupLayout.Dispose();
            }
        }
    }
}