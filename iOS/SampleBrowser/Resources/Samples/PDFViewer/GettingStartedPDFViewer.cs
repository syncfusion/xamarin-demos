#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
	class PdfViewerDemo : SampleView
	{
		private SfPdfViewer pdfViewerControl;
		private UIView parentView;
		public PdfViewerDemo()
		{
			parentView = new UIView(this.Frame);
		}


		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			parentView.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);
			pdfViewerControl = new SfPdfViewer();
			parentView.AddSubview(pdfViewerControl);
			AddSubview(parentView);
			var fileStream = typeof(PdfViewerDemo).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDFViewer.Assets.GIS Succinctly.pdf");
			pdfViewerControl.LoadDocument(fileStream);
		}
	}
}
