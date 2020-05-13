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
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Charts;
using Android.Graphics;

namespace SampleBrowser
{
    public class TechnicalIndicators : SamplePage
    {
        SfChart chart;

        List<String> adapter;
        public override View GetSampleContent(Context context)
        {
            chart = new SfChart(context);
            chart.SetPadding(0, 10, 0, 0);
            chart.Behaviors.Add(new ChartTrackballBehavior());
            DateTimeAxis dateTimeAxis = new DateTimeAxis();
            dateTimeAxis.LabelStyle.LabelFormat = "MM/yyyy";
            chart.PrimaryAxis = dateTimeAxis;


            NumericalAxis numericalAxis = new NumericalAxis();
            chart.SecondaryAxis = numericalAxis;

            HiLoOpenCloseSeries candleSeries = new HiLoOpenCloseSeries();
			candleSeries.ItemsSource = MainPage.GetTechnicalIndicatorData();
			candleSeries.XBindingPath = "XValue";
			candleSeries.Open = "Open";
			candleSeries.Close = "Close";
			candleSeries.High = "High";
			candleSeries.Low = "Low";
            candleSeries.EnableAnimation = true;
            candleSeries.Name = "Series";
            chart.Series.Add(candleSeries);

            SimpleMovingAverageIndicator sMA = new SimpleMovingAverageIndicator();
            sMA.SeriesName = "Series";
            sMA.XBindingPath = "XValue";
            sMA.Open = "Open";
            sMA.Close = "Close";
            sMA.High = "High";
            sMA.Low = "Low";
            sMA.EnableAnimation = true;
            chart.TechnicalIndicators.Add(sMA);

            TextView labelDisplayMode = new TextView(context);
            labelDisplayMode.TextSize = 20;
            labelDisplayMode.Text = "Technical Indicator type";

            Spinner selectLabelMode = new Spinner(context,SpinnerMode.Dialog);
            adapter = new List<String>() {"Simple Moving Average Indicator", "Average True Indicator", "Exponential Moving Averge Indicator", "Momentum Indicator",
                "Accumulation Distribution Indicator", "RSI Indicator", "Triangular Moving Average Indicator",
                "MACD Indicator", "Stochastic Indicator", "Bollinger Band Indicator" };

            ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>
                (context, Android.Resource.Layout.SimpleSpinnerItem, adapter);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);
            selectLabelMode.Adapter = dataAdapter;
            selectLabelMode.ItemSelected += SelectLabelMode_ItemSelected;

            LinearLayout linearLayout = new LinearLayout(context);
            linearLayout.SetPadding(20, 0, 20, 30);
            linearLayout.SetBackgroundColor(Color.Rgb(236, 235, 242));
            linearLayout.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent,
                LinearLayout.LayoutParams.WrapContent);
            linearLayout.Orientation = Orientation.Vertical;
            linearLayout.SetBackgroundColor(Color.White);
            linearLayout.AddView(selectLabelMode);
            linearLayout.AddView(chart);
            return linearLayout;
        }

        private void SelectLabelMode_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            String selectedItem = adapter[e.Position];
            if (selectedItem.Equals("Accumulation Distribution Indicator"))
            {
                chart.TechnicalIndicators.RemoveAt(0);
                AccumulationDistributionIndicator accumulationDistribution = new AccumulationDistributionIndicator();
                NumericalAxis numericalAxis = new NumericalAxis();
                numericalAxis.OpposedPosition = true;
                numericalAxis.ShowMajorGridLines = false;
                accumulationDistribution.YAxis = numericalAxis;
                accumulationDistribution.SeriesName = "Series";
                accumulationDistribution.XBindingPath = "XValue";
                accumulationDistribution.Open = "Open";
                accumulationDistribution.Close = "Close";
                accumulationDistribution.High = "High";
                accumulationDistribution.Low = "Low";
                chart.TechnicalIndicators.Add(accumulationDistribution);
            }
            else if (selectedItem.Equals("Average True Indicator"))
            {
                chart.TechnicalIndicators.RemoveAt(0);
                AverageTrueIndicator aTR = new AverageTrueIndicator();
                NumericalAxis numericalAxis = new NumericalAxis();
                numericalAxis.OpposedPosition = true;
                numericalAxis.ShowMajorGridLines = false;
                aTR.YAxis = numericalAxis;
                aTR.Period = 14;
                aTR.SeriesName = "Series";
                aTR.XBindingPath = "XValue";
                aTR.Open = "Open";
                aTR.Close = "Close";
                aTR.High = "High";
                aTR.Low = "Low";
                chart.TechnicalIndicators.Add(aTR);
            }
            else if (selectedItem.Equals("Exponential Moving Averge Indicator"))
            {
                chart.TechnicalIndicators.RemoveAt(0);
                ExponentialMovingAverageIndicator eMA = new ExponentialMovingAverageIndicator();
                NumericalAxis numericalAxis = new NumericalAxis();
                numericalAxis.OpposedPosition = true;
                numericalAxis.ShowMajorGridLines = false;
                eMA.YAxis = numericalAxis;
                eMA.Period = 14;
                eMA.SeriesName = "Series";
                eMA.XBindingPath = "XValue";
                eMA.Open = "Open";
                eMA.Close = "Close";
                eMA.High = "High";
                eMA.Low = "Low";
                chart.TechnicalIndicators.Add(eMA);
            }
            else if (selectedItem.Equals("Momentum Indicator"))
            {
                chart.TechnicalIndicators.RemoveAt(0);
                MomentumIndicator momentum = new MomentumIndicator();
                NumericalAxis numericalAxis = new NumericalAxis();
                numericalAxis.OpposedPosition = true;
                numericalAxis.ShowMajorGridLines = false;
                momentum.YAxis = numericalAxis;
                momentum.SeriesName = "Series";
                momentum.XBindingPath = "XValue";
                momentum.Open = "Open";
                momentum.Close = "Close";
                momentum.High = "High";
                momentum.Low = "Low";
                momentum.Period = 14;
                chart.TechnicalIndicators.Add(momentum);
            }
            else if (selectedItem.Equals("Simple Moving Average Indicator"))
            {
                chart.TechnicalIndicators.RemoveAt(0);
                SimpleMovingAverageIndicator sMA = new SimpleMovingAverageIndicator();
                sMA.SeriesName = "Series";
                sMA.XBindingPath = "XValue";
                sMA.Open = "Open";
                sMA.Close = "Close";
                sMA.High = "High";
                sMA.Low = "Low";
                sMA.Period = 14;
                chart.TechnicalIndicators.Add(sMA);
            }
            else if (selectedItem.Equals("RSI Indicator"))
            {
                chart.TechnicalIndicators.RemoveAt(0);
                RSIIndicator rSI = new RSIIndicator();
                NumericalAxis numericalAxis = new NumericalAxis();
                numericalAxis.OpposedPosition = true;
                numericalAxis.ShowMajorGridLines = false;
                rSI.YAxis = numericalAxis;
                rSI.Period = 14;
                rSI.SeriesName = "Series";
                rSI.XBindingPath = "XValue";
                rSI.Open = "Open";
                rSI.Close = "Close";
                rSI.High = "High";
                rSI.Low = "Low";
                chart.TechnicalIndicators.Add(rSI);
            }
            else if (selectedItem.Equals("Triangular Moving Average Indicator"))
            {
                chart.TechnicalIndicators.RemoveAt(0);
                TriangularMovingAverageIndicator tMA = new TriangularMovingAverageIndicator();
                NumericalAxis numericalAxis = new NumericalAxis();
                numericalAxis.OpposedPosition = true;
                numericalAxis.ShowMajorGridLines = false;
                tMA.YAxis = numericalAxis;
                tMA.Period = 14;
                tMA.SeriesName = "Series";
                tMA.XBindingPath = "XValue";
                tMA.Open = "Open";
                tMA.Close = "Close";
                tMA.High = "High";
                tMA.Low = "Low";
                chart.TechnicalIndicators.Add(tMA);
            }
            else if (selectedItem.Equals("MACD Indicator"))
            {
                chart.TechnicalIndicators.RemoveAt(0);
                MACDIndicator mACD = new MACDIndicator();
                NumericalAxis numericalAxis = new NumericalAxis();
                numericalAxis.OpposedPosition = true;
                numericalAxis.ShowMajorGridLines = false;
                mACD.YAxis = numericalAxis;
                mACD.SeriesName = "Series";
                mACD.XBindingPath = "XValue";
                mACD.Open = "Open";
                mACD.Close = "Close";
                mACD.High = "High";
                mACD.Low = "Low";
                mACD.ShortPeriod = 2;
                mACD.LongPeriod = 10;
                mACD.Trigger = 14;
                chart.TechnicalIndicators.Add(mACD);
            }
            else if (selectedItem.Equals("Stochastic Indicator"))
            {
                chart.TechnicalIndicators.RemoveAt(0);
                StochasticIndicator stochastic = new StochasticIndicator();
                NumericalAxis numericalAxis = new NumericalAxis();
                numericalAxis.OpposedPosition = true;
                numericalAxis.ShowMajorGridLines = false;
                stochastic.YAxis = numericalAxis;
                stochastic.SeriesName = "Series";
                stochastic.XBindingPath = "XValue";
                stochastic.Open = "Open";
                stochastic.Close = "Close";
                stochastic.High = "High";
                stochastic.Low = "Low";
                stochastic.Period = 14;
                stochastic.KPeriod = 5;
                stochastic.DPeriod = 6;
                chart.TechnicalIndicators.Add(stochastic);
            }
            else if (selectedItem.Equals("Bollinger Band Indicator"))
            {
                chart.TechnicalIndicators.RemoveAt(0);
                BollingerBandIndicator bB = new BollingerBandIndicator();
                bB.Period = 14;
                NumericalAxis numericalAxis = new NumericalAxis();
                numericalAxis.OpposedPosition = true;
                numericalAxis.ShowMajorGridLines = false;
                //bB.YAxis = numericalAxis;
                bB.SeriesName = "Series";
                bB.XBindingPath = "XValue";
                bB.Open = "Open";
                bB.Close = "Close";
                bB.High = "High";
                bB.Low = "Low";
                chart.TechnicalIndicators.Add(bB);
            }
        }
    }
}