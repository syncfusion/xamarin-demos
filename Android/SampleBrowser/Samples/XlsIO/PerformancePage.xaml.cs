#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.XlsIO;
using COLOR = Syncfusion.Drawing;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using System.Data;
using System.IO;
using Com.Syncfusion.Numerictextbox;
using Syncfusion.Android.MaskedEdit;

namespace SampleBrowser
{
    class PerformancePage: SamplePage
    {
        private CheckBox chkImport;
        private SfMaskedEdit textBox1;
        private SfMaskedEdit textBox2;
        private Context m_context;

        public override View GetSampleContent(Context con)
        {
            LinearLayout linear = new LinearLayout(con);
            linear.SetBackgroundColor(Color.White);
            linear.Orientation = Orientation.Vertical;
            linear.SetPadding(10, 10, 10, 10);

            TextView text2 = new TextView(con);
            text2.TextSize = 17;
            text2.TextAlignment = TextAlignment.Center;
            text2.Text = "This sample demonstrates the performance of Syncfusion XlsIO library to create larger Excel files.";
            text2.SetTextColor(Color.ParseColor("#262626"));
            text2.SetPadding(5, 5, 5, 5);

            linear.AddView(text2);

            TextView space = new TextView(con);
            space.TextSize = 10;
            linear.AddView(space);

            TextView text3 = new TextView(con);
            text3.TextSize = 15;
            text3.Text = "Enter the no. of rows";
            text3.SetTextColor(Color.ParseColor("#262626"));

            linear.AddView(text3);

            textBox1 = new SfMaskedEdit(con);
            textBox1.Value = 5000;
            linear.AddView(textBox1);

            TextView space3 = new TextView(con);
            space3.TextSize = 10;
            linear.AddView(space3);

            TextView text4 = new TextView(con);
            text4.TextSize = 15;
            text4.TextAlignment = TextAlignment.Center;
            text4.Text = "Enter the no. of columns";

            linear.AddView(text4);

            textBox2 = new SfMaskedEdit(con);
            textBox2.Value = 50;
            linear.AddView(textBox2);

            TextView space1 = new TextView(con);
            space1.TextSize = 10;
            linear.AddView(space1);

            chkImport = new CheckBox(con);
            chkImport.Text = "Import on Save";

            linear.AddView(chkImport);

            TextView text = new TextView(con);
            text.TextSize = 13;
            text.Text = "Import on Save option directly serialize data while saving the workbook.";

            linear.AddView(text);

            TextView space2 = new TextView(con);
            space1.TextSize = 10;
            linear.AddView(space2);

            m_context = con;
            Button button1 = new Button(con);
            button1.Text = "Generate Excel";
            button1.Click += Button1_Click; 
            linear.AddView(button1);

            return linear;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int rowCount = Convert.ToInt32(textBox1.Value);
            int colCount = Convert.ToInt32(textBox2.Value);
            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();

            //Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;
            IWorkbook workbook;

            workbook = application.Workbooks.Create(1);
            IWorksheet sheet = workbook.Worksheets[0];

            if (chkImport.Checked)
            {
                workbook.Version = ExcelVersion.Excel2013;
                DataTable dataTable = new DataTable();
                for (int column = 1; column <= colCount; column++)
                {
                    dataTable.Columns.Add("Column: " + column.ToString(), typeof(int));
                }
                //Adding data into data table
                for (int row = 1; row < rowCount; row++)
                {
                    dataTable.Rows.Add();
                    for (int column = 1; column <= colCount; column++)
                    {
                        dataTable.Rows[row - 1][column - 1] = row * column;
                    }
                }
                sheet.ImportDataTable(dataTable, 1, 1, true, true);
            }
            else
            {

                IMigrantRange migrantRange = sheet.MigrantRange;

                for (int column = 1; column <= colCount; column++)
                {
                    migrantRange.ResetRowColumn(1, column);
                    migrantRange.SetValue("Column: " + column.ToString());
                }

                //Writing Data using normal interface
                for (int row = 2; row <= rowCount; row++)
                {
                    //double columnSum = 0.0; 
                    for (int column = 1; column <= colCount; column++)
                    {
                        //Writing number
                        migrantRange.ResetRowColumn(row, column);
                        migrantRange.SetValue(row * column);
                    }
                }
            }
            workbook.Version = ExcelVersion.Excel2013;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            workbook.Close();
            excelEngine.Dispose();


            if (stream != null)
            {
                SaveAndroid androidSave = new SaveAndroid();
                androidSave.Save("CreateSheet.xlsx", "application/msexcel", stream, m_context);
            }
        }
    }
}