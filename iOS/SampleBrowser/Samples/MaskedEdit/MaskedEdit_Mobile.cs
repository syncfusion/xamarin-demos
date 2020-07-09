#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.iOS.MaskedEdit;
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
    public class MaskedEdit_Mobile : SampleView
    {
        UIView view;
        UIButton searchButton = new UIButton();
        public UIView option = new UIView();
        UILabel visibilityLabel, fundTransferLable, accountLabel, descriptionLabel, amountLabel, emailIDLabel, mobileNumberLabel, inputValidationModeLabel, cultureLabel, hidepromptLabel, promptcharLabel;
        UILabel accInputRejectLable, amtInputRejectLable, emailInputRejectLable, phoneInputRejectLable;
        SfMaskedEdit acccountmaskedEdit, descriptionmaskedEdit, amountmaskedEdit, emailIDmaskedEdit, mobileNumbermaskedEdit;
        private UIPickerView visibilityPicker, cutCopyPicker, promptPicker, culturePicker;
        private UIButton visibilityDoneButton, visibilityButton, promptcharButton, validationDoneButton, promptDoneButton, validationButton, cultureDoneButton, cultureButton;
        private readonly IList<string> cultureList, inputValidationModeList, promptCharList, visibilityList;
        private string cultureSelectedType, validationSelectedType, promptSelectedType, visibilityType;
        private UISwitch hidepromptSwitch;
        UIScrollView scrollView = new UIScrollView();
        nfloat accPoint = 0;
        nfloat amtPoint = 0;
        nfloat emailPoint = 0;
        nfloat phonePoint = 0;
        public override void LayoutSubviews()
        {

            foreach (var view in this.Subviews)
            {
                view.Frame = new CGRect(Frame.Location.X, 0.0f, Frame.Size.Width, Frame.Size.Height);
                this.OptionView.Frame = view.Frame;
                this.option.Frame = new CGRect(0, 20, Frame.Width, Frame.Height);
                scrollView.Frame = new CGRect(Frame.Location.X, 0.0f, Frame.Width, Frame.Height);
                scrollView.ContentSize = new CGSize(scrollView.Frame.Width, scrollView.Frame.Height + 255);
                fundTransferLable.Frame = new CGRect(10, 0, this.Frame.Size.Width - 20, 40);
                accountLabel.Frame = new CGRect(10, 30, this.Frame.Size.Width - 20, 40);
                acccountmaskedEdit.Frame = new CGRect(10, 65, this.Frame.Size.Width - 20, 40);

                accInputRejectLable.Frame = new CGRect(10, 105, this.Frame.Size.Width - 20, 20);

                descriptionLabel.Frame = new CGRect(10, 105 + accPoint, view.Frame.Width - 10, 40);
                descriptionmaskedEdit.Frame = new CGRect(10, 140 + accPoint, view.Frame.Width - 20, 40);

                amountLabel.Frame = new CGRect(10, 180 + accPoint, view.Frame.Width - 20, 40);
                amountmaskedEdit.Frame = new CGRect(10, 215 + accPoint, view.Frame.Width - 20, 40);

                amtInputRejectLable.Frame = new CGRect(10, 255 + accPoint, this.Frame.Size.Width - 20, 20);

                emailIDLabel.Frame = new CGRect(10, 255 + accPoint + amtPoint, view.Frame.Width - 20, 40);
                emailIDmaskedEdit.Frame = new CGRect(10, 290 + accPoint + amtPoint, view.Frame.Width - 20, 40);

                emailInputRejectLable.Frame = new CGRect(10, 330 + accPoint + amtPoint, this.Frame.Size.Width - 20, 20);

                mobileNumberLabel.Frame = new CGRect(10, 330 + accPoint + amtPoint + emailPoint, view.Frame.Width - 20, 40);
                mobileNumbermaskedEdit.Frame = new CGRect(10, 365 + accPoint + amtPoint + emailPoint, view.Frame.Width - 20, 40);

                phoneInputRejectLable.Frame = new CGRect(10, 405 + accPoint + amtPoint + emailPoint, this.Frame.Size.Width - 20, 15);

                searchButton.Frame = new CGRect(10, 430 + accPoint + amtPoint + emailPoint + phonePoint, this.Frame.Size.Width - 20, 40);

                inputValidationModeLabel.Frame = new CGRect(10, 20, this.Frame.Size.Width - 10, 30);
                validationButton.Frame = new CGRect(10, 50, this.Frame.Size.Width - 20, 20);
                cutCopyPicker.Frame = new CGRect(10, 260, this.Frame.Size.Width, 100);
                validationDoneButton.Frame = new CGRect(10, 255, this.Frame.Size.Width - 20, 30);

                cultureLabel.Frame = new CGRect(10, 70, this.Frame.Size.Width - 20, 30);
                cultureButton.Frame = new CGRect(10, 100, this.Frame.Size.Width - 20, 20);
                culturePicker.Frame = new CGRect(10, 260, this.Frame.Size.Width, 100);
                cultureDoneButton.Frame = new CGRect(10, 255, this.Frame.Size.Width - 20, 30);

                visibilityLabel.Frame = new CGRect(10, 125, this.Frame.Size.Width - 20, 30);
                visibilityButton.Frame = new CGRect(10, 155, this.Frame.Size.Width - 20, 20);
                visibilityPicker.Frame = new CGRect(10, 260, this.Frame.Size.Width, 100);
                visibilityDoneButton.Frame = new CGRect(10, 255, this.Frame.Size.Width - 20, 30);

                hidepromptLabel.Frame = new CGRect(10, 175, this.Frame.Size.Width - 20, 40);
                hidepromptSwitch.Frame = new CGRect(250, 180, this.Frame.Size.Width - 20, 15);

                promptcharLabel.Frame = new CGRect(10, 215, this.Frame.Size.Width - 20, 40);
                promptcharButton.Frame = new CGRect(200, 220, this.Frame.Size.Width - 215, 30);
                promptPicker.Frame = new CGRect(10, 260, this.Frame.Size.Width, 100);
                promptDoneButton.Frame = new CGRect(10, 255, this.Frame.Size.Width - 20, 30);


            }
            this.optionView();
            base.LayoutSubviews();
        }

        public void optionView()
        {
            option.AddSubview(inputValidationModeLabel);
            option.AddSubview(validationButton);
            option.AddSubview(cutCopyPicker);
            option.AddSubview(validationDoneButton);
            option.AddSubview(cultureLabel);
            option.AddSubview(cultureButton);
            option.AddSubview(culturePicker);
            option.AddSubview(cultureDoneButton);
            option.AddSubview(visibilityLabel);
            option.AddSubview(visibilityButton);
            option.AddSubview(visibilityPicker);
            option.AddSubview(visibilityDoneButton);
            option.AddSubview(hidepromptLabel);
            option.AddSubview(hidepromptSwitch);
            option.AddSubview(promptcharLabel);
            option.AddSubview(promptcharButton);
            option.AddSubview(promptPicker);
            option.AddSubview(promptDoneButton);

        }

        public MaskedEdit_Mobile()
        {
            view = new UIView();
            this.OptionView = new UIView();
            this.cultureList = new List<string>() { (NSString)"United States", (NSString)"United Kingdom", (NSString)"Japan", (NSString)"France", (NSString)"Italy" };
            this.inputValidationModeList = new List<string>() { (NSString)"Key Press", (NSString)"Lost Focus" };
            this.visibilityList = new List<string> { (NSString)"While Editing", (NSString)"Never", };
            this.promptCharList = new List<string>() { "_", "*", "~" };

            fundTransferLable = new UILabel();
            fundTransferLable.TextColor = UIColor.Black;
            fundTransferLable.BackgroundColor = UIColor.Clear;
            fundTransferLable.Text = @"Funds Transfer";
            fundTransferLable.TextAlignment = UITextAlignment.Left;
            fundTransferLable.Font = UIFont.FromName("Helvetica-Bold", 20f);
            scrollView.AddSubview(fundTransferLable);

            accountLabel = new UILabel();
            accountLabel.Text = "To Account";
            accountLabel.TextColor = UIColor.Black;
            accountLabel.Font = UIFont.FromName("Helvetica", 16f);
            scrollView.AddSubview(accountLabel);

            acccountmaskedEdit = new SfMaskedEdit();
            acccountmaskedEdit.Mask = "0000 0000 0000 0000";
            acccountmaskedEdit.Culture = new CultureInfo("en-us");
            acccountmaskedEdit.ClipsToBounds = true;
            acccountmaskedEdit.ValueMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            acccountmaskedEdit.Layer.BorderColor = UIColor.LightGray.CGColor;
            acccountmaskedEdit.TextAlignment = UITextAlignment.Left;
            acccountmaskedEdit.ValidationMode = InputValidationMode.KeyPress;
            acccountmaskedEdit.MaskInputRejected += AcccountmaskedEdit_MaskInputRejected;
            acccountmaskedEdit.ValueChanged += AcccountmaskedEdit_ValueChanged;
            acccountmaskedEdit.Placeholder = "1234 1234 1234 1234";
            acccountmaskedEdit.ClearButtonMode = UITextFieldViewMode.WhileEditing;
            scrollView.AddSubview(acccountmaskedEdit);

            accInputRejectLable = new UILabel();
            accInputRejectLable.Font = UIFont.FromName("Helvetica", 12f);
            accInputRejectLable.TextColor = UIColor.Red;
            accInputRejectLable.Hidden = true;
            scrollView.AddSubview(accInputRejectLable);

            descriptionLabel = new UILabel();
            descriptionLabel.Text = "Description";
            descriptionLabel.TextColor = UIColor.Black;
            descriptionLabel.Font = UIFont.FromName("Helvetica", 16f);
            scrollView.AddSubview(descriptionLabel);

            descriptionmaskedEdit = new SfMaskedEdit();
            descriptionmaskedEdit.Mask = "";
            descriptionmaskedEdit.Culture = new CultureInfo("en-us");
            descriptionmaskedEdit.ValueMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            descriptionmaskedEdit.Placeholder = "Enter description";
            descriptionmaskedEdit.TextAlignment = UITextAlignment.Left;
            descriptionmaskedEdit.ClipsToBounds = true;
            descriptionmaskedEdit.Layer.BorderColor = UIColor.LightGray.CGColor;
            descriptionmaskedEdit.ClearButtonMode = UITextFieldViewMode.WhileEditing;
            scrollView.AddSubview(descriptionmaskedEdit);

            amountLabel = new UILabel();
            amountLabel.Text = "Amount";
            amountLabel.TextColor = UIColor.Black;
            amountLabel.Font = UIFont.FromName("Helvetica", 16f);
            scrollView.AddSubview(amountLabel);

            amountmaskedEdit = new SfMaskedEdit();
            amountmaskedEdit.Mask = "$ 0,000.00";
            amountmaskedEdit.Culture = new CultureInfo("en-us");
            amountmaskedEdit.Placeholder = "$ 3,874.00";
            amountmaskedEdit.ValueMaskFormat = MaskFormat.IncludeLiterals;
            amountmaskedEdit.Layer.BorderColor = UIColor.LightGray.CGColor;
            amountmaskedEdit.ValidationMode = InputValidationMode.KeyPress;
            amountmaskedEdit.MaskInputRejected += AmountmaskedEdit_MaskInputRejected;
            amountmaskedEdit.ValueChanged += AmountmaskedEdit_ValueChanged;
            amountmaskedEdit.TextAlignment = UITextAlignment.Left;
            amountmaskedEdit.ClearButtonMode = UITextFieldViewMode.WhileEditing;
            scrollView.AddSubview(amountmaskedEdit);

            amtInputRejectLable = new UILabel();
            amtInputRejectLable.Font = UIFont.FromName("Helvetica", 12f);
            amtInputRejectLable.TextColor = UIColor.Red;
            amtInputRejectLable.Hidden = true;
            scrollView.AddSubview(amtInputRejectLable);

            emailIDLabel = new UILabel();
            emailIDLabel.Text = "Email ID";
            emailIDLabel.TextColor = UIColor.Black;
            emailIDLabel.Font = UIFont.FromName("Helvetica", 16f);
            scrollView.AddSubview(emailIDLabel);

            emailIDmaskedEdit = new SfMaskedEdit();
            emailIDmaskedEdit.Mask = @"\w+@\w+\.\w+";
            emailIDmaskedEdit.Culture = new CultureInfo("en-us");
            emailIDmaskedEdit.Placeholder = "david@syncfusion.com";
            emailIDmaskedEdit.ValueMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            emailIDmaskedEdit.ValidationMode = InputValidationMode.KeyPress;
            emailIDmaskedEdit.MaskInputRejected += EmailIDmaskedEdit_MaskInputRejected;
            emailIDmaskedEdit.ValueChanged += EmailIDmaskedEdit_ValueChanged;
            emailIDmaskedEdit.MaskType = MaskType.RegEx;
            emailIDmaskedEdit.Layer.BorderColor = UIColor.LightGray.CGColor;
            emailIDmaskedEdit.ClearButtonMode = UITextFieldViewMode.WhileEditing;
            scrollView.AddSubview(emailIDmaskedEdit);

            emailInputRejectLable = new UILabel();
            emailInputRejectLable.Font = UIFont.FromName("Helvetica", 12f);
            emailInputRejectLable.TextColor = UIColor.Red;
            emailInputRejectLable.Hidden = true;
            scrollView.AddSubview(emailInputRejectLable);

            mobileNumberLabel = new UILabel();
            mobileNumberLabel.Text = "Mobile Number";
            mobileNumberLabel.TextColor = UIColor.Black;
            mobileNumberLabel.Font = UIFont.FromName("Helvetica", 16f);
            scrollView.AddSubview(mobileNumberLabel);

            mobileNumbermaskedEdit = new SfMaskedEdit();
            mobileNumbermaskedEdit.Mask = "+1 000 000 0000";
            mobileNumbermaskedEdit.Culture = new CultureInfo("en-us");
            mobileNumbermaskedEdit.ClipsToBounds = true;
            mobileNumbermaskedEdit.ValueMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mobileNumbermaskedEdit.Layer.BorderColor = UIColor.LightGray.CGColor;
            mobileNumbermaskedEdit.ValidationMode = InputValidationMode.KeyPress;
            mobileNumbermaskedEdit.MaskInputRejected += MobileNumbermaskedEdit_MaskInputRejected;
            mobileNumbermaskedEdit.ValueChanged += MobileNumbermaskedEdit_ValueChanged;
            mobileNumbermaskedEdit.Placeholder = "+1 323 339 3392";
            mobileNumbermaskedEdit.TextAlignment = UITextAlignment.Left;
            mobileNumbermaskedEdit.ClearButtonMode = UITextFieldViewMode.WhileEditing;
            scrollView.AddSubview(mobileNumbermaskedEdit);

            phoneInputRejectLable = new UILabel();
            phoneInputRejectLable.Font = UIFont.FromName("Helvetica", 12f);
            phoneInputRejectLable.TextColor = UIColor.Red;
            phoneInputRejectLable.Hidden = true;
            scrollView.AddSubview(phoneInputRejectLable);


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
            scrollView.AddSubview(searchButton);

            AddSubview(scrollView);
            mainPageDesign();
        }

        private void MobileNumbermaskedEdit_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            phoneInputRejectLable.Hidden = true;
            phonePoint = 0;
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

        private void EmailIDmaskedEdit_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            emailInputRejectLable.Hidden = true;
            emailPoint = 0;
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

        private void AmountmaskedEdit_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            amtInputRejectLable.Hidden = true;
            amtPoint = 0;
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

        private void AcccountmaskedEdit_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            accInputRejectLable.Hidden = true;
            accPoint = 0;
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
            inputValidationModeLabel.Font = UIFont.FromName("Helvetica", 13f);

            validationButton = new UIButton();
            validationButton.SetTitle("Key Press", UIControlState.Normal);
            validationButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            validationButton.BackgroundColor = UIColor.Clear;
            validationButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            validationButton.Hidden = false;
            validationButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
            validationButton.Layer.BorderWidth = 2;
            validationButton.TitleLabel.Font = UIFont.SystemFontOfSize(13f);
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
            validationDoneButton.TitleLabel.Font = UIFont.SystemFontOfSize(13f);
            validationDoneButton.TouchUpInside += CutCopyDoneButton_TouchUpInside;

            cultureLabel = new UILabel();
            cultureLabel.TextColor = UIColor.Black;
            cultureLabel.BackgroundColor = UIColor.Clear;
            cultureLabel.Text = @"Culture";
            cultureLabel.TextAlignment = UITextAlignment.Left;
            cultureLabel.Font = UIFont.FromName("Helvetica", 13f);

            cultureButton = new UIButton();
            cultureButton.SetTitle("United States", UIControlState.Normal);
            cultureButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            cultureButton.BackgroundColor = UIColor.Clear;
            cultureButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            cultureButton.Hidden = false;
            cultureButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
            cultureButton.Layer.BorderWidth = 2;
            cultureButton.Layer.CornerRadius = 8;
            cultureButton.TitleLabel.Font = UIFont.SystemFontOfSize(13f);
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
            cultureDoneButton.TitleLabel.Font = UIFont.SystemFontOfSize(13f);
            cultureDoneButton.TouchUpInside += HideCulturePicker;

            visibilityLabel = new UILabel();
            visibilityLabel.TextColor = UIColor.Black;
            visibilityLabel.BackgroundColor = UIColor.Clear;
            visibilityLabel.Text = @"Clear Button Visibility";
            visibilityLabel.TextAlignment = UITextAlignment.Left;
            visibilityLabel.Font = UIFont.FromName("Helvetica", 13f);

            visibilityButton = new UIButton();
            visibilityButton.SetTitle("While Editing", UIControlState.Normal);
            visibilityButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            visibilityButton.BackgroundColor = UIColor.Clear;
            visibilityButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            visibilityButton.Hidden = false;
            visibilityButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
            visibilityButton.Layer.BorderWidth = 2;
            visibilityButton.Layer.CornerRadius = 8;
            visibilityButton.TitleLabel.Font = UIFont.SystemFontOfSize(13f);

            visibilityButton.TouchUpInside += VisibilityButton_TouchUpInside;
            PickerModel VisibilityPickermodel = new PickerModel(this.visibilityList);
            VisibilityPickermodel.PickerChanged += (sender, e) =>
            {
                this.visibilityType = e.SelectedValue;
                visibilityButton.SetTitle(visibilityType, UIControlState.Normal);
                if (visibilityType == "Never")
                {
                    acccountmaskedEdit.ClearButtonMode = UITextFieldViewMode.Never;
                    descriptionmaskedEdit.ClearButtonMode = UITextFieldViewMode.Never;
                    amountmaskedEdit.ClearButtonMode = UITextFieldViewMode.Never;
                    emailIDmaskedEdit.ClearButtonMode = UITextFieldViewMode.Never;
                    mobileNumbermaskedEdit.ClearButtonMode = UITextFieldViewMode.Never;
                }
                else if (visibilityType == "While Editing")
                {
                    acccountmaskedEdit.ClearButtonMode = UITextFieldViewMode.WhileEditing;
                    descriptionmaskedEdit.ClearButtonMode = UITextFieldViewMode.WhileEditing;
                    amountmaskedEdit.ClearButtonMode = UITextFieldViewMode.WhileEditing;
                    emailIDmaskedEdit.ClearButtonMode = UITextFieldViewMode.WhileEditing;
                    mobileNumbermaskedEdit.ClearButtonMode = UITextFieldViewMode.WhileEditing;
                }
            };


            visibilityPicker = new UIPickerView();
            visibilityPicker.ShowSelectionIndicator = true;
            visibilityPicker.Hidden = true;
            visibilityPicker.Model = VisibilityPickermodel;
            visibilityPicker.BackgroundColor = UIColor.White;

            visibilityDoneButton = new UIButton();
            visibilityDoneButton.SetTitle("Done\t", UIControlState.Normal);
            visibilityDoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            visibilityDoneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            visibilityDoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            visibilityDoneButton.Hidden = true;
            visibilityDoneButton.TitleLabel.Font = UIFont.SystemFontOfSize(13f);
            visibilityDoneButton.TouchUpInside += visibilityDoneButton_TouchUpInside;


            hidepromptLabel = new UILabel();
            hidepromptLabel.TextColor = UIColor.Black;
            hidepromptLabel.BackgroundColor = UIColor.Clear;
            hidepromptLabel.Text = @"Hide Prompt On Leave";
            hidepromptLabel.TextAlignment = UITextAlignment.Left;
            hidepromptLabel.Font = UIFont.FromName("Helvetica", 13f);

            hidepromptSwitch = new UISwitch();
            hidepromptSwitch.ValueChanged += AllowSwitch_ValueChanged;
            hidepromptSwitch.On = false;

            promptcharLabel = new UILabel();
            promptcharLabel.TextColor = UIColor.Black;
            promptcharLabel.BackgroundColor = UIColor.Clear;
            promptcharLabel.Text = @"Prompt Character";
            promptcharLabel.TextAlignment = UITextAlignment.Left;
            promptcharLabel.Font = UIFont.FromName("Helvetica", 13f);

            promptcharButton = new UIButton();
            promptcharButton.SetTitle("_", UIControlState.Normal);
            promptcharButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            promptcharButton.BackgroundColor = UIColor.Clear;
            promptcharButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            promptcharButton.Hidden = false;
            promptcharButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
            promptcharButton.Layer.BorderWidth = 2;
            promptcharButton.Layer.CornerRadius = 8;
            promptcharButton.TitleLabel.Font = UIFont.SystemFontOfSize(13f);
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
            promptDoneButton.TitleLabel.Font = UIFont.SystemFontOfSize(13f);
            promptDoneButton.TouchUpInside += HidepromptPicker;
            this.BackgroundColor = UIColor.White;
        }

        private void HidepromptPicker(object sender, EventArgs e)
        {
            promptDoneButton.Hidden = true;
            promptPicker.Hidden = true;
        }

        private void ShowpromptPicker(object sender, EventArgs e)
        {
            promptDoneButton.Hidden = false;
            promptPicker.Hidden = false;
        }

        private void CutCopyDoneButton_TouchUpInside(object sender, EventArgs e)
        {
            validationDoneButton.Hidden = true;
            cutCopyPicker.Hidden = true;
        }

        private void CutCopyMaskFormatButton_TouchUpInside(object sender, EventArgs e)
        {
            validationDoneButton.Hidden = false;
            cutCopyPicker.Hidden = false;

        }

        private void VisibilityButton_TouchUpInside(object sender, EventArgs e)
        {
            visibilityDoneButton.Hidden = false;
            visibilityPicker.Hidden = false;
        }

        private void visibilityDoneButton_TouchUpInside(object sender, EventArgs e)
        {
            visibilityDoneButton.Hidden = true;
            visibilityPicker.Hidden = true;
        }

        private void ShowCulturePicker(object sender, EventArgs e)
        {
            cultureDoneButton.Hidden = false;
            culturePicker.Hidden = false;
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
        }

    }
}
