using System;
using UIKit;
using Foundation;
using Syncfusion.SfRotator.iOS;
using System.Collections.Generic;
using CoreGraphics;

namespace SampleBrowser
{
	public class Rotator : SampleView
	{
		Rotator_Mobile phoneView;
		public Rotator ()
		{
			if((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
				this.AddSubview(new Rotator_Tablet());

			}
			else{
				phoneView = new Rotator_Mobile ();
				this.AddSubview (phoneView);
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

