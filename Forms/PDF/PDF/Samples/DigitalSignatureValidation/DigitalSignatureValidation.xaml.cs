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
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleBrowser.PDF
{
    public partial class DigitalSignatureValidation : SampleView
    {
        public DigitalSignatureValidation()
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
            this.textBlock.IsVisible = true;
            StringBuilder builder = new StringBuilder();

            //Get the stream from the document
#if COMMONSB
            Stream docStream = typeof(DigitalSignature).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Samples.Assets.SignedDocument.pdf");
#else
            Stream docStream = typeof(DigitalSignature).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.PDF.Samples.Assets.SignedDocument.pdf");
#endif
            //Load an existing signed PDF document
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

            //Get signature field
            PdfLoadedSignatureField lSigFld = loadedDocument.Form.Fields[0] as PdfLoadedSignatureField;

            //X509Certificate2Collection to check the signer's identity using root certificates
            X509CertificateCollection collection = new X509CertificateCollection();

            //Read the certificate file
#if COMMONSB
            Stream certificateStream = typeof(DigitalSignature).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Samples.Assets.PDF.pfx");
#else
            Stream certificateStream = typeof(DigitalSignature).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.PDF.Samples.Assets.PDF.pfx");
#endif
            byte[] data = new byte[certificateStream.Length];
            certificateStream.Read(data, 0, data.Length);

            //Create new X509Certificate2 with the root certificate
            X509Certificate2 certificate = new X509Certificate2(data, "password123");

            //Add the certificate to the collection
            collection.Add(certificate);

            //Validate signature and get the validation result
            PdfSignatureValidationResult result = lSigFld.ValidateSignature(collection);

            builder.AppendLine("Signature is " + result.SignatureStatus);
            builder.AppendLine();
            builder.AppendLine("--------Validation Summary--------");
            builder.AppendLine();

            //Checks whether the document is modified or not
            bool isModified = result.IsDocumentModified;
            if (isModified)
                builder.AppendLine("The document has been altered or corrupted since the signature was applied.");
            else
                builder.AppendLine("The document has not been modified since the signature was applied.");

            //Signature details
            builder.AppendLine("Digitally signed by " + lSigFld.Signature.Certificate.IssuerName);
            builder.AppendLine("Valid From : " + lSigFld.Signature.Certificate.ValidFrom);
            builder.AppendLine("Valid To : " + lSigFld.Signature.Certificate.ValidTo);
            builder.AppendLine("Signature Algorithm : " + result.SignatureAlgorithm);
            builder.AppendLine("Hash Algorithm : " + result.DigestAlgorithm);

            //Revocation validation details
            builder.AppendLine("OCSP revocation status : " + result.RevocationResult.OcspRevocationStatus);
            if (result.RevocationResult.OcspRevocationStatus == RevocationStatus.None && result.RevocationResult.IsRevokedCRL)
                builder.AppendLine("CRL is revoked.");

            this.textBlock.Text = builder.ToString();
            
            //Close the document
            loadedDocument.Close(true);
        }
    }
}
