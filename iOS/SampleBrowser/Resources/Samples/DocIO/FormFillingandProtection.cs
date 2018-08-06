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
    public partial class FormFillingAndProtection : SampleView
    {
        CGRect frameRect = new CGRect();
        float frameMargin = 8.0f;
        UILabel label;
        UIButton button;

        public FormFillingAndProtection()
        {
            label = new UILabel();
            button = new UIButton(UIButtonType.System);
            button.TouchUpInside += OnButtonClicked;
        }

        void LoadAllowedTextsLabel()
        {
            label.Frame = frameRect;
            label.TextColor = UIColor.FromRGB(38 / 255.0f, 38 / 255.0f, 38 / 255.0f);
            label.Text = "This sample demonstrates how to fill data and protect the content controls in an existing Word document.";
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
                button.Frame = new CGRect(5, 80, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            else
            {
                button.Frame = new CGRect(frameRect.Location.X, 80, frameRect.Size.Width, 10);
            }
            this.AddSubview(button);
        }
        void OnButtonClicked(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream inputStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.DocIO.Templates.ContentControlTemplate.docx");

            //Creates an empty Word document instance.
            WordDocument document = new WordDocument();

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
                SaveiOS iOSSave = new SaveiOS();
                iOSSave.Save("FormFillingAndProtection.docx", "application/msword", stream);
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