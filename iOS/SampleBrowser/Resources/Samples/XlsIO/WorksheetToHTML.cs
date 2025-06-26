#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.XlsIO;
using Syncfusion.iOS.Buttons;
using System.IO;
using COLOR = Syncfusion.Drawing;
using System.Collections.Generic;
using System.Reflection;
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
    public class WorksheetToHTML : SampleView
    {
        CGRect frameRect = new CGRect();
        float frameMargin = 8.0f;
        UILabel label;
        UILabel imageTypelabel;
        UIButton imageType;
        UIButton inputButton;
        UIButton convertButton;
        bool isGenerateClicked = false;
        //RadioButton
        SfRadioGroup radioGroup = new SfRadioGroup();
        SfRadioButton bookButton = new SfRadioButton();
        SfRadioButton sheetButton = new SfRadioButton();
        public WorksheetToHTML()
        {
            label = new UILabel();
            imageTypelabel = new UILabel();
			imageType = new UIButton();
            inputButton = new UIButton(UIButtonType.System);
            inputButton.TouchUpInside += OnButtonClicked;
            convertButton = new UIButton(UIButtonType.System);
            convertButton.TouchUpInside += OnConvertClicked;
        }

        void LoadAllowedTextsLabel()
        {
            #region Description Label
            label.Frame = frameRect;
            label.TextColor = UIColor.FromRGB(38 / 255.0f, 38 / 255.0f, 38 / 255.0f);
            label.Text = "This sample illustrates the conversion of a simple Excel document to HTML file.";
            label.Font = UIFont.SystemFontOfSize(15);
            label.Lines = 0;
            label.SizeToFit();
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
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                imageTypelabel.Font = UIFont.SystemFontOfSize(18);
                imageTypelabel.Frame = new CGRect(10, 45, frameRect.Location.X + frameRect.Size.Width - 20, 50);
                imageType.Frame = new CGRect(10, 95, frameRect.Location.X + frameRect.Size.Width - 20, 40);
            }
            else
            {
                imageTypelabel.Frame = new CGRect(10, 50, frameRect.Location.X + frameRect.Size.Width - 20, 50);
                imageType.Frame = new CGRect(10, 100, frameRect.Location.X + frameRect.Size.Width - 20, 40);
            }

            //filter Label
            imageTypelabel.TextColor = UIColor.Black;
            imageTypelabel.BackgroundColor = UIColor.Clear;
            imageTypelabel.Text = "Convert Type:";
            imageTypelabel.TextAlignment = UITextAlignment.Left;
            imageTypelabel.Font = UIFont.FromName("Helvetica", 16f);
            this.AddSubview(imageTypelabel);

            #endregion

            #region Radio Buttons
            radioGroup.Axis = UILayoutConstraintAxis.Horizontal;

            bookButton.SetTitle("Workbook", UIControlState.Normal);
            bookButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
            radioGroup.AddArrangedSubview(bookButton);
            sheetButton.SetTitle("Worksheet", UIControlState.Normal);
            sheetButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
            radioGroup.AddArrangedSubview(sheetButton);
            bookButton.IsChecked = true;
            radioGroup.Distribution = UIStackViewDistribution.FillProportionally;

            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                radioGroup.Frame = new CGRect(130, 55, frameRect.Width / 2 - 40, 30);
            }
            else
            {
                radioGroup.Frame = new CGRect(20, 95, frameRect.Location.X + frameRect.Size.Width, 30);
            }
            this.AddSubview(radioGroup);
            #endregion

            #region Input Template Button
            //button
            inputButton.SetTitle("Input Template", UIControlState.Normal);
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {

                inputButton.Frame = new CGRect(0, 105, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            else
            {
                inputButton.Frame = new CGRect(0, (this.Frame.Size.Height / 4) + 25, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            this.AddSubview(inputButton);
            #endregion

            #region Convert Button
            convertButton.SetTitle("Convert", UIControlState.Normal);
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                convertButton.Frame = new CGRect(0, 135, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            else
            {
                convertButton.Frame = new CGRect(0, this.Frame.Size.Height / 4 + 55, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            this.AddSubview(convertButton);
            #endregion
        }



        void OnButtonClicked(object sender, EventArgs e)
        {
            //Load the input template from assembly.
            string resourcePath = "SampleBrowser.Samples.XlsIO.Template.NorthwindTemplate.xlsx";
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            //Create memory stream
            MemoryStream stream = new MemoryStream();

            //Copy input template to newly created memory stream.
            fileStream.CopyTo(stream);
            stream.Position = 0;

            if (stream != null)
            {
                SaveiOS iOSSave = new SaveiOS();
                iOSSave.Save("Template.xlsx", "application/msexcel", stream);
            }

        }
        void OnConvertClicked(object sender, EventArgs e)
        {
            //Instantiate excel engine
            ExcelEngine excelEngine = new ExcelEngine();
            //Excel application
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2013;

            #region Initializing Workbook

            //Load the input template from assembly.
            string resourcePath = "SampleBrowser.Samples.XlsIO.Template.NorthwindTemplate.xlsx";
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            //Open workbook from stream
            IWorkbook workbook = application.Workbooks.Open(fileStream);

            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];
            #endregion
            
            MemoryStream stream = new MemoryStream();
            
            if(sheetButton.IsChecked != null && (bool)sheetButton.IsChecked)
            {
                sheet.SaveAsHtml(stream);
            }
            else
            {
                workbook.SaveAsHtml(stream);
            }
            
            if (stream != null)
            {
                stream.Position = 0;
                StreamReader reader = new StreamReader(stream);
                string htmlString = reader.ReadToEnd();
                UIWebView webView = new UIWebView(this.Bounds);
                webView.Frame = new CGRect(0, 0, this.Bounds.Width, this.Bounds.Height);
                isGenerateClicked = true;
                this.AddSubview(webView);
                webView.LoadHtmlString(htmlString, NSBundle.MainBundle.BundleUrl);
                webView.ScalesPageToFit = false;
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

            if(!isGenerateClicked)
                LoadAllowedTextsLabel();

            base.LayoutSubviews();
        }
    }
}
