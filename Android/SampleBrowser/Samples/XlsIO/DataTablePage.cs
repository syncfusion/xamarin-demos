#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using COLOR = Syncfusion.Drawing;
using System.Xml;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using SampleBrowser;
using Android.App;
using Syncfusion.SfDataGrid;
using System.ComponentModel;
using System.Data;

namespace SampleBrowser
{
    public partial class DataTablePage : SamplePage
    {
        private Context m_context;
        SfDataGrid sfGrid;
        Button btnExport;
        public override View GetSampleContent(Context con)
        {
            LinearLayout linear = new LinearLayout(con);
            linear.SetBackgroundColor(Color.White);
            linear.Orientation = Orientation.Vertical;
            linear.SetPadding(10, 10, 10, 10);

            TextView text2 = new TextView(con);
            text2.TextSize = 17;
            text2.TextAlignment = TextAlignment.Center;
            text2.Text = "This sample illustrates how to import/export DataTable from/to an Excel worksheet.";
            text2.SetTextColor(Color.ParseColor("#262626"));
            text2.SetPadding(5, 5, 5, 5);

            linear.AddView(text2);

            m_context = con;

            Button btnInput = new Button(con);
            btnInput.Text = "Input Template";
            btnInput.Click += ButtonInputClicked;
            linear.AddView(btnInput);

            Button btnImport = new Button(con);
            btnImport.Text = "Import From Excel";
            btnImport.Click += ButtonImportClicked;
            linear.AddView(btnImport);

            btnExport = new Button(con);
            btnExport.Text = "Export To Excel";
            btnExport.Click += ButtonExportClicked;
            btnExport.Enabled = false;
            linear.AddView(btnExport);

            sfGrid = new SfDataGrid(con);
            sfGrid.AutoGenerateColumns = false;
            sfGrid.RowHeight = 50;
            sfGrid.AllowEditing = true;
            sfGrid.EditTapAction = TapAction.OnTap;
            sfGrid.ColumnSizer = ColumnSizer.Star;
            sfGrid.SelectionMode = SelectionMode.None;
            sfGrid.HeaderRowHeight = 40;
            sfGrid.ItemsSource = GetEmptyRows();
            sfGrid.VerticalOverScrollMode = VerticalOverScrollMode.None;

            GridTextColumn salesPerson = new GridTextColumn();
            salesPerson.MappingName = "SalesPerson";
            salesPerson.HeaderText = "Name";
            salesPerson.HeaderTextAlignment = GravityFlags.Center;

            GridTextColumn salesJanJune = new GridTextColumn();
            salesJanJune.MappingName = "SalesJanJune";
            salesJanJune.HeaderText = "Jan-June";
            salesJanJune.HeaderTextAlignment = GravityFlags.Center;

            GridTextColumn salesJulyDec = new GridTextColumn();
            salesJulyDec.MappingName = "SalesJulyDec";
            salesJulyDec.HeaderText = "July-Dec";
            salesJulyDec.HeaderTextAlignment = GravityFlags.Center;

            GridTextColumn change = new GridTextColumn();
            change.MappingName = "Change";
            change.HeaderText = "Change";
            change.HeaderTextAlignment = GravityFlags.Center;

            sfGrid.Columns.Add(salesPerson);
            sfGrid.Columns.Add(salesJanJune);
            sfGrid.Columns.Add(salesJulyDec);
            sfGrid.Columns.Add(change);
            linear.AddView(sfGrid);
            return linear;
        }

        private object GetEmptyRows()
        {
            List<CustomerObject> customerObjects = new List<CustomerObject>();
            for (int i = 0; i < 20; i++)
                customerObjects.Add(new CustomerObject());
            return customerObjects;
        }

        void ButtonInputClicked(object sender, EventArgs e)
        {
            string resourcePath = "SampleBrowser.Samples.XlsIO.Template.ExportSales.xlsx";
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            MemoryStream stream = new MemoryStream();
            fileStream.CopyTo(stream);

            if (stream != null)
            {
                SaveAndroid androidSave = new SaveAndroid();
                androidSave.Save("Input Template.xlsx", "application/msexcel", stream, m_context);
            }
        }

        void ButtonImportClicked(object sender, EventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;

            application.DefaultVersion = ExcelVersion.Excel2013;

            string resourcePath = "";
            resourcePath = "SampleBrowser.Samples.XlsIO.Template.ExportSales.xlsx";
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            IWorkbook workbook = application.Workbooks.Open(fileStream);
            IWorksheet sheet = workbook.Worksheets[0];

			//Export DataTable from worksheet
            System.Data.DataTable dataTable = sheet.ExportDataTable(sheet.UsedRange, ExcelExportDataTableOptions.ColumnNames);

			//Set exported DataTable as source to DataGrid.
            sfGrid.ItemsSource = dataTable;
            btnExport.Enabled = true;
        }

        void ButtonExportClicked(object sender, EventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2013;

            #region Initializing Workbook
            //A new workbook is created.[Equivalent to creating a new workbook in MS Excel]
            //The new workbook will have 1 worksheets
            IWorkbook workbook = application.Workbooks.Create(1);
            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];

            DataTable dataTable = (DataTable)sfGrid.ItemsSource;

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
            #endregion

            #region Saving workbook and disposing objects
            workbook.Version = ExcelVersion.Excel2013;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            workbook.Close();
            excelEngine.Dispose();


            if (stream != null)
            {
                SaveAndroid androidSave = new SaveAndroid();
                androidSave.Save("DataTable.xlsx", "application/msexcel", stream, m_context);
            }
            #endregion
        }
    }
}
