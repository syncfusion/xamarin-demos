
using System;
using System.Collections.Generic;
using Syncfusion.SfRating.iOS;


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
	public class Rating : SampleView
	{
		Rating_Mobile phoneView;			
		public Rating ()
		{
			if((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
				this.AddSubview(new Rating_Tablet ());

			}
			else{
				phoneView = new Rating_Mobile ();
				this.AddSubview(phoneView);
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