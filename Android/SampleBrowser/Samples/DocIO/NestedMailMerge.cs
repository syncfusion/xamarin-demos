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
using System.Collections;

namespace SampleBrowser
{
    public partial class NestedMailMerge : SamplePage
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
            Stream inputStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.DocIO.Templates.Template_Letter.doc");
            //Open Template document
            document.Open(inputStream, FormatType.Word2013);
            inputStream.Dispose();

            inputStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.DocIO.Templates.Employees.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(inputStream);
            ArrayList commands = new ArrayList();

            //DictionaryEntry contain "Source table" (KEY) and "Command" (VALUE)
            DictionaryEntry entry = new DictionaryEntry("Employees", string.Empty);
            commands.Add(entry);

            // To retrive customer details
            DataTable table = ds.Tables["Customers"];
            string relation = table.ParentRelations[0].ChildColumns[0].ColumnName + " = %Employees." + table.ParentRelations[0].ParentColumns[0].ColumnName + "%";
            entry = new DictionaryEntry("Customers", relation);
            commands.Add(entry);

            // To retrieve order details
            table = ds.Tables["Orders"];
            relation = table.ParentRelations[0].ChildColumns[0].ColumnName + " = %Customers." + table.ParentRelations[0].ParentColumns[0].ColumnName + "%";
            entry = new DictionaryEntry("Orders", relation);
            commands.Add(entry);

            //Executes nested Mail merge using explicit relational data.
            document.MailMerge.ExecuteNestedGroup(ds, commands);

            MemoryStream stream = new MemoryStream();
            document.Save(stream, FormatType.Word2013);
            document.Close();
			if (stream != null) 
			{
				SaveAndroid androidSave = new SaveAndroid ();
				androidSave.Save ("NestedMailMerge.docx", "application/msword", stream, m_context);
			}
        }
    }
}
