#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using CoreAnimation;
using CoreGraphics;
using Foundation;
using Syncfusion.DataSource;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UIKit;
using Syncfusion.iOS.PopupLayout;
using System.Threading.Tasks;

namespace SampleBrowser
{
    public class DetailsView : SampleView
    {
        #region Fields

        UITableView tableView;
        ContatsViewModel viewModel;
        DataSource sfDataSource;
        SfPopupLayout initialPopup;

        #endregion

        #region Constructor

        public DetailsView()
        {
            tableView = new UITableView();
            tableView.RowHeight = 70;
            tableView.SeparatorColor = UIColor.Clear;
            tableView.EstimatedRowHeight = 70;
            tableView.AllowsSelection = false;
            viewModel = new ContatsViewModel();
            sfDataSource = new DataSource();
            sfDataSource.Source = viewModel.ContactsList;
            tableView.Source = new PopupTableViewSource(sfDataSource);
            tableView.ContentInset = new UIEdgeInsets(-30, 0, 0 ,0);
            tableView.BackgroundColor = UIColor.FromRGB(244, 244, 244);
            tableView.SectionHeaderHeight = 50;
			tableView.ScrollEnabled = true;
            DisplayInitialPopup();
            this.AddSubview(tableView);
        }

        private void DisplayInitialPopup()
        {
            initialPopup = new SfPopupLayout();
            initialPopup.PopupView.AppearanceMode = AppearanceMode.OneButton;
            initialPopup.PopupView.PopupStyle.HeaderBackgroundColor = UIColor.White;
            initialPopup.PopupView.FooterHeight = initialPopup.PopupView.FooterHeight - 10;
            initialPopup.PopupView.ShowFooter = true;
            initialPopup.PopupView.ShowCloseButton = false;
            initialPopup.PopupView.HeaderTitle = "Notification !";
            initialPopup.PopupView.AcceptButtonText = "OK";
            initialPopup.StaysOpen = true;
            UILabel messageView = new UILabel();
            messageView.Text = "Click on the contact tile to view the options";
            messageView.TextColor = UIColor.Black;
            messageView.LineBreakMode = UILineBreakMode.WordWrap;
            messageView.Lines = 5;
            messageView.TextAlignment = UITextAlignment.Center;
            messageView.BackgroundColor = UIColor.White;
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
            {
                initialPopup.PopupView.PopupStyle.HeaderFontSize = 14;
                messageView.Font = UIFont.PreferredCaption1;
                initialPopup.PopupView.Frame = new CGRect(-1, -1, (UIScreen.MainScreen.ApplicationFrame.Width / 10) * 8, 180);
            }
            else
            {
                initialPopup.PopupView.PopupStyle.HeaderFontSize = 20;
                messageView.Font = UIFont.PreferredBody;
                initialPopup.PopupView.Frame = new CGRect(-1, -1, -1, 200);
            }
            initialPopup.PopupView.ContentView = messageView;
            initialPopup.Show();
        }

        #endregion

        #region Override Methods


        public override void LayoutSubviews()
        {
            tableView.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);
            base.LayoutSubviews();
        }

        #endregion

    }



    public class PopupTableViewSource : UITableViewSource
    {
        #region Field

        DataSource dataSource;

        #endregion

        #region Constructor

        public PopupTableViewSource(DataSource sfDataSource)
        {
            dataSource = sfDataSource;
        }

        #endregion

        #region implemented abstract members of UITableViewDataSource

        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            var item = dataSource.DisplayItems[indexPath.Row];
            if (item is Contacts)
            {
                PopupContactCell cell = tableView.DequeueReusableCell("TableCell") as PopupContactCell;
                if (cell == null)
                    cell = new PopupContactCell();
                cell.UpdateValue(item);
                return cell;
            }
            return new UITableViewCell();
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return (nint)dataSource.DisplayItems.Count;
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return tableView.RowHeight;
        }

        public override UIView GetViewForHeader(UITableView tableView, nint section)
        {
            var mainView = new UIView();
            var view = new UILabel();
            mainView.Layer.AddSublayer(new CALayer());
            mainView.Layer.Frame = tableView.Frame;
            mainView.Layer.Sublayers[0].BackgroundColor = UIColor.FromRGB(244, 244, 244).CGColor;
            mainView.Layer.Sublayers[0].Frame = new CGRect(0, 0, 15, 50);
            view.Frame = new CGRect(15, 20, tableView.Frame.Width - 15, 50);
            view.BackgroundColor = UIColor.FromRGB(244, 244, 244);
            view.Text = "Today";
            view.TextColor = UIColor.FromRGB(0, 0, 0);
            mainView.AddSubview(view);
            return mainView;
        }

        #endregion
    }

    public class PopupContactCell : UITableViewCell
    {
        #region Field

        private UIImageView imageView1;
        private UIImageView imageView2;        
        private UILabel Label1;
        private UILabel Label2;
        private UILabel Label3;
        private UILabel Label4;
        internal static UILabel currentLabel;
		UILabel overlayTags;
        SfPopupLayout detailsPopup;

        #endregion

        #region Constructor

        public PopupContactCell()
        {
            this.AutosizesSubviews = false;
            this.BackgroundColor = UIColor.FromRGB(255, 255, 255);

            Label1 = CreateLabel(Label1);
            Label1.Font = UIFont.FromName("Helvetica Neue", 15);

            Label2 = CreateLabel(Label2);
            Label2.TextColor = UIColor.LightGray;

            imageView1 = new UIImageView();
            imageView2 = new UIImageView() { Alpha = 0.54f };

            Label3 = new UILabel() { BackgroundColor = UIColor.FromRGB(244, 244, 244) };
            Label4 = new UILabel() { BackgroundColor = UIColor.FromRGB(244, 244, 244) };

            SelectionStyle = UITableViewCellSelectionStyle.Blue;
            this.AddSubviews(new UIView[] { Label3, imageView1, Label1, Label2, imageView2, Label4 });
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
            Label1.Text = contact.ContactName;
            Label2.Text = contact.ContactNumber;
            imageView1.Image = UIImage.FromBundle("Images/PopupImage" + r.Next(1, 10) + ".png");
            imageView2.Image = UIImage.FromBundle("Images/Popup_CallerImage.png");
        }

        #endregion

        #region override 

        public override void LayoutSubviews()
        {
            this.Layer.Frame = this.Frame;
            this.Layer.Sublayers[0].BackgroundColor = UIColor.FromRGB(244, 244, 244).CGColor;
            this.Layer.Sublayers[0].Frame = new CGRect(0, 0, this.Frame.Width, 10);
            nfloat y = 0;
            foreach (var subview in this.Subviews)
            {
                if (subview is UILabel && !(subview == imageView1) && subview != Label3 && subview != Label4)
                {
                    subview.Frame = new CoreGraphics.CGRect(imageView1.Frame.Right + 20, y + 20, (this.Frame.Width - imageView1.Frame.Right - 85), this.Frame.Height / 3);
                    y += subview.Frame.Height;
                }
                else if (subview == imageView1)
                {
                    subview.Frame = new CGRect(Label3.Frame.Right + 10, 23, 33, 35);
                }
                else if (subview is UIImageView && subview == imageView2)
                {
                    subview.Frame = new CoreGraphics.CGRect(Label1.Frame.Right + 20, 28, 25, this.Frame.Height - 48);
                }
                else if (subview == Label3)
                {
                    subview.Frame = new CGRect(0, 0, 10, this.Frame.Height);
                }
                else if (subview == Label4)
                {
                    subview.Frame = new CGRect(imageView2.Frame.Right + 10, 0, 16, this.Frame.Height);
                }
            }
        }

		public override void TouchesEnded(NSSet touches, UIEvent evt)
		{
			base.TouchesEnded(touches, evt);

			foreach (var view in this.Subviews)
			{
				if (view == Label1)
				{
					currentLabel = Label1;
					break;
				}
			}
            DisplayDetailsPopup();
        }

        private void DisplayDetailsPopup()
        {
            detailsPopup = new SfPopupLayout();
            detailsPopup.PopupView.BackgroundColor = UIColor.FromRGB(255, 255, 255);
            detailsPopup.PopupView.PopupStyle.BorderThickness = 5;
            detailsPopup.PopupView.ShowHeader = false;
            detailsPopup.PopupView.ShowFooter = false;
            detailsPopup.PopupView.Frame = new CGRect(-1, -1, this.Frame.Width - Label4.Frame.Width - 5, 150);
            detailsPopup.PopupView.ContentView = GetCustomPopupView();
            
             // In iPhone the parent is directly UITableView but in iPOD and iPAD the immedidate super view is not UITableView. Hence checked superview based on condition.
             if ((this.Frame.Bottom + detailsPopup.PopupView.Frame.Height) -
                (UIDevice.CurrentDevice.Model == "iPhone" ? 
                (this.Superview as UITableView).ContentOffset.Y :
                (this.Superview.Superview as UITableView).ContentOffset.Y) +10 <= this.Superview.Frame.Bottom)
                {
                    detailsPopup.ShowRelativeToView(this, RelativePosition.AlignBottom, 10, 0);
                }
                else
                {
                    detailsPopup.ShowRelativeToView(this, RelativePosition.AlignTop, 10, 0);
                }
        }

        private UIView GetCustomPopupView()
        {
            UIImageView imageView1;
            UIImageView imageView2;
            UIImageView imageView3;
            UILabel label1;
            UILabel label2;
            UILabel label3;
            UIView view1;
            UIView view2;
            UIView view3;
            UIView mainView;

            var height = detailsPopup.PopupView.Frame.Height / 3;

            imageView1 = new UIImageView();
            imageView1.Image = UIImage.FromBundle("Images/Popup_SendMessage.png");
            imageView1.Alpha = 0.54f;
            imageView1.Frame = new CGRect(10, 15, 20, 20);

            label1 = new UILabel();
            label1.Text = "Send Message";
            var tapGesture1 = new UITapGestureRecognizer(DisplayToast) { NumberOfTapsRequired = 1 };
            label1.AddGestureRecognizer(tapGesture1);
            label1.TextColor = UIColor.FromRGB(0, 0, 0);
            label1.Alpha = 0.54f;
			label1.Tag = 11;
            label1.UserInteractionEnabled = true;
            label1.Frame = new CGRect(50, 13, this.Frame.Width, 20);

            view1 = new UIView();
            view1.AddSubview(imageView1);
            view1.AddSubview(label1);
            view1.Frame = new CGRect(10, 0, this.Frame.Width, height);

            imageView2 = new UIImageView();
            imageView2.Image = UIImage.FromBundle("Images/Popup_BlockContact.png");
            imageView2.Alpha = 0.54f;
            imageView2.Frame = new CGRect(10, 13, 22, 22);

            label2 = new UILabel();
            label2.Text = "Block/report contact";
            label2.TextColor = UIColor.FromRGB(0, 0, 0);
			label2.UserInteractionEnabled = true;
            var tapGesture2 = new UITapGestureRecognizer(DisplayToast) { NumberOfTapsRequired = 1 };
			label2.AddGestureRecognizer(tapGesture2);
            label2.Alpha = 0.54f;
			label2.Tag = 22;
            label2.Frame = new CGRect(50, 13, this.Frame.Width, 20);

            view2 = new UIView();
            view2.AddSubview(imageView2);
            view2.AddSubview(label2);
            view2.Frame = new CGRect(10, height, this.Frame.Width, height);

            imageView3 = new UIImageView();
            imageView3.Image = UIImage.FromBundle("Images/Popup_ContactInfo.png");
            imageView3.Alpha = 0.54f;
            imageView3.Frame = new CGRect(10, 13, 22, 22);

            label3 = new UILabel();
            label3.Text = "Contact Details";
			label3.UserInteractionEnabled = true;
            label3.TextColor = UIColor.FromRGB(0, 0, 0);
			var tapGesture3 = new UITapGestureRecognizer(DisplayToast) { NumberOfTapsRequired = 1 };
			label3.AddGestureRecognizer(tapGesture3);
            label3.Alpha = 0.54f;
			label3.Tag = 33;
            label3.Frame = new CGRect(50, 13, this.Frame.Width, 20);

            view3 = new UIView();
            view3.AddSubview(imageView3);
            view3.AddSubview(label3);
            view3.Frame = new CGRect(10, height * 2, this.Frame.Width, height);

            mainView = new UIView();
            mainView.BackgroundColor = UIColor.FromRGB(255, 255, 255);
            mainView.AddSubview(view1);
            mainView.AddSubview(view2);
            mainView.AddSubview(view3);

            return mainView;
        }

		async void DisplayToast(UITapGestureRecognizer tasture)
		{
			overlayTags = new UILabel();
			overlayTags.Hidden = false;
			if(tasture.View.Tag == 11)
			overlayTags.Text = "Message sent";
			else if(tasture.View.Tag == 22)
				overlayTags.Text = "Contact blocked";
			else if(tasture.View.Tag == 33)
				overlayTags.Text = "No outgoing call history";
			overlayTags.Layer.CornerRadius = 20f;
			overlayTags.TextColor = UIColor.White;
			overlayTags.TextAlignment = UITextAlignment.Center;
			overlayTags.ClipsToBounds = true;
			//overlayTags.Alpha = 0.0f;
			overlayTags.Font = UIFont.SystemFontOfSize(14);
			overlayTags.BackgroundColor = UIColor.FromRGB(101.0f / 255.0f, 101.0f / 255.0f, 101.0f / 255.0f);
			overlayTags.Layer.ZPosition = 1000;
            UIApplication.SharedApplication.KeyWindow.RootViewController.View.AddSubview(overlayTags);
            overlayTags.Frame = new CGRect((UIScreen.MainScreen.Bounds.Width / 2) - 100, UIScreen.MainScreen.Bounds.Height - 70, 200, 40);
            UIView.Animate(0.5, 0, UIViewAnimationOptions.CurveLinear, () =>
			{
				overlayTags.Alpha = 1.0f;
			},
				() =>
				{
					UIView.Animate(3.0, () =>
					{
						overlayTags.Alpha = 0.0f;
					});
				}
			);
            detailsPopup.IsOpen = false;
            await Task.Delay(700);
            overlayTags.RemoveFromSuperview();
		}

        #endregion
    }

}
