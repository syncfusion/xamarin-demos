#region Copyright Syncfusion Inc. 2001-2018.
// <copyright file="SplashScreenActivity.cs" company=" Syncfusion Inc.">
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
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Runtime;
    using Android.Views;
    using Android.Widget;

    /// <summary>
    /// A splash screen may display start up progress to the user or to indicate branding.
    /// </summary>
    [Activity(Theme = "@style/Theme.Splash",
              MainLauncher = true,
                 NoHistory = true, Icon = "@drawable/AppIcon")]
    public class SplashScreenActivity : SampleBrowser.Core.Android.SplashScreenActivity
    {
        /// <summary>
        /// Override the value of <see cref="Type"/> class.
        /// </summary>
        /// <returns>Return the value of <see cref="MainActivity"/> class.</returns>
        protected override Type GetMainActivityType()
        {
                return typeof(MainActivity);
        }
    }
}
