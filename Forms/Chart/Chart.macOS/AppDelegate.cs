#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using AppKit;
using CoreGraphics;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;
using SampleBrowser.Core.MacOS;
using Syncfusion.ListView.XForms.MacOS;
using Syncfusion.SfChart.XForms.MacOS;

namespace SampleBrowser.SfChart.MacOS
{
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {


        NSWindow _window;

        public override NSWindow MainWindow
        {
            get { return _window; }
        }


        public AppDelegate()
        {
            var style = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled;

            var rect = new CGRect(0, 1000, 200, 200);
            _window = new NSWindow(rect, style, NSBackingStore.Buffered, false);
            var screenFrame = _window.Screen.Frame;
            _window.SetFrame(new CGRect(0, 0, screenFrame.Width, screenFrame.Height), true, true);
            _window.TitleVisibility = NSWindowTitleVisibility.Hidden;
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            Forms.Init();
            LoadApplication(new App());
            new SfChartRenderer();
            SfListViewRenderer.Init();
            SampleBrowserMac.Init();

            base.DidFinishLaunching(notification);
            // Insert code here to initialize your application
        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }
    }
}
