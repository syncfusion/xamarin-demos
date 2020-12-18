#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;
using Xamarin.Forms;
using SampleBrowser.SfRadioButton.iOS;

[assembly: ExportRenderer(typeof(Frame), typeof(SampleBrowser.SfRadioButton.iOS.MaterialFrameRenderer))]
namespace SampleBrowser.SfRadioButton.iOS
{
    public class MaterialFrameRenderer : Xamarin.Forms.Platform.iOS.FrameRenderer
    {
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            Layer.ShadowColor = new UIColor(0, 0, 0, 0.16f).CGColor;
        }
    }
}
