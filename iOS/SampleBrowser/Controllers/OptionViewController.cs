#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using CoreGraphics;
using UIKit;

namespace SampleBrowser
{
	public class OptionViewController: UIViewController
	{
		public OptionViewController ()
		{
		}

		public UIView optionView {
			get;
			set;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.Title = "Options";
			this.View.BackgroundColor = UIColor.White;

			optionView.Frame = new CGRect(0, 0, 320, 400);

			this.View.AddSubview (optionView);
		}

		//public SampleView sampleView {
		//	get;
		//	set;
		//}
	}
}

