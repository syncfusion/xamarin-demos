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
using System.Xml;

namespace SampleBrowser
{
    public partial class PieChart : SamplePage
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
		    text1.Text = "This sample demonstrates how to create a pie chart in a Word document.";
			text1.SetPadding(5, 10, 10, 5);
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
			Assembly assembly = Assembly.GetExecutingAssembly();
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
            //Get chart data from xml file
            List<ProductDetail> Products = LoadXMLData();
            //Create and Append chart to the paragraph
            WChart pieChart = document.LastParagraph.AppendChart(446, 270);
            //Set chart data
            pieChart.ChartType = OfficeChartType.Pie;
            pieChart.ChartTitle = "Best Selling Products";
            pieChart.ChartTitleArea.FontName = "Calibri (Body)";
            pieChart.ChartTitleArea.Size = 14;
            for (int i = 0; i < Products.Count; i++)
            {
                ProductDetail product = Products[i];
                pieChart.ChartData.SetValue(i + 2, 1, product.ProductName);
                pieChart.ChartData.SetValue(i + 2, 2, product.Sum);
            }
            //Create a new chart series with the name “Sales”
            IOfficeChartSerie pieSeries = pieChart.Series.Add("Sales");
            pieSeries.Values = pieChart.ChartData[2, 2, 11, 2];
            //Setting data label
            pieSeries.DataPoints.DefaultDataPoint.DataLabels.IsPercentage = true;
            pieSeries.DataPoints.DefaultDataPoint.DataLabels.Position = OfficeDataLabelPosition.Outside;
            //Setting background color
            pieChart.ChartArea.Fill.ForeColor = Syncfusion.Drawing.Color.FromArgb(242, 242, 242);
            pieChart.PlotArea.Fill.ForeColor = Syncfusion.Drawing.Color.FromArgb(242, 242, 242);
            pieChart.ChartArea.Border.LinePattern = OfficeChartLinePattern.None;
            pieChart.PrimaryCategoryAxis.CategoryLabels = pieChart.ChartData[2, 1, 11, 1];
            MemoryStream stream = new MemoryStream();
            document.Save(stream, FormatType.Word2013);
            document.Close();

			if (stream != null) 
			{
				SaveAndroid androidSave = new SaveAndroid ();
				androidSave.Save ("PieChart.docx", "application/msword", stream, m_context);
			}
        }

        private List<ProductDetail> LoadXMLData ()
		{
           
			List<ProductDetail> Products = new List<ProductDetail> ();
			ProductDetail productDetails;
			Assembly assembly = Assembly.GetExecutingAssembly ();
			Stream productXMLStream = assembly.GetManifestResourceStream ("SampleBrowser.Samples.DocIO.Templates.Products.xml");
			XmlReader reader = XmlReader.Create (productXMLStream);

           
			string serailNo = string.Empty;
			string productName = string.Empty;
			string sum = string.Empty;
			while (reader.Read ()) {
				if (reader.IsStartElement ()) {
					switch (reader.Name) {
					case "Products":
						while (reader.Read ()) {
							if (reader.IsStartElement ()) {
								switch (reader.Name) {
                        
								case "SNO":
									reader.Read ();
									serailNo = reader.Value;
									break;
								case "ProductName":
									reader.Read ();
									productName = reader.Value;
									break;
								case "Sum":
									reader.Read ();
									sum = reader.Value;
									productDetails = new ProductDetail (int.Parse (serailNo), productName, decimal.Parse (sum));
									Products.Add (productDetails);
									break;
								}
							} else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "Products")
								break;

						}
						break;
					}
				}
			}
			return Products;
		}

	}

    public class ProductDetail
    {
        #region fields

        private int m_serialNo;
        private string m_productName;
        private decimal m_sum;

        #endregion

        #region properties

        public int SNO
        {
            get { return m_serialNo; }
            set { m_serialNo = value; }
        }

        public string ProductName
        {
            get { return m_productName; }
            set { m_productName = value; }
        }

        public decimal Sum
        {
            get { return m_sum; }
            set { m_sum = value; }
        }

        #endregion

        #region Constructor

        public ProductDetail(int serialNumber, string productName, decimal sum)
        {
            SNO = serialNumber;
            ProductName = productName;
            Sum = Math.Round(sum, 3);
        }

        #endregion
    }
}
