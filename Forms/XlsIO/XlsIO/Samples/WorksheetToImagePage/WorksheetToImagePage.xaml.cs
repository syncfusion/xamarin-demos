#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
using COLOR = Syncfusion.Drawing;
using SampleBrowser.Core;
using Syncfusion.XlsIO;
using Syncfusion.XlsIORenderer;
using Xamarin.Forms;
using LayoutOptions = Xamarin.Forms.LayoutOptions;


namespace SampleBrowser.XlsIO
{
    /// <summary>
    /// This class is the conversion of a simple Excel document to an image.
    /// </summary>
    public partial class WorksheetToImagePage : SampleView
    {
        public WorksheetToImagePage()
        {
            InitializeComponent();
            this.pngButton.IsChecked = true;

            if (Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Content_1.HorizontalOptions = Xamarin.Forms.LayoutOptions.Start;
                this.btnGenerate.HorizontalOptions = Xamarin.Forms.LayoutOptions.Start;
                this.btnInput.HorizontalOptions = Xamarin.Forms.LayoutOptions.Start;
                this.Content_1.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnInput.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnGenerate.BackgroundColor = Color.Gray;
                this.btnInput.BackgroundColor = Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {        
                {
                    this.Content_1.FontSize = 13.5;
                }

                this.Content_1.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnInput.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
            }
        }

        internal void OnButtonClicked(object sender, EventArgs e)
        {
            //XlsIORenderer renderer = new XlsIORenderer();
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
#if COMMONSB
			Stream stream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Samples.Template.ExpenseReport.xlsx");
#else
            Stream stream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.ExpenseReport.xlsx");
#endif
            IWorkbook workbook = application.Workbooks.Open(stream);
            IWorksheet worksheet = workbook.Worksheets[0];
            application.XlsIORenderer = new XlsIORenderer();
            MemoryStream image = new MemoryStream();
            ExportImageOptions imageOptions = new ExportImageOptions();
            string fileName = null;
            string contentType = null;

            if (this.jpegButton.IsChecked != null && (bool)this.jpegButton.IsChecked)
            {
                imageOptions.ImageFormat = ExportImageFormat.Jpeg;
                fileName = "Image.jpeg";
                contentType = "image/jpeg";
            }
            else
            {
                imageOptions.ImageFormat = ExportImageFormat.Png;
                fileName = "Image.png";
                contentType = "image/png";
            }

            //Convert to image
            worksheet.ConvertToImage(worksheet.UsedRange, imageOptions, image);

            image.Position = 0;

            if (Device.RuntimePlatform == Device.UWP)
            {
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save(fileName, contentType, image);
            }
            else
            {
                Xamarin.Forms.DependencyService.Get<ISave>().Save(fileName, contentType, image);
            }
        }

        internal void OnInputButtonClicked(object sender, EventArgs e)
        {
            //Load Input Template to memory stream.
#if COMMONSB
			Stream file = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Samples.Template.ExpenseReport.xlsx");
#else
            Stream file = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.ExpenseReport.xlsx");
#endif
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
