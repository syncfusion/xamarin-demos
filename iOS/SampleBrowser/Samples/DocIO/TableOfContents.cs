#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.Pdf;
using Syncfusion.DocIORenderer;
using Syncfusion.OfficeChart;
using Syncfusion.Drawing;
using System.IO;
using COLOR = Syncfusion.Drawing;
using System.Reflection;
using Syncfusion.iOS.Buttons;
#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;
using ObjCRuntime;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using CGRect = System.Drawing.RectangleF;
using CGPoint = System.Drawing.PointF;
using CGSize = System.Drawing.SizeF;
#endif

namespace SampleBrowser
{
    public partial class TableofContents : SampleView
    {
        CGRect frameRect = new CGRect();
        float frameMargin = 8.0f;
        UILabel label;
        UILabel imageTypelabel;
        UIButton imageType;
        UIButton generateButton;

        //RadioButton
        SfRadioGroup radioGroup = new SfRadioGroup();
        SfRadioButton docxButton = new SfRadioButton();
        SfRadioButton pdfButton = new SfRadioButton();
        public TableofContents()
        {
            label = new UILabel();
            imageTypelabel = new UILabel();
            imageType = new UIButton();
            generateButton = new UIButton(UIButtonType.System);
            generateButton.TouchUpInside += OnConvertClicked;
        }

        void LoadAllowedTextsLabel()
        {
            #region Description Label
            label.Frame = frameRect;
            label.TextColor = UIColor.FromRGB(38 / 255.0f, 38 / 255.0f, 38 / 255.0f);
            label.Text = "This sample demonstrates how to create a Word document with Group shapes";
            label.Font = UIFont.SystemFontOfSize(15);
            label.Lines = 0;

            label.LineBreakMode = UILineBreakMode.WordWrap;
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                label.Font = UIFont.SystemFontOfSize(18);
                label.Frame = new CGRect(5, 5, frameRect.Location.X + frameRect.Size.Width, 35);
            }
            else
            {
                label.Frame = new CGRect(5, 5, frameRect.Location.X + frameRect.Size.Width, 50);
            }
            this.AddSubview(label);
            #endregion

            #region ImageFormat Label
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                imageTypelabel.Font = UIFont.SystemFontOfSize(18);
                imageTypelabel.Frame = new CGRect(10, 45, frameRect.Location.X + frameRect.Size.Width - 20, 50);
                imageType.Frame = new CGRect(10, 95, frameRect.Location.X + frameRect.Size.Width - 20, 40);
            }
            else
            {
                imageTypelabel.Frame = new CGRect(10, 50, frameRect.Location.X + frameRect.Size.Width - 20, 50);
                imageType.Frame = new CGRect(10, 100, frameRect.Location.X + frameRect.Size.Width - 20, 40);
            }

            //filter Label
            imageTypelabel.TextColor = UIColor.Black;
            imageTypelabel.BackgroundColor = UIColor.Clear;
            imageTypelabel.Text = "Save As:";
            imageTypelabel.TextAlignment = UITextAlignment.Left;
            imageTypelabel.Font = UIFont.FromName("Helvetica", 16f);
            this.AddSubview(imageTypelabel);

            #endregion

            #region Radio Buttons
            radioGroup.Axis = UILayoutConstraintAxis.Horizontal;
            docxButton.SetTitle("DOCX", UIControlState.Normal);
            radioGroup.AddArrangedSubview(docxButton);
            pdfButton.SetTitle("PDF", UIControlState.Normal);
            radioGroup.AddArrangedSubview(pdfButton);
            docxButton.IsChecked = true;
            radioGroup.Distribution = UIStackViewDistribution.FillProportionally;

            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                radioGroup.Frame = new CGRect(110, 55, frameRect.Width - 500, 30);
            }
            else
            {
                radioGroup.Frame = new CGRect(110, 60, frameRect.Width - 90, 30);
            }
            this.AddSubview(radioGroup);
            #endregion

            #region Convert Button
            generateButton.SetTitle("Generate Word", UIControlState.Normal);
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                generateButton.Frame = new CGRect(0, 105, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            else
            {
                generateButton.Frame = new CGRect(0, (this.Frame.Size.Height / 4) - 5, frameRect.Location.X + frameRect.Size.Width, 10);
            }

            this.AddSubview(generateButton);
            #endregion
        }

        void OnConvertClicked(object sender, EventArgs e)
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

            string fileName = null;
            string ContentType = null;
            MemoryStream ms = new MemoryStream();
            if (pdfButton != null && (bool)pdfButton.IsChecked)
            {
                fileName = "Table of Contents.pdf";
                ContentType = "application/pdf";
                DocIORenderer renderer = new DocIORenderer();
                PdfDocument pdfDoc = renderer.ConvertToPDF(doc);
                pdfDoc.Save(ms);
                pdfDoc.Close();
            }
            else
            {
                fileName = "Table of Contents.docx";
                ContentType = "application/msword";
                doc.Save(ms, FormatType.Docx);
            }

            //Reset the stream position
            ms.Position = 0;

            //Close the document instance.
            doc.Close();

            if (ms != null)
            {
                SaveiOS iOSSave = new SaveiOS();
                iOSSave.Save(fileName, ContentType, ms as MemoryStream);
            }

        }

        public override void LayoutSubviews()
        {
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                frameMargin = 0.0f;
            }
            frameRect = Bounds;
            frameRect.Location = new CGPoint(frameRect.Location.X + frameMargin, frameRect.Location.Y + 1.5f * frameMargin);
            frameRect.Size = new CGSize(frameRect.Size.Width - (frameRect.Location.X + frameMargin), frameRect.Size.Height - (frameRect.Location.Y + 1.5f * frameMargin));

            LoadAllowedTextsLabel();

            base.LayoutSubviews();
        }
    }
}