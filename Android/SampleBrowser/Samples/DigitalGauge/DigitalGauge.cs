#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any indigitalGaugeLayoutingement will be prosecuted under
// applicable laws. 
#endregion

using System;
using Android.Util;
using Android.Views;

namespace SampleBrowser
{
	public class DigitalGauge : SamplePage
	{
        public DigitalGauge()
        {

        }

        public override View GetSampleContent(Android.Content.Context con)
        {
            if (IsTabletDevice(con))
            {
                DigitalGauge_Tab tab = new DigitalGauge_Tab();
                return tab.GetSampleContent(con);
            }
            else
            {
                DigitalGauge_Mobile mobile = new DigitalGauge_Mobile();
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
                DigitalGauge_Mobile mobile = new DigitalGauge_Mobile();
                return mobile.GetPropertyWindowLayout(context);
            }
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





