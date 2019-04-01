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
	public partial class ImagesPresentation : SampleView
	{
		CGRect frameRect = new CGRect ();
		float frameMargin = 8.0f;
		UILabel label;
		UILabel label1;
		UILabel label2;
		UIButton button;
		public ImagesPresentation()
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
			label.TextColor = UIColor.FromRGB (38/255.0f, 38/255.0f, 38/255.0f);
			label.Text = "This sample demonstrates how to add images to PowerPoint presentation slides using Presentation library.";
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
			string resourcePath = "SampleBrowser.Samples.Presentation.Templates.Images.pptx";
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            IPresentation presentation = Presentation.Open(fileStream);

            #region Slide1
            ISlide slide1 = presentation.Slides[0];
            IShape shape1 = (IShape)slide1.Shapes[0];
            shape1.Left = 1.27 * 72;
            shape1.Top = 0.56 * 72;
            shape1.Width = 9.55 * 72;
            shape1.Height = 5.4 * 72;

            ITextBody textFrame = shape1.TextBody;
            IParagraphs paragraphs = textFrame.Paragraphs;
            paragraphs.Add();
            IParagraph paragraph = paragraphs[0];
            paragraph.HorizontalAlignment = HorizontalAlignmentType.Left;
            ITextParts textParts = paragraph.TextParts;
            textParts.Add();
            ITextPart textPart = textParts[0];
            textPart.Text = "Essential Presentation ";
            textPart.Font.CapsType = TextCapsType.All;
            textPart.Font.FontName = "Calibri Light (Headings)";
            textPart.Font.FontSize = 80;
            textPart.Font.Color = ColorObject.Black;
            #endregion

            #region Slide2
            ISlide slide2 = presentation.Slides.Add(SlideLayoutType.ContentWithCaption);
            slide2.Background.Fill.FillType = FillType.Solid;
            slide2.Background.Fill.SolidFill.Color = ColorObject.White;

            //Adds shape in slide
            shape1 = (IShape)slide2.Shapes[0];
            shape1.Left = 0.47 * 72;
            shape1.Top = 1.15 * 72;
            shape1.Width = 3.5 * 72;
            shape1.Height = 4.91 * 72;

            ITextBody textFrame1 = shape1.TextBody;

            //Instance to hold paragraphs in textframe
            IParagraphs paragraphs1 = textFrame1.Paragraphs;
            IParagraph paragraph1 = paragraphs1.Add();
            paragraph1.HorizontalAlignment = HorizontalAlignmentType.Left;
            ITextPart textpart1 = paragraph1.AddTextPart();
            textpart1.Text = "Lorem ipsum dolor sit amet, lacus amet amet ultricies. Quisque mi venenatis morbi libero, orci dis, mi ut et class porta, massa ligula magna enim, aliquam orci vestibulum tempus.";
            textpart1.Font.Color = ColorObject.White;
            textpart1.Font.FontName = "Calibri (Body)";
            textpart1.Font.FontSize = 15;
            paragraphs1.Add();

            IParagraph paragraph2 = paragraphs1.Add();
            paragraph2.HorizontalAlignment = HorizontalAlignmentType.Left;
            textpart1 = paragraph2.AddTextPart();
            textpart1.Text = "Turpis facilisis vitae consequat, cum a a, turpis dui consequat massa in dolor per, felis non amet.";
            textpart1.Font.Color = ColorObject.White;
            textpart1.Font.FontName = "Calibri (Body)";
            textpart1.Font.FontSize = 15;
            paragraphs1.Add();

            IParagraph paragraph3 = paragraphs1.Add();
            paragraph3.HorizontalAlignment = HorizontalAlignmentType.Left;
            textpart1 = paragraph3.AddTextPart();
            textpart1.Text = "Auctor eleifend in omnis elit vestibulum, donec non elementum tellus est mauris, id aliquam, at lacus, arcu pretium proin lacus dolor et. Eu tortor, vel ultrices amet dignissim mauris vehicula.";
            textpart1.Font.Color = ColorObject.White;
            textpart1.Font.FontName = "Calibri (Body)";
            textpart1.Font.FontSize = 15;
            paragraphs1.Add();

            IParagraph paragraph4 = paragraphs1.Add();
            paragraph4.HorizontalAlignment = HorizontalAlignmentType.Left;
            textpart1 = paragraph4.AddTextPart();
            textpart1.Text = "Lorem tortor neque, purus taciti quis id. Elementum integer orci accumsan minim phasellus vel.";
            textpart1.Font.Color = ColorObject.White;
            textpart1.Font.FontName = "Calibri (Body)";
            textpart1.Font.FontSize = 15;
            paragraphs1.Add();

            slide2.Shapes.RemoveAt(1);
            slide2.Shapes.RemoveAt(1);

            //Adds picture in the shape
            resourcePath = "SampleBrowser.Samples.Presentation.Templates.tablet.jpg";
            assembly = Assembly.GetExecutingAssembly();
            fileStream = assembly.GetManifestResourceStream(resourcePath);
            IPicture picture1 = slide2.Shapes.AddPicture(fileStream, 5.18 * 72, 1.15 * 72, 7.3 * 72, 5.31 * 72);
            fileStream.Close();
            #endregion

            MemoryStream stream = new MemoryStream();
            presentation.Save(stream);
            presentation.Close();
            stream.Position = 0;

			if (stream != null)
			{
				SaveiOS iOSSave = new SaveiOS ();
				iOSSave.Save ("ImagesPresentation.pptx", "application/mspowerpoint", stream);
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
