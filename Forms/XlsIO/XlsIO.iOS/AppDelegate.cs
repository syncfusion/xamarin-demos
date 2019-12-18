#region Copyright Syncfusion Inc. 2001-2018.
// <copyright file="AppDelegate.cs" company=" Syncfusion Inc.">
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
// </copyright>
#endregion

namespace SampleBrowser.XlsIO.IOS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Foundation;
    using UIKit;

    /// <summary>
    /// The UIApplicationDelegate for the application. This class is responsible for launching the User
    /// Interface of the application, as well as listening (and optionally responding) to application
    /// events from iOS.
    /// </summary>
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        /// <summary>
        /// This method is invoked when the application has loaded and is ready to run. In this method
        /// you should instantiate the window, load the UI into it and then make the window visible.
        /// You have 17 seconds to return from this method, or iOS will terminate your application.
        /// </summary>
        /// <param name="app">parameter of UIApplication</param>
        /// <param name="options">parameter of NSDictionary</param>
        /// <returns>Return the boolean value.</returns>
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            Syncfusion.SfDataGrid.XForms.iOS.SfDataGridRenderer.Init();
            Syncfusion.SfNumericTextBox.XForms.iOS.SfNumericTextBoxRenderer.Init();
            Syncfusion.ListView.XForms.iOS.SfListViewRenderer.Init();
            Syncfusion.XForms.iOS.Buttons.SfRadioButtonRenderer.Init();
            SampleBrowser.Core.iOS.CoreSampleBrowser.Init(UIScreen.MainScreen.Bounds, app.StatusBarFrame.Size.Height);
            this.LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }
    }
}
