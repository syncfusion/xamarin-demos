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
    public class Candle : SamplePage
    {
        SfChart chart;
       public override View GetSampleContent(Context context)
        {
           chart = new SfChart(context);
           chart.SetBackgroundColor(Color.White);
           chart.Title.Text = "Foreign Exchange Rate Analysis";
            chart.Title.TextSize = 15;
            DateTimeAxis dateTimeAxis = new DateTimeAxis();
           dateTimeAxis.LabelRotationAngle = -45;
           dateTimeAxis.LabelStyle.LabelFormat = "MM/dd/yyyy";
           dateTimeAxis.Title.Text = "Date";
           chart.PrimaryAxis = dateTimeAxis;

           NumericalAxis numericalAxis = new NumericalAxis();
           numericalAxis.Title.Text = "Price in Dollar";
           numericalAxis.Minimum = 0;
           numericalAxis.Maximum = 250;
           numericalAxis.Interval = 50;
           numericalAxis.LabelStyle.LabelFormat = "$##.##";
           chart.SecondaryAxis = numericalAxis;

           CandleSeries candleSeries = new CandleSeries();
			candleSeries.ItemsSource = MainPage.GetCandleData();
			candleSeries.XBindingPath = "XValue";
			candleSeries.Open = "Open";
			candleSeries.Close = "Close";
			candleSeries.High = "High";
			candleSeries.Low = "Low";
            candleSeries.TooltipEnabled = true;
            candleSeries.EnableAnimation = true;

           chart.Series.Add(candleSeries);

           return chart;
        }
    }
}