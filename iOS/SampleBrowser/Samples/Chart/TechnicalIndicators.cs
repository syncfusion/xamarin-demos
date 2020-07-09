#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
using System.Collections.Generic;


#endregion
using System;
using Syncfusion.SfChart.iOS;
using System.Collections.ObjectModel;

#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;

#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using nint = System.Int32;
using nuint = System.Int32;
#endif

namespace SampleBrowser
{
	public class TechnicalIndicators : SampleView
	{
		SFChart chart;
		SFSMAIndicator indicator;
        ObservableCollection<SFTechnicalIndicator> indicatorCollection;
		UIPickerView indicatorTypePicker;
		UIButton doneButton;
		UIButton indicatorTypeTextButton;

		public TechnicalIndicators()
		{
			indicatorTypePicker = new UIPickerView();

			indicatorTypeTextButton = new UIButton();
			doneButton = new UIButton();
			indicator = new SFSMAIndicator();
			indicator.SeriesName = new NSString("Hi-Low");
			indicator.XBindingPath = "XValue";
			indicator.High = "High";
			indicator.Low = "Low";
			indicator.Open = "Open";
			indicator.Close = "Close";

			SFNumericalAxis axis = new SFNumericalAxis();
			axis.OpposedPosition = true;
			axis.ShowMajorGridLines = false;
			NSNumberFormatter axisFormatter = new NSNumberFormatter();
			axisFormatter.PositivePrefix = "$";
			axis.LabelStyle.LabelFormatter = axisFormatter;
			indicator.YAxis = axis;

            indicatorCollection = new ObservableCollection<SFTechnicalIndicator>();
			indicatorCollection.Add(indicator);

			chart = new SFChart();
			chart.Title.Text = new NSString("StockDetails");
			chart.Title.TextAlignment = UITextAlignment.Center;

			SFDateTimeAxis datetime = new SFDateTimeAxis();
			datetime.MaximumLabels = 6;
			datetime.LabelsIntersectAction = SFChartAxisLabelsIntersectAction.Hide;
			chart.PrimaryAxis = datetime;
			datetime.Title.Text = new NSString("Date");
			chart.SecondaryAxis = new SFNumericalAxis();
			NSNumberFormatter secondaryAxisFormatter = new NSNumberFormatter();
			secondaryAxisFormatter.PositivePrefix = "$";
            chart.SecondaryAxis.LabelStyle.LabelFormatter = secondaryAxisFormatter;

			SFChartTrackballBehavior behavior = new SFChartTrackballBehavior();
			chart.AddChartBehavior(behavior);
			chart.TechnicalIndicators.Add(indicator);

			ChartViewModel dataModel = new ChartViewModel();
			SFOHLCSeries series = new SFOHLCSeries();
			series.ItemsSource = dataModel.TechnicalIndicatorData;
			series.XBindingPath = "XValue";
			series.High = "High";
			series.Low = "Low";
			series.Open = "Open";
			series.Close = "Close";
			series.EnableTooltip = true;
			series.LineWidth = 1;
			series.SeriesName = new NSString("Hi-Low");
            series.ColorModel.Palette = SFChartColorPalette.Natural;
			chart.Series.Add(series);

			this.AddSubview(chart);

			indicatorTypeTextButton.SetTitle("SMA indicator", UIControlState.Normal);
			indicatorTypeTextButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			indicatorTypeTextButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			indicatorTypeTextButton.TouchUpInside += delegate
			{

				indicatorTypePicker.Hidden = false;
				doneButton.Hidden = false;
				this.BecomeFirstResponder();

			};
			indicatorTypeTextButton.BackgroundColor = UIColor.Clear;
			indicatorTypeTextButton.Layer.BorderWidth = 2.0f;
			indicatorTypeTextButton.Layer.BorderColor = UIColor.FromRGB(240.0f / 255.0f, 240.0f / 255.0f, 240.0f / 255.0f).CGColor;
			indicatorTypeTextButton.Layer.CornerRadius = 8.0f;
			this.AddSubview(indicatorTypeTextButton);

			indicatorTypePicker.ShowSelectionIndicator = true;
			indicatorTypePicker.Hidden = true;

			indicatorTypePicker.Model = new StatusPickerViewModel(chart, indicatorTypeTextButton, indicator, indicatorCollection);

			indicatorTypePicker.BackgroundColor = UIColor.FromRGB(240f / 255.0f, 240f / 255.0f, 240f / 255.0f);
			indicatorTypePicker.SelectedRowInComponent(0);
			this.AddSubview(indicatorTypePicker);

			doneButton.SetTitle("Done" + "\t", UIControlState.Normal);
			doneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			doneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			doneButton.TouchUpInside += delegate
			{

				indicatorTypePicker.Hidden = true;
				doneButton.Hidden = true;
				this.BecomeFirstResponder();

			};

			doneButton.BackgroundColor = UIColor.FromRGB(240f / 255.0f, 240f / 255.0f, 240f / 255.0f);
			doneButton.Hidden = true;
			this.AddSubview(doneButton);

		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		public override void LayoutSubviews()
		{

			base.LayoutSubviews();

			chart.Frame = new CGRect(this.Bounds.X, this.Bounds.Y + 40,
				this.Bounds.Width, this.Bounds.Height - 40);


			indicatorTypeTextButton.Frame = new CGRect(10, Bounds.Y, Frame.Size.Width - 20, 40);

			if (Utility.IsIPad)
			{
				doneButton.Frame = new CGRect(0, Bounds.Y + Frame.Size.Height - 253, Frame.Size.Width, 35);
				indicatorTypePicker.Frame = new CGRect(0, Bounds.Y + Frame.Size.Height - 260, Frame.Size.Width, 260);
			}
			else
			{
				doneButton.Frame = new CGRect(0, Bounds.Y + Frame.Size.Height - 143, Frame.Size.Width, 35);
				indicatorTypePicker.Frame = new CGRect(0, Bounds.Y + Frame.Size.Height - 150, Frame.Size.Width, 150);
			}
		}
	}

	public class StatusPickerViewModel : UIPickerViewModel
	{
		UIButton indicatorTypeTextButton;
		SFChart chart;
		SFTechnicalIndicator indicator;
        ObservableCollection<SFTechnicalIndicator> indicatorCollection;

        public StatusPickerViewModel(SFChart chart1, UIButton indicatorButton, SFTechnicalIndicator indicator1, ObservableCollection<SFTechnicalIndicator> collection)
		{
			indicatorTypeTextButton = indicatorButton;
			chart = chart1;
			indicator = indicator1;
			indicatorCollection = collection;
		}

		private readonly IList<string> colors = new List<string>
	{
		"AD Indicator",
		"ATR Indicator",
		"BB Indicator",
		"EMA Indicator",
		"MACD Indicator",
		"Momentum Indicator",
		"RSI Indicator",
		"SMA Indicator",
		"Stochastic Indicator",
		"TMA Indicator"
	};


		public override nint GetComponentCount(UIPickerView pickerView)
		{
			return 1;
		}

		public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
		{
			return (nint)colors.Count;
		}

		public override string GetTitle(UIPickerView pickerView, nint row, nint component)
		{
			return colors[(int)row];
		}

		public override void Selected(UIPickerView pickerView, nint row, nint component)
		{

			indicatorTypeTextButton.SetTitle(colors[(int)row], UIControlState.Normal);

			indicatorCollection.Clear();
			chart.TechnicalIndicators.RemoveAt(0);

			if (row == 0)
				indicator = new SFADIndicator();
			else if (row == 1)
				indicator = new SFATRIndicator();
			else if (row == 2)
				indicator = new SFBBIndicator();
			else if (row == 3)
				indicator = new SFEMAIndicator();
			else if (row == 4)
				indicator = new SFMACDIndicator();
			else if (row == 5)
				indicator = new SFMomentumIndicator();
			else if (row == 6)
				indicator = new SFRSIIndicator();
			else if (row == 7)
				indicator = new SFSMAIndicator();
			else if (row == 8)
				indicator = new SFStochasticIndicator();
			else if (row == 9)
				indicator = new SFTMAIndicator();

			indicator.SeriesName = new NSString("Hi-Low");
			indicator.XBindingPath = "XValue";
			indicator.High = "High";
			indicator.Low = "Low";
			indicator.Open = "Open";
			indicator.Close = "Close"; 

			SFNumericalAxis axis = new SFNumericalAxis();
			axis.OpposedPosition = true;
			axis.ShowMajorGridLines = false;
			NSNumberFormatter axisFormatter = new NSNumberFormatter();
			axisFormatter.PositivePrefix = "$";
			axis.LabelStyle.LabelFormatter = axisFormatter;
			indicator.YAxis = axis;

            indicatorCollection = new ObservableCollection<SFTechnicalIndicator>();
			indicatorCollection.Add(indicator);
			chart.TechnicalIndicators.Add(indicator);
		}
	}

}







