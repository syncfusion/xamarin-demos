#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.Content;
using Android.Views;
using Android.Widget;
using System.IO;
using Syncfusion.Pdf.Graphics;

using Syncfusion.Pdf;
using Syncfusion.Drawing;
using System.Reflection;

namespace SampleBrowser
{
    public partial class OpenTypeFont : SamplePage
    {
        private Context m_context;
        public override View GetSampleContent(Context con)
        {
            LinearLayout linear = new LinearLayout(con);
            linear.SetBackgroundColor(Android.Graphics.Color.White);
            linear.Orientation = Orientation.Vertical;
            linear.SetPadding(10, 10, 10, 10);
                       
            TextView space = new TextView(con);
            space.TextSize = 10;
            linear.AddView(space);

            TextView text2 = new TextView(con);
            text2.TextSize = 17;
            text2.TextAlignment = TextAlignment.Center;
            text2.Text = "This sample demonstrates how to draw a text with OpenType font in a PDF document.";
            text2.SetTextColor(Android.Graphics.Color.ParseColor("#262626"));
            text2.SetPadding(5, 5, 5, 5);

            linear.AddView(text2);

            TextView space1 = new TextView(con);
            space1.TextSize = 10;
            linear.AddView(space1); 
           
            m_context = con;

            TextView space2 = new TextView(con);
            space2.TextSize = 10;
            linear.AddView(space2);

            Button button1 = new Button(con);
            button1.Text = "Generate PDF";
            button1.Click += OnButtonClicked;
            linear.AddView(button1);

            return linear;
        }
        void OnButtonClicked(object sender, EventArgs e)
        {
            //Create a new PDF document
            PdfDocument document = new PdfDocument();

            //Add a page
            PdfPage page = document.Pages.Add();

            //Create font
            Stream fontStream = typeof(OpenTypeFont).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Assets.NotoSerif-Black.otf");
            PdfFont font = new PdfTrueTypeFont(fontStream, 14);

            //Text to draw          
            string text = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
           
            //Create a brush
            PdfBrush brush = new PdfSolidBrush(new PdfColor(0, 0, 0));
            PdfPen pen = new PdfPen(new PdfColor(0, 0, 0));
            SizeF clipBounds = page.Graphics.ClientSize;
            RectangleF rect = new RectangleF(0, 0, clipBounds.Width, clipBounds.Height);
         
            //Draw text.
            page.Graphics.DrawString(text, font, brush, rect);
            
            MemoryStream stream = new MemoryStream();
            //Save the PDF dcoument.
            document.Save(stream);

            //Close the PDF document.
            document.Close();
			
            stream.Position = 0;

            if (stream != null)
            {
                SaveAndroid androidSave = new SaveAndroid();
                androidSave.Save("OpenTypeFont.pdf", "application/pdf", stream, m_context);
            }
        }
    }
}