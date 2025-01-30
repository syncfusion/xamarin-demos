using System;
using Syncfusion.SfNumericTextBox.iOS;
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
	public class NumericTextBox : SampleView
	{
		NumericTextBox_Mobile phoneView;
		public NumericTextBox ()
		{
			if((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
				this.AddSubview (new NumericTextBox_Tablet ());
			}
			else{
				phoneView = new NumericTextBox_Mobile ();
				this.AddSubview (phoneView);
				this.OptionView = phoneView.option;
			}
	    }
		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Bounds;
			}
		}
	}
}

