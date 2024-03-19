#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
using System.Collections.Generic;

namespace SampleBrowser.XlsIO
{
    /// <summary>
    /// This class is used for What-If Analysis in worksheet.
    /// </summary>
    public partial class WhatIfAnalysisPage : SampleView
    {
        public WhatIfAnalysisPage()
        {
            InitializeComponent();
            if (Device.Idiom != TargetIdiom.Phone && (Device.RuntimePlatform == Device.UWP))
            {
                this.Content_1.HorizontalOptions = LayoutOptions.Start;
                this.Content_1.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.BackgroundColor = Color.Gray;
                this.btnInputTemplate.HorizontalOptions = LayoutOptions.Start;
                this.btnInputTemplate.VerticalOptions = LayoutOptions.Center;
                this.btnInputTemplate.BackgroundColor = Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                {
                    this.Content_1.FontSize = 13.5;
                }

                this.Content_1.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
                this.btnInputTemplate.VerticalOptions = LayoutOptions.Center;
            }
        }

        private void BtnInputTemplate_Clicked(object sender, System.EventArgs e)
        {
            Assembly assembly = typeof(App).GetTypeInfo().Assembly;

            Stream inputStream = null;
            string fileName = "WhatIfAnalysisTemplate.xlsx";
            string contentType = "application/msexcel";
#if COMMONSB
			inputStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Samples.Template.WhatIfAnalysisTemplate.xlsx");
#else
            inputStream = assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.WhatIfAnalysisTemplate.xlsx");
#endif
            MemoryStream stream = new MemoryStream();

            inputStream.CopyTo(stream);

            stream.Position = 0;

            if (Device.RuntimePlatform == Device.UWP)
            {
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save(fileName, contentType, stream);
            }
            else
            {
                Xamarin.Forms.DependencyService.Get<ISave>().Save(fileName, contentType, stream);
            }
        }

        private void BtnGenerate_Clicked(object sender, System.EventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
#if COMMONSB
			Stream excelStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Samples.Template.WhatIfAnalysisTemplate.xlsx");
#else
            Stream excelStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.WhatIfAnalysisTemplate.xlsx");
#endif
            IWorkbook workbook = application.Workbooks.Open(excelStream);
            IWorksheet worksheet = workbook.Worksheets[0];

            //Initailize list objects with different values for scenarios
            List<object> currentChange_Values = new List<object> { 0.23, 0.8, 1.1, 0.5, 0.35, 0.2, 0.4, 0.37, 1.1, 1, 0.94, 0.75 };
            List<object> increasedChange_Values = new List<object> { 0.45, 0.56, 0.9, 0.5, 0.58, 0.43, 0.39, 0.89, 1.45, 1.2, 0.99, 0.8 };
            List<object> decreasedChange_Values = new List<object> { 0.3, 0.2, 0.5, 0.3, 0.5, 0.23, 0.2, 0.3, 0.8, 0.6, 0.87, 0.4 };

            List<object> currentQuantity_Values = new List<object> { 1500, 3000, 5000, 4000, 500, 4000, 1200, 1500, 750, 750, 1200, 7900 };
            List<object> increasedQuantity_Values = new List<object> { 1000, 5000, 4500, 3900, 10000, 8900, 8000, 3500, 15000, 5500, 4500, 4200 };
            List<object> decreasedQuantity_Values = new List<object> { 1000, 2000, 3000, 3000, 300, 4000, 1200, 1000, 550, 650, 800, 6900 };

            //Add scenarios in the worksheet
            IScenarios scenarios = worksheet.Scenarios;
            scenarios.Add("Current % of Change", worksheet.Range["F5:F16"], currentChange_Values);
            scenarios.Add("Increased % of Change", worksheet.Range["F5:F16"], increasedChange_Values);
            scenarios.Add("Decreased % of Change", worksheet.Range["F5:F16"], decreasedChange_Values);

            scenarios.Add("Current Quantity", worksheet.Range["D5:D16"], currentQuantity_Values);
            scenarios.Add("Increased Quantity", worksheet.Range["D5:D16"], increasedQuantity_Values);
            scenarios.Add("Decreased Quantity", worksheet.Range["D5:D16"], decreasedQuantity_Values);

            //Create Summary
            if (this.IsSummary.IsChecked.Value)
            {
                worksheet.Scenarios.CreateSummary(worksheet.Range["L7"]);
            }

            MemoryStream outputStream = new MemoryStream();
            string fileName = "WhatIfAnalysis.xlsx";
            string contentType = "application/msexcel";

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