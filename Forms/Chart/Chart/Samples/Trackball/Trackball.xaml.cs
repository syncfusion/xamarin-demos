#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;
using SampleBrowser.Core;

namespace SampleBrowser.SfChart
{
    public partial class Trackball : SampleView
    {
        public Trackball()
        {
            InitializeComponent();
            var data = new TrackballViewModel();

            labelDisplayMode.SelectedIndex = 1;

            labelDisplayMode.SelectedIndexChanged += labelDisplayMode_SelectedIndexChanged;

            trackballTouchMode.SelectedIndex = 0;

            trackballTouchMode.SelectedIndexChanged += trackballTouchMode_SelectedIndexChanged;

            if(Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WPF)
            {
                secondaryAxisLabelStyle.LabelFormat = "0'M '";
            }
            else
            {
                secondaryAxisLabelStyle.LabelFormat = "#'M '";
            }

            if (Device.RuntimePlatform == Device.macOS || Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WPF)
            {
                chart.Legend.OverflowMode = ChartLegendOverflowMode.Scroll;
                label.IsVisible = false;
            }
        }

        void labelDisplayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (labelDisplayMode.SelectedIndex)
            {
                case 0:
                    chartTrackball.LabelDisplayMode = TrackballLabelDisplayMode.NearestPoint;
                    break;
                case 1:
                    chartTrackball.LabelDisplayMode = TrackballLabelDisplayMode.FloatAllPoints;
                    break;
            }
        }

        void trackballTouchMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (trackballTouchMode.SelectedIndex)
            {
                case 0:
                    chartTrackball.ActivationMode = ChartTrackballActivationMode.LongPress;
                    break;
                case 1:
                    chartTrackball.ActivationMode = ChartTrackballActivationMode.TouchMove;
                    break;
                case 2:
                    chartTrackball.ActivationMode = ChartTrackballActivationMode.None;
                    break;
            }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if ((Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS))
            {
                if (height > 0 && width > 0)
                {
                    if (height > width)
                    {
                        chart.Legend.DockPosition = LegendPlacement.Top;
                    }
                    else
                    {
                        chart.Legend.DockPosition = LegendPlacement.Right;
                    }
                }
            }
        }
    }

    public class StringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.ToString() + "%";
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string Value = value.ToString();
            int result;
            if (int.TryParse(Value, out result))
                return result;
            return value;
        }

    }
}