#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfPdfViewer.XForms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SampleBrowser.Core;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using System.IO;

namespace SampleBrowser.SfPdfViewer
{
    [Preserve(AllMembers = true)]
    public partial class FillAndSign : SampleView
    {
        private float backUpVerticalOffset = 0;
        private float backUpHorizontalOffset = 0;
        private float backUpZoomFactor = 0;
        string currentDocument = "FormFillingDocument";
        private bool canRestoreBackup = false;
        private bool isPageSwitched = false;
        public FillAndSign()
        {
            InitializeComponent();
            pdfViewerControl.DocumentSaveInitiated += PdfViewerControl_DocumentSaved;
            pdfViewerControl.DocumentLoaded += PdfViewerControl_DocumentLoaded;
            (BindingContext as GettingStartedViewModel).DocumentName = currentDocument;
            isPageSwitched = true;
        }
        private void PdfViewerControl_DocumentLoaded(object sender, EventArgs args)
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                if (canRestoreBackup)
                {
                    pdfViewerControl.ZoomPercentage = backUpZoomFactor;
                    pdfViewerControl.VerticalOffset = backUpVerticalOffset;
                    pdfViewerControl.HorizontalOffset = backUpHorizontalOffset;
                    canRestoreBackup = false;
                }
            }
        }

        public override void OnAppearing()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                string filePath = string.Empty;
#if COMMONSB
            filePath = "SampleBrowser.Samples.PdfViewer.Samples.";

#else
                filePath = "SampleBrowser.SfPdfViewer.";

#endif
                canRestoreBackup = !isPageSwitched;
                if (!isPageSwitched)
                {
                    (BindingContext as GettingStartedViewModel).PdfDocumentStream = (typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream(filePath + "Assets." + currentDocument + ".pdf"));
                }
            }
        }

        public override void OnDisappearing()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                backUpHorizontalOffset = pdfViewerControl.HorizontalOffset;
                backUpVerticalOffset = pdfViewerControl.VerticalOffset;
                backUpZoomFactor = pdfViewerControl.ZoomPercentage;
                pdfViewerControl.Unload();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                isPageSwitched = false;
            }
        }

        private void PdfViewerControl_DocumentSaved(object sender, DocumentSaveInitiatedEventArgs args)
        {
            string filePath = DependencyService.Get<ISave>().Save(args.SaveStream as MemoryStream);
            string message = "The PDF has been saved to " + filePath;
            DependencyService.Get<IAlertView>().Show(message);
        }
    }
}

