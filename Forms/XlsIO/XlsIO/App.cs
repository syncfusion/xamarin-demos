#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using SampleBrowser.Core;

using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.XlsIO
{
	[Preserve(AllMembers = true)]
    public class App : Application
    {
        public App()
        {
            var page = SampleBrowser.Core.SampleBrowser.GetMainPage("XlsIO", "SampleBrowser.XlsIO");
            MainPage = page;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1630:DocumentationTextMustContainWhitespace", Justification = "Reviewed. Suppression is OK here.")]
    public enum Platforms
    {
        /// <summary>
        /// Universal Windows Platform
        /// </summary>
        UWP,

        /// <summary>
        /// Windows 81 
        /// </summary>
        Windows81,

        /// <summary>
        /// Android
        /// </summary>
        Android,

        /// <summary>
        /// IOS
        /// </summary>
        iOS,

        /// <summary>
        /// Windows Phone 8
        /// </summary>
        WindowsPhone8,

        /// <summary>
        /// Windows Phone 81
        /// </summary>
        WindowsPhone81,
    }
}
