#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleBrowser.PDF
{
    public partial class DigitalSignature : SampleView
    {
        public DigitalSignature()
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
            //Get the stream from the document.
#if COMMONSB
            Stream docStream = typeof(DigitalSignature).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Samples.Assets.SalesOrderDetail.pdf");
#else
            Stream docStream = typeof(DigitalSignature).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.PDF.Samples.Assets.SalesOrderDetail.pdf");
#endif         
            //Load the PDF document into the loaded document object.
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

            //Get the certificate stream from .pfx file.
#if COMMONSB
            Stream certificateStream = typeof(DigitalSignature).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Samples.Assets.PDF.pfx");
#else
            Stream certificateStream = typeof(DigitalSignature).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.PDF.Samples.Assets.PDF.pfx");
#endif
            //Create PdfCertificate using certificate stream and password.
            PdfCertificate pdfCert = new PdfCertificate(certificateStream, "password123");

            //Add certificate to document first page.
            PdfSignature signature = new PdfSignature(loadedDocument, loadedDocument.Pages[0], pdfCert, "Signature");

            signature.Bounds = new RectangleF(5, 5, 300, 300);

            MemoryStream stream = new MemoryStream();

            //Save the PDF document
            loadedDocument.Save(stream);

            //Close the PDF document
            loadedDocument.Close(true);

           stream.Position = 0;

            //Open in default system viewer.
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<IMailService>().ComposeMail("DigitalSignature.pdf", null, "Signing the document", "Syncfusion", stream);
            else
                Xamarin.Forms.DependencyService.Get<IMailService>().ComposeMail("DigitalSignature.pdf", null, "Signing the document", "Syncfusion", stream);

        }
    }
}
