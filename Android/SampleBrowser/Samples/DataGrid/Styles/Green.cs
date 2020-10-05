#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.Graphics;
using Syncfusion.SfDataGrid;

namespace SampleBrowser
{
	public class Green : DataGridStyle
	{
		public Green ()
		{
		}

        public override Color GetHeaderBackgroundColor()
        {
            return Color.ParseColor("#5C8A5E");
        }

        public override Color GetHeaderForegroundColor()
        {
            return Color.ParseColor("#FFFFFF");
        }

        public override Color GetRecordForegroundColor()
        {
            return Color.ParseColor("#000000");
        }

        public override Color GetAlternatingRowBackgroundColor()
        {
            return Color.ParseColor("#E8F5E9");
        }

        public override Color GetSelectionBackgroundColor()
        {
            return Color.ParseColor("#81C784");
        }

        public override Color GetSelectionForegroundColor()
        {
            return Color.ParseColor("#FFFFFF");
        }

        public override Color GetCaptionSummaryRowBackgroundColor ()
		{
			return Color.Rgb (224, 224, 224);
		}

		public override Color GetCaptionSummaryRowForegroundColor ()
		{
			return Color.Rgb (51, 51, 51);
		}

		public override Color GetBorderColor ()
		{
			return Color.Rgb (180, 180, 180);
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

