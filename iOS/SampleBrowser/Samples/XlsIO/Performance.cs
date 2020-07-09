#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.XlsIO;
using System.IO;
using COLOR = Syncfusion.Drawing;
using Syncfusion.iOS.Buttons;
using Syncfusion.iOS.MaskedEdit;
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
    class Performance : SampleView
    {
        CGRect frameRect = new CGRect();
        float frameMargin = 8.0f;
        UILabel label;
        UILabel label1;
        UILabel label2;
        UILabel label3;
        SfCheckBox importCheck;
        SfMaskedEdit textBox1;
        SfMaskedEdit textBox2;
        UIButton button;

        public Performance()
        {
            label = new UILabel();
            label1 = new UILabel();
            label2 = new UILabel();
            label3 = new UILabel();
            button = new UIButton(UIButtonType.System);
            textBox1 = new SfMaskedEdit();
            textBox2 = new SfMaskedEdit();
            importCheck = new SfCheckBox();
            button.TouchUpInside += OnButtonClicked;
        }

        void LoadAllowedTextsLabel()
        {

            label.Frame = frameRect;
            label.TextColor = UIColor.FromRGB(38 / 255.0f, 38 / 255.0f, 38 / 255.0f);
            label.Text = "This sample demonstrates the performance of Syncfusion XlsIO library to create larger Excel files.";
            label.Font = UIFont.SystemFontOfSize(15);
            label.Lines = 0;
            label.SizeToFit();
            label.LineBreakMode = UILineBreakMode.WordWrap;
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                label.Font = UIFont.SystemFontOfSize(18);
                label.Frame = new CGRect(5, 5, frameRect.Location.X + frameRect.Size.Width, 50);
            }
            else
            {
                label.Frame = new CGRect(5, 5, frameRect.Size.Width, 70);
            }
            this.AddSubview(label);

            label2.Frame = new CGRect(10, 80, 300, 17);
            label2.Text = "Enter the no. of rows";
            label2.Font = UIFont.SystemFontOfSize(14);
            label2.Lines = 0;
            label2.SizeToFit();
            label2.LineBreakMode = UILineBreakMode.WordWrap;
            this.AddSubview(label2);

            textBox1.Value = 5000;
            textBox1.Frame = new CGRect(10, 100, 250, 20);
            this.AddSubview(textBox1);

            label3.Frame = new CGRect(10, 130, 300, 17);
            label3.Text = "Enter the no. of columns";
            label3.Font = UIFont.SystemFontOfSize(14);
            label3.Lines = 0;
            label3.SizeToFit();
            label3.LineBreakMode = UILineBreakMode.WordWrap;
            this.AddSubview(label3);


            textBox2.Value = 50;
            textBox2.Frame = new CGRect(10, 150, 250, 20);
            this.AddSubview(textBox2);

            importCheck.Frame = new CGRect(10, 180, 200, 20);
            importCheck.Font = UIFont.SystemFontOfSize(14);
            importCheck.CornerRadius = 5.0f;
            importCheck.SetTitle("Import on Save", UIControlState.Normal);

            this.AddSubview(importCheck);

            label1.Frame = new CGRect(10, 210, 300, 17); 
            label1.Text = "Import on Save option directly serialize data while saving the workbook.";
            label1.Font = UIFont.SystemFontOfSize(12);
            label1.Lines = 0;
            label1.SizeToFit();
            label1.LineBreakMode = UILineBreakMode.WordWrap;
            this.AddSubview(label1);


            button.SetTitle("Generate Excel", UIControlState.Normal);
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                button.Frame = new CGRect(0, 240, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            else
            {
                button.Frame = new CGRect(5, 255, frameRect.Size.Width, 10);
            }
            this.AddSubview(button);
        }



        void OnButtonClicked(object sender, EventArgs e)
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

            if (this.importCheck.IsChecked.Value)
            {
                workbook.Version = ExcelVersion.Excel2013;
                System.Data.DataTable dataTable = new System.Data.DataTable();
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
                SaveiOS iOSSave = new SaveiOS();
                iOSSave.Save("CreateSheet.xlsx", "application/msexcel", stream);
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