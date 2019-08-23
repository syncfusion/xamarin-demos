#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.Presentation;
using System.IO;
using COLOR = Syncfusion.Drawing;
using System.Reflection;
using System.Xml;
using System.Linq;
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
	public partial class SlidesPresentation : SampleView
	{
		CGRect frameRect = new CGRect ();
		float frameMargin = 8.0f;
		UILabel label;
		UILabel label1;
		UIButton button;
		public SlidesPresentation()
		{

			label1 = new UILabel();
			label = new UILabel();
			button = new UIButton(UIButtonType.System);
			button.TouchUpInside += OnButtonClicked;
		}

		void LoadAllowedTextsLabel()
		{
			label.Frame = frameRect;
			label.TextColor = UIColor.FromRGB (38/255.0f, 38/255.0f, 38/255.0f);
			label.Text = "This sample demonstrates how to create a slide with predefined layouts, like Microsoft PowerPoint.";
			label.Font = UIFont.SystemFontOfSize(15);
			label.Lines 				= 0;
			label.LineBreakMode 		= UILineBreakMode.WordWrap;
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				label.Font = UIFont.SystemFontOfSize(18);
				label.Frame = new CGRect (5, 5,frameRect.Location.X + frameRect.Size.Width  , 50);
			} 
			else {
				label.Frame = new CGRect (frameRect.Location.X, 5, frameRect.Size.Width , 70);

			}
			this.AddSubview (label);
            
			button.SetTitle("Generate Presentation",UIControlState.Normal);
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				button.Frame = new CGRect (0, 65, frameRect.Location.X + frameRect.Size.Width , 10);
			} 
			else {
				button.Frame = new CGRect (frameRect.Location.X, 70, frameRect.Size.Width , 10);

			}
			this.AddSubview (button);
		}

		void OnButtonClicked(object sender, EventArgs e)
		{
			string resourcePath = "SampleBrowser.Samples.Presentation.Templates.Slides.pptx";
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);
            IPresentation presentation = Presentation.Open(fileStream);
			#region Slide1
			ISlide slide1 = presentation.Slides[0];
			IShape shape1 = slide1.Shapes[0] as IShape;
			shape1.Left = 108;
            shape1.Top = 139.68;
            shape1.Width = 743.04;
            shape1.Height = 144;

            ITextBody textFrame1 = shape1.TextBody;
			IParagraphs paragraphs1 = textFrame1.Paragraphs;
			IParagraph paragraph1 = paragraphs1.Add();
			paragraphs1[0].IndentLevelNumber = 0;

			AddParagraphData(paragraph1, "ESSENTIAL PRESENTATION", "Calibri", 48,true);
			paragraph1.HorizontalAlignment = HorizontalAlignmentType.Center;
            slide1.Shapes.RemoveAt(1);
			#endregion

			#region Slide2
			ISlide slide2 = presentation.Slides.Add(SlideLayoutType.SectionHeader);
			shape1 = slide2.Shapes[0] as IShape;
            shape1.Left = 55;
            shape1.Top = 23;
            shape1.Width = 573;
            shape1.Height = 71;
            textFrame1 = shape1.TextBody;

            //Instance to hold paragraphs in textframe
            paragraphs1 = textFrame1.Paragraphs;
            paragraph1 = paragraphs1.Add();           
			AddParagraphData(paragraph1, "Slide with simple text", "Calibri", 40, false);
			paragraphs1[0].HorizontalAlignment = HorizontalAlignmentType.Left;

            IShape shape2 = slide2.Shapes[1] as IShape;
			shape2.Left = 87;
            shape2.Top = 119;
            shape2.Width = 725;
            shape2.Height = 355;
            ITextBody textFrame2 = shape2.TextBody;

			//Instance to hold paragraphs in textframe
			IParagraphs paragraphs2 = textFrame2.Paragraphs;

			//Add paragrpah text
			IParagraph paragraph_1 = paragraphs2.Add();
			AddParagraphData(paragraph_1, "Adventure Works Cycles, the fictitious company on which the AdventureWorks sample databases are based, is a large, multinational manufacturing company. The company manufactures and sells metal and composite bicycles to North American, European and Asian commercial markets. While its base operation is located in Bothell, Washington with 290 employees, several regional sales teams are located throughout their market base.", "Calibri", 15, false);

			IParagraph paragraph_2 = paragraphs2.Add();
            AddParagraphData(paragraph_2, "In 2000, Adventure Works Cycles bought a small manufacturing plant, Importadores Neptuno, located in Mexico. Importadores Neptuno manufactures several critical subcomponents for the Adventure Works Cycles product line. These subcomponents are shipped to the Bothell location for final product assembly. In 2001, Importadores Neptuno, became the sole manufacturer and distributor of the touring bicycle product group.", "Calibri", 15, false);
            #endregion

            #region Slide3
            slide2 = presentation.Slides.Add(SlideLayoutType.TwoContent);
            shape1 = slide2.Shapes[0] as IShape;
            shape1.Left = 26;
            shape1.Top = 37;
            shape1.Width = 815;
            shape1.Height = 76;

            //Adds textframe in shape
            textFrame1 = shape1.TextBody;

            //Instance to hold paragraphs in textframe
            paragraphs1 = textFrame1.Paragraphs;
            paragraphs1.Add();
            paragraph1 = paragraphs1[0];
            AddParagraphData(paragraph1, "Slide with Image", "Calibri", 44, false);

			//Adds shape in slide
			shape2 = slide2.Shapes[1] as IShape;
            shape2.Left = 578;
            shape2.Top = 141;
            shape2.Width = 316;
            shape2.Height = 326;
            textFrame2 = shape2.TextBody;

            //Instance to hold paragraphs in textframe
            paragraphs2 = textFrame2.Paragraphs;
            IParagraph paragraph2 = paragraphs2.Add();

            AddParagraphData(paragraph2, "The Northwind sample database (Northwind.mdb) is included with all versions of Access. It provides data you can experiment with and database objects that demonstrate features you might want to implement in your own databases.", "Calibri", 16, false);
			IParagraph paragraph3 = paragraphs2.Add();

            AddParagraphData(paragraph3, "Using Northwind, you can become familiar with how a relational database is structured and how the database objects work together to help you enter, store, manipulate, and print your data.", "Calibri", 16, false);
			IParagraph paragraph4 = paragraphs2.Add();

 //           AddParagraphData(paragraph4, ref textpart1, "While its base operation is located in Bothell, Washington with 290 employees, several regional sales teams are located throughout their market base.", "Calibri", 16);
IShape shape3 = (IShape)slide2.Shapes[2];
slide2.Shapes.RemoveAt(2);

            //Adds picture in the shape
            resourcePath = "SampleBrowser.Samples.Presentation.Templates.tablet.jpg";
            assembly = Assembly.GetExecutingAssembly();
            fileStream = assembly.GetManifestResourceStream(resourcePath);
            IPicture picture1 = slide2.Shapes.AddPicture(fileStream, 58, 141, 477, 318);
            fileStream.Close();
            #endregion

#region Slide4
ISlide slide4 = presentation.Slides.Add(SlideLayoutType.TwoContent);
shape1 = slide4.Shapes[0] as IShape;
            shape1.Left = 37;
            shape1.Top = 24;
            shape1.Width = 815;
            shape1.Height = 76;
            textFrame1 = shape1.TextBody;
            
            //Instance to hold paragraphs in textframe
            paragraphs1 = textFrame1.Paragraphs;
            paragraphs1.Add();
            paragraph1 = paragraphs1[0];

			AddParagraphData(paragraph1, "Slide with Table", "Calibri", 44, false);
shape2 = slide4.Shapes[1] as IShape;
            slide4.Shapes.Remove(shape2);

            ITable table = (ITable)slide4.Shapes.AddTable(6, 6, 58, 154, 823, 273);
table.Rows[0].Height = 61.2;
            table.Rows[1].Height = 30;
            table.Rows[2].Height = 61;
            table.Rows[3].Height = 61;
            table.Rows[4].Height = 61;
            table.Rows[5].Height = 61;
            table.HasBandedRows = true;
            table.HasHeaderRow = true;
            table.HasBandedColumns = false;
            table.BuiltInStyle = BuiltInTableStyle.MediumStyle2Accent1;

            ICell cell1 = table.Rows[0].Cells[0];
textFrame2 = cell1.TextBody;
            paragraph2 = textFrame2.Paragraphs.Add();
            paragraph2.HorizontalAlignment = HorizontalAlignmentType.Center;
            ITextPart textPart2 = paragraph2.AddTextPart();
textPart2.Text = "ID";

            ICell cell2 = table.Rows[0].Cells[1];
ITextBody textFrame3 = cell2.TextBody;
paragraph3 = textFrame3.Paragraphs.Add();
            paragraph3.HorizontalAlignment = HorizontalAlignmentType.Center;
            ITextPart textPart3 = paragraph3.AddTextPart();
textPart3.Text = "Company Name";

            ICell cell3 = table.Rows[0].Cells[2];
ITextBody textFrame4 = cell3.TextBody;
paragraph4 = textFrame4.Paragraphs.Add();
            paragraph4.HorizontalAlignment = HorizontalAlignmentType.Center;
            ITextPart textPart4 = paragraph4.AddTextPart();
textPart4.Text = "Contact Name";

            ICell cell4 = table.Rows[0].Cells[3];
ITextBody textFrame5 = cell4.TextBody;
IParagraph paragraph5 = textFrame5.Paragraphs.Add();
paragraph5.HorizontalAlignment = HorizontalAlignmentType.Center;
            ITextPart textPart5 = paragraph5.AddTextPart();
textPart5.Text = "Address";

            ICell cell5 = table.Rows[0].Cells[4];
ITextBody textFrame6 = cell5.TextBody;
IParagraph paragraph6 = textFrame6.Paragraphs.Add();
paragraph6.HorizontalAlignment = HorizontalAlignmentType.Center;
            ITextPart textPart6 = paragraph6.AddTextPart();
textPart6.Text = "City";

            ICell cell6 = table.Rows[0].Cells[5];
ITextBody textFrame7 = cell6.TextBody;
IParagraph paragraph7 = textFrame7.Paragraphs.Add();
paragraph7.HorizontalAlignment = HorizontalAlignmentType.Center;
            ITextPart textPart7 = paragraph7.AddTextPart();
textPart7.Text = "Country";

			//Add data in table
			AddTableData(cell1, table, textFrame1, paragraph1);
slide4.Shapes.RemoveAt(1);
            #endregion

            MemoryStream stream = new MemoryStream();
            presentation.Save(stream);
            presentation.Close();
            stream.Position = 0;

			if (stream != null)
			{
				SaveiOS iOSSave = new SaveiOS ();
				iOSSave.Save ("SlidesPresentation.pptx", "application/mspowerpoint", stream);
			}

		}

void AddTableData(ICell cell1, ITable table, ITextBody textFrame1, IParagraph paragraph1)
{
	Dictionary<string, Dictionary<string, string>> products = LoadXMLData();
	int count = 0;
	for (int i = 1; i <= 5; i++)
	{
		for (int j = 0; j <= 5; j++)
		{
			cell1 = table.Rows[i].Cells[j];
			textFrame1 = cell1.TextBody;
			paragraph1 = textFrame1.Paragraphs.Add();
			paragraph1.HorizontalAlignment = HorizontalAlignmentType.Center;
ITextPart textpart1 = paragraph1.AddTextPart();
			textpart1.Text = products.Values.ToList()[0].Values.ToList()[count];
			count++;
		}
			} 
		}
void AddParagraphData(IParagraph paragraph, string text, string fontname, int fontsize,bool isBolt)
{
ITextPart textpart = paragraph.AddTextPart();
	paragraph.HorizontalAlignment = HorizontalAlignmentType.Left;
	textpart.Text = text;
	textpart.Font.FontName = fontname;
	textpart.Font.FontSize = fontsize;
			textpart.Font.Color = ColorObject.Black;
			textpart.Font.Bold = isBolt;
		}
private Dictionary<string, Dictionary<string, string>> LoadXMLData()
{
	Dictionary<string, Dictionary<string, string>> Products = new Dictionary<string, Dictionary<string, string>>();
	Assembly assembly = Assembly.GetExecutingAssembly();
	Stream productXMLStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.Presentation.Templates.SlideTableData.xml");
	XmlReader reader = XmlReader.Create(productXMLStream);
	string serailNo = string.Empty;
	string productName = string.Empty;
	string sum = string.Empty;
	string cell;

	while (reader.Read())
	{
		if (reader.IsStartElement())
		{
			switch (reader.Name)
			{
				case "Products":
					Dictionary<string, string> Cell_Value = new Dictionary<string, string>();
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
												case "Cell":
													while (reader.Read())
													{
														cell = reader.Name;
														if (reader.IsStartElement())
														{
															cell = reader.Name;
															while (reader.Read())
															{
																if (reader.IsStartElement())
																{
																	if (reader.Name == "Value")
																	{
																		reader.Read();
																		reader.MoveToContent();
																		Cell_Value.Add(cell, reader.Value);
																	}
																}
																else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == cell)
																{
																	break;
																}
															}
														}
														else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "Cell")
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
							Products.Add(productName, Cell_Value);
							Cell_Value = new Dictionary<string, string>();
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



		public override void LayoutSubviews ()
		{
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				frameMargin = 0.0f;
			}
			frameRect = Bounds;
			frameRect.Location = new CGPoint (frameRect.Location.X + frameMargin, frameRect.Location.Y + 1.5f * frameMargin);
			frameRect.Size = new CGSize(frameRect.Size.Width - (frameRect.Location.X + frameMargin), frameRect.Size.Height - (frameRect.Location.Y + 1.5f * frameMargin));

			LoadAllowedTextsLabel ();

			base.LayoutSubviews ();
		}
	}
}
