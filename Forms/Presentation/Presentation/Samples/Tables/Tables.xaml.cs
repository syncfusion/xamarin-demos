#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COLOR = Syncfusion.Drawing;
using Xamarin.Forms;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using SampleBrowser.Core;

namespace SampleBrowser.Presentation
{
    public partial class Tables : SampleView
    {
        public Tables()
        {
            InitializeComponent();

            if (Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Description.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.HorizontalOptions = LayoutOptions.Start;
                this.Description.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.BackgroundColor = Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Description.FontSize = 13.5;
                this.Description.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
            }
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            //Stream to save the created PowerPoint presnetation
            MemoryStream stream = new MemoryStream();
            //Creates a new instance of the presentation.
            using (IPresentation presentation = Syncfusion.Presentation.Presentation.Create())
            {
                #region Slide1
                //To add a slide to PowerPoint presentation
                ISlide slide = presentation.Slides.Add(SlideLayoutType.TitleOnly);
                //To set the table title in a slide
                SetTableTitle(slide);
                //To get the table data from an XML file
                Dictionary<string, Dictionary<string, string>> products = LoadXMLData();
                int columnCount = products.Keys.Count + 1;
                int rowCount = products[products.Keys.ToArray()[0]].Count + 1;
                //To add a new table in slide.
                ITable table = slide.Shapes.AddTable(rowCount, columnCount, 61.92, 95.76, 856.8, 378.72);
                //To set the style for the table.
                table.BuiltInStyle = BuiltInTableStyle.MediumStyle2Accent6;
                //To set category title
                SetCategoryTitle(table);
                //Iterates and sets the values to the table cells.
                for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
                {
                    IRow row = table.Rows[rowIndex];
                    Dictionary<string, string> months = products[products.Keys.ToArray()[0]];
                    string[] monthName = months.Keys.ToArray();
                    for (int cellIndex = 0; cellIndex < row.Cells.Count - 1; cellIndex++)
                    {
                        months = products[products.Keys.ToArray()[cellIndex]];
                        AddHeaderRowAndColumn(row, cellIndex, products.Keys.ToArray(), rowIndex, monthName);
                        AddCellContent(row, rowIndex, monthName, months, cellIndex);
                    }
                }
                #endregion

                //Save the presentation instance to the memory stream.
                presentation.Save(stream);
            }
            stream.Position = 0;
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("TablesSample.pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("TablesSample.pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation", stream);
        }

        #region HelperMethods
        /// <summary>
        /// Loads the xml content to fill the table cells in the presentation.
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, Dictionary<string, string>> LoadXMLData()
        {
            XDocument productXml;
            Dictionary<string, Dictionary<string, string>> Products = new Dictionary<string, Dictionary<string, string>>();
            Assembly assembly = typeof(Tables).GetTypeInfo().Assembly;
            Stream productXMLStream = null;
#if COMMONSB
			productXMLStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.Presentation.Samples.Templates.TableData.xml");
#else
            productXMLStream = assembly.GetManifestResourceStream("SampleBrowser.Presentation.Samples.Templates.TableData.xml");
#endif
            productXml = XDocument.Load(productXMLStream);
            IEnumerable<XElement> productElements = from product in productXml.Descendants("Product") select product;
            string serailNo = string.Empty;
            string productName = string.Empty;
            string sum = string.Empty;
            string month;
            foreach (XElement productElement in productElements)
            {

                Dictionary<string, string> Month_Value = new Dictionary<string, string>();
                foreach (XElement child in productElement.Descendants())
                {
                    var childElements = productElement.Element(child.Name);
                    if (childElements != null)
                    {
                        string value = childElements.Value;
                        string elementName = child.Name.ToString();
                        switch (elementName)
                        {
                            case "Month":
                                foreach (XElement mo in child.Descendants())
                                {
                                    month = mo.Name.LocalName;
                                    foreach (XElement val in mo.Descendants())
                                    {
                                        Month_Value.Add(month, val.Value);
                                    }
                                }
                                break;
                            case "ProductName":
                                productName = value;
                                break;
                        }
                    }
                }
                Products.Add(productName, Month_Value);
            }
            return Products;
        }

        /// <summary>
        /// Sets the table title.
        /// </summary>
        /// <param name="slide">Represents the slide instance of the presentation.</param>
        private void SetTableTitle(ISlide slide)
        {
            IShape shape = slide.Shapes[0] as IShape;
            shape.Left = 84.24;
            shape.Top = 0;
            shape.Width = 792;
            shape.Height = 126.72;
            ITextBody textFrame = shape.TextBody;
            IParagraphs paragraphs = textFrame.Paragraphs;
            paragraphs.Add();
            IParagraph paragraph = paragraphs[0];
            paragraph.HorizontalAlignment = HorizontalAlignmentType.Center;

            //Instance to hold textparts in paragraph.
            ITextParts textParts = paragraph.TextParts;
            textParts.Add();
            ITextPart textPart = textParts[0];
            textPart.Text = "Target ";
            IFont font = textPart.Font;
            font.FontName = "Arial";
            font.FontSize = 28;
            font.Bold = true;
            font.CapsType = TextCapsType.All;
            textParts.Add();

            //Creates a textpart and assigns value to it.
            textPart = textParts[1];
            textPart.Text = "Vs ";
            font = textPart.Font;
            font.FontName = "Arial";
            font.FontSize = 18;
            textParts.Add();

            //Creates a textpart and assigns value to it.
            textPart = textParts[2];
            textPart.Text = "PERFORMANCE";
            font = textPart.Font;
            font.FontName = "Arial";
            font.FontSize = 28;
            font.Bold = true;
        }

        /// <summary>
        /// Adds the cell content to the table.
        /// </summary>
        /// <param name="row">Represents the instance of row.</param>
        /// <param name="rowIndex">Represents the row index.</param>
        /// <param name="monthName">Represnets the array of month name.</param>
        /// <param name="months">Represnets the dictionary of months and its values.</param>
        /// <param name="cellIndex">Represents the cell index.</param>
        private void AddCellContent(IRow row, int rowIndex, string[] monthName, Dictionary<string, string> months, int cellIndex)
        {
            if (rowIndex == 0) return;
            ICell cell = row.Cells[cellIndex + 1];
            //Instance to hold paragraphs in cell.
            IParagraphs paragraphs = cell.TextBody.Paragraphs;
            paragraphs.Add();
            IParagraph paragraph = paragraphs[0];
            paragraph.HorizontalAlignment = HorizontalAlignmentType.Left;
            ITextParts textParts = paragraph.TextParts;
            textParts.Add();

            //Creates a textpart and assigns value to it.
            ITextPart textPart = textParts[0];
            textPart.Text = months[monthName[rowIndex - 1]];
            IFont font = textPart.Font;
            font.FontName = "Arial";
            font.FontSize = 14;
        }

        /// <summary>
        /// Adds the content for the row and column for the table.
        /// </summary>
        /// <param name="row">Represents the particular row.</param>
        /// <param name="cellIndex">Represents the index of the cell.</param>
        /// <param name="cellContent">Represents the cell content.</param>
        /// <param name="rowIndex">Represents the index of the row.</param>
        /// <param name="monthName">Represents the content of monthname for the table.</param>
        private void AddHeaderRowAndColumn(IRow row, int cellIndex, string[] cellContent, int rowIndex, string[] monthName)
        {
            //To set text alignment type inside cell
            ICell cell = null;
            if (rowIndex == 0)
                cell = row.Cells[cellIndex + 1];
            else
                cell = row.Cells[0];
            cell.TextBody.VerticalAlignment = VerticalAlignmentType.Middle;

            //To add a paragraph inside cell
            IParagraphs paragraphs = cell.TextBody.Paragraphs;
            if (paragraphs.Count == 0)
                paragraphs.Add();
            IParagraph paragraph = paragraphs[0];
            paragraph.HorizontalAlignment = HorizontalAlignmentType.Center;
            ITextParts textParts = paragraph.TextParts;
            if (textParts.Count == 0)
                textParts.Add();

            //Creates a textpart and assigns value to it.
            ITextPart textPart = textParts[0];
            if (rowIndex == 0)
                textPart.Text = cellContent[cellIndex];
            else
                textPart.Text = monthName[rowIndex - 1];
            IFont font = textPart.Font;
            font.FontName = "Arial";
            font.FontSize = 14;
            font.Bold = true;
        }

        /// <summary>
        /// Sets the title for the category in the table.
        /// </summary>
        /// <param name="table">Instance to access the table from the presentation.</param>
        void SetCategoryTitle(ITable table)
        {
            //Instance to hold rows in the table
            table.Rows[0].Height = 81.44;
            //To set text alignment type inside cell
            //ICell cell11 = ;
            table.Rows[0].Cells[0].TextBody.VerticalAlignment = VerticalAlignmentType.Middle;

            //To add a paragraph inside cell
            IParagraphs paragraphs = table.Rows[0].Cells[0].TextBody.Paragraphs;
            paragraphs.Add();
            IParagraph paragraph = paragraphs[0];
            paragraph.HorizontalAlignment = HorizontalAlignmentType.Center;
            ITextParts textParts = paragraph.TextParts;
            textParts.Add();

            //Creates a textpart and assigns value to it.
            ITextPart textPart = textParts[0];
            textPart.Text = "Month";
            IFont font = textPart.Font;
            font.FontName = "Arial";
            font.FontSize = 14;
            font.Bold = true;
        }
        #endregion HelperMethods

    }
}
