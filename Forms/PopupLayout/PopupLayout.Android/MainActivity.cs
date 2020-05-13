// ------------------------------------------------------------------------------------
// <copyright file = "MainActivity.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
namespace SampleBrowser.SfPopupLayout.Droid
{
    using System.Diagnostics.CodeAnalysis;

    using Android.App;
    using Android.Content.PM;
    using Android.OS;
    using Syncfusion.XForms.Android.PopupLayout;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    [Activity(Label = "SampleBrowser.SfPopupLayout", Icon = "@drawable/icon", Theme = "@style/MainTheme",
        MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]

    /// <summary>
    /// The MainActivity of the Application
    /// </summary>
    public class MainActivity : FormsAppCompatActivity
    {
        /// <summary>
        /// Called when the activity is starting
        /// </summary>
        /// <param name="bundle">Bundle type parameter named as bundle</param>
        protected override void OnCreate(Bundle bundle)
        {
            FormsAppCompatActivity.TabLayoutResource = Resource.Layout.Tabbar;
            FormsAppCompatActivity.ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            SfPopupLayoutRenderer.Init();
            this.LoadApplication(new App());
        }
    }
}