#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Syncfusion.Android.MaskedEdit;

namespace SampleBrowser
{
    class SfMaskedEditText_Tab
    {
        SfMaskedEdit sfToAccount, sfDesc, amountMask, emailMask, phoneMask;
        TextView erroToAccount, errotextAmount, errotextEmail, errotextPhone;
        Context context;
        LinearLayout propertylayout ,linear;
        AlertDialog.Builder resultsDialog;
        FrameLayout propertyFrameLayout, buttomButtonLayout, frame;
        int totalWidth;
        Button propertyButton;
        TextView closeLabel;
        SfMaskedEditProperties maskProperties;
        InputValidationMode validationMask= InputValidationMode.KeyPress;
        CultureInfo currentCulute = new CultureInfo("en-us");

        /// <summary>
        /// Contain the close button visibility details
        /// </summary>
        ClearButtonVisibilityMode clearButtonVisibility;

        bool hidePrompt;
        char currentPrompt='_';
        double actionBarHeight, navigationBarHeight, totalHeight;
        LinearLayout proprtyOptionsLayout;
        ScrollView propPageScrollView ,mainPageScrollView;
        public SfMaskedEditText_Tab()
        {
            maskProperties = new SfMaskedEditProperties(this);
        }
        #region Properties

        internal LinearLayout ProprtyOptionsLayout
        {
            get
            {
                return proprtyOptionsLayout;
            }

            set
            {
                proprtyOptionsLayout = value;
            }
        }
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


        private void InitialMethod()
        {
            frame = new FrameLayout(context);
            totalHeight = context.Resources.DisplayMetrics.HeightPixels;

            TypedValue tv = new TypedValue();
            if (context.Theme.ResolveAttribute(Android.Resource.Attribute.ActionBarSize, tv, true))
            {
                actionBarHeight = TypedValue.ComplexToDimensionPixelSize(tv.Data, context.Resources.DisplayMetrics);
            }

            navigationBarHeight = getNavigationBarHeight(context);

            totalHeight = totalHeight - navigationBarHeight - actionBarHeight;
        }

        private int getNavigationBarHeight(Android.Content.Context con)
        {
            int navBarHeight = 0;
            int resourceId = con.Resources.GetIdentifier("navigation_bar_height", "dimen", "android");
            if (resourceId > 0)
            {
                navBarHeight = con.Resources.GetDimensionPixelSize(resourceId);
            }
            return navBarHeight;
        }
        public View GetSampleContent(Context con)
        {
            context = con;
            InitialMethod();

            ScrollView scroll = new ScrollView(con);
            bool isTablet = SfMaskedEditText.IsTabletDevice(con);
            linear= new LinearLayout(con);
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
            textToAccount.TextSize = 18;
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
            sfToAccount.FocusChange += SfToAccount_FocusChange;
            sfToAccount.SetHintTextColor(Color.LightGray);
            linear.AddView(sfToAccount);

            erroToAccount = new TextView(con);
            erroToAccount.SetTextColor(Color.Red);
            erroToAccount.TextSize = 14;
            erroToAccount.Typeface = Typeface.Default;
            linear.AddView(erroToAccount);

            TextView textDesc = new TextView(con);
            textDesc.Text = "Description";
            textDesc.Typeface = Typeface.Default;
            textDesc.SetPadding(0, 30, 0, 10);
            textDesc.TextSize = 18;
            linear.AddView(textDesc);


            sfDesc = new SfMaskedEdit(con);
            sfDesc.Mask = "";
            sfDesc.Gravity = GravityFlags.Start;
            sfDesc.ValidationMode = InputValidationMode.KeyPress;
            sfDesc.ValueMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            sfDesc.Hint = "Enter description";
            sfDesc.FocusChange += SfToAccount_FocusChange;
            sfDesc.SetHintTextColor(Color.LightGray);
            linear.AddView(sfDesc);


            TextView textAmount = new TextView(con);
            textAmount.Text = "Amount";
            textAmount.Typeface = Typeface.Default;
            textAmount.SetPadding(0, 30, 0, 10);
            textAmount.TextSize = 18;
            linear.AddView(textAmount);

            amountMask = new SfMaskedEdit(con);
            amountMask.Mask = "$ 0,000.00";
            amountMask.Gravity = GravityFlags.Start;
            amountMask.ValidationMode = InputValidationMode.KeyPress;
            amountMask.ValueMaskFormat = MaskFormat.IncludePromptAndLiterals;
            amountMask.Hint = "$ 3,874.00";
            amountMask.FocusChange += SfToAccount_FocusChange;
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
            textEmail.TextSize = 18;
            linear.AddView(textEmail);

            emailMask = new SfMaskedEdit(con);
            emailMask.Mask = @"\w+@\w+\.\w+";
            emailMask.MaskType = MaskType.RegEx;
            emailMask.Gravity = GravityFlags.Start;
            emailMask.ValidationMode = InputValidationMode.KeyPress;
            emailMask.ValueMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            emailMask.Hint = "david@syncfusion.com";
            emailMask.FocusChange += SfToAccount_FocusChange;
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
            textPhone.TextSize = 18;
            linear.AddView(textPhone);

            phoneMask = new SfMaskedEdit(con);
            phoneMask.Mask = "+1 000 000 0000";
            phoneMask.Gravity = GravityFlags.Start;
            phoneMask.ValueMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            phoneMask.ValidationMode = InputValidationMode.KeyPress;
            phoneMask.Hint = "+1 323 339 3392";
            phoneMask.FocusChange += SfToAccount_FocusChange;
            phoneMask.SetHintTextColor(Color.LightGray);
            linear.AddView(phoneMask);

            errotextPhone = new TextView(con);
            errotextPhone.SetTextColor(Color.Red);
            errotextPhone.TextSize = 12;
            errotextPhone.Typeface = Typeface.Default;
            linear.AddView(errotextPhone);

            TextView transferButtonSpacing = new TextView(con);
            transferButtonSpacing.SetHeight(30);

            Button transferButton = new Button(con);
            transferButton.SetWidth(ActionBar.LayoutParams.MatchParent);
            transferButton.SetHeight(40);
            transferButton.Text = "TRANSFER MONEY";
            transferButton.SetTextColor(Color.White);
            transferButton.SetBackgroundColor(Color.Rgb(72, 178, 224));
            transferButton.Click += (object sender, EventArgs e) =>
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
            linear.AddView(transferButtonSpacing);
            linear.AddView(transferButton);

            TextView transferAfterButtonSpacing = new TextView(con);
            transferAfterButtonSpacing.SetHeight(60);
            linear.AddView(transferAfterButtonSpacing);

            sfToAccount.ValueChanged += SfToAccount_ValueChanged;
            sfToAccount.MaskInputRejected += SfToAccount_MaskInputRejected;

            amountMask.ValueChanged += AmountMask_ValueChanged;
            amountMask.MaskInputRejected += AmountMask_MaskInputRejected;

            emailMask.ValueChanged += EmailMask_ValueChanged;
            emailMask.MaskInputRejected += EmailMask_MaskInputRejected;

            phoneMask.ValueChanged += PhoneMask_ValueChanged;
            phoneMask.MaskInputRejected += PhoneMask_MaskInputRejected;

            linear.Touch += (object sender, View.TouchEventArgs e) =>
            {
                if (sfToAccount.IsFocused || sfDesc.IsFocused || amountMask.IsFocused || emailMask.IsFocused ||phoneMask.IsFocused)
                {
                    Rect outRect = new Rect();
                    sfToAccount.GetGlobalVisibleRect(outRect);
                    sfDesc.GetGlobalVisibleRect(outRect);
                    amountMask.GetGlobalVisibleRect(outRect);
                    emailMask.GetGlobalVisibleRect(outRect);
                    phoneMask.GetGlobalVisibleRect(outRect);
                    if (!outRect.Contains((int)e.Event.RawX, (int)e.Event.RawY))
                    {
                        sfToAccount.ClearFocus();
                        sfDesc.ClearFocus();
                        amountMask.ClearFocus();
                        emailMask.ClearFocus();
                        phoneMask.ClearFocus();

                    }
                }
                hideSoftKeyboard((Activity)con);
            };

            //results dialog
            resultsDialog = new AlertDialog.Builder(con);
            resultsDialog.SetTitle("Status");
            resultsDialog.SetPositiveButton("OK", (object sender, DialogClickEventArgs e) =>
            {
            });

            resultsDialog.SetCancelable(true);

            frame.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            frame.SetBackgroundColor(Color.White);
            frame.SetPadding(10, 10, 10, 10);

            //scrollView1
            mainPageScrollView = new ScrollView(con);
            mainPageScrollView.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.7), GravityFlags.Top | GravityFlags.CenterHorizontal);
            mainPageScrollView.AddView(linear);           
            frame.AddView(mainPageScrollView);

            //buttomButtonLayout
            buttomButtonLayout = new FrameLayout(con);
            buttomButtonLayout.SetBackgroundColor(Color.Transparent);
            buttomButtonLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.1), GravityFlags.Bottom | GravityFlags.CenterHorizontal);

            //propertyButton
            propertyButton = new Button(con);
            propertyButton.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent, GravityFlags.Bottom | GravityFlags.CenterHorizontal);
            propertyButton.Text = "OPTIONS";
            propertyButton.Gravity = GravityFlags.Start;
            propertyFrameLayout = new FrameLayout(con);
            propertyFrameLayout.SetBackgroundColor(Color.Rgb(236, 236, 236));
            propertyFrameLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.3), GravityFlags.CenterHorizontal);
            propertyFrameLayout.AddView(GetPropertyLayout(con));

            //propertyButton Click Listener
            propertyButton.Click += (object sender, EventArgs e) =>
            {
                buttomButtonLayout.RemoveAllViews();
                propertyFrameLayout.RemoveAllViews();
                propPageScrollView.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.3), GravityFlags.Bottom | GravityFlags.CenterHorizontal);
                mainPageScrollView.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.7), GravityFlags.Top | GravityFlags.CenterHorizontal);
                propertyFrameLayout.AddView(GetPropertyLayout(con));

            };

            //scrollView
            propPageScrollView = new ScrollView(con);
            propPageScrollView.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.3), GravityFlags.Bottom | GravityFlags.CenterHorizontal);
            propPageScrollView.AddView(propertyFrameLayout);

            frame.AddView(propPageScrollView);
            frame.AddView(buttomButtonLayout);
            frame.FocusableInTouchMode = true;

            return frame;
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

        public static void hideSoftKeyboard(Activity activity)
        {
            InputMethodManager inputMethodManager = (InputMethodManager)activity.GetSystemService(Activity.InputMethodService);
            inputMethodManager.HideSoftInputFromWindow(activity.CurrentFocus.WindowToken, 0);

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
            phoneMask.Culture = currentCulute;
            phoneMask.ClearButtonVisibility = clearButtonVisibility;
        }

        private void SfToAccount_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            if ((sender as EditText).IsFocused)
            {
                propertyFrameLayout.RemoveAllViews();
                buttomButtonLayout.RemoveAllViews();
                mainPageScrollView.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
                propPageScrollView.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.003), GravityFlags.Bottom | GravityFlags.CenterHorizontal);
                buttomButtonLayout.AddView(propertyButton);
            }
        }

        FrameLayout topProperty;
        private void OptionViewLayout()
        {
            /****************
             **Options View**
             ****************/
            TextView propertyLabel = new TextView(context);
            propertyLabel.SetTextColor(Color.ParseColor("#282828"));
            propertyLabel.Gravity = GravityFlags.CenterVertical;
            propertyLabel.TextSize = 18;
            propertyLabel.SetPadding(0, 10, 0, 10);
            propertyLabel.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent, GravityFlags.Left | GravityFlags.CenterHorizontal);
            propertyLabel.Text = "  " + "OPTIONS";

            //CloseLabel
            closeLabel = new TextView(context);
            closeLabel.SetBackgroundColor(Color.Transparent);
            closeLabel.Gravity = GravityFlags.CenterVertical;
            closeLabel.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent, GravityFlags.Right | GravityFlags.CenterHorizontal);
            closeLabel.SetBackgroundResource(Resource.Drawable.sfclosebutton);

            //CloseLayout
            FrameLayout closeLayout = new FrameLayout(context);
            closeLayout.SetBackgroundColor(Color.Transparent);
            closeLayout.SetPadding(0, 10, 0, 10);
            closeLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent, GravityFlags.Right | GravityFlags.CenterHorizontal);
            closeLayout.AddView(closeLabel);

            //TopProperty
            topProperty = new FrameLayout(context);
            topProperty.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            topProperty.SetBackgroundColor(Color.Rgb(230, 230, 230));
            topProperty.AddView(propertyLabel);
            topProperty.AddView(closeLayout);

            //topProperty Touch Event
            topProperty.Touch += (object sendar, View.TouchEventArgs e) =>
            {
                propertyFrameLayout.RemoveAllViews();                
                buttomButtonLayout.RemoveAllViews();               
                buttomButtonLayout.AddView(propertyButton);
                mainPageScrollView.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
                propPageScrollView.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent,(int)(totalHeight * 0.0003));
            };
            proprtyOptionsLayout = new LinearLayout(context);
            proprtyOptionsLayout.Orientation = Android.Widget.Orientation.Vertical;

            //SpaceText
            TextView spaceText1 = new TextView(context);
            spaceText1.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 38, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText1);
        }
        public View GetPropertyLayout(Android.Content.Context context)
        {

            totalWidth = (context.Resources.DisplayMetrics.WidthPixels);
            propertylayout = new LinearLayout(context);
            propertylayout.Orientation = Orientation.Vertical;

            OptionViewLayout();
            maskProperties.ValidationLayout(context, propertylayout, false);
            maskProperties.CultureLayout(context, propertylayout, false);
            maskProperties.CloseButtonVisibilityLayout(context, propertylayout, false);
            maskProperties.HideLayout(context, propertylayout, false);
            maskProperties.PromptLayout(context, propertylayout, false);

            TextView spaceLabel = new TextView(context);
            spaceLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.167), ViewGroup.LayoutParams.WrapContent);

            LinearLayout layout1 = new LinearLayout(context);
            layout1.Orientation = Android.Widget.Orientation.Horizontal;
            layout1.AddView(spaceLabel);
            layout1.AddView(ProprtyOptionsLayout);

            propertylayout.AddView(topProperty);
            propertylayout.AddView(layout1);
            propertylayout.SetBackgroundColor(Color.Rgb(240, 240, 240));
            return propertylayout;
        }
    }
}