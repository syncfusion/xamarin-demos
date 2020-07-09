#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Reflection;
using CoreGraphics;
using Syncfusion.SfPdfViewer.iOS;
using UIKit;
using System.Timers;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using Foundation;
namespace SampleBrowser
{
	class SinglePageView : SampleView
	{
		private SfPdfViewer pdfViewerControl;
		private UIView parentView;
		public SinglePageView()
		{
			parentView = new UIView(this.Frame);
		}


		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			parentView.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);
			pdfViewerControl = new SfPdfViewer();
			parentView.AddSubview(pdfViewerControl);
            pdfViewerControl.PageViewMode = PageViewMode.PageByPage;
			AddSubview(parentView);
			var fileStream = typeof(PdfViewerDemo).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDFViewer.Assets.Xamarin Forms Succinctly.pdf");
			pdfViewerControl.LoadDocument(fileStream);
			pdfViewerControl.DocumentSaveInitiated += PdfViewerControl_DocumentSaveInitiated;
            pdfViewerControl.PreserveSignaturePadOrientation = true;
		}
		
		private void PdfViewerControl_DocumentSaveInitiated(object sender, DocumentSaveInitiatedEventArgs args)
        {
            Stream stream = args.SaveStream as MemoryStream;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filepath = Path.Combine(path, "savedDocument.pdf");

            FileStream outputFillStream = File.Open(filepath, FileMode.Create);
            stream.Position = 0;
            stream.CopyTo(outputFillStream);
            outputFillStream.Close();

            UIAlertView alertview = new UIAlertView();
            alertview.Frame = new CGRect(20, 100, 200, 200);
            alertview.Message = filepath;
            alertview.Title = "The modified document is saved in the below location.";
            alertview.AddButton("Ok");
            alertview.Show();
        }
	}
}
