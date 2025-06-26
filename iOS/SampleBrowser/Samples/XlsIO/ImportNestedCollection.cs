#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.XlsIO;
using System.IO;
using Syncfusion.Drawing;
using System.Reflection;
using System.Collections.Generic;
using Syncfusion.iOS.Buttons;
using System.ComponentModel;
using System.Xml.Serialization;
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
	public partial class ImportNestedCollection : SampleView
	{
		public ImportNestedCollection()
		{
			this.layoutList.Add((NSString)"Default");
            this.layoutList.Add((NSString)"Merge");
            this.layoutList.Add((NSString)"Repeat");
        }

        CGRect frameRect = new CGRect ();
		float frameMargin = 8.0f;
        private readonly IList<string> layoutList = new List<string>();
        string selectedLayout;
        UILabel layoutLabel;
        UIButton layoutDoneButton;
        UIButton layoutButton;
        UIPickerView layoutPicker;
        UILabel groupLabel;
        UISwitch groupSwitch;
        UILabel groupOptionsLabel;
        SfRadioGroup radioGroup = new SfRadioGroup();
        SfRadioButton expandButton = new SfRadioButton();
        SfRadioButton collapseButton = new SfRadioButton();
        UITextField textField;
        UIButton button;
		bool isLoaded = false;
        bool isGroupEnabled = false;
        bool isTextEnabled = false;
        
        void LoadAllowedTextsLabel()
		{
            
            #region Description Label
                  
            UILabel label = new UILabel ();
			label.Frame = frameRect;
			label.TextColor = UIColor.FromRGB (38/255.0f, 38/255.0f, 38/255.0f);
			label.Text = "This sample demonstrates how to filter data within a range of Excel worksheet.";
			label.Font = UIFont.SystemFontOfSize(15);
			label.Lines 				= 0;
			label.LineBreakMode 		= UILineBreakMode.WordWrap;
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				label.Font = UIFont.SystemFontOfSize(18);
				label.Frame = new CGRect (5, 5,frameRect.Location.X + frameRect.Size.Width  ,35);
			} 
			else {
				label.Frame = new CGRect(5, 5, frameRect.Location.X + frameRect.Size.Width  ,50);

			}
			this.AddSubview (label);
            #endregion

            #region Layout Region
            layoutLabel = new UILabel();
            layoutDoneButton = new UIButton();
            layoutButton = new UIButton();
            layoutPicker = new UIPickerView();
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                layoutLabel.Font = UIFont.SystemFontOfSize(18);
                layoutLabel.Frame = new CGRect(10, 45, this.Frame.Size.Width / 2, 50);
                layoutButton.Frame = new CGRect(150, 45, this.Frame.Size.Width / 2, 40);
            }
            else
            {
                layoutLabel.Frame = new CGRect(10, 50, this.Frame.Size.Width / 2, 50);
				layoutButton.Frame = new CGRect(150, 50, this.Frame.Size.Width / 2, 40);
            }

            //filter Label
            layoutLabel.TextColor = UIColor.Black;
            layoutLabel.BackgroundColor = UIColor.Clear;
            layoutLabel.Text = @"Layout Options";
            layoutLabel.TextAlignment = UITextAlignment.Left;
            layoutLabel.Font = UIFont.FromName("Helvetica", 16f);
            this.AddSubview(layoutLabel);
			
            //filter button
            layoutButton.SetTitle("Default", UIControlState.Normal);
            layoutButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            layoutButton.BackgroundColor = UIColor.Clear;
            layoutButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            layoutButton.Hidden = false;
            layoutButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
            layoutButton.Layer.BorderWidth = 4;
            layoutButton.Layer.CornerRadius = 8;
			layoutButton.Font = UIFont.FromName("Helvetica", 16f);
            this.AddSubview(layoutButton);
            layoutButton.TouchUpInside += ShowLayoutPicker;

            //filterpicker
            PickerModel layoutPickermodel = new PickerModel(this.layoutList);
            layoutPickermodel.PickerChanged += (sender, e) =>
            {
                this.selectedLayout = e.SelectedValue;
                layoutButton.SetTitle(selectedLayout, UIControlState.Normal);
            };
            layoutPicker = new UIPickerView();
            layoutPicker.ShowSelectionIndicator = true;
            layoutPicker.Hidden = true;
            layoutPicker.Model = layoutPickermodel;
            layoutPicker.BackgroundColor = UIColor.White;

            //filterDoneButtonn
            layoutDoneButton = new UIButton();
            layoutDoneButton.SetTitle("Done\t", UIControlState.Normal);
            layoutDoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            layoutDoneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            layoutDoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            layoutDoneButton.Hidden = true;
            layoutDoneButton.TouchUpInside += HideLayoutPicker;

            layoutPicker.Frame = new CGRect(150, 50, this.Frame.Size.Width / 2, this.Frame.Size.Height / 3);
			layoutDoneButton.Frame = new CGRect(150, 55, this.Frame.Size.Width / 2, 40);
			this.AddSubview(layoutPicker);
			this.AddSubview(layoutDoneButton);
            #endregion

            #region Group Region
            
            //unique records label
            groupLabel = new UILabel();
            groupLabel.TextColor = UIColor.Black;
            groupLabel.BackgroundColor = UIColor.Clear;
            groupLabel.Text = @"Apply Group";
            groupLabel.TextAlignment = UITextAlignment.Left;
            groupLabel.Font = UIFont.FromName("Helvetica", 16f);
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                groupLabel.Frame = new CGRect(60, 105, this.Frame.Size.Width / 2, 40);
            else
                groupLabel.Frame = new CGRect(60, 110, this.Frame.Size.Width / 2, 40);
            this.AddSubview(groupLabel);

            //unique records switch
            groupSwitch = new UISwitch();
            groupSwitch.On = false;
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                groupSwitch.Frame = new CGRect(150, 105, this.Frame.Size.Width / 2, 40);
            else
                groupSwitch.Frame = new CGRect(150, 110, this.Frame.Size.Width / 2, 40);

            groupSwitch.TouchUpInside += ShowGroupOptions;
            this.AddSubview(groupSwitch);

            #endregion

            #region Group Options Region

            //filter Label
            groupOptionsLabel = new UILabel();
            groupOptionsLabel.TextColor = UIColor.Black;
            groupOptionsLabel.BackgroundColor = UIColor.Clear;
            groupOptionsLabel.Text = "Options";
            groupOptionsLabel.TextAlignment = UITextAlignment.Left;
            groupOptionsLabel.Font = UIFont.FromName("Helvetica", 16f);
            
            this.AddSubview(groupOptionsLabel);
            groupOptionsLabel.Hidden = true;

            radioGroup.Axis = UILayoutConstraintAxis.Vertical;
            expandButton.SetTitle("Expand", UIControlState.Normal);
            radioGroup.AddArrangedSubview(expandButton);
            collapseButton.SetTitle("Group at Level", UIControlState.Normal);
            radioGroup.AddArrangedSubview(collapseButton);
            expandButton.IsChecked = true;
            radioGroup.Distribution = UIStackViewDistribution.FillProportionally;
            
            this.AddSubview(radioGroup);
            radioGroup.Hidden = true;

            expandButton.StateChanged += ShowHideTextField;
            collapseButton.StateChanged += ShowHideTextField;
            
            textField = new UITextField();
            textField.TextColor = UIColor.Black;
            textField.BackgroundColor = UIColor.Clear;
            textField.Text = "1";
            textField.TextAlignment = UITextAlignment.Left;
            textField.Font = UIFont.FromName("Helvetica", 16f);
            
            this.AddSubview(textField);
            textField.Hidden = true;

            #endregion

            #region Button Region
            //button
            button = new UIButton (UIButtonType.System);
			button.SetTitle("Generate Excel", UIControlState.Normal);
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
				button.Frame = new CGRect(0, 155, frameRect.Location.X + frameRect.Size.Width, 20);
			}
			else
			{
				button.Frame = new CGRect(0, 160, frameRect.Location.X + frameRect.Size.Width, 20);
			}
			button.TouchUpInside += OnButtonClicked;
			this.AddSubview (button);
            #endregion

            isLoaded = true;
		}

        void OnButtonClicked(object sender, EventArgs e)
		{
			ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
			application.DefaultVersion = ExcelVersion.Excel2013;
            IWorkbook workbook = application.Workbooks.Create(1);
            IWorksheet worksheet = workbook.Worksheets[0];

            IList<Brands> list = GetVehicleDetails();

            int index = layoutList.IndexOf(selectedLayout);
            ExcelImportDataOptions importDataOptions = new ExcelImportDataOptions();
            importDataOptions.FirstRow = 4;

            if (index == 0)
                importDataOptions.NestedDataLayoutOptions = ExcelNestedDataLayoutOptions.Default;
            else if (index == 1)
                importDataOptions.NestedDataLayoutOptions = ExcelNestedDataLayoutOptions.Merge;
            else if (index == 2)
                importDataOptions.NestedDataLayoutOptions = ExcelNestedDataLayoutOptions.Repeat;

            if (groupSwitch.Selected)
            {
                if (expandButton.IsChecked.Value)
                {
                    importDataOptions.NestedDataGroupOptions = ExcelNestedDataGroupOptions.Expand;
                }
                else if (collapseButton.IsChecked.Value)
                {
                    importDataOptions.NestedDataGroupOptions = ExcelNestedDataGroupOptions.Collapse;
                    if (textField.Text != string.Empty)
                    {
                        importDataOptions.CollapseLevel = int.Parse(textField.Text);
                    }
                }
            }

            worksheet.ImportData(list, importDataOptions);

            #region Define Styles
            IStyle pageHeader = workbook.Styles.Add("PageHeaderStyle");
            IStyle tableHeader = workbook.Styles.Add("TableHeaderStyle");

            pageHeader.Font.FontName = "Calibri";
            pageHeader.Font.Size = 16;
            pageHeader.Font.Bold = true;
            pageHeader.Color = Color.FromArgb(0, 146, 208, 80);
            pageHeader.HorizontalAlignment = ExcelHAlign.HAlignCenter;
            pageHeader.VerticalAlignment = ExcelVAlign.VAlignCenter;

            tableHeader.Font.Bold = true;
            tableHeader.Font.FontName = "Calibri";
            tableHeader.Color = Color.FromArgb(0, 146, 208, 80);

            #endregion

            #region Apply Styles
            // Apply style for header
            worksheet["A1:C2"].Merge();
            worksheet["A1"].Text = "Automobile Brands in the US";
            worksheet["A1"].CellStyle = pageHeader;

            worksheet["A4:C4"].CellStyle = tableHeader;

            worksheet["A1:C1"].CellStyle.Font.Bold = true;
            worksheet.UsedRange.AutofitColumns();

            #endregion

            MemoryStream stream = new MemoryStream();
			workbook.SaveAs(stream);
			workbook.Close();
			excelEngine.Dispose();

			if (stream != null)
			{
				SaveiOS iOSSave = new SaveiOS ();
				iOSSave.Save ("ImportData.xlsx", "application/msexcel", stream);
			}
		}

		public override void LayoutSubviews ()
		{
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				frameMargin = 0.0f;
			}
			frameRect = Bounds;
			frameRect.Location = new CGPoint (frameRect.Location.X + frameMargin, frameRect.Location.Y + 1.5f * frameMargin);
			frameRect.Size = new CGSize(frameRect.Size.Width - (frameRect.Location.X + frameMargin), frameRect.Size.Height - (frameRect.Location.Y + 1.5f * frameMargin));
			if(!isLoaded)
			LoadAllowedTextsLabel ();            
            base.LayoutSubviews();         
		}

        void ShowLayoutPicker(object sender, EventArgs e)
        {
            layoutDoneButton.Hidden = false;
            layoutPicker.Hidden = false;
            groupLabel.Hidden = true;
            groupSwitch.Hidden = true;
            groupOptionsLabel.Hidden = true;
            radioGroup.Hidden = true;
            textField.Hidden = true;
            button.Hidden = true;
            this.BecomeFirstResponder();
        }

        void HideLayoutPicker(object sender, EventArgs e)
        {
            layoutDoneButton.Hidden = true;
            layoutPicker.Hidden = true;
            groupLabel.Hidden = false;
            groupSwitch.Hidden = false;
            if (isGroupEnabled)
            {
                groupOptionsLabel.Hidden = false;
                radioGroup.Hidden = false;
                if (isTextEnabled)
                {
                    textField.Hidden = false;
                }
            }
            
            button.Hidden = false;
            this.BecomeFirstResponder();            
        }

        void ShowGroupOptions(object sender, EventArgs e)
        {
            isGroupEnabled = true;
            if (groupSwitch.On)
            {
                if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                    groupOptionsLabel.Frame = new CGRect(150, 150, this.Frame.Size.Width / 2, 25);
                else
                    groupOptionsLabel.Frame = new CGRect(150, 155, this.Frame.Size.Width / 2, 25);

                groupOptionsLabel.Hidden = false;

                if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                {
                    radioGroup.Frame = new CGRect(150, 180, this.Frame.Size.Width / 2, 80);
                }
                else
                {
                    radioGroup.Frame = new CGRect(150, 185, this.Frame.Size.Width / 2, 80);
                }
                radioGroup.Hidden = false;

                if (isTextEnabled)
                {
                    if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                        textField.Frame = new CGRect(160, 270, this.Frame.Size.Width / 2, 30);
                    else
                        textField.Frame = new CGRect(160, 275, this.Frame.Size.Width / 2, 30);

                    textField.Hidden = false;

                    if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                    {
                        button.Frame = new CGRect(0, 310, frameRect.Location.X + frameRect.Size.Width, 20);
                    }
                    else
                    {
                        button.Frame = new CGRect(0, 315, frameRect.Location.X + frameRect.Size.Width, 20);
                    }
                }
                else
                {
                    if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                    {
                        button.Frame = new CGRect(0, 270, frameRect.Location.X + frameRect.Size.Width, 20);
                    }
                    else
                    {
                        button.Frame = new CGRect(0, 275, frameRect.Location.X + frameRect.Size.Width, 20);
                    }
                }                

            }
            else
            {
                groupOptionsLabel.Hidden = true;
                radioGroup.Hidden = true;
                textField.Hidden = true;

                if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                {
                    button.Frame = new CGRect(0, 155, frameRect.Location.X + frameRect.Size.Width, 20);
                }
                else
                {
                    button.Frame = new CGRect(0, 160, frameRect.Location.X + frameRect.Size.Width, 20);
                }

                isGroupEnabled = false;
            }
            this.BecomeFirstResponder();
        }

        void ShowHideTextField(object sender, EventArgs e)
        {
            if(collapseButton.IsChecked.Value)
            {
                isTextEnabled = true;

                if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                    textField.Frame = new CGRect(160, 270, this.Frame.Size.Width / 2, 30);
                else
                    textField.Frame = new CGRect(160, 275, this.Frame.Size.Width / 2, 30);

                textField.Hidden = false;
                
                if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                {
                    button.Frame = new CGRect(0, 310, frameRect.Location.X + frameRect.Size.Width, 20);
                }
                else
                {
                    button.Frame = new CGRect(0, 315, frameRect.Location.X + frameRect.Size.Width, 20);
                }
            }
            else
            {
                isTextEnabled = false;
                textField.Hidden = true;
                if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                {
                    button.Frame = new CGRect(0, 270, frameRect.Location.X + frameRect.Size.Width, 20);
                }
                else
                {
                    button.Frame = new CGRect(0, 275, frameRect.Location.X + frameRect.Size.Width, 20);
                }
            }
            this.BecomeFirstResponder();
        }

        #region Helper Methods
        private IList<Brands> GetVehicleDetails()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(BrandObjects));
            string resourcePath = "SampleBrowser.Samples.XlsIO.Template.ExportData.xml";
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);
            TextReader textReader = new StreamReader(fileStream);
            BrandObjects brands = (BrandObjects)deserializer.Deserialize(textReader);

            List<Brands> list = new List<Brands>();
            string brandName = brands.BrandObject[0].BrandName;
            string vehicleType = brands.BrandObject[0].VahicleType;
            string modelName = brands.BrandObject[0].ModelName;
            Brands brand = new Brands(brandName);
            brand.VehicleTypes = new List<VehicleTypes>();

            VehicleTypes vehicle = new VehicleTypes(vehicleType);
            vehicle.Models = new List<Models>();
            Models model = new Models(modelName);

            brand.VehicleTypes.Add(vehicle);
            list.Add(brand);

            foreach (BrandObject brandObj in brands.BrandObject)
            {
                if (brandName == brandObj.BrandName)
                {
                    if (vehicleType == brandObj.VahicleType)
                    {
                        vehicle.Models.Add(new Models(brandObj.ModelName));
                        continue;
                    }
                    else
                    {
                        vehicle = new VehicleTypes(brandObj.VahicleType);
                        vehicle.Models = new List<Models>();
                        vehicle.Models.Add(new Models(brandObj.ModelName));
                        brand.VehicleTypes.Add(vehicle);
                        vehicleType = brandObj.VahicleType;
                    }
                    continue;
                }
                else
                {
                    brand = new Brands(brandObj.BrandName);
                    vehicle = new VehicleTypes(brandObj.VahicleType);
                    vehicle.Models = new List<Models>();
                    vehicle.Models.Add(new Models(brandObj.ModelName));
                    brand.VehicleTypes = new List<VehicleTypes>();
                    brand.VehicleTypes.Add(vehicle);
                    vehicleType = brandObj.VahicleType;
                    list.Add(brand);
                    brandName = brandObj.BrandName;
                }
            }
            textReader.Close();
            return list;
        }
        #endregion
    }

    #region Helper Class
    [XmlRootAttribute("BrandObjects")]
    public class BrandObjects
    {
        [XmlElement("BrandObject")]
        public BrandObject[] BrandObject { get; set; }
    }
    public class BrandObject
    {
        public string BrandName { get; set; }
        public string VahicleType { get; set; }
        public string ModelName { get; set; }
    }

    public class Brands
    {
        private string m_brandName;
        [DisplayNameAttribute("Brand")]
        public string BrandName
        {
            get { return m_brandName; }
            set { m_brandName = value; }
        }

        private IList<VehicleTypes> m_vehicleTypes;
        public IList<VehicleTypes> VehicleTypes
        {
            get { return m_vehicleTypes; }
            set { m_vehicleTypes = value; }
        }

        public Brands(string brandName)
        {
            m_brandName = brandName;
        }
    }

    public class VehicleTypes
    {
        private string m_vehicleName;
        [DisplayNameAttribute("Vehicle Type")]
        public string VehicleName
        {
            get { return m_vehicleName; }
            set { m_vehicleName = value; }
        }

        private IList<Models> m_models;
        public IList<Models> Models
        {
            get { return m_models; }
            set { m_models = value; }
        }

        public VehicleTypes(string vehicle)
        {
            m_vehicleName = vehicle;
        }
    }

    public class Models
    {
        private string m_modelName;
        [DisplayNameAttribute("Model")]
        public string ModelName
        {
            get { return m_modelName; }
            set { m_modelName = value; }
        }

        public Models(string name)
        {
            m_modelName = name;
        }
    }
    #endregion
}

