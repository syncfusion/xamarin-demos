#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Android.Content;

namespace SampleBrowser.SfRadialMenu.Droid
{
	[Activity(Label = "SampleBrowser SfRadialMenu", MainLauncher = false, Icon = "@drawable/AppIcon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		double statusBarHeight, navbarheight;
		protected override void OnCreate(Bundle bundle)
		{
			int navigationResID = Resources.GetIdentifier("navigation_bar_height", "dimen", "android");
			if (navigationResID > 0)
			{
				navbarheight = (Resources.GetDimensionPixelSize(navigationResID) / Resources.DisplayMetrics.Density);
			}

			int statusResID = Resources.GetIdentifier("status_bar_height", "dimen", "android");
			if (statusResID > 0)
			{
				statusBarHeight = (Resources.GetDimensionPixelSize(statusResID) / Resources.DisplayMetrics.Density);
			}
			SetScreenSize((Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density), (Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density));
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);
			SampleBrowser.Core.Droid.CoreSampleBrowser.Init(Resources, null);
			LoadApplication(new App());
		}
		public event EventHandler<ActivityResultEventArgs> ActivityResult;


		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			if (resultCode == Result.Ok)
			{
				if (ActivityResult != null)
					ActivityResult(this, new ActivityResultEventArgs { Intent = data });

			}
		}

		public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
		{
			base.OnConfigurationChanged(newConfig);

			if (newConfig.Orientation == Android.Content.Res.Orientation.Landscape)
			{
				SetScreenSize((Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density), (Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density));
				if (Device.Idiom == TargetIdiom.Phone)
					RequestedOrientation = ScreenOrientation.Portrait;
				else if (Device.Idiom == TargetIdiom.Tablet)
				{
					RequestedOrientation = ScreenOrientation.FullSensor;
				}
			}
			else if (newConfig.Orientation == Android.Content.Res.Orientation.Portrait)
			{
				SetScreenSize((Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density), (Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density));
				if (Device.Idiom == TargetIdiom.Phone)
					RequestedOrientation = ScreenOrientation.Portrait;
				else if (Device.Idiom == TargetIdiom.Tablet)
					RequestedOrientation = ScreenOrientation.FullSensor;
			}

		}

		void SetScreenSize(double width, double height)
		{
			App.StatusBarHeight = statusBarHeight;
			App.NavigationBarHeight = navbarheight;
			App.ScreenWidth = width;
			App.ScreenHeight = height - (statusBarHeight + navbarheight);
			App.Platform = Platforms.Android;
			App.Density = Resources.DisplayMetrics.Density;
		}
	}
	public class ActivityResultEventArgs : EventArgs
	{

		public Intent Intent
		{
			get;
			set;
		}
	}
}


