// ------------------------------------------------------------------------------------
// <copyright file = "SplashScreenActivity.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
namespace SampleBrowser.SfPopupLayout.Droid
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using Android.App;

    [Activity(Theme = "@style/Theme.Splash",
        MainLauncher = true,
        NoHistory = true, Icon = "@drawable/AppIcon")]

    /// <summary>
    /// The initial activity of the application.
    /// </summary>
    public class SplashScreenActivity : Core.Android.SplashScreenActivity
    {
        /// <summary>
        /// Gets the type of MainActivity 
        /// </summary>
        /// <returns>returns type of MainActivity</returns>
        protected override Type GetMainActivityType()
        {
            return typeof(MainActivity);
        }
    }
}