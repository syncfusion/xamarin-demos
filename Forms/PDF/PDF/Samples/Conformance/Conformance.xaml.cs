#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Xamarin.Forms;
using System.IO;
using SampleBrowser.Core;
using System.Reflection;
using Syncfusion.Pdf.Interactive;

namespace SampleBrowser.PDF
{
    public partial class Conformance : SampleView
    {
        public Conformance()
        {
            InitializeComponent();
            this.comformance.Items.Add("PDF/A-1a");
            this.comformance.Items.Add("PDF/A-1b");
            this.comformance.Items.Add("PDF/A-2a");
            this.comformance.Items.Add("PDF/A-2b");
            this.comformance.Items.Add("PDF/A-2u");
            this.comformance.Items.Add("PDF/A-3a");
            this.comformance.Items.Add("PDF/A-3b");
            this.comformance.Items.Add("PDF/A-3u");
            this.comformance.SelectedIndex = 0;
            if (Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Description.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.BackgroundColor = Xamarin.Forms.Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Description.FontSize = 13.5;
                this.Description.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
            }
        }
        void OnButtonClicked(object sender, EventArgs e)
        {
            PdfDocument document = null;
            if (this.comformance.Items[this.comformance.SelectedIndex] == "PDF/A-1a")
            {
                //Create a new PDF document
                document = new PdfDocument(PdfConformanceLevel.Pdf_A1A);
            }
            else if (this.comformance.Items[this.comformance.SelectedIndex] == "PDF/A-1b")
            {
                document = new PdfDocument(PdfConformanceLevel.Pdf_A1B);
            }
            else if (this.comformance.Items[this.comformance.SelectedIndex] == "PDF/A-2a")
            {
                document = new PdfDocument(PdfConformanceLevel.Pdf_A2A);
            }
            else if (this.comformance.Items[this.comformance.SelectedIndex] == "PDF/A-2b")
            {
                document = new PdfDocument(PdfConformanceLevel.Pdf_A2B);
            }
            else if (this.comformance.Items[this.comformance.SelectedIndex] == "PDF/A-2u")
            {
                document = new PdfDocument(PdfConformanceLevel.Pdf_A2U);
            }
            else 
            {
                if (this.comformance.Items[this.comformance.SelectedIndex] == "PDF/A-3a")
                {
                    document = new PdfDocument(PdfConformanceLevel.Pdf_A3A);
                }
                else if (this.comformance.Items[this.comformance.SelectedIndex] == "PDF/A-3b")
                {
                    document = new PdfDocument(PdfConformanceLevel.Pdf_A3B);
                }
                else if (this.comformance.Items[this.comformance.SelectedIndex] == "PDF/A-3u")
                {
                    document = new PdfDocument(PdfConformanceLevel.Pdf_A3U);
                }
#if COMMONSB
                Stream imgStream = typeof(Conformance).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Samples.Assets.Products.xml");
               
#else
                Stream imgStream = typeof(Conformance).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.PDF.Samples.Assets.Products.xml");
#endif

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
#if COMMONSB
            Stream arialFontStream = typeof(Conformance).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Samples.Assets.arial.ttf");
            Stream imageStream = typeof(Conformance).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Samples.Assets.AdventureCycle.jpg");
#else
            Stream arialFontStream = typeof(Conformance).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.PDF.Samples.Assets.arial.ttf");
            Stream imageStream = typeof(Conformance).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.PDF.Samples.Assets.AdventureCycle.jpg");
#endif
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
            //Save the PDF document.
            document.Save(stream);

            //Close the PDF document.
            document.Close();

            stream.Position = 0;

            if ( Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("PDF_A.pdf", "application/pdf", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("PDF_A.pdf", "application/pdf", stream);

        }
    }
}
