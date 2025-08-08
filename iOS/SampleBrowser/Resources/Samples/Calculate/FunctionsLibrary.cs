#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using UIKit;
using CoreGraphics;
using Foundation;
using CoreAnimation;
using Syncfusion.Calculate;

namespace SampleBrowser
{
	public partial class FunctionsLibrary : SampleView
	{
		#region Fields

		FunctionsLibraryView functionsLibraryView;

		#endregion

		#region Constructor

		public FunctionsLibrary ()
		{
			functionsLibraryView  = new FunctionsLibraryView();
			this.AddSubview (functionsLibraryView);
		}

		#endregion

		#region Methods

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Bounds;
			}
			base.LayoutSubviews ();
		}

		protected override void Dispose (bool disposing)
		{
			functionsLibraryView.Dispose ();
			base.Dispose (disposing);
		}

		#endregion
	}

	public class CalcData : ICalcData
	{
		public event ValueChangedEventHandler ValueChanged;

		public CalcData()
		{

		}

		Dictionary<string, object> values = new Dictionary<string, object>();
		public object GetValueRowCol(int row, int col)
		{
			object value = null;

            var key = RangeInfo.GetAlphaLabel(col) + row;

			this.values.TryGetValue(key, out value);

			return value;
		}

		public void SetValueRowCol(object value, int row, int col)
		{
            var key = RangeInfo.GetAlphaLabel(col) + row;

			if (!values.ContainsKey(key))
				values.Add(key, value);
			else if (values.ContainsKey(key) && values[key] != value)
				values[key] = value;
		}

		public void WireParentObject()
		{
			
		}

		private void OnValueChanged(int row, int col, string value)
        {
            if (ValueChanged != null)
                ValueChanged(this, new ValueChangedEventArgs(row, col, value));
        }
	}
}

