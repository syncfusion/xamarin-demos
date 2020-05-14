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
	public partial class TechnicalIndicator : SampleView
	{
        Picker animationPicker;
        StackLayout PropertyWindowLayout;
        public TechnicalIndicator()
        {
            InitializeComponent();
			if (Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WPF)
            {
                secondaryAxisLabelStyle.LabelFormat = "'$'0.00";
            }
            else
            {
                secondaryAxisLabelStyle.LabelFormat = "'$'##.##";
            }

            PropertyWindowLayout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical
            };
            animationPicker = new Picker();
            animationPicker.Items.Add("Accumulation Distribution");
            animationPicker.Items.Add("Average True");
            animationPicker.Items.Add("Exponential Moving Average");
            animationPicker.Items.Add("Momentum");
            animationPicker.Items.Add("Simple Moving Average");
            animationPicker.Items.Add("RSI Indicator");
            animationPicker.Items.Add("Triangular Moving Average");
            animationPicker.Items.Add("MACD Indicator");
            animationPicker.Items.Add("Stochastic");
            animationPicker.Items.Add("Bollinger Band");
            
            animationPicker.SelectedIndex = 4;

            animationPicker.HorizontalOptions = LayoutOptions.FillAndExpand;
            animationPicker.VerticalOptions = LayoutOptions.Center;

            SimpleMovingAverageIndicator sma4 = new SimpleMovingAverageIndicator();
            NumericalAxis numericalAxis4 = new NumericalAxis();
            numericalAxis4.OpposedPosition = true;
            numericalAxis4.ShowMajorGridLines = false;
			if (Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WPF)
            {
				numericalAxis4.LabelStyle.LabelFormat = "'$'0.00";
            }
            else
            {
				numericalAxis4.LabelStyle.LabelFormat = "'$'##.##";
            }
            sma4.YAxis = numericalAxis4;
            sma4.SeriesName = "Series";
            sma4.Period = 14;
            Chart.TechnicalIndicators.Add(sma4);
            animationPickerLabel.Text = "Simple Moving Average";

                pickerLayout.IsVisible = true;
             
                PropertyWindowLayout.IsVisible = true;
            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
            {
                
            }
            else
            {
                PropertyWindowLayout.Margin = new Thickness(5,2,2,2);
            }
                animationPickerTitle.VerticalOptions = LayoutOptions.Start;
                animationPickerTitle.HorizontalOptions = LayoutOptions.FillAndExpand;
                animationPicker.HorizontalOptions = LayoutOptions.FillAndExpand;
                animationPicker.VerticalOptions = LayoutOptions.Center;
                PropertyWindowLayout.Children.Add(animationPickerTitle);
                PropertyWindowLayout.Children.Add(animationPicker);
                this.PropertyView = PropertyWindowLayout;

           
            animationPicker.SelectedIndexChanged += labelDisplayMode_SelectedIndexChanged;

            if (Device.RuntimePlatform != Device.Android && Device.RuntimePlatform != Device.iOS)
                animationPicker.Margin = new Thickness(5, 5, 10, 0);
            animationPickerTitle.Margin = new Thickness(3, 5, 10, 0);
            animationPickerLabel.Margin = new Thickness(10, 5, 10, 5);
        }

        void labelDisplayMode_SelectedIndexChanged(object sender, EventArgs e)
		{
            animationPickerLabel.Text = animationPicker.Items[animationPicker.SelectedIndex];

			NumericalAxis numericalAxis = new NumericalAxis();
            numericalAxis.OpposedPosition = true;
            numericalAxis.ShowMajorGridLines = false;
			if (Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WPF)
            {
				numericalAxis.LabelStyle.LabelFormat = "'$'0.00";
            }
            else
            {
				numericalAxis.LabelStyle.LabelFormat = "'$'##.##";
            }
            switch (animationPicker.SelectedIndex)
			{
				case 0:
					Chart.TechnicalIndicators.RemoveAt(0);
					AccumulationDistributionIndicator sma = new AccumulationDistributionIndicator();
					sma.SeriesName = "Series";
					sma.YAxis = numericalAxis;
					Chart.TechnicalIndicators.Add(sma);
					break;
				case 1:
					Chart.TechnicalIndicators.RemoveAt(0);
					AverageTrueIndicator sma1 = new AverageTrueIndicator();
					sma1.SeriesName = "Series";
					sma1.Period = 14;
					sma1.YAxis = numericalAxis;
					Chart.TechnicalIndicators.Add(sma1);
					break;
				case 2:
					Chart.TechnicalIndicators.RemoveAt(0);
					ExponentialMovingAverageIndicator sma2 = new ExponentialMovingAverageIndicator();
					sma2.SeriesName = "Series";
					sma2.Period = 14;
					sma2.YAxis = numericalAxis;
					Chart.TechnicalIndicators.Add(sma2);
					break;
				case 3:
					Chart.TechnicalIndicators.RemoveAt(0);
					MomentumIndicator sma3 = new MomentumIndicator();
					sma3.SeriesName = "Series";
					sma3.Period = 14;
					sma3.YAxis = numericalAxis;
					Chart.TechnicalIndicators.Add(sma3);
					break;
				case 4:
					if (Chart.TechnicalIndicators.Count > 0)
						Chart.TechnicalIndicators.RemoveAt(0);
					SimpleMovingAverageIndicator sma4 = new SimpleMovingAverageIndicator();
					sma4.YAxis = numericalAxis;
					sma4.SeriesName = "Series";
					sma4.Period = 14;
					Chart.TechnicalIndicators.Add(sma4);
					break;
				case 5:
					Chart.TechnicalIndicators.RemoveAt(0);
					RSIIndicator sma5 = new RSIIndicator();
					sma5.SeriesName = "Series";
					sma5.Period = 14;
					sma5.YAxis = numericalAxis;
					Chart.TechnicalIndicators.Add(sma5);
					break;
				case 6:
					Chart.TechnicalIndicators.RemoveAt(0);
					TriangularMovingAverageIndicator sma6 = new TriangularMovingAverageIndicator();
					sma6.SeriesName = "Series";
					sma6.Period = 14;
					sma6.YAxis = numericalAxis;
					Chart.TechnicalIndicators.Add(sma6);
					break;
				case 7:
					Chart.TechnicalIndicators.RemoveAt(0);
					MACDIndicator sma7 = new MACDIndicator();
					sma7.ItemsSource = (Chart.BindingContext as TechnicalIndicatorViewModel).TechnicalIndicatorData;
					sma7.SeriesName = "Series";
					sma7.LongPeriod = 10;
					sma7.ShortPeriod = 2;
					sma7.Trigger = 14;
					sma7.YAxis = numericalAxis;
					Chart.TechnicalIndicators.Add(sma7);
					break;
				case 8:
					Chart.TechnicalIndicators.RemoveAt(0);
					StochasticIndicator sma8 = new StochasticIndicator();
					sma8.SeriesName = "Series";
					sma8.Period = 14;
					sma8.KPeriod = 5;
					sma8.DPeriod = 6;
					sma8.YAxis = numericalAxis;
					Chart.TechnicalIndicators.Add(sma8);
					break;
				case 9:
					Chart.TechnicalIndicators.RemoveAt(0);
					BollingerBandIndicator sma9 = new BollingerBandIndicator();
					sma9.Period = 14;
					sma9.SeriesName = "Series";
					sma9.YAxis = numericalAxis;
					Chart.TechnicalIndicators.Add(sma9);
					break;
			}
		}
	}
}