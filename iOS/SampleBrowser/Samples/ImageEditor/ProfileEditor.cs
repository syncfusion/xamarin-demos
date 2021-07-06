#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Threading.Tasks;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using Syncfusion.SfImageEditor.iOS;
using UIKit;

namespace SampleBrowser
{
    public class ProfileEditor : SampleView
    {
        UIView mainView;
        
        UINavigationController navigationController;

        UIImageView imageView;

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            mainView = new UIView();
            mainView.Frame = new CGRect(0, 0, Frame.Width, Frame.Height);

            UIStackView profileView = new UIStackView();
            var height = mainView.Frame.Height * 0.45;
            profileView.Frame = new CoreGraphics.CGRect(0, 0, mainView.Frame.Width, height);
            profileView.Axis = UILayoutConstraintAxis.Vertical;

            CAGradientLayer gradientLayer = new CAGradientLayer();
            gradientLayer.Frame = profileView.Frame;
            gradientLayer.Colors = new CGColor[] { UIColor.FromRGB(115, 218,240).CGColor,
                UIColor.FromRGB(0, 113, 138).CGColor };
            gradientLayer.StartPoint = new CGPoint(0, 0);
            gradientLayer.EndPoint = new CGPoint(0, 1);
            profileView.Layer.AddSublayer(gradientLayer);

            var height1 = profileView.Frame.Height * 0.25;
            var height2 = profileView.Frame.Height * 0.5;
            var height3 = profileView.Frame.Height * 0.25;

            UILabel label = new UILabel(new CGRect(20, 0, profileView.Frame.Width, height1));
            label.BackgroundColor = UIColor.Clear;
            label.Font = UIFont.SystemFontOfSize(25);
            label.TextColor = UIColor.Black;
            label.TextAlignment = UITextAlignment.Left;
            label.Text = "Profile";
            profileView.Add(label);

            imageView = new UIImageView();
            imageView.ContentMode = UIViewContentMode.ScaleAspectFit;
            imageView.Frame = new CoreGraphics.CGRect(0, label.Frame.Bottom, profileView.Frame.Width, height2);
            imageView.Image = UIImage.FromBundle("Images/ImageEditor/Profile.png");
            profileView.Add(imageView);

            UIButton button = new UIButton();
            button.SetTitle("Edit Image", UIControlState.Normal);
            var size = imageView.SizeThatFits(CGSize.Empty);

            button.Frame = new CoreGraphics.CGRect(profileView.Frame.Width / 2 - size.Width / 4, imageView.Frame.Bottom + 20, size.Width / 2, height3 / 2);
            button.VerticalAlignment = UIControlContentVerticalAlignment.Center;
            button.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            button.BackgroundColor = UIColor.Clear;
            button.Font = UIFont.SystemFontOfSize(20);
            button.Layer.CornerRadius = 20;
            button.Layer.BorderColor = UIColor.White.CGColor;
            button.Layer.BorderWidth = 2;
            button.SetTitleColor(UIColor.White, UIControlState.Normal);
            button.TouchDown += (sender, e) =>
            {
                navigationController.PushViewController(new ProfileViewController(imageView.Image, navigationController, imageView), false);
            };
            profileView.Add(button);
            mainView.AddSubview(profileView);

            UIView detailsView = new UIView();
            detailsView.Frame = new CGRect(0, profileView.Frame.Bottom, mainView.Frame.Width, mainView.Frame.Height * 0.55);
            
            previousTop = 0;

            for (int i = 0; i < 4; i++)
            {
                UIView itemView = CreateView(detailsView, i);
                detailsView.Add(itemView);
            }

            mainView.AddSubview(detailsView);
            AddSubview(mainView);
        }

        double previousTop;

        private UIView CreateView(UIView detailsView, int index)
        {
            var itemHeight = detailsView.Frame.Height / 5;
            var iconsWidth = detailsView.Frame.Width * 0.2;
            var detailsWidth = detailsView.Frame.Width * 0.8;
            var padding = 5;

            previousTop = index * itemHeight;

            UIView nameView = new UIView();
            nameView.Frame = new CGRect(0, previousTop, mainView.Frame.Width, itemHeight);

            UIImageView icon = new UIImageView();
            icon.BackgroundColor = UIColor.Clear;
            icon.ContentMode = UIViewContentMode.ScaleAspectFit;
            icon.Frame = new CGRect(0, itemHeight /4, iconsWidth, itemHeight / 2);

            UILabel name = new UILabel();
            name.Font = UIFont.SystemFontOfSize(20);
            name.TextColor = UIColor.Gray;
            name.TextAlignment = UITextAlignment.Left;
            name.Frame = new CGRect(icon.Frame.Right + padding, 10, detailsWidth, itemHeight / 3);

            UILabel profileName = new UILabel();
            profileName.Font = UIFont.SystemFontOfSize(24);
            profileName.TextColor = UIColor.Black;
            profileName.TextAlignment = UITextAlignment.Left;
            profileName.Frame = new CGRect(icon.Frame.Right + padding, name.Frame.Bottom, detailsWidth, itemHeight / 2);

            UIView border = new UIView();
            border.Layer.BorderWidth = 1;
            border.Layer.BorderColor = UIColor.Gray.CGColor;
            border.Frame = new CGRect(icon.Frame.Right + padding, profileName.Frame.Bottom, detailsWidth, 1);


            if (index == 0)
            {
                icon.Image = UIImage.FromBundle("Images/ImageEditor/LabelContactName.png");
                name.Text = "Name";
                profileName.Text = "Alison Doody";
            }
            else if (index == 1)
            {
                icon.Image = UIImage.FromBundle("Images/ImageEditor/Email.png");
                name.Text = "Email";
                profileName.Text = "alison.doody@syncfusion.com";
            }
            else if (index == 2)
            {
                icon.Image = UIImage.FromBundle("Images/ImageEditor/Phone.png");
                name.Text = "Phone";
                profileName.Text = "+1-123-456-7890";
            }
            else if (index == 3)
            {
                icon.Image = UIImage.FromBundle("Images/ImageEditor/Address.png");
                name.Text = "Address";
                profileName.Text = "Avenue 8th street, NW SY";
            }

            nameView.Add(icon);
            nameView.Add(name);
            nameView.Add(profileName);
            nameView.Add(border);

            return nameView;
        }

        public override void MovedToSuperview()
        {
            base.MovedToSuperview();
            var window = UIApplication.SharedApplication.KeyWindow;
            navigationController = window.RootViewController as UINavigationController;
        }
    }

    public class ProfileViewController : UIViewController
    {
        SfImageEditor editor;

        UIImage editorImage;

        UINavigationController controller;

        UIImageView profilePicture;

        public ProfileViewController(UIImage image, UINavigationController navigationController, UIImageView imageView)
        {
            editorImage = image;
            controller = navigationController;
            profilePicture = imageView;
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            editor = new SfImageEditor(new CGRect(View.Frame.Location.X, 60, View.Frame.Size.Width, View.Frame.Size.Height - 60));
            editor.ImageLoaded += Editor_ImageLoaded;
            editor.Image = editorImage;
            this.View.AddSubview(editor);

            editor.ToolBarSettings.ToolbarItems.Add(new FooterToolbarItem() { Text = "Crop" });
            editor.SetToolbarItemVisibility("Text, Shape, Brightness, Effects, Bradley Hand, Path, 3:1, 3:2, 4:3, 5:4, 16:9, Undo, Redo, Transform", false);
            editor.ImageSaving += Editor_ImageSaving;
            editor.ToolBarSettings.ToolbarItemSelected += ToolBarSettings_ToolbarItemSelected;
        }

        private void Editor_ImageSaving(object sender, ImageSavingEventArgs e)
        {
            e.Cancel = true;
            var imageData = NSData.FromStream(e.Stream);
            profilePicture.Image = UIImage.LoadFromData(imageData);
            controller.PopViewController(false);
        }

        private void Editor_ImageSaved(object sender, ImageSavedEventArgs e)
        {
            controller.PopViewController(false);
        }

        private void ToolBarSettings_ToolbarItemSelected(object sender, ToolbarItemSelectedEventArgs e)
        {
            if (e.ToolbarItem.Text == "Crop")
            {
                editor.ToggleCropping(true, 3);
                e.Cancel = true;
            }
        }

        private async void Editor_ImageLoaded(object sender, ImageLoadedEventArgs e)
        {
            await Task.Delay(25);
            editor.ToggleCropping(true, 3);
        }
    }
}
