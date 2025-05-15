#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.IO;
using System.Reflection;
using SampleBrowser.Core;
using Syncfusion.XlsIO;
using Syncfusion.Pdf;
using Syncfusion.XlsIORenderer;
using Xamarin.Forms;
using LayoutOptions = Xamarin.Forms.LayoutOptions;

namespace SampleBrowser.XlsIO
{
    /// <summary>
    /// This class is the conversion of a Excel document to PDF.
    /// </summary>
    public partial class ExcelToJSON : SampleView
    {
        public ExcelToJSON()
        {
            InitializeComponent();
            this.picker.Items.Add("Workbook");
            this.picker.Items.Add("Worksheet");
            this.picker.Items.Add("Range");
            this.picker.SelectedIndex = 0;
            if (Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Content_1.HorizontalOptions = LayoutOptions.Start;
                this.Content_1.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.BackgroundColor = Color.Gray;
                this.btnInput.HorizontalOptions = LayoutOptions.Start;
                this.btnInput.VerticalOptions = LayoutOptions.Center;
                this.btnInput.BackgroundColor = Color.Gray;
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
            Stream stream = GetFileStream("ExcelToJSON.xlsx");

            IWorkbook workbook = application.Workbooks.Open(stream);

            IWorksheet sheet = workbook.Worksheets[0];
            IRange range = sheet.Range["A2:B10"];

            bool isShema = this.IsSchema.IsChecked.Value;

            MemoryStream memoryStream = new MemoryStream();

            if (this.picker.SelectedIndex == 0)
                workbook.SaveAsJson(memoryStream, isShema);
            else if (this.picker.SelectedIndex == 1)
                workbook.SaveAsJson(memoryStream, sheet, isShema);
            else if (this.picker.SelectedIndex == 2)
                workbook.SaveAsJson(memoryStream, range, isShema);


            if (Device.RuntimePlatform == Device.UWP)
            {
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("ExcelToJSON.json", "application/json", memoryStream);
            }
            else
            {
                Xamarin.Forms.DependencyService.Get<ISave>().Save("ExcelToJSON.json", "application/json", memoryStream);
            }
        }

        internal Stream GetFileStream(string fileName)
        {
            Stream stream = null;
#if COMMONSB
            stream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Samples.Template."+ fileName);
#else
            stream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template." + fileName);
#endif
            return stream;
        }

        internal void OnInputButtonClicked(object sender, EventArgs e)
        {
            //Load Input Template to memory stream.
            Stream file = GetFileStream("ExcelToJSON.xlsx"); ;
                

            file.Position = 0;

            MemoryStream stream = new MemoryStream();
            file.CopyTo(stream);

            if (Device.RuntimePlatform == Device.UWP)
            {
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("InputTemplate.xlsx", "application/msexcel", stream);
            }
            else
            {
                Xamarin.Forms.DependencyService.Get<ISave>().Save("InputTemplate.xlsx", "application/msexcel", stream);
            }
        }
    }
}