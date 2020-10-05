#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfDataGrid;
using Syncfusion.Data;
using Android.Graphics;
using Android.Widget;
using System.Reflection;
using Android.Content;
using System.IO;

namespace SampleBrowser
{
	public class GridImageCell:GridCell
	{
		private ImageView customerImage;
		Bitmap bitmap;
		public GridImageCell (Context context) : base (context)
		{
			customerImage = new ImageView (context);
			this.CanRendererUnload = false;
			this.AddView (customerImage);
		}

		public MemoryStream LoadResource (String name)
		{
			MemoryStream aMem = new MemoryStream ();
			var assm = Assembly.GetExecutingAssembly ();
			var path = String.Format ("DataGrid.Resources.drawable.{0}", name);
			var aStream = assm.GetManifestResourceStream (path);
			aStream.CopyTo (aMem);
			return aMem;
		}

		protected override void UnLoad ()
		{
			if (this.Parent != null)
				(this.Parent as VirtualizingCellsControl).RemoveView (this);
		}

		protected override void OnLayout (bool changed, int left, int top, int right, int bottom)
		{
			customerImage.Layout (0, 5, this.Width, this.Height - 5);
		}

		public override void Draw (Canvas canvas)
		{
			base.Draw (canvas);
			bitmap = (Bitmap)DataColumn.RowData.GetType ().GetProperty ("CustomerImage").GetValue (DataColumn.RowData);
			customerImage.SetImageBitmap (bitmap);
		}

		protected override void Dispose (bool disposing)
		{
			if (bitmap != null) {
				this.customerImage.Dispose ();
				this.customerImage = null;
			}
			base.Dispose (disposing);
		}
	}

	public class BoolFormatCell : GridCell
	{
		private ToggleButton isOpen;

		public BoolFormatCell (Context ctxt) : base (ctxt)
		{
			isOpen = new ToggleButton (ctxt);
			isOpen.SetTextColor (Color.Rgb (51, 51, 51));
			isOpen.TextOn = "Open";
			isOpen.TextOff = "Closed";
			isOpen.Click += isOpen_Click;
            CanRendererUnload = false;
			this.AddView (isOpen);
		}

		void isOpen_Click (object sender, EventArgs e)
		{
			bool isChecked = (sender as ToggleButton).Checked;
			DataColumn.Renderer.DataGrid.View.GetPropertyAccessProvider().SetValue(DataColumn.RowData, DataColumn.GridColumn.MappingName, isChecked);
		}

		protected override void UnLoad ()
		{
			if (this.Parent != null)
				(this.Parent as VirtualizingCellsControl).RemoveView (this);
		}

		protected override void OnLayout (bool changed, int left, int top, int right, int bottom)
		{
			isOpen.Layout (35, 20, this.Width - 35, bottom - 20);
		}

		public override void Draw (Canvas canvas)
		{
			base.Draw (canvas);
			isOpen.Checked = Convert.ToBoolean (DataColumn.CellValue);
		}

		protected override void Dispose (bool disposing)
		{
			this.isOpen.Click -= isOpen_Click;
			this.isOpen.Dispose ();
			this.isOpen = null;
			base.Dispose (disposing);
		}
	}
}

