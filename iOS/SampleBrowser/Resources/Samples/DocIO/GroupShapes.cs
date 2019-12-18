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
            //Creates a new Word document 
            WordDocument document = new WordDocument();
            //Adds new section to the document
            IWSection section = document.AddSection();
            //Sets page setup options
            section.PageSetup.Orientation = PageOrientation.Landscape;
            section.PageSetup.Margins.All = 72;
            section.PageSetup.PageSize = new SizeF(792f, 612f);
            //Adds new paragraph to the section
            WParagraph paragraph = section.AddParagraph() as WParagraph;
            //Creates new group shape
            GroupShape groupShape = new GroupShape(document);
            //Adds group shape to the paragraph.
            paragraph.ChildEntities.Add(groupShape);

            //Create a RoundedRectangle shape with "Management" text
            CreateChildShape(AutoShapeType.RoundedRectangle, new RectangleF(324f, 107.7f, 144f, 45f), 0, false, false, Syncfusion.Drawing.Color.FromArgb(50, 48, 142), "Management", groupShape, document);

            //Create a BentUpArrow shape to connect with "Development" shape
            CreateChildShape(AutoShapeType.BentUpArrow, new RectangleF(177.75f, 176.25f, 210f, 50f), 180, false, false, Syncfusion.Drawing.Color.White, null, groupShape, document);

            //Create a BentUpArrow shape to connect with "Sales" shape
            CreateChildShape(AutoShapeType.BentUpArrow, new RectangleF(403.5f, 175.5f, 210f, 50f), 180, true, false, Syncfusion.Drawing.Color.White, null, groupShape, document);

            //Create a DownArrow shape to connect with "Production" shape
            CreateChildShape(AutoShapeType.DownArrow, new RectangleF(381f, 153f, 29.25f, 72.5f), 0, false, false, Syncfusion.Drawing.Color.White, null, groupShape, document);

            //Create a RoundedRectangle shape with "Development" text
            CreateChildShape(AutoShapeType.RoundedRectangle, new RectangleF(135f, 226.45f, 110f, 40f), 0, false, false, Syncfusion.Drawing.Color.FromArgb(104, 57, 157), "Development", groupShape, document);

            //Create a RoundedRectangle shape with "Production" text
            CreateChildShape(AutoShapeType.RoundedRectangle, new RectangleF(341f, 226.5f, 110f, 40f), 0, false, false, Syncfusion.Drawing.Color.FromArgb(149, 50, 118), "Production", groupShape, document);

            //Create a RoundedRectangle shape with "Sales" text
            CreateChildShape(AutoShapeType.RoundedRectangle, new RectangleF(546.75f, 226.5f, 110f, 40f), 0, false, false, Syncfusion.Drawing.Color.FromArgb(179, 63, 62), "Sales", groupShape, document);

            //Create a DownArrow shape to connect with "Software" and "Hardware" shape
            CreateChildShape(AutoShapeType.DownArrow, new RectangleF(177f, 265.5f, 25.5f, 20.25f), 0, false, false, Syncfusion.Drawing.Color.White, null, groupShape, document);

            //Create a DownArrow shape to connect with "Series" and "Parts" shape
            CreateChildShape(AutoShapeType.DownArrow, new RectangleF(383.25f, 265.5f, 25.5f, 20.25f), 0, false, false, Syncfusion.Drawing.Color.White, null, groupShape, document);

            //Create a DownArrow shape to connect with "North" and "South" shape            
            CreateChildShape(AutoShapeType.DownArrow, new RectangleF(588.75f, 266.25f, 25.5f, 20.25f), 0, false, false, Syncfusion.Drawing.Color.White, null, groupShape, document);

            //Create a BentUpArrow shape to connect with "Software" shape
            CreateChildShape(AutoShapeType.BentUpArrow, new RectangleF(129.5f, 286.5f, 60f, 33f), 180, false, false, Syncfusion.Drawing.Color.White, null, groupShape, document);

            //Create a BentUpArrow shape to connect with "Hardware" shape
            CreateChildShape(AutoShapeType.BentUpArrow, new RectangleF(190.5f, 286.5f, 60f, 33f), 180, true, false, Syncfusion.Drawing.Color.White, null, groupShape, document);

            //Create a BentUpArrow shape to connect with "Series" shape
            CreateChildShape(AutoShapeType.BentUpArrow, new RectangleF(336f, 287.25f, 60f, 33f), 180, false, false, Syncfusion.Drawing.Color.White, null, groupShape, document);

            //Create a BentUpArrow shape to connect with "Parts" shape
            CreateChildShape(AutoShapeType.BentUpArrow, new RectangleF(397f, 287.25f, 60f, 33f), 180, true, false, Syncfusion.Drawing.Color.White, null, groupShape, document);

            //Create a BentUpArrow shape to connect with "North" shape
            CreateChildShape(AutoShapeType.BentUpArrow, new RectangleF(541.5f, 288f, 60f, 33f), 180, false, false, Syncfusion.Drawing.Color.White, null, groupShape, document);

            //Create a BentUpArrow shape to connect with "South" shape
            CreateChildShape(AutoShapeType.BentUpArrow, new RectangleF(602.5f, 288f, 60f, 33f), 180, true, false, Syncfusion.Drawing.Color.White, null, groupShape, document);

            //Create a RoundedRectangle shape with "Software" text
            CreateChildShape(AutoShapeType.RoundedRectangle, new RectangleF(93f, 320.25f, 90f, 40f), 0, false, false, Syncfusion.Drawing.Color.FromArgb(23, 187, 189), "Software", groupShape, document);

            //Create a RoundedRectangle shape with "Hardware" text
            CreateChildShape(AutoShapeType.RoundedRectangle, new RectangleF(197.2f, 320.25f, 90f, 40f), 0, false, false, Syncfusion.Drawing.Color.FromArgb(24, 159, 106), "Hardware", groupShape, document);

            //Create a RoundedRectangle shape with "Series" text
            CreateChildShape(AutoShapeType.RoundedRectangle, new RectangleF(299.25f, 320.25f, 90f, 40f), 0, false, false, Syncfusion.Drawing.Color.FromArgb(23, 187, 189), "Series", groupShape, document);

            //Create a RoundedRectangle shape with "Parts" text
            CreateChildShape(AutoShapeType.RoundedRectangle, new RectangleF(404.2f, 320.25f, 90f, 40f), 0, false, false, Syncfusion.Drawing.Color.FromArgb(24, 159, 106), "Parts", groupShape, document);

            //Create a RoundedRectangle shape with "North" text
            CreateChildShape(AutoShapeType.RoundedRectangle, new RectangleF(505.5f, 321.75f, 90f, 40f), 0, false, false, Syncfusion.Drawing.Color.FromArgb(23, 187, 189), "North", groupShape, document);

            //Create a RoundedRectangle shape with "South" text
            CreateChildShape(AutoShapeType.RoundedRectangle, new RectangleF(609.7f, 321.75f, 90f, 40f), 0, false, false, Syncfusion.Drawing.Color.FromArgb(24, 159, 106), "South", groupShape, document);

            string fileName = null;
            string ContentType = null;
            MemoryStream ms = new MemoryStream();
            if (pdfButton != null && (bool)pdfButton.IsChecked)
            {
                fileName = "GroupShapes.pdf";
                ContentType = "application/pdf";
                DocIORenderer renderer = new DocIORenderer();
                PdfDocument pdfDoc = renderer.ConvertToPDF(document);
                pdfDoc.Save(ms);
                pdfDoc.Close();
            }
            else
            {
                fileName = "GroupShapes.docx";
                ContentType = "application/msword";
                document.Save(ms, FormatType.Docx);
            }

            //Reset the stream position
            ms.Position = 0;

            //Close the document instance.
            document.Close();

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

        /// <summary>
        /// Create a child shape with its specified properties and add into specified group shape
        /// </summary>
        /// <param name="autoShapeType">Represent the AutoShapeType of child shape</param>
        /// <param name="bounds">Represent the bounds of child shape to be placed</param>
        /// <param name="rotation">Represent the rotation of child shape</param>
        /// <param name="flipH">Represent the horizontal flip of child shape</param>
        /// <param name="flipV">Represent the vertical flip of child shape</param>
        /// <param name="fillColor">Represent the fill color of child shape</param>
        /// <param name="text">Represent the text that to be append in child shape</param>
        /// <param name="groupShape">Represent the group shape to add a child shape</param>
        /// <param name="wordDocument">Represent the Word document instance</param>
        private static void CreateChildShape(AutoShapeType autoShapeType, RectangleF bounds, float rotation, bool flipH, bool flipV, Syncfusion.Drawing.Color fillColor, string text, GroupShape groupShape, WordDocument wordDocument)
        {
            //Creates new shape to add into group
            Shape shape = new Shape(wordDocument, autoShapeType);
            //Sets height and width for shape
            shape.Height = bounds.Height;
            shape.Width = bounds.Width;
            //Sets horizontal and vertical position
            shape.HorizontalPosition = bounds.X;
            shape.VerticalPosition = bounds.Y;
            //Set rotation and flipH for the shape
            if (rotation != 0)
                shape.Rotation = rotation;
            if (flipH)
                shape.FlipHorizontal = true;
            if (flipV)
                shape.FlipVertical = true;
            //Applies fill color for shape
            if (fillColor != Syncfusion.Drawing.Color.White)
            {
                shape.FillFormat.Fill = true;
                shape.FillFormat.Color = fillColor;
            }
            //Set wrapping style for shape
            shape.WrapFormat.TextWrappingStyle = TextWrappingStyle.InFrontOfText;
            //Sets horizontal and vertical origin
            shape.HorizontalOrigin = HorizontalOrigin.Page;
            shape.VerticalOrigin = VerticalOrigin.Page;
            //Sets no line to RoundedRectangle shapes
            if (autoShapeType == AutoShapeType.RoundedRectangle)
                shape.LineFormat.Line = false;
            //Add paragraph for the shape textbody
            if (text != null)
            {
                IWParagraph paragraph = shape.TextBody.AddParagraph();
                //Set required textbody alignments
                shape.TextFrame.TextVerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;
                //Set required paragraph alignments
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                IWTextRange textRange = paragraph.AppendText(text);
                //Applies a required text formatting's
                textRange.CharacterFormat.FontName = "Calibri";
                textRange.CharacterFormat.FontSize = 15;
                textRange.CharacterFormat.TextColor = Syncfusion.Drawing.Color.White;
                textRange.CharacterFormat.Bold = true;
                textRange.CharacterFormat.Italic = true;
            }
            //Adds the specified shape to group shape
            groupShape.Add(shape);
        }
    }
}