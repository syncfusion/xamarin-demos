#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Drawing;
using CoreGraphics;
using UIKit;

namespace SampleBrowser
{
	internal class UIMarginLabel : UILabel
	{
        #region ctor

        public UIMarginLabel()
		{
		}

        #endregion

        #region properties

        public UIEdgeInsets Insets { get; set; }

        #endregion

        #region methods

        public override void DrawText(CGRect rect)
		{
			base.DrawText(Insets.InsetRect(rect));
		}

        #endregion
    }
}