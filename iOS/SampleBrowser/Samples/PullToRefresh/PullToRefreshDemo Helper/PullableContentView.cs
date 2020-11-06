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