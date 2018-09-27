#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleBrowser.PDF

{
    public partial class Encryption : SampleView
    {
        public Encryption()
        {
            InitializeComponent(); 
            this.keysize.Items.Add("128 Bit");
            this.keysize.Items.Add("256 Bit");
            this.keysize.Items.Add("256 Revision 6");

            this.Algorithms.Items.Add("RC4");
            this.Algorithms.Items.Add("AES");
            this.keysize.SelectedIndex = 1;
            this.Algorithms.SelectedIndex = 1;

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

        public void OnButtonClicked(object sender, EventArgs e)
        {
            //Create new PDF document.
            PdfDocument document = new PdfDocument();

            //Add page to the PDF document.
            PdfPage page = document.Pages.Add();

            PdfGraphics graphics = page.Graphics;

            //Create font object.
            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 14f, PdfFontStyle.Bold);
            PdfBrush brush = PdfBrushes.Black;
            PdfForm form = document.Form;

            //Document security
            PdfSecurity security = document.Security;

            if (this.Algorithms.Items[this.Algorithms.SelectedIndex] == "AES")
            {
                security.Algorithm = PdfEncryptionAlgorithm.AES;
                if (this.keysize.SelectedIndex == 0)
                {
                    security.KeySize = PdfEncryptionKeySize.Key128Bit;
                }
                else if (this.keysize.SelectedIndex == 1)
                {
                    security.KeySize = PdfEncryptionKeySize.Key256Bit;
                }
                else if (this.keysize.SelectedIndex == 2)
                {
                    security.KeySize = PdfEncryptionKeySize.Key256BitRevision6;
                }
            }
            else if(this.Algorithms.Items[this.Algorithms.SelectedIndex] == "RC4")
            {
                security.Algorithm = PdfEncryptionAlgorithm.RC4;
                if (this.keysize.SelectedIndex == 0)
                {
                    security.KeySize = PdfEncryptionKeySize.Key40Bit;
                 
                }
                else if (this.keysize.SelectedIndex == 1)
                {
                    security.KeySize = PdfEncryptionKeySize.Key128Bit;
                }
            }

            
            security.OwnerPassword = "syncfusion";
            security.Permissions = PdfPermissionsFlags.Print | PdfPermissionsFlags.FullQualityPrint;
            security.UserPassword = "password";

            string text = "Security options:\n\n" + String.Format("KeySize: {0}\n\nEncryption Algorithm: {4}\n\nOwner Password: {1}\n\nPermissions: {2}\n\n" +
               "UserPassword: {3}", security.KeySize, security.OwnerPassword, security.Permissions, security.UserPassword, security.Algorithm);
            if (this.Algorithms.SelectedIndex == 1)  
            {
                if(this.keysize.SelectedIndex == 2)
                  text += String.Format("\n\nRevision: {0}", "Revision 6");
                else if (this.keysize.SelectedIndex == 1)
                  text += String.Format("\n\nRevision: {0}", "Revision 5");
            }
           
            graphics.DrawString("Document is Encrypted with following settings", font, brush, PointF.Empty);
            font = new PdfStandardFont(PdfFontFamily.TimesRoman, 11f, PdfFontStyle.Bold);
            graphics.DrawString(text, font, brush, new PointF(0, 40));

            MemoryStream stream = new MemoryStream();
            //Save the PDF document.
            document.Save(stream);

            if (Device.RuntimePlatform == Device.WinPhone || Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("Secured.pdf", "application/pdf", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("Secured.pdf", "application/pdf", stream);
        }
        void OnItemSelected(object sender, EventArgs e)
        {

            if (this.Algorithms.SelectedIndex == 0)
            {
                this.keysize.Items.Clear();
                this.keysize.Items.Add("40 Bit");
                this.keysize.Items.Add("128 Bit");
                this.keysize.SelectedIndex = 0;
            }
            else if (this.Algorithms.SelectedIndex == 1)
            {
                this.keysize.Items.Clear();
                this.keysize.Items.Add("128 Bit");
                this.keysize.Items.Add("256 Bit");
                this.keysize.Items.Add("256 Revision 6");
                this.keysize.SelectedIndex = 0;
            }            

        }
    }
}
