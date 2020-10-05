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
using System.Data;

namespace SampleBrowser
{
    public partial class EmployeeList_MailMerge : SamplePage
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
			text1.Text = "This sample demonstrates how to create a letter format document by filling the data using Mail merge functionality of DocIO.";
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
            // Creating a new document.
            WordDocument document = new WordDocument();
            Stream inputStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.DocIO.Templates.EmployeesReportDemo.doc");
            //Open Template document
            document.Open(inputStream, FormatType.Word2013);
            inputStream.Dispose();

            DataTable table = GetDataTable();
            //Uses the mail merge events handler for image fields

            document.MailMerge.MergeImageField += new MergeImageFieldEventHandler(MergeField_ProductImage);

            document.MailMerge.ExecuteGroup(table);

            MemoryStream stream = new MemoryStream();
            document.Save(stream, FormatType.Word2013);
            document.Close();
			if (stream != null) 
			{
				SaveAndroid androidSave = new SaveAndroid ();
				androidSave.Save ("EmployeeReport.docx", "application/msword", stream, m_context);
			}
        }

        /// <summary>
        /// Gets the Employees record in DataTable format
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataTable()
        {
            //Data source
            DataSet ds = new DataSet();
            ds.Tables.Add();
            //Defining columns
            ds.Tables[0].TableName = "Employees";
            ds.Tables[0].Columns.Add("Photo");
            ds.Tables[0].Columns.Add("FirstName");
            ds.Tables[0].Columns.Add("LastName");
            ds.Tables[0].Columns.Add("Title");
            ds.Tables[0].Columns.Add("Address");
            ds.Tables[0].Columns.Add("City");
            ds.Tables[0].Columns.Add("Region");
            ds.Tables[0].Columns.Add("Country");
            ds.Tables[0].Columns.Add("PostalCode");
            ds.Tables[0].Columns.Add("HomePhone");
            ds.Tables[0].Columns.Add("Extension");
            ds.Tables[0].Columns.Add("BirthDate");
            //Set values.
            DataRow row;
            row = ds.Tables["Employees"].NewRow();
            row["Photo"] = "SampleImage.png";
            row["FirstName"] = "Nancy";
            row["LastName"] = "Davolio";
            row["Title"] = "Sales Representative";
            row["Address"] = "507 - 20th Ave. E.Apt. 2A";
            row["City"] = "Seattle";
            row["Region"] = "WA";
            row["Country"] = "USA";
            row["PostalCode"] = "98122";
            row["HomePhone"] = "(206) 555-9857";
            row["Extension"] = "5467";
            row["BirthDate"] = "08-12-1948 12:00:00 AM";
            ds.Tables["Employees"].Rows.Add(row);

            row = ds.Tables["Employees"].NewRow();
            row["Photo"] = "SampleImage.png";
            row["FirstName"] = "Andrew";
            row["LastName"] = "Fuller";
            row["Title"] = "Vice President, Sales";
            row["Address"] = "507 - 20th Ave. E.Apt. 2A";
            row["City"] = "Tacoma";
            row["Region"] = "WA";
            row["Country"] = "USA";
            row["PostalCode"] = "98401";
            row["HomePhone"] = "(206) 555-9842";
            row["Extension"] = "3457";
            row["BirthDate"] = "19-02-1952 12:00:00 AM";
            ds.Tables["Employees"].Rows.Add(row);

            row = ds.Tables["Employees"].NewRow();
            row["Photo"] = "SampleImage.png";
            row["FirstName"] = "Janet";
            row["LastName"] = "Leverling";
            row["Title"] = "Sales Representative";
            row["Address"] = "722 Moss Bay Blvd";
            row["City"] = "Kirkland";
            row["Region"] = "WA";
            row["Country"] = "USA";
            row["PostalCode"] = "98033";
            row["HomePhone"] = "(206) 555-3412";
            row["Extension"] = "3355";
            row["BirthDate"] = "30-08-1963 12:00:00 AM";
            ds.Tables["Employees"].Rows.Add(row);
            DataTable table = ds.Tables["Employees"];
            return table;
        }
        /// <summary>
        /// Execute the MergeImageFieldEvent to merge the images to corresponding image fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void MergeField_ProductImage(object sender, MergeImageFieldEventArgs args)

        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string rootPath = "SampleBrowser.Samples.DocIO.Templates.";
    
            //Binds image from file system during mail merge

            if (args.FieldName == "Photo")

            {

                string ProductFileName = args.FieldValue.ToString();

                Stream inputStream = assembly.GetManifestResourceStream(rootPath + ProductFileName);

                args.ImageStream = inputStream;

            }

        }
    }
}
