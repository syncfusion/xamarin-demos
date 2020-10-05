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
using Syncfusion.SfPullToRefresh;
using CoreGraphics;
using Syncfusion.SfDataGrid;

namespace SampleBrowser
{
    public class Options : UIView
    {
        UILabel transtionMode;
        UISwitch transtion;

        public Options(SfPullToRefresh pullToRefresh)
        {
            transtionMode = new UILabel();
            transtionMode.Text = "Transition: Push / SlideOnTop";

            transtion = new UISwitch();
            transtion.On = pullToRefresh.TransitionType == TransitionType.SlideOnTop ? true : false;
            transtion.ValueChanged += (sender, e) =>
            {
                pullToRefresh.TransitionType = transtion.On ? TransitionType.SlideOnTop : TransitionType.Push;
                if (pullToRefresh.PullableContent.GetType() != typeof(SfDataGrid))
                    pullToRefresh.RefreshContentThreshold = transtion.On ? 0 : 17;
                else
                    pullToRefresh.PullingThreshold = transtion.On ? 90 : 120;
            };
            this.AddSubview(transtionMode);
            this.AddSubview(transtion);
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            transtionMode.Frame = new CGRect(10, 10, 3 * this.Frame.Width / 4, 50);
            transtion.Frame = new CGRect(3 * this.Frame.Width / 4, 20, 30, 10);
        }
    }
}