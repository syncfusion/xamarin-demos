#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfPdfViewer
{
    [Preserve(AllMembers = true)]
    internal class GettingStartedViewModel: INotifyPropertyChanged
    {
        private Stream m_pdfDocumentStream;

        private string m_documentName;

        string filePath = string.Empty;

        public event PropertyChangedEventHandler PropertyChanged;

        public string DocumentName
        {
            get
            {
                return m_documentName;
            }
            set
            {
                m_documentName = value;
                PdfDocumentStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream(filePath + "Assets." + DocumentName + ".pdf");
            }
        }

        public GettingStartedViewModel()
        {
           
#if COMMONSB
            filePath = "SampleBrowser.Samples.PdfViewer.Samples.";

#else
            filePath = "SampleBrowser.SfPdfViewer.";
           
#endif
        }
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
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
