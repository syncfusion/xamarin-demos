#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using COLOR = Syncfusion.Drawing;
using Xamarin.Forms;
using SampleBrowser.Core;
using Syncfusion.SfDataGrid;
using Syncfusion.SfDataGrid.XForms;
using Syncfusion.XlsIO;



namespace SampleBrowser.XlsIO
{
    /// <summary>
    /// This class used to import/export DataTable from/to an Excel worksheet.
    /// </summary>
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public partial class DataTablePage : SampleView
    {
        public DataTablePage()
        {
            InitializeComponent();
            if (Device.Idiom != TargetIdiom.Phone && (Device.RuntimePlatform == Device.UWP))
            {
                this.Content_1.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.BackgroundColor = Color.Gray;
                this.btnInput.BackgroundColor = Color.Gray;
                this.btnImport.BackgroundColor = Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                {
                    this.Content_1.FontSize = 13.5;
                }

                this.Content_1.VerticalOptions = LayoutOptions.Center;
            }

            if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.iOS)
            {
                this.dataGrid.DefaultColumnWidth = 120;
            }
            else
            {
                this.dataGrid.DefaultColumnWidth = 160;
            }

            this.dataGrid.ItemsSource = SetGridData();
        }

        private object SetGridData()
        {
            List<CustomerObject> customerObjects = new List<CustomerObject>();
            for (int i = 0; i < 20; i++)
            {
                customerObjects.Add(new CustomerObject());
            }

            return customerObjects;
        }

        internal void OnInputClicked(object sender, EventArgs e)
        {
            Assembly assembly = typeof(App).GetTypeInfo().Assembly;
            Stream fileStream = null;

#if COMMONSB
			 fileStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Samples.Template.ExportSales.xlsx");
#else
            fileStream = assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.ExportSales.xlsx");
#endif
            MemoryStream stream = new MemoryStream();
            fileStream.CopyTo(stream);
            stream.Position = 0;

            if (Device.RuntimePlatform == Device.UWP)
            {
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("InputTemplate.xlsx", "application/msexcel", stream);
            }
            else
            {
                Xamarin.Forms.DependencyService.Get<ISave>().Save("InputTemplate.xlsx", "application/msexcel", stream);
            }
        }

        internal void OnImportClicked(object sender, EventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2013;

            //Initializing Workbook
            Assembly assembly = typeof(App).GetTypeInfo().Assembly;
            Stream fileStream = null;

#if COMMONSB
			 fileStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Samples.Template.ExportSales.xlsx");
#else
            fileStream = assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.ExportSales.xlsx");
#endif
            IWorkbook workbook = application.Workbooks.Open(fileStream);
            workbook.Version = ExcelVersion.Excel2013;
            IWorksheet sheet = workbook.Worksheets[0];

            //Export SheetData as DataTable
            DataTable dataTable = sheet.ExportDataTable(sheet.UsedRange, ExcelExportDataTableOptions.ColumnNames);

            //Convert DataTable to ObservableCollection
            ObservableCollection<CustomerObject> data = new ObservableCollection<CustomerObject>();
            UpdateGridData(data, dataTable);

            //Set DataSource to Grid
            dataGrid.ItemsSource = data;

            this.btnGenerate.IsEnabled = true;
            workbook.Close();
            excelEngine.Dispose();
        }

        private void UpdateGridData(ObservableCollection<CustomerObject> data, DataTable dataTable)
        {
            foreach (System.Data.DataRow row in dataTable.Rows)
            {
                data.Add(new CustomerObject()
                {
                  SalesPerson = row[0].ToString(),
                  SalesJanJune = int.Parse(row[1].ToString()),
                  SalesJulyDec = int.Parse(row[2].ToString()),
                  Change = int.Parse(row[3].ToString())
                });
            }
        }

        internal void OnExportClicked(object sender, EventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2013;

            //Initializing Workbook
            //A new workbook is created.[Equivalent to creating a new workbook in MS Excel]
            //The new workbook will have 1 worksheets
            IWorkbook workbook = application.Workbooks.Create(1);

            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];

            //Create new DataTable to store the data from DataGrid
            DataTable dataTable = new DataTable();

            //Convert the Grid's data to DataTable
            ConvertGridDataToDataTable(dataTable, dataGrid.ItemsSource);

            //Import the DataTable to worksheet
            sheet.ImportDataTable(dataTable, 5, 1, false);

            // Define Styles
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

            // Apply Styles
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

            // Saving workbook and disposing objects
            workbook.Version = ExcelVersion.Excel2013;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            workbook.Close();
            excelEngine.Dispose();

            if (Device.RuntimePlatform == Device.UWP)
            {
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("DataTable.xlsx", "application/msexcel", stream);
            }
            else
            {
                Xamarin.Forms.DependencyService.Get<ISave>().Save("DataTable.xlsx", "application/msexcel", stream);
            }
        }

        private void ConvertGridDataToDataTable(DataTable dataTable, object itemsSource)
        {
            ObservableCollection<CustomerObject> items = (ObservableCollection<CustomerObject>)itemsSource;
            dataTable.Columns.Add("SalesPerson");
            dataTable.Columns.Add("SalesJanJune");
            dataTable.Columns.Add("SalesJulyDec");
            dataTable.Columns.Add("Change");
            foreach (CustomerObject customerObject in items)
            {
                dataTable.Rows.Add(customerObject.SalesPerson, customerObject.SalesJanJune, customerObject.SalesJulyDec, customerObject.Change);
            }
        }
    }
}