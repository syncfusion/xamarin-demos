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
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Gauges.SfLinearGauge;

namespace SampleBrowser
{
    public class Annotations : SamplePage
    {
        public static int pointervalue = 35;

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

            var density = con.Resources.DisplayMetrics.Density;

            //OuterScale
            LinearScale outerScale = new LinearScale();
            outerScale.Minimum = 0;
            outerScale.Maximum = 90;
            outerScale.ShowLabels = false;
            outerScale.ScaleBarColor = Color.Transparent;
            outerScale.Offset = -50;
            outerScale.MinorTicksPerInterval = 1;
            outerScale.ScaleBarSize = 13;
            outerScale.ScaleDirection = LinearScaleDirection.Backward;

            //OuterScale MajorTicksSettings
            LinearTickSettings outerScale_majorTicksSettings = new LinearTickSettings();
            outerScale_majorTicksSettings.Color = Color.Transparent;
            outerScale_majorTicksSettings.Length = 0;
            outerScale_majorTicksSettings.StrokeWidth = 1;
            outerScale.MajorTickSettings = outerScale_majorTicksSettings;

            //OuterScale MinorTicksSettings
            LinearTickSettings outerScale_minorTicksSettings = new LinearTickSettings();
            outerScale_minorTicksSettings.Color = Color.Transparent;
            outerScale_minorTicksSettings.Length = 0;
            outerScale_minorTicksSettings.StrokeWidth = 1;
            outerScale.MinorTickSettings = outerScale_minorTicksSettings;

            //Symbol Pointer
            SymbolPointer outerScale_needlePointer = new SymbolPointer();
            outerScale_needlePointer.Value = pointervalue;
            outerScale_needlePointer.StrokeWidth = 12;
            outerScale_needlePointer.Color = Color.Red;
            outerScale_needlePointer.MarkerShape = MarkerShape.InvertedTriangle;
            pointers.Add(outerScale_needlePointer);
            outerScale.Pointers = pointers;

            //Symbol Range
            LinearRange range = new LinearRange();
            range.StartWidth = 60;
            range.EndWidth = 60;
            range.Color = Color.ParseColor("#30b32d");
            range.StartValue = 0;
            range.EndValue = 30;
            ranges.Add(range);

            //Symbol Range1
            LinearRange range1 = new LinearRange();
            range1.StartWidth = 60;
            range1.EndWidth = 60;
            range1.Color = Color.ParseColor("#ffdd00");
            range1.StartValue = 30;
            range1.EndValue = 60;
            ranges.Add(range1);

            //Symbol Range2
            LinearRange range2 = new LinearRange();
            range2.StartWidth = 60;
            range2.EndWidth = 60;
            range2.Color = Color.ParseColor("#f03e3e");
            range2.StartValue = 60;
            range2.EndValue = 90;
            ranges.Add(range2);
            outerScale.Ranges = ranges;

            scales.Add(outerScale);
            linearGauge.Scales = scales;

            //Annotation
            LinearGaugeAnnotation annotation = new LinearGaugeAnnotation();
            annotation.ScaleValue = 15;
            annotation.ViewMargin = new PointF(0, 30);
            ImageView imageView = new ImageView(con);
            imageView.SetImageResource(Resource.Drawable.Low);
            LinearLayout layout = new LinearLayout(con);
            layout.LayoutParameters = new LinearLayout.LayoutParams((int)(80 * density), 60);
            layout.SetGravity(GravityFlags.Center);
            layout.AddView(imageView);
            annotation.View = layout;
            linearGauge.Annotations.Add(annotation);

            //Annotation1
            LinearGaugeAnnotation annotation1 = new LinearGaugeAnnotation();
            annotation1.ScaleValue = 45;
            annotation1.ViewMargin = new PointF(0, 30);
            ImageView imageView1 = new ImageView(con);
            imageView1.SetImageResource(Resource.Drawable.Moderate);
            LinearLayout layout1 = new LinearLayout(con);
            layout1.LayoutParameters = new LinearLayout.LayoutParams((int)(80 * density), 60);
            layout1.SetGravity(GravityFlags.Center);
            layout1.AddView(imageView1);
            annotation1.View = layout1;
            linearGauge.Annotations.Add(annotation1);

            //Annotation2
            LinearGaugeAnnotation annotation2 = new LinearGaugeAnnotation();
            annotation2.ScaleValue = 75;
            annotation2.ViewMargin = new PointF(0, 30);
            ImageView imageView2 = new ImageView(con);
            imageView2.SetImageResource(Resource.Drawable.High);
            LinearLayout layout2 = new LinearLayout(con);
            layout2.LayoutParameters = new LinearLayout.LayoutParams((int)(80 * density), 60);
            layout2.SetGravity(GravityFlags.Center);
            layout2.AddView(imageView2);
            annotation2.View = layout2;
            linearGauge.Annotations.Add(annotation2);

            //Annotation3
            LinearGaugeAnnotation annotation3 = new LinearGaugeAnnotation();
            annotation3.ScaleValue = 15;
            annotation3.ViewMargin = new PointF(0, 80);
            TextView text = new TextView(con);
            text.Text = "Low";
            text.SetTextColor(Color.ParseColor("#30b32d"));
            LinearLayout layout3 = new LinearLayout(con);
            layout3.LayoutParameters = new LinearLayout.LayoutParams((int)(60 * density), 60);
            layout3.SetGravity(GravityFlags.Center);
            layout3.AddView(text);
            annotation3.View = layout3;
            linearGauge.Annotations.Add(annotation3);

            //Annotation4
            LinearGaugeAnnotation annotation4 = new LinearGaugeAnnotation();
            annotation4.ScaleValue = 45;
            annotation4.ViewMargin = new PointF(0, 80);
            TextView text1 = new TextView(con);
            text1.Text = "Moderate";
            text1.SetTextColor(Color.ParseColor("#ffdd00"));
            LinearLayout layout4 = new LinearLayout(con);
            layout4.LayoutParameters = new LinearLayout.LayoutParams((int)(90 * density), 60);
            layout4.SetGravity(GravityFlags.Center);
            layout4.AddView(text1);
            annotation4.View = layout4;
            linearGauge.Annotations.Add(annotation4);

            //Annotation5
            LinearGaugeAnnotation annotation5 = new LinearGaugeAnnotation();
            annotation5.ScaleValue = 75;
            annotation5.ViewMargin = new PointF(0, 80);
            TextView text2 = new TextView(con);
            text2.Text = "High";
            text2.SetTextColor(Color.ParseColor("#f03e3e"));
            LinearLayout layout5 = new LinearLayout(con);
            layout5.LayoutParameters = new LinearLayout.LayoutParams((int)(60 * density), 60);
            layout5.SetGravity(GravityFlags.Center);
            layout5.AddView(text2);
            annotation5.View = layout5;
            linearGauge.Annotations.Add(annotation5);

            //Annotation6
            LinearGaugeAnnotation annotation6 = new LinearGaugeAnnotation();
            annotation6.ScaleValue = 45;
            annotation6.ViewMargin = new PointF(0, -50);
            LinearLayout layout6 = new LinearLayout(con);
            layout6.LayoutParameters = new LinearLayout.LayoutParams((int)(200 * density), 100);
            layout6.SetGravity(GravityFlags.Center);
            layout6.AddView(new TextView(con) { Text = "CPU Utilization", TextSize = 20 });
            annotation6.View = layout6;
            linearGauge.Annotations.Add(annotation6);

     

            //Main Gauge Layout
            LinearLayout mainLinearGaugeLayout = new LinearLayout(con);
            mainLinearGaugeLayout.Orientation = Android.Widget.Orientation.Vertical;
            mainLinearGaugeLayout.SetBackgroundColor(Color.Rgb(255, 255, 255));
            mainLinearGaugeLayout.SetGravity((GravityFlags)17);

            //Linear Gauge Layout
            LinearLayout linearGaugeLayout = new LinearLayout(con);
            linearGaugeLayout.SetGravity((GravityFlags)17);
            linearGaugeLayout.SetBackgroundColor(Color.Rgb(255, 255, 255));
            mainLinearGaugeLayout.AddView(linearGaugeLayout);
            mainLinearGaugeLayout.AddView(linearGauge);

            return mainLinearGaugeLayout;
        }
    }
}
 
