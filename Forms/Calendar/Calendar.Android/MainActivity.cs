#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SampleBrowser.SfCalendar.Droid
{
    /// <summary>
    /// Main Activity
    /// </summary>
    [Activity(Label = "SampleBrowser.SfCalendar", Icon = "@drawable/AppIcon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        /// <summary>
        /// statusBa and navigation bar Height
        /// </summary>
        private double statusBarHeight, navigationBarheight;

        /// <summary>
        /// Initializes a new instance of the <see cref="OnCreate" /> class
        /// </summary>
        /// <param name="bundle">bundle param </param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "SA1126:prefix to indicate the intended method call", Justification = "Not mark member as static")]
        protected override void OnCreate(Bundle bundle)
        {
            int navigationResID = Resources.GetIdentifier("navigation_bar_height", "dimen", "android");
            if (navigationResID > 0)
            {
                this.navigationBarheight = Resources.GetDimensionPixelSize(navigationResID) / Resources.DisplayMetrics.Density;
            }

            int statusResID = Resources.GetIdentifier("status_bar_height", "dimen", "android");
            if (statusResID > 0)
            {
                this.statusBarHeight = Resources.GetDimensionPixelSize(statusResID) / Resources.DisplayMetrics.Density;
            }

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            SampleBrowser.Core.Droid.CoreSampleBrowser.Init(this.Resources, null);
            this.LoadApplication(new App());
        }
    }
}