#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.Content;
using Android.Views;
using Android.Widget;
using System.IO;
using Syncfusion.Pdf.Graphics;
using System.Collections.Generic;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using System.Reflection;
using Syncfusion.Pdf.Grid;
using Syncfusion.ZugFerd;
using Syncfusion.Pdf.Interactive;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Data;

namespace SampleBrowser
{
    public partial class ZugFerd : SamplePage
    {
        private Context m_context;
        public override View GetSampleContent(Context con)
        {
            LinearLayout linear = new LinearLayout(con);
            linear.SetBackgroundColor(Android.Graphics.Color.White);
            linear.Orientation = Orientation.Vertical;
            linear.SetPadding(10, 10, 10, 10);
                       
            TextView space = new TextView(con);
            space.TextSize = 10;
            linear.AddView(space);

            TextView text2 = new TextView(con);
            text2.TextSize = 17;
            text2.TextAlignment = TextAlignment.Center;
            text2.Text = "This sample demonstrates how to create ZUGFeRD PDF invoice using Essential PDF.";
            text2.SetTextColor(Android.Graphics.Color.ParseColor("#262626"));
            text2.SetPadding(5, 5, 5, 5);

            linear.AddView(text2);

            TextView space1 = new TextView(con);
            space1.TextSize = 10;
            linear.AddView(space1); 
           
            m_context = con;

            TextView space2 = new TextView(con);
            space2.TextSize = 10;
            linear.AddView(space2);

            Button button1 = new Button(con);
            button1.Text = "Generate PDF";
            button1.Click += OnButtonClicked;
            linear.AddView(button1);

            return linear;
        }
		public RectangleF TotalPriceCellBounds = RectangleF.Empty;
        public RectangleF QuantityCellBounds = RectangleF.Empty;
        void OnButtonClicked(object sender, EventArgs e)
        {
            //Create ZugFerd invoice PDF
            PdfDocument document = new PdfDocument(PdfConformanceLevel.Pdf_A3B);

            document.ZugferdVersion = ZugferdVersion.ZugferdVersion2_0;
            document.ZugferdConformanceLevel = ZugferdConformanceLevel.Extended;

            CreateZugFerdInvoicePDF(document);

            //Create ZugFerd Xml attachment file
            Stream zugferdXmlStream = CreateZugFerdXML();

            //Creates an attachment.
            PdfAttachment attachment = new PdfAttachment("ZUGFeRD-invoice.xml", zugferdXmlStream);
            attachment.Relationship = PdfAttachmentRelationship.Alternative;
            attachment.ModificationDate = DateTime.Now;

            attachment.Description = "Adventure Invoice";

            attachment.MimeType = "application/xml";

            document.Attachments.Add(attachment);

            MemoryStream stream = new MemoryStream();
            //Save the PDF document.
            document.Save(stream);

            //Close the PDF document.
            document.Close();

            stream.Position = 0;

            if (stream != null)
            {
                SaveAndroid androidSave = new SaveAndroid();
                androidSave.Save("ZugFerd.pdf", "application/pdf", stream, m_context);
            }
        }
		public Stream CreateZugFerdXML()
        {
            //Create ZugFerd Invoice
            ZugFerdInvoice invoice = new ZugFerdInvoice("2058557939", new DateTime(2013, 6, 5), CurrencyCodes.USD);

            //Set ZugFerdProfile to ZugFerdInvoice
            invoice.Profile = ZugFerdProfile.Basic;

            //Add buyer details
            invoice.Buyer = new UserDetails
            {
                ID = "Abraham_12",
                Name = "Abraham Swearegin",
                ContactName = "Swearegin",
                City = "United States, California",
                Postcode = "9920",
                Country = CountryCodes.US,
                Street = "9920 BridgePointe Parkway"
            };

            //Add seller details
            invoice.Seller = new UserDetails
            {
                ID = "Adventure_123",
                Name = "AdventureWorks",
                ContactName = "Adventure support",
                City = "Austin,TX",
                Postcode = "",
                Country = CountryCodes.US,
                Street = "800 Interchange Blvd"
            };
            Stream xmlStream = typeof(ZugFerd).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Assets.InvoiceProductList.xml");
            float total = 0;
            using (XmlReader reader = XmlReader.Create(xmlStream))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        reader.Name.ToString();

                        Product product = new Product();


                        switch (reader.Name.ToString())
                        {
                            case "Productid":
                                product.ProductID = reader.ReadString();
                                break;
                            case "Product":
                                product.productName = reader.ReadString();
                                break;
                            case "Price":
                                product.Price = float.Parse(reader.ReadString(), System.Globalization.CultureInfo.InvariantCulture);
                                break;
                            case "Quantity":
                                product.Quantity = float.Parse(reader.ReadString(), System.Globalization.CultureInfo.InvariantCulture);
                                break;
                            case "Total":
                                product.Total = float.Parse(reader.ReadString(), System.Globalization.CultureInfo.InvariantCulture);
                                total += product.Total;
                                invoice.AddProduct(product.ProductID, product.productName, product.Price, product.Quantity, product.Total);
                                break;
                        }
                    }
                }
            }

            invoice.TotalAmount = total;

            MemoryStream ms = new MemoryStream();
          
            //Save ZugFerd Xml
            return invoice.Save(ms);
        }

        /// <summary>
        /// Create ZugFerd Invoice Pdf
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public PdfDocument CreateZugFerdInvoicePDF(PdfDocument document)
        {
            //Add page to the PDF
            PdfPage page = document.Pages.Add();

            PdfGraphics graphics = page.Graphics;

            //Create border color
            PdfColor borderColor = Syncfusion.Drawing.Color.FromArgb(255, 142, 170, 219);

            //Get the page width and height
            float pageWidth = page.GetClientSize().Width;
            float pageHeight = page.GetClientSize().Height;

            //Set the header height
            float headerHeight = 90;


            PdfColor lightBlue = Syncfusion.Drawing.Color.FromArgb(255, 91, 126, 215);
            PdfBrush lightBlueBrush = new PdfSolidBrush(lightBlue);

            PdfColor darkBlue = Syncfusion.Drawing.Color.FromArgb(255, 65, 104, 209);
            PdfBrush darkBlueBrush = new PdfSolidBrush(darkBlue);

            PdfBrush whiteBrush = new PdfSolidBrush(Syncfusion.Drawing.Color.FromArgb(255, 255, 255, 255));

            Stream fontStream = typeof(Conformance).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Assets.arial.ttf");


            PdfTrueTypeFont headerFont = new PdfTrueTypeFont(fontStream, 30, PdfFontStyle.Regular);

            PdfTrueTypeFont arialRegularFont = new PdfTrueTypeFont(fontStream, 18, PdfFontStyle.Regular);
            PdfTrueTypeFont arialBoldFont = new PdfTrueTypeFont(fontStream, 9, PdfFontStyle.Bold);

            //Create string format.
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Center;
            format.LineAlignment = PdfVerticalAlignment.Middle;

            float y = 0;
            float x = 0;

            //Set the margins of address.
            float margin = 30;

            //Set the line space
            float lineSpace = 7;

            PdfPen borderPen = new PdfPen(borderColor, 1f);

            //Draw page border
            graphics.DrawRectangle(borderPen, new RectangleF(0, 0, pageWidth, pageHeight));


            PdfGrid grid = new PdfGrid();

            grid.DataSource = GetZugferdDataset();

            #region Header         

            //Fill the header with light Brush 
            graphics.DrawRectangle(lightBlueBrush, new RectangleF(0, 0, pageWidth, headerHeight));

            string title = "INVOICE";

            SizeF textSize = headerFont.MeasureString(title);

            RectangleF headerTotalBounds = new RectangleF(400, 0, pageWidth - 400, headerHeight);

            graphics.DrawString(title, headerFont, whiteBrush, new RectangleF(0, 0, textSize.Width + 50, headerHeight), format);

            graphics.DrawRectangle(darkBlueBrush, headerTotalBounds);

            graphics.DrawString("$" + GetTotalAmount(grid).ToString(), arialRegularFont, whiteBrush, new RectangleF(400, 0, pageWidth - 400, headerHeight + 10), format);

            arialRegularFont = new PdfTrueTypeFont(fontStream, 9, PdfFontStyle.Regular);

            format.LineAlignment = PdfVerticalAlignment.Bottom;
            graphics.DrawString("Amount", arialRegularFont, whiteBrush, new RectangleF(400, 0, pageWidth - 400, headerHeight / 2 - arialRegularFont.Height), format);

            #endregion


            SizeF size = arialRegularFont.MeasureString("Invoice Number: 2058557939");
            y = headerHeight + margin;
            x = (pageWidth - margin) - size.Width;

            graphics.DrawString("Invoice Number: 2058557939", arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            size = arialRegularFont.MeasureString("Date :" + DateTime.Now.ToString("dddd dd, MMMM yyyy"));
            x = (pageWidth - margin) - size.Width;
            y += arialRegularFont.Height + lineSpace;

            graphics.DrawString("Date: " + DateTime.Now.ToString("dddd dd, MMMM yyyy"), arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            y = headerHeight + margin;
            x = margin;
            graphics.DrawString("Bill To:", arialRegularFont, PdfBrushes.Black, new PointF(x, y));
            y += arialRegularFont.Height + lineSpace;
            graphics.DrawString("Abraham Swearegin,", arialRegularFont, PdfBrushes.Black, new PointF(x, y));
            y += arialRegularFont.Height + lineSpace;
            graphics.DrawString("United States, California, San Mateo,", arialRegularFont, PdfBrushes.Black, new PointF(x, y));
            y += arialRegularFont.Height + lineSpace;
            graphics.DrawString("9920 BridgePointe Parkway,", arialRegularFont, PdfBrushes.Black, new PointF(x, y));
            y += arialRegularFont.Height + lineSpace;
            graphics.DrawString("9365550136", arialRegularFont, PdfBrushes.Black, new PointF(x, y));


            #region Grid

            grid.Columns[0].Width = 110;
            grid.Columns[1].Width = 150;
            grid.Columns[2].Width = 110;
            grid.Columns[3].Width = 70;
            grid.Columns[4].Width = 100;

            for (int i = 0; i < grid.Headers.Count; i++)
            {
                grid.Headers[i].Height = 20;
                for (int j = 0; j < grid.Columns.Count; j++)
                {
                    PdfStringFormat pdfStringFormat = new PdfStringFormat();
                    pdfStringFormat.LineAlignment = PdfVerticalAlignment.Middle;

                    pdfStringFormat.Alignment = PdfTextAlignment.Left;
                    if (j == 0 || j == 2)
                        grid.Headers[i].Cells[j].Style.CellPadding = new PdfPaddings(30, 1, 1, 1);

                    grid.Headers[i].Cells[j].StringFormat = pdfStringFormat;

                    grid.Headers[i].Cells[j].Style.Font = arialBoldFont;

                }
                grid.Headers[0].Cells[0].Value = "Product Id";
            }
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                grid.Rows[i].Height = 23;
                for (int j = 0; j < grid.Columns.Count; j++)
                {

                    PdfStringFormat pdfStringFormat = new PdfStringFormat();
                    pdfStringFormat.LineAlignment = PdfVerticalAlignment.Middle;

                    pdfStringFormat.Alignment = PdfTextAlignment.Left;
                    if (j == 0 || j == 2)
                        grid.Rows[i].Cells[j].Style.CellPadding = new PdfPaddings(30, 1, 1, 1);

                    grid.Rows[i].Cells[j].StringFormat = pdfStringFormat;
                    grid.Rows[i].Cells[j].Style.Font = arialRegularFont;
                }

            }
            grid.ApplyBuiltinStyle(PdfGridBuiltinStyle.ListTable4Accent5);
            grid.BeginCellLayout += Grid_BeginCellLayout;


            PdfGridLayoutResult result = grid.Draw(page, new PointF(0, y + 40));

            y = result.Bounds.Bottom + lineSpace;
            format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Center;
            RectangleF bounds = new RectangleF(QuantityCellBounds.X, y, QuantityCellBounds.Width, QuantityCellBounds.Height);

            page.Graphics.DrawString("Grand Total:", arialBoldFont, PdfBrushes.Black, bounds, format);

            bounds = new RectangleF(TotalPriceCellBounds.X, y, TotalPriceCellBounds.Width, TotalPriceCellBounds.Height);
            page.Graphics.DrawString(GetTotalAmount(grid).ToString(), arialBoldFont, PdfBrushes.Black, bounds);


            #endregion



            borderPen.DashStyle = PdfDashStyle.Custom;
            borderPen.DashPattern = new float[] { 3, 3 };

            graphics.DrawLine(borderPen, new PointF(0, pageHeight - 100), new PointF(pageWidth, pageHeight - 100));

            y = pageHeight - 100 + margin;

            size = arialRegularFont.MeasureString("800 Interchange Blvd.");

            x = pageWidth - size.Width - margin;

            graphics.DrawString("800 Interchange Blvd.", arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            y += arialRegularFont.Height + lineSpace;

            size = arialRegularFont.MeasureString("Suite 2501,  Austin, TX 78721");

            x = pageWidth - size.Width - margin;

            graphics.DrawString("Suite 2501,  Austin, TX 78721", arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            y += arialRegularFont.Height + lineSpace;

            size = arialRegularFont.MeasureString("Any Questions? support@adventure-works.com");

            x = pageWidth - size.Width - margin;
            graphics.DrawString("Any Questions? support@adventure-works.com", arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            return document;
        }
        private IEnumerable<Product> GetZugferdDataset()
        {

            Stream xmlStream = typeof(ZugFerd).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Assets.InvoiceProductList.xml");
            XmlReader reader = XmlReader.Create(xmlStream);
            List<Product> collection = new List<Product>();

            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    switch (reader.Name)
                    {
                        case "ProductDetails":
                            Product product = new Product();
                            while (reader.Read())
                            {
                                if (reader.IsStartElement())
                                {
                                    switch (reader.Name)
                                    {
                                        case "Productid":
                                            reader.Read();
                                            product.ProductID = reader.Value;
                                            break;
                                        case "Product":
                                            reader.Read();
                                            product.productName = reader.Value;
                                            break;
                                        case "Price":
                                            reader.Read();
                                            product.Price = float.Parse(reader.Value, System.Globalization.CultureInfo.InvariantCulture);
                                            break;
                                        case "Quantity":
                                            reader.Read();
                                            product.Quantity = int.Parse(reader.Value);
                                            break;
                                        case "Total":
                                            reader.Read();
                                            product.Total = float.Parse(reader.Value, System.Globalization.CultureInfo.InvariantCulture);
                                            break;
                                    }
                                }
                                else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "ProductDetails")
                                {
                                    collection.Add(product);
                                    break;
                                }

                            }
                            break;
                    }
                }
            }

            return collection.AsEnumerable();
        }
        private void Grid_BeginCellLayout(object sender, PdfGridBeginCellLayoutEventArgs args)
        {
            PdfGrid grid = sender as PdfGrid;
            if (args.CellIndex == grid.Columns.Count - 1)
            {
                TotalPriceCellBounds = args.Bounds;
            }
            else if (args.CellIndex == grid.Columns.Count - 2)
            {
                QuantityCellBounds = args.Bounds;
            }

        }

        /// <summary>
        /// Get the Total amount of purcharsed items
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        private float GetTotalAmount(PdfGrid grid)
        {
            float Total = 0f;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                string cellValue = grid.Rows[i].Cells[grid.Columns.Count - 1].Value.ToString();
                float result = float.Parse(cellValue, System.Globalization.CultureInfo.InvariantCulture);
                Total +=  result;
            }
            return Total;

        }
    }
}