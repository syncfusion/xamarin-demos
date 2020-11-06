#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using CoreGraphics;
using Foundation;
using UIKit;
using Syncfusion.SfNavigationDrawer.iOS;
using CoreAnimation;

namespace SampleBrowser
{
    public class HomeViewController : UIViewController
    {
        #region fields

        private CALayer overlay;

        private UIButton menuButton;

        private UIImageView userImg;

        private UILabel title, version, headerDetails;

        private UICollectionView collectionViewAllControls;

        private UICollectionViewFlowLayout flowLayoutAllControls;

        private UIView content, header, HeaderView, centerview, yellowSeperater;

        #endregion

        #region ctor

        public HomeViewController()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(string.Empty);
            this.View.BackgroundColor = Utility.BackgroundColor;
        }

        protected HomeViewController(IntPtr handle) : base(handle)
        {
        }

        #endregion

        #region properties

        public static SFNavigationDrawer NavigationDrawer { get; set; }

        public UITableView Table { get; set; }

        public NSMutableArray Controls { get; set; }

        public CALayer BottomBorder { get; set; }

        #endregion

        #region methods

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            content = new UIView
            {
                Frame = this.View.Frame
            };

            this.ParseControlsPlist();
            this.LoadHeaderView();
        }

        public void DrawerEvent(int index)
        {
            switch (index)
            {
                case 0:
                    UIApplication.SharedApplication.OpenUrl(new NSUrl("https://www.syncfusion.com/products/xamarin"));
                    break;
                case 1:
                    UIApplication.SharedApplication.OpenUrl(new NSUrl("https://www.syncfusion.com/products/whatsnew/xamarin-iOS"));
                    break;
                case 2:
                    UIApplication.SharedApplication.OpenUrl(new NSUrl("https://help.syncfusion.com/xamarin-ios/introduction/overview"));
                    break;
                default:
                    break;
            }

            HideDrawer(true);
        }

        public void HideDrawer(bool flag)
        {
            overlay.Hidden = flag;
            NavigationDrawer.ToggleDrawer();
        }

        public void HideOverlay()
        {
            overlay.Hidden = true;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            this.NavigationController.SetNavigationBarHidden(true, false);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            overlay.Hidden = true;
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            content.Frame = this.View.Frame;

            overlay.Frame = this.View.Frame;

            NavigationDrawer.Frame = new CGRect(0, 0, this.View.Frame.Width, this.View.Frame.Height);
            HeaderView.Frame = new CGRect(0, 0, NavigationDrawer.DrawerWidth, (NavigationDrawer.Frame.Height * 65) / 100);

            nfloat yellowLineStart = (HeaderView.Frame.Height * 50) / 100;
            yellowSeperater.Frame = new CGRect(20, yellowLineStart, HeaderView.Frame.Width - 40, 3);
            headerDetails.Frame = new CGRect(20, yellowLineStart + 6, HeaderView.Frame.Width - 40, yellowLineStart - 50);

            nfloat x = 20, y = yellowLineStart - 100;
            float imageWidth = 200, imageHeight = 70, lblWidth = 140;

            userImg.Frame = new CGRect(x, y, imageWidth, imageHeight);
            version.Frame = new CGRect(HeaderView.Frame.Width - 120, HeaderView.Frame.Height - 50, 150, 50);
            centerview.Frame = new CGRect(0, lblWidth, NavigationDrawer.DrawerWidth, 500);

            NavigationDrawer.DrawerHeaderView = HeaderView;
            NavigationDrawer.DrawerHeaderView.Superview.BackgroundColor = UIColor.Clear;
            NavigationDrawer.DrawerContentView = centerview;
            NavigationDrawer.DrawerContentView.BackgroundColor = UIColor.FromRGBA(1.0f, 1.0f, 1.0f, 0.96f);
            NavigationDrawer.DrawerContentView.Superview.BackgroundColor = UIColor.Clear;
            NavigationDrawer.DrawerHeaderHeight = (NavigationDrawer.Frame.Height * 65) / 100;
            NavigationDrawer.DidClose += NavigationDrawer_DidClose;

            nfloat width = this.View.Frame.Size.Width;
            nfloat height = this.View.Frame.Size.Height;

            float itemSpace = Utility.IsIPad ? 15 : 10;
            nfloat startY = 30;

            menuButton.Frame = new CGRect(10, startY, 22, 22);
            title.Frame = new CGRect(40, startY, height, 22);

            startY += title.Frame.Height + itemSpace;

            header.Frame = new CGRect(0, 0, width, startY);

            startY += 10;

            collectionViewAllControls.Frame = new CGRect(0, startY, width, height - startY);
            flowLayoutAllControls.ItemSize = new CGSize(width - 20, 100);

            if (Utility.IsIPad)
            {
                nfloat cellWidth = (width / 2) - 60;
                collectionViewAllControls.Frame = new CGRect(50, startY, width - 100, height - startY);
                flowLayoutAllControls.ItemSize = new CGSize(cellWidth, 100);
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        private void NavigationDrawer_DidClose(object sender, EventArgs e)
        {
            overlay.Hidden = true;
        }

        private void ParseControlsPlist()
        {
            string controlListPathString = NSBundle.MainBundle.BundlePath + "/plist/ControlList.plist";
            NSDictionary controlDict = new NSDictionary();
            controlDict = NSDictionary.FromFile(controlListPathString);
            NSString controlDictKey = new NSString("Control");
            NSArray controlDictArray = controlDict.ValueForKey(controlDictKey) as NSArray;

            Controls = new NSMutableArray();

            if (controlDictArray.Count > 0)
            {
                for (nuint i = 0; i < controlDictArray.Count; i++)
                {
                    NSDictionary dict = controlDictArray.GetItem<NSDictionary>(i);
                    string image = dict.ValueForKey(new NSString("ControlName")).ToString();
                    image = "Controls/" + image;
                    Control control = new Control
                    {
                        Name = new NSString(dict.ValueForKey(new NSString("ControlName")).ToString()),
                        Description = new NSString(dict.ValueForKey(new NSString("Description")).ToString()),
                        Image = UIImage.FromBundle(image)
                    };

                    if (!UIDevice.CurrentDevice.CheckSystemVersion(9, 0) && control.Name == "PDFViewer")
                    {
                        continue;
                    }

                    if (dict.ValueForKey(new NSString("IsNew")) != null && dict.ValueForKey(new NSString("IsNew")).ToString() == "YES")
                    {
                        control.Tag = new NSString("NEW");
                    }
                    else if (dict.ValueForKey(new NSString("IsUpdated")) != null && dict.ValueForKey(new NSString("IsUpdated")).ToString() == "YES")
                    {
                        control.Tag = new NSString("UPDATED");
                    }
                    else if (dict.ValueForKey(new NSString("IsPreview")) != null && dict.ValueForKey(new NSString("IsPreview")).ToString() == "YES")
                    {
                        control.Tag = new NSString("PREVIEW");
                    }
                    else
                    {
                        control.Tag = new NSString(string.Empty);
                    }

                    if (dict.ValueForKey(new NSString("Type1")) != null)
                    {
                        control.IsMultipleSampleView = true;
                        control.Type1 = new NSString(dict.ValueForKey(new NSString("Type1")).ToString());
                        control.Type2 = new NSString(dict.ValueForKey(new NSString("Type2")).ToString());
                    }

                    Controls.Add(control);
                }
            }
        }

        private static string[] GetTableItems()
        {
            return new string[] { "Product Page", "Whats New", "Documentation" };
        }

        private void LoadHeaderView()
        {
            NavigationDrawer = new SFNavigationDrawer
            {
                BackgroundColor = UIColor.Clear,
                ContentView = content
            };

            menuButton = new UIButton();
            menuButton.SetBackgroundImage(new UIImage("Images/menu.png"), UIControlState.Normal);

            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                NavigationDrawer.DrawerWidth = (this.View.Bounds.Width * 40) / 100;
            }
            else
            {
                NavigationDrawer.DrawerWidth = (this.View.Bounds.Width * 75) / 100;
            }

            NavigationDrawer.DrawerHeight = this.View.Bounds.Height;

            HeaderView = new UIView
            {
                BackgroundColor = UIColor.FromRGBA(249.0f / 255.0f, 78.0f / 255.0f, 56.0f / 255.0f, 0.97f)
            };

            userImg = new UIImageView
            {
                Image = new UIImage("Controls/synclogo.png")
            };

            version = new UILabel
            {
                Text = "Version " + NSUserDefaults.StandardUserDefaults.ValueForKey(new NSString("VersionNumber")),
                Font = UIFont.FromName("Helvetica", 12f),
                TextColor = UIColor.White,
                TextAlignment = UITextAlignment.Left
            };
            HeaderView.AddSubview(version);

            yellowSeperater = new UIView
            {
                BackgroundColor = UIColor.FromRGB(255.0f / 255.0f, 198.0f / 255.0f, 14.0f / 255.0f)
            };
            HeaderView.AddSubview(yellowSeperater);

            headerDetails = new UILabel
            {
                LineBreakMode = UILineBreakMode.WordWrap,
                Lines = 0,
                Text = "The toolkit contains all the components that are typically required for building line-of-business applications for IOS",
                TextColor = UIColor.White,
                Font = UIFont.FromName("Helvetica", 18f)
            };
            HeaderView.AddSubview(headerDetails);

            HeaderView.AddSubview(userImg);

            Table = new UITableView(new CGRect(0, 20, NavigationDrawer.DrawerWidth, this.View.Frame.Height))
            {
                SeparatorColor = UIColor.Clear
            };

            NavigationTableSource tablesource = new NavigationTableSource(this, GetTableItems())
            {
                Customize = false
            };

            Table.Source = tablesource;
            Table.BackgroundColor = UIColor.Clear;
            centerview = new UIView
            {
                Table
            };

            centerview.BackgroundColor = UIColor.Clear;

            NavigationDrawer.Position = SFNavigationDrawerPosition.SFNavigationDrawerPositionLeft;

            menuButton.TouchDown += (object sender, System.EventArgs e) =>
            {
                HideDrawer(false);
            };

            header = new UIView
            {
                BackgroundColor = UIColor.FromRGB(0, 122.0f / 255.0f, 238.0f / 255.0f)
            };

            title = new UILabel
            {
                TextColor = UIColor.White,
                Text = "Syncfusion Xamarin Samples",
                Font = UIFont.FromName("HelveticaNeue-Medium", 16f)
            };

            flowLayoutAllControls = new UICollectionViewFlowLayout
            {
                MinimumLineSpacing = 5,
                ScrollDirection = UICollectionViewScrollDirection.Vertical
            };

            collectionViewAllControls = new UICollectionView(CGRect.Empty, flowLayoutAllControls);
            collectionViewAllControls.RegisterClassForCell(typeof(UICollectionViewCell), "controlCell");
            collectionViewAllControls.DataSource = new AllControlsCollectionSource(Controls);
            collectionViewAllControls.Delegate = new AllControlsCollectionDelegate(this);
            collectionViewAllControls.BackgroundColor = Utility.BackgroundColor;

            UINib nibAllControls = UINib.FromName("ControlCell_9", null);
            collectionViewAllControls.RegisterNibForCell(nibAllControls, "controlCell");

            BottomBorder = new CALayer
            {
                BorderWidth = 1,
                BorderColor = UIColor.FromRGB(213.0f / 255.0f, 213.0f / 255.0f, 213.0f / 255.0f).CGColor,
                Hidden = true
            };

            content.AddSubview(header);
            content.AddSubview(menuButton);
            content.AddSubview(title);
            content.AddSubview(collectionViewAllControls);

            overlay = new CALayer
            {
                ZPosition = 1000,
                Hidden = true,
                BackgroundColor = UIColor.FromRGBA(0.0f / 255.0f, 0.0f / 255.0f, 0.0f / 255.0f, 0.05f).CGColor
            };
            content.Layer.AddSublayer(overlay);

            this.View.AddSubview(NavigationDrawer);
        }

        #endregion
    }
}