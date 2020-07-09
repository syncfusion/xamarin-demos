#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Syncfusion.Android.MaskedEdit;

namespace SampleBrowser
{
    class SfMaskedEditText : SamplePage
    {
        SfMaskedEditText_Mobile mobile;
        public override View GetSampleContent(Context con)
        {
            if (IsTabletDevice(con))
            {
                SfMaskedEditText_Tab tab = new SfMaskedEditText_Tab();
                return tab.GetSampleContent(con);
            }
            else
            {
                mobile = new SfMaskedEditText_Mobile();
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