#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
    public partial class LaTeX : SampleView
    {
        public LaTeX()
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
            Assembly assembly = typeof(CreateEquation).GetTypeInfo().Assembly;
#if COMMONSB
            string rootPath = "SampleBrowser.Samples.DocIO.Samples.Templates.";
#else
            string rootPath = "SampleBrowser.DocIO.Samples.Templates.";
#endif
            Stream inputStream = assembly.GetManifestResourceStream(rootPath + "CreateEquation.docx");

            // Loads the stream into Word Document.
            WordDocument document = new WordDocument(inputStream, Syncfusion.DocIO.FormatType.Automatic);
            //Get the last section in the document
            WSection section = document.LastSection;
            //Set page margins
            section.PageSetup.Margins.All = 72;
            //Add new paragraph to the section
            IWParagraph paragraph = section.AddParagraph();

            //Append text to paragraph
            IWTextRange textRange = paragraph.AppendText("Mathematical equation");
            textRange.CharacterFormat.FontSize = 28;
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            paragraph.ParagraphFormat.AfterSpacing = 12;

            //Add new paragraph to the section.
            paragraph = section.AddParagraph();
            //Append mathematical equation using LaTeX.
            if (!string.IsNullOrEmpty(latex.Text))
                paragraph.AppendMath(latex.Text);

            string filename = "";
            string contenttype = "";
            MemoryStream outputStream = new MemoryStream();
            if (this.pdfButton.IsChecked != null && (bool)this.pdfButton.IsChecked)
            {
                filename = "LaTeXToMath.pdf";
                contenttype = "application/pdf";
                DocIORenderer renderer = new DocIORenderer();
                PdfDocument pdfDoc = renderer.ConvertToPDF(document);
                pdfDoc.Save(outputStream);
                pdfDoc.Close();
            }
            else
            {
                filename = "LaTeXToMath.docx";
                contenttype = "application/msword";
                document.Save(outputStream, FormatType.Docx);
            }
            document.Close();            

            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save(filename, contenttype, outputStream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save(filename, contenttype, outputStream);
        }
    }
}
