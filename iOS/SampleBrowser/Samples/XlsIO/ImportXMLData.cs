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
using COLOR = Syncfusion.Drawing;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
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
	public partial class ImportXMLData : SampleView
    {
		CGRect frameRect = new CGRect ();
		float frameMargin = 8.0f;
		UILabel label;
		UILabel label1;
		UIButton button;

		public ImportXMLData()
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
			label.Text = "This sample demonstrates how to import XML data into Excel workbook.";
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
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2013;

            #region Initializing Workbook
            //A new workbook is created.[Equivalent to creating a new workbook in MS Excel]
            //The new workbook will have 1 worksheets
            IWorkbook workbook = application.Workbooks.Create(1);
            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];

			Assembly assembly = Assembly.GetExecutingAssembly ();
			Stream fileStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Template.customers.xml");

            // Import the XML contents to worksheet
            XlsIOExtensions exten = new XlsIOExtensions();
            exten.ImportXML(fileStream, sheet, 1, 1, true);

            // Apply style for header
            IStyle headerStyle = sheet[1, 1, 1, sheet.UsedRange.LastColumn].CellStyle;
            headerStyle.Font.Bold = true;
            headerStyle.Font.Color = ExcelKnownColors.Brown;
            headerStyle.Font.Size = 10;

            // Resize columns
            sheet.Columns[0].ColumnWidth = 11;
            sheet.Columns[1].ColumnWidth = 30.5;
            sheet.Columns[2].ColumnWidth = 20;
            sheet.Columns[3].ColumnWidth = 25.6;
            sheet.Columns[6].ColumnWidth = 10.5;
            sheet.Columns[4].ColumnWidth = 40;
            sheet.Columns[5].ColumnWidth = 25.5;
            sheet.Columns[7].ColumnWidth = 9.6;
            sheet.Columns[8].ColumnWidth = 15;
            sheet.Columns[9].ColumnWidth = 15;
            #endregion

            workbook.Version = ExcelVersion.Excel2013;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            workbook.Close();
            excelEngine.Dispose();


			if (stream != null)
			{
				SaveiOS iOSSave = new SaveiOS ();
				iOSSave.Save ("ImportXML.xlsx", "application/msexcel", stream);
			}

		}

		public override void LayoutSubviews ()
		{
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) 
			{
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
