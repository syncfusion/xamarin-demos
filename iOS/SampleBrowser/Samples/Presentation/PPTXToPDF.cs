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
using Syncfusion.PresentationToPdfConverter;
using Syncfusion.Pdf;
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
	public partial class PPTXToPDF : SampleView
	{
		CGRect frameRect = new CGRect ();
		float frameMargin = 8.0f;
		UILabel label;
		UILabel label1;
		UIButton button;
        UIButton button2;
        public PPTXToPDF()
		{

			label1 = new UILabel();
			label = new UILabel();
			button = new UIButton(UIButtonType.System);
			button.TouchUpInside += OnButtonClicked;
            button2 = new UIButton(UIButtonType.System);
            button2.TouchUpInside += OnInpTemplateButtonClicked;
        }

		void LoadAllowedTextsLabel()
		{
			label.Frame = frameRect;
			label.TextColor = UIColor.FromRGB (38/255.0f, 38/255.0f, 38/255.0f);
			label.Text = "This sample demonstrates how to convert a PowerPoint presentation to PDF.";
			label.Font = UIFont.SystemFontOfSize(15);
			label.Lines 				= 0;
			label.LineBreakMode 		= UILineBreakMode.WordWrap;
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				label.Font = UIFont.SystemFontOfSize(18);
				label.Frame = new CGRect (5, 5,frameRect.Location.X + frameRect.Size.Width  , 50);
			} 
			else {
				label.Frame = new CGRect (frameRect.Location.X, 5, frameRect.Size.Width , 70);

			}
			this.AddSubview (label);
			button.SetTitle("Convert",UIControlState.Normal);
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				button.Frame = new CGRect (0, 85, frameRect.Location.X + frameRect.Size.Width , 10);
			} 
			else {
				button.Frame = new CGRect (frameRect.Location.X, 110, frameRect.Size.Width , 10);

			}
			this.AddSubview (button);
            button2.SetTitle("Input Template", UIControlState.Normal);
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                button2.Frame = new CGRect(0, 65, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            else
            {
                button2.Frame = new CGRect(frameRect.Location.X, 70, frameRect.Size.Width, 10);

            }
            this.AddSubview(button2);
        }


        void OnInpTemplateButtonClicked(object sender, EventArgs e)
        {
            string resourcePath = "SampleBrowser.Samples.Presentation.Templates.Template.pptx";
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);
           
            MemoryStream stream = new MemoryStream();
            fileStream.CopyTo(stream);
            stream.Position = 0;
            fileStream.Dispose();

            if (stream != null)
            {
                SaveiOS iOSSave = new SaveiOS();
                iOSSave.Save("InputTemplate.pptx", "application/mspowerpoint", stream);
            }

        }

        void OnButtonClicked(object sender, EventArgs e)
		{
			string resourcePath = "SampleBrowser.Samples.Presentation.Templates.Template.pptx";
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);
            //Open the existing PowerPoint Presentation.
            IPresentation presentation = Presentation.Open(fileStream);

            //Convert the PowerPoint document to PDF document.
            PdfDocument pdfDocument = PresentationToPdfConverter.Convert(presentation);

            MemoryStream stream = new MemoryStream();

            //Save the converted PDF document to MemoryStream.
            pdfDocument.Save(stream);
            stream.Position = 0;

            //Close the PDF document.
            pdfDocument.Close(true);

            //Close the PowerPoint Presentation.
            presentation.Close();            

			if (stream != null)
			{
				SaveiOS iOSSave = new SaveiOS ();
				iOSSave.Save ("PPTXToPDF.pdf", "application/pdf", stream);
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
