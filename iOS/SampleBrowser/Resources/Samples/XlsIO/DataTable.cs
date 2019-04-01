#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.XlsIO;
using Syncfusion.SfDataGrid;
using System.IO;
using COLOR = Syncfusion.Drawing;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.ComponentModel;
using System.Data;
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
    public partial class DataTable : SampleView
    {
        CGRect frameRect = new CGRect();
        float frameMargin = 8.0f;
        UILabel label;
        UILabel label1;
        UIButton button;
        UIButton btnInput;
        UIButton btnImport;
        SfDataGrid sfGrid;

        public DataTable()
        {
            label = new UILabel();
            label1 = new UILabel();
            button = new UIButton(UIButtonType.System);
            button.TouchUpInside += OnExportButtonClicked;
            btnInput = new UIButton(UIButtonType.System);
            btnInput.TouchUpInside += OnButtonInputClicked;
            btnImport = new UIButton(UIButtonType.System);
            btnImport.TouchUpInside += OnButtonImportClicked;

            sfGrid = new SfDataGrid();
            sfGrid.AutoGenerateColumns = false;
            sfGrid.RowHeight = 50;
            sfGrid.AllowEditing = true;
            sfGrid.EditTapAction = TapAction.OnTap;
            sfGrid.ColumnSizer = ColumnSizer.Star;
            sfGrid.SelectionMode = SelectionMode.None;
            sfGrid.HeaderRowHeight = 40;
            sfGrid.ItemsSource = GetEmptyData();

            GridTextColumn salesPerson = new GridTextColumn();
            salesPerson.MappingName = "SalesPerson";
            salesPerson.HeaderText = "Name";
            salesPerson.HeaderTextAlignment = UIKit.UITextAlignment.Center;

            GridTextColumn salesJanJune = new GridTextColumn();
            salesJanJune.MappingName = "SalesJanJune";
            salesJanJune.HeaderText = "Jan-June";
            salesPerson.HeaderTextAlignment = UIKit.UITextAlignment.Center;

            GridTextColumn salesJulyDec = new GridTextColumn();
            salesJulyDec.MappingName = "SalesJulyDec";
            salesJulyDec.HeaderText = "July-Dec";
            salesPerson.HeaderTextAlignment = UIKit.UITextAlignment.Center;

            GridTextColumn change = new GridTextColumn();
            change.MappingName = "Change";
            change.HeaderText = "Change";
            salesPerson.HeaderTextAlignment = UIKit.UITextAlignment.Center;

            sfGrid.Columns.Add(salesPerson);
            sfGrid.Columns.Add(salesJanJune);
            sfGrid.Columns.Add(salesJulyDec);
            sfGrid.Columns.Add(change);
            this.AddSubview(sfGrid);
        }

        private object GetEmptyData()
        {
            List<CustomerObject> customerObjects = new List<CustomerObject>();
            for (int i = 0; i < 20; i++)
                customerObjects.Add(new CustomerObject());
            return customerObjects;
        }

        void LoadAllowedTextsLabel()
        {

            label.Frame = frameRect;
            label.TextColor = UIColor.FromRGB(38 / 255.0f, 38 / 255.0f, 38 / 255.0f);
            label.Text = "This sample allows you to import/export data from/to DataTable.";
            label.Font = UIFont.SystemFontOfSize(15);
            label.Lines = 0;
            label.LineBreakMode = UILineBreakMode.WordWrap;
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                label.Font = UIFont.SystemFontOfSize(18);
                label.Frame = new CGRect(5, 5, frameRect.Location.X + frameRect.Size.Width, 50);
            }
            else
            {
                label.Frame = new CGRect(5, 5, frameRect.Location.X + frameRect.Size.Width, 50);
            }
            this.AddSubview(label);


            btnInput.SetTitle("Input Template", UIControlState.Normal);
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                btnInput.Frame = new CGRect(0, 65, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            else
            {
                btnInput.Frame = new CGRect(5, 65, frameRect.Size.Width, 10);

            }
            this.AddSubview(btnInput);

            btnImport.SetTitle("Import From Excel", UIControlState.Normal);
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                btnImport.Frame = new CGRect(0, 95, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            else
            {
                btnImport.Frame = new CGRect(5, 95, frameRect.Size.Width, 10);

            }
            this.AddSubview(btnImport);

            button.SetTitle("Export To Excel", UIControlState.Normal);
            button.Enabled = false;
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                button.Frame = new CGRect(0, 125, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            else
            {
                button.Frame = new CGRect(5, 125, frameRect.Size.Width, 10);

            }
            this.AddSubview(button);

            this.sfGrid.Frame = new CGRect(0, 145, this.Frame.Width, this.Frame.Height - 145);
            base.LayoutSubviews();

        }

        void OnButtonInputClicked(object sender, EventArgs e)
        {
            string resourcePath = "SampleBrowser.Samples.XlsIO.Template.ExportSales.xlsx";
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            MemoryStream stream = new MemoryStream();
            fileStream.CopyTo(stream);

            if (stream != null)
            {
                SaveiOS iOSSave = new SaveiOS();
                iOSSave.Save("InputTemplate.xlsx", "application/msexcel", stream);
            }
        }

        void OnButtonImportClicked(object sender, EventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;

            application.DefaultVersion = ExcelVersion.Excel2013;

            #region Initializing Workbook
            string resourcePath = "SampleBrowser.Samples.XlsIO.Template.ExportSales.xlsx";
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            IWorkbook workbook = application.Workbooks.Open(fileStream);

            IWorksheet sheet = workbook.Worksheets[0];
            #endregion

			//Export DataTable from Excel worksheet
            System.Data.DataTable dataTable = sheet.ExportDataTable(sheet.UsedRange, ExcelExportDataTableOptions.ColumnNames);
            
			//Set exported DataTable as datasource to DataGrid
			sfGrid.ItemsSource = dataTable;
            button.Enabled = true;
        }

        void OnExportButtonClicked(object sender, EventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2013;

            //A new workbook is created.[Equivalent to creating a new workbook in MS Excel]
            //The new workbook will have 1 worksheets
            IWorkbook workbook = application.Workbooks.Create(1);
            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];
			
			//Get DataGrid's datasource as DataTable
            System.Data.DataTable dataTable = (System.Data.DataTable)sfGrid.ItemsSource;

			//Import DataTable to Excel worksheet.
            sheet.ImportDataTable(dataTable, 5, 1, false);

            #region Define Styles
            IStyle pageHeader = workbook.Styles.Add("PageHeaderStyle");
            IStyle tableHeader = workbook.Styles.Add("TableHeaderStyle");

            pageHeader.Font.RGBColor = COLOR.Color.FromArgb(255, 83, 141, 213);
            pageHeader.Font.FontName = "Calibri";
            pageHeader.Font.Size = 18;
            pageHeader.Font.Bold = true;
            pageHeader.HorizontalAlignment = ExcelHAlign.HAlignCenter;
            pageHeader.VerticalAlignment = ExcelVAlign.VAlignCenter;

            tableHeader.Font.Color = ExcelKnownColors.Black;
            tableHeader.Font.Bold = true;
            tableHeader.Font.Size = 11;
            tableHeader.Font.FontName = "Calibri";
            tableHeader.HorizontalAlignment = ExcelHAlign.HAlignCenter;
            tableHeader.VerticalAlignment = ExcelVAlign.VAlignCenter;
            tableHeader.Color = COLOR.Color.FromArgb(255, 118, 147, 60);
            tableHeader.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
            tableHeader.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
            tableHeader.Borders[ExcelBordersIndex.EdgeTop].LineStyle = ExcelLineStyle.Thin;
            tableHeader.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
            #endregion

            #region Apply Styles
            // Apply style for header
            sheet["A1:D1"].Merge();
            sheet["A1"].Text = "Yearly Sales Report";
            sheet["A1"].CellStyle = pageHeader;
            sheet["A1"].RowHeight = 20;

            sheet["A2:D2"].Merge();
            sheet["A2"].Text = "Namewise Sales Comparison Report";
            sheet["A2"].CellStyle = pageHeader;
            sheet["A2"].CellStyle.Font.Bold = false;
            sheet["A2"].CellStyle.Font.Size = 16;
            sheet["A2"].RowHeight = 20;

            sheet["A3:A4"].Merge();
            sheet["D3:D4"].Merge();
            sheet["B3:C3"].Merge();
            sheet["B3"].Text = "Sales";
            sheet["A3:D4"].CellStyle = tableHeader;

            sheet["A3"].Text = "Sales Person";
            sheet["B4"].Text = "Jan - Jun";
            sheet["C4"].Text = "Jul - Dec";
            sheet["D3"].Text = "Change (%)";

            sheet.Columns[0].ColumnWidth = 19;
            sheet.Columns[1].ColumnWidth = 10;
            sheet.Columns[2].ColumnWidth = 10;
            sheet.Columns[3].ColumnWidth = 11;
            #endregion

            workbook.Version = ExcelVersion.Excel2013;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            workbook.Close();
            excelEngine.Dispose();

            if (stream != null)
            {
                SaveiOS iOSSave = new SaveiOS();
                iOSSave.Save("DataTable.xlsx", "application/msexcel", stream);
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