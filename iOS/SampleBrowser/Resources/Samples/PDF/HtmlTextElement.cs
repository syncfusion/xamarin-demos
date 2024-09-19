#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
using Syncfusion.Pdf.Graphics;
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
    public partial class HtmlTextElement : SampleView
    {
        CGRect frameRect = new CGRect();
        float frameMargin = 8.0f;
        UILabel label1;
        UIButton button;
        public HtmlTextElement()
        {
            label1 = new UILabel();
            button = new UIButton(UIButtonType.System);
            button.TouchUpInside += OnButtonClicked;
        }
        void LoadAllowedTextsLabel()
        {
            label1.Frame = frameRect;
            label1.TextColor = UIColor.FromRGB(38 / 255.0f, 38 / 255.0f, 38 / 255.0f);
            label1.Text = "This sample demonstrates drawing HTML text element in the PDF document.";
            label1.Font = UIFont.SystemFontOfSize(15);
            label1.Lines = 0;
            label1.LineBreakMode = UILineBreakMode.WordWrap;
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                label1.Font = UIFont.SystemFontOfSize(18);
                label1.Frame = new CGRect(0, 12, frameRect.Location.X + frameRect.Size.Width, 50);
            }
            else
            {
                label1.Frame = new CGRect(frameRect.Location.X, 12, frameRect.Size.Width, 50);

            }
            this.AddSubview(label1);

            button.SetTitle("Generate PDF", UIControlState.Normal);
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                button.Frame = new CGRect(0, 70, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            else
            {
                button.Frame = new CGRect(frameRect.Location.X, 70, frameRect.Size.Width, 10);

            }

            this.AddSubview(button);
        }
        void OnButtonClicked(object sender, EventArgs e)
        {
            PdfDocument doc = new PdfDocument();

            //Add a page
            PdfPage page = doc.Pages.Add();

            PdfSolidBrush brush = new PdfSolidBrush(Syncfusion.Drawing.Color.Black);

            PdfPen pen = new PdfPen(Syncfusion.Drawing.Color.Black, 1f);

            //Create font
            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 11.5f);

            PdfFont heading = new PdfStandardFont(PdfFontFamily.TimesRoman, 12, PdfFontStyle.Bold);

            font = new PdfStandardFont(PdfFontFamily.Helvetica, 10f);

            page.Graphics.DrawString("Create, Read, and Edit PDF Files from C#, VB.NET", heading, PdfBrushes.Black, new RectangleF(0, 0, page.GetClientSize().Width, 20), new PdfStringFormat(PdfTextAlignment.Center));

            string longText = "The <b> Syncfusion Essential PDF </b> is a feature-rich and high-performance .NET PDF library that allows you to add robust PDF functionalities to any .NET application." +
                "It allows you to create, read, and edit PDF documents programmatically without Adobe dependencies. This library also offers functionality to <font color='#0000F8'> merge, split, stamp, form-fill, compress, and secure PDF files.</font>" +
                "<br/><br/><font color='#FF3440'><b>1. Secure your PDF with advanced encryption, digital signatures, and redaction.</b></font>" +
                "<br/><br/><font color='#FF9E4D'><b>2. Extract text and images from your PDF files.</b></font>" +
                "<br/><br/><font color='#4F6200'><b>3. Top features: forms, tables, barcodes; stamp, split, and merge PDFs.</b></font>";

            //Rendering HtmlText
            PdfHTMLTextElement richTextElement = new PdfHTMLTextElement(longText, font, brush);

            // Formatting Layout
            PdfLayoutFormat format = new PdfLayoutFormat();
            format.Layout = PdfLayoutType.OnePage;

            //Drawing htmlString
            richTextElement.Draw(page, new RectangleF(0, 20, page.GetClientSize().Width, page.GetClientSize().Height), format);


            MemoryStream stream = new MemoryStream();
            //Save the PDF dcoument.
            doc.Save(stream);

            //Close the PDF document.
            doc.Close();

            stream.Position = 0;

            if (stream != null)
            {
                SaveiOS iosSave = new SaveiOS();
                iosSave.Save("HtmlTextElement.pdf", "application/pdf", stream);
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