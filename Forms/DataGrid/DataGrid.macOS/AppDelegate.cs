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
namespace SampleBrowser.SfDataGrid.MacOS
{
    using System.Diagnostics.CodeAnalysis;
    using AppKit;
    using CoreGraphics;  
    using Foundation;
    using Syncfusion.SfDataGrid.XForms.MacOS;
    using Xamarin.Forms.Platform.MacOS;

    [Register("AppDelegate")]

    /// <summary>
    /// The UIApplicationDelegate for the application. This class is responsible for launching the User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    /// </summary>
    public class AppDelegate : FormsApplicationDelegate
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private NSWindow nswindow;

        /// <summary>
        /// Initializes a new instance of the AppDelegate class.
        /// </summary>
        public AppDelegate()
        {
            var style = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled;
            var rect = new CGRect(0, 1000, 200, 200);
            this.nswindow = new NSWindow(rect, style, NSBackingStore.Buffered, false);
            var screenFrame = this.nswindow.Screen.Frame;
            this.nswindow.SetFrame(new CGRect(0, 0, screenFrame.Width, screenFrame.Height), true, true);
            this.nswindow.TitleVisibility = NSWindowTitleVisibility.Hidden;
        }

        /// <summary>
        /// Gets the value of FilterText
        /// </summary>
        public override NSWindow MainWindow
        {
            get
            {
                return this.nswindow;
            }
        }

        /// <summary>
        /// Sent by the default notification center after the application has been launched and initialized but before it has received its first event.
        /// </summary>
        /// <param name="notification">The value for this key is an NSNumber containing a Boolean value. The value is false if the app was launched to open or print a file, to perform a Service action, if the app had saved state that will be restored, or if the app launch was in some other sense not a default launch. Otherwise its value will be true.</param>
        public override void DidFinishLaunching(NSNotification notification)
        {
            Xamarin.Forms.Forms.Init();
            Syncfusion.ListView.XForms.MacOS.SfListViewRenderer.Init();
            SfDataGridRenderer.Init();
            SampleBrowser.Core.MacOS.SampleBrowserMac.Init();
            this.LoadApplication(new App());
            base.DidFinishLaunching(notification);
        }
    }
}
