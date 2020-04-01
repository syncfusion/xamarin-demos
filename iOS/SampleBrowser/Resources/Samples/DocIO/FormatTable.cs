#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
using System.Collections.Generic;


#endregion
using System;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIORenderer;
using System.IO;
using COLOR = Syncfusion.Drawing;
using System.Reflection;
#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;
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
    public partial class FormatTable : SampleView
    {
        CGRect frameRect = new CGRect();
        float frameMargin = 8.0f;
        UILabel label;
        UIButton button;

        public FormatTable()
        {
            label = new UILabel();
            button = new UIButton(UIButtonType.System);
            button.TouchUpInside += OnButtonClicked;
        }

        void LoadAllowedTextsLabel()
        {
            label.Frame = frameRect;
            label.TextColor = UIColor.FromRGB(38 / 255.0f, 38 / 255.0f, 38 / 255.0f);
            label.Text = "This sample demonstrates how to format the tables in the Word document using Essential DocIO.";
            label.Lines = 0;
            label.Font = UIFont.SystemFontOfSize(15);
            label.LineBreakMode = UILineBreakMode.WordWrap;
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                label.Font = UIFont.SystemFontOfSize(18);
                label.Frame = new CGRect(5, 5, frameRect.Location.X + frameRect.Size.Width, 70);
            }
            else
            {
                label.Frame = new CGRect(frameRect.Location.X, 5, frameRect.Size.Width, 70);
            }
            this.AddSubview(label);

            button.SetTitle("Generate Word", UIControlState.Normal);
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                button.Frame = new CGRect(5, 90, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            else
            {
                button.Frame = new CGRect(frameRect.Location.X, 90, frameRect.Size.Width, 10);
            }
            button.TouchUpInside += OnButtonClicked;
            this.AddSubview(button);
        }
        void OnButtonClicked(object sender, EventArgs e)
        {
            // Create a new document.
            WordDocument document = new WordDocument();
            // Adding a new section to the document.
            IWSection section = document.AddSection();
            section.PageSetup.DifferentFirstPage = true;
            IWTextRange textRange;
            IWParagraph paragraph = section.AddParagraph();


            #region Table Cell Spacing.
            // --------------------------------------------
            // Table Cell Spacing.
            // --------------------------------------------
            paragraph.AppendText("Table Cell spacing...").CharacterFormat.FontSize = 14;

            section.AddParagraph();
            paragraph = section.AddParagraph();
            WTextBody textBody = section.Body;

            // Adding a new Table to the textbody.
            IWTable table = textBody.AddTable();
            table.TableFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Single;
            table.TableFormat.Paddings.All = 5.4f;
            RowFormat format = new RowFormat();

            format.Paddings.All = 5;
            format.CellSpacing = 2;
            format.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.DotDash;
            format.IsBreakAcrossPages = true;
            table.ResetCells(25, 5, format, 90);
            IWTextRange text;
            table.Rows[0].IsHeader = true;

            for (int i = 0; i < table.Rows[0].Cells.Count; i++)
            {
                paragraph = table[0, i].AddParagraph() as WParagraph;
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                text = paragraph.AppendText(string.Format("Header {0}", i + 1));
                text.CharacterFormat.FontName = "Calibri";
                text.CharacterFormat.FontSize = 10;
                text.CharacterFormat.Bold = true;
                text.CharacterFormat.TextColor = Syncfusion.Drawing.Color.FromArgb(0, 21, 84);
                table[0, i].CellFormat.BackColor = Syncfusion.Drawing.Color.FromArgb(203, 211, 226);
            }

            for (int i = 1; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    paragraph = table[i, j].AddParagraph() as WParagraph;
                    paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;

                    text = paragraph.AppendText(string.Format("Cell {0} , {1}", i, j + 1));
                    text.CharacterFormat.TextColor = Syncfusion.Drawing.Color.FromArgb(242, 151, 50);
                    text.CharacterFormat.Bold = true;
                    if (i % 2 != 1)
                        table[i, j].CellFormat.BackColor = Syncfusion.Drawing.Color.FromArgb(231, 235, 245);
                    else
                        table[i, j].CellFormat.BackColor = Syncfusion.Drawing.Color.FromArgb(246, 249, 255);

                }

            }
            //table.TableFormat.IsAutoResized = true;
            (table as WTable).AutoFit(AutoFitType.FitToContent);
            #endregion Table Cell Spacing.

            #region Nested Table
            // --------------------------------------------
            // Nested Table.
            // --------------------------------------------

            section.AddParagraph();
            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.PageBreakBefore = true;
            paragraph.AppendText("Nested Table...").CharacterFormat.FontSize = 14;

            section.AddParagraph();
            paragraph = section.AddParagraph();
            textBody = section.Body;

            // Adding a new Table to the textbody.
            table = textBody.AddTable();

            format = new RowFormat();
            format.Paddings.All = 5;
            format.CellSpacing = 2.5f;
            format.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.DotDash;
            table.ResetCells(5, 3, format, 100);

            for (int i = 0; i < table.Rows[0].Cells.Count; i++)
            {
                paragraph = table[0, i].AddParagraph() as WParagraph;
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                text = paragraph.AppendText(string.Format("Header {0}", i + 1));
                text.CharacterFormat.FontName = "Calibri";
                text.CharacterFormat.FontSize = 10;
                text.CharacterFormat.Bold = true;
                text.CharacterFormat.TextColor = Syncfusion.Drawing.Color.FromArgb(0, 21, 84);
                table[0, i].CellFormat.BackColor = Syncfusion.Drawing.Color.FromArgb(242, 151, 50);
            }
            table[0, 2].Width = 200;
            for (int i = 1; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    paragraph = table[i, j].AddParagraph() as WParagraph;
                    paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;

                    if ((i == 2) && (j == 2))
                    {
                        text = paragraph.AppendText("Nested Table");
                    }

                    else
                    {
                        text = paragraph.AppendText(string.Format("Cell {0} , {1}", i, j + 1));
                    }

                    if ((j == 2))
                        table[i, j].Width = 200;

                    text.CharacterFormat.TextColor = Syncfusion.Drawing.Color.FromArgb(242, 151, 50);
                    text.CharacterFormat.Bold = true;
                }
            }

            // Adding a nested Table.
            IWTable nestTable = table[2, 2].AddTable();

            format = new RowFormat();

            format.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.DotDash;
            format.HorizontalAlignment = RowAlignment.Center;
            nestTable.ResetCells(3, 3, format, 45);

            for (int i = 0; i < nestTable.Rows.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    paragraph = nestTable[i, j].AddParagraph() as WParagraph;
                    paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;

                    nestTable[i, j].CellFormat.BackColor = Syncfusion.Drawing.Color.FromArgb(231, 235, 245);
                    text = paragraph.AppendText(string.Format("Cell {0} , {1}", i, j + 1));
                    text.CharacterFormat.TextColor = Syncfusion.Drawing.Color.Black;
                    text.CharacterFormat.Bold = true;
                }
            }
            (nestTable as WTable).AutoFit(AutoFitType.FitToContent);
            (table as WTable).AutoFit(AutoFitType.FitToWindow);
            #endregion Nested Table

            MemoryStream stream = new MemoryStream();
            document.Save(stream, FormatType.Docx);
            document.Close();
            if (stream != null)
            {
                SaveiOS iOSSave = new SaveiOS();
                iOSSave.Save("FormatTable.docx", "application/msword", stream);
            }
        }
        public override void LayoutSubviews()
        {
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                frameMargin = 0.0f;
            }
            frameRect = Frame;
            frameRect.Location = new CGPoint(frameRect.Location.X + frameMargin, frameRect.Location.Y + 1.5f * frameMargin);
            frameRect.Size = new CGSize(frameRect.Size.Width - (frameRect.Location.X + frameMargin), frameRect.Size.Height - (frameRect.Location.Y + 1.5f * frameMargin));
            LoadAllowedTextsLabel();
            base.LayoutSubviews();
        }
    }
}