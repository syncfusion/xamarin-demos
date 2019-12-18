#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.IO;
using Syncfusion.Drawing;
using System.Reflection;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Barcode;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Interactive;
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
    public partial class ImageInsertion : SampleView
    {
        CGRect frameRect = new CGRect();  
        float frameMargin = 8.0f;		
		UILabel label1;		
		UIButton button ;
        public ImageInsertion()
        {
         
		  label1 = new UILabel();
		 
		  button = new UIButton(UIButtonType.System);
		  button.TouchUpInside += OnButtonClicked;
        }

        void LoadAllowedTextsLabel()
        { 
            label1.Frame = frameRect;
            label1.TextColor = UIColor.FromRGB(38 / 255.0f, 38 / 255.0f, 38 / 255.0f);
            label1.Text = "This sample demonstrates how to insert images in a PDF document.";
            label1.Font = UIFont.SystemFontOfSize(15);
            label1.Lines = 0;
            label1.LineBreakMode = UILineBreakMode.WordWrap;
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                label1.Font = UIFont.SystemFontOfSize(18);
                label1.Frame = new CGRect(0, 12, frameRect.Location.X + frameRect.Size.Width, 50);
            }
            else {
                label1.Frame = new CGRect(frameRect.Location.X, 12, frameRect.Size.Width, 50);

            }
            this.AddSubview(label1);

            button.SetTitle("Generate PDF", UIControlState.Normal);
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                button.Frame = new CGRect(0, 70, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            else {
                button.Frame = new CGRect(frameRect.Location.X, 70, frameRect.Size.Width, 10);

            }            
            this.AddSubview(button);
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            // Create a new instance of PdfDocument class.
            PdfDocument document = new PdfDocument();

            // Add a new page to the newly created document.
            PdfPage page = document.Pages.Add();

            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Bold);

            PdfGraphics g = page.Graphics;
			
			 g.DrawString("JPEG Image", font, PdfBrushes.Blue, new Syncfusion.Drawing.PointF(0, 40));

            //Load JPEG image to stream.
            Stream jpgImageStream = typeof(ImageInsertion).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Assets.Xamarin_JPEG.jpg");

            //Load the JPEG image
            PdfImage jpgImage = new PdfBitmap(jpgImageStream);

            //Draw the JPEG image
            g.DrawImage(jpgImage,new Syncfusion.Drawing.RectangleF(0,70,515,215));           

            g.DrawString("PNG Image", font, PdfBrushes.Blue, new Syncfusion.Drawing.PointF(0, 355));

            //Load PNG image to stream.
            Stream pngImageStream = typeof(ImageInsertion).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Assets.Xamarin_PNG.png");

            //Load the PNG image
            PdfImage pngImage = new PdfBitmap(pngImageStream);
            
			//Draw the PNG image
            g.DrawImage(pngImage,new Syncfusion.Drawing.RectangleF(0,365,199,300));
        
            MemoryStream stream = new MemoryStream();

            //Save the PDF document
            document.Save(stream);
			
			stream.Position = 0;

            //Close the PDF document
            document.Close(true);

            if (stream != null)
            {
                SaveiOS iosSave = new SaveiOS();
                iosSave.Save("ImageInsertion.pdf", "application/pdf", stream);
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
