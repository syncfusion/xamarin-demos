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
    public partial class CustomStyle : SamplePage
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
		    text1.Text = "This sample demonstrates how to format the Word document contents with user defined styles.";
			text1.SetPadding(5, 5, 5, 5);
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
            WordDocument document = new WordDocument();
            IWParagraphStyle style = null;
            // Adding a new section to the document.
            WSection section = document.AddSection() as WSection;
            //Set Margin of the section
            section.PageSetup.Margins.All = 72;
            IWParagraph par = document.LastSection.AddParagraph();
            WTextRange range = par.AppendText("Using CustomStyles") as WTextRange;
            range.CharacterFormat.TextBackgroundColor = Syncfusion.Drawing.Color.Red;
            range.CharacterFormat.TextColor = Syncfusion.Drawing.Color.White;
            range.CharacterFormat.FontSize = 18f;
            document.LastParagraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;

            // Create Paragraph styles
            style = document.AddParagraphStyle("MyStyle_Normal");
            style.CharacterFormat.FontName = "Bitstream Vera Serif";
            style.CharacterFormat.FontSize = 10f;
            style.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Justify;
            style.CharacterFormat.TextColor = Syncfusion.Drawing.Color.FromArgb(0, 21, 84);

            style = document.AddParagraphStyle("MyStyle_Low");
            style.CharacterFormat.FontName = "Times New Roman";
            style.CharacterFormat.FontSize = 16f;
            style.CharacterFormat.Bold = true;

            style = document.AddParagraphStyle("MyStyle_Medium");
            style.CharacterFormat.FontName = "Monotype Corsiva";
            style.CharacterFormat.FontSize = 18f;
            style.CharacterFormat.Bold = true;
            style.CharacterFormat.TextColor = Syncfusion.Drawing.Color.FromArgb(51, 66, 125);

            style = document.AddParagraphStyle("Mystyle_High");
            style.CharacterFormat.FontName = "Bitstream Vera Serif";
            style.CharacterFormat.FontSize = 20f;
            style.CharacterFormat.Bold = true;
            style.CharacterFormat.TextColor = Syncfusion.Drawing.Color.FromArgb(242, 151, 50);

            IWParagraph paragraph = null;
            for (int i = 1; i < document.Styles.Count; i++)
            {
                //Skip to apply the document default styles and also paragraph style.
                if(document.Styles[i].Name=="Normal"||document.Styles[i].Name=="Default Paragraph Font"||document.Styles[i].StyleType!=StyleType.ParagraphStyle)
                    continue;
                // Getting styles from Document.
                style = (IWParagraphStyle)document.Styles[i];
                // Adding a new paragraph
                section.AddParagraph();
                paragraph = section.AddParagraph();
                // Applying styles to the current paragraph.
                paragraph.ApplyStyle(style.Name);
                // Writing Text with the current style and formatting.
                paragraph.AppendText("Northwind Database with [" + style.Name + "] Style");
                // Adding a new paragraph
                section.AddParagraph();
                paragraph = section.AddParagraph();
                // Applying another style to the current paragraph.
                paragraph.ApplyStyle("MyStyle_Normal");
                // Writing text with current style.
                paragraph.AppendText("The Northwind sample database (Northwind.mdb) is included with all versions of Access. It provides data you can experiment with and database objects that demonstrate features you might want to implement in your own databases. Using Northwind, you can become familiar with how a relational database is structured and how the database objects work together to help you enter, store, manipulate, and print your data.");
            }
            #region Saving Document
            MemoryStream stream = new MemoryStream();
            document.Save(stream, FormatType.Word2013);
            document.Close();
			if(stream != null)
			{
				SaveAndroid androidSave = new SaveAndroid ();
				androidSave.Save ("CustomStyle.docx", "application/msword", stream, m_context);
			}
            #endregion
        }
    }
}
