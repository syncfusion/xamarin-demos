#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "MailService.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using MessageUI;
using SampleBrowser.SfDataGrid;
using SampleBrowser.SfDataGrid.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(MailService))]

[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Reviewed.")]

namespace SampleBrowser.SfDataGrid.iOS
{
    /// <summary>
    ///  A dependency service used to open the required application.
    /// </summary>
    public class MailService : IMailService
    {
        /// <summary>
        /// Initializes a new instance of the MailService class.
        /// </summary>
        public MailService()
        {
        }

        /// <summary>
        /// Use this method to compose mail
        /// </summary>
        /// <param name="fileName">string type of parameter fileName</param>
        /// <param name="recipients">string type of parameter recipients</param>
        /// <param name="subject">string type of parameter subject</param>
        /// <param name="messagebody">string type of parameter message body</param>
        /// <param name="stream">MemoryStream type parameter stream</param>
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

                mailer.AddAttachmentData(NSData.FromFile(filePath), this.GetMimeType(fileName), Path.GetFileName(fileName));
                UIViewController vc = UIApplication.SharedApplication.KeyWindow.RootViewController;
                while (vc.PresentedViewController != null)
                {
                    vc = vc.PresentedViewController;
                }

                vc.PresentViewController(mailer, true, null);
            }
        }

        /// <summary>
        /// This method return the application type
        /// </summary>
        /// <param name="filename">indicates file name as string type</param>
        /// <returns>returns the Image type</returns>
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