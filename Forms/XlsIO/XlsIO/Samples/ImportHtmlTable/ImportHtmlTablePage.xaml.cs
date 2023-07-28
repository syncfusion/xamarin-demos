#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.XlsIO;
using Xamarin.Forms;
using System.Reflection;
using System.IO;
using SampleBrowser.Core;

namespace SampleBrowser.XlsIO
{
    /// <summary>
    /// This class is used to import HTML table to worksheet.
    /// </summary>
    public partial class ImportHtmlTablePage : SampleView
    {
        public ImportHtmlTablePage()
        {
            InitializeComponent();
            if (Device.Idiom != TargetIdiom.Phone && (Device.RuntimePlatform == Device.UWP))
            {
                this.Content_1.HorizontalOptions = LayoutOptions.Start;
                this.Content_1.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.BackgroundColor = Color.Gray;
                this.btnGetInputTemplate.HorizontalOptions = LayoutOptions.Start;
                this.btnGetInputTemplate.VerticalOptions = LayoutOptions.Center;
                this.btnGetInputTemplate.BackgroundColor = Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                {
                    this.Content_1.FontSize = 13.5;
                }

                this.Content_1.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
                this.btnGetInputTemplate.VerticalOptions = LayoutOptions.Center;
            }
        }

        private void BtnGetInputTemplate_Clicked(object sender, System.EventArgs e)
        {
            Assembly assembly = typeof(App).GetTypeInfo().Assembly;

            Stream inputStream = null;
            string fileName = "ImportHTMLTable.html";
            string contentType = "text/html";
#if COMMONSB
			inputStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Samples.Template.ImportHTMLTable.html");
#else
            inputStream = assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.ImportHTMLTable.html");
#endif
            MemoryStream htmlStream = new MemoryStream();

            inputStream.CopyTo(htmlStream);

            htmlStream.Position = 0;

            if (Device.RuntimePlatform == Device.UWP)
            {
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save(fileName, contentType, htmlStream);
            }
            else
            {
                Xamarin.Forms.DependencyService.Get<ISave>().Save(fileName, contentType, htmlStream);
            }
        }

        private void BtnGenerate_Clicked(object sender, System.EventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
#if COMMONSB
			Stream stream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Samples.Template.ImportHTMLTable.html");
#else
            Stream stream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.ImportHTMLTable.html");
#endif
            IWorkbook workbook = application.Workbooks.Create(1);
            workbook.Version = ExcelVersion.Excel2016;

            IWorksheet worksheet = workbook.Worksheets[0];

            MemoryStream outputStream = new MemoryStream();
            string fileName = "ImportHTMLTable.xlsx";
            string contentType = "application/msexcel";

            worksheet.ImportHtmlTable(stream, 1, 1);

            worksheet.UsedRange.AutofitColumns();
            worksheet.UsedRange.AutofitRows();

            workbook.SaveAs(outputStream);

            outputStream.Position = 0;

            if (Device.RuntimePlatform == Device.UWP)
            {
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save(fileName, contentType, outputStream);
            }
            else
            {
                Xamarin.Forms.DependencyService.Get<ISave>().Save(fileName, contentType, outputStream);
            }
        }
    }
}