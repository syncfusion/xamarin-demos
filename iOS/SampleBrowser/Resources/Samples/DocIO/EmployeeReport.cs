#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
using System.Collections.Generic;


#endregion
using System;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System.IO;
using COLOR = Syncfusion.Drawing;
using System.Reflection;
using System.Data;
#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using CGRect = System.Drawing.RectangleF;
using CGPoint = System.Drawing.PointF;
using CGSize = System.Drawing.SizeF;
#endif

namespace SampleBrowser
{
    public partial class EmployeeReport : SampleView
    {
        CGRect frameRect = new CGRect();
        float frameMargin = 8.0f;
        UILabel label;
        UIButton button;

        public EmployeeReport()
        {
            label = new UILabel();
            button = new UIButton(UIButtonType.System);
            button.TouchUpInside += OnButtonClicked;
        }

        void LoadAllowedTextsLabel()
        {
            label.Frame = frameRect;
            label.TextColor = UIColor.FromRGB(38 / 255.0f, 38 / 255.0f, 38 / 255.0f);
            label.Text = "This sample demonstrates how to create a letter format document by filling the data using Mail merge functionality of DocIO.";
            label.Lines = 0;
            label.Font = UIFont.SystemFontOfSize(15);
            label.LineBreakMode = UILineBreakMode.WordWrap;
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                label.Font = UIFont.SystemFontOfSize(18);
                label.Frame = new CGRect(5, 5, frameRect.Location.X + frameRect.Size.Width, 70);
            }
            else
            {
                label.Frame = new CGRect(frameRect.Location.X, 5, frameRect.Size.Width, 70);
            }
            this.AddSubview(label);

            button.SetTitle("Generate Word", UIControlState.Normal);
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                button.Frame = new CGRect(5, 90, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            else
            {
                button.Frame = new CGRect(frameRect.Location.X, 90, frameRect.Size.Width, 10);
            }
            button.TouchUpInside += OnButtonClicked;
            this.AddSubview(button);
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

            System.Data.DataTable table = GetDataTable();
            //Uses the mail merge events handler for image fields

            document.MailMerge.MergeImageField += new MergeImageFieldEventHandler(MergeField_ProductImage);

            document.MailMerge.ExecuteGroup(table);

            MemoryStream stream = new MemoryStream();
            document.Save(stream, FormatType.Word2013);
            document.Close();
            if (stream != null)
            {
                SaveiOS iOSSave = new SaveiOS();
                iOSSave.Save("MailMerge.docx", "application/msword", stream);
            }
        }
        public override void LayoutSubviews()
        {
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                frameMargin = 0.0f;
            }
            frameRect = Frame;
            frameRect.Location = new CGPoint(frameRect.Location.X + frameMargin, frameRect.Location.Y + 1.5f * frameMargin);
            frameRect.Size = new CGSize(frameRect.Size.Width - (frameRect.Location.X + frameMargin), frameRect.Size.Height - (frameRect.Location.Y + 1.5f * frameMargin));
            LoadAllowedTextsLabel();
            base.LayoutSubviews();
        }

        /// <summary>
        /// Gets the Employees record in DataTable format
        /// </summary>
        /// <returns></returns>
        private System.Data.DataTable GetDataTable()
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
            System.Data.DataTable table = ds.Tables["Employees"];
            return table;
        }
        /// <summary>
        /// Execute the MergeImageFieldEvent to merge the images to corresponding image fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void MergeField_ProductImage(object sender, MergeImageFieldEventArgs args)

        {
            Assembly assembly = typeof(MailMerge).GetTypeInfo().Assembly;
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