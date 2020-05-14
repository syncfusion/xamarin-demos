#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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


		public ImageEditor()
		{

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
			UIView mainView = new UIView();
			nfloat TotalWidth = Frame.Width - 20;
			int height=150;
			mainView.Frame = new CGRect(0, 0,TotalWidth, Frame.Height);


			/*------Header Label-------*/

			UILabel label = new UILabel(new CGRect(20, 50, TotalWidth, 25));
			label.BackgroundColor = UIColor.Clear;
			label.Font = UIFont.SystemFontOfSize(25);
			label.TextAlignment = UITextAlignment.Left;
			label.TextColor = UIColor.Gray;
			label.Text = "Sample Pictures";


			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
			  height=200;
			}
			UIButton imageView1 = new UIButton(new CGRect(0, 100, TotalWidth / 3, height));
			imageView1.SetImage(UIImage.FromBundle("Images/ImageEditor/image2.png"), UIControlState.Normal);
			imageView1.ImageView.ContentMode = UIViewContentMode.ScaleToFill;
			imageView1.TouchDown += (sender, e) =>
			{

				navigationController.PushViewController(new ImageEditorViewController(imageView1.CurrentImage), false);

			};

			mainView.AddSubview(imageView1);

               
            
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
			  height=200;
			}
			UIButton imageView2 = new UIButton(new CGRect(TotalWidth / 3, 100, TotalWidth / 3, height));
			imageView2.SetImage(UIImage.FromBundle("Images/ImageEditor/image3.png"), UIControlState.Normal);
			imageView2.ImageView.ContentMode = UIViewContentMode.ScaleToFill;
			mainView.AddSubview(imageView2);

			imageView2.TouchDown += (sender, e) =>
			{

				navigationController.PushViewController(new ImageEditorViewController(imageView2.CurrentImage), false);

			};

            
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
			  height=200;
			}
			UIButton imageView3 = new UIButton(new CGRect(2 * (TotalWidth / 3), 100, TotalWidth/ 3, height));
			imageView3.SetImage(UIImage.FromBundle("Images/ImageEditor/image4.png"), UIControlState.Normal);
			imageView3.ImageView.ContentMode = UIViewContentMode.ScaleToFill;
			imageView3.TouchDown += (sender, e) =>
			{

				navigationController.PushViewController(new ImageEditorViewController(imageView3.CurrentImage), false);

			};
			mainView.AddSubview(imageView3);

			AddSubview(label);
			AddSubview(mainView);

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