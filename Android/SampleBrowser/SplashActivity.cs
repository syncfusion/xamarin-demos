#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Threading;
using Android.App;
using Android.Content.PM;
using Android.OS;

namespace SampleBrowser
{
    [Activity(Theme = "@style/Theme.Splash", MainLauncher = true, Icon = "@drawable/icon",
        ScreenOrientation = ScreenOrientation.Portrait, NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Thread.Sleep(100);
            StartActivity(typeof(MainActivity));
        }
    }
}