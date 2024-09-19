#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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

namespace SampleBrowser.PDF
{
    public partial class CompressExistingPDF : SampleView
    {
        public CompressExistingPDF()
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
            Stream documentStream = typeof(RemoveImage).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Samples.Assets.jQuery_Succinctly.pdf");
#else
            Stream documentStream = typeof(RemoveImage).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.PDF.Samples.Assets.jQuery_Succinctly.pdf");
#endif
            MemoryStream stream = new MemoryStream();
            documentStream.CopyTo(stream);
            stream.Position = 0;
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("CompressionTemplate.pdf", "application/pdf", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("CompressionTemplate.pdf", "application/pdf", stream);
        }
        void OnButtonClicked(object sender, EventArgs e)
        {            
#if COMMONSB
            Stream documentStream = typeof(CompressExistingPDF).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Samples.Assets.jQuery_Succinctly.pdf");
#else
            Stream documentStream = typeof(CompressExistingPDF).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.PDF.Samples.Assets.jQuery_Succinctly.pdf");
#endif
            //Load the PDF document from stream.
            PdfLoadedDocument document = new PdfLoadedDocument(documentStream);
            //Initialize new instance of PdfCompressionOptions class.
            PdfCompressionOptions options = new PdfCompressionOptions();
            //set the compress images based on the image quality. 
            options.CompressImages = true;
            options.ImageQuality = 50;
            //Enable the optimize font option
            options.OptimizeFont = true;
            //Enable the optimize page contents.
            options.OptimizePageContents = true;
            //Set to remove the metadata information.
            options.RemoveMetadata = true;
            //Assign the compression option to the document
            document.Compress(options);
            MemoryStream stream = new MemoryStream();
            //Saves the PDF to the memory stream.
            document.Save(stream);
            //Close the PDF document
            document.Close(true);
            stream.Position = 0;

            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("CompressExistingPDF.pdf", "application/pdf", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("CompressExistingPDF.pdf", "application/pdf", stream);
        }
    }
}
