#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Syncfusion.Android.MaskedEdit;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace SampleBrowser
{
    class SfMaskedEditProperties
    {
        InputValidationMode validateMask;
        SfMaskedEditText_Mobile textMask;
        SfMaskedEditText_Tab tabMask;
        int validatePosition = 0;
        int culturePosition = 0;
        int promptPosition = 0;

        /// <summary>
        /// Contain the close button visibility details
        /// </summary>
        ClearButtonVisibilityMode clearButtonVisibility;

        /// <summary>
        /// It contain the index for the spinner
        /// </summary>
        int visibilityPosition = 1;

        bool ishidePrompt = false;
        public SfMaskedEditProperties(SfMaskedEditText_Mobile maskedEdit)
        {
            textMask = maskedEdit;
        }
        public SfMaskedEditProperties(SfMaskedEditText_Tab maskedEdit)
        {
            tabMask = maskedEdit;
        }
        internal InputValidationMode ValidationLayout(Context context, LinearLayout propertylayout, bool isMobile)
        {
            TextView validationLabel = new TextView(context);
            validationLabel.TextSize = 20;
            validationLabel.Text = "Validation On";

            //CutCopy Spinner
            Spinner validationSpinner = new Spinner(context, SpinnerMode.Dialog);
            validationSpinner.SetGravity(GravityFlags.Left);

            //CutCopy List
            List<String> validationList = new List<String>();
            validationList.Add("Key Press");
            validationList.Add("Lost Focus");

            ArrayAdapter<String> validationAdopter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, validationList);
            validationAdopter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            validationSpinner.Adapter = validationAdopter;
            validationSpinner.SetSelection(validatePosition);

            //cutcopy Spinner ItemSelected Listener
            validationSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                String selectedItem = validationAdopter.GetItem(e.Position);
                validatePosition = e.Position;
                if (selectedItem.Equals("Key Press"))
                {
                    validateMask = InputValidationMode.KeyPress;
                }
                if (selectedItem.Equals("Lost Focus"))
                {
                    validateMask = InputValidationMode.LostFocus;
                }
                if (isMobile)
                {
                    textMask.ValidationMask = validateMask;
                }
                else
                {
                    tabMask.ValidationMask = validateMask;
                    tabMask.OnApplyChanges();
                }
            };

            if (isMobile)
            {
                propertylayout.AddView(validationLabel);

                //AdjLabel
                TextView adjLabel2 = new TextView(context);
                adjLabel2.SetHeight(14);
                adjLabel2.SetPadding(0, 0, 0, 20);
                propertylayout.AddView(adjLabel2);
                validationSpinner.SetPadding(0, 0, 0, 20);
                propertylayout.AddView(validationSpinner);
            }
            else
            {
                LinearLayout validationLayout = new LinearLayout(context);
                validationLayout.Orientation = Android.Widget.Orientation.Horizontal;
                validationLayout.AddView(validationLabel);
                LinearLayout.LayoutParams validationSpinnerLayout = new LinearLayout.LayoutParams(
                ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
                validationSpinnerLayout.SetMargins(160, 0, 70, 0);
                validationLayout.AddView(validationSpinner,validationSpinnerLayout);

                tabMask.ProprtyOptionsLayout.AddView(validationLayout);
                TextView spaceText2 = new TextView(context);
                spaceText2.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 38, GravityFlags.Center);
                tabMask.ProprtyOptionsLayout.AddView(spaceText2);
            }

            return validateMask;
        }

        internal void CultureLayout(Context context, LinearLayout propertylayout, bool isMobile)
        {
            TextView cultureLabel = new TextView(context);
            cultureLabel.TextSize = 20;
            cultureLabel.Text = "Culture";

            //culture Spinner
            Spinner cultureSpinner = new Spinner(context, SpinnerMode.Dialog);
            cultureSpinner.SetGravity(GravityFlags.Left);

            //culture List
            List<String> cultureList = new List<String>();
            cultureList.Add("United States");
            cultureList.Add("United Kingdom");
            cultureList.Add("Japan");
            cultureList.Add("France");
            cultureList.Add("Italy");
            //culture Adapter
            ArrayAdapter<string> cultureAdopter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, cultureList);
            cultureAdopter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            cultureSpinner.Adapter = cultureAdopter;
            cultureSpinner.SetSelection(culturePosition);

            CultureInfo currentCulture = new CultureInfo("en-us");
            //culture Spinner ItemSelected Listener
            cultureSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                String selectedItem = cultureAdopter.GetItem(e.Position);
                culturePosition = e.Position;
                if (selectedItem.Equals("United States"))
                {
                    currentCulture = new CultureInfo("en-us");
                }
                else if (selectedItem.Equals("United Kingdom"))
                {
                    currentCulture = new CultureInfo("en-GB");
                }
                else if (selectedItem.Equals("Japan"))
                {
                    currentCulture = new CultureInfo("ja-JP");
                }
                else if (selectedItem.Equals("France"))
                {
                    currentCulture = new CultureInfo("fr-FR");
                }
                else if (selectedItem.Equals("Italy"))
                {
                    currentCulture = new CultureInfo("it-IT");
                }

                if (isMobile)
                {
                    textMask.CurrentCulture = currentCulture;
                }
                else
                {
                    tabMask.CurrentCulture = currentCulture;
                    tabMask.OnApplyChanges();
                }
            };

            if (isMobile)
            {
                TextView spaceText = new TextView(context);
                propertylayout.AddView(spaceText);
                propertylayout.AddView(cultureLabel);

                //AdjLabel
                TextView adjLabel2 = new TextView(context);
                adjLabel2.SetHeight(14);
                adjLabel2.SetPadding(0, 0, 0, 20);
                propertylayout.AddView(adjLabel2);
                cultureSpinner.SetPadding(0, 0, 0, 0);
                propertylayout.AddView(cultureSpinner);
            }
            else
            {
                tabMask.OnApplyChanges();
                LinearLayout cultureLayout = new LinearLayout(context);
                cultureLayout.Orientation = Android.Widget.Orientation.Horizontal;
                cultureLayout.AddView(cultureLabel);
                LinearLayout.LayoutParams cultureSpinnerLayout = new LinearLayout.LayoutParams(
               ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
                cultureSpinnerLayout.SetMargins(220, 0, 65, 0);
                cultureLayout.AddView(cultureSpinner,cultureSpinnerLayout);

                tabMask.ProprtyOptionsLayout.AddView(cultureLayout);
                TextView spaceText3 = new TextView(context);
                spaceText3.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 38, GravityFlags.Center);
                tabMask.ProprtyOptionsLayout.AddView(spaceText3);
            }
        }

        /// <summary>
        /// Add the close button property in property window.
        /// </summary>
        /// <param name="context">It is context</param>
        /// <param name="propertylayout">it is a property layout</param>
        /// <param name="isMobile">It will enable when deploy in mobile</param>
        internal void CloseButtonVisibilityLayout(Context context, LinearLayout propertylayout, bool isMobile)
        {
            TextView visibilityLabel = new TextView(context);
            visibilityLabel.TextSize = 20;
            visibilityLabel.Text = "Clear Button Visibility";
            //visibility Spinner  
            Spinner visibilitySpinner = new Spinner(context, SpinnerMode.Dialog);
            visibilitySpinner.SetGravity(GravityFlags.Left);
            //visibility List  
            List<String> visibilityList = new List<String>();
            visibilityList.Add("Never");
            visibilityList.Add("While Editing");
            ArrayAdapter<String> visibilityAdopter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, visibilityList);
            visibilityAdopter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            visibilitySpinner.Adapter = visibilityAdopter;
            visibilitySpinner.SetSelection(visibilityPosition);
            //visibility Spinner ItemSelected Listener  
            visibilitySpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                String selectedItem = visibilityAdopter.GetItem(e.Position);
                visibilityPosition = e.Position;
                if (selectedItem.Equals("Never"))
                {
                    clearButtonVisibility = ClearButtonVisibilityMode.Never;
                }

                if (selectedItem.Equals("While Editing"))
                {
                    clearButtonVisibility = ClearButtonVisibilityMode.WhileEditing;
                }

                if (isMobile)
                {
                    textMask.ClearButtonVisibility = clearButtonVisibility;
                }
                else
                {
                    tabMask.ClearButtonVisibility = clearButtonVisibility;
                    tabMask.OnApplyChanges();
                }
            };
            if (isMobile)
            {
                TextView spaceText = new TextView(context);
                propertylayout.AddView(spaceText);
                propertylayout.AddView(visibilityLabel);
                //AdjLabel  
                TextView adjLabel2 = new TextView(context);
                adjLabel2.SetHeight(14);
                adjLabel2.SetPadding(0, 0, 0, 20);
                propertylayout.AddView(adjLabel2);
                visibilitySpinner.SetPadding(0, 0, 0, 20);
                propertylayout.AddView(visibilitySpinner);
            }
            else
            {
                LinearLayout visibilityLayout = new LinearLayout(context);
                visibilityLayout.Orientation = Android.Widget.Orientation.Horizontal;
                visibilityLayout.AddView(visibilityLabel);
                LinearLayout.LayoutParams visibilitySpinnerLayout = new LinearLayout.LayoutParams(
                ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
                visibilitySpinnerLayout.SetMargins(160, 0, 70, 0);
                visibilityLayout.AddView(visibilitySpinner, visibilitySpinnerLayout);
                tabMask.ProprtyOptionsLayout.AddView(visibilityLayout);
                TextView spaceText2 = new TextView(context);
                spaceText2.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 38, GravityFlags.Center);
                tabMask.ProprtyOptionsLayout.AddView(spaceText2);
            }
        }

        internal void HideLayout(Context context, LinearLayout propertylayout, bool isMobile)
        {

            TextView hidePromtText = new TextView(context);
            hidePromtText.Text = "Hide Prompt On Leave";
            hidePromtText.Gravity = GravityFlags.Center;
            hidePromtText.TextSize = 20;


            Switch hidePromptSwitch = new Switch(context);
            hidePromptSwitch.Checked = ishidePrompt;
            hidePromptSwitch.CheckedChange += (object send, CompoundButton.CheckedChangeEventArgs eve) =>
            {
                ishidePrompt = eve.IsChecked;
                if (isMobile)
                {
                    textMask.HidePrompt = eve.IsChecked;
                }
                else
                {
                    tabMask.HidePrompt = eve.IsChecked;
                    tabMask.OnApplyChanges();
                }
            };

            LinearLayout.LayoutParams hidePromptSwitchParams = new LinearLayout.LayoutParams(
               ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            if(SfMaskedEditText.IsTabletDevice(context))
            hidePromptSwitchParams.SetMargins(0, 0,110, 0);
            else
                hidePromptSwitchParams.SetMargins(0, 10, 0, 0);

            LinearLayout hidePromptLayout = new LinearLayout(context);
            hidePromptLayout.AddView(hidePromtText);
            hidePromptLayout.AddView(hidePromptSwitch, hidePromptSwitchParams);
            hidePromptLayout.Orientation = Orientation.Horizontal;

            if (isMobile)
            {
                TextView textSpacing = new TextView(context);
                propertylayout.AddView(textSpacing);
                propertylayout.AddView(hidePromptLayout);

                TextView textSpacing1 = new TextView(context);
                propertylayout.AddView(textSpacing1);
                propertylayout.SetPadding(5, 0, 5, 0);
            }
            else
            {
                tabMask.OnApplyChanges();
                tabMask.ProprtyOptionsLayout.AddView(hidePromptLayout);
                TextView spaceText4 = new TextView(context);
                spaceText4.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 38, GravityFlags.Center);
                tabMask.ProprtyOptionsLayout.AddView(spaceText4);
            }
        }
        internal void PromptLayout(Context context, LinearLayout propertylayout, bool isMobile)
        {

            TextView promptLabel = new TextView(context);
            promptLabel.TextSize = 20;
            promptLabel.Text = "Prompt Character";

            //prompt Spinner
            Spinner promptSpinner = new Spinner(context, SpinnerMode.Dialog);
            promptSpinner.SetGravity(GravityFlags.Left);

            //prompt List
            List<char> promptList = new List<char>();
            promptList.Add('_');
            promptList.Add('*');
            promptList.Add('~');
            //prompt Adapter
            ArrayAdapter<char> promptAdopter = new ArrayAdapter<char>(context, Android.Resource.Layout.SimpleSpinnerItem, promptList);
            promptAdopter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            promptSpinner.Adapter = promptAdopter;
            promptSpinner.SetSelection(promptPosition);

            //prompt Spinner ItemSelected Listener
            promptSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                promptPosition = e.Position;
                char prompt = promptAdopter.GetItem(e.Position);
                if (isMobile)
                    textMask.CurrentPrompt = prompt;
                else
                {
                    tabMask.CurrentPrompt = prompt;
                    tabMask.OnApplyChanges();
                }
            };

            LinearLayout.LayoutParams promptspinnerLayout = new LinearLayout.LayoutParams(
               ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            if (SfMaskedEditText.IsTabletDevice(context))
                promptspinnerLayout.SetMargins(120, 0,90, 0);
            else
                promptspinnerLayout.SetMargins(200, 0, 0, 0);


            LinearLayout promptLayout = new LinearLayout(context);
            promptLayout.AddView(promptLabel);
            promptLayout.AddView(promptSpinner, promptspinnerLayout);
            promptLayout.Orientation = Orientation.Horizontal;
            if (isMobile)
                propertylayout.AddView(promptLayout);
            else
            {
                tabMask.OnApplyChanges();
                tabMask.ProprtyOptionsLayout.AddView(promptLayout);
            }

        }
    }
}