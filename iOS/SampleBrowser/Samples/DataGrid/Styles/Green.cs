#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfDataGrid;
using UIKit;

namespace SampleBrowser
{
	public class Green : DataGridStyle
	{
		public Green ()
		{
		}

		public override UIColor GetHeaderBackgroundColor ()
		{
            return UIColor.FromRGB (92, 138, 94);
		}

        public override UIColor GetHeaderForegroundColor()
        {
            return UIColor.FromRGB(255, 255, 255);
        }

		public override UIColor GetAlternatingRowBackgroundColor ()
		{
            return UIColor.FromRGB (232, 248, 233);
		}

		public override UIColor GetSelectionBackgroundColor ()
		{
            return UIColor.FromRGB (129, 199, 132);
		}

		public override UIColor GetSelectionForegroundColor ()
		{
			return UIColor.FromRGB (255, 255, 255);
		}

		public override UIColor GetCaptionSummaryRowBackgroundColor ()
		{
			return UIColor.FromRGB (224, 224, 224);
		}

		public override UIColor GetCaptionSummaryRowForegroundColor ()
		{
			return UIColor.FromRGB (51, 51, 51);
		}

		public override UIColor GetBorderColor ()
		{
			return UIColor.FromRGB (180, 180, 180);
		}

//		public override int GetHeaderSortIndicatorDown ()
//		{
//			return Resource.Drawable.SortingDown;
//		}
//
//		public override int GetHeaderSortIndicatorUp ()
//		{
//			return Resource.Drawable.SortingUp;
//		}
	}
}

