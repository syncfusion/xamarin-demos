#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Foundation;
using UIKit;

namespace SampleBrowser
{
	public class Control : NSObject
	{
        #region ctor

        public Control()
		{
		}

        #endregion

        #region properties

        public NSString ControlName { get; set; }

        public NSString Name { get; set; }

        public NSString DisplayName { get; set; }

        public new NSString Description { get; set; }

        public UIImage Image { get; set; }

        public NSString Tag { get; set; }

        public NSString Type1 { get; set; }

        public NSString Type2 { get; set; }

        public bool IsMultipleSampleView { get; set; }

        #endregion
    }
}