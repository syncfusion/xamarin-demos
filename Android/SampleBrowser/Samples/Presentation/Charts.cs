#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Presentation;
using Syncfusion.OfficeChart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COLOR = Syncfusion.Drawing;
using System.IO;
using System.Reflection;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Xml;

namespace SampleBrowser
{
    public partial class ChartsPresentation : SamplePage
    {
        private Context m_context;
        public override View GetSampleContent(Context con)
        {
            LinearLayout linear = new LinearLayout(con);
            linear.SetBackgroundColor(Android.Graphics.Color.White);
            linear.Orientation = Orientation.Vertical;
            linear.SetPadding(10, 10, 10, 10);
            
            TextView text1 = new TextView(con);
            text1.TextSize = 17;
            text1.TextAlignment = TextAlignment.Center;
            text1.SetTextColor(Android.Graphics.Color.ParseColor("#262626"));
            text1.Text = "This sample demonstrates how to create a pie chart in PowerPoint presentation.";
            text1.SetPadding(5, 10, 10, 5);
            linear.AddView(text1);
            
            TextView space = new TextView(con);
            space.TextSize = 10;
            linear.AddView(space);             
            m_context = con;
            
            TextView space2 = new TextView(con);
            space2.TextSize = 10;
            linear.AddView(space2);
            
            Button button1 = new Button(con);
            button1.Text = "Generate Presentation";
            button1.Click += OnButtonClicked;
            linear.AddView(button1);
            
            return linear;
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
			MemoryStream stream = new MemoryStream();
            //Opens the existing presentation stream.
            using (IPresentation presentation = Syncfusion.Presentation.Presentation.Create())
            {
                ISlide slide = presentation.Slides.Add(SlideLayoutType.TitleOnly);
                IParagraph paragraph = ((IShape)slide.Shapes[0]).TextBody.Paragraphs.Add();
                //Apply center alignment to the paragraph
                paragraph.HorizontalAlignment = HorizontalAlignmentType.Center;
                //Add slide title
                ITextPart textPart = paragraph.AddTextPart("Northwind Management Report");
                textPart.Font.Color = ColorObject.FromArgb(46, 116, 181);
                //Get chart data from xml file
                List<ProductDetails> Products = LoadXMLData();
                //Add a new chart to the presentation slide
                IPresentationChart chart = slide.Charts.AddChart(44.64, 133.2, 870.48, 380.16);
                //Set chart type
                chart.ChartType = OfficeChartType.Pie;
                //Set chart title
                chart.ChartTitle = "Best Selling Products";
                //Set chart properties font name and size
                chart.ChartTitleArea.FontName = "Calibri (Body)";
                chart.ChartTitleArea.Size = 14;
                for (int i = 0; i < Products.Count; i++)
                {
                    ProductDetails product = Products[i];
                    chart.ChartData.SetValue(i + 2, 1, product.ProductName);
                    chart.ChartData.SetValue(i + 2, 2, product.Sum);
                }
                //Create a new chart series with the name “Sales”
                AddSeriesForChart(chart);
                //Setting the font size of the legend.
                chart.Legend.TextArea.Size = 14;
                //Setting background color
                chart.ChartArea.Fill.ForeColor = Syncfusion.Drawing.Color.FromArgb(242, 242, 242);
                chart.PlotArea.Fill.ForeColor = Syncfusion.Drawing.Color.FromArgb(242, 242, 242);
                chart.ChartArea.Border.LinePattern = OfficeChartLinePattern.None;
                chart.PrimaryCategoryAxis.CategoryLabels = chart.ChartData[2, 1, 11, 1];
                //Saves the presentation instance to the stream.
                presentation.Save(stream);
            }
            stream.Position = 0;
			if (stream != null)
			{
				SaveAndroid androidSave = new SaveAndroid ();
				androidSave.Save ("Charts.pptx", "application/powerpoint", stream, m_context);
			}
        }
		
		#region Helper Methods
        /// <summary>
        /// Gets list of product details from an XML file
        /// </summary>
        /// <returns></returns>
        private List<ProductDetails> LoadXMLData()
        {
            List<ProductDetails> Products = new List<ProductDetails>();
            ProductDetails productDetails;
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream productXMLStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.Presentation.Templates.Products.xml");
            XmlReader reader = XmlReader.Create(productXMLStream);


            string serailNo = string.Empty;
            string productName = string.Empty;
            string sum = string.Empty;
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    switch (reader.Name)
                    {
                        case "Products":
                            while (reader.Read())
                            {
                                if (reader.IsStartElement())
                                {
                                    switch (reader.Name)
                                    {

                                        case "SNO":
                                            reader.Read();
                                            serailNo = reader.Value;
                                            break;
                                        case "ProductName":
                                            reader.Read();
                                            productName = reader.Value;
                                            break;
                                        case "Sum":
                                            reader.Read();
                                            sum = reader.Value;
                                            productDetails = new ProductDetails(int.Parse(serailNo), productName, decimal.Parse(sum));
                                            Products.Add(productDetails);
                                            break;
                                    }
                                }
                                else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "Products")
                                    break;

                            }
                            break;
                    }
                }
            }
            return Products;
        }

        /// <summary>
        /// Adds the series for the chart.
        /// </summary>
        /// <param name="chart">Represents the chart instance from the presentation.</param>
        private void AddSeriesForChart(IPresentationChart chart)
        {
            //Add a series for the chart.
            IOfficeChartSerie series = chart.Series.Add("Sales");
            series.Values = chart.ChartData[2, 2, 11, 2];
            //Setting data label
            series.DataPoints.DefaultDataPoint.DataLabels.IsValue = true;
            series.DataPoints.DefaultDataPoint.DataLabels.Position = OfficeDataLabelPosition.Outside;
            series.DataPoints.DefaultDataPoint.DataLabels.Size = 14;
        }

        #endregion HelperMethods
    }
	
	#region Helper class
    /// <summary>
    /// Specifies the Product details
    /// </summary>
    public class ProductDetails
	{
		#region fields

		private int m_serialNo;
		private string m_productName;
		private decimal m_sum;

		#endregion

		#region properties

		/// <summary>
		/// Gets or sets the serial number of the product.
		/// </summary>
		public int SNO
		{
			get { return m_serialNo; }
			set { m_serialNo = value; }
		}

		/// <summary>
		/// Gets or sets the name of the product.
		/// </summary>
		public string ProductName
		{
			get { return m_productName; }
			set { m_productName = value; }
		}

		/// <summary>
		/// Gets or sets the sum value of the product.
		/// </summary>
		public decimal Sum
		{
			get { return m_sum; }
			set { m_sum = value; }
		}

		#endregion

		#region Constructor

		/// <summary>
		/// Constructor for the ProductDetails to create a new instance.
		/// </summary>
		/// <param name="serialNumber">Represents the serial number of the product.</param>
		/// <param name="productName">Represents the product name.</param>
		/// <param name="sum">Represents the sum value of the product.</param>
		public ProductDetails(int serialNumber, string productName, decimal sum)
		{
			SNO = serialNumber;
			ProductName = productName;
			Sum = Math.Round(sum, 3);
		}

		#endregion
	}
	#endregion
}
