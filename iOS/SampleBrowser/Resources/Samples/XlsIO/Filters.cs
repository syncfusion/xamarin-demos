#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.XlsIO;
using System.IO;
using COLOR = Syncfusion.Drawing;
using System.Reflection;
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
	public partial class Filters : SampleView
	{
		public Filters ()
		{
			this.filterList.Add((NSString)"Custom Filter");
			this.filterList.Add((NSString)"Text Filter");
			this.filterList.Add((NSString)"DateTime Filter");
			this.filterList.Add((NSString)"Dynamic Filter");
            this.filterList.Add((NSString)"Color Filter");
            this.filterList.Add((NSString)"Icon Filter");
			this.filterList.Add((NSString)"Advanced Filter");
			this.filterActionList.Add((NSString)"Filter In Place");
			this.filterActionList.Add((NSString)"Filter Copy");
			selectedFilterType = "Custom Filter";
			selectedFilterActionType = "Filter In Place";
            this.colorFilterTypeList.Add((NSString)"Font Color");
            this.colorFilterTypeList.Add((NSString)"Cell Color");
            this.colorsList.Add((NSString)"Red");
            this.colorsList.Add((NSString)"Blue");
            this.colorsList.Add((NSString)"Green");
            this.colorsList.Add((NSString)"Yellow");
            this.colorsList.Add((NSString)"Empty");
            this.iconSetList.Add((NSString)"ThreeSymbols");
            this.iconSetList.Add((NSString)"FourRating");
            this.iconSetList.Add((NSString)"FiveArrows");
            this.iconIdList1.Add((NSString)"RedCrossSymbol");
            this.iconIdList1.Add((NSString)"YellowExclamationSymbol");
            this.iconIdList1.Add((NSString)"GreenCheckSymbol");
            this.iconIdList1.Add((NSString)"NoIcon");
            this.iconIdList2.Add((NSString)"SignalWithOneFillBar");
            this.iconIdList2.Add((NSString)"SignalWithTwoFillBars");
			this.iconIdList2.Add((NSString)"SignalWithThreeFillBars");
			this.iconIdList2.Add((NSString)"SignalWithFourFillBars");
			this.iconIdList2.Add((NSString)"NoIcon");
            this.iconIdList3.Add((NSString)"RedDownArrow");
			this.iconIdList3.Add((NSString)"YellowDownInclinedArrow");
			this.iconIdList3.Add((NSString)"YellowSideArrow");
			this.iconIdList3.Add((NSString)"YellowUpInclinedArrow");
			this.iconIdList3.Add((NSString)"GreenUpArrow");
			this.iconIdList3.Add((NSString)"NoIcon");

		}

		CGRect frameRect = new CGRect ();
		float frameMargin = 8.0f;
        private readonly IList<string> filterList = new List<string>();
        private readonly IList<string> filterActionList = new List<string>();
        private readonly IList<string> colorFilterTypeList = new List<string>();
        private readonly IList<string> colorsList = new List<string>();
        private readonly IList<string> iconSetList = new List<string>();
        private readonly IList<string> iconIdList1 = new List<string>();
		private readonly IList<string> iconIdList2 = new List<string>();
		private readonly IList<string> iconIdList3 = new List<string>();
		UILabel filterLabel;
        UIButton filterDoneButton;
        UIButton filterButton;
        UIPickerView filterPicker;
        UILabel filterActionLabel;
        UIButton filterActionDoneButton;
        UIButton filterActionButton;
        UIButton colorFilterTypeButton;
        UIButton colorsListButton;
        UIButton colorFilterTypeDoneButton;
        UIButton colorsListDoneButton;
        UIButton iconSetListButton;
        UIButton iconSetListDoneButton;
        UIButton iconIdListButton;
        UIButton iconIdListDoneButton;
        UIPickerView filterActionPicker;
        UIPickerView colorFilterType;
        UIPickerView colorsListPicker;
        UIPickerView iconSetPicker;
        UIPickerView iconIdPicker;
        UIPickerView iconIdPicker2;
        UIPickerView iconIdPicker3;
        string selectedFilterType;
        string selectedFilterActionType;
        string selectedColorFilterType = "Font Color";
        string selectedColor = "Red";
        string selectedIconSet = "ThreeSymbols";
        string selectedIconId = "RedCrossSymbol";
        UILabel uniqueRecordsLabel;
        UILabel colorFilterTypeLabel;
        UILabel colorsLabel;
        UILabel iconSetLabel;
        UILabel iconIdLabel;
        UISwitch uniqueRecordsSwitch;
        UIButton button;
		bool isLoaded = false;
        
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

            #region Filter Region
            filterLabel = new UILabel();
            filterDoneButton = new UIButton();
            filterButton = new UIButton();
            filterPicker = new UIPickerView();
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                filterLabel.Font = UIFont.SystemFontOfSize(18);
                filterLabel.Frame = new CGRect(10, 45, frameRect.Location.X + frameRect.Size.Width-20, 50);
                filterButton.Frame = new CGRect(10, 95, frameRect.Location.X + frameRect.Size.Width - 20, 40);
            }
            else
            {
                filterLabel.Frame = new CGRect(10, 50, frameRect.Location.X + frameRect.Size.Width-20, 50);
				filterButton.Frame = new CGRect(10, 100, frameRect.Location.X + frameRect.Size.Width - 20, 40);
            }

            //filter Label
            filterLabel.TextColor = UIColor.Black;
            filterLabel.BackgroundColor = UIColor.Clear;
            filterLabel.Text = @"Filter Type";
            filterLabel.TextAlignment = UITextAlignment.Left;
            filterLabel.Font = UIFont.FromName("Helvetica", 16f);
            this.AddSubview(filterLabel);
			
            //filter button
            filterButton.SetTitle("Custom Filter", UIControlState.Normal);
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
            PickerModel filterPickermodel = new PickerModel(this.filterList);
            filterPickermodel.PickerChanged += (sender, e) =>
            {
                this.selectedFilterType = e.SelectedValue;
                filterButton.SetTitle(selectedFilterType, UIControlState.Normal);
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
            colorFilterTypeLabel = new UILabel();
            colorsLabel = new UILabel();
            iconSetLabel = new UILabel();
            iconIdLabel = new UILabel();
            filterActionDoneButton = new UIButton();
            filterActionButton = new UIButton();
            colorFilterTypeButton = new UIButton();
            colorsListButton = new UIButton();
            iconSetListButton = new UIButton();
            iconSetListDoneButton = new UIButton();
            iconIdListButton = new UIButton();
            iconIdListDoneButton = new UIButton();
            filterActionPicker = new UIPickerView();
            colorFilterType = new UIPickerView();
            colorsListPicker = new UIPickerView();
            iconSetPicker = new UIPickerView();
            iconIdPicker = new UIPickerView();
            iconIdPicker2 = new UIPickerView();
            iconIdPicker3 = new UIPickerView();
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                filterActionLabel.Font = UIFont.SystemFontOfSize(18);
                filterActionLabel.Frame = new CGRect(10, 140, frameRect.Location.X + frameRect.Size.Width - 20, 50);
                filterActionButton.Frame = new CGRect(10, 190, frameRect.Location.X + frameRect.Size.Width - 20, 40);
                colorFilterTypeLabel.Font = UIFont.SystemFontOfSize(18);
                colorFilterTypeLabel.Frame = new CGRect(10, 140, frameRect.Location.X + frameRect.Size.Width - 20, 50);
                colorsLabel.Font = UIFont.SystemFontOfSize(18);
                colorFilterTypeButton.Frame = new CGRect(10, 190, frameRect.Location.X + frameRect.Size.Width - 20, 40);
                colorsLabel.Frame = new CGRect(10, 240, frameRect.Location.X + frameRect.Size.Width - 20, 50);
                colorsListButton.Frame = new CGRect(10, 290, frameRect.Location.X + frameRect.Size.Width - 20, 40);
                iconSetLabel.Font = UIFont.SystemFontOfSize(18);
                iconSetLabel.Frame = new CGRect(10, 140, frameRect.Location.X + frameRect.Size.Width - 20, 50);
                iconIdLabel.Font = UIFont.SystemFontOfSize(18);
                iconSetListButton.Frame = new CGRect(10, 190, frameRect.Location.X + frameRect.Size.Width - 20, 40);
                iconIdLabel.Frame = new CGRect(10, 240, frameRect.Location.X + frameRect.Size.Width - 20, 50);
                iconIdListButton.Frame = new CGRect(10, 290, frameRect.Location.X + frameRect.Size.Width - 20, 40);

			}
            else
            {
                filterActionLabel.Frame = new CGRect(10, 145, frameRect.Location.X + frameRect.Size.Width - 20, 50);
 				filterActionButton.Frame = new CGRect(10, 195, frameRect.Location.X + frameRect.Size.Width - 20, 40);
                colorFilterTypeLabel.Frame = new CGRect(10, 145, frameRect.Location.X + frameRect.Size.Width - 20, 50);
                colorFilterTypeButton.Frame = new CGRect(10, 195, frameRect.Location.X + frameRect.Size.Width - 20, 40);
                colorsLabel.Frame = new CGRect(10, 245, frameRect.Location.X + frameRect.Size.Width - 20, 50);
                colorsListButton.Frame = new CGRect(10, 295, frameRect.Location.X + frameRect.Size.Width - 20, 40);
                iconSetLabel.Frame = new CGRect(10, 145, frameRect.Location.X + frameRect.Size.Width - 20, 50);
                iconSetListButton.Frame = new CGRect(10, 195, frameRect.Location.X + frameRect.Size.Width - 20, 40);
                iconIdLabel.Frame = new CGRect(10, 245, frameRect.Location.X + frameRect.Size.Width - 20, 50);
                iconIdListButton.Frame = new CGRect(10, 295, frameRect.Location.X + frameRect.Size.Width - 20, 40);

			}

            //filterActionLabel
            filterActionLabel.TextColor = UIColor.Black;
            filterActionLabel.BackgroundColor = UIColor.Clear;
            filterActionLabel.Text = @"Filter Action";
            filterActionLabel.TextAlignment = UITextAlignment.Left;
            filterActionLabel.Font = UIFont.FromName("Helvetica", 16f);           

            //filterActionButton
            filterActionButton.SetTitle("Filter In Place", UIControlState.Normal);
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
            PickerModel filterActionPickermodel = new PickerModel(this.filterActionList);
            filterActionPickermodel.PickerChanged += (sender, e) =>
            {
                this.selectedFilterActionType = e.SelectedValue;
                filterActionButton.SetTitle(selectedFilterActionType, UIControlState.Normal);                
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

            //unique records label
            uniqueRecordsLabel = new UILabel();
            uniqueRecordsLabel.TextColor = UIColor.Black;
            uniqueRecordsLabel.BackgroundColor = UIColor.Clear;
            uniqueRecordsLabel.Text = @"Unique Records";
            uniqueRecordsLabel.TextAlignment = UITextAlignment.Left;
            uniqueRecordsLabel.Font = UIFont.FromName("Helvetica", 16f);
            uniqueRecordsLabel.Frame = new CGRect(10, 240, this.Frame.Size.Width - 20, 40);

            //unique records switch
            uniqueRecordsSwitch = new UISwitch();            
            uniqueRecordsSwitch.On = false;
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			    uniqueRecordsSwitch.Frame=new CGRect(330,240,  this.Frame.Size.Width - 220, 40);
			else
				uniqueRecordsSwitch.Frame=new CGRect(250,240, this.Frame.Size.Width - 20, 40);

            //Color Filter Type label
            colorFilterTypeLabel.TextColor = UIColor.Black;
            colorFilterTypeLabel.BackgroundColor = UIColor.Clear;
            colorFilterTypeLabel.Text = @"Color Filter Type";
            colorFilterTypeLabel.TextAlignment = UITextAlignment.Left;
            colorFilterTypeLabel.Font = UIFont.FromName("Helvetica", 16f);           

            colorFilterTypeButton.SetTitle("Font Color", UIControlState.Normal);
            colorFilterTypeButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            colorFilterTypeButton.BackgroundColor = UIColor.Clear;
            colorFilterTypeButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            colorFilterTypeButton.Hidden = false;
            colorFilterTypeButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
            colorFilterTypeButton.Layer.BorderWidth = 4;
            colorFilterTypeButton.Layer.CornerRadius = 8;
            colorFilterTypeButton.Font = UIFont.FromName("Helvetica", 16f);
            colorFilterTypeButton.TouchUpInside += ShowColorFilterTypePicker;           

            colorFilterTypeDoneButton = new UIButton();
            colorFilterTypeDoneButton.SetTitle("Done\t", UIControlState.Normal);
            colorFilterTypeDoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            colorFilterTypeDoneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            colorFilterTypeDoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            colorFilterTypeDoneButton.Hidden = true;
            colorFilterTypeDoneButton.TouchUpInside += HideColorFilterTypePicker;            

            //Color Filter Type picker model
            PickerModel colorFilterPickerModel = new PickerModel(colorFilterTypeList);
            colorFilterPickerModel.PickerChanged += (sender, e) =>
            {
                this.selectedColorFilterType = e.SelectedValue;
                colorFilterTypeButton.SetTitle(selectedColorFilterType, UIControlState.Normal);
            };
            //colorFilterType.Hidden = true;
            colorFilterType.ShowSelectionIndicator = true;
            colorFilterType.Hidden = true;
            colorFilterType.Model = colorFilterPickerModel;
            colorFilterType.BackgroundColor = UIColor.White;

            colorFilterType.Frame = new CGRect(0, this.Frame.Size.Height / 4 + 30, this.Frame.Size.Width, this.Frame.Size.Height / 3);
            colorFilterTypeDoneButton.Frame = new CGRect(0,  this.Frame.Size.Height / 4 - 30,this.Frame.Size.Width, 40);
            this.AddSubview(colorFilterType);
            this.AddSubview(colorFilterTypeDoneButton);


            colorsLabel.TextColor = UIColor.Black;
            colorsLabel.BackgroundColor = UIColor.Clear;
            colorsLabel.Text = @"Color";
            colorsLabel.TextAlignment = UITextAlignment.Left;
            colorsLabel.Font = UIFont.FromName("Helvetica", 16f);           

            colorsListButton.SetTitle("Red", UIControlState.Normal);
            colorsListButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            colorsListButton.BackgroundColor = UIColor.Clear;
            colorsListButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            colorsListButton.Hidden = false;
            colorsListButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
            colorsListButton.Layer.BorderWidth = 4;
            colorsListButton.Layer.CornerRadius = 8;
            colorsListButton.Font = UIFont.FromName("Helvetica", 16f);
            colorsListButton.TouchUpInside += ShowColorsListPicker;           

            colorsListDoneButton = new UIButton();
            colorsListDoneButton.SetTitle("Done\t", UIControlState.Normal);
            colorsListDoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            colorsListDoneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            colorsListDoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            colorsListDoneButton.Hidden = true;
            colorsListDoneButton.TouchUpInside += HideColorsListPicker;            

            //Colors List picker model
            PickerModel colorsListPickerModel = new PickerModel(colorsList);
            colorsListPickerModel.PickerChanged += (sender, e) =>
            {
                this.selectedColor = e.SelectedValue;
                colorsListButton.SetTitle(selectedColor, UIControlState.Normal);
            };
            colorsListPicker.ShowSelectionIndicator = true;
            colorsListPicker.Hidden = true;
            colorsListPicker.Model = colorsListPickerModel;
            colorsListPicker.BackgroundColor = UIColor.White;

            colorsListPicker.Frame = new CGRect(0, this.Frame.Size.Height / 4 + 30, this.Frame.Size.Width, this.Frame.Size.Height / 3);
            colorsListDoneButton.Frame = new CGRect(0, this.Frame.Size.Height / 4 - 30, this.Frame.Size.Width, 40);
            this.AddSubview(colorsListPicker);
            this.AddSubview(colorsListDoneButton);

			//IconSet label
            iconSetLabel.TextColor = UIColor.Black;
			iconSetLabel.BackgroundColor = UIColor.Clear;
			iconSetLabel.Text = @"IconSet Type";
			iconSetLabel.TextAlignment = UITextAlignment.Left;
			iconSetLabel.Font = UIFont.FromName("Helvetica", 16f);

            iconSetListButton.SetTitle("ThreeSymbols", UIControlState.Normal);
			iconSetListButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			iconSetListButton.BackgroundColor = UIColor.Clear;
			iconSetListButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			iconSetListButton.Hidden = false;
			iconSetListButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
			iconSetListButton.Layer.BorderWidth = 4;
			iconSetListButton.Layer.CornerRadius = 8;
			iconSetListButton.Font = UIFont.FromName("Helvetica", 16f);
            iconSetListButton.TouchUpInside += ShowIconSetPicker;

            iconSetListDoneButton = new UIButton();
			iconSetListDoneButton.SetTitle("Done\t", UIControlState.Normal);
			iconSetListDoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			iconSetListDoneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
			iconSetListDoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			iconSetListDoneButton.Hidden = true;
            iconSetListDoneButton.TouchUpInside += HideIconSetPicker;

			//Color Filter Type picker model
            PickerModel iconFilterPickerModel = new PickerModel(iconSetList);
			iconFilterPickerModel.PickerChanged += (sender, e) =>
			{
                this.selectedIconSet = e.SelectedValue;
                iconSetListButton.SetTitle(selectedIconSet, UIControlState.Normal);
                if(this.selectedIconSet == "ThreeSymbols")
                {
                    this.selectedIconId = "RedCrossSymbol";
                    iconIdListButton.SetTitle(selectedIconId, UIControlState.Normal);
                }
                else if(this.selectedIconSet == "FourRating")
                {
					this.selectedIconId = "SignalWithOneFillBar";
					iconIdListButton.SetTitle(selectedIconId, UIControlState.Normal);
                }
                else
                {
					this.selectedIconId = "RedDownArrow";
					iconIdListButton.SetTitle(selectedIconId, UIControlState.Normal);
                }
			};
			//colorFilterType.Hidden = true;
            iconSetPicker.ShowSelectionIndicator = true;
			iconSetPicker.Hidden = true;
			iconSetPicker.Model = iconFilterPickerModel;
			iconSetPicker.BackgroundColor = UIColor.White;

			iconSetPicker.Frame = new CGRect(0, this.Frame.Size.Height / 4 + 30, this.Frame.Size.Width, this.Frame.Size.Height / 3);
			iconSetListDoneButton.Frame = new CGRect(0, this.Frame.Size.Height / 4 - 30, this.Frame.Size.Width, 40);
			this.AddSubview(iconSetPicker);
			this.AddSubview(iconSetListDoneButton);


            iconIdLabel.TextColor = UIColor.Black;
			iconIdLabel.BackgroundColor = UIColor.Clear;
			iconIdLabel.Text = @"Icon ID";
			iconIdLabel.TextAlignment = UITextAlignment.Left;
			iconIdLabel.Font = UIFont.FromName("Helvetica", 16f);

            iconIdListButton.SetTitle("RedCrossSymbol", UIControlState.Normal);
			iconIdListButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			iconIdListButton.BackgroundColor = UIColor.Clear;
			iconIdListButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			iconIdListButton.Hidden = false;
			iconIdListButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
			iconIdListButton.Layer.BorderWidth = 4;
			iconIdListButton.Layer.CornerRadius = 8;
			iconIdListButton.Font = UIFont.FromName("Helvetica", 16f);
            iconIdListButton.TouchUpInside += ShowIconIdPicker;

            iconIdListDoneButton = new UIButton();
			iconIdListDoneButton.SetTitle("Done\t", UIControlState.Normal);
			iconIdListDoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			iconIdListDoneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
			iconIdListDoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			iconIdListDoneButton.Hidden = true;
            iconIdListDoneButton.TouchUpInside += HideIconIdPicker;

			//Colors List picker model
            PickerModel iconIdPickerModel = new PickerModel(iconIdList1);
            iconIdPickerModel.PickerChanged += (sender, e) =>
			{
                this.selectedIconId = e.SelectedValue;
                iconIdListButton.SetTitle(selectedIconId, UIControlState.Normal);
			};
            PickerModel iconIdPickerModel2 = new PickerModel(iconIdList2);
			iconIdPickerModel2.PickerChanged += (sender, e) =>
			{
				this.selectedIconId = e.SelectedValue;
				iconIdListButton.SetTitle(selectedIconId, UIControlState.Normal);
			};
            PickerModel iconIdPickerModel3 = new PickerModel(iconIdList3);
			iconIdPickerModel3.PickerChanged += (sender, e) =>
			{
				this.selectedIconId = e.SelectedValue;
				iconIdListButton.SetTitle(selectedIconId, UIControlState.Normal);
			};

			iconIdPicker.ShowSelectionIndicator = true;
			iconIdPicker.Hidden = true;
            iconIdPicker.Model = iconIdPickerModel;
			iconIdPicker.BackgroundColor = UIColor.White;
            iconIdPicker.Frame = new CGRect(0, this.Frame.Size.Height / 4 + 30, this.Frame.Size.Width, this.Frame.Size.Height / 3);

			iconIdPicker2.ShowSelectionIndicator = true;
			iconIdPicker2.Hidden = true;
			iconIdPicker2.Model = iconIdPickerModel2;
			iconIdPicker2.BackgroundColor = UIColor.White;
            iconIdPicker2.Frame = new CGRect(0, this.Frame.Size.Height / 4 + 30, this.Frame.Size.Width, this.Frame.Size.Height / 3);

			iconIdPicker3.ShowSelectionIndicator = true;
			iconIdPicker3.Hidden = true;
			iconIdPicker3.Model = iconIdPickerModel3;
			iconIdPicker3.BackgroundColor = UIColor.White;
            iconIdPicker3.Frame = new CGRect(0, this.Frame.Size.Height / 4 + 30, this.Frame.Size.Width, this.Frame.Size.Height / 3);
			
            iconIdListDoneButton.Frame = new CGRect(0, this.Frame.Size.Height / 4 - 30, this.Frame.Size.Width, 40);
			this.AddSubview(iconIdPicker);
			this.AddSubview(iconIdPicker2);
			this.AddSubview(iconIdPicker3);
            this.AddSubview(iconIdListDoneButton);


			#endregion


			this.AddSubview(filterActionLabel);
			this.AddSubview(filterActionButton);
			this.AddSubview(uniqueRecordsLabel);
			this.AddSubview(uniqueRecordsSwitch);
            this.AddSubview(colorFilterTypeLabel);
            this.AddSubview(colorFilterTypeButton);
            this.AddSubview(colorsLabel);
            this.AddSubview(colorsListButton);
            this.AddSubview(iconSetLabel);
            this.AddSubview(iconSetListButton);
            this.AddSubview(iconIdLabel);
            this.AddSubview(iconIdListButton);
			filterActionLabel.Hidden = true;
			filterActionButton.Hidden = true;
			uniqueRecordsLabel.Hidden = true;
			uniqueRecordsSwitch.Hidden = true;
            colorFilterTypeLabel.Hidden = true;
            colorFilterTypeButton.Hidden = true;
            colorsLabel.Hidden = true;
            colorsListButton.Hidden = true;
            iconSetLabel.Hidden = true;
            iconSetListButton.Hidden = true;
            iconIdLabel.Hidden = true;
            iconIdListButton.Hidden = true;

            //button
            button = new UIButton (UIButtonType.System);
			button.SetTitle("Generate Excel", UIControlState.Normal);
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
				button.Frame = new CGRect(0, 150, frameRect.Location.X + frameRect.Size.Width, 10);
			}
			else
			{
				button.Frame = new CGRect(0, 155, frameRect.Location.X + frameRect.Size.Width, 10);
			}
			button.TouchUpInside += OnButtonClicked;
			this.AddSubview (button);
			isLoaded = true;
		}


       

        void OnButtonClicked(object sender, EventArgs e)
		{
			ExcelEngine excelEngine = new ExcelEngine();
			IApplication application = excelEngine.Excel;

			application.DefaultVersion = ExcelVersion.Excel2013;

            #region Initializing Workbook
            string resourcePath = null;
            int index = filterList.IndexOf(selectedFilterType);
            if(index == 6)
                resourcePath = "SampleBrowser.Samples.XlsIO.Template.AdvancedFilterData.xlsx";
			else if (index == 5)
				resourcePath = "SampleBrowser.Samples.XlsIO.Template.IconFilterData.xlsx";
			else if(index == 4)
                resourcePath = "SampleBrowser.Samples.XlsIO.Template.FilterData_Color.xlsx";
            else
             resourcePath = "SampleBrowser.Samples.XlsIO.Template.FilterData.xlsx";
            Assembly assembly = Assembly.GetExecutingAssembly ();
			Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

			IWorkbook workbook = application.Workbooks.Open(fileStream);

			IWorksheet sheet = workbook.Worksheets[0];
			#endregion
            if(index !=6)
                sheet.AutoFilters.FilterRange = sheet.Range[1, 1, 49, 3];

            switch (index)
            {
                case 0:                   
                    IAutoFilter filter1 = sheet.AutoFilters[0];
                    filter1.IsAnd = false;
                    filter1.FirstCondition.ConditionOperator = ExcelFilterCondition.Equal;
                    filter1.FirstCondition.DataType = ExcelFilterDataType.String;
                    filter1.FirstCondition.String = "Owner";

                    filter1.SecondCondition.ConditionOperator = ExcelFilterCondition.Equal;
                    filter1.SecondCondition.DataType = ExcelFilterDataType.String;
                    filter1.SecondCondition.String = "Sales Representative";
                    break;

                case 1:                    
                    IAutoFilter filter2 = sheet.AutoFilters[0];
                    filter2.AddTextFilter(new string[] { "Owner", "Sales Representative", "Sales Associate" });
                    break;

                case 2:                    
                    IAutoFilter filter3 = sheet.AutoFilters[1];
                    filter3.AddDateFilter(new DateTime(2004, 9, 1, 1, 0, 0, 0), DateTimeGroupingType.month);
                    filter3.AddDateFilter(new DateTime(2011, 1, 1, 1, 0, 0, 0), DateTimeGroupingType.year);
                    break;

                case 3:                   
                    IAutoFilter filter4 = sheet.AutoFilters[1];
                    filter4.AddDynamicFilter(DynamicFilterType.Quarter1);
                    break;

                case 4:
                    #region
                    sheet.AutoFilters.FilterRange = sheet["A1:C49"];
                    Syncfusion.Drawing.Color color = Syncfusion.Drawing.Color.Empty;
                    switch(selectedColor.ToLower())
                    {
                        case "red":
                            color = Syncfusion.Drawing.Color.Red;
                            break;
                        case "blue":
                            color = Syncfusion.Drawing.Color.Blue;
                            break;
                        case "green":
                            color = Syncfusion.Drawing.Color.Green;
                            break;
                        case "yellow":
                            color = Syncfusion.Drawing.Color.Yellow;
                            break;
                        case "empty":
                            //Do nothing.
                            break;
                    }
                    if(selectedColorFilterType.ToLower().Equals("font color"))
                    {
                        IAutoFilter filter = sheet.AutoFilters[2];
                        filter.AddColorFilter(color, ExcelColorFilterType.FontColor);
                    }
                    else
                    {
                        IAutoFilter filter = sheet.AutoFilters[0];
                        filter.AddColorFilter(color, ExcelColorFilterType.CellColor);
                    }
                    #endregion
                    break;

                case 5:
                    #region IconFilter
                    sheet.AutoFilters.FilterRange = sheet["A4:D44"];
                    ExcelIconSetType iconSet = ExcelIconSetType.FiveArrows;
                    int filterIndex = 0;
                    int iconId = 0;
                    switch(iconSetList.IndexOf(selectedIconSet))
                    {
                        case 0:
                            filterIndex = 3;
                            iconSet = ExcelIconSetType.ThreeSymbols;
                            switch(iconIdList1.IndexOf(selectedIconId))
                            {
                                case 0:
                                    iconId = 0;
                                    break;
                                case 1:
                                    iconId = 1;
                                    break;
                                case 2:
                                    iconId = 2;
                                    break;
                                case 3:
                                    iconSet = (ExcelIconSetType)(-1);
                                    break;
                            }
                            break;
                        case 1:
                            filterIndex = 1;
                            iconSet = ExcelIconSetType.FourRating;
                            switch (iconIdList1.IndexOf(selectedIconId))
                            {
                                case 0:
                                    iconId = 0;
                                    break;
                                case 1:
                                    iconId = 1;
                                    break;
                                case 2:
                                    iconId = 2;
                                    break;
                                case 3:
                                    iconId = 3;
                                    break;
                                case 4:
                                    iconSet = (ExcelIconSetType)(-1);
                                    break;
                            }
                            break;
                        case 2:
                            filterIndex = 2;
                            iconSet = ExcelIconSetType.FiveArrows;
                            switch (iconIdList1.IndexOf(selectedIconId))
                            {
                                case 0:
                                    iconId = 0;
                                    break;
                                case 1:
                                    iconId = 1;
                                    break;
                                case 2:
                                    iconId = 2;
                                    break;
                                case 3:
                                    iconId = 3;
                                    break;
                                case 4:
                                    iconId = 4;
                                    break;
                                case 5:
                                    iconSet = (ExcelIconSetType)(-1);
                                    break;
                            }
                            break;
                    }
                    IAutoFilter filter5 = sheet.AutoFilters[filterIndex];
                    filter5.AddIconFilter(iconSet, iconId);
                    #endregion
                    break;

                case 6:
                    #region AdvancedFilter                   
                    IRange filterRange = sheet.Range["A8:G51"];
                    IRange criteriaRange = sheet.Range["A2:B5"];
                    if (selectedFilterActionType == "Filter In Place")
                    {
                        sheet.AdvancedFilter(ExcelFilterAction.FilterInPlace, filterRange, criteriaRange, null, uniqueRecordsSwitch.On);
                    }
                    else
                    {
                        IRange range = sheet.Range["I7:O7"];
                        range.Merge();
                        range.Text = "FilterCopy";
                        range.CellStyle.Font.RGBColor = Syncfusion.Drawing.Color.FromArgb(0, 112, 192);
                        range.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                        range.CellStyle.Font.Bold = true;
                        IRange copyRange = sheet.Range["I8"];
                        sheet.AdvancedFilter(ExcelFilterAction.FilterCopy, filterRange, criteriaRange, copyRange, uniqueRecordsSwitch.On);
                    }
                    #endregion
                    break;
            }

            workbook.Version = ExcelVersion.Excel2013;


			MemoryStream stream = new MemoryStream();
			workbook.SaveAs(stream);
			workbook.Close();
			excelEngine.Dispose();

			if (stream != null)
			{
				SaveiOS iOSSave = new SaveiOS ();
				iOSSave.Save ("Filters.xlsx", "application/msexcel", stream);
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

        void ShowFilterPicker(object sender, EventArgs e)
        {
			
            filterDoneButton.Hidden = false;
            filterPicker.Hidden = false;
			button.Hidden = true;
			filterActionLabel.Hidden = true;
			filterActionButton.Hidden = true;
			uniqueRecordsLabel.Hidden = true;
			uniqueRecordsSwitch.Hidden = true;
            colorFilterTypeLabel.Hidden = true;
            colorFilterTypeButton.Hidden = true;
            colorsLabel.Hidden = true;
            colorsListButton.Hidden = true;
            iconSetLabel.Hidden = true;
            iconSetListButton.Hidden = true;
            iconIdLabel.Hidden = true;
            iconIdListButton.Hidden = true;
            this.BecomeFirstResponder();
        }

        void HideFilterPicker(object sender, EventArgs e)
        {
            filterDoneButton.Hidden = true;
            filterPicker.Hidden = true;
			button.Hidden = false;
            this.BecomeFirstResponder();
			if (selectedFilterType == "Advanced Filter")
			{
				filterActionLabel.Hidden = false;
				filterActionButton.Hidden = false;
				uniqueRecordsLabel.Hidden = false;
				uniqueRecordsSwitch.Hidden = false;
				if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				{
					button.Frame = new CGRect(0, 290, frameRect.Location.X + frameRect.Size.Width, 10);
				}
				else
				{
					button.Frame = new CGRect(0, 295, frameRect.Location.X + frameRect.Size.Width, 10);

				}

                colorFilterTypeLabel.Hidden = true;
                colorsLabel.Hidden = true;
                colorsListButton.Hidden = true;
			}
            else if(selectedFilterType == "Color Filter")
            {
                colorFilterTypeLabel.Hidden = false;
                colorFilterTypeButton.Hidden = false;
                colorsLabel.Hidden = false;
                colorsListButton.Hidden = false;
                if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                {
                    button.Frame = new CGRect(0, 345, frameRect.Location.X + frameRect.Size.Width, 10);
                }
                else
                {
                    button.Frame = new CGRect(0, 350, frameRect.Location.X + frameRect.Size.Width, 10);

                }
            }
			else if (selectedFilterType == "Icon Filter")
			{
                iconSetLabel.Hidden = false;
                iconSetListButton.Hidden = false;
                iconIdLabel.Hidden = false;
                iconIdListButton.Hidden = false;
				if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				{
					button.Frame = new CGRect(0, 345, frameRect.Location.X + frameRect.Size.Width, 10);
				}
				else
				{
					button.Frame = new CGRect(0, 350, frameRect.Location.X + frameRect.Size.Width, 10);

				}
			}
			else
			{
				filterActionLabel.Hidden = true;
				filterActionButton.Hidden = true;
				uniqueRecordsLabel.Hidden = true;
				uniqueRecordsSwitch.Hidden = true;
				if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				{
					button.Frame = new CGRect(0, 150, frameRect.Location.X + frameRect.Size.Width, 10);
				}
				else
				{
					button.Frame = new CGRect(0, 155, frameRect.Location.X + frameRect.Size.Width, 10);

				}

                colorFilterTypeLabel.Hidden = true;
                colorFilterTypeButton.Hidden = true;
                colorsLabel.Hidden = true;
                colorsListButton.Hidden = true;
                iconSetLabel.Hidden = true;
                iconSetListButton.Hidden = true;
                iconIdLabel.Hidden = true;
                iconIdListButton.Hidden = true;
			}
        }

        void ShowFilterActionPicker(object sender, EventArgs e)
		{
			filterActionLabel.Hidden = true;
			filterActionButton.Hidden = true;
			filterActionDoneButton.Hidden = false;
			filterActionPicker.Hidden = false;
			uniqueRecordsLabel.Hidden = true;
			uniqueRecordsSwitch.Hidden = true;
            button.Hidden = true;
			filterButton.Hidden = true;
            colorFilterTypeButton.Hidden = true;
            this.BecomeFirstResponder();
        }

        void HideFilterActionPicker(object sender, EventArgs e)
        {
			filterActionLabel.Hidden = false;
			filterActionButton.Hidden = false;
			filterActionDoneButton.Hidden = true;
			filterActionPicker.Hidden = true;
			uniqueRecordsLabel.Hidden = false;
			uniqueRecordsSwitch.Hidden = false;
            button.Hidden = false;
			filterButton.Hidden = false;
            colorFilterTypeButton.Hidden = true;
			this.BecomeFirstResponder();
        }
        void ShowColorFilterTypePicker(object sender, EventArgs e)
        {
            filterButton.Hidden = true;
            colorFilterTypeLabel.Hidden = true;
            button.Hidden = true;
            colorFilterTypeButton.Hidden = true;
            colorFilterType.Hidden = false;
            colorFilterTypeDoneButton.Hidden = false;
            colorsLabel.Hidden = true;
            colorsListButton.Hidden = true;
            this.BecomeFirstResponder();
        }

        void HideColorFilterTypePicker(object sender, EventArgs e)
        {
            filterButton.Hidden = false;
            colorFilterTypeLabel.Hidden = false;
            button.Hidden = false;
            colorFilterTypeButton.Hidden = false;
            colorFilterType.Hidden = true;
            colorFilterTypeDoneButton.Hidden = true;
            colorsLabel.Hidden = false;
            colorsListButton.Hidden = false;
            this.BecomeFirstResponder();
        }

        void ShowColorsListPicker(object sender, EventArgs e)
        {
            colorFilterTypeLabel.Hidden = true;
            button.Hidden = true;
            colorFilterTypeButton.Hidden = true;
            colorFilterType.Hidden = true;
            colorFilterTypeDoneButton.Hidden = true;
            colorsListButton.Hidden = true;
            colorsListDoneButton.Hidden = false;
            colorsListPicker.Hidden = false;
            colorsLabel.Hidden = true;
            filterButton.Hidden = true;
            this.BecomeFirstResponder();
        
        }
        void HideColorsListPicker(object sender, EventArgs e)
        {
            colorFilterTypeLabel.Hidden = false;
            button.Hidden = false;
            colorFilterTypeButton.Hidden = false;
            colorFilterType.Hidden = true;
            colorFilterTypeDoneButton.Hidden = true;
            colorsListButton.Hidden = false;
            colorsListDoneButton.Hidden = true;
            colorsListPicker.Hidden = true;
            colorsLabel.Hidden = false;
            filterButton.Hidden = false;
            this.BecomeFirstResponder();
         
        }
        void ShowIconSetPicker(object sender, EventArgs e)
        {
            button.Hidden = true;
            filterButton.Hidden = true;
            iconSetLabel.Hidden = true;
            iconSetListButton.Hidden = true;
            iconIdLabel.Hidden = true;
            iconIdListButton.Hidden = true;
            iconSetPicker.Hidden = false;
            iconSetListDoneButton.Hidden = false;
            this.BecomeFirstResponder();
        }
        void HideIconSetPicker(object sender, EventArgs e)
        {
            button.Hidden = false;
            filterButton.Hidden = false;
            iconSetPicker.Hidden = true;
            iconSetLabel.Hidden = false;
            iconSetListButton.Hidden = false;
            iconIdLabel.Hidden = false;
            iconIdListButton.Hidden = false;
            iconSetListDoneButton.Hidden = true;
			this.BecomeFirstResponder();


        }
        void ShowIconIdPicker(object sender, EventArgs e)
        {
			button.Hidden = true;
			filterButton.Hidden = true;
			iconSetLabel.Hidden = true;
			iconSetListButton.Hidden = true;
			iconIdLabel.Hidden = true;
			iconIdListButton.Hidden = true;
            iconIdListDoneButton.Hidden = false;

			this.BecomeFirstResponder();
			if (selectedIconSet == "ThreeSymbols")
			{
				iconIdPicker.Hidden = false;
				iconIdPicker2.Hidden = true;
				iconIdPicker3.Hidden = true;
			}
			else if (selectedIconSet == "FourRating")
			{
				iconIdPicker.Hidden = true;
				iconIdPicker2.Hidden = false;
				iconIdPicker3.Hidden = true;
			}
			else
			{
				iconIdPicker.Hidden = true;
				iconIdPicker2.Hidden = true;
				iconIdPicker3.Hidden = false;
			}
        }
        void HideIconIdPicker(object sender, EventArgs e)
        {
			button.Hidden = false;
			filterButton.Hidden = false;
            iconIdPicker.Hidden = true;
			iconIdPicker2.Hidden = true;
			iconIdPicker3.Hidden = true;
            iconSetLabel.Hidden = false;
			iconSetListButton.Hidden = false;
			iconIdLabel.Hidden = false;
			iconIdListButton.Hidden = false;
            iconIdListDoneButton.Hidden = true;
			this.BecomeFirstResponder();
        }
    }
}

