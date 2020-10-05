#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

using UIKit;

namespace SampleBrowser
{
	public partial class ViewController : UINavigationController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		UIView header;

		public ViewController()
		{
			
			Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("");
			this.SetNavigationBarHidden(true, false);
			this.View.BackgroundColor = UIColor.White;

			header = new UIView();
			header.BackgroundColor = UIColor.Blue;
			header.Frame = new CoreGraphics.CGRect(0, 0, this.View.Frame.Size.Width, this.View.Frame.Size.Height / 2.5);
              
			this.View.AddSubview(header);
		}

		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();
			header.Frame = new CoreGraphics.CGRect(0, 0, this.View.Frame.Size.Width, this.View.Frame.Size.Height / 2.5);
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

