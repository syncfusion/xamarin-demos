#region Copyright Syncfusion Inc. 2001-2022.
// <copyright file="App.cs" company="Syncfusion">
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using SampleBrowser.Core;

using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfCalendar
{
    /// <summary>
    /// Target platforms in XForms
    /// </summary>
    public enum Platforms
    {
        /// <summary>
        /// UWP Platform
        /// </summary>
        UWP,

        /// <summary>
        /// Android Platform
        /// </summary>
        Android,

        /// <summary>
        /// iOS Platform
        /// </summary>
        iOS
    }

    /// <summary>
    /// Rendering App derived from Application
    /// </summary>
    [Preserve(AllMembers = true)]
    public class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App" /> class
        /// </summary>
        public App()
        {
            var page = SampleBrowser.Core.SampleBrowser.GetMainPage("SfCalendar", "SampleBrowser.SfCalendar");
            this.MainPage = page;
        }

        /// <summary>
        /// Handle when your app starts
        /// </summary>
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        /// <summary>
        /// Handle when your app sleeps
        /// </summary>
        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        /// <summary>
        /// Handle when your app resumes
        /// </summary>
        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
