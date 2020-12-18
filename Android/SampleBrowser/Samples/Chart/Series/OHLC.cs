#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Com.Syncfusion.Charts;

namespace SampleBrowser
{
    public class OHLC : SamplePage
    {
        public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);
            chart.SetBackgroundColor(Color.White);
            chart.Title.Text = "Financial Analysis";
            chart.Title.TextSize = 15;

            DateTimeAxis dateTimeAxis = new DateTimeAxis();
            dateTimeAxis.LabelStyle.LabelFormat = "MM/dd/yyyy";
            dateTimeAxis.LabelRotationAngle = -45;
            dateTimeAxis.Title.Text = "Date";
            chart.PrimaryAxis = dateTimeAxis;

            NumericalAxis numericalAxis = new NumericalAxis();
            numericalAxis.Title.Text = "Price in Dollar";
            numericalAxis.Minimum = 0;
            numericalAxis.Maximum = 250;
            numericalAxis.Interval = 50;
            numericalAxis.LabelStyle.LabelFormat = "$##.##";
            chart.SecondaryAxis = numericalAxis;

            chart.Series.Add(new HiLoOpenCloseSeries
            {
                StrokeWidth = 5,
				ItemsSource = MainPage.GetOhlcData(),
				XBindingPath = "XValue",
				Open = "Open",
				Close = "Close",
				High = "High",
				Low = "Low",
                TooltipEnabled = true,
                EnableAnimation = true,
            });
            return chart;
        }
    }
}