#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using SampleBrowser.Core;
using System.IO;
using System.Reflection;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using Syncfusion.OfficeChart;
using Xamarin.Forms;

namespace SampleBrowser.DocIO
{
    public partial class DocIO_BarChart : SampleView
    {
        public DocIO_BarChart()
        {
            InitializeComponent();

            if (Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
               
                this.Content_1.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.HorizontalOptions = LayoutOptions.Start;

                
                this.Content_1.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
				this.btnGenerate.BackgroundColor = Xamarin.Forms.Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
               //if (!SampleBrowser.DocIO.App.isUWP)
                //{
                  //  this.Content_1.FontSize = 18.5;
                //}
                //else
                //{
                    this.Content_1.FontSize = 13.5;
                //}
                
                this.Content_1.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
            }
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            Assembly assembly = typeof(DocIO_BarChart).GetTypeInfo().Assembly;
            //A new document is created.
            WordDocument document = new WordDocument();
            //Add new section to the Word document
            IWSection section = document.AddSection();
            //Set page margins of the section
            section.PageSetup.Margins.All = 72;
            //Add new paragraph to the section
            IWParagraph paragraph = section.AddParagraph();
            //Apply heading style to the title paragraph
            paragraph.ApplyStyle(BuiltinStyle.Heading1);
            //Apply center alignment to the paragraph
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            //Append text to the paragraph
            paragraph.AppendText("Northwind Management Report").CharacterFormat.TextColor = Syncfusion.Drawing.Color.FromArgb(46, 116, 181);
            //Add new paragraph
            paragraph = section.AddParagraph();
            //Set before spacing to the paragraph
            paragraph.ParagraphFormat.BeforeSpacing = 20;
#if COMMONSB
            string rootPath = "SampleBrowser.Samples.DocIO.Samples.Templates.";
#else
            string rootPath = "SampleBrowser.DocIO.Samples.Templates.";
#endif
            //Load the excel template as stream
            Stream excelStream = assembly.GetManifestResourceStream(rootPath + "Excel_Template.xlsx");
            //Create and Append chart to the paragraph with excel stream as parameter
            WChart barChart = paragraph.AppendChart(excelStream, 1, "B2:C6", 470, 300);
            //Set chart data
            barChart.ChartType = OfficeChartType.Bar_Clustered;
            barChart.ChartTitle = "Purchase Details";
            barChart.ChartTitleArea.FontName = "Calibri (Body)";
            barChart.ChartTitleArea.Size = 14;
            //Set name to chart series            
            barChart.Series[0].Name = "Sum of Purchases";
            barChart.Series[1].Name = "Sum of Future Expenses";
            //Set Chart Data table
            barChart.HasDataTable = true;
            barChart.DataTable.HasBorders = true;
            barChart.DataTable.HasHorzBorder = true;
            barChart.DataTable.HasVertBorder = true;
            barChart.DataTable.ShowSeriesKeys = true;
            barChart.HasLegend = false;
            //Setting background color
            barChart.ChartArea.Fill.ForeColor = Syncfusion.Drawing.Color.FromArgb(208, 206, 206);
            barChart.PlotArea.Fill.ForeColor = Syncfusion.Drawing.Color.FromArgb(208, 206, 206);
            //Setting line pattern to the chart area
            barChart.PrimaryCategoryAxis.Border.LinePattern = OfficeChartLinePattern.None;
            barChart.PrimaryValueAxis.Border.LinePattern = OfficeChartLinePattern.None;
            barChart.ChartArea.Border.LinePattern = OfficeChartLinePattern.None;
            barChart.PrimaryValueAxis.MajorGridLines.Border.LineColor = Syncfusion.Drawing.Color.FromArgb(175, 171, 171);
            //Set label for primary catagory axis
            barChart.PrimaryCategoryAxis.CategoryLabels = barChart.ChartData[2, 1, 6, 1];
            #region Saving Document
            MemoryStream stream = new MemoryStream();
            document.Save(stream, FormatType.Word2013);
            document.Close();
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("BarChart.docx", "application/msword", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("BarChart.docx", "application/msword", stream);
            #endregion
        }
    }
}
