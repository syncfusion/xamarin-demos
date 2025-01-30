using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace SampleBrowser
{
   public class CheckBox : SampleView
    {
        CheckBox_Mobile phoneView;
        public CheckBox()
        {
                phoneView = new CheckBox_Mobile();
                this.AddSubview(phoneView);
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