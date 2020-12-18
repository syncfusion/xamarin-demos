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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.Graphics;

namespace SampleBrowser
{
    public partial class ImportXMLPage : SamplePage
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
			    text2.Text = "This sample demonstrates how to import XML data into Excel workbook.";
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

            #region Saving workbook and disposing objects
            workbook.Version = ExcelVersion.Excel2013;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            workbook.Close();
            excelEngine.Dispose();


				if (stream != null)
				{
					SaveAndroid androidSave = new SaveAndroid ();
					androidSave.Save ("ImportXML.xlsx", "application/msexcel", stream, m_context);
				}
            #endregion
        }
    }
}
