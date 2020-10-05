#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using Android.Views;
using Android.Util;

namespace SampleBrowser
{
    public class BusyIndicator : SamplePage
    {
        BusyIndicator_Mobile mobile;
        BusyIndicator_Tab tab;
        public BusyIndicator()
        {

        }

        public override View GetSampleContent(Android.Content.Context con)
        {
            if (IsTabletDevice(con))
            {
                tab = new BusyIndicator_Tab();
                return tab.GetSampleContent(con);
            }
            else
            {
                mobile = new BusyIndicator_Mobile();
                return mobile.GetSampleContent(con);
            }
        }

        public override View GetPropertyWindowLayout(Android.Content.Context context)
        {
            if (IsTabletDevice(context))
            {
                return tab.GetPropertyWindowLayout(context);
            }
            else
            {
                return null;
            }
        }


        public static bool IsTabletDevice(Android.Content.Context context)
        {
            try
            {
                DisplayMetrics displayMetrics = context.Resources.DisplayMetrics;
                float screenWidth = displayMetrics.WidthPixels / displayMetrics.Xdpi;
                float screenHeight = displayMetrics.HeightPixels / displayMetrics.Ydpi;
                double size = Math.Sqrt(Math.Pow(screenWidth, 2) + Math.Pow(screenHeight, 2));
                return size >= 6;
            }
            catch
            {
                return false;
            }
        }
    }
}
