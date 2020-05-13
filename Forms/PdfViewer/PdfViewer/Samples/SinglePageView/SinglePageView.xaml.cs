#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
    public partial class SinglePageView : SampleView
    {
        string currentDocument = "Xamarin Forms Succinctly";
        public SinglePageView()
        {
            InitializeComponent();
            pdfViewerControl.DocumentSaveInitiated += PdfViewerControl_DocumentSaved;
            (BindingContext as GettingStartedViewModel).DocumentName = currentDocument;
        }
        public override void OnAppearing()
        {
            
			string filePath = string.Empty;
#if COMMONSB
            filePath = "SampleBrowser.Samples.PdfViewer.Samples.";

#else
            filePath = "SampleBrowser.SfPdfViewer.";
           
#endif
            (BindingContext as GettingStartedViewModel).PageByPageDocumentStream = (typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream(filePath+"Assets." + currentDocument + ".pdf"));
            
        }

        public override void OnDisappearing()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                pdfViewerControl.Unload();
                GC.Collect();
                GC.WaitForPendingFinalizers();
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

