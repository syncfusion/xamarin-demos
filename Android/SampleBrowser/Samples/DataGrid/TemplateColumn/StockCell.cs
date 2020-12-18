#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfDataGrid;
using Android.Views;
using Android.Content;
using Android.Widget;
using Android.Graphics;

namespace SampleBrowser
{
	public class StockCell : GridCell
	{
		TextView stockText;
		ImageView stockImage;

		public StockCell (Context context) : base (context)
		{
			stockText = new TextView (context);
			stockImage = new ImageView (context);
			stockText.Gravity = GravityFlags.Right;
			stockText.SetTextColor (Color.Rgb (51, 51, 51));
			this.CanRendererUnload = false;
			this.AddView (stockText);
			this.AddView (stockImage);
		}

		protected override void UnLoad ()
		{
			if (this.Parent != null)
				(this.Parent as VirtualizingCellsControl).RemoveView (this);
		}

		protected override void OnDraw (Canvas canvas)
		{
			stockText.Text = DataColumn.CellValue.ToString ();
			if (Convert.ToDouble (DataColumn.CellValue) > 0.05)
				stockImage.SetImageResource (Resource.Drawable.GreenUp);
			else
				stockImage.SetImageResource (Resource.Drawable.RedDown);
			base.OnDraw (canvas);
		}

		protected override void OnLayout (bool changed, int left, int top, int right, int bottom)
		{
			stockImage.Layout ((int)(15 * Resources.DisplayMetrics.Density), 0, (int)(35 * Resources.DisplayMetrics.Density), Height);
			stockText.Layout ((int)(35 * Resources.DisplayMetrics.Density), (int)(10 * Resources.DisplayMetrics.Density), Width - 20, Height);
		}
	}
}

