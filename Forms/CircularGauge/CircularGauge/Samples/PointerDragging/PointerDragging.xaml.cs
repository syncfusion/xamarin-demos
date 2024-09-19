#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfGauge.XForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;


namespace SampleBrowser.SfCircularGauge
{
    [Preserve(AllMembers = true)]
    public partial class PointerDragging : SampleView
    {

        public PointerDragging()
        {
            InitializeComponent();
            header.Text = "08"+ " h" + " 00" + " min";
        }

        private void Pointer2_ValueChanging(object sender, Syncfusion.SfGauge.XForms.PointerValueChangingEventArgs e)
        {
            var context = (sender as MarkerPointer).BindingContext as PointerViewModel;
            if (e.NewValue <= context.FirstMarkerValue || Math.Abs(e.NewValue - context.SecondMarkerValue) > (1 + pointer2.StepFrequency))
            {
                e.Cancel = true;
            }
        }

        private void Pointer1_ValueChanging(object sender, Syncfusion.SfGauge.XForms.PointerValueChangingEventArgs e)
        {
            var context = (sender as MarkerPointer).BindingContext as PointerViewModel;
            if (e.NewValue >= context.SecondMarkerValue || Math.Abs(e.NewValue - context.FirstMarkerValue) > (1 + pointer1.StepFrequency))
            {
                e.Cancel = true;
            }
        }

        private void Pointer1_ValueChanged(object sender, Syncfusion.SfGauge.XForms.PointerValueChangedEventArgs e)
        {
            var context = (sender as Syncfusion.SfGauge.XForms.MarkerPointer).BindingContext as PointerViewModel;
            context.FirstMarkerValue = e.Value;
            double value = Math.Abs(context.FirstMarkerValue - context.SecondMarkerValue);
            CalculateTimeDifference(value);
        }

        private void Pointer2_ValueChanged(object sender, Syncfusion.SfGauge.XForms.PointerValueChangedEventArgs e)
        {
            var context = (sender as Syncfusion.SfGauge.XForms.MarkerPointer).BindingContext as PointerViewModel;
            context.SecondMarkerValue = e.Value;
            double value = Math.Abs(context.SecondMarkerValue - pointer1.Value);
            CalculateTimeDifference(value);
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

        private void gauge_SizeChanged(object sender, EventArgs e)
        {
            var gauge = (sender as Syncfusion.SfGauge.XForms.SfCircularGauge);
            var viewModel = gauge.BindingContext as PointerViewModel;
            var minSize = Math.Min(gauge.Bounds.Width, gauge.Bounds.Height);
            var radius = minSize / 2;
            var scale = gauge.Scales[0];
            viewModel.PointerSize = radius * Math.Abs (scale.ScaleEndOffset - scale.ScaleStartOffset);
        }

        private void frequency_slider_ValueChanged(object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            double stepValue = 0.2;

            var newStep = Math.Round(e.NewValue / stepValue);

            (sender as Slider).Value = newStep * stepValue;
        }
    }
}