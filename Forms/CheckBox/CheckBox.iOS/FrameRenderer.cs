#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using UIKit;
using Xamarin.Forms;
using CoreGraphics;

[assembly: ExportRenderer(typeof(Frame), typeof(SampleBrowser.SfCheckBox.iOS.FrameRenderer))]
namespace SampleBrowser.SfCheckBox.iOS
{
    public class FrameRenderer : Xamarin.Forms.Platform.iOS.FrameRenderer
    {
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            Layer.ShadowColor = new UIColor(0, 0, 0, 0.16f).CGColor;
        }
    }
}
