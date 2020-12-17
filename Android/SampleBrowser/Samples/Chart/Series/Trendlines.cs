#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Charts;

namespace SampleBrowser
{
    class Trendlines : SamplePage
    {
        SfChart chart;
        SfChart chart2;
        TextView ForwardForecast;
        TextView TrendTypeValue;
        TextView BackwardForecast;
        TextView PolyomialOrder;
        SplineSeries splineSeries1;
        SplineSeries splineSeries2;
        ChartTrendline linearTrendline;
        ChartTrendline powerTrendline;
        List<String> adapter;
        public override View GetSampleContent(Context context)
        {
            GetCurrencyDevationChart(context);
            chart.Visibility = ViewStates.Visible;
            var linearlayout = new LinearLayout(context);
            linearlayout.AddView(chart);

            GetMeterDevationChart(context);
            chart2.Visibility = ViewStates.Gone;

            linearlayout.AddView(chart2);
            return linearlayout;
        }

        private void GetCurrencyDevationChart(Context context)
        {
            chart = new SfChart(context);
            chart.Title.Text = "1 USD to INR form 1977 to 2019";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);
            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.DockPosition = ChartDock.Top;
            chart.Legend.IconHeight = 14;
            chart.Legend.IconWidth = 14;
            chart.Legend.Orientation = ChartOrientation.Vertical;
            chart.ColorModel.ColorPalette = ChartColorPalette.Natural;

            NumericalAxis numericalaxis = new NumericalAxis();
            numericalaxis.LineStyle.StrokeWidth = 0;
            numericalaxis.MajorTickStyle.TickSize = 0;
            numericalaxis.Title.Text = "Rupees against Dollars";
            numericalaxis.LabelStyle.LabelFormat = "₹##";
            chart.SecondaryAxis = numericalaxis;

            DateTimeAxis primaryAxis = new DateTimeAxis();
            primaryAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Center;
            primaryAxis.ShowMajorGridLines = false;
            primaryAxis.Title.Text = "Years";
            primaryAxis.ShowMinorGridLines = false;
            primaryAxis.IntervalType = DateTimeIntervalType.Years;
            primaryAxis.Interval = 5;
            chart.PrimaryAxis = primaryAxis;

            splineSeries1 = new SplineSeries();
            splineSeries1.XBindingPath = "Date";
            splineSeries1.YBindingPath = "YValue";
            splineSeries1.ItemsSource = MainPage.GetTrendlineDataSource1();
            splineSeries1.Label = "Rupees";
            splineSeries1.LegendIcon = ChartLegendIcon.SeriesType;

            splineSeries1.DataMarker.ShowMarker = true;
            splineSeries1.DataMarker.ShowLabel = false;
            splineSeries1.DataMarker.MarkerHeight = 5;
            splineSeries1.DataMarker.MarkerWidth = 5;
            splineSeries1.DataMarker.MarkerStrokeWidth = 2;
            splineSeries1.DataMarker.MarkerStrokeColor = Color.ParseColor("#00bdae");
            splineSeries1.Trendlines = new ChartTrendlineCollection();
            linearTrendline = new ChartTrendline()
            {
                Type = ChartTrendlineType.Linear,
                StrokeColor = new Color(201, 23, 97),
                LegendIcon = ChartLegendIcon.SeriesType,
                VisibilityOnLegend= Visibility.Visible,
                Label = "Linear",
            };

            splineSeries1.Trendlines.Add(linearTrendline);

            chart.Series.Add(splineSeries1);
        }

        private void GetMeterDevationChart(Context context)
        {
            chart2 = new SfChart(context);
            chart2.Title.Text = "Distance Measurement";
            chart2.Title.TextSize = 15;
            chart2.SetBackgroundColor(Color.White);
            chart2.Legend.Visibility = Visibility.Visible;
            chart2.Legend.DockPosition = ChartDock.Top;
            chart2.Legend.IconHeight = 14;
            chart2.Legend.IconWidth = 14;
            chart2.ColorModel.ColorPalette = ChartColorPalette.Natural;

            NumericalAxis numericalaxis = new NumericalAxis();
            numericalaxis.LineStyle.StrokeWidth = 0;
            numericalaxis.MajorTickStyle.TickSize = 0;
            numericalaxis.Title.Text = "Meters";
            chart2.SecondaryAxis = numericalaxis;

            NumericalAxis primaryAxis = new NumericalAxis();
            primaryAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Center;
            primaryAxis.ShowMajorGridLines = false;
            primaryAxis.Title.Text = "Seconds";
            primaryAxis.ShowMinorGridLines = false;
            chart2.PrimaryAxis = primaryAxis;

            splineSeries2 = new SplineSeries();
            splineSeries2.ItemsSource = MainPage.GetTrendlineDataSource2();
            splineSeries2.XBindingPath = "XValue";
            splineSeries2.YBindingPath = "YValue";
            splineSeries2.Label = "Rupees";
            splineSeries2.LegendIcon = ChartLegendIcon.SeriesType;

            splineSeries2.DataMarker.ShowMarker = true;
            splineSeries2.DataMarker.ShowLabel = false;
            splineSeries2.DataMarker.MarkerHeight = 5;
            splineSeries2.DataMarker.MarkerWidth = 5;
            splineSeries2.DataMarker.MarkerStrokeWidth = 2;
            splineSeries2.DataMarker.MarkerStrokeColor = Color.ParseColor("#00bdae");

            splineSeries2.Trendlines = new ChartTrendlineCollection();
            powerTrendline = new ChartTrendline()
            {
                Type = ChartTrendlineType.Power,
                StrokeColor = new Color(201, 23, 97),
                LegendIcon = ChartLegendIcon.SeriesType,
                VisibilityOnLegend = Visibility.Visible,
                Label = "Power",
            };

            splineSeries2.Trendlines.Add(powerTrendline);
            chart2.Series.Add(splineSeries2);
        }


        public override View GetPropertyWindowLayout(Android.Content.Context context)
        {
            /**
     * Property Window
     * */
            int width = (context.Resources.DisplayMetrics.WidthPixels) / 2;
            LinearLayout propertylayout = new LinearLayout(context); //= new LinearLayout(context);
            propertylayout.Orientation = Android.Widget.Orientation.Vertical;

            LinearLayout.LayoutParams layoutParams1 = new LinearLayout.LayoutParams(
                width * 2, 5);

            layoutParams1.SetMargins(0, 20, 0, 0);

            TrendTypeValue = new TextView(context);
            TrendTypeValue.Text = "Trendline Type";
            TrendTypeValue.SetPadding(5, 20, 0, 20);

            ForwardForecast = new TextView(context);
            ForwardForecast.Text = "Forward Forecast: 0";
            ForwardForecast.SetPadding(5, 20, 0, 20);

            SeekBar FwdForecast = new SeekBar(context);
            FwdForecast.Max = 5;
            FwdForecast.Progress = 0;
            FwdForecast.ProgressChanged += FwdForecast_ProgressChanged;

            BackwardForecast = new TextView(context);
            BackwardForecast.Text = "Backward Forecast: 0";
            BackwardForecast.SetPadding(5, 20, 0, 20);

            SeekBar BwdForecast = new SeekBar(context);
            BwdForecast.Max = 5;
            BwdForecast.Progress = 0;
            BwdForecast.ProgressChanged += BwdForecast_ProgressChanged;

            PolyomialOrder = new TextView(context);
            PolyomialOrder.Text = "Polynomial Order: 2";
            PolyomialOrder.SetPadding(5, 20, 0, 20);

            SeekBar PolyOrder = new SeekBar(context);
            PolyOrder.Max = 5;
            PolyOrder.Progress = 2;
            PolyOrder.ProgressChanged += PolyOrder_ProgressChanged;
            var spinner = new Spinner(context, SpinnerMode.Dialog);
            adapter = new List<String>() { "Linear", "Exponential", "Logarithmic", "Power", "Polynomial" };
            ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>
               (context, Android.Resource.Layout.SimpleSpinnerItem, adapter);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);
            spinner.Adapter = dataAdapter;

            spinner.ItemSelected += Spinner_ItemSelected;

            propertylayout.AddView(TrendTypeValue);
            propertylayout.AddView(spinner);
            propertylayout.AddView(ForwardForecast);
            propertylayout.AddView(FwdForecast);
            propertylayout.AddView(BackwardForecast);
            propertylayout.AddView(BwdForecast);
            propertylayout.AddView(PolyomialOrder);
            propertylayout.AddView(PolyOrder);
            SeparatorView separate = new SeparatorView(context, width * 2);
            separate.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
            propertylayout.AddView(separate, layoutParams1);

            return propertylayout;
        }

        private void PolyOrder_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            var value = (int)e.Progress;
            if (linearTrendline != null)
                linearTrendline.PolynomialOrder = value;
            PolyomialOrder.Text = "Polynomial Order: " + value;
        }

        private void BwdForecast_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            var value = (int)e.Progress;
            if (linearTrendline != null)
                linearTrendline.BackwardForecast = value;
            BackwardForecast.Text = "Backward Forecast: " + value;
        }

        private void FwdForecast_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            var value = (int)e.Progress;
            if (linearTrendline != null)
                linearTrendline.ForwardForecast = value;
            if (powerTrendline != null)
                powerTrendline.ForwardForecast = value;
            ForwardForecast.Text = "Forward Forecast: " + value;
        }

        private void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            String selectedItem = adapter[e.Position];
            if (selectedItem.Equals("Power"))
            {
                chart2.Visibility = ViewStates.Visible;
                chart.Visibility = ViewStates.Gone;
            }
            else
            {
                if (selectedItem.Equals("Linear"))
                {
                    linearTrendline.Type = ChartTrendlineType.Linear;
                    linearTrendline.Label = "Linear";
                }
                else if (selectedItem.Equals("Exponential"))
                {
                    linearTrendline.Type = ChartTrendlineType.Exponential;
                    linearTrendline.Label = "Exponential";
                }
                else if (selectedItem.Equals("Logarithmic"))
                {
                    linearTrendline.Label = "Logarithmic";
                    linearTrendline.Type = ChartTrendlineType.Logarithmic;
                }
                else if (selectedItem.Equals("Polynomial"))
                {
                    linearTrendline.Label = "Polynomial";
                    linearTrendline.Type = ChartTrendlineType.Polynomial;
                }

                if(chart.Visibility == ViewStates.Gone)
                {
                    chart2.Visibility = ViewStates.Gone;
                    chart.Visibility = ViewStates.Visible;
                }
            }
        }
    }
}