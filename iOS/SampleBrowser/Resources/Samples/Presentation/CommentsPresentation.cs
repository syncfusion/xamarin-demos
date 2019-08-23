#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.Presentation;
using System.IO;
using COLOR = Syncfusion.Drawing;
using System.Reflection;
using Syncfusion.OfficeChart;
#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using CGRect = System.Drawing.RectangleF;
using CGPoint = System.Drawing.PointF;
using CGSize = System.Drawing.SizeF;
#endif
namespace SampleBrowser
{
	public partial class CommentsPresentation : SampleView
	{
		CGRect frameRect = new CGRect();
		float frameMargin = 8.0f;
		UILabel label;
		UILabel label1;
		UILabel label2;
		UIButton button;
		public CommentsPresentation()
		{

			label2 = new UILabel();
			label1 = new UILabel();
			label = new UILabel();
			button = new UIButton(UIButtonType.System);
			button.TouchUpInside += OnButtonClicked;
		}

		void LoadAllowedTextsLabel()
		{
			label.Frame = frameRect;
			label.TextColor = UIColor.FromRGB(38 / 255.0f, 38 / 255.0f, 38 / 255.0f);
			label.Text = "This sample demonstrates how to create comments in PowerPoint slides using Presentation library.";
			label.Font = UIFont.SystemFontOfSize(15);
			label.Lines = 0;
			label.LineBreakMode = UILineBreakMode.WordWrap;
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
				label.Font = UIFont.SystemFontOfSize(18);
				label.Frame = new CGRect(0, 10, frameRect.Location.X + frameRect.Size.Width, 120);
			}
			else
			{
				label.Frame = new CGRect(frameRect.Location.X, 10, frameRect.Size.Width, 120);

			}
			this.AddSubview(label);

			label2.Frame = frameRect;
			label2.TextColor = UIColor.FromRGB(38 / 255.0f, 38 / 255.0f, 38 / 255.0f);
			label2.Text = "Please click the Generate Presentation button to save and view the generated PowerPoint Presentation.";
			label2.Font = UIFont.SystemFontOfSize(15);
			label2.Lines = 0;
			label2.LineBreakMode = UILineBreakMode.WordWrap;
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
				label2.Font = UIFont.SystemFontOfSize(18);
				label2.Frame = new CGRect(0, 190, frameRect.Location.X + frameRect.Size.Width, 50);
			}
			else
			{
				label2.Frame = new CGRect(frameRect.Location.X, 190, frameRect.Size.Width, 50);

			}
			this.AddSubview(label2);

			button.SetTitle("Generate Presentation", UIControlState.Normal);
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
				button.Frame = new CGRect(0, 290, frameRect.Location.X + frameRect.Size.Width, 10);
			}
			else
			{
				button.Frame = new CGRect(frameRect.Location.X, 260, frameRect.Size.Width, 10);

			}
			this.AddSubview(button);
		}




		void OnButtonClicked(object sender, EventArgs e)
		{
			string resourcePath = "SampleBrowser.Samples.Presentation.Templates.Images.pptx";
			Assembly assembly = Assembly.GetExecutingAssembly();
			Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

			IPresentation presentation = Presentation.Open(fileStream);

			//  Method call to create slides
            CommentsHelper.SlideWithComments1(presentation);
            CommentsHelper.SlideWithComments2(presentation);
            CommentsHelper.SlideWithComments3(presentation);

			MemoryStream stream = new MemoryStream();
			presentation.Save(stream);
			presentation.Close();
			stream.Position = 0;

			if (stream != null)
			{
				SaveiOS iOSSave = new SaveiOS();
				iOSSave.Save("CommentsPresentation.pptx", "application/mspowerpoint", stream);
			}

		}

		public override void LayoutSubviews()
		{
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
				frameMargin = 0.0f;
			}
			frameRect = Bounds;
			frameRect.Location = new CGPoint(frameRect.Location.X + frameMargin, frameRect.Location.Y + 1.5f * frameMargin);
			frameRect.Size = new CGSize(frameRect.Size.Width - (frameRect.Location.X + frameMargin), frameRect.Size.Height - (frameRect.Location.Y + 1.5f * frameMargin));

			LoadAllowedTextsLabel();

			base.LayoutSubviews();
		}
	}
}
