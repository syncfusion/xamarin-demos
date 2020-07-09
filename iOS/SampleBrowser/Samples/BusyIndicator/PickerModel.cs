#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;

#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;

#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using nint = System.Int32;
using nuint = System.Int32;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
using nfloat  = System.Single;
#endif

namespace SampleBrowser
{
	public class PickerModel : UIPickerViewModel
	{
		private readonly IList<string> values;

		public event EventHandler<PickerChangedEventArgs> PickerChanged;

		public PickerModel(IList<string> values)
		{
			this.values = values;
		}

		public override nint GetComponentCount (UIPickerView picker)
		{
			return 1;
		}

		public override nint GetRowsInComponent (UIPickerView picker, nint component)
		{
			return values.Count;
		}

		public override string GetTitle (UIPickerView picker, nint row, nint component)
		{
			return values[(int)row];
		}

		public override nfloat GetRowHeight (UIPickerView picker, nint component)
		{
			return 30f;
		}

		public override void Selected (UIPickerView picker, nint row, nint component)
		{
			if (this.PickerChanged != null)
			{
				this.PickerChanged(this, new PickerChangedEventArgs{SelectedValue = values[(int)row]});
			}
		}
	}
}


