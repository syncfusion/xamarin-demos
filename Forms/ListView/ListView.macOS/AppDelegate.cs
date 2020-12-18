#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using AppKit;
using Foundation;
using Syncfusion.ListView.XForms.MacOS;

using Xamarin.Forms;
using CoreGraphics;
using Xamarin.Forms.Platform.MacOS;
using SampleBrowser.Core.MacOS;

namespace SampleBrowser.SfListView.MacOS
{
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {
        NSWindow nswindow;

        public AppDelegate()
        {
            var style = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled;
            var rect = new CGRect(0, 1000, 200, 200);
            nswindow = new NSWindow(rect, style, NSBackingStore.Buffered, false);
            var screenFrame = nswindow.Screen.Frame;
            nswindow.SetFrame(new CGRect(0, 0, screenFrame.Width, screenFrame.Height), true, true);
            nswindow.TitleVisibility = NSWindowTitleVisibility.Hidden;
        }

        public override NSWindow MainWindow
        {
            get
            {
                return nswindow;
            }
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            Forms.Init();
            LoadApplication(new App());
            SfListViewRenderer.Init();
            SampleBrowserMac.Init();
            base.DidFinishLaunching(notification);
        }
    }
}