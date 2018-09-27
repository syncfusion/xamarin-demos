#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinIOInvoice.Views
{

    # region ItemView

    public partial class ItemView
    {

        #region Fields / Properties

        IList<InvoiceItem> ListSource;
        public BillInfo billInfo;
        #endregion

        #region Constructor

        public ItemView()
        {
            InitializeComponent();

            InitializeBillInfo();

            this.listView.IsVisible = Device.OnPlatform(iOS: false, Android: false, WinPhone: false);
            this.ListStack.IsVisible = Device.OnPlatform(iOS: true, Android: true, WinPhone: true);

            this.AddButtonLayout.VerticalOptions = LayoutOptions.StartAndExpand;
            this.DummyLayout.HorizontalOptions = LayoutOptions.StartAndExpand;
            this.AddTitleLabel.HorizontalOptions = LayoutOptions.CenterAndExpand;
            this.DoneButtonLayout.HorizontalOptions = LayoutOptions.EndAndExpand;
            this.ItemsLayout.Padding = Device.OnPlatform(iOS: new Thickness(0, 25, 0, 0), Android: new Thickness(0, 0, 0, 0), WinPhone: new Thickness(0, 0, 0, 0));

            this.PickerLayout.Padding = Device.OnPlatform(iOS: new Thickness(10, 10, 10, 10), Android: new Thickness(10, 10, 10, 10), WinPhone: new Thickness(0, 0, 0, 0));
            this.AmountFrame.OutlineColor = Xamarin.Forms.Color.White;
            this.AmountEntry.Font = Xamarin.Forms.Font.SystemFontOfSize(25);
            this.AmountFrame.Padding = (new Thickness(10, 10, 10, 10));
            this.ItemPickerLayout.Padding = this.QuantityPickerLayout.Padding = Device.OnPlatform(iOS: new Thickness(0, 0, 0, 0), Android: new Thickness(0, 0, 0, 0), WinPhone: new Thickness(-15, -15, 0, 0));
            if(App.isUWP)
            {
                this.ItemPickerLayout.Padding = this.QuantityPickerLayout.Padding= new Thickness(0, 0, 0, 0);
                this.PDFButton.HorizontalOptions = LayoutOptions.CenterAndExpand;
                this.PDFButton.WidthRequest = this.WordButton.WidthRequest = this.ExcelButton.WidthRequest = 225;
                this.WordButton.HorizontalOptions = LayoutOptions.CenterAndExpand;
                this.ExcelButton.HorizontalOptions = LayoutOptions.CenterAndExpand;
                if (Device.Idiom == TargetIdiom.Phone)
                    this.WinRTLabel.Font = this.WinRTLabelRate.Font = this.WindowsPhoneLabel.Font =
                        this.WindowsPhoneLabelRate.Font = Xamarin.Forms.Font.SystemFontOfSize(20);
            }
            this.AddButton.Clicked += AddButton_Clicked;
            this.DoneButton.Clicked += DoneButton_Clicked;
            this.ExportButton.Clicked += ExportButton_Clicked;
            this.HomeButton.Clicked += HomeButton_Clicked;
            this.ExcelButton.Clicked += ExcelButton_Clicked;
            this.WordButton.Clicked += WordButton_Clicked;
            this.PDFButton.Clicked += PDFButton_Clicked;
            this.ItemPicker.SelectedIndexChanged += ItemPicker_SelectedIndexChanged;
            this.QuantityPicker.SelectedIndexChanged += QuantityPicker_SelectedIndexChanged;

            this.AddLayout.IsVisible = false;
            this.ExportLayout.IsVisible = false;
            ListSource = GetDataSource();
            this.listView.ItemsSource = ListSource;
            LoadItemsInPicker();
            getListItem(Product.WinRT, "1", Product.CalcuateTotal(Product.WinRTRate, "1", Product.WinRTax).ToString());
            getListItem(Product.WindowsPhone, "1", Product.CalcuateTotal(Product.WindowsPhoneRate, "1", Product.WindowsPhoneTax).ToString());
        }

        private void InitializeBillInfo()
        {
            billInfo = new BillInfo();
            billInfo.Name = "Hanna Moos";
            billInfo.Date = DateTime.Today.Month + "/" + DateTime.Today.Day + "/" + DateTime.Today.Year;
            billInfo.Address = "German";
            billInfo.InvoiceNumber = "947823";
        }
        #endregion

        # region Events / Methods

        void HomeButton_Clicked(object sender, EventArgs e)
        {
            this.AddLayout.IsVisible = false;
            this.ExportLayout.IsVisible = false;
            this.MainLayout.IsVisible = true;
            this.Title = "Items";
        }
        public static bool isIOS;
        private StackLayout getListItem(string productItem, string productQuantity, string productAmount)
        {

            StackLayout layout = new StackLayout();
            layout.Orientation = StackOrientation.Horizontal;
            layout.HorizontalOptions = LayoutOptions.FillAndExpand;
            Label nameLabel = new Label();
            nameLabel.Text = productItem;
            nameLabel.HorizontalOptions = LayoutOptions.StartAndExpand;
            if (Device.OS == TargetPlatform.Android || Device.OS == TargetPlatform.WinPhone)
            {
                nameLabel.Font = Device.OnPlatform(iOS: Xamarin.Forms.Font.OfSize("Bold", 15), Android: Xamarin.Forms.Font.OfSize("Bold", 15), WinPhone: Xamarin.Forms.Font.OfSize("Bold", 35));
            }
            Label amountLabel = new Label();
            amountLabel.Text = productAmount;
            amountLabel.HorizontalOptions = LayoutOptions.EndAndExpand;
            if (Device.OS == TargetPlatform.Android || Device.OS == TargetPlatform.WinPhone)
                amountLabel.Font = Device.OnPlatform(iOS: Xamarin.Forms.Font.OfSize("Bold", 15), Android: Xamarin.Forms.Font.OfSize("Bold", 15), WinPhone: Xamarin.Forms.Font.OfSize("Bold", 35)); ;
            Label quantityLabel = new Label();
            quantityLabel.Text = "Quantity : " + productQuantity;
            if (Device.OS == TargetPlatform.Android || Device.OS == TargetPlatform.WinPhone)
                quantityLabel.Font = Device.OnPlatform(iOS: Xamarin.Forms.Font.OfSize("Bold", 10), Android: Xamarin.Forms.Font.OfSize("Bold", 10), WinPhone: Xamarin.Forms.Font.OfSize("Bold", 20)); ;

            layout.Children.Add(nameLabel);
            layout.Children.Add(amountLabel);

            StackLayout MainLayout = new StackLayout();
            MainLayout.Orientation = StackOrientation.Vertical;
            MainLayout.HorizontalOptions = LayoutOptions.FillAndExpand;
            MainLayout.Padding = new Thickness(10, 0, 10, 10);
            MainLayout.Children.Add(layout);

            MainLayout.Children.Add(quantityLabel);


            return MainLayout;
        }

        void PDFButton_Clicked(object sender, EventArgs e)
        {
            PdfDocument document = new PdfDocument();
            document.PageSettings.Orientation = PdfPageOrientation.Portrait;
            document.PageSettings.Margins.All = 50;
            PdfPage page = document.Pages.Add();
            PdfGraphics g = page.Graphics;
            PdfTextElement element = new PdfTextElement(@"Syncfusion Software 
2501 Aerial Center Parkway 
Suite 200 Morrisville, NC 27560 USA 
Tel +1 888.936.8638 Fax +1 919.573.0306");
            element.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 14);
            element.Brush = new PdfSolidBrush(new PdfColor(0, 0, 0));
            PdfLayoutResult result = element.Draw(page, new RectangleF(0, 0, page.Graphics.ClientSize.Width / 2, 200));
            Stream imgStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("Invoice_2017.SyncfusionLogo.jpg");
            PdfImage img = PdfImage.FromStream(imgStream);
            page.Graphics.DrawImage(img, new RectangleF(g.ClientSize.Width - 200, result.Bounds.Y, 190, 45));
            PdfFont subHeadingFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 15);
            g.DrawRectangle(new PdfSolidBrush(new PdfColor(34, 83, 142)), new RectangleF(0, result.Bounds.Bottom + 40, g.ClientSize.Width, 30));
            element = new PdfTextElement("INVOICE: " + billInfo.InvoiceNumber.ToString(), subHeadingFont);
            element.Brush = PdfBrushes.White;
            result = element.Draw(page, new PointF(10, result.Bounds.Bottom + 48));
            string currentDate = "DATE: " + billInfo.Date.ToString();
            SizeF textSize = subHeadingFont.MeasureString(currentDate);
            g.DrawString(currentDate, subHeadingFont, element.Brush, new PointF(g.ClientSize.Width - textSize.Width - 10, result.Bounds.Y));

            element = new PdfTextElement("BILL TO ", new PdfStandardFont(PdfFontFamily.TimesRoman, 14));
            element.Brush = new PdfSolidBrush(new PdfColor(34, 83, 142));
            result = element.Draw(page, new PointF(10, result.Bounds.Bottom + 25));

            g.DrawLine(new PdfPen(new PdfColor(34, 83, 142), 0.70f), new PointF(0, result.Bounds.Bottom + 3), new PointF(g.ClientSize.Width, result.Bounds.Bottom + 3));

            element = new PdfTextElement(billInfo.Name, new PdfStandardFont(PdfFontFamily.TimesRoman, 14));
            element.Brush = new PdfSolidBrush(new PdfColor(0, 0, 0));
            result = element.Draw(page, new RectangleF(10, result.Bounds.Bottom + 5, g.ClientSize.Width / 2, 100));

            element = new PdfTextElement(billInfo.Address, new PdfStandardFont(PdfFontFamily.TimesRoman, 14));
            element.Brush = new PdfSolidBrush(new PdfColor(0, 0, 0));
            result = element.Draw(page, new RectangleF(10, result.Bounds.Bottom + 3, g.ClientSize.Width / 2, 100));

            PdfGrid grid = new PdfGrid();
            grid.DataSource = this.ListSource;
            PdfGridCellStyle cellStyle = new PdfGridCellStyle();
            cellStyle.Borders.All = PdfPens.White;
            PdfGridRow header = grid.Headers[0];

            PdfGridCellStyle headerStyle = new PdfGridCellStyle();
            headerStyle.Borders.All = new PdfPen(new PdfColor(34, 83, 142));
            headerStyle.BackgroundBrush = new PdfSolidBrush(new PdfColor(34, 83, 142));
            headerStyle.TextBrush = PdfBrushes.White;
            headerStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 15f, PdfFontStyle.Regular);

            for (int i = 0; i < header.Cells.Count; i++)
            {
                if (i == 0)
                    header.Cells[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
                else
                    header.Cells[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);
            }
            header.Cells[0].Value = "ITEM";
            header.Cells[1].Value = "QUANTITY";
            header.Cells[2].Value = "RATE";
            header.Cells[3].Value = "TAXES (%)";
            header.Cells[4].Value = "AMOUNT";
            header.ApplyStyle(headerStyle);
            cellStyle.Borders.Bottom = new PdfPen(new PdfColor(217, 217, 217), 0.70f);
            cellStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 14f);
            cellStyle.TextBrush = new PdfSolidBrush(new PdfColor(0, 0, 0));
            foreach (PdfGridRow row in grid.Rows)
            {
                row.ApplyStyle(cellStyle);
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    PdfGridCell cell = row.Cells[i];
                    if (i == 0)
                        cell.StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
                    else
                        cell.StringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);

                    if (i > 1 && i != 3)
                    {
                        //float val = float.MinValue;
                        //float.TryParse(cell.Value.ToString(), out val);
                        if (cell.Value.ToString().Contains("$"))
                        {
                            cell.Value = cell.Value.ToString();
                        }
                        else
                        {
                            cell.Value = "$" + cell.Value.ToString();
                        }
                    }
                }
            }

            PdfGridLayoutFormat layoutFormat = new PdfGridLayoutFormat();
            layoutFormat.Layout = PdfLayoutType.Paginate;

            PdfGridLayoutResult gridResult = grid.Draw(page, new RectangleF(new PointF(0, result.Bounds.Bottom + 40), new SizeF(g.ClientSize.Width, g.ClientSize.Height - 100)), layoutFormat);
            float pos = 0.0f;
            for (int i = 0; i < grid.Columns.Count - 1; i++)
                pos += grid.Columns[i].Width;

            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 14f,PdfFontStyle.Bold);

            gridResult.Page.Graphics.DrawString("TOTAL DUE", font, new PdfSolidBrush(new PdfColor(34, 83, 142)), new RectangleF(new PointF(pos, gridResult.Bounds.Bottom + 10), new SizeF(grid.Columns[3].Width - pos, 20)), new PdfStringFormat(PdfTextAlignment.Right));
            gridResult.Page.Graphics.DrawString("Thank you for your business!", new PdfStandardFont(PdfFontFamily.TimesRoman, 14), new PdfSolidBrush(new PdfColor(0, 0, 0)), new PointF(pos -210, gridResult.Bounds.Bottom + 60));
            pos += grid.Columns[4].Width;
            gridResult.Page.Graphics.DrawString("$" + GetNetAmount().ToString(), font, new PdfSolidBrush(new PdfColor(0, 0, 0)), new RectangleF(new Syncfusion.Drawing.PointF(pos, gridResult.Bounds.Bottom + 10), new Syncfusion.Drawing.SizeF(grid.Columns[4].Width - pos, 20)), new PdfStringFormat(PdfTextAlignment.Right));

            MemoryStream data = new MemoryStream();

            document.Save(data);

            document.Close();

            DependencyService.Get<ISave>().SaveTextAsync("Invoice.pdf", "application/pdf", data);

        }

        void WordButton_Clicked(object sender, EventArgs e)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            Stream inputStream = null;
            //Load Template document stream
            if (isIOS)
                inputStream = assembly.GetManifestResourceStream("Invoice_2017.Template_iOS.docx");
            else
                inputStream = assembly.GetManifestResourceStream("Invoice_2017.Template.docx");

            //Create instance
            WordDocument document = new WordDocument();
            //Open Template document
            document.Open(inputStream, FormatType.Doc);
            //Dispose input stream
            inputStream.Dispose();

            //Set Clear Fields to false
            document.MailMerge.ClearFields = false;
            //Create Mail Merge Data Table
            MailMergeDataTable mailMergeDataTable = new MailMergeDataTable("Invoice", this.ListSource);
            //Executes mail merge using the data generated in the app.
            document.MailMerge.ExecuteGroup(mailMergeDataTable);

            //Mail Merge Billing information
            string[] fieldNames = { "Name", "Address", "Date", "InvoiceNumber", "DueDate", "TotalDue" };
            string[] fieldValues = { billInfo.Name, billInfo.Address, billInfo.Date, billInfo.InvoiceNumber, DateTime.Now.ToString("d"), GetNetAmount().ToString() };
            document.MailMerge.Execute(fieldNames, fieldValues);

            MemoryStream data = new MemoryStream();

            document.Save(data, FormatType.Docx);

            document.Close();
            DependencyService.Get<ISave>().SaveTextAsync("Invoice.docx", "application/msword", data);
        }

        void ExcelButton_Clicked(object sender, EventArgs e)
        {
            Assembly executingAssembly = typeof(App).GetTypeInfo().Assembly;
            Stream inputStream = null;
            //Seperate template added for ios viewers
            if (isIOS)
                inputStream = executingAssembly.GetManifestResourceStream("Invoice_2017.InvoiceTemplate_iOS.xlsx");
            else
                inputStream = executingAssembly.GetManifestResourceStream("Invoice_2017.InvoiceTemplate.xlsx");

            IWorkbook book = null;

            ExcelEngine excelEngine = new ExcelEngine();
            book = excelEngine.Excel.Workbooks.Open(inputStream);
            inputStream.Dispose();
            IWorksheet sheet = book.Worksheets[0];
            sheet.EnableSheetCalculations();

            //Create Template Marker Processor
            ITemplateMarkersProcessor marker = book.CreateTemplateMarkersProcessor();
            //Binding the business object with the marker.
            marker.AddVariable("InvoiceItem", this.ListSource);
            marker.AddVariable("BillInfo", this.billInfo);

            //Applies the marker.
            marker.ApplyMarkers(UnknownVariableAction.Skip);

            sheet[(16 + this.ListSource.Count + 1), 6].Text = "$ " + GetNetAmount();


            MemoryStream data = new MemoryStream();

            book.SaveAs(data);

            book.Close();
            DependencyService.Get<ISave>().SaveTextAsync("Invoice.xlsx", "application/msexcel", data);
        }

        void ExportButton_Clicked(object sender, EventArgs e)
        {
            this.MainLayout.IsVisible = false;
            this.ExportLayout.IsVisible = true;
        }

        void QuantityPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            AmountEntry.Text = CalculateValue();
        }

        void ItemPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.QuantityPicker.SelectedIndex = 0;
            AmountEntry.Text = CalculateValue();
        }

        void DoneButton_Clicked(object sender, EventArgs e)
        {
            if (this.ItemPicker.SelectedIndex >= 0 && this.QuantityPicker.SelectedIndex >= 0)
            {
                this.Title = "Items";
                InvoiceItem invoiceItem = new InvoiceItem();
                invoiceItem.ItemName = this.ItemPicker.Items[this.ItemPicker.SelectedIndex];
                invoiceItem.Quantity = this.QuantityPicker.Items[this.QuantityPicker.SelectedIndex]; ;
                invoiceItem.Rate = getRate(this.ItemPicker.SelectedIndex.ToString());
                invoiceItem.Taxes = "7";
                invoiceItem.TotalAmount = this.AmountEntry.Text;
                this.ListSource.Add(invoiceItem);

                if (this.ListStack.IsVisible)
                {
                    this.ListStack.Children.Add(getListItem(invoiceItem.ItemName, invoiceItem.Quantity, invoiceItem.TotalAmount));
                }
            }
            this.AddLayout.IsVisible = false;
            this.MainLayout.IsVisible = true;
            this.ExportLayout.IsVisible = false;
            //  this.listView.IsVisible = true;

            this.listView.HeightRequest = this.Height;
        }

        void AddButton_Clicked(object sender, EventArgs e)
        {
            ItemPicker.SelectedIndex = 1;
            //this.listView.IsVisible = false;
            this.MainLayout.IsVisible = false;
            this.AddLayout.IsVisible = true;
            this.ExportLayout.IsVisible = false;
        }

        public string CalculateValue()
        {
            if (QuantityPicker.SelectedIndex != -1 && ItemPicker.SelectedIndex != -1)
            {
                if (ItemPicker.SelectedIndex == 0)
                {
                    return "$ " + Product.CalcuateTotal(Product.WinRTRate, QuantityPicker.Items[QuantityPicker.SelectedIndex].ToString(), Product.WinRTax);
                }
                else if (ItemPicker.SelectedIndex == 1)
                {
                    return "$ " + Product.CalcuateTotal(Product.WindowsPhoneRate, QuantityPicker.Items[QuantityPicker.SelectedIndex].ToString(), Product.WindowsPhoneTax);
                }
                else if (ItemPicker.SelectedIndex == 2)
                {
                    return "$ " + Product.CalcuateTotal(Product.HTMLRate, QuantityPicker.Items[QuantityPicker.SelectedIndex].ToString(), Product.HTMLTax);
                }
                else if (ItemPicker.SelectedIndex == 3)
                {
                    return "$ " + Product.CalcuateTotal(Product.OruBaseRate, QuantityPicker.Items[QuantityPicker.SelectedIndex].ToString(), Product.OruBaseTax);
                }
            }
            return string.Empty;
        }

        public void LoadItemsInPicker()
        {
            this.ItemPicker.Items.Add(Product.WinRT);
            this.ItemPicker.Items.Add(Product.WindowsPhone);
            this.ItemPicker.Items.Add(Product.HTML);
            this.ItemPicker.Items.Add(Product.OruBase);

            this.QuantityPicker.Items.Add("1");
            this.QuantityPicker.Items.Add("2");
            this.QuantityPicker.Items.Add("3");
            this.QuantityPicker.Items.Add("4");
            this.QuantityPicker.Items.Add("5");
        }

        private string getRate(string product)
        {
            switch (product)
            {
                case "0":
                    return "$ " + Product.WinRTRate;
                case "1":
                    return "$ " + Product.WindowsPhoneRate;
                case "2":
                    return "$ " + Product.HTMLRate;
                case "3":
                    return "$ " + Product.OruBaseRate;
            }
            return string.Empty;
        }

        public IList<InvoiceItem> GetDataSource()
        {
            List<InvoiceItem> items = new List<InvoiceItem>();

            InvoiceItem item = new InvoiceItem();
            item.ItemName = Product.WinRT;
            item.Quantity = "1";
            item.Rate = "$ " + Product.WinRTRate;
            item.Taxes = Product.WinRTax;
            item.TotalAmount = "$ " + Product.CalcuateTotal(item.Rate, item.Quantity, item.Taxes).ToString();
            items.Add(item);

            //getListItem (item.ItemName, item.Quantity, item.TotalAmount);

            item = new InvoiceItem();
            item.ItemName = Product.WindowsPhone;
            item.Quantity = "1";
            item.Rate = "$ " + Product.WindowsPhoneRate;
            item.Taxes = Product.WindowsPhoneTax;
            item.TotalAmount = "$ " + Product.CalcuateTotal(item.Rate, item.Quantity, item.Taxes).ToString();
            items.Add(item);

            return items;
        }

        private double GetNetAmount()
        {
            double netAmount = 0;
            for (int i = 0; i < ListSource.Count; i++)
                netAmount += Product.CalcuateTotal(ListSource[i].Rate, ListSource[i].Quantity, ListSource[i].Taxes);

            return netAmount;
        }

        # endregion
    }

    #endregion
}
