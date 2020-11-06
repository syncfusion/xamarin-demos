#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using CoreGraphics;
using Foundation;
using QuickLook;
using System;
using System.Threading.Tasks;
using SampleBrowser;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Reflection;
using UIKit;

namespace SampleBrowser
{
    class SaveiOS
    {
		public void Save(string filename, String contentType, MemoryStream stream )
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
			if (exception != string.Empty)
				return;
			UIViewController currentController = UIApplication.SharedApplication.KeyWindow.RootViewController;
			while (currentController.PresentedViewController != null)
				currentController = currentController.PresentedViewController;
			UIView currentView = currentController.View;

			QLPreviewController qlPreview = new QLPreviewController();
			QLPreviewItem item = new QLPreviewItemBundle(filename, filePath);
			qlPreview.DataSource = new PreviewControllerDS(item);

			currentController.PresentViewController((UIViewController)qlPreview, true, (Action)null);
        }
    }
}