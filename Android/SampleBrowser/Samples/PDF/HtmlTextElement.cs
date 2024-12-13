
using System;
using Android.Content;
using Android.Views;
using Android.Widget;
using Syncfusion.Pdf;
using System.IO;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;

namespace SampleBrowser
{
    public partial class HtmlTextElement : SamplePage
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
            text2.Text = "This sample demonstrates drawing HTML text element in the PDF document.";
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
            PdfDocument doc = new PdfDocument();

            //Add a page
            PdfPage page = doc.Pages.Add();

            PdfSolidBrush brush = new PdfSolidBrush(Syncfusion.Drawing.Color.Black);

            PdfPen pen = new PdfPen(Syncfusion.Drawing.Color.Black, 1f);

            //Create font
            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 11.5f);

            PdfFont heading = new PdfStandardFont(PdfFontFamily.TimesRoman, 12, PdfFontStyle.Bold);

            font = new PdfStandardFont(PdfFontFamily.Helvetica, 10f);

            page.Graphics.DrawString("Create, Read, and Edit PDF Files from C#, VB.NET", heading, PdfBrushes.Black, new RectangleF(0, 0, page.GetClientSize().Width, 20), new PdfStringFormat(PdfTextAlignment.Center));

            string longText = "The <b> Syncfusion Essential PDF </b> is a feature-rich and high-performance .NET PDF library that allows you to add robust PDF functionalities to any .NET application." +
                "It allows you to create, read, and edit PDF documents programmatically without Adobe dependencies. This library also offers functionality to <font color='#0000F8'> merge, split, stamp, form-fill, compress, and secure PDF files.</font>" +
                "<br/><br/><font color='#FF3440'><b>1. Secure your PDF with advanced encryption, digital signatures, and redaction.</b></font>" +
                "<br/><br/><font color='#FF9E4D'><b>2. Extract text and images from your PDF files.</b></font>" +
                "<br/><br/><font color='#4F6200'><b>3. Top features: forms, tables, barcodes; stamp, split, and merge PDFs.</b></font>";

            //Rendering HtmlText
            PdfHTMLTextElement richTextElement = new PdfHTMLTextElement(longText, font, brush);

            // Formatting Layout
            PdfLayoutFormat format = new PdfLayoutFormat();
            format.Layout = PdfLayoutType.OnePage;

            //Drawing htmlString
            richTextElement.Draw(page, new RectangleF(0, 20, page.GetClientSize().Width, page.GetClientSize().Height), format);


            MemoryStream stream = new MemoryStream();
            //Save the PDF dcoument.
            doc.Save(stream);

            //Close the PDF document.
            doc.Close();

            stream.Position = 0;

            if (stream != null)
            {
                SaveAndroid androidSave = new SaveAndroid();
                androidSave.Save("HtmlTextElement.pdf", "application/pdf", stream, m_context);
            }
        }
    }
}