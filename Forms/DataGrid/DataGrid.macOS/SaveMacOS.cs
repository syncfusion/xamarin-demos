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
using AppKit;
using QuickLook;
using UIView = AppKit.NSView;
using Xamarin.Forms;
using SampleBrowser.SfDataGrid.MacOS;

[assembly: Dependency(typeof(SaveMacOS))]
namespace SampleBrowser.SfDataGrid.MacOS
{
    [Preserve(AllMembers = true)]
    class SaveMacOS : ISave
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

            NSWorkspace.SharedWorkspace.OpenFile(filePath);
        }
    }
}