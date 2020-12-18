#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 


#endregion
using System;
using Syncfusion.SfChart.iOS;
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
	public class VerticalChart : SampleView
	{
		SFChart chart ;
		ChartViewModel dataModel;
		bool isDispose = false;

		public VerticalChart ()
		{
			chart = new SFChart ();
			chart.Legend.Visible = true;
            chart.Legend.ToggleSeriesVisibility = true;

			SFDateTimeAxis xAxis 			= new SFDateTimeAxis ();
			NSDateFormatter formatter 		= new NSDateFormatter ();
			formatter.DateFormat 			= new NSString ("mm:ss");
			xAxis.LabelStyle.LabelFormatter = formatter;
			xAxis.Title.Text 				= new NSString ("Time (s)");
			xAxis.ShowMajorGridLines		= false;
			chart.PrimaryAxis 				= xAxis;

			SFNumericalAxis yAxis 			= new SFNumericalAxis ();
			yAxis.Minimum 					= new NSNumber(-10);
			yAxis.Maximum 					= new NSNumber (10);
			yAxis.Interval 					= new NSNumber (10);
			yAxis.Title.Text 				= new NSString ("Velocity(m/s)");
			yAxis.ShowMajorGridLines 		= false;
			chart.SecondaryAxis				= yAxis;

			chart.Title.Text       = new NSString ("Seismograph analysis of country");
			chart.Title.Font       = UIFont.FromName ("Helvetica neue",15);

			dataModel = new ChartViewModel();
			SFFastLineSeries series = new SFFastLineSeries();
			series.LegendIcon =  SFChartLegendIcon.Circle;
            chart.Legend.IconWidth = 14;
            chart.Legend.IconHeight = 14;
			series.Label = "Indonesia";
			series.ItemsSource = dataModel.verticalData;
			series.XBindingPath = "XValue";
			series.YBindingPath = "YValue";
			series.IsTransposed = true;
			series.EnableAnimation = true;
            chart.ColorModel.Palette = SFChartColorPalette.Natural;
			chart.Series.Add(series);

			this.AddSubview(chart);
			UpdateData ();
		}

		async void UpdateData()
		{
			await Task.Delay(50);

			if (!isDispose)
			{
				ChartDataModel datapoint = dataModel.dataPointWithTimeInterval(0.13);

				(chart.Series[0].ItemsSource as ObservableCollection<ChartDataModel>).Add(new ChartDataModel(datapoint.XValue, datapoint.YValue));

				if (dataModel.verticalCount < 340)
					UpdateData();
			}
		}

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Bounds;
			}
			base.LayoutSubviews ();
		}

		protected override void Dispose(bool disposing)
		{
			isDispose = disposing;
			base.Dispose(disposing);
		}
	}
}

