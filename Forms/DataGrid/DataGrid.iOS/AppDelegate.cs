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

namespace SampleBrowser.SfDataGrid.iOS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Foundation;
    using UIKit;

    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]

    /// <summary>
    ///  The UIApplicationDelegate for the application. This class is responsible for launching the  User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    /// </summary>
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        /// <summary>
        /// This method is invoked when the application has loaded and is ready to run. In this  method you should instantiate the window, load the UI into it and then make the window visible. You have 17 seconds to return from this method, or iOS will terminate your application.
        /// </summary>
        /// <param name="app">UIApplication type of app parameter</param>
        /// <param name="options">NSDictionary type of options parameter</param>
        /// <returns>returns base.FinishedLaunching</returns>
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
           
            Syncfusion.SfDataGrid.XForms.iOS.SfDataGridRenderer.Init();
            Syncfusion.ListView.XForms.iOS.SfListViewRenderer.Init();
            Syncfusion.SfPullToRefresh.XForms.iOS.SfPullToRefreshRenderer.Init();
            Syncfusion.XForms.iOS.PopupLayout.SfPopupLayoutRenderer.Init();
            Syncfusion.SfSparkline.XForms.iOS.SfSparklineRenderer.Init();
            Syncfusion.XForms.iOS.MaskedEdit.SfMaskedEditRenderer.Init();
            SampleBrowser.Core.iOS.CoreSampleBrowser.Init(UIScreen.MainScreen.Bounds, app.StatusBarFrame.Size.Height);
            this.LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }
    }
}
