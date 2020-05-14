#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
	public class CustomScroll: UIScrollView
	{
        public CustomScroll()
        {

        }

		public CustomScroll(CGRect frame) : base(frame)
		{
			Frame = frame;
		}

		public override void SetContentOffset(CoreGraphics.CGPoint contentOffset, bool animated)
		{
			if (contentOffset.Y == -64)
			{
				contentOffset.Y = 0;
			}

			base.SetContentOffset(contentOffset, animated);
		}
	}
}

