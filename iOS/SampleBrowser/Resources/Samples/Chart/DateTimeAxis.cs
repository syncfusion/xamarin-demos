#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Foundation;
using Syncfusion.SfChart.iOS;
using UIKit;

namespace SampleBrowser
{
	public class DateTimeAxis : SampleView
	{
		int month = int.MaxValue;

		public DateTimeAxis()
		{
			SFChart chart = new SFChart();
			chart.Title.Text = (NSString)"Food Production - 2017";

			chart.PrimaryAxis = new SFDateTimeAxis() { ZoomFactor = 0.1f, ZoomPosition = 0.6f, EdgeLabelsDrawingMode = SFChartAxisEdgeLabelsDrawingMode.Shift };
			chart.PrimaryAxis.LabelCreated += (sender, e) =>
			{
				var date = DateTime.Parse(e.AxisLabel.LabelContent.ToString());
				NSDateFormatter formatter = new NSDateFormatter();
				if (date.Month != month)
				{
					SFAxisLabelStyle labelStyle = new SFAxisLabelStyle();
					formatter.DateFormat = new NSString("MMM-dd");
					labelStyle.LabelFormatter = formatter;
					labelStyle.Font = UIFont.FromName("Helvetica-Bold", 9);
					e.AxisLabel.LabelStyle = labelStyle;
					month = date.Month;
				}
				else
				{
					SFAxisLabelStyle labelStyle = new SFAxisLabelStyle();
					formatter.DateFormat = new NSString("dd");
					labelStyle.LabelFormatter = formatter;
					e.AxisLabel.LabelStyle = labelStyle;
				}
			};
			chart.PrimaryAxis.Title.Text = (NSString)"Production Across Years";

			chart.SecondaryAxis = new SFNumericalAxis();
			chart.SecondaryAxis.Title.Text = (NSString)"Growth (In Metric Tons)";

			ChartViewModel dataModel = new ChartViewModel();

			SFFastLineSeries series = new SFFastLineSeries();
			series.ColorModel.Palette = SFChartColorPalette.Natural;
			series.ItemsSource = dataModel.DateTimeAxisData;
			series.XBindingPath = "XValue";
			series.YBindingPath = "YValue";
			series.EnableTooltip = true;
			chart.Series.Add(series);

			SFChartZoomPanBehavior zoomPan = new SFChartZoomPanBehavior();
			zoomPan.EnableSelectionZooming = false;
			zoomPan.ZoomMode = SFChartZoomMode.X;

			chart.Behaviors.Add(zoomPan);

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
	}
}
