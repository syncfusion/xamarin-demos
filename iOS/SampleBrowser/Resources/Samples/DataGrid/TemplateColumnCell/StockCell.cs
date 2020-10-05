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
using System.IO;
using System.Reflection;

namespace SampleBrowser
{
	public class StockCell : GridCell
	{
		UIImageView imageView;
		UILabel stocktext;

		public StockCell ()
		{
			imageView = new UIImageView ();
			stocktext = new UILabel ();
			stocktext.Font = UIFont.SystemFontOfSize (20);
			this.Add (stocktext);
			this.CanRendererUnload = false;
			this.AddSubview (imageView);
		}

		public MemoryStream LoadResource (String name)
		{
			MemoryStream aMem = new MemoryStream ();

			var assm = Assembly.GetExecutingAssembly ();

			var path = String.Format ("SampleBrowser.Resources.Images.{0}",name);

			var aStream = assm.GetManifestResourceStream (path);

			aStream.CopyTo (aMem);

			return aMem;
		}

		protected override void UnLoad ()
		{
			this.RemoveFromSuperview ();
		}

		public override void Draw (CoreGraphics.CGRect rect)
		{
			this.stocktext.Font = DataColumn.GridColumn.RecordFont;
			this.stocktext.TextColor = DataColumn.Renderer.DataGrid.GridStyle.GetRecordForegroundColor ();
			this.stocktext.TextAlignment = UITextAlignment.Right;
			base.Draw (rect);
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();

			if (Convert.ToDouble (DataColumn.CellValue) < 0.05) {
				imageView.Image = ImageHelper.ToUIImage (new ImageMapStream (LoadResource ("RedDown.png").ToArray ()));
			} else {
				imageView.Image = ImageHelper.ToUIImage (new ImageMapStream (LoadResource ("GreenUp.png").ToArray ()));
			}
			this.stocktext.Frame = new CoreGraphics.CGRect (35, this.Bounds.Top, 65, this.Bounds.Height);
			this.imageView.Frame = new CoreGraphics.CGRect (20, 10, 17, this.Bounds.Height - 20);
            this.stocktext.Font = DataColumn.GridColumn.RecordFont;
            this.stocktext.TextAlignment = UITextAlignment.Right;
			this.stocktext.Text = DataColumn.CellValue.ToString ();
		}

		protected override void Dispose (bool disposing)
		{
			if (this.imageView != null && stocktext != null) {

				imageView.Dispose ();
				imageView = null;
				stocktext.Dispose ();
				stocktext = null;
			}

			base.Dispose (disposing);
		}
	}
}

