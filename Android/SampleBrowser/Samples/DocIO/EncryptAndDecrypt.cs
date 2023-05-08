#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
    public partial class EncryptAndDecrypt : SamplePage
    {
        private Context m_context;
        RadioGroup radioGroup;
        RadioButton encryptDocument;
        RadioButton decryptDocument;


        public override View GetSampleContent(Context con)
        {
            LinearLayout linear = new LinearLayout(con);
            linear.SetBackgroundColor(Android.Graphics.Color.White);
            linear.Orientation = Orientation.Vertical;
            linear.SetPadding(10, 10, 10, 10);

            TextView text2 = new TextView(con);
            text2.TextSize = 17;
            text2.TextAlignment = TextAlignment.Center;
            text2.Text = "This sample demonstrates how to encrypt and decrypt the Word document using Essential DocIO.";
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
            encryptDocument = new RadioButton(con);
            encryptDocument.Text = "Encrypt Document";
            radioGroup.AddView(encryptDocument);
            decryptDocument = new RadioButton(con);
            decryptDocument.Text = "Decrypt Document";
            radioGroup.AddView(decryptDocument);
            radioGroup.Check(1);
            radioLinearLayoutVertical.AddView(radioGroup);
            linear.AddView(radioLinearLayoutVertical);
            encryptDocument.Checked = true;

            TextView space2 = new TextView(con);
            space2.TextSize = 10;
            linear.AddView(space2);

            Button generateButton = new Button(con);
            generateButton.Text = "Generate";
            generateButton.Click += OnButtonClicked;
            linear.AddView(generateButton);

            return linear;
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            WordDocument document = null;
            if (encryptDocument.Checked == true)
            {
                //create worddocument instances
                document = new WordDocument();

                document.EnsureMinimal();

                // Getting last section of the document.
                IWSection section = document.LastSection;

                // Adding a paragraph to the section.
                IWParagraph paragraph = section.AddParagraph();

                // Writing text
                IWTextRange text = paragraph.AppendText("This document was encrypted with password");
                text.CharacterFormat.FontSize = 16f;
                text.CharacterFormat.FontName = "Bitstream Vera Serif";

                // Encrypt the document by giving password
                document.EncryptDocument("syncfusion");
            }
            else
            {
                // Open an existing template document with single section.
                document = new WordDocument();
                Stream inputStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.DocIO.Templates.Security Settings.docx");
                // Open an existing template document.
                document.Open(inputStream, FormatType.Docx, "syncfusion");
                inputStream.Dispose();

                // Getting last section of the document.
                IWSection section = document.LastSection;

                // Adding a paragraph to the section.
                IWParagraph paragraph = section.AddParagraph();

                // Writing text
                IWTextRange text = paragraph.AppendText("\nDemo For Document Decryption with Essential DocIO");
                text.CharacterFormat.FontSize = 16f;
                text.CharacterFormat.FontName = "Bitstream Vera Serif";

                text = paragraph.AppendText("\nThis document is Decrypted");
                text.CharacterFormat.FontSize = 16f;
                text.CharacterFormat.FontName = "Bitstream Vera Serif";
            }
            MemoryStream ms = new MemoryStream();

            //Set file content type
            string contentType = null;
            string fileName = null;
            //Save the document as docx
            fileName = "Encrypt and Decrypt.docx";
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

