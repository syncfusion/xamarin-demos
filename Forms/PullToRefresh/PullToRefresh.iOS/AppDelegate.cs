#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "AppDelegate.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Reviewed.")]

namespace SampleBrowser.SfPullToRefresh.iOS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Foundation;
    using UIKit;

    /// <summary>
    /// The UIApplicationDelegate for the application. This class is responsible for launching the User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    /// </summary>
     [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        /// <summary>
        /// This method is invoked when the application has loaded and is ready to run. In this  method you should instantiate the window, load the UI into it and then make the window visible. You have 17 seconds to return from this method, or iOS will terminate your application.
        /// </summary>
        /// <param name="app">Encapsulates the main processing loop for a mono Touch application type parameter app</param>
        /// <param name="options">Dictionary that provides mapping from keys to values parameter options</param>
        /// <returns>returns base.FinishedLaunching</returns>
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            this.LoadApplication(new App());
            Syncfusion.SfPullToRefresh.XForms.iOS.SfPullToRefreshRenderer.Init();
            Syncfusion.SfDataGrid.XForms.iOS.SfDataGridRenderer.Init();
            Syncfusion.ListView.XForms.iOS.SfListViewRenderer.Init();
            Syncfusion.XForms.iOS.ProgressBar.SfCircularProgressBarRenderer.Init();
            Syncfusion.XForms.iOS.Border.SfBorderRenderer.Init();
            SampleBrowser.Core.iOS.CoreSampleBrowser.Init(UIScreen.MainScreen.Bounds, app.StatusBarFrame.Size.Height);
            return base.FinishedLaunching(app, options);
        }
    }
}