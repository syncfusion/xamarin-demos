#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfPdfViewer.XForms;
using SampleBrowser.Core;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using System.IO;

namespace SampleBrowser.SfPdfViewer
{
    [Preserve(AllMembers = true)]
    public partial class Annotations : SampleView
    {
        string currentDocument = "Annotations";
        public Annotations()
        {
            InitializeComponent();
            pdfViewerControl.DocumentSaveInitiated += PdfViewerControl_DocumentSaved;
            (BindingContext as GettingStartedViewModel).DocumentName = currentDocument;
        }

        private void PdfViewerControl_DocumentSaved(object sender, DocumentSaveInitiatedEventArgs args)
        {
            string filePath = DependencyService.Get<ISave>().Save(args.SaveStream as MemoryStream);
            string message = "The PDF has been saved to " + filePath;
            DependencyService.Get<IAlertView>().Show(message);
        }
    }
}

