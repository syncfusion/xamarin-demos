#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
using Syncfusion.Pdf.Redaction;

namespace SampleBrowser.PDF
{
    public partial class Redaction : SampleView
    {
        public Redaction()
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
            Stream documentStream = typeof(RemoveImage).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Samples.Assets.RedactionTemplate.pdf");
#else
            Stream documentStream = typeof(RemoveImage).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.PDF.Samples.Assets.RedactionTemplate.pdf");
#endif
            MemoryStream stream = new MemoryStream();
            documentStream.CopyTo(stream);
            stream.Position = 0;
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("RedactionTemplate.pdf", "application/pdf", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("RedactionTemplate.pdf", "application/pdf", stream);
        }
        void OnButtonClicked(object sender, EventArgs e)
        {
            //Load Tiff image to stream.
#if COMMONSB
            Stream documentStream = typeof(Redaction).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Samples.Assets.RedactionTemplate.pdf");
#else
            Stream documentStream = typeof(Redaction).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.PDF.Samples.Assets.RedactionTemplate.pdf");
#endif
            //Load the PDF document from stream.
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(documentStream);

            PdfLoadedPage lpage = loadedDocument.Pages[0] as PdfLoadedPage;

            //Create PDF redaction for the page to redact text 
            PdfRedaction textRedaction = new PdfRedaction(new Syncfusion.Drawing.RectangleF(477f, 154f, 62.709f, 16.802f), Syncfusion.Drawing.Color.Black);

            PdfRedaction textRedaction2 = new PdfRedaction(new Syncfusion.Drawing.RectangleF(70, 240, 65.709f, 16.802f), Syncfusion.Drawing.Color.Black);

            PdfRedaction imageRedaction = new PdfRedaction(new Syncfusion.Drawing.RectangleF(52.14447f, 712.1465f, 126.10835f, 81.45297f), Syncfusion.Drawing.Color.Black);

            lpage.AddRedaction(textRedaction);
            lpage.AddRedaction(textRedaction2);
            lpage.AddRedaction(imageRedaction);
            loadedDocument.Redact();

            MemoryStream stream = new MemoryStream();
            //Saves the PDF to the memory stream.
            loadedDocument.Save(stream);
            loadedDocument.Close();
            stream.Position = 0;

            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("Redaction.pdf", "application/pdf", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("Redaction.pdf", "application/pdf", stream);
        }
    }
}
