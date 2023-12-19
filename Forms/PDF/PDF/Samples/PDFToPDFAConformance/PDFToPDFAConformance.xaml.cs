#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Pdf;
using System;
using System.IO;
using Xamarin.Forms;
using System.Reflection;
using SampleBrowser.Core;
using Syncfusion.Pdf.Parsing;
using SkiaSharp;
using Syncfusion.Pdf.Graphics;

namespace SampleBrowser.PDF
{
    public partial class PDFToPDFAConformance : SampleView
    {
        public PDFToPDFAConformance()
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
        private void ButtonView_Click(object sender, EventArgs e)
        {
#if COMMONSB
            Stream documentStream = typeof(PDFToPDFAConformance).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Samples.Assets.InvoiceTemplate.pdf");
#else
            Stream documentStream = typeof(PDFToPDFAConformance).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.PDF.Samples.Assets.InvoiceTemplate.pdf");
#endif
            MemoryStream stream = new MemoryStream();
            documentStream.CopyTo(stream);
            stream.Position = 0;
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("ConformanceTemplate.pdf", "application/pdf", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("ConformanceTemplate.pdf", "application/pdf", stream);
        }
        void OnButtonClicked(object sender, EventArgs e)
        {
#if COMMONSB
            Stream documentStream = typeof(PDFToPDFAConformance).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Samples.Assets.InvoiceTemplate.pdf");
#else
            Stream documentStream = typeof(PDFToPDFAConformance).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.PDF.Samples.Assets.InvoiceTemplate.pdf");
#endif
            //Load the PDF document from stream.
            PdfLoadedDocument document = new PdfLoadedDocument(documentStream);
            //Sample level font event handling
            document.SubstituteFont += LoadedDocument_SubstituteFont;
            //convert a document to PDF/A standard document.
            document.ConvertToPDFA(PdfConformanceLevel.Pdf_A1B);
            MemoryStream stream = new MemoryStream();
            //Saves the PDF to the memory stream.
            document.Save(stream);
            //Close the PDF document
            document.Close(true);
            stream.Position = 0;

            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("PDFToPDFAConformance.pdf", "application/pdf", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("PDFToPDFAConformance.pdf", "application/pdf", stream);
        }
        static void LoadedDocument_SubstituteFont(object sender, PdfFontEventArgs args)
        {
            //get the font name
            string fontName = args.FontName.Split(',')[0];

            //get the font style
            PdfFontStyle fontStyle = args.FontStyle;

            SKFontStyle sKFontStyle = SKFontStyle.Normal;

            if (fontStyle != PdfFontStyle.Regular)
            {
                if (fontStyle == PdfFontStyle.Bold)
                {
                    sKFontStyle = SKFontStyle.Bold;
                }
                else if (fontStyle == PdfFontStyle.Italic)
                {
                    sKFontStyle = SKFontStyle.Italic;
                }
                else if (fontStyle == (PdfFontStyle.Italic | PdfFontStyle.Bold))
                {
                    sKFontStyle = SKFontStyle.BoldItalic;
                }
            }

            SKTypeface typeface = SKTypeface.FromFamilyName(fontName, sKFontStyle);

            SKStreamAsset typeFaceStream = typeface.OpenStream();

            MemoryStream memoryStream = null;

            if (typeFaceStream != null && typeFaceStream.Length > 0)
            {
                //Create the fontData from the type face stream.
                byte[] fontData = new byte[typeFaceStream.Length];

                typeFaceStream.Read(fontData, typeFaceStream.Length);
                typeFaceStream.Dispose();

                //Create the new memory stream from the font data.
                memoryStream = new MemoryStream(fontData);
            }

            //set the font stream to the event args.
            args.FontStream = memoryStream;
        }
    }
}
