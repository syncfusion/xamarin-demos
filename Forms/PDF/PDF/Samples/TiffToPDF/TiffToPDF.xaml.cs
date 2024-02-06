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
using Syncfusion.Pdf.Graphics;

namespace SampleBrowser.PDF
{
    public partial class TiffToPDF : SampleView
    {
        public TiffToPDF()
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
            //Load Tiff image to stream.
#if COMMONSB
            Stream imageFileStream = typeof(TiffToPDF).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Samples.Assets.image.tiff");
#else
            Stream imageFileStream = typeof(TiffToPDF).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.PDF.Samples.Assets.image.tiff");
#endif
            //Create a new PDF document
            PdfDocument document = new PdfDocument();
            //Set margin to the page
            document.PageSettings.Margins.All = 0;
            //Load Multiframe Tiff image
            PdfTiffImage tiffImage = new PdfTiffImage(imageFileStream);
            //Get the frame count
            int frameCount = tiffImage.FrameCount;
            //Access each frame and draw into the page
            for (int i = 0; i < frameCount; i++)
            {
                //Add new page for each frames
                PdfPage page = document.Pages.Add();
                //Get page graphics
                PdfGraphics graphics = page.Graphics;
                //Set active frame.
                tiffImage.ActiveFrame = i;
                //Draw Tiff image into page
                graphics.DrawImage(tiffImage, 0, 0, page.GetClientSize().Width, page.GetClientSize().Height);
            }
            //Save PDF document
            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            //Close the PDF document
            document.Close(true);
            stream.Position = 0;

            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("TiffToPDF.pdf", "application/pdf", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("TiffToPDF.pdf", "application/pdf", stream);
        }
    }
}
