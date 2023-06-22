#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.XlsIO;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using Syncfusion.iOS.Buttons;
using System;
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
    class ExcelToJSON : SampleView
    {
        CGRect frameRect = new CGRect();
        float frameMargin = 8.0f;
        private readonly IList<string> layoutList = new List<string>();
        string selectedLayout;
        UILabel label;
        UILabel pageSetuplabel;
        UIButton layoutDoneButton;
        UIButton layoutButton;
        UIPickerView layoutPicker;
        UIButton inputButton;
        UIButton convertButton;
        SfCheckBox checkSchema;

        public ExcelToJSON()
        {
            this.layoutList.Add((NSString)"Workbook");
            this.layoutList.Add((NSString)"Worksheet");
            this.layoutList.Add((NSString)"Range");
            label = new UILabel();
            inputButton = new UIButton(UIButtonType.System);
            inputButton.TouchUpInside += OnButtonClicked;
            convertButton = new UIButton(UIButtonType.System);
            convertButton.TouchUpInside += OnConvertClicked;

            layoutDoneButton = new UIButton();
            layoutButton = new UIButton();
            layoutPicker = new UIPickerView();
            pageSetuplabel = new UILabel();
            layoutPicker = new UIPickerView();
            layoutDoneButton = new UIButton();
            checkSchema = new SfCheckBox();

            this.AddSubview(label);
            this.AddSubview(pageSetuplabel);
            this.AddSubview(layoutButton);
            this.AddSubview(layoutPicker);
            this.AddSubview(layoutDoneButton);
            this.AddSubview(checkSchema);
            this.AddSubview(convertButton);
            this.AddSubview(inputButton);
        }
        void LoadAllowedTextsLabel()
        {
            #region Description Label
            label.Frame = frameRect;
            label.TextColor = UIColor.FromRGB(38 / 255.0f, 38 / 255.0f, 38 / 255.0f);
            label.Text = "This sample illustrates the conversion of Excel documents to JSON file.";
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
            #endregion

            #region Page Setup Options Label
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                pageSetuplabel.Font = UIFont.SystemFontOfSize(18);
                pageSetuplabel.Frame = new CGRect(10, 45, frameRect.Location.X + frameRect.Size.Width - 20, 50);
                layoutButton.Frame = new CGRect(10, 95, frameRect.Location.X + frameRect.Size.Width - 20, 50);
            }
            else
            {
                pageSetuplabel.Frame = new CGRect(10, 50, frameRect.Location.X + frameRect.Size.Width - 20, 50);
                layoutButton.Frame = new CGRect(10, 100, frameRect.Location.X + frameRect.Size.Width - 20, 50);
            }

            //filter Label
            pageSetuplabel.TextColor = UIColor.Black;
            pageSetuplabel.BackgroundColor = UIColor.Clear;
            pageSetuplabel.Text = "Convert :";
            pageSetuplabel.TextAlignment = UITextAlignment.Left;
            pageSetuplabel.Font = UIFont.FromName("Helvetica", 16f);

            //filter button
            layoutButton.SetTitle("Workbook", UIControlState.Normal);
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

            ///UI CheckBox
            checkSchema.SetTitle("As Schema", UIControlState.Normal);
            checkSchema.SetTitleColor(UIColor.Black, UIControlState.Normal);
            checkSchema.Frame = new CGRect(10, 155, frameRect.Location.X + frameRect.Size.Width - 20, 50);
            checkSchema.IsChecked = true;

            #region Input Template Button
            //button
            inputButton.SetTitle("Input Template", UIControlState.Normal);
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {

                inputButton.Frame = new CGRect(0, 215, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            else
            {
                inputButton.Frame = new CGRect(0, 220, frameRect.Location.X + frameRect.Size.Width, 10);
            }

            #endregion

            #region Convert Button
            convertButton.SetTitle("Convert", UIControlState.Normal);
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                convertButton.Frame = new CGRect(0, 245, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            else
            {
                convertButton.Frame = new CGRect(0, 250, frameRect.Location.X + frameRect.Size.Width, 10);
            }

            #endregion
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            string resourcePath = "SampleBrowser.Samples.XlsIO.Template.ExcelToJSON.xlsx";

            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            //Create a new memory stream.
            MemoryStream stream = new MemoryStream();

            //Copy input template to newly created memory stream.
            fileStream.CopyTo(stream);
            stream.Position = 0;

            SaveAndView(stream, "application/msexcel");
        }
        void OnConvertClicked(object sender, EventArgs e)
        {
            //Instantiate excel engine
            ExcelEngine excelEngine = new ExcelEngine();
            //Excel application
            IApplication application = excelEngine.Excel;
            string resourcePath = "SampleBrowser.Samples.XlsIO.Template.ExcelToJSON.xlsx";
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            //Open Workbook
            IWorkbook workbook = application.Workbooks.Open(fileStream);

            IWorksheet sheet = workbook.Worksheets[0];

            IRange range = sheet.Range["A2:B10"];

            bool isSchema = checkSchema.IsChecked.Value;

            int index = layoutList.IndexOf(selectedLayout);
            MemoryStream stream = new MemoryStream();
            if (index == 0)
                workbook.SaveAsJson(stream, isSchema);
            else if (index == 1)
                workbook.SaveAsJson(stream, sheet, isSchema);
            else if (index == 2)
                workbook.SaveAsJson(stream, range, isSchema);

            workbook.Close();
            excelEngine.Dispose();
            SaveAndView(stream, "application/json");
        }
        void SaveAndView(MemoryStream stream, string contentType)
        {
            if (stream != null)
            {
                stream.Position = 0;
                SaveiOS iOSSave = new SaveiOS();
                if (contentType == "application/json")
                    iOSSave.Save("ExcelToJSON.json", contentType, stream);
                else
                    iOSSave.Save("Input Template.xlsx", contentType, stream);
            }
        }
        void ShowFilterPicker(object sender, EventArgs e)
        {

            layoutDoneButton.Hidden = false;
            layoutPicker.Hidden = false;
            inputButton.Hidden = true;
            convertButton.Hidden = true;
            this.BecomeFirstResponder();
            checkSchema.Hidden = true;
        }

        void HideFilterPicker(object sender, EventArgs e)
        {
            layoutDoneButton.Hidden = true;
            layoutPicker.Hidden = true;
            inputButton.Hidden = false;
            convertButton.Hidden = false;
            this.BecomeFirstResponder();
            layoutButton.Hidden = false;
            checkSchema.Hidden = false;
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