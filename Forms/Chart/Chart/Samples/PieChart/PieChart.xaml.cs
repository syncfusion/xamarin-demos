#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Globalization;
using System.Linq;

namespace SampleBrowser.SfChart
{
	public partial class PieChart : SampleView
	{
		public PieChart()
		{
			InitializeComponent();

            if (Device.RuntimePlatform == Device.macOS || Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WPF)
            {
                Chart.Legend.OverflowMode = ChartLegendOverflowMode.Scroll;
            }

            slider.MaximumTrackColor = Color.LightBlue;
            slider.MinimumTrackColor = Color.Blue;

            groupMode.SelectedIndex = 0;
            groupMode.SelectedIndexChanged += GroupMode_SelectedIndexChanged;
            slider.ValueChanged += Slider_ValueChanged;
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            groupTo.Text = "GroupTo Value is " + ((int)e.NewValue).ToString();
            pieSeries.GroupTo = (int)e.NewValue;
        }

        private void GroupMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(groupMode.SelectedIndex)
            {
                case 0:
                    pieSeries.GroupMode = PieGroupMode.Value;
                    break;
                case 1:
                    pieSeries.GroupMode = PieGroupMode.Percentage;
                    break;
                case 2:
                    pieSeries.GroupMode = PieGroupMode.Angle;
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
                        Chart.Legend.OverflowMode = ChartLegendOverflowMode.Wrap;
                        Chart.Legend.DockPosition = LegendPlacement.Bottom;
                    }
                    else
                    {
                        Chart.Legend.DockPosition = LegendPlacement.Right;
                        Chart.Legend.OverflowMode = ChartLegendOverflowMode.Scroll;
                    }
                }
            }
        }
    }
    public class DataMarkerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null && parameter.ToString() == "Label")
            {
                if (value is List<object>)
                {
                    return "Others";
                }
                else
                {
                    if (value != null)
                    {
                        return (value as ChartDataModel).Name;
                    }
                }
            }
            else
            {
                if (value is List<object>)
                {
                    return (value as List<object>).Sum(item => (item as ChartDataModel).Value).ToString() + "%";
                }
                else
                {
                    if (value != null)
                    {
                        return (value as ChartDataModel).Value + "%";
                    }
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
