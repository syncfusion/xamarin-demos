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
using System.IO;
using Syncfusion.Pdf.Parsing;

using Syncfusion.Pdf;
using System.Reflection;

namespace SampleBrowser
{
    public partial class Booklet : SamplePage
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
            text2.Text = "This sample demonstrates how to create a booklet from an existing PDF document.";
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
            Stream docStream = typeof(Booklet).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Assets.JavaScript Succinctly.pdf");
            PdfLoadedDocument ldoc = new PdfLoadedDocument(docStream);
            float width = 1224;
            float height = 792;

            PdfDocument document = PdfBookletCreator.CreateBooklet(ldoc, new Syncfusion.Drawing.SizeF(width, height), true);
            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            document.Close(true);

            if (stream != null)
            {
                SaveAndroid androidSave = new SaveAndroid();
                androidSave.Save("Booklet.pdf", "application/pdf", stream, m_context);
            }
        }
    }
}