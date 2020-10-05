#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SampleBrowser.Core;
using Syncfusion.XlsIO;
using Xamarin.Forms;

namespace SampleBrowser.XlsIO
{
    /// <summary>
    /// This class is used to import XML data into Excel workbook.
    /// </summary>
    public partial class ImportXMLPage : SampleView
    {
        public ImportXMLPage()
        {
            InitializeComponent();

            if (Device.Idiom != TargetIdiom.Phone && (Device.RuntimePlatform == Device.UWP))
            {
                this.Content_1.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.HorizontalOptions = LayoutOptions.Start;

                this.Content_1.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
				this.btnGenerate.BackgroundColor = Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {               
                {
                    this.Content_1.FontSize = 13.5;
                }

                this.Content_1.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
            }
        }

        internal void OnButtonClicked(object sender, EventArgs e)
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

            Assembly assembly = typeof(App).GetTypeInfo().Assembly;
			Stream fileStream = null;
			#if COMMONSB
			fileStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Samples.Template.customers.xml");
			#else
            fileStream = assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.customers.xml");
			#endif

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

            // Saving workbook and disposing objects
            workbook.Version = ExcelVersion.Excel2013;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            workbook.Close();
            excelEngine.Dispose();

            if (Device.RuntimePlatform == Device.UWP)
            {
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("ImportXML.xlsx", "application/msexcel", stream);
            }
            else
            {
                Xamarin.Forms.DependencyService.Get<ISave>().Save("ImportXML.xlsx", "application/msexcel", stream);
            }
        }
    }
}
