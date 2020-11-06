#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfChart.iOS;

#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;

#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using nint	 = System.Int32;
using nuint	 = System.Int32;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
#endif

namespace SampleBrowser
{
	public class Tooltip : SampleView
	{
		public Tooltip()
		{
			SFChart chart = new SFChart();
			chart.Title.Text = new NSString("Efficiency of oil power Production");

			//Primary Axis

			SFCategoryAxis primaryAxis = new SFCategoryAxis();
			primaryAxis.PlotOffset = 10;
			primaryAxis.ShowMajorGridLines = false;
			primaryAxis.AxisLineStyle.LineWidth = new NSNumber(0.5);
			primaryAxis.Interval = new NSNumber(2);
			chart.PrimaryAxis = primaryAxis;

			// Secondary Axis

			SFNumericalAxis secondaryAxis = new SFNumericalAxis();
			secondaryAxis.EdgeLabelsDrawingMode = SFChartAxisEdgeLabelsDrawingMode.Shift;
			secondaryAxis.Maximum = new NSNumber(2.701);
			secondaryAxis.Minimum = new NSNumber(1.5);
			secondaryAxis.Interval = new NSNumber(0.2);
			secondaryAxis.AxisLineStyle.LineWidth = new NSNumber(0);
			secondaryAxis.LabelStyle.Font = UIFont.FromName("Helvetica", 12f);
			secondaryAxis.Title.Font = UIFont.FromName("Helvetica", 15f);
			secondaryAxis.MajorTickStyle.LineSize = 0;
			secondaryAxis.MajorGridLineStyle.LineWidth = new NSNumber(0.25);
			chart.SecondaryAxis = secondaryAxis;

			ChartViewModel dataModel = new ChartViewModel();

			SFSplineSeries series = new SFSplineSeries();
			series.ItemsSource = dataModel.TooltipData;
			series.XBindingPath = "XValue";
			series.YBindingPath = "YValue";
			series.EnableTooltip = true;
			//series.Color = UIColor.Orange;
            series.LineWidth = 2.5f;
			series.DataMarker.ShowMarker = true;
			series.DataMarker.MarkerType = SFChartDataMarkerType.Ellipse;
			series.DataMarker.MarkerHeight = 5;
			series.DataMarker.MarkerWidth = 5;
			series.DataMarker.MarkerBorderColor = UIColor.Black;
			series.DataMarker.MarkerColor = UIColor.FromRGBA(193.0f / 255.0f, 39.0f / 255.0f, 45.0f / 255.0f, 1.0f);
			series.EnableAnimation = true;
			chart.Series.Add(series);
			chart.Delegate = new ChartTooltipDelegate();
			SFChartTooltipBehavior behavior = new SFChartTooltipBehavior();
			behavior.BackgroundColor = UIColor.FromRGBA(193.0f / 255.0f, 39.0f / 255.0f, 45.0f / 255.0f, 1.0f);
			chart.AddChartBehavior(behavior);

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

	public class ChartTooltipDelegate : SFChartDelegate
	{
		public override void WillShowTooltip(SFChart chart, SFChartTooltip tooltipView)
		{
			UIView customView = new UIView();
			customView.Frame = new CGRect(0, 0, 80, 40);

			UIImageView imageView = new UIImageView();
			imageView.Frame = new CGRect(0, 0, 40, 40);
			imageView.Image = UIImage.FromBundle("Images/grain.png");

			UILabel xLabel = new UILabel();
			xLabel.Frame = new CGRect(47, 0, 35, 18);
			xLabel.TextColor = UIColor.Orange;
			xLabel.Font = UIFont.FromName("Helvetica", 12f);
			xLabel.Text = (tooltipView.DataPoint as ChartDataModel).XValue.ToString();

			UILabel yLabel = new UILabel();
			yLabel.Frame = new CGRect(47, 20, 35, 18);
			yLabel.TextColor = UIColor.White;
			yLabel.Font = UIFont.FromName("Helvetica", 15f);
			yLabel.Text = tooltipView.Text;

			customView.AddSubview(imageView);
			customView.AddSubview(xLabel);
			customView.AddSubview(yLabel);
			tooltipView.CustomView = customView;
		}
	}
}
