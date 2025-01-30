using System;
using CoreGraphics;
using UIKit;

namespace SampleBrowser
{
	public class CustomScroll: UIScrollView
	{
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

