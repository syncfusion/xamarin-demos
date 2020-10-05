#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.iOS.ComboBox;

#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;

#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using nint = System.Int32;
using nuint = System.Int32;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
using nfloat  = System.Single;
#endif

namespace SampleBrowser
{
	public class ComboBox_Mobile:SampleView
	{
        NSMutableArray sizeDetails = new NSMutableArray();
        UILabel isEditableLabel,diacriticModeLabel,comboBoxModeLabel,sizeLabel,textColorLabel,backColorLabel,waterMarkLabel,spaceLabel;
		UIButton comboBoxButton = new UIButton ();
        UIButton sizeButton = new UIButton();
        UIButton textColorButton, backColorButton;
		UIButton suggestionDoneButton=new UIButton();
		UIPickerView suggestionModePicker, comboBoxModePicker,sizePicker,textColorPicker,backColorPicker;
		UITextView waterMarkText;
		private string selectedType;
		private readonly IList<string> exp = new List<string> ();
		private string experienceSelectedType;
        SfComboBox sizeComboBox,resolutionComboBox,orientationComboBox;
		UILabel comboBoxHeaderLabel,sizetextLabel,resolutionLabel,orientationLabel;
        UISwitch isEditableSwitch, diacriticsSwitch;
		UIButton comboBoxDoneButton = new UIButton ();
        UIButton sizeDoneButton, textColorDoneButton, backColorDoneButton;
		NSMutableArray jobTitle = new NSMutableArray ();
        NSMutableArray resolutionDetails = new NSMutableArray();
        NSMutableArray orientationDetails = new NSMutableArray();
        PickerModel comboBoxModel,sizeModel,textColorModel,backColorModel;
        public UIView option = new UIView();
        UIView controlView = new UIView();
        UIScrollView propertyScrollView;

		private readonly IList<string> comboBoxModeList = new List<string>{
			"Append",
			"Suggest",
			"SuggestAppend"
		};

        private readonly IList<string> sizeList = new List<string>{
            "Small",
            "Medium",
            "Large"
        };

        private readonly IList<string> textColorList = new List<string>{
            "Black",
            "Blue",
            "Red",
            "Yellow"
        };

        private readonly IList<string> backColorList = new List<string>{
            "Transparent",
            "Blue",
            "Red",
            "Yellow"
        };

		public void  createOptionView()
		{
			propertyScrollView = new UIScrollView();
			propertyScrollView.Frame = this.OptionView.Frame;
			propertyScrollView.ContentSize = new CGSize(propertyScrollView.Frame.Width,propertyScrollView.Frame.Height+120);
			this.propertyScrollView.AddSubview (textColorLabel);
			this.propertyScrollView.AddSubview (backColorLabel);
            this.propertyScrollView.AddSubview(waterMarkLabel);
            this.propertyScrollView.AddSubview(spaceLabel);
            this.propertyScrollView.AddSubview (sizeButton);
            this.propertyScrollView.AddSubview (textColorButton);
            this.propertyScrollView.AddSubview(backColorButton);
			this.propertyScrollView.AddSubview (waterMarkText);
			this.propertyScrollView.AddSubview (isEditableLabel);
            this.propertyScrollView.AddSubview(diacriticModeLabel);
            this.propertyScrollView.AddSubview(diacriticsSwitch);
            this.propertyScrollView.AddSubview(isEditableSwitch);
			this.propertyScrollView.AddSubview (comboBoxModeLabel);
			this.propertyScrollView.AddSubview (sizeLabel);
			this.propertyScrollView.AddSubview (comboBoxButton);
			this.propertyScrollView.AddSubview (suggestionModePicker);
			this.propertyScrollView.AddSubview (comboBoxModePicker);
            this.propertyScrollView.AddSubview(sizePicker);
            this.propertyScrollView.AddSubview(textColorPicker);
            this.propertyScrollView.AddSubview(backColorPicker);
			this.propertyScrollView.AddSubview (suggestionDoneButton);
            this.propertyScrollView.AddSubview(comboBoxDoneButton);
            this.propertyScrollView.AddSubview(sizeDoneButton);
            this.propertyScrollView.AddSubview(textColorDoneButton);
            this.propertyScrollView.AddSubview(backColorDoneButton);
			this.option.AddSubview(propertyScrollView);
		}
		public ComboBox_Mobile()
		{
			mainPageDesign();
			//sizeComboBox
			sizeComboBox = new SfComboBox();
            sizeComboBox.ComboBoxSource = sizeDetails ;
            sizeComboBox.IsEditable = false;
            sizeComboBox.Text =  (NSString)"150%(Recommended)";
            sizeComboBox.SuggestionMode = SuggestionMode.StartsWith;
			sizeComboBox.MaxDropDownHeight=160;
            sizeComboBox.ItemHeight = 40;
            sizeComboBox.DropDownCornerRadius = 5;
            sizeComboBox.Watermark = (NSString)"Search Here";

			//resolutionComboBox

            resolutionComboBox = new SfComboBox();
            resolutionComboBox.IsEditable = false;
            resolutionComboBox.MaxDropDownHeight = 160;
            resolutionComboBox.ItemHeight = 40;
            resolutionComboBox.DropDownCornerRadius = 5;
            resolutionComboBox.Text = (NSString)"1920 x 1080 (Recommended)";
            resolutionComboBox.ComboBoxSource = resolutionDetails;
			resolutionComboBox.SuggestionMode = SuggestionMode.StartsWith;
            resolutionComboBox.Watermark = (NSString)"Search Here";

            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                this.controlView.AddSubview(sizeComboBox);
                this.controlView.AddSubview(resolutionComboBox);
                this.AddSubview(controlView);
            }
            else
            {
                this.AddSubview(sizeComboBox);
                this.AddSubview(resolutionComboBox); 
            }
			
			loadOptionView();


		}
		public void mainPageDesign()
		{ 
			this.OptionView = new UIView();
            controlView = new UIView();
			this.addingSourceList();
            isEditableSwitch = new UISwitch();
            diacriticsSwitch = new UISwitch();
			suggestionModePicker = new UIPickerView();
			comboBoxModePicker = new UIPickerView();
            sizePicker = new UIPickerView();
            textColorPicker = new UIPickerView();
            backColorPicker = new UIPickerView();
            sizeDoneButton = new UIButton();
            textColorDoneButton = new UIButton();
            backColorDoneButton = new UIButton();
			comboBoxModel = new PickerModel(comboBoxModeList);
			comboBoxModePicker.Model = comboBoxModel;
            comboBoxModePicker.Select(1,0,false);
            sizeModel = new PickerModel(sizeList);
            sizePicker.Model = sizeModel;
            sizePicker.Select(2, 0, false);
            textColorModel = new PickerModel(textColorList);
            textColorPicker.Model = textColorModel;
            textColorPicker.Select(0, 0, false);
            backColorModel = new PickerModel(backColorList);
            backColorPicker.Model = backColorModel;
            backColorPicker.Select(0, 0, false);
			isEditableLabel = new UILabel();
            diacriticModeLabel = new UILabel();
			comboBoxModeLabel = new UILabel();
			sizeLabel = new UILabel();
			textColorLabel = new UILabel();
			backColorLabel = new UILabel();
            waterMarkLabel = new UILabel();
            spaceLabel = new UILabel();
			comboBoxButton = new UIButton();
            sizeButton = new UIButton();
            textColorButton = new UIButton();
            backColorButton = new UIButton();
			comboBoxHeaderLabel = new UILabel();
			sizetextLabel = new UILabel();
			resolutionLabel = new UILabel();
			orientationLabel = new UILabel();
			//searchButton = new UIButton();

			//comboBoxHeaderLabell
			comboBoxHeaderLabel.Text = "Scale And Layout";
			comboBoxHeaderLabel.TextColor = UIColor.Black;
			comboBoxHeaderLabel.TextAlignment = UITextAlignment.Left;
			comboBoxHeaderLabel.Font = UIFont.FromName("Helvetica-Bold", 15f);

			//sizetextLabell
            sizetextLabel.Text = "Change the size of text, apps and other items";
            sizetextLabel.Lines = 2;
            sizetextLabel.LineBreakMode = UILineBreakMode.WordWrap;
			sizetextLabel.TextColor = UIColor.Black;
			sizetextLabel.TextAlignment = UITextAlignment.Left;
			sizetextLabel.Font = UIFont.FromName("Helvetica", 16f);
		
			//resolutionLabell
			resolutionLabel.Text = "Resolution";
			resolutionLabel.TextColor = UIColor.Black;
			resolutionLabel.TextAlignment = UITextAlignment.Left;
			resolutionLabel.Font = UIFont.FromName("Helvetica", 16f);

			//orientationLabell
			orientationLabel.Text = "Orientation";
			orientationLabel.TextColor = UIColor.Black;
			orientationLabel.TextAlignment = UITextAlignment.Left;
			orientationLabel.Font = UIFont.FromName("Helvetica", 16f);

			//experienceButtonn
            orientationComboBox = new SfComboBox();
            orientationComboBox.ComboBoxSource = orientationDetails;
            orientationComboBox.IsEditable = false;
            orientationComboBox.Text = (NSString)"Landscape";
            orientationComboBox.SuggestionMode = SuggestionMode.StartsWith;
            orientationComboBox.MaxDropDownHeight = 160;
            orientationComboBox.ItemHeight = 40;
            orientationComboBox.DropDownCornerRadius = 5;
            orientationComboBox.Watermark = (NSString)"Search Here";
            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                this.controlView.AddSubview(orientationComboBox);
            }
            else
            {
                this.AddSubview(orientationComboBox);
            }
			//comboBoxDoneButtonn
			comboBoxDoneButton.SetTitle("Done\t", UIControlState.Normal);
			comboBoxDoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			comboBoxDoneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
			comboBoxDoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			comboBoxDoneButton.Hidden = true;
			comboBoxDoneButton.TouchUpInside += HideexperiencePicker;

            sizeDoneButton.SetTitle("Done\t", UIControlState.Normal);
            sizeDoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            sizeDoneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            sizeDoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            sizeDoneButton.Hidden = true;
            sizeDoneButton.TouchUpInside += HideexperiencePicker;

            textColorDoneButton.SetTitle("Done\t", UIControlState.Normal);
            textColorDoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            textColorDoneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            textColorDoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            textColorDoneButton.Hidden = true;
            textColorDoneButton.TouchUpInside += HideexperiencePicker;

            backColorDoneButton.SetTitle("Done\t", UIControlState.Normal);
            backColorDoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            backColorDoneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            backColorDoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            backColorDoneButton.Hidden = true;
            backColorDoneButton.TouchUpInside += HideexperiencePicker;
			//add vieww
            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                this.controlView.AddSubview(comboBoxDoneButton);
                this.controlView.AddSubview(sizeDoneButton);
                this.controlView.AddSubview(textColorDoneButton);
                this.controlView.AddSubview(backColorDoneButton);

                this.controlView.AddSubview(comboBoxHeaderLabel);
                this.controlView.AddSubview(sizetextLabel);
                this.controlView.AddSubview(resolutionLabel);
                this.controlView.AddSubview(orientationLabel);
            }
            else
            {
                this.AddSubview(comboBoxDoneButton);
                this.AddSubview(sizeDoneButton);
                this.AddSubview(textColorDoneButton);
                this.AddSubview(backColorDoneButton);

                this.AddSubview(comboBoxHeaderLabel);
                this.AddSubview(sizetextLabel);
                this.AddSubview(resolutionLabel);
                this.AddSubview(orientationLabel);
            }
		}

		public void loadOptionView()
		{
			//isEditableLabell
			isEditableLabel.Text = "IsEditable";
			isEditableLabel.TextColor = UIColor.Black;
			isEditableLabel.TextAlignment = UITextAlignment.Left;
            isEditableLabel.Font = UIFont.FromName("Helvetica", 14f);
            isEditableSwitch.ValueChanged += IsEditableSwitch_ValueChanged;

            diacriticModeLabel.Text = "Enable Diacritics";
            diacriticModeLabel.TextColor = UIColor.Black;
            diacriticModeLabel.TextAlignment = UITextAlignment.Left;
            diacriticModeLabel.Font = UIFont.FromName("Helvetica", 14f);
            diacriticsSwitch.ValueChanged += DiacriticsSwitch_ValueChanged; 

            isEditableSwitch.ValueChanged += IsEditableSwitch_ValueChanged;
			comboBoxModeLabel.Text = "ComboBox Mode";
			comboBoxModeLabel.TextColor = UIColor.Black;
			comboBoxModeLabel.TextAlignment = UITextAlignment.Left;
            comboBoxModeLabel.Font = UIFont.FromName("Helvetica", 14f);

			//sizeLabell
			sizeLabel.Text = "Size";
			sizeLabel.TextColor = UIColor.Black;
			sizeLabel.TextAlignment = UITextAlignment.Left;
			sizeLabel.Font = UIFont.FromName("Helvetica", 14f);

			//textColorLabell
			textColorLabel.Text = "Text Color";
			textColorLabel.TextColor = UIColor.Black;
			textColorLabel.TextAlignment = UITextAlignment.Left;
			textColorLabel.Font = UIFont.FromName("Helvetica", 14f);

			//backColorLabel
			backColorLabel.Text = "Back Color";
			backColorLabel.TextColor = UIColor.Black;
			backColorLabel.TextAlignment = UITextAlignment.Left;
			backColorLabel.Font = UIFont.FromName("Helvetica", 14f);

            waterMarkLabel.Text = "WaterMark";
            waterMarkLabel.TextColor = UIColor.Black;
            waterMarkLabel.TextAlignment = UITextAlignment.Left;
            waterMarkLabel.Font = UIFont.FromName("Helvetica", 14f);

            spaceLabel.Text = "";

			//Text
			
			waterMarkText = new UITextView();
			
			waterMarkText.Layer.BorderColor = UIColor.Black.CGColor;
			
			waterMarkText.BackgroundColor = UIColor.FromRGB(246, 246, 246);
			
            waterMarkText.KeyboardType = UIKeyboardType.Default;
			
			waterMarkText.Text = "Search Here";
			waterMarkText.Changed += (object sender, EventArgs e) =>
			 {
				 if (waterMarkText.Text.Length > 0)
				 {
                    sizeComboBox.Watermark = (NSString)waterMarkText.Text;
                    resolutionComboBox.Watermark = (NSString)waterMarkText.Text;
                    orientationComboBox.Watermark = (NSString)waterMarkText.Text;
				 }
				 else
				 {
                    sizeComboBox.Watermark = (NSString)"";
                    resolutionComboBox.Watermark = (NSString)"";
                    orientationComboBox.Watermark = (NSString)"";
				 }
			 };

			//comboBoxButton
			comboBoxButton.SetTitle("Suggest", UIControlState.Normal);
			comboBoxButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            comboBoxButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			comboBoxButton.Layer.CornerRadius = 8;
			comboBoxButton.Layer.BorderWidth = 2;
			comboBoxButton.TouchUpInside += ShowcomboBoxModePicker;
			comboBoxButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;

            //SizeButton
            sizeButton.SetTitle("Large", UIControlState.Normal);
            sizeButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            sizeButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            sizeButton.Layer.CornerRadius = 8;
            sizeButton.Layer.BorderWidth = 2;
            sizeButton.TouchUpInside += ShowsizePicker;
            sizeButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;

            textColorButton.SetTitle("Black", UIControlState.Normal);
            textColorButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            textColorButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            textColorButton.Layer.CornerRadius = 8;
            textColorButton.Layer.BorderWidth = 2;
            textColorButton.TouchUpInside += ShowtextColorPicker;
            textColorButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;

            backColorButton.SetTitle("Transparent", UIControlState.Normal);
            backColorButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            backColorButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            backColorButton.Layer.CornerRadius = 8;
            backColorButton.Layer.BorderWidth = 2;
            backColorButton.TouchUpInside += ShowbackColorPicker;
            backColorButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;

			
			comboBoxModel.PickerChanged += comboBoxSelectedIndexChanged;
            sizeModel.PickerChanged += sizeSelectedIndexChanged;
            textColorModel.PickerChanged += textColorSelectedIndexChanged;
            backColorModel.PickerChanged += backColorSelectedIndexChanged;
			suggestionModePicker.ShowSelectionIndicator = true;
			suggestionModePicker.Hidden = true;
			suggestionModePicker.BackgroundColor = UIColor.Gray;
			comboBoxModePicker.BackgroundColor = UIColor.Gray;
			comboBoxModePicker.ShowSelectionIndicator = true;
			comboBoxModePicker.Hidden = true;

            sizePicker.BackgroundColor = UIColor.Gray;
            sizePicker.ShowSelectionIndicator = true;
            sizePicker.Hidden = true;

            textColorPicker.BackgroundColor = UIColor.Gray;
            textColorPicker.ShowSelectionIndicator = true;
            textColorPicker.Hidden = true;

            backColorPicker.BackgroundColor = UIColor.Gray;
            backColorPicker.ShowSelectionIndicator = true;
            backColorPicker.Hidden = true;

		}

        private void ShowcomboBoxModePicker(object sender, EventArgs e)
        {
            waterMarkText.EndEditing(true);
            comboBoxModePicker.Hidden = false;
            comboBoxDoneButton.Hidden = false;
            sizePicker.Hidden = true;
            textColorPicker.Hidden = true;
            backColorPicker.Hidden = true;
        }

        private void ShowbackColorPicker(object sender, EventArgs e)
        {
            waterMarkText.EndEditing(true);
            comboBoxModePicker.Hidden = true;
            textColorPicker.Hidden = true;
            backColorPicker.Hidden = false;
            backColorDoneButton.Hidden = false;
            sizePicker.Hidden = true;
        }

        private void ShowtextColorPicker(object sender, EventArgs e)
        {
            waterMarkText.EndEditing(true);
            comboBoxModePicker.Hidden = true;
            textColorPicker.Hidden = false;
            textColorDoneButton.Hidden = false;
            backColorPicker.Hidden = true;
            sizePicker.Hidden = true;
        }

        private void ShowsizePicker(object sender, EventArgs e)
        {
            waterMarkText.EndEditing(true);
            sizePicker.Hidden = false;
            sizeDoneButton.Hidden = false;
            comboBoxModePicker.Hidden = true;
            textColorPicker.Hidden = true;
            backColorPicker.Hidden = true;
        }

        private void IsEditableSwitch_ValueChanged(object sender, EventArgs e)
        {
            if (((UISwitch)sender).On)
            {
                orientationComboBox.IsEditable = true;
                resolutionComboBox.IsEditable = true;
                sizeComboBox.IsEditable = true;
            }
            else
            {
                orientationComboBox.IsEditable = false;
                resolutionComboBox.IsEditable = false;
                sizeComboBox.IsEditable = false;
            }
        }

        void DiacriticsSwitch_ValueChanged(object sender, EventArgs e)
        {
            if (((UISwitch)sender).On)
            {
                orientationComboBox.IgnoreDiacritic = true;
                resolutionComboBox.IgnoreDiacritic = true;
                sizeComboBox.IgnoreDiacritic = true;
            }
            else
            {
                orientationComboBox.IgnoreDiacritic = false;
                resolutionComboBox.IgnoreDiacritic = false;
                sizeComboBox.IgnoreDiacritic = false;
            }
        }

		public void addingSourceList()
		{
            sizeDetails.Add((NSString)"100%");
            sizeDetails.Add((NSString)"125%");
            sizeDetails.Add((NSString)"150%(Recommended)");
            sizeDetails.Add((NSString)"175%");

            resolutionDetails.Add((NSString)"1920 x 1080 (Recommended)");
            resolutionDetails.Add((NSString)"1680 x 1050");
            resolutionDetails.Add((NSString)"1600 x 900");
            resolutionDetails.Add((NSString)"1440 x 900");
            resolutionDetails.Add((NSString)"1400 x 1050");
            resolutionDetails.Add((NSString)"1366 x 768");
            resolutionDetails.Add((NSString)"1360 x 768");
            resolutionDetails.Add((NSString)"1280 x 1024");
            resolutionDetails.Add((NSString)"1280 x 960");
            resolutionDetails.Add((NSString)"1280 x 720");
            resolutionDetails.Add((NSString)"854 x 480");
            resolutionDetails.Add((NSString)"800 x 480");
            resolutionDetails.Add((NSString)"480 X 640");
            resolutionDetails.Add((NSString)"480 x 320");
            resolutionDetails.Add((NSString)"432 x 240");
            resolutionDetails.Add((NSString)"360 X 640");
            resolutionDetails.Add((NSString)"320 x 240");

            orientationDetails.Add((NSString)"Landscape");
            orientationDetails.Add((NSString)"Portrait");
            orientationDetails.Add((NSString)"Landscape (flipped)");
            orientationDetails.Add((NSString)"Portrait (flipped)");
		}

		public override void TouchesBegan (NSSet touches, UIEvent evt)
        {
			this.EndEditing (true);
		}
		
		void HideexperiencePicker (object sender, EventArgs e)
        {
            comboBoxDoneButton.Hidden = true;
            comboBoxModePicker.Hidden = true;
            sizePicker.Hidden = true;
            sizeDoneButton.Hidden = true;
            textColorPicker.Hidden = true;
            textColorDoneButton.Hidden = true;
            backColorPicker.Hidden = true;
            backColorDoneButton.Hidden = true;
			this.BecomeFirstResponder ();
		}

		public override void LayoutSubviews ()
		{

			foreach (var view in this.Subviews) {
				view.Frame = Bounds;
                this.OptionView.Frame = view.Frame;
                if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                {
                    controlView.Frame = new CGRect(150, 40, view.Frame.Size.Width - 300, view.Frame.Size.Height - 40);
                    isEditableLabel.Frame = new CGRect(10, 10, this.Frame.Size.Width - 10, 30);
                    diacriticModeLabel.Frame = new CGRect(10, 60, this.Frame.Size.Width - 10, 30);
                    isEditableSwitch.Frame = new CGRect(200, 10, this.Frame.Size.Width - 10, 30);
                    diacriticsSwitch.Frame = new CGRect(200, 60, this.Frame.Size.Width - 10, 30);
                    comboBoxModeLabel.Frame = new CGRect(10, 110, this.Frame.Size.Width - 20, 30);
                    comboBoxButton.Frame = new CGRect(10, 150, 300, 30);
                    comboBoxModePicker.Frame = new CGRect(0, this.Frame.Size.Height / 4, 350, this.Frame.Size.Height / 3);
                    sizeLabel.Frame = new CGRect(10, 190, this.Frame.Size.Width - 10, 30);
                    sizeButton.Frame = new CGRect(10, 220, 300, 30);
                    sizePicker.Frame = new CGRect(0, this.Frame.Size.Height / 4, 350, this.Frame.Size.Height / 3);
                    textColorLabel.Frame = new CGRect(10, 270, this.Frame.Size.Width - 10, 30);
                    textColorButton.Frame = new CGRect(10, 300, 300, 30);
                    textColorPicker.Frame = new CGRect(0, this.Frame.Size.Height / 4, 350, this.Frame.Size.Height / 3);
                    backColorLabel.Frame = new CGRect(10, 350, this.Frame.Size.Width - 10, 30);
                    backColorButton.Frame = new CGRect(10, 380, 300, 30);
                    backColorPicker.Frame = new CGRect(0, this.Frame.Size.Height / 4, 350, this.Frame.Size.Height / 3);
                    waterMarkLabel.Frame = new CGRect(10, 430, this.Frame.Size.Width - 10, 30);
                    waterMarkText.Frame = new CGRect(150, 430, 300, 30);
                    spaceLabel.Frame = new CGRect(10, 510, this.Frame.Size.Width - 10, 30);
                    suggestionDoneButton.Frame = new CGRect(0, this.Frame.Size.Height / 4, this.Frame.Size.Width, 30);
                    comboBoxHeaderLabel.Frame = new CGRect(10, 10, controlView.Frame.Width, 30);
                    sizetextLabel.Frame = new CGRect(10, 50, controlView.Frame.Width, 30);
                    resolutionLabel.Frame = new CGRect(10, 130, controlView.Frame.Width, 30);
                    orientationLabel.Frame = new CGRect(10, 210, controlView.Frame.Width, 30);
                    sizeComboBox.Frame = new CGRect(10, 80, controlView.Frame.Size.Width - 20, 40);
                    resolutionComboBox.Frame = new CGRect(10, 160, controlView.Frame.Size.Width - 20, 40);
                    orientationComboBox.Frame = new CGRect(10, 240, controlView.Frame.Size.Width - 20, 40);
                    comboBoxDoneButton.Frame = new CGRect(0, this.Frame.Size.Height / 4, 325, 40);
                    sizeDoneButton.Frame = new CGRect(0, this.Frame.Size.Height /4 , 325, 40);
                    textColorDoneButton.Frame = new CGRect(0, this.Frame.Size.Height / 4, 325, 40);
                    backColorDoneButton.Frame = new CGRect(0, this.Frame.Size.Height / 4, 325, 40);
                }
                else
                {
                    option.Frame = new CGRect(0, 40, Frame.Width, Frame.Height);
                    isEditableLabel.Frame = new CGRect(10, 10, this.Frame.Size.Width - 10, 30);
                    diacriticModeLabel.Frame = new CGRect(10, 60, this.Frame.Size.Width - 10, 30);
                    isEditableSwitch.Frame = new CGRect(200, 10, this.Frame.Size.Width - 10, 30);
                    diacriticsSwitch.Frame = new CGRect(200, 60, this.Frame.Size.Width - 10, 30);
                    comboBoxModeLabel.Frame = new CGRect(10, 110, this.Frame.Size.Width - 20, 30);
                    comboBoxButton.Frame = new CGRect(10, 150, this.Frame.Size.Width - 20, 30);
                    comboBoxModePicker.Frame = new CGRect(0, this.Frame.Size.Height / 4, this.Frame.Size.Width, this.Frame.Size.Height / 3);
                    sizeLabel.Frame = new CGRect(10, 190, this.Frame.Size.Width - 10, 30);
                    sizeButton.Frame = new CGRect(10, 220, this.Frame.Size.Width - 20, 30);
                    sizePicker.Frame = new CGRect(0, this.Frame.Size.Height / 4, this.Frame.Size.Width, this.Frame.Size.Height / 3);
                    textColorLabel.Frame = new CGRect(10, 270, this.Frame.Size.Width - 10, 30);
                    textColorButton.Frame = new CGRect(10, 300, this.Frame.Size.Width - 20, 30);
                    textColorPicker.Frame = new CGRect(0, this.Frame.Size.Height / 3, this.Frame.Size.Width, this.Frame.Size.Height / 3);
                    backColorLabel.Frame = new CGRect(10, 350, this.Frame.Size.Width - 10, 30);
                    backColorButton.Frame = new CGRect(10, 380, this.Frame.Size.Width - 20, 30);
                    backColorPicker.Frame = new CGRect(0, this.Frame.Size.Height / 2, this.Frame.Size.Width, this.Frame.Size.Height / 3);
                    waterMarkLabel.Frame = new CGRect(10, 430, this.Frame.Size.Width - 10, 30);
                    waterMarkText.Frame = new CGRect(150, 430, this.Frame.Size.Width - 20, 30);
                    spaceLabel.Frame = new CGRect(10, 510, this.Frame.Size.Width - 10, 30);
                    suggestionDoneButton.Frame = new CGRect(0, this.Frame.Size.Height / 4, this.Frame.Size.Width, 30);
                    comboBoxHeaderLabel.Frame = new CGRect(10, 10, view.Frame.Width, 30);
                    sizetextLabel.Frame = new CGRect(10, 50, view.Frame.Width, 30);
                    resolutionLabel.Frame = new CGRect(10, 130, view.Frame.Width, 30);
                    orientationLabel.Frame = new CGRect(10, 210, view.Frame.Width, 30);
                    sizeComboBox.Frame = new CGRect(10, 80, this.Frame.Size.Width - 20, 40);
                    resolutionComboBox.Frame = new CGRect(10, 160, this.Frame.Size.Width - 20, 40);
                    orientationComboBox.Frame = new CGRect(10, 240, this.Frame.Size.Width - 20, 40);
                    comboBoxDoneButton.Frame = new CGRect(0, this.Frame.Size.Height / 4, this.Frame.Size.Width, 40);
                    sizeDoneButton.Frame = new CGRect(0, this.Frame.Size.Height / 4, this.Frame.Size.Width, 40);
                    textColorDoneButton.Frame = new CGRect(0, this.Frame.Size.Height / 3, this.Frame.Size.Width, 40);
                    backColorDoneButton.Frame = new CGRect(0, this.Frame.Size.Height / 2, this.Frame.Size.Width, 40);
                }
  			}

			this.createOptionView ();
			base.LayoutSubviews ();
		}

		private void comboBoxSelectedIndexChanged(object sender, PickerChangedEventArgs e)
		{
			this.selectedType = e.SelectedValue;
			comboBoxButton.SetTitle (selectedType, UIControlState.Normal);
			if (selectedType == "Append") {
                sizeComboBox.ComboBoxMode = ComboBoxMode.Append;
				resolutionComboBox.ComboBoxMode = ComboBoxMode.Append;
                orientationComboBox.ComboBoxMode = ComboBoxMode.Append;
			}
			else if (selectedType == "Suggest") {
				sizeComboBox.ComboBoxMode = ComboBoxMode.Suggest;
				resolutionComboBox.ComboBoxMode = ComboBoxMode.Suggest;
                orientationComboBox.ComboBoxMode = ComboBoxMode.Append;

			}
			else if (selectedType == "SuggestAppend")
			{
				sizeComboBox.ComboBoxMode = ComboBoxMode.SuggestAppend;
				resolutionComboBox.ComboBoxMode = ComboBoxMode.SuggestAppend;
                orientationComboBox.ComboBoxMode = ComboBoxMode.Append;

			}
		}

        private void sizeSelectedIndexChanged(object sender, PickerChangedEventArgs e)
        {
            this.selectedType = e.SelectedValue;
            sizeButton.SetTitle(selectedType, UIControlState.Normal);
            if (selectedType == "Small")
            {
                sizeComboBox.TextSize = 13;
                resolutionComboBox.TextSize = 13;
                orientationComboBox.TextSize = 13;
                comboBoxHeaderLabel.Font = UIFont.SystemFontOfSize(13f);
                sizetextLabel.Font = UIFont.SystemFontOfSize(13f);
                resolutionLabel.Font = UIFont.SystemFontOfSize(13f);
                orientationLabel.Font = UIFont.SystemFontOfSize(13f);
            }
            else if (selectedType == "Medium")
            {
                sizeComboBox.TextSize = 15;
                resolutionComboBox.TextSize = 15;
                orientationComboBox.TextSize = 15;
                comboBoxHeaderLabel.Font = UIFont.SystemFontOfSize(15f);
                sizetextLabel.Font = UIFont.SystemFontOfSize(15f);
                resolutionLabel.Font = UIFont.SystemFontOfSize(15f);
                orientationLabel.Font = UIFont.SystemFontOfSize(15f);

            }
            else if (selectedType == "Large")
            {
                sizeComboBox.TextSize = 17;
                resolutionComboBox.TextSize = 17;
                orientationComboBox.TextSize = 17;
                comboBoxHeaderLabel.Font = UIFont.SystemFontOfSize(17f);
                sizetextLabel.Font = UIFont.SystemFontOfSize(17f);
                resolutionLabel.Font = UIFont.SystemFontOfSize(17f);
                orientationLabel.Font = UIFont.SystemFontOfSize(17f);
            }
        }

        private void textColorSelectedIndexChanged(object sender, PickerChangedEventArgs e)
        {
            this.selectedType = e.SelectedValue;
            textColorButton.SetTitle(selectedType, UIControlState.Normal);
            if (selectedType == "Black")
            {
                sizeComboBox.TextColor = UIColor.Black;
                resolutionComboBox.TextColor = UIColor.Black;
                orientationComboBox.TextColor = UIColor.Black;
            }
            else if (selectedType == "Blue")
            {
                sizeComboBox.TextColor = UIColor.Blue;
                resolutionComboBox.TextColor = UIColor.Blue;
                orientationComboBox.TextColor = UIColor.Blue;
            }
            else if (selectedType == "Red")
            {
                sizeComboBox.TextColor = UIColor.Red;
                resolutionComboBox.TextColor = UIColor.Red;
                orientationComboBox.TextColor = UIColor.Red;
            }
            else if (selectedType == "Yellow")
            {
                sizeComboBox.TextColor = UIColor.Yellow;
                resolutionComboBox.TextColor = UIColor.Yellow;
                orientationComboBox.TextColor = UIColor.Yellow;
            }
        }

        private void backColorSelectedIndexChanged(object sender, PickerChangedEventArgs e)
        {
            this.selectedType = e.SelectedValue;
            backColorButton.SetTitle(selectedType, UIControlState.Normal);
            if (selectedType == "Transparent")
            {
                sizeComboBox.BackgroundColor = UIColor.Clear;
                resolutionComboBox.BackgroundColor = UIColor.Clear;
                orientationComboBox.BackgroundColor = UIColor.Clear;
                this.BackgroundColor = UIColor.Clear;
            }
            else if (selectedType == "Blue")
            {
                sizeComboBox.BackgroundColor = UIColor.Blue;
                resolutionComboBox.BackgroundColor = UIColor.Blue;
                orientationComboBox.BackgroundColor = UIColor.Blue;
                this.BackgroundColor = UIColor.Blue;
            }
            else if (selectedType == "Red")
            {
                sizeComboBox.BackgroundColor = UIColor.Red;
                resolutionComboBox.BackgroundColor = UIColor.Red;
                orientationComboBox.BackgroundColor = UIColor.Red;
                this.BackgroundColor = UIColor.Red;
            }
            else if (selectedType == "Yellow")
            {
                sizeComboBox.BackgroundColor = UIColor.Yellow;
                resolutionComboBox.BackgroundColor = UIColor.Yellow;
                orientationComboBox.BackgroundColor = UIColor.Yellow;
                this.BackgroundColor = UIColor.Yellow;
            }
        }
	}
}
