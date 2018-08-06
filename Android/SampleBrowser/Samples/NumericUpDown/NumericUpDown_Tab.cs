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
    public class NumericUpDown_Tab : SamplePage
    {
       /*********************************
        **Local Variable Inizialisation**
        *********************************/
        SfNumericUpDown adultNumericUpDown, infantsNumericUpDown;
        Android.Views.TextAlignment textAlign = Android.Views.TextAlignment.TextStart;
        Button propertyButton;
        FrameLayout propertyFrameLayout, buttomButtonLayout, topProperty, frame;
        double actionBarHeight, navigationBarHeight, totalHeight, totalWidth;
        double minimumValue = 0, maximumValue = 100, minimumPosition = 0, maximumPosition = 100;
        Context con, context;
        int width,spinButtonPosition = 0;
        Boolean maxNegative, minNegative;
        bool autoReversePosition = false, autoReverse = false;
        float density;
        LinearLayout mainLayout, proprtyOptionsLayout, propertylayout;     
        ArrayAdapter<String> spinButtonDataAdapter;
        Spinner spinButtonSpinner;      
        EditText minimumText, maximumText;
        SpinButtonAlignment spinButtonAlignment = SpinButtonAlignment.Right;
        TextView adultText, infantsText;
		GravityFlags gravity = GravityFlags.CenterVertical;
        public override View GetSampleContent(Context con1)
        {
            con = con1;
            InitialMethod();

            //adultNumericUpDown
            AdultLayout();
            int numerHeight = (int)(density * 55);
			if (density >= 3)
			{
				numerHeight = (int)(density * 65);
			}
            adultNumericUpDown = new SfNumericUpDown(con);
            adultNumericUpDown.FontSize = 18;
			adultNumericUpDown.TextGravity = GravityFlags.CenterVertical;
			adultNumericUpDown.LayoutParameters = new ViewGroup.LayoutParams((int)(width * 0.7), numerHeight);
            adultNumericUpDown.Minimum = 0;
            adultNumericUpDown.Maximum = 100;
            adultNumericUpDown.Value = 5;
            adultNumericUpDown.FormatString = "N";
            adultNumericUpDown.AutoReverse = false;
            adultNumericUpDown.StepValue = 1;
            (adultNumericUpDown.GetChildAt(0) as EditText).FocusChange += adultNumericUpDown_Tab_FocusChange;
            mainLayout.AddView(adultNumericUpDown);

            //infantsNumericUpDown
            infantsTextLayout();
            infantsNumericUpDown = new SfNumericUpDown(con);
            infantsNumericUpDown.FontSize = 18;
			infantsNumericUpDown.TextGravity = GravityFlags.CenterVertical;
			infantsNumericUpDown.LayoutParameters = new ViewGroup.LayoutParams((int)(width * 0.7), numerHeight);
            infantsNumericUpDown.Minimum = 0;
            infantsNumericUpDown.Maximum = 100;
            infantsNumericUpDown.Value = 2;
            infantsNumericUpDown.FormatString = "N";
            infantsNumericUpDown.AutoReverse = false;
            infantsNumericUpDown.StepValue = 1;
            (infantsNumericUpDown.GetChildAt(0) as EditText).FocusChange += NumericUpDown_Tab_FocusChange;

            OptionLayout();
            return frame;
        }
      
        private void InitialMethod()
        {
            //frame
            frame = new FrameLayout(con);
            totalHeight = con.Resources.DisplayMetrics.HeightPixels;
            totalWidth = con.Resources.DisplayMetrics.WidthPixels;

            TypedValue tv = new TypedValue();
			if (con.Theme.ResolveAttribute(Android.Resource.Attribute.ActionBarSize, tv, true))
			{
				actionBarHeight = TypedValue.ComplexToDimensionPixelSize(tv.Data, con.Resources.DisplayMetrics);
			}
            navigationBarHeight = getNavigationBarHeight(con);
            totalHeight = totalHeight - navigationBarHeight - actionBarHeight;
            width = con.Resources.DisplayMetrics.WidthPixels - 40;
            density = con.Resources.DisplayMetrics.Density;

            //mainFrameLayout
            FrameLayout mainFrameLayout = new FrameLayout(con);
            mainFrameLayout.SetPadding(10, 10, 10, 10);
            FrameLayout.LayoutParams layoutParams = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent, GravityFlags.FillVertical);
            mainFrameLayout.LayoutParameters = layoutParams;
           
            //mainLayout
            mainLayout = new LinearLayout(con);
            mainLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
            mainLayout.SetGravity(GravityFlags.FillVertical);
            mainLayout.Orientation = Orientation.Vertical;
            mainLayout.SetBackgroundColor(Color.White);
        }
        
        private void AdultLayout()
        {
            //Adult
            adultText = new TextView(con);
            adultText.Text = "Number of adults";
            adultText.TextSize = 18;
            mainLayout.AddView(adultText);
        }

        private void infantsTextLayout()
        {
            TextView spaceText5 = new TextView(con);
            spaceText5.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 40, GravityFlags.Center);
            mainLayout.AddView(spaceText5);

            //infants
            infantsText = new TextView(con);
            infantsText.SetPadding(0, 15, 0, 0);
            infantsText.Text = "Number of infants";
            infantsText.TextSize = 18;
            mainLayout.AddView(infantsText);
        }

        private void OptionLayout()
        {
            mainLayout.AddView(infantsNumericUpDown);
            //Touch Event
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

            frame.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            frame.SetBackgroundColor(Color.White);

            //numericCenterLayout
            LinearLayout numericCenterLayout = new LinearLayout(con);
            numericCenterLayout.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.7), ViewGroup.LayoutParams.MatchParent, GravityFlags.Top);
            numericCenterLayout.SetX((int)(totalWidth * 0.15));
            numericCenterLayout.SetY((int)(totalHeight * 0.1));
            numericCenterLayout.AddView(mainLayout);

            //scrollView1
            ScrollView scrollView1 = new ScrollView(con);
            scrollView1.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.5), GravityFlags.Top | GravityFlags.CenterHorizontal);
            scrollView1.AddView(numericCenterLayout);
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

            //propertyFrameLayout
            propertyFrameLayout = new FrameLayout(con);
            propertyFrameLayout.SetBackgroundColor(Color.Rgb(236, 236, 236));
            propertyFrameLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.35), GravityFlags.CenterHorizontal);
            propertyFrameLayout.AddView(GetPropertyLayout(con));
            propertyButton.Click += (object sender, EventArgs e) =>
            {
                buttomButtonLayout.RemoveAllViews();
                propertyFrameLayout.RemoveAllViews();
                adultNumericUpDown.ClearFocus();
                infantsNumericUpDown.ClearFocus();
                propertyFrameLayout.AddView(GetPropertyLayout(con));
            };

            //scrollView
            ScrollView scrollView = new ScrollView(con);
            scrollView.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.35), GravityFlags.Bottom | GravityFlags.CenterHorizontal);
            scrollView.AddView(propertyFrameLayout);

            //frame
            frame.AddView(scrollView);
            frame.AddView(buttomButtonLayout);
            frame.FocusableInTouchMode = true;
        }
        private void NumericUpDown_Tab_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            if ((sender as EditText).IsFocused)
            {
                propertyFrameLayout.RemoveAllViews();
                buttomButtonLayout.RemoveAllViews();
                buttomButtonLayout.AddView(propertyButton);
            }
        }

        private void adultNumericUpDown_Tab_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            if ((sender as EditText).IsFocused)
            {
                propertyFrameLayout.RemoveAllViews();
                buttomButtonLayout.RemoveAllViews();
                buttomButtonLayout.AddView(propertyButton);
            }
        }
      
        //Apply Changes Method
        public void ApplyChanges()
        {
            //adultNumericUpDown
            adultNumericUpDown.Minimum = minimumValue;
            adultNumericUpDown.Maximum = maximumValue;
            adultNumericUpDown.AutoReverse = autoReverse;
            adultNumericUpDown.SpinButtonAlignment = spinButtonAlignment;
           // adultNumericUpDown.TextAlignment = textAlign;
			adultNumericUpDown.TextGravity = gravity;

            //infantsNumericUpDown
            infantsNumericUpDown.Minimum = minimumValue;
            infantsNumericUpDown.Maximum = maximumValue;
            infantsNumericUpDown.AutoReverse = autoReverse;
            infantsNumericUpDown.SpinButtonAlignment = spinButtonAlignment;
            //infantsNumericUpDown.TextAlignment = textAlign;
			infantsNumericUpDown.TextGravity = gravity;

            maxNegative = minNegative = false;
        }
     
        public View GetPropertyLayout(Context context1)
        {
            context = context1;           
            width = (context.Resources.DisplayMetrics.WidthPixels) / 2;
            totalWidth = (context.Resources.DisplayMetrics.WidthPixels);

            OptionViewLayout();
            MinimumLabelLayout();
            MaximumLabelLayout();
            SpinButtonAlignmentLayout();
            AutoReverseLayout();

            return propertylayout;
        }    
        private void OptionViewLayout()
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
            spaceText1.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 40, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText1);
        }

        private void MinimumLabelLayout()
        {
            double newNumber;
            //minimum
            TextView minimumLabel = new TextView(context);
            minimumLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            minimumLabel.Text = "Minimum";
            minimumLabel.TextSize = 15;

            //minimumText
            minimumText = new EditText(context);
            minimumText.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            minimumText.Text = minimumPosition.ToString();
            minimumText.TextSize = 16;
            minimumText.InputType = Android.Text.InputTypes.ClassPhone;
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
                minimumPosition = minimumValue;
                ApplyChanges();
            };

            //minimumLayout
            LinearLayout minimumLayout = new LinearLayout(context);
            minimumLayout.Orientation = Android.Widget.Orientation.Horizontal;
            minimumLayout.AddView(minimumLabel);
            minimumLayout.AddView(minimumText);
            proprtyOptionsLayout.AddView(minimumLayout);

            //spaceText
            TextView spaceText2 = new TextView(context);
            spaceText2.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 40, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText2);
        }

        private void MaximumLabelLayout()
        {
            double newNumber;
            //maximum
            TextView maximumLabel = new TextView(context);
            maximumLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            maximumLabel.Text = "Maximum";
            maximumLabel.TextSize = 15;

            //maximumText
            maximumText = new EditText(context);
            maximumText.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            maximumText.Text = maximumPosition.ToString();
            maximumText.TextSize = 16;
            maximumText.InputType = Android.Text.InputTypes.ClassPhone;
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
                maximumPosition = maximumValue;
                ApplyChanges();
            };

            //maximumLayout
            LinearLayout maximumLayout = new LinearLayout(context);
            maximumLayout.Orientation = Android.Widget.Orientation.Horizontal;
            maximumLayout.AddView(maximumLabel);
            maximumLayout.AddView(maximumText);
            proprtyOptionsLayout.AddView(maximumLayout);
            
            //spaceText
            TextView spaceText3 = new TextView(context);
            spaceText3.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 40, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText3);
        }

        private void SpinButtonAlignmentLayout()
        {
            //spinButtonAlignment
            TextView spinButtonText = new TextView(context);
            spinButtonText.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            spinButtonText.TextSize = 15;
            spinButtonText.Text = "SpinButtonAlignment";
        
            //spinButtonList
            List<String> spinButtonList = new List<String>();
            spinButtonList.Add("Right");
            spinButtonList.Add("Left");
            spinButtonList.Add("Both");
            spinButtonDataAdapter = new ArrayAdapter<String>
                (context, Android.Resource.Layout.SimpleSpinnerItem, spinButtonList);
            spinButtonDataAdapter.SetDropDownViewResource
            (Android.Resource.Layout.SimpleSpinnerDropDownItem);
            //spinButtonSpinner
            spinButtonSpinner = new Spinner(context,SpinnerMode.Dialog);
            spinButtonSpinner.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            spinButtonSpinner.Adapter = spinButtonDataAdapter;
            spinButtonSpinner.SetSelection(spinButtonPosition);
            spinButtonSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
                String selectedItem = spinButtonDataAdapter.GetItem(e.Position);
                spinButtonPosition = e.Position;
                if (selectedItem.Equals("Right"))
                {
                    spinButtonAlignment = SpinButtonAlignment.Right;
                    textAlign = Android.Views.TextAlignment.TextStart;
					gravity = GravityFlags.CenterVertical;
                }
                if (selectedItem.Equals("Left"))
                {
                    spinButtonAlignment = SpinButtonAlignment.Left;
                    textAlign = Android.Views.TextAlignment.TextEnd;
					gravity = GravityFlags.End | GravityFlags.CenterVertical;
                }
                if (selectedItem.Equals("Both"))
                {
                    spinButtonAlignment = SpinButtonAlignment.Both;
                    textAlign = Android.Views.TextAlignment.Center;
					gravity = GravityFlags.Center;
                }
                ApplyChanges();
            };

            //spinButtonLayout
            LinearLayout spinButtonLayout = new LinearLayout(context);
            spinButtonLayout.Orientation = Android.Widget.Orientation.Horizontal;
            spinButtonLayout.AddView(spinButtonText);
            spinButtonLayout.AddView(spinButtonSpinner);
            proprtyOptionsLayout.AddView(spinButtonLayout);
            
            //spaceText
            TextView spaceText4 = new TextView(context);
            spaceText4.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 40, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText4);
        }

        private void AutoReverseLayout()
        {
            //AutoReverse
            TextView autoReverseText = new TextView(context);
            autoReverseText.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            autoReverseText.Text = "AutoReverse";

            //autoReverseCheckBox
            Switch autoReverseCheckBox = new Switch(context);
            autoReverseCheckBox.Checked = autoReversePosition;
            autoReverseCheckBox.CheckedChange += (object send, CompoundButton.CheckedChangeEventArgs eve) => {
                if (!eve.IsChecked)
                    autoReverse = false;
                else
                    autoReverse = true;

                autoReversePosition = autoReverse;
                ApplyChanges();
            };
            
            //spaceText
            TextView spaceText7 = new TextView(context);
            spaceText7.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.167), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);

            //autoReverseLayout
            LinearLayout autoReverseLayout = new LinearLayout(context);
            autoReverseLayout.Orientation = Android.Widget.Orientation.Horizontal;
            autoReverseLayout.AddView(autoReverseText);
            autoReverseLayout.AddView(autoReverseCheckBox);
            autoReverseLayout.AddView(spaceText7);
            proprtyOptionsLayout.AddView(autoReverseLayout);
            
            //spaceText
            TextView spaceText5 = new TextView(context);
            spaceText5.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 40, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText5);
            TextView spaceLabel = new TextView(context);
            spaceLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.167), ViewGroup.LayoutParams.WrapContent);

            //layout1
            LinearLayout layout1 = new LinearLayout(context);
            layout1.Orientation = Android.Widget.Orientation.Horizontal;
            layout1.AddView(spaceLabel);
            layout1.AddView(proprtyOptionsLayout);

            //propertylayout
            propertylayout.AddView(topProperty);
            propertylayout.AddView(layout1);
            propertylayout.SetPadding(10, 10, 10, 10);
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
