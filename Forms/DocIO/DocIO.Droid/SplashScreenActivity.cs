#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.App;

namespace SampleBrowser.DocIO.Droid
{
    [Activity(Theme = "@style/Theme.Splash",
              MainLauncher = true,
                 NoHistory = true, Icon = "@drawable/AppIcon")]
    public class SplashScreenActivity : SampleBrowser.Core.Android.SplashScreenActivity
    {
            protected override Type GetMainActivityType()
            {
                    return typeof(MainActivity);
            }
    }
}
