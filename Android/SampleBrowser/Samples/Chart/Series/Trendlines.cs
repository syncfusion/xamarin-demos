#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Charts;

namespace SampleBrowser
{
    class Trendlines : SamplePage
    {
        SfChart salesDeviationChart;
        SfChart meterDevitionChart;
        TextView ForwardForecast;
        TextView TrendTypeValue;
        TextView BackwardForecast;
        TextView PolyomialOrder;
        ColumnSeries salesColumnSeries;
        ColumnSeries splineSeries2;
        ChartTrendline linearTrendline;
        ChartTrendline powerTrendline;
        NumericalAxis numericalaxis;
        List<String> adapter;
        public override View GetSampleContent(Context context)
        {
            GetSalseDevationChart(context);
            var linearlayout = new LinearLayout(context);
            linearlayout.AddView(salesDeviationChart);
            GetMeterDevationChart(context);
            meterDevitionChart.Visibility = ViewStates.Gone;
            linearlayout.AddView(meterDevitionChart);
          
            return linearlayout;
        }

        private void GetSalseDevationChart(Context context)
        {
            salesDeviationChart = new SfChart(context);
            salesDeviationChart.Title.Text = "Average Sales Comparison";
            salesDeviationChart.Title.TextSize = 15;
            salesDeviationChart.SetBackgroundColor(Color.White);
            salesDeviationChart.ColorModel.ColorPalette = ChartColorPalette.Natural;
            DateTimeAxis primaryAxis = new DateTimeAxis();
            primaryAxis.Title.Text = "Months";
            primaryAxis.ShowMinorGridLines = false;
            primaryAxis.ShowMinorGridLines = false;
            primaryAxis.IntervalType = DateTimeIntervalType.Months;
            primaryAxis.Interval = 1;
            primaryAxis.MajorTickStyle.StrokeWidth = 0;
            primaryAxis.LabelStyle.LabelFormat = "MMM";
            salesDeviationChart.PrimaryAxis = primaryAxis;
           
            numericalaxis = new NumericalAxis();
            numericalaxis.LineStyle.StrokeWidth = 0;
            numericalaxis.MajorTickStyle.TickSize = 0;
            numericalaxis.Title.Text = "Number of Customer";
            numericalaxis.LineStyle.StrokeColor = Color.Transparent;
            salesDeviationChart.SecondaryAxis = numericalaxis;

            salesColumnSeries = new ColumnSeries();
            salesColumnSeries.XBindingPath = "Date";
            salesColumnSeries.YBindingPath = "YValue";
            salesColumnSeries.ItemsSource = MainPage.GetTrendlineDataSource("Linear");
            salesColumnSeries.Label = "Sales";
            salesColumnSeries.LegendIcon = ChartLegendIcon.SeriesType;
            salesDeviationChart.Series.Add(salesColumnSeries);

            linearTrendline = new ChartTrendline()
            {
                Type = ChartTrendlineType.Linear,
                StrokeColor = new Color(64,64,65),
                Label = "Linear",
            };

            salesColumnSeries.Trendlines = new ChartTrendlineCollection()
            {
                linearTrendline
            };
        }

        private void GetMeterDevationChart(Context context)
        {
            meterDevitionChart = new SfChart(context);
            meterDevitionChart.Title.Text = "Distance Measurement";
            meterDevitionChart.Title.TextSize = 15;
            meterDevitionChart.SetBackgroundColor(Color.White);

            meterDevitionChart.ColorModel.ColorPalette = ChartColorPalette.Natural;

            NumericalAxis numericalaxis = new NumericalAxis();
            numericalaxis.LineStyle.StrokeWidth = 0;
            numericalaxis.MajorTickStyle.TickSize = 0;
            numericalaxis.Title.Text = "Meters";
            meterDevitionChart.SecondaryAxis = numericalaxis;

            NumericalAxis primaryAxis = new NumericalAxis();
            primaryAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Center;
            primaryAxis.ShowMajorGridLines = false;
            primaryAxis.Title.Text = "Seconds";
            primaryAxis.ShowMinorGridLines = false;
            meterDevitionChart.PrimaryAxis = primaryAxis;

            splineSeries2 = new ColumnSeries();
            splineSeries2.ItemsSource = MainPage.GetPowerTrendlineDataSource();
            splineSeries2.XBindingPath = "XValue";
            splineSeries2.YBindingPath = "YValue";
            splineSeries2.Label = "Rupees";
            splineSeries2.LegendIcon = ChartLegendIcon.SeriesType;
            meterDevitionChart.Series.Add(splineSeries2);

            powerTrendline = new ChartTrendline()
            {
                Type = ChartTrendlineType.Power,
                StrokeColor = new Color(64,64,65),
                LegendIcon = ChartLegendIcon.SeriesType,
                VisibilityOnLegend = Visibility.Visible,
                Label = "Power",
            };

            splineSeries2.Trendlines = new ChartTrendlineCollection()
            {
                powerTrendline
            };
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
            FwdForecast.Max = 2;
            FwdForecast.Progress = 0;
            FwdForecast.ProgressChanged += FwdForecast_ProgressChanged;

            BackwardForecast = new TextView(context);
            BackwardForecast.Text = "Backward Forecast: 0";
            BackwardForecast.SetPadding(5, 20, 0, 20);

            SeekBar BwdForecast = new SeekBar(context);
            BwdForecast.Max = 2;
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
                meterDevitionChart.Visibility = ViewStates.Visible;
                salesDeviationChart.Visibility = ViewStates.Gone;
            }
            else
            {
                if (selectedItem.Equals("Linear"))
                {
                    salesColumnSeries.ItemsSource = MainPage.GetTrendlineDataSource("Linear");
                    linearTrendline.Type = ChartTrendlineType.Linear;
                    numericalaxis.Interval = 10;
                    linearTrendline.Label = "Linear";
                }
                else if (selectedItem.Equals("Exponential"))
                {
                    salesColumnSeries.ItemsSource = MainPage.GetTrendlineDataSource("Exponential");
                    linearTrendline.Type = ChartTrendlineType.Exponential;
                    numericalaxis.Interval = 100;
                    linearTrendline.Label = "Exponential";
                }
                else if (selectedItem.Equals("Logarithmic"))
                {
                    salesColumnSeries.ItemsSource = MainPage.GetTrendlineDataSource("Logarithmic");
                    linearTrendline.Label = "Logarithmic";
                    numericalaxis.Interval = 50;
                    linearTrendline.Type = ChartTrendlineType.Logarithmic;
                }
                else if (selectedItem.Equals("Polynomial"))
                {
                    salesColumnSeries.ItemsSource = MainPage.GetTrendlineDataSource("Polynomial");
                    linearTrendline.Label = "Polynomial";
                    numericalaxis.Interval = 50;
                    linearTrendline.Type = ChartTrendlineType.Polynomial;
                }

                if(salesDeviationChart.Visibility == ViewStates.Gone)
                {
                    meterDevitionChart.Visibility = ViewStates.Gone;
                    salesDeviationChart.Visibility = ViewStates.Visible;
                }
            }
        }
    }
}