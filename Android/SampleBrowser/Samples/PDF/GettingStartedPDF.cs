#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using System.IO;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.Reflection;

namespace SampleBrowser
{
    public partial class GettingStartedPDF : SamplePage
    {
        private Context m_context;
        PdfDocument doc;
        PdfPage page;
        Syncfusion.Drawing.Color gray = Syncfusion.Drawing.Color.FromArgb(255, 77, 77, 77);
        Syncfusion.Drawing.Color black = Syncfusion.Drawing.Color.FromArgb(255, 0, 0, 0);
        Syncfusion.Drawing.Color white = Syncfusion.Drawing.Color.FromArgb(255, 255, 255, 255);
        Syncfusion.Drawing.Color violet = Syncfusion.Drawing.Color.FromArgb(255, 151, 108, 174);
        public override View GetSampleContent(Context con)
        {
            LinearLayout linear = new LinearLayout(con);
            linear.SetBackgroundColor(Android.Graphics.Color.White);
            linear.Orientation = Orientation.Vertical;
            linear.SetPadding(10, 10, 10, 10);

           
            TextView space = new TextView(con);
            space.TextSize = 10;
            linear.AddView(space);

            TextView text2 = new TextView(con);
            text2.TextSize = 17;
            text2.TextAlignment = TextAlignment.Center;
            text2.Text = "This sample demonstrates how to create a simple PDF document with text and images.";
            text2.SetTextColor(Android.Graphics.Color.ParseColor("#262626"));
            text2.SetPadding(5, 5, 5, 5);

            linear.AddView(text2);

            TextView space1 = new TextView(con);
            space1.TextSize = 10;
            linear.AddView(space1);
           

            m_context = con;

            TextView space2 = new TextView(con);
            space2.TextSize = 10;
            linear.AddView(space2);

            Button button1 = new Button(con);
            button1.Text = "Generate PDF";
            button1.Click += OnButtonClicked;
            linear.AddView(button1);

            return linear;
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            doc = new PdfDocument();
            doc.PageSettings.Margins.All = 0;
            page = doc.Pages.Add();
            PdfGraphics g = page.Graphics;

            PdfFont headerFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 35);
            PdfFont subHeadingFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);
            g.DrawRectangle(new PdfSolidBrush(gray), new RectangleF(0, 0, page.Graphics.ClientSize.Width, page.Graphics.ClientSize.Height));
            g.DrawRectangle(new PdfSolidBrush(black), new RectangleF(0, 0, page.Graphics.ClientSize.Width, 130));
            g.DrawRectangle(new PdfSolidBrush(white), new RectangleF(0, 400, page.Graphics.ClientSize.Width, page.Graphics.ClientSize.Height - 450));
            g.DrawString("Syncfusion", headerFont, new PdfSolidBrush(violet), new PointF(10, 20));
            g.DrawRectangle(new PdfSolidBrush(violet), new RectangleF(10, 63, 155, 35));
            g.DrawString("File Formats", subHeadingFont, new PdfSolidBrush(black), new PointF(45, 70));

            PdfLayoutResult result = HeaderPoints("Optimized for usage in a server environment where spread and low memory usage in critical.", 15);
            result = HeaderPoints("Proven, reliable platform thousands of users over the past 10 years.", result.Bounds.Bottom + 15);
            result = HeaderPoints("Microsoft Excel, Word, Presentation, PDF and PDF Viewer.", result.Bounds.Bottom + 15);
            result = HeaderPoints("Why start from scratch? Rely on our dependable solution frameworks.", result.Bounds.Bottom + 15);

            result = BodyContent("Deployment-ready framework tailored to your needs.", result.Bounds.Bottom + 45);
            result = BodyContent("Enable your applications to read and write file formats documents easily.", result.Bounds.Bottom + 25);
            result = BodyContent("Solutions available for web, desktop, and mobile applications.", result.Bounds.Bottom + 25);
            result = BodyContent("Backed by our end-to-end product maintenance infrastructure.", result.Bounds.Bottom + 25);
            result = BodyContent("The quickest path from concept to delivery.", result.Bounds.Bottom + 25);

            PdfPen redPen = new PdfPen(PdfBrushes.Red, 2);
            g.DrawLine(redPen, new PointF(40, result.Bounds.Bottom + 92), new PointF(40, result.Bounds.Bottom + 145));
            float headerBulletsXposition = 40;
            PdfTextElement txtElement = new PdfTextElement("The Experts");
            txtElement.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 20);
            txtElement.Draw(page, new RectangleF(headerBulletsXposition + 5, result.Bounds.Bottom + 90, 450, 200));

            PdfPen violetPen = new PdfPen(PdfBrushes.Violet, 2);
            g.DrawLine(violetPen, new PointF(headerBulletsXposition + 280, result.Bounds.Bottom + 92), new PointF(headerBulletsXposition + 280, result.Bounds.Bottom + 145));
            txtElement = new PdfTextElement("Accurate Estimates");
            txtElement.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 20);
            result = txtElement.Draw(page, new RectangleF(headerBulletsXposition + 290, result.Bounds.Bottom + 90, 450, 200));

            txtElement = new PdfTextElement("A substantial number of .NET reporting applications use our frameworks.");
            txtElement.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 11, PdfFontStyle.Regular);
            result = txtElement.Draw(page, new RectangleF(headerBulletsXposition + 5, result.Bounds.Bottom + 5, 250, 200));


            txtElement = new PdfTextElement("Given our expertise, you can expect estimates to be accurate.");
            txtElement.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 11, PdfFontStyle.Regular);
            result = txtElement.Draw(page, new RectangleF(headerBulletsXposition + 290, result.Bounds.Y, 250, 200));


            PdfPen greenPen = new PdfPen(PdfBrushes.Green, 2);
            g.DrawLine(greenPen, new PointF(40, result.Bounds.Bottom + 32), new PointF(40, result.Bounds.Bottom + 85));

            txtElement = new PdfTextElement("No-Hassle Licensing");
            txtElement.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 20);
            txtElement.Draw(page, new RectangleF(headerBulletsXposition + 5, result.Bounds.Bottom + 30, 450, 200));

            PdfPen bluePen = new PdfPen(PdfBrushes.Blue, 2);
            g.DrawLine(bluePen, new PointF(headerBulletsXposition + 280, result.Bounds.Bottom + 32), new PointF(headerBulletsXposition + 280, result.Bounds.Bottom + 85));
            txtElement = new PdfTextElement("About Syncfusion");
            txtElement.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 20);
            result = txtElement.Draw(page, new RectangleF(headerBulletsXposition + 290, result.Bounds.Bottom + 30, 450, 200));

            txtElement = new PdfTextElement("No royalties, run time, or server deployment fees means no surprises.");
            txtElement.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 11, PdfFontStyle.Regular);
            result = txtElement.Draw(page, new RectangleF(headerBulletsXposition + 5, result.Bounds.Bottom + 5, 250, 200));


            txtElement = new PdfTextElement("Syncfusion offers over 1,000 components and frameworks for mobile, web, and desktop development.");
            txtElement.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 11, PdfFontStyle.Regular);
            result = txtElement.Draw(page, new RectangleF(headerBulletsXposition + 290, result.Bounds.Y, 250, 200));

            Stream imgStream = typeof(GettingStartedPDF).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Assets.Xamarin_bannerEdit.jpg");

            g.DrawImage(PdfImage.FromStream(imgStream), 180, 630, 280, 150);

            g.DrawString("All trademarks mentioned belong to their owners.", new PdfStandardFont(PdfFontFamily.TimesRoman, 8, PdfFontStyle.Italic), PdfBrushes.White, new PointF(10, g.ClientSize.Height - 30));
            PdfTextWebLink linkAnnot = new PdfTextWebLink();
            linkAnnot.Url = "http://www.syncfusion.com";
            linkAnnot.Text = "www.syncfusion.com";
            linkAnnot.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 8, PdfFontStyle.Italic);
            linkAnnot.Brush = PdfBrushes.White;
            linkAnnot.DrawTextWebLink(page, new PointF(g.ClientSize.Width - 100, g.ClientSize.Height - 30));
            MemoryStream stream = new MemoryStream();
            doc.Save(stream);
            doc.Close(true);

            if (stream != null)
            {
                SaveAndroid androidSave = new SaveAndroid();
                androidSave.Save("GettingStarted.pdf", "application/pdf", stream, m_context);
            }
        }
        private PdfLayoutResult BodyContent(string text, float yPosition)
        {
            float headerBulletsXposition = 35;
            PdfTextElement txtElement = new PdfTextElement("3");
            txtElement.Font = new PdfStandardFont(PdfFontFamily.ZapfDingbats, 16);
            txtElement.Brush = new PdfSolidBrush(violet);
            txtElement.StringFormat = new PdfStringFormat();
            txtElement.StringFormat.WordWrap = PdfWordWrapType.Word;
            txtElement.StringFormat.LineLimit = true;
            txtElement.Draw(page, new RectangleF(headerBulletsXposition, yPosition, 320, 100));

            txtElement = new PdfTextElement(text);
            txtElement.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 17);
            txtElement.Brush = new PdfSolidBrush(white);
            txtElement.StringFormat = new PdfStringFormat();
            txtElement.StringFormat.WordWrap = PdfWordWrapType.Word;
            txtElement.StringFormat.LineLimit = true;
            PdfLayoutResult result = txtElement.Draw(page, new RectangleF(headerBulletsXposition + 25, yPosition, 450, 130));
            return result;
        }

        private PdfLayoutResult HeaderPoints(string text, float yPosition)
        {
            float headerBulletsXposition = 220;
            PdfTextElement txtElement = new PdfTextElement("l");
            txtElement.Font = new PdfStandardFont(PdfFontFamily.ZapfDingbats, 10);
            txtElement.Brush = new PdfSolidBrush(violet);
            txtElement.StringFormat = new PdfStringFormat();
            txtElement.StringFormat.WordWrap = PdfWordWrapType.Word;
            txtElement.StringFormat.LineLimit = true;
            txtElement.Draw(page, new RectangleF(headerBulletsXposition, yPosition, 300, 100));

            txtElement = new PdfTextElement(text);
            txtElement.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 11);
            txtElement.Brush = new PdfSolidBrush(white);
            txtElement.StringFormat = new PdfStringFormat();
            txtElement.StringFormat.WordWrap = PdfWordWrapType.Word;
            txtElement.StringFormat.LineLimit = true;
            PdfLayoutResult result = txtElement.Draw(page, new RectangleF(headerBulletsXposition + 20, yPosition, 320, 100));
            return result;
        }
    }
}