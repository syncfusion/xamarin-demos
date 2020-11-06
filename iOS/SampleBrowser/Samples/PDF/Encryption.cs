#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.IO;
using Syncfusion.Drawing;
using System.Reflection;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Barcode;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using MessageUI;
using System.Collections.Generic;
using Syncfusion.Pdf.Interactive;
#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;
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
    public partial class Encryption : SampleView
    {
	   	    
       	public Encryption()
		{
			this.algorithmlist.Add((NSString)"AES");
			this.algorithmlist.Add((NSString)"RC4");
		 
            this.AESkeylist.Add((NSString)"128 Bit");
            this.AESkeylist.Add((NSString)"256 Bit");
            this.AESkeylist.Add((NSString)"256Revision6");

			RC4keylist.Add((NSString)"40 Bit");
			RC4keylist.Add((NSString)"128 Bit");

            this.options.Add("Encrypt all contents");
            this.options.Add("Encrypt all contents except metadata");
            this.options.Add("Encrypt only attachments");

            algorithmfilterType = "AES";
			keysizefilterType = "128 Bit";
            optionType = "Encrypt all contents";
        }

        
		
      CGRect frameRect = new CGRect ();
        float frameMargin = 8.0f;
        private readonly IList<string> algorithmlist = new List<string>();
        private readonly IList<string> AESkeylist = new List<string>();
        private readonly IList<string> RC4keylist = new List<string>();
        private readonly IList<string> options = new List<string>();
        UILabel filterLabel;
		UILabel userPasswordLabel;
		UILabel ownerPasswordLabel;
        UIButton filterDoneButton;
        UIButton filterButton;
        UIPickerView filterPicker;
        UILabel filterActionLabel;
        UIButton filterActionDoneButton;
        UIButton filterActionButton;
        UIPickerView filterActionPicker;
        UILabel filterActionLabel1;
        UIButton filterActionDoneButton1;
        UIButton filterActionButton1;
        UIPickerView filterActionPicker1;
        string algorithmfilterType;
        string keysizefilterType;
        string optionType;
        bool isLoaded = false;
        UIButton button;

        UILabel optionLabel;
        UIButton optionDoneButton;
        UIButton optionButton;
        UIPickerView optionPicker;

        void LoadAllowedTextsLabel()
        {
            

            #region Description Label
                  
            UILabel label = new UILabel ();
            label.Frame = frameRect;
            label.TextColor = UIColor.FromRGB (38/255.0f, 38/255.0f, 38/255.0f);
            label.Text = "This sample demonstrates how to create secure PDF document.";
            label.Font = UIFont.SystemFontOfSize(15);
            label.Lines                 = 0;
            label.LineBreakMode         = UILineBreakMode.WordWrap;
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
                label.Font = UIFont.SystemFontOfSize(18);
                label.Frame = new CGRect (5, 5,frameRect.Location.X + frameRect.Size.Width  ,35);
            } 
            else {
                label.Frame = new CGRect(5, 5, frameRect.Location.X + frameRect.Size.Width  ,50);
            }
            this.AddSubview (label);
            #endregion

            #region Filter Region
            filterLabel = new UILabel();
			userPasswordLabel = new UILabel();
			ownerPasswordLabel = new UILabel();
            filterDoneButton = new UIButton();
            filterButton = new UIButton();
            filterPicker = new UIPickerView();
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
				filterLabel.Font = UIFont.SystemFontOfSize(18);
				userPasswordLabel.Font = UIFont.SystemFontOfSize(15);
				ownerPasswordLabel.Font = UIFont.SystemFontOfSize(15);
                userPasswordLabel.Frame = new CGRect(10, 320, frameRect.Location.X + frameRect.Size.Width - 20, 30);
                ownerPasswordLabel.Frame = new CGRect(10, 350, frameRect.Location.X + frameRect.Size.Width - 20, 30);
                filterLabel.Frame = new CGRect(10, 45, frameRect.Location.X + frameRect.Size.Width - 20, 50);
				filterButton.Frame = new CGRect(10, 95, frameRect.Location.X + frameRect.Size.Width - 20, 40);
			}
			else
			{
                userPasswordLabel.Frame = new CGRect(10, 325, frameRect.Location.X + frameRect.Size.Width - 20, 30);
                ownerPasswordLabel.Frame = new CGRect(10, 355, frameRect.Location.X + frameRect.Size.Width - 20, 30);
                filterLabel.Frame = new CGRect(10, 50, frameRect.Location.X + frameRect.Size.Width - 20, 50);
				filterButton.Frame = new CGRect(10, 100, frameRect.Location.X + frameRect.Size.Width - 20, 40);
			}

            //filter Label
            filterLabel.TextColor = UIColor.Black;
            filterLabel.BackgroundColor = UIColor.Clear;
            filterLabel.Text = @"Encryption Algorithms";
            filterLabel.TextAlignment = UITextAlignment.Left;
            filterLabel.Font = UIFont.FromName("Helvetica", 16f);
            this.AddSubview(filterLabel);

			//user password label
			//userPasswordLabel.TextColor = UIColor.Black;
			userPasswordLabel.BackgroundColor = UIColor.Clear;
			userPasswordLabel.Text = @"User Password: password";
			userPasswordLabel.TextAlignment = UITextAlignment.Left;
			userPasswordLabel.Font = UIFont.FromName("Helvetica", 15f);

			//owner password label
			//ownerPasswordLabel.TextColor = UIColor.Black;
			ownerPasswordLabel.BackgroundColor = UIColor.Clear;
			ownerPasswordLabel.Text = @"Owner Password: syncfusion";
			ownerPasswordLabel.TextAlignment = UITextAlignment.Left;
			ownerPasswordLabel.Font = UIFont.FromName("Helvetica", 15f);

            //filter button
            filterButton.SetTitle("AES", UIControlState.Normal);
            filterButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            filterButton.BackgroundColor = UIColor.Clear;
            filterButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            filterButton.Hidden = false;
            filterButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
            filterButton.Layer.BorderWidth = 4;
            filterButton.Layer.CornerRadius = 8;
            filterButton.Font = UIFont.FromName("Helvetica", 16f);
            filterButton.TouchUpInside += ShowFilterPicker;
            this.AddSubview(filterButton);
        

            //filterpicker
		    PickerModel filterPickermodel = new PickerModel(this.algorithmlist);
            filterPickermodel.PickerChanged += (sender, e) =>
            {
                this.algorithmfilterType = e.SelectedValue;
                filterButton.SetTitle(algorithmfilterType, UIControlState.Normal);
            };
            filterPicker = new UIPickerView();
            filterPicker.ShowSelectionIndicator = true;
            filterPicker.Hidden = true;
            filterPicker.Model = filterPickermodel;
            filterPicker.BackgroundColor = UIColor.White;

            //filterDoneButtonn
            filterDoneButton = new UIButton();
            filterDoneButton.SetTitle("Done\t", UIControlState.Normal);
            filterDoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            filterDoneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            filterDoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            filterDoneButton.Hidden = true;
            filterDoneButton.TouchUpInside += HideFilterPicker;

            filterPicker.Frame = new CGRect(0, this.Frame.Size.Height / 4 + 20, this.Frame.Size.Width, this.Frame.Size.Height / 3);
            filterDoneButton.Frame = new CGRect(0, this.Frame.Size.Height / 4 - 20, this.Frame.Size.Width, 40);
            this.AddSubview(filterPicker);
            this.AddSubview(filterDoneButton);
            #endregion

            #region Filter Action Region
            filterActionLabel = new UILabel();
            filterActionDoneButton = new UIButton();
            filterActionButton = new UIButton();
            filterActionPicker = new UIPickerView();
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                filterActionLabel.Font = UIFont.SystemFontOfSize(18);
                filterActionLabel.Frame = new CGRect(10, 140, frameRect.Location.X + frameRect.Size.Width - 20, 50);
                filterActionButton.Frame = new CGRect(10, 190, frameRect.Location.X + frameRect.Size.Width - 20, 40);
            }
            else
            {
                filterActionLabel.Frame = new CGRect(10, 145, frameRect.Location.X + frameRect.Size.Width - 20, 50);
                filterActionButton.Frame = new CGRect(10, 195, frameRect.Location.X + frameRect.Size.Width - 20, 40);
            }

            //filterActionLabel
            filterActionLabel.TextColor = UIColor.Black;
            filterActionLabel.BackgroundColor = UIColor.Clear;
            filterActionLabel.Text = @"Encryption KeySize";
            filterActionLabel.TextAlignment = UITextAlignment.Left;
            filterActionLabel.Font = UIFont.FromName("Helvetica", 16f);           

            //filterActionButton
            filterActionButton.SetTitle("128 Bit", UIControlState.Normal);
            filterActionButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            filterActionButton.BackgroundColor = UIColor.Clear;
            filterActionButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            filterActionButton.Hidden = false;
            filterActionButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
            filterActionButton.Layer.BorderWidth = 4;
            filterActionButton.Layer.CornerRadius = 8;
            filterActionButton.Font = UIFont.FromName("Helvetica", 16f);
            filterActionButton.TouchUpInside += ShowFilterActionPicker;           


            //filterActionPickermodel
            PickerModel filterActionPickermodel = new PickerModel(this.AESkeylist);
            filterActionPickermodel.PickerChanged += (sender, e) =>
            {
                this.keysizefilterType = e.SelectedValue;
                filterActionButton.SetTitle(keysizefilterType, UIControlState.Normal);                
            };
            filterActionPicker = new UIPickerView();
            filterActionPicker.ShowSelectionIndicator = true;
            filterActionPicker.Hidden = true;
            filterActionPicker.Model = filterActionPickermodel;
            filterActionPicker.BackgroundColor = UIColor.White;

            //filterActionDoneButton
            filterActionDoneButton = new UIButton();
            filterActionDoneButton.SetTitle("Done\t", UIControlState.Normal);
            filterActionDoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            filterActionDoneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            filterActionDoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            filterActionDoneButton.Hidden = true;
            filterActionDoneButton.TouchUpInside += HideFilterActionPicker;            

            filterActionPicker.Frame = new CGRect(0, this.Frame.Size.Height / 4 + 30, this.Frame.Size.Width, this.Frame.Size.Height / 3);
            filterActionDoneButton.Frame = new CGRect(0,  this.Frame.Size.Height / 4 - 30,this.Frame.Size.Width, 40);
            this.AddSubview(filterActionPicker);
            this.AddSubview(filterActionDoneButton);

            optionLabel = new UILabel();
            optionDoneButton = new UIButton();
            optionButton = new UIButton();
            optionPicker = new UIPickerView();

            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                optionLabel.Font = UIFont.SystemFontOfSize(18);
                optionLabel.Frame = new CGRect(10, 235, frameRect.Location.X + frameRect.Size.Width - 20, 50);
                optionButton.Frame = new CGRect(10, 285, frameRect.Location.X + frameRect.Size.Width - 20, 40);
            }
            else
            {
                optionLabel.Frame = new CGRect(10, 240, frameRect.Location.X + frameRect.Size.Width - 20, 50);
                optionButton.Frame = new CGRect(10, 280, frameRect.Location.X + frameRect.Size.Width - 20, 40);
            }

            //optionLabel
            optionLabel.TextColor = UIColor.Black;
            optionLabel.BackgroundColor = UIColor.Clear;
            optionLabel.Text = @"Encryption Options";
            optionLabel.TextAlignment = UITextAlignment.Left;
            optionLabel.Font = UIFont.FromName("Helvetica", 16f);

            //optionButton
            optionButton.SetTitle("Encrypt all contents", UIControlState.Normal);
            optionButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            optionButton.BackgroundColor = UIColor.Clear;
            optionButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            optionButton.Hidden = false;
            optionButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
            optionButton.Layer.BorderWidth = 4;
            optionButton.Layer.CornerRadius = 8;
            optionButton.Font = UIFont.FromName("Helvetica", 16f);
            optionButton.TouchUpInside += ShowOptionPicker;

            //optionPickermodel
            PickerModel optionPickermodel = new PickerModel(this.options);
            optionPickermodel.PickerChanged += (sender, e) =>
            {
                this.optionType = e.SelectedValue;
                optionButton.SetTitle(this.optionType, UIControlState.Normal);
            };
            optionPicker = new UIPickerView();
            optionPicker.ShowSelectionIndicator = true;
            optionPicker.Hidden = true;
            optionPicker.Model = optionPickermodel;
            optionPicker.BackgroundColor = UIColor.White;

            //optionDoneButton
            optionDoneButton = new UIButton();
            optionDoneButton.SetTitle("Done\t", UIControlState.Normal);
            optionDoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            optionDoneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            optionDoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            optionDoneButton.Hidden = true;
            optionDoneButton.TouchUpInside += HideOptionPicker;

            optionPicker.Frame = new CGRect(0, this.Frame.Size.Height / 4 + 30, this.Frame.Size.Width, this.Frame.Size.Height / 3);
            optionDoneButton.Frame = new CGRect(0, this.Frame.Size.Height / 4 - 30, this.Frame.Size.Width, 40);
            this.AddSubview(optionPicker);
            this.AddSubview(optionDoneButton);

            #endregion

            #region
            filterActionLabel1 = new UILabel();
            filterActionDoneButton1 = new UIButton();
            filterActionButton1 = new UIButton();
            filterActionPicker1 = new UIPickerView();
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{

				filterActionButton1.Frame = new CGRect(10, 190, frameRect.Location.X + frameRect.Size.Width - 20, 40);
			}
			else
			{

				filterActionButton1.Frame = new CGRect(10, 195, frameRect.Location.X + frameRect.Size.Width - 20, 40);
			}

                    
            //filterActionButton
            filterActionButton1.SetTitle("40 Bit", UIControlState.Normal);
            filterActionButton1.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            filterActionButton1.BackgroundColor = UIColor.Clear;
            filterActionButton1.SetTitleColor(UIColor.Black, UIControlState.Normal);
			filterActionButton1.Hidden = true;
            filterActionButton1.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
            filterActionButton1.Layer.BorderWidth = 4;
            filterActionButton1.Layer.CornerRadius = 8;
            filterActionButton1.Font = UIFont.FromName("Helvetica", 16f);
            filterActionButton1.TouchUpInside += ShowFilterActionPicker;           


            //filterActionPickermodel
            PickerModel filterActionPickermodel1 = new PickerModel(this.RC4keylist);
filterActionPickermodel1.PickerChanged += (sender, e) =>
            {

				this.keysizefilterType = e.SelectedValue;

				filterActionButton1.SetTitle(keysizefilterType, UIControlState.Normal);
};
filterActionPicker1 = new UIPickerView();
filterActionPicker1.ShowSelectionIndicator = true;
            filterActionPicker1.Hidden = true;
            filterActionPicker1.Model = filterActionPickermodel1;
            filterActionPicker1.BackgroundColor = UIColor.White;

            //filterActionDoneButton
            filterActionDoneButton1 = new UIButton();
filterActionDoneButton1.SetTitle("Done\t", UIControlState.Normal);
            filterActionDoneButton1.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            filterActionDoneButton1.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            filterActionDoneButton1.SetTitleColor(UIColor.Black, UIControlState.Normal);
            filterActionDoneButton1.Hidden = true;
            filterActionDoneButton1.TouchUpInside += HideFilterActionPicker;            

            filterActionPicker1.Frame = new CGRect(0, this.Frame.Size.Height / 4 + 30, this.Frame.Size.Width, this.Frame.Size.Height / 3);
filterActionDoneButton1.Frame = new CGRect(0, this.Frame.Size.Height / 4 - 30, this.Frame.Size.Width, 40);

			this.AddSubview(filterActionPicker1);
            this.AddSubview(filterActionDoneButton1);

             this.AddSubview(filterActionButton1);
			#endregion


            this.AddSubview(filterActionLabel);
            this.AddSubview(filterActionButton);
            this.AddSubview(optionLabel);
            this.AddSubview(optionButton);
            this.AddSubview(userPasswordLabel);
			this.AddSubview(ownerPasswordLabel);

            //button
            button = new UIButton (UIButtonType.System);
            button.SetTitle("Generate PDF", UIControlState.Normal);
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                button.Frame = new CGRect(0, 390, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            else
            {
                button.Frame = new CGRect(0, 395, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            button.TouchUpInside += OnButtonClicked;
            this.AddSubview (button);
            isLoaded = true;
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

			int algorithmindex = algorithmlist.IndexOf(algorithmfilterType);
			int keyindex;
			if(algorithmindex==0)
			{
               keyindex= AESkeylist.IndexOf(keysizefilterType);
			   security.Algorithm = PdfEncryptionAlgorithm.AES;
			    if(keyindex == 0)
				{
                  security.KeySize = PdfEncryptionKeySize.Key128Bit;
				}
				 else if(keyindex == 1)
				 {
				   security.KeySize = PdfEncryptionKeySize.Key256Bit;
				 }    
				 else if(keyindex == 2)
				 { 
				   security.KeySize = PdfEncryptionKeySize.Key256BitRevision6;
				 }			
			}
			else
			{
               keyindex=RC4keylist.IndexOf(keysizefilterType);

			    if(keyindex == 0)
				{
                 security.KeySize = PdfEncryptionKeySize.Key40Bit;
				 }
				 else if(keyindex == 1)
				 {
				 security.KeySize = PdfEncryptionKeySize.Key128Bit;
				 } 			
			}

            int optionIndex = options.IndexOf(optionType);
            if (optionIndex == 0)
            {
                security.EncryptionOptions = PdfEncryptionOptions.EncryptAllContents;
            }
            else if (optionIndex == 1)
            {
                security.EncryptionOptions = PdfEncryptionOptions.EncryptAllContentsExceptMetadata;
            }
            else if (optionIndex == 2)
            {
                //Read the file
                Stream file = typeof(DigitalSignatureValidation).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Assets.Products.xml");

                //Creates an attachment
                PdfAttachment attachment = new PdfAttachment("Products.xml", file);

                attachment.ModificationDate = DateTime.Now;

                attachment.Description = "About Syncfusion";

                attachment.MimeType = "application/txt";

                //Adds the attachment to the document
                document.Attachments.Add(attachment);

                security.EncryptionOptions = PdfEncryptionOptions.EncryptOnlyAttachments;
            }


            security.Permissions = PdfPermissionsFlags.Print | PdfPermissionsFlags.FullQualityPrint;
            security.UserPassword = "password";
			security.OwnerPassword = "syncfusion";

             string text = "Security options:\n\n" + String.Format("KeySize: {0}\n\nEncryption Algorithm: {4}\n\nOwner Password: {1}\n\nPermissions: {2}\n\n" +
                "UserPassword: {3}", security.KeySize, security.OwnerPassword, security.Permissions, security.UserPassword, security.Algorithm);

			if(algorithmindex==1)
			{
			    if(keyindex == 2)
				 {
					 text += String.Format("\n\nRevision: {0}", "Revision 6");
				 }
				 else if (keyindex == 1 )
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
                stream.Position = 0;
                SaveiOS iosSave = new SaveiOS();
                iosSave.Save("Secure.pdf", "application/pdf", stream);

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
            if(!isLoaded)
            LoadAllowedTextsLabel();

            base.LayoutSubviews();
        }
		void ShowFilterPicker(object sender, EventArgs e)
		{

			filterDoneButton.Hidden = false;

			filterPicker.Hidden = false;
			button.Hidden = true;
			filterActionLabel.Hidden = true;
			userPasswordLabel.Hidden = true;
			ownerPasswordLabel.Hidden = true;
			filterActionButton.Hidden = true;
			filterActionButton1.Hidden = true;
            optionButton.Hidden = true;
            optionLabel.Hidden = true;

			this.BecomeFirstResponder();
		}

        void HideFilterPicker(object sender, EventArgs e)
        {
           int index = algorithmlist.IndexOf(algorithmfilterType);
            filterDoneButton.Hidden = true;
             
            filterPicker.Hidden = true;
            button.Hidden = false;
            this.BecomeFirstResponder();

            filterActionLabel.Hidden = false;
			userPasswordLabel.Hidden = false;
			ownerPasswordLabel.Hidden = false;


			if (index == 1)
			{
				filterActionButton.Hidden = true;
				filterActionButton1.Hidden = false;
			}
			else
			{
				filterActionButton.Hidden = false;
				filterActionButton1.Hidden = true;
			}

            this.optionType = "Encrypt all contents";
            optionButton.SetTitle(this.optionType, UIControlState.Normal);
            if (algorithmfilterType == "RC4")
            {
                this.keysizefilterType = "40 Bit";
                this.optionLabel.Hidden = true;
                this.optionButton.Hidden = true;
                if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                {
                    this.userPasswordLabel.Frame = new CGRect(10, 235, frameRect.Location.X + frameRect.Size.Width - 20, 50);
                    this.ownerPasswordLabel.Frame = new CGRect(10, 255, frameRect.Location.X + frameRect.Size.Width - 20, 50);
                    button.Frame = new CGRect(0, 300, frameRect.Location.X + frameRect.Size.Width, 10);
                }
                else
                {
                    this.userPasswordLabel.Frame = new CGRect(10, 240, frameRect.Location.X + frameRect.Size.Width - 20, 50);
                    this.ownerPasswordLabel.Frame = new CGRect(10, 260, frameRect.Location.X + frameRect.Size.Width - 20, 50);
                    button.Frame = new CGRect(0, 305, frameRect.Location.X + frameRect.Size.Width, 10);
                }
            }
            else
            {
                this.keysizefilterType = "128 Bit";
                this.optionLabel.Hidden = false;
                this.optionButton.Hidden = false;
                if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                {
                    this.userPasswordLabel.Frame = new CGRect(10, 325, frameRect.Location.X + frameRect.Size.Width - 20, 30);
                    this.ownerPasswordLabel.Frame = new CGRect(10, 355, frameRect.Location.X + frameRect.Size.Width - 20, 30);
                    button.Frame = new CGRect(0, 390, frameRect.Location.X + frameRect.Size.Width, 10);
                }
                else
                {
                    this.userPasswordLabel.Frame = new CGRect(10, 330, frameRect.Location.X + frameRect.Size.Width - 20, 30);
                    this.ownerPasswordLabel.Frame = new CGRect(10, 360, frameRect.Location.X + frameRect.Size.Width - 20, 30);
                    button.Frame = new CGRect(0, 395, frameRect.Location.X + frameRect.Size.Width, 10);
                }
            }

        }

		void ShowFilterActionPicker(object sender, EventArgs e)
		{
            int index = algorithmlist.IndexOf(algorithmfilterType);
			filterActionLabel.Hidden = true;
			userPasswordLabel.Hidden = true;
			ownerPasswordLabel.Hidden = true;
			filterActionButton.Hidden = true;
			if (index == 1)
			{
				filterActionButton.Hidden = true;
				filterActionButton1.Hidden = true;
				filterActionDoneButton.Hidden = true;
				filterActionPicker.Hidden = true;
				filterActionDoneButton1.Hidden = false;
			    filterActionPicker1.Hidden = false;

			}
			else
			{
				filterActionButton.Hidden = true;
				filterActionButton1.Hidden = true;
				filterActionDoneButton.Hidden = false;
			    filterActionPicker.Hidden = false;
				filterActionDoneButton1.Hidden = true;
				filterActionPicker1.Hidden = true;

			}

            optionButton.Hidden = true;
            optionLabel.Hidden = true;

            button.Hidden = true;
			filterButton.Hidden = true;
			this.BecomeFirstResponder();
		}

        void ShowOptionPicker(object sender, EventArgs e)
        {
            optionDoneButton.Hidden = false;

            optionPicker.Hidden = false;
            button.Hidden = true;
            filterActionLabel.Hidden = true;
            userPasswordLabel.Hidden = true;
            ownerPasswordLabel.Hidden = true;
            filterActionButton.Hidden = true;
            filterActionButton1.Hidden = true;
            filterLabel.Hidden = true;
            filterButton.Hidden = true;
            optionButton.Hidden = true;
            optionLabel.Hidden = true;
            this.BecomeFirstResponder();
        }

        void HideFilterActionPicker(object sender, EventArgs e)
		{
            int index = algorithmlist.IndexOf(algorithmfilterType);
			filterActionLabel.Hidden = false;
			userPasswordLabel.Hidden = false;
			ownerPasswordLabel.Hidden = false;
			filterActionDoneButton.Hidden = true;
			filterActionPicker.Hidden = true;
			filterActionDoneButton1.Hidden = true;
			filterActionPicker1.Hidden = true;

			if (index == 1)
			{
				filterActionButton.Hidden = true;
				filterActionButton1.Hidden = false;
			}
			else
			{
				filterActionButton.Hidden = false;
				filterActionButton1.Hidden = true;
			} 
			button.Hidden = false;
			filterButton.Hidden = false;

            if (algorithmfilterType == "RC4")
            {
                this.optionLabel.Hidden = true;
                this.optionButton.Hidden = true;
                if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                {
                    this.userPasswordLabel.Frame = new CGRect(10, 235, frameRect.Location.X + frameRect.Size.Width - 20, 50);
                    this.ownerPasswordLabel.Frame = new CGRect(10, 255, frameRect.Location.X + frameRect.Size.Width - 20, 50);
                    button.Frame = new CGRect(0, 300, frameRect.Location.X + frameRect.Size.Width, 10);
                }
                else
                {
                    this.userPasswordLabel.Frame = new CGRect(10, 240, frameRect.Location.X + frameRect.Size.Width - 20, 50);
                    this.ownerPasswordLabel.Frame = new CGRect(10, 260, frameRect.Location.X + frameRect.Size.Width - 20, 50);
                    button.Frame = new CGRect(0, 305, frameRect.Location.X + frameRect.Size.Width, 10);
                }
            }
            else
            {
                this.optionLabel.Hidden = false;
                this.optionButton.Hidden = false;
                if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                {
                    this.userPasswordLabel.Frame = new CGRect(10, 325, frameRect.Location.X + frameRect.Size.Width - 20, 30);
                    this.ownerPasswordLabel.Frame = new CGRect(10, 355, frameRect.Location.X + frameRect.Size.Width - 20, 30);
                    button.Frame = new CGRect(0, 390, frameRect.Location.X + frameRect.Size.Width, 10);
                }
                else
                {
                    this.userPasswordLabel.Frame = new CGRect(10, 330, frameRect.Location.X + frameRect.Size.Width - 20, 30);
                    this.ownerPasswordLabel.Frame = new CGRect(10, 360, frameRect.Location.X + frameRect.Size.Width - 20, 30);
                    button.Frame = new CGRect(0, 395, frameRect.Location.X + frameRect.Size.Width, 10);
                }
            }

            this.BecomeFirstResponder();
		}
        void HideOptionPicker(object sender, EventArgs e)
        {
            optionDoneButton.Hidden = true;

            optionPicker.Hidden = true;
            button.Hidden = false;
            filterActionLabel.Hidden = false;
            userPasswordLabel.Hidden = false;
            filterActionButton.Hidden = false;
            filterActionButton1.Hidden = true;
            filterLabel.Hidden = false;
            filterButton.Hidden = false;
            optionButton.Hidden = false;
            optionLabel.Hidden = false;
            if (this.optionType == "Encrypt only attachments")
            {
                this.ownerPasswordLabel.Hidden = true;
                if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                {
                    button.Frame = new CGRect(0, 360, frameRect.Location.X + frameRect.Size.Width, 10);
                }
                else
                {
                    button.Frame = new CGRect(0, 365, frameRect.Location.X + frameRect.Size.Width, 10);
                }
            }
            else
            {
                this.ownerPasswordLabel.Hidden = false;
                if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                {
                    this.ownerPasswordLabel.Frame = new CGRect(10, 355, frameRect.Location.X + frameRect.Size.Width - 20, 30);
                    button.Frame = new CGRect(0, 390, frameRect.Location.X + frameRect.Size.Width, 10);
                }
                else
                {
                    this.ownerPasswordLabel.Frame = new CGRect(10, 360, frameRect.Location.X + frameRect.Size.Width - 20, 30);
                    button.Frame = new CGRect(0, 395, frameRect.Location.X + frameRect.Size.Width, 10);
                }
            }
            this.BecomeFirstResponder();
        }
    }
}
