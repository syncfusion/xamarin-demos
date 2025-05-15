#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.XlsIO;
using System;
using System.IO;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using System.Reflection;

namespace SampleBrowser
{
    public partial class ImportHtmlTablePage : SamplePage
    {
        private Context m_context;

        public override View GetSampleContent(Context con)
        {
            int numerHeight = getDimensionPixelSize(con, Resource.Dimension.numeric_txt_ht);
            int width = con.Resources.DisplayMetrics.WidthPixels - 40;
            LinearLayout linear = new LinearLayout(con);
            linear.SetBackgroundColor(Color.White);
            linear.Orientation = Orientation.Vertical;
            linear.SetPadding(10, 10, 10, 10);

            TextView text2 = new TextView(con);
            text2.TextSize = 17;
            text2.TextAlignment = TextAlignment.Center;
            text2.Text = "This sample illustrates how to import HTML table to worksheet.";
            text2.SetTextColor(Color.ParseColor("#262626"));
            text2.SetPadding(5, 5, 5, 5);

            linear.AddView(text2);

            TextView space1 = new TextView(con);
            space1.TextSize = 10;
            linear.AddView(space1);

            m_context = con;

            LinearLayout subLinearLayout = new LinearLayout(con);
            subLinearLayout.Orientation = Orientation.Horizontal;

            LinearLayout advancedLinear1;
            advancedLinear1 = new LinearLayout(con);
            advancedLinear1.Orientation = Orientation.Horizontal;
            TextView space4 = new TextView(con);
            space4.TextSize = 17;
            space4.TextAlignment = TextAlignment.Center;
            space4.Text = "  ";
            space4.SetTextColor(Color.ParseColor("#262626"));
            space4.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight);
            advancedLinear1.AddView(space4);

            TextView space6 = new TextView(con);
            space6.TextSize = 17;
            linear.AddView(space6);

            Button templateButton = new Button(con);
            templateButton.Text = "Input Template";
            templateButton.Click += OnButtonClicked;
            linear.AddView(templateButton);

            Button convertButton = new Button(con);
            convertButton.Text = "Import";
            convertButton.Click += OnConvertButtonClicked;
            linear.AddView(convertButton);

            return linear;
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Stream filestream = null;
            filestream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Template.ImportHTMLTable.html");
            MemoryStream stream = new MemoryStream();
            filestream.CopyTo(stream);

            stream.Position = 0;

            SaveAndView(stream, "text/html");
        }

        private void OnConvertButtonClicked(object sender, EventArgs e)
        {
            //Instantiate excel engine
            ExcelEngine excelEngine = new ExcelEngine();
            //Excel application
            IApplication application = excelEngine.Excel;

            //Get assembly manifest resource
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fileStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Template.ImportHTMLTable.html");

            //Create Workbook
            IWorkbook workbook = application.Workbooks.Create(1);

            workbook.Version = ExcelVersion.Excel2016;

            IWorksheet sheet = workbook.Worksheets[0];

            sheet.ImportHtmlTable(fileStream, 1, 1);
            
            sheet.UsedRange.AutofitColumns();
            sheet.UsedRange.AutofitRows();

            MemoryStream stream = new MemoryStream();

            workbook.SaveAs(stream);

            stream.Position = 0;

            workbook.Close();
            excelEngine.Dispose();
            SaveAndView(stream, "application/msexcel");
        }

        void SaveAndView(MemoryStream stream, string contentType)
        {
            if (stream != null)
            {
                SaveAndroid androidSave = new SaveAndroid();
                if (contentType == "text/html")
                    androidSave.Save("ImportHTMLTable.html", contentType, stream, m_context);
                else
                    androidSave.Save("ImportHTMLTable.xlsx", contentType, stream, m_context);
            }
        }

        private int getDimensionPixelSize(Context con, int id)
        {
            return con.Resources.GetDimensionPixelSize(id);
        }
    }
}