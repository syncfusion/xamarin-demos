#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
using System.Reflection;
using Xamarin.Forms;
using Syncfusion.Office;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;

namespace SampleBrowser.DocIO
{
    public partial class MarkdownToWord : SampleView
    {
        public MarkdownToWord()
        {
            InitializeComponent();

            this.docxButton.IsChecked = true;

            if (Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Content_1.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.HorizontalOptions = LayoutOptions.Start;
                this.Content_1.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.BackgroundColor = Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Content_1.FontSize = 13.5;
                this.Content_1.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
            }
        }
        void OnButtonClicked(object sender, EventArgs e)
        {
            Assembly assembly = typeof(MarkdownToWord).GetTypeInfo().Assembly;
#if COMMONSB
            string rootPath = "SampleBrowser.Samples.DocIO.Samples.Templates.";
#else
            string rootPath = "SampleBrowser.DocIO.Samples.Templates.";
#endif
            Stream inputStream = assembly.GetManifestResourceStream(rootPath + "MarkdownToWord.md");

            // Loads the stream into Word Document.
            WordDocument document = new WordDocument(inputStream, Syncfusion.DocIO.FormatType.Markdown);
            string filename = "";
            string contenttype = "";
            MemoryStream outputStream = new MemoryStream();
            if (this.pdfButton.IsChecked != null && (bool)this.pdfButton.IsChecked)
            {
                filename = "MarkdownToWord.pdf";
                contenttype = "application/pdf";
                DocIORenderer renderer = new DocIORenderer();
                PdfDocument pdfDoc = renderer.ConvertToPDF(document);
                pdfDoc.Save(outputStream);
                pdfDoc.Close();
            }
            else if(this.htmlButton.IsChecked != null && (bool)this.htmlButton.IsChecked)
            {
                filename = "MarkdownToWord.html";
                contenttype = "application/html";
                document.Save(outputStream, FormatType.Html);
            }
            else
            {
                filename = "MarkdownToWord.docx";
                contenttype = "application/msword";
                document.Save(outputStream, FormatType.Docx);
            }
            document.Close();

            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save(filename, contenttype, outputStream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save(filename, contenttype, outputStream);
            
            if (contenttype == "application/html" && !(Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP))
            {
                //Set the stream to start position to read the content as string
                outputStream.Position = 0;
                StreamReader reader = new StreamReader(outputStream);
                string htmlString = reader.ReadToEnd();

                //Set the HtmlWebViewSource to the html string
                HtmlWebViewSource html = new HtmlWebViewSource();
                html.Html = htmlString;

                //Create the web view control to view the web page
                WebView view = new WebView();
                view.Source = html;
                ContentPage webpage = new ContentPage();
                webpage.Content = view;
                this.Content.Navigation.PushAsync(webpage);
            }
        }
    }
}
