#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.OfficeChart;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;
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
	public partial class WordToPDF : SamplePage
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
            text1.Text = "This sample demonstrates how to convert the Word document into PDF.";
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
            button1.Text = "Input Template";
            button1.Click += OnInpTemplateButtonClicked;
            linear.AddView(button1);

            Button button2 = new Button(con);
            button2.Text = "Convert";
            button2.Click += OnButtonClicked;
            linear.AddView(button2);

            return linear;
        }

        void OnInpTemplateButtonClicked(object sender, EventArgs e)
        {
            string resourcePath = "SampleBrowser.Samples.DocIO.Templates.WordtoPDF.docx";
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            MemoryStream stream = new MemoryStream();
            fileStream.CopyTo(stream);
            fileStream.Dispose();
            stream.Position = 0;
            if (stream != null)
            {
                SaveAndroid androidSave = new SaveAndroid();
                androidSave.Save("WordtoPDF.docx", "application/msword", stream, m_context);
            }
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            string resourcePath = "SampleBrowser.Samples.DocIO.Templates.WordtoPDF.docx";
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            // Loads the stream into Word Document.
            WordDocument wordDocument = new WordDocument(fileStream, Syncfusion.DocIO.FormatType.Automatic);

            //Instantiation of DocIORenderer for Word to PDF conversion
            DocIORenderer render = new DocIORenderer();

            //Sets Chart rendering Options.
            render.Settings.ChartRenderingOptions.ImageFormat = ExportImageFormat.Jpeg;

            //Converts Word document into PDF document
            PdfDocument pdfDocument = render.ConvertToPDF(wordDocument);

            //Releases all resources used by the Word document and DocIO Renderer objects
            render.Dispose();

            wordDocument.Dispose();

            MemoryStream pdfStream = new MemoryStream();

            //Save the converted PDF document into MemoryStream.
            pdfDocument.Save(pdfStream);
            pdfStream.Position = 0;

            //Close the PDF document.
            pdfDocument.Close(true);
            
            if (pdfStream != null)
            {
                SaveAndroid androidSave = new SaveAndroid();
                androidSave.Save("WordtoPDF.pdf", "application/pdf", pdfStream, m_context);
            }
        }
    }			
}

