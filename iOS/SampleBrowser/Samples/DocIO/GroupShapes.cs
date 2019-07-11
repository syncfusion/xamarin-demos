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
using Syncfusion.Pdf;
using Syncfusion.DocIORenderer;
using Syncfusion.OfficeChart;
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
    public partial class GroupShapes : SampleView
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
        public GroupShapes()
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
            generateButton.SetTitle("Generate", UIControlState.Normal);
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
            //Initialize Word document
            WordDocument doc = new WordDocument();
            //Ensure Minimum
            doc.EnsureMinimal();
            //Set margins for page.
            doc.LastSection.PageSetup.Margins.All = 72;
            //Create new group shape
            GroupShape groupShape = new GroupShape(doc);

            //Append AutoShape
            Shape shape = new Shape(doc, AutoShapeType.RoundedRectangle);
            shape.Width = 130;
            shape.Height = 45;
            //Set horizontal origin
            shape.HorizontalOrigin = HorizontalOrigin.Page;
            //Set vertical origin
            shape.VerticalOrigin = VerticalOrigin.Page;
            //Set vertical position
            shape.VerticalPosition = 122;
            //Set horizontal position
            shape.HorizontalPosition = 220;
            //Set AllowOverlap to true for overlapping shapes
            shape.WrapFormat.AllowOverlap = true;
            //Set Fill Color
            shape.FillFormat.Color = Syncfusion.Drawing.Color.Blue;
            //Set Content vertical alignment
            shape.TextFrame.TextVerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;
            //Add Texbody contents to Shape
            IWParagraph para = shape.TextBody.AddParagraph();
            para.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            para.AppendText("Requirement").ApplyCharacterFormat(new WCharacterFormat(doc) { Bold = true, TextColor = Syncfusion.Drawing.Color.White, FontSize = 12, FontName = "Verdana" });
            groupShape.Add(shape);

            shape = new Shape(doc, AutoShapeType.DownArrow);
            shape.Width = 45;
            shape.Height = 45;
            shape.HorizontalOrigin = HorizontalOrigin.Page;
            shape.VerticalOrigin = VerticalOrigin.Page;
            shape.VerticalPosition = 167;
            //Set horizontal position
            shape.HorizontalPosition = 265;
            shape.WrapFormat.AllowOverlap = true;
            groupShape.Add(shape);

            shape = new Shape(doc, AutoShapeType.RoundedRectangle);
            shape.Width = 130;
            shape.Height = 45;
            shape.HorizontalOrigin = HorizontalOrigin.Page;
            shape.VerticalOrigin = VerticalOrigin.Page;
            shape.VerticalPosition = 212;
            //Set horizontal position
            shape.HorizontalPosition = 220;
            shape.WrapFormat.AllowOverlap = true;
            shape.FillFormat.Color = Syncfusion.Drawing.Color.Orange;
            shape.TextFrame.TextVerticalAlignment = VerticalAlignment.Middle;
            para = shape.TextBody.AddParagraph();
            para.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            para.AppendText("Design").ApplyCharacterFormat(new WCharacterFormat(doc) { Bold = true, TextColor = Syncfusion.Drawing.Color.White, FontSize = 12, FontName = "Verdana" });
            groupShape.Add(shape);

            shape = new Shape(doc, AutoShapeType.DownArrow);
            shape.Width = 45;
            shape.Height = 45;
            shape.HorizontalOrigin = HorizontalOrigin.Page;
            shape.VerticalOrigin = VerticalOrigin.Page;
            shape.VerticalPosition = 257;
            //Set horizontal position
            shape.HorizontalPosition = 265;
            shape.WrapFormat.AllowOverlap = true;
            groupShape.Add(shape);

            shape = new Shape(doc, AutoShapeType.RoundedRectangle);
            shape.Width = 130;
            shape.Height = 45;
            shape.HorizontalOrigin = HorizontalOrigin.Page;
            shape.VerticalOrigin = VerticalOrigin.Page;
            shape.VerticalPosition = 302;
            //Set horizontal position
            shape.HorizontalPosition = 220;
            shape.WrapFormat.AllowOverlap = true;
            shape.FillFormat.Color = Syncfusion.Drawing.Color.Blue;
            shape.TextFrame.TextVerticalAlignment = VerticalAlignment.Middle;
            para = shape.TextBody.AddParagraph();
            para.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            para.AppendText("Execution").ApplyCharacterFormat(new WCharacterFormat(doc) { Bold = true, TextColor = Syncfusion.Drawing.Color.White, FontSize = 12, FontName = "Verdana" });
            groupShape.Add(shape);

            shape = new Shape(doc, AutoShapeType.DownArrow);
            shape.Width = 45;
            shape.Height = 45;
            shape.HorizontalOrigin = HorizontalOrigin.Page;
            shape.VerticalOrigin = VerticalOrigin.Page;
            shape.VerticalPosition = 347;
            //Set horizontal position
            shape.HorizontalPosition = 265;
            shape.WrapFormat.AllowOverlap = true;
            groupShape.Add(shape);

            shape = new Shape(doc, AutoShapeType.RoundedRectangle);
            shape.Width = 130;
            shape.Height = 45;
            shape.HorizontalOrigin = HorizontalOrigin.Page;
            shape.VerticalOrigin = VerticalOrigin.Page;
            shape.VerticalPosition = 392;
            //Set horizontal position
            shape.HorizontalPosition = 220;
            shape.WrapFormat.AllowOverlap = true;
            shape.FillFormat.Color = Syncfusion.Drawing.Color.Violet;
            shape.TextFrame.TextVerticalAlignment = VerticalAlignment.Middle;
            para = shape.TextBody.AddParagraph();
            para.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            para.AppendText("Testing").ApplyCharacterFormat(new WCharacterFormat(doc) { Bold = true, TextColor = Syncfusion.Drawing.Color.White, FontSize = 12, FontName = "Verdana" });
            groupShape.Add(shape);


            shape = new Shape(doc, AutoShapeType.DownArrow);
            shape.Width = 45;
            shape.Height = 45;
            shape.HorizontalOrigin = HorizontalOrigin.Page;
            shape.VerticalOrigin = VerticalOrigin.Page;
            shape.VerticalPosition = 437;
            //Set horizontal position
            shape.HorizontalPosition = 265;
            shape.WrapFormat.AllowOverlap = true;
            groupShape.Add(shape);


            shape = new Shape(doc, AutoShapeType.RoundedRectangle);
            shape.Width = 130;
            shape.Height = 45;
            shape.HorizontalOrigin = HorizontalOrigin.Page;
            shape.VerticalOrigin = VerticalOrigin.Page;
            shape.VerticalPosition = 482;
            //Set horizontal position
            shape.HorizontalPosition = 220;
            shape.WrapFormat.AllowOverlap = true;
            shape.FillFormat.Color = Syncfusion.Drawing.Color.PaleVioletRed;
            shape.TextFrame.TextVerticalAlignment = VerticalAlignment.Middle;
            para = shape.TextBody.AddParagraph();
            para.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            para.AppendText("Release").ApplyCharacterFormat(new WCharacterFormat(doc) { Bold = true, TextColor = Syncfusion.Drawing.Color.White, FontSize = 12, FontName = "Verdana" });
            groupShape.Add(shape);
            doc.LastParagraph.ChildEntities.Add(groupShape);            

            string fileName = null;
            string ContentType = null;
            MemoryStream ms = new MemoryStream();
            if (pdfButton != null && (bool)pdfButton.IsChecked)
            {
                fileName = "GroupShapes.pdf";
                ContentType = "application/pdf";
                DocIORenderer renderer = new DocIORenderer();
                PdfDocument pdfDoc = renderer.ConvertToPDF(doc);
                pdfDoc.Save(ms);
                pdfDoc.Close();
            }
            else
            {
                fileName = "GroupShapes.docx";
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