#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Xamarin.Forms;
using System.IO;
using SampleBrowser.Core;
using System.Reflection;
using System.Collections.Generic;
using System.Xml.Linq;
using Syncfusion.Pdf.Grid;
using Syncfusion.ZugFerd;
using System.Linq;
using Syncfusion.Pdf.Interactive;

namespace SampleBrowser.PDF
{
    public partial class ZugFerd : SampleView
    {
        public ZugFerd()
        {
            InitializeComponent();
            if (Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Description.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.BackgroundColor = Xamarin.Forms.Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Description.FontSize = 13.5;
                this.Description.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
            }
        }
        RectangleF TotalPriceCellBounds = RectangleF.Empty;
        RectangleF QuantityCellBounds = RectangleF.Empty;
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

            if ( Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("ZugFerd.pdf", "application/pdf", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("ZugFerd.pdf", "application/pdf", stream);

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

            
            IEnumerable<Product> products = GetProductReport();

            float total = 0;
            foreach (var product in products)
            {
                invoice.AddProduct(product);
                total += product.Total;
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
#if COMMONSB
            Stream fontStream = typeof(ZugFerd).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Samples.Assets.arial.ttf");
#else
            Stream fontStream = typeof(ZugFerd).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.PDF.Samples.Assets.arial.ttf");
#endif

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

            grid.DataSource = GetProductReport();

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

        private IEnumerable<Product> GetProductReport()
        {
            #if COMMONSB
            Stream xmlStream = typeof(ZugFerd).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Samples.Assets.InvoiceProductList.xml");
#else
            Stream xmlStream = typeof(ZugFerd).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.PDF.Samples.Assets.InvoiceProductList.xml");
#endif

            using (StreamReader reader = new StreamReader(xmlStream, true))
            {
                return XElement.Parse(reader.ReadToEnd())
                    .Elements("ProductDetails")
                    .Select(c => new Product
                    {
                        ProductID = c.Element("Productid").Value,
                        productName = c.Element("Product").Value,
                        Price = float.Parse(c.Element("Price").Value, System.Globalization.CultureInfo.InvariantCulture),
                        Quantity = float.Parse(c.Element("Quantity").Value, System.Globalization.CultureInfo.InvariantCulture),
                        Total = float.Parse(c.Element("Total").Value, System.Globalization.CultureInfo.InvariantCulture)
                    });
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
                Total += result;
            }
            return Total;

        }
    }
}
