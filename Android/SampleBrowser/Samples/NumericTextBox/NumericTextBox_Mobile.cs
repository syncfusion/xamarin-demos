#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
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
    public class NumericTextBox_Mobile
    {
       /*********************************
        **Local Variable Inizialisation**
        *********************************/
        TextView simpleInterestCalculatorLabel, sILabelSpacing, findingSILabel, formulaLabel;
        TextView formulaLabelSpacing, principalLabel, principalStackSpacing, interestLabel;
        TextView InterestcalStackSpacing, period, outputLabel, outputStackSpacing;
        SfNumericTextBox principalAmountNumericTextBox, outputNumberTextBox;
        SfNumericTextBox interestNumericTextBox, periodValueNumericTextBox;
        LinearLayout propertylayout, allowNullLayout;
        ArrayAdapter<String> cultureDataAdapter;     
        Java.Util.Locale localinfo;
        Spinner cultureSpinner;
        int numerHeight, width;
        bool allownull = true;

        public View GetSampleContent(Context con)
        {
            

            SamplePageContent(con);
            FrameLayout mainFrameLayout = new FrameLayout(con);
            FrameLayout.LayoutParams layoutParams = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent, GravityFlags.FillVertical);
            mainFrameLayout.LayoutParameters = layoutParams;

            //PrincipalAmountNumericTextBox
            principalAmountNumericTextBox = new SfNumericTextBox(con);
            principalAmountNumericTextBox.FormatString = "C";
            principalAmountNumericTextBox.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight);
            principalAmountNumericTextBox.Value = 1000;
            principalAmountNumericTextBox.AllowNull = true;
            principalAmountNumericTextBox.Watermark = "Principal Amount";
            principalAmountNumericTextBox.MaximumNumberDecimalDigits = 2;
            var culture = new Java.Util.Locale("en", "US");
            principalAmountNumericTextBox.CultureInfo = culture;
            principalAmountNumericTextBox.ValueChangeMode = ValueChangeMode.OnKeyFocus;
                               
            //InterestNumericTextBox           
            interestNumericTextBox = new SfNumericTextBox(con);
            interestNumericTextBox.FormatString = "P";
            interestNumericTextBox.Value = 0.1;
            interestNumericTextBox.PercentDisplayMode = PercentDisplayMode.Compute;
            interestNumericTextBox.MaximumNumberDecimalDigits = 2;
            interestNumericTextBox.ValueChangeMode = ValueChangeMode.OnKeyFocus;
            interestNumericTextBox.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight);          
            interestNumericTextBox.Watermark = "Rate of Interest";
            interestNumericTextBox.AllowNull = true;
            interestNumericTextBox.CultureInfo = culture;

            //PeriodValueNumericTextBox                      
            periodValueNumericTextBox = new SfNumericTextBox(con);
            periodValueNumericTextBox.FormatString = " years";
            periodValueNumericTextBox.Value = 20;
            periodValueNumericTextBox.MaximumNumberDecimalDigits = 0;
            periodValueNumericTextBox.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight);           
            periodValueNumericTextBox.Watermark = "Period (in years)";
            periodValueNumericTextBox.ValueChangeMode = ValueChangeMode.OnKeyFocus;
            periodValueNumericTextBox.CultureInfo = culture;
            periodValueNumericTextBox.AllowNull = true;
          
            //OutputNumberTextBox
            outputNumberTextBox = new SfNumericTextBox(con);
            outputNumberTextBox.FormatString = "c";
            outputNumberTextBox.MaximumNumberDecimalDigits = 0;
            outputNumberTextBox.AllowNull = true;
            outputNumberTextBox.CultureInfo = culture;
            outputNumberTextBox.Watermark = "Enter Values";
            outputNumberTextBox.Clickable = false;
            outputNumberTextBox.Value = (float)(1000 * 0.1 * 20);
            outputNumberTextBox.Enabled = false;
            outputNumberTextBox.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight);
            outputNumberTextBox.ValueChangeMode = ValueChangeMode.OnLostFocus;
          
            //Numerictextbox Value Changed Listener
            principalAmountNumericTextBox.ValueChanged += (object sender, ValueChangedEventArgs e) => {
				if (e.Value != null && periodValueNumericTextBox.Value != null && interestNumericTextBox.Value != null)
					outputNumberTextBox.Value = Double.Parse(e.Value.ToString()) * Double.Parse(periodValueNumericTextBox.Value.ToString()) * Double.Parse(interestNumericTextBox.Value.ToString());

            };
            periodValueNumericTextBox.ValueChanged += (object sender, ValueChangedEventArgs e) => {
				if (e.Value != null && principalAmountNumericTextBox.Value != null && interestNumericTextBox.Value != null)
					outputNumberTextBox.Value = Double.Parse(e.Value.ToString()) * Double.Parse(principalAmountNumericTextBox.Value.ToString()) * Double.Parse(interestNumericTextBox.Value.ToString());

            };
            interestNumericTextBox.ValueChanged += (object sender, ValueChangedEventArgs e) => {
				if (e.Value != null && principalAmountNumericTextBox.Value != null && periodValueNumericTextBox.Value != null)
					outputNumberTextBox.Value = Double.Parse(e.Value.ToString()) * Double.Parse(principalAmountNumericTextBox.Value.ToString()) * Double.Parse(periodValueNumericTextBox.Value.ToString());

            };
           
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
            mainLayout.AddView(simpleInterestCalculatorLabel);
            mainLayout.AddView(sILabelSpacing);
            mainLayout.AddView(findingSILabel);
            mainLayout.FocusableInTouchMode = true;
            mainLayout.AddView(formulaLabel);
            mainLayout.AddView(formulaLabelSpacing);

            LinearLayout principalStack = new LinearLayout(con);
            principalStack.Orientation = Orientation.Horizontal;
            principalStack.AddView(principalLabel);
            principalStack.AddView(principalAmountNumericTextBox);
            mainLayout.AddView(principalStack);
            mainLayout.AddView(principalStackSpacing);

            LinearLayout InterestcalStack = new LinearLayout(con);
            InterestcalStack.Orientation = Orientation.Horizontal;
            InterestcalStack.AddView(interestLabel);
            InterestcalStack.AddView(interestNumericTextBox);
            mainLayout.AddView(InterestcalStack);
            mainLayout.AddView(InterestcalStackSpacing);

            LinearLayout periodStack = new LinearLayout(con);
            periodStack.Orientation = Orientation.Horizontal;
            periodStack.AddView(period);
            periodStack.AddView(periodValueNumericTextBox);
            mainLayout.AddView(periodStack);

            LinearLayout outputStack = new LinearLayout(con);
            outputStack.Orientation = Orientation.Horizontal;
            outputStack.AddView(outputLabel);
            if (con.Resources.DisplayMetrics.Density > 1.5)
            {
                outputStack.SetY(60);
            }
            outputStack.AddView(outputNumberTextBox);
            mainLayout.AddView(outputStack);

            mainLayout.SetPadding(20, 20, 10, 20);
            mainLayout.AddView(outputStackSpacing);
            mainLayout.Touch += (object sender, View.TouchEventArgs e) => {
                if (outputNumberTextBox.IsFocused || interestNumericTextBox.IsFocused || periodValueNumericTextBox.IsFocused || principalAmountNumericTextBox.IsFocused)
                {
                    Rect outRect = new Rect();
                    outputNumberTextBox.GetGlobalVisibleRect(outRect);
                    interestNumericTextBox.GetGlobalVisibleRect(outRect);
                    periodValueNumericTextBox.GetGlobalVisibleRect(outRect);
                    principalAmountNumericTextBox.GetGlobalVisibleRect(outRect);

                    if (!outRect.Contains((int)e.Event.RawX, (int)e.Event.RawY))
                    {
                        outputNumberTextBox.ClearFocus();
                        interestNumericTextBox.ClearFocus();
                        periodValueNumericTextBox.ClearFocus();
                        principalAmountNumericTextBox.ClearFocus();
                    }
                    hideSoftKeyboard((Activity)con);
                }
            };

            return mainLayout;
        }

        
        private void SamplePageContent(Context con)
        {
            numerHeight = getDimensionPixelSize(con, Resource.Dimension.numeric_txt_ht);
            width = con.Resources.DisplayMetrics.WidthPixels - 40;
           
            //SimpleInterestCalculatorLabel
            simpleInterestCalculatorLabel = new TextView(con);
            simpleInterestCalculatorLabel.Text = "Simple Interest Calculator";
            simpleInterestCalculatorLabel.Gravity = GravityFlags.Center;
            simpleInterestCalculatorLabel.TextSize = 24;
           
            //FindingSILabel
            findingSILabel = new TextView(con);
            findingSILabel.Text = "The formula for finding simple interest is:";
            findingSILabel.TextSize = 18;

            SpannableStringBuilder formulaBuilder = new SpannableStringBuilder();
            //FormulaLabel
            formulaLabel = new TextView(con);
            String interest = "Interest";
            SpannableString interestSpannable = new SpannableString(interest);
            interestSpannable.SetSpan(new ForegroundColorSpan(Color.ParseColor("#66BB6A")), 0, interest.Length, 0);
            formulaBuilder.Append(interestSpannable);
            formulaBuilder.Append(" = Principal * Rate * Time");
            formulaLabel.SetText(formulaBuilder, TextView.BufferType.Spannable);
            formulaLabel.TextSize = 18;

            //PrincipalLabel
            principalLabel = new TextView(con);
            principalLabel.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight);
            principalLabel.Text = "Principal";
			principalLabel.TextSize = 20;

            //InterestLabel
            interestLabel = new TextView(con);
            interestLabel.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight);
            interestLabel.Text = "Interest Rate";
			interestLabel.TextSize = 20;
           
            //periodLabel
            period = new TextView(con);
            period.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight);
            period.Text = "Term";
			period.TextSize = 20;

            //outputLabel
            outputLabel = new TextView(con);
            outputLabel.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight);
            outputLabel.Text = "Interest";
			outputLabel.TextSize = 20;
            outputLabel.SetTextColor(Color.ParseColor("#66BB6A"));

            //SpacingLabel
            sILabelSpacing = new TextView(con);
            formulaLabelSpacing = new TextView(con);
            principalStackSpacing = new TextView(con);
            InterestcalStackSpacing = new TextView(con);
            outputStackSpacing = new TextView(con);
        }
        /************************
         **Apply Changes Method**
         ************************/
        public void OnApplyChanges()
        {
            principalAmountNumericTextBox.CultureInfo = localinfo;
            outputNumberTextBox.CultureInfo = localinfo;
            principalAmountNumericTextBox.AllowNull = allownull;
            periodValueNumericTextBox.AllowNull = allownull;
            interestNumericTextBox.AllowNull = allownull;
        }

        public View GetPropertyWindowLayout(Context context)
        {          
            width = (context.Resources.DisplayMetrics.WidthPixels) / 2;
            propertylayout = new LinearLayout(context);
            propertylayout.Orientation = Orientation.Vertical;

            /***********
             **Culture**
             ***********/
            LinearLayout.LayoutParams cultureLayoutParams = new LinearLayout.LayoutParams(width * 2, 5);
            cultureLayoutParams.SetMargins(0, 20, 0, 0);

            //Culture Text
            TextView culturetxt = new TextView(context);
            culturetxt.TextSize = 20;
            culturetxt.Text = "Culture";
         
            //CultureList
            List<String> cultureList = new List<String>();
            cultureList.Add("United States");
            cultureList.Add("United Kingdom");
            cultureList.Add("Japan");
            cultureList.Add("France");
            cultureList.Add("Italy");
            cultureDataAdapter = new ArrayAdapter<String>
                (context, Android.Resource.Layout.SimpleSpinnerItem, cultureList);
            cultureDataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            //CultureSpinner
			cultureSpinner = new Spinner(context,SpinnerMode.Dialog);
            cultureSpinner.Adapter = cultureDataAdapter;

            //CultureSpinner ItemSelected Listener
            cultureSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
                String selectedItem = cultureDataAdapter.GetItem(e.Position);
                if (selectedItem.Equals("United States"))
                {
                    localinfo = Java.Util.Locale.Us;
                }
                if (selectedItem.Equals("United Kingdom"))
                {
                    localinfo = Java.Util.Locale.Uk;
                }
                if (selectedItem.Equals("Japan"))
                {
                    localinfo = Java.Util.Locale.Japan;
                }
                if (selectedItem.Equals("France"))
                {
                    localinfo = Java.Util.Locale.France;
                }
                if (selectedItem.Equals("Italy"))
                {
                    localinfo = Java.Util.Locale.Italy;
                }
            };
            propertylayout.AddView(culturetxt);
            propertylayout.AddView(cultureSpinner);

            //CultureSeparate
            SeparatorView cultureSeparate = new SeparatorView(context, width * 2);
            cultureSeparate.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
           // propertylayout.AddView(cultureSeparate, cultureLayoutParams);

           /*************
            **AllowNull**
            *************/
            TextView allowNullText = new TextView(context);
            allowNullText.Text = "Allow Null";
            allowNullText.Gravity = GravityFlags.Center;
            allowNullText.TextSize = 20;

            //AllowNullCheckBox
            Switch allowNullCheckBox = new Switch(context);
            allowNullCheckBox.Checked = true;
            allowNullCheckBox.CheckedChange += (object send, CompoundButton.CheckedChangeEventArgs eve) => {
                if (!eve.IsChecked)
                    allownull = false;
                else
                    allownull = true;
            };
            LinearLayout.LayoutParams allowNullCheckBoxLayoutParams = new LinearLayout.LayoutParams(
                ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            allowNullCheckBoxLayoutParams.SetMargins(0, 10, 0, 0);
            LinearLayout.LayoutParams allowNullTextLayoutParams = new LinearLayout.LayoutParams(
                ViewGroup.LayoutParams.WrapContent, 70);
            allowNullTextLayoutParams.SetMargins(0, 10, 0, 0);

			TextView textSpacing = new TextView(context);
			propertylayout.AddView(textSpacing);

            //AllowNullLayout
            allowNullLayout = new LinearLayout(context);
            allowNullLayout.AddView(allowNullText);
            allowNullLayout.AddView(allowNullCheckBox, allowNullCheckBoxLayoutParams);
            allowNullLayout.Orientation = Orientation.Horizontal;
            propertylayout.AddView(allowNullLayout);

			TextView textSpacing1 = new TextView(context);
			propertylayout.AddView(textSpacing1);
            //AllowNullSeparate
            SeparatorView allowNullSeparate = new SeparatorView(context, width * 2);
            allowNullSeparate.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
            LinearLayout.LayoutParams allowNullLayoutParams = new LinearLayout.LayoutParams(width * 2, 5);
            allowNullLayoutParams.SetMargins(0, 20, 15, 0);
        //    propertylayout.AddView(allowNullSeparate, allowNullLayoutParams);
            propertylayout.SetPadding(5, 0, 5, 0);

            return propertylayout;
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

