#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Syncfusion.SfPdfViewer.Android;
using System.IO;
using System.Reflection;
using Android.Views.InputMethods;
using System.Diagnostics;
using static Android.Views.ViewGroup;
using Android.Graphics;
namespace SampleBrowser
{
    [Activity(ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class PdfViewerDemo : SamplePage
    {
        SfPdfViewer pdfViewerControl;
        LinearLayout mainView;
        public override View GetSampleContent(Context context)
        {
            LayoutInflater layoutInflater = LayoutInflater.From(context);
            mainView = (LinearLayout)layoutInflater.Inflate(Resource.Layout.PDFViewer, null);
            pdfViewerControl = (SfPdfViewer)mainView.FindViewById(Resource.Id.pdfviewercontrol);
            Stream docStream = typeof(PdfViewerDemo).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDFViewer.Assets.GIS Succinctly.pdf");
            pdfViewerControl.LoadDocument(docStream);
            pdfViewerControl.DocumentSaveInitiated += PdfViewerControl_DocumentSaveInitiated;
            pdfViewerControl.PreserveSignaturePadOrientation = true;
            return mainView;
        }
        
         private void PdfViewerControl_DocumentSaveInitiated(object sender, DocumentSaveInitiatedEventArgs args)
        {
            MemoryStream stream = args.SavedStream as MemoryStream;
            string root = null;
            string fileName = "sample.pdf";
            if (Android.OS.Environment.IsExternalStorageEmulated)
            {
                root = Android.OS.Environment.ExternalStorageDirectory.ToString();
            }
            else
                root = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            Java.IO.File directory = new Java.IO.File(root + "/Syncfusion");
            directory.Mkdir();
            Java.IO.File file = new Java.IO.File(directory, fileName);
            if (file.Exists()) file.Delete();
            Java.IO.FileOutputStream outputStream = new Java.IO.FileOutputStream(file);
            outputStream.Write(stream.ToArray());
            outputStream.Flush();
            outputStream.Close();
            AlertDialog.Builder alertDialog = new AlertDialog.Builder(mainView.Context);
            alertDialog.SetTitle("Save");
            alertDialog.SetMessage("The modified document is saved in the below location. " + "\n" + file.Path);
            alertDialog.SetPositiveButton("OK", (senderAlert, e) => { });
            Dialog dialog = alertDialog.Create();
            dialog.Show();
        }
		
		public override void Destroy()
        {
            pdfViewerControl.Unload();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            base.Destroy(); 
        }
    }
}