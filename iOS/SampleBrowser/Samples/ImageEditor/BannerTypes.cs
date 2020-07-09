#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.IO;
using System.Threading;
using CoreGraphics;
using Syncfusion.SfImageEditor.iOS;
using UIKit;
using System.Reflection;
using Foundation;
using Photos;

namespace SampleBrowser
{
    public class BannerTypes : SampleView
    {

        UINavigationController navigationController;
        UIView mainView;
        UILabel label;
        UIButton imageView1, imageView2, imageView3;
        int padding = 3;

        public BannerTypes()
        {
            mainView = new UIView();
            nfloat TotalWidth = Frame.Width - 10;
            mainView.Frame = new CGRect(0, 0, Frame.Width, Frame.Height);
           


            /*------Header Label-------*/

            label = new UILabel(new CGRect(20, 50, TotalWidth, 25));
            label.BackgroundColor = UIColor.Clear;
            label.Font = UIFont.SystemFontOfSize(25);
            label.TextAlignment = UITextAlignment.Left;
            label.TextColor = UIColor.Gray;
            label.Text = "Banner Types";



            imageView1 = new UIButton(new CGRect(padding, 100, (TotalWidth / 3) - padding, 150));
            imageView1.SetImage(UIImage.FromBundle("Images/ImageEditor/dashboard.jpg"), UIControlState.Normal);
            imageView1.ImageView.ContentMode = UIViewContentMode.ScaleToFill;
            imageView1.Layer.BorderColor = UIColor.LightGray.CGColor;
            imageView1.Layer.BorderWidth = 0.5f;
            imageView1.TouchDown += (sender, e) =>
            {

                navigationController.PushViewController(new BannerViewController(imageView1.CurrentImage, 0), false);

            };

            mainView.AddSubview(imageView1);

            imageView2 = new UIButton(new CGRect((TotalWidth / 3) + (1 * padding), 100, (TotalWidth / 3) - padding, 150));
            imageView2.SetImage(UIImage.FromBundle("Images/ImageEditor/succinity.png"), UIControlState.Normal);
            imageView2.ImageView.ContentMode = UIViewContentMode.ScaleToFill;
            imageView2.Layer.BorderColor = UIColor.LightGray.CGColor;
            imageView2.Layer.BorderWidth = 0.5f;
            mainView.AddSubview(imageView2);

            imageView2.TouchDown += (sender, e) =>
            {

                navigationController.PushViewController(new BannerViewController(imageView2.CurrentImage, 1), false);

            };


            imageView3 = new UIButton(new CGRect((2 * (TotalWidth / 3)) + (1 * padding), 100, (TotalWidth / 3) - padding, 150));
            imageView3.SetImage(UIImage.FromBundle("Images/ImageEditor/twitter.jpeg"), UIControlState.Normal);
            imageView3.ImageView.ContentMode = UIViewContentMode.ScaleToFill;
            imageView3.Layer.BorderColor = UIColor.LightGray.CGColor;
            imageView3.Layer.BorderWidth = 0.5f;
            imageView3.TouchDown += (sender, e) =>
            {

                navigationController.PushViewController(new BannerViewController(imageView3.CurrentImage, 2), false);

            };

            mainView.AddSubview(imageView3);
            AddSubview(label);
            AddSubview(mainView);

        }

        public override void MovedToSuperview()
        {
            base.MovedToSuperview();
            var view = Superview;
            var window = UIApplication.SharedApplication.KeyWindow;
            navigationController = window.RootViewController as UINavigationController;
        }


        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            nfloat TotalWidth = Frame.Width - 10;
            mainView.Frame = new CGRect(0, 0, Frame.Width, Frame.Height);
            float renderWidth = (float)(TotalWidth / 3) - padding;
            label.Frame = new CGRect(20, 50, TotalWidth, 25);
            imageView1.Frame = new CGRect(padding, 100, (TotalWidth / 3) - padding, 150);
            imageView2.Frame = new CGRect((TotalWidth / 3) + (1 * padding), 100, (TotalWidth / 3) - padding, 150);
            imageView3.Frame = new CGRect((2 * (TotalWidth / 3)) + (1 * padding), 100, (TotalWidth / 3) - padding, 150);


        }



    }


    public class BannerViewController : UIViewController
    {
        UIImage _image;

        public BannerViewController(UIImage image, int index)
        {
            _image = image;
            selectedIndex = index;
        }

        SfImageEditor sfImageEditor;
        UIViewController presentController;
        UIView CropSelectionMenu;
        int selectedIndex = 0;

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            presentController = GetVisibleViewController();
            sfImageEditor = new SfImageEditor(new CGRect(View.Frame.Location.X, 60, View.Frame.Size.Width, View.Frame.Size.Height - 60));
            sfImageEditor.ToolBarSettings.ToolbarItems.Clear();
            sfImageEditor.ToolBarSettings.ToolbarItems.Add(new FooterToolbarItem()
            {
                Text = "Banner Types",

                SubItems = new System.Collections.Generic.List<ToolbarItem>()
                {
                     new ToolbarItem(){Text="Facebook Post"},
                      new ToolbarItem(){Text="Facebook Cover"},
                       new ToolbarItem(){Text="Twitter Cover"},
                        new ToolbarItem(){Text="Twitter Post"},
                         new ToolbarItem(){Text="YouTubeChannel Cover"}
                     }

            });
            sfImageEditor.ToolBarSettings.ToolbarItems.Add(new CustomHeader() { HeaderName = "Share", Icon = UIImage.FromBundle("Images/ImageEditor/share.png") });
            sfImageEditor.ToolBarSettings.ToolbarItemSelected += ToolbarItemSelected;
            sfImageEditor.ImageSaved += ImageEditor_ImageSaved;
            sfImageEditor.Image = _image;
            this.View.AddSubview(sfImageEditor);

            CropSelectionMenu = new UIView(new CGRect(0, 60, View.Frame.Width, 50));
            CropSelectionMenu.BackgroundColor = UIColor.White;
            UIButton okButton = new UIButton(new CGRect(0, 0, View.Frame.Width / 2, 50));
            okButton.SetTitle("OK", UIControlState.Normal);
            okButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            okButton.TouchDown += (sender, e) =>
            {
                sfImageEditor.Crop();
                CropSelectionMenu.Hidden = true;

            };
            CropSelectionMenu.AddSubview(okButton);


            UIButton cancelButton = new UIButton(new CGRect(View.Frame.Width / 2, 0, View.Frame.Width / 2, 50));
            cancelButton.SetTitle("Cancel", UIControlState.Normal);
            cancelButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            cancelButton.TouchDown += (sender, e) =>
            {

                sfImageEditor.ToggleCropping();
                CropSelectionMenu.Hidden = true;
            };

            CropSelectionMenu.Hidden = true;
            CropSelectionMenu.AddSubview(cancelButton);
            View.AddSubview(CropSelectionMenu);

        }


        void ToolbarItemSelected(object sender, ToolbarItemSelectedEventArgs e)
        {

            if (e.ToolbarItem is ToolbarItem)
            {
                var toolitem = e.ToolbarItem as ToolbarItem;
                if (!(toolitem is HeaderToolbarItem))
                {
                    CropSelectionMenu.Hidden = false;
                }
                if (toolitem is HeaderToolbarItem)
                    sfImageEditor.Save();
                else if (toolitem.Text == "Facebook Post")
                    sfImageEditor.ToggleCropping(1200, 900);
                else if (toolitem.Text == "Facebook Cover")
                    sfImageEditor.ToggleCropping(851, 315);
                else if (toolitem.Text == "Twitter Cover")
                    sfImageEditor.ToggleCropping(1500, 500);
                else if (toolitem.Text == "Twitter Post")
                    sfImageEditor.ToggleCropping(1024, 512);
                else if (toolitem.Text == "YouTubeChannel Cover")
                    sfImageEditor.ToggleCropping(2560, 1440);
                else if (toolitem.Text == "Banner Types")
                    sfImageEditor.ToggleCropping(1200, 900);

            }

        }

        void ImageEditor_ImageSaved(object sender, ImageSavedEventArgs e)
        {
            string[] str = e.Location.Split('/');
            PHFetchResult assetResult = PHAsset.FetchAssetsUsingLocalIdentifiers(str, null);
            PHAsset asset = assetResult.firstObject as PHAsset;
            PHImageManager.DefaultManager.RequestImageData(asset, null, async (data, dataUti, orientation, info) =>
            {
                UIImage newImage = new UIImage(data);
                var items = new NSObject[] { newImage };
                var activityController = new UIActivityViewController(items, null);


                NSString[] excludedActivityTypes = null;

                if (excludedActivityTypes != null && excludedActivityTypes.Length > 0)
                    activityController.ExcludedActivityTypes = excludedActivityTypes;

                if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
                {
                    if (activityController.PopoverPresentationController != null)
                    {
                        activityController.PopoverPresentationController.SourceView = presentController.View;
                    }
                }

                await presentController.PresentViewControllerAsync(activityController, true);
            });


        }

        internal static UIViewController GetVisibleViewController()
        {
            var rootController = UIApplication.SharedApplication.KeyWindow.RootViewController;

            if (rootController.PresentedViewController == null)
                return rootController;

            if (rootController.PresentedViewController is UINavigationController)
            {
                return ((UINavigationController)rootController.PresentedViewController).TopViewController;
            }

            if (rootController.PresentedViewController is UITabBarController)
            {
                return ((UITabBarController)rootController.PresentedViewController).SelectedViewController;
            }

            return rootController.PresentedViewController;
        }
    }
    public class CustomHeader : HeaderToolbarItem
    {

        public string HeaderName { get; set; }
    }



}

