#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.Compression;
using Syncfusion.OfficeChart;
using Syncfusion.DocIORenderer;
using Syncfusion.Office;
using Syncfusion.Pdf;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Webkit;
using Android.App;
using Android.OS;

namespace SampleBrowser
{
    public partial class MarkdownToWord : SamplePage
    {
        private Context m_context;
        RadioGroup radioGroup;
        RadioButton docxButton;
        RadioButton pdfButton;
        RadioButton htmlButton;

        public override View GetSampleContent(Context con)
        {
            LinearLayout linear = new LinearLayout(con);
            linear.SetBackgroundColor(Color.White);
            linear.Orientation = Orientation.Vertical;
            linear.SetPadding(10, 10, 10, 10);

            TextView text1 = new TextView(con);
            text1.TextSize = 17;
            text1.TextAlignment = TextAlignment.Center;
            text1.SetTextColor(Color.ParseColor("#262626"));
            text1.Text = "This sample demonstrates how to convert the Markdown file to Word document using .NET Word (DocIO) library.";
            text1.SetPadding(5, 10, 10, 5);
            linear.AddView(text1);

            TextView space1 = new TextView(con);
            space1.TextSize = 10;
            linear.AddView(space1);

            m_context = con;
            LinearLayout radioLinearLayout = new LinearLayout(con);
            radioLinearLayout.Orientation = Orientation.Horizontal;

            TextView imageType = new TextView(con);
            imageType.Text = "Save As : ";
            imageType.TextSize = 19;
            radioLinearLayout.AddView(imageType);

            radioGroup = new RadioGroup(con);
            radioGroup.TextAlignment = TextAlignment.Center;
            radioGroup.Orientation = Orientation.Horizontal;
            docxButton = new RadioButton(con);
            docxButton.Text = "DOCX";
            radioGroup.AddView(docxButton);
            htmlButton = new RadioButton(con);
            htmlButton.Text = "HTML";
            radioGroup.AddView(htmlButton);
            pdfButton = new RadioButton(con);
            pdfButton.Text = "PDF";
            radioGroup.AddView(pdfButton);
            radioGroup.Check(1);
            radioLinearLayout.AddView(radioGroup);
            linear.AddView(radioLinearLayout);
            docxButton.Checked = true;

            TextView space2 = new TextView(con);
            space2.TextSize = 10;
            linear.AddView(space2);

            Button button1 = new Button(con);
            button1.Text = "Generate Document";
            button1.Click += OnButtonClicked;
            linear.AddView(button1);

            return linear;
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            string resourcePath = "SampleBrowser.Samples.DocIO.Templates.MarkdownToWord.md";
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            // Loads the stream into Word Document.
            WordDocument document = new WordDocument(fileStream, Syncfusion.DocIO.FormatType.Markdown);
            MemoryStream stream = new MemoryStream();
            //Set file content type
            string contentType = null;
            string fileName = null;
            //Save the document as .html
            if (htmlButton.Checked)
            {
                fileName = "MarkdownToWord.html";
                contentType = "application/html";
                document.Save(stream, FormatType.Html);
            }
            //Save the document as .Pdf
            else if(pdfButton.Checked)
            {
                fileName = "MarkdownToWord.pdf";
                contentType = "application/pdf";
                //Convert the word document to PDF.
                DocIORenderer renderer = new DocIORenderer();
                PdfDocument pdfDoc = renderer.ConvertToPDF(document);
                pdfDoc.Save(stream);
                pdfDoc.Close();
            }
            //Save the document as .docx
            else
            {
                fileName = "MarkdownToWord.docx";
                contentType = "application/msword";
                document.Save(stream, FormatType.Docx);
            }
            document.Dispose();
            if (contentType == "application/html" && stream != null)
            {
                //Set the stream to start position to read the content as string
                stream.Position = 0;
                StreamReader reader = new StreamReader (stream);
                string htmlString = reader.ReadToEnd ();
                Intent i = new Intent (m_context, typeof(WebViewActivity));
                i.PutExtra ("HtmlString", htmlString);
                m_context.StartActivity (i);
            }
            else if (stream != null)
            {
                SaveAndroid androidSave = new SaveAndroid();
                androidSave.Save(fileName, contentType, stream, m_context);
            }
        }
    }
}

