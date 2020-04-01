#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Foundation;
using UIKit;
using CoreGraphics;
using Syncfusion.SfAutoComplete.iOS;
using System.Collections.Generic;

namespace SampleBrowser
{
    public class MultiSelection : SampleView
    {
        UILabel email, attach, send, ToLabel, ccLabel, bcclabel, interestLabel, cultureLabel, allowNullLabel;

        UIView redpanel;
        SfAutoComplete toAutoComplete;
        SfAutoComplete ccAutoComplete;
        SfAutoComplete bccAutoComplete;
        UITextField messageBox;
        public UIView option = new UIView();
        private readonly IList<string> cultureList = new List<string>();
        public MultiSelection()
        {
            //ToAutoComplete
            toAutoComplete = new SfAutoComplete();
            toAutoComplete.MultiSelectMode = MultiSelectMode.Token;
            toAutoComplete.TokensWrapMode = TokensWrapMode.Wrap;
            toAutoComplete.DataSource = new ContactsInfoCollection().GetContactDetails();
            toAutoComplete.DisplayMemberPath = (NSString)"ContactName";
            toAutoComplete.ImageMemberPath = "ContactImage";
            this.AddSubview(toAutoComplete);

            //CCAutoComplete
            ccAutoComplete = new SfAutoComplete();
            ccAutoComplete.MultiSelectMode = MultiSelectMode.Token;
            ccAutoComplete.TokensWrapMode = TokensWrapMode.Wrap;
            ccAutoComplete.DataSource = new ContactsInfoCollection().GetContactDetails();
            ccAutoComplete.DisplayMemberPath = (NSString)"ContactName";
            ccAutoComplete.ImageMemberPath = "ContactImage";
            this.AddSubview(ccAutoComplete);

           //BCCAutoComplete
            bccAutoComplete = new SfAutoComplete();
            bccAutoComplete.MultiSelectMode = MultiSelectMode.Token;
            bccAutoComplete.TokensWrapMode = TokensWrapMode.Wrap;
            bccAutoComplete.DataSource = new ContactsInfoCollection().GetContactDetails();
            bccAutoComplete.DisplayMemberPath = (NSString)"ContactName";
            bccAutoComplete.ImageMemberPath = "ContactImage";
            this.AddSubview(bccAutoComplete);

            //MessageBox
            messageBox = new UITextField();
            messageBox.Text = "Send from my smart phone";
            this.AddSubview(messageBox);
           
            mainPageDesign();
        }

        public void mainPageDesign()
        {
            redpanel = new UIView();
            redpanel.BackgroundColor = UIColor.Red;
            this.AddSubview(redpanel);
            //emaill
            email = new UILabel();
            email.TextColor = UIColor.White;
            email.BackgroundColor = UIColor.Clear;
            email.Text = @"Email - Compose";
            email.TextAlignment = UITextAlignment.Left;
            email.Font = UIFont.FromName("Helvetica", 16f);
            redpanel.AddSubview(email);

            //attachl
            attach = new UILabel();
            attach.TextColor = UIColor.White;
            attach.BackgroundColor = UIColor.Clear;
            attach.Text = @"Attach";
            attach.TextAlignment = UITextAlignment.Left;
            attach.Font = UIFont.FromName("Helvetica", 16f);
            redpanel.AddSubview(attach);

            //sendl
            send = new UILabel();
            send.TextColor = UIColor.White;
            send.BackgroundColor = UIColor.Clear;
            send.Text = @"Send";
            send.TextAlignment = UITextAlignment.Left;
            send.Font = UIFont.FromName("Helvetica", 16f);
            redpanel.AddSubview(send);

            //ToLabell
            ToLabel = new UILabel();
            ToLabel.TextColor = UIColor.Black;
            ToLabel.BackgroundColor = UIColor.Clear;
            ToLabel.Text = @"To";
            ToLabel.TextAlignment = UITextAlignment.Left;
            ToLabel.Font = UIFont.FromName("Helvetica", 13f);
            this.AddSubview(ToLabel);

            //ccLabell
            ccLabel = new UILabel();
            ccLabel.TextColor = UIColor.Black;
            ccLabel.BackgroundColor = UIColor.Clear;
            ccLabel.Text = @"Cc";
            ccLabel.TextAlignment = UITextAlignment.Left;
            ccLabel.Font = UIFont.FromName("Helvetica", 13f);
            this.AddSubview(ccLabel);

            //bcclabell
            bcclabel = new UILabel();
            bcclabel.TextColor = UIColor.Black;
            bcclabel.BackgroundColor = UIColor.Clear;
            bcclabel.Text = @"Bcc";
            bcclabel.TextAlignment = UITextAlignment.Left;
            bcclabel.Font = UIFont.FromName("Helvetica", 13f);
            this.AddSubview(bcclabel);

            this.BackgroundColor = UIColor.White;
        }
        public override void LayoutSubviews()
        {
            foreach (var view in this.Subviews)
            {
                view.Frame = Bounds;
                redpanel.Frame = new CGRect(0, 0, view.Frame.Width, 50);
                toAutoComplete.Frame = new CGRect(50, 60, view.Frame.Width - 60, 30);
                ccAutoComplete.Frame = new CGRect(50, 110, view.Frame.Width - 60, 30);
                bccAutoComplete.Frame = new CGRect(50, 160, view.Frame.Width - 60, 30);
                messageBox.Frame = new CGRect(10, 210, view.Frame.Width - 60, 30);
                email.Frame = new CGRect(15, 10, 180, 40);
                attach.Frame = new CGRect(this.Frame.Size.Width - 120, 10, 60, 40);
                send.Frame = new CGRect(this.Frame.Size.Width - 60, 10, 50, 40);
                ToLabel.Frame = new CGRect(15, 60, 60, 30);
                ccLabel.Frame = new CGRect(15, 110, this.Frame.Size.Width - 20, 30);
                bcclabel.Frame = new CGRect(15, 160, this.Frame.Size.Width - 20, 30);
            }
        }


    }

}
