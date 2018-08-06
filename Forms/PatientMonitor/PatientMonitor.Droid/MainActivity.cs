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
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;


namespace PatientMonitor.Droid
{
    [Activity(Label = " ", Icon = "@android:color/transparent", Theme = "@style/AppTheme",

ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity :
        global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            ActionBar.Subtitle = "Dr. Jacob John M.D.";
            RequestedOrientation = ScreenOrientation.Portrait;
            LoadApplication(new App());
           

        }
    }
}

