#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "MainActivity.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfDataGrid.Droid
{
    using Android.App;
    using Android.Content.PM;
    using Android.OS;
    using SampleBrowser.Core.Droid;

    [Activity(Label = "SampleBrowser.SfDataGrid", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    
    /// <summary>
    /// The MainActivity of the Application
    /// </summary>
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        /// <summary>
        /// Called when the activity is starting
        /// </summary>
        /// <param name="bundle">On Create method parameter as bundle type bundle</param>
        protected override void OnCreate(Bundle bundle)
        {
            Xamarin.Forms.Platform.Android.FormsAppCompatActivity.TabLayoutResource = Resource.Layout.Tabbar;
            Xamarin.Forms.Platform.Android.FormsAppCompatActivity.ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            //// Pass the activity and Resources to core android project

            SampleBrowser.Core.Droid.CoreSampleBrowser.Init(this.Resources, this);
            this.LoadApplication(new App());
        }
    }
}