#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

[assembly:Dependency(typeof(SampleBrowser.SfPdfViewer.Droid.SaveAndroid))]
[assembly:Dependency(typeof(SampleBrowser.SfPdfViewer.Droid.DeviceInfo))]
[assembly: Dependency(typeof(SampleBrowser.SfPdfViewer.Droid.BrowserURI))]

namespace SampleBrowser.SfPdfViewer.Droid
{
    public class SaveAndroid : ISave
    {
        public string Save(MemoryStream stream)
        {
            string root = null;
            string fileName = "SavedDocument.pdf";
            if (Android.OS.Environment.IsExternalStorageEmulated)
            {
#pragma warning disable CS0618 // Type or member is obsolete
                root = Android.OS.Environment.ExternalStorageDirectory.ToString();
#pragma warning restore CS0618 // Type or member is obsolete
            }
            Java.IO.File myDir = new Java.IO.File(root + "/Syncfusion");
            myDir.Mkdir();
            Java.IO.File file = new Java.IO.File(myDir, fileName);
            string filePath = file.Path;
            if (file.Exists()) file.Delete();
            Java.IO.FileOutputStream outs = new Java.IO.FileOutputStream(file);
            outs.Write(stream.ToArray());
            var ab = file.Path;
            outs.Flush();
            outs.Close();
            return filePath;
        }
    }

    public class BrowserURI : IDeviceOpenURI
    {
        public void OpenURI(string selectedText)
        {
            String escapedQuery = Java.Net.URLEncoder.Encode(selectedText, "UTF-8");
            var uri = Android.Net.Uri.Parse($"https://www.google.com/search?q={escapedQuery}");
            var intent = new Intent(Intent.ActionView, uri);
            intent.AddFlags(ActivityFlags.NewTask);
            intent.AddFlags(ActivityFlags.MultipleTask);
            Android.App.Application.Context.StartActivity(intent);
        }
    }

    public class DeviceInfo : IDeviceInfo
    {
        public ScreenSize GetScreenSize()
        {
            if ((Resources.System.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeNormal)
                return ScreenSize.Normal;
            else if ((Resources.System.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeLarge)
                return ScreenSize.Large;
            else if ((Resources.System.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeSmall)
                return ScreenSize.Small;
            else if ((Resources.System.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeXlarge)
                return ScreenSize.Small;
            return ScreenSize.Normal;
        }
    }
}