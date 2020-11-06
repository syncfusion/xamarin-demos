#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleBrowser.Core;
using Syncfusion.XlsIO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.XlsIO
{
    public partial class PerformancePage : SampleView
    {
        public PerformancePage()
        {
            InitializeComponent();
        }

        private void BtnGenerate_Clicked(object sender, EventArgs e)
        {
            int rows = Convert.ToInt32(this.rowCount.Text);
            int columns = Convert.ToInt32(this.colCount.Text);
            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();

            //Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;
            IWorkbook workbook;

            workbook = application.Workbooks.Create(1);
            workbook.Version = ExcelVersion.Excel2013;
            IWorksheet sheet = workbook.Worksheets[0];

            if (this.Import.IsChecked.Value)
            {
               
                DataTable dataTable = new DataTable();
                for (int column = 1; column <= columns; column++)
                {
                    dataTable.Columns.Add("Column: " + column.ToString(), typeof(int));
                }
                //Adding data into data table
                for (int row = 1; row < rows; row++)
                {
                    dataTable.Rows.Add();
                    for (int column = 1; column <= columns; column++)
                    {
                        dataTable.Rows[row - 1][column - 1] = row * column;
                    }
                }
                sheet.ImportDataTable(dataTable, 1, 1, true, true);
            }
            else
            {

                IMigrantRange migrantRange = sheet.MigrantRange;

                for (int column = 1; column <= Convert.ToInt32(this.colCount.Text); column++)
                {
                    migrantRange.ResetRowColumn(1, column);
                    migrantRange.SetValue("Column: " + column.ToString());
                }

                //Writing Data using normal interface
                for (int row = 2; row <= rows; row++)
                {
                    //double columnSum = 0.0; 
                    for (int column = 1; column <= columns; column++)
                    {
                        //Writing number
                        migrantRange.ResetRowColumn(row, column);
                        migrantRange.SetValue(row * column);
                    }
                }
            }

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            workbook.Close();
            excelEngine.Dispose();

            if (Device.RuntimePlatform == Device.UWP)
            {
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("Sample.xlsx", "application/msexcel", stream);
            }
            else
            {
                Xamarin.Forms.DependencyService.Get<ISave>().Save("Sample.xlsx", "application/msexcel", stream);
            }
        }        
    }
}