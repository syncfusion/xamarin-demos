#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using CoreGraphics;
using Foundation;
using Syncfusion.SfRadialMenu.iOS;
using UIKit;

namespace SampleBrowser
{
	public class ContextualMenu : SampleView
	{
		SfRadialMenu radialMenu;
		UIButton shareButton;
		UILabel shareText, titleLabel;
		UIAlertView alertWindow;
		UIView shareView;
		UIStringAttributes underlineAttr = new UIStringAttributes { UnderlineStyle = NSUnderlineStyle.Single, ForegroundColor = UIColor.FromRGB(30,168,242) };
		public ContextualMenu()
		{
			titleLabel = new UILabel();
			titleLabel.Text = "About Syncfusion";
			titleLabel.Font = UIFont.FromName("Helvetica", 20f);

			shareText = new UILabel();
			shareText.Text = "\tSyncfusion is the enterprise technology partner of choice for software development, delivering a broad range of web, mobile, and desktop controls coupled with a service-oriented approach throughout the entire application lifecycle. Syncfusion has established itself as the trusted partner worldwide for use in applications.";
			shareText.Lines = 0;
			shareText.LineBreakMode = UILineBreakMode.WordWrap;
			shareText.Font = UIFont.FromName("Helvetica", 16f);

			shareView = new UIView();
			shareView.BackgroundColor = UIColor.White;

			shareButton = new UIButton();
			shareButton.SetAttributedTitle(new NSAttributedString("Tap here to follow us", underlineAttr), UIControlState.Normal);
			shareButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			shareButton.BackgroundColor = UIColor.Clear;
			shareButton.SetTitleColor(UIColor.FromRGB(41,146,247), UIControlState.Normal);
			shareButton.TouchUpInside += shareButtonClicked;
			shareView.Add(shareButton);

			radialMenu = new SfRadialMenu();
			radialMenu.Hidden = true;
			CGRect apprect = UIScreen.MainScreen.Bounds;
			//radialMenu.Position = new CGPoint(apprect.Width / 2, apprect.Height - apprect.Height/3 - 55);
			radialMenu.IsDragEnabled = false;
			radialMenu.RimRadius = 100;
			radialMenu.CenterButtonRadius = 25;
			radialMenu.CenterButtonBorderThickness = 2;
			radialMenu.EnableRotation = true;
			radialMenu.RimColor = UIColor.Clear;
			radialMenu.CenterButtonText = "\ue703";
			radialMenu.CenterButtonBackgroundColor = UIColor.FromRGB(0,207,72);
			radialMenu.CenterButtonTextColor = UIColor.White;
			radialMenu.CenterButtonIconFont = UIFont.FromName("Social", 30);
			radialMenu.CenterButtonTextFrame = new CGRect(-1,5,50,50);
			radialMenu.Closed+= RadialMenu_Closed;
			SfRadialMenuItem facebook = new SfRadialMenuItem() {Image="facebook.png", FontIconFrame= new CGRect(0,4,30,30),IconFont = UIFont.FromName("Social", 20),FontIconColor=UIColor.White, FontIcon = "\ue700" };
			facebook.ItemTapped += facebook_ItemTapped;
			radialMenu.Items.Add(facebook);

			SfRadialMenuItem gplus = new SfRadialMenuItem() { Image = "gplus.png", FontIconFrame = new CGRect(0, 4, 30, 30),IconFont = UIFont.FromName("Social", 20),FontIconColor = UIColor.White, FontIcon = "\ue707" };
			gplus.ItemTapped += gPlus_ItemTapped;
			radialMenu.Items.Add(gplus);

			SfRadialMenuItem twitter = new SfRadialMenuItem() {Image = "twitter.png", FontIconFrame = new CGRect(0, 4, 30, 30), IconFont = UIFont.FromName("Social", 20),FontIconColor = UIColor.White, FontIcon = "\ue704"};
			twitter.ItemTapped += twitter_ItemTapped;
			radialMenu.Items.Add(twitter);

			SfRadialMenuItem pinterest = new SfRadialMenuItem() { Image = "pinterest.png", FontIconFrame = new CGRect(0, 4, 30, 30),IconFont = UIFont.FromName("Social", 20),FontIconColor = UIColor.White, FontIcon = "\ue705"};
			pinterest.ItemTapped += pinterest_ItemTapped;
			radialMenu.Items.Add(pinterest);

			SfRadialMenuItem linkedIn = new SfRadialMenuItem() { Image = "linkedin.png", FontIconFrame = new CGRect(0, 4, 30, 30),IconFont = UIFont.FromName("Social", 20),FontIconColor = UIColor.White, FontIcon = "\ue706"};
			linkedIn.ItemTapped += linkedIn_ItemTapped;
			radialMenu.Items.Add(linkedIn);

			SfRadialMenuItem instagram = new SfRadialMenuItem() {Image = "instagram.png", FontIconFrame = new CGRect(0, 4, 30, 30), IconFont = UIFont.FromName("Social", 20),FontIconColor = UIColor.White, FontIcon = "\ue708"};
			instagram.ItemTapped += instagram_ItemTapped;
			radialMenu.Items.Add(instagram);

			alertWindow = new UIAlertView();
			alertWindow.AddButton("OK");

			this.Add(titleLabel);
			this.Add(shareText);
			this.Add(shareView);
			this.Add(radialMenu);
		}

		public override void LayoutSubviews()
		{
			foreach (var view in this.Subviews)
			{
				if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
				{
					titleLabel.Frame = new CGRect(10, 10, Frame.Width, 30);
					shareText.Frame = new CGRect(5, 40, Frame.Width-10, 160);
					shareView.Frame = new CGRect(10,210,Frame.Width-20,Frame.Height/2);
					shareButton.Frame = new CGRect(0, 0, shareView.Frame.Width, shareView.Frame.Height);
					radialMenu.Position = new CGPoint(Frame.Width/2, shareView.Frame.Top+shareView.Frame.Height/2);
				}
				else
				{
					titleLabel.Frame = new CGRect(10, 10, Frame.Width, 30);
					shareText.Frame = new CGRect(5, 40, Frame.Width - 10, 160);
					shareView.Frame = new CGRect(10, 210, Frame.Width - 20, Frame.Height / 2);
					shareButton.Frame = new CGRect(0, 0, shareView.Frame.Width, shareView.Frame.Height);
					radialMenu.Position = new CGPoint(Frame.Width / 2, shareView.Frame.Top + shareView.Frame.Height / 2);
				}
			}
			base.LayoutSubviews();
		}
		void facebook_ItemTapped(object sender, EventArgs e)
		{
			alertWindow.Message = "Shared in Facebook";
			alertWindow.Show();
		}
		void gPlus_ItemTapped(object sender, EventArgs e)
		{
			alertWindow.Message = "Shared in Google+";
			alertWindow.Show();
		}
		void twitter_ItemTapped(object sender, EventArgs e)
		{
			alertWindow.Message = "Shared in Twitter";
			alertWindow.Show();
		}
		void pinterest_ItemTapped(object sender, EventArgs e)
		{
			alertWindow.Message = "Shared in Pinterest";
			alertWindow.Show();
		}
		void linkedIn_ItemTapped(object sender, EventArgs e)
		{
			alertWindow.Message = "Shared in LinkedIn";
			alertWindow.Show();
		}
		void instagram_ItemTapped(object sender, EventArgs e)
		{
			alertWindow.Message = "Shared in Instagram";
			alertWindow.Show();
		}
		void RadialMenu_Closed(object sender, EventArgs e)
		{
			shareButton.SetAttributedTitle(new NSAttributedString("Tap here to share", underlineAttr), UIControlState.Normal);
			radialMenu.Hidden = true;
		}

		void shareButtonClicked(object sender, EventArgs e)
		{
			if (radialMenu.Hidden)
			{
				shareButton.SetAttributedTitle(new NSAttributedString("", underlineAttr), UIControlState.Normal);
				radialMenu.Hidden = false;
				radialMenu.Open();
			}
			this.BecomeFirstResponder();
		}
	}
}
