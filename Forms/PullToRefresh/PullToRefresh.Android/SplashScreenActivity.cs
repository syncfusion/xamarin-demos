#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "SplashScreenActivity.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfPullToRefresh.Droid
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Runtime;
    using Android.Views;
    using Android.Widget;

    [Activity(Theme = "@style/Theme.Splash",
        MainLauncher = true,
        NoHistory = true, Icon = "@drawable/AppIcon")]

    /// <summary>
    /// The initial activity of the application.
    /// </summary>
    public class SplashScreenActivity : SampleBrowser.Core.Android.SplashScreenActivity
    {
        /// <summary>
        /// Gets the MainActivity Type
        /// </summary>
        /// <returns>returns type of MainActivity</returns>
        protected override Type GetMainActivityType()
        {
            return typeof(MainActivity);
        }
    }
}