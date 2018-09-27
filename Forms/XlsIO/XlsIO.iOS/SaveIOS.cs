#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Foundation;
using UIKit;
using QuickLook;

using Xamarin.Forms;
using SampleBrowser.XlsIO.iOS;
using SampleBrowser.Core;
[assembly: Dependency(typeof(SaveIOS))]
namespace SampleBrowser.XlsIO.iOS
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
            finally
            {
                if(contentType != "application/html")
                    stream.Dispose();
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
}