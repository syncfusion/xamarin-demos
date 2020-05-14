#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using Syncfusion.SfChart.iOS;
using UIKit;

namespace SampleBrowser
{
	public class DataMarker : SampleView
	{
		SFChart chart;
		public DataMarker()
		{
			chart 									= new SFChart();
			chart.Title.Text = new NSString("Population of India (2013 - 2016)");
			SFCategoryAxis primary 					= new SFCategoryAxis();
			primary.ShowMajorGridLines 				= false;
			primary.EdgeLabelsDrawingMode = SFChartAxisEdgeLabelsDrawingMode.Shift;
			primary.PlotOffset = 30;
			primary.AxisLineOffset = 30;
			chart.PrimaryAxis 						= primary;
			chart.SecondaryAxis 				 	= new SFNumericalAxis();
			chart.SecondaryAxis.ShowMajorGridLines 	= false;
			chart.SecondaryAxis.Minimum = new NSNumber(900);
			chart.SecondaryAxis.Maximum 			= new NSNumber(1300);
			chart.SecondaryAxis.Interval = new NSNumber(80);
			chart.SecondaryAxis.EdgeLabelsDrawingMode = SFChartAxisEdgeLabelsDrawingMode.Shift;
			chart.SecondaryAxis.Title.Text = new NSString("Population");
			ChartViewModel dataModel 				= new ChartViewModel();

			SFLineSeries series = new SFLineSeries();
			series.ItemsSource = dataModel.DataMarkerData1;
			series.XBindingPath = "XValue";
			series.YBindingPath = "YValue";
			series.DataMarker.LabelStyle.LabelPosition = SFChartDataMarkerLabelPosition.Center;
			series.DataMarker.ShowMarker = true;
			series.DataMarker.MarkerColor = UIColor.White;
			series.DataMarker.MarkerBorderColor = UIColor.FromRGBA(0.0f / 255.0f, 189.0f / 255.0f, 174.0f / 255.0f, 1.0f);
			series.DataMarker.MarkerBorderWidth = 2;
			series.DataMarker.MarkerWidth = 6f;
			series.DataMarker.MarkerHeight = 6f;
			series.DataMarker.LabelStyle.OffsetY = -18;
			series.DataMarker.ShowLabel = true;
			series.Label = "Male";
			chart.Series.Add(series);

			SFLineSeries series1 = new SFLineSeries();
            series1.ItemsSource = dataModel.DataMarkerData2;
            series1.XBindingPath = "XValue";
            series1.YBindingPath = "YValue";
            series1.DataMarker.LabelStyle.LabelPosition = SFChartDataMarkerLabelPosition.Center;
			series1.DataMarker.ShowMarker = true;
            series1.DataMarker.MarkerColor = UIColor.White;
			series1.DataMarker.MarkerBorderColor = UIColor.FromRGBA(64.0f / 255.0f, 64.0f / 255.0f, 65.0f / 255.0f, 1.0f);
			series1.DataMarker.MarkerBorderWidth = 2;
            series1.DataMarker.MarkerWidth = 6f;
            series1.DataMarker.MarkerHeight = 6f;
			series1.DataMarker.MarkerType = SFChartDataMarkerType.Square;
            series1.DataMarker.LabelStyle.OffsetY = 18;
            series1.DataMarker.ShowLabel = true;
			series1.Label = "Female";
            chart.Series.Add(series1);

			chart.Delegate 							= new ChartDataMarkerDelegate();
            chart.ColorModel.Palette = SFChartColorPalette.Natural;
			chart.Legend.Visible = true;
            chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.IconWidth = 14;
            chart.Legend.IconHeight = 14;
            chart.Legend.DockPosition = SFChartLegendPosition.Bottom;
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

	public class ChartDataMarkerDelegate : SFChartDelegate
	{
		public override UIView ViewForDataMarkerLabel(SFChart chart, NSString label, nint index, SFSeries series)
		{
			var dataPoint = (series.ItemsSource as IList<ChartDataModel>);

			UIView customView = new UIView();
			customView.Frame = new CGRect(0, 0, 63, 20);

            
			UIImageView imageView = new UIImageView();
			imageView.Frame = new CGRect(3, 2, 15, 15);

			UILabel value = new UILabel();
			value.Frame = new CGRect(25, 0, 35, 20);
			value.Font = UIFont.FromName("Helvetica", 10f);
			value.Text = label + "M";
			value.TextColor = UIColor.White;

			if (series.Label == "Male") 
			{
				imageView.Image = UIImage.FromBundle("Images/Male.png");
				customView.BackgroundColor = UIColor.FromRGBA(0.0f / 255.0f, 189.0f / 255.0f, 174.0f / 255.0f, 1.0f);
			}
			else
			{
				imageView.Image = UIImage.FromBundle("Images/Female.png");
				customView.BackgroundColor = UIColor.FromRGBA(64.0f / 255.0f, 64.0f / 255.0f, 65.0f / 255.0f, 1.0f);
			}

			customView.AddSubview(imageView);
			customView.AddSubview(value);
			return customView;
		}

		public override NSString GetFormattedAxisLabel(SFChart chart, NSString label, NSObject value, SFAxis axis)
        {
            if (axis == chart.SecondaryAxis)
            {
                String formattedLabel = label + "M";
                label = new NSString(formattedLabel);
                return label;
            }
            return label;
        }
	}
}

