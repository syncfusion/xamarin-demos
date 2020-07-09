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
    public partial class RTLSupport : SampleView
    {
        public RTLSupport()
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
            PdfDocument document = new PdfDocument();

            //Add a page
            PdfPage page = document.Pages.Add();

            //Create font
#if COMMONSB
            Stream arialFontStream = typeof(RTLSupport).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Samples.Assets.arial.ttf");
#else
            Stream arialFontStream = typeof(RTLSupport).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.PDF.Samples.Assets.arial.ttf");
#endif
            PdfFont font = new PdfTrueTypeFont(arialFontStream, 14);

            //Read the text from text file
#if COMMONSB
            Stream rtlText = typeof(RTLSupport).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Samples.Assets.arabic.txt");
#else
            Stream rtlText = typeof(RTLSupport).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.PDF.Samples.Assets.arabic.txt");
#endif
            StreamReader reader = new StreamReader(rtlText, System.Text.Encoding.Unicode);
            string text = reader.ReadToEnd();
            reader.Dispose();

            //Create a brush
            PdfBrush brush = new PdfSolidBrush(new PdfColor(0, 0, 0));
            PdfPen pen = new PdfPen(new PdfColor(0,0,0));
            SizeF clipBounds = page.Graphics.ClientSize;
            RectangleF rect = new RectangleF(0, 0, clipBounds.Width, clipBounds.Height);

            //Set the property for RTL text
            PdfStringFormat format = new PdfStringFormat();
            format.TextDirection = PdfTextDirection.RightToLeft;
            format.Alignment = PdfTextAlignment.Right;
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
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("RTLText.pdf", "application/pdf", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("RTLText.pdf", "application/pdf", stream);

        }
    }
}
