#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Syncfusion.Android.MaskedEdit;
using System;
using System.Globalization;

namespace SampleBrowser
{
    public class SfMaskedEditText_Mobile
    {
        #region Fields
        SfMaskedEdit sfToAccount, sfDesc, amountMask, emailMask, phoneMask;
        TextView erroToAccount, errotextAmount, errotextEmail, errotextPhone;
        Context context;
        LinearLayout propertylayout;
        InputValidationMode validationMask;
        CultureInfo currentCulute;

        /// <summary>
        /// Contain the close button visibility details
        /// </summary>
        ClearButtonVisibilityMode clearButtonVisibility;

        bool hidePrompt;
        char currentPrompt;
        AlertDialog.Builder resultsDialog;
        SfMaskedEditProperties maskProperties;
        #endregion
        public SfMaskedEditText_Mobile()
        {
            maskProperties = new SfMaskedEditProperties(this);
        }

        #region Properties
        internal InputValidationMode ValidationMask
        {
            get
            {
                return validationMask;
            }
            set
            {
                validationMask = value;
            }
        }

        internal char CurrentPrompt
        {
            get
            {
                return currentPrompt;
            }
            set
            {
                currentPrompt = value;
            }
        }

        internal CultureInfo CurrentCulture
        {
            get
            {
                return currentCulute;
            }
            set
            {
                currentCulute = value;
            }
        }

        /// <summary>
        /// Gets or Set the close button visibility.
        /// </summary>
        internal ClearButtonVisibilityMode ClearButtonVisibility
        {
            get
            {
                return clearButtonVisibility;
            }
            set
            {
                clearButtonVisibility = value;
            }
        }

        internal bool HidePrompt
        {
            get
            {
                return hidePrompt;
            }
            set
            {
                hidePrompt = value;
            }
        }
        #endregion
        public View GetSampleContent(Context con)
        {
            ScrollView scroll = new ScrollView(con);
            bool isTablet = SfMaskedEditText.IsTabletDevice(con);
            LinearLayout linear = new LinearLayout(con);
            linear.SetBackgroundColor(Color.White);
            linear.Orientation = Orientation.Vertical;
            linear.SetPadding(12, 12, 12, 12);

            TextView headLabel = new TextView(con);
            headLabel.TextSize = 30;
            headLabel.SetTextColor(Color.ParseColor("#262626"));
            headLabel.Typeface = Typeface.DefaultBold;
            headLabel.Text = "Funds Transfer";
            linear.AddView(headLabel);

            TextView fundTransferLabelSpacing = new TextView(con);
            fundTransferLabelSpacing.SetHeight(40);
            linear.AddView(fundTransferLabelSpacing);

            TextView textToAccount = new TextView(con);
            textToAccount.SetTextColor(Color.ParseColor("#6d6d72"));
            textToAccount.TextSize = 16;
            textToAccount.Typeface = Typeface.Default;
            textToAccount.Text = "To Account";
            textToAccount.SetPadding(0, 0, 0, 10);
            linear.AddView(textToAccount);

            
            sfToAccount = new SfMaskedEdit(con);
            sfToAccount.Mask = "0000 0000 0000 0000";
            sfToAccount.Gravity = GravityFlags.Start;
            sfToAccount.ValidationMode = InputValidationMode.KeyPress;
            sfToAccount.ValueMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            sfToAccount.Hint = "1234 1234 1234 1234";
            sfToAccount.SetHintTextColor(Color.LightGray);
            linear.AddView(sfToAccount);

            erroToAccount = new TextView(con);
            erroToAccount.SetTextColor(Color.Red);
            erroToAccount.TextSize = 12;
            erroToAccount.Typeface = Typeface.Default;
            linear.AddView(erroToAccount);

            TextView textDesc = new TextView(con);
            textDesc.Text = "Description";
            textDesc.Typeface = Typeface.Default;
            textDesc.SetPadding(0, 30, 0, 10);
            textDesc.TextSize = 16;
            linear.AddView(textDesc);


            sfDesc = new SfMaskedEdit(con);
            sfDesc.Mask = "";
            sfDesc.Gravity = GravityFlags.Start;
            sfDesc.ValidationMode = InputValidationMode.KeyPress;
            sfDesc.ValueMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            sfDesc.Hint = "Enter description";
            sfDesc.SetHintTextColor(Color.LightGray);
            linear.AddView(sfDesc);


            TextView textAmount = new TextView(con);
            textAmount.Text = "Amount";
            textAmount.Typeface = Typeface.Default;
            textAmount.SetPadding(0, 30, 0, 10);
            textAmount.TextSize = 16;
            linear.AddView(textAmount);

            amountMask = new SfMaskedEdit(con);
            amountMask.Mask = "$ 0,000.00";
            amountMask.Gravity = GravityFlags.Start;
            amountMask.ValidationMode = InputValidationMode.KeyPress;
            amountMask.ValueMaskFormat = MaskFormat.IncludePromptAndLiterals;
            amountMask.Hint = "$ 3,874.00";
            amountMask.SetHintTextColor(Color.LightGray);
            linear.AddView(amountMask);

            errotextAmount = new TextView(con);
            errotextAmount.SetTextColor(Color.Red);
            errotextAmount.TextSize = 12;
            errotextAmount.Typeface = Typeface.Default;
            linear.AddView(errotextAmount);


            TextView textEmail = new TextView(con);
            textEmail.Text = "Email ID";
            textEmail.Typeface = Typeface.Default;
            textEmail.SetPadding(0, 30, 0, 10);
            textEmail.TextSize = 16;
            linear.AddView(textEmail);

            emailMask = new SfMaskedEdit(con);
            emailMask.Mask = @"\w+@\w+\.\w+";
            emailMask.MaskType = MaskType.RegEx;
            emailMask.Gravity = GravityFlags.Start;
            emailMask.ValidationMode = InputValidationMode.KeyPress;
            emailMask.ValueMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            emailMask.Hint = "david@syncfusion.com";
            emailMask.SetHintTextColor(Color.LightGray);
            linear.AddView(emailMask);

            errotextEmail = new TextView(con);
            errotextEmail.SetTextColor(Color.Red);
            errotextEmail.TextSize = 12;
            errotextEmail.Typeface = Typeface.Default;
            linear.AddView(errotextEmail);

            TextView textPhone = new TextView(con);
            textPhone.Text = "Mobile Number ";
            textPhone.Typeface = Typeface.Default;
            textPhone.SetPadding(0, 30, 0, 10);
            textPhone.TextSize = 16;
            linear.AddView(textPhone);

            phoneMask = new SfMaskedEdit(con);
            phoneMask.Mask = "+1 000 000 0000";
            phoneMask.Gravity = GravityFlags.Start;
            phoneMask.ValueMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            phoneMask.ValidationMode = InputValidationMode.KeyPress;
            phoneMask.Hint = "+1 323 339 3392";
            phoneMask.SetHintTextColor(Color.LightGray);
            linear.AddView(phoneMask);

            errotextPhone = new TextView(con);
            errotextPhone.SetTextColor(Color.Red);
            errotextPhone.TextSize = 12;
            errotextPhone.Typeface = Typeface.Default;
            linear.AddView(errotextPhone);

            TextView searchButtonSpacing = new TextView(con);
            searchButtonSpacing.SetHeight(30);

            Button searchButton = new Button(con);
            searchButton.SetWidth(ActionBar.LayoutParams.MatchParent);
            searchButton.SetHeight(40);
            searchButton.Text = "TRANSFER MONEY";
            searchButton.SetTextColor(Color.White);
            searchButton.SetBackgroundColor(Color.Gray);
            searchButton.Click += (object sender, EventArgs e) =>
            {               
                 if (string.IsNullOrEmpty(sfToAccount.Text) || string.IsNullOrEmpty(sfDesc.Text) || string.IsNullOrEmpty(amountMask.Text) || string.IsNullOrEmpty(emailMask.Text) || string.IsNullOrEmpty(phoneMask.Text))
                {
                    resultsDialog.SetMessage("Please fill all the required data!");
                }
                else if((sfToAccount.HasError || sfDesc.HasError || amountMask.HasError || emailMask.HasError || phoneMask.HasError))
                {
                    resultsDialog.SetMessage("Please enter valid details");
                }
                else
                {
                    resultsDialog.SetMessage(string.Format("Amount of {0} has been transferred successfully!", amountMask.Value));
                    string mask1 = sfToAccount.Mask;
                    sfToAccount.Mask = string.Empty;
                    sfToAccount.Mask = mask1;

                    mask1 = sfDesc.Mask;
                    sfDesc.Mask = "0";
                    sfDesc.Mask = mask1;

                    mask1 = amountMask.Mask;
                    amountMask.Mask = string.Empty;
                    amountMask.Mask = mask1;

                    mask1 = emailMask.Mask;
                    emailMask.Mask = string.Empty;
                    emailMask.Mask = mask1;

                    mask1 = phoneMask.Mask;
                    phoneMask.Mask = string.Empty;
                    phoneMask.Mask = mask1;

                }
                resultsDialog.Create().Show();
            };
            linear.AddView(searchButtonSpacing);
            linear.AddView(searchButton);

            sfToAccount.ValueChanged += SfToAccount_ValueChanged;
            sfToAccount.MaskInputRejected += SfToAccount_MaskInputRejected;

            amountMask.ValueChanged += AmountMask_ValueChanged;
            amountMask.MaskInputRejected += AmountMask_MaskInputRejected;

            emailMask.ValueChanged += EmailMask_ValueChanged;
            emailMask.MaskInputRejected += EmailMask_MaskInputRejected;

            phoneMask.ValueChanged += PhoneMask_ValueChanged;
            phoneMask.MaskInputRejected += PhoneMask_MaskInputRejected;

            //results dialog
            resultsDialog = new AlertDialog.Builder(con);
            resultsDialog.SetTitle("Status");
            resultsDialog.SetPositiveButton("OK", (object sender, DialogClickEventArgs e) =>
            {
            });

            resultsDialog.SetCancelable(true);

            scroll.AddView(linear);

            return scroll;
        }

        private void PhoneMask_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            errotextPhone.Text = GetRejectionHintText(e.RejectionHint);
        }

        private void PhoneMask_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            errotextPhone.Text = "";
        }

        private void EmailMask_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            errotextEmail.Text = GetRejectionHintText(e.RejectionHint);
        }

        private void EmailMask_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            errotextEmail.Text = "";
        }

        private void AmountMask_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            errotextAmount.Text = GetRejectionHintText(e.RejectionHint);
        }

        private void AmountMask_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            errotextAmount.Text = "";
        }

        private void SfToAccount_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            erroToAccount.Text = GetRejectionHintText(e.RejectionHint);
        }

        private void SfToAccount_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            erroToAccount.Text = "";
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
                    //case MaskedTextResultHint.UnavailableEditPosition:
                    //    hintText = "Invalid typed character!";
                    //    break;
            }
            return hintText;
        }

        public View GetPropertyWindowLayout(Context context1)
        {
            bool isTablet = SfMaskedEditText.IsTabletDevice(context1);
            LinearLayout gridLinearLayout = null;
            context = context1;
            if (isTablet)
            {
                gridLinearLayout = new LinearLayout(context) { Orientation = Android.Widget.Orientation.Vertical };

                LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);

                layoutParams.TopMargin = 25;
                gridLinearLayout.LayoutParameters = layoutParams;
                gridLinearLayout.SetBackgroundResource(Resource.Drawable.LinearLayout_Border);
            }

            propertylayout = new LinearLayout(context);
            propertylayout.Orientation = Android.Widget.Orientation.Vertical;

            maskProperties.ValidationLayout(context, propertylayout, true);
            maskProperties.CultureLayout(context, propertylayout, true);
            maskProperties.CloseButtonVisibilityLayout(context, propertylayout, true);
            maskProperties.HideLayout(context, propertylayout, true);
            maskProperties.PromptLayout(context, propertylayout, true);

            if (isTablet)
            {
                gridLinearLayout.AddView(propertylayout);
                return gridLinearLayout;
            }
            else
                return propertylayout;
        }


        public void OnApplyChanges()
        {
            sfToAccount.HidePromptOnLeave = hidePrompt;
            sfToAccount.ValidationMode = validationMask;
            sfToAccount.PromptChar = currentPrompt;
            sfToAccount.Culture = currentCulute;
            sfToAccount.ClearButtonVisibility = clearButtonVisibility;
            sfDesc.HidePromptOnLeave = hidePrompt;
            sfDesc.ValidationMode = validationMask;
            sfDesc.PromptChar = currentPrompt;
            sfDesc.Culture = currentCulute;
            sfDesc.ClearButtonVisibility = clearButtonVisibility;
            amountMask.HidePromptOnLeave = hidePrompt;
            amountMask.ValidationMode = validationMask;
            amountMask.Culture = currentCulute;
            amountMask.PromptChar = currentPrompt;
            amountMask.ClearButtonVisibility = clearButtonVisibility;
            emailMask.HidePromptOnLeave = hidePrompt;
            emailMask.ValidationMode = validationMask;
            emailMask.PromptChar = currentPrompt;
            emailMask.Culture = currentCulute;
            emailMask.ClearButtonVisibility = clearButtonVisibility;
            phoneMask.HidePromptOnLeave = hidePrompt;
            phoneMask.ValidationMode = validationMask;
            phoneMask.PromptChar = currentPrompt;
            phoneMask.ClearButtonVisibility = clearButtonVisibility;
            phoneMask.Culture = currentCulute;
        }

    }
}