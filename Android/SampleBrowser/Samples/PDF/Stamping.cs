#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using System.IO;
using System.Reflection;
using Syncfusion.Drawing;

namespace SampleBrowser
{
    public partial class Stamping : SamplePage
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
            text2.Text = "This sample demonstrates how to stamp or watermark an existing PDF document.";
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
            Stream docStream = typeof(Stamping).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Assets.Product Catalog.pdf");
            PdfLoadedDocument ldoc = new PdfLoadedDocument(docStream);

            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 100f, PdfFontStyle.Regular);

            foreach (PdfPageBase lPage in ldoc.Pages)
            {
                PdfGraphics g = lPage.Graphics;
                PdfGraphicsState state = g.Save();
                g.TranslateTransform(ldoc.Pages[0].Size.Width / 2, ldoc.Pages[0].Size.Height / 2);
                g.SetTransparency(0.25f);
                SizeF waterMarkSize = font.MeasureString("Sample");
                g.RotateTransform(-40);
                g.DrawString("Sample", font, PdfPens.Red, PdfBrushes.Red, new PointF(-waterMarkSize.Width / 2, -waterMarkSize.Height / 2));
                g.Restore(state); 
            }
            MemoryStream stream = new MemoryStream();
            ldoc.Save(stream);
            ldoc.Close(true);

            if (stream != null)
            {
                SaveAndroid androidSave = new SaveAndroid();
                androidSave.Save("Stamping.pdf", "application/pdf", stream, m_context);
            }
        }
    }
}