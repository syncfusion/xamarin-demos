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
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace SampleBrowser.SfChart
{
    public partial class HistogramChart : SampleView
    {
        public HistogramChart()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.WPF)
            {
                Chart.ChartPadding = new Thickness(0, 0, 0, 10);
            }
        }
    }

    public class TooltipConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is List<object>)
            {
                return (value as List<object>).Count.ToString();
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }       
    }

    public class TooltipLabelConverter : IValueConverter
    {
        int interval = 20;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is List<object>)
            {
                var data = value as List<object>;
                int x = 0;
                int index = (int)(data[0] as ChartDataModel).Value / interval;
                x = interval * index;
                string text = x.ToString() + "-" + (x + interval).ToString() + " : ";

                return text;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}