#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "App.xaml.cs" company="Syncfusion.com">
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
    using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

    /// <summary>
    /// Class that represents a cross-platform mobile application
    /// </summary>
    public partial class App : Xamarin.Forms.Application
    {
        /// <summary>
        /// Initializes a new instance of the App class.
        /// </summary>
        public App()
        {
            this.InitializeComponent();

            var page = SampleBrowser.GetMainPage("SfPopupLayout", "SampleBrowser.SfPopupLayout");
            page.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            this.MainPage = page;
        }

        /// <summary>
        /// Handle when your app starts
        /// </summary>
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        /// <summary>
        /// Handle when your app sleeps
        /// </summary>
        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        /// <summary>
        /// Handle when your app resumes
        /// </summary>
        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}