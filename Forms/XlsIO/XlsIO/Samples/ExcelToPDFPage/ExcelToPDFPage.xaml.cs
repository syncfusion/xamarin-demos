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
    public partial class ExcelToPDFPage : SampleView
    {
        public ExcelToPDFPage()
        {
            InitializeComponent();
            this.picker.Items.Add("NoScaling");
            this.picker.Items.Add("FitAllRowsOnOnePage");
            this.picker.Items.Add("FitAllColumnsOnOnePage");
            this.picker.Items.Add("FitSheetOnOnePage");

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
            Stream stream = null;

            if (this.checkfontName.IsChecked.Value || this.checkfontStream.IsChecked.Value)
            {
                application.SubstituteFont += new Syncfusion.XlsIO.Implementation.SubstituteFontEventHandler(SubstituteFont);
                stream = GetFileStream("InvoiceTemplate.xlsx");
            }
            else
                stream = GetFileStream("ExcelToPDF.xlsx");

            IWorkbook workbook = application.Workbooks.Open(stream);

            XlsIORenderer renderer = new XlsIORenderer();
            XlsIORendererSettings settings = new XlsIORendererSettings();
            settings.IsConvertBlankPage = false;

            //Set the Layout Options for the output Pdf page.
            if (this.picker.SelectedIndex == 0)
            {
                settings.LayoutOptions = Syncfusion.XlsIORenderer.LayoutOptions.NoScaling;
            }
            else if (this.picker.SelectedIndex == 1)
            {
                settings.LayoutOptions = Syncfusion.XlsIORenderer.LayoutOptions.FitAllRowsOnOnePage;
            }
            else if (this.picker.SelectedIndex == 2)
            {
                settings.LayoutOptions = Syncfusion.XlsIORenderer.LayoutOptions.FitAllColumnsOnOnePage;
            }
            else if (this.picker.SelectedIndex == 3)
            {
                settings.LayoutOptions = Syncfusion.XlsIORenderer.LayoutOptions.FitSheetOnOnePage;
            }

            PdfDocument pdfDocument = renderer.ConvertToPDF(workbook, settings);
            MemoryStream memoryStream = new MemoryStream();
            pdfDocument.Save(memoryStream);
            pdfDocument.Close(true);

            if (Device.RuntimePlatform == Device.UWP)
            {
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("ExcelToPDF.pdf", "application/pdf", memoryStream);
            }
            else
            {
                Xamarin.Forms.DependencyService.Get<ISave>().Save("ExcelToPDF.pdf", "application/pdf", memoryStream);
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
            Stream file;
            if (this.checkfontName.IsChecked.Value || this.checkfontStream.IsChecked.Value)
            {
                file = GetFileStream("InvoiceTemplate.xlsx");
            }
            else
                file = GetFileStream("ExcelToPDF.xlsx");

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

        private void SubstituteFont(object sender, Syncfusion.XlsIO.Implementation.SubstituteFontEventArgs args)
        {
            if (checkfontName.IsChecked.Value && (args.OriginalFontName == "Bahnschrift Pro SemiBold" || args.OriginalFontName == "Georgia Pro Semibold"))
            {
                args.AlternateFontName = "Calibri";
            }
            if (checkfontStream.IsChecked.Value)
            {
                if (args.OriginalFontName == "Georgia Pro Semibold")
                {
                    Stream file = GetFileStream("georgiab.ttf");
                    MemoryStream memoryStream = new MemoryStream();
                    file.CopyTo(memoryStream);
                    file.Close();
                    args.AlternateFontStream = memoryStream;
                }
                else if (args.OriginalFontName == "Bahnschrift Pro SemiBold")
                {
                    Stream file = GetFileStream("bahnschrift.ttf");
                    MemoryStream memoryStream = new MemoryStream();
                    file.CopyTo(memoryStream);
                    file.Close();
                    args.AlternateFontStream = memoryStream;
                }
            }
        }
    }
}