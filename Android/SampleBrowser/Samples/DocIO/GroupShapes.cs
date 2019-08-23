#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.OfficeChart;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Webkit;
using Android.App;
using Android.OS;

namespace SampleBrowser
{
	public partial class GroupShapes : SamplePage
    {
        private Context m_context;
        RadioGroup radioGroup;
        RadioButton docxButton;
        RadioButton pdfButton;

        public override View GetSampleContent(Context con)
        {
            LinearLayout linear = new LinearLayout(con);
            linear.SetBackgroundColor(Color.White);
            linear.Orientation = Orientation.Vertical;
            linear.SetPadding(10, 10, 10, 10);

            TextView text2 = new TextView(con);
            text2.TextSize = 17;
            text2.TextAlignment = TextAlignment.Center;
            text2.Text = "This sample demonstrates how to create a Word document with Group shapes.";
            text2.SetTextColor(Color.ParseColor("#262626"));
            text2.SetPadding(5, 5, 5, 5);

            linear.AddView(text2);

            TextView space1 = new TextView(con);
            space1.TextSize = 10;
            linear.AddView(space1);

            m_context = con;

            LinearLayout radioLinearLayout = new LinearLayout(con);
            radioLinearLayout.Orientation = Orientation.Horizontal;

            TextView imageType = new TextView(con);
            imageType.Text = "Save As : ";
            imageType.TextSize = 19;
            radioLinearLayout.AddView(imageType);

            radioGroup = new RadioGroup(con);
            radioGroup.TextAlignment = TextAlignment.Center;
            radioGroup.Orientation = Orientation.Horizontal;
            docxButton = new RadioButton(con);
            docxButton.Text = "DOCX";
            radioGroup.AddView(docxButton);
            pdfButton = new RadioButton(con);
            pdfButton.Text = "PDF";
            radioGroup.AddView(pdfButton);
            radioGroup.Check(1);
            radioLinearLayout.AddView(radioGroup);
            linear.AddView(radioLinearLayout);
            docxButton.Checked = true;

            TextView space2 = new TextView(con);
            space2.TextSize = 10;
            linear.AddView(space2);

            Button generateButton = new Button(con);
            generateButton.Text = "Generate";
            generateButton.Click += OnButtonClicked;
            linear.AddView(generateButton);

            return linear;
        }        

        void OnButtonClicked(object sender, EventArgs e)
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

            MemoryStream ms = new MemoryStream();

            //Set file content type
            string contentType = null;
            string fileName = null;
            if (docxButton.Checked)
            {
                fileName = "GroupShapes.docx";
                contentType = "application/msword";
                doc.Save(ms, FormatType.Docx);
            }
            else
            {
                fileName = "GroupShapes.pdf";
                contentType = "application/pdf";
                DocIORenderer renderer = new DocIORenderer();
                PdfDocument pdfDoc = renderer.ConvertToPDF(doc);
                pdfDoc.Save(ms);
                pdfDoc.Close();
            }

            doc.Dispose();
            
            if (ms != null)
            {
                SaveAndroid androidSave = new SaveAndroid();
                androidSave.Save(fileName, contentType, ms, m_context);
            }
        }
    }
}

