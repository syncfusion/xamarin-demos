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
using Photos;
using System.IO;

namespace SampleBrowser
{
	public class ImageEditorCustomization : SampleView
	{
		bool isReset, isUndo, isRedo, isRect, isText, isPath = false;
		UIView RightView;
		UIView overView;
		UIView topView;
		SfImageEditor sfImageEditor;
		Object settings;
		UITextField textView;
		UIViewController presentController;
		public ImageEditorCustomization()
		{
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			presentController = GetVisibleViewController();
			UIView mainView = new UIView();
			mainView.Frame = new CGRect(0, 0, Frame.Width, Frame.Height);
			mainView.BackgroundColor = UIColor.Clear;
			sfImageEditor = new SfImageEditor(new CGRect(mainView.Frame.X, mainView.Frame.Y, mainView.Frame.Width, mainView.Frame.Height));
			sfImageEditor.Image = UIImage.FromBundle("Images/ImageEditor/Customize.jpg");
			sfImageEditor.BackgroundColor = UIColor.Black;
			sfImageEditor.ToolBarSettings.IsVisible = false;
			//settings = new Object();
			sfImageEditor.ItemSelected += (object sender, ItemSelectedEventArgs e) => 
			{
				RightView.Alpha = 1;
				settings = e.Settings;
			};
			mainView.AddSubview(sfImageEditor);

			/*--------------------------------------------------*/
			//TopView

			topView = new UIView();
			topView.Frame = new CGRect(0, 15, Frame.Width, 25);
			topView.Alpha = 0;

			UIButton reset = new UIButton(new CGRect(0, 0, Frame.Width / 6, 25));
			reset.BackgroundColor = UIColor.Clear;
			reset.SetImage(UIImage.FromBundle("Images/ImageEditor/reset_customization.png"), UIControlState.Normal);
			reset.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
			reset.TouchUpInside += Reset_TouchUpInside;
			topView.AddSubview(reset);

			UIButton redo = new UIButton(new CGRect(Frame.Width / 6, 0, Frame.Width / 6, 25));
			redo.BackgroundColor = UIColor.Clear;
			redo.SetImage(UIImage.FromBundle("Images/ImageEditor/redo_customization.png"), UIControlState.Normal);
			redo.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
			redo.TouchUpInside += Redo_TouchUpInside;
			redo.Alpha = 0;
			topView.AddSubview(redo);

			UIButton undo = new UIButton(new CGRect(2 * (Frame.Width / 6), 0, Frame.Width / 6, 25));
			undo.BackgroundColor = UIColor.Clear;
			undo.SetImage(UIImage.FromBundle("Images/ImageEditor/undo_customization.png"), UIControlState.Normal);
			undo.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
			undo.TouchUpInside += Undo_TouchUpInside;
			topView.AddSubview(undo);

			UIButton rect = new UIButton(new CGRect(3 * (Frame.Width / 6), 0, Frame.Width / 6, 25));
			rect.BackgroundColor = UIColor.Clear;
			rect.SetImage(UIImage.FromBundle("Images/ImageEditor/rect_customization.png"), UIControlState.Normal);
			rect.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
			rect.TouchUpInside += Rect_TouchUpInside;
			topView.AddSubview(rect);

			UIButton text = new UIButton(new CGRect(4 * (Frame.Width / 6), 0, Frame.Width / 6, 25));
			text.BackgroundColor = UIColor.Clear;
			text.SetImage(UIImage.FromBundle("Images/ImageEditor/text_customization.png"), UIControlState.Normal);
			text.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
			text.TouchUpInside += Text_TouchUpInside;
			topView.AddSubview(text);

			UIButton path = new UIButton(new CGRect(5 * (Frame.Width / 6), 0, Frame.Width / 6, 25));
			path.BackgroundColor = UIColor.Clear;
			path.SetImage(UIImage.FromBundle("Images/ImageEditor/pen_customization.png"), UIControlState.Normal);
			path.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
			path.TouchUpInside += Path_TouchUpInside;
			topView.AddSubview(path);

			mainView.AddSubview(topView);

			/*----------------------------------------------------------*/
			//BottomView

			UIView bottomView = new UIView();
			bottomView.Frame = new CGRect(10, Frame.Height - 50, Frame.Width, 30);
			bottomView.BackgroundColor = UIColor.Clear;

			textView = new UITextField(new CGRect(20, 0, Frame.Width - 100, 30));
			textView.Layer.CornerRadius = 10.0f;
			textView.Layer.BorderColor = UIColor.White.CGColor;
			textView.Layer.BorderWidth = 2;

			textView.TextColor = UIColor.White;
			textView.Placeholder = "Enter a Caption";
			textView.Enabled = true;
			textView.ResignFirstResponder();
			textView.MultipleTouchEnabled = true;
			bottomView.AddSubview(textView);

			UIButton share = new UIButton(new CGRect(Frame.Width - 70, 0, 50, 30));
			share.BackgroundColor = UIColor.Clear;
			share.SetImage(UIImage.FromBundle("Images/ImageEditor/share_customization.png"), UIControlState.Normal);
			share.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
			share.TouchUpInside += Share_TouchUpInside;
			bottomView.AddSubview(share);
			mainView.AddSubview(bottomView);

			/*--------------------------------------------------*/

			//RightView
			RightView = new UIView();
			RightView.Frame = new CGRect(Frame.Width - 50, 20, 30, Frame.Height );
			RightView.BackgroundColor = UIColor.Clear;

			//Color Collection
			UIColor[] array = new UIColor[10]{ UIColor.FromRGB(68,114,196)
											  ,UIColor.FromRGB(237,125,49)
											  ,UIColor.FromRGB(255,192,0)
											  ,UIColor.FromRGB(112,173,71)
											  ,UIColor.FromRGB(91,155,213)
											  ,UIColor.FromRGB(193,193,193)
											  ,UIColor.FromRGB(111,111,226)
											  ,UIColor.FromRGB(226,105,174)
											  ,UIColor.FromRGB(158,72,14)
											  ,UIColor.FromRGB(153,115,0)
											  };

			int y = (int)(this.Frame.Height / 2)-175;
			for (int i = 0; i < 10; i++)
			{
				UIButton colorButton = new UIButton();
				colorButton.Frame = new CGRect(3, y + 5, 25, 25);
				colorButton.Layer.CornerRadius = 10;
				y = y + 30;
				colorButton.BackgroundColor = array[i];
				colorButton.TouchUpInside += ColorButton_TouchUpInside;
				RightView.Add(colorButton);
			}

			mainView.AddSubview(RightView);
			RightView.Alpha = 0;

			overView = new UIView();
			overView.Frame = new CGRect(0, 0, Frame.Width, Frame.Height);
			overView.BackgroundColor = UIColor.Clear;
			overView.Alpha = 1f;
			UITapGestureRecognizer tapped = new UITapGestureRecognizer(TapCarrierLabel);
			overView.AddGestureRecognizer(tapped);

			AddSubview(mainView);
			AddSubview(overView);
		}
		public void TapCarrierLabel(UITapGestureRecognizer uitgr)
		{
			overView.Alpha = 0;
			topView.Alpha = 1;
		}

		void Path_TouchUpInside(object sender, EventArgs e)
		{
			isPath = true;
			isReset = false;
			isUndo = false;
			isRedo = false;
			isRect = false;
			isText = false;
			if (RightView.Alpha == 0)
				RightView.Alpha = 1;
			else
				RightView.Alpha = 0;
		}

		void Text_TouchUpInside(object sender, EventArgs e)
		{
			settings = null;
			isPath = false;
			isReset = false;
			isUndo = false;
			isRedo = false;
			isRect = false;
			isText = true;
			if (RightView.Alpha == 0)
				RightView.Alpha = 1;
			else
				RightView.Alpha = 0;
				sfImageEditor.AddText("Text",new TextSettings());
		}

		void Rect_TouchUpInside(object sender, EventArgs e)
		{
			settings = null;
			isPath = false;
			isReset = false;
			isUndo = false;
			isRedo = false;
			isRect = true;
			isText = false;
			if (RightView.Alpha == 0)
				RightView.Alpha = 1;
			else
				RightView.Alpha = 0;
			sfImageEditor.AddShape(ShapeType.Rectangle,new PenSettings());
		}

		void Redo_TouchUpInside(object sender, EventArgs e)
		{
			isPath = false;
			isReset = false;
			isUndo = false;
			isRedo = true;
			isRect = false;
			isText = false;
			RightView.Alpha = 0;
			sfImageEditor.Redo();

		}

		void Undo_TouchUpInside(object sender, EventArgs e)
		{
			isPath = false;
			isReset = false;
			isUndo = true;
			isRedo = false;
			isRect = false;
			isText = false;
			RightView.Alpha = 0;
			sfImageEditor.Undo();

		}

		void Reset_TouchUpInside(object sender, EventArgs e)
		{
			isPath = false;
			isReset = true;
			isUndo = false;
			isRedo = false;
			isRect = false;
			isText = false;
			RightView.Alpha = 0;
			sfImageEditor.Reset();
			overView.Alpha = 1;
			topView.Alpha = 0;

		}

		void Share_TouchUpInside(object sender, EventArgs e)
		{
			sfImageEditor.Save();
			sfImageEditor.ImageSaved += SfImageEditor_ImageSaved;
		}

		void ColorButton_TouchUpInside(object sender, EventArgs e)
		{
			var colorSelected = (sender as UIButton).BackgroundColor;
			if (isPath)
			{
				sfImageEditor.AddShape(ShapeType.Path, new PenSettings() { Color = colorSelected });

			}
			if (settings is TextSettings)			{
				
				(settings as TextSettings).Color = colorSelected;
			}
			    if (settings is PenSettings)
			{
				
				(settings as PenSettings).Color = colorSelected;
				//sfImageEditor.AddShape(ShapeType.Rectangle, new PenSettings() { Color = colorSelected, StrokeWidth = 5 });

			}
			RightView.Alpha = 0;
		}

		void SfImageEditor_ImageSaved(object sender, ImageSavedEventArgs e)
		{
			string[] str = e.Location.Split('/');
			PHFetchResult assetResult = PHAsset.FetchAssetsUsingLocalIdentifiers(str, null);
			PHAsset asset = assetResult.firstObject as PHAsset;
			Stream stream = null;
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


}