#region Copyright Syncfusion Inc. 2001-2018.
// <copyright file="SaveAndroid.cs" company=" Syncfusion Inc.">
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
// </copyright>
#endregion
using System;
using System.IO;
using System.Threading.Tasks;
using Android.Content;
using Android.Support.V4.Content;
using Java.IO;
using SampleBrowser.Core;
using SampleBrowser.XlsIO;
using SampleBrowser.XlsIO.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(SaveAndroid))]

namespace SampleBrowser.XlsIO.Droid
{
    /// <summary>
    /// This method used to save the files.
    /// </summary>
    internal class SaveAndroid : ISave
    {
        /// <summary>
        /// Save method used to save the files using <see cref="MemoryStream"/> class.
        /// </summary>
        /// <param name="fileName">Name of the output file.</param>
        /// <param name="contentType">Content type of the output file.</param>
        /// <param name="stream">The file in the form of <see cref="MemoryStream"/> class.</param>
        public void Save(string fileName, string contentType, MemoryStream stream)
        {
            string exception = string.Empty;
            string root = null;
            if (Android.OS.Environment.IsExternalStorageEmulated)
            {
                root = Android.OS.Environment.ExternalStorageDirectory.ToString();
            }
            else
            {
                root = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
        
            Java.IO.File myDir = new Java.IO.File(root + "/Syncfusion");
            myDir.Mkdir();
        
            Java.IO.File file = new Java.IO.File(myDir, fileName);
        
            if (file.Exists())
            {
                file.Delete();
            }
        
            try
            {
                FileOutputStream outs = new FileOutputStream(file);
                outs.Write(stream.ToArray());
        
                outs.Flush();
                outs.Close();
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
        
            if (file.Exists() && contentType != "application/html")
            {
                Android.Net.Uri path = Android.Net.Uri.FromFile(file);
                string extension = Android.Webkit.MimeTypeMap.GetFileExtensionFromUrl(Android.Net.Uri.FromFile(file).ToString());
                string mimeType = Android.Webkit.MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);
                Intent intent = new Intent(Intent.ActionView);
                intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask);
                path = FileProvider.GetUriForFile(Android.App.Application.Context, Android.App.Application.Context.PackageName + ".provider", file);
                intent.SetDataAndType(path, mimeType);
                intent.AddFlags(ActivityFlags.GrantReadUriPermission);
                Forms.Context.StartActivity(Intent.CreateChooser(intent, "Choose App"));
            }
        }
    }
}