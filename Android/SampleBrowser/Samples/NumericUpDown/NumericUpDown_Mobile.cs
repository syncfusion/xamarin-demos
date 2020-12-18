#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
using Com.Syncfusion.Numericupdown;


#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Numerictextbox;
using Android.Graphics;
using Android.Views.InputMethods;
using Android.Text;
using Android.Text.Style;

namespace SampleBrowser
{
    public class NumericUpDown_Mobile
    {
        /*********************************
         **Local Variable Inizialisation**
         *********************************/
        LinearLayout propertylayout, autoReverseLayout, minimumValueLayout, maximumValueLayout, fontSizeLayOut, selectAllOnFocusLayout;
        ArrayAdapter<String> spinButtonDataAdapter;
        Spinner spinButtonSpinner;
        bool autoReverse = false, selectAllOnFocus = false;
        EditText minimumText, maximumText, fontSizeText;
        SpinButtonAlignment spinButtonAlignment = SpinButtonAlignment.Right;
        double minimumValue = 0, maximumValue = 100, fontSizeValue = 18;
        Boolean maxNegative, minNegative, fontsizeNegative;
        SfNumericUpDown adultNumericUpDown, infantsNumericUpDown;
        TextView adultText, infantsText;
        Context context;
        int width;
		GravityFlags gravity=GravityFlags.CenterVertical;
        public View GetSampleContent(Context con)
        {
            
            int width = con.Resources.DisplayMetrics.WidthPixels - 40;
            float density = con.Resources.DisplayMetrics.Density;                                
            int numerHeight = (int)(density * 55);
			if (density >= 3)
			{
				numerHeight = (int)(density * 65);
			}

            SamplePageContent(con);
           
            //AdultNumericUpDown
            adultNumericUpDown = new SfNumericUpDown(con);
            adultNumericUpDown.FontSize = 18;
            adultNumericUpDown.TextGravity = GravityFlags.CenterVertical;
            adultNumericUpDown.LayoutParameters = new ViewGroup.LayoutParams(width, numerHeight);
            adultNumericUpDown.Minimum = 0;
            adultNumericUpDown.Maximum = 100;
            adultNumericUpDown.Value = 5;
            adultNumericUpDown.FormatString = "N";
            adultNumericUpDown.AutoReverse = false;
            adultNumericUpDown.MaximumDecimalDigits = 0;
            adultNumericUpDown.StepValue = 1;
                  
            //InfantsNumericUpDown
            infantsNumericUpDown = new SfNumericUpDown(con);
            infantsNumericUpDown.FontSize = 18;
			infantsNumericUpDown.TextGravity = GravityFlags.CenterVertical;
			infantsNumericUpDown.LayoutParameters = new ViewGroup.LayoutParams(width, numerHeight);
            infantsNumericUpDown.Minimum = 0;
            infantsNumericUpDown.Maximum = 100;
            infantsNumericUpDown.Value = 2;
            infantsNumericUpDown.FormatString = "N";
            infantsNumericUpDown.AutoReverse = false;
            infantsNumericUpDown.MaximumDecimalDigits = 0;
            infantsNumericUpDown.StepValue = 1;

            //MainFrameLayout
            FrameLayout mainFrameLayout = new FrameLayout(con);
            mainFrameLayout.SetPadding(10, 10, 10, 10);
            FrameLayout.LayoutParams layoutParams = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent, GravityFlags.FillVertical);
            mainFrameLayout.LayoutParameters = layoutParams;
            mainFrameLayout.AddView(GetView(con));
            ScrollView mainScrollView = new ScrollView(con);
            mainScrollView.AddView(mainFrameLayout);

            return mainScrollView;
        }

        private LinearLayout GetView(Context con)
        {
            //mainLayout
            LinearLayout mainLayout = new LinearLayout(con);
            mainLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
            mainLayout.SetGravity(GravityFlags.FillVertical);
            mainLayout.Orientation = Orientation.Vertical;      
            mainLayout.AddView(adultText);
            mainLayout.AddView(adultNumericUpDown);
            mainLayout.AddView(infantsText);
            mainLayout.AddView(infantsNumericUpDown);

            //MainLayout Touch Event
            mainLayout.Touch += (object sender, View.TouchEventArgs e) => {
                if (adultNumericUpDown.IsFocused || infantsNumericUpDown.IsFocused)
                {
                    Rect outRect = new Rect();
                    adultNumericUpDown.GetGlobalVisibleRect(outRect);
                    infantsNumericUpDown.GetGlobalVisibleRect(outRect);
                    if (!outRect.Contains((int)e.Event.RawX, (int)e.Event.RawY))
                    {
                        adultNumericUpDown.ClearFocus();
                        infantsNumericUpDown.ClearFocus();

                    }
                    hideSoftKeyboard((Activity)con);
                }
            };

            return mainLayout;
        }

        
        private void SamplePageContent(Context con)
        {
            //AdultText
            adultText = new TextView(con);
            adultText.Text = "Number of adults";
            adultText.TextSize = 18;

            //InfantsText
            infantsText = new TextView(con);
            infantsText.SetPadding(0, 15, 0, 0);
            infantsText.Text = "Number of infants";
            infantsText.TextSize = 18;
        }
    
        //Apply Changes Method
        public void OnApplyChanges()
        {
            //adultNumericUpDown
            adultNumericUpDown.Minimum = minimumValue;
            adultNumericUpDown.Maximum = maximumValue;
            adultNumericUpDown.FontSize = fontSizeValue;
            adultNumericUpDown.AutoReverse = autoReverse;
            adultNumericUpDown.SelectAllOnFocus = selectAllOnFocus;
            adultNumericUpDown.SpinButtonAlignment = spinButtonAlignment;
			adultNumericUpDown.TextGravity = gravity;
           
            //infantsNumericUpDown
            infantsNumericUpDown.Minimum = minimumValue;
            infantsNumericUpDown.Maximum = maximumValue;
            infantsNumericUpDown.FontSize = fontSizeValue;
            infantsNumericUpDown.AutoReverse = autoReverse;
            infantsNumericUpDown.SelectAllOnFocus = selectAllOnFocus;
            infantsNumericUpDown.SpinButtonAlignment = spinButtonAlignment;
			infantsNumericUpDown.TextGravity = gravity;

            maxNegative = minNegative = fontsizeNegative = false;
        }
      
        public View GetPropertyWindowLayout(Context context1)
        {
            context = context1;
            width = (context.Resources.DisplayMetrics.WidthPixels) / 2;
            propertylayout = new LinearLayout(context);
            propertylayout.Orientation = Orientation.Vertical;
           
            MinimumLayout();
            MaximumLayout();
            FontSizeLayout();
            SpinButtonLayout();
            AutoReverseLayout();
            SelectAllOnFocusLayout();

            return propertylayout;
        }

        private void FontSizeLayout()
        {
            /***********
            **FontSize**
            ***********/
            double newNumber;
            TextView fontSizeLabel = new TextView(context);
            fontSizeLabel.Text = "FontSize";
            fontSizeLabel.SetWidth(400);
            fontSizeLabel.TextSize = 20;

            //FontSize Text
            fontSizeText = new EditText(context);
            fontSizeText.Text = "18";
            fontSizeText.TextSize = 16;
            fontSizeText.InputType = Android.Text.InputTypes.ClassPhone;

            // FontSizeText Changed Listener
            fontSizeText.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                if (fontSizeText.Text.Length > 0)
                {
                    String str = e.Text.ToString();
                    if (str.StartsWith("-") || str.EndsWith("-"))
                    {
                        str = str.Replace("-", "");
                        fontsizeNegative = true;
                    }
                    if (!str.Equals(""))
                    {
                        newNumber = Convert.ToDouble(str);
                        if (fontsizeNegative)
                        {
                            newNumber = newNumber * -1;
                        }
                        fontSizeValue = newNumber;
                    }
                }
            };
            LinearLayout.LayoutParams fontsizeTextLayoutParams = new LinearLayout.LayoutParams(
                ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            fontsizeTextLayoutParams.SetMargins(0, 10, 0, 0);
            LinearLayout.LayoutParams fontsizeLabelLayoutParams = new LinearLayout.LayoutParams(
                ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
            fontsizeLabelLayoutParams.SetMargins(0, 10, 0, 0);
            TextView textSpacing = new TextView(context);
            propertylayout.AddView(textSpacing);

            //FontSizeValueLayout
            fontSizeLayOut = new LinearLayout(context);
            fontSizeLayOut.AddView(fontSizeLabel, fontsizeLabelLayoutParams);
            fontSizeLayOut.AddView(fontSizeText, fontsizeTextLayoutParams);
            fontSizeLayOut.Orientation = Orientation.Horizontal;
            propertylayout.AddView(fontSizeLayOut);

            //FontSizeSeparate
            SeparatorView fontsizeSeparate = new SeparatorView(context, width * 2);
            fontsizeSeparate.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
            LinearLayout.LayoutParams fontsizeSeparateLayoutParams = new LinearLayout.LayoutParams(width * 2, 5);
            fontsizeSeparateLayoutParams.SetMargins(0, 20, 15, 0);
            //propertylayout.AddView(fontsizeSeparate, fontsizeSeparateLayoutParams);
        }

        private void MinimumLayout()
        {
            /***********
           **Minimum**
           ***********/
            double newNumber;
            TextView minimumLabel = new TextView(context);
            minimumLabel.Text = "Minimum";
            minimumLabel.SetWidth(400);
            minimumLabel.TextSize = 20;

            //Minimum Text
            minimumText = new EditText(context);
            minimumText.Text = "0";
            minimumText.TextSize = 16;
            minimumText.InputType = Android.Text.InputTypes.ClassPhone;

            //Minimum Text Changed Listener
            minimumText.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                if (minimumText.Text.Length > 0)
                {
                    String str = e.Text.ToString();
                    if (str.StartsWith("-") || str.EndsWith("-"))
                    {
                        str = str.Replace("-", "");
                        minNegative = true;
                    }
                    if (!str.Equals(""))
                    {
                        newNumber = Convert.ToDouble(str);
                        if (minNegative)
                        {
                            newNumber = newNumber * -1;
                        }
                        minimumValue = newNumber;
                    }
                }
            };
            LinearLayout.LayoutParams minimumTextLayoutParams = new LinearLayout.LayoutParams(
                ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            minimumTextLayoutParams.SetMargins(0, 10, 0, 0);
            LinearLayout.LayoutParams minimumLabelLayoutParams = new LinearLayout.LayoutParams(
                ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
            minimumLabelLayoutParams.SetMargins(0, 10, 0, 0);

            //MinimumValueLayout
            minimumValueLayout = new LinearLayout(context);
            minimumValueLayout.AddView(minimumLabel, minimumLabelLayoutParams);
            minimumValueLayout.AddView(minimumText, minimumTextLayoutParams);
            minimumValueLayout.Orientation = Orientation.Horizontal;
            propertylayout.AddView(minimumValueLayout);

            //MinimumSeparate
            SeparatorView minimumSeparate = new SeparatorView(context, width * 2);
            minimumSeparate.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
            LinearLayout.LayoutParams minimumLayoutParams = new LinearLayout.LayoutParams(width * 2, 5);
            minimumLayoutParams.SetMargins(0, 20, 15, 0);
           // propertylayout.AddView(minimumSeparate, minimumLayoutParams);
        }

        private void MaximumLayout()
        {
            /***********
            **Maximum**
            ***********/
            double newNumber;
            TextView maximumLabel = new TextView(context);
            maximumLabel.Text = "Maximum";
            maximumLabel.SetWidth(400);
            maximumLabel.TextSize = 20;

            //MaximumText
            maximumText = new EditText(context);
            maximumText.Text = "100";
            maximumText.TextSize = 16;
            maximumText.InputType = Android.Text.InputTypes.ClassPhone;

            //MaximumText TextChanged Listener
            maximumText.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                if (maximumText.Text.Length > 0)
                {
                    String str = e.Text.ToString();
                    if (str.StartsWith("-") || str.EndsWith("-"))
                    {
                        str = str.Replace("-", "");
                        maxNegative = true;
                    }
                    if (!str.Equals(""))
                    {
                        newNumber = Convert.ToDouble(str);
                        if (maxNegative)
                        {
                            newNumber = newNumber * -1;
                        }
                        maximumValue = newNumber;
                    }
                }
            };
            LinearLayout.LayoutParams maximumTextLayoutParams = new LinearLayout.LayoutParams(
                ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            maximumTextLayoutParams.SetMargins(0, 10, 0, 0);
            LinearLayout.LayoutParams maximumLabelLayoutParams = new LinearLayout.LayoutParams(
                ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
            maximumLabelLayoutParams.SetMargins(0, 10, 0, 0);

			TextView textSpacing = new TextView(context);
			propertylayout.AddView(textSpacing);
            //MaximumValueLayout
            maximumValueLayout = new LinearLayout(context);
            maximumValueLayout.AddView(maximumLabel, maximumLabelLayoutParams);
            maximumValueLayout.AddView(maximumText, maximumTextLayoutParams);
            maximumValueLayout.Orientation = Orientation.Horizontal;
            propertylayout.AddView(maximumValueLayout);

            //MaximumSeparate
            SeparatorView maximumSeparate = new SeparatorView(context, width * 2);
            maximumSeparate.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
            LinearLayout.LayoutParams maximumLayoutParams = new LinearLayout.LayoutParams(width * 2, 5);
            maximumLayoutParams.SetMargins(0, 20, 15, 0);
           // propertylayout.AddView(maximumSeparate, maximumLayoutParams);
        }

        private void SpinButtonLayout()
        {
            /***********************
           **SpinButtonAlignment**
           ***********************/
            LinearLayout.LayoutParams spinButtonLayoutParams = new LinearLayout.LayoutParams(width * 2, 5);
            spinButtonLayoutParams.SetMargins(0, 20, 0, 0);

            //SpinButtonText
            TextView spinButtonText = new TextView(context);
            spinButtonText.TextSize = 20;
            spinButtonText.Text = "SpinButtonAlignment";

            //SpinButtonList
            List<String> spinButtonList = new List<String>();
            spinButtonList.Add("Right");
            spinButtonList.Add("Left");
            spinButtonList.Add("Both");
            spinButtonDataAdapter = new ArrayAdapter<String>
                (context, Android.Resource.Layout.SimpleSpinnerItem, spinButtonList);
            spinButtonDataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            //SpinButtonSpinner
            spinButtonSpinner = new Spinner(context,SpinnerMode.Dialog);
            spinButtonSpinner.Adapter = spinButtonDataAdapter;

			TextView textSpacing = new TextView(context);
			propertylayout.AddView(textSpacing);
            //SpinButtonSpinner ItemSelected Listener
            spinButtonSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
                String selectedItem = spinButtonDataAdapter.GetItem(e.Position);
                if (selectedItem.Equals("Right"))
                {
                    spinButtonAlignment = SpinButtonAlignment.Right;
					gravity = GravityFlags.CenterVertical;
                }
                if (selectedItem.Equals("Left"))
                {
                    spinButtonAlignment = SpinButtonAlignment.Left;
					gravity=GravityFlags.End | GravityFlags.CenterVertical;
                }
                if (selectedItem.Equals("Both"))
                {
                    spinButtonAlignment = SpinButtonAlignment.Both;
					gravity = GravityFlags.Center;
                }
            };
            propertylayout.AddView(spinButtonText);
            propertylayout.AddView(spinButtonSpinner);

            //SpinButtonSeparate
            SeparatorView spinButtonSeparate = new SeparatorView(context, width * 2);
            spinButtonSeparate.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
           // propertylayout.AddView(spinButtonSeparate, spinButtonLayoutParams);
        }

        private void AutoReverseLayout()
        {
            /***************
           **AutoReverse**
           ***************/
            TextView autoReverseText = new TextView(context);
            autoReverseText.Text = "AutoReverse";
            autoReverseText.Gravity = GravityFlags.Center;
            autoReverseText.TextSize = 20;

            //AutoReverseCheckBox
            Switch autoReverseCheckBox = new Switch(context);
            autoReverseCheckBox.Checked = false;
            autoReverseCheckBox.CheckedChange += (object send, CompoundButton.CheckedChangeEventArgs eve) => {
                if (!eve.IsChecked)
                    autoReverse = false;
                else
                    autoReverse = true;
            };
            LinearLayout.LayoutParams autoReverseCheckBoxLayoutParams = new LinearLayout.LayoutParams(
                ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            autoReverseCheckBoxLayoutParams.SetMargins(0, 10, 0, 0);
            LinearLayout.LayoutParams autoReverseTextLayoutParams = new LinearLayout.LayoutParams(
                ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
            autoReverseTextLayoutParams.SetMargins(0, 10, 0, 0);

			TextView textSpacing = new TextView(context);
			propertylayout.AddView(textSpacing);
            //AutoReverseLayout
            autoReverseLayout = new LinearLayout(context);
            autoReverseLayout.AddView(autoReverseText, autoReverseTextLayoutParams);
            autoReverseLayout.AddView(autoReverseCheckBox, autoReverseCheckBoxLayoutParams);
            autoReverseLayout.Orientation = Orientation.Horizontal;
            propertylayout.AddView(autoReverseLayout);

            //AutoReverseSeparate
            SeparatorView autoReverseSeparate = new SeparatorView(context, width * 2);
            autoReverseSeparate.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
            LinearLayout.LayoutParams autoReverseLayoutParams = new LinearLayout.LayoutParams(width * 2, 5);
            autoReverseLayoutParams.SetMargins(0, 20, 15, 0);
           // propertylayout.AddView(autoReverseSeparate, autoReverseLayoutParams);
            propertylayout.SetPadding(20, 20, 20, 20);
        }

        private void SelectAllOnFocusLayout()
        {
            /***************
            **SelectAllOnFocus**
            ***************/
            TextView selectAllOnFocusText = new TextView(context);
            selectAllOnFocusText.Text = "SelectAllOnFocus";
            selectAllOnFocusText.Gravity = GravityFlags.Center;
            selectAllOnFocusText.TextSize = 20;

            //SelectAllOnFocusCheckBox
            Switch selectAllOnFocusCheckBox = new Switch(context);
            selectAllOnFocusCheckBox.Checked = false;
            selectAllOnFocusCheckBox.CheckedChange += (object send, CompoundButton.CheckedChangeEventArgs eve) => {
                if (!eve.IsChecked)
                    selectAllOnFocus = false;
                else
                    selectAllOnFocus = true;
            };
            LinearLayout.LayoutParams selectAllOnFocusCheckBoxLayoutParams = new LinearLayout.LayoutParams(
               ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            selectAllOnFocusCheckBoxLayoutParams.SetMargins(0, 10, 0, 0);
            LinearLayout.LayoutParams selectAllOnFocusTextLayoutParams = new LinearLayout.LayoutParams(
                ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
            selectAllOnFocusTextLayoutParams.SetMargins(0, 10, 0, 0);

            TextView textSpacing = new TextView(context);
            propertylayout.AddView(textSpacing);
            //SelectAllOnFocusLayout
            selectAllOnFocusLayout = new LinearLayout(context);
            selectAllOnFocusLayout.AddView(selectAllOnFocusText, selectAllOnFocusTextLayoutParams);
            selectAllOnFocusLayout.AddView(selectAllOnFocusCheckBox, selectAllOnFocusCheckBoxLayoutParams);
            selectAllOnFocusLayout.Orientation = Orientation.Horizontal;
            propertylayout.AddView(selectAllOnFocusLayout);
            propertylayout.SetPadding(20, 20, 20, 20);
        }

        public static void hideSoftKeyboard(Activity activity)
        {
            InputMethodManager inputMethodManager = (InputMethodManager)activity.GetSystemService(Activity.InputMethodService);
            inputMethodManager.HideSoftInputFromWindow(activity.CurrentFocus.WindowToken, 0);
        }

        private int getDimensionPixelSize(Context con, int id)
        {
            return con.Resources.GetDimensionPixelSize(id);
        }
    }
}
