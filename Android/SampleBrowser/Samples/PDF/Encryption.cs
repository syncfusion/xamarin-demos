#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using Android.Graphics;

using Syncfusion.Pdf.Barcode;
using System.IO;
using Syncfusion.Pdf.Graphics;

using Syncfusion.Pdf;
using Syncfusion.Pdf.Security;
using Syncfusion.Drawing;
using System.Reflection;
using Syncfusion.Pdf.Interactive;

namespace SampleBrowser
{
    public partial class Encryption : SamplePage
    {
        private Context m_context;
        private Spinner m_rc4Key, m_aesKey, m_encryptionKey;
        private Spinner m_algorithms;
        private LinearLayout advancedLinear1;
        public override View GetSampleContent(Context con)
        {
            int numerHeight = getDimensionPixelSize(con, Resource.Dimension.numeric_txt_ht);
            int width = con.Resources.DisplayMetrics.WidthPixels - 40;
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
            text2.Text = "This sample demonstrates how to create secure PDF document.";
            text2.SetTextColor(Android.Graphics.Color.ParseColor("#262626"));
            text2.SetPadding(5, 5, 5, 5);

            linear.AddView(text2);

            TextView space1 = new TextView(con);
            space1.TextSize = 10;
            linear.AddView(space1);

            advancedLinear1 = new LinearLayout(con);
            TextView space3 = new TextView(con);
            space3.TextSize = 17;
            space3.TextAlignment = TextAlignment.Center;
            space3.Text = "Algorithms";
            space3.SetTextColor(Android.Graphics.Color.ParseColor("#262626"));
            space3.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight);
            advancedLinear1.AddView(space3);
            m_context = con;

            string[] list1 = new string[] { "RC4", "AES" };
            ArrayAdapter<String> array1 = new ArrayAdapter<String>(con, Android.Resource.Layout.SimpleSpinnerItem, list1);
            m_algorithms = new Spinner(con);
            m_algorithms.Adapter = array1;
            m_algorithms.SetSelection(1);
            advancedLinear1.AddView(m_algorithms);
            linear.AddView(advancedLinear1);

            TextView space4 = new TextView(con);
            space4.TextSize = 10;
            linear.AddView(space4);

            LinearLayout subLinear = new LinearLayout(con);
            TextView space2 = new TextView(con);
            space2.TextSize = 17;
            space2.TextAlignment = TextAlignment.Center;
            space2.Text = "Key Size";
            space2.SetTextColor(Android.Graphics.Color.ParseColor("#262626"));
            space2.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight);
            subLinear.AddView(space2);

            string[] list = { "40 Bit", "128 Bit" };
            ArrayAdapter<String> array = new ArrayAdapter<String>(con, Android.Resource.Layout.SimpleSpinnerItem, list);
            m_rc4Key = new Spinner(con);
            m_rc4Key.Adapter = array;
            m_rc4Key.SetSelection(1);
            subLinear.AddView(m_rc4Key);
            //linear.AddView(subLinear);

            LinearLayout subLinear2 = new LinearLayout(con);
            TextView sbspace = new TextView(con);
            sbspace.TextSize = 17;
            sbspace.TextAlignment = TextAlignment.Center;
            sbspace.Text = "Key Size";
            sbspace.SetTextColor(Android.Graphics.Color.ParseColor("#262626"));
            sbspace.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight);
            subLinear2.AddView(sbspace);

            string[] list2 = { "128 Bit", "256 Bit", "256 Revision 6" };
            ArrayAdapter<String> array2 = new ArrayAdapter<String>(con, Android.Resource.Layout.SimpleSpinnerItem, list2);
            m_aesKey = new Spinner(con);
            m_aesKey.Adapter = array2;
            m_aesKey.SetSelection(1);
            subLinear2.AddView(m_aesKey);

            LinearLayout subLinear5 = new LinearLayout(con);
            TextView sbspace2 = new TextView(con);
            sbspace2.TextSize = 17;
            sbspace2.TextAlignment = TextAlignment.Center;
            sbspace2.Text = "Encryption Options";
            sbspace2.SetTextColor(Android.Graphics.Color.ParseColor("#262626"));
            sbspace2.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight);
            subLinear5.AddView(sbspace2);

            string[] encryptionList = new string[] { "Encrypt all contents", "Encrypt all contents except metadata", "Encrypt only attachments" };
            ArrayAdapter<String> array3 = new ArrayAdapter<String>(con, Android.Resource.Layout.SimpleSpinnerItem, encryptionList);
            m_encryptionKey = new Spinner(con);
            m_encryptionKey.Adapter = array3;
            m_encryptionKey.SetSelection(0);
            subLinear5.AddView(m_encryptionKey);
            //linear.AddView(subLinear5);

            LinearLayout subLinear3 = new LinearLayout(con);
            TextView space5 = new TextView(con);
            space5.TextSize = 10;
            subLinear3.AddView(space5);

            TextView text4 = new TextView(con);
            text4.TextSize = 17;
            text4.TextAlignment = TextAlignment.Center;
            text4.Text = "User Password : password";
            text4.SetTextColor(Android.Graphics.Color.ParseColor("#262626"));
            text4.SetPadding(5, 5, 5, 5);
            subLinear3.AddView(text4);
            linear.AddView(subLinear3);

            LinearLayout subLinear4 = new LinearLayout(con);
            TextView text5 = new TextView(con);
            text5.TextSize = 17;
            text5.TextAlignment = TextAlignment.Center;
            text5.Text = "Owner Password : syncfusion";
            text5.SetTextColor(Android.Graphics.Color.ParseColor("#262626"));
            text5.SetPadding(5, 5, 5, 5);
            subLinear4.AddView(text5);
            linear.AddView(subLinear4);

            Button button1 = new Button(con);
            button1.Text = "Generate PDF";
            button1.Click += OnButtonClicked;
            linear.AddView(button1);

            m_algorithms.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                String selectedItem = array1.GetItem(e.Position);
                if (selectedItem.Equals("AES"))
                {
                    linear.RemoveView(button1);
                    linear.RemoveView(subLinear3);
                    linear.RemoveView(subLinear4);
                    linear.RemoveView(subLinear);
                    linear.AddView(subLinear2);
                    linear.AddView(subLinear5);
                    linear.AddView(subLinear3);
                    linear.AddView(subLinear4);
                    linear.AddView(button1);

                }
                else
                {
                    linear.RemoveView(button1);
                    linear.RemoveView(subLinear3);
                    linear.RemoveView(subLinear4);
                    linear.RemoveView(subLinear2);
                    linear.RemoveView(subLinear5);
                    m_encryptionKey.SetSelection(0);
                    linear.AddView(subLinear);
                    linear.AddView(subLinear3);
                    linear.AddView(subLinear4);
                    linear.AddView(button1);

                }
            };
            m_encryptionKey.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                String selectedItem = array3.GetItem(e.Position);
                if (selectedItem.Equals("Encrypt only attachments"))
                {
                    linear.RemoveView(button1);
                    linear.RemoveView(subLinear4);
                    linear.RemoveView(subLinear3);
                    linear.RemoveView(subLinear5);
                    linear.RemoveView(subLinear2);
                    linear.AddView(subLinear2);
                    linear.AddView(subLinear5);
                    linear.AddView(subLinear3);
                    linear.AddView(button1);
                }
                else
                {
                    linear.RemoveView(button1);
                    linear.RemoveView(subLinear4);
                    linear.RemoveView(subLinear3);
                    linear.RemoveView(subLinear5);
                    linear.RemoveView(subLinear2);
                    linear.AddView(subLinear2);
                    linear.AddView(subLinear5);
                    linear.AddView(subLinear3);
                    linear.AddView(subLinear4);
                    linear.AddView(button1);
                }
            };
            return linear;
        }
        private int getDimensionPixelSize(Context con, int id)
        {
            return con.Resources.GetDimensionPixelSize(id);
        }
        void OnButtonClicked(object sender, EventArgs e)
        {
            //Create new PDF document.
            PdfDocument document = new PdfDocument();

            //Add page to the PDF document.
            PdfPage page = document.Pages.Add();

            PdfGraphics graphics = page.Graphics;

            //Create font object.
            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 14f, PdfFontStyle.Bold);
            PdfBrush brush = PdfBrushes.Black;

            //Document security
            PdfSecurity security = document.Security;
            if (this.m_algorithms.SelectedItemPosition == 0)
            {   security.Algorithm = PdfEncryptionAlgorithm.RC4;
                if (this.m_rc4Key.SelectedItemPosition == 0)
                {
                    security.KeySize = PdfEncryptionKeySize.Key40Bit;
                }
                else if (this.m_rc4Key.SelectedItemPosition == 1)
                {
                    security.KeySize = PdfEncryptionKeySize.Key128Bit;
                }
            }
            else if (this.m_algorithms.SelectedItemPosition == 1)
            {
                security.Algorithm = PdfEncryptionAlgorithm.AES;
                if (this.m_aesKey.SelectedItemPosition == 0)
                {
                    security.KeySize = PdfEncryptionKeySize.Key128Bit;
                }
                else if (this.m_aesKey.SelectedItemPosition == 1)
                {
                    security.KeySize = PdfEncryptionKeySize.Key256Bit;
                }
                else if (this.m_aesKey.SelectedItemPosition == 2)
                {
                    security.KeySize = PdfEncryptionKeySize.Key256BitRevision6;
                }
            }

            if (this.m_encryptionKey.SelectedItemPosition == 0)
            {
                security.EncryptionOptions = PdfEncryptionOptions.EncryptAllContents;
            }
            else if (this.m_encryptionKey.SelectedItemPosition == 1)
            {
                security.EncryptionOptions = PdfEncryptionOptions.EncryptAllContentsExceptMetadata;
            }
            else if (this.m_encryptionKey.SelectedItemPosition == 2)
            {
                //Read the file
                Stream file = typeof(Encryption).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Assets.Products.xml");

                //Creates an attachment
                PdfAttachment attachment = new PdfAttachment("Products.xml", file);

                attachment.ModificationDate = DateTime.Now;

                attachment.Description = "About Syncfusion";

                attachment.MimeType = "application/txt";

                //Adds the attachment to the document
                document.Attachments.Add(attachment);

                security.EncryptionOptions = PdfEncryptionOptions.EncryptOnlyAttachments;
            }


            security.OwnerPassword = "syncfusion";
            security.Permissions = PdfPermissionsFlags.Print | PdfPermissionsFlags.FullQualityPrint;
            security.UserPassword = "password";

            string text = "Security options:\n\n" + String.Format("KeySize: {0}\n\nEncryption Algorithm: {4}\n\nOwner Password: {1}\n\nPermissions: {2}\n\n" +
               "UserPassword: {3}", security.KeySize, security.OwnerPassword, security.Permissions, security.UserPassword, security.Algorithm);
            if (this.m_algorithms.SelectedItemPosition == 1)
            {
                if (this.m_aesKey.SelectedItemPosition == 2)
                {
                    text += String.Format("\n\nRevision: {0}", "Revision 6");
                }
                else if (this.m_aesKey.SelectedItemPosition == 1)
                {
                    text += String.Format("\n\nRevision: {0}", "Revision 5");
                }
            }
            // Draw String.
            graphics.DrawString("Document is Encrypted with following settings", font, brush, Syncfusion.Drawing.PointF.Empty);

            font = new PdfStandardFont(PdfFontFamily.TimesRoman, 11f, PdfFontStyle.Bold);
            graphics.DrawString(text, font, brush, new Syncfusion.Drawing.PointF(0, 40));

            MemoryStream stream = new MemoryStream();

            //Save the PDF document.
            document.Save(stream);

            document.Close();

            if (stream != null)
            {
                SaveAndroid androidSave = new SaveAndroid();
                androidSave.Save("Securepdf.pdf", "application/pdf", stream, m_context);
            }
        }
    }
}