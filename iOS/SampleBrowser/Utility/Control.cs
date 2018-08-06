#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Foundation;
using UIKit;

namespace SampleBrowser
{
	public class Control : NSObject
	{
		public Control ()
		{
		}

		public NSString ControlName
		{
			get;
			set;
		}

		public NSString name {
			get;
			set;
		}

		public NSString dispName
		{
			get;
			set;
		}

		public NSString description 
		{
			get;
			set;
		}

		public UIImage image {
			get;
			set;
		}

		public NSString tag {
			get;
			set;
		}

		public NSString Type1
		{
			get;
			set;
		}

		public NSString Type2
		{
			get;
			set;
		}

		public bool IsMultipleSampleView {
			get;
			set;
		}

	}
}

