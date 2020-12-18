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
    public partial class ChartsPage : SamplePage
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
			text2.Text = "This sample demonstrates the creation of Excel document with bar chart.";
			text2.SetTextColor(Color.ParseColor("#262626"));
			text2.SetPadding(5, 5, 5, 5);

			linear.AddView(text2);

			TextView space1 = new TextView (con);
			space1.TextSize = 10;
			linear.AddView (space1);

			m_context = con;

			TextView space2 = new TextView (con);
			space2.TextSize = 10;
            linear.AddView(space2);

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
            string resourcePath = "SampleBrowser.Samples.XlsIO.Template.ChartData.xlsx";
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            IWorkbook workbook = application.Workbooks.Open(fileStream);
            IWorksheet sheet = workbook.Worksheets[0];
            #endregion

            #region Generate Chart
            IChartShape chart = sheet.Charts.Add();

            chart.DataRange = sheet["A16:E26"];
            chart.ChartTitle = sheet["A15"].Text;
            chart.HasLegend = false;
            chart.TopRow = 3;
            chart.LeftColumn = 1;
            chart.RightColumn = 6;
            chart.BottomRow = 15;
            #endregion

            workbook.Version = ExcelVersion.Excel2013;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            workbook.Close();
            excelEngine.Dispose();

            if (stream != null)
            {
                SaveAndroid androidSave = new SaveAndroid();
                androidSave.Save("Charts.xlsx", "application/msexcel", stream, m_context);
            }


        }

    }
}
