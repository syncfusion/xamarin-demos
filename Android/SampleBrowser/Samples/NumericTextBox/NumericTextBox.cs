#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using Android.Util;
using Android.Views;

namespace SampleBrowser
{
    public class NumericTextBox : SamplePage
    {
        NumericTextBox_Mobile mobile;
        public NumericTextBox()
        {

        }

        public override View GetSampleContent(Android.Content.Context con)
        {
            if (IsTabletDevice(con))
            {
                NumericTextBox_Tab tab = new NumericTextBox_Tab();
                return tab.GetSampleContent(con);
            }
            else
            {
                mobile = new NumericTextBox_Mobile();
                return mobile.GetSampleContent(con);
            }
        }

        public override View GetPropertyWindowLayout(Android.Content.Context context)
        {
            if (IsTabletDevice(context))
            {
                return null;
            }
            else
            {
                return mobile.GetPropertyWindowLayout(context);
            }
        }

        public override void OnApplyChanges()
        {
            base.OnApplyChanges();
            mobile.OnApplyChanges();
        }
        public static bool IsTabletDevice(Android.Content.Context context)
        {
            try
            {
                DisplayMetrics displayMetrics = context.Resources.DisplayMetrics;
                float screenWidth = displayMetrics.WidthPixels / displayMetrics.Xdpi;
                float screenHeight = displayMetrics.HeightPixels / displayMetrics.Ydpi;
                double size = Java.Lang.Math.Sqrt(Math.Pow(screenWidth, 2) + Math.Pow(screenHeight, 2));
                return size >= 6;
            }
            catch
            {
                return false;
            }
        }
    }
}

