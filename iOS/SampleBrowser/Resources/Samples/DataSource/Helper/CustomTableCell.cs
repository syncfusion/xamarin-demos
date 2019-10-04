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
    public class CustomTableCell : UITableViewCell
    {
        #region Field

        private UILabel Label1;
        private UILabel Label2;
        private UILabel Label3;
        private UILabel Label4;
        private UIImageView imageview;
        #endregion

        #region Constructor

        public CustomTableCell()
        {
            this.AutosizesSubviews = true;
            Label1 = CreateLabel(Label1);
            Label2 = CreateLabel(Label2);
            Label3 = CreateLabel(Label3);
            Label4 = CreateLabel(Label4);
            imageview= new UIImageView();
            SelectionStyle = UITableViewCellSelectionStyle.Blue;
            this.AddSubviews(new UIView[] { imageview, Label1, Label2, Label3, Label4 });
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
            label.Font = UIFont.FromName("Helvetica Neue", 12);
            return label;
        }

        public void UpdateCell( object obj)
        {
            if (obj is BookDetails)
            {
                var bookDetails = obj as BookDetails;
                Label1.Text = "Name : " + bookDetails.CustomerName;
                Label2.Text = "Book ID : " + bookDetails.BookID.ToString();
                Label3.Text = "Book Name : " + bookDetails.BookName;
                Label4.Text = "Price : " + "$" + bookDetails.Price.ToString();
                imageview.Image = bookDetails.CustomerImage;
            }
        }

        #endregion

        #region override 

        public override void LayoutSubviews()
        {
           // this.Layer.Frame = this.Frame;
            this.Layer.Sublayers[0].BackgroundColor = UIColor.LightGray.CGColor;
            this.Layer.Sublayers[0].Frame = new CoreGraphics.CGRect(0, 0, this.Frame.Width, 0.5);
            imageview.Frame = new CoreGraphics.CGRect(10, 10, 80, this.Frame.Height- 20);
            nfloat y=0;
           foreach (var subview in this.Subviews)
           {
               if (subview is UILabel)
               {
                   subview.Frame = new CoreGraphics.CGRect(imageview.Frame.Right + 30, y + 10, (this.Frame.Width - 30 - imageview.Frame.Right) , (this.Frame.Height -20)/4);
                   y += subview.Frame.Height;
               }
           }
        }

        #endregion
    }
}
