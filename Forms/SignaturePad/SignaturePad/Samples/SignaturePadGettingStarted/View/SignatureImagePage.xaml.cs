#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.Pdf.Parsing;
using Syncfusion.SfPdfViewer.XForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfSignaturePad
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignatureImagePage : ContentPage ,  INotifyPropertyChanged
    {
        /// <summary>
        /// m_pdfDocumentStream
        /// </summary>
        private Stream m_pdfDocumentStream;

        /// <summary>
        /// filePath
        /// </summary>
        string filePath = string.Empty;

        /// <summary>
        /// currentDocument
        /// </summary>
        string currentDocument = "FormFillingDocument";

        /// <summary>
        /// Signimage
        /// </summary>
        Image Signimage = new Image();

        /// <summary>
        /// PdfDocumentStream
        /// </summary>
        public Stream PdfDocumentStream
        {
            get
            {
                return m_pdfDocumentStream;
            }
            set
            {
                m_pdfDocumentStream = value;
                NotifyPropertyChanged("PdfDocumentStream");

            }
        }

        /// <summary>
        /// SignatureImagePage
        /// </summary>
        /// <param name="image">image</param>
        public SignatureImagePage(ImageSource imagesource)
        {
            InitializeComponent();
            BindingContext = this;
            pdfViewerControl.IsToolbarVisible = false;
            pdfViewerControl.DocumentLoaded += PdfViewerControl_DocumentLoaded;
#if COMMONSB
            filePath = "SampleBrowser.Samples.PdfViewer.Samples.";
#else
            filePath = "SampleBrowser.SfSignaturePad.";
#endif
            Signimage.WidthRequest = 200;
            Signimage.HeightRequest = 150;
            Signimage.Source = imagesource;
        }

 

        /// <summary>
        /// OnAppearing
        /// </summary>
        protected override void OnAppearing()
        {
            PdfDocumentStream = (typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream(filePath + "Assets." + currentDocument + ".pdf"));
            PdfLoadedDocument ldoc = new PdfLoadedDocument(PdfDocumentStream);
            if (ldoc.Form != null)
            {
                foreach (var field in ldoc.Form.Fields)
                {
                    if (field is PdfLoadedSignatureField)
                    {
                        (field as PdfLoadedSignatureField).ReadOnly = true;
                    }
                }
            }
            MemoryStream strm = new MemoryStream();
            ldoc.Save(strm);
            pdfViewerControl.LoadDocument(strm);
        }
        private async void PdfViewerControl_DocumentLoaded(object sender, EventArgs args)
        {
            await Task.Delay(100);
            if(Device.RuntimePlatform == "Android")
                pdfViewerControl.AddStamp(Signimage, 1, new Point(250, 850));
            else
                pdfViewerControl.AddStamp(Signimage, 1, new Point(220, 600));
        }

        public event PropertyChangedEventHandler PropertyChangedEvent;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChangedEvent != null)
            {
                PropertyChangedEvent(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}