#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
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
    public partial class CustomStyle : SampleView
    {
        CGRect frameRect = new CGRect();
        float frameMargin = 8.0f;
        UILabel label;
       
        UIButton button;

        public CustomStyle()
        {
            label = new UILabel();
            
            button = new UIButton(UIButtonType.System);
            button.TouchUpInside += OnButtonClicked;
        }

        void LoadAllowedTextsLabel()
        {
            label.Frame = frameRect;
            label.TextColor = UIColor.FromRGB(38 / 255.0f, 38 / 255.0f, 38 / 255.0f);
            label.Text = "This sample demonstrates how to format the Word document contents with user defined styles.";
            label.Font = UIFont.SystemFontOfSize(15);
            label.Lines = 0;
            label.LineBreakMode = UILineBreakMode.WordWrap;
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                label.Font = UIFont.SystemFontOfSize(18);
                label.Frame = new CGRect(5, 5, frameRect.Location.X + frameRect.Size.Width, 60);
            }
            else
            {
                label.Frame = new CGRect(frameRect.Location.X, 5, frameRect.Size.Width, 60);
            }
            this.AddSubview(label);

            
            button.SetTitle("Generate Word", UIControlState.Normal);
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                button.Frame = new CGRect(5,80, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            else
            {
                button.Frame = new CGRect(frameRect.Location.X, 80, frameRect.Size.Width, 10);
            }
            this.AddSubview(button);
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
                if (document.Styles[i].Name == "Normal" || document.Styles[i].Name == "Default Paragraph Font" || document.Styles[i].StyleType != StyleType.ParagraphStyle)
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
            if (stream != null)
            {
                SaveiOS iOSSave = new SaveiOS();
                iOSSave.Save("CustomStyle.docx", "application/msword", stream);
            }
            #endregion
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