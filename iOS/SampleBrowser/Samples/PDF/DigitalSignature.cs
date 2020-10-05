#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.IO;
using Syncfusion.Drawing;
using System.Reflection;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Barcode;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security; 
using MessageUI;
#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using CGRect = System.Drawing.RectangleF;
using CGPoint = System.Drawing.PointF;
using CGSize = System.Drawing.SizeF;
#endif

namespace SampleBrowser
{
    public partial class DigitalSignature : SampleView
    {
        CGRect frameRect = new CGRect();
        float frameMargin = 8.0f;
        UILabel label1;
        UIButton button;
        public DigitalSignature()
        {
           
            label1 = new UILabel();
          
            button = new UIButton(UIButtonType.System);
            button.TouchUpInside += OnButtonClicked;
        }

        void LoadAllowedTextsLabel()
        {

            label1.Frame = frameRect;
            label1.TextColor = UIColor.FromRGB(38 / 255.0f, 38 / 255.0f, 38 / 255.0f);
            label1.Text = "This sample demonstrates how to digitally sign PDF document using a .pfx certificate.";
            label1.Font = UIFont.SystemFontOfSize(15);
            label1.Lines = 0;
            label1.LineBreakMode = UILineBreakMode.WordWrap;
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                label1.Font = UIFont.SystemFontOfSize(18);
                label1.Frame = new CGRect(0, 12, frameRect.Location.X + frameRect.Size.Width, 50);
            }
            else
            {
                label1.Frame = new CGRect(frameRect.Location.X, 12, frameRect.Size.Width, 50);

            }
            this.AddSubview(label1);


          
            button.SetTitle("Sign and Email", UIControlState.Normal);
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                button.Frame = new CGRect(0, 70, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            else
            {
                button.Frame = new CGRect(frameRect.Location.X, 70, frameRect.Size.Width, 10);

            }

            this.AddSubview(button);
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            Stream docStream = typeof(Booklet).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Assets.SalesOrderDetail.pdf");
            //Load the PDF document into the loaded document object.
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

            //Get the certificate stream from .pfx file.
            Stream certificateStream = typeof(DigitalSignature).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Assets.PDF.pfx");

            //Create PdfCertificate using certificate stream and password.
            PdfCertificate pdfCert = new PdfCertificate(certificateStream, "syncfusion");

            //Add certificate to document first page.
            PdfSignature signature = new PdfSignature(loadedDocument, loadedDocument.Pages[0], pdfCert, "Signature");

            signature.Bounds = new Syncfusion.Drawing.RectangleF(5, 5, 300, 300);

            MemoryStream stream = new MemoryStream();

            //Save the PDF document
            loadedDocument.Save(stream);

            //Close the PDF document
            loadedDocument.Close(true);

            if (stream != null)
            {
                stream.Position = 0;
                ComposeMail("DigitalSignature.pdf", null, "Signing the document", "Syncfusion", stream);

            }
        }
		
		  public void ComposeMail(string fileName, string[] recipients, string subject, string messagebody, MemoryStream stream)
        {
            if (MFMailComposeViewController.CanSendMail)
            {

                var mailer = new MFMailComposeViewController();

                mailer.SetMessageBody(messagebody ?? string.Empty, false);
                mailer.SetSubject(subject ?? subject);
                mailer.Finished += (s, e) => ((MFMailComposeViewController)s).DismissViewController(true, () => { });


                string exception = string.Empty;
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string filePath = Path.Combine(path, fileName);
                try
                {
                    FileStream fileStream = File.Open(filePath, FileMode.Create);
                    stream.Position = 0;
                    stream.CopyTo(fileStream);
                    fileStream.Flush();
                    fileStream.Close();
                }
                catch (Exception e)
                {
                    exception = e.ToString();
                }
                finally
                {
                }


                mailer.AddAttachmentData(NSData.FromFile(filePath), GetMimeType(fileName), Path.GetFileName(fileName));



                UIViewController vc = UIApplication.SharedApplication.KeyWindow.RootViewController;
                while (vc.PresentedViewController != null)
                {
                    vc = vc.PresentedViewController;
                }
                vc.PresentViewController(mailer, true, null);
            }
			else
            {
                var alertController = UIAlertController.Create("Email not supported", "Please configure the email to send PDF document", UIAlertControllerStyle.Alert);
                alertController.AddAction(UIAlertAction.Create("OK",UIAlertActionStyle.Default,null));
                UIViewController vc = UIApplication.SharedApplication.KeyWindow.RootViewController;
				while (vc.PresentedViewController != null)
				{
					vc = vc.PresentedViewController;
				}
                vc.PresentViewController(alertController,true,null);
            }
        }
 private string GetMimeType(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                return null;
            }

            var extension = Path.GetExtension(filename.ToLowerInvariant());

            switch (extension)
            {
                case "png":
                    return "image/png";
                case "doc":
                    return "application/msword";
                case "pdf":
                    return "application/pdf";
                case "jpeg":
                case "jpg":
                    return "image/jpeg";
                case "zip":
                case "docx":
                case "xlsx":
                case "pptx":
                    return "application/zip";
                case "htm":
                case "html":
                    return "text/html";
            }

            return "application/octet-stream";
        }
        public override void LayoutSubviews()
        {
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                frameMargin = 0.0f;
            }
            frameRect = Bounds;
            frameRect.Location = new CGPoint(frameRect.Location.X + frameMargin, frameRect.Location.Y + 1.5f * frameMargin);
            frameRect.Size = new CGSize(frameRect.Size.Width - (frameRect.Location.X + frameMargin), frameRect.Size.Height - (frameRect.Location.Y + 1.5f * frameMargin));

            LoadAllowedTextsLabel();

            base.LayoutSubviews();
        }
    }
}
