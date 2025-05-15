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
using Syncfusion.Pdf.Exporting;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Drawing;

namespace SampleBrowser.PDF
{
    public partial class WatermarkAnnotation : SampleView
    {
        public WatermarkAnnotation()
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
#if COMMONSB
            Stream documentStream = typeof(WatermarkAnnotation).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Samples.Assets.InvoiceTemplate.pdf");
#else
            Stream documentStream = typeof(WatermarkAnnotation).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.PDF.Samples.Assets.InvoiceTemplate.pdf");
#endif
            //Load the existing PDF document.
            PdfLoadedDocument document = new PdfLoadedDocument(documentStream);

            //Get the existing PDF page.
            PdfLoadedPage page = document.Pages[0] as PdfLoadedPage;

            SizeF pageSize = page.Size;

            //Create new watermark annotation.
            PdfWatermarkAnnotation watermarkAnnotation = new PdfWatermarkAnnotation(new RectangleF(0, 0, pageSize.Width, pageSize.Height));
            //Set opacity and annotation flags.
            watermarkAnnotation.Opacity = 0.25F;
            watermarkAnnotation.AnnotationFlags = PdfAnnotationFlags.Print;
            //Get the appearance graphics.
            PdfGraphics graphics = watermarkAnnotation.Appearance.Normal.Graphics;
            string watermarkText = "Confidential";
            PdfFont watermarkFont = new PdfStandardFont(PdfFontFamily.Helvetica, 40);
            SizeF textSize = watermarkFont.MeasureString(watermarkText);
            //Find the center position.
            float x = pageSize.Width / 2 - textSize.Width / 2;
            float y = pageSize.Height / 2;
            graphics.Save();
            graphics.TranslateTransform(x, y);
            graphics.RotateTransform(-45);
            //Draw the watermark content.
            graphics.DrawString(watermarkText, watermarkFont, PdfBrushes.Red, PointF.Empty);
            graphics.Restore();
            if (flatten.IsChecked)
            {
                watermarkAnnotation.Flatten = true;
            }
            //Add the watermark annotation to the PDF page.
            page.Annotations.Add(watermarkAnnotation);

            MemoryStream stream = new MemoryStream();
            //Saves the PDF to the memory stream.
            document.Save(stream);
            //Close the PDF document
            document.Close(true);
            stream.Position = 0;

            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("WatermarkAnnotation.pdf", "application/pdf", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("WatermarkAnnotation.pdf", "application/pdf", stream);
        }
    }
}
