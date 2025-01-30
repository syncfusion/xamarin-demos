using System;
using System.Collections.Generic;
using Syncfusion.SfBusyIndicator.iOS;

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
	public class BusyIndicator : SampleView
	{
		BusyIndicator_Mobile phoneView;
        public BusyIndicator()
        {

            phoneView = new BusyIndicator_Mobile();
            this.AddSubview(phoneView);

        }
		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Bounds;
			}
		}
	
	}
}