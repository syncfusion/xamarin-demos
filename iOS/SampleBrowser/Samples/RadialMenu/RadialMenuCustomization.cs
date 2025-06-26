#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using CoreGraphics;
using Syncfusion.SfRadialMenu.iOS;
using UIKit;

namespace SampleBrowser
{
	public class RadialMenuCustomization : SampleView
	{
		UIView centerView;
		UIImageView centerImage;
		SfRadialMenu radialMenu;
		CustomDrawing drawingTool;
		UIView colorPaletteView;
		UILabel startUpLabel;
		bool isEraserSelected;
		UIColor tempColor;

		void DrawingTool_Tapped(object sender, EventArgs e)
		{
			startUpLabel.Hidden = true;
		}

		void HandleEventHandler(object sender, EventArgs e)
		{
			tempColor = (sender as UIButton).BackgroundColor;
			if (isEraserSelected)
				drawingTool.PenColor = UIColor.White;
			else
				drawingTool.PenColor = tempColor;
		}
		static Random rand = new Random();
		public static UIColor GetRandomColor()
		{

			UIColor color = UIColor.FromRGB(
				rand.Next(255),
				rand.Next(255),
				rand.Next(255));
			return color;
		}
		public RadialMenuCustomization()
		{
			tempColor = GetRandomColor();
			isEraserSelected = false;
			colorPaletteView = new UIView();
			colorPaletteView.BackgroundColor = UIColor.FromRGB(230, 230, 230);
			nfloat elementCount = UIScreen.MainScreen.Bounds.Width / 30;
			nfloat xPos = 5;
			for (int i = 0; i < elementCount; i++)
			{
				UIButton button = new UIButton();
				button.Tag = 1000 + i;
				button.Layer.CornerRadius = 15;
				button.Frame = new CGRect(xPos, 5, 30, 30);
				button.BackgroundColor = GetRandomColor();
				button.AddTarget(HandleEventHandler, UIControlEvent.TouchDown);
				colorPaletteView.Add(button);
				xPos += 40;
			}
			startUpLabel = new UILabel();
			startUpLabel.Text = "Touch to draw";
			startUpLabel.TextColor = UIColor.FromRGB(0, 191, 255);
			startUpLabel.TextAlignment = UITextAlignment.Center;
			startUpLabel.BackgroundColor = UIColor.Clear;

			radialMenu = new SfRadialMenu();
			radialMenu.IsDragEnabled = false;
			radialMenu.RimRadius = 120;
			radialMenu.CenterButtonRadius = 40;
			radialMenu.CenterButtonBorderThickness = 0;
			radialMenu.CenterButtonBorderColor = UIColor.Clear;
			radialMenu.CenterButtonBackgroundColor = UIColor.Clear;
			radialMenu.EnableRotation = true;
			radialMenu.RimColor = UIColor.Clear;
			radialMenu.SeparatorThickness = 10;
			radialMenu.SeparatorColor = UIColor.Clear;
			centerView = new UIView();
			centerView.Frame = new CGRect(0, 0, 80, 80);
			centerImage = new UIImageView();
			centerImage.Image = UIImage.FromBundle("blue.png");
			centerImage.Frame = new CGRect(0, 0, 80, 80);
			centerView.Add(centerImage);
			UILabel centerLabel = new UILabel();
			centerLabel.Frame = new CGRect(0, 5, 80, 80);
			centerLabel.Text = "U";
			centerLabel.TextAlignment = UITextAlignment.Center;
			centerLabel.Font = UIFont.FromName("ios", 30);
			centerLabel.TextColor = UIColor.White;
			centerView.Add(centerLabel);
			radialMenu.EnableCenterButtonAnimation = false;
			radialMenu.CenterButtonView = centerView;

			UIView penView = new UIView();
			penView.Frame = new CGRect(0, 0, 80, 80);
			UIImageView penImage = new UIImageView();
			penImage.Image = UIImage.FromBundle("green.png");
			penImage.Frame = new CGRect(0, 0, 80, 80);
			penView.Add(penImage);
			UILabel penLabel = new UILabel();
			penLabel.Frame = new CGRect(0, 5, 80, 80);
			penLabel.Text = "L";
			penLabel.TextAlignment = UITextAlignment.Center;
			penLabel.Font = UIFont.FromName("ios", 30);
			penLabel.TextColor = UIColor.White;
			penView.Add(penLabel);
			SfRadialMenuItem pen = new SfRadialMenuItem() { Height = 80, Width = 80, View = penView, BackgroundColor = UIColor.Clear };
			pen.ItemTapped += Pen_ItemTapped;
			radialMenu.Items.Add(pen);

			UIView brushView = new UIView();
			brushView.Frame = new CGRect(0, 0, 80, 80);
			UIImageView brushImage = new UIImageView();
			brushImage.Image = UIImage.FromBundle("green.png");
			brushImage.Frame = new CGRect(0, 0, 80, 80);
			brushView.Add(brushImage);
			UILabel brushLabel = new UILabel();
			brushLabel.Frame = new CGRect(0, 5, 80, 80);
			brushLabel.Text = "A";
			brushLabel.TextAlignment = UITextAlignment.Center;
			brushLabel.Font = UIFont.FromName("ios", 30);
			brushLabel.TextColor = UIColor.White;
			brushView.Add(brushLabel);
			SfRadialMenuItem brush = new SfRadialMenuItem() { Height = 80, Width = 80, View = brushView, BackgroundColor = UIColor.Clear };
			brush.ItemTapped += Brush_ItemTapped;
			radialMenu.Items.Add(brush);

			UIView eraserView = new UIView();
			eraserView.Frame = new CGRect(0, 0, 80, 80);
			UIImageView eraserImage = new UIImageView();
			eraserImage.Image = UIImage.FromBundle("green.png");
			eraserImage.Frame = new CGRect(0, 0, 80, 80);
			eraserView.Add(eraserImage);
			UILabel eraserLabel = new UILabel();
			eraserLabel.Frame = new CGRect(0, 5, 80, 80);
			eraserLabel.Text = "R";
			eraserLabel.TextAlignment = UITextAlignment.Center;
			eraserLabel.Font = UIFont.FromName("ios", 30);
			eraserLabel.TextColor = UIColor.White;
			eraserView.Add(eraserLabel);
			SfRadialMenuItem eraser = new SfRadialMenuItem() { Height = 80, Width = 80, View = eraserView, BackgroundColor = UIColor.Clear };
			eraser.ItemTapped += Eraser_ItemTapped;
			radialMenu.Items.Add(eraser);

			UIView removeView = new UIView();
			removeView.Frame = new CGRect(0, 0, 80, 80);
			UIImageView removeImage = new UIImageView();
			removeImage.Image = UIImage.FromBundle("green.png");
			removeImage.Frame = new CGRect(0, 0, 80, 80);
			removeView.Add(removeImage);
			UILabel removeLabel = new UILabel();
			removeLabel.Frame = new CGRect(0, 5, 80, 80);
			removeLabel.Text = "Q";
			removeLabel.TextAlignment = UITextAlignment.Center;
			removeLabel.Font = UIFont.FromName("ios", 30);
			removeLabel.TextColor = UIColor.White;
			removeView.Add(removeLabel);
			SfRadialMenuItem remove = new SfRadialMenuItem() { Height = 80, Width = 80, View = removeView, BackgroundColor = UIColor.Clear };
			remove.ItemTapped += Remove_ItemTapped;
			radialMenu.Items.Add(remove);

			UIView paintView = new UIView();
			paintView.Frame = new CGRect(0, 0, 80, 80);
			UIImageView paintImage = new UIImageView();
			paintImage.Image = UIImage.FromBundle("green.png");
			paintImage.Frame = new CGRect(0, 0, 80, 80);
			paintView.Add(paintImage);
			UILabel paintLabel = new UILabel();
			paintLabel.Frame = new CGRect(0, 5, 80, 80);
			paintLabel.Text = "G";
			paintLabel.TextAlignment = UITextAlignment.Center;
			paintLabel.Font = UIFont.FromName("ios", 30);
			paintLabel.TextColor = UIColor.White;
			paintView.Add(paintLabel);
			SfRadialMenuItem paint = new SfRadialMenuItem() { Height = 80, Width = 80, View = paintView, BackgroundColor = UIColor.Clear };
			paint.ItemTapped += Paint_ItemTapped;
			radialMenu.Items.Add(paint);

			UIView paintBoxView = new UIView();
			paintBoxView.Frame = new CGRect(0, 0, 80, 80);
			UIImageView paintBoxImage = new UIImageView();
			paintBoxImage.Image = UIImage.FromBundle("green.png");
			paintBoxImage.Frame = new CGRect(0, 0, 80, 80);
			paintBoxView.Add(paintBoxImage);
			UILabel paintBoxLabel = new UILabel();
			paintBoxLabel.Frame = new CGRect(0, 5, 80, 80);
			paintBoxLabel.Text = "V";
			paintBoxLabel.TextAlignment = UITextAlignment.Center;
			paintBoxLabel.Font = UIFont.FromName("ios", 30);
			paintBoxLabel.TextColor = UIColor.White;
			paintBoxView.Add(paintBoxLabel);
			SfRadialMenuItem paintBox = new SfRadialMenuItem() { Height = 80, Width = 80, View = paintBoxView, BackgroundColor = UIColor.Clear };
			paintBox.ItemTapped += PaintBox_ItemTapped;
			radialMenu.Items.Add(paintBox);


			if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
					//radialMenu.RimRadius = 250;
				radialMenu.CenterButtonRadius = 50;
				centerLabel.Font = UIFont.FromName("ios", 40);
				pen.IconFont = UIFont.FromName("ios", 40);
				pen.Height = 100;
				pen.Width = 100;
				brush.IconFont = UIFont.FromName("ios", 40);
				brush.Height = 100;
				brush.Width = 100;
				eraser.IconFont = UIFont.FromName("ios", 40);
				eraser.Height = 100;
				eraser.Width = 100;
				remove.Height = 100;
				remove.Width = 100;
				remove.IconFont = UIFont.FromName("ios", 40);
				paintBox.Height = 100;
				paintBox.Width = 100;
				paintBox.IconFont = UIFont.FromName("ios", 40);
				paint.Height = 100;
				paint.Width = 100;
				paint.IconFont = UIFont.FromName("ios", 40);
			}

			drawingTool = new CustomDrawing();
			drawingTool.PenColor = tempColor;
			drawingTool.Tapped += DrawingTool_Tapped;
			this.ClipsToBounds = true;
			this.Add(drawingTool);
			this.Add(startUpLabel);
			this.Add(colorPaletteView);
			this.Add(radialMenu);
		}

		void Pen_ItemTapped(object sender, EventArgs e)
		{
			isEraserSelected = false;
			drawingTool.LineWidth = 1;
			drawingTool.PenColor = tempColor;
			radialMenu.Close();
		}

		void Brush_ItemTapped(object sender, EventArgs e)
		{
			isEraserSelected = false;
			drawingTool.LineWidth = 10;
			drawingTool.PenColor = tempColor;
			radialMenu.Close();
		}

		void Remove_ItemTapped(object sender, EventArgs e)
		{
			isEraserSelected = false;
			drawingTool.Clear();
			drawingTool.BackgroundColor = UIColor.White;
			radialMenu.Close();
		}

		void Paint_ItemTapped(object sender, EventArgs e)
		{
			isEraserSelected = false;
			drawingTool.LineWidth = 60;
			drawingTool.PenColor = tempColor;
			radialMenu.Close();
		}

		void PaintBox_ItemTapped(object sender, EventArgs e)
		{
			isEraserSelected = false;
			drawingTool.BackgroundColor = tempColor;
			radialMenu.Close();
		}

		void Eraser_ItemTapped(object sender, EventArgs e)
		{
			isEraserSelected = true;
			drawingTool.LineWidth = 30;
			drawingTool.PenColor = UIColor.White;
			radialMenu.Close();
		}

		public override void LayoutSubviews()
		{
			foreach (var view in this.Subviews)
			{
				if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
				{
					radialMenu.Position = new CGPoint(Frame.Width / 2, Frame.Height);
					drawingTool.Frame = new CGRect(0, 0, Frame.Width, Frame.Height);
					startUpLabel.Frame = new CGRect(0, Frame.Height / 2 - 15, Frame.Width, 30);
					colorPaletteView.Frame = new CGRect(0, 0, Frame.Width, 40);
				}
				else
				{
					radialMenu.Position = new CGPoint(Frame.Width / 2, Frame.Height);
					drawingTool.Frame = new CGRect(0, 0, Frame.Width, Frame.Height);
					startUpLabel.Frame = new CGRect(0, Frame.Height / 2 - 15, Frame.Width, 30);
					colorPaletteView.Frame = new CGRect(0, 0, Frame.Width, 40);
				}
			}
			base.LayoutSubviews();
		}
	}
}

