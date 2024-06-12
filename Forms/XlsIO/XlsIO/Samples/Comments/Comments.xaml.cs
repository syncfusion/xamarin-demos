#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SampleBrowser.Core;
using Syncfusion.XlsIO;
using Xamarin.Forms;
using Syncfusion.Pdf;
using Syncfusion.XlsIORenderer;

namespace SampleBrowser.XlsIO
{
    /// <summary>
    /// This class is used to add comments in Excel worksheet.
    /// </summary>
    public partial class Comments : SampleView
    {
        public Comments()
        {
            InitializeComponent();

            
            if (Device.Idiom != TargetIdiom.Phone && (Device.RuntimePlatform == Device.UWP))
            {
                this.Content_1.HorizontalOptions = Xamarin.Forms.LayoutOptions.Start;
                this.btnGenerate.HorizontalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnGetInputTemplate.HorizontalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnConvertToPDF.HorizontalOptions = Xamarin.Forms.LayoutOptions.Center;

                this.Content_1.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnGetInputTemplate.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;

                this.btnGetInputTemplate.BackgroundColor = Color.Gray;
                this.btnGenerate.BackgroundColor = Color.Gray;
                this.btnConvertToPDF.BackgroundColor = Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                {
                    this.Content_1.FontSize = 13.5;
                }

                this.Content_1.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnGetInputTemplate.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnConvertToPDF.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
            }
        }

        internal void btnGenerate_Clicked(object sender, EventArgs e)
        {
            //Initialize ExcelEngine
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                //Initialize IApplication and set the default application version
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Xlsx;

                // Initializing Workbook
                Assembly assembly = typeof(App).GetTypeInfo().Assembly;
                Stream fileStream = null;
#if COMMONSB
                fileStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Samples.Template.CommentsTemplate.xlsx");
#else
                fileStream = assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.CommentsTemplate.xlsx");
#endif

                IWorkbook workbook = application.Workbooks.Open(fileStream);

                IWorksheet worksheet = workbook.Worksheets[0];

                //Add Comments
                AddComments(worksheet);

                MemoryStream stream = new MemoryStream();
                workbook.SaveAs(stream);
                workbook.Close();
                excelEngine.Dispose();
                if (Device.RuntimePlatform == Device.UWP)
                {
                    Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("ExcelComments.xlsx", "application/msexcel", stream);
                }
                else
                {
                    Xamarin.Forms.DependencyService.Get<ISave>().Save("ExcelComments.xlsx", "application/msexcel", stream);
                }
            }
        }

        internal void btnGetInputTemplate_Clicked(object sender, EventArgs e)
        {
             Assembly assembly = typeof(App).GetTypeInfo().Assembly;

            Stream inputStream = null;
            string fileName = "CommentsTemplate.xlsx";
            string contentType = "application/msexcel";
#if COMMONSB
			inputStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Samples.Template.CommentsTemplate.xlsx");
#else
            inputStream = assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.CommentsTemplate.xlsx");
#endif
            MemoryStream stream = new MemoryStream();

            inputStream.CopyTo(stream);

            stream.Position = 0;

            if (Device.RuntimePlatform == Device.UWP)
            {
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("CommentsTemplate.xlsx", "application/msexcel", stream);
            }
            else
            {
                Xamarin.Forms.DependencyService.Get<ISave>().Save("CommentsTemplate.xlsx", "application/msexcel", stream);
            }
        }
        internal void btnConvertToPDF_Clicked(object sender, EventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Xlsx;

            // Initializing Workbook
            Assembly assembly = typeof(App).GetTypeInfo().Assembly;
            Stream fileStream = null;
#if COMMONSB
                fileStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Samples.Template.CommentsTemplate.xlsx");
#else

            fileStream = assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.CommentsTemplate.xlsx");

#endif
            
            IWorkbook workbook = application.Workbooks.Open(fileStream);

            IWorksheet worksheet = workbook.Worksheets[0];

            //Add Comments
            AddComments(worksheet);

            //Set print location of comments
            worksheet.PageSetup.PrintComments = ExcelPrintLocation.PrintSheetEnd;

            XlsIORenderer renderer = new XlsIORenderer();
            
            PdfDocument pdfDocument = renderer.ConvertToPDF(workbook);
            MemoryStream memoryStream = new MemoryStream();
            pdfDocument.Save(memoryStream);
            pdfDocument.Close(true);

            if (Device.RuntimePlatform == Device.UWP)
            {
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("ExcelComments.pdf", "application/pdf", memoryStream);
            }
            else
            {
                Xamarin.Forms.DependencyService.Get<ISave>().Save("ExcelComments.pdf", "application/pdf", memoryStream);
            }
        }

        /// <summary>
        /// Add threaded comments and notes in worksheet.
        /// </summary>
        /// <param name="worksheet"></param>
        private void AddComments(IWorksheet worksheet)
        {
            //Add Comments (Notes)
            IComment comment = worksheet.Range["H1"].AddComment();
            comment.Text = "This Total column comment will be printed at the end of sheet.";
            comment.IsVisible = true;

            //Add Threaded Comments
            IThreadedComment threadedComment = worksheet.Range["H16"].AddThreadedComment("What is the reason for the higher total amount of \"desk\"  in the west region?", "User1", DateTime.Now);
            threadedComment.AddReply("The unit cost of desk is higher compared to other items in the west region. As a result, the total amount is elevated.", "User2", DateTime.Now);
            threadedComment.AddReply("Additionally, Wilson sold 31 desks in the west region, which is also a contributing factor to the increased total amount.", "User3", DateTime.Now);
        }
    }
}