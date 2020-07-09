#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using UIKit;
using CoreGraphics;
using Syncfusion.SfImageEditor.iOS;
using Foundation;

namespace SampleBrowser
{
    public class ImageEditorCustomView : SampleView
    {
        UINavigationController navigationController;
        UIView mainView;
        UILabel label;
        UIButton imageView1,imageView2,imageView3;
        int padding = 3;

        public ImageEditorCustomView()
        {
            mainView = new UIView();
            nfloat TotalWidth = Frame.Width - 10;
            float renderWidth = (float)TotalWidth / 3;
            mainView.Frame = new CGRect(0, 0, Frame.Width, Frame.Height);
           

            /*------Header Label-------*/

            label = new UILabel(new CGRect(20, 50, TotalWidth, 25));
            label.BackgroundColor = UIColor.Clear;
            label.Font = UIFont.SystemFontOfSize(25);
            label.TextAlignment = UITextAlignment.Left;
            label.TextColor = UIColor.Gray;
            label.Text = "Sample Pictures";



             imageView1 = new UIButton(new CGRect(padding, 100, (TotalWidth / 3) - padding, 150));
            imageView1.SetImage(UIImage.FromBundle("Images/ImageEditor/CustomViewImage1.png"), UIControlState.Normal);
            imageView1.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
            imageView1.Layer.BorderColor = UIColor.LightGray.CGColor;
            imageView1.Layer.BorderWidth = 0.5f;
            float renderHeight = GetImageHeight(imageView1, renderWidth);
            imageView1.Frame = new CGRect(0, 100, renderWidth, renderHeight);
            imageView1.TouchDown += (sender, e) =>
            {

                navigationController.PushViewController(new CustomViewViewController(imageView1.CurrentImage, 0), false);

            };

            mainView.AddSubview(imageView1);

             imageView2 = new UIButton(new CGRect((TotalWidth / 3) + (1 * padding), 100, (TotalWidth / 3) - padding, 150));
            imageView2.SetImage(UIImage.FromBundle("Images/ImageEditor/CustomViewImage2.png"), UIControlState.Normal);
            imageView2.ImageView.ContentMode = UIViewContentMode.ScaleToFill;
            imageView2.Layer.BorderColor = UIColor.LightGray.CGColor;
            imageView2.Layer.BorderWidth = 0.5f;
            float renderHeight1 = GetImageHeight(imageView2, renderWidth);
            imageView2.Frame = new CGRect(TotalWidth / 3, 100, renderWidth, renderHeight1);
            mainView.AddSubview(imageView2);

            imageView2.TouchDown += (sender, e) =>
            {

                navigationController.PushViewController(new CustomViewViewController(imageView2.CurrentImage, 1), false);

            };


             imageView3 = new UIButton(new CGRect((2 * (TotalWidth / 3)) + (1 * padding), 100, (TotalWidth / 3) - padding, 150));
            imageView3.SetImage(UIImage.FromBundle("Images/ImageEditor/CustomViewImage3.png"), UIControlState.Normal);
            imageView3.ImageView.ContentMode = UIViewContentMode.ScaleToFill;
            imageView3.Layer.BorderColor = UIColor.LightGray.CGColor;
            imageView3.Layer.BorderWidth = 0.5f;
            float renderHeight2 = GetImageHeight(imageView3, renderWidth);
            imageView3.Frame = new CGRect((2 * TotalWidth / 3), 100, renderWidth, renderHeight2);
            imageView3.TouchDown += (sender, e) =>
            {

                navigationController.PushViewController(new CustomViewViewController(imageView3.CurrentImage, 2), false);

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
            nfloat TotalWidth = Frame.Width - 20;
            mainView.Frame = new CGRect(0, 0, TotalWidth, Frame.Height);
            float renderWidth = (float)(TotalWidth / 3)-padding;
            label.Frame = new CGRect(20, 50, TotalWidth, 25);
            float renderHeight1 = GetImageHeight(imageView1, renderWidth);
            imageView1.Frame = new CGRect(padding, 100, renderWidth, renderHeight1);
            float renderHeight2 = GetImageHeight(imageView2, renderWidth);
            imageView2.Frame = new CGRect((TotalWidth / 3)+padding, 100, renderWidth, renderHeight2);
            float renderHeight3 = GetImageHeight(imageView3, renderWidth);
            imageView3.Frame = new CGRect((2 * TotalWidth / 3)+padding, 100, renderWidth, renderHeight3);

          
        }
        private float GetImageHeight(UIButton button, float renderWidth)
        {
            float originalWidth = (float)button.ImageView.Image.Size.Width;

            float originalHeight = (float)button.ImageView.Image.Size.Height;

            float renderedHeight = (renderWidth * originalHeight) / originalWidth;

            return renderedHeight;
        }


    }


    public class CustomViewViewController : UIViewController
    {
        UIImage image;
        public CustomViewViewController(UIImage image, int index)
        {
            this.image = image;
            selectedIndex = index;
        }

        SfImageEditor imageEditor;
        UIViewController presentController;
        int selectedIndex = 0;
        List<ToolbarItem> CustomViewItems;
        CustomViewSettings customViewSettings;
        bool isReplaced; string imageName;
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            presentController = GetVisibleViewController();
            imageEditor = new SfImageEditor(new CGRect(View.Frame.Location.X, 60, View.Frame.Size.Width, View.Frame.Size.Height - 60));
            imageEditor.SetToolbarItemVisibility("text,transform,shape,path,effects", false);

            CustomViewItems = new List<ToolbarItem>()
            {
                new CustomToolbarItem(){ CustomName = "Typogy1",Icon=UIImage.FromBundle("Images/ImageEditor/ITypogy1.png"),IconHeight=70 },
                new CustomToolbarItem(){CustomName = "Typogy2",Icon=UIImage.FromBundle("Images/ImageEditor/ITypogy2.png"),IconHeight=70  },
                new CustomToolbarItem(){CustomName = "Typogy3",Icon=UIImage.FromBundle("Images/ImageEditor/ITypogy3.png"),IconHeight=70  },
                new CustomToolbarItem(){CustomName = "Typogy4",Icon=UIImage.FromBundle("Images/ImageEditor/ITypogy4.png"),IconHeight=70  },
 new CustomToolbarItem(){CustomName = "Typogy5",Icon=UIImage.FromBundle("Images/ImageEditor/ITypogy5.png"),IconHeight=70  },
 new CustomToolbarItem(){CustomName = "Typogy6",Icon=UIImage.FromBundle("Images/ImageEditor/ITypogy6.png"),IconHeight=70  },
            };

            // Add the custom tool bar items
            var item1 = new FooterToolbarItem()
            {
                Text = "Add",
                Icon = UIImage.FromBundle("Images/ImageEditor/AddIcon.png"),
                SubItems = CustomViewItems,
                TextHeight = 20,
            };

            var item2 = new FooterToolbarItem()
            {
                Text = "Replace",
                Icon = UIImage.FromBundle("Images/ImageEditor/ReplaceIcon.png"),
                SubItems = CustomViewItems,
                TextHeight = 20
            };

            var item3 = new FooterToolbarItem()
            {
                Icon = UIImage.FromBundle("Images/ImageEditor/BringFrontIcon"),
                Text = "Bring Front",
                TextHeight = 20
            };

            var item4 = new FooterToolbarItem()
            {
                Icon = UIImage.FromBundle("Images/ImageEditor/SendBack"),
                Text = "Send Back",
                TextHeight = 20
            };
            imageEditor.ToolBarSettings.ToolbarItems.Add(item1);
            imageEditor.ToolBarSettings.ToolbarItems.Add(item2);
            imageEditor.ToolBarSettings.ToolbarItems.Add(item3);
            imageEditor.ToolBarSettings.ToolbarItems.Add(item4);
            imageEditor.ToolBarSettings.SubItemToolbarHeight = 70;
            imageEditor.ItemSelected += ImageEditor_ItemSelected;
            imageEditor.ToolBarSettings.ToolbarItemSelected += OnToolbarItemSelected;
            imageEditor.Image = image;
            this.View.AddSubview(imageEditor);

        }
        private void ImageEditor_ItemSelected(object sender, ItemSelectedEventArgs args)
        {
            if (args.Settings != null && args.Settings is CustomViewSettings)
            {
                customViewSettings = args.Settings as CustomViewSettings;
            }
        }
        private void OnToolbarItemSelected(object sender, ToolbarItemSelectedEventArgs e)
        {
            string text = string.Empty; //e.ToolbarItem.Name;
            if (text != "back")
            {
                if (e.ToolbarItem is FooterToolbarItem)
                {
                    text = e.ToolbarItem.Text;
                    e.MoveSubItemsToFooterToolbar = true;
                }
                else if (e.ToolbarItem is CustomToolbarItem)
                    text = (e.ToolbarItem as CustomToolbarItem).CustomName;
                else
                    text = e.ToolbarItem.Text;

                if (text == "Replace")
                {
                    isReplaced = true;
                    //imageEditor.ToolbarSettings.FooterToolbarHeight = 70;
                }
                else if (text == "back")
                {
                    isReplaced = false;
                    //imageEditor.ToolbarSettings.FooterToolbarHeight = 50;
                }
                else if (text == "Add")
                {
                    isReplaced = false;
                    //imageEditor.ToolbarSettings.FooterToolbarHeight = 70;
                }
                if (isReplaced && imageEditor.IsSelected && (text == "Typogy1" ||
                    text == "Typogy2" || text == "Typogy3" || text == "Typogy4" || text == "Typogy5" ||  text == "Typogy6"))
                {
                    imageEditor.Delete();
                    AddImage(text);
                }
                else if (text == "Typogy1" ||
                    text == "Typogy2" || text == "Typogy3" || text == "Typogy4" || text == "Typogy5" ||  text == "Typogy6")
                    AddImage(text);
                if (text == "Bring Front")
                    imageEditor.BringToFront();
                else if (text == "Send Back")
                    imageEditor.SendToBack();
            }
            else
            {
                isReplaced = false;
            }
        }

        private void AddImage(string text)
        {
            imageName = text;

            CustomWebView webView = new CustomWebView()
            {
                Frame = new CGRect(0, 0, 150, 150),

            };
            var path = NSBundle.MainBundle.PathForResource("Images/ImageEditor/" + imageName, "svg");
            var url = new NSUrl(path);
            var urlreq = new NSUrlRequest(url);
            webView.LoadRequest(urlreq);
           
             if (isReplaced)
             {
                if(customViewSettings!=null)
                imageEditor.AddCustomView(webView, new CustomViewSettings() { Bounds = customViewSettings.Bounds });
           
             }
            else
            {
                imageEditor.AddCustomView(webView, new CustomViewSettings() { });
            }

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
    public class CustomWebView : UIWebView
    {
        public CustomWebView()
        {

            BackgroundColor = UIColor.Clear;
            Opaque = false;
            UserInteractionEnabled = false;
            ScalesPageToFit = false;

        }
        public override CGRect Frame
        {
            get
            {
                return base.Frame;
            }
            set
            {
                var tempFrame = base.Frame;
                base.Frame = new CGRect(0,0,Math.Round(value.Width),Math.Round(value.Height));
                if (tempFrame != value && value != CGRect.Empty)
                    UpdateScrollViewFrame();
            }
        }

        void UpdateScrollViewFrame()
        {
            if (ScrollView != null)
            {
                ScrollView.Frame = new CGRect(0, 0, Frame.Width, Frame.Height);
                ScrollView.ContentSize = new CGSize(Frame.Width, Frame.Height);
                if (ScrollView.Subviews.Length > 0)
                {
                    ScrollView.Subviews[0].Frame = new CGRect(0, 0, Frame.Width, Frame.Height);
                }
            }

        }
    }
    public class CustomToolbarItem : ToolbarItem
    {
        public string CustomName { get; set; }
        public CustomToolbarItem()
        {

        }
    }
}

