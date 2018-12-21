#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
    public partial class Conformance : SampleView
    {
        public Conformance()
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
            //Create a new PDF document
            PdfDocument document = new PdfDocument(PdfConformanceLevel.Pdf_A1B);

            //Add a page
            PdfPage page = document.Pages.Add();

            //Create font
#if COMMONSB
            Stream arialFontStream = typeof(Conformance).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Samples.Assets.arial.ttf");
#else
            Stream arialFontStream = typeof(Conformance).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.PDF.Samples.Assets.arial.ttf");
#endif
            PdfFont font = new PdfTrueTypeFont(arialFontStream, 14);

            //Text to draw
            string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

            //Create a brush
            PdfBrush brush = new PdfSolidBrush(new PdfColor(0, 0, 0));
            PdfPen pen = new PdfPen(new PdfColor(0,0,0));
            RectangleF rect = new RectangleF(0, 0, page.Graphics.ClientSize.Width, page.Graphics.ClientSize.Height);

            //Set the property for the text
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Justify;
            format.ParagraphIndent = 35f;

            //Draw text.
            page.Graphics.DrawString(text, font, brush, rect, format);
            
            MemoryStream stream = new MemoryStream();
            //Save the PDF document.
            document.Save(stream);

            //Close the PDF document.
            document.Close();

            stream.Position = 0;

            if ( Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("PDF_A1b.pdf", "application/pdf", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("PDF_A1b.pdf", "application/pdf", stream);

        }
    }
}
