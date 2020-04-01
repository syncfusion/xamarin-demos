#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfRangeSlider.iOS;
using System.Collections.Generic;
using Syncfusion.SfMaskedEdit.iOS;
using System.Globalization;


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
using nfloat = System.Single;
#endif

namespace SampleBrowser
{
    public class MaskedEdit_Tablet : SampleView
    {
        UIView view;
        UIView subView = new UIView();
        UIButton searchButton = new UIButton();
        public UIView option = new UIView();
        UILabel fundTransferLable, accountLabel, descriptionLabel, amountLabel, emailIDLabel, mobileNumberLabel, inputValidationModeLabel, cultureLabel, hidepromptLabel, promptcharLabel;
        SfMaskedEdit acccountmaskedEdit, descriptionmaskedEdit, amountmaskedEdit, emailIDmaskedEdit, mobileNumbermaskedEdit;
        UILabel accInputRejectLable, amtInputRejectLable, emailInputRejectLable, phoneInputRejectLable;
        private UIPickerView cutCopyPicker, promptPicker, culturePicker;
        private UIButton promptcharButton, validationDoneButton, promptDoneButton, validationButton, cultureDoneButton, cultureButton;
        private readonly IList<string> cultureList, inputValidationModeList, promptCharList;
        private string cultureSelectedType, validationSelectedType, promptSelectedType;
        private UISwitch hidepromptSwitch;
        UIScrollView scrollView = new UIScrollView();
        UIView contentView = new UIView();
        UIView controlView = new UIView();
        UILabel propertiesLabel = new UILabel();
        UIButton closeButton = new UIButton();
        UIButton showPropertyButton = new UIButton();
        nfloat accPoint = 0;
        nfloat amtPoint = 0;
        nfloat emailPoint = 0;
        nfloat phonePoint = 0;
        public override void LayoutSubviews()
        {

            foreach (var view in this.Subviews)
            {
                view.Frame = Bounds;
                subView.Frame = new CGRect(0, this.Frame.Size.Height - this.Frame.Size.Height / 3 + 75, this.Frame.Size.Width, this.Frame.Height / 3 - 75);

                controlView.Frame = new CGRect(150, 40, view.Frame.Size.Width - 300, view.Frame.Size.Height + 300);
                contentView.Frame = new CGRect(0, 40, subView.Frame.Size.Width, subView.Frame.Size.Height);

                fundTransferLable.Frame = new CGRect(10, 0, controlView.Frame.Size.Width - 20, 40);
                accountLabel.Frame = new CGRect(10, 50, controlView.Frame.Size.Width - 20, 40);
                acccountmaskedEdit.Frame = new CGRect(10, 85, controlView.Frame.Size.Width - 20, 40);

                accInputRejectLable.Frame = new CGRect(10, 125, this.Frame.Size.Width - 20, 20);

                descriptionLabel.Frame = new CGRect(10, 135 + accPoint, controlView.Frame.Size.Width - 20, 40);
                descriptionmaskedEdit.Frame = new CGRect(10, 170 + accPoint, controlView.Frame.Size.Width - 20, 40);

                amountLabel.Frame = new CGRect(10, 220 + accPoint, controlView.Frame.Size.Width - 20, 40);
                amountmaskedEdit.Frame = new CGRect(10, 255 + accPoint, controlView.Frame.Size.Width - 20, 40);

                amtInputRejectLable.Frame = new CGRect(10, 295 + accPoint, this.Frame.Size.Width - 20, 20);

                emailIDLabel.Frame = new CGRect(10, 305 + accPoint + amtPoint, controlView.Frame.Size.Width - 20, 40);
                emailIDmaskedEdit.Frame = new CGRect(10, 340 + accPoint + amtPoint, controlView.Frame.Size.Width - 20, 40);

                emailInputRejectLable.Frame = new CGRect(10, 380 + accPoint + amtPoint, this.Frame.Size.Width - 20, 20);

                mobileNumberLabel.Frame = new CGRect(10, 390 + accPoint + amtPoint + emailPoint, controlView.Frame.Size.Width - 20, 40);
                mobileNumbermaskedEdit.Frame = new CGRect(10 , 425 + accPoint + amtPoint + emailPoint, controlView.Frame.Size.Width - 20, 40);

                phoneInputRejectLable.Frame = new CGRect(10, 470 + accPoint + amtPoint + emailPoint, this.Frame.Size.Width - 20, 15);

                searchButton.Frame = new CGRect(10, 500 + accPoint + amtPoint + emailPoint+phonePoint, controlView.Frame.Size.Width - 20, 40);

                inputValidationModeLabel.Frame = new CGRect(110, 10, 200, 30);
                validationButton.Frame = new CGRect(340, 10, contentView.Frame.Size.Width - 520, 30);
                cutCopyPicker.Frame = new CGRect(100, 20, contentView.Frame.Size.Width - 200, 200);
                validationDoneButton.Frame = new CGRect(100, 20, contentView.Frame.Size.Width - 200, 30);

                cultureLabel.Frame = new CGRect(110, 60, 200, 30);
                cultureButton.Frame = new CGRect(340, 60, contentView.Frame.Size.Width - 520, 30);
                culturePicker.Frame = new CGRect(100, 20, contentView.Frame.Size.Width - 200, 200);
                cultureDoneButton.Frame = new CGRect(100, 20, contentView.Frame.Size.Width - 200, 30);

                promptcharLabel.Frame = new CGRect(110, 110, 200, 30);
                promptcharButton.Frame = new CGRect(340, 110, contentView.Frame.Size.Width - 520, 30);
                promptPicker.Frame = new CGRect(100, 20, contentView.Frame.Size.Width - 200, 200);
                promptDoneButton.Frame = new CGRect(100, 20, contentView.Frame.Size.Width - 200, 30);

                hidepromptLabel.Frame = new CGRect(110, 160, 200, 30);
                hidepromptSwitch.Frame = new CGRect(340, 160, contentView.Frame.Size.Width - 520, 30);

                showPropertyButton.Frame = new CGRect(0, this.Frame.Size.Height - 25, this.Frame.Size.Width, 30);
                closeButton.Frame = new CGRect(this.Frame.Size.Width - 30, 5, 20, 30);
                propertiesLabel.Frame = new CGRect(10, 5, this.Frame.Width, 30);
            }
            base.LayoutSubviews();
        }

        public MaskedEdit_Tablet()
        {
            view = new UIView();
            this.OptionView = new UIView();
            this.cultureList = new List<string>() { (NSString)"United States", (NSString)"United Kingdom", (NSString)"Japan", (NSString)"France", (NSString)"Italy" };
            this.inputValidationModeList = new List<string>() { (NSString)"Key Press", (NSString)"Lost Focus" };
            this.promptCharList = new List<string>() { "_", "*", "~" };

            fundTransferLable = new UILabel();
            fundTransferLable.TextColor = UIColor.Black;
            fundTransferLable.BackgroundColor = UIColor.Clear;
            fundTransferLable.Text = @"Funds Transfer";
            fundTransferLable.TextAlignment = UITextAlignment.Left;
            fundTransferLable.Font = UIFont.FromName("Helvetica-Bold", 20f);
            controlView.AddSubview(fundTransferLable);

            accountLabel = new UILabel();
            accountLabel.Text = "To Account";
            accountLabel.TextColor = UIColor.Black;
            accountLabel.Font = UIFont.FromName("Helvetica", 16f);
            controlView.AddSubview(accountLabel);

            acccountmaskedEdit = new SfMaskedEdit();
            acccountmaskedEdit.Mask = "0000 0000 0000 0000";
            acccountmaskedEdit.Culture = new CultureInfo("en-us");
            acccountmaskedEdit.ValueMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            acccountmaskedEdit.ClipsToBounds = true;
            acccountmaskedEdit.Layer.BorderColor = UIColor.LightGray.CGColor;
            acccountmaskedEdit.HidePromptOnLeave = true;
            acccountmaskedEdit.ValidationMode = InputValidationMode.KeyPress;
            acccountmaskedEdit.MaskInputRejected += AcccountmaskedEdit_MaskInputRejected;
            acccountmaskedEdit.ValueChanged += AcccountmaskedEdit_ValueChanged1;
            acccountmaskedEdit.TextAlignment = UITextAlignment.Left;
            acccountmaskedEdit.Placeholder = "1234 1234 1234 1234";
            controlView.AddSubview(acccountmaskedEdit);

            accInputRejectLable = new UILabel();
            accInputRejectLable.Font = UIFont.FromName("Helvetica", 14f);
            accInputRejectLable.TextColor = UIColor.Red;
            accInputRejectLable.Hidden = true;
            controlView.AddSubview(accInputRejectLable);

            descriptionLabel = new UILabel();
            descriptionLabel.Text = "Description";
            descriptionLabel.TextColor = UIColor.Black;
            descriptionLabel.Font = UIFont.FromName("Helvetica", 16f);
            controlView.AddSubview(descriptionLabel);

            descriptionmaskedEdit = new SfMaskedEdit();
            descriptionmaskedEdit.Mask = "";
            descriptionmaskedEdit.Culture = new CultureInfo("en-us");
            descriptionmaskedEdit.ValueMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            descriptionmaskedEdit.Placeholder = "Enter description";
            descriptionmaskedEdit.TextAlignment = UITextAlignment.Left;
            descriptionmaskedEdit.ClipsToBounds = true;
            descriptionmaskedEdit.Layer.BorderColor = UIColor.LightGray.CGColor;
            controlView.AddSubview(descriptionmaskedEdit);

            amountLabel = new UILabel();
            amountLabel.Text = "Amount";
            amountLabel.TextColor = UIColor.Black;
            amountLabel.Font = UIFont.FromName("Helvetica", 16f);
            controlView.AddSubview(amountLabel);

            amountmaskedEdit = new SfMaskedEdit();
            amountmaskedEdit.Mask = "$ 0,000.00";
            amountmaskedEdit.Culture = new CultureInfo("en-us");
            amountmaskedEdit.ValueMaskFormat = MaskFormat.IncludeLiterals;
            amountmaskedEdit.Placeholder = "$ 3,874.00";
            amountmaskedEdit.ValidationMode = InputValidationMode.KeyPress;
            amountmaskedEdit.MaskInputRejected += AmountmaskedEdit_MaskInputRejected;
            amountmaskedEdit.ValueChanged += AmountmaskedEdit_ValueChanged1;
            amountmaskedEdit.Layer.BorderColor = UIColor.LightGray.CGColor;
            amountmaskedEdit.TextAlignment = UITextAlignment.Left;
            controlView.AddSubview(amountmaskedEdit);

            amtInputRejectLable = new UILabel();
            amtInputRejectLable.Font = UIFont.FromName("Helvetica", 14f);
            amtInputRejectLable.TextColor = UIColor.Red;
            amtInputRejectLable.Hidden = true;
            controlView.AddSubview(amtInputRejectLable);

            emailIDLabel = new UILabel();
            emailIDLabel.Text = "Email ID";
            emailIDLabel.TextColor = UIColor.Black;
            emailIDLabel.Font = UIFont.FromName("Helvetica", 16f);
            controlView.AddSubview(emailIDLabel);

            emailIDmaskedEdit = new SfMaskedEdit();
            emailIDmaskedEdit.Mask = @"\w+@\w+\.\w+";
            emailIDmaskedEdit.Culture = new CultureInfo("en-us");
            emailIDmaskedEdit.ValueMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            emailIDmaskedEdit.Placeholder = "david@syncfusion.com";
            emailIDmaskedEdit.ValidationMode = InputValidationMode.KeyPress;
            emailIDmaskedEdit.MaskInputRejected += EmailIDmaskedEdit_MaskInputRejected;
            emailIDmaskedEdit.ValueChanged += EmailIDmaskedEdit_ValueChanged1;
            emailIDmaskedEdit.MaskType = MaskType.RegEx;
            emailIDmaskedEdit.Layer.BorderColor = UIColor.LightGray.CGColor;
            controlView.AddSubview(emailIDmaskedEdit);

            emailInputRejectLable = new UILabel();
            emailInputRejectLable.Font = UIFont.FromName("Helvetica", 14f);
            emailInputRejectLable.TextColor = UIColor.Red;
            emailInputRejectLable.Hidden = true;
            controlView.AddSubview(emailInputRejectLable);

            mobileNumberLabel = new UILabel();
            mobileNumberLabel.Text = "Mobile Number";
            mobileNumberLabel.TextColor = UIColor.Black;
            mobileNumberLabel.Font = UIFont.FromName("Helvetica", 16f);
            controlView.AddSubview(mobileNumberLabel);

            mobileNumbermaskedEdit = new SfMaskedEdit();
            mobileNumbermaskedEdit.Mask = "+1 000 000 0000";
            mobileNumbermaskedEdit.Culture = new CultureInfo("en-us");
            mobileNumbermaskedEdit.ValueMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mobileNumbermaskedEdit.ClipsToBounds = true;
            mobileNumbermaskedEdit.Layer.BorderColor = UIColor.LightGray.CGColor;
            mobileNumbermaskedEdit.ValidationMode = InputValidationMode.KeyPress;
            mobileNumbermaskedEdit.MaskInputRejected += MobileNumbermaskedEdit_MaskInputRejected;
            mobileNumbermaskedEdit.ValueChanged += MobileNumbermaskedEdit_ValueChanged1;
            mobileNumbermaskedEdit.Placeholder = "+1 323 339 3392";
            mobileNumbermaskedEdit.TextAlignment = UITextAlignment.Left;
            controlView.AddSubview(mobileNumbermaskedEdit);

            phoneInputRejectLable = new UILabel();
            phoneInputRejectLable.Font = UIFont.FromName("Helvetica", 14f);
            phoneInputRejectLable.TextColor = UIColor.Red;
            phoneInputRejectLable.Hidden = true;
            controlView.AddSubview(phoneInputRejectLable);

            //searchButtonn
            searchButton.SetTitle("Transfer Money", UIControlState.Normal);
            searchButton.SetTitleColor(UIColor.White, UIControlState.Normal);
            searchButton.BackgroundColor = UIColor.FromRGB(50, 150, 221);
            searchButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            searchButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            searchButton.Layer.CornerRadius = 8;
            searchButton.Layer.BorderWidth = 2;
            searchButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
            searchButton.TouchUpInside += FoundTransfer;
            controlView.AddSubview(searchButton);

            this.AddSubview(controlView);
            mainPageDesign();
            optionView();
        }

        private void EmailIDmaskedEdit_ValueChanged1(object sender, ValueChangedEventArgs e)
        {
            emailInputRejectLable.Hidden = true;
            emailPoint = 0;
            LayoutSubviews();
        }

        private void MobileNumbermaskedEdit_ValueChanged1(object sender, ValueChangedEventArgs e)
        {
            phoneInputRejectLable.Hidden = true;
            phonePoint = 0;
            LayoutSubviews();
        }

        private void AmountmaskedEdit_ValueChanged1(object sender, ValueChangedEventArgs e)
        {
            amtInputRejectLable.Hidden = true;
            amtPoint = 0;
            LayoutSubviews();
        }

        private void AcccountmaskedEdit_ValueChanged1(object sender, ValueChangedEventArgs e)
        {
            accInputRejectLable.Hidden = true;
            accPoint = 0;
            LayoutSubviews();
        }

        private void MobileNumbermaskedEdit_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            phoneInputRejectLable.Hidden = false;
            phoneInputRejectLable.Text = GetRejectionHintText(e.RejectionHint);
            if (!string.IsNullOrEmpty(phoneInputRejectLable.Text))
                phonePoint = 15;
            LayoutSubviews();
        }

        private void EmailIDmaskedEdit_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            emailInputRejectLable.Hidden = false;
            emailInputRejectLable.Text = GetRejectionHintText(e.RejectionHint);
            if (!string.IsNullOrEmpty(emailInputRejectLable.Text))
                emailPoint = 15;
            LayoutSubviews();
        }
        private void AmountmaskedEdit_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            amtInputRejectLable.Hidden = false;
            amtInputRejectLable.Text = GetRejectionHintText(e.RejectionHint);
            if (!string.IsNullOrEmpty(amtInputRejectLable.Text))
                amtPoint = 15;
            LayoutSubviews();
        }

        private void AcccountmaskedEdit_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            accInputRejectLable.Hidden = false;
            accInputRejectLable.Text = GetRejectionHintText(e.RejectionHint);
            if (!string.IsNullOrEmpty(accInputRejectLable.Text))
                accPoint = 15;
            LayoutSubviews();
        }

        private string GetRejectionHintText(MaskedTextResultHint hint)
        {
            string hintText = string.Empty;
            switch (hint)
            {
                case MaskedTextResultHint.AlphanumericCharacterExpected:
                    hintText = "Invalid character!";
                    break;
                case MaskedTextResultHint.DigitExpected:
                    hintText = "Invalid character!";
                    break;
                case MaskedTextResultHint.LetterExpected:
                    hintText = "Invalid character!";
                    break;
                case MaskedTextResultHint.SignedDigitExpected:
                    hintText = "Invalid character!";
                    break;
            }
            return hintText;
        }

        private void FoundTransfer(object sender, EventArgs e)
        {
            if ((acccountmaskedEdit.Value == null || acccountmaskedEdit.Value.ToString() == string.Empty)
                    || (descriptionmaskedEdit.Value == null || descriptionmaskedEdit.Value.ToString() == string.Empty)
                    || (amountmaskedEdit.Value == null || amountmaskedEdit.Value.ToString() == string.Empty)
                    || (emailIDmaskedEdit.Value == null || emailIDmaskedEdit.Value.ToString() == string.Empty)
                    || (mobileNumbermaskedEdit.Value == null || mobileNumbermaskedEdit.Value.ToString() == string.Empty))
            {
                UIAlertView v = new UIAlertView();
                v.Title = "Results";
                v.Message = "Please fill all the required data!";
                v.AddButton("OK");
                v.Show();
            }
            else if (acccountmaskedEdit.HasError || descriptionmaskedEdit.HasError || amountmaskedEdit.HasError || emailIDmaskedEdit.HasError || mobileNumbermaskedEdit.HasError)
            {
                UIAlertView v = new UIAlertView();
                v.Title = "Results";
                v.Message = "Please enter valid details";
                v.AddButton("OK");
                v.Show();
            }
            else
            {
                UIAlertView v1 = new UIAlertView();
                v1.Title = "Results";
                v1.AddButton("OK");
                v1.Message = string.Format("Amount of {0} has been transferred successfully!", amountmaskedEdit.Text);
                v1.Show();
                string mask1 = acccountmaskedEdit.Mask;
                acccountmaskedEdit.Mask = string.Empty;
                acccountmaskedEdit.Mask = mask1;
                mask1 = descriptionmaskedEdit.Mask;
                descriptionmaskedEdit.Mask = "0";
                descriptionmaskedEdit.Mask = mask1;
                mask1 = amountmaskedEdit.Mask;
                amountmaskedEdit.Mask = string.Empty;
                amountmaskedEdit.Mask = mask1;
                mask1 = emailIDmaskedEdit.Mask;
                emailIDmaskedEdit.Mask = string.Empty;
                emailIDmaskedEdit.Mask = mask1;
                mask1 = mobileNumbermaskedEdit.Mask;
                mobileNumbermaskedEdit.Mask = string.Empty;
                mobileNumbermaskedEdit.Mask = mask1;                

            }
            this.BecomeFirstResponder();
        }
        public void mainPageDesign()
        {
            inputValidationModeLabel = new UILabel();
            inputValidationModeLabel.TextColor = UIColor.Black;
            inputValidationModeLabel.BackgroundColor = UIColor.Clear;
            inputValidationModeLabel.Text = @"Validation On";
            inputValidationModeLabel.TextAlignment = UITextAlignment.Left;
            inputValidationModeLabel.Font = UIFont.FromName("Helvetica", 16f);

            validationButton = new UIButton();
            validationButton.SetTitle("Key Press", UIControlState.Normal);
            validationButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            validationButton.BackgroundColor = UIColor.Clear;
            validationButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            validationButton.Hidden = false;
            validationButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
            validationButton.Layer.BorderWidth = 2;
            validationButton.Layer.CornerRadius = 8;
            validationButton.TouchUpInside += CutCopyMaskFormatButton_TouchUpInside; ;

            PickerModel cutCopyPickermodel = new PickerModel(this.inputValidationModeList);
            cutCopyPickermodel.PickerChanged += (sender, e) =>
            {
                this.validationSelectedType = e.SelectedValue;
                validationButton.SetTitle(validationSelectedType, UIControlState.Normal);
                if (validationSelectedType == "Key Press")
                {
                    acccountmaskedEdit.ValidationMode = InputValidationMode.KeyPress;
                    descriptionmaskedEdit.ValidationMode = InputValidationMode.KeyPress;
                    amountmaskedEdit.ValidationMode = InputValidationMode.KeyPress;
                    emailIDmaskedEdit.ValidationMode = InputValidationMode.KeyPress;
                    mobileNumbermaskedEdit.ValidationMode = InputValidationMode.KeyPress;
                }
                else if (validationSelectedType == "Lost Focus")
                {
                    acccountmaskedEdit.ValidationMode = InputValidationMode.LostFocus;
                    descriptionmaskedEdit.ValidationMode = InputValidationMode.LostFocus;
                    amountmaskedEdit.ValidationMode = InputValidationMode.LostFocus;
                    emailIDmaskedEdit.ValidationMode = InputValidationMode.LostFocus;
                    mobileNumbermaskedEdit.ValidationMode = InputValidationMode.LostFocus;
                }
            };
            cutCopyPicker = new UIPickerView();
            cutCopyPicker.ShowSelectionIndicator = true;
            cutCopyPicker.Hidden = true;
            cutCopyPicker.Model = cutCopyPickermodel;
            cutCopyPicker.BackgroundColor = UIColor.White;

            validationDoneButton = new UIButton();
            validationDoneButton.SetTitle("Done\t", UIControlState.Normal);
            validationDoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            validationDoneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            validationDoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            validationDoneButton.Hidden = true;
            validationDoneButton.TouchUpInside += CutCopyDoneButton_TouchUpInside;

            cultureLabel = new UILabel();
            cultureLabel.TextColor = UIColor.Black;
            cultureLabel.BackgroundColor = UIColor.Clear;
            cultureLabel.Text = @"Culture";
            cultureLabel.TextAlignment = UITextAlignment.Left;
            cultureLabel.Font = UIFont.FromName("Helvetica", 15f);

            cultureButton = new UIButton();
            cultureButton.SetTitle("United States", UIControlState.Normal);
            cultureButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            cultureButton.BackgroundColor = UIColor.Clear;
            cultureButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            cultureButton.Hidden = false;
            cultureButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
            cultureButton.Layer.BorderWidth = 2;
            cultureButton.Layer.CornerRadius = 8;
            cultureButton.TouchUpInside += ShowCulturePicker;

            PickerModel culturePickermodel = new PickerModel(this.cultureList);
            culturePickermodel.PickerChanged += (sender, e) =>
            {
                this.cultureSelectedType = e.SelectedValue;
                cultureButton.SetTitle(cultureSelectedType, UIControlState.Normal);
                if (cultureSelectedType == "United States")
                {
                    acccountmaskedEdit.Culture = new CultureInfo("en-us");
                    descriptionmaskedEdit.Culture = new CultureInfo("en-us");
                    amountmaskedEdit.Culture = new CultureInfo("en-us");
                    emailIDmaskedEdit.Culture = new CultureInfo("en-us");
                    mobileNumbermaskedEdit.Culture = new CultureInfo("en-us");
                }
                else if (cultureSelectedType == "United Kingdom")
                {
                    acccountmaskedEdit.Culture = new CultureInfo("en-GB"); descriptionmaskedEdit.Culture = new CultureInfo("en-GB"); amountmaskedEdit.Culture = new CultureInfo("en-GB");
                    emailIDmaskedEdit.Culture = new CultureInfo("en-GB"); mobileNumbermaskedEdit.Culture = new CultureInfo("en-GB");
                }
                else if (cultureSelectedType == "Japan")
                {
                    acccountmaskedEdit.Culture = new CultureInfo("ja-JP");
                    descriptionmaskedEdit.Culture = new CultureInfo("ja-JP");
                    amountmaskedEdit.Culture = new CultureInfo("ja-JP");
                    emailIDmaskedEdit.Culture = new CultureInfo("ja-JP");
                    mobileNumbermaskedEdit.Culture = new CultureInfo("ja-JP");
                }
                else if (cultureSelectedType == "France")
                {
                    acccountmaskedEdit.Culture = new CultureInfo("fr-FR");
                    descriptionmaskedEdit.Culture = new CultureInfo("fr-FR");
                    amountmaskedEdit.Culture = new CultureInfo("fr-FR");
                    emailIDmaskedEdit.Culture = new CultureInfo("fr-FR");
                    mobileNumbermaskedEdit.Culture = new CultureInfo("fr-FR");
                }
                else if (cultureSelectedType == "Italy")
                {
                    acccountmaskedEdit.Culture = new CultureInfo("it-IT");
                    descriptionmaskedEdit.Culture = new CultureInfo("it-IT");
                    amountmaskedEdit.Culture = new CultureInfo("it-IT");
                    emailIDmaskedEdit.Culture = new CultureInfo("it-IT");
                    mobileNumbermaskedEdit.Culture = new CultureInfo("it-IT");
                }
            };
            culturePicker = new UIPickerView();
            culturePicker.ShowSelectionIndicator = true;
            culturePicker.Hidden = true;
            culturePicker.Model = culturePickermodel;
            culturePicker.BackgroundColor = UIColor.White;

            cultureDoneButton = new UIButton();
            cultureDoneButton.SetTitle("Done\t", UIControlState.Normal);
            cultureDoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            cultureDoneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            cultureDoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            cultureDoneButton.Hidden = true;
            cultureDoneButton.TouchUpInside += HideCulturePicker;

            hidepromptLabel = new UILabel();
            hidepromptLabel.TextColor = UIColor.Black;
            hidepromptLabel.BackgroundColor = UIColor.Clear;
            hidepromptLabel.Text = @"Hide Prompt On Leave";
            hidepromptLabel.TextAlignment = UITextAlignment.Left;
            hidepromptLabel.Font = UIFont.FromName("Helvetica", 16f);

            hidepromptSwitch = new UISwitch();
            hidepromptSwitch.ValueChanged += AllowSwitch_ValueChanged;
            hidepromptSwitch.On = false;

            promptcharLabel = new UILabel();
            promptcharLabel.TextColor = UIColor.Black;
            promptcharLabel.BackgroundColor = UIColor.Clear;
            promptcharLabel.Text = @"Prompt Character";
            promptcharLabel.TextAlignment = UITextAlignment.Left;
            promptcharLabel.Font = UIFont.FromName("Helvetica", 16f);

            promptcharButton = new UIButton();
            promptcharButton.SetTitle("_", UIControlState.Normal);
            promptcharButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            promptcharButton.BackgroundColor = UIColor.Clear;
            promptcharButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            promptcharButton.Hidden = false;
            promptcharButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
            promptcharButton.Layer.BorderWidth = 2;
            promptcharButton.Layer.CornerRadius = 8;
            promptcharButton.TouchUpInside += ShowpromptPicker;

            PickerModel promptcharPickermodel = new PickerModel(this.promptCharList);
            promptcharPickermodel.PickerChanged += (sender, e) =>
            {
                this.promptSelectedType = e.SelectedValue;
                promptcharButton.SetTitle(promptSelectedType, UIControlState.Normal);
                if (promptSelectedType == "*")
                {
                    acccountmaskedEdit.PromptChar = '*';
                    descriptionmaskedEdit.PromptChar = '*';
                    amountmaskedEdit.PromptChar = '*';
                    emailIDmaskedEdit.PromptChar = '*';
                    mobileNumbermaskedEdit.PromptChar = '*';
                }
                else if (promptSelectedType == "~")
                {
                    acccountmaskedEdit.PromptChar = '~';
                    descriptionmaskedEdit.PromptChar = '~';
                    amountmaskedEdit.PromptChar = '~';
                    emailIDmaskedEdit.PromptChar = '~';
                    mobileNumbermaskedEdit.PromptChar = '~';
                }
                else if (promptSelectedType == "_")
                {
                    acccountmaskedEdit.PromptChar = '_';
                    descriptionmaskedEdit.PromptChar = '_';
                    amountmaskedEdit.PromptChar = '_';
                    emailIDmaskedEdit.PromptChar = '_';
                    mobileNumbermaskedEdit.PromptChar = '_';
                }
            };
            promptPicker = new UIPickerView();
            promptPicker.ShowSelectionIndicator = true;
            promptPicker.Hidden = true;
            promptPicker.Model = promptcharPickermodel;
            promptPicker.BackgroundColor = UIColor.White;

            promptDoneButton = new UIButton();
            promptDoneButton.SetTitle("Done\t", UIControlState.Normal);
            promptDoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            promptDoneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            promptDoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            promptDoneButton.Hidden = true;
            promptDoneButton.TouchUpInside += HidepromptPicker;

            //propertiesLabel
            propertiesLabel = new UILabel();
            propertiesLabel.Text = "OPTIONS";


            //showPropertyButton
            showPropertyButton = new UIButton();
            showPropertyButton.Hidden = true;
            showPropertyButton.SetTitle(" OPTIONS\t", UIControlState.Normal);
            showPropertyButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
            showPropertyButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            showPropertyButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            showPropertyButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                subView.Hidden = false;
                showPropertyButton.Hidden = true;
            };
            this.AddSubview(showPropertyButton);


            //closeButton
            closeButton = new UIButton();
            closeButton.SetTitle("X\t", UIControlState.Normal);
            closeButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
            closeButton.BackgroundColor = UIColor.FromRGB(230, 230, 230);
            closeButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            closeButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                subView.Hidden = true;
                showPropertyButton.Hidden = false;
            };

            //subVieww
            subView.AddSubview(closeButton);
            subView.AddSubview(propertiesLabel);
            subView.BackgroundColor = UIColor.FromRGB(230, 230, 230);
            contentView.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            subView.AddSubview(contentView);
            this.AddSubview(subView);


            //AddingGesture
            UITapGestureRecognizer tapgesture = new UITapGestureRecognizer(() =>
            {
                subView.Hidden = true;
                showPropertyButton.Hidden = false;
            }
            );
            propertiesLabel.UserInteractionEnabled = true;
            propertiesLabel.AddGestureRecognizer(tapgesture);
            this.BackgroundColor = UIColor.White;
        }

        public void optionView()
        {
            contentView.AddSubview(inputValidationModeLabel);
            contentView.AddSubview(validationButton);
            contentView.AddSubview(cutCopyPicker);
            contentView.AddSubview(validationDoneButton);
            contentView.AddSubview(cultureLabel);
            contentView.AddSubview(cultureButton);
            contentView.AddSubview(culturePicker);
            contentView.AddSubview(cultureDoneButton);
            contentView.AddSubview(hidepromptLabel);
            contentView.AddSubview(hidepromptSwitch);
            contentView.AddSubview(promptcharLabel);
            contentView.AddSubview(promptcharButton);
            contentView.AddSubview(promptPicker);
            contentView.AddSubview(promptDoneButton);
            subView.AddSubview(closeButton);
            contentView.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            subView.BackgroundColor = UIColor.FromRGB(230, 230, 230);
            subView.AddSubview(contentView);
            this.AddSubview(subView);
        }

        private void HidepromptPicker(object sender, EventArgs e)
        {
            promptDoneButton.Hidden = true;
            promptPicker.Hidden = true;


            validationButton.Hidden = false;
            inputValidationModeLabel.Hidden = false;
            cultureLabel.Hidden = false;
            hidepromptLabel.Hidden = false;
            promptcharLabel.Hidden = false;
            validationButton.Hidden = false;
            cultureButton.Hidden = false;
            promptcharButton.Hidden = false;
            hidepromptSwitch.Hidden = false;
        }

        private void ShowpromptPicker(object sender, EventArgs e)
        {
            promptDoneButton.Hidden = false;
            promptPicker.Hidden = false;


            validationButton.Hidden = true;
            inputValidationModeLabel.Hidden = true;
            cultureLabel.Hidden = true;
            hidepromptLabel.Hidden = true;
            promptcharLabel.Hidden = true;
            validationButton.Hidden = true;
            cultureButton.Hidden = true;
            promptcharButton.Hidden = true;
            hidepromptSwitch.Hidden = true;
        }

        private void CutCopyDoneButton_TouchUpInside(object sender, EventArgs e)
        {
            validationDoneButton.Hidden = true;
            cutCopyPicker.Hidden = true;

            validationButton.Hidden = false;
            inputValidationModeLabel.Hidden = false;
            cultureLabel.Hidden = false;
            hidepromptLabel.Hidden = false;
            promptcharLabel.Hidden = false;
            validationButton.Hidden = false;
            cultureButton.Hidden = false;
            promptcharButton.Hidden = false;
            hidepromptSwitch.Hidden = false;
        }

        private void CutCopyMaskFormatButton_TouchUpInside(object sender, EventArgs e)
        {
            validationDoneButton.Hidden = false;
            cutCopyPicker.Hidden = false;

            validationButton.Hidden = true;
            inputValidationModeLabel.Hidden = true;
            cultureLabel.Hidden = true;
            hidepromptLabel.Hidden = true;
            promptcharLabel.Hidden = true;
            validationButton.Hidden = true;
            cultureButton.Hidden = true;
            promptcharButton.Hidden = true;
            hidepromptSwitch.Hidden = true;



        }
        private void ShowCulturePicker(object sender, EventArgs e)
        {
            cultureDoneButton.Hidden = false;
            culturePicker.Hidden = false;

            validationButton.Hidden = true;
            inputValidationModeLabel.Hidden = true;
            cultureLabel.Hidden = true;
            hidepromptLabel.Hidden = true;
            promptcharLabel.Hidden = true;
            validationButton.Hidden = true;
            cultureButton.Hidden = true;
            promptcharButton.Hidden = true;
            hidepromptSwitch.Hidden = true;
        }
        private void AllowSwitch_ValueChanged(object sender, EventArgs e)
        {
            if (((UISwitch)sender).On)
            {
                acccountmaskedEdit.HidePromptOnLeave = true;
                descriptionmaskedEdit.HidePromptOnLeave = true;
                amountmaskedEdit.HidePromptOnLeave = true;
                emailIDmaskedEdit.HidePromptOnLeave = true;
                mobileNumbermaskedEdit.HidePromptOnLeave = true;
            }
            else
            {
                acccountmaskedEdit.HidePromptOnLeave = false;
                descriptionmaskedEdit.HidePromptOnLeave = false;
                amountmaskedEdit.HidePromptOnLeave = false;
                emailIDmaskedEdit.HidePromptOnLeave = false;
                mobileNumbermaskedEdit.HidePromptOnLeave = false;
            }
        }
        void HideCulturePicker(object sender, EventArgs e)
        {
            cultureDoneButton.Hidden = true;
            culturePicker.Hidden = true;

            validationButton.Hidden = false;
            inputValidationModeLabel.Hidden = false;
            cultureLabel.Hidden = false;
            hidepromptLabel.Hidden = false;
            promptcharLabel.Hidden = false;
            validationButton.Hidden = false;
            cultureButton.Hidden = false;
            promptcharButton.Hidden = false;
            hidepromptSwitch.Hidden = false;

        }

    }
}
