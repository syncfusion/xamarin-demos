#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinIOInvoice.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using QuickLook;

[assembly: Dependency(typeof(SaveIOS))]
namespace XamarinIOInvoice.iOS
{
    class SaveIOS:ISave
    {
        public async Task SaveTextAsync(string filename,string contentType, MemoryStream s)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			string filePath = Path.Combine(path,filename);
			try
			{
				FileStream fileStream = File.Open(filePath, FileMode.Create);
				s.Position=0;
				s.CopyTo(fileStream);
				fileStream.Flush();
				fileStream.Close();
			}
			catch (Exception e)
			{

			}

			UIViewController currentController = UIApplication.SharedApplication.KeyWindow.RootViewController; 
			while (currentController.PresentedViewController != null)
				currentController = currentController.PresentedViewController;
			UIView currentView = currentController.View;

			QLPreviewController qlPreview = new QLPreviewController();
			QLPreviewItem item= new QLPreviewItemBundle(filename,filePath);
			qlPreview.DataSource = new PreviewControllerDS(item);

			currentController.PresentViewController (qlPreview, true, null);


        }
    }
}