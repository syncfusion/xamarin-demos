#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COLOR = Syncfusion.Drawing;
using System.IO;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.Graphics;

namespace SampleBrowser
{
    public partial class CreateSpreadsheetPage : SamplePage
    {
		private Context m_context; 

		public override View GetSampleContent (Context con)
		{
			LinearLayout linear = new LinearLayout(con);
			linear.SetBackgroundColor(Color.White);
			linear.Orientation = Orientation.Vertical;
			linear.SetPadding(10, 10, 10, 10);

			TextView text2 = new TextView(con);
			text2.TextSize = 17;
			text2.TextAlignment = TextAlignment.Center;
			text2.Text = "This sample demonstrates the creation of a simple Excel document with text, number, date and formula.";
			text2.SetTextColor(Color.ParseColor("#262626"));
			text2.SetPadding(5, 5, 5, 5);

			linear.AddView(text2);

			TextView space1 = new TextView (con);
			space1.TextSize = 10;
			linear.AddView (space1);

			m_context = con;

			TextView space2 = new TextView (con);
			space2.TextSize = 10;
			linear.AddView (space2);

			Button button1 = new Button (con);
			button1.Text = "Generate Excel";
			button1.Click += OnButtonClicked;
			linear.AddView (button1);

			return linear;
		}
			

           

		void OnButtonClicked(object sender, EventArgs e)
        {
            //Instantiate excel engine
            ExcelEngine excelEngine = new ExcelEngine();
            //Excel application
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2013;

            #region Initializing Workbook
            //A new workbook is created.[Equivalent to creating a new workbook in MS Excel]
            //The new workbook will have 1 worksheet
            IWorkbook workbook = application.Workbooks.Create(1);

            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];
            #endregion

            #region Generate Excel

            sheet.EnableSheetCalculations();

            sheet.Range["A2"].ColumnWidth = 20;
            sheet.Range["B2"].ColumnWidth = 13;
            sheet.Range["C2"].ColumnWidth = 13;
            sheet.Range["D2"].ColumnWidth = 13;

            sheet.Range["A2:D2"].Merge(true);

            //Inserting sample text into the first cell of the first worksheet.
            sheet.Range["A2"].Text = "EXPENSE REPORT";
            sheet.Range["A2"].CellStyle.Font.FontName = "Verdana";
            sheet.Range["A2"].CellStyle.Font.Bold = true;
            sheet.Range["A2"].CellStyle.Font.Size = 28;
            sheet.Range["A2"].CellStyle.Font.RGBColor = COLOR.Color.FromArgb(255, 0, 112, 192);
            sheet.Range["A2"].HorizontalAlignment = ExcelHAlign.HAlignCenter;
            sheet.Range["A2"].RowHeight = 34;

            sheet.Range["A4"].Text = "Employee";
            sheet.Range["B4"].Text = "Roger Federer";
            sheet.Range["A4:B7"].CellStyle.Font.FontName = "Verdana";
            sheet.Range["A4:B7"].CellStyle.Font.Bold = true;
            sheet.Range["A4:B7"].CellStyle.Font.Size = 11;
            sheet.Range["A4:A7"].CellStyle.Font.RGBColor = COLOR.Color.FromArgb(255, 128, 128, 128);
            sheet.Range["A4:A7"].HorizontalAlignment = ExcelHAlign.HAlignLeft;
            sheet.Range["B4:B7"].CellStyle.Font.RGBColor = COLOR.Color.FromArgb(255, 174, 170, 170);
            sheet.Range["B4:B7"].HorizontalAlignment = ExcelHAlign.HAlignRight;
            sheet.Range["B4:D4"].Merge(true);

            sheet.Range["A9:D20"].CellStyle.Font.FontName = "Verdana";
            sheet.Range["A9:D20"].CellStyle.Font.Size = 11;

            sheet.Range["A5"].Text = "Department";
            sheet.Range["B5"].Text = "Administration";
            sheet.Range["B5:D5"].Merge(true);

            sheet.Range["A6"].Text = "Week Ending";
            sheet.Range["B6"].NumberFormat = "m/d/yyyy";
            sheet.Range["B6"].DateTime = DateTime.Parse("10/10/2012");
            sheet.Range["B6:D6"].Merge(true);

            sheet.Range["A7"].Text = "Mileage Rate";
            sheet.Range["B7"].NumberFormat = "$#,##0.00";
            sheet.Range["B7"].Number = 0.70;
            sheet.Range["B7:D7"].Merge(true);

            sheet.Range["A10"].Text = "Miles Driven";
            sheet.Range["A11"].Text = "Reimbursement";
            sheet.Range["A12"].Text = "Parking/Tolls";
            sheet.Range["A13"].Text = "Auto Rental";
            sheet.Range["A14"].Text = "Lodging";
            sheet.Range["A15"].Text = "Breakfast";
            sheet.Range["A16"].Text = "Lunch";
            sheet.Range["A17"].Text = "Dinner";
            sheet.Range["A18"].Text = "Snacks";
            sheet.Range["A19"].Text = "Others";
            sheet.Range["A20"].Text = "Total";
            sheet.Range["A20:D20"].CellStyle.Color = COLOR.Color.FromArgb(255, 0, 112, 192);
            sheet.Range["A20:D20"].CellStyle.Font.Color = ExcelKnownColors.Black;
            sheet.Range["A20:D20"].CellStyle.Font.Bold = true;

            IStyle style = sheet["B9:D9"].CellStyle;
            style.VerticalAlignment = ExcelVAlign.VAlignCenter;
            style.HorizontalAlignment = ExcelHAlign.HAlignRight;
            style.Color = COLOR.Color.FromArgb(255, 0, 112, 192);
            style.Font.Bold = true;
            style.Font.Color = ExcelKnownColors.Black;

            sheet.Range["A9"].Text = "Expenses";
            sheet.Range["A9"].CellStyle.Color = COLOR.Color.FromArgb(255, 0, 112, 192);
            sheet.Range["A9"].CellStyle.Font.Color = ExcelKnownColors.White;
            sheet.Range["A9"].CellStyle.Font.Bold = true;
            sheet.Range["B9"].Text = "Day 1";
            sheet.Range["B10"].Number = 100;
            sheet.Range["B11"].NumberFormat = "$#,##0.00";
            sheet.Range["B11"].Formula = "=(B7*B10)";
            sheet.Range["B12"].NumberFormat = "$#,##0.00";
            sheet.Range["B12"].Number = 0;
            sheet.Range["B13"].NumberFormat = "$#,##0.00";
            sheet.Range["B13"].Number = 0;
            sheet.Range["B14"].NumberFormat = "$#,##0.00";
            sheet.Range["B14"].Number = 0;
            sheet.Range["B15"].NumberFormat = "$#,##0.00";
            sheet.Range["B15"].Number = 9;
            sheet.Range["B16"].NumberFormat = "$#,##0.00";
            sheet.Range["B16"].Number = 12;
            sheet.Range["B17"].NumberFormat = "$#,##0.00";
            sheet.Range["B17"].Number = 13;
            sheet.Range["B18"].NumberFormat = "$#,##0.00";
            sheet.Range["B18"].Number = 9.5;
            sheet.Range["B19"].NumberFormat = "$#,##0.00";
            sheet.Range["B19"].Number = 0;
            sheet.Range["B20"].NumberFormat = "$#,##0.00";
            sheet.Range["B20"].Formula = "=SUM(B11:B19)";

            sheet.Range["C9"].Text = "Day 2";
            sheet.Range["C10"].Number = 145;
            sheet.Range["C11"].NumberFormat = "$#,##0.00";
            sheet.Range["C11"].Formula = "=(B7*C10)";
            sheet.Range["C12"].NumberFormat = "$#,##0.00";
            sheet.Range["C12"].Number = 15;
            sheet.Range["C13"].NumberFormat = "$#,##0.00";
            sheet.Range["C13"].Number = 0;
            sheet.Range["C14"].NumberFormat = "$#,##0.00";
            sheet.Range["C14"].Number = 45;
            sheet.Range["C15"].NumberFormat = "$#,##0.00";
            sheet.Range["C15"].Number = 9;
            sheet.Range["C16"].NumberFormat = "$#,##0.00";
            sheet.Range["C16"].Number = 12;
            sheet.Range["C17"].NumberFormat = "$#,##0.00";
            sheet.Range["C17"].Number = 15;
            sheet.Range["C18"].NumberFormat = "$#,##0.00";
            sheet.Range["C18"].Number = 7;
            sheet.Range["C19"].NumberFormat = "$#,##0.00";
            sheet.Range["C19"].Number = 0;
            sheet.Range["C20"].NumberFormat = "$#,##0.00";
            sheet.Range["C20"].Formula = "=SUM(C11:C19)";

            sheet.Range["D9"].Text = "Day 3";
            sheet.Range["D10"].Number = 113;
            sheet.Range["D11"].NumberFormat = "$#,##0.00";
            sheet.Range["D11"].Formula = "=(B7*D10)";
            sheet.Range["D12"].NumberFormat = "$#,##0.00";
            sheet.Range["D12"].Number = 17;
            sheet.Range["D13"].NumberFormat = "$#,##0.00";
            sheet.Range["D13"].Number = 8;
            sheet.Range["D14"].NumberFormat = "$#,##0.00";
            sheet.Range["D14"].Number = 45;
            sheet.Range["D15"].NumberFormat = "$#,##0.00";
            sheet.Range["D15"].Number = 7;
            sheet.Range["D16"].NumberFormat = "$#,##0.00";
            sheet.Range["D16"].Number = 11;
            sheet.Range["D17"].NumberFormat = "$#,##0.00";
            sheet.Range["D17"].Number = 16;
            sheet.Range["D18"].NumberFormat = "$#,##0.00";
            sheet.Range["D18"].Number = 7;
            sheet.Range["D19"].NumberFormat = "$#,##0.00";
            sheet.Range["D19"].Number = 5;
            sheet.Range["D20"].NumberFormat = "$#,##0.00";
            sheet.Range["D20"].Formula = "=SUM(D11:D19)";

            sheet.Range["A10:D10"].CellStyle.Font.RGBColor = COLOR.Color.FromArgb(255, 174, 170, 170);
            #endregion

            workbook.Version = ExcelVersion.Excel2013;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            workbook.Close();
            excelEngine.Dispose();


			if (stream != null)
			{
				SaveAndroid androidSave = new SaveAndroid ();
				androidSave.Save ("CreateSheet.xlsx", "application/msexcel", stream, m_context);
			}

        }
    }
}
