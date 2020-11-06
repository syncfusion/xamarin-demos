#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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

