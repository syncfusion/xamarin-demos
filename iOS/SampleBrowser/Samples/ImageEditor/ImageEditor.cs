#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfImageEditor.iOS;
using Foundation;
using UIKit;
using CoreGraphics;
using System.Drawing;

namespace SampleBrowser
{
	public partial class ImageEditor : SampleView
	{

		UINavigationController navigationController;
        UIView mainView;
        UILabel label;
        UIButton imageView1,imageView2, imageView3;
     
        public ImageEditor()
		{
            mainView = new UIView();
            nfloat TotalWidth = Frame.Width - 20;
            int height = 150;
            mainView.Frame = new CGRect(0, 0, TotalWidth, Frame.Height);


            /*------Header Label-------*/

            label = new UILabel(new CGRect(20, 50, TotalWidth, 25));
            label.BackgroundColor = UIColor.Clear;
            label.Font = UIFont.SystemFontOfSize(25);
            label.TextAlignment = UITextAlignment.Left;
            label.TextColor = UIColor.Gray;
            label.Text = "Sample Pictures";


            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                height = 200;
            }


            float renderWidth = (float)(TotalWidth / 3);
             imageView1 = new UIButton(new CGRect(0, 100, TotalWidth / 3, height));
            imageView1.SetImage(UIImage.FromBundle("Images/ImageEditor/image2.png"), UIControlState.Normal);
            imageView1.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
            float renderHeight = GetImageHeight(imageView1, renderWidth);
            imageView1.Frame = new CGRect(0, 100, renderWidth, renderHeight);
            imageView1.TouchDown += (sender, e) =>
            {

                navigationController.PushViewController(new ImageEditorViewController(imageView1.CurrentImage), false);

            };

            mainView.AddSubview(imageView1);



            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                height = 200;
            }

             imageView2 = new UIButton(new CGRect(TotalWidth / 3, 100, TotalWidth / 3, height));
            imageView2.SetImage(UIImage.FromBundle("Images/ImageEditor/image3.png"), UIControlState.Normal);
            imageView2.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
            float renderHeight1 = GetImageHeight(imageView2, renderWidth);
            imageView2.Frame = new CGRect(TotalWidth / 3, 100, renderWidth, renderHeight1);

            mainView.AddSubview(imageView2);

            imageView2.TouchDown += (sender, e) =>
            {

                navigationController.PushViewController(new ImageEditorViewController(imageView2.CurrentImage), false);

            };


            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                height = 200;
            }

             imageView3 = new UIButton(new CGRect(2 * (TotalWidth / 3), 100, TotalWidth / 3, height));
            imageView3.SetImage(UIImage.FromBundle("Images/ImageEditor/image4.png"), UIControlState.Normal);
            imageView3.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
            float renderHeight2 = GetImageHeight(imageView3, renderWidth);
            imageView3.Frame = new CGRect((2 * TotalWidth / 3), 100, renderWidth, renderHeight2);
            imageView3.TouchDown += (sender, e) =>
            {

                navigationController.PushViewController(new ImageEditorViewController(imageView3.CurrentImage), false);

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
            float renderWidth = (float)(TotalWidth / 3);
            label.Frame = new CGRect(20, 50, TotalWidth, 25);
            float renderHeight1 = GetImageHeight(imageView1, renderWidth);
            imageView1.Frame = new CGRect(0, 100, renderWidth, renderHeight1);
            float renderHeight2 = GetImageHeight(imageView2, renderWidth);
            imageView2.Frame = new CGRect(( TotalWidth / 3), 100, renderWidth, renderHeight2);
            float renderHeight3 = GetImageHeight(imageView3, renderWidth);
            imageView3.Frame = new CGRect((2 * TotalWidth / 3), 100, renderWidth, renderHeight3);

		}
        private float GetImageHeight(UIButton button,float renderWidth)
        {
            float originalWidth = (float)button.ImageView.Image.Size.Width;

            float originalHeight = (float)button.ImageView.Image.Size.Height;

            float renderedHeight = (renderWidth * originalHeight) / originalWidth;
           
            return renderedHeight;
        }

	}

	public class ImageEditorViewController : UIViewController
	{
		UIImage _image;

		public ImageEditorViewController(UIImage image)
		{
			_image = image;
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			SfImageEditor sfImageEditor = new SfImageEditor(new CGRect(View.Frame.Location.X, 60, View.Frame.Size.Width, View.Frame.Size.Height - 60));
			sfImageEditor.Image = _image;
			this.View.Add(sfImageEditor);
		}
	}

}