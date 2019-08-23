#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using UIKit;
using CoreGraphics;
namespace SampleBrowser
{
  
    public class NodeImageView : UIView
    {
        #region Fields

        UILabel label1;
        UIImageView imageIcon;
        #endregion

        #region Constructor

        public NodeImageView()
        {
            label1 = new UILabel();
            imageIcon = new UIImageView();
            imageIcon.ClipsToBounds = true;
            this.AddSubview(imageIcon);
            this.AddSubview(label1);
        }

        #endregion

        #region Methods

        public override void LayoutSubviews()
        {
            this.imageIcon.Frame = new CGRect(0, 0, 40,40);
            
            this.label1.Frame = new CGRect(40, 0, this.Frame.Width, this.Frame.Height);

            base.LayoutSubviews();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    
        #endregion
    }

}