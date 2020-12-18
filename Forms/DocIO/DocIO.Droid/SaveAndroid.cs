#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.IO;
using Android.Content;
using Java.IO;
using Xamarin.Forms;
using System.Threading.Tasks;
using SampleBrowser.DocIO.Droid;
using SampleBrowser.Core;
using Android.Support.V4.Content;

[assembly: Dependency(typeof(SaveAndroid))]
[assembly: Dependency(typeof(MailService))]
namespace SampleBrowser.DocIO.Droid
{
    class SaveAndroid : ISave
    {
        public void Save(string fileName, String contentType, MemoryStream stream)
        {            
            string exception = string.Empty;
            string root = null;
            if (Android.OS.Environment.IsExternalStorageEmulated)
            {
                root = Android.OS.Environment.ExternalStorageDirectory.ToString();
            }
            else
                root = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            Java.IO.File myDir = new Java.IO.File(root + "/Syncfusion");
            myDir.Mkdir();

            Java.IO.File file = new Java.IO.File(myDir, fileName);

            if (file.Exists()) file.Delete();

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
            if (file.Exists() && contentType != "application/html")
            {
                Android.Net.Uri path = Android.Net.Uri.FromFile(file);
                string extension = Android.Webkit.MimeTypeMap.GetFileExtensionFromUrl(Android.Net.Uri.FromFile(file).ToString());
                string mimeType = Android.Webkit.MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);
                Intent intent = new Intent(Intent.ActionView);
                intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask);
				path = FileProvider.GetUriForFile(Forms.Context, Android.App.Application.Context.PackageName + ".provider", file);
				intent.SetDataAndType(path, mimeType);
				intent.AddFlags(ActivityFlags.GrantReadUriPermission); 
				Forms.Context.StartActivity(Intent.CreateChooser(intent, "Choose App"));
            }
        }
    }

    public class MailService : IMailService
    {
        public MailService()
        {
        }
        public void ComposeMail(string fileName, string[] recipients, string subject, string messagebody, MemoryStream filestream)
        {
            string exception = string.Empty;
            string root = null;
            if (Android.OS.Environment.IsExternalStorageEmulated)
            {
                root = Android.OS.Environment.ExternalStorageDirectory.ToString();
            }
            else
                root = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

            Java.IO.File myDir = new Java.IO.File(root + "/Syncfusion");
            myDir.Mkdir();

            Java.IO.File file = new Java.IO.File(myDir, fileName);

            if (file.Exists()) file.Delete();

            try
            {
                FileOutputStream outs = new FileOutputStream(file);
                outs.Write(filestream.ToArray());

                outs.Flush();
                outs.Close();
            }
            catch (Exception e)
            {
                exception = e.ToString();
            }

            Intent email = new Intent(Android.Content.Intent.ActionSend);
            var uri = Android.Net.Uri.Parse("file:///" + file.AbsolutePath);

            //file.SetReadable(true, true);
            email.PutExtra(Android.Content.Intent.ExtraSubject, subject);
            email.PutExtra(Intent.ExtraStream, uri);
            email.SetType("application/pdf");

            //MainActivity.MainPageActivity.StartActivity(email);
        }
    }
}