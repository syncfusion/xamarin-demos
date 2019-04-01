#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
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

namespace SampleBrowser
{
    public partial class XMLMapping: SamplePage
    {
		private Context m_context;
		public override View GetSampleContent (Context con)
		{
			LinearLayout linear = new LinearLayout(con);
			linear.SetBackgroundColor(Color.White);
			linear.Orientation = Orientation.Vertical;
			linear.SetPadding(10, 10, 10, 10);

			TextView text1 = new TextView(con);
			text1.TextSize = 17;
			text1.TextAlignment = TextAlignment.Center;
			text1.SetTextColor(Color.ParseColor("#262626"));
			text1.Text = "This sample demonstrates how to map custom XML part to content controls in the Word document.";
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
        void OnButtonClicked(object sender, EventArgs e)
        {
			Assembly assembly = Assembly.GetExecutingAssembly();
            
            Stream inputStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.DocIO.Templates.Employees.xml");
            // Create a new document.
            WordDocument document = new WordDocument();

            //Add a section & a paragraph in the empty document.
            document.EnsureMinimal();

            //Loads XML file into the customXML part of the Word document.
            CustomXMLPart docIOxmlPart = new CustomXMLPart(document);
            docIOxmlPart.Load(inputStream);

            //Insert content controls and maps Employees details to it.
            InsertAndMapEmployees(document, "EmployeesList", docIOxmlPart);

            MemoryStream stream = new MemoryStream();
            document.Save(stream, FormatType.Word2013);
            document.Close();
			if (stream != null) 
			{
				SaveAndroid androidSave = new SaveAndroid ();
				androidSave.Save ("XMLMapping.docx", "application/msword", stream, m_context);
			}
        }

        #region Helpher Methods       
        /// <summary>
        /// Insert and Maps CustomXMLPart to content control based on XPath.
        /// </summary>
        /// <param name="paragraph">Paragraph instance to append content control.</param>
        /// <param name="XPath">XPath of the CustomXMLNode to be mapped</param>
        /// <param name="custXMLPart">CustomXMLPart of the CustomXMLNode</param>
        private void MapCustomXMLPart(IWParagraph paragraph, string XPath, CustomXMLPart custXMLPart)
        {
            IInlineContentControl contentControl = paragraph.AppendInlineContentControl(ContentControlType.Text);
            contentControl.ContentControlProperties.XmlMapping.SetMapping(XPath, string.Empty, custXMLPart);
        }
        /// <summary>
        /// Inserts content control and maps the employees details to it. 
        /// </summary>
        /// <param name="document">Word document instance.</param>
        /// <param name="xmlRootPath">Custom XML root Xpath.</param>
        /// <param name="docIOxmlPart">CustomXMLPart instance.</param>
        private void InsertAndMapEmployees(WordDocument document, string xmlRootPath, CustomXMLPart docIOxmlPart)
        {
            //Retrieving CustomXMLNode from xmlRootPath.
            CustomXMLNode parentNode = docIOxmlPart.SelectSingleNode(xmlRootPath);

            int empIndex = 1;
            foreach (CustomXMLNode employeeNode in parentNode.ChildNodes)
            {
                if (employeeNode.HasChildNodes())
                {
                    //Adds new paragraph to the section
                    IWParagraph paragraph = document.LastSection.AddParagraph();
                    paragraph.ParagraphFormat.BackColor = Syncfusion.Drawing.Color.Gray;

                    IWTextRange textrange = paragraph.AppendText("Employee");
                    textrange.CharacterFormat.TextColor = Syncfusion.Drawing.Color.White;
                    textrange.CharacterFormat.Bold = true;
                    textrange.CharacterFormat.FontSize = 14;

                    //Insert content controls and maps Employee details to it.
                    InsertAndMapEmployee(document, employeeNode, xmlRootPath, docIOxmlPart, empIndex);
                }
                empIndex++;
            }
        }
        /// <summary>
        /// Inserts content control and maps the employee details to it.
        /// </summary>
        /// <param name="document">Word document instance.</param>
        /// <param name="employeesNode">CustomXMLNode of employee.</param>
        /// <param name="rootXmlPath">Custom XML root Xpath.</param>
        /// <param name="docIOxmlPart">CustomXMLPart instance.</param>
        /// <param name="empIndex">Current employee index.</param>
        private void InsertAndMapEmployee(WordDocument document, CustomXMLNode employeesNode, string rootXmlPath, CustomXMLPart docIOxmlPart, int empIndex)
        {
            //Column names of Employee element.
            string[] employeesDetails = { "FirstName", "LastName", "Employee ID", "Extension", "Address", "City", "Country" };
            int empChildIndex = 0;
            int customerIndex = 1;

            // Append current empolyee XPath with root XPath.
            string empPath = "/" + rootXmlPath + "/Employees[" + empIndex + "]/";
            // Iterating child elements of Employee
            foreach (CustomXMLNode employeeChild in employeesNode.ChildNodes)
            {
                IWParagraph paragraph = document.LastParagraph;
                if (employeeChild.HasChildNodes())
                {
                    //Insert a content controls and maps Customer details to it.
                    InsertAndMapCustomer(document, employeeChild, docIOxmlPart, empPath, customerIndex);
                    customerIndex++;
                }
                else
                {
                    if (empChildIndex != 1)
                    {
                        //Insert a content controls and maps Employee details other than Customer details to it.
                        paragraph = document.LastSection.AddParagraph();
                        if (empChildIndex == 0)
                            paragraph.AppendText("Name: ");
                        else
                            paragraph.AppendText(employeesDetails[empChildIndex] + ": ");
                    }
                    else
                        paragraph.AppendText(" ");
                    MapCustomXMLPart(paragraph, empPath + employeesDetails[empChildIndex].Replace(" ",""), docIOxmlPart);
                }
                empChildIndex++;
            }
        }
        /// <summary>
        /// Insert a content controls and maps Customer details to it.
        /// </summary>
        /// <param name="document">Word document instance.</param>
        /// <param name="customerNode">CustomXMLNode of customer.</param>
        /// <param name="docIOxmlPart">CustomXMLPart instance.</param>
        /// <param name="empPath">Current employee index.</param>
        /// <param name="custIndex">Current customer index.</param>
        private void InsertAndMapCustomer(WordDocument document, CustomXMLNode customerNode, CustomXMLPart docIOxmlPart, string empPath, int custIndex)
        {
            //Column names of Customer element.
            string[] customersDetails = { "Customer ID", "Employee ID", "Company Name", "Contact Name", "City", "Country" };

            document.LastSection.AddParagraph();

            //Adds new paragraph to the section
            IWParagraph paragraph = document.LastSection.AddParagraph();
            paragraph.ParagraphFormat.BackColor = Syncfusion.Drawing.Color.Green;
            paragraph.ParagraphFormat.LeftIndent = 72;

            IWTextRange textrange = paragraph.AppendText("Customers");
            textrange.CharacterFormat.TextColor = Syncfusion.Drawing.Color.White;
            textrange.CharacterFormat.Bold = true;
            textrange.CharacterFormat.FontSize = 14;

            int orderIndex = 1;
            int custChild = 0;
            bool isFirstOrder = true;
            string customerXpath = empPath + "Customers[" + custIndex + "]/";
            foreach (CustomXMLNode customerChild in customerNode.ChildNodes)
            {
                if (customerChild.HasChildNodes())
                {
                    //Insert a content controls and maps Orders details to it.
                    InsertAndMapOrders(document, customerChild, docIOxmlPart, customerXpath, orderIndex, isFirstOrder);
                    document.LastSection.AddParagraph();
                    isFirstOrder = false;
                    orderIndex++;
                }
                else
                {
                    //Insert a content controls and maps Customer details other than Order details to it.
                    paragraph = document.LastSection.AddParagraph();
                    paragraph.ParagraphFormat.LeftIndent = 72;

                    paragraph.AppendText(customersDetails[custChild] + ": ");
                    MapCustomXMLPart(paragraph, customerXpath + customersDetails[custChild].Replace(" ", ""), docIOxmlPart);
                }
                custChild++;
            }
        }
        /// <summary>
        /// Insert a content controls and maps Orders details to it.
        /// </summary>
        /// <param name="document">Word document instance.</param>
        /// <param name="orderNode">CustomXMLNode of order.</param>
        /// <param name="docIOxmlPart">CustomXMLPart instance.</param>
        /// <param name="custPath">Current customer index</param>
        /// <param name="orderIndex">Current order index</param>
        /// <param name="isFirst">Indicates whether it is the first order of the customer.</param>
        private void InsertAndMapOrders(WordDocument document, CustomXMLNode orderNode, CustomXMLPart docIOxmlPart, string custPath, int orderIndex, bool isFirst)
        {
            //Column names of order element.
            string[] ordersDetails = { "Order ID", "Customer ID", "Order Date", "Shipped Date", "Required Date" };

            IWParagraph paragraph = null;
            IWTextRange textrange = null;
            if (isFirst)
            {
                document.LastSection.AddParagraph();
                //Adds new paragraph to the section
                paragraph = document.LastSection.AddParagraph();
                paragraph.ParagraphFormat.BackColor = Syncfusion.Drawing.Color.Red;
                paragraph.ParagraphFormat.LeftIndent = 128;

                textrange = paragraph.AppendText("Orders");
                textrange.CharacterFormat.TextColor = Syncfusion.Drawing.Color.White;
                textrange.CharacterFormat.Bold = true;
                textrange.CharacterFormat.FontSize = 14;
            }
            int orderChildIndex = 0;
            string customerXpath = custPath + "Orders[" + orderIndex + "]/";
            foreach (CustomXMLNode orderChild in orderNode.ChildNodes)
            {
                //Adds new paragraph to the section
                paragraph = document.LastSection.AddParagraph();
                paragraph.ParagraphFormat.LeftIndent = 128;

                paragraph.AppendText(ordersDetails[orderChildIndex] + ": ");
                MapCustomXMLPart(paragraph, customerXpath + "/" + ordersDetails[orderChildIndex].Replace(" ", ""), docIOxmlPart);
                orderChildIndex++;
            }
        }
        # endregion
    }
}
