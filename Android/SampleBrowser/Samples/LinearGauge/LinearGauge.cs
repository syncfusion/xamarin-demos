#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Android.Util;
using System;
using Android.Views;
using Com.Syncfusion.Gauges.SfLinearGauge;
using Android.Widget;
using Android.Content;
using Android.OS;
using Android.Runtime;
using System.Collections.ObjectModel;
using Android.Graphics;


namespace SampleBrowser
{
	public class LinearGauge : SamplePage
	{
        public static int pointervalue = 10;

        public override View GetSampleContent(Android.Content.Context con)
        {
            /****************
            **Linear Gauge**
            ****************/
            SfLinearGauge linearGauge = new SfLinearGauge(con);
            ObservableCollection<LinearScale> scales = new ObservableCollection<LinearScale>();
            ObservableCollection<LinearPointer> pointers = new ObservableCollection<LinearPointer>();
            ObservableCollection<LinearRange> ranges = new ObservableCollection<LinearRange>();

            linearGauge.SetX(0);
            linearGauge.SetY(0);
            linearGauge.SetBackgroundColor(Color.Rgb(255, 255, 255));
            linearGauge.SetOrientation(SfLinearGauge.Orientation.Horizontal);

            //OuterScale
            LinearScale outerScale = new LinearScale();
            outerScale.Minimum = 0;
            outerScale.Maximum = 100;
            outerScale.ScaleBarSize = 2;
            outerScale.Interval = 10;
            outerScale.ScaleBarColor = Android.Graphics.Color.ParseColor("#9e9e9e");
            outerScale.MinorTicksPerInterval = 4;
            outerScale.LabelFontSize = 14;
            outerScale.LabelColor = Color.ParseColor("#424242");
            outerScale.OpposedPosition = true;

            //OuterScale MajorTicksSettings
            LinearTickSettings outerScale_majorTicksSettings = new LinearTickSettings();
            outerScale_majorTicksSettings.Color = Color.ParseColor("#9E9E9E");//
            outerScale_majorTicksSettings.Length = 30;
            outerScale_majorTicksSettings.StrokeWidth = 1.5;
            outerScale.MajorTickSettings = outerScale_majorTicksSettings;

            //OuterScale MinorTicksSettings
            LinearTickSettings outerScale_minorTicksSettings = new LinearTickSettings();
            outerScale_minorTicksSettings.Color = Color.ParseColor("#9E9E9E");
            outerScale_minorTicksSettings.Length = 15;
            outerScale_minorTicksSettings.StrokeWidth = 0.9;
            outerScale.MinorTickSettings = outerScale_minorTicksSettings;

            //Symbol Pointer
            SymbolPointer outerScale_needlePointer = new SymbolPointer();
            outerScale_needlePointer.SymbolPosition = SymbolPointerPosition.Away;
            outerScale_needlePointer.Value = pointervalue;
            outerScale_needlePointer.StrokeWidth = 12;
            outerScale_needlePointer.Color = Color.ParseColor("#9E9E9E");
            outerScale_needlePointer.MarkerShape = MarkerShape.Triangle;
            pointers.Add(outerScale_needlePointer);
            outerScale.Pointers = pointers;

            scales.Add(outerScale);
            linearGauge.Scales = scales;

            //Linear Gauge Layout
            LinearLayout linearGaugeLayout = new LinearLayout(con);
            linearGaugeLayout.SetBackgroundColor(Color.Rgb(255, 255, 255));
            linearGaugeLayout.AddView(linearGauge);

            return linearGaugeLayout;
        }
    }
}


