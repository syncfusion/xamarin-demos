#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using SampleBrowser.Core.iOS;
using UIKit;

#region Generated Code
namespace SampleBrowser.SfCalendar.iOS
#endregion
{
    /// <summary>
    /// The UIApplicationDelegate for the application. This class is responsible for launching the 
    /// User Interface of the application, as well as listening (and optionally responding) to 
    /// application events from iOS.
    /// </summary>
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        /// <summary>
        /// status Bar and navigation bar Height
        /// </summary>
        private double statusBarHeight, navigationBarHeight;

        /// <summary>
        /// This method is invoked when the application has loaded and is ready to run. In this 
        /// method you should instantiate the window, load the UI into it and then make the window
        /// visible.
        /// You have 17 seconds to return from this method, or iOS will terminate your application.
        /// </summary>
        /// <param name="app">app param</param>
        /// <param name="options">options param</param>
        /// <returns>Finished Launching</returns>
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            this.statusBarHeight = app.StatusBarFrame.Size.Height;
            this.navigationBarHeight = new CustomNavigationPageRenderer().NavigationBar.Frame.Height;
            global::Xamarin.Forms.Forms.Init();
            Syncfusion.SfCalendar.XForms.iOS.SfCalendarRenderer.Init();
            Syncfusion.ListView.XForms.iOS.SfListViewRenderer.Init();
            SampleBrowser.Core.iOS.CoreSampleBrowser.Init(UIScreen.MainScreen.Bounds, app.StatusBarFrame.Size.Height);
            this.LoadApplication(new App());
			return base.FinishedLaunching(app, options);
        }
    }
}