#region Copyright Syncfusion Inc. 2001-2018.
// <copyright file="SaveIOS.cs" company=" Syncfusion Inc.">
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
// </copyright>
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using QuickLook;
using SampleBrowser.Core;
using SampleBrowser.XlsIO.IOS;
using UIKit;

using Xamarin.Forms;

[assembly: Dependency(typeof(SaveIOS))]

namespace SampleBrowser.XlsIO.IOS
{
    /// <summary>
    /// This class is used to save option for IOS.
    /// </summary>
    public class SaveIOS : ISave
    {
        /// <summary>
        /// This method used to provide save option for IOS.
        /// </summary>
        /// <param name="filename">Name of the output file</param>
        /// <param name="contentType">Content type of the output file</param>
        /// <param name="stream">Input file of MemoryStream</param>
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
            finally
            {
                if (contentType != "application/html")
                {
                    stream.Dispose();
                }
            }

            if (contentType == "application/html" || exception != string.Empty)
            {
                return;
            }

            UIViewController currentController = UIApplication.SharedApplication.KeyWindow.RootViewController;
            while (currentController.PresentedViewController != null)
            {
                currentController = currentController.PresentedViewController;
            }

            UIView currentView = currentController.View;

            QLPreviewController preview = new QLPreviewController();
            QLPreviewItem item = new QLPreviewItemBundle(filename, filePath);
            preview.DataSource = new PreviewControllerDS(item);

            // UIViewController uiView = currentView as UIViewController;
            currentController.PresentViewController((UIViewController)preview, true, (Action)null);
        }
    }
}