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
using Syncfusion.Pdf.Interactive;

namespace SampleBrowser
{
    public partial class Conformance : SamplePage
    {
        private Context m_context;
        private Spinner m_conformance;
        private LinearLayout advancedLinear1;
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
            text2.Text = "This sample demonstrates various PDF conformance support in Essential PDF.";
            text2.SetTextColor(Android.Graphics.Color.ParseColor("#262626"));
            text2.SetPadding(5, 5, 5, 5);

            linear.AddView(text2);
            TextView text3 = new TextView(con);
            text3.TextSize = 19;
            text3.TextAlignment = TextAlignment.Center;
            text3.Text = "Please select the conformance";
            text3.SetTextColor(Android.Graphics.Color.ParseColor("#262626"));
            text3.SetPadding(5, 100, 5, 5);

            linear.AddView(text3);
            advancedLinear1 = new LinearLayout(con);

            TextView space1 = new TextView(con);
            space1.TextSize = 10;
            linear.AddView(space1); 
           
            string[] list1 = { "PDF/A-1a", "PDF/A-1b", "PDF/A-2a", "PDF/A-2b", "PDF/A-2u", "PDF/A-3a", "PDF/A-3b" , "PDF/A-3u"};
            ArrayAdapter<String> array1 = new ArrayAdapter<String>(con, Android.Resource.Layout.SimpleSpinnerItem, list1);
            m_conformance = new Spinner(con);
            m_conformance.Adapter = array1;
            m_conformance.SetSelection(0);
            advancedLinear1.AddView(m_conformance);
            advancedLinear1.SetPadding(320,0,5,5);
            linear.AddView(advancedLinear1);

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
            PdfDocument document =null;
            if(this.m_conformance.SelectedItemPosition == 0)
            {
                //Create a new PDF document
                document = new PdfDocument(PdfConformanceLevel.Pdf_A1A);
            }
            else if(this.m_conformance.SelectedItemPosition == 1)
            {
                document = new PdfDocument(PdfConformanceLevel.Pdf_A1B);
            }
			else if(this.m_conformance.SelectedItemPosition == 2)
            {
                document = new PdfDocument(PdfConformanceLevel.Pdf_A2A);
            }
			else if(this.m_conformance.SelectedItemPosition == 3)
            {
                document = new PdfDocument(PdfConformanceLevel.Pdf_A2B);
            }
            else if(this.m_conformance.SelectedItemPosition == 4)
            {
                document = new PdfDocument(PdfConformanceLevel.Pdf_A2U);
            }
            else 
            {
				if (this.m_conformance.SelectedItemPosition == 5)
				{
                document = new PdfDocument(PdfConformanceLevel.Pdf_A3A);
				}
				else if (this.m_conformance.SelectedItemPosition == 6)
				{
                document = new PdfDocument(PdfConformanceLevel.Pdf_A3B);
				}
				else if (this.m_conformance.SelectedItemPosition == 7)
				{
                document = new PdfDocument(PdfConformanceLevel.Pdf_A3U);
				}
				Stream imgStream = typeof(Conformance).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Assets.Products.xml");

                PdfAttachment attachment = new PdfAttachment("PDF_A.xml",imgStream);
                attachment.Relationship = PdfAttachmentRelationship.Alternative;
                attachment.ModificationDate = DateTime.Now;

                attachment.Description = "PDF_A";

                attachment.MimeType = "application/xml";

                document.Attachments.Add(attachment);
            }

            //Add a page
            PdfPage page = document.Pages.Add();

            //Create font
            Stream arialFontStream = typeof(Conformance).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Assets.arial.ttf");
            Stream imageStream = typeof(Conformance).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.DocIO.Templates.AdventureCycle.jpg");

            PdfFont font = new PdfTrueTypeFont(arialFontStream, 14);

            //Create PDF graphics for the page.
            PdfGraphics graphics = page.Graphics;
            //Load the image from the disk.
            PdfImage img = PdfImage.FromStream(imageStream);
            //Draw the image in the specified location and size.
            graphics.DrawImage(img, new RectangleF(150, 30, 200, 100));


            PdfTextElement textElement = new PdfTextElement("Adventure Works Cycles, the fictitious company on which the AdventureWorks sample databases are based," +
                      " is a large, multinational manufacturing company. The company manufactures and sells metal and composite bicycles to North American, " +
                      "European and Asian commercial markets. While its base operation is located in Bothell, Washington with 290 employees, several regional" +
                      " sales teams are located throughout their market base.")
            {
                Font = font
            };
            PdfLayoutResult layoutResult = textElement.Draw(page, new RectangleF(0, 150, page.GetClientSize().Width, page.GetClientSize().Height));



            MemoryStream stream = new MemoryStream();
            //Save the PDF dcoument.
            document.Save(stream);

            //Close the PDF document.
            document.Close();
			
            stream.Position = 0;

            if (stream != null)
            {
                SaveAndroid androidSave = new SaveAndroid();
                androidSave.Save("PDF_Ab.pdf", "application/pdf", stream, m_context);
            }
        }
    }
}