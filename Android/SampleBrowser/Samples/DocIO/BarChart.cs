#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
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
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using Syncfusion.Drawing;
using Syncfusion.OfficeChart;

namespace SampleBrowser
{
	public partial class BarChart : SamplePage
    {
		private Context m_context;
		public override View GetSampleContent (Context con)
		{
			LinearLayout linear = new LinearLayout(con);
			linear.SetBackgroundColor(Android.Graphics.Color.White);
			linear.Orientation = Orientation.Vertical;
			linear.SetPadding(10, 10, 10, 10);

			TextView text1 = new TextView(con);
			text1.TextSize = 17;
			text1.TextAlignment = TextAlignment.Center;
			text1.SetTextColor(Android.Graphics.Color.ParseColor("#262626"));
			text1.Text = "This sample demonstrates how to create a bar chart in a Word document with the data from an existing Excel file.";
			text1.SetPadding(5, 5, 5, 5);
			linear.AddView(text1);

			TextView space1 = new TextView (con);
			space1.TextSize = 10;
			linear.AddView (space1);
			
			m_context = con;

			TextView space2 = new TextView (con);
			space2.TextSize = 10;
			linear.AddView (space2);

			Button button1 = new Button (con);
			button1.Text = "Generate Word";
			button1.Click += OnButtonClicked;
			linear.AddView (button1);

			return linear;

		}


        private void OnButtonClicked(object sender, EventArgs e)
        {
			Assembly assembly = Assembly.GetExecutingAssembly ();
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
            //Load the excel template as stream
            Stream excelStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.DocIO.Templates.Excel_Template.xlsx");
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
			if (stream != null)
			{
				SaveAndroid androidSave = new SaveAndroid ();
				androidSave.Save ("BarChart.docx", "application/msword", stream, m_context);
			}
            #endregion
		}
	}
}