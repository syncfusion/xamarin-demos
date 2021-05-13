#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.OfficeChart;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
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
	public partial class TableOfContents : SamplePage
    {
        private Context m_context;
        RadioGroup radioGroup;
        RadioButton docxButton;
        RadioButton pdfButton;

        public override View GetSampleContent(Context con)
        {
            LinearLayout linear = new LinearLayout(con);
            linear.SetBackgroundColor(Android.Graphics.Color.White);
            linear.Orientation = Orientation.Vertical;
            linear.SetPadding(10, 10, 10, 10);

            TextView text2 = new TextView(con);
            text2.TextSize = 17;
            text2.TextAlignment = TextAlignment.Center;
            text2.Text = "This sample demonstrates how to insert and update the Table of Contents (TOC) in a Word document using Essential DocIO.";
            text2.SetTextColor(Android.Graphics.Color.ParseColor("#262626"));
            text2.SetPadding(5, 5, 5, 5);

            linear.AddView(text2);

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

            Button generateButton = new Button(con);
            generateButton.Text = "Generate";
            generateButton.Click += OnButtonClicked;
            linear.AddView(generateButton);

            return linear;
        }        

        void OnButtonClicked(object sender, EventArgs e)
        {
            WordDocument doc = new WordDocument();
            doc.EnsureMinimal();

            WParagraph para = doc.LastParagraph;
            para.AppendText("Essential DocIO - Table of Contents");
            para.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            para.ApplyStyle(BuiltinStyle.Heading4);

            para = doc.LastSection.AddParagraph() as WParagraph;
            para.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            para.ApplyStyle(BuiltinStyle.Heading4);

           para = doc.LastSection.AddParagraph() as WParagraph;

            //Insert TOC
            TableOfContent toc = para.AppendTOC(1, 3);

            para.ApplyStyle(BuiltinStyle.Heading4);

            //Apply built-in paragraph formatting
            WSection section = doc.LastSection;
            #region Default Styles
            WParagraph newPara = section.AddParagraph() as WParagraph;
            newPara = section.AddParagraph() as WParagraph;
            newPara.AppendBreak(BreakType.PageBreak);
            WTextRange text = newPara.AppendText("Document with Default styles") as WTextRange;
            newPara.ApplyStyle(BuiltinStyle.Heading1);
            newPara = section.AddParagraph() as WParagraph;
            newPara.AppendText("This is the heading1 of built in style. This sample demonstrates the TOC insertion in a word document. Note that DocIO can only insert TOC field in a word document. It can not refresh or create TOC field. MS Word refreshes the TOC field after insertion. Please update the field or press F9 key to refresh the TOC.");

            section.AddParagraph();
            newPara = section.AddParagraph() as WParagraph;
            text = newPara.AppendText("Section1") as WTextRange;
            newPara.ApplyStyle(BuiltinStyle.Heading2);
            newPara = section.AddParagraph() as WParagraph;
            newPara.AppendText("This is the heading2 of built in style. A document can contain any number of sections. Sections are used to apply same formatting for a group of paragraphs. You can insert sections by inserting section breaks.");

            section.AddParagraph();
            newPara = section.AddParagraph() as WParagraph;
            text = newPara.AppendText("Paragraph1") as WTextRange;
            newPara.ApplyStyle(BuiltinStyle.Heading3);
            newPara = section.AddParagraph() as WParagraph;
            newPara.AppendText("This is the heading3 of built in style. Each section contains any number of paragraphs. A paragraph is a set of statements that gives a meaning for the text.");

            section.AddParagraph();
            newPara = section.AddParagraph() as WParagraph;
            text = newPara.AppendText("Paragraph2") as WTextRange;
            newPara.ApplyStyle(BuiltinStyle.Heading3);
            newPara = section.AddParagraph() as WParagraph;
            newPara.AppendText("This is the heading3 of built in style. This demonstrates the paragraphs at the same level and style as that of the previous one. A paragraph can have any number formatting. This can be attained by formatting each text range in the paragraph.");

            section.AddParagraph();
            section = doc.AddSection() as WSection;
            section.BreakCode = SectionBreakCode.NewPage;
            newPara = section.AddParagraph() as WParagraph;
            text = newPara.AppendText("Section2") as WTextRange;
            newPara.ApplyStyle(BuiltinStyle.Heading2);
            newPara = section.AddParagraph() as WParagraph;
            newPara.AppendText("This is the heading2 of built in style. A document can contain any number of sections. Sections are used to apply same formatting for a group of paragraphs. You can insert sections by inserting section breaks.");

            section.AddParagraph();
            newPara = section.AddParagraph() as WParagraph;
            text = newPara.AppendText("Paragraph1") as WTextRange;
            newPara.ApplyStyle(BuiltinStyle.Heading3);
            newPara = section.AddParagraph() as WParagraph;
            newPara.AppendText("This is the heading3 of built in style. Each section contains any number of paragraphs. A paragraph is a set of statements that gives a meaning for the text.");

            section.AddParagraph();
            newPara = section.AddParagraph() as WParagraph;
            text = newPara.AppendText("Paragraph2") as WTextRange;
            newPara.ApplyStyle(BuiltinStyle.Heading3);
            newPara = section.AddParagraph() as WParagraph;
            newPara.AppendText("This is the heading3 of built in style. This demonstrates the paragraphs at the same level and style as that of the previous one. A paragraph can have any number formatting. This can be attained by formatting each text range in the paragraph.");
            #endregion

            toc.IncludePageNumbers = true;
            toc.RightAlignPageNumbers = true;
            toc.UseHyperlinks = true;
            toc.LowerHeadingLevel = 1;
            toc.UpperHeadingLevel = 3;

            toc.UseOutlineLevels = true;

            //Updates the table of contents.
            doc.UpdateTableOfContents();
            MemoryStream ms = new MemoryStream();

            //Set file content type
            string contentType = null;
            string fileName = null;
            if (docxButton.Checked)
            {
                fileName = "Table of Contents.docx";
                contentType = "application/msword";
                doc.Save(ms, FormatType.Docx);
            }
            else
            {
                fileName = "Table of Contents.pdf";
                contentType = "application/pdf";
                DocIORenderer renderer = new DocIORenderer();
                PdfDocument pdfDoc = renderer.ConvertToPDF(doc);
                pdfDoc.Save(ms);
                pdfDoc.Close();
            }

            doc.Dispose();
            
            if (ms != null)
            {
                SaveAndroid androidSave = new SaveAndroid();
                androidSave.Save(fileName, contentType, ms, m_context);
            }
        }
    }
}

