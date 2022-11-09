#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using CoreGraphics;
using Foundation;
using Syncfusion.SfGauge.iOS;
using UIKit;

namespace SampleBrowser
{
    public class PointerDragging : SampleView
    {
        UISlider slider;
        UIView option = new UIView();
        SFCircularGauge gauge;
        SFMarkerPointer markerPointer1;
        SFMarkerPointer markerPointer2;
        SFGaugeHeader header;
        SFCircularRange range;
        float firstMarkerValue = 2;
        float secondMarkerValue = 10;

        

        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public override void LayoutSubviews()
        {
            foreach (var view in this.Subviews)
            {
                view.Frame = Bounds;
            }

            if (Utility.IsIPad)
            {
                gauge.Frame = new CGRect(50, 50, (float)this.Frame.Width - 100, (float)this.Frame.Height - 100);
            }
            else
            {
                gauge.Frame = new CGRect(10, 10, (float)this.Frame.Width - 20, (float)this.Frame.Height - 20);

            }
            

            var minSize = Math.Min(gauge.Bounds.Width, gauge.Bounds.Height);
            var radius = (float)minSize / 2;
            var scale = gauge.Scales[0];
            if (scale != null)
            {
                float pointerSize = radius * Math.Abs(scale.ScaleStartOffset - scale.ScaleEndOffSet);
                foreach (SFMarkerPointer pointer in scale.Pointers)
                {
                    pointer.MarkerHeight = pointerSize;
                    pointer.MarkerWidth = pointerSize;
                }
            }

            base.LayoutSubviews();
        }

        public PointerDragging()
        {
            gauge = new SFCircularGauge();

            header = new SFGaugeHeader();
            header.Position = new CGPoint(0.5, 0.5);
            header.TextStyle = UIFont.FromName("Helvetica", 25f);
            header.TextColor = UIColor.FromRGB(255, 69, 0);
            header.Text = (NSString)("08" + " h" + " 00" + " min");
            gauge.Headers.Add(header);

            SFCircularScale scale = new SFCircularScale();
            scale.StartValue = 0;
            scale.EndValue = 12;
            scale.StartAngle = 180;
            scale.SweepAngle = 540;
            scale.Interval = 1;
            scale.LabelOffset = 0.67f;
            scale.ShowFirstLabel = false;
            scale.ScaleStartOffset = 0.9f;
            scale.ScaleEndOffSet = 0.8f;
            scale.MinorTicksPerInterval = 4;

            SFTickSettings majorTickSetting = new SFTickSettings();
            majorTickSetting.StartOffset = 0.8f;
            majorTickSetting.EndOffset = 0.72f;
            majorTickSetting.Width = 2;
            majorTickSetting.Color = UIColor.DarkGray;

            SFTickSettings minorTickSetting = new SFTickSettings();
            minorTickSetting.StartOffset = 0.8f;
            minorTickSetting.EndOffset = 0.75f;

            scale.MajorTickSettings = majorTickSetting;
            scale.MinorTickSettings = minorTickSetting;

            markerPointer1 = new SFMarkerPointer();
            markerPointer1.EnableAnimation = false;
            markerPointer1.EnableDragging = true;
            markerPointer1.Offset = 0.9f;
            markerPointer1.Value = firstMarkerValue;
            markerPointer1.MarkerShape = MarkerShape.Circle;
            markerPointer1.Color = UIColor.FromRGB(247, 206, 114);
            markerPointer1.ValueChanging += MarkerPointer1_ValueChanging;
            
            markerPointer2 = new SFMarkerPointer();
            markerPointer2.EnableAnimation = false;
            markerPointer2.EnableDragging = true;
            markerPointer2.Offset = 0.9f;
            markerPointer2.Value = secondMarkerValue;
            markerPointer2.MarkerShape = MarkerShape.Circle;
            markerPointer2.Color = UIColor.FromRGB(247, 206, 114);
            markerPointer2.ValueChanging += MarkerPointer2_ValueChanging; ;
            scale.Pointers.Add(markerPointer1);
            scale.Pointers.Add(markerPointer2);

            markerPointer2.StepFrequency = markerPointer1.StepFrequency = 0.2;

            range = new SFCircularRange();
            range.StartValue = markerPointer1.Value;
            range.EndValue = markerPointer2.Value;
            range.InnerEndOffset = 0.8f;
            range.InnerStartOffset = 0.8f;
            range.OuterEndOffset = 0.9f;
            range.OuterStartOffset = 0.9f;
            range.Color = UIColor.FromRGB(229, 121, 130);

            gauge.PointerPositionChange += Gauge_PointerPositionChange;

            scale.Ranges.Add(range);
            gauge.Scales.Add(scale);
            this.AddSubview(gauge);
            CreateOptionView();
            this.OptionView = option;
        }

        private void Gauge_PointerPositionChange(object sender, GaugeEventArgs e)
        {
            var index = e.PointerPosition.PointerIndex;
            double value;
            if (index == 0)
            {
                firstMarkerValue = (float)e.PointerPosition.PointerValue;
                value = Math.Abs(firstMarkerValue - secondMarkerValue);
            }
            else
            {
                secondMarkerValue = (float)e.PointerPosition.PointerValue;
                value = Math.Abs(secondMarkerValue - markerPointer1.Value);
            }

            range.StartValue = firstMarkerValue;
            range.EndValue = secondMarkerValue;
            CalculateTimeDifference(value);
        }

        private void MarkerPointer2_ValueChanging(object sender, SFCircularPointer.PointerValueChangingEventArgs e)
        {
            if ((e.NewValue) <= firstMarkerValue || Math.Abs(e.NewValue - secondMarkerValue) > 1)
                e.Cancel = true;
        }

        private void MarkerPointer1_ValueChanging(object sender, SFCircularPointer.PointerValueChangingEventArgs e)
        {
            if ((e.NewValue) >= secondMarkerValue || Math.Abs(e.NewValue - firstMarkerValue) > 1)
                e.Cancel = true;
        }

        private void CreateOptionView()
        {
            UILabel stepFrequencyText = new UILabel();
            stepFrequencyText.Frame = new CGRect(10, 25, 150, 40);
            stepFrequencyText.Text = "Step Frequency : ";
            stepFrequencyText.Font = UIFont.BoldSystemFontOfSize(16);
            stepFrequencyText.TextColor = UIColor.FromRGB(0, 0, 0);

            UILabel stepFrequencyValue = new UILabel();
            stepFrequencyValue.Frame = new CGRect(170, 25, 100, 40);
            stepFrequencyValue.Text = "0.2";
            stepFrequencyValue.Font = UIFont.BoldSystemFontOfSize(16);
            stepFrequencyValue.TextColor = UIColor.FromRGB(0, 0, 0);

            slider = new UISlider();
            slider.Frame = new CGRect(10, 80, 250, 60);
            slider.MinValue = 0f;
            slider.MaxValue = 1f;
            slider.Value = 0.2f;
            slider.ValueChanged += (object sender, EventArgs e) =>
            {
                slider.Value = (float) (Math.Round(slider.Value / 0.2f) * 0.2f);
                markerPointer1.StepFrequency = markerPointer2.StepFrequency = slider.Value;
                stepFrequencyValue.Text = slider.Value.ToString();
            };
           
            this.option.AddSubview(stepFrequencyText);
            this.option.AddSubview(stepFrequencyValue);
            this.option.AddSubview(slider);
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
            header.Text = (NSString)(hourValue + " h " + minutesValue + " min");
        }
    }
}
