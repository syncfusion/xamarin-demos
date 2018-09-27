#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.XlsIO;
using SampleBrowser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COLOR = Syncfusion.Drawing;
using Xamarin.Forms;
using System.IO;
using System.Reflection;

namespace SampleBrowser.XlsIO
{
    public partial class WorksheetToHTMLPage : SampleView
    {
        public WorksheetToHTMLPage()
        {
            InitializeComponent();
            this.bookButton.IsChecked = true;

            if (Device.Idiom != TargetIdiom.Phone && (Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WinRT))
            {
                this.Content_1.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.HorizontalOptions = LayoutOptions.Start;
                this.btnInput.HorizontalOptions = LayoutOptions.Start;
                this.Content_1.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.BackgroundColor = Color.Gray;
                this.btnInput.VerticalOptions = LayoutOptions.Center;
                this.btnInput.BackgroundColor = Color.Gray;
                Grid.SetColumn(this.radioButtons, 3);
                Grid.SetColumn(this.btnGenerate, 3);
                Grid.SetColumnSpan(this.btnInput, 2);
                Grid.SetColumnSpan(this.btnGenerate, 3);
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.WinPhone)
            {
                this.Content_1.FontSize = 13.5;
                this.Content_1.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
                this.btnInput.VerticalOptions = LayoutOptions.Center;
            }
            else if (Device.Idiom == TargetIdiom.Tablet)
            {
                if (Device.RuntimePlatform != Device.Android)
                {
                    Grid.SetColumn(this.radioButtons, 4);
                    Grid.SetColumn(this.btnGenerate, 3);
                    Grid.SetColumnSpan(this.btnInput, 2);
                    Grid.SetColumnSpan(this.btnGenerate, 3);
                }
            }
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
#if COMMONSB
			Stream stream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Samples.Template.NorthwindTemplate.xlsx");
#else
            Stream stream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.NorthwindTemplate.xlsx");
#endif
            IWorkbook workbook = application.Workbooks.Open(stream);
            IWorksheet worksheet = workbook.Worksheets[0];

            MemoryStream htmlStream = new MemoryStream();
            string fileName = "Htmlfile.html";
            string ContentType = "text/html";

            if (this.sheetButton.IsChecked != null && (bool)this.sheetButton.IsChecked)
                worksheet.SaveAsHtml(htmlStream);
            else
                workbook.SaveAsHtml(htmlStream);

            htmlStream.Position = 0;

            if (Device.RuntimePlatform == Device.WinPhone || Device.RuntimePlatform == Device.WinRT || Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save(fileName, ContentType, htmlStream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save(fileName, ContentType, htmlStream);
        }
        void OnInputButtonClicked(object sender, EventArgs e)
        {
            //Load Input Template to memory stream.
#if COMMONSB
			Stream file = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Samples.Template.NorthwindTemplate.xlsx");
#else
            Stream file = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.NorthwindTemplate.xlsx");
#endif

            file.Position = 0;

            MemoryStream stream = new MemoryStream();
            file.CopyTo(stream);

            if (Device.RuntimePlatform == Device.WinPhone || Device.RuntimePlatform == Device.WinRT || Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("InputTemplate.xlsx", "application/msexcel", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("InputTemplate.xlsx", "application/msexcel", stream);
        }
    }
}
