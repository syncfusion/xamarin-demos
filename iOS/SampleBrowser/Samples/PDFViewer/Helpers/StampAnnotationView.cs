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
    internal class StampAnnotationView : UIView
    {
        UIButton backButton;
        UIView titleBar, parent, transparentView, bottomBar;
        UILabel title;
        UIButton approved, notApproved, expired, confidential, draft;
        UIButton closeButton;
        CustomToolbar mainView;
        internal StampAnnotationView(CustomToolbar customToolbar)
        {
            parent = new UIView();
            transparentView = new UIView();
            mainView = customToolbar;
            titleBar = new UIView();
            backButton = new UIButton();
            backButton.SetTitle("\ue71b", UIControlState.Normal);
            backButton.Font = mainView.highFont;
            backButton.SetTitleColor(UIColor.DarkGray, UIControlState.Normal);
            titleBar.AddSubview(backButton);
            backButton.TouchUpInside += BackButton_TouchUpInside;

            title = new UILabel();
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
            {
                title.TextAlignment = UITextAlignment.Right;
                title.Text = "CHOOSE STAMP";
                title.TextColor = UIColor.FromRGB(0, 118, 255);
            }
            else
            {
                title.TextAlignment = UITextAlignment.Center;
                title.Text = "Choose Stamp";
                title.TextColor = UIColor.Black;
            }
            titleBar.AddSubview(title);
            titleBar.BackgroundColor = UIColor.FromRGB(249, 249, 249);
            parent.AddSubview(titleBar);

            UIImage imageApproved = UIImage.FromBundle("Approved.png");
            UIImage imageNotApproved = UIImage.FromBundle("NotApproved.png");
            UIImage imageDraft = UIImage.FromBundle("Draft.png");
            UIImage imageConfidential = UIImage.FromBundle("Confidential.png");
            UIImage imageExpired = UIImage.FromBundle("Expired.png");

            approved = new UIButton();
            approved.SetImage(imageApproved, UIControlState.Normal);
            approved.TouchUpInside += Stamp_TouchUpInside;
            parent.AddSubview(approved);

            notApproved = new UIButton();
            notApproved.SetImage(imageNotApproved, UIControlState.Normal);
            notApproved.TouchUpInside += Stamp_TouchUpInside;
            parent.AddSubview(notApproved);

            draft = new UIButton();
            draft.SetImage(imageDraft, UIControlState.Normal);
            draft.TouchUpInside += Stamp_TouchUpInside;
            parent.AddSubview(draft);

            confidential = new UIButton();
            confidential.SetImage(imageConfidential, UIControlState.Normal);
            confidential.TouchUpInside += Stamp_TouchUpInside;
            parent.AddSubview(confidential);

            expired = new UIButton();
            expired.SetImage(imageExpired, UIControlState.Normal);
            expired.TouchUpInside += Stamp_TouchUpInside;
            parent.AddSubview(expired);

            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                transparentView.BackgroundColor = UIColor.Black;
                transparentView.Alpha = 0.5f;
                AddSubview(transparentView);
            }

            AddSubview(parent);

            bottomBar = new UIView();
            bottomBar.BackgroundColor = UIColor.FromRGB(249, 249, 249);
            parent.AddSubview(bottomBar);

            closeButton = new UIButton();
            closeButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            closeButton.SetTitle("Close", UIControlState.Normal);
            closeButton.Font = UIFont.SystemFontOfSize(16);
            bottomBar.AddSubview(closeButton);
            closeButton.TouchUpInside += CloseButton_TouchUpInside;

            parent.BackgroundColor = UIColor.White;
        }

        private void BackButton_TouchUpInside(object sender, EventArgs e)
        {
            Hide();
        }

        private void CloseButton_TouchUpInside(object sender, EventArgs e)
        {
            Hide();
        }

        private void Hide()
        {
            RemoveFromSuperview();
            mainView.isStampViewVisible = false;
        }

        private void Stamp_TouchUpInside(object sender, EventArgs e)
        {
            UIButton button = sender as UIButton;
            UIImage image = null;
            if (button == approved)
                image = UIImage.FromBundle("Approved.png");
            else if (button == notApproved)
                image = UIImage.FromBundle("NotApproved.png");
            else if (button == draft)
                image = UIImage.FromBundle("Draft.png");
            else if (button == expired)
                image = UIImage.FromBundle("Expired.png");
            else if (button == confidential)
                image = UIImage.FromBundle("Confidential.png");
            UIImageView customStamp = new UIImageView();
            customStamp.Image = image;
            customStamp.Frame = new CGRect(200, 200, 200, 50);
            mainView.pdfViewerControl.AddStamp(customStamp, new CGPoint(220, 300), mainView.pdfViewerControl.PageNumber);
            Hide();
        }

        public override void LayoutSubviews()
        {
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                transparentView.Frame = Frame;
                nfloat width = 500, height = 400;
                nfloat left = (Frame.Width - width) / 2;
                nfloat top = (Frame.Height - height) / 2;
                parent.Frame = new CGRect(left, top, width, height);
                titleBar.Frame = new CGRect(0, 0, parent.Frame.Width, 50);
                title.Frame = new CGRect(0, 0, parent.Frame.Width, 50);
                bottomBar.Frame = new CGRect(0, parent.Frame.Height - 50, parent.Frame.Width, 50);
                closeButton.Frame = new CGRect(420, 0, parent.Frame.Width - 420, 50);

                nfloat gap = 20, stampWidth = 200, stampHeight = 60;
                approved.Frame = new CGRect(40, 70, stampWidth, stampHeight);
                confidential.Frame = new CGRect(260, 70, stampWidth, stampHeight);
                draft.Frame = new CGRect(40, 70 + stampHeight + gap, stampWidth, stampHeight);
                expired.Frame = new CGRect(260, 70 + stampHeight + gap, stampWidth, stampHeight);
                notApproved.Frame = new CGRect(40, 70 + 2*(stampHeight + gap), stampWidth, stampHeight);
            }
            else
            {
                parent.Frame = Frame;
                titleBar.Frame = new CGRect(0, 0, Frame.Width, 50);
                backButton.Frame = new CGRect(0, 0, 50, 50);
                title.Frame = new CGRect(50, 0, Frame.Width - 80, 50);
                nfloat left = (Frame.Width - 100 - 100 - 30) / 2;
                approved.Frame = new CGRect(left, 70, 100, 30);
                confidential.Frame = new CGRect(left + 130, 70, 100, 30);
                draft.Frame = new CGRect(left, 120, 100, 30);
                expired.Frame = new CGRect(left + 130, 120, 100, 30);
                notApproved.Frame = new CGRect(left, 170, 100, 30);
            }
            base.LayoutSubviews();
        }
    }
}