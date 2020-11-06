#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfChart.iOS;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
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
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
#endif

namespace SampleBrowser
{
	public class LiveUpdate : SampleView
	{
		SFChart chart;
		SFFastLineSeries series;
		SFFastLineSeries series1;
		ChartViewModel dataModel;
		bool isDisappeared = false;

		public LiveUpdate()
		{
			chart = new SFChart();
			SFNumericalAxis primaryAxis = new SFNumericalAxis();
            primaryAxis.ShowMajorGridLines = false;
			chart.PrimaryAxis = primaryAxis;
			SFNumericalAxis secondaryAxis = new SFNumericalAxis();
            secondaryAxis.ShowMajorGridLines = false;
			secondaryAxis.Minimum = NSObject.FromObject(-1.5);
			secondaryAxis.Maximum = NSObject.FromObject(1.5);
			secondaryAxis.Interval = NSObject.FromObject(0.5);
			chart.SecondaryAxis = secondaryAxis;
			dataModel = new ChartViewModel();

		 	series = new SFFastLineSeries();
			series.ItemsSource = dataModel.liveData1;
			series.XBindingPath = "XValue";
			series.YBindingPath = "YValue";
			chart.Series.Add(series);

			series1 = new SFFastLineSeries();
			series1.ItemsSource = dataModel.liveData2;
			series1.XBindingPath = "XValue";
			series1.YBindingPath = "YValue";
			chart.Series.Add(series1);
            chart.ColorModel.Palette = SFChartColorPalette.Natural;

			this.AddSubview(chart);
		}

		public override void LayoutSubviews()
		{
			foreach (var view in this.Subviews)
			{
				view.Frame = Bounds;
			}
			base.LayoutSubviews();
		}

		async void UpdateData()
		{
			await Task.Delay(10);
			if (!isDisappeared)
			{
				(chart.Series[0].ItemsSource as ObservableCollection<ChartDataModel>).RemoveAt(0);
				(chart.Series[0].ItemsSource as ObservableCollection<ChartDataModel>).Add(new ChartDataModel(dataModel.wave1, Math.Sin(dataModel.wave1 * (Math.PI / 180.0))));
				dataModel.wave1++;

				(chart.Series[1].ItemsSource as ObservableCollection<ChartDataModel>).RemoveAt(0);
				(chart.Series[1].ItemsSource as ObservableCollection<ChartDataModel>).Add(new ChartDataModel(dataModel.wave1, Math.Sin(dataModel.wave2 * (Math.PI / 180.0))));
				dataModel.wave2++;
				UpdateData();
			}
		}

		protected override void Dispose(bool disposing)
		{
			isDisappeared = disposing;
			base.Dispose(disposing);
		}

		public override void ViewWillAppear()
		{
			isDisappeared = false;
			UpdateData();
			base.ViewWillAppear();
		}

		public override void ViewWillDisappear()
		{
			isDisappeared = true;
			base.ViewWillDisappear();
		}
	}
}