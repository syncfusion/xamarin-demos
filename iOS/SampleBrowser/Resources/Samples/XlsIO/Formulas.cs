#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.XlsIO;
using System.IO;
using COLOR = Syncfusion.Drawing.Color;
using System.Reflection;
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
	public partial class Formulas : SampleView
    {
     
		CGRect frameRect = new CGRect ();
		float frameMargin = 8.0f;
		UILabel label;
		UILabel label1;
		UIButton button;
		
		public Formulas()
		{
		 label = new UILabel ();
		 label1 = new UILabel ();
		 button = new UIButton (UIButtonType.System);
		 button.TouchUpInside += OnButtonClicked;
		}

		void LoadAllowedTextsLabel()
		{
			
			label.Frame = frameRect;
			label.TextColor = UIColor.FromRGB (38/255.0f, 38/255.0f, 38/255.0f);
			label.Text = "This sample demonstrates calculating cell values using formulas. ";
			label.Font = UIFont.SystemFontOfSize(15);
			label.Lines 				= 0;
			label.LineBreakMode 		= UILineBreakMode.WordWrap;
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				label.Font = UIFont.SystemFontOfSize(18);

			} 
			label.Frame = new CGRect(5, 5, frameRect.Location.X + frameRect.Size.Width  , 50);
			this.AddSubview (label);

			button.SetTitle("Generate Excel",UIControlState.Normal);
			button.Frame = new CGRect(0, 65, frameRect.Location.X + frameRect.Size.Width , 10);
			
			this.AddSubview (button);
		}
       
		void OnButtonClicked(object sender, EventArgs e)
        {
            #region Workbook Initialize

            ExcelEngine engine = new ExcelEngine();
            IApplication application = engine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2016;
            IWorkbook workbook = application.Workbooks.Create(1);
            IWorksheet sheet = workbook.Worksheets[0];
            sheet.EnableSheetCalculations();
            sheet["A40"].Activate();
            #endregion

            #region Worksheet Data

            sheet.Name = "Inventory";
            sheet.IsGridLinesVisible = false;
            sheet["A1"].Text = "INVENTORY LIST";
            sheet["A3"].Text = "TOTAL INVENTORY VALUE";
            sheet["D3"].Text = "TOTAL ITEMS";
            sheet["F3"].Text = "BIN COUNT";

            sheet["A6"].Text = "ID";
            sheet["B6"].Text = "Name";
            sheet["C6"].Text = "Bin #";
            sheet["D6"].Text = "Unit Price";
            sheet["E6"].Text = "Quantity in Stock";
            sheet["F6"].Text = "Inventory Value";

            sheet["A7"].Text = "IN001";
            sheet["B7"].Text = "Item 1";
            sheet["C7"].Text = "T340";
            sheet["D7"].Number = 51;
            sheet["E7:E26"].Number = 25;

            sheet["A8"].Text = "IN002";
            sheet["B8"].Text = "Item 2";
            sheet["C8"].Text = "T5780";
            sheet["D8"].Number = 93;

            sheet["A9"].Text = "IN003";
            sheet["B9"].Text = "Item 3";
            sheet["C9"].Text = "T340";
            sheet["D9"].Number = 57;

            sheet["A10"].Text = "IN004";
            sheet["B10"].Text = "Item 4";
            sheet["C10"].Text = "T908";
            sheet["D10"].Number = 19;

            sheet["A11"].Text = "IN005";
            sheet["B11"].Text = "Item 5";
            sheet["C11"].Text = "T9845";
            sheet["D11"].Number = 75;

            sheet["A12"].Text = "IN006";
            sheet["B12"].Text = "Item 6";
            sheet["C12"].Text = "T540";
            sheet["D12"].Number = 11;

            sheet["A13"].Text = "IN007";
            sheet["B13"].Text = "Item 7";
            sheet["C13"].Text = "T5780";
            sheet["D13"].Number = 56;

            sheet["A14"].Text = "IN008";
            sheet["B14"].Text = "Item 8";
            sheet["C14"].Text = "T340";
            sheet["D14"].Number = 38;

            sheet["A15"].Text = "IN009";
            sheet["B15"].Text = "Item 9";
            sheet["C15"].Text = "T908";
            sheet["D15"].Number = 59;

            sheet["A16"].Text = "IN010";
            sheet["B16"].Text = "Item 10";
            sheet["C16"].Text = "T9845";
            sheet["D16"].Number = 50;

            sheet["A17"].Text = "IN011";
            sheet["B17"].Text = "Item 11";
            sheet["C17"].Text = "T306";
            sheet["D17"].Number = 59;

            sheet["A18"].Text = "IN012";
            sheet["B18"].Text = "Item 12";
            sheet["C18"].Text = "T5780";
            sheet["D18"].Number = 18;

            sheet["A19"].Text = "IN013";
            sheet["B19"].Text = "Item 13";
            sheet["C19"].Text = "T306";
            sheet["D19"].Number = 26;

            sheet["A20"].Text = "IN014";
            sheet["B20"].Text = "Item 14";
            sheet["C20"].Text = "T908";
            sheet["D20"].Number = 42;

            sheet["A21"].Text = "IN015";
            sheet["B21"].Text = "Item 15";
            sheet["C21"].Text = "T9845";
            sheet["D21"].Number = 32;

            sheet["A22"].Text = "IN016";
            sheet["B22"].Text = "Item 16";
            sheet["C22"].Text = "T415";
            sheet["D22"].Number = 90;

            sheet["A23"].Text = "IN017";
            sheet["B23"].Text = "Item 17";
            sheet["C23"].Text = "T5780";
            sheet["D23"].Number = 12;

            sheet["A24"].Text = "IN018";
            sheet["B24"].Text = "Item 18";
            sheet["C24"].Text = "T340";
            sheet["D24"].Number = 82;

            sheet["A25"].Text = "IN019";
            sheet["B25"].Text = "Item 19";
            sheet["C25"].Text = "T908";
            sheet["D25"].Number = 16;

            sheet["A26"].Text = "IN020";
            sheet["B26"].Text = "Item 20";
            sheet["C26"].Text = "T9845";
            sheet["D26"].Number = 11;

            sheet["A27"].Text = "Total";
            #endregion

            #region Formatting 

            sheet.Range["A1:F1"].Merge();
            sheet.Range["A4:B4"].Merge();

            sheet["A1"].CellStyle.Font.Bold = true;
            sheet["A1"].CellStyle.Font.FontName = "Calibri";
            sheet["A1"].CellStyle.Font.Size = 18;

            sheet.Range["A1:F1"].CellStyle.IncludeBorder = true;
            sheet.Range["A1:F1"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].ColorRGB = COLOR.FromArgb(0, 204, 153);
            sheet.Range["A1:F1"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Medium;

            sheet["A3:F3"].CellStyle.Font.Bold = true;
            sheet["A3:F3"].CellStyle.Font.FontName = "Calibri";
            sheet["A3:F3"].CellStyle.Font.Size = 9;

            sheet["A4:F4"].CellStyle.Font.Bold = true;
            sheet["A4:F4"].CellStyle.Font.FontName = "Calibri";
            sheet["A4:F4"].CellStyle.Font.Size = 14;
            sheet["A4:F4"].CellStyle.Font.RGBColor = COLOR.FromArgb(0, 204, 153);
            sheet["A4"].HorizontalAlignment = ExcelHAlign.HAlignCenter;
            sheet["A4"].NumberFormat = "_($* #,##0.00_)";

            sheet["A6:F6"].CellStyle.Font.FontName = "Calibri";
            sheet["A6:F6"].CellStyle.Font.Size = 11;
            sheet["A6:F6"].CellStyle.Font.Bold = true;
            sheet["A6:F6"].CellStyle.Font.RGBColor = COLOR.FromArgb(255, 255, 255);
            sheet["A6:F6"].WrapText = true;
            sheet["A6:F6"].VerticalAlignment = ExcelVAlign.VAlignTop;
            sheet.Range["A6:F6"].CellStyle.Color = COLOR.FromArgb(0, 204, 153);


            sheet["A6:F27"].CellStyle.Font.FontName = "Calibri";
            sheet["A6:F27"].CellStyle.Font.Size = 11;

            sheet["D7:F27"].NumberFormat = "_($* #,##0.00_)";

            sheet["D4:F4"].HorizontalAlignment = ExcelHAlign.HAlignLeft;

            sheet["A27:F27"].CellStyle.Font.FontName = "Calibri";
            sheet["A27:F27"].CellStyle.Font.Size = 11;
            sheet["A27:F27"].CellStyle.Font.Bold = true;

            sheet.Range["A7:27"].CellStyle.IncludeBorder = true;
            sheet.Range["A7:F27"].CellStyle.Borders.ColorRGB = COLOR.FromArgb(112, 173, 71);
            sheet.Range["A7:F27"].CellStyle.Borders.LineStyle = ExcelLineStyle.Thin;
            sheet.Range["A7:F27"].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;
            sheet.Range["A7:F27"].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
            sheet["A26:F26"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Double;

            sheet.Range["A1:F1"].RowHeight = 24;

            sheet["A2"].RowHeight = 7.18;
            sheet["A3"].RowHeight = 23.5;
            sheet["A4"].RowHeight = 19.5;
            sheet["A5"].RowHeight = 6.8;
            sheet["A6"].RowHeight = 41.3;

            sheet["A1:B1"].ColumnWidth = 7.18;
            sheet["C1"].ColumnWidth = 6.91;
            sheet["D1"].ColumnWidth = 9.55;
            sheet["E1"].ColumnWidth = 8.91;
            sheet["F1"].ColumnWidth = 11.18;

            #endregion

            #region Formula

            sheet["D4"].Formula = "=COUNT(D7:D26)";
            sheet["F4"].Formula = "=SUMPRODUCT(1/COUNTIF(C7:C26,C7:C26))";

            for (int i = 7; i < 27; i++)
                sheet["F" + i].Formula = "=D" + i + "*E" + i;

            sheet["D27"].Formula = "SUM(D7:D26)";
            sheet["E27"].Formula = "SUM(E7:E26)";
            sheet["F27"].Formula = "SUM(F7:F26)";
            sheet["A4"].Formula = "=F27";

            #endregion
		   
            workbook.Version = ExcelVersion.Excel2013;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            workbook.Close();
            engine.Dispose();

			if (stream != null)
			{
				SaveiOS iOSSave = new SaveiOS ();
				iOSSave.Save ("Formulas.xlsx", "application/msexcel", stream);
			}

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
