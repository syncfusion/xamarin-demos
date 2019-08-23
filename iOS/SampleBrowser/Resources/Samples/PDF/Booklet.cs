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
    public partial class Booklet : SampleView
    {
        CGRect frameRect = new CGRect();
        float frameMargin = 8.0f;
       
		UILabel label1;
		
		UIButton button ;
        public Booklet()
        {
		  label1 = new UILabel();
		  button = new UIButton(UIButtonType.System);	
		  button.TouchUpInside += OnButtonClicked;		  
        }

        void LoadAllowedTextsLabel()
        {
           
            label1.Frame = frameRect;
            label1.TextColor = UIColor.FromRGB(38 / 255.0f, 38 / 255.0f, 38 / 255.0f);
            label1.Text = "This sample demonstrates how to create a booklet from an existing PDF document.";
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
            Stream docStream = typeof(Booklet).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Assets.JavaScript Succinctly.pdf");
            PdfLoadedDocument ldoc = new PdfLoadedDocument(docStream);
            float width = 1224;
            float height = 792;

            PdfDocument document = PdfBookletCreator.CreateBooklet(ldoc, new Syncfusion.Drawing.SizeF(width, height), true);
            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            document.Close(true);

            if (stream != null)
            {
                SaveiOS iosSave = new SaveiOS();
                iosSave.Save("Booklet.pdf", "application/pdf", stream);
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
