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
    public partial class PDFViewerGettingStarted : SampleView
    {
        private float m_backUpVerticalOffset = 0;
        private float m_backUpHorizontalOffset = 0;
        private float m_backUpZoomFactor = 0;
        string currentDocument = "GIS Succinctly";
        private bool m_canRestoreBackup = false;
        private bool m_isPageSwitched = false;
        public PDFViewerGettingStarted()
        {
            InitializeComponent();
            pdfViewerControl.DocumentSaveInitiated += PdfViewerControl_DocumentSaved;
            pdfViewerControl.DocumentLoaded += PdfViewerControl_DocumentLoaded;
            (BindingContext as GettingStartedViewModel).DocumentName = currentDocument;
            m_isPageSwitched = true;
        }
        private void PdfViewerControl_DocumentLoaded(object sender, EventArgs args)
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                if (m_canRestoreBackup)
                {
                    pdfViewerControl.ZoomPercentage = m_backUpZoomFactor;
                    pdfViewerControl.VerticalOffset = m_backUpVerticalOffset;
                    pdfViewerControl.HorizontalOffset = m_backUpHorizontalOffset;
                    m_canRestoreBackup = false;
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
                m_canRestoreBackup = !m_isPageSwitched;
                if (!m_isPageSwitched)
                {
                    (BindingContext as GettingStartedViewModel).PdfDocumentStream = (typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream(filePath+"Assets." + currentDocument + ".pdf"));
                }
            }
        }

        public override void OnDisappearing()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                m_backUpHorizontalOffset = pdfViewerControl.HorizontalOffset;
                m_backUpVerticalOffset = pdfViewerControl.VerticalOffset;
                m_backUpZoomFactor = pdfViewerControl.ZoomPercentage;
                pdfViewerControl.Unload();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                m_isPageSwitched = false;
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

