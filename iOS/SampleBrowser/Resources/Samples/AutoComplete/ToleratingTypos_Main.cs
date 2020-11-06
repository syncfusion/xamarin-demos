#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using SampleBrowser;
using UIKit;

namespace SampleBrowser
{
    public class ToleratingTypos_Main:SampleView
    {
        ToleratingTypos phoneView;
        ToleratingTypos_Tablet tableyviewOfAuto;
        public ToleratingTypos_Main()
        {

            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {

                tableyviewOfAuto = new ToleratingTypos_Tablet();
                this.AddSubview(tableyviewOfAuto);

            }
            else
            {
                phoneView = new ToleratingTypos();
                this.AddSubview(phoneView);
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
