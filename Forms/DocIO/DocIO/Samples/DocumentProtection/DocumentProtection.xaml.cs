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
using Syncfusion.Drawing;

namespace SampleBrowser.DocIO
{
    public partial class DocumentProtection : SampleView
    {
        public DocumentProtection()
        {
            InitializeComponent();

            if (Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Content_1.HorizontalOptions = LayoutOptions.Start;
                this.Content_2.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.HorizontalOptions = LayoutOptions.Start;
                this.Content_1.VerticalOptions = LayoutOptions.Center;
                this.Content_2.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.BackgroundColor = System.Drawing.Color.Gray;
                this.btnGenerate1.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate1.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate1.BackgroundColor = System.Drawing.Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Content_1.FontSize = 13.5;
                this.Content_1.VerticalOptions = LayoutOptions.Center;
                this.Content_2.FontSize = 13.5;
                this.Content_2.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
            }
        }
        void OnButtonClicked1(object sender, EventArgs e)
        {
            Assembly assembly = typeof(BookmarkNavigation).GetTypeInfo().Assembly;
#if COMMONSB
            string rootPath = "SampleBrowser.Samples.DocIO.Samples.Templates.";
#else
            string rootPath = "SampleBrowser.DocIO.Samples.Templates.";
#endif
            Stream inputStream = assembly.GetManifestResourceStream(rootPath + "TemplateReading.docx");
            MemoryStream stream = new MemoryStream();
            inputStream.CopyTo(stream);
            inputStream.Dispose();
            stream.Position = 0;
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("TemplateReading.docx", "application/msword", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("TemplateReading.docx", "application/msword", stream);
        }
        void OnButtonClicked2(object sender, EventArgs e)
        {
            Assembly assembly = typeof(BookmarkNavigation).GetTypeInfo().Assembly;
#if COMMONSB
            string rootPath = "SampleBrowser.Samples.DocIO.Samples.Templates.";
#else
            string rootPath = "SampleBrowser.DocIO.Samples.Templates.";
#endif
            Stream inputStream = assembly.GetManifestResourceStream(rootPath + "TemplateReading.docx");
            // Creating a new document.
            WordDocument document = new WordDocument(inputStream, FormatType.Docx);
            // Add editable ranges to allow unrestricted editing in specific sections.
            AddEditableRange(document);
            // Sets the protection type as allow only Reading.
            document.Protect(ProtectionType.AllowOnlyReading, "syncfusion");
            #region Saving Document
            MemoryStream stream = new MemoryStream();
            document.Save(stream, FormatType.Docx);
            document.Close();
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("DocumentProtection.docx", "application/msword", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("DocumentProtection.docx", "application/msword", stream);
            #endregion
        }
        private void AddEditableRange(WordDocument document)
        {
            // Access the paragraph
            WParagraph paragraph = document.Sections[0].Body.ChildEntities[5] as WParagraph;
            // Create a new editable range start
            EditableRangeStart editableRangeStart = new EditableRangeStart(document);
            // Insert the editable range start at the beginning of the selected paragraph
            paragraph.ChildEntities.Insert(0, editableRangeStart);
            // Set the editor group for the editable range to allow everyone to edit
            editableRangeStart.EditorGroup = EditorType.Everyone;
            // Append an editable range end to close the editable region
            paragraph.AppendEditableRangeEnd();

            // Access the first table in the first section of the document
            WTable table = document.Sections[0].Tables[0] as WTable;
            // Access the paragraph in the third row and third column of the table
            paragraph = table[2, 2].ChildEntities[0] as WParagraph;
            // Create a new editable range start for the table cell paragraph
            editableRangeStart = new EditableRangeStart(document);
            // Insert the editable range start at the beginning of the paragraph
            paragraph.ChildEntities.Insert(0, editableRangeStart);
            // Set the editor group for the editable range to allow everyone to edit
            editableRangeStart.EditorGroup = EditorType.Everyone;
            // Apply editable range to second column only
            editableRangeStart.FirstColumn = 1;
            editableRangeStart.LastColumn = 1;
            // Access the paragraph
            paragraph = table[5, 2].ChildEntities[0] as WParagraph;
            // Append an editable range end to close the editable region
            paragraph.AppendEditableRangeEnd();
        }
    }
}
