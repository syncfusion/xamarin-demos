#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Xamarin.Forms;
using System.IO;
using SampleBrowser.Core;
using System.Reflection;

namespace SampleBrowser.PDF
{
    public partial class HtmlTextElement : SampleView
    {
        public HtmlTextElement()
        {
            InitializeComponent();
            if (Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Description.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.BackgroundColor = Xamarin.Forms.Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Description.FontSize = 13.5;
                this.Description.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
            }
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
            //Save the PDF document.
            doc.Save(stream);

            //Close the PDF document.
            doc.Close();

            stream.Position = 0;

            if ( Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("HtmlTextElement.pdf", "application/pdf", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("HtmlTextElement.pdf", "application/pdf", stream);

        }
       
    }
}
