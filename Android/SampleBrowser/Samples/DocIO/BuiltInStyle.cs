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
    public partial class BuiltInStyle : SamplePage
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
		    text1.Text = "This sample demonstrates how to format the Word document contents with the built-in styles.";
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
            // Creating a new document.
            WordDocument document = new WordDocument();


            WSection section = document.AddSection() as WSection;
            //Set Margin of the section
            section.PageSetup.Margins.All = 72;
            WParagraph para = section.AddParagraph() as WParagraph;
            section.AddColumn(100, 100);
            section.AddColumn(100, 100);
            section.MakeColumnsEqual();

            #region Built-in styles
            # region List Style

            //List
            //para = section.AddParagraph() as WParagraph;
            para.AppendText("This para is written with style List").CharacterFormat.UnderlineStyle = Syncfusion.Drawing.UnderlineStyle.Double;
            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.List);
            para.AppendText("Google Chrome\n");
            para.AppendText("Mozilla Firefox\n");
            para.AppendText("Internet Explorer");

            //List5 style
            para = section.AddParagraph() as WParagraph;
            para.AppendText("\nThis para is written with style List5").CharacterFormat.UnderlineStyle = Syncfusion.Drawing.UnderlineStyle.Double;
            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.List5);
            para.AppendText("Google Chrome\n");
            para.AppendText("Mozilla Firefox\n");
            para.AppendText("Internet Explorer");

            # endregion

            # region ListNumber Style

            //List Number style
            para = section.AddParagraph() as WParagraph;
            para.AppendText("\nThis para is written with style ListNumber").CharacterFormat.UnderlineStyle = Syncfusion.Drawing.UnderlineStyle.Double;
            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.ListNumber);
            para.AppendText("Google Chrome\n");
            para.AppendText("Mozilla Firefox\n");
            para.AppendText("Internet Explorer");

            //List Number5 style
            para = section.AddParagraph() as WParagraph;
            para.AppendText("\nThis para is written with style ListNumber5").CharacterFormat.UnderlineStyle = Syncfusion.Drawing.UnderlineStyle.Double;
            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.ListNumber5);
            para.AppendText("Google Chrome\n");
            para.AppendText("Mozilla Firefox\n");
            para.AppendText("Internet Explorer");

            # endregion

            # region TOA Heading Style

            //TOA Heading
            para = section.AddParagraph() as WParagraph;
            para.AppendText("\nThis para is written with style TOA Heading").CharacterFormat.UnderlineStyle = Syncfusion.Drawing.UnderlineStyle.Double;
            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.ToaHeading);
            para.AppendText("Google Chrome\n");
            para.AppendText("Mozilla Firefox\n");
            para.AppendText("Internet Explorer");

            # endregion

            para = section.AddParagraph() as WParagraph;
            section.BreakCode = SectionBreakCode.NewColumn;

            # region ListBullet Style
            //ListBullet
            para = section.AddParagraph() as WParagraph;
            para.AppendText("\nThis para is written with style ListBullet").CharacterFormat.UnderlineStyle = Syncfusion.Drawing.UnderlineStyle.Double;
            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.ListBullet);
            para.AppendText("Google Chrome\n");
            para.AppendText("Mozilla Firefox\n");
            para.AppendText("Internet Explorer");

            //ListBullet5
            para = section.AddParagraph() as WParagraph;
            para.AppendText("\nThis para is written with style ListBullet5").CharacterFormat.UnderlineStyle = Syncfusion.Drawing.UnderlineStyle.Double;
            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.ListBullet5);
            para.AppendText("Google Chrome\n");
            para.AppendText("Mozilla Firefox\n");
            para.AppendText("Internet Explorer");

            # endregion

            # region List Continue Style

            //ListContinue
            para = section.AddParagraph() as WParagraph;
            para.AppendText("\nThis para is written with style ListContinue").CharacterFormat.UnderlineStyle = Syncfusion.Drawing.UnderlineStyle.Double;
            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.ListContinue);
            para.AppendText("Google Chrome\n");
            para.AppendText("Mozilla Firefox\n");
            para.AppendText("Internet Explorer");

            //ListContinue5
            para = section.AddParagraph() as WParagraph;
            para.AppendText("\nThis para is written with style ListContinue5").CharacterFormat.UnderlineStyle = Syncfusion.Drawing.UnderlineStyle.Double;
            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.ListContinue5);
            para.AppendText("Google Chrome\n");
            para.AppendText("Mozilla Firefox\n");
            para.AppendText("Internet Explorer");

            # endregion

            # region HTMLSample Style

            //HtmlSample
            para = section.AddParagraph() as WParagraph;
            para.AppendText("\nThis para is written with style HtmlSample").CharacterFormat.UnderlineStyle = Syncfusion.Drawing.UnderlineStyle.Double;
            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.HtmlSample);
            para.AppendText("Google Chrome\n");
            para.AppendText("Mozilla Firefox\n");
            para.AppendText("Internet Explorer");

            # endregion

            section = document.AddSection() as WSection;
            section.BreakCode = SectionBreakCode.NoBreak;

            # region Document Map Style

            //Docuemnt Map
            para = section.AddParagraph() as WParagraph;
            para.AppendText("This para is written with style DocumentMap\n").CharacterFormat.UnderlineStyle = Syncfusion.Drawing.UnderlineStyle.Double;
            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.DocumentMap);
            IWTextRange textrange = para.AppendText("Google Chrome\n");
            textrange.CharacterFormat.TextBackgroundColor = Syncfusion.Drawing.Color.Red;
            textrange = para.AppendText("Mozilla Firefox\n");
            textrange.CharacterFormat.TextBackgroundColor = Syncfusion.Drawing.Color.Red;
            textrange = para.AppendText("Internet Explorer");
            textrange.CharacterFormat.TextBackgroundColor = Syncfusion.Drawing.Color.Red;

            #endregion

            # region Heading Styles
            //Heading Styles
            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.Heading1);
            para.AppendText("Hello World. This para is written with style " + para.StyleName.ToString());

            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.Heading2);
            para.AppendText("Hello World. This para is written with style " + para.StyleName.ToString());

            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.Heading3);
            para.AppendText("Hello World. This para is written with style " + para.StyleName.ToString());

            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.Heading4);
            para.AppendText("Hello World. This para is written with style " + para.StyleName.ToString());

            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.Heading5);
            para.AppendText("Hello World. This para is written with style " + para.StyleName.ToString());

            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.Heading6);
            para.AppendText("Hello World. This para is written with style " + para.StyleName.ToString());

            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.Heading7);
            para.AppendText("Hello World. This para is written with style " + para.StyleName.ToString());

            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.Heading8);
            para.AppendText("Hello World. This para is written with style " + para.StyleName.ToString());

            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.Heading9);
            para.AppendText("Hello World. This para is written with style " + para.StyleName.ToString());

            # endregion

            #endregion Built-in styles

            #region Saving Document
            MemoryStream stream = new MemoryStream();
            document.Save(stream, FormatType.Word2013);
            document.Close();
			if (stream != null)
			{
				SaveAndroid androidSave = new SaveAndroid ();
				androidSave.Save ("BuiltInStyle.docx", "application/msword", stream, m_context);
			}
            #endregion
        }
    }
}
