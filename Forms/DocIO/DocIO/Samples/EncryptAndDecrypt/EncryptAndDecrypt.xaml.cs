#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.DocIO;
using SampleBrowser.Core;
using Syncfusion.DocIO.DLS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SampleBrowser.DocIO;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;
using Syncfusion.OfficeChart;
using Syncfusion.Drawing;

namespace SampleBrowser.DocIO
{
    public partial class EncryptAndDecrypt : SampleView
    {
        public EncryptAndDecrypt()
        {
            InitializeComponent();
			
			this.encryptButton.IsChecked = true;

            if (Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Description.HorizontalOptions = Xamarin.Forms.LayoutOptions.Start;
                this.btnGenerate.HorizontalOptions = Xamarin.Forms.LayoutOptions.Start;
                this.Description.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnGenerate.BackgroundColor = Xamarin.Forms.Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                {
                    this.Description.FontSize = 13.5;
                }

                this.Description.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
            }
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            WordDocument document = null;
            if (this.encryptButton != null && (bool)this.encryptButton.IsChecked)
            {
                //Creates a new Word document 
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
                Assembly assembly = typeof(EncryptAndDecrypt).GetTypeInfo().Assembly;
                document = new WordDocument();
#if COMMONSB
                string rootPath = "SampleBrowser.Samples.DocIO.Samples.Templates.";
#else
                string rootPath = "SampleBrowser.DocIO.Samples.Templates.";
#endif
                // Open an existing template document.
                Stream inputStream = assembly.GetManifestResourceStream(rootPath + "Security Settings.docx");
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

            MemoryStream stream = new MemoryStream();
            document.Save(stream, FormatType.Docx);
            document.Close();

            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("Encrypt and Decrypt.docx", "application/msword", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("Encrypt and Decrypt.docx", "application/msword", stream);
        }

    }
}
