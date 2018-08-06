#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Drawing;
using CoreGraphics;
using UIKit;

namespace SampleBrowser
{
	class UIMarginLabel : UILabel
	{
		public UIMarginLabel()
		{
		}

		public UIMarginLabel(RectangleF frame) : base(frame)
		{
		}

		public UIEdgeInsets Insets { get; set; }

		public override void DrawText(CGRect rect)
		{
			base.DrawText(Insets.InsetRect(rect));
		}
	}
}

