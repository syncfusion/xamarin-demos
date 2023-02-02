#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Gauges.SfCircularGauge;

namespace SampleBrowser
{
    public class PointerDragging : SamplePage
    {
        MarkerPointer markerPointer1;
        MarkerPointer markerPointer2;
        Header header;
        CircularRange range;
        double firstMarkerValue = 2;
        double secondMarkerValue = 10;
        float deviceDensity;
        TextView stepFrequencyValue;

        public override View GetSampleContent(Context context)
        {
            deviceDensity = context.Resources.DisplayMetrics.Density;
            SfCircularGauge sfCircularGauge = new SfCircularGauge(context);

            ObservableCollection<Header> headers = new ObservableCollection<Header>();

            header = new Header();
            header.Text = "08" + " h" + " 00" + " min";
            header.TextSize = 25;
            header.TextColor = Color.ParseColor("#FF4500");
            header.TextStyle = Typeface.DefaultBold;
            header.Position = new PointF((float)0.5, (float)0.5);
            headers.Add(header);
            sfCircularGauge.Headers = headers;

            ObservableCollection<CircularScale> circularScales = new ObservableCollection<CircularScale>();
            CircularScale scale = new CircularScale();
            scale.StartValue = 0;
            scale.EndValue = 12;
            scale.Interval = 1;
            scale.StartAngle = 270;
            scale.SweepAngle = 360;
            scale.LabelOffset = 0.67;
            scale.ScaleStartOffset = 0.9;
            scale.ScaleEndOffset = 0.8;
            scale.ShowFirstLabel = false;
            scale.MinorTicksPerInterval = 4;
            scale.MajorTickSettings = new TickSetting()
            {
                StartOffset = 0.8,
                EndOffset = 0.72,
                Width = 2,
                Color = Color.DarkGray
            };
            scale.MinorTickSettings = new TickSetting()
            {
                StartOffset = 0.8,
                EndOffset = 0.75
            };

            ObservableCollection<CircularPointer> pointers = new ObservableCollection<CircularPointer>();

            markerPointer1 = new MarkerPointer();
            markerPointer1.EnableDragging = true;
            markerPointer1.EnableAnimation = false;
            markerPointer1.Value = firstMarkerValue;
            markerPointer1.Color = Color.ParseColor("#F7CE72");
            markerPointer1.Offset = 0.9;
            markerPointer1.MarkerShape = Com.Syncfusion.Gauges.SfCircularGauge.Enums.MarkerShape.Circle;
            markerPointer1.ValueChanging += MarkerPointer1_ValueChanging;
            markerPointer1.PointerPositionChangedEvent += MarkerPointer1_PointerPositionChangedEvent;
            pointers.Add(markerPointer1);

            markerPointer2 = new MarkerPointer();
            markerPointer2.EnableDragging = true;
            markerPointer2.EnableAnimation = false;
            markerPointer2.Value = secondMarkerValue;
            markerPointer2.Color = Color.ParseColor("#F7CE72");
            markerPointer2.Offset = 0.9;
            markerPointer2.MarkerShape = Com.Syncfusion.Gauges.SfCircularGauge.Enums.MarkerShape.Circle;
            markerPointer2.ValueChanging += MarkerPointer2_ValueChanging;
            markerPointer2.PointerPositionChangedEvent += MarkerPointer2_PointerPositionChangedEvent;
            pointers.Add(markerPointer2);

            markerPointer2.StepFrequency = markerPointer1.StepFrequency = 0.2;

            range = new CircularRange();
            range.StartValue = markerPointer1.Value;
            range.EndValue = markerPointer2.Value;
            range.InnerStartOffset = 0.8;
            range.InnerEndOffset = 0.8;
            range.OuterStartOffset = 0.9;
            range.OuterEndOffset = 0.9;
            range.Color = Color.ParseColor("#E57982");
            scale.CircularRanges.Add(range);

            scale.CircularPointers = pointers;
            circularScales.Add(scale);

            sfCircularGauge.CircularScales = circularScales;
            sfCircularGauge.SetBackgroundColor(Color.White);

            LinearLayout linearLayout = new LinearLayout(context);
            linearLayout.AddView(sfCircularGauge);
            linearLayout.SetPadding(30, 30, 30, 30);
            linearLayout.SetBackgroundColor(Color.White);
            linearLayout.LayoutChange += LinearLayout_LayoutChange;
            return linearLayout;
        }

        public override View GetPropertyWindowLayout(Context context)
        {
            TextView stepFrequencyText = new TextView(context);
            stepFrequencyText.Text = "Step Frequency : ";
            stepFrequencyText.Typeface = Typeface.DefaultBold;
            stepFrequencyText.SetTextColor(Color.ParseColor("#262626"));
            stepFrequencyText.TextSize = 20;

            stepFrequencyValue = new TextView(context);
            stepFrequencyValue.Text = "0.2";
            stepFrequencyValue.Typeface = Typeface.DefaultBold;
            stepFrequencyValue.SetTextColor(Color.ParseColor("#262626"));
            stepFrequencyValue.TextSize = 20;

            LinearLayout stepFrequencyLayout = new LinearLayout(context);
            stepFrequencyLayout.Orientation = Orientation.Horizontal;
            stepFrequencyLayout.AddView(stepFrequencyText);
            stepFrequencyLayout.AddView(stepFrequencyValue);

            SeekBar stepFrequencySeekBar = new SeekBar(context);
            stepFrequencySeekBar.Min = 0;
            stepFrequencySeekBar.Progress = 1;
            stepFrequencySeekBar.Max = 5;
            stepFrequencySeekBar.ProgressChanged += StepFrequencySeekBar_ProgressChanged;

            LinearLayout optionsPage = new LinearLayout(context);

            optionsPage.Orientation = Orientation.Vertical;
            optionsPage.AddView(stepFrequencyLayout);
            optionsPage.AddView(stepFrequencySeekBar);

            optionsPage.SetPadding(10, 10, 10, 10);
            optionsPage.SetBackgroundColor(Color.White);
            return optionsPage;
        }

        private void StepFrequencySeekBar_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            SeekBar seekBar = sender as SeekBar;
            double value = ((double)e.Progress / 10) * 2;

            markerPointer2.StepFrequency = markerPointer1.StepFrequency = value;
            stepFrequencyValue.Text = value.ToString();
            
        }

        private void LinearLayout_LayoutChange(object sender, View.LayoutChangeEventArgs e)
        {
            var gauge = (sender as LinearLayout).GetChildAt(0) as SfCircularGauge;
            if (gauge == null) return;
            var minSize = Math.Min(gauge.Width, gauge.Height);
            var radius = (float)minSize / 2;
            var scale = gauge.CircularScales[0];
            if (scale != null)
            {
                float pointerSize = (float)(radius * Math.Abs(scale.ScaleStartOffset - scale.ScaleEndOffset));
                pointerSize /= deviceDensity;
                foreach (MarkerPointer pointer in scale.CircularPointers)
                {
                    if (pointer.MarkerHeight != pointerSize)
                        pointer.MarkerHeight = pointerSize;
                    if (pointer.MarkerWidth != pointerSize)
                        pointer.MarkerWidth = pointerSize;
                }
            }
        }

        private void MarkerPointer1_PointerPositionChangedEvent(object sender, CircularPointer.PointerPositionChangedEventArgs e)
        {
            firstMarkerValue = e.P1.PointerValue;
            double value = Math.Abs(firstMarkerValue - secondMarkerValue);
            range.StartValue = firstMarkerValue;
            range.EndValue = secondMarkerValue;
            CalculateTimeDifference(value);
        }

        private void MarkerPointer2_PointerPositionChangedEvent(object sender, CircularPointer.PointerPositionChangedEventArgs e)
        {
            secondMarkerValue = e.P1.PointerValue;
            double value = Math.Abs(secondMarkerValue - markerPointer1.Value);
            range.StartValue = firstMarkerValue;
            range.EndValue = secondMarkerValue;
            CalculateTimeDifference(value);
        }

        private void MarkerPointer2_ValueChanging(object sender, CircularPointer.PointerValueChangingEventArgs e)
        {
            if (e.NewValue <= firstMarkerValue || Math.Abs(e.NewValue - secondMarkerValue) > (1 + markerPointer2.StepFrequency))
            {
                e.Cancel = true;
            }
        }

        private void MarkerPointer1_ValueChanging(object sender, CircularPointer.PointerValueChangingEventArgs e)
        {
            if (e.NewValue >= secondMarkerValue || Math.Abs(e.NewValue - firstMarkerValue) > (1 + markerPointer1.StepFrequency))
            {
                e.Cancel = true;
            }
        }

        private void CalculateTimeDifference(double value)
        {
            int hour = Convert.ToInt32(Math.Floor(value));
            float digit = hour / 10f;
            bool isHourSingleDigit = digit >= 1 ? false : true;

            var min = Math.Floor((value - hour) * 60);
            digit = (float)min / 10f;
            bool isMinuteSingleDigit = digit >= 1 ? false : true;

            string hourValue = isHourSingleDigit ? "0" + hour.ToString() : hour.ToString();
            string minutesValue = isMinuteSingleDigit ? "0" + min.ToString() : min.ToString();
            header.Text = hourValue + " h " + minutesValue + " min";
        }
    }
}