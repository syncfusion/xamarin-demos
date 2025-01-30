using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;

namespace SampleBrowser
{
    public class PullableContentView : UIView
    {
        BaseView baseView;
        CustomScroll customScroll;
        UILabel label;

        public PullableContentView(BaseView baseview, CustomScroll customscroll, UILabel lable) : base()
        {
            baseView = baseview;
            customScroll = customscroll;
            label = lable;
            this.AddSubview(baseview);
            this.AddSubview(customscroll);
            this.AddSubview(lable);
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            label.Frame = new CGRect(0, 20, this.Frame.Width, 50);
            baseView.Frame = new CGRect(0, (Frame.Height / 4), Frame.Width, Frame.Height / 2);
            customScroll.Frame = new CGRect(0, this.Frame.Height - 150, this.Frame.Width, 150);
        }
    }
}