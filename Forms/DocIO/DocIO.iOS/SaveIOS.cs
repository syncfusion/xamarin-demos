#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.IO;

using Foundation;
using UIKit;
using QuickLook;

using Xamarin.Forms;
using SampleBrowser.DocIO.iOS;
using MessageUI;

[assembly: Dependency(typeof(SaveIOS))]
[assembly: Dependency(typeof(MailService))]
namespace SampleBrowser.DocIO.iOS
{
    class SaveIOS: ISave
    {
        public void Save(string filename, string contentType, MemoryStream stream)
        {
            string exception = string.Empty;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filePath = Path.Combine(path, filename);
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
            if (contentType == "application/html" || exception != string.Empty)
                return;
            UIViewController currentController = UIApplication.SharedApplication.KeyWindow.RootViewController;
            while (currentController.PresentedViewController != null)
                currentController = currentController.PresentedViewController;
            UIView currentView = currentController.View;

            QLPreviewController qlPreview = new QLPreviewController();
            QLPreviewItem item = new QLPreviewItemBundle(filename, filePath);
            qlPreview.DataSource = new PreviewControllerDS(item);
            
            //UIViewController uiView = currentView as UIViewController;

            currentController.PresentViewController((UIViewController)qlPreview, true, (Action)null);
        }
    }
    public class MailService : IMailService
    {
        public MailService()
        {
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

    }
}