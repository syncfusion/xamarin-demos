#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

namespace SampleBrowser
{
	using System.Threading;
	using Android.App;
	using Android.Content.PM;
	using Android.OS;

	[Activity(Theme = "@style/Theme.Splash", MainLauncher = true, Icon = "@drawable/icon",ScreenOrientation = ScreenOrientation.Portrait, NoHistory = true)]
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

