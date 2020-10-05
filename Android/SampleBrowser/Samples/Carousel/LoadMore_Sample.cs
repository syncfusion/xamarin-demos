#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace SampleBrowser
{
    public class LoadMore_Sample : SamplePage
    {
        LoadMore_Mobile mobile;
        //PullToRefresh_Tab tab;

        public LoadMore_Sample()
        {

        }

        public override View GetSampleContent(Android.Content.Context con)
        {
            //if (IsTabletDevice(con))
            //{
            //    tab = new PullToRefresh_Tab();
            //    contextTablet = con;
            //    return tab.GetSampleContent(con);

            //}
            //else
            //{
                mobile = new LoadMore_Mobile();
                return mobile.GetSampleContent(con);
            //}
        }

        public override View GetPropertyWindowLayout(Android.Content.Context context)
        {
            //if (IsTabletDevice(context))
            //{
            //    return tab.GetPropertyWindowLayout(context);
            //}
            //else
            //{
                return mobile.GetPropertyWindowLayout(context);
            //}
        }

        public override void OnApplyChanges()
        {
            //if (IsTabletDevice(contextTablet))
            //    tab.OnApplyChanges();
            //else
                mobile.OnApplyChanges();
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

