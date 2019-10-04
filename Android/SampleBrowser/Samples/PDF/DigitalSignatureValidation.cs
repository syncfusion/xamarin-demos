#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Java.IO;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using Syncfusion.Pdf.Parsing;
using System.Threading.Tasks;

using Syncfusion.Pdf;
using System.Reflection;
using Syncfusion.Pdf.Security;
using Syncfusion.Drawing;
using Android.Support.V4.Content;
using System.Security.Cryptography.X509Certificates;

namespace SampleBrowser
{
    public partial class DigitalSignatureValidation : SamplePage
    {
        private Context m_context;
        TextView resultView;
        public override View GetSampleContent(Context con)
        {
            LinearLayout linear = new LinearLayout(con);
            linear.SetBackgroundColor(Android.Graphics.Color.White);
            linear.Orientation = Orientation.Vertical;
            linear.SetPadding(10, 10, 10, 10);          

            TextView space = new TextView(con);
            space.TextSize = 10;
            linear.AddView(space);

            TextView text2 = new TextView(con);
            text2.TextSize = 17;
            text2.TextAlignment = TextAlignment.Center;
            text2.Text = "This sample illustrates how to validate the digitally signed PDF document signature.";
            text2.SetTextColor(Android.Graphics.Color.ParseColor("#262626"));
            text2.SetPadding(5, 5, 5, 5);

            linear.AddView(text2);

            TextView space1 = new TextView(con);
            space1.TextSize = 10;
            linear.AddView(space1);
 
            m_context = con;

            TextView space2 = new TextView(con);
            space2.TextSize = 10;
            linear.AddView(space2);

            Button button1 = new Button(con);
            button1.Text = "Validate Signature";
            button1.Click += OnButtonClicked;
            linear.AddView(button1);

            resultView = new TextView(con);
            resultView.TextSize = 17;
            resultView.TextAlignment = TextAlignment.Center;
            resultView.Text = "";
            resultView.SetTextColor(Android.Graphics.Color.ParseColor("#262626"));
            resultView.SetPadding(5, 5, 5, 5);

            linear.AddView(resultView);

            return linear;
        }
        void OnButtonClicked(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();

            //Get the stream from the document.
            Stream docStream = typeof(DigitalSignatureValidation).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Assets.SignedDocument.pdf");
            
            //Load the PDF document into the loaded document object.
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

            //Get signature field
            PdfLoadedSignatureField lSigFld = loadedDocument.Form.Fields[0] as PdfLoadedSignatureField;

            //Get the certificate stream from .pfx file.
            Stream certificateStream = typeof(DigitalSignatureValidation).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Assets.PDF.pfx");

            byte[] data = new byte[certificateStream.Length];
            certificateStream.Read(data, 0, data.Length);

            //Create new X509Certificate2 with the root certificate
            X509Certificate2 certificate = new X509Certificate2(data, "password123");

            //X509Certificate2Collection to check the signer's identity using root certificates
            X509CertificateCollection collection = new X509CertificateCollection();

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

            this.resultView.Text = builder.ToString();

            //Close the document
            loadedDocument.Close(true);

        }
    }
}