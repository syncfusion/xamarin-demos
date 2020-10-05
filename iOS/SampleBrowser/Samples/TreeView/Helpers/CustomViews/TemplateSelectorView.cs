#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using UIKit;
using CoreGraphics;

namespace SampleBrowser
{
    public class TemplateSelectorView : UIView
    {
        #region Fields

        UILabel label1;
        UILabel label2;

        #endregion

        #region Constructor

        public TemplateSelectorView()
        {
            label1 = new UILabel();
            label2 = new UILabel();
            this.AddSubview(label1);
            this.AddSubview(label2);
        }

        #endregion

        #region Override Methods

        public override void LayoutSubviews()
        {
            this.label1.Frame = new CGRect(0, 0, this.Frame.Width - 100, 40);
            this.label2.Frame = new CGRect(this.Frame.Width - 50, 10, 20, 20);

            base.LayoutSubviews();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
      
        #endregion
    }
}