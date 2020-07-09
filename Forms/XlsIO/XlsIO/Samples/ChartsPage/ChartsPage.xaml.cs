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
    /// This class illustrates the creation of Excel document with bar chart.
    /// </summary>
    public partial class ChartsPage : SampleView
    {
        public ChartsPage()
        {
            InitializeComponent();

            if (Device.Idiom != TargetIdiom.Phone && (Device.RuntimePlatform == Device.UWP))
            {
                this.Content.HorizontalOptions = LayoutOptions.Start;
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

            // Initializing Workbook
            string resourcePath = string.Empty;
			#if COMMONSB
			resourcePath = "SampleBrowser.Samples.XlsIO.Samples.Template.ChartData.xlsx";
			#else
			resourcePath = "SampleBrowser.XlsIO.Samples.Template.ChartData.xlsx";
			#endif
            Assembly assembly = typeof(App).GetTypeInfo().Assembly;
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            IWorkbook workbook = application.Workbooks.Open(fileStream);

            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];

            // Generate Chart
            IChartShape chart = sheet.Charts.Add();

            chart.DataRange = sheet["A16:E26"];
            chart.ChartTitle = sheet["A15"].Text;
            chart.HasLegend = false;
            chart.TopRow = 3;
            chart.LeftColumn = 1;
            chart.RightColumn = 6;
            chart.BottomRow = 15;           

            workbook.Version = ExcelVersion.Excel2013;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            workbook.Close();
            excelEngine.Dispose();

            if (Device.RuntimePlatform == Device.UWP)
            {
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("Charts.xlsx", "application/msexcel", stream);
            }
            else
            {
                Xamarin.Forms.DependencyService.Get<ISave>().Save("Charts.xlsx", "application/msexcel", stream);
            }
        }        
    }
}
