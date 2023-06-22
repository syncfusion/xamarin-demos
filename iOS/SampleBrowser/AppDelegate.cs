#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Foundation;
using UIKit;

namespace SampleBrowser
{
	[Register("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
        #region properties

        public override UIWindow Window { get; set; }

        #endregion

        #region methods

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
		{
            this.Window = new UIWindow(UIScreen.MainScreen.Bounds);
            
			NSUserDefaults.StandardUserDefaults.SetString("22.1.34", "VersionNumber");
			NSUserDefaults.StandardUserDefaults.Synchronize();

			UINavigationController controller = new UINavigationController(new HomeViewController());

			UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
			{
				TextColor = UIColor.White
			});

			controller.NavigationBar.BarTintColor = Utility.ThemeColor;

			controller.NavigationBar.TintColor = UIColor.White;

			application.StatusBarHidden = false;
			application.StatusBarStyle = UIStatusBarStyle.LightContent;

			var appearance = new UINavigationBarAppearance()
			{
				BackgroundColor = UIColor.FromRGB(3.0f / 255.0f, 126.0f / 255.0f, 249.0f / 255.0f),
				ShadowColor = UIColor.FromRGB(3.0f / 255.0f, 126.0f / 255.0f, 249.0f / 255.0f),
			};

			UINavigationBar.Appearance.StandardAppearance = appearance;
			UINavigationBar.Appearance.ScrollEdgeAppearance = appearance;

			this.Window.RootViewController = controller;
			this.Window.MakeKeyAndVisible();

			return true;
		}

		public override void OnResignActivation(UIApplication application)
		{
		}

		public override void DidEnterBackground(UIApplication application)
		{
		}

		public override void WillEnterForeground(UIApplication application)
		{
		}

		public override void OnActivated(UIApplication application)
		{
		}

		public override void WillTerminate(UIApplication application)
		{
		}

        #endregion
    }
}
