#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfChart
{
    public partial class ChartTrendlines : SampleView
    {
        public ChartTrendlines()
        {
            InitializeComponent();
        }

        private void OnStepper3_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            polynomialLabel.Text = "Polynomial Order: " + e.NewValue;
        }

        private void OnStepper2_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            backwardForecast.Text = "Backward Forecast: " + e.NewValue;
        }      
        
        private void OnStepper1_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            forwardForecast.Text = "Forward Forecast: " + e.NewValue;
        }
    }

    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}