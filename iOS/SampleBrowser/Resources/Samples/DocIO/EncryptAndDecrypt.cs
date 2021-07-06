#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.Pdf;
using Syncfusion.DocIORenderer;
using Syncfusion.OfficeChart;
using Syncfusion.Drawing;
using System.IO;
using COLOR = Syncfusion.Drawing;
using System.Reflection;
using Syncfusion.iOS.Buttons;
#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;
using ObjCRuntime;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using CGRect = System.Drawing.RectangleF;
using CGPoint = System.Drawing.PointF;
using CGSize = System.Drawing.SizeF;
#endif

namespace SampleBrowser
{
    public partial class EncryptandDecrypt : SampleView
    {
        CGRect frameRect = new CGRect();
        float frameMargin = 8.0f;
        UILabel label;
        UIButton imageType;
        UIButton generateButton;

        //RadioButton
        SfRadioGroup radioGroup = new SfRadioGroup();
        SfRadioButton encryptButton = new SfRadioButton();
        SfRadioButton decryptButton = new SfRadioButton();
        public EncryptandDecrypt()
        {
            label = new UILabel();
            imageType = new UIButton();
            generateButton = new UIButton(UIButtonType.System);
            generateButton.TouchUpInside += OnConvertClicked;
        }

        void LoadAllowedTextsLabel()
        {
            #region Description Label
            label.Frame = frameRect;
            label.TextColor = UIColor.FromRGB(38 / 255.0f, 38 / 255.0f, 38 / 255.0f);
            label.Text = "This sample demonstrates how to encrypt and decrypt the Word document using Essential DocIO.";
            label.Font = UIFont.SystemFontOfSize(15);
            label.Lines = 0;
            label.LineBreakMode = UILineBreakMode.WordWrap;
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                label.Font = UIFont.SystemFontOfSize(18);
                label.Frame = new CGRect(5, 5, frameRect.Location.X + frameRect.Size.Width, 35);
            }
            else
            {
                label.Frame = new CGRect(5, 5, frameRect.Location.X + frameRect.Size.Width, 50);
            }
            this.AddSubview(label);
            #endregion

            #region ImageFormat Label
            imageType.Frame = new CGRect(10, 100, frameRect.Location.X + frameRect.Size.Width - 20, 40);
            #endregion

            #region Radio Buttons for encrypt and decrypt
            radioGroup.Axis = UILayoutConstraintAxis.Horizontal;
            encryptButton.SetTitle("Encrypt", UIControlState.Normal);
            radioGroup.AddArrangedSubview(encryptButton);
            decryptButton.SetTitle("Decrypt", UIControlState.Normal);
            radioGroup.AddArrangedSubview(decryptButton);


            encryptButton.IsChecked = true;
            radioGroup.Distribution = UIStackViewDistribution.FillProportionally;

            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                radioGroup.Frame = new CGRect(5, 60, frameRect.Width - 500, 40);
            }
            else
            {
                radioGroup.Frame = new CGRect(5, 65, frameRect.Width - 90, 40);
            }
            this.AddSubview(radioGroup);
            #endregion

            #region Convert Button
            generateButton.SetTitle("Generate Word", UIControlState.Normal);
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                generateButton.Frame = new CGRect(0, 115, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            else
            {
                generateButton.Frame = new CGRect(0, 120, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            this.AddSubview(generateButton);
            #endregion
        }

        void OnConvertClicked(object sender, EventArgs e)
        {
            WordDocument document = null;
            if (encryptButton != null && (bool)encryptButton.IsChecked)
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
                Assembly assembly = Assembly.GetExecutingAssembly();
                document = new WordDocument();
                // Open an existing template document.
                Stream inputStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.DocIO.Templates.Security Settings.docx");
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

            string fileName = null;
            string ContentType = null;
            MemoryStream ms = new MemoryStream();
            fileName = "Encrypt and Decrypt.docx";
            ContentType = "application/msword";
            document.Save(ms, FormatType.Docx);


            //Reset the stream position
            ms.Position = 0;

            //Close the document instance.
            document.Close();

            if (ms != null)
            {
                SaveiOS iOSSave = new SaveiOS();
                iOSSave.Save(fileName, ContentType, ms as MemoryStream);
            }

        }

        public override void LayoutSubviews()
        {
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                frameMargin = 0.0f;
            }
            frameRect = Bounds;
            frameRect.Location = new CGPoint(frameRect.Location.X + frameMargin, frameRect.Location.Y + 1.5f * frameMargin);
            frameRect.Size = new CGSize(frameRect.Size.Width - (frameRect.Location.X + frameMargin), frameRect.Size.Height - (frameRect.Location.Y + 1.5f * frameMargin));

            LoadAllowedTextsLabel();

            base.LayoutSubviews();
        }
    }
}