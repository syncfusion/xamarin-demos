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
    public partial class TableOfFigures : SampleView
    {
        public TableOfFigures()
        {
            InitializeComponent();
			this.docxButton.IsChecked = true;

            if (Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
				this.Description.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.HorizontalOptions = LayoutOptions.Start;
				this.Description.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.BackgroundColor = Color.Gray;
                this.btnInpTemplate.HorizontalOptions = LayoutOptions.Start;
                this.btnInpTemplate.VerticalOptions = LayoutOptions.Center;
                this.btnInpTemplate.BackgroundColor = Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Description.FontSize = 13.5;
				this.Description.VerticalOptions = LayoutOptions.Center;
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
            Assembly assembly = typeof(TableOfFigures).GetTypeInfo().Assembly;
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath + "TableOfFiguresInput.docx");

            MemoryStream stream = new MemoryStream();
            fileStream.CopyTo(stream);
            stream.Position = 0;
            fileStream.Dispose();
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("TableOfFiguresInput.docx", "application/msword", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("TableOfFiguresInput.docx", "application/msword", stream);
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            Assembly assembly = typeof(TableOfFigures).GetTypeInfo().Assembly;
#if COMMONSB
            string rootPath = "SampleBrowser.Samples.DocIO.Samples.Templates.";
#else
            string rootPath = "SampleBrowser.DocIO.Samples.Templates.";
#endif
            Stream inputStream = assembly.GetManifestResourceStream(rootPath + "TableOfFiguresInput.docx");
            
            // Loads the stream into Word Document.
            WordDocument document = new WordDocument(inputStream, Syncfusion.DocIO.FormatType.Automatic);

            #region Add Table of Figures
            //Create a new paragraph.
            WParagraph paragraph = new WParagraph(document);
            paragraph.AppendText("List of Figures");
            //Apply Heading1 style for paragraph.
            paragraph.ApplyStyle(BuiltinStyle.Heading1);
            //Insert the paragraph. 
            document.LastSection.Body.ChildEntities.Insert(0, paragraph);

            //Create new paragraph and append TOC.
            paragraph = new WParagraph(document);
            Syncfusion.DocIO.DLS.TableOfContent tableOfContent = paragraph.AppendTOC(1, 3);
            //Disable a flag to exclude heading style paragraphs in TOC entries.
            tableOfContent.UseHeadingStyles = false;
            //Set the name of SEQ field identifier for table of figures.
            tableOfContent.TableOfFiguresLabel = "Figure";
            if (checkBox.IsChecked)
                //Disable the flag, to exclude caption's label and number in TOC entries.
                tableOfContent.IncludeCaptionLabelsAndNumbers = false;

            //Insert the paragraph to the text body.
            document.LastSection.Body.ChildEntities.Insert(1, paragraph);
            #endregion

            #region Add caption for pictures
            //Find all pictures from the document.
            List<Entity> pictures = document.FindAllItemsByProperty(EntityType.Picture, null, null);
            // Iterate each picture and add caption.
            foreach (WPicture picture in pictures)
            {
                //Set alternate text as caption for picture.
                WParagraph captionPara = picture.AddCaption("Figure", CaptionNumberingFormat.Number, CaptionPosition.AfterImage) as WParagraph;
                captionPara.AppendText(" " + picture.AlternativeText);
                //Apply formatting to the caption.
                captionPara.ApplyStyle(BuiltinStyle.Caption);
                captionPara.ParagraphFormat.BeforeSpacing = 8;
                captionPara.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            }
            #endregion


            #region Add Table of Tables
            // Create a new paragraph.
            paragraph = new WParagraph(document);
            paragraph.AppendText("List of Tables");
            // Apply Heading1 style for paragraph.
            paragraph.ApplyStyle(BuiltinStyle.Heading1);
            // Insert the paragraph.
            document.LastSection.Body.ChildEntities.Insert(2, paragraph);

            //Create a new paragraph and append TOC.
            paragraph = new WParagraph(document);
            tableOfContent = paragraph.AppendTOC(1, 3);
            //Disable a flag to exclude heading style paragraphs in TOC entries.
            tableOfContent.UseHeadingStyles = false;
            //Set the name of SEQ field identifier for table of tables.
            tableOfContent.TableOfFiguresLabel = "Table";
            if (checkBox.IsChecked)
                //Disable the flag, to exclude caption's label and number in TOC entries.
                tableOfContent.IncludeCaptionLabelsAndNumbers = false;
            // Insert the paragraph to the text body.
            document.LastSection.Body.ChildEntities.Insert(3, paragraph);
            #endregion

            #region Add caption for tables
            // Find all tables from the document.
            List<Entity> tables = document.FindAllItemsByProperty(EntityType.Table, null, null);
            //Iterate each table and add caption.
            foreach (WTable table in tables)
            {
                //Gets the table index.
                int tableIndex = table.OwnerTextBody.ChildEntities.IndexOf(table);
                //Create a new paragraph and appends the sequence field to use as a caption.
                WParagraph captionPara = new WParagraph(document);
                captionPara.AppendText("Table ");
                captionPara.AppendField("Table", FieldType.FieldSequence);
                //Set alternate text as caption for table.
                captionPara.AppendText(" " + table.Description);
                // Apply formatting to the paragraph.
                captionPara.ApplyStyle(BuiltinStyle.Caption);
                captionPara.ParagraphFormat.BeforeSpacing = 8;
                captionPara.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                //Insert the paragraph next to the table.
                table.OwnerTextBody.ChildEntities.Insert(tableIndex + 1, captionPara);
            }
            #endregion

            #region Update
            //Update all document fields to update SEQ fields.
            document.UpdateDocumentFields();
            //Update the table of contents.
            document.UpdateTableOfContents();
            #endregion
			string filename = "";
            string contenttype = "";
            MemoryStream outputStream = new MemoryStream();
            if (this.pdfButton.IsChecked != null && (bool)this.pdfButton.IsChecked)
            {
                filename = "TableOfFigures.pdf";
                contenttype = "application/pdf";
                DocIORenderer renderer = new DocIORenderer();
                PdfDocument pdfDoc = renderer.ConvertToPDF(document);
                pdfDoc.Save(outputStream);
                pdfDoc.Close();
            }
            else
            {
                filename = "TableOfFigures.docx";
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
