#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.Graphics;

namespace SampleBrowser
{
    public partial class GettingStartedDocIO : SamplePage
    {
		private Context m_context;
		public override View GetSampleContent (Context con)
		{
			LinearLayout linear = new LinearLayout(con);
			linear.SetBackgroundColor(Color.White);
			linear.Orientation = Orientation.Vertical;
			linear.SetPadding(10, 10, 10, 10);

			TextView text1 = new TextView(con);
			text1.TextSize = 17;
			text1.TextAlignment = TextAlignment.Center;
			text1.SetTextColor(Color.ParseColor("#262626"));
			text1.Text = "This sample illustrates creating a Word document with text, image and tables.";
			text1.SetPadding(5, 10, 10, 5);
			linear.AddView(text1);
			
            TextView space1 = new TextView (con);
			space1.TextSize = 10;
			linear.AddView (space1);
			

			m_context = con;

			TextView space2 = new TextView (con);
			space2.TextSize = 10;
			linear.AddView (space2);

			Button button1 = new Button (con);
			button1.Text = "Generate Word";
			button1.Click += OnButtonClicked;
			linear.AddView (button1);

			return linear;

		}
        void OnButtonClicked(object sender, EventArgs e)
        {
			Assembly assembly = Assembly.GetExecutingAssembly();
            // Creating a new document.
            // Creating a new document.
            WordDocument document = new WordDocument();
            //Adding a new section to the document.
            WSection section = document.AddSection() as WSection;
            //Set Margin of the section
            section.PageSetup.Margins.All = 72;
            //Set page size of the section
            section.PageSetup.PageSize = new Syncfusion.Drawing.SizeF(612, 792);

            //Create Paragraph styles
            WParagraphStyle style = document.AddParagraphStyle("Normal") as WParagraphStyle;
            style.CharacterFormat.FontName = "Calibri";
            style.CharacterFormat.FontSize = 11f;
            style.ParagraphFormat.BeforeSpacing = 0;
            style.ParagraphFormat.AfterSpacing = 8;
            style.ParagraphFormat.LineSpacing = 13.8f;

            style = document.AddParagraphStyle("Heading 1") as WParagraphStyle;
            style.ApplyBaseStyle("Normal");
            style.CharacterFormat.FontName = "Calibri Light";
            style.CharacterFormat.FontSize = 16f;
            style.CharacterFormat.TextColor = Syncfusion.Drawing.Color.FromArgb(46, 116, 181);
            style.ParagraphFormat.BeforeSpacing = 12;
            style.ParagraphFormat.AfterSpacing = 0;
            style.ParagraphFormat.Keep = true;
            style.ParagraphFormat.KeepFollow = true;
            style.ParagraphFormat.OutlineLevel = OutlineLevel.Level1;
            IWParagraph paragraph = section.HeadersFooters.Header.AddParagraph();

            Stream imageStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.DocIO.Templates.AdventureCycle.jpg");
            WPicture picture = paragraph.AppendPicture(imageStream) as WPicture;
            picture.TextWrappingStyle = TextWrappingStyle.InFrontOfText;
            picture.VerticalOrigin = VerticalOrigin.Margin;
            picture.VerticalPosition = -24;
            picture.HorizontalOrigin = HorizontalOrigin.Column;
            picture.HorizontalPosition = 263.5f;
            picture.WidthScale = 20;
            picture.HeightScale = 15;

            paragraph.ApplyStyle("Normal");
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Left;
            WTextRange textRange = paragraph.AppendText("Adventure Works Cycles") as WTextRange;
            textRange.CharacterFormat.FontSize = 12f;
            textRange.CharacterFormat.FontName = "Calibri";
            textRange.CharacterFormat.TextColor = Syncfusion.Drawing.Color.Red;

            //Appends paragraph.
            paragraph = section.AddParagraph();
            paragraph.ApplyStyle("Heading 1");
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            textRange = paragraph.AppendText("Adventure Works Cycles") as WTextRange;
            textRange.CharacterFormat.FontSize = 18f;
            textRange.CharacterFormat.FontName = "Calibri";


            //Appends paragraph.
            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.FirstLineIndent = 36;
            paragraph.BreakCharacterFormat.FontSize = 12f;
            textRange = paragraph.AppendText("Adventure Works Cycles, the fictitious company on which the AdventureWorks sample databases are based, is a large, multinational manufacturing company. The company manufactures and sells metal and composite bicycles to North American, European and Asian commercial markets. While its base operation is located in Bothell, Washington with 290 employees, several regional sales teams are located throughout their market base.") as WTextRange;
            textRange.CharacterFormat.FontSize = 12f;

            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.FirstLineIndent = 36;
            paragraph.BreakCharacterFormat.FontSize = 12f;
            textRange = paragraph.AppendText("In 2000, Adventure Works Cycles bought a small manufacturing plant, Importadores Neptuno, located in Mexico. Importadores Neptuno manufactures several critical subcomponents for the Adventure Works Cycles product line. These subcomponents are shipped to the Bothell location for final product assembly. In 2001, Importadores Neptuno, became the sole manufacturer and distributor of the touring bicycle product group.") as WTextRange;
            textRange.CharacterFormat.FontSize = 12f;

            paragraph = section.AddParagraph();
            paragraph.ApplyStyle("Heading 1");
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Left;
            textRange = paragraph.AppendText("Product Overview") as WTextRange;
            textRange.CharacterFormat.FontSize = 16f;
            textRange.CharacterFormat.FontName = "Calibri";


            //Appends table.
            IWTable table = section.AddTable();
            table.ResetCells(3, 2);
            table.TableFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.None;
            table.TableFormat.IsAutoResized = true;

            //Appends paragraph.
            paragraph = table[0, 0].AddParagraph();
            paragraph.ParagraphFormat.AfterSpacing = 0;
            paragraph.BreakCharacterFormat.FontSize = 12f;
            imageStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.DocIO.Templates.Mountain-200.jpg");
            //Appends picture to the paragraph.
            picture = paragraph.AppendPicture(imageStream) as WPicture;
            picture.TextWrappingStyle = TextWrappingStyle.TopAndBottom;
            picture.VerticalOrigin = VerticalOrigin.Paragraph;
            picture.VerticalPosition = 0;
            picture.HorizontalOrigin = HorizontalOrigin.Column;
            picture.HorizontalPosition = -5.15f;
            picture.WidthScale = 79;
            picture.HeightScale = 79;

            //Appends paragraph.
            paragraph = table[0, 1].AddParagraph();
            paragraph.ApplyStyle("Heading 1");
            paragraph.ParagraphFormat.AfterSpacing = 0;
            paragraph.ParagraphFormat.LineSpacing = 12f;
            paragraph.AppendText("Mountain-200");
            //Appends paragraph.
            paragraph = table[0, 1].AddParagraph();
            paragraph.ParagraphFormat.AfterSpacing = 0;
            paragraph.ParagraphFormat.LineSpacing = 12f;
            paragraph.BreakCharacterFormat.FontSize = 12f;
            paragraph.BreakCharacterFormat.FontName = "Times New Roman";

            textRange = paragraph.AppendText("Product No: BK-M68B-38\r") as WTextRange;
            textRange.CharacterFormat.FontSize = 12f;
            textRange.CharacterFormat.FontName = "Times New Roman";
            textRange = paragraph.AppendText("Size: 38\r") as WTextRange;
            textRange.CharacterFormat.FontSize = 12f;
            textRange.CharacterFormat.FontName = "Times New Roman";
            textRange = paragraph.AppendText("Weight: 25\r") as WTextRange;
            textRange.CharacterFormat.FontSize = 12f;
            textRange.CharacterFormat.FontName = "Times New Roman";
            textRange = paragraph.AppendText("Price: $2,294.99\r") as WTextRange;
            textRange.CharacterFormat.FontSize = 12f;
            textRange.CharacterFormat.FontName = "Times New Roman";

            //Appends paragraph.
            paragraph = table[0, 1].AddParagraph();
            paragraph.ParagraphFormat.AfterSpacing = 0;
            paragraph.ParagraphFormat.LineSpacing = 12f;
            paragraph.BreakCharacterFormat.FontSize = 12f;

            //Appends paragraph.
            paragraph = table[1, 0].AddParagraph();
            paragraph.ApplyStyle("Heading 1");
            paragraph.ParagraphFormat.AfterSpacing = 0;
            paragraph.ParagraphFormat.LineSpacing = 12f;
            paragraph.AppendText("Mountain-300 ");
            //Appends paragraph.
            paragraph = table[1, 0].AddParagraph();
            paragraph.ParagraphFormat.AfterSpacing = 0;
            paragraph.ParagraphFormat.LineSpacing = 12f;
            paragraph.BreakCharacterFormat.FontSize = 12f;
            paragraph.BreakCharacterFormat.FontName = "Times New Roman";
            textRange = paragraph.AppendText("Product No: BK-M47B-38\r") as WTextRange;
            textRange.CharacterFormat.FontSize = 12f;
            textRange.CharacterFormat.FontName = "Times New Roman";
            textRange = paragraph.AppendText("Size: 35\r") as WTextRange;
            textRange.CharacterFormat.FontSize = 12f;
            textRange.CharacterFormat.FontName = "Times New Roman";
            textRange = paragraph.AppendText("Weight: 22\r") as WTextRange;
            textRange.CharacterFormat.FontSize = 12f;
            textRange.CharacterFormat.FontName = "Times New Roman";
            textRange = paragraph.AppendText("Price: $1,079.99\r") as WTextRange;
            textRange.CharacterFormat.FontSize = 12f;
            textRange.CharacterFormat.FontName = "Times New Roman";

            //Appends paragraph.
            paragraph = table[1, 0].AddParagraph();
            paragraph.ParagraphFormat.AfterSpacing = 0;
            paragraph.ParagraphFormat.LineSpacing = 12f;
            paragraph.BreakCharacterFormat.FontSize = 12f;

            //Appends paragraph.
            paragraph = table[1, 1].AddParagraph();
            paragraph.ApplyStyle("Heading 1");
            paragraph.ParagraphFormat.LineSpacing = 12f;
            imageStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.DocIO.Templates.Mountain-300.jpg");
            //Appends picture to the paragraph.
            picture = paragraph.AppendPicture(imageStream) as WPicture;
            picture.TextWrappingStyle = TextWrappingStyle.TopAndBottom;
            picture.VerticalOrigin = VerticalOrigin.Paragraph;
            picture.VerticalPosition = 8.2f;
            picture.HorizontalOrigin = HorizontalOrigin.Column;
            picture.HorizontalPosition = -14.95f;
            picture.WidthScale = 75;
            picture.HeightScale = 75;

            //Appends paragraph.
            paragraph = table[2, 0].AddParagraph();
            paragraph.ApplyStyle("Heading 1");
            paragraph.ParagraphFormat.LineSpacing = 12f;
            imageStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.DocIO.Templates.Road-550-W.jpg");
            //Appends picture to the paragraph.
            picture = paragraph.AppendPicture(imageStream) as WPicture;
            picture.TextWrappingStyle = TextWrappingStyle.TopAndBottom;
            picture.VerticalOrigin = VerticalOrigin.Paragraph;
            picture.VerticalPosition = 0;
            picture.HorizontalOrigin = HorizontalOrigin.Column;
            picture.HorizontalPosition = -4.9f;
            picture.WidthScale = 92;
            picture.HeightScale = 92;

            //Appends paragraph.
            paragraph = table[2, 1].AddParagraph();
            paragraph.ApplyStyle("Heading 1");
            paragraph.ParagraphFormat.AfterSpacing = 0;
            paragraph.ParagraphFormat.LineSpacing = 12f;
            paragraph.AppendText("Road-150 ");
            //Appends paragraph.
            paragraph = table[2, 1].AddParagraph();
            paragraph.ParagraphFormat.AfterSpacing = 0;
            paragraph.ParagraphFormat.LineSpacing = 12f;
            paragraph.BreakCharacterFormat.FontSize = 12f;
            paragraph.BreakCharacterFormat.FontName = "Times New Roman";
            textRange = paragraph.AppendText("Product No: BK-R93R-44\r") as WTextRange;
            textRange.CharacterFormat.FontSize = 12f;
            textRange.CharacterFormat.FontName = "Times New Roman";
            textRange = paragraph.AppendText("Size: 44\r") as WTextRange;
            textRange.CharacterFormat.FontSize = 12f;
            textRange.CharacterFormat.FontName = "Times New Roman";
            textRange = paragraph.AppendText("Weight: 14\r") as WTextRange;
            textRange.CharacterFormat.FontSize = 12f;
            textRange.CharacterFormat.FontName = "Times New Roman";
            textRange = paragraph.AppendText("Price: $3,578.27\r") as WTextRange;
            textRange.CharacterFormat.FontSize = 12f;
            textRange.CharacterFormat.FontName = "Times New Roman";
            //Appends paragraph.
            paragraph = table[2, 1].AddParagraph();
            paragraph.ApplyStyle("Heading 1");
            paragraph.ParagraphFormat.LineSpacing = 12f;

            //Appends paragraph.
            section.AddParagraph();
            MemoryStream stream = new MemoryStream();
            document.Save(stream, FormatType.Word2013);
            document.Close();
			if (stream != null) 
			{
				SaveAndroid androidSave = new SaveAndroid ();
				androidSave.Save ("GettingStarted.docx", "application/msword", stream, m_context);
			}
        }
    }
}
