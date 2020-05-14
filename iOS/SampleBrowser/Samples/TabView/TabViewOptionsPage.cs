#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CoreGraphics;
using Syncfusion.iOS.TabView;
using UIKit;

namespace SampleBrowser
{
    internal class CustomTextDelegate : UITextFieldDelegate
    {
        TabViewOptionsPage optionsPage;
        public CustomTextDelegate(TabViewOptionsPage page)
        {
            optionsPage = page;
        }
        public override bool ShouldBeginEditing(UITextField textField)
        {
            optionsPage.HandleAction((int)textField.Tag);
            return false;
        }
    }
    public class TabViewOptionsPage : UIView
    {
        UILabel tabdisplaymodelabel;
        UILabel tabpositionlabel;
        UILabel selectionindicatorlabel;
        UILabel overflowmodelabel;

        UITextField tabdisplaymodeEntry;
        UITextField tabpositionEntry;
        UITextField selectionindicatorEntry;
        UITextField overflowmodeEntry;

        internal UIPickerView picker;
        internal UIButton doneButton;
        internal PickerModel model;
        internal SfTabView sftabView;
        int clickedtag = 0;
        private string selectedType;

        internal IList<string> displaymodelist = new List<string>();
        internal IList<string> positionlist = new List<string>();
        internal IList<string> selectionindicatorlist = new List<string>();
        internal IList<string> overflowlist = new List<string>();

        public TabViewOptionsPage()
        {
            var customDelegate = new CustomTextDelegate(this);
            AddData();
            tabdisplaymodelabel = new UILabel();
            tabdisplaymodelabel.Text = "Tab Display Mode";

            tabpositionlabel = new UILabel();
            tabpositionlabel.Text = "Tab Position";

            selectionindicatorlabel = new UILabel();
            selectionindicatorlabel.Text = "Selection Type";

            overflowmodelabel = new UILabel();
            overflowmodelabel.Text = "Overflow Mode";

            tabdisplaymodeEntry = new UITextField();
            tabdisplaymodeEntry.Tag = 1;
            tabdisplaymodeEntry.Layer.BorderColor = UIColor.LightGray.CGColor;
            tabdisplaymodeEntry.Layer.BorderWidth = 1;
            tabdisplaymodeEntry.Layer.CornerRadius = 5;
            tabdisplaymodeEntry.TextAlignment = UITextAlignment.Center;
            tabdisplaymodeEntry.Delegate = customDelegate; 
            tabdisplaymodeEntry.Text = "Image";

            tabpositionEntry = new UITextField();
            tabpositionEntry.Tag = 2;
            tabpositionEntry.Layer.BorderColor = UIColor.LightGray.CGColor;
            tabpositionEntry.Layer.BorderWidth = 1;
            tabpositionEntry.Layer.CornerRadius = 5;
            tabpositionEntry.TextAlignment = UITextAlignment.Center;
            tabpositionEntry.Delegate = customDelegate;
            tabpositionEntry.Text = "Top";

            selectionindicatorEntry = new UITextField();
            selectionindicatorEntry.Tag = 3;
            selectionindicatorEntry.Layer.BorderColor = UIColor.LightGray.CGColor;
            selectionindicatorEntry.Layer.BorderWidth = 1;
            selectionindicatorEntry.Layer.CornerRadius = 5;
            selectionindicatorEntry.TextAlignment = UITextAlignment.Center;
            selectionindicatorEntry.Delegate = customDelegate;
            selectionindicatorEntry.Text = "Bottom";

            overflowmodeEntry = new UITextField();
            overflowmodeEntry.Tag = 4;
            overflowmodeEntry.Layer.BorderColor = UIColor.LightGray.CGColor;
            overflowmodeEntry.Layer.BorderWidth = 1;
            overflowmodeEntry.Layer.CornerRadius = 5;
            overflowmodeEntry.TextAlignment = UITextAlignment.Center;
            overflowmodeEntry.Delegate = customDelegate;
            overflowmodeEntry.Text = "Scroll";

            Add(tabdisplaymodelabel);
            Add(tabpositionlabel);
            Add(selectionindicatorlabel);
            Add(overflowmodelabel);

            Add(tabdisplaymodeEntry);
            Add(tabpositionEntry);
            Add(selectionindicatorEntry);
            Add(overflowmodeEntry);
            InitializePicker();
        }

        void InitializePicker()
        {
            model = new PickerModel(displaymodelist);
            model.PickerChanged += PickerIndexChanged;
            picker = new UIPickerView();
            picker.Model = model;
            picker.ShowSelectionIndicator = true;
            picker.Hidden = true;
            picker.BackgroundColor = UIColor.White;
            //DoneButton
            doneButton = new UIButton();
            doneButton.SetTitle("Done\t", UIControlState.Normal);
            doneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            doneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            doneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            doneButton.Hidden = true;
            doneButton.TouchUpInside += HidePicker;
            Add(picker);
            Add(doneButton);
        }

        void AddData()
        {
            displaymodelist.Add("Image");
            displaymodelist.Add("Text");
            displaymodelist.Add("Image with Text");
            displaymodelist.Add("No Header");

            positionlist.Add("Top");
            positionlist.Add("Bottom");

            selectionindicatorlist.Add("Top");
            selectionindicatorlist.Add("Bottom");
            selectionindicatorlist.Add("Fill");

            overflowlist.Add("Scroll");
            overflowlist.Add("DropDown");
        }

        public override void LayoutSubviews()
        {
            var height = this.Frame.Height;
            picker.Frame = new CGRect(0, height/3 - 5, this.Frame.Size.Width, height / 3);
            doneButton.Frame = new CGRect(0,(height / 3)-5, this.Frame.Size.Width, 40);

            tabdisplaymodelabel.Frame = new CGRect(10, 0, this.Frame.Width - 20, 30);
            tabdisplaymodeEntry.Frame = new CGRect(10, 30, this.Frame.Width - 20, 30);
            tabpositionlabel.Frame = new CGRect(10, 80, this.Frame.Width - 20, 30);
            tabpositionEntry.Frame = new CGRect(10, 110, this.Frame.Width - 20, 30);
            overflowmodelabel.Frame = new CGRect(10, 160, this.Frame.Width - 20, 30);
            overflowmodeEntry.Frame = new CGRect(10, 190, this.Frame.Width - 20, 30);
            selectionindicatorlabel.Frame = new CGRect(10, 240, this.Frame.Width - 20, 30);
            selectionindicatorEntry.Frame = new CGRect(10, 270, this.Frame.Width - 20, 30);

            base.LayoutSubviews();
        }

        private void PickerIndexChanged(object sender, PickerChangedEventArgs e)
        {
            this.selectedType = e.SelectedValue;
        }


        void HidePicker(object sender, EventArgs e)
        {
            switch(clickedtag)
            {
                case 1:
                    if (this.selectedType == "Image")
                        sftabView.DisplayMode = TabDisplayMode.Image;
                    else if (this.selectedType == "Text")
                        sftabView.DisplayMode = TabDisplayMode.Text;
                    else if (this.selectedType == "Image with Text")
                        sftabView.DisplayMode = TabDisplayMode.ImageWithText;
                    else
                        sftabView.DisplayMode = TabDisplayMode.NoHeader;
                    break;
                case 2:
                    if (this.selectedType == "Top")
                        sftabView.TabHeaderPosition = TabHeaderPosition.Top;
                    else
                        sftabView.TabHeaderPosition = TabHeaderPosition.Bottom;
                    break;
                case 3:
                    if (this.selectedType == "Top")
                        sftabView.SelectionIndicatorSettings.Position = SelectionIndicatorPosition.Top;
                    else if (this.selectedType == "Fill")
                        sftabView.SelectionIndicatorSettings.Position = SelectionIndicatorPosition.Fill;
                    else
                        sftabView.SelectionIndicatorSettings.Position = SelectionIndicatorPosition.Bottom;
                    break;
                case 4:
                    if (this.selectedType == "Scroll")
                        sftabView.OverflowMode = OverflowMode.Scroll;
                    else
                        sftabView.OverflowMode = OverflowMode.DropDown;
                    break;
            }
            doneButton.Hidden = true;
            picker.Hidden = true;
            this.BecomeFirstResponder();
        }

        internal void HandleAction(int tag)
        {
            clickedtag = tag;
            switch (tag)
            {
                case 1:
                    model = new PickerModel(displaymodelist);
                    break;
                case 2:
                    model = new PickerModel(positionlist);
                    break;
                case 3:
                    model = new PickerModel(selectionindicatorlist);
                    break;
                case 4:
                    model = new PickerModel(overflowlist);
                    break;
            }
            model.PickerChanged -= PickerIndexChanged;
            model.PickerChanged += PickerIndexChanged;
            picker.Model = model;
            picker.ReloadAllComponents();
            doneButton.Hidden = false;
            picker.Hidden = false;
            BecomeFirstResponder();
        }
    }
}
