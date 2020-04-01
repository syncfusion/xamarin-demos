#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfDataGrid;
using Android.Graphics;

namespace SampleBrowser
{
	public class Dark : DataGridStyle
	{
		public Dark ()
		{
		}

		public override Color GetHeaderBackgroundColor ()
		{
			return Color.ParseColor("#212121");
		}

		public override Color GetHeaderForegroundColor ()
		{
            return Color.ParseColor("#FFFFFF");
        }

		public override Color GetRecordForegroundColor ()
		{
            return Color.ParseColor("#FFFFFF");
        }

        public override Color GetAlternatingRowBackgroundColor()
        {
            return Color.ParseColor("#2E2E2E");
        }

        public override Color GetRecordBackgroundColor()
        {
            return Color.ParseColor("#2B2b2B");
        }


        public override Color GetSelectionBackgroundColor ()
		{
            return Color.ParseColor("#555555");
        }

		public override Color GetSelectionForegroundColor ()
		{
            return Color.ParseColor("#FFFFFF");
        }

		public override Color GetCaptionSummaryRowBackgroundColor ()
		{
			return Color.Rgb (02, 02, 02);
		}

		public override Color GetCaptionSummaryRowForegroundColor ()
		{
			return Color.Rgb (255, 255, 255);
		}

		public override Color GetBorderColor ()
		{
			return Color.Rgb (81, 83, 82);
		}

		public override int GetHeaderSortIndicatorDown ()
		{
			return Resource.Drawable.SortingDown;
		}

		public override int GetHeaderSortIndicatorUp ()
		{
			return Resource.Drawable.SortingUp;
		}

        public override GridLinesVisibility GetGridLinesVisibility()
        {
            return GridLinesVisibility.Horizontal;
        }
    }
}

