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

namespace SampleBrowser
{
    public class GradientRange : SamplePage
    {

        public override View GetSampleContent (Context con)
		{
            SfCircularGauge sfCircularGauge = new SfCircularGauge(con);

            ObservableCollection<Header> headers = new ObservableCollection<Header>();
            Header header = new Header();
            header.Text = "0";
            header.TextSize = 20;
            header.TextColor = Color.ParseColor("#F03E3E");
            header.Position = new PointF((float)0.28, (float)0.86);
            headers.Add(header);

            Header header1 = new Header();
            header1.Text = "100";
            header1.TextSize = 20;
            header1.TextColor = Color.ParseColor("#30B32D");
            header1.Position = new PointF((float)0.75, (float)0.86);
            headers.Add(header1);

            Header header2 = new Header();
            header2.Text = "55%";
            header2.TextSize = 20;
            header2.TextColor = Color.ParseColor("#F03E3E");
            header2.Position = new PointF((float)0.5, (float)0.5);
            headers.Add(header2);
            sfCircularGauge.Headers = headers;

            ObservableCollection<CircularScale> circularScales = new ObservableCollection<CircularScale>();
            CircularScale scale = new CircularScale();
            scale.StartValue = 0;
            scale.EndValue = 100;
            scale.Interval = 10;
            scale.ShowRim = false;
            scale.ShowTicks = false;
            scale.ShowLabels = false;

            ObservableCollection<CircularRange> ranges = new ObservableCollection<CircularRange>();
            CircularRange circularRange = new CircularRange();
            circularRange.Offset = 0.8;
            circularRange.StartValue = 0;
            circularRange.EndValue = 100;
            circularRange.Width = 25;

            ObservableCollection<GaugeGradientStop> gradients = new ObservableCollection<GaugeGradientStop>();
            GaugeGradientStop gaugeGradientStop = new GaugeGradientStop();
            gaugeGradientStop.Value = 0;
            gaugeGradientStop.Color = Color.ParseColor("#F03E3E");
            gradients.Add(gaugeGradientStop);
            GaugeGradientStop gaugeGradientStop1 = new GaugeGradientStop();
            gaugeGradientStop1.Value = 35;
            gaugeGradientStop1.Color = Color.ParseColor("#FFDD00");
            gradients.Add(gaugeGradientStop1);
            GaugeGradientStop gaugeGradientStop2 = new GaugeGradientStop();
            gaugeGradientStop2.Value = 75;
            gaugeGradientStop2.Color = Color.ParseColor("#FFDD00");
            gradients.Add(gaugeGradientStop2);
            GaugeGradientStop gaugeGradientStop3 = new GaugeGradientStop();
            gaugeGradientStop3.Value = 100;
            gaugeGradientStop3.Color = Color.ParseColor("#30B32D");
            gradients.Add(gaugeGradientStop3);
            circularRange.GradientStops = gradients;
            ranges.Add(circularRange);
            scale.CircularRanges = ranges;

            ObservableCollection<CircularPointer> pointers = new ObservableCollection<CircularPointer>();
            MarkerPointer markerPointer = new MarkerPointer();
            markerPointer.MarkerShape = Com.Syncfusion.Gauges.SfCircularGauge.Enums.MarkerShape.InvertedTriangle;
            markerPointer.Offset = 0.8;
            markerPointer.MarkerHeight = 15;
            markerPointer.MarkerWidth = 15;
            markerPointer.Value = 55;
            markerPointer.Color = Color.Red;
            pointers.Add(markerPointer);

            scale.CircularPointers = pointers;
            circularScales.Add(scale);
            sfCircularGauge.CircularScales = circularScales;

            sfCircularGauge.SetBackgroundColor(Color.White);

            LinearLayout linearLayout = new LinearLayout(con);
            linearLayout.AddView(sfCircularGauge);
            linearLayout.SetPadding(30, 30, 30, 30);
            linearLayout.SetBackgroundColor(Color.White);
            return linearLayout;
		}
	}
}
