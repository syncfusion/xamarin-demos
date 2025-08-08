#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Java.IO;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using Syncfusion.Pdf.Parsing;
using System.Threading.Tasks;

using Syncfusion.Pdf;
using System.Reflection;
using Syncfusion.Pdf.Security;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Graphics;

namespace SampleBrowser
{
    public partial class ImageInsertion : SamplePage
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
            text2.Text = "This sample demonstrates how to insert images in a PDF document.";
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
            // Create a new instance of PdfDocument class.
            PdfDocument document = new PdfDocument();

            // Add a new page to the newly created document.
            PdfPage page = document.Pages.Add();

            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Bold);

            PdfGraphics g = page.Graphics;
			
			 g.DrawString("JPEG Image", font, PdfBrushes.Blue, new Syncfusion.Drawing.PointF(0, 40));

            //Load JPEG image to stream.
            Stream jpgImageStream = typeof(ImageInsertion).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Assets.Xamarin_JPEG.jpg");

            //Load the JPEG image
            PdfImage jpgImage = new PdfBitmap(jpgImageStream);

            //Draw the JPEG image
            g.DrawImage(jpgImage,new Syncfusion.Drawing.RectangleF(0,70,515,215));           

            g.DrawString("PNG Image", font, PdfBrushes.Blue, new Syncfusion.Drawing.PointF(0, 355));

            //Load PNG image to stream.
            Stream pngImageStream = typeof(ImageInsertion).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Assets.Xamarin_PNG.png");

            //Load the PNG image
            PdfImage pngImage = new PdfBitmap(pngImageStream);
            
			//Draw the PNG image
            g.DrawImage(pngImage,new Syncfusion.Drawing.RectangleF(0,365,199,300));
        
            MemoryStream stream = new MemoryStream();

            //Save the PDF document
            document.Save(stream);
			
			stream.Position = 0;

            //Close the PDF document
            document.Close(true);

            if (stream != null)
            {
			   stream.Position=0;
                SaveAndroid androidSave = new SaveAndroid();
                androidSave.Save("ImageInsertion.pdf", "application/pdf", stream, m_context);

            }
        }		
    }
}