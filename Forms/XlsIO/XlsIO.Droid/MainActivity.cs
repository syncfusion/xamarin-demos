#region Copyright Syncfusion Inc. 2001-2018.
// <copyright file="MainActivity.cs" company=" Syncfusion Inc.">
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
// </copyright>
#endregion

namespace SampleBrowser.XlsIO.Droid
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Android.App;
    using Android.Content.PM;
    using Android.OS;
    using Android.Runtime;
    using Android.Views;
    using Android.Widget;

    /// <summary>
    /// This class used to load the application for android.
    /// </summary>
    [Activity(Label = "SampleBrowser XlsIO", MainLauncher = false, Icon = "@drawable/AppIcon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed.")]

        /// <summary>
        /// override the method OnCreate with <see cref="Bundle"/> class.
        /// </summary>
        /// <param name="bundle">The value from <see cref="Bundle"/> class.</param>
        protected override void OnCreate(Bundle bundle)
        {            
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            Core.Droid.CoreSampleBrowser.Init(Resources, this);
            LoadApplication(new App());
        }
    }
}