#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;

using Android.Content;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Com.Syncfusion.Barcode;
using Com.Syncfusion.Barcode.Enums;

namespace SampleBrowser
{
    public class UpcBarcode : SamplePage
    {
        SfBarcode barcode;

        public override View GetSampleContent(Context con)
        {
            LinearLayout linear = new LinearLayout(con);
            linear.SetBackgroundColor(Color.White);
            linear.Orientation = Orientation.Vertical;
            linear.SetPadding(10, 10, 10, 10);

            TextView text1 = new TextView(con);
            text1.TextSize = 16;
            text1.SetTextColor(Color.ParseColor("#262626"));
            text1.Typeface = Typeface.DefaultBold;
            text1.Text = "Allowed Characters";
            text1.SetPadding(5, 10, 10, 5);
            linear.AddView(text1);

            TextView text2 = new TextView(con);
            text2.TextSize = 14;
            text2.SetTextColor(Color.ParseColor("#3F3F3F"));
            text2.Text = "1 2 3 4 5 6 7 8 9 0\nText length should be 11 or 12!!!";
            text2.SetPadding(5, 5, 5, 5);
            LinearLayout text2Layout = new LinearLayout(con);
            LinearLayout.LayoutParams parms = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
            text2Layout.LayoutParameters = parms;
            text2Layout.AddView(text2);
            linear.AddView(text2Layout);

            LinearLayout barcodeLayout = new LinearLayout(con);
            barcodeLayout.SetPadding(0, 10, 0, 5);
            LinearLayout.LayoutParams parms1 = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
            barcodeLayout.LayoutParameters = parms1;

            barcode = new SfBarcode(con);
            barcode.Text = "01234567890";
            Typeface fontFamily = Typeface.Create("helvetica", TypefaceStyle.Bold);
            barcode.TextFont = fontFamily;
            barcode.SetBackgroundColor(Color.ParseColor("#F2F2F2"));
            barcode.Symbology = BarcodeSymbolType.UpcBarcode;
            barcode.TextSize = 20;

            UpcBarcodeSettings setting = new UpcBarcodeSettings();
            setting.BarHeight = 120;
            setting.NarrowBarWidth = 3;
            barcode.SymbologySettings = setting;
            barcodeLayout.AddView(barcode);
            linear.AddView(barcodeLayout);

            return linear;
        }
    }
}