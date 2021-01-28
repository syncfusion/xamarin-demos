#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Webkit;
using Android.App;
using Android.OS;

namespace SampleBrowser
{
	public partial class WordToHTML : SamplePage
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
		    text1.Text = "This sample demonstrates how to convert the Word document into HTML file.";
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
			button1.Text = "Generate";
			button1.Click += OnButtonClicked;
			linear.AddView (button1);

			return linear;

		}
        void OnButtonClicked(object sender, EventArgs e)
		{
			Assembly assembly = Assembly.GetExecutingAssembly ();
			// Creating a new document.
			WordDocument document = new WordDocument ();
			Stream inputStream = assembly.GetManifestResourceStream ("SampleBrowser.Samples.DocIO.Templates.WordtoHTML.doc");
			//Open the Word document to convert
			document.Open (inputStream, FormatType.Doc);
			//Export the Word document to HTML file
			MemoryStream stream = new MemoryStream ();
			HTMLExport htmlExport = new HTMLExport ();
			htmlExport.SaveAsXhtml (document, stream);
			document.Close ();
			//Set the stream to start position to read the content as string
			stream.Position = 0;
			StreamReader reader = new StreamReader (stream);
			string htmlString = reader.ReadToEnd ();
			Intent i = new Intent (m_context, typeof(WebViewActivity));
			i.PutExtra ("HtmlString", htmlString);
			m_context.StartActivity (i);

		}
	}			
}

