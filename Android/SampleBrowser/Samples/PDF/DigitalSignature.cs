#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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

namespace SampleBrowser
{
    public partial class DigitalSignature : SamplePage
    {
        private Context m_context;
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
            text2.Text = "This sample demonstrates how to digitally sign PDF document using a .pfx certificate.";
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
            button1.Text = "Sign and Email";
            button1.Click += OnButtonClicked;
            linear.AddView(button1);

            return linear;
        }
        void OnButtonClicked(object sender, EventArgs e)
        {
            //Get the stream from the document.
            Stream docStream = typeof(Booklet).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Assets.SalesOrderDetail.pdf");
            
            //Load the PDF document into the loaded document object.
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

            //Get the certificate stream from .pfx file.
            Stream certificateStream = typeof(DigitalSignature).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Assets.PDF.pfx");

            //Create PdfCertificate using certificate stream and password.
            PdfCertificate pdfCert = new PdfCertificate(certificateStream, "syncfusion");

            //Add certificate to document first page.
            PdfSignature signature = new PdfSignature(loadedDocument, loadedDocument.Pages[0], pdfCert, "Signature");

            signature.Bounds = new RectangleF(5, 5, 300, 300);

            MemoryStream stream = new MemoryStream();

            //Save the PDF document
            loadedDocument.Save(stream);

            //Close the PDF document
            loadedDocument.Close(true);            
          

            if (stream != null)
            {
			   stream.Position=0;
               ComposeMail("DigitalSignature.pdf", null, "Signing the document", "Syncfusion", stream);

            }
        }
		
		  public void ComposeMail(string fileName, string[] recipients, string subject, string messagebody, MemoryStream filestream)
        {
            string exception = string.Empty;
            string root = null;
            if (Android.OS.Environment.IsExternalStorageEmulated)
            {
                root = Android.OS.Environment.ExternalStorageDirectory.ToString();
            }
            else
                root = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

            Java.IO.File myDir = new Java.IO.File(root + "/Syncfusion");
            myDir.Mkdir();

            Java.IO.File file = new Java.IO.File(myDir, fileName);

            if (file.Exists()) file.Delete();

            try
            {
                FileOutputStream outs = new FileOutputStream(file);
                outs.Write(filestream.ToArray());

                outs.Flush();
                outs.Close();
            }
            catch (Exception e)
            {
                exception = e.ToString();
            }

            Intent email = new Intent(Android.Content.Intent.ActionSend);
            var uri = FileProvider.GetUriForFile(this.m_context, Application.Context.PackageName + ".provider", file);

            //file.SetReadable(true, true);
            email.PutExtra(Android.Content.Intent.ExtraSubject, subject);
            email.PutExtra(Intent.ExtraStream, uri);
            email.SetType("application/pdf");

            MainActivity.BaseActivity.StartActivity(email);
        }
    }
}