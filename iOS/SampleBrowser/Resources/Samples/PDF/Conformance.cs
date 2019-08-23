#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using System.Collections.Generic;
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
    public partial class Conformance : SampleView
    {
        CGRect frameRect = new CGRect();
        float frameMargin = 8.0f;     
		UILabel label1;
		UILabel conformanceLevellabel;
		UIButton button ;
		private readonly IList<string> layoutList = new List<string>();
        string selectedLayout;
		UIButton layoutDoneButton;
        UIButton layoutButton;
        UIPickerView layoutPicker;
        public Conformance()
        {
			this.layoutList.Add((NSString)"PDF/A-1b");
            this.layoutList.Add((NSString)"PDF/A-2b");
            this.layoutList.Add((NSString)"PDF/A-3b");
            label1 = new UILabel();
			button = new UIButton(UIButtonType.System);
			button.TouchUpInside += OnButtonClicked;
			layoutDoneButton = new UIButton();
            layoutButton = new UIButton();
			conformanceLevellabel = new UILabel();
            layoutPicker = new UIPickerView();
			this.AddSubview(layoutButton);
            this.AddSubview(layoutPicker);
            this.AddSubview(layoutDoneButton);
            selectedLayout = "PDF/A-1b";
        }

        void LoadAllowedTextsLabel()
        {   
            label1.Frame = frameRect;
            label1.TextColor = UIColor.FromRGB(38 / 255.0f, 38 / 255.0f, 38 / 255.0f);
            label1.Text = "This sample demonstrates various PDF conformance support in Essential PDF. Essential PDF provides support for PDF/A-1b, PDF/A-2b, and PDF/A-3b conformance.";
            label1.Font = UIFont.SystemFontOfSize(15);
            label1.Lines = 0;
            label1.LineBreakMode = UILineBreakMode.WordWrap;
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                label1.Font = UIFont.SystemFontOfSize(18);
                label1.Frame = new CGRect(0, 12, frameRect.Location.X + frameRect.Size.Width, 50);
            }
            else {
                label1.Frame = new CGRect(frameRect.Location.X, 12, frameRect.Size.Width, 50);

            }
            this.AddSubview(label1);
			
			#region Conformance Level Label
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                conformanceLevellabel.Font = UIFont.SystemFontOfSize(18);
                conformanceLevellabel.Frame = new CGRect(10, 45, frameRect.Location.X + frameRect.Size.Width - 20, 50);
                layoutButton.Frame = new CGRect(10, 95, frameRect.Location.X + frameRect.Size.Width - 20, 50);
            }
            else
            {
                conformanceLevellabel.Frame = new CGRect(10, 50, frameRect.Location.X + frameRect.Size.Width - 20, 50);
                layoutButton.Frame = new CGRect(10, 100, frameRect.Location.X + frameRect.Size.Width - 20, 50);
            }

            //filter Label
            conformanceLevellabel.TextColor = UIColor.Black;
            conformanceLevellabel.BackgroundColor = UIColor.Clear;
            conformanceLevellabel.Text = "Select Conformance Level Option :";
            conformanceLevellabel.TextAlignment = UITextAlignment.Left;
            conformanceLevellabel.Font = UIFont.FromName("Helvetica", 16f);

            //filter button
            layoutButton.SetTitle("PDF/A-1b", UIControlState.Normal);
            layoutButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            layoutButton.BackgroundColor = UIColor.Clear;
            layoutButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            layoutButton.Hidden = false;
            layoutButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
            layoutButton.Layer.BorderWidth = 4;
            layoutButton.Layer.CornerRadius = 8;
            layoutButton.Font = UIFont.FromName("Helvetica", 16f);
            layoutButton.TouchUpInside += ShowFilterPicker;

            #endregion
			
            #region Layout Picker

            //filterpicker
            PickerModel filterPickermodel = new PickerModel(this.layoutList);
            filterPickermodel.PickerChanged += (sender, e) =>
            {
                this.selectedLayout = e.SelectedValue;
                layoutButton.SetTitle(selectedLayout, UIControlState.Normal);
            };

            layoutPicker.ShowSelectionIndicator = true;
            layoutPicker.Hidden = true;
            layoutPicker.Model = filterPickermodel;
            layoutPicker.BackgroundColor = UIColor.White;

            layoutDoneButton.SetTitle("Done\t", UIControlState.Normal);
            layoutDoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            layoutDoneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            layoutDoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            layoutDoneButton.Hidden = true;
            layoutDoneButton.TouchUpInside += HideFilterPicker;

            layoutPicker.Frame = new CGRect(0, this.Frame.Size.Height / 4 + 20, this.Frame.Size.Width, this.Frame.Size.Height / 3);
            layoutDoneButton.Frame = new CGRect(0, this.Frame.Size.Height / 4 - 20, this.Frame.Size.Width, 40);

            #endregion
			
            button.SetTitle("Generate PDF", UIControlState.Normal);
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                button.Frame = new CGRect(0, 70, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            else {
                button.Frame = new CGRect(frameRect.Location.X, 70, frameRect.Size.Width, 10);

            }
           
            this.AddSubview(button);
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
			PdfDocument document = null;
			int index = layoutList.IndexOf(selectedLayout);
            if (index == 0)
			{
				//Create a new PDF document
                document = new PdfDocument(PdfConformanceLevel.Pdf_A1B);
			}
            else if (index == 1)
			{
                document = new PdfDocument(PdfConformanceLevel.Pdf_A2B);
			}
            else if (index == 2)
			{
                document = new PdfDocument(PdfConformanceLevel.Pdf_A3B);
                Stream imgStream = typeof(Conformance).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Assets.Products.xml");

                PdfAttachment attachment = new PdfAttachment("PDF_A.xml", imgStream);
                attachment.Relationship = PdfAttachmentRelationship.Alternative;
                attachment.ModificationDate = DateTime.Now;

                attachment.Description = "PDF_A";

                attachment.MimeType = "application/xml";

                document.Attachments.Add(attachment);

            }

            PdfPage page = document.Pages.Add();

            //Create font
            Stream arialFontStream = typeof(Conformance).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Assets.arial.ttf");
            Stream imageStream = typeof(Conformance).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.DocIO.Templates.AdventureCycle.jpg");

            PdfFont font = new PdfTrueTypeFont(arialFontStream, 14);

            //Create PDF graphics for the page.
            PdfGraphics graphics = page.Graphics;
            //Load the image from the disk.
            PdfImage img = PdfImage.FromStream(imageStream);
            //Draw the image in the specified location and size.
            graphics.DrawImage(img, new RectangleF(150, 30, 200, 100));


            PdfTextElement textElement = new PdfTextElement("Adventure Works Cycles, the fictitious company on which the AdventureWorks sample databases are based," +
                      " is a large, multinational manufacturing company. The company manufactures and sells metal and composite bicycles to North American, " +
                      "European and Asian commercial markets. While its base operation is located in Bothell, Washington with 290 employees, several regional" +
                      " sales teams are located throughout their market base.")
            {
                Font = font
            };
            PdfLayoutResult layoutResult = textElement.Draw(page, new RectangleF(0, 150, page.GetClientSize().Width, page.GetClientSize().Height));

            MemoryStream stream = new MemoryStream();
            //Save the PDF dcoument.
            document.Save(stream);

            //Close the PDF document.
            document.Close();
			
            stream.Position = 0;

            if (stream != null)
            {
                SaveiOS iosSave = new SaveiOS();
                iosSave.Save("PDF_Ab.pdf", "application/pdf", stream);
            }
        }
		void ShowFilterPicker(object sender, EventArgs e)
        {

            layoutDoneButton.Hidden = false;
            layoutPicker.Hidden = false;
            this.BecomeFirstResponder();
        }

        void HideFilterPicker(object sender, EventArgs e)
        {
            layoutDoneButton.Hidden = true;
            layoutPicker.Hidden = true;
            this.BecomeFirstResponder();
            layoutButton.Hidden = false;
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
