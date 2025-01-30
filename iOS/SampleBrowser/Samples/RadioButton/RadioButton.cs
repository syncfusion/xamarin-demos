using System;
using System.Collections.Generic;
using System.Text;

namespace SampleBrowser
{
    public class RadioButton : SampleView
    {
        RadioButton_Mobile phoneView;
        public RadioButton()
        {
            phoneView = new RadioButton_Mobile();
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
