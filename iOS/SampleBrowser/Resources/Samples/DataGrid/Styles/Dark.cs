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
	public class Dark : DataGridStyle
	{
		public Dark ()
		{
		}

		public override UIColor GetHeaderBackgroundColor ()
		{
			return UIColor.FromRGB (33, 33, 33);
		}

		public override UIColor GetHeaderForegroundColor ()
		{
			return UIColor.FromRGB (255, 255, 255);
		}

		public override UIColor GetRecordBackgroundColor ()
		{
			return UIColor.FromRGB (43, 43, 43);
		}

		public override UIColor GetRecordForegroundColor ()
		{
			return UIColor.FromRGB (255, 255, 255);
		}

		public override UIColor GetAlternatingRowBackgroundColor ()
		{
            return UIColor.FromRGB (46, 46, 46);
		}

		public override UIColor GetSelectionBackgroundColor ()
		{
			return UIColor.FromRGB (85, 85, 85);
		}

		public override UIColor GetSelectionForegroundColor ()
		{
			return UIColor.FromRGB (255, 255, 255);
		}

		public override UIColor GetCaptionSummaryRowBackgroundColor ()
		{
			return UIColor.FromRGB (02, 02, 02);
		}

		public override UIColor GetCaptionSummaryRowForegroundColor ()
		{
			return UIColor.FromRGB (255, 255, 255);
		}

		public override UIColor GetBorderColor ()
		{
			return UIColor.FromRGB (81, 83, 82);
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

