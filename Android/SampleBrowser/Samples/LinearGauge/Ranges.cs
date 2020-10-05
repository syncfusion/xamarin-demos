#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Com.Syncfusion.Gauges.SfLinearGauge;

namespace SampleBrowser
{
    public class Ranges : SamplePage
    {
        public static int pointervalue = 35;
        LinearLayout range1Layout, range2Layout, range3Layout;
        SfLinearGauge linearGauge1, linearGauge2, linearGauge3;
        Context context;

        public override View GetSampleContent(Android.Content.Context con)
        {
            context = con;

            RangeLayout1();
            RangeLayout2();
            RangeLayout3();

            //Main View
            LinearLayout mainLinearGaugeLayout = GetView(con);
            ScrollView mainView = new ScrollView(con);
            mainView.AddView(mainLinearGaugeLayout);

            return mainView;
        }

        private void RangeLayout1()
        {
            DisplayMetrics displayMetrics = context.Resources.DisplayMetrics;
            float screenHeight = displayMetrics.HeightPixels;
            /****************
           **Linear Gauge**
           ****************/
            linearGauge1 = new SfLinearGauge(context);
            ObservableCollection<LinearScale> scales = new ObservableCollection<LinearScale>();
            ObservableCollection<LinearPointer> pointers = new ObservableCollection<LinearPointer>();
            ObservableCollection<LinearRange> ranges = new ObservableCollection<LinearRange>();

            linearGauge1.SetX(0);
            linearGauge1.SetY(0);
            linearGauge1.SetBackgroundColor(Color.Rgb(255, 255, 255));
            linearGauge1.SetOrientation(SfLinearGauge.Orientation.Horizontal);

            //OuterScale
            LinearScale outerScale = new LinearScale();
            outerScale.Minimum = 0;
            outerScale.Maximum = 100;
            outerScale.Interval = 25;
            outerScale.LabelOffset = 15;
            outerScale.ScaleBarColor = Color.Transparent;
            outerScale.MinorTicksPerInterval = 0;
            outerScale.LabelFontSize = 14;
            outerScale.LabelColor = Color.ParseColor("#424242");
            outerScale.ShowTicks = false;

            //Symbol Pointer
            SymbolPointer outerScale_needlePointer = new SymbolPointer();
            outerScale_needlePointer.SymbolPosition = SymbolPointerPosition.Far;
            outerScale_needlePointer.Value = pointervalue;
            outerScale_needlePointer.StrokeWidth = 10;
            outerScale_needlePointer.Color = Color.Black;
            outerScale_needlePointer.MarkerShape = MarkerShape.InvertedTriangle;
            pointers.Add(outerScale_needlePointer);
            outerScale.Pointers = pointers;

            //Symbol Range
            LinearRange range = new LinearRange();
            range.StartWidth = 20;
            range.EndWidth = 20;
            range.Color = Color.ParseColor("#1A237E");
            range.StartValue = 0;
            range.EndValue = 25;
            ranges.Add(range);

            //Symbol Range1
            LinearRange range1 = new LinearRange();
            range1.StartWidth = 20;
            range1.EndWidth = 20;
            range1.Color = Color.ParseColor("#283593");
            range1.StartValue = 25;
            range1.EndValue = 50;
            ranges.Add(range1);

            //Symbol Range2
            LinearRange range2 = new LinearRange();
            range2.StartWidth = 20;
            range2.EndWidth = 20;
            range2.Color = Color.ParseColor("#3F51B5");
            range2.StartValue = 50;
            range2.EndValue = 75;
            ranges.Add(range2);

            //Symbol Range3
            LinearRange range3 = new LinearRange();
            range3.StartWidth = 20;
            range3.EndWidth = 20;
            range3.Color = Color.ParseColor("#5C6BC0");
            range3.StartValue = 75;
            range3.EndValue = 100;
            ranges.Add(range3);

            outerScale.Ranges = ranges;

            scales.Add(outerScale);
            linearGauge1.Scales = scales;

            linearGauge1.LayoutParameters = (new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, (int)(screenHeight / 4)));

            //Range Layout
            range1Layout = new LinearLayout(context);
            range1Layout.SetGravity(GravityFlags.Center);
            range1Layout.AddView(linearGauge1);
        }

        private void RangeLayout2()
        {
            DisplayMetrics displayMetrics = context.Resources.DisplayMetrics;
            float screenHeight = displayMetrics.HeightPixels;
            /****************
          **Linear Gauge**
          ****************/
            linearGauge2 = new SfLinearGauge(context);
            ObservableCollection<LinearScale> scales = new ObservableCollection<LinearScale>();
            ObservableCollection<LinearPointer> pointers = new ObservableCollection<LinearPointer>();
            ObservableCollection<LinearRange> ranges = new ObservableCollection<LinearRange>();

            linearGauge2.SetX(0);
            linearGauge2.SetY(0);
            linearGauge2.SetBackgroundColor(Color.Rgb(255, 255, 255));
            linearGauge2.SetOrientation(SfLinearGauge.Orientation.Horizontal);

            //OuterScale
            LinearScale outerScale = new LinearScale();
            outerScale.Minimum = 0;
            outerScale.Maximum = 100;
            outerScale.Interval = 25;
            outerScale.ScaleBarColor = Color.Transparent;
            outerScale.MinorTicksPerInterval = 0;
            outerScale.LabelFontSize = 14;
            outerScale.LabelOffset = 23;
            outerScale.LabelColor = Color.ParseColor("#424242");
            outerScale.ShowTicks = false;

            //Symbol Pointer
            SymbolPointer outerScale_needlePointer = new SymbolPointer();
            outerScale_needlePointer.SymbolPosition = SymbolPointerPosition.Far;
            outerScale_needlePointer.Value = pointervalue;
            outerScale_needlePointer.StrokeWidth = 10;
            outerScale_needlePointer.Color = Color.Black;
            outerScale_needlePointer.MarkerShape = MarkerShape.InvertedTriangle;
            pointers.Add(outerScale_needlePointer);
            outerScale.Pointers = pointers;

            //Symbol Range
            LinearRange range = new LinearRange();
            range.StartWidth = 10;
            range.EndWidth = 15;
            range.Color = Color.ParseColor("#6de500");
            range.StartValue = 0;
            range.EndValue = 25;
            ranges.Add(range);

            //Symbol Range1
            LinearRange range1 = new LinearRange();
            range1.StartWidth = 15;
            range1.EndWidth = 20;
            range1.Color = Color.ParseColor("#53ad00");
            range1.StartValue = 25;
            range1.EndValue = 50;
            ranges.Add(range1);

            //Symbol Range2
            LinearRange range2 = new LinearRange();
            range2.StartWidth = 20;
            range2.EndWidth = 25;
            range2.Color = Color.ParseColor("#009148");
            range2.StartValue = 50;
            range2.EndValue = 75;
            ranges.Add(range2);

            //Symbol Range3
            LinearRange range3 = new LinearRange();
            range3.StartWidth = 25;
            range3.EndWidth = 30;
            range3.Color = Color.ParseColor("#026623");
            range3.StartValue = 75;
            range3.EndValue = 100;
            ranges.Add(range3);

            outerScale.Ranges = ranges;

            scales.Add(outerScale);
            linearGauge2.Scales = scales;

            linearGauge2.LayoutParameters = (new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, (int)screenHeight / 4));

            //Range Layout
            range2Layout = new LinearLayout(context);
            range2Layout.SetGravity(GravityFlags.Center);
            range2Layout.AddView(linearGauge2);

        }

        private void RangeLayout3()
        {
            DisplayMetrics displayMetrics = context.Resources.DisplayMetrics;
            float screenHeight = displayMetrics.HeightPixels;
            /****************
          **Linear Gauge**
          ****************/
            linearGauge3 = new SfLinearGauge(context);
            ObservableCollection<LinearScale> scales = new ObservableCollection<LinearScale>();
            ObservableCollection<LinearPointer> pointers = new ObservableCollection<LinearPointer>();
            ObservableCollection<LinearRange> ranges = new ObservableCollection<LinearRange>();

            linearGauge3.SetX(0);
            linearGauge3.SetY(0);
            linearGauge3.SetBackgroundColor(Color.Rgb(255, 255, 255));
            linearGauge3.SetOrientation(SfLinearGauge.Orientation.Horizontal);

            //OuterScale
            LinearScale outerScale = new LinearScale();
            outerScale.LabelFontSize = 14;
            outerScale.Interval = 25;
            outerScale.LabelOffset = 15;
            outerScale.ScaleBarSize = 20;
            outerScale.ScaleBarColor = Color.Transparent;
            outerScale.LabelColor = Color.ParseColor("#424242");
            outerScale.ShowTicks = false;

            //Symbol Pointer
            SymbolPointer outerScale_needlePointer = new SymbolPointer();
            outerScale_needlePointer.SymbolPosition = SymbolPointerPosition.Far;
            outerScale_needlePointer.Value = pointervalue;
            outerScale_needlePointer.StrokeWidth = 10;
            outerScale_needlePointer.Color = Color.Black;
            outerScale_needlePointer.MarkerShape = MarkerShape.InvertedTriangle;
            pointers.Add(outerScale_needlePointer);
            outerScale.Pointers = pointers;

            //Symbol Range
            LinearRange range = new LinearRange();
            range.StartWidth = 20;
            range.EndWidth = 20;
            range.StartValue = 0;
            range.EndValue = 100;
            ranges.Add(range);
            outerScale.Ranges = ranges;
            range.GradientStops = new ObservableCollection<GaugeGradientStop>()
            {
                new GaugeGradientStop() { Value = 0, Color = Color.ParseColor("#FFF9C2C3") },
                new GaugeGradientStop() { Value = 100, Color = Color.ParseColor("#FFD91D71") }
            };

            scales.Add(outerScale);
            linearGauge3.Scales = scales;

            linearGauge3.LayoutParameters = (new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, (int)screenHeight / 4));

            //Range Layout
            range3Layout = new LinearLayout(context);
            range3Layout.SetGravity(GravityFlags.Center);
            range3Layout.AddView(linearGauge3);
        }

        private LinearLayout GetView(Context con)
        {
            //Ranges Layout
            LinearLayout rangesLayout = new LinearLayout(con);
            rangesLayout.Orientation = Orientation.Vertical;
            rangesLayout.AddView(range1Layout);
            rangesLayout.AddView(range2Layout);
            rangesLayout.AddView(range3Layout);
            rangesLayout.SetGravity(GravityFlags.Center);

            //Main Layout
            LinearLayout mainLayout = new LinearLayout(con);
            mainLayout.AddView(rangesLayout);
            mainLayout.SetBackgroundColor(Color.White);
            mainLayout.SetGravity(GravityFlags.Center);

            return mainLayout;
        }
    }
}