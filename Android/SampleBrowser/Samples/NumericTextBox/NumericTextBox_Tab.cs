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
    public class NumericTextBox_Tab : SamplePage
    {
        /*********************************
         **Local Variable Inizialisation**
         *********************************/
        SfNumericTextBox principalAmountNumericTextBox, outputNumberTextBox, interestNumericTextBox, periodValueNumericTextBox;
        LinearLayout propertylayout, mainLayout;
        ArrayAdapter<String> cultureDataAdapter;
        Spinner cultureSpinner;
        Java.Util.Locale localinfo;
        Button propertyButton;
        FrameLayout propertyFrameLayout, buttomButtonLayout;
        bool allownull = true;
        int culturePosition = 0, numerHeight, width;
        bool allowNullPosition = true;
        double actionBarHeight, navigationBarHeight,  totalHeight;
        Context context, con;
        FrameLayout frame, mainFrameLayout;
        public override View GetSampleContent(Context con1)
        {
            context = con = con1;
            InitialMethod();
            HeaderLabel();

            // principalAmountNumericTextBox
            LinearLayout principalStack = new LinearLayout(con);
            TextView principalLabel = new TextView(con);
            principalLabel.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight);
            principalLabel.Text = "Principal";
			principalLabel.TextSize = 20;
			principalAmountNumericTextBox = new SfNumericTextBox(con);
            principalAmountNumericTextBox.FormatString = "C";
            principalAmountNumericTextBox.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight);
            principalAmountNumericTextBox.Value = 1000;
            principalAmountNumericTextBox.AllowNull = true;
            principalAmountNumericTextBox.Watermark = "Principal Amount";
            principalAmountNumericTextBox.MaximumNumberDecimalDigits = 2;
            principalAmountNumericTextBox.FocusChange += PrincipalAmountNumericTextBox_FocusChange;
            var culture = new Java.Util.Locale("en", "US");
            principalAmountNumericTextBox.CultureInfo = culture;
            principalAmountNumericTextBox.ValueChangeMode = ValueChangeMode.OnKeyFocus;
            principalStack.Orientation = Orientation.Horizontal;
            principalStack.AddView(principalLabel);
            principalStack.AddView(principalAmountNumericTextBox);
            mainLayout.AddView(principalStack);
            TextView principalStackSpacing = new TextView(con);
            mainLayout.AddView(principalStackSpacing);

            //interestNumericTextBox
            LinearLayout InterestcalStack = new LinearLayout(con);
            TextView interestLabel = new TextView(con);
            interestLabel.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight);
            interestLabel.Text = "Interest Rate";
			interestLabel.TextSize = 20;
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
            interestNumericTextBox.FocusChange += InterestNumericTextBox_FocusChange;
            InterestcalStack.Orientation = Orientation.Horizontal;
            InterestcalStack.AddView(interestLabel);
            InterestcalStack.AddView(interestNumericTextBox);
            mainLayout.AddView(InterestcalStack);
            TextView InterestcalStackSpacing = new TextView(con);
            mainLayout.AddView(InterestcalStackSpacing);

            //periodValueNumericTextBox
            LinearLayout periodStack = new LinearLayout(con);
            TextView period = new TextView(con);
            period.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight);
            period.Text = "Term";
			period.TextSize = 20;
            periodValueNumericTextBox = new SfNumericTextBox(con);
            periodValueNumericTextBox.FormatString = " years";
            periodValueNumericTextBox.Value = 20;
            periodValueNumericTextBox.MaximumNumberDecimalDigits = 0;
            periodValueNumericTextBox.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight);
            periodValueNumericTextBox.Watermark = "Period (in years)";
            periodValueNumericTextBox.ValueChangeMode = ValueChangeMode.OnKeyFocus;
            periodValueNumericTextBox.CultureInfo = culture;
            periodValueNumericTextBox.AllowNull = true;
            periodValueNumericTextBox.FocusChange += PeriodValueNumericTextBox_FocusChange;
            periodStack.Orientation = Orientation.Horizontal;
            periodStack.AddView(period);
            periodStack.AddView(periodValueNumericTextBox);
            mainLayout.AddView(periodStack);

            //outputNumberTextBox
            LinearLayout outputStack = new LinearLayout(con);
            TextView outputLabel = new TextView(con);
            outputLabel.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight);
            outputLabel.Text = "Interest";
			outputLabel.TextSize = 20;
            outputLabel.SetTextColor(Color.ParseColor("#66BB6A"));
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
            outputStack.Orientation = Orientation.Horizontal;
            outputStack.AddView(outputLabel);
            if (con.Resources.DisplayMetrics.Density > 1.5)
            {
                outputStack.SetY(60);
            }
            outputStack.AddView(outputNumberTextBox);
            mainLayout.AddView(outputStack);
            TextView outputStackSpacing = new TextView(con);
            mainLayout.AddView(outputStackSpacing);

            ValueChangeListener();

            return frame;
        }

        private void InitialMethod()
        {
            frame = new FrameLayout(con);
            totalHeight = con.Resources.DisplayMetrics.HeightPixels;

            TypedValue tv = new TypedValue();
            if (con.Theme.ResolveAttribute(Android.Resource.Attribute.ActionBarSize, tv, true))
            {
                actionBarHeight = TypedValue.ComplexToDimensionPixelSize(tv.Data, con.Resources.DisplayMetrics);
            }
           
            navigationBarHeight = getNavigationBarHeight(con);
            totalHeight = totalHeight - navigationBarHeight - actionBarHeight;
            numerHeight = getDimensionPixelSize(con, Resource.Dimension.numeric_txt_ht);
            width = con.Resources.DisplayMetrics.WidthPixels - 40;

            mainFrameLayout = new FrameLayout(con);
            FrameLayout.LayoutParams layoutParams = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent, GravityFlags.FillVertical);
            mainFrameLayout.LayoutParameters = layoutParams;

            //mainLayout
            mainLayout = new LinearLayout(con);
            mainLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.6), GravityFlags.Top | GravityFlags.CenterHorizontal);
            mainLayout.SetGravity(GravityFlags.FillVertical);
            mainLayout.SetPadding(10, 10, 10, 10);
            mainLayout.SetBackgroundColor(Color.White);
            mainLayout.Orientation = Orientation.Vertical;
        }

        private void HeaderLabel()
        {
            //simpleInterestCalculatorLabel
            TextView simpleInterestCalculatorLabel = new TextView(con);
            simpleInterestCalculatorLabel.Text = "Simple Interest Calculator";
            simpleInterestCalculatorLabel.Gravity = GravityFlags.Center;
            simpleInterestCalculatorLabel.TextSize = 24;
            mainLayout.AddView(simpleInterestCalculatorLabel);
            TextView sILabelSpacing = new TextView(con);
            mainLayout.AddView(sILabelSpacing);

            //findingSILabel
            TextView findingSILabel = new TextView(con);
            findingSILabel.Text = "The formula for finding simple interest is:";
            findingSILabel.TextSize = 16;

            //mainLayout.AddView(findingSILabel);
            mainLayout.FocusableInTouchMode = true;
            SpannableStringBuilder formulaBuilder = new SpannableStringBuilder();

            //formulaLabel
            TextView formulaLabel = new TextView(con);
            String interest = "";
            SpannableString interestSpannable = new SpannableString(interest);
            interestSpannable.SetSpan(new ForegroundColorSpan(Color.ParseColor("#66BB6A")), 0, interest.Length, 0);
            formulaBuilder.Append(interestSpannable);
            formulaBuilder.Append("  Principal * Rate * Time");
            formulaLabel.SetText(formulaBuilder, TextView.BufferType.Spannable);
            formulaLabel.TextSize = 16;

            //formulaLayout
            LinearLayout formulaLayout = new LinearLayout(con);
            formulaLayout.Orientation = Android.Widget.Orientation.Horizontal;
            formulaLayout.AddView(findingSILabel);
            formulaLayout.AddView(formulaLabel);
            mainLayout.AddView(formulaLayout);
            TextView formulaLabelSpacing = new TextView(con);
            mainLayout.AddView(formulaLabelSpacing);
        }

        private void ValueChangeListener()
        {
            //numerictextbox Value Changed Listener
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

            //frame
            frame.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            frame.SetBackgroundColor(Color.White);

            //scrollView1
            ScrollView scrollView1 = new ScrollView(con);
            scrollView1.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.6), GravityFlags.Top | GravityFlags.CenterHorizontal);
            scrollView1.AddView(mainLayout);
            frame.AddView(scrollView1);

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
            propertyFrameLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.36), GravityFlags.CenterHorizontal);
            propertyFrameLayout.AddView(GetPropertyLayout(con));
            propertyButton.Click += (object sender, EventArgs e) =>
            {
                buttomButtonLayout.RemoveAllViews();
                propertyFrameLayout.RemoveAllViews();
                outputNumberTextBox.ClearFocus();
                interestNumericTextBox.ClearFocus();
                periodValueNumericTextBox.ClearFocus();
                principalAmountNumericTextBox.ClearFocus();
                propertyFrameLayout.AddView(GetPropertyLayout(con));
            };

            //scrollView
            ScrollView scrollView = new ScrollView(con);
            scrollView.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.36), GravityFlags.Bottom | GravityFlags.CenterHorizontal);
            scrollView.AddView(propertyFrameLayout);

            //frame
            frame.AddView(scrollView);
            frame.AddView(buttomButtonLayout);
            frame.FocusableInTouchMode = true;
        }
        private void PeriodValueNumericTextBox_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            if (e.HasFocus)
            {
                propertyFrameLayout.RemoveAllViews();
                buttomButtonLayout.RemoveAllViews();
                buttomButtonLayout.AddView(propertyButton);
            }
        }

        private void InterestNumericTextBox_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            if (e.HasFocus)
            {
                propertyFrameLayout.RemoveAllViews();
                buttomButtonLayout.RemoveAllViews();
                buttomButtonLayout.AddView(propertyButton);
            }
        }

        private void PrincipalAmountNumericTextBox_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            if (e.HasFocus)
            {
                propertyFrameLayout.RemoveAllViews();
                buttomButtonLayout.RemoveAllViews();
                buttomButtonLayout.AddView(propertyButton);
            }
        }

        //Apply Changes Method
        public void ApplyChanges()
        {
            principalAmountNumericTextBox.CultureInfo = localinfo;
            outputNumberTextBox.CultureInfo = localinfo;
            principalAmountNumericTextBox.AllowNull = allownull;
            periodValueNumericTextBox.AllowNull = allownull;
            interestNumericTextBox.AllowNull = allownull;
        }

        int totalWidth;
        public View GetPropertyLayout(Context context)
        {
            //Property Window
            width = (context.Resources.DisplayMetrics.WidthPixels) / 2;
            totalWidth = (context.Resources.DisplayMetrics.WidthPixels);

            OptionLayout();
            CultureLayout();
            AllowNullLayout();

            return propertylayout;
        }

        FrameLayout topProperty;
        LinearLayout proprtyOptionsLayout;
        private void OptionLayout()
        {
            propertylayout = new LinearLayout(context);
            propertylayout.Orientation = Orientation.Vertical;

            //propertyLabel
            TextView propertyLabel = new TextView(context);
            propertyLabel.SetTextColor(Color.ParseColor("#282828"));
            propertyLabel.Gravity = GravityFlags.CenterVertical;
            propertyLabel.TextSize = 18;
            propertyLabel.SetPadding(0, 10, 0, 10);
            propertyLabel.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent, GravityFlags.Left | GravityFlags.CenterHorizontal);
            propertyLabel.Text = "  " + "OPTIONS";

            //closeLabel
            TextView closeLabel = new TextView(context);
            closeLabel.SetBackgroundColor(Color.Transparent);
            closeLabel.Gravity = GravityFlags.CenterVertical;
            closeLabel.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent, GravityFlags.Right | GravityFlags.CenterHorizontal);
            closeLabel.SetBackgroundResource(Resource.Drawable.sfclosebutton);

            //closeLayout
            FrameLayout closeLayout = new FrameLayout(context);
            closeLayout.SetBackgroundColor(Color.Transparent);
            closeLayout.SetPadding(0, 10, 0, 10);
            closeLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent, GravityFlags.Right | GravityFlags.CenterHorizontal);
            closeLayout.AddView(closeLabel);

            //topProperty
            topProperty = new FrameLayout(context);
            topProperty.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            topProperty.SetBackgroundColor(Color.Rgb(230, 230, 230));
            topProperty.AddView(propertyLabel);
            topProperty.AddView(closeLayout);
            topProperty.Touch += (object sendar, View.TouchEventArgs e) =>
            {
                propertyFrameLayout.RemoveAllViews();
                buttomButtonLayout.RemoveAllViews();
                buttomButtonLayout.AddView(propertyButton);
            };
            proprtyOptionsLayout = new LinearLayout(context);
            proprtyOptionsLayout.Orientation = Android.Widget.Orientation.Vertical;

            //spaceText
            TextView spaceText1 = new TextView(context);
            spaceText1.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.08), GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText1);
        }

        private void CultureLayout()
        {
            //culture
            TextView culturetxt = new TextView(context);
            culturetxt.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            culturetxt.TextSize = 15;
            culturetxt.Text = "Culture";
            cultureSpinner = new Spinner(context,SpinnerMode.Dialog);
            cultureSpinner.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            List<String> cultureList = new List<String>();
            cultureList.Add("United States");
            cultureList.Add("United Kingdom");
            cultureList.Add("Japan");
            cultureList.Add("France");
            cultureList.Add("Italy");
            cultureDataAdapter = new ArrayAdapter<String>
                (context, Android.Resource.Layout.SimpleSpinnerItem, cultureList);
            cultureDataAdapter.SetDropDownViewResource
            (Android.Resource.Layout.SimpleSpinnerDropDownItem);
            cultureSpinner.Adapter = cultureDataAdapter;
            cultureSpinner.SetSelection(culturePosition);
            cultureSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
                String selectedItem = cultureDataAdapter.GetItem(e.Position);
                culturePosition = e.Position;
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

                ApplyChanges();
            };

            LinearLayout cultureLayout = new LinearLayout(context);
            cultureLayout.Orientation = Android.Widget.Orientation.Horizontal;
            cultureLayout.AddView(culturetxt);
            cultureLayout.AddView(cultureSpinner);

            proprtyOptionsLayout.AddView(cultureLayout);

            //spaceText
            TextView spaceText2 = new TextView(context);
            spaceText2.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.067), GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText2);
        }

        private void AllowNullLayout()
        {
            //AllowNull
            TextView allowNullText = new TextView(context);
            allowNullText.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            allowNullText.Text = "Allow Null";
            allowNullText.TextSize = 15;
            Switch allowNullCheckBox = new Switch(context);
            allowNullCheckBox.Gravity = GravityFlags.Left;
            // allowNullCheckBox.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.167), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            allowNullCheckBox.Checked = allowNullPosition;
            allowNullCheckBox.CheckedChange += (object send, CompoundButton.CheckedChangeEventArgs eve) => {
                if (!eve.IsChecked)
                    allownull = false;
                else
                    allownull = true;

                allowNullPosition = allownull;
                ApplyChanges();
            };
            //spaceText
            TextView spaceText7 = new TextView(context);
            spaceText7.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.167), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);

            LinearLayout allowNullLayout = new LinearLayout(context);
            allowNullLayout.Orientation = Android.Widget.Orientation.Horizontal;
            allowNullLayout.AddView(allowNullText);
            allowNullLayout.AddView(allowNullCheckBox);
            allowNullLayout.AddView(spaceText7);

            proprtyOptionsLayout.AddView(allowNullLayout);
            //spaceText
            TextView spaceText3 = new TextView(context);
            spaceText3.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.08), GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText3);

            TextView spaceLabel = new TextView(context);
            spaceLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.167), ViewGroup.LayoutParams.WrapContent);

            LinearLayout layout1 = new LinearLayout(context);
            layout1.Orientation = Android.Widget.Orientation.Horizontal;
            layout1.AddView(spaceLabel);
            layout1.AddView(proprtyOptionsLayout);


            propertylayout.AddView(topProperty);
            propertylayout.AddView(layout1);
            propertylayout.SetBackgroundColor(Color.Rgb(240, 240, 240));
            propertylayout.SetPadding(10, 0, 10, 10);

            //ScrollView scroll = new ScrollView(context);
            //scroll.AddView(propertylayout);
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
        private int getStatusBarHeight(Android.Content.Context con)
        {
            int barHeight = 0;
            int resourceId = con.Resources.GetIdentifier("status_bar_height", "dimen", "android");
            if (resourceId > 0)
            {
                barHeight = con.Resources.GetDimensionPixelSize(resourceId);
            }
            return barHeight;
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
    }
}

