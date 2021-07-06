#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Foundation;
using UIKit;
using System.IO;

[assembly: Dependency(typeof(SampleBrowser.SfPdfViewer.iOS.SaveiOS))]
[assembly: Dependency(typeof(SampleBrowser.SfPdfViewer.iOS.BrowserURI))]
namespace SampleBrowser.SfPdfViewer.iOS
{
    public class SaveiOS : ISave
    {
        public string Save(MemoryStream fileStream)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filepath = Path.Combine(path, "SavedDocument.pdf");

            FileStream outputFileStream = File.Open(filepath, FileMode.Create);
            fileStream.Position = 0;
            fileStream.CopyTo(outputFileStream);
            outputFileStream.Close();
            return filepath;
        }
    }

    public class BrowserURI : IDeviceOpenURI
    {
        public void OpenURI(string selectedText)
        {
            Foundation.NSUrl url = new Foundation.NSUrl($"https://www.google.com/search?q={selectedText}");
            UIApplication.SharedApplication.OpenUrl(url);
        }
    }
}