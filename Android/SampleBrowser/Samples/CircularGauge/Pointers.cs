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
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Gauges.SfCircularGauge;
using System.Collections.ObjectModel;
using Android.Graphics;
using Com.Syncfusion.Gauges.SfCircularGauge.Enums;
using Android.Renderscripts;
using static Android.App.ActionBar;

namespace SampleBrowser
{
    public class Pointers : SamplePage
    {
        public override View GetSampleContent(Context con)
        {
            SfCircularGauge sfCircularGauge = new SfCircularGauge(con);

            ObservableCollection<Header> headers = new ObservableCollection<Header>();
            Header header = new Header();
            header.Text = "Inverted Traingle";
            header.TextSize = 18;
            header.TextColor = Color.Black;
            header.Position = new PointF((float)0.5, (float)0.6);
            headers.Add(header);
            sfCircularGauge.Headers = headers;

            ObservableCollection<CircularScale> circularScales = new ObservableCollection<CircularScale>();
            CircularScale scale = new CircularScale();
            scale.StartAngle = 180;
            scale.SweepAngle = 180;
            scale.ScaleStartOffset = 0.7;
            scale.ScaleEndOffset = 0.68;
            scale.StartValue = 0;
            scale.EndValue = 100;
            scale.RimColor = Color.Gray;
            scale.Interval = 50;
            scale.ShowLabels = false;
            scale.ShowTicks = false;
            scale.MinorTicksPerInterval = 0;

            ObservableCollection<CircularPointer> pointers = new ObservableCollection<CircularPointer>();
            MarkerPointer markerPointer = new MarkerPointer();
            markerPointer.Value = 80;
            markerPointer.Color = Color.ParseColor("#00bdae");
            markerPointer.Offset = 0.7;
            markerPointer.MarkerShape = Com.Syncfusion.Gauges.SfCircularGauge.Enums.MarkerShape.InvertedTriangle;
            pointers.Add(markerPointer);

            scale.CircularPointers = pointers;
            circularScales.Add(scale);

            sfCircularGauge.CircularScales = circularScales;

            sfCircularGauge.SetBackgroundColor(Color.White);
            //triangle

            SfCircularGauge sfCircularGauge1 = new SfCircularGauge(con);

            ObservableCollection<Header> headers1 = new ObservableCollection<Header>();
            Header header1 = new Header();
            header1.Text = "Traingle";
            header1.TextSize = 18;
            header1.TextColor = Color.Black;
            header1.Position = new PointF((float)0.5, (float)0.6);
            headers1.Add(header1);
            sfCircularGauge1.Headers = headers1;

            ObservableCollection<CircularScale> circularScales1 = new ObservableCollection<CircularScale>();
            CircularScale scale1 = new CircularScale();
            scale1.StartAngle = 180;
            scale1.SweepAngle = 180;
            scale1.ScaleStartOffset = 0.7;
            scale1.ScaleEndOffset = 0.68;
            scale1.StartValue = 0;
            scale1.EndValue = 100;
            scale1.RimColor = Color.Gray;
            scale1.Interval = 50;
            scale1.ShowLabels = false;
            scale1.ShowTicks = false;
            scale1.MinorTicksPerInterval = 0;

            ObservableCollection<CircularPointer> pointers1 = new ObservableCollection<CircularPointer>();
            MarkerPointer markerPointer1 = new MarkerPointer();
            markerPointer1.Value = 80;
            markerPointer1.Color = Color.Green;
            markerPointer1.Offset = 0.68;
            markerPointer1.MarkerShape = Com.Syncfusion.Gauges.SfCircularGauge.Enums.MarkerShape.Triangle;
            pointers1.Add(markerPointer1);

            scale1.CircularPointers = pointers1;
            circularScales1.Add(scale1);

            sfCircularGauge1.CircularScales = circularScales1;

            sfCircularGauge1.SetBackgroundColor(Color.White);

            //range pointer

            SfCircularGauge sfCircularGauge2 = new SfCircularGauge(con);

            ObservableCollection<Header> headers2 = new ObservableCollection<Header>();
            Header header2 = new Header();
            header2.Text = "Range Pointer";
            header2.TextSize = 18;
            header2.TextColor = Color.Black;
            header2.Position = new PointF((float)0.5, (float)0.6);
            headers2.Add(header2);
            sfCircularGauge2.Headers = headers2;

            ObservableCollection<CircularScale> circularScales2 = new ObservableCollection<CircularScale>();
            CircularScale scale2 = new CircularScale();
            scale2.StartAngle = 180;
            scale2.SweepAngle = 180;
            scale2.StartValue = 0;
            scale2.EndValue = 100;
            scale2.RadiusFactor = 0.7;
            scale2.RimColor = Color.Gray;
            scale2.Interval = 50;
            scale2.ShowLabels = false;
            scale2.ShowTicks = false;
            scale2.RimWidth = 3;
            scale2.MinorTicksPerInterval = 0;

            ObservableCollection<CircularPointer> pointers2 = new ObservableCollection<CircularPointer>();
            RangePointer rangePointer = new RangePointer();
            rangePointer.Value = 60;
            rangePointer.Color = Color.ParseColor("#FF2680");
            rangePointer.Offset = 0.6;
            rangePointer.Width = 20;
            rangePointer.EnableAnimation = false;
            pointers2.Add(rangePointer);

            scale2.CircularPointers = pointers2;
            circularScales2.Add(scale2);

            sfCircularGauge2.CircularScales = circularScales2;

            sfCircularGauge2.SetBackgroundColor(Color.White);

            //needlepointer

            SfCircularGauge sfCircularGauge3 = new SfCircularGauge(con);

            ObservableCollection<Header> headers3 = new ObservableCollection<Header>();
            Header header3 = new Header();
            header3.Text = "Needle Pointer";
            header3.TextSize = 18;
            header3.TextColor = Color.Black;
            header3.Position = new PointF((float)0.5, (float)0.6);
            headers3.Add(header3);
            sfCircularGauge3.Headers = headers3;

            ObservableCollection<CircularScale> circularScales3 = new ObservableCollection<CircularScale>();
            CircularScale scale3 = new CircularScale();
            scale3.StartAngle = 180;
            scale3.SweepAngle = 180;
            scale3.StartValue = 0;
            scale3.EndValue = 100;
            scale3.RadiusFactor = 0.7;
            scale3.RimColor = Color.Gray;
            scale3.Interval = 50;
            scale3.ShowLabels = false;
            scale3.ShowTicks = false;
            scale3.RimWidth = 3;
            scale3.MinorTicksPerInterval = 0;

            ObservableCollection<CircularPointer> pointers3 = new ObservableCollection<CircularPointer>();
            NeedlePointer needlePointer = new NeedlePointer();
            needlePointer.Value = 80;
            needlePointer.Color = Color.Purple;
            needlePointer.LengthFactor = 0.7;
            needlePointer.KnobRadius = 0;
            needlePointer.Width = 10;
            needlePointer.Type = NeedleType.Triangle;
            pointers3.Add(needlePointer);

            scale3.CircularPointers = pointers3;
            circularScales3.Add(scale3);

            sfCircularGauge3.CircularScales = circularScales3;

            sfCircularGauge3.SetBackgroundColor(Color.White);

            SfCircularGauge sfCircularGauge4 = new SfCircularGauge(con);

            ObservableCollection<Header> headers4 = new ObservableCollection<Header>();
            Header header4 = new Header();
            header4.Text = "Multiple Needle";
            header4.TextSize = 18;
            header4.TextColor = Color.Black;
            header4.Position = new PointF((float)0.5, (float)0.7);
            headers4.Add(header4);
            sfCircularGauge4.Headers = headers4;

            ObservableCollection<CircularScale> circularScales4 = new ObservableCollection<CircularScale>();
            CircularScale scale4 = new CircularScale();
            scale4.StartAngle = 180;
            scale4.SweepAngle = 180;
            scale4.StartValue = 0;
            scale4.EndValue = 100;
            scale4.RadiusFactor = 0.7;
            scale4.RimColor = Color.Gray;
            scale4.Interval = 50;
            scale4.ShowLabels = false;
            scale4.ShowTicks = false;
            scale4.RimWidth = 3;
            scale4.MinorTicksPerInterval = 0;

            ObservableCollection<CircularPointer> pointers4 = new ObservableCollection<CircularPointer>();
            NeedlePointer needlePointer1 = new NeedlePointer();
            needlePointer1.Value = 40;
            needlePointer1.Color = Color.ParseColor("#ed7d31");
            needlePointer1.LengthFactor = 0.5;
            needlePointer1.KnobRadiusFactor = 0.05;
            needlePointer1.KnobColor = Color.White;
            needlePointer1.Width = 10;
            needlePointer1.Type = NeedleType.Triangle;
            needlePointer1.TailStrokeColor = Color.ParseColor("#ed7d31");
            needlePointer1.KnobStrokeWidth = 2;
            needlePointer1.KnobStrokeColor = Color.ParseColor("#ed7d31");
            pointers4.Add(needlePointer1);

            NeedlePointer needlePointer2 = new NeedlePointer();
            needlePointer2.Value = 70;
            needlePointer2.Color = Color.ParseColor("#ed7d31");
            needlePointer2.LengthFactor = 0.6;
            needlePointer2.KnobRadiusFactor = 0.05;
            needlePointer2.KnobColor = Color.White;
            needlePointer2.Width = 10;
            needlePointer2.Type = NeedleType.Triangle;
            needlePointer2.TailStrokeColor = Color.ParseColor("#ed7d31");
            needlePointer2.KnobStrokeWidth = 2;
            needlePointer2.KnobStrokeColor = Color.ParseColor("#ed7d31");
            pointers4.Add(needlePointer2);

            scale4.CircularPointers = pointers4;
            circularScales4.Add(scale4);

            sfCircularGauge4.CircularScales = circularScales4;

            sfCircularGauge4.SetBackgroundColor(Color.White);

            LinearLayout linearLayout = new LinearLayout(con);
            linearLayout.Orientation = Orientation.Vertical;
            linearLayout.LayoutParameters = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
            linearLayout.AddView(sfCircularGauge, LayoutParams.WrapContent, (int)(250 * con.Resources.DisplayMetrics.Density));
            linearLayout.AddView(sfCircularGauge1, LayoutParams.WrapContent, (int)(250 * con.Resources.DisplayMetrics.Density));
            linearLayout.AddView(sfCircularGauge2, LayoutParams.WrapContent, (int)(250 * con.Resources.DisplayMetrics.Density));
            linearLayout.AddView(sfCircularGauge3, LayoutParams.WrapContent, (int)(250 * con.Resources.DisplayMetrics.Density));
            linearLayout.AddView(sfCircularGauge4, LayoutParams.WrapContent, (int)(250 * con.Resources.DisplayMetrics.Density));

            linearLayout.SetPadding(30, 30, 30, 30);
            ScrollView mainView = new ScrollView(con);
            mainView.AddView(linearLayout);
            return mainView;
        }
	}
}
