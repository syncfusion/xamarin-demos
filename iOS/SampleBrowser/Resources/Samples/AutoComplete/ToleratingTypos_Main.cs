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
