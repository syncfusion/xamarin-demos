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
    public partial class FormFillingAndProtection: SamplePage
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
			text1.Text = "This sample demonstrates how to fill data and protect the content controls in an existing Word document.";
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
            //Creates an empty Word document instance.
            WordDocument document = new WordDocument();

            Stream inputStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.DocIO.Templates.ContentControlTemplate.docx");
            //Opens template document.
            document.Open(inputStream, FormatType.Word2013);

            IWTextRange textRange;
            //Gets table from the template document.
            IWTable table = document.LastSection.Tables[0];
            WTableRow row = table.Rows[1];

            #region Inserting content controls

            #region Calendar content control
            IWParagraph cellPara = row.Cells[0].Paragraphs[0];
            //Accesses the date picker content control.
            IInlineContentControl inlineControl = (cellPara.ChildEntities[2] as IInlineContentControl);
            textRange = inlineControl.ParagraphItems[0] as WTextRange;
            //Sets today's date to display.
            textRange.Text = DateTime.Now.ToShortDateString();
            textRange.CharacterFormat.FontSize = 14;
            //Protects the content control.
            inlineControl.ContentControlProperties.LockContents = true;
            #endregion

            #region Plain text content controls
            table = document.LastSection.Tables[1];
            row = table.Rows[0];
            cellPara = row.Cells[0].LastParagraph;
            //Accesses the plain text content control.
            inlineControl = (cellPara.ChildEntities[1] as IInlineContentControl);
            //Protects the content control.
            inlineControl.ContentControlProperties.LockContents = true;
            textRange = inlineControl.ParagraphItems[0] as WTextRange;
            //Sets text in plain text content control.
            textRange.Text = "Northwind Analytics";
            textRange.CharacterFormat.FontSize = 14;

            cellPara = row.Cells[1].LastParagraph;
            //Accesses the plain text content control.
            inlineControl = (cellPara.ChildEntities[1] as IInlineContentControl);
            //Protects the content control.
            inlineControl.ContentControlProperties.LockContents = true;
            textRange = inlineControl.ParagraphItems[0] as WTextRange;
            //Sets text in plain text content control.
            textRange.Text = "Northwind";
            textRange.CharacterFormat.FontSize = 14;

            row = table.Rows[1];
            cellPara = row.Cells[0].LastParagraph;
            //Accesses the plain text content control.
            inlineControl = (cellPara.ChildEntities[1] as IInlineContentControl);
            //Protects the content control.
            inlineControl.ContentControlProperties.LockContents = true;
            //Sets text in plain text content control.
            textRange = inlineControl.ParagraphItems[0] as WTextRange;
            textRange.Text = "10";
            textRange.CharacterFormat.FontSize = 14;


            cellPara = row.Cells[1].LastParagraph;
            //Accesses the plain text content control.
            inlineControl = (cellPara.ChildEntities[1] as IInlineContentControl);
            //Protects the content control.
            inlineControl.ContentControlProperties.LockContents = true;
            //Sets text in plain text content control.
            textRange = inlineControl.ParagraphItems[0] as WTextRange;
            textRange.Text = "Nancy Davolio";
            textRange.CharacterFormat.FontSize = 14;
            #endregion

            #region CheckBox Content control
            row = table.Rows[2];
            cellPara = row.Cells[0].LastParagraph;
            //Inserts checkbox content control.
            inlineControl = cellPara.AppendInlineContentControl(ContentControlType.CheckBox);
            inlineControl.ContentControlProperties.LockContents = true;
            //Sets checkbox as checked state.
            inlineControl.ContentControlProperties.IsChecked = true;
            textRange = cellPara.AppendText("C#, ");
            textRange.CharacterFormat.FontSize = 14;

            //Inserts checkbox content control.
            inlineControl = cellPara.AppendInlineContentControl(ContentControlType.CheckBox);
            inlineControl.ContentControlProperties.LockContents = true;
            //Sets checkbox as checked state.
            inlineControl.ContentControlProperties.IsChecked = true;
            textRange = cellPara.AppendText("VB");
            textRange.CharacterFormat.FontSize = 14;
            #endregion


            #region Drop down list content control
            cellPara = row.Cells[1].LastParagraph;
            //Accesses the dropdown list content control.
            inlineControl = (cellPara.ChildEntities[1] as IInlineContentControl);
            inlineControl.ContentControlProperties.LockContents = true;
            //Sets default option to display.
            textRange = inlineControl.ParagraphItems[0] as WTextRange;
            textRange.Text = "ASP.NET";
            textRange.CharacterFormat.FontSize = 14;
            inlineControl.ParagraphItems.Add(textRange);

            //Adds items to the dropdown list.
            ContentControlListItem item;
            item = new ContentControlListItem();
            item.DisplayText = "ASP.NET MVC";
            item.Value = "2";
            inlineControl.ContentControlProperties.ContentControlListItems.Add(item);

            item = new ContentControlListItem();
            item.DisplayText = "Windows Forms";
            item.Value = "3";
            inlineControl.ContentControlProperties.ContentControlListItems.Add(item);

            item = new ContentControlListItem();
            item.DisplayText = "WPF";
            item.Value = "4";
            inlineControl.ContentControlProperties.ContentControlListItems.Add(item);

            item = new ContentControlListItem();
            item.DisplayText = "Xamarin";
            item.Value = "5";
            inlineControl.ContentControlProperties.ContentControlListItems.Add(item);
            #endregion

            #region Calendar content control
            row = table.Rows[3];
            cellPara = row.Cells[0].LastParagraph;
            //Accesses the date picker content control.
            inlineControl = (cellPara.ChildEntities[1] as IInlineContentControl);
            inlineControl.ContentControlProperties.LockContents = true;
            //Sets default date to display.
            textRange = inlineControl.ParagraphItems[0] as WTextRange;
            textRange.Text = DateTime.Now.AddDays(-5).ToShortDateString();
            textRange.CharacterFormat.FontSize = 14;

            cellPara = row.Cells[1].LastParagraph;
            //Inserts date picker content control.
            inlineControl = (cellPara.ChildEntities[1] as IInlineContentControl);
            inlineControl.ContentControlProperties.LockContents = true;
            //Sets default date to display.
            textRange = inlineControl.ParagraphItems[0] as WTextRange;
            textRange.Text = DateTime.Now.AddDays(10).ToShortDateString();
            textRange.CharacterFormat.FontSize = 14;
            #endregion

            #endregion
            #region Block content control
            //Accesses the block content control.
            BlockContentControl blockContentControl = ((document.ChildEntities[0] as WSection).Body.ChildEntities[2] as BlockContentControl);
            //Protects the block content control
            blockContentControl.ContentControlProperties.LockContents = true;
            #endregion

            MemoryStream stream = new MemoryStream();
            document.Save(stream, FormatType.Word2013);
            document.Close();
			if (stream != null) 
			{
				SaveAndroid androidSave = new SaveAndroid ();
				androidSave.Save ("FormFillingAndProtection.docx", "application/msword", stream, m_context);
			}
        }
    }
}
