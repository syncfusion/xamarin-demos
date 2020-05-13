#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.DocIO;
using SampleBrowser.Core;
using Syncfusion.DocIO.DLS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SampleBrowser.DocIO;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;
using Syncfusion.OfficeChart;

namespace SampleBrowser.DocIO
{
    public partial class WordToPDF : SampleView
    {
        public WordToPDF()
        {
            InitializeComponent();

            if (Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.btnGenerate.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.BackgroundColor = Color.Gray;
                this.btnInpTemplate.HorizontalOptions = LayoutOptions.Start;
                this.btnInpTemplate.VerticalOptions = LayoutOptions.Center;
                this.btnInpTemplate.BackgroundColor = Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Description.FontSize = 13.5;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
                this.btnInpTemplate.VerticalOptions = LayoutOptions.Center;
            }
        }

        void OnInputButtonClicked(object sender, EventArgs e)
        {
            string resourcePath = "";
#if COMMONSB
			resourcePath = "SampleBrowser.Samples.DocIO.Samples.Templates.";
#else
            resourcePath = "SampleBrowser.DocIO.Samples.Templates.";
#endif
            Assembly assembly = typeof(WordToPDF).GetTypeInfo().Assembly;
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath + "WordtoPDF.docx");

            MemoryStream stream = new MemoryStream();
            fileStream.CopyTo(stream);
            stream.Position = 0;
            fileStream.Dispose();
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("InputTemplate.docx", "application/msword", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("InputTemplate.docx", "application/msword", stream);
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            Assembly assembly = typeof(WordToPDF).GetTypeInfo().Assembly;
            // Creating a new document.
            WordDocument document = new WordDocument();
#if COMMONSB
            string rootPath = "SampleBrowser.Samples.DocIO.Samples.Templates.";
#else
            string rootPath = "SampleBrowser.DocIO.Samples.Templates.";
#endif
            Stream inputStream = assembly.GetManifestResourceStream(rootPath + "WordtoPDF.docx");
            
            // Loads the stream into Word Document.
            WordDocument wordDocument = new WordDocument(inputStream, Syncfusion.DocIO.FormatType.Automatic);

            //Instantiation of DocIORenderer for Word to PDF conversion
            DocIORenderer render = new DocIORenderer();

            //Sets Chart rendering Options.
            render.Settings.ChartRenderingOptions.ImageFormat = ExportImageFormat.Jpeg;

            //Converts Word document into PDF document
            PdfDocument pdfDocument = render.ConvertToPDF(wordDocument);

            //Releases all resources used by the Word document and DocIO Renderer objects
            render.Dispose();

            wordDocument.Dispose();

            //Saves the PDF file
            MemoryStream outputStream = new MemoryStream();
            pdfDocument.Save(outputStream);

            //Closes the instance of PDF document object
            pdfDocument.Close();

            if (Device.RuntimePlatform == Device.UWP)
                DependencyService.Get<ISaveWindowsPhone>()
                    .Save("WordtoPDF.pdf", "application/pdf", outputStream);
            else
                DependencyService.Get<ISave>().Save("WordtoPDF.pdf", "application/pdf", outputStream);
        }
    }
}
