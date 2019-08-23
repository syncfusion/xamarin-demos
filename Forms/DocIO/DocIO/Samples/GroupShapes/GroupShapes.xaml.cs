#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SampleBrowser.DocIO;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;
using Syncfusion.OfficeChart;

namespace SampleBrowser.DocIO
{
    public partial class GroupShapes : SampleView
    {
        public GroupShapes()
        {
            InitializeComponent();

            this.docxButton.IsChecked = true;

            if (Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Description.HorizontalOptions = Xamarin.Forms.LayoutOptions.Start;
                this.btnGenerate.HorizontalOptions = Xamarin.Forms.LayoutOptions.Start;
                this.Description.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnGenerate.BackgroundColor = Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                {
                    this.Description.FontSize = 13.5;
                }

                this.Description.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
            }
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

            string filename = "";
            string contenttype = "";
            MemoryStream outputStream = new MemoryStream();
            if (this.pdfButton.IsChecked != null && (bool)this.pdfButton.IsChecked)
            {
                filename = "GroupShapes.pdf";
                contenttype = "application/pdf";
                DocIORenderer renderer = new DocIORenderer();
                PdfDocument pdfDoc = renderer.ConvertToPDF(doc);
                pdfDoc.Save(outputStream);
                pdfDoc.Close();
            }
            else
            {
                filename = "GroupShapes.docx";
                contenttype = "application/msword";
                doc.Save(outputStream, FormatType.Docx);
            }
            doc.Close();
            if (Device.RuntimePlatform == Device.UWP)
                DependencyService.Get<ISaveWindowsPhone>()
                    .Save(filename, contenttype, outputStream);
            else
                DependencyService.Get<ISave>().Save(filename, contenttype, outputStream);
        }
    }
}
