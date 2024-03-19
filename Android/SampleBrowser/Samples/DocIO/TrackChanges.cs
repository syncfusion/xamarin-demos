#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
using Syncfusion.Drawing;
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
    public partial class TrackChanges : SamplePage
    {
        private Context m_context;
        RadioGroup radioGroup;
        RadioButton acceptAll;
        RadioButton rejectAll;
        public override View GetSampleContent(Context con)
        {
            LinearLayout linear = new LinearLayout(con);
            linear.SetBackgroundColor(Android.Graphics.Color.White);
            linear.Orientation = Orientation.Vertical;
            linear.SetPadding(10, 10, 10, 10);
            TextView text2 = new TextView(con);
            text2.TextSize = 17;
            text2.TextAlignment = TextAlignment.Center;
            text2.Text = "This sample demonstrates how to accept or reject the tracked changes in the Word document using Essential DocIO.";
            text2.SetTextColor(Android.Graphics.Color.ParseColor("#262626"));
            text2.SetPadding(5, 5, 5, 5);
            linear.AddView(text2);
            TextView space1 = new TextView(con);
            space1.TextSize = 10;
            linear.AddView(space1);

            m_context = con;
            LinearLayout radioLinearLayoutVertical = new LinearLayout(con);
            radioLinearLayoutVertical.Orientation = Orientation.Vertical;
            radioGroup = new RadioGroup(con);
            radioGroup.TextAlignment = TextAlignment.Center;
            radioGroup.Orientation = Orientation.Vertical;
            acceptAll = new RadioButton(con);
            acceptAll.Text = "Accepts all the tracked changes in the Word document";
            radioGroup.AddView(acceptAll);
            rejectAll = new RadioButton(con);
            rejectAll.Text = "Rejects all the tracked changes in the Word document";
            radioGroup.AddView(rejectAll);
            radioGroup.Check(1);
            radioLinearLayoutVertical.AddView(radioGroup);
            linear.AddView(radioLinearLayoutVertical);
            acceptAll.Checked = true;

            TextView space2 = new TextView(con);
            space2.TextSize = 10;
            linear.AddView(space2);
            Button viewButton = new Button(con);
            viewButton.Text = "View Template";
            viewButton.Click += OnButtonClicked1;
            linear.AddView(viewButton);
            TextView space3 = new TextView(con);
            space3.TextSize = 10;
            linear.AddView(space3);
            Button generateButton = new Button(con);
            generateButton.Text = "Generate";
            generateButton.Click += OnButtonClicked2;
            linear.AddView(generateButton);
            return linear;
        }
        void OnButtonClicked1(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream inputStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.DocIO.Templates.TrackChangesTemplate.docx");
            MemoryStream stream = new MemoryStream();
            inputStream.CopyTo(stream);
            stream.Position = 0;
            inputStream.Dispose();
            //Set file content type
            string contentType = null;
            string fileName = null;
            //Save the document as docx
            fileName = "TrackChangesTemplate.docx";
            contentType = "application/msword";
            if (stream != null)
            {
                SaveAndroid androidSave = new SaveAndroid();
                androidSave.Save(fileName, contentType, stream, m_context);
            }
        }
            void OnButtonClicked2(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            // Open an existing template document with single section.
            WordDocument document = new WordDocument();
            Stream inputStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.DocIO.Templates.TrackChangesTemplate.docx");
            // Open an existing template document.
            document.Open(inputStream, FormatType.Docx);
            inputStream.Dispose();
            if (acceptAll.Checked == true)
		     document.Revisions.AcceptAll();   
            else
             document.Revisions.RejectAll();
            MemoryStream ms = new MemoryStream();
            //Set file content type
            string contentType = null;
            string fileName = null;
            //Save the document as docx
            fileName = "Track Changes.docx";
            contentType = "application/msword";
            document.Save(ms, FormatType.Docx);
            document.Dispose();
            if (ms != null)
            {
                SaveAndroid androidSave = new SaveAndroid();
                androidSave.Save(fileName, contentType, ms, m_context);
            }
        }
    }
}

