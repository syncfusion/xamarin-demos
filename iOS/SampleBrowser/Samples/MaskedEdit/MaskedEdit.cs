#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfRangeSlider.iOS;
using System.Collections.Generic;
using Syncfusion.SfAutoComplete.iOS;


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
    public class MaskedEdit : SampleView
    {
        MaskedEdit_Mobile phoneView;
        public MaskedEdit()
        {

            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                this.AddSubview(new MaskedEdit_Tablet());

            }
            else
            {
                phoneView = new MaskedEdit_Mobile();
                this.AddSubview(phoneView);
                this.OptionView = phoneView.option;
            }
        }


        public override void LayoutSubviews()
        {
            foreach (var view in this.Subviews)
            {
                view.Frame = Bounds;
            }
        }

    }
}