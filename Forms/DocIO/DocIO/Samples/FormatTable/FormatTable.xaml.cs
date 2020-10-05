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
using System.Reflection;
using Xamarin.Forms;
using Syncfusion.Office;
using Syncfusion.DocIORenderer;

namespace SampleBrowser.DocIO
{
    public partial class FormatTable : SampleView
    {
        public FormatTable()
        {
            InitializeComponent();

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
               // if (!SampleBrowser.DocIO.App.isUWP)
               // {
                //    this.Content_1.FontSize = 18.5;
                //}
                //else
               // {
                    this.Content_1.FontSize = 13.5;
               // }
                
                this.Content_1.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
            }
        }
        void OnButtonClicked(object sender, EventArgs e)
        {
            Assembly assembly = typeof(FormatTable).GetTypeInfo().Assembly;
            // Create a new document.
            WordDocument document = new WordDocument();
            // Adding a new section to the document.
            IWSection section = document.AddSection();
            section.PageSetup.Margins.All = 50;
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

            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("FormatTable.docx", "application/msword", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("FormatTable.docx", "application/msword", stream);
        }     
    }
}
