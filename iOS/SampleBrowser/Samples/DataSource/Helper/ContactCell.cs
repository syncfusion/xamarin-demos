#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using CoreAnimation;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace SampleBrowser
{
    public class ContactCell : UITableViewCell
    {
        #region Field

        private UILabel Label1;
        private UILabel Label2;
        private UILabel Label3;

        #endregion

        #region Constructor

        public ContactCell()
        {
            this.AutosizesSubviews = false;
            Label1 = CreateLabel(Label1);
            Label1.TextColor = UIColor.White;
            Label1.TextAlignment = UITextAlignment.Center;
            Label1.Font = UIFont.BoldSystemFontOfSize(20);
            Label1.Layer.MasksToBounds = false;
            Label1.Layer.BorderColor = UIColor.White.CGColor;
            Label1.Layer.BorderWidth = 0;
            Label1.ClipsToBounds = true;
            Label1.Frame = new CoreGraphics.CGRect(0, 0, 70, 70);
            Label2 = CreateLabel(Label2);
            Label2.Font = UIFont.FromName("Helvetica Neue", 15);
            Label3 = CreateLabel(Label3);
            Label3.TextColor = UIColor.LightGray;
            SelectionStyle = UITableViewCellSelectionStyle.Blue;
            this.AddSubviews(new UIView[] {Label1, Label2, Label3 });
            this.LayoutMargins = new UIEdgeInsets(10, 10, 10, 10);
            this.Layer.AddSublayer(new CALayer());
        }



        #endregion

        #region Private Method

        private UILabel CreateLabel(UILabel label)
        {
            label = new UILabel();
            label.TextColor = UIColor.Black;
            label.TextAlignment = UITextAlignment.Left;
            label.LineBreakMode = UILineBreakMode.CharacterWrap;
            label.Font = UIFont.FromName("Helvetica Neue", 11);
            return label;
        }

        Random r = new Random();
        public void UpdateValue(object obj)
        {
            var contact = obj as Contacts;
            Label1.Text = contact.ContactName[0].ToString();
            Label2.Text = contact.ContactName;
            Label3.Text = contact.ContactNumber;
            Label1.BackgroundColor = contact.ContactColor;
        }

        #endregion

        #region override 

        public override void LayoutSubviews()
        {
            this.Layer.Frame = this.Frame;
            this.Layer.Sublayers[0].BackgroundColor = UIColor.LightGray.CGColor;
            this.Layer.Sublayers[0].Frame = new CoreGraphics.CGRect(0, 0, this.Frame.Width, 0.5);
            Label1.Frame = new CoreGraphics.CGRect(10, 10, 50, this.Frame.Height - 20);
            var radius = (float)Math.Min(Label1.Frame.Width, Label1.Frame.Height);
            Label1.Layer.CornerRadius = (radius / 2);
            nfloat y = 0;
            foreach (var subview in this.Subviews)
            {
                if (subview is UILabel && !(subview == Label1))
                {
                    subview.Frame = new CoreGraphics.CGRect(Label1.Frame.Right + 20, y + 10, (this.Frame.Width - 20 - Label1.Frame.Right), (this.Frame.Height - 20) / 3);
                    y += subview.Frame.Height;
                }
            }
        }

        #endregion
    }
}
