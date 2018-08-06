#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace PatientMonitor.Droid
{
    [Activity(Theme = "@style/Theme.Splash", //Indicates the theme to use for this activity
          MainLauncher = true, //Set it as boot activity
          NoHistory = true, Label = "Patient Monitor", Icon = "@drawable/Icon")]
    public class SplashScreenActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            RequestedOrientation = IsTabletDevice(this) ? ScreenOrientation.Landscape : ScreenOrientation.Portrait;

            this.StartActivity(typeof(MainActivity));
        }

        public static bool IsTabletDevice(Context context)
        {
            var dm = context.Resources.DisplayMetrics;
            var screenWidth = dm.WidthPixels / dm.Xdpi;
            var screenHeight = dm.HeightPixels / dm.Ydpi;
            var size = Math.Sqrt(Math.Pow(screenWidth, 2) + Math.Pow(screenHeight, 2));
            return size >= 6;
        }
    }
}