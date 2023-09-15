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
using Syncfusion.Pdf.Exporting;
using Syncfusion.Pdf.Parsing;

namespace SampleBrowser.PDF
{
    public partial class RemoveImage : SampleView
    {
        public RemoveImage()
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
            Stream documentStream = typeof(RemoveImage).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Samples.Assets.RemoveImageTemplate.pdf");
#else
            Stream documentStream = typeof(RemoveImage).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.PDF.Samples.Assets.RemoveImageTemplate.pdf");
#endif
            MemoryStream stream = new MemoryStream();
            documentStream.CopyTo(stream);
            stream.Position = 0;
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("RemoveImageTemplate.pdf", "application/pdf", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("RemoveImageTemplate.pdf", "application/pdf", stream);
        }
        void OnButtonClicked(object sender, EventArgs e)
        {           
#if COMMONSB
            Stream documentStream = typeof(RemoveImage).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Samples.Assets.RemoveImageTemplate.pdf");
#else
            Stream documentStream = typeof(RemoveImage).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.PDF.Samples.Assets.RemoveImageTemplate.pdf");
#endif
            //Load the PDF document from stream.
            PdfLoadedDocument document = new PdfLoadedDocument(documentStream);
            //Load the first page.
            PdfPageBase page = document.Pages[0];
            //Extract images from the first page.
            PdfImageInfo[] imageInfo = page.GetImagesInfo();
            //Remove the Image.
            page.RemoveImage(imageInfo[0]);
            MemoryStream stream = new MemoryStream();
            //Saves the PDF to the memory stream.
            document.Save(stream);
            //Close the PDF document
            document.Close(true);
            stream.Position = 0;

            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("RemoveImage.pdf", "application/pdf", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("RemoveImage.pdf", "application/pdf", stream);
        }
    }
}
