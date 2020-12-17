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
using System.IO;
using System.Reflection;
using Android.Content;
using Android.Views;
using Android.Widget;
using System.Xml;

namespace SampleBrowser
{
    public partial class TablesPresentation : SamplePage
    {
        private Context m_context;
        public override View GetSampleContent(Context con)
        {
            LinearLayout linear = new LinearLayout(con);
            linear.SetBackgroundColor(Android.Graphics.Color.White);
            linear.Orientation = Orientation.Vertical;
            linear.SetPadding(10, 10, 10, 10);
            
            TextView text1 = new TextView(con);
            text1.TextSize = 17;
            text1.TextAlignment = TextAlignment.Center;
            text1.SetTextColor(Android.Graphics.Color.ParseColor("#262626"));
            text1.Text = "This sample demonstrates how to create a table with specified number of rows and columns in PowerPoint presentation for displaying tabular data.";
            text1.SetPadding(5, 10, 10, 5);
            linear.AddView(text1);
            
            TextView space = new TextView(con);
            space.TextSize = 10;
            linear.AddView(space);
            m_context = con;
            
            TextView space2 = new TextView(con);
            space2.TextSize = 10;
            linear.AddView(space2);
            
            Button button1 = new Button(con);
            button1.Text = "Generate Presentation";
            button1.Click += OnButtonClicked;
            linear.AddView(button1);
            
            return linear;
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
			if (stream != null)
			{
				SaveAndroid androidSave = new SaveAndroid ();
				androidSave.Save ("Tables.pptx", "application/powerpoint", stream, m_context);
			}
        }
		
		#region HelperMethods
        /// <summary>
        /// Loads the xml content to fill the table cells in the presentation.
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, Dictionary<string, string>> LoadXMLData()
        {
            Dictionary<string, Dictionary<string, string>> Products = new Dictionary<string, Dictionary<string, string>>();
			Assembly assembly = Assembly.GetExecutingAssembly();
            Stream productXMLStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.Presentation.Templates.TableData.xml");
            XmlReader reader = XmlReader.Create(productXMLStream);
            string serailNo = string.Empty;
            string productName = string.Empty;
            string sum = string.Empty;
            string month;

            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    switch (reader.Name)
                    {
                        case "Products":
                            Dictionary<string, string> Month_Value = new Dictionary<string, string>();
                            while (reader.Read())
                            {
                                if (reader.IsStartElement())
                                {
                                    switch (reader.Name)
                                    {
                                        case "Product":
                                            while (reader.Read())
                                            {
                                                if (reader.IsStartElement())
                                                {
                                                    switch (reader.Name)
                                                    {
                                                        case "Month":
                                                            while (reader.Read())
                                                            {
                                                                month = reader.Name;
                                                                if (reader.IsStartElement())
                                                                {
                                                                    month = reader.Name;
                                                                    while (reader.Read())
                                                                    {
                                                                        if (reader.IsStartElement())
                                                                        {
                                                                            if (reader.Name == "Value")
                                                                            {
																				reader.Read();
																				reader.MoveToContent();
                                                                                Month_Value.Add(month, reader.Value);
                                                                            }
                                                                        }
                                                                        else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == month)
                                                                        {
                                                                            break;
                                                                        }
                                                                    }
                                                                }
                                                                else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "Month")
                                                                {
                                                                    break;
                                                                }
                                                            }
                                                            break;
                                                        case "ProductName":
															reader.Read();
															reader.MoveToContent();
                                                            productName = reader.Value;
                                                            break;
                                                    }
                                                }
                                                else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "Product")
                                                {
                                                    break;
                                                }
                                            }
                                            break;
                                    }
                                    Products.Add(productName, Month_Value);
									Month_Value = new Dictionary<string, string>();
                                }
                                else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "Products")
                                    break;
                            }
                            break;
                    }
                }
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
