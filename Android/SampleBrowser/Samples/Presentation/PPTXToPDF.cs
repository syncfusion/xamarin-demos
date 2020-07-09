#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Presentation;
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
using Syncfusion.PresentationToPdfConverter;
using Syncfusion.Pdf;

namespace SampleBrowser
{
    public partial class PPTXToPDF : SamplePage
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
            text1.Text = "This sample demonstrates how to convert a PowerPoint presentation to PDF.";
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
            string resourcePath = "SampleBrowser.Samples.Presentation.Templates.Template.pptx";
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            MemoryStream stream = new MemoryStream();
            fileStream.CopyTo(stream);
            fileStream.Dispose();
            stream.Position = 0;
            if (stream != null)
            {
                SaveAndroid androidSave = new SaveAndroid();
                androidSave.Save("InputTemplate.pptx", "application/powerpoint", stream, m_context);
            }
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            string resourcePath = "SampleBrowser.Samples.Presentation.Templates.Template.pptx";
			Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            //Open a existing PowerPoint Presentation.
            IPresentation presentation = Syncfusion.Presentation.Presentation.Open(fileStream);

            //Convert the PowerPoint document to PDF document.
            PdfDocument pdfDocument = PresentationToPdfConverter.Convert(presentation);

            MemoryStream pdfStream = new MemoryStream();

            //Save the converted PDF document into MemoryStream.
            pdfDocument.Save(pdfStream);
            pdfStream.Position = 0;            

            //Close the PDF document.
            pdfDocument.Close(true);

            //Close the PowerPoint Presentation.
            presentation.Close();
			if (pdfStream != null)
			{
				SaveAndroid androidSave = new SaveAndroid ();
				androidSave.Save ("PPTXToPDF.pdf", "application/pdf", pdfStream, m_context);
			}
        }       
    }
}
