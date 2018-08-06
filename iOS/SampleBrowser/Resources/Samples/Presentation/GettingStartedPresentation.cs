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
	public partial class GettingStartedPresentation : SampleView
	{
		CGRect frameRect = new CGRect ();
		float frameMargin = 8.0f;
		UILabel label;
		UILabel label2;
		UIButton button;
		public GettingStartedPresentation ()
		{

			label2 = new UILabel();
			label = new UILabel();
			button = new UIButton(UIButtonType.System);
			button.TouchUpInside += OnButtonClicked;
		}

		void LoadAllowedTextsLabel()
		{
			label.Frame = frameRect;
			label.TextColor = UIColor.FromRGB (38/255.0f, 38/255.0f, 38/255.0f);
			label.Text = "This sample demonstrates how to create a PowerPoint presentation by adding text with simple text-formattings using Presentation library";
			label.Font = UIFont.SystemFontOfSize(15);
			label.Lines 				= 0;
			label.LineBreakMode 		= UILineBreakMode.WordWrap;
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				label.Font = UIFont.SystemFontOfSize(18);
				label.Frame = new CGRect (0, 10,frameRect.Location.X + frameRect.Size.Width  , 120);
			} 
			else {
				label.Frame = new CGRect (frameRect.Location.X, 10, frameRect.Size.Width , 120);

			}
			this.AddSubview (label);

			label2.Frame = frameRect;
			label2.TextColor = UIColor.FromRGB (38/255.0f, 38/255.0f, 38/255.0f);
			label2.Text = "Please click the Generate Presentation button to save and view the generated PowerPoint Presentation.";
			label2.Font = UIFont.SystemFontOfSize(15);
			label2.Lines 				= 0;
			label2.LineBreakMode 		= UILineBreakMode.WordWrap;
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				label2.Font = UIFont.SystemFontOfSize(18);
				label2.Frame = new CGRect (0, 190, frameRect.Location.X + frameRect.Size.Width , 50);
			} 
			else {
				label2.Frame = new CGRect (frameRect.Location.X, 190, frameRect.Size.Width , 50);

			}
			this.AddSubview (label2);

			button.SetTitle("Generate Presentation",UIControlState.Normal);
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				button.Frame = new CGRect (0, 290, frameRect.Location.X + frameRect.Size.Width , 10);
			} 
			else {
				button.Frame = new CGRect (frameRect.Location.X, 260, frameRect.Size.Width , 10);

			}
			this.AddSubview (button);
		}




		void OnButtonClicked(object sender, EventArgs e)
		{
			string resourcePath = "SampleBrowser.Samples.Presentation.Templates.HelloWorld.pptx";
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            IPresentation presentation = Presentation.Open(fileStream);

            #region Slide1
            ISlide slide1 = presentation.Slides[0];
            IShape titleShape = slide1.Shapes[0] as IShape;
            titleShape.Left = 0.33 * 72;
            titleShape.Top = 0.58 * 72;
            titleShape.Width = 12.5 * 72;
            titleShape.Height = 1.75 * 72;

            ITextBody textFrame1 = (slide1.Shapes[0] as IShape).TextBody;
            IParagraphs paragraphs1 = textFrame1.Paragraphs;
            IParagraph paragraph = paragraphs1.Add();
            paragraph.HorizontalAlignment = HorizontalAlignmentType.Center;
            ITextPart textPart1 = paragraph.AddTextPart();
            textPart1.Text = "Essential Presentation";
            textPart1.Font.CapsType = TextCapsType.All;
            textPart1.Font.FontName = "Adobe Garamond Pro";
            textPart1.Font.Bold = true;
            textPart1.Font.FontSize = 40;

            IShape subtitle = slide1.Shapes[1] as IShape;
            subtitle.Left = 0.5 * 72;
            subtitle.Top = 3 * 72;
            subtitle.Width = 11.8 * 72;
            subtitle.Height = 1.7 * 72;

            ITextBody textFrame2 = (slide1.Shapes[1] as IShape).TextBody;
            textFrame2.VerticalAlignment = VerticalAlignmentType.Top;
            IParagraphs paragraphs2 = textFrame2.Paragraphs;
            IParagraph para = paragraphs2.Add();
            para.HorizontalAlignment = HorizontalAlignmentType.Left;
            ITextPart textPart2 = para.AddTextPart();
            textPart2.Text = "Lorem ipsum dolor sit amet, lacus amet amet ultricies. Quisque mi venenatis morbi libero, orci dis, mi ut et class porta, massa ligula magna enim, aliquam orci vestibulum tempus.Turpis facilisis vitae consequat, cum a a, turpis dui consequat massa in dolor per, felis non amet.";
            textPart2.Font.FontName = "Adobe Garamond Pro";
            textPart2.Font.FontSize = 21;

            para = paragraphs2.Add();
            para.HorizontalAlignment = HorizontalAlignmentType.Left;
            textPart2 = para.AddTextPart();
            textPart2.Text = "Turpis facilisis vitae consequat, cum a a, turpis dui consequat massa in dolor per, felis non amet. Auctor eleifend in omnis elit vestibulum, donec non elementum tellus est mauris, id aliquam, at lacus, arcu pretium proin lacus dolor et. Eu tortor, vel ultrices amet dignissim mauris vehicula.";
            textPart2.Font.FontName = "Adobe Garamond Pro";
            textPart2.Font.FontSize = 21;
            #endregion

            MemoryStream stream = new MemoryStream();
            presentation.Save(stream);
            presentation.Close();
            stream.Position = 0;

			if (stream != null)
			{
				SaveiOS iOSSave = new SaveiOS ();
				iOSSave.Save ("GettingStartedPresentation.pptx", "application/mspowerpoint", stream);
			}

		}

		public override void LayoutSubviews ()
		{
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				frameMargin = 0.0f;
			}
			frameRect = Bounds;
			frameRect.Location = new CGPoint (frameRect.Location.X + frameMargin, frameRect.Location.Y + 1.5f * frameMargin);
			frameRect.Size = new CGSize(frameRect.Size.Width - (frameRect.Location.X + frameMargin), frameRect.Size.Height - (frameRect.Location.Y + 1.5f * frameMargin));

			LoadAllowedTextsLabel ();

			base.LayoutSubviews ();
		}
	}
}
